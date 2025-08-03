// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet;

/// <summary>
///     An <see cref="IQuantity{TSelf}"/> that (in .NET 7+) implements generic math interfaces for arithmetic operations.
/// </summary>
/// <typeparam name="TSelf">The type itself, for the CRT pattern.</typeparam>
/// <typeparam name="TOffset"></typeparam>
public interface IAffineQuantity<TSelf, TOffset> : IQuantityOfType<TSelf>
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
        bool Equals(TSelf? other, TOffset tolerance);
#endif
}

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
