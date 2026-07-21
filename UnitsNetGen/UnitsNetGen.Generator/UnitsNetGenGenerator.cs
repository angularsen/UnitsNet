// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

namespace UnitsNetGen.Generator;

[Generator]
public sealed class UnitsNetGenGenerator : IIncrementalGenerator
{
    private const string ModuleAttribute = "UnitsNetGen.Generation.UnitsNetModuleAttribute";
    private const string UnitSetAttribute = "UnitsNetGen.Generation.UnitSetAttribute";
    private const string QuantityAttribute = "UnitsNetGen.Generation.QuantityDefinitionAttribute";
    private const string GenerationNamespace = "UnitsNetGen.Generation";
    private const string BuiltInsNamespace = "UnitsNetGen.BuiltIns";
    private const string IncludeName = "IInclude";
    private const string IncludeProfileName = "IIncludeProfile";

    private static readonly DiagnosticDescriptor MissingDefinition = new DiagnosticDescriptor(
        "UNG001",
        "Quantity definition is missing",
        "Type '{0}' is selected as a quantity but has no UnitsNetGen quantity definition",
        "UnitsNetGen",
        DiagnosticSeverity.Error,
        true);

    private static readonly DiagnosticDescriptor EmptyUnitSet = new DiagnosticDescriptor(
        "UNG002",
        "Unit pattern matched no units",
        "Pattern '{0}' matched no units in quantity '{1}'",
        "UnitsNetGen",
        DiagnosticSeverity.Error,
        true);

    private static readonly DiagnosticDescriptor InvalidDefinition = new DiagnosticDescriptor(
        "UNG003",
        "Quantity definition is invalid",
        "Quantity '{0}' must define its base unit '{1}'",
        "UnitsNetGen",
        DiagnosticSeverity.Error,
        true);

    private static readonly DiagnosticDescriptor InvalidJsonDefinition = new DiagnosticDescriptor(
        "UNG004",
        "JSON quantity definition is invalid",
        "Definition file '{0}' is invalid: {1}",
        "UnitsNetGen",
        DiagnosticSeverity.Error,
        true);

    private static readonly DiagnosticDescriptor DuplicateDefinition = new DiagnosticDescriptor(
        "UNG005",
        "Quantity definition ID is duplicated",
        "Quantity definition ID '{0}' is provided by more than one JSON file",
        "UnitsNetGen",
        DiagnosticSeverity.Error,
        true);

    private static readonly DiagnosticDescriptor InvalidPattern = new DiagnosticDescriptor(
        "UNG006",
        "Unit selection pattern is invalid",
        "Pattern '{0}' for quantity '{1}' is invalid: {2}",
        "UnitsNetGen",
        DiagnosticSeverity.Error,
        true);

    private static readonly DiagnosticDescriptor InvalidRelationDefinition = new DiagnosticDescriptor(
        "UNG010",
        "Quantity relation definition is invalid",
        "Relation file '{0}' is invalid: {1}",
        "UnitsNetGen",
        DiagnosticSeverity.Error,
        true);

    private static readonly DiagnosticDescriptor InvalidRelationSet = new DiagnosticDescriptor(
        "UNG011",
        "Selected quantity relations are invalid",
        "{0}",
        "UnitsNetGen",
        DiagnosticSeverity.Error,
        true);

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterPostInitializationOutput(static output =>
            output.AddSource("UnitsNetGen.Markers.g.cs", SourceText.From(BootstrapSource.Text, System.Text.Encoding.UTF8)));

        IncrementalValuesProvider<INamedTypeSymbol?> modules = context.SyntaxProvider.CreateSyntaxProvider(
            static (node, _) => node is InterfaceDeclarationSyntax declaration && declaration.AttributeLists.Count > 0,
            static (syntaxContext, cancellationToken) =>
            {
                var declaration = (InterfaceDeclarationSyntax)syntaxContext.Node;
                INamedTypeSymbol? symbol = syntaxContext.SemanticModel.GetDeclaredSymbol(declaration, cancellationToken) as INamedTypeSymbol;
                return symbol is not null && HasAttribute(symbol, ModuleAttribute) ? symbol : null;
            });

        IncrementalValuesProvider<JsonDefinitionResult> jsonDefinitions = context.AdditionalTextsProvider
            .Combine(context.AnalyzerConfigOptionsProvider)
            .Where(static input => IsJsonDefinition(input.Left, input.Right))
            .Select(static (input, cancellationToken) => JsonDefinitionParser.Parse(input.Left, cancellationToken));

