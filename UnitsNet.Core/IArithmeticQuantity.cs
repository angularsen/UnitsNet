// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Numerics;

namespace UnitsNet.Core;

/// <summary>A quantity that supports same-quantity arithmetic with a <see cref="double" /> scalar.</summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
public interface IArithmeticQuantity<TSelf> :
    IAdditionOperators<TSelf, TSelf, TSelf>,
    ISubtractionOperators<TSelf, TSelf, TSelf>,
    IMultiplyOperators<TSelf, double, TSelf>,
    IDivisionOperators<TSelf, double, TSelf>,
    IUnaryNegationOperators<TSelf, TSelf>
    where TSelf : IArithmeticQuantity<TSelf>
{
}

/// <summary>A strongly typed arithmetic quantity.</summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
/// <typeparam name="TUnit">The unit enum type.</typeparam>
public interface IArithmeticQuantity<TSelf, TUnit> :
    IQuantity<TSelf, TUnit, double>,
    IArithmeticQuantity<TSelf>
    where TSelf : IArithmeticQuantity<TSelf, TUnit>
    where TUnit : struct, Enum
{
}

/// <summary>A linear quantity with an additive zero and conventional arithmetic semantics.</summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
public interface ILinearQuantity<TSelf> :
    IArithmeticQuantity<TSelf>,
    IAdditiveIdentity<TSelf, TSelf>
    where TSelf : ILinearQuantity<TSelf>
{
    /// <summary>Gets zero expressed in the quantity's base unit.</summary>
    static abstract TSelf Zero { get; }

    static TSelf IAdditiveIdentity<TSelf, TSelf>.AdditiveIdentity => TSelf.Zero;
}

/// <summary>A strongly typed linear quantity.</summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
/// <typeparam name="TUnit">The unit enum type.</typeparam>
public interface ILinearQuantity<TSelf, TUnit> :
    IArithmeticQuantity<TSelf, TUnit>,
    ILinearQuantity<TSelf>
    where TSelf : ILinearQuantity<TSelf, TUnit>
    where TUnit : struct, Enum
{
}
