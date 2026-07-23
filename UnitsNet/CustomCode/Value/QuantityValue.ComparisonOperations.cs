// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Numerics;

namespace UnitsNet;

public partial struct QuantityValue
{
    /// <summary>
    ///     Greater-than operator
    /// </summary>
    public static bool operator >(QuantityValue a, QuantityValue b)
    {
        return a.CompareTo(b) > 0 && !IsNaN(a) && !IsNaN(b);
    }

    /// <summary>
    ///     Less-than operator
    /// </summary>
    public static bool operator <(QuantityValue a, QuantityValue b)
    {
        return a.CompareTo(b) < 0 && !IsNaN(a) && !IsNaN(b);
    }

    /// <summary>
    ///     Greater-than-or-equal operator
    /// </summary>
    public static bool operator >=(QuantityValue a, QuantityValue b)
    {
        return a.CompareTo(b) >= 0 && !IsNaN(a) && !IsNaN(b);
    }

    /// <summary>
    ///     Less-than-or-equal operator
    /// </summary>
    public static bool operator <=(QuantityValue a, QuantityValue b)
    {
        return a.CompareTo(b) <= 0 && !IsNaN(a) && !IsNaN(b);
    }

    /// <summary>
    ///     Compares this QuantityValue instance to another QuantityValue instance.
    /// </summary>
    /// <param name="other">The QuantityValue to compare with this instance.</param>
    /// <returns>
    ///     A value indicating the relative order of the QuantityValue instances being compared.
    ///     Less than zero: This instance is less than the other instance.
    ///     Zero: This instance is equal to the other instance.
    ///     Greater than zero: This instance is greater than the other instance.
    /// </returns>
    public int CompareTo(QuantityValue other)
    {
        var numerator1 = Numerator;
        var denominator1 = Denominator;
        var numerator2 = other.Numerator;
        var denominator2 = other.Denominator;

        if (denominator1 == denominator2)
        {
            if (!denominator1.IsZero)
            {
                return numerator1.CompareTo(numerator2); // finite numbers: {-1/2} < {1/2}
            }

            if (numerator1.IsZero)
            {
                return numerator2.IsZero ? 0 : -1; // NaN and anything else
            }

            if (numerator2.IsZero)
            {
                return 1; // other is NaN
            }

            // comparing infinities
            return numerator1.Sign.CompareTo(numerator2.Sign);
        }

        if (denominator1.IsZero)
        {
            return numerator1.Sign switch
            {
                1 => 1, // PositiveInfinity -> 1
                _ => -1 // NaN or NegativeInfinity -> -1
            };
        }

        if (denominator2.IsZero)
        {
            return numerator2.Sign switch
            {
                1 => -1, // PositiveInfinity -> -1
                _ => 1 // NaN or NegativeInfinity -> 1
            };
        }

        var firstNumeratorSign = numerator1.Sign;
        var secondNumeratorSign = numerator2.Sign;

        if (firstNumeratorSign != secondNumeratorSign)
        {
            return firstNumeratorSign.CompareTo(secondNumeratorSign);
        }

        if (firstNumeratorSign == 0)
        {
            return 0; // both fractions are zeros
        }

        // both values are non-zero fractions with different denominators
        if (denominator1 < denominator2)
        {
            // reverse the comparison from x.CompareTo(y) to y.CompareTo(x)
            return firstNumeratorSign == 1
                ? -ComparePositiveTerms(numerator2, denominator2, numerator1, denominator1)
                : -CompareNegativeTerms(numerator2, denominator2, numerator1, denominator1);
        }

        return firstNumeratorSign == 1
            ? ComparePositiveTerms(numerator1, denominator1, numerator2, denominator2)
            : CompareNegativeTerms(numerator1, denominator1, numerator2, denominator2);

        static int ComparePositiveTerms(BigInteger numerator1, BigInteger denominator1, BigInteger numerator2, BigInteger denominator2)
        {
            // From here [denominator1 > denominator2 > 0] applies

            // example: {10/10} and {1/1} or {10/100} and {1/10}
            if (numerator1 <= numerator2)
            {
                return -1; // expecting: 0 < numerator2 < numerator1
            }

            if (numerator2.IsOne)
            {
                if (denominator2.IsOne)
                {
                    // {n1/d1}.CompareTo({1/1})
                    return numerator1.CompareTo(denominator1);
                }

                // {n1/d1}.CompareTo({1/d2}) => {(n1*d2)/d1}.CompareTo(1) => (n1*d2).CompareTo(d1)
                return (numerator1 * denominator2).CompareTo(denominator1);
            }

            if (denominator2.IsOne)
            {
                // {n1/d1}.CompareTo({n2/1}) => (n1).CompareTo((n2*d1))
                return numerator1.CompareTo(numerator2 * denominator1);
            }

            /* Comparing the positive term ratios:
             * {9/7} / {4/3} = {(1 + 2/7) / (1 + 1/3)} = {27/28}
             *               => ((1).CompareTo(1)) == 0 and ((2/7).CompareTo(1/3)) == -1
             * Given that:
             * {a/b} / {c/d} = {a/b} * {d/c} = {(a*d)/(c*b)} = {a/c} * {d/b} = {a/c} / {b/d}
             * we can also write:
             * {9/4} / {7/3} = {(2 + 1/4) / (2 + 1/3)} = {27/28}
             *               => ((2).CompareTo(2)) == 0 and ((1/4).CompareTo(1/3)) == -1
             */

            var denominatorQuotient = BigInteger.DivRem(denominator1, denominator2, out var remainderDenominators);
            if (remainderDenominators.IsZero)
            {
                /* Example:
                 * {7/4} / {3/2}         =
                 * {7/3} / {4/2}         =
                 * {(2 + 1/3) / (2 + 0)} =
                 * {7/3} / 2             = {7/6}
                 *                       => (7).CompareTo(3*2) == 1
                 */
                return numerator1.CompareTo(numerator2 * denominatorQuotient);
            }

            var numeratorQuotient = BigInteger.DivRem(numerator1, numerator2, out var remainderNumerators);
            // if the fractions are equal: numeratorQuotient should be equal to denominatorQuotient
            var quotientComparison = numeratorQuotient.CompareTo(denominatorQuotient);
            if (quotientComparison != 0)
            {
                return quotientComparison;
            }

            // if the fractions are equal: {remainderNumerators / numerator2} should be equal to {remainderDenominators / denominator2}
            if (remainderNumerators.IsZero)
            {
                /* Example:
                 * {6/5} / {3/2}   =
                 * {6/3} / {5/2}   =
                 * {2 / (2 + 1/2)} =
                 * {2 / (3/2)}     = {4/3}
                 */
                return -1; // when both values are 0 the fractions are equal
            }

            return (remainderNumerators * denominator2).CompareTo(remainderDenominators * numerator2);
        }

        static int CompareNegativeTerms(BigInteger numerator1, BigInteger denominator1, BigInteger numerator2, BigInteger denominator2)
        {
            // From here [denominator1 > denominator2 > 0] applies

            // example: {-10/10} and {-1/1} or {-10/100} and {-1/10}
            if (numerator1 >= numerator2)
            {
                return 1; // expecting: numerator1 < numerator2 < 0
            }

            if (numerator2 == BigInteger.MinusOne)
            {
                return denominator2.IsOne ? numerator1.CompareTo(-denominator1) : denominator1.CompareTo(numerator1 * -denominator2);
            }

            if (denominator2.IsOne)
            {
                return numerator1.CompareTo(numerator2 * denominator1);
            }

            /* Comparing the negative term ratios, example:
             * {-9/7} / {-4/3} = {(-1 + -2/7) / (-1 + -1/3)} = {27/28}
             *                 => ((-1).CompareTo(-1)) == 0 and ((-2/7).CompareTo(-1/3)) == 1
             * Given that:
             * {a/b} / {c/d} = {a/b} * {d/c} = {(a*d)/(c*b)} = {a/c} * {d/b} = {a/c} / {b/d}
             * we can also write:
             * {-9/4} / {-7/3} = {(-2 + -1/4) / (-2 - 1/3)} = {27/28}
             *                 => ((-2).CompareTo(-2)) == 0 and ((-1/4).CompareTo(-1/3)) == 1
             */
            var denominatorQuotient = BigInteger.DivRem(denominator1, denominator2, out var remainderDenominators);
            if (remainderDenominators.IsZero)
            {
                // {-7/4} / {-3/2} = {(2 + 1/3) / 2} = {(7/3)/2} = {7/6}
                return numerator1.CompareTo(numerator2 * denominatorQuotient);
            }

            var numeratorQuotient = BigInteger.DivRem(numerator1, numerator2, out var remainderNumerators);
            // if the fractions are equal: numeratorQuotient should be equal to denominatorQuotient
            var quotientComparison = numeratorQuotient.CompareTo(denominatorQuotient);
            if (quotientComparison != 0)
            {
                return -quotientComparison;
            }

            // if the fractions are equal: {remainderNumerators / numerator2} should be equal to {remainderDenominators / denominator2}
            if (remainderNumerators.IsZero)
            {
                return 1; // when both values are 0 the fractions are equal
            }

            return (remainderNumerators * denominator2).CompareTo(remainderDenominators * numerator2);
        }
    }

