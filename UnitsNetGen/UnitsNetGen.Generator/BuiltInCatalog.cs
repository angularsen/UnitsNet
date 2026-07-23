// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace UnitsNetGen.Generator;

internal static class BuiltInCatalog
{
    private static readonly string[] QuantityNames =
    {
        "Length",
        "Mass",
        "Duration",
        "Area",
        "Speed",
        "Acceleration",
        "Force",
        "Pressure",
        "Energy",
        "Power",
        "Temperature",
        "TemperatureDelta",
        "Level",
        "Information",
    };

    private static readonly IReadOnlyDictionary<string, QuantityDefinition> Definitions = LoadDefinitions();

    public static bool TryGet(string name, out QuantityDefinition definition)
        => Definitions.TryGetValue(name, out definition!);

    private static IReadOnlyDictionary<string, QuantityDefinition> LoadDefinitions()
    {
        var definitions = new Dictionary<string, QuantityDefinition>(StringComparer.Ordinal);
        Assembly assembly = typeof(BuiltInCatalog).Assembly;
        foreach (string quantityName in QuantityNames)
        {
            string resourceName = $"UnitsNetGen.Generator.BuiltIns.{quantityName}.json";
            using Stream stream = assembly.GetManifestResourceStream(resourceName)
                ?? throw new InvalidOperationException($"Missing embedded built-in definition '{resourceName}'.");
            using var reader = new StreamReader(stream);
            JsonDefinitionResult result = JsonDefinitionParser.Parse(reader.ReadToEnd(), resourceName);
            if (result.Error is not null)
            {
                throw new InvalidOperationException(
                    $"Embedded built-in definition '{quantityName}' is invalid: {result.Error}");
            }

            definitions.Add(quantityName, result.Definition!.WithSemanticId("UnitsNet." + quantityName));
        }

        return definitions;
    }
}