        IncrementalValuesProvider<RelationDefinitionResult> relationDefinitions = context.AdditionalTextsProvider
            .Combine(context.AnalyzerConfigOptionsProvider)
            .Where(static input => IsRelationDefinition(input.Left, input.Right))
            .Select(static (input, cancellationToken) => QuantityRelationParser.Parse(input.Left, cancellationToken));

        context.RegisterSourceOutput(
            modules.Where(static module => module is not null)
                .Collect()
                .Combine(jsonDefinitions.Collect())
                .Combine(relationDefinitions.Collect()),
            static (productionContext, input) => Emit(
                productionContext,
                input.Left.Left,
                input.Left.Right,
                input.Right));
    }

    private static void Emit(
        SourceProductionContext context,
        ImmutableArray<INamedTypeSymbol?> moduleSymbols,
        ImmutableArray<JsonDefinitionResult> jsonDefinitionResults,
        ImmutableArray<RelationDefinitionResult> relationDefinitionResults)
    {
        var jsonDefinitions = new Dictionary<string, QuantityDefinition>(StringComparer.Ordinal);
        foreach (JsonDefinitionResult result in jsonDefinitionResults)
        {
            if (result.Error is not null)
            {
                context.ReportDiagnostic(Diagnostic.Create(InvalidJsonDefinition, Location.None, result.Path, result.Error));
                continue;
            }

            QuantityDefinition definition = result.Definition!;
            if (jsonDefinitions.ContainsKey(definition.Id))
            {
                context.ReportDiagnostic(Diagnostic.Create(DuplicateDefinition, Location.None, definition.Id));
            }
            else
            {
                jsonDefinitions.Add(definition.Id, definition);
            }
        }

        var requests = new Dictionary<string, SelectionRequest>(StringComparer.Ordinal);
        bool emitUnitsNetCompatibilityContracts = false;

        foreach (INamedTypeSymbol module in moduleSymbols.OfType<INamedTypeSymbol>())
        {
            string? moduleNamespace = GetModuleTargetNamespace(module);
            emitUnitsNetCompatibilityContracts |= string.Equals(moduleNamespace, "UnitsNet", StringComparison.Ordinal);
            INamedTypeSymbol[] directIncludes = module.Interfaces.Where(IsInclude).ToArray();
            var directDefinitions = new HashSet<ITypeSymbol>(
                directIncludes
                    .Where(include => include.TypeArguments.Length > 0)
                    .Select(include => include.TypeArguments[0]),
                SymbolEqualityComparer.Default);
            IEnumerable<INamedTypeSymbol> profileIncludes = GetProfileIncludes(module)
                .Where(include => include.TypeArguments.Length > 0 && !directDefinitions.Contains(include.TypeArguments[0]));

            foreach (INamedTypeSymbol inheritedInterface in profileIncludes.Concat(directIncludes))
            {
                INamedTypeSymbol genericDefinition = inheritedInterface.OriginalDefinition;
                ImmutableArray<ITypeSymbol> arguments = inheritedInterface.TypeArguments;
                if (arguments.Length is < 1 or > 2 || arguments[0] is not INamedTypeSymbol definitionMarker)
                {
                    continue;
                }

                QuantityDefinition? definition = ResolveDefinition(definitionMarker, jsonDefinitions);
                if (definition is null)
                {
                    context.ReportDiagnostic(Diagnostic.Create(MissingDefinition, module.Locations.FirstOrDefault(), definitionMarker.ToDisplayString()));
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(moduleNamespace))
                {
                    definition = definition.WithTargetNamespace(moduleNamespace!);
                }

                string key = definition.TargetNamespace + "." + definition.Name;
                if (!requests.TryGetValue(key, out SelectionRequest? request))
                {
                    request = new SelectionRequest(definition);
                    requests.Add(key, request);
                }

                if (arguments.Length == 1)
                {
                    request.IncludeAll = true;
                    continue;
                }

                IReadOnlyList<string>? patterns = GetUnitSetPatterns(arguments[1]);
                if (patterns is null || patterns.Count == 0)
                {
                    context.ReportDiagnostic(Diagnostic.Create(EmptyUnitSet, module.Locations.FirstOrDefault(), "<missing UnitSet attribute>", definition.Name));
                    continue;
                }

                request.Patterns.UnionWith(patterns);
            }
        }

        var selections = new List<QuantitySelection>();
        foreach (SelectionRequest request in requests.Values.OrderBy(x => x.Definition.TargetNamespace, StringComparer.Ordinal).ThenBy(x => x.Definition.Name, StringComparer.Ordinal))
        {
            if (!request.Definition.Units.Any(unit => unit.SingularName == request.Definition.BaseUnit))
            {
                context.ReportDiagnostic(Diagnostic.Create(InvalidDefinition, Location.None, request.Definition.Name, request.Definition.BaseUnit));
                continue;
            }

            var selectedUnits = new List<UnitDefinition>();
            if (request.IncludeAll)
            {
                selectedUnits.AddRange(request.Definition.Units);
            }
            else
            {
                foreach (string pattern in request.Patterns)
                {
                    if (!TryCreateMatcher(pattern, out Func<string, bool>? matcher, out string patternError))
                    {
                        context.ReportDiagnostic(Diagnostic.Create(InvalidPattern, Location.None, pattern, request.Definition.Name, patternError));
                        continue;
                    }

                    UnitDefinition[] matches = request.Definition.Units.Where(unit => matcher(unit.SingularName)).ToArray();
                    if (matches.Length == 0)
                    {
                        context.ReportDiagnostic(Diagnostic.Create(EmptyUnitSet, Location.None, pattern, request.Definition.Name));
                    }

                    selectedUnits.AddRange(matches);
                }
            }

            UnitDefinition baseUnit = request.Definition.Units.First(unit => unit.SingularName == request.Definition.BaseUnit);
            selectedUnits.Insert(0, baseUnit);
            UnitDefinition[] distinctUnits = selectedUnits
                .GroupBy(unit => unit.SingularName, StringComparer.Ordinal)
                .Select(group => group.First())
                .ToArray();
            selections.Add(new QuantitySelection(request.Definition, distinctUnits));
        }

        var relationDefinitions = new List<QuantityRelationDefinition>(BuiltInRelationCatalog.Definitions);
        foreach (RelationDefinitionResult result in relationDefinitionResults)
        {
            if (result.Error is not null)
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    InvalidRelationDefinition,
                    Location.None,
                    result.Path,
                    result.Error));
                continue;
            }

            relationDefinitions.AddRange(result.Definitions!);
        }

        IReadOnlyList<QuantityRelation> expandedRelations = QuantityRelationParser.Expand(relationDefinitions);
        IReadOnlyDictionary<string, IReadOnlyList<EmittedQuantityRelation>> relationshipsByOwner =
            QuantityRelationPlanner.Plan(selections, expandedRelations, out IReadOnlyList<string> relationErrors);
        foreach (string error in relationErrors)
        {
            context.ReportDiagnostic(Diagnostic.Create(InvalidRelationSet, Location.None, error));
        }

        if (emitUnitsNetCompatibilityContracts)
        {
            context.AddSource(
                "UnitsNetGen.Compatibility.g.cs",
                SourceText.From(BootstrapSource.CompatibilityText, System.Text.Encoding.UTF8));
        }

        foreach (QuantitySelection selection in selections)
        {
            string ownerKey = selection.Definition.TargetNamespace + "." + selection.Definition.Name;
            IReadOnlyList<EmittedQuantityRelation> relationships =
                relationshipsByOwner.TryGetValue(ownerKey, out IReadOnlyList<EmittedQuantityRelation>? owned)
                    ? owned
                    : Array.Empty<EmittedQuantityRelation>();
            string hintName = selection.Definition.TargetNamespace.Replace('.', '_') + "_" + selection.Definition.Name + ".g.cs";
            context.AddSource(hintName, SourceText.From(QuantityEmitter.Emit(selection, relationships), System.Text.Encoding.UTF8));
        }
    }

    private static bool IsInclude(INamedTypeSymbol candidate)
    {
        INamedTypeSymbol definition = candidate.OriginalDefinition;
        return definition.Name == IncludeName &&
               definition.ContainingNamespace.ToDisplayString() == GenerationNamespace;
    }

    private static bool IsIncludeProfile(INamedTypeSymbol candidate)
    {
        INamedTypeSymbol definition = candidate.OriginalDefinition;
        return definition.Name == IncludeProfileName &&
               definition.ContainingNamespace.ToDisplayString() == GenerationNamespace;
    }

    private static IEnumerable<INamedTypeSymbol> GetProfileIncludes(INamedTypeSymbol module)
    {
        var includes = new List<INamedTypeSymbol>();
        var pending = new Queue<INamedTypeSymbol>();
        var visited = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);

        foreach (INamedTypeSymbol profileSelection in module.AllInterfaces.Where(IsIncludeProfile))
        {
            if (profileSelection.TypeArguments.Length == 1 &&
                profileSelection.TypeArguments[0] is INamedTypeSymbol profile)
            {
                pending.Enqueue(profile);
            }
        }

        while (pending.Count > 0)
        {
            INamedTypeSymbol profile = pending.Dequeue();
            if (!visited.Add(profile))
            {
                continue;
            }

            includes.AddRange(profile.AllInterfaces.Where(IsInclude));
            foreach (INamedTypeSymbol nestedSelection in profile.AllInterfaces.Where(IsIncludeProfile))
            {
                if (nestedSelection.TypeArguments.Length == 1 &&
                    nestedSelection.TypeArguments[0] is INamedTypeSymbol nestedProfile)
                {
                    pending.Enqueue(nestedProfile);
                }
            }
        }

        return includes;
    }

    private static string? GetModuleTargetNamespace(INamedTypeSymbol module)
    {
        AttributeData? moduleAttribute = module.GetAttributes()
            .FirstOrDefault(attribute => AttributeName(attribute) == ModuleAttribute);
        if (moduleAttribute?.ConstructorArguments.Length != 1)
        {
            return null;
        }

        return moduleAttribute.ConstructorArguments[0].Value as string;
    }

    private static QuantityDefinition? ResolveDefinition(
        INamedTypeSymbol marker,
        IReadOnlyDictionary<string, QuantityDefinition> jsonDefinitions)
    {
        if (marker.ContainingNamespace.ToDisplayString() == BuiltInsNamespace && BuiltInCatalog.TryGet(marker.Name, out QuantityDefinition builtIn))
        {
            return builtIn;
        }

        AttributeData? quantityAttribute = marker.GetAttributes().FirstOrDefault(attribute => AttributeName(attribute) == QuantityAttribute);
        if (quantityAttribute is null || quantityAttribute.ConstructorArguments.Length != 1)
        {
            return null;
        }

        string? id = quantityAttribute.ConstructorArguments[0].Value as string;
        return id is not null && jsonDefinitions.TryGetValue(id, out QuantityDefinition definition) ? definition : null;
    }

    private static IReadOnlyList<string>? GetUnitSetPatterns(ITypeSymbol unitSet)
    {
        AttributeData? attribute = unitSet.GetAttributes().FirstOrDefault(candidate => AttributeName(candidate) == UnitSetAttribute);
        if (attribute?.ConstructorArguments.Length != 1)
        {
            return null;
        }

        TypedConstant argument = attribute.ConstructorArguments[0];
        return argument.Kind == TypedConstantKind.Array
            ? argument.Values.Select(value => value.Value as string).Where(value => value is not null).Cast<string>().ToArray()
            : argument.Value is string value ? new[] { value } : null;
    }

    private static bool TryCreateMatcher(string pattern, out Func<string, bool> matcher, out string error)
    {
        try
        {
            bool isRegex = pattern.StartsWith("regex:", StringComparison.OrdinalIgnoreCase);
            string expression = isRegex ? pattern.Substring("regex:".Length) : pattern;
            if (!isRegex && expression.StartsWith("glob:", StringComparison.OrdinalIgnoreCase))
            {
                expression = expression.Substring("glob:".Length);
            }

            if (!isRegex)
            {
                expression = "^" + Regex.Escape(expression).Replace("\\*", ".*") + "$";
            }

            var regex = new Regex(
                expression,
                RegexOptions.CultureInvariant | RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(100));
            matcher = value =>
            {
                try
                {
                    return regex.IsMatch(value);
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
            };
            error = string.Empty;
            return true;
        }
        catch (ArgumentException exception)
        {
            matcher = _ => false;
            error = exception.Message;
            return false;
        }
    }

    private static bool HasAttribute(ISymbol symbol, string metadataName)
        => symbol.GetAttributes().Any(attribute => AttributeName(attribute) == metadataName);

    private static string? AttributeName(AttributeData attribute)
        => attribute.AttributeClass?.ToDisplayString();

    private static bool IsJsonDefinition(AdditionalText file, AnalyzerConfigOptionsProvider optionsProvider)
    {
        if (file.Path.EndsWith(".unitsnet.json", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        return optionsProvider.GetOptions(file).TryGetValue(
                   "build_metadata.AdditionalFiles.UnitsNetGenDefinition",
                   out string? value) &&
               string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsRelationDefinition(AdditionalText file, AnalyzerConfigOptionsProvider optionsProvider)
    {
        if (file.Path.EndsWith(".unitsnet.relations.json", StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        return optionsProvider.GetOptions(file).TryGetValue(
                   "build_metadata.AdditionalFiles.UnitsNetGenRelation",
                   out string? value) &&
               string.Equals(value, "true", StringComparison.OrdinalIgnoreCase);
    }

    private sealed class SelectionRequest
    {
        public SelectionRequest(QuantityDefinition definition)
        {
            Definition = definition;
        }

        public QuantityDefinition Definition { get; }

        public bool IncludeAll { get; set; }

        public HashSet<string> Patterns { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    }
}
