// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Numerics;
using Fractions;

namespace CodeGen.Helpers.ExpressionAnalyzer.Functions.Math;

/// <summary>
/// We should try to push these extensions to the original library (working on the PRs)
/// </summary>
internal static class FractionExtensions
{
    public static readonly Fraction OneHalf = new(BigInteger.One, new BigInteger(2));
    public static readonly BigInteger Ten = new(10);

    public static Fraction Pow(this Fraction x, Fraction power)
    {
        if (power == Fraction.One)
        {
            return x;
        }
        
        if (x == Fraction.One)
        {
            return x;
        }
        
        if (power.Denominator == Fraction.One)
        {
            return Fraction.Pow(x, (int)power);
        }
        
        // return FractionExtensions.FromDoubleRounded(System.Math.Pow(x.ToDouble(), power.ToDouble()));
        return PowRational(x, power);
        // if (power == OneHalf)
        // {
        //     return x.Sqrt();
        // }
        //
    }

    private static Fraction PowRational(this Fraction x, Fraction power)
    {
        var numeratorRaised = Fraction.Pow(x, (int)power.Numerator);
        return numeratorRaised.Root((int)power.Denominator, BigInteger.Pow(10, 12));
    }

    public static Fraction Root(this Fraction number, int n, BigInteger precision)
    {
        // Fraction x = number; // Initial guess
        var initialGuess = System.Math.Pow(number.ToDouble(), 1.0/n);
        Fraction x =
            initialGuess == 0.0 ? number:
            FromDoubleRounded(initialGuess); // Initial guess
        Fraction xPrev;
        var minChange = new Fraction(1, precision);
        do
        {
            xPrev = x;
            x = ((n - 1) * x + number / Fraction.Pow(x, n - 1)) / n;
        } while ((x - xPrev).Abs() > minChange);
        return x;
    }
    
    /// <summary>
    ///     Converts a floating point value to a QuantityValue. The value is rounded if possible.
    /// </summary>
    /// <param name="value">The floating point value to convert.</param>
    /// <param name="nbSignificantDigits"></param>
    /// <returns>A QuantityValue representing the rounded floating point value.</returns>
    /// <remarks>
    ///     The double data type stores its values as 64-bit floating point numbers in accordance with the IEC 60559:1989 (IEEE
    ///     754) standard for binary floating-point arithmetic.
    ///     However, the double data type cannot precisely store some binary fractions. For instance, 1/10, which is accurately
    ///     represented by .1 as a decimal fraction, is represented by .0001100110011... as a binary fraction, with the pattern
    ///     0011 repeating indefinitely.
    ///     In such cases, the floating-point value provides an approximate representation of the number.
    ///     <para>
    ///         This method can be used to avoid large numbers in the numerator and denominator. However, be aware that the
    ///         creation speed is significantly slower than using the pure value resulting from casting to double.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     This example shows how to use the <see cref="FromDoubleRounded(double, int)" /> method.
    ///     <code>
    /// QuantityValue qv = QuantityValue.FromDoubleRounded(0.1);
    /// // Output: 1/10, which is exactly 0.1
    /// </code>
    /// </example>
    public static Fraction FromDoubleRounded(double value, int nbSignificantDigits = 15)
    {
        if (value == 0)
        {
            return Fraction.Zero;
        }

        // Determine the number of decimal places to keep
        var magnitude = System.Math.Floor( System.Math.Log10( System.Math.Abs(value)));
        if (magnitude > nbSignificantDigits)
        {
            var digitsToKeep = new BigInteger(value /  System.Math.Pow(10, magnitude - nbSignificantDigits));
            return digitsToKeep * BigInteger.Pow(Ten, (int)magnitude - nbSignificantDigits);
        }

        // "decimal" values
        var truncatedValue =  System.Math.Truncate(value);
        var integerPart = new BigInteger(truncatedValue);

        var decimalPlaces =  System.Math.Min(-(int)magnitude + nbSignificantDigits - 1, 308);
        var scaleFactor =  System.Math.Pow(10, decimalPlaces);
        // Get the fractional part
        var fractionalPartDouble =  System.Math.Round((value - truncatedValue) * scaleFactor);
        if (fractionalPartDouble == 0) // rounded to integer
        {
            return new Fraction(integerPart);
        }

        var denominator = BigInteger.Pow(Ten, decimalPlaces);
        BigInteger numerator = integerPart * denominator + new BigInteger(fractionalPartDouble);
        return new Fraction(numerator, denominator);
    }

    /// <summary>
    ///     Rounds the given Fraction to the specified number of digits.
    /// </summary>
    /// <param name="x">The Fraction to be rounded.</param>
    /// <param name="nbDigits">The number of decimal places in the return value.</param>
    /// <returns>A new Fraction that is the nearest number with the specified number of digits.</returns>
    public static Fraction Round(this Fraction x, int nbDigits)
    {
        var factor = BigInteger.Pow(10, nbDigits);
        var numerator = x.Numerator * factor;
        var roundedNumerator = BigInteger.Divide(numerator + x.Denominator / 2, x.Denominator);
        return new Fraction(roundedNumerator, factor);
    }
}
