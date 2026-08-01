// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet;

/// <summary>A minimal, type-erased quantity value contract.</summary>
/// <typeparam name="TValue">The numeric storage type.</typeparam>
public interface IQuantity<out TValue> : IFormattable
{
    /// <summary>Gets the stored numeric value.</summary>
    TValue Value { get; }

    /// <summary>
    /// Gets the unit in which <see cref="Value" /> is expressed.
    /// Use a strongly typed quantity contract when the unit enum type is known.
    /// </summary>
    Enum Unit { get; }
}

/// <summary>
/// A self-typed quantity contract with construction and conversion primitives.
/// </summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
/// <typeparam name="TUnit">The unit enum type.</typeparam>
/// <typeparam name="TValue">The numeric storage type.</typeparam>
public interface IQuantity<TSelf, TUnit, TValue> : IQuantity<TValue>
    where TSelf : IQuantity<TSelf, TUnit, TValue>
    where TUnit : struct, Enum
{
    /// <summary>Gets the unit in which <see cref="IQuantity{TValue}.Value" /> is expressed.</summary>
    new TUnit Unit { get; }

    Enum IQuantity<TValue>.Unit => Unit;

    /// <summary>Creates a quantity with a value expressed in the specified unit.</summary>
    static abstract TSelf From(TValue value, TUnit unit);

    /// <summary>Converts a numeric value between two units of this quantity.</summary>
    static abstract TValue Convert(TValue value, TUnit fromUnit, TUnit toUnit);

    /// <summary>Gets this quantity's value expressed in the specified unit.</summary>
    TValue As(TUnit unit) => TSelf.Convert(Value, Unit, unit);

    /// <summary>Converts this quantity to the specified unit.</summary>
    TSelf ToUnit(TUnit unit) => TSelf.From(As(unit), unit);
}

/// <summary>
/// A self-typed generated quantity with immutable metadata, construction, and conversion primitives.
/// </summary>
/// <typeparam name="TSelf">The concrete generated quantity type.</typeparam>
/// <typeparam name="TUnit">The generated unit enum type.</typeparam>
public interface IQuantity<TSelf, TUnit> : IQuantity<TSelf, TUnit, double>
    where TSelf : IQuantity<TSelf, TUnit>
    where TUnit : struct, Enum
{
    /// <summary>Gets the canonical immutable description of this generated quantity type.</summary>
    static abstract QuantityInfo<TSelf, TUnit> Info { get; }
}
