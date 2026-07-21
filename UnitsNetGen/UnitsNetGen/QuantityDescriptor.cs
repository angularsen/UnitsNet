// Licensed under MIT No Attribution, see LICENSE file at the root.

using UnitsNet.Core;

namespace UnitsNetGen;

/// <summary>Non-generic metadata and operations for one quantity in a generated module.</summary>
public interface IQuantityDescriptor
{
    /// <summary>Gets the stable semantic quantity identity.</summary>
    QuantityId Id { get; }

    /// <summary>Gets the quantity's source definition name.</summary>
    string Name { get; }

    /// <summary>Gets the generated quantity CLR type.</summary>
    Type QuantityType { get; }

    /// <summary>Gets the generated unit-enum CLR type.</summary>
    Type UnitType { get; }

    /// <summary>Gets the generated base unit name.</summary>
    string BaseUnitName { get; }

    /// <summary>Gets the quantity's SI base dimensions.</summary>
    BaseDimensions BaseDimensions { get; }

    /// <summary>Gets immutable metadata for the selected units.</summary>
    IReadOnlyList<UnitDescriptor> Units { get; }

    /// <summary>Gets the selected unit for an immutable unit-system policy.</summary>
    UnitDescriptor GetUnit(UnitSystem unitSystem);

    /// <summary>Attempts to get the selected unit for an immutable unit-system policy.</summary>
    bool TryGetUnit(UnitSystem? unitSystem, out UnitDescriptor? unit);

    /// <summary>Creates the generated quantity from a numeric value and unit name.</summary>
    IQuantity<double> Create(double value, string unitName);

    /// <summary>Creates the generated quantity using an immutable unit-system policy.</summary>
    IQuantity<double> Create(double value, UnitSystem unitSystem);

    /// <summary>Attempts to create the generated quantity from a numeric value and unit name.</summary>
    bool TryCreate(
        double value,
        string unitName,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity);

    /// <summary>Attempts to create the generated quantity using an immutable unit-system policy.</summary>
    bool TryCreate(
        double value,
        UnitSystem? unitSystem,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity);

    /// <summary>Converts a numeric value between two selected unit names.</summary>
    double Convert(double value, string fromUnitName, string toUnitName);

    /// <summary>Attempts to convert a numeric value between two selected unit names.</summary>
    bool TryConvert(double value, string fromUnitName, string toUnitName, out double convertedValue);

    /// <summary>Converts a numeric value from a selected unit into an immutable unit system.</summary>
    double Convert(double value, string fromUnitName, UnitSystem unitSystem);

    /// <summary>Attempts to convert a numeric value from a selected unit into an immutable unit system.</summary>
    bool TryConvert(
        double value,
        string fromUnitName,
        UnitSystem? unitSystem,
        out double convertedValue);

    /// <summary>Parses a generated quantity.</summary>
    IQuantity<double> Parse(string text, IFormatProvider? formatProvider = null);

    /// <summary>Attempts to parse a generated quantity.</summary>
    bool TryParse(
        string? text,
        IFormatProvider? formatProvider,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity);

    /// <summary>Gets the stored numeric value from a generated quantity.</summary>
    double GetValue(IQuantity<double> quantity);

    /// <summary>Gets the stored unit name from a generated quantity.</summary>
    string GetUnitName(IQuantity<double> quantity);

    /// <summary>Formats a generated quantity after validating its concrete type.</summary>
    string Format(
        IQuantity<double> quantity,
        string? format = null,
        IFormatProvider? formatProvider = null);
}

/// <summary>Type-erased immutable metadata for one selected unit.</summary>
public sealed record UnitDescriptor(
    string Name,
    int Value,
    string SingularName,
    string PluralName,
    BaseUnits BaseUnits,
    IReadOnlyList<UnitLocalization> Localizations);

