// Licensed under MIT No Attribution, see LICENSE file at the root.

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

/// <summary>A strongly typed affine quantity.</summary>
/// <typeparam name="TSelf">The concrete quantity type.</typeparam>
/// <typeparam name="TUnit">The unit enum type.</typeparam>
public interface IAffineQuantity<TSelf, TUnit> :
    IQuantity<TSelf, TUnit, double>,
    IAffineQuantity<TSelf>
    where TSelf : IAffineQuantity<TSelf, TUnit>
    where TUnit : struct, Enum
{
}
