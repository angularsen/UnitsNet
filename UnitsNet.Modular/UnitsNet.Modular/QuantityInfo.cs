// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using UnitsNet.Core;
using UnitsNet.Modular;

namespace UnitsNet;

/// <summary>
/// Provides immutable, strongly typed metadata for one generated quantity.
/// </summary>
/// <typeparam name="TQuantity">The generated quantity type.</typeparam>
/// <typeparam name="TUnit">The generated unit enum type.</typeparam>
public sealed class QuantityInfo<TQuantity, TUnit> : IQuantityDescriptor
    where TQuantity : struct, IQuantity<TQuantity, TUnit, double>, IParsable<TQuantity>
    where TUnit : struct, Enum
{
    private readonly IQuantityMetadata<TUnit> _metadata;
    private readonly FrozenDictionary<TUnit, UnitInfo<TUnit>> _unitInfosByValue;
    private readonly FrozenDictionary<TUnit, UnitDescriptor> _unitDescriptorsByValue;
    private readonly IReadOnlyList<UnitDescriptor> _unitDescriptors;

    /// <summary>Creates immutable metadata from generated quantity metadata.</summary>
    public QuantityInfo(QuantityId id, IQuantityMetadata<TUnit> metadata)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id.Value, nameof(id));
        ArgumentNullException.ThrowIfNull(metadata);
        ArgumentException.ThrowIfNullOrWhiteSpace(metadata.Name);
        ArgumentNullException.ThrowIfNull(metadata.BaseDimensions);
        ArgumentNullException.ThrowIfNull(metadata.Units);

        UnitInfo<TUnit>[] unitInfos = metadata.Units.ToArray();
        if (unitInfos.Any(unit => unit is null))
        {
            throw new ArgumentException("Unit metadata cannot contain null values.", nameof(metadata));
        }

        _metadata = metadata;
        Id = id;
        Name = metadata.Name;
        BaseUnit = metadata.BaseUnit;
        BaseDimensions = metadata.BaseDimensions;
        UnitInfos = Array.AsReadOnly(unitInfos);
        _unitInfosByValue = unitInfos.ToFrozenDictionary(unit => unit.Unit);
        Units = Array.AsReadOnly(unitInfos.Select(unit => unit.Unit).ToArray());

        if (!_unitInfosByValue.TryGetValue(BaseUnit, out UnitInfo<TUnit>? baseUnitInfo))
        {
            throw new ArgumentException(
                $"No unit metadata was supplied for the base unit '{BaseUnit}'.",
                nameof(metadata));
        }

        BaseUnitInfo = baseUnitInfo;
        UnitDescriptor[] descriptors = unitInfos
            .Select(unit => new UnitDescriptor(
                unit.Unit.ToString(),
                System.Convert.ToInt32(unit.Unit),
                unit.SingularName,
                unit.PluralName,
                unit.BaseUnits,
                unit.Localizations))
            .ToArray();
        _unitDescriptors = Array.AsReadOnly(descriptors);
        _unitDescriptorsByValue = unitInfos
            .Select((unit, index) => (unit.Unit, Descriptor: descriptors[index]))
            .ToFrozenDictionary(pair => pair.Unit, pair => pair.Descriptor);
    }

    /// <summary>Gets the stable semantic quantity identity.</summary>
    public QuantityId Id { get; }

    /// <summary>Gets the quantity's invariant name.</summary>
    public string Name { get; }

    /// <summary>Gets the generated quantity CLR type.</summary>
    public Type QuantityType => typeof(TQuantity);

    /// <summary>Gets the generated unit-enum CLR type.</summary>
    public Type UnitType => typeof(TUnit);

    /// <summary>Gets the unit through which conversions are performed.</summary>
    public TUnit BaseUnit { get; }

    /// <summary>Gets metadata for the unit through which conversions are performed.</summary>
    public UnitInfo<TUnit> BaseUnitInfo { get; }

    /// <summary>Gets the quantity's SI base dimensions.</summary>
    public BaseDimensions BaseDimensions { get; }

    /// <summary>Gets immutable metadata for all generated units of this quantity.</summary>
    public IReadOnlyList<UnitInfo<TUnit>> UnitInfos { get; }

    /// <summary>Gets all generated unit enum values for this quantity.</summary>
    public IReadOnlyCollection<TUnit> Units { get; }

    /// <summary>Gets zero expressed in the quantity's base unit.</summary>
    public TQuantity Zero => TQuantity.From(0, BaseUnit);

    /// <summary>Gets metadata for a generated unit.</summary>
    public UnitInfo<TUnit> this[TUnit unit] =>
        _unitInfosByValue.TryGetValue(unit, out UnitInfo<TUnit>? info)
            ? info
            : throw new KeyNotFoundException($"Unit '{unit}' is not generated for {Name}.");

    /// <summary>Attempts to get metadata for a generated unit.</summary>
    public bool TryGetUnitInfo(TUnit unit, [NotNullWhen(true)] out UnitInfo<TUnit>? unitInfo) =>
        _unitInfosByValue.TryGetValue(unit, out unitInfo);

    /// <summary>Gets the single generated unit compatible with the supplied base units.</summary>
    public UnitInfo<TUnit> GetUnitInfoFor(BaseUnits baseUnits)
    {
        ArgumentNullException.ThrowIfNull(baseUnits);
        using IEnumerator<UnitInfo<TUnit>> matches = GetUnitInfosFor(baseUnits).GetEnumerator();
        if (!matches.MoveNext())
        {
            throw new InvalidOperationException($"No unit for {Name} is compatible with {baseUnits}.");
        }

        UnitInfo<TUnit> match = matches.Current;
        if (matches.MoveNext())
        {
            throw new InvalidOperationException($"More than one unit for {Name} is compatible with {baseUnits}.");
        }

        return match;
    }

    /// <summary>Gets generated units compatible with the supplied base units.</summary>
    public IEnumerable<UnitInfo<TUnit>> GetUnitInfosFor(BaseUnits baseUnits)
    {
        ArgumentNullException.ThrowIfNull(baseUnits);
        return UnitInfos.Where(unit => unit.BaseUnits.IsSubsetOf(baseUnits));
    }

    /// <summary>Gets the generated unit selected by an immutable unit-system policy.</summary>
    public UnitInfo<TUnit> GetUnit(UnitSystem unitSystem) =>
        this[QuantityOperations.GetUnit(unitSystem, _metadata)];

    /// <summary>Attempts to get the generated unit selected by an immutable unit-system policy.</summary>
    public bool TryGetUnit(UnitSystem? unitSystem, [NotNullWhen(true)] out UnitInfo<TUnit>? unitInfo)
    {
        if (QuantityOperations.TryGetUnit(unitSystem, _metadata, out TUnit unit))
        {
            return TryGetUnitInfo(unit, out unitInfo);
        }

        unitInfo = null;
        return false;
    }

    /// <summary>Creates the quantity from a numeric value and generated unit.</summary>
    public TQuantity From(double value, TUnit unit) => TQuantity.From(value, unit);

    /// <summary>Creates the quantity using an immutable unit-system policy.</summary>
    public TQuantity From(double value, UnitSystem unitSystem) =>
        TQuantity.From(value, GetUnit(unitSystem).Unit);

    string IQuantityDescriptor.BaseUnitName => BaseUnit.ToString();

    IReadOnlyList<UnitDescriptor> IQuantityDescriptor.Units => _unitDescriptors;

    UnitDescriptor IQuantityDescriptor.GetUnit(UnitSystem unitSystem) =>
        _unitDescriptorsByValue[GetUnit(unitSystem).Unit];

    bool IQuantityDescriptor.TryGetUnit(UnitSystem? unitSystem, out UnitDescriptor? unit)
    {
        if (TryGetUnit(unitSystem, out UnitInfo<TUnit>? selected))
        {
            unit = _unitDescriptorsByValue[selected.Unit];
            return true;
        }

        unit = null;
        return false;
    }

    IQuantity<double> IQuantityDescriptor.Create(double value, string unitName) =>
        From(value, ParseUnit(unitName));

    IQuantity<double> IQuantityDescriptor.Create(double value, UnitSystem unitSystem) =>
        From(value, unitSystem);

    bool IQuantityDescriptor.TryCreate(
        double value,
        string unitName,
        [NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TryParseUnit(unitName, out TUnit unit))
        {
            quantity = From(value, unit);
            return true;
        }

        quantity = null;
        return false;
    }

    bool IQuantityDescriptor.TryCreate(
        double value,
        UnitSystem? unitSystem,
        [NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TryGetUnit(unitSystem, out UnitInfo<TUnit>? unit))
        {
            quantity = From(value, unit.Unit);
            return true;
        }

        quantity = null;
        return false;
    }

    double IQuantityDescriptor.Convert(double value, string fromUnitName, string toUnitName) =>
        TQuantity.Convert(value, ParseUnit(fromUnitName), ParseUnit(toUnitName));

    bool IQuantityDescriptor.TryConvert(
        double value,
        string fromUnitName,
        string toUnitName,
        out double convertedValue)
    {
        if (TryParseUnit(fromUnitName, out TUnit fromUnit) &&
            TryParseUnit(toUnitName, out TUnit toUnit))
        {
            convertedValue = TQuantity.Convert(value, fromUnit, toUnit);
            return true;
        }

        convertedValue = default;
        return false;
    }

    double IQuantityDescriptor.Convert(double value, string fromUnitName, UnitSystem unitSystem) =>
        TQuantity.Convert(value, ParseUnit(fromUnitName), GetUnit(unitSystem).Unit);

    bool IQuantityDescriptor.TryConvert(
        double value,
        string fromUnitName,
        UnitSystem? unitSystem,
        out double convertedValue)
    {
        if (TryParseUnit(fromUnitName, out TUnit fromUnit) &&
            TryGetUnit(unitSystem, out UnitInfo<TUnit>? toUnit))
        {
            convertedValue = TQuantity.Convert(value, fromUnit, toUnit.Unit);
            return true;
        }

        convertedValue = default;
        return false;
    }

    IQuantity<double> IQuantityDescriptor.Parse(string text, IFormatProvider? formatProvider) =>
        TQuantity.Parse(text, formatProvider);

    bool IQuantityDescriptor.TryParse(
        string? text,
        IFormatProvider? formatProvider,
        [NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TQuantity.TryParse(text, formatProvider, out TQuantity parsed))
        {
            quantity = parsed;
            return true;
        }

        quantity = null;
        return false;
    }

    double IQuantityDescriptor.GetValue(IQuantity<double> quantity) => RequireQuantity(quantity).Value;

    string IQuantityDescriptor.GetUnitName(IQuantity<double> quantity) => RequireQuantity(quantity).Unit.ToString();

    string IQuantityDescriptor.Format(
        IQuantity<double> quantity,
        string? format,
        IFormatProvider? formatProvider) =>
        RequireQuantity(quantity).ToString(format, formatProvider);

    private TUnit ParseUnit(string name)
    {
        if (TryParseUnit(name, out TUnit unit))
        {
            return unit;
        }

        throw new ArgumentException($"Unit '{name}' is not selected for {Name}.", nameof(name));
    }

    private bool TryParseUnit(string? name, out TUnit unit) =>
        QuantityOperations.TryParseUnit(name, null, _metadata, out unit);

    private static TQuantity RequireQuantity(IQuantity<double> quantity) =>
        quantity is TQuantity typed
            ? typed
            : throw new ArgumentException(
                $"Expected a quantity of type {typeof(TQuantity).FullName}.",
                nameof(quantity));
}
