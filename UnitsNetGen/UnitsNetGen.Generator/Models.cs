// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Generic;

namespace UnitsNetGen.Generator;

internal sealed class QuantityDefinition
{
    public QuantityDefinition(string name, string targetNamespace, string baseUnit, IReadOnlyList<UnitDefinition> units, string? sourcePath = null)
    {
        Name = name;
        TargetNamespace = targetNamespace;
        BaseUnit = baseUnit;
        Units = units;
        SourcePath = sourcePath;
    }

    public string Name { get; }

    public string TargetNamespace { get; }

    public string BaseUnit { get; }

    public IReadOnlyList<UnitDefinition> Units { get; }

    public string? SourcePath { get; }

    public string Id => TargetNamespace + "." + Name;
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
