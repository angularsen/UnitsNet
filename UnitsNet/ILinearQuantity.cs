// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

#if NET7_0_OR_GREATER
using System.Numerics;
#endif

namespace UnitsNet;

/// <summary>
///     An <see cref="ILinearQuantity{TSelf}" /> with a strongly typed unit enum.
/// </summary>
/// <remarks>
///     This interface represents linear quantities with known unit enum types, and (in .NET 7+) implements generic math
///     interfaces for arithmetic operations.
/// </remarks>
/// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
/// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
public interface ILinearQuantity<TSelf, TUnitType> : IArithmeticQuantity<TSelf, TUnitType>, ILinearQuantity<TSelf>
    where TSelf : ILinearQuantity<TSelf, TUnitType>
    where TUnitType : struct, Enum
{
}

/// <summary>
///     Represents a quantity that has both magnitude and direction, supporting various arithmetic operations and
///     comparisons.
/// </summary>
/// <remarks>
///     This interface defines standard linear arithmetic operations such as addition, subtraction, multiplication, and
///     division.
///     These types of quantities naturally support comparison operations with either absolute or relative tolerance, which
///     is useful for determining equality within a certain margin of error.
///     <para>
///         For more information, see the Wikipedia page on
///         <a href="https://en.wikipedia.org/wiki/Dimensional_analysis#Geometry:_position_vs._displacement">
///             Dimensional
///             Analysis
///         </a>
///         .
///     </para>
/// </remarks>
/// <typeparam name="TSelf">The type that implements this interface.</typeparam>
public interface ILinearQuantity<TSelf> : IQuantityOfType<TSelf>, IArithmeticQuantity<TSelf>
#if NET7_0_OR_GREATER
    , IAdditiveIdentity<TSelf, TSelf>
#endif
    where TSelf : ILinearQuantity<TSelf>
{
#if NET7_0_OR_GREATER
    /// <summary>
    ///     The zero value of this quantity.
    /// </summary>
    static abstract TSelf Zero { get; }

    static TSelf IAdditiveIdentity<TSelf, TSelf>.AdditiveIdentity
    {
        get => TSelf.Zero;
    }

#endif
}
