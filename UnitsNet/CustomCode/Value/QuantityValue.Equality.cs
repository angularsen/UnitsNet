// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Numerics;
using System.Runtime.CompilerServices;

namespace UnitsNet;

public partial struct QuantityValue
{
    /// <summary>
    ///     Determines whether this QuantityValue instance is equal to another QuantityValue instance.
    /// </summary>
    /// <param name="other">The QuantityValue to compare with this instance.</param>
    /// <returns>True if the two QuantityValue instances are equal, false otherwise.</returns>
    public bool Equals(QuantityValue other)
    {
        var numerator1 = Numerator;
        var denominator1 = Denominator;
        var numerator2 = other.Numerator;
        var denominator2 = other.Denominator;
        
        if (denominator1 == denominator2)
        {
            return denominator1.IsZero
                ? numerator1.Sign == numerator2.Sign // both fractions represent infinities
                : numerator1 == numerator2;
        }

        if (denominator1.IsZero || denominator2.IsZero)
        {
            // either x or y is NaN or infinity.
            return false;
        }

        if (numerator1.IsZero)
        {
            return numerator2.IsZero; // if TRUE, both values are 0
        }

        if (numerator2.IsZero)
        {
            return false;
        }

        var firstNumeratorSign = numerator1.Sign;
        var secondNumeratorSign = numerator2.Sign;
        if (firstNumeratorSign != secondNumeratorSign)
        {
            return false; // different signs
        }

        // both values are non-zero fractions with different denominators
        if (denominator1 < denominator2)
        {
            // reverse the comparison from x == y to y == x
            Swap(ref numerator1, ref numerator2);
            Swap(ref denominator1, ref denominator2);
        }

        // from here [denominator1 > denominator2 > 0] applies
        if (firstNumeratorSign == 1)
        {
            // both fractions are greater than 0 (positive)

            // After the swap, [numerator1 > numerator2 > 0] is expected if both fractions were equal.
            // example: {10/10} and {1/1} or {10/100} and {1/10}
            if (numerator1 <= numerator2)
            {
                return false;
            }

            if (numerator2.IsOne)
            {
                return denominator2.IsOne
                    ? numerator1 == denominator1 // if equal, then {n/n} == {1/1}
                    : numerator1 * denominator2 == denominator1; // if equal, then {a/(a*b)} == {1/b}
            }
        }
        else
        {
            // both fractions are less than 0 (negative)

            // After the swap, [numerator1 < numerator2 < 0] is expected if both fractions were equal.
            // example: {-10/10} and {-1/1} or {-10/100} and {-1/10}
            if (numerator1 >= numerator2)
            {
                return false;
            }

            if (numerator2 == BigInteger.MinusOne)
            {
                return denominator2.IsOne
                    ? numerator1 == -denominator1 // if equal, then {-a/a} == {-1/1}
                    : numerator1 * -denominator2 == denominator1; // if equal, then {a/(a*-b)} == {-1/b}
            }
        }

        if (denominator2.IsOne)
        {
            return numerator1 == numerator2 * denominator1; // if equal, then {(b*a)/a} == {b/1}
        }

        /*
         * The following algorithm checks whether both fractions have the same ratio between numerator and denominator.
         *
         * Assumed that
         * x = {n1/d1}
         * y = {n2/d2}
         *
         * If x / y == 1 then x == y.
         *
         * This gives us:
         * {n1/d1} / {n2/d2} == {(n1*d2) / (d1*n2)} == {n1/n2} / {d2/d1}
         *
         * If both fractions are equal their ratio is exactly 1:
         * {n1/n2} / {d2/d1} == 1
         * And from this it follows:
         * {n1/n2} == {d1/d2}
         */

        var numeratorQuotient = BigInteger.DivRem(numerator1, numerator2, out var remainderNumerators);
        var denominatorQuotient = BigInteger.DivRem(denominator1, denominator2, out var remainderDenominators);

        // If the fractions are equal: numeratorQuotient should be equal to denominatorQuotient.
        if (numeratorQuotient != denominatorQuotient)
        {
            return false;
        }

        // if the fractions are equal: {remainderNumerators / numerator2} should be equal to {remainderDenominators / denominator2}
        if (remainderDenominators.IsZero)
        {
            return remainderNumerators.IsZero; // if equal, then both values must be 0 
        }

        if (remainderNumerators.IsZero)
        {
            return false; // if equal, then both values must be 0 
        }

        /*
         * Since the decimal places disappear when dividing integer data types, the formula must be converted into a multiplication:
         * {rN / n2} == {rD / d2}
         * can be written as:
         * (rN * d2) == (rD * n2)
         */
        return remainderNumerators * denominator2 == remainderDenominators * numerator2;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void Swap(ref BigInteger a, ref BigInteger b)
    {
        (a, b) = (b, a);
    }

    /// <summary>
    ///     Determines whether this QuantityValue instance is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare with this instance.</param>
    /// <returns>True if the object is a QuantityValue instance and is equal to this instance, false otherwise.</returns>
    public override bool Equals(object? obj)
    {
        return obj is QuantityValue other && Equals(other);
    }

    /// <summary>
    ///     Returns the hash code for this QuantityValue instance.
    /// </summary>
    /// <returns>The hash code.</returns>
    public override int GetHashCode()
    {
        var fraction = Reduce(this);
        unchecked {
            return (fraction.Denominator.GetHashCode() * 397) ^ fraction.Numerator.GetHashCode();
        }
    }

    /// <summary>
    ///     Compares two QuantityValue instances for equality.
    /// </summary>
    /// <param name="a">The first QuantityValue.</param>
    /// <param name="b">The second QuantityValue.</param>
    /// <returns>True if the two QuantityValue instances are equal, false otherwise.</returns>
    public static bool operator ==(QuantityValue a, QuantityValue b)
    {
        return a.Equals(b) && !IsNaN(a) && !IsNaN(b);
    }

    /// <summary>
    ///     Compares two QuantityValue instances for inequality.
    /// </summary>
    /// <param name="a">The first QuantityValue.</param>
    /// <param name="b">The second QuantityValue.</param>
    /// <returns>True if the two QuantityValue instances are not equal, false otherwise.</returns>
    public static bool operator !=(QuantityValue a, QuantityValue b)
    {
        return !a.Equals(b) || IsNaN(a) || IsNaN(b);
    }
}