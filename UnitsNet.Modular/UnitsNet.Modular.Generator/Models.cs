// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Security.Cryptography;
using System.Text;

namespace UnitsNet.Modular.Generator;

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
        string? semanticId = null,
        string? affineOffsetType = null,
        BaseDimensionsDefinition? baseDimensions = null,
        IReadOnlyList<QuantityAugmentationDefinition>? augmentations = null)
    {
        Name = name;
        TargetNamespace = targetNamespace;
        BaseUnit = baseUnit;
        Units = units;
        SourcePath = sourcePath;
        IsLogarithmic = isLogarithmic;
        LogarithmicScalingFactor = logarithmicScalingFactor;
        SemanticId = semanticId ?? targetNamespace + "." + name;
        AffineOffsetType = affineOffsetType;
        BaseDimensions = baseDimensions ?? BaseDimensionsDefinition.Dimensionless;
        Augmentations = augmentations ?? Array.Empty<QuantityAugmentationDefinition>();
    }

    public string Name { get; }

    public string TargetNamespace { get; }

    public string BaseUnit { get; }

    public IReadOnlyList<UnitDefinition> Units { get; }

    public string? SourcePath { get; }

    public bool IsLogarithmic { get; }

    public double LogarithmicScalingFactor { get; }

    public string? AffineOffsetType { get; }

    public bool IsAffine => !string.IsNullOrWhiteSpace(AffineOffsetType);

    public BaseDimensionsDefinition BaseDimensions { get; }

    public IReadOnlyList<QuantityAugmentationDefinition> Augmentations { get; }

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
            SemanticId,
            AffineOffsetType,
            BaseDimensions,
            Augmentations);

    public QuantityDefinition WithSemanticId(string semanticId)
        => new QuantityDefinition(
            Name,
            TargetNamespace,
            BaseUnit,
            Units,
            SourcePath,
            IsLogarithmic,
            LogarithmicScalingFactor,
            semanticId,
            AffineOffsetType,
            BaseDimensions,
            Augmentations);

    public QuantityDefinition WithAugmentations(IReadOnlyList<QuantityAugmentationDefinition> augmentations)
        => new QuantityDefinition(
            Name,
            TargetNamespace,
            BaseUnit,
            Units,
            SourcePath,
            IsLogarithmic,
            LogarithmicScalingFactor,
            SemanticId,
            AffineOffsetType,
            BaseDimensions,
            augmentations);
}

internal sealed class QuantityAugmentationDefinition
{
    public QuantityAugmentationDefinition(
        QuantityAugmentationKind kind,
        IReadOnlyList<string>? requiredQuantities = null,
        IReadOnlyList<string>? requiredUnits = null)
    {
        Kind = kind;
        RequiredQuantities = requiredQuantities ?? Array.Empty<string>();
        RequiredUnits = requiredUnits ?? Array.Empty<string>();
    }

    public QuantityAugmentationKind Kind { get; }

    public IReadOnlyList<string> RequiredQuantities { get; }

    public IReadOnlyList<string> RequiredUnits { get; }
}

internal enum QuantityAugmentationKind
{
    DurationTimeSpan,
    AreaCircle,
    MassFractionMass,
    ForcePressureArea,
    ForceMassAcceleration,
    MassGravitationalForce,
    AmountOfSubstanceParticles,
    AmountOfSubstanceMass,
    MassConcentrationMolarity,
    MassConcentrationVolumeConcentration,
    MolarityMassConcentration,
    MolarityVolumeConcentration,
    VolumeConcentrationMassConcentration,
    VolumeConcentrationMolarity,
    VolumeConcentrationVolumes,
    ElectricApparentPowerDivision,
    EnergyDensityCombustionEnergy,
    AmplitudeRatioElectricPotential,
    AmplitudeRatioPowerRatio,
    ElectricPotentialAmplitudeRatio,
    LevelRatio,
    PowerPowerRatio,
    PowerRatioPower,
    PowerRatioAmplitudeRatio,
    LengthFeetInches,
    MassStonePounds,
}

