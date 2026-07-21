// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace UnitsNetGen.Generator;

internal static class BuiltInRelationCatalog
{
    private const string ResourceName = "UnitsNetGen.Generator.BuiltIns.UnitRelations.json";

    public static IReadOnlyList<QuantityRelationDefinition> Definitions { get; } = LoadDefinitions();

    private static IReadOnlyList<QuantityRelationDefinition> LoadDefinitions()
    {
        Assembly assembly = typeof(BuiltInRelationCatalog).Assembly;
        using Stream stream = assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidOperationException($"Missing embedded built-in relation catalog '{ResourceName}'.");
        using var reader = new StreamReader(stream);
        RelationDefinitionResult result = QuantityRelationParser.Parse(reader.ReadToEnd(), ResourceName);
        if (result.Error is not null)
        {
            throw new InvalidOperationException($"Embedded built-in relation catalog is invalid: {result.Error}");
        }

        return result.Definitions!;
    }
}
