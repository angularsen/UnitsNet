// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet.Core;

/// <summary>A minimal quantity value contract independent of its unit and concrete CLR type.</summary>
/// <typeparam name="TValue">The numeric storage type.</typeparam>
public interface IQuantity<out TValue> : IFormattable
{
    /// <summary>Gets the stored numeric value.</summary>
    TValue Value { get; }
}

/// <summary>A quantity contract whose concrete unit enum is known.</summary>
/// <typeparam name="TUnit">The unit enum type.</typeparam>
/// <typeparam name="TValue">The numeric storage type.</typeparam>
public interface IQuantity<out TUnit, out TValue> : IQuantity<TValue>
    where TUnit : struct, Enum
{
    /// <summary>Gets the unit in which <see cref="IQuantity{TValue}.Value" /> is expressed.</summary>
    TUnit Unit { get; }
}

/// <summary>
/// A self-typed quantity contract with type-level identity, construction, and conversion.
/// </summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
/// <typeparam name="TUnit">The unit enum type.</typeparam>
/// <typeparam name="TValue">The numeric storage type.</typeparam>
public interface IQuantity<TSelf, TUnit, TValue> : IQuantity<TUnit, TValue>
    where TSelf : IQuantity<TSelf, TUnit, TValue>
    where TUnit : struct, Enum
{
    /// <summary>Gets the stable semantic identity of the quantity type.</summary>
    static abstract QuantityId QuantityId { get; }

    /// <summary>Gets the definition's base unit.</summary>
    static abstract TUnit BaseUnit { get; }

    /// <summary>Creates a quantity with a value expressed in the specified unit.</summary>
    static abstract TSelf From(TValue value, TUnit unit);

    /// <summary>Converts a numeric value between two units of this quantity.</summary>
    static abstract TValue Convert(TValue value, TUnit fromUnit, TUnit toUnit);

    /// <summary>Gets this quantity's value expressed in the specified unit.</summary>
    TValue As(TUnit unit) => TSelf.Convert(Value, Unit, unit);

    /// <summary>Converts this quantity to the specified unit.</summary>
    TSelf ToUnit(TUnit unit) => TSelf.From(As(unit), unit);
}