internal sealed class CompanionTypeDefinition
{
    public CompanionTypeDefinition(
        CompanionTypeKind kind,
        IReadOnlyList<string>? requiredQuantities = null,
        IReadOnlyList<string>? requiredUnits = null)
    {
        Kind = kind;
        RequiredQuantities = requiredQuantities ?? Array.Empty<string>();
        RequiredUnits = requiredUnits ?? Array.Empty<string>();
    }

    public CompanionTypeKind Kind { get; }

    public IReadOnlyList<string> RequiredQuantities { get; }

    public IReadOnlyList<string> RequiredUnits { get; }
}

internal enum CompanionTypeKind
{
    FeetInches,
    StonePounds,
    ReferencePressure,
}

internal sealed class BaseDimensionsDefinition
{
    public static BaseDimensionsDefinition Dimensionless { get; } = new BaseDimensionsDefinition(0, 0, 0, 0, 0, 0, 0);

    public BaseDimensionsDefinition(
        int length,
        int mass,
        int time,
        int current,
        int temperature,
        int amount,
        int luminousIntensity)
    {
        Length = length;
        Mass = mass;
        Time = time;
        Current = current;
        Temperature = temperature;
        Amount = amount;
        LuminousIntensity = luminousIntensity;
    }

    public int Length { get; }

    public int Mass { get; }

    public int Time { get; }

    public int Current { get; }

    public int Temperature { get; }

    public int Amount { get; }

    public int LuminousIntensity { get; }
}

internal sealed class UnitDefinition
{
    public UnitDefinition(
        string singularName,
        string pluralName,
        string fromUnitToBaseExpression,
        string fromBaseToUnitExpression,
        BaseUnitsDefinition baseUnits,
        IReadOnlyList<UnitLocalizationDefinition> localizations,
        IReadOnlyList<string>? prefixes = null)
    {
        SingularName = singularName;
        PluralName = pluralName;
        FromUnitToBaseExpression = fromUnitToBaseExpression;
        FromBaseToUnitExpression = fromBaseToUnitExpression;
        BaseUnits = baseUnits;
        Localizations = localizations;
        Prefixes = prefixes ?? Array.Empty<string>();
    }

    public string SingularName { get; }

    public string PluralName { get; }

    public string FromUnitToBaseExpression { get; }

    public string FromBaseToUnitExpression { get; }

    public BaseUnitsDefinition BaseUnits { get; }

    public IReadOnlyList<UnitLocalizationDefinition> Localizations { get; }

    public IReadOnlyList<string> Prefixes { get; }
}

internal sealed class BaseUnitsDefinition
{
    public static BaseUnitsDefinition Undefined { get; } =
        new BaseUnitsDefinition(null, null, null, null, null, null, null);

    public BaseUnitsDefinition(
        string? length,
        string? mass,
        string? time,
        string? current,
        string? temperature,
        string? amount,
        string? luminousIntensity)
    {
        Length = length;
        Mass = mass;
        Time = time;
        Current = current;
        Temperature = temperature;
        Amount = amount;
        LuminousIntensity = luminousIntensity;
    }

    public string? Length { get; }

    public string? Mass { get; }

    public string? Time { get; }

    public string? Current { get; }

    public string? Temperature { get; }

    public string? Amount { get; }

    public string? LuminousIntensity { get; }

    public bool IsUndefined =>
        Length is null &&
        Mass is null &&
        Time is null &&
        Current is null &&
        Temperature is null &&
        Amount is null &&
        LuminousIntensity is null;

    public BaseUnitsDefinition Rename(string fromUnitName, string toUnitName) =>
        new BaseUnitsDefinition(
            Rename(Length, fromUnitName, toUnitName),
            Rename(Mass, fromUnitName, toUnitName),
            Rename(Time, fromUnitName, toUnitName),
            Rename(Current, fromUnitName, toUnitName),
            Rename(Temperature, fromUnitName, toUnitName),
            Rename(Amount, fromUnitName, toUnitName),
            Rename(LuminousIntensity, fromUnitName, toUnitName));