    /// <summary>
    ///     Compares this QuantityValue instance to another object.
    /// </summary>
    /// <param name="obj">The object to compare with this instance.</param>
    /// <returns>
    ///     A value indicating the relative order of the QuantityValue instances being compared.
    ///     Less than zero: This instance is less than the other instance.
    ///     Zero: This instance is equal to the other instance.
    ///     Greater than zero: This instance is greater than the other instance.
    /// </returns>
    public int CompareTo(object? obj)
    {
        return obj switch
        {
            null => 1,
            QuantityValue other => CompareTo(other),
            _ => throw new ArgumentException($"Object must be of type {nameof(QuantityValue)}")
        };
    }

    /// <summary>
    ///     Returns the <see cref="QuantityValue" /> with the maximum magnitude from the two provided values.
    /// </summary>
    /// <param name="x">The first <see cref="QuantityValue" /> to compare.</param>
    /// <param name="y">The second <see cref="QuantityValue" /> to compare.</param>
    /// <returns>The <see cref="QuantityValue" /> with the maximum magnitude.</returns>
    public static QuantityValue MaxMagnitude(QuantityValue x, QuantityValue y)
    {
        if (IsNaN(x))
        {
            return x;
        }

        if (IsNaN(y))
        {
            return y;
        }

        // note: unlike the <= operator, CompareTo with NaN returns NaN
        var comparison = Abs(x).CompareTo(Abs(y));
        return comparison switch
        {
            1 => x,
            -1 => y,
            _ => IsNegative(x) ? y : x
        };
    }

