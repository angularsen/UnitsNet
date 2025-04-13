// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Numerics;
#if NET7_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace UnitsNet;

public partial struct QuantityValue
{
    private static readonly BigInteger MaxDecimal = new(decimal.MaxValue);
    private static readonly BigInteger MinDecimal = -MaxDecimal;
    private static readonly BigInteger MaxDouble = new(double.MaxValue);
    private static readonly BigInteger MinDouble = -MaxDouble;

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="double" />.</summary>
    public static explicit operator double(QuantityValue value)
    {
        return value.ToDouble();
    }

    /// <summary>
    ///     Converts the quantity value to the closest double-precision floating point number.
    /// </summary>
    /// <returns>
    ///     A double-precision floating point representation of the quantity value, which may be NaN, positive infinity, or
    ///     negative infinity.
    /// </returns>
    public double ToDouble()
    {
        var numerator = Numerator;
        var denominator = Denominator;
        if (denominator.IsZero)
        {
            return numerator.Sign switch
            {
                1 => double.PositiveInfinity,
                -1 => double.NegativeInfinity,
                _ => double.NaN
            };
        }

        if (numerator.IsZero)
        {
            return 0;
        }

        if (denominator.IsOne)
        {
            return (double)numerator;
        }

        var convertedNumerator = (double)numerator;
        if (double.IsPositiveInfinity(convertedNumerator))
        {
            if (denominator > MaxDouble)
            {
                // both terms need to be rounded
                numerator = numerator * MaxDouble / denominator;
                denominator = MaxDouble;
                if (numerator <= MaxDouble)
                {
                    // both terms are now within range
                    return (double)numerator / (double)denominator;
                }
            }

            var withoutDecimalPlaces = (double)BigInteger.DivRem(numerator, denominator, out var remainder);
            if (double.IsPositiveInfinity(withoutDecimalPlaces))
            {
                return double.PositiveInfinity;
            }

            return remainder.IsZero ? withoutDecimalPlaces : withoutDecimalPlaces + (double)remainder / (double)denominator;
        }

        if (double.IsNegativeInfinity(convertedNumerator))
        {
            if (denominator > MaxDouble)
            {
                // both terms need to be rounded
                numerator = numerator * MaxDouble / denominator;
                denominator = MaxDouble;
                if (numerator >= MinDouble)
                {
                    // both terms are now within range
                    return (double)numerator / (double)denominator;
                }
            }

            var withoutDecimalPlaces = (double)BigInteger.DivRem(numerator, denominator, out var remainder);
            if (double.IsNegativeInfinity(withoutDecimalPlaces))
            {
                return double.NegativeInfinity;
            }

            return remainder.IsZero ? withoutDecimalPlaces : withoutDecimalPlaces + (double)remainder / (double)denominator;
        }

        var convertedDenominator = (double)denominator;
        if (double.IsPositiveInfinity(convertedDenominator))
        {
            // since both terms are non-zero and the numerator is smaller (in magnitude) to the denominator
            // the resulting number would be in the range [-1,1] (exclusive)
            // we want to flip the operation: x = a/b -> 1/x = b/a
            var decimalPart = (double)BigInteger.DivRem(denominator, numerator, out var remainder);
            if (double.IsInfinity(decimalPart))
            {
                return 0;
            }

            return remainder.IsZero ? 1 / decimalPart : 1 / (decimalPart + (double)remainder / (double)numerator);
        }

        return convertedNumerator / convertedDenominator;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="decimal" />.</summary>
    public static explicit operator decimal(QuantityValue value)
    {
        return value.ToDecimal();
    }

    /// <summary>
    ///     Converts the current <see cref="QuantityValue" /> to its <see cref="decimal" /> equivalent.
    /// </summary>
    /// <returns>
    ///     A <see cref="decimal" /> that represents the value of the current <see cref="QuantityValue" />.
    /// </returns>
    /// <exception cref="OverflowException">
    ///     Thrown when the denominator of the underlying fraction is zero (case of PositiveInfinity, NegativeInfinity or NaN)
    ///     or when the resulting number is outside the range of the <see cref="decimal" /> type.
    /// </exception>
    public decimal ToDecimal()
    {
        var numerator = Numerator;
        var denominator = Denominator;
        if (denominator.IsZero)
        {
            throw new OverflowException();
        }

        if (numerator.IsZero)
        {
            return decimal.Zero;
        }

        if (denominator.IsOne)
        {
            return (decimal)numerator;
        }

        if (numerator > MaxDecimal)
        {
            if (denominator > MaxDecimal)
            {
                // both terms need to be rounded
                numerator = numerator * MaxDecimal / denominator;
                denominator = MaxDecimal;
                if (numerator <= MaxDecimal)
                {
                    // both terms are now within range
                    return (decimal)numerator / (decimal)denominator;
                }
            }

            var withoutDecimalPlaces = (decimal)BigInteger.DivRem(numerator, denominator, out var remainder);
            return remainder.IsZero ? withoutDecimalPlaces : withoutDecimalPlaces + (decimal)remainder / (decimal)denominator;
        }

        if (numerator < MinDecimal)
        {
            if (denominator > MaxDecimal)
            {
                // both terms need to be rounded
                numerator = numerator * MaxDecimal / denominator;
                denominator = MaxDecimal;
                if (numerator >= MinDecimal)
                {
                    // both terms are now within range
                    return (decimal)numerator / (decimal)denominator;
                }
            }

            var withoutDecimalPlaces = (decimal)BigInteger.DivRem(numerator, denominator, out var remainder);
            return remainder.IsZero ? withoutDecimalPlaces : withoutDecimalPlaces + (decimal)remainder / (decimal)denominator;
        }

        if (denominator > MaxDecimal)
        {
            // since both terms are non-zero and the numerator is smaller (in magnitude) to the denominator
            // the resulting number would be in the range [-1,1] (exclusive)
            // we want to flip the operation: x = a/b -> 1/x = b/a
            var decimalPart = BigInteger.DivRem(denominator, numerator, out var remainder);
            return remainder.IsZero ? 1m / (decimal)decimalPart : 1m / ((decimal)decimalPart + (decimal)remainder / (decimal)numerator);
        }

        return (decimal)numerator / (decimal)denominator;
    }

    /// <summary>
    ///     Converts the fraction to a decimal number. If the fraction cannot be represented as a decimal due to its
    ///     size, the method will return the closest possible decimal representation (either decimal.MaxValue or
    ///     decimal.MinValue).
    /// </summary>
    /// <returns>
    ///     The decimal representation of the fraction. If the fraction is too large to represent as a decimal, returns
    ///     decimal.MaxValue. If the fraction is too small to represent as a decimal, returns decimal.MinValue.
    /// </returns>
    /// <remarks>If the fraction is NaN (the numerator and the denominator are both zero), the method will return decimal.Zero.</remarks>
    public decimal ToDecimalSaturating()
    {
        var numerator = Numerator;
        var denominator = Denominator;
        if (denominator.IsZero)
        {
            return numerator.Sign switch
            {
                1 => decimal.MaxValue,
                -1 => decimal.MinValue,
                _ => decimal.Zero
            };
        }
        
        if (numerator.IsZero)
        {
            return decimal.Zero;
        }

        if (denominator.IsOne)
        {
            if (numerator > MaxDecimal)
            {
                return decimal.MaxValue;
            }

            if (numerator < MinDecimal)
            {
                return decimal.MinValue;
            }

            return (decimal)numerator;
        }

        if (numerator > MaxDecimal)
        {
            if (denominator > MaxDecimal)
            {
                // both terms need to be rounded
                numerator = numerator * MaxDecimal / denominator;
                denominator = MaxDecimal;
                if (numerator <= MaxDecimal)
                {
                    // both terms are now within range
                    return (decimal)numerator / (decimal)denominator;
                }
            }

            var withoutDecimalPlaces = BigInteger.DivRem(numerator, denominator, out BigInteger remainder);
            if (withoutDecimalPlaces > MaxDecimal)
            {
                return decimal.MaxValue;
            }

            return remainder.IsZero ? (decimal)withoutDecimalPlaces : (decimal)withoutDecimalPlaces + (decimal)remainder / (decimal)denominator;
        }

        if (numerator < MinDecimal)
        {
            if (denominator > MaxDecimal)
            {
                // both terms need to be rounded
                numerator = numerator * MaxDecimal / denominator;
                denominator = MaxDecimal;
                if (numerator >= MinDecimal)
                {
                    // both terms are now within range
                    return (decimal)numerator / (decimal)denominator;
                }
            }

            var withoutDecimalPlaces = BigInteger.DivRem(numerator, denominator, out BigInteger remainder);
            if (withoutDecimalPlaces < MinDecimal)
            {
                return decimal.MinValue;
            }

            return remainder.IsZero ? (decimal)withoutDecimalPlaces : (decimal)withoutDecimalPlaces + (decimal)remainder / (decimal)denominator;
        }

        if (denominator > MaxDecimal)
        {
            // since both terms are non-zero and the numerator is smaller (in magnitude) to the denominator
            // the resulting number would be in the range [-1,1] (exclusive)
            // we want to flip the operation: x = a/b -> 1/x = b/a
            var decimalPart = BigInteger.DivRem(denominator, numerator, out BigInteger remainder);
            if (decimalPart < MinDecimal || decimalPart > MaxDecimal)
            {
                return decimal.Zero;
            }

            return remainder.IsZero ? 1m / (decimal)decimalPart : 1m / ((decimal)decimalPart + (decimal)remainder / (decimal)numerator);
        }

        return (decimal)numerator / (decimal)denominator;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="float" />.</summary>
    public static explicit operator float(QuantityValue value)
    {
        return (float)(double)value;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="BigInteger" />.</summary>
    public static explicit operator BigInteger(QuantityValue value)
    {
        var numerator = value.Numerator;
        var denominator = value.Denominator;
        if (denominator.IsZero)
        {
            throw new OverflowException("The big integer type cannot represent NaN or Infinity");
        }
        
        return denominator.IsOne ? numerator : numerator / denominator;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="long" />.</summary>
    public static explicit operator long(QuantityValue value)
    {
        return (long)(BigInteger)value;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="ulong" />.</summary>
    [CLSCompliant(false)]
    public static explicit operator ulong(QuantityValue value)
    {
        return (ulong)(BigInteger)value;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="int" />.</summary>
    public static explicit operator int(QuantityValue value)
    {
        return (int)(BigInteger)value;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="uint" />.</summary>
    [CLSCompliant(false)]
    public static explicit operator uint(QuantityValue value)
    {
        return (uint)(BigInteger)value;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="short" />.</summary>
    public static explicit operator short(QuantityValue value)
    {
        return (short)(BigInteger)value;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="ushort" />.</summary>
    [CLSCompliant(false)]
    public static explicit operator ushort(QuantityValue value)
    {
        return (ushort)(BigInteger)value;
    }

    /// <summary>Explicit cast from <see cref="QuantityValue" /> to <see cref="byte" />.</summary>
    public static explicit operator byte(QuantityValue value)
    {
        return (byte)(BigInteger)value;
    }

#if NET7_0_OR_GREATER
    /// <summary>
    ///     Converts the given QuantityValue to a Half precision floating point number.
    /// </summary>
    /// <param name="value">The QuantityValue to convert.</param>
    /// <returns>The converted Half precision floating point number.</returns>
    /// <exception cref="OverflowException">Thrown when the QuantityValue is too large to fit in a Half.</exception>
    public static explicit operator Half(QuantityValue value)
    {
        return (Half)value.ToDouble();
    }

    /// <summary>
    ///     Converts the given QuantityValue to an Int128.
    /// </summary>
    /// <param name="value">The QuantityValue to convert.</param>
    /// <returns>The converted Int128.</returns>
    /// <exception cref="OverflowException">Thrown when the QuantityValue is too large to fit in an Int128.</exception>
    public static explicit operator Int128(QuantityValue value)
    {
        return (Int128)(BigInteger)value;
    }

    /// <summary>
    ///     Converts the given Fraction to an UInt128.
    /// </summary>
    /// <param name="value">The Fraction to convert.</param>
    /// <returns>The converted UInt128.</returns>
    /// <exception cref="OverflowException">Thrown when the Fraction is too large to fit in an UInt128.</exception>
    [CLSCompliant(false)]
    public static explicit operator UInt128(QuantityValue value)
    {
        return (UInt128)(BigInteger)value;
    }

    static bool INumberBase<QuantityValue>.TryConvertToChecked<TOther>(QuantityValue value, [MaybeNullWhen(false)] out TOther result)
    {
        if (typeof(TOther) == typeof(decimal))
        {
            var convertedValue = value.ToDecimal();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(double))
        {
            var convertedValue = value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(Complex))
        {
            Complex convertedValue = value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(float))
        {
            var convertedValue = (float)value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(Half))
        {
            var convertedValue = (Half)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(BigInteger))
        {
            var convertedValue = (BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(Int128))
        {
            var convertedValue = (Int128)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(UInt128))
        {
            var convertedValue = (UInt128)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(long))
        {
            var convertedValue = (long)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(ulong))
        {
            var convertedValue = (ulong)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(int))
        {
            var num = (int)value;
            result = (TOther)(object)num;
            return true;
        }

        if (typeof(TOther) == typeof(uint))
        {
            var convertedValue = (uint)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(nint))
        {
            var convertedValue = (nint)(BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(UIntPtr))
        {
            var convertedValue = (UIntPtr)(BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(short))
        {
            var convertedValue = (short)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(ushort))
        {
            var convertedValue = (ushort)(BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(char)) {
            var convertedValue = (char)(BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }
        
        if (typeof(TOther) == typeof(byte))
        {
            var convertedValue = (byte)(BigInteger)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(sbyte))
        {
            var num = (sbyte)value;
            result = (TOther)(object)num;
            return true;
        }

        result = default;
        return false;
    }

    static bool INumberBase<QuantityValue>.TryConvertToSaturating<TOther>(QuantityValue value, [MaybeNullWhen(false)] out TOther result)
    {
        if (typeof(TOther) == typeof(decimal))
        {
            var convertedValue = value.ToDecimalSaturating();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(double))
        {
            var convertedValue = value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(Complex))
        {
            Complex convertedValue = value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(float))
        {
            var convertedValue = (float)value.ToDouble();
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(Half))
        {
            var convertedValue = (Half)value;
            result = (TOther)(object)convertedValue;
            return true;
        }

        if (typeof(TOther) == typeof(BigInteger))
        {
            if (IsFinite(value))
            {
                result = (TOther)(object)(BigInteger)value;
                return true;
            }

            if (value.Numerator.IsZero)
            {
                result = TOther.Zero;
            }
            else
            {
                throw new OverflowException();
            }

            return true;
        }

        if (typeof(TOther) == typeof(Int128))
        {
            return ConvertFromBigInteger<Int128>(value, out result);
        }

        if (typeof(TOther) == typeof(UInt128))
        {
            return ConvertFromBigInteger<UInt128>(value, out result);
        }

        if (typeof(TOther) == typeof(long))
        {
            return ConvertFromBigInteger<long>(value, out result);
        }

        if (typeof(TOther) == typeof(ulong))
        {
            return ConvertFromBigInteger<ulong>(value, out result);
        }

        if (typeof(TOther) == typeof(int))
        {
            return ConvertFromBigInteger<int>(value, out result);
        }

        if (typeof(TOther) == typeof(uint))
        {
            return ConvertFromBigInteger<uint>(value, out result);
        }

        if (typeof(TOther) == typeof(nint))
        {
            return ConvertFromBigInteger<nint>(value, out result);
        }

        if (typeof(TOther) == typeof(UIntPtr))
        {
            return ConvertFromBigInteger<UIntPtr>(value, out result);
        }

        if (typeof(TOther) == typeof(short))
        {
            return ConvertFromBigInteger<short>(value, out result);
        }

        if (typeof(TOther) == typeof(ushort))
        {
            return ConvertFromBigInteger<ushort>(value, out result);
        }
        
        if (typeof(TOther) == typeof(char)) {
            return ConvertFromBigInteger<char>(value, out result);
        }

        if (typeof(TOther) == typeof(byte))
        {
            return ConvertFromBigInteger<byte>(value, out result);
        }

        if (typeof(TOther) == typeof(sbyte))
        {
            return ConvertFromBigInteger<sbyte>(value, out result);
        }

        result = default;
        return false;

        static bool ConvertFromBigInteger<TNumber>(QuantityValue value, out TOther convertedValue) where TNumber : INumberBase<TNumber>, IMinMaxValue<TNumber>
        {
            if (IsFinite(value))
            {
                convertedValue = TOther.CreateSaturating((BigInteger)value);
            }
            else
            {
                convertedValue = value.Numerator.Sign switch
                {
                    1 => (TOther)(object)TNumber.MaxValue,
                    -1 => (TOther)(object)TNumber.MinValue,
                    _ => (TOther)(object)TNumber.Zero
                };
            }

            return true;
        }
    }

    static bool INumberBase<QuantityValue>.TryConvertToTruncating<TOther>(QuantityValue value, [MaybeNullWhen(false)] out TOther result)
    {
        if (typeof(TOther) == typeof(decimal))
        {
            var num = value.ToDecimalSaturating();
            result = (TOther)(object)num;
            return true;
        }

        if (typeof(TOther) == typeof(double))
        {
            var num = value.ToDouble();
            result = (TOther)(object)num;
            return true;
        }

        if (typeof(TOther) == typeof(Complex))
        {
            Complex num = value.ToDouble();
            result = (TOther)(object)num;
            return true;
        }

        if (typeof(TOther) == typeof(float))
        {
            var num = (float)value.ToDouble();
            result = (TOther)(object)num;
            return true;
        }

        if (typeof(TOther) == typeof(Half))
        {
            var half = (Half)value;
            result = (TOther)(object)half;
            return true;
        }

        if (typeof(TOther) == typeof(BigInteger))
        {
            if (IsFinite(value))
            {
                result = (TOther)(object)(BigInteger)value;
            }
            else if (value.Numerator.IsZero)
            {
                result = TOther.Zero;
            }
            else
            {
                throw new OverflowException();
            }

            return true;
        }

        if (typeof(TOther) == typeof(Int128))
        {
            return ConvertFromBigInteger<Int128>(value, out result);
        }

        if (typeof(TOther) == typeof(UInt128))
        {
            return ConvertFromBigInteger<UInt128>(value, out result);
        }

        if (typeof(TOther) == typeof(long))
        {
            return ConvertFromBigInteger<long>(value, out result);
        }

        if (typeof(TOther) == typeof(ulong))
        {
            return ConvertFromBigInteger<ulong>(value, out result);
        }

        if (typeof(TOther) == typeof(int))
        {
            return ConvertFromBigInteger<int>(value, out result);
        }

        if (typeof(TOther) == typeof(uint))
        {
            return ConvertFromBigInteger<uint>(value, out result);
        }

        if (typeof(TOther) == typeof(nint))
        {
            return ConvertFromBigInteger<nint>(value, out result);
        }

        if (typeof(TOther) == typeof(UIntPtr))
        {
            return ConvertFromBigInteger<UIntPtr>(value, out result);
        }

        if (typeof(TOther) == typeof(short))
        {
            return ConvertFromBigInteger<short>(value, out result);
        }

        if (typeof(TOther) == typeof(ushort))
        {
            return ConvertFromBigInteger<ushort>(value, out result);
        }
        
        if (typeof(TOther) == typeof(char)) {
            return ConvertFromBigInteger<char>(value, out result);
        }

        if (typeof(TOther) == typeof(byte))
        {
            return ConvertFromBigInteger<byte>(value, out result);
        }

        if (typeof(TOther) == typeof(sbyte))
        {
            return ConvertFromBigInteger<sbyte>(value, out result);
        }

        result = default;
        return false;

        static bool ConvertFromBigInteger<TNumber>(QuantityValue value, out TOther convertedValue) where TNumber : INumberBase<TNumber>, IMinMaxValue<TNumber>
        {
            convertedValue = IsFinite(value)
                ? TOther.CreateTruncating((BigInteger)value)
                : value.Numerator.Sign switch
                {
                    1 => (TOther)(object)TNumber.MaxValue,
                    -1 => (TOther)(object)TNumber.MinValue,
                    _ => (TOther)(object)TNumber.Zero
                };

            return true;
        }
    }

#endif
}
