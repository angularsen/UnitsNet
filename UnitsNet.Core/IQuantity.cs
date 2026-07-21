// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet.Core;

/// <summary>A quantity contract independent of its concrete unit enum and generated CLR type.</summary>
/// <typeparam name="TValue">The numeric storage type.</typeparam>
public interface IQuantity<out TValue> : IFormattable
{
    /// <summary>Gets the stable semantic quantity identity.</summary>
    QuantityId QuantityId { get; }

    /// <summary>Gets the stored value expressed in <see cref="UnitName" />.</summary>
    TValue Value { get; }

    /// <summary>Gets the value normalized to the definition's base unit.</summary>
    TValue BaseValue { get; }

    /// <summary>Gets the selected unit's stable enum name.</summary>
    string UnitName { get; }
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
