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
        PropertyNameCaseInsensitive = true,
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
            using JsonDocument document = JsonDocument.Parse(
                json,
                new JsonDocumentOptions
                {
                    AllowTrailingCommas = true,
                    CommentHandling = JsonCommentHandling.Skip,
                });
            if (document.RootElement.ValueKind != JsonValueKind.Array)
            {
                return Error(path, "The file did not contain a relation array.");
            }

            var definitions = new List<QuantityRelationDefinition>();
            int index = 0;
            foreach (JsonElement element in document.RootElement.EnumerateArray())
            {
                if (element.ValueKind == JsonValueKind.String)
                {
                    definitions.Add(ParseRelation(element.GetString()!));
                }
                else if (element.ValueKind == JsonValueKind.Object)
                {
                    definitions.Add(ParseStructuredRelation(element, path, index));
                }
                else
                {
                    throw new FormatException(
                        $"Relation at index {index} must be a string or structured relation object.");
                }

                index++;
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

    public static IReadOnlyList<QuantityRelationDefinition> QualifyQuantityIds(
        IEnumerable<QuantityRelationDefinition> definitions,
        string quantityNamespace) => definitions
        .Select(definition => new QuantityRelationDefinition(
            Qualify(definition.Result, quantityNamespace),
            Qualify(definition.Left, quantityNamespace),
            Qualify(definition.Right, quantityNamespace),
            definition.NoInferredDivision,
            definition.Source))
        .ToArray();

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

    private static QuantityRelationDefinition ParseStructuredRelation(
        JsonElement element,
        string path,
        int index)
    {
        var relation = element.Deserialize<StructuredRelation>(SerializerOptions)
            ?? throw new FormatException($"Relation at index {index} was empty.");
        if (!string.IsNullOrWhiteSpace(relation.Operator) && relation.Operator != "*")
        {
            throw new FormatException(
                $"Relation at index {index} uses unsupported operator '{relation.Operator}'. Expected '*'.");
        }

        return new QuantityRelationDefinition(
            StructuredEndpoint(relation.Result, "result", index),
            StructuredEndpoint(relation.Left, "left", index),
            StructuredEndpoint(relation.Right, "right", index),
            relation.NoInferredDivision,
            $"{path} relation {index + 1}");
    }

    private static RelationEndpoint StructuredEndpoint(
        StructuredRelationEndpoint? endpoint,
        string role,
        int index)
    {
        if (endpoint is null || string.IsNullOrWhiteSpace(endpoint.Quantity))
        {
            throw new FormatException($"Relation at index {index} has no {role} quantity ID.");
        }

        if (endpoint.Quantity is not ("1" or "double") && string.IsNullOrWhiteSpace(endpoint.Unit))
        {
            throw new FormatException($"Relation at index {index} has no {role} unit.");
        }

        return new RelationEndpoint(endpoint.Quantity!, endpoint.Unit);
    }

    private static RelationEndpoint Qualify(RelationEndpoint endpoint, string quantityNamespace) =>
        endpoint.Quantity is "1" or "double" || endpoint.Quantity.Contains('.')
            ? endpoint
            : new RelationEndpoint(quantityNamespace + "." + endpoint.Quantity, endpoint.Unit);

    private sealed class StructuredRelation
    {
        public StructuredRelationEndpoint? Result { get; set; }

        public StructuredRelationEndpoint? Left { get; set; }

        public StructuredRelationEndpoint? Right { get; set; }

        public string? Operator { get; set; }

        public bool NoInferredDivision { get; set; }
    }

    private sealed class StructuredRelationEndpoint
    {
        public string? Quantity { get; set; }

        public string? Unit { get; set; }
    }

    private static RelationDefinitionResult Error(string path, string error)
        => new RelationDefinitionResult(path, null, error);
}
