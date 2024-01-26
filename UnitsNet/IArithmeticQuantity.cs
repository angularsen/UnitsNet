// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Numerics;

namespace UnitsNet;

/// <summary>
///     An <see cref="IQuantity{TSelf, TUnitType}"/> that (in .NET 7+) implements generic math interfaces for arithmetic operations.
/// </summary>
/// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
/// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
public interface IArithmeticQuantity<TSelf, TUnitType> : IQuantity<TSelf, TUnitType>
#if NET7_0_OR_GREATER
    , IAdditionOperators<TSelf, TSelf, TSelf>
    , IAdditiveIdentity<TSelf, TSelf>
    , ISubtractionOperators<TSelf, TSelf, TSelf>
    , IMultiplyOperators<TSelf, double, TSelf>
    , IDivisionOperators<TSelf, double, TSelf>
    , IUnaryNegationOperators<TSelf, TSelf>
#endif
    where TSelf : IArithmeticQuantity<TSelf, TUnitType>
    where TUnitType : Enum
{
#if NET7_0_OR_GREATER
    /// <summary>
    ///     The zero value of this quantity.
    /// </summary>
    static abstract TSelf Zero { get; }
#endif
}