/// <summary>Strongly typed implementation of a generated quantity descriptor.</summary>
public sealed class QuantityDescriptor<TQuantity, TUnit> : IQuantityDescriptor
    where TQuantity : struct, IQuantity<TQuantity, TUnit, double>, IParsable<TQuantity>
    where TUnit : struct, Enum
{
    private readonly IReadOnlyList<UnitInfo<TUnit>> _typedUnits;

    /// <summary>Creates immutable metadata for a generated quantity.</summary>
    public QuantityDescriptor(
        QuantityId id,
        string name,
        TUnit baseUnit,
        BaseDimensions baseDimensions,
        IReadOnlyList<UnitInfo<TUnit>> units)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(baseDimensions);
        ArgumentNullException.ThrowIfNull(units);
        Id = id;
        Name = name;
        BaseUnit = baseUnit;
        BaseDimensions = baseDimensions;
        _typedUnits = units;
        UnitDescriptor[] descriptors = units
            .Select(unit => new UnitDescriptor(
                unit.Unit.ToString(),
                System.Convert.ToInt32(unit.Unit),
                unit.SingularName,
                unit.PluralName,
                unit.BaseUnits,
                unit.Localizations))
            .ToArray();
        Units = Array.AsReadOnly(descriptors);
    }

    /// <inheritdoc />
    public QuantityId Id { get; }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public Type QuantityType => typeof(TQuantity);

    /// <inheritdoc />
    public Type UnitType => typeof(TUnit);

    /// <summary>Gets the strongly typed base unit.</summary>
    public TUnit BaseUnit { get; }

    /// <inheritdoc />
    public string BaseUnitName => BaseUnit.ToString();

    /// <inheritdoc />
    public BaseDimensions BaseDimensions { get; }

    /// <inheritdoc />
    public IReadOnlyList<UnitDescriptor> Units { get; }

    /// <inheritdoc />
    public UnitDescriptor GetUnit(UnitSystem unitSystem)
    {
        ArgumentNullException.ThrowIfNull(unitSystem);
        return TryGetUnit(unitSystem, out UnitDescriptor? unit)
            ? unit!
            : throw new ArgumentException(
                $"No selected unit for {Name} is compatible with {unitSystem.BaseUnits}.",
                nameof(unitSystem));
    }

    /// <inheritdoc />
    public bool TryGetUnit(UnitSystem? unitSystem, out UnitDescriptor? unit)
    {
        unit = null;
        if (unitSystem is null)
        {
            return false;
        }

        if (BaseDimensions.IsDimensionless())
        {
            unit = Units.First(candidate =>
                string.Equals(candidate.Name, BaseUnitName, StringComparison.Ordinal));
            return true;
        }

        unit = Units
            .OrderBy(candidate => candidate.SingularName, StringComparer.Ordinal)
            .FirstOrDefault(candidate => candidate.BaseUnits.IsSubsetOf(unitSystem.BaseUnits));
        return unit is not null;
    }

    /// <inheritdoc />
    public IQuantity<double> Create(double value, string unitName) =>
        TQuantity.From(value, ParseUnit(unitName));

    /// <inheritdoc />
    public IQuantity<double> Create(double value, UnitSystem unitSystem) =>
        TQuantity.From(value, ParseUnit(GetUnit(unitSystem).Name));

    /// <inheritdoc />
    public bool TryCreate(
        double value,
        string unitName,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TryParseUnit(unitName, out TUnit unit))
        {
            quantity = TQuantity.From(value, unit);
            return true;
        }

        quantity = null;
        return false;
    }

    /// <inheritdoc />
    public bool TryCreate(
        double value,
        UnitSystem? unitSystem,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TryGetUnit(unitSystem, out UnitDescriptor? selected))
        {
            quantity = TQuantity.From(value, ParseUnit(selected!.Name));
            return true;
        }

        quantity = null;
        return false;
    }

    /// <inheritdoc />
    public double Convert(double value, string fromUnitName, string toUnitName) =>
        TQuantity.Convert(value, ParseUnit(fromUnitName), ParseUnit(toUnitName));

    /// <inheritdoc />
    public bool TryConvert(double value, string fromUnitName, string toUnitName, out double convertedValue)
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

    /// <inheritdoc />
    public double Convert(double value, string fromUnitName, UnitSystem unitSystem) =>
        Convert(value, fromUnitName, GetUnit(unitSystem).Name);

    /// <inheritdoc />
    public bool TryConvert(
        double value,
        string fromUnitName,
        UnitSystem? unitSystem,
        out double convertedValue)
    {
        if (TryGetUnit(unitSystem, out UnitDescriptor? selected))
        {
            return TryConvert(value, fromUnitName, selected!.Name, out convertedValue);
        }

        convertedValue = default;
        return false;
    }

    /// <inheritdoc />
    public IQuantity<double> Parse(string text, IFormatProvider? formatProvider = null) =>
        TQuantity.Parse(text, formatProvider);

    /// <inheritdoc />
    public bool TryParse(
        string? text,
        IFormatProvider? formatProvider,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TQuantity.TryParse(text, formatProvider, out TQuantity parsed))
        {
            quantity = parsed;
            return true;
        }

        quantity = null;
        return false;
    }

    /// <inheritdoc />
    public double GetValue(IQuantity<double> quantity) => RequireQuantity(quantity).Value;

    /// <inheritdoc />
    public string GetUnitName(IQuantity<double> quantity) => RequireQuantity(quantity).Unit.ToString();

    /// <inheritdoc />
    public string Format(
        IQuantity<double> quantity,
        string? format = null,
        IFormatProvider? formatProvider = null) =>
        RequireQuantity(quantity).ToString(format, formatProvider);

    private TUnit ParseUnit(string name)
    {
        if (TryParseUnit(name, out TUnit unit))
        {
            return unit;
        }

        throw new ArgumentException($"Unit '{name}' is not selected for {Name}.", nameof(name));
    }

    private bool TryParseUnit(string? name, out TUnit unit)
    {
        if (Enum.TryParse(name, ignoreCase: true, out TUnit parsed) &&
            _typedUnits.Any(candidate => EqualityComparer<TUnit>.Default.Equals(candidate.Unit, parsed)))
        {
            unit = parsed;
            return true;
        }

        unit = default;
        return false;
    }

    private static TQuantity RequireQuantity(IQuantity<double> quantity) =>
        quantity is TQuantity typed
            ? typed
            : throw new ArgumentException(
                $"Expected a quantity of type {typeof(TQuantity).FullName}.",
                nameof(quantity));
}
