// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet;

/// <summary>
///     Compare equality to another <typeparamref name="TQuantity"/> within the given absolute or relative tolerance.
/// </summary>
/// <typeparam name="TQuantity">Type of quantity.</typeparam>
public interface IEquatableQuantity<in TQuantity>
{
    /// <summary>
    ///     <para>
    ///     Compare equality to another <typeparamref name="TQuantity"/> within the given absolute or relative tolerance.
    ///     </para>
    ///     <para>
    ///     Relative tolerance is defined as the maximum allowable absolute difference between this quantity's value and
    ///     <paramref name="other"/> as a percentage of this quantity's value. <paramref name="other"/> will be converted into
    ///     this quantity's unit for comparison. A relative tolerance of 0.01 means the absolute difference must be within +/- 1% of
    ///     this quantity's value to be considered equal.
    ///     <example>
    ///     In this example, the two quantities will be equal if the value of b is within +/- 1% of a (0.02m or 2cm).
    ///     <code>
    ///     var a = Length.FromMeters(2.0);
    ///     var b = Length.FromInches(50.0);
    ///     a.Equals(b, 0.01, ComparisonType.Relative);
    ///     </code>
    ///     </example>
    ///     </para>
    ///     <para>
    ///     Absolute tolerance is defined as the maximum allowable absolute difference between this quantity's value and
    ///     <paramref name="other"/> as a fixed number in this quantity's unit. <paramref name="other"/> will be converted into
    ///     this quantity's unit for comparison.
    ///     <example>
    ///     In this example, the two quantities will be equal if the value of b is within 0.01 of a (0.01m or 1cm).
    ///     <code>
    ///     var a = Length.FromMeters(2.0);
    ///     var b = Length.FromInches(50.0);
    ///     a.Equals(b, 0.01, ComparisonType.Absolute);
    ///     </code>
    ///     </example>
    ///     </para>
    ///     <para>
    ///     Note that it is advised against specifying zero difference, due to the nature of floating-point operations and using double internally.
    ///     </para>
    /// </summary>
    /// <param name="other">The other quantity to compare to.</param>
    /// <param name="tolerance">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
    /// <param name="comparisonType">The comparison type: either relative or absolute.</param>
    /// <returns>True if the absolute difference between the two values is not greater than the specified relative or absolute tolerance.</returns>
    bool Equals(TQuantity? other, double tolerance, ComparisonType comparisonType);
}
