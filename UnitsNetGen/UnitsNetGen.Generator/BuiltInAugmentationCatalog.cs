// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitsNetGen.Generator;

internal static class BuiltInAugmentationCatalog
{
    private const string ResourceName = "UnitsNetGen.Generator.BuiltIns.Augmentations.json";

    private static readonly IReadOnlyDictionary<string, IReadOnlyList<QuantityAugmentationDefinition>> Augmentations =
        LoadAugmentations();

    public static IReadOnlyList<QuantityAugmentationDefinition> Get(string semanticId) =>
        Augmentations.TryGetValue(semanticId, out IReadOnlyList<QuantityAugmentationDefinition>? augmentations)
            ? augmentations
            : Array.Empty<QuantityAugmentationDefinition>();

    private static IReadOnlyDictionary<string, IReadOnlyList<QuantityAugmentationDefinition>> LoadAugmentations()
    {
        Assembly assembly = typeof(BuiltInAugmentationCatalog).Assembly;
        using Stream stream = assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidOperationException($"Missing embedded built-in augmentation catalog '{ResourceName}'.");
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() },
        };
        Dictionary<string, JsonAugmentation[]> parsed =
            JsonSerializer.Deserialize<Dictionary<string, JsonAugmentation[]>>(stream, options)
            ?? throw new InvalidOperationException("The built-in augmentation catalog is empty.");
        return parsed.ToDictionary(
            pair => pair.Key,
            pair => (IReadOnlyList<QuantityAugmentationDefinition>)pair.Value
                .Select(augmentation => new QuantityAugmentationDefinition(
                    augmentation.Kind,
                    augmentation.RequiredQuantities,
                    augmentation.RequiredUnits))
                .ToArray(),
            StringComparer.Ordinal);
    }

    private sealed class JsonAugmentation
    {
        public QuantityAugmentationKind Kind { get; set; }

        public string[]? RequiredQuantities { get; set; }

        public string[]? RequiredUnits { get; set; }
    }
}
