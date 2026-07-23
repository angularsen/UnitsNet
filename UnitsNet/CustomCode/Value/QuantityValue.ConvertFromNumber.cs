// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Numerics;
#if NET
using System.Runtime.CompilerServices;
#endif

namespace UnitsNet;

public partial struct QuantityValue
{
    /// <summary>Implicit cast from <see cref="byte" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(byte value)
    {
        return new QuantityValue(value, BigInteger.One);
    }

    /// <summary>Implicit cast from <see cref="sbyte" /> to <see cref="QuantityValue" />.</summary>
    [CLSCompliant(false)]
    public static implicit operator QuantityValue(sbyte value)
    {
        return new QuantityValue(value);
    }

    /// <summary>Implicit cast from <see cref="short" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(short value)
    {
        return new QuantityValue(value);
    }

    /// <summary>Implicit cast from <see cref="ushort" /> to <see cref="QuantityValue" />.</summary>
    [CLSCompliant(false)]
    public static implicit operator QuantityValue(ushort value)
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
        return FromDoubleRounded(value);
    }

    /// <summary>Implicit cast from <see cref="double" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(double value)
    {
        return FromDoubleRounded(value);
    }

    /// <summary>Implicit cast from <see cref="decimal" /> to <see cref="QuantityValue" />.</summary>
    public static implicit operator QuantityValue(decimal value)
    {
        return new QuantityValue(value);
    }

    /// <summary>Implicit cast from <see cref="QuantityValue" /> to <see cref="BigInteger" />.</summary>
    public static implicit operator QuantityValue(BigInteger value)
    {
        return new QuantityValue(value);
    }

    /// <summary>
    ///     Creates a new instance of <see cref="QuantityValue" /> from the specified numerator and denominator.
    /// </summary>
    /// <param name="numerator">The numerator of the fraction representing the quantity value.</param>
    /// <param name="denominator">
    ///     The denominator of the fraction representing the quantity value.
    ///     If the denominator is negative, both the numerator and denominator are negated to ensure a canonical
    ///     representation.
    /// </param>
    /// <returns>
    ///     A <see cref="QuantityValue" /> instance representing the fraction defined by the given numerator and denominator.
    /// </returns>
    public static QuantityValue FromTerms(BigInteger numerator, BigInteger denominator)
    {
        return denominator.Sign < 0 ? new QuantityValue(-numerator, -denominator) : new QuantityValue(numerator, denominator);
    }

    /// <summary>
    ///     Creates a new instance of the <see cref="QuantityValue" /> struct with the specified number and a power of ten exponent.
    /// </summary>
    /// <param name="number">The number to multiply.</param>
    /// <param name="powerOfTen">
    ///     The power of ten to adjust the value. A positive exponent multiplies the number by 10 raised to the power,
    ///     while a negative exponent multiplies the denominator by 10 raised to the absolute value of the power.
    /// </param>
    /// <returns>
    ///     A new <see cref="QuantityValue" /> instance representing the specified value, corresponding to the scientific
    ///     notation: number * 10 ^ powerOfTen.
    /// </returns>
    /// <remarks>
    ///     This constructor enables precise representation of values using a fraction and a power of ten, 
    ///     corresponding to the scientific notation: number * 10 ^ powerOfTen.
    /// </remarks>
    public static QuantityValue FromPowerOfTen(BigInteger number, int powerOfTen)
    {
        return new QuantityValue(number, BigInteger.One, powerOfTen);
    }

    /// <summary>
    ///     Creates a new instance of the <see cref="QuantityValue" /> struct with the specified numerator, denominator,
    ///     and a power of ten exponent.
    /// </summary>
    /// <param name="numerator">The numerator of the fraction representing the value.</param>
    /// <param name="denominator">The denominator of the fraction representing the value.</param>
    /// <param name="powerOfTen">
    ///     The power of ten to adjust the value. A positive exponent multiplies the numerator by 10 raised to the power,
    ///     while a negative exponent multiplies the denominator by 10 raised to the absolute value of the power.
    /// </param>
    /// <returns>
    ///     A new <see cref="QuantityValue" /> instance representing the specified value, corresponding to the scientific
    ///     notation: (numerator/denominator) * 10 ^ powerOfTen.
    /// </returns>
    /// <remarks>
    ///     This constructor enables precise representation of values using a fraction and a power of ten, 
    ///     corresponding to the scientific notation: (numerator/denominator) * 10 ^ powerOfTen.
    /// </remarks>
    public static QuantityValue FromPowerOfTen(BigInteger numerator, BigInteger denominator, int powerOfTen)
    {
        return denominator.Sign < 0 ? new QuantityValue(-numerator, -denominator, powerOfTen) : new QuantityValue(numerator, denominator, powerOfTen);
    }

    /// <summary>
    ///     Converts a floating point value to a QuantityValue. The value is rounded if possible.
    /// </summary>
    /// <param name="value">The floating point value to convert.</param>
    /// <param name="nbSignificantDigits"></param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    ///     Thrown when the number of significant digits is less than 1 or greater than 17.
    /// </exception>
    /// <returns>A QuantityValue representing the rounded floating point value.</returns>
    /// <remarks>
    ///     The double data type stores its values as 64-bit floating point numbers in accordance with the IEC 60559:1989 (IEEE
    ///     754) standard for binary floating-point arithmetic.
    ///     However, the double data type cannot precisely store some numbers. For instance, 1/10, which is accurately
    ///     represented by .1 as a decimal fraction, is represented by .0001100110011... as a binary fraction, with the pattern
    ///     0011 repeating indefinitely.
    ///     In such cases, the floating-point value provides an approximate representation of the number.
    ///     <para>
    ///         This method can be used to avoid large numbers in the numerator and denominator while also making it safe to
    ///         use in comparison operations with other values.
    ///         <code>
    /// QuantityValue value = QuantityValue.FromDoubleRounded(0.1, 15); // returns {1/10}, which is exactly 0.1
    /// </code>
    ///     </para>
    /// </remarks>
    /// <example>
    ///     <code>
    /// QuantityValue qv = QuantityValue.FromDoubleRounded(0.1);
    /// // Output: 1/10, which is exactly 0.1
    /// </code>
    /// </example>
    public static QuantityValue FromDoubleRounded(double value, byte nbSignificantDigits = 15)
    {
        if (nbSignificantDigits is < 1 or > 17)
        {
            throw new ArgumentOutOfRangeException(nameof(nbSignificantDigits), nbSignificantDigits, "The number of significant digits must be between 1 and 17 (inclusive).");
        }

        switch (value)
        {
            case 0d:
                return Zero;
            case double.NaN:
                return NaN;
            case double.PositiveInfinity:
                return PositiveInfinity;
            case double.NegativeInfinity:
                return NegativeInfinity;
        }

        // Determine the number of decimal places to keep
        var magnitude = Math.Floor(Math.Log10(Math.Abs(value)));
        if (magnitude > nbSignificantDigits)
        {
            var digitsToKeep = new BigInteger(value / Math.Pow(10, magnitude - nbSignificantDigits));
            return new QuantityValue(digitsToKeep * PowerOfTen((int)magnitude - nbSignificantDigits));
        }

        // "decimal" values
        var truncatedValue = Math.Truncate(value);
        var integerPart = new BigInteger(truncatedValue);

        var decimalPlaces = Math.Min(-(int)magnitude + nbSignificantDigits - 1, 308);
        var scaleFactor = Math.Pow(10, decimalPlaces);
        // Get the fractional part
        var fractionalPart = (long)Math.Round((value - truncatedValue) * scaleFactor);
        if (fractionalPart == 0) // rounded to integer
        {
            return new QuantityValue(integerPart);
        }

        // reduce the insignificant trailing zeros from the fractional part before converting it to BigInteger
        while (fractionalPart % 10 == 0)
        {
            fractionalPart /= 10;
            decimalPlaces--;
        }

        var denominator = PowerOfTen(decimalPlaces);
        var numerator = integerPart.IsZero ? fractionalPart : integerPart * denominator + fractionalPart;
        return new QuantityValue(numerator, denominator);
    }

