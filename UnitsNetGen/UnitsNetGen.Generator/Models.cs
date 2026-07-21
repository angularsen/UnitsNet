// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Generic;

namespace UnitsNetGen.Generator;

internal sealed class QuantityDefinition
{
    public QuantityDefinition(
        string name,
        string targetNamespace,
        string baseUnit,
        IReadOnlyList<UnitDefinition> units,
        string? sourcePath = null,
        bool isLogarithmic = false,
        double logarithmicScalingFactor = 1,
        string? semanticId = null)
    {
        Name = name;
        TargetNamespace = targetNamespace;
        BaseUnit = baseUnit;
        Units = units;
        SourcePath = sourcePath;
        IsLogarithmic = isLogarithmic;
        LogarithmicScalingFactor = logarithmicScalingFactor;
        SemanticId = semanticId ?? targetNamespace + "." + name;
    }

    public string Name { get; }

    public string TargetNamespace { get; }

    public string BaseUnit { get; }

    public IReadOnlyList<UnitDefinition> Units { get; }

    public string? SourcePath { get; }

    public bool IsLogarithmic { get; }

    public double LogarithmicScalingFactor { get; }

    public string Id => SemanticId;

    public string SemanticId { get; }

    public QuantityDefinition WithTargetNamespace(string targetNamespace)
        => new QuantityDefinition(
            Name,
            targetNamespace,
            BaseUnit,
            Units,
            SourcePath,
            IsLogarithmic,
            LogarithmicScalingFactor,
            SemanticId);

    public QuantityDefinition WithSemanticId(string semanticId)
        => new QuantityDefinition(
            Name,
            TargetNamespace,
            BaseUnit,
            Units,
            SourcePath,
            IsLogarithmic,
            LogarithmicScalingFactor,
            semanticId);
}

internal sealed class UnitDefinition
{
    public UnitDefinition(
        string singularName,
        string pluralName,
        string fromUnitToBaseExpression,
        string fromBaseToUnitExpression,
        IReadOnlyList<UnitLocalizationDefinition> localizations,
        IReadOnlyList<string>? prefixes = null)
    {
        SingularName = singularName;
        PluralName = pluralName;
        FromUnitToBaseExpression = fromUnitToBaseExpression;
        FromBaseToUnitExpression = fromBaseToUnitExpression;
        Localizations = localizations;
        Prefixes = prefixes ?? Array.Empty<string>();
    }

    public string SingularName { get; }

    public string PluralName { get; }

    public string FromUnitToBaseExpression { get; }

    public string FromBaseToUnitExpression { get; }

    public IReadOnlyList<UnitLocalizationDefinition> Localizations { get; }

    public IReadOnlyList<string> Prefixes { get; }
}

internal sealed class UnitLocalizationDefinition
{
    public UnitLocalizationDefinition(
        string culture,
        IReadOnlyList<string> abbreviations,
        IReadOnlyDictionary<string, IReadOnlyList<string>>? abbreviationsForPrefixes = null)
    {
        Culture = culture;
        Abbreviations = abbreviations;
        AbbreviationsForPrefixes = abbreviationsForPrefixes ?? new Dictionary<string, IReadOnlyList<string>>();
    }

    public string Culture { get; }

    public IReadOnlyList<string> Abbreviations { get; }

    public IReadOnlyDictionary<string, IReadOnlyList<string>> AbbreviationsForPrefixes { get; }
}

internal sealed class QuantitySelection
{
    public QuantitySelection(QuantityDefinition definition, IReadOnlyList<UnitDefinition> units)
    {
        Definition = definition;
        Units = units;
    }

    public QuantityDefinition Definition { get; }

    public IReadOnlyList<UnitDefinition> Units { get; }
}

internal sealed class JsonDefinitionResult
{
    public JsonDefinitionResult(string path, QuantityDefinition? definition, string? error)
    {
        Path = path;
        Definition = definition;
        Error = error;
    }

    public string Path { get; }

    public QuantityDefinition? Definition { get; }

    public string? Error { get; }
}

internal sealed class QuantityRelationDefinition
{
    public QuantityRelationDefinition(
        RelationEndpoint result,
        RelationEndpoint left,
        RelationEndpoint right,
        bool noInferredDivision,
        string source)
    {
        Result = result;
        Left = left;
        Right = right;
        NoInferredDivision = noInferredDivision;
        Source = source;
    }

    public RelationEndpoint Result { get; }

    public RelationEndpoint Left { get; }

    public RelationEndpoint Right { get; }

    public bool NoInferredDivision { get; }

    public string Source { get; }
}

internal sealed class RelationEndpoint
{
    public RelationEndpoint(string quantity, string? unit)
    {
        Quantity = quantity;
        Unit = unit;
    }

    public string Quantity { get; }

    public string? Unit { get; }
}

internal sealed class QuantityRelation
{
    public QuantityRelation(
        string @operator,
        RelationEndpoint result,
        RelationEndpoint left,
        RelationEndpoint right,
        bool noInferredDivision,
        string source)
    {
        Operator = @operator;
        Result = result;
        Left = left;
        Right = right;
        NoInferredDivision = noInferredDivision;
        Source = source;
    }

    public string Operator { get; }

    public RelationEndpoint Result { get; }

    public RelationEndpoint Left { get; }

    public RelationEndpoint Right { get; }

    public bool NoInferredDivision { get; }

    public string Source { get; }

    public string Key => Result.Quantity + "." + Result.Unit + " = " +
                         Left.Quantity + "." + Left.Unit + " " + Operator + " " +
                         Right.Quantity + "." + Right.Unit;
}

internal sealed class RelationDefinitionResult
{
    public RelationDefinitionResult(
        string path,
        IReadOnlyList<QuantityRelationDefinition>? definitions,
        string? error)
    {
        Path = path;
        Definitions = definitions;
        Error = error;
    }

    public string Path { get; }

    public IReadOnlyList<QuantityRelationDefinition>? Definitions { get; }

    public string? Error { get; }
}

internal sealed class EmittedQuantityRelation
{
    public EmittedQuantityRelation(
        string @operator,
        QuantitySelection? result,
        UnitDefinition? resultUnit,
        QuantitySelection left,
        UnitDefinition leftUnit,
        QuantitySelection right,
        UnitDefinition rightUnit,
        string source)
    {
        Operator = @operator;
        Result = result;
        ResultUnit = resultUnit;
        Left = left;
        LeftUnit = leftUnit;
        Right = right;
        RightUnit = rightUnit;
        Source = source;
    }

    public string Operator { get; }

    public QuantitySelection? Result { get; }

    public UnitDefinition? ResultUnit { get; }

    public QuantitySelection Left { get; }

    public UnitDefinition LeftUnit { get; }

    public QuantitySelection Right { get; }

    public UnitDefinition RightUnit { get; }

    public string Source { get; }

    public string Key => Result?.Definition.Name + "." + ResultUnit?.SingularName + " = " +
                         Left.Definition.Name + "." + LeftUnit.SingularName + " " + Operator + " " +
                         Right.Definition.Name + "." + RightUnit.SingularName;
}
