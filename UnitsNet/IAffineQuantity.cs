// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET7_0_OR_GREATER
using System.Numerics;
#endif

namespace UnitsNet;

/// <summary>
///     An <see cref="IQuantity{TSelf, TUnitType}"/> that (in .NET 7+) implements generic math interfaces for arithmetic operations.
/// </summary>
/// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
/// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
/// <typeparam name="TOffset"></typeparam>
public interface IAffineQuantity<TSelf, TUnitType, TOffset> : IQuantity<TSelf, TUnitType>, IAffineQuantity<TSelf, TOffset>
#if NET7_0_OR_GREATER
    , IAdditionOperators<TSelf, TOffset, TSelf>
    , ISubtractionOperators<TSelf, TSelf, TOffset>
    where TOffset : IAdditiveIdentity<TOffset, TOffset>
#endif
    where TSelf : IAffineQuantity<TSelf, TUnitType, TOffset>
    where TUnitType : struct, Enum
{
}

/// <summary>
///     An <see cref="IQuantity{TSelf}"/> that (in .NET 7+) implements generic math interfaces for arithmetic operations.
/// </summary>
/// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
/// <typeparam name="TOffset"></typeparam>
public interface IAffineQuantity<TSelf, TOffset> : IQuantityInstance<TSelf>
#if NET7_0_OR_GREATER
    , IAdditiveIdentity<TSelf, TOffset>
    where TOffset : IAdditiveIdentity<TOffset, TOffset>
#endif
    where TSelf : IAffineQuantity<TSelf, TOffset>
{
#if NET7_0_OR_GREATER
    /// <summary>
    ///     The zero value of this quantity.
    /// </summary>
    static abstract TSelf Zero { get; }

    static TOffset IAdditiveIdentity<TSelf, TOffset>.AdditiveIdentity => TOffset.AdditiveIdentity;
#endif
}
