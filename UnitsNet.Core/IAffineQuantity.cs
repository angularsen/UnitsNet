// Licensed under MIT No Attribution, see LICENSE file at the root.

using System.Numerics;

namespace UnitsNet.Core;

/// <summary>
/// A quantity whose unit conversions may include an offset and therefore do not have conventional
/// same-quantity arithmetic semantics.
/// </summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
public interface IAffineQuantity<TSelf>
    where TSelf : IAffineQuantity<TSelf>
{
    /// <summary>Gets zero expressed in the quantity's base unit.</summary>
    static abstract TSelf Zero { get; }
}

/// <summary>An affine quantity whose arithmetic is expressed through a linear offset quantity.</summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
/// <typeparam name="TOffset">The linear quantity type representing differences.</typeparam>
public interface IAffineQuantity<TSelf, TOffset> :
    IAffineQuantity<TSelf>,
    IAdditionOperators<TSelf, TOffset, TSelf>,
    ISubtractionOperators<TSelf, TSelf, TOffset>
    where TSelf : IAffineQuantity<TSelf, TOffset>
    where TOffset : ILinearQuantity<TOffset>
{
}

/// <summary>A strongly typed affine quantity with a linear offset quantity.</summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
/// <typeparam name="TUnit">The unit enum type.</typeparam>
/// <typeparam name="TOffset">The linear quantity type representing differences.</typeparam>
public interface IAffineQuantity<TSelf, TUnit, TOffset> :
    IQuantity<TSelf, TUnit, double>,
    IAffineQuantity<TSelf, TOffset>
    where TSelf : IAffineQuantity<TSelf, TUnit, TOffset>
    where TUnit : struct, Enum
    where TOffset : ILinearQuantity<TOffset>
{
}
