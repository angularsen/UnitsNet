// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.Globalization;
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
        string json = file.GetText(cancellationToken)?.ToString() ?? string.Empty;
        return Parse(json, file.Path);
    }

    public static JsonDefinitionResult Parse(string json, string path)
    {
        try
        {
            JsonQuantity? parsed = JsonSerializer.Deserialize<JsonQuantity>(json, SerializerOptions);
            if (parsed is null)
            {
                return Error(path, "The file did not contain a quantity definition.");
            }

            if (string.IsNullOrWhiteSpace(parsed.Name) || string.IsNullOrWhiteSpace(parsed.BaseUnit))
            {
                return Error(path, "Name and BaseUnit are required.");
            }

            var units = new List<UnitDefinition>();
            foreach (JsonUnit unit in parsed.Units ?? Array.Empty<JsonUnit>())
            {
                if (string.IsNullOrWhiteSpace(unit.SingularName) || string.IsNullOrWhiteSpace(unit.PluralName))
                {
                    return Error(path, "Every unit requires SingularName and PluralName.");
                }

                if (!ConversionExpression.TryNormalize(unit.FromUnitToBaseFunc, out string toBase, out string toBaseError))
                {
                    return Error(path, $"{unit.SingularName}.FromUnitToBaseFunc: {toBaseError}");
                }

                if (!ConversionExpression.TryNormalize(unit.FromBaseToUnitFunc, out string fromBase, out string fromBaseError))
                {
                    return Error(path, $"{unit.SingularName}.FromBaseToUnitFunc: {fromBaseError}");
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
            bool isLogarithmic = bool.TryParse(parsed.Logarithmic, out bool logarithmic) && logarithmic;
            double logarithmicScalingFactor = double.TryParse(
                parsed.LogarithmicScalingFactor,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out double scalingFactor)
                    ? scalingFactor
                    : 1;
            var definition = new QuantityDefinition(
                parsed.Name!,
                targetNamespace,
                parsed.BaseUnit!,
                units,
                path,
                isLogarithmic,
                logarithmicScalingFactor,
                affineOffsetType: parsed.AffineOffsetType);
            return new JsonDefinitionResult(path, PrefixExpander.Expand(definition), null);
        }
        catch (JsonException exception)
        {
            long line = exception.LineNumber.GetValueOrDefault() + 1;
            long position = exception.BytePositionInLine.GetValueOrDefault();
            return Error(path, $"JSON line {line}, byte position {position}: {exception.Message}");
        }
        catch (Exception exception)
        {
            return Error(path, exception.Message);
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
        public string? Logarithmic { get; set; }
        public string? LogarithmicScalingFactor { get; set; }
        public string? AffineOffsetType { get; set; }
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
