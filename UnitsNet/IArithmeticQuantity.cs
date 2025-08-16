// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet;

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
public interface ILinearQuantity<TSelf> : IQuantityOfType<TSelf>
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

#if EXTENDED_EQUALS_INTERFACE
        /// <summary>
        ///     <para>
        ///     Compare equality to <paramref name="other"/> given a <paramref name="tolerance"/> for the maximum allowed +/- difference.
        ///     </para>
        ///     <example>
        ///     In this example, the two quantities will be equal if the value of b is within 0.01 of a (0.01m or 1cm).
        ///     <code>
        ///     var a = Length.FromMeters(2.0);
        ///     var b = Length.FromMeters(2.1);
        ///     var tolerance = Length.FromCentimeters(10);
        ///     a.Equals(b, tolerance); // true, 2m equals 2.1m +/- 0.1m
        ///     </code>
        ///     </example>
        ///     <para>
        ///     It is generally advised against specifying "zero" tolerance, due to the nature of floating-point operations.
        ///     </para>
        /// </summary>
        /// <param name="other">The other quantity to compare to.</param>
        /// <param name="tolerance">The absolute tolerance value. Must be greater than or equal to zero.</param>
        /// <returns>True if the absolute difference between the two values is not greater than the specified tolerance.</returns>
        bool Equals(TSelf? other, TSelf tolerance);
#endif
}

/// <summary>
///     An <see cref="IQuantity{TSelf, TUnitType}" /> that (in .NET 7+) implements generic math interfaces for arithmetic
///     operations.
/// </summary>
/// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
/// <typeparam name="TUnitType">The underlying unit enum type.</typeparam>
public interface IArithmeticQuantity<TSelf, TUnitType> : IQuantity<TSelf, TUnitType>, ILinearQuantity<TSelf>
#if NET7_0_OR_GREATER
    , IAdditionOperators<TSelf, TSelf, TSelf>
    , ISubtractionOperators<TSelf, TSelf, TSelf>
    , IMultiplyOperators<TSelf, QuantityValue, TSelf>
    , IDivisionOperators<TSelf, QuantityValue, TSelf>
    , IUnaryNegationOperators<TSelf, TSelf>
#endif
    where TSelf : IArithmeticQuantity<TSelf, TUnitType>
    where TUnitType : struct, Enum
{
}
