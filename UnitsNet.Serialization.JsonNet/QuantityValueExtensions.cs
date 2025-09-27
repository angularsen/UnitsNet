// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Numerics;
using Newtonsoft.Json;
#if NETSTANDARD2_0
using System.Text;
#endif

namespace UnitsNet.Serialization.JsonNet;

internal static class QuantityValueExtensions
{
    public static void WriteValue(this JsonWriter writer, QuantityValue value, JsonSerializer serializer, QuantityValueSerializationFormat format)
    {
        switch (format)
        {
            case QuantityValueSerializationFormat.DoublePrecision:
                writer.WriteValueWithDoublePrecision(value);
                break;
            case QuantityValueSerializationFormat.DecimalPrecision:
                writer.WriteValueWithDecimalPrecision(value);
                break;
            case QuantityValueSerializationFormat.RoundTripping:
                writer.WriteValueRoundTripping(value);
                break;
            case QuantityValueSerializationFormat.Custom:
            default:
                serializer.Serialize(writer, value);
                break;
        }
    }

    // public static void WriteValueAsDouble(this JsonWriter writer, QuantityValue value)
    // {
    //     writer.WriteValue(value.ToDouble());
    // }

    public static void WriteValueWithDoublePrecision(this JsonWriter writer, QuantityValue value)
    {
        writer.WriteRawValue(value.ToString(CultureInfo.InvariantCulture));
    }

    public static void WriteValueWithDecimalPrecision(this JsonWriter writer, QuantityValue value)
    {
        writer.WriteRawValue(value.ToString("G29", CultureInfo.InvariantCulture));
    }

    public static void WriteValueRoundTripping(this JsonWriter writer, QuantityValue value)
    {
        (BigInteger numerator, BigInteger denominator) = QuantityValue.Reduce(value);
        // TODO see about using exponential notation
        if (denominator <= long.MaxValue / 10)
        {
            if (numerator <= long.MaxValue && numerator >= long.MinValue)
            {
                WriteSmallTerms(writer, (long)numerator, (long)denominator);
                return;
            }

            if (denominator.IsOne)
            {
                writer.WriteValue(numerator);
                return;
            }
        }
        
        if (!QuantityValue.HasNonDecimalFactors(denominator))
        {
            // failed to format the value as a decimal number
            writer.WriteValue($"{numerator}/{denominator}");
            return;
        }
        
        // decimal number
        var quotient = BigInteger.DivRem(numerator, denominator, out BigInteger remainder);
        
#if NET
        var bufferSize = 512;
        Span<char> charBuffer = stackalloc char[bufferSize];
        int charsWritten;
        while (!quotient.TryFormat(charBuffer, out charsWritten))
        {
            bufferSize *= 4;
            charBuffer = new char[bufferSize];
        }

        if (charsWritten + 2 > bufferSize)
        {
            bufferSize *= 2;
            var extendedBuffer = new char[bufferSize * 2];
            charBuffer.CopyTo(extendedBuffer);
            charBuffer = extendedBuffer;
        }

        BigInteger ten = 10;
        charBuffer[charsWritten++] = '.';
        remainder = BigInteger.Abs(remainder);
        do
        {
            var digit = (int)BigInteger.DivRem(remainder * ten, denominator, out remainder);
            if (charsWritten == bufferSize)
            {
                // extend the buffer
                bufferSize *= 2;
                var extendedBuffer = new char[bufferSize * 2];
                charBuffer.CopyTo(extendedBuffer);
                charBuffer = extendedBuffer;
            }

            charBuffer[charsWritten++] = (char)('0' + digit);
        } while (!remainder.IsZero);

        writer.WriteRawValue(new string(charBuffer[..charsWritten]));
#else
        // decimal number
        StringBuilder sb = new StringBuilder(quotient.ToString()).Append('.');
        BigInteger ten = 10;
        remainder = BigInteger.Abs(remainder);
        do
        {
            var digit = (int)BigInteger.DivRem(remainder * ten, denominator, out remainder);
            sb.Append((char)('0' + digit));
        } while (!remainder.IsZero);

        writer.WriteRawValue(sb.ToString());
#endif

        static void WriteSmallTerms(JsonWriter writer, long numerator, long denominator)
        {
            switch (denominator)
            {
                case 0:
                    // NaN or Infinity
                    switch (numerator)
                    {
                        case > 0:
                            writer.WriteValue(NumberFormatInfo.InvariantInfo.PositiveInfinitySymbol);
                            return;
                        case < 0:
                            writer.WriteValue(NumberFormatInfo.InvariantInfo.NegativeInfinitySymbol);
                            return;
                        default:
                            writer.WriteValue(NumberFormatInfo.InvariantInfo.NaNSymbol);
                            return;
                    }
                case 1:
                    writer.WriteValue(numerator);
                    return;
            }

            var quotient = Math.DivRem(numerator, denominator, out var remainder);

            // decimal number
            const int bufferSize = 45;
#if NET
            Span<char> charBuffer = stackalloc char[bufferSize];

            quotient.TryFormat(charBuffer, out var charsWritten);
#else
            var charBuffer = new char[bufferSize];
            var quotientString = quotient.ToString();
            quotientString.CopyTo(0, charBuffer, 0, quotientString.Length);
            var charsWritten = quotientString.Length;
#endif
            charBuffer[charsWritten++] = '.';
            remainder = Math.Abs(remainder);
            do
            {
                var digit = Math.DivRem(remainder * 10, denominator, out remainder);

                charBuffer[charsWritten++] = (char)(digit + '0');
                if (remainder == 0)
                {
                    #if NET
                    writer.WriteRawValue(new string(charBuffer[..charsWritten]));
                    #else
                    writer.WriteRawValue(new string(charBuffer, 0, charsWritten));
                    #endif
                    return;
                }
            } while (charsWritten < bufferSize);

            // failed to format the value as a decimal number
            writer.WriteValue($"{numerator}/{denominator}");
        }
    }

