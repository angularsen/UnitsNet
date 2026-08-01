// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Collections.Frozen;
using UnitsNet;

namespace UnitsNet.Modular;

/// <summary>An immutable registry of the quantities selected into one consumer-owned module.</summary>
public sealed class QuantityRegistry
{
    private readonly FrozenDictionary<QuantityId, IQuantityDescriptor> _byId;
    private readonly FrozenDictionary<string, IQuantityDescriptor> _byName;
    private readonly FrozenDictionary<Type, IQuantityDescriptor> _byType;
    private readonly FrozenDictionary<Type, IQuantityDescriptor> _byUnitType;

    /// <summary>Creates a registry from generated descriptors.</summary>
    public QuantityRegistry(IEnumerable<IQuantityDescriptor> quantities)
    {
        ArgumentNullException.ThrowIfNull(quantities);
        IQuantityDescriptor[] entries = quantities.ToArray();
        Quantities = Array.AsReadOnly(entries);
        Names = Array.AsReadOnly(entries.Select(quantity => quantity.Name).ToArray());
        _byId = entries.ToFrozenDictionary(quantity => quantity.Id);
        _byName = entries.ToFrozenDictionary(quantity => quantity.Name, StringComparer.OrdinalIgnoreCase);
        _byType = entries.ToFrozenDictionary(quantity => quantity.QuantityType);
        _byUnitType = entries.ToFrozenDictionary(quantity => quantity.UnitType);
    }

    /// <summary>Gets all quantities selected into the generated module.</summary>
    public IReadOnlyList<IQuantityDescriptor> Quantities { get; }

    /// <summary>Gets all invariant quantity names selected into the generated module.</summary>
    public IReadOnlyCollection<string> Names { get; }

    /// <summary>Gets selected quantity descriptors by invariant name.</summary>
    public IReadOnlyDictionary<string, IQuantityDescriptor> ByName => _byName;

    /// <summary>Gets a descriptor by stable semantic identity.</summary>
    public IQuantityDescriptor Get(QuantityId id) =>
        _byId.TryGetValue(id, out IQuantityDescriptor? quantity)
            ? quantity
            : throw new KeyNotFoundException($"Quantity '{id}' is not selected into this module.");

    /// <summary>Gets a descriptor by definition name.</summary>
    public IQuantityDescriptor Get(string name) =>
        _byName.TryGetValue(name, out IQuantityDescriptor? quantity)
            ? quantity
            : throw new KeyNotFoundException($"Quantity '{name}' is not selected into this module.");

    /// <summary>Gets a descriptor by generated CLR type.</summary>
    public IQuantityDescriptor Get(Type type) =>
        _byType.TryGetValue(type, out IQuantityDescriptor? quantity)
            ? quantity
            : throw new KeyNotFoundException($"Quantity type '{type.FullName}' is not selected into this module.");

    /// <summary>Gets a descriptor by generated unit-enum CLR type.</summary>
    public IQuantityDescriptor GetByUnitType(Type unitType) =>
        _byUnitType.TryGetValue(unitType, out IQuantityDescriptor? quantity)
            ? quantity
            : throw new KeyNotFoundException($"Unit type '{unitType.FullName}' is not selected into this module.");

    /// <summary>Attempts to get a descriptor by stable semantic identity.</summary>
    public bool TryGet(QuantityId id, out IQuantityDescriptor? quantity) => _byId.TryGetValue(id, out quantity);

    /// <summary>Attempts to get a descriptor by definition name.</summary>
    public bool TryGet(string name, out IQuantityDescriptor? quantity) => _byName.TryGetValue(name, out quantity);

    /// <summary>Attempts to get a descriptor by generated CLR type.</summary>
    public bool TryGet(Type type, out IQuantityDescriptor? quantity) => _byType.TryGetValue(type, out quantity);

    /// <summary>Attempts to get a descriptor by generated unit-enum CLR type.</summary>
    public bool TryGetByUnitType(Type unitType, out IQuantityDescriptor? quantity) =>
        _byUnitType.TryGetValue(unitType, out quantity);

    /// <summary>Creates a selected quantity from invariant quantity and unit names.</summary>
    public IQuantity<double> Create(double value, string quantityName, string unitName) =>
        Get(quantityName).Create(value, unitName);

    /// <summary>Attempts to create a selected quantity from invariant quantity and unit names.</summary>
    public bool TryCreate(
        double value,
        string quantityName,
        string unitName,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TryGet(quantityName, out IQuantityDescriptor? descriptor))
        {
            return descriptor!.TryCreate(value, unitName, out quantity);
        }

