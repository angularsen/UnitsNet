// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace UnitsNet.Modular.Generator;

internal static class BuiltInCatalog
{
    private const string ResourcePrefix = "UnitsNet.Modular.Generator.BuiltIns.Quantities.";
    private const string ResourceSuffix = ".json";

    private static readonly IReadOnlyDictionary<string, QuantityDefinition> ParsedDefinitions = LoadDefinitions();
    internal static readonly PrefixExpander.BaseUnitPrefixCatalog BaseUnitPrefixes =
        PrefixExpander.BaseUnitPrefixCatalog.Create(ParsedDefinitions.Values);
    private static readonly IReadOnlyDictionary<string, QuantityDefinition> Definitions =
        ParsedDefinitions.ToDictionary(
            pair => pair.Key,
            pair => PrefixExpander.Expand(pair.Value, BaseUnitPrefixes),
            StringComparer.Ordinal);

    public static IReadOnlyList<string> Names { get; } =
        Definitions.Keys.OrderBy(name => name, StringComparer.Ordinal).ToArray();

    public static bool TryGet(string name, out QuantityDefinition definition)
        => Definitions.TryGetValue(name, out definition!);

    public static PrefixExpander.BaseUnitPrefixCatalog CreateBaseUnitPrefixes(
        IEnumerable<QuantityDefinition> additionalDefinitions) =>
        PrefixExpander.BaseUnitPrefixCatalog.Create(
            ParsedDefinitions.Values.Concat(additionalDefinitions));

    private static IReadOnlyDictionary<string, QuantityDefinition> LoadDefinitions()
    {
        var definitions = new Dictionary<string, QuantityDefinition>(StringComparer.Ordinal);
        Assembly assembly = typeof(BuiltInCatalog).Assembly;
        string[] resourceNames = assembly.GetManifestResourceNames()
            .Where(name => name.StartsWith(ResourcePrefix, StringComparison.Ordinal) &&
                           name.EndsWith(ResourceSuffix, StringComparison.Ordinal))
            .OrderBy(name => name, StringComparer.Ordinal)
            .ToArray();
        foreach (string resourceName in resourceNames)
        {
            using Stream stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new InvalidOperationException($"Missing embedded built-in definition '{resourceName}'.");
            using var reader = new StreamReader(stream);
            JsonDefinitionResult result = JsonDefinitionParser.Parse(reader.ReadToEnd(), resourceName);
            if (result.Error is not null)
            {
                throw new InvalidOperationException(
                    $"Embedded built-in definition '{resourceName}' is invalid: {result.Error}");
            }

            string semanticId = "UnitsNet." + result.Definition!.Name;
            QuantityDefinition definition = result.Definition
                .WithSemanticId(semanticId)
                .WithAugmentations(BuiltInAugmentationCatalog.Get(semanticId));
            definitions.Add(definition.Name, definition);
        }

        return definitions;
    }
}