    /// <summary>
    ///     Compares two values to compute which has the greater magnitude and returning the other value if an input is
    ///     <c>NaN</c>.
    /// </summary>
    /// <param name="x">The value to compare with <paramref name="y" />.</param>
    /// <param name="y">The value to compare with <paramref name="x" />.</param>
    /// <returns>
    ///     <paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.
    /// </returns>
    public static QuantityValue MaxMagnitudeNumber(QuantityValue x, QuantityValue y)
    {
        if (IsNaN(x))
        {
            return y;
        }

        if (IsNaN(y))
        {
            return x;
        }

        var comparison = Abs(x).CompareTo(Abs(y));
        return comparison switch
        {
            1 => x,
            -1 => y,
            _ => IsNegative(x) ? y : x
        };
    }

    /// <summary>
    ///     Returns the QuantityValue with the smallest magnitude from the two provided QuantityValues.
    /// </summary>
    /// <param name="x">The first QuantityValue to compare.</param>
    /// <param name="y">The second QuantityValue to compare.</param>
    /// <returns>The QuantityValue with the smallest magnitude.</returns>
    public static QuantityValue MinMagnitude(QuantityValue x, QuantityValue y)
    {
        var comparison = Abs(x).CompareTo(Abs(y));
        return comparison switch
        {
            -1 => x,
            1 => y,
            _ => IsNegative(x) ? x : y
        };
    }

    /// <summary>
    ///     Compares two values to compute which has the lesser magnitude and returning the other value if an input is
    ///     <c>NaN</c>.
    /// </summary>
    /// <param name="x">The value to compare with <paramref name="y" />.</param>
    /// <param name="y">The value to compare with <paramref name="x" />.</param>
    /// <returns>
    ///     <paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.
    /// </returns>
    public static QuantityValue MinMagnitudeNumber(QuantityValue x, QuantityValue y)
    {
        return IsNaN(x) ? y : IsNaN(y) ? x : MinMagnitude(x, y);
    }
}