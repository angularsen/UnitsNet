// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Numerics;
using Fractions;

namespace UnitsNet;

public readonly partial struct QuantityValue
{
    /// <summary>Implicit cast from <see cref="byte" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(byte value)
    {
        return new QuantityValue(new Fraction(value));
    }

    /// <summary>Implicit cast from <see cref="short" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(short value)
    {
        return new QuantityValue(value);
    }

    /// <summary>Implicit cast from <see cref="int" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(int value)
    {
        return new QuantityValue(value);
    }

    /// <summary>Implicit cast from <see cref="uint" /> to <see cref="QuantityValue" />.</summary>
    [CLSCompliant(false)]
    public static implicit operator QuantityValue(uint value)
    {
        return new QuantityValue(value);
    }

    /// <summary>Implicit cast from <see cref="long" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(long value)
    {
        return new QuantityValue(value);
    }

    /// <summary>Implicit cast from <see cref="ulong" /> to <see cref="QuantityValue" />.</summary>
    [CLSCompliant(false)]
    public static implicit operator QuantityValue(ulong value)
    {
        return new QuantityValue(value);
    }

    /// <summary>Implicit cast from <see cref="float" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(float value)
    {
        return new QuantityValue(new Fraction(value));
    }

    /// <summary>Implicit cast from <see cref="double" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(double value)
    {
        // return FromDouble(value);
        return FromDoubleRounded(value);
        // return new QuantityValue(new Fraction(value));
    }

    /// <summary>Implicit cast from <see cref="decimal" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(decimal value)
    {
        return new QuantityValue(new Fraction(value));
    }

    /// <summary>Implicit cast from <see cref="QuantityValue" /> to <see cref="BigInteger" />.</summary>
    public static implicit operator QuantityValue(BigInteger value)
    {
        return new QuantityValue(value);
    }

    /// <summary>
    ///     Creates a new QuantityValue from a decimal number.
    /// </summary>
    /// <param name="value">The decimal number to convert into a QuantityValue.</param>
    /// <returns>A new QuantityValue that represents the given decimal number.</returns>
    public static QuantityValue FromDecimal(decimal value)
    {
        return new QuantityValue(new Fraction(value));
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
    public static QuantityValue FromDoubleRounded(double value, int nbSignificantDigits = 15)
    {
        if (value == 0)
        {
            return Zero;
        }

        // TODO replace these with constants once the issue is resolved: https://github.com/danm-de/Fractions/issues/26
        if (double.IsNaN(value))
        {
            return new QuantityValue(BigInteger.Zero, BigInteger.Zero, false);
        }

        if (double.IsPositiveInfinity(value))
        {
            return new QuantityValue(BigInteger.One, BigInteger.Zero, false);
        }

        if (double.IsNegativeInfinity(value))
        {
            return new QuantityValue(BigInteger.MinusOne, BigInteger.Zero, false);
        }

        // Determine the number of decimal places to keep
        var magnitude = Math.Floor(Math.Log10(Math.Abs(value)));
        if (magnitude > nbSignificantDigits)
        {
            var digitsToKeep = new BigInteger(value / Math.Pow(10, magnitude - nbSignificantDigits));
            return digitsToKeep * BigInteger.Pow(Ten, (int)magnitude - nbSignificantDigits);
        }

        // "decimal" values
        var truncatedValue = Math.Truncate(value);
        var integerPart = new BigInteger(truncatedValue);

        var decimalPlaces = Math.Min(-(int)magnitude + nbSignificantDigits - 1, 308);
        var scaleFactor = Math.Pow(10, decimalPlaces);
        // Get the fractional part
        var fractionalPartDouble = Math.Round((value - truncatedValue) * scaleFactor);
        if (fractionalPartDouble == 0) // rounded to integer
        {
            return new QuantityValue(new Fraction(integerPart));
        }

        var denominator = BigInteger.Pow(Ten, decimalPlaces);
        BigInteger numerator = integerPart * denominator + new BigInteger(fractionalPartDouble);
        return new QuantityValue(numerator, denominator);
    }

    /// <summary>
    ///     Converts a floating point value to a QuantityValue.
    /// </summary>
    /// <param name="value">The floating point value to convert.</param>
    /// <returns>A QuantityValue representing the given floating point value.</returns>
    /// <remarks>
    ///     The double data type stores its values as 64-bit floating point numbers in accordance with the IEC 60559:1989 (IEEE
    ///     754) standard for binary floating-point arithmetic.
    ///     However, the double data type cannot precisely store some binary fractions. For instance, 1/10, which is accurately
    ///     represented by .1 as a decimal fraction, is represented by .0001100110011... as a binary fraction, with the pattern
    ///     0011 repeating indefinitely.
    ///     In such cases, the floating-point value provides an approximate representation of the number.
    /// </remarks>
    /// <example>
    ///     This example shows how to use the <see cref="FromExactDouble" /> method.
    ///     <code>
    /// QuantityValue qv = QuantityValue.FromDouble(0.1);
    /// // Output: 3602879701896397/36028797018963968, which is approximately 0.10000000000000000555111512312578
    /// </code>
    /// </example>
    public static QuantityValue FromExactDouble(double value)
    {
        return new QuantityValue(Fraction.FromDouble(value));
    }
}
