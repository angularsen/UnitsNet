// Licensed under MIT No Attribution, see LICENSE file at the root.

namespace UnitsNet.Core;

/// <summary>A logarithmic quantity with logarithmic arithmetic semantics.</summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
public interface ILogarithmicQuantity<TSelf>
    where TSelf : ILogarithmicQuantity<TSelf>
{
    /// <summary>Gets the factor used to map between logarithmic and linear space.</summary>
    static abstract double LogarithmicScalingFactor { get; }

    /// <summary>Gets zero expressed in the quantity's base unit.</summary>
    static abstract TSelf Zero { get; }
}

/// <summary>A strongly typed logarithmic quantity.</summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
/// <typeparam name="TUnit">The unit enum type.</typeparam>
public interface ILogarithmicQuantity<TSelf, TUnit> :
    IQuantity<TSelf, TUnit, double>,
    ILogarithmicQuantity<TSelf>
    where TSelf : ILogarithmicQuantity<TSelf, TUnit>
    where TUnit : struct, Enum
{
}
