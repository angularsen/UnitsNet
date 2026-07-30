// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitsNet.Modular.Generator;

internal static class BuiltInCompanionCatalog
{
    private const string ResourceName = "UnitsNet.Modular.Generator.BuiltIns.Companions.json";

    private static readonly IReadOnlyDictionary<string, IReadOnlyList<CompanionTypeDefinition>> Companions =
        LoadCompanions();

    public static IReadOnlyList<CompanionTypeDefinition> Get(string semanticId) =>
        Companions.TryGetValue(semanticId, out IReadOnlyList<CompanionTypeDefinition>? companions)
            ? companions
            : Array.Empty<CompanionTypeDefinition>();

    private static IReadOnlyDictionary<string, IReadOnlyList<CompanionTypeDefinition>> LoadCompanions()
    {
        Assembly assembly = typeof(BuiltInCompanionCatalog).Assembly;
        using Stream stream = assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidOperationException($"Missing embedded built-in companion catalog '{ResourceName}'.");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() },
        };
        Dictionary<string, JsonCompanion[]> parsed =
            JsonSerializer.Deserialize<Dictionary<string, JsonCompanion[]>>(stream, options)
            ?? throw new InvalidOperationException("The built-in companion catalog is empty.");
        return parsed.ToDictionary(
            pair => pair.Key,
            pair => (IReadOnlyList<CompanionTypeDefinition>)pair.Value
                .Select(companion => new CompanionTypeDefinition(
                    companion.Kind,
                    companion.RequiredQuantities,
                    companion.RequiredUnits))
                .ToArray(),
            StringComparer.Ordinal);
    }

    private sealed class JsonCompanion
    {
        public CompanionTypeKind Kind { get; set; }

        public string[]? RequiredQuantities { get; set; }

        public string[]? RequiredUnits { get; set; }
    }
}
