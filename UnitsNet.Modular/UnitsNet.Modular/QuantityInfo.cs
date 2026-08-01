// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Frozen;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using UnitsNet.Modular;

namespace UnitsNet;

/// <summary>
/// Provides the canonical immutable runtime description of one generated quantity.
/// </summary>
/// <remarks>
/// Generated quantity types expose one instance through their static <c>Info</c> property, and the
/// generated discovery registry stores that same instance. Value operations remain on the quantity
/// type; this object describes its identity, units, dimensions, and unit-system selection.
/// </remarks>
/// <typeparam name="TQuantity">The generated quantity type.</typeparam>
/// <typeparam name="TUnit">The generated unit enum type.</typeparam>
public sealed class QuantityInfo<TQuantity, TUnit> : IQuantityDescriptor
    where TQuantity : IQuantity<TQuantity, TUnit, double>
    where TUnit : struct, Enum
{
    private readonly IQuantityMetadata<TQuantity, TUnit> _metadata;
    private readonly FrozenDictionary<TUnit, UnitInfo<TUnit>> _unitInfosByValue;
    private readonly FrozenDictionary<TUnit, UnitDescriptor> _unitDescriptorsByValue;
    private readonly IReadOnlyList<UnitDescriptor> _unitDescriptors;

    /// <summary>Creates immutable metadata from generated quantity metadata.</summary>
    /// <remarks>This constructor is public only so generated code can initialize its static <c>Info</c>.</remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public QuantityInfo(QuantityId id, IQuantityMetadata<TQuantity, TUnit> metadata)
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
        BaseDimensions = metadata.BaseDimensions;
        Units = Array.AsReadOnly(unitInfos);
        _unitInfosByValue = unitInfos.ToFrozenDictionary(unit => unit.Value);

        if (!_unitInfosByValue.TryGetValue(metadata.BaseUnit, out UnitInfo<TUnit>? baseUnitInfo))
        {
            throw new ArgumentException(
                $"No unit metadata was supplied for the base unit '{metadata.BaseUnit}'.",
                nameof(metadata));
        }

        BaseUnit = baseUnitInfo;
        UnitDescriptor[] descriptors = unitInfos
            .Select(unit => new UnitDescriptor(
                unit.Value.ToString(),
                System.Convert.ToInt32(unit.Value),
                unit.SingularName,
                unit.PluralName,
                unit.BaseUnits,
                unit.Localizations))
            .ToArray();
        _unitDescriptors = Array.AsReadOnly(descriptors);
        _unitDescriptorsByValue = unitInfos
            .Select((unit, index) => (unit.Value, Descriptor: descriptors[index]))
            .ToFrozenDictionary(pair => pair.Value, pair => pair.Descriptor);
    }

    /// <summary>Gets the stable semantic quantity identity.</summary>
    public QuantityId Id { get; }

    /// <summary>Gets the quantity's invariant name.</summary>
    public string Name { get; }

    /// <summary>Gets the generated quantity CLR type.</summary>
    public Type QuantityType => typeof(TQuantity);

    /// <summary>Gets the generated unit-enum CLR type.</summary>
    public Type UnitType => typeof(TUnit);

    /// <summary>Gets metadata for the unit through which conversions are performed.</summary>
    public UnitInfo<TUnit> BaseUnit { get; }

    /// <summary>
    /// Gets metadata for the unit through which conversions are performed.
    /// This is a source-compatibility alias for <see cref="BaseUnit" />.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public UnitInfo<TUnit> BaseUnitInfo => BaseUnit;

    /// <summary>Gets the quantity's SI base dimensions.</summary>
    public BaseDimensions BaseDimensions { get; }

    /// <summary>Gets immutable metadata for all generated units of this quantity.</summary>
    public IReadOnlyList<UnitInfo<TUnit>> Units { get; }

    /// <summary>
    /// Gets immutable metadata for all generated units of this quantity.
    /// This is a source-compatibility alias for <see cref="Units" />.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public IReadOnlyList<UnitInfo<TUnit>> UnitInfos => Units;

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
        return Units.Where(unit => unit.BaseUnits.IsSubsetOf(baseUnits));
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

    string IQuantityDescriptor.BaseUnitName => BaseUnit.Value.ToString();

    IReadOnlyList<UnitDescriptor> IQuantityDescriptor.Units => _unitDescriptors;

    UnitDescriptor IQuantityDescriptor.GetUnit(UnitSystem unitSystem) =>
        _unitDescriptorsByValue[GetUnit(unitSystem).Value];

    bool IQuantityDescriptor.TryGetUnit(UnitSystem? unitSystem, out UnitDescriptor? unit)
    {
        if (TryGetUnit(unitSystem, out UnitInfo<TUnit>? selected))
        {
            unit = _unitDescriptorsByValue[selected.Value];
            return true;
        }

        unit = null;
        return false;
    }

    IQuantity<double> IQuantityDescriptor.Create(double value, string unitName) =>
        TQuantity.From(value, ParseUnit(unitName));

    IQuantity<double> IQuantityDescriptor.Create(double value, UnitSystem unitSystem) =>
        TQuantity.From(value, GetUnit(unitSystem).Value);

    bool IQuantityDescriptor.TryCreate(
        double value,
        string unitName,
        [NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TryParseUnit(unitName, out TUnit unit))
        {
            quantity = TQuantity.From(value, unit);
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
            quantity = TQuantity.From(value, unit.Value);
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
        TQuantity.Convert(value, ParseUnit(fromUnitName), GetUnit(unitSystem).Value);

    bool IQuantityDescriptor.TryConvert(
        double value,
        string fromUnitName,
        UnitSystem? unitSystem,
        out double convertedValue)
    {
        if (TryParseUnit(fromUnitName, out TUnit fromUnit) &&
            TryGetUnit(unitSystem, out UnitInfo<TUnit>? toUnit))
        {
            convertedValue = TQuantity.Convert(value, fromUnit, toUnit.Value);
            return true;
        }

        convertedValue = default;
        return false;
    }

    IQuantity<double> IQuantityDescriptor.Parse(string text, IFormatProvider? formatProvider) =>
        _metadata.Parse(text, formatProvider);

    bool IQuantityDescriptor.TryParse(
        string? text,
        IFormatProvider? formatProvider,
        [NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (_metadata.TryParse(text, formatProvider, out TQuantity parsed))
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