        quantity = null;
        return false;
    }

    /// <summary>Creates a selected quantity using an immutable unit-system policy.</summary>
    public IQuantity<double> Create(double value, string quantityName, UnitSystem unitSystem) =>
        Get(quantityName).Create(value, unitSystem);

    /// <summary>Attempts to create a selected quantity using an immutable unit-system policy.</summary>
    public bool TryCreate(
        double value,
        string quantityName,
        UnitSystem? unitSystem,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TryGet(quantityName, out IQuantityDescriptor? descriptor))
        {
            return descriptor!.TryCreate(value, unitSystem, out quantity);
        }

        quantity = null;
        return false;
    }

    /// <summary>Creates a selected quantity from a generated unit-enum value.</summary>
    public IQuantity<double> Create(double value, Enum unit)
    {
        ArgumentNullException.ThrowIfNull(unit);
        IQuantityDescriptor descriptor = GetByUnitType(unit.GetType());
        return descriptor.Create(value, GetUnitName(unit));
    }

    /// <summary>Attempts to create a selected quantity from a generated unit-enum value.</summary>
    public bool TryCreate(
        double value,
        Enum? unit,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TryResolveUnit(unit, out IQuantityDescriptor descriptor, out string unitName))
        {
            return descriptor.TryCreate(value, unitName, out quantity);
        }

        quantity = null;
        return false;
    }

    /// <summary>Converts a value between selected units identified by invariant names.</summary>
    public double Convert(double value, string quantityName, string fromUnitName, string toUnitName) =>
        Get(quantityName).Convert(value, fromUnitName, toUnitName);

    /// <summary>Attempts to convert a value between selected units identified by invariant names.</summary>
    public bool TryConvert(
        double value,
        string quantityName,
        string fromUnitName,
        string toUnitName,
        out double convertedValue)
    {
        if (TryGet(quantityName, out IQuantityDescriptor? descriptor))
        {
            return descriptor!.TryConvert(value, fromUnitName, toUnitName, out convertedValue);
        }

        convertedValue = default;
        return false;
    }

    /// <summary>Converts a value from a selected unit name into an immutable unit system.</summary>
    public double Convert(
        double value,
        string quantityName,
        string fromUnitName,
        UnitSystem unitSystem) =>
        Get(quantityName).Convert(value, fromUnitName, unitSystem);

    /// <summary>Attempts to convert a value from a selected unit name into an immutable unit system.</summary>
    public bool TryConvert(
        double value,
        string quantityName,
        string fromUnitName,
        UnitSystem? unitSystem,
        out double convertedValue)
    {
        if (TryGet(quantityName, out IQuantityDescriptor? descriptor))
        {
            return descriptor!.TryConvert(
                value,
                fromUnitName,
                unitSystem,
                out convertedValue);
        }

        convertedValue = default;
        return false;
    }

    /// <summary>Converts a value between two values of the same selected unit-enum type.</summary>
    public double Convert(double value, Enum fromUnit, Enum toUnit)
    {
        ArgumentNullException.ThrowIfNull(fromUnit);
        ArgumentNullException.ThrowIfNull(toUnit);
        if (fromUnit.GetType() != toUnit.GetType())
        {
            throw new ArgumentException("Source and target units must belong to the same quantity.", nameof(toUnit));
        }

        IQuantityDescriptor descriptor = GetByUnitType(fromUnit.GetType());
        return descriptor.Convert(value, GetUnitName(fromUnit), GetUnitName(toUnit));
    }

    /// <summary>Attempts to convert a value between two values of the same selected unit-enum type.</summary>
    public bool TryConvert(double value, Enum? fromUnit, Enum? toUnit, out double convertedValue)
    {
        if (TryResolveUnit(fromUnit, out IQuantityDescriptor fromDescriptor, out string fromUnitName) &&
            TryResolveUnit(toUnit, out IQuantityDescriptor toDescriptor, out string toUnitName) &&
            ReferenceEquals(fromDescriptor, toDescriptor))
        {
            return fromDescriptor.TryConvert(value, fromUnitName, toUnitName, out convertedValue);
        }

        convertedValue = default;
        return false;
    }

    /// <summary>Parses a selected quantity identified by its generated CLR type.</summary>
    public IQuantity<double> Parse(
        Type quantityType,
        string text,
        IFormatProvider? formatProvider = null) =>
        Get(quantityType).Parse(text, formatProvider);

    /// <summary>Attempts to parse a selected quantity identified by its generated CLR type.</summary>
    public bool TryParse(
        Type quantityType,
        string? text,
        IFormatProvider? formatProvider,
        [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out IQuantity<double>? quantity)
    {
        if (TryGet(quantityType, out IQuantityDescriptor? descriptor))
        {
            return descriptor!.TryParse(text, formatProvider, out quantity);
        }

        quantity = null;
        return false;
    }

    /// <summary>Finds selected quantities with exactly matching SI base dimensions.</summary>
    public IReadOnlyList<IQuantityDescriptor> FindByBaseDimensions(BaseDimensions baseDimensions)
    {
        ArgumentNullException.ThrowIfNull(baseDimensions);
        return Array.AsReadOnly(
            Quantities.Where(quantity => quantity.BaseDimensions == baseDimensions).ToArray());
    }

    private static string GetUnitName(Enum unit) =>
        Enum.GetName(unit.GetType(), unit)
        ?? throw new ArgumentOutOfRangeException(nameof(unit), unit, "The unit value has no defined name.");

    private bool TryResolveUnit(
        Enum? unit,
        out IQuantityDescriptor descriptor,
        out string unitName)
    {
        if (unit is not null &&
            _byUnitType.TryGetValue(unit.GetType(), out IQuantityDescriptor? resolved) &&
            resolved is not null &&
            Enum.GetName(unit.GetType(), unit) is { } definedName)
        {
            descriptor = resolved;
            unitName = definedName;
            return true;
        }

        descriptor = null!;
        unitName = null!;
        return false;
    }
}