#if NET7_0_OR_GREATER


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool INumberBase<QuantityValue>.TryConvertFromChecked<TOther>(TOther value, out QuantityValue result)
    {
        if (TryConvertFrom(value, out result))
        {
            return true;
        }

        if (typeof(TOther) == typeof(Complex))
        {
            // Complex numbers with an imaginary part can't be represented as a "real number"
            // so we will convert it to NaN for the floating-point types,
            // since that's what Sqrt(-1) (which is `new Complex(0, 1)`) results in.
            result = FromDoubleRounded(double.CreateChecked(value));
            return true;
        }

        result = default;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool INumberBase<QuantityValue>.TryConvertFromSaturating<TOther>(TOther value, out QuantityValue result)
    {
        if (TryConvertFrom(value, out result))
        {
            return true;
        }

        if (typeof(TOther) == typeof(Complex))
        {
            result = FromDoubleRounded(double.CreateSaturating(value));
            return true;
        }

        result = default;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static bool INumberBase<QuantityValue>.TryConvertFromTruncating<TOther>(TOther value, out QuantityValue result)
    {
        if (TryConvertFrom(value, out result))
        {
            return true;
        }

        if (typeof(TOther) == typeof(Complex))
        {
            result = FromDoubleRounded(double.CreateTruncating(value));
            return true;
        }

        result = default;
        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryConvertFrom<TOther>(TOther value, out QuantityValue result) where TOther : INumberBase<TOther>
    {
        if (typeof(TOther) == typeof(decimal))
        {
            var num = (decimal)(object)value;
            result = num;
            return true;
        }

        if (typeof(TOther) == typeof(double))
        {
            var num = (double)(object)value;
            result = num;
            return true;
        }

        if (typeof(TOther) == typeof(float))
        {
            var actualValue = (float)(object)value;
            result = actualValue;
            return true;
        }

        if (typeof(TOther) == typeof(Half))
        {
            var actualValue = (Half)(object)value;
            result = (float)actualValue;
            return true;
        }

        if (typeof(TOther) == typeof(BigInteger))
        {
            var num = (BigInteger)(object)value;
            result = num;
            return true;
        }

        if (typeof(TOther) == typeof(Int128))
        {
            var num = (Int128)(object)value;
            result = (BigInteger)num;
            return true;
        }

        if (typeof(TOther) == typeof(UInt128))
        {
            var num = (UInt128)(object)value;
            result = (BigInteger)num;
            return true;
        }

        if (typeof(TOther) == typeof(long))
        {
            var num = (long)(object)value;
            result = num;
            return true;
        }

        if (typeof(TOther) == typeof(ulong))
        {
            var num = (ulong)(object)value;
            result = num;
            return true;
        }

        if (typeof(TOther) == typeof(int))
        {
            long num = (int)(object)value;
            result = num;
            return true;
        }

        if (typeof(TOther) == typeof(uint))
        {
            var num = (uint)(object)value;
            result = num;
            return true;
        }

        if (typeof(TOther) == typeof(nint))
        {
            var num = (nint)(object)value;
            result = num;
            return true;
        }

        if (typeof(TOther) == typeof(UIntPtr))
        {
            var num = (UIntPtr)(object)value;
            result = num;
            return true;
        }

        if (typeof(TOther) == typeof(short))
        {
            var num = (short)(object)value;
            result = (BigInteger)num;
            return true;
        }

        if (typeof(TOther) == typeof(ushort))
        {
            var num = (ushort)(object)value;
            result = (decimal)num;
            return true;
        }

        if (typeof(TOther) == typeof(char))
        {
            var ch = (char)(object)value;
            result = (decimal)ch;
            return true;
        }

        if (typeof(TOther) == typeof(byte))
        {
            var num = (byte)(object)value;
            result = num;
            return true;
        }

        if (typeof(TOther) == typeof(sbyte))
        {
            var num = (sbyte)(object)value;
            result = num;
            return true;
        }

        result = default;
        return false;
    }

    /// <summary>
    ///     Creates a <see cref="QuantityValue" /> instance from the specified value, throwing an exception if the value
    ///     cannot be represented within the range of <see cref="QuantityValue" />.
    /// </summary>
    /// <typeparam name="TOther">The type of the input value.</typeparam>
    /// <param name="value">The value to convert to a <see cref="QuantityValue" />.</param>
    /// <returns>A <see cref="QuantityValue" /> instance representing the specified value.</returns>
    /// <exception cref="NotSupportedException">
    ///     Thrown if the conversion from <typeparamref name="TOther" /> to <see cref="QuantityValue" /> is not supported.
    /// </exception>
    /// <exception cref="OverflowException">
    ///     Thrown if the specified value is outside the representable range of <see cref="QuantityValue" />.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QuantityValue CreateChecked<TOther>(TOther value) where TOther : INumberBase<TOther>
    {
        QuantityValue result;
        if (typeof(TOther) == typeof(QuantityValue))
            result = (QuantityValue)(object)value;
        else if (!TryConvertChecked(value, out result) && !TOther.TryConvertToChecked(value, out result))
            throw new NotSupportedException($"Cannot create a {nameof(QuantityValue)} from the given value of type {typeof(TOther)}.");
        return result;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TryConvertChecked<TSource, TTarget>(TSource source, out TTarget? result)
            where TSource : INumberBase<TSource>
            where TTarget : INumberBase<TTarget>
        {
            return TTarget.TryConvertFromChecked(source, out result);
        }
    }

    /// <summary>
    ///     Creates a new instance of <see cref="QuantityValue" /> from the specified value, saturating the value if it falls
    ///     outside the representable range of <see cref="QuantityValue" />.
    /// </summary>
    /// <typeparam name="TOther">The type of the input value.</typeparam>
    /// <param name="value">The value to be converted into a <see cref="QuantityValue" />.</param>
    /// <returns>
    ///     A <see cref="QuantityValue" /> instance created from the specified value. If the value is outside the representable
    ///     range, it is saturated to the nearest representable value.
    /// </returns>
    /// <exception cref="NotSupportedException">
    ///     Thrown if the conversion from <typeparamref name="TOther" /> to <see cref="QuantityValue" /> is not supported.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QuantityValue CreateSaturating<TOther>(TOther value) where TOther : INumberBase<TOther>
    {
        QuantityValue result;
        if (typeof(TOther) == typeof(QuantityValue))
            result = (QuantityValue)(object)value;
        else if (!TryConvertSaturating(value, out result) && !TOther.TryConvertToSaturating(value, out result))
            throw new NotSupportedException($"Cannot create a {nameof(QuantityValue)} from the given value of type {typeof(TOther)}.");
        return result;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TryConvertSaturating<TSource, TTarget>(TSource source, out TTarget? result)
            where TSource : INumberBase<TSource>
            where TTarget : INumberBase<TTarget>
        {
            return TTarget.TryConvertFromSaturating(source, out result);
        }
    }
    
    /// <summary>
    ///     Creates a <see cref="QuantityValue" /> instance from the specified value, truncating any values that fall outside
    ///     the representable range of <see cref="QuantityValue" />.
    /// </summary>
    /// <typeparam name="TOther">The type of the input value.</typeparam>
    /// <param name="value">The value to convert to a <see cref="QuantityValue" />.</param>
    /// <returns>
    ///     A <see cref="QuantityValue" /> instance created from the specified value, with truncation applied if the value
    ///     exceeds the representable range.
    /// </returns>
    /// <exception cref="NotSupportedException">
    ///     Thrown if the conversion from <typeparamref name="TOther" /> to <see cref="QuantityValue" /> is not supported.
    /// </exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static QuantityValue CreateTruncating<TOther>(TOther value) where TOther : INumberBase<TOther>
    {
        QuantityValue result;
        if (typeof(TOther) == typeof(QuantityValue))
            result = (QuantityValue)(object)value;
        else if (!TryConvertTruncating(value, out result) && !TOther.TryConvertToTruncating(value, out result))
            throw new NotSupportedException($"Cannot create a {nameof(QuantityValue)} from the given value of type {typeof(TOther)}.");
        return result;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool TryConvertTruncating<TSource, TTarget>(TSource source, out TTarget? result)
            where TSource : INumberBase<TSource>
            where TTarget : INumberBase<TTarget>
        {
            return TTarget.TryConvertFromTruncating(source, out result);
        }
    }
#endif
}
