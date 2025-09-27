// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet;

/// <summary>
///     Helper methods to perform relative and absolute comparison.
/// </summary>
public static class Comparison
{
    /// <summary>
    ///     <para>
    ///         Checks if two values are equal with a given relative or absolute tolerance.
    ///     </para>
    ///     <para>
    ///         Relative tolerance is defined as the maximum allowable absolute difference between
    ///         <paramref name="referenceValue" /> and
    ///         <paramref name="otherValue" /> as a percentage of <paramref name="referenceValue" />. A relative tolerance of
    ///         0.01 means the
    ///         absolute difference of <paramref name="referenceValue" /> and <paramref name="otherValue" /> must be within +/-
    ///         1%.
    ///         <example>
    ///             In this example, the two values will be equal if the value of b is within +/- 1% of a.
    ///             <code>
    ///     Equals(a, b, 0.01, ComparisonType.Relative);
    ///     </code>
    ///         </example>
    ///     </para>
    ///     <para>
    ///         Absolute tolerance is defined as the maximum allowable absolute difference between
    ///         <paramref name="referenceValue" /> and
    ///         <paramref name="otherValue" /> as a fixed number.
    ///         <example>
    ///             In this example, the two values will be equal if abs(<paramref name="referenceValue" /> -
    ///             <paramref name="otherValue" />) &lt;= 0.01
    ///             <code>
    ///     Equals(a, b, 0.01, ComparisonType.Absolute);
    ///     </code>
    ///         </example>
    ///     </para>
    /// </summary>
    /// <param name="referenceValue">
    ///     The reference value. If using relative tolerance, it is the value which the relative
    ///     tolerance will be calculated against.
    /// </param>
    /// <param name="otherValue">The value to compare to.</param>
    /// <param name="tolerance">The absolute or relative tolerance value. Must be greater than or equal to 0.</param>
    /// <param name="comparisonType">Whether the tolerance is absolute or relative.</param>
    /// <returns>True if the two values are equal within the given tolerance, otherwise false.</returns>
    /// <exception cref="ArgumentOutOfRangeException"> Thrown when the <paramref name="tolerance"/> is negative.</exception>
    public static bool Equals(QuantityValue referenceValue, QuantityValue otherValue, QuantityValue tolerance, ComparisonType comparisonType)
    {
        return comparisonType switch
        {
            ComparisonType.Relative => EqualsRelative(referenceValue, otherValue, tolerance),
            ComparisonType.Absolute => EqualsAbsolute(referenceValue, otherValue, tolerance),
            _ => throw new InvalidOperationException("The given ComparisonType is not supported.")
        };
    }

    /// <summary>
    ///     Checks if two values are equal with a given relative tolerance.
    ///     <para>
    ///         Relative tolerance is defined as the maximum allowable absolute difference between
    ///         <paramref name="referenceValue" /> and
    ///         <paramref name="otherValue" /> as a percentage of <paramref name="referenceValue" />. A relative tolerance of
    ///         0.01 means the
    ///         absolute difference of <paramref name="referenceValue" /> and <paramref name="otherValue" /> must be within +/-
    ///         1%.
    ///         <example>
    ///             In this example, the two values will be equal if the value of b is within +/- 1% of a.
    ///             <code>
    ///     EqualsRelative(a, b, 0.01);
    ///     </code>
    ///         </example>
    ///     </para>
    /// </summary>
    /// <param name="referenceValue">The reference value which the tolerance will be calculated against.</param>
    /// <param name="otherValue">The value to compare to.</param>
    /// <param name="tolerance">The relative tolerance. Must be greater than or equal to 0.</param>
    /// <returns>True if the two values are equal within the given relative tolerance, otherwise false.</returns>
    /// <exception cref="ArgumentOutOfRangeException"> Thrown when the <paramref name="tolerance"/> is negative.</exception>
    public static bool EqualsRelative(QuantityValue referenceValue, QuantityValue otherValue, QuantityValue tolerance)
    {
        if (QuantityValue.IsNegative(tolerance))
        {
            throw ExceptionHelper.CreateArgumentOutOfRangeExceptionForNegativeTolerance(nameof(tolerance));
        }
        
        var maxVariation = QuantityValue.Abs(referenceValue) * tolerance;
        return QuantityValue.Abs(referenceValue - otherValue) <= maxVariation;
    }

    /// <summary>
    ///     Checks if two values are equal with a given absolute tolerance.
    ///     <para>
    ///         Absolute tolerance is defined as the maximum allowable absolute difference between <paramref name="value1" />
    ///         and
    ///         <paramref name="value2" /> as a fixed number.
    ///         <example>
    ///             In this example, the two values will be equal if abs(<paramref name="value1" /> -
    ///             <paramref name="value2" />) &lt;= 0.01
    ///             <code>
    ///     Equals(a, b, 0.01, ComparisonType.Absolute);
    ///     </code>
    ///         </example>
    ///     </para>
    /// </summary>
    /// <param name="value1">The first value.</param>
    /// <param name="value2">The second value.</param>
    /// <param name="tolerance">The absolute tolerance. Must be greater than or equal to 0.</param>
    /// <returns>True if the two values are equal within the given absolute tolerance, otherwise false.</returns>
    /// <exception cref="ArgumentOutOfRangeException"> Thrown when the <paramref name="tolerance"/> is negative.</exception>
    public static bool EqualsAbsolute(QuantityValue value1, QuantityValue value2, QuantityValue tolerance)
    {
        if (QuantityValue.IsNegative(tolerance))
        {
            throw ExceptionHelper.CreateArgumentOutOfRangeExceptionForNegativeTolerance(nameof(tolerance));
        }

        return QuantityValue.Abs(value1 - value2) <= tolerance;
    }

    internal static int GetHashCode(Type type, QuantityValue value)
    {
#if NET7_0_OR_GREATER
        return HashCode.Combine(type, value);
        #else
        unchecked
        {
            var hash = 17;
            hash = hash * 23 + type.GetHashCode();
            hash = hash * 23 + value.GetHashCode();
            return hash;
        }
#endif
    }
}
