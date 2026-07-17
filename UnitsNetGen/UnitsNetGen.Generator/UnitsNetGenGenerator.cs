// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace UnitsNetGen.Generator;

[Generator]
public sealed class UnitsNetGenGenerator : IIncrementalGenerator
{
    private const string ModuleAttribute = "UnitsNetGen.Generation.UnitsNetModuleAttribute";
    private const string UnitSetAttribute = "UnitsNetGen.Generation.UnitSetAttribute";
    private const string QuantityAttribute = "UnitsNetGen.Generation.QuantityDefinitionAttribute";
    private const string UnitAttribute = "UnitsNetGen.Generation.UnitDefinitionAttribute";
    private const string GenerationNamespace = "UnitsNetGen.Generation";
    private const string BuiltInsNamespace = "UnitsNetGen.BuiltIns";

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

        context.RegisterSourceOutput(modules.Where(static module => module is not null).Collect(), Emit);
    }

    private static void Emit(SourceProductionContext context, ImmutableArray<INamedTypeSymbol?> moduleSymbols)
    {
        var requests = new Dictionary<string, SelectionRequest>(StringComparer.Ordinal);

        foreach (INamedTypeSymbol module in moduleSymbols.OfType<INamedTypeSymbol>())
        {
            foreach (INamedTypeSymbol inheritedInterface in module.AllInterfaces)
            {
                INamedTypeSymbol genericDefinition = inheritedInterface.OriginalDefinition;
                if (genericDefinition.Name != "IInclude" || genericDefinition.ContainingNamespace.ToDisplayString() != GenerationNamespace)
                {
                    continue;
                }

                ImmutableArray<ITypeSymbol> arguments = inheritedInterface.TypeArguments;
                if (arguments.Length is < 1 or > 2 || arguments[0] is not INamedTypeSymbol definitionMarker)
                {
                    continue;
                }

                QuantityDefinition? definition = ResolveDefinition(definitionMarker);
                if (definition is null)
                {
                    context.ReportDiagnostic(Diagnostic.Create(MissingDefinition, module.Locations.FirstOrDefault(), definitionMarker.ToDisplayString()));
                    continue;
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

                string? pattern = GetUnitSetPattern(arguments[1]);
                if (pattern is null)
                {
                    context.ReportDiagnostic(Diagnostic.Create(EmptyUnitSet, module.Locations.FirstOrDefault(), "<missing UnitSet attribute>", definition.Name));
                    continue;
                }

                request.Patterns.Add(pattern);
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
                    UnitDefinition[] matches = request.Definition.Units.Where(unit => Matches(pattern, unit.SingularName)).ToArray();
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

        var selectedNames = new HashSet<string>(selections.Select(selection => selection.Definition.Name), StringComparer.Ordinal);
        foreach (QuantitySelection selection in selections)
        {
            string hintName = selection.Definition.TargetNamespace.Replace('.', '_') + "_" + selection.Definition.Name + ".g.cs";
            context.AddSource(hintName, SourceText.From(QuantityEmitter.Emit(selection, selectedNames), System.Text.Encoding.UTF8));
        }
    }

    private static QuantityDefinition? ResolveDefinition(INamedTypeSymbol marker)
    {
        if (marker.ContainingNamespace.ToDisplayString() == BuiltInsNamespace && BuiltInCatalog.TryGet(marker.Name, out QuantityDefinition builtIn))
        {
            return builtIn;
        }

        AttributeData? quantityAttribute = marker.GetAttributes().FirstOrDefault(attribute => AttributeName(attribute) == QuantityAttribute);
        if (quantityAttribute is null || quantityAttribute.ConstructorArguments.Length != 2)
        {
            return null;
        }

        string name = (string?)quantityAttribute.ConstructorArguments[0].Value ?? marker.Name;
        string baseUnit = (string?)quantityAttribute.ConstructorArguments[1].Value ?? string.Empty;
        string targetNamespace = marker.ContainingNamespace.IsGlobalNamespace ? "UnitsNetGen.Custom" : marker.ContainingNamespace.ToDisplayString();
        foreach (KeyValuePair<string, TypedConstant> argument in quantityAttribute.NamedArguments)
        {
            if (argument.Key == "Namespace" && argument.Value.Value is string configuredNamespace && configuredNamespace.Length > 0)
            {
                targetNamespace = configuredNamespace;
            }
        }

        var units = new List<UnitDefinition>();
        foreach (AttributeData unitAttribute in marker.GetAttributes().Where(attribute => AttributeName(attribute) == UnitAttribute))
        {
            if (unitAttribute.ConstructorArguments.Length != 4)
            {
                continue;
            }

            string singularName = (string?)unitAttribute.ConstructorArguments[0].Value ?? string.Empty;
            string pluralName = (string?)unitAttribute.ConstructorArguments[1].Value ?? singularName;
            string abbreviation = (string?)unitAttribute.ConstructorArguments[2].Value ?? singularName;
            double scale = (double)(unitAttribute.ConstructorArguments[3].Value ?? 1d);
            double offset = 0;
            foreach (KeyValuePair<string, TypedConstant> argument in unitAttribute.NamedArguments)
            {
                if (argument.Key == "OffsetToBase" && argument.Value.Value is double configuredOffset)
                {
                    offset = configuredOffset;
                }
            }

            units.Add(new UnitDefinition(singularName, pluralName, abbreviation, scale, offset));
        }

        return new QuantityDefinition(name, targetNamespace, baseUnit, units);
    }

    private static string? GetUnitSetPattern(ITypeSymbol unitSet)
    {
        AttributeData? attribute = unitSet.GetAttributes().FirstOrDefault(candidate => AttributeName(candidate) == UnitSetAttribute);
        return attribute?.ConstructorArguments.Length == 1 ? attribute.ConstructorArguments[0].Value as string : null;
    }

    private static bool Matches(string pattern, string unitName)
    {
        if (pattern == "*")
        {
            return true;
        }

        bool startsWithWildcard = pattern.StartsWith("*", StringComparison.Ordinal);
        bool endsWithWildcard = pattern.EndsWith("*", StringComparison.Ordinal);
        string value = pattern.Trim('*');

        if (startsWithWildcard && endsWithWildcard)
        {
            return unitName.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        if (startsWithWildcard)
        {
            return unitName.EndsWith(value, StringComparison.OrdinalIgnoreCase);
        }

        if (endsWithWildcard)
        {
            return unitName.StartsWith(value, StringComparison.OrdinalIgnoreCase);
        }

        return string.Equals(unitName, value, StringComparison.OrdinalIgnoreCase);
    }

    private static bool HasAttribute(ISymbol symbol, string metadataName)
        => symbol.GetAttributes().Any(attribute => AttributeName(attribute) == metadataName);

    private static string? AttributeName(AttributeData attribute)
        => attribute.AttributeClass?.ToDisplayString();

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
