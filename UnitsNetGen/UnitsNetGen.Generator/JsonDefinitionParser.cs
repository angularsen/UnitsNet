// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.CodeAnalysis;

namespace UnitsNetGen.Generator;

internal static class JsonDefinitionParser
{
    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
    {
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };

    public static JsonDefinitionResult Parse(AdditionalText file, System.Threading.CancellationToken cancellationToken)
    {
        try
        {
            string json = file.GetText(cancellationToken)?.ToString() ?? string.Empty;
            JsonQuantity? parsed = JsonSerializer.Deserialize<JsonQuantity>(json, SerializerOptions);
            if (parsed is null)
            {
                return Error(file.Path, "The file did not contain a quantity definition.");
            }

            if (string.IsNullOrWhiteSpace(parsed.Name) || string.IsNullOrWhiteSpace(parsed.BaseUnit))
            {
                return Error(file.Path, "Name and BaseUnit are required.");
            }

            var units = new List<UnitDefinition>();
            foreach (JsonUnit unit in parsed.Units ?? Array.Empty<JsonUnit>())
            {
                if (string.IsNullOrWhiteSpace(unit.SingularName) || string.IsNullOrWhiteSpace(unit.PluralName))
                {
                    return Error(file.Path, "Every unit requires SingularName and PluralName.");
                }

                if (!ConversionExpression.TryNormalize(unit.FromUnitToBaseFunc, out string toBase, out string toBaseError))
                {
                    return Error(file.Path, $"{unit.SingularName}.FromUnitToBaseFunc: {toBaseError}");
                }

                if (!ConversionExpression.TryNormalize(unit.FromBaseToUnitFunc, out string fromBase, out string fromBaseError))
                {
                    return Error(file.Path, $"{unit.SingularName}.FromBaseToUnitFunc: {fromBaseError}");
                }

                UnitLocalizationDefinition[] localizations = (unit.Localization ?? Array.Empty<JsonLocalization>())
                    .Select(localization => new UnitLocalizationDefinition(
                        localization.Culture ?? string.Empty,
                        localization.Abbreviations ?? Array.Empty<string>(),
                        ParsePrefixAbbreviations(localization.AbbreviationsForPrefixes)))
                    .ToArray();

                units.Add(new UnitDefinition(
                    unit.SingularName!,
                    unit.PluralName!,
                    toBase,
                    fromBase,
                    localizations,
                    unit.Prefixes ?? Array.Empty<string>()));
            }

            string targetNamespace = string.IsNullOrWhiteSpace(parsed.Namespace) ? "UnitsNetGen" : parsed.Namespace!;
            var definition = new QuantityDefinition(parsed.Name!, targetNamespace, parsed.BaseUnit!, units, file.Path);
            return new JsonDefinitionResult(file.Path, PrefixExpander.Expand(definition), null);
        }
        catch (JsonException exception)
        {
            long line = exception.LineNumber.GetValueOrDefault() + 1;
            long position = exception.BytePositionInLine.GetValueOrDefault();
            return Error(file.Path, $"JSON line {line}, byte position {position}: {exception.Message}");
        }
        catch (Exception exception)
        {
            return Error(file.Path, exception.Message);
        }
    }

    private static IReadOnlyDictionary<string, IReadOnlyList<string>> ParsePrefixAbbreviations(
        IDictionary<string, JsonElement>? values)
    {
        var result = new Dictionary<string, IReadOnlyList<string>>(StringComparer.Ordinal);
        if (values is null)
        {
            return result;
        }

        foreach (KeyValuePair<string, JsonElement> value in values)
        {
            string[] abbreviations;
            if (value.Value.ValueKind == JsonValueKind.Array)
            {
                abbreviations = value.Value.EnumerateArray().Select(ReadAbbreviation).ToArray();
            }
            else
            {
                abbreviations = new[] { ReadAbbreviation(value.Value) };
            }

            result[value.Key] = abbreviations;
        }

        return result;
    }

    private static string ReadAbbreviation(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.String)
        {
            throw new JsonException("Prefix abbreviations must be strings or arrays of strings.");
        }

        return value.GetString() ?? string.Empty;
    }

    private static JsonDefinitionResult Error(string path, string error) => new JsonDefinitionResult(path, null, error);

    private sealed class JsonQuantity
    {
        public string? Name { get; set; }
        public string? Namespace { get; set; }
        public string? BaseUnit { get; set; }
        public JsonUnit[]? Units { get; set; }
    }

    private sealed class JsonUnit
    {
        public string? SingularName { get; set; }
        public string? PluralName { get; set; }
        public string? FromUnitToBaseFunc { get; set; }
        public string? FromBaseToUnitFunc { get; set; }
        public string[]? Prefixes { get; set; }
        public JsonLocalization[]? Localization { get; set; }
    }

    private sealed class JsonLocalization
    {
        public string? Culture { get; set; }
        public string[]? Abbreviations { get; set; }
        public Dictionary<string, JsonElement>? AbbreviationsForPrefixes { get; set; }
    }
}
