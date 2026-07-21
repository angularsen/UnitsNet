// Licensed under MIT No Attribution, see LICENSE file at the root.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.CodeAnalysis;

namespace UnitsNetGen.Generator;

internal static class QuantityRelationParser
{
    private const string NoInferredDivision = "NoInferredDivision";

    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
    {
        AllowTrailingCommas = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
    };

    public static RelationDefinitionResult Parse(
        AdditionalText file,
        System.Threading.CancellationToken cancellationToken)
    {
        string json = file.GetText(cancellationToken)?.ToString() ?? string.Empty;
        return Parse(json, file.Path);
    }

    public static RelationDefinitionResult Parse(string json, string path)
    {
        try
        {
            string[]? relationStrings = JsonSerializer.Deserialize<string[]>(json, SerializerOptions);
            if (relationStrings is null)
            {
                return Error(path, "The file did not contain a relation array.");
            }

            var definitions = new List<QuantityRelationDefinition>();
            foreach (string relationString in relationStrings)
            {
                definitions.Add(ParseRelation(relationString));
            }

            return new RelationDefinitionResult(path, definitions, null);
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

    public static IReadOnlyList<QuantityRelation> Expand(
        IEnumerable<QuantityRelationDefinition> definitions)
    {
        var relations = definitions
            .Select(definition => new QuantityRelation(
                definition.Result.Quantity == "1" ? "inverse" : "*",
                definition.Result,
                definition.Left,
                definition.Right,
                definition.NoInferredDivision,
                definition.Source))
            .ToList();

        relations.AddRange(relations
            .Where(relation =>
                (relation.Operator == "*" || relation.Operator == "inverse") &&
                relation.Left.Quantity != relation.Right.Quantity)
            .Select(relation => new QuantityRelation(
                relation.Operator,
                relation.Result,
                relation.Right,
                relation.Left,
                relation.NoInferredDivision,
                relation.Source))
            .ToArray());

        relations.AddRange(relations
            .Where(relation =>
                relation.Operator == "*" &&
                !relation.NoInferredDivision)
            .Select(relation => new QuantityRelation(
                "/",
                relation.Left,
                relation.Result,
                relation.Right,
                false,
                relation.Source))
            .Where(relation => relation.Left.Quantity != relation.Right.Quantity)
            .ToArray());

        return relations
            .OrderBy(relation => relation.Key, StringComparer.Ordinal)
            .ToArray();
    }

    private static QuantityRelationDefinition ParseRelation(string relationString)
    {
        string[] segments = relationString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (segments.Length < 5 || segments[1] != "=" || segments[3] != "*")
        {
            throw new FormatException($"Invalid relation '{relationString}'. Expected 'Result.Unit = Left.Unit * Right.Unit'.");
        }

        bool noInferredDivision = segments.Skip(5).Contains(NoInferredDivision, StringComparer.Ordinal);
        if (segments.Length > 5 &&
            !(segments.Length == 7 && segments[5] == "--" && noInferredDivision))
        {
            throw new FormatException($"Invalid relation suffix in '{relationString}'.");
        }

        return new QuantityRelationDefinition(
            ParseEndpoint(segments[0], relationString),
            ParseEndpoint(segments[2], relationString),
            ParseEndpoint(segments[4], relationString),
            noInferredDivision,
            relationString);
    }

    private static RelationEndpoint ParseEndpoint(string text, string relationString)
    {
        if (text is "1" or "double")
        {
            return new RelationEndpoint(text, null);
        }

        string[] segments = text.Split('.');
        if (segments.Length != 2 || segments.Any(string.IsNullOrWhiteSpace))
        {
            throw new FormatException($"Invalid endpoint '{text}' in relation '{relationString}'.");
        }

        return new RelationEndpoint(segments[0], segments[1]);
    }

    private static RelationDefinitionResult Error(string path, string error)
        => new RelationDefinitionResult(path, null, error);
}
