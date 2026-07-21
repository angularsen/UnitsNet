// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Reflection;
using System.Text.Json;

namespace UnitsNetGen.Generator;

internal static class BuiltInUnitEnumValues
{
    private const string ResourceName = "UnitsNetGen.Generator.BuiltIns.UnitEnumValues.json";

    private static readonly IReadOnlyDictionary<string, Dictionary<string, int>> Values = Load();

    public static bool TryGet(string semanticId, string unitName, out int value)
    {
        const string prefix = "UnitsNet.";
        if (!semanticId.StartsWith(prefix, StringComparison.Ordinal))
        {
            value = default;
            return false;
        }

        string quantityName = semanticId.Substring(prefix.Length);
        value = default;
        return Values.TryGetValue(quantityName, out Dictionary<string, int>? units) &&
               units.TryGetValue(unitName, out value);
    }

    private static IReadOnlyDictionary<string, Dictionary<string, int>> Load()
    {
        Assembly assembly = typeof(BuiltInUnitEnumValues).Assembly;
        using Stream stream = assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidOperationException($"Missing embedded unit enum values '{ResourceName}'.");
        return JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, int>>>(
                   stream,
                   new JsonSerializerOptions
                   {
                       AllowTrailingCommas = true,
                       ReadCommentHandling = JsonCommentHandling.Skip,
                   })
               ?? throw new InvalidOperationException("The embedded unit enum value map was empty.");
    }
}