    public static QuantityValue ReadValue(this JsonReader reader, JsonSerializer serializer, QuantityValueDeserializationFormat format)
    {
        switch (format)
        {
            case QuantityValueDeserializationFormat.ExactNumber:
                return reader.ReadExactNumber();
            case QuantityValueDeserializationFormat.RoundedDouble:
                return reader.ReadValueFromDouble();
            case QuantityValueDeserializationFormat.RoundTripping:
                return reader.ReadValueRoundTripping();
            case QuantityValueDeserializationFormat.Custom:
            default:
                reader.Read();
                return serializer.Deserialize<QuantityValue>(reader);
        }
    }

    public static QuantityValue ReadExactNumber(this JsonReader reader)
    {
        var valueString = reader.ReadAsString();
        if (valueString == null)
        {
            throw new JsonSerializationException("Error converting value {null} to type 'QuantityValue'");
        }
        
        return QuantityValue.Parse(valueString, NumberStyles.Float, CultureInfo.InvariantCulture);
    }

    public static QuantityValue ReadValueFromDouble(this JsonReader reader)
    {
        var doubleValue = reader.ReadAsDouble();
        if (!doubleValue.HasValue)
        {
            throw new JsonSerializationException("Error converting value {null} to type 'QuantityValue'");
        }
        
        return QuantityValue.FromDoubleRounded(doubleValue.Value);
    }

    public static QuantityValue ReadValueRoundTripping(this JsonReader reader)
    {
        var valueString = reader.ReadAsString();
        if (valueString == null)
        {
            throw new JsonSerializationException("Error converting value {null} to type 'QuantityValue'");
        }
        
#if NET
        ReadOnlySpan<char> valueSpan = valueString.AsSpan();
        return TryParseFraction(valueSpan, out QuantityValue quantityValue)
            ? quantityValue
            : QuantityValue.Parse(valueSpan, NumberStyles.Float, CultureInfo.InvariantCulture);
#else
        return TryParseFraction(valueString, out QuantityValue quantityValue)
            ? quantityValue
            : QuantityValue.Parse(valueString, NumberStyles.Float, CultureInfo.InvariantCulture);
#endif

#if NET
        static bool TryParseFraction(ReadOnlySpan<char> value, out QuantityValue quantityValue)
        {
            if (value.TrySplit('/', out ReadOnlySpan<char> numeratorSpan, out ReadOnlySpan<char> denominatorSpan))
            {
                if (BigInteger.TryParse(numeratorSpan, out BigInteger numerator) && BigInteger.TryParse(denominatorSpan, out BigInteger denominator))
                {
                    quantityValue = QuantityValue.FromTerms(numerator, denominator);
                    return true;
                }
            }

            quantityValue = default;
            return false;
        }
#else
        static bool TryParseFraction(string valueToken, out QuantityValue quantityValue)
        {
            var ranges = valueToken.Split('/');
            if (ranges.Length == 2)
            {
                if (BigInteger.TryParse(ranges[0], out BigInteger numerator) && BigInteger.TryParse(ranges[1], out BigInteger denominator))
                {
                    quantityValue = QuantityValue.FromTerms(numerator, denominator);
                    return true;
                }
            }

            quantityValue = default;
            return false;
        }
#endif
    }
}