    private static string? Rename(string? value, string fromUnitName, string toUnitName) =>
        string.Equals(value, fromUnitName, StringComparison.Ordinal) ? toUnitName : value;
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
    public JsonDefinitionResult(
        string path,
        QuantityDefinition? definition,
        string? error,
        string content,
        int errorLine = 0,
        int errorColumn = 0)
    {
        Path = path;
        Definition = definition;
        Error = error;
        ContentFingerprint = AdditionalFileFingerprint.Create(content);
        ErrorLine = errorLine;
        ErrorColumn = errorColumn;
    }

    public string Path { get; }

    public QuantityDefinition? Definition { get; }

    public string? Error { get; }

    public string ContentFingerprint { get; }

    public int ErrorLine { get; }

    public int ErrorColumn { get; }
}

internal sealed class JsonDefinitionResultComparer : IEqualityComparer<JsonDefinitionResult>
{
    public static JsonDefinitionResultComparer Instance { get; } = new JsonDefinitionResultComparer();

    public bool Equals(JsonDefinitionResult? x, JsonDefinitionResult? y) =>
        ReferenceEquals(x, y) ||
        (x is not null &&
         y is not null &&
         string.Equals(x.Path, y.Path, StringComparison.Ordinal) &&
         string.Equals(x.ContentFingerprint, y.ContentFingerprint, StringComparison.Ordinal));

    public int GetHashCode(JsonDefinitionResult obj)
    {
        unchecked
        {
            return (StringComparer.Ordinal.GetHashCode(obj.Path) * 397) ^
                   StringComparer.Ordinal.GetHashCode(obj.ContentFingerprint);
        }
    }
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
        string? error,
        string content,
        int errorLine = 0,
        int errorColumn = 0)
    {
        Path = path;
        Definitions = definitions;
        Error = error;
        ContentFingerprint = AdditionalFileFingerprint.Create(content);
        ErrorLine = errorLine;
        ErrorColumn = errorColumn;
    }

    public string Path { get; }

    public IReadOnlyList<QuantityRelationDefinition>? Definitions { get; }

    public string? Error { get; }

    public string ContentFingerprint { get; }

    public int ErrorLine { get; }

    public int ErrorColumn { get; }
}

internal sealed class RelationDefinitionResultComparer : IEqualityComparer<RelationDefinitionResult>
{
    public static RelationDefinitionResultComparer Instance { get; } = new RelationDefinitionResultComparer();

    public bool Equals(RelationDefinitionResult? x, RelationDefinitionResult? y) =>
        ReferenceEquals(x, y) ||
        (x is not null &&
         y is not null &&
         string.Equals(x.Path, y.Path, StringComparison.Ordinal) &&
         string.Equals(x.ContentFingerprint, y.ContentFingerprint, StringComparison.Ordinal));

    public int GetHashCode(RelationDefinitionResult obj)
    {
        unchecked
        {
            return (StringComparer.Ordinal.GetHashCode(obj.Path) * 397) ^
                   StringComparer.Ordinal.GetHashCode(obj.ContentFingerprint);
        }
    }
}

internal static class AdditionalFileFingerprint
{
    public static string Create(string content)
    {
        using SHA256 algorithm = SHA256.Create();
        return Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(content)));
    }
}

internal sealed class EmittedQuantityRelation
{
    public EmittedQuantityRelation(
        string @operator,
        QuantitySelection? result,
        UnitDefinition? resultUnit,
        QuantitySelection? left,
        UnitDefinition? leftUnit,
        QuantitySelection? right,
        UnitDefinition? rightUnit,
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

    public QuantitySelection? Left { get; }

    public UnitDefinition? LeftUnit { get; }

    public QuantitySelection? Right { get; }

    public UnitDefinition? RightUnit { get; }

    public string Source { get; }

    public string Key => Result?.Definition.SemanticId + "." + ResultUnit?.SingularName + " = " +
                         (Left?.Definition.SemanticId ?? "double") + "." + LeftUnit?.SingularName + " " + Operator + " " +
                         (Right?.Definition.SemanticId ?? "double") + "." + RightUnit?.SingularName;
}
