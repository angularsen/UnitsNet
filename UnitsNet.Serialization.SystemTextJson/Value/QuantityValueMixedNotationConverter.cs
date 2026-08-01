// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
#if NETSTANDARD2_0
using System.Buffers;
#endif

namespace UnitsNet.Serialization.SystemTextJson.Value;

/// <summary>
///     Provides a custom JSON converter for serializing and deserializing <see cref="QuantityValue" /> objects
///     using mixed notation, supporting both fractional and decimal representations.
/// </summary>
/// <remarks>
///     This converter ensures that any <see cref="QuantityValue" /> can round-trip exactly during serialization
///     and deserialization, even for values like 1/3 that cannot be represented precisely as a finite decimal.
///     For values with a finite decimal expansion, the shorter and more readable decimal format is used.
/// </remarks>
[SuppressMessage("ReSharper", "ReplaceSliceWithRangeIndexer")]
public class QuantityValueMixedNotationConverter : JsonConverter<QuantityValue>
{
    private const int StackAllocThreshold = 512;

    /// <summary>
    ///     Gets the default instance of the <see cref="QuantityValueMixedNotationConverter" />.
    /// </summary>
    /// <remarks>
    ///     This property provides a pre-configured, shared instance of the converter
    ///     with default settings, simplifying the serialization and deserialization
    ///     of <see cref="QuantityValue" /> objects in JSON format.
    /// </remarks>
    public static QuantityValueMixedNotationConverter Default { get; } = new();

    /// <inheritdoc />
    public override QuantityValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
            {
#if NET
                var nbBytes = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
                Span<char> charBuffer = nbBytes <= StackAllocThreshold ? stackalloc char[nbBytes] : new char[nbBytes];
                var charsWritten = reader.HasValueSequence
                    ? Encoding.UTF8.GetChars(reader.ValueSequence, charBuffer)
                    : Encoding.UTF8.GetChars(reader.ValueSpan, charBuffer);
                return QuantityValue.Parse(charBuffer[..charsWritten], NumberStyles.Float, CultureInfo.InvariantCulture);
#else
                var bytes = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan.ToArray();
                var charBuffer = new char[bytes.Length];
                var charsWritten = Encoding.UTF8.GetChars(bytes, 0, bytes.Length, charBuffer, 0);
                return QuantityValue.Parse(new string(charBuffer, 0, charsWritten), NumberStyles.Float, CultureInfo.InvariantCulture);
#endif
            }
            case JsonTokenType.String:
            {
                var decimalNotationNotAllowed = (options.NumberHandling & JsonNumberHandling.AllowReadingFromString) == 0;
                if (decimalNotationNotAllowed && reader.ValueIsEscaped)
                {
                    throw new JsonException("Numbers can't contain escape characters.");
                }

                var nbBytes = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
                Span<char> charBuffer = nbBytes <= StackAllocThreshold ? stackalloc char[nbBytes] : new char[nbBytes];
                var charsWritten = reader.CopyString(charBuffer);
                if (TryParseFraction(charBuffer.Slice(0, charsWritten), out QuantityValue quantityValue))
                {
                    return quantityValue;
                }

                // falling back to the default quoted number handling
                if (decimalNotationNotAllowed)
                {
                    throw new JsonException(
                        "String tokens are not supported with the current `NumberHandling` settings. Consider specifying 'JsonNumberHandling.AllowReadingFromString' (see https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonnumberhandling)");
                }

#if NET
                return QuantityValue.Parse(charBuffer[..charsWritten], NumberStyles.Float, CultureInfo.InvariantCulture);
#else
                return QuantityValue.Parse(charBuffer.Slice(0, charsWritten).ToString(), NumberStyles.Float, CultureInfo.InvariantCulture);
#endif
            }
            case JsonTokenType.None:
            case JsonTokenType.StartObject:
            case JsonTokenType.EndObject:
            case JsonTokenType.StartArray:
            case JsonTokenType.EndArray:
            case JsonTokenType.PropertyName:
            case JsonTokenType.Comment:
            case JsonTokenType.True:
            case JsonTokenType.False:
            case JsonTokenType.Null:
            default:
                throw new JsonException($"Unexpected token type: {reader.TokenType}");
        }
    }

    private static bool TryParseFraction(ReadOnlySpan<char> value, out QuantityValue quantityValue)
    {
        if (value.TrySplit('/', out ReadOnlySpan<char> numeratorSpan, out ReadOnlySpan<char> denominatorSpan))
        {
#if NET
            if (BigInteger.TryParse(numeratorSpan, out BigInteger numerator) && BigInteger.TryParse(denominatorSpan, out BigInteger denominator))
#else
            if (BigInteger.TryParse(numeratorSpan.ToString(), out BigInteger numerator) &&
                BigInteger.TryParse(denominatorSpan.ToString(), out BigInteger denominator))
#endif
            {
                quantityValue = QuantityValue.FromTerms(numerator, denominator);
                return true;
            }
        }

        quantityValue = default;
        return false;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, QuantityValue value, JsonSerializerOptions options)
    {
        (BigInteger numerator, BigInteger denominator) = QuantityValue.Reduce(value);
        // TODO see about using exponential notation

        if (denominator <= long.MaxValue / 10)
        {
            if (numerator <= long.MaxValue && numerator >= long.MinValue)
            {
                WriteSmallTerms(writer, (long)numerator, (long)denominator, options.NumberHandling);
                return;
            }

            if (denominator.IsOne)
            {
                BigIntegerConverter.Default.Write(writer, numerator, options);
                return;
            }
        }
        
        if (!QuantityValue.HasNonDecimalFactors(denominator))
        {
#if NET
            writer.WriteValuesAsString(numerator, '/', denominator);
#else
            writer.WriteStringValues(numerator.ToString().AsSpan(), '/', denominator.ToString().AsSpan());
#endif
            return;
        }

        var quotient = BigInteger.DivRem(numerator, denominator, out BigInteger remainder);

        // decimal number
        var bufferSize = StackAllocThreshold;
#if NET
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
#else
        var quotientString = quotient.ToString();
        if (quotientString.Length + 2 > bufferSize)
        {
            bufferSize = quotientString.Length * 2;
        }

        // Copy the quotient string into the char buffer
        Span<char> charBuffer = bufferSize <= StackAllocThreshold ? stackalloc char[bufferSize] : new char[bufferSize];
        quotientString.AsSpan().CopyTo(charBuffer);
        var charsWritten = quotientString.Length;
#endif

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

        if ((options.NumberHandling & JsonNumberHandling.WriteAsString) == 0)
        {
            writer.WriteRawValue(charBuffer.Slice(0, charsWritten), true);
        }
        else
        {
            writer.WriteStringValue(charBuffer.Slice(0, charsWritten));
        }
    }

    private static void WriteSmallTerms(Utf8JsonWriter writer, long numerator, long denominator, JsonNumberHandling numberHandling)
    {
        switch (denominator)
        {
            case 0:
                if ((numberHandling & JsonNumberHandling.AllowNamedFloatingPointLiterals) == 0)
                {
                    throw new JsonException(
                        "NamedFloatingPointLiterals are not supported with the current `NumberHandling` settings. Consider specifying 'JsonNumberHandling.AllowNamedFloatingPointLiterals' (see https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonnumberhandling)");
                }

                // NaN or Infinity
                switch (numerator)
                {
                    case > 0:
                        writer.WriteStringValue(NumberFormatInfo.InvariantInfo.PositiveInfinitySymbol);
                        return;
                    case < 0:
                        writer.WriteStringValue(NumberFormatInfo.InvariantInfo.NegativeInfinitySymbol);
                        return;
                    default:
                        writer.WriteStringValue(NumberFormatInfo.InvariantInfo.NaNSymbol);
                        return;
                }
            case 1:
                if ((numberHandling & JsonNumberHandling.WriteAsString) == 0)
                {
                    writer.WriteNumberValue(numerator);
                }
                else
                {
                    writer.WriteStringValue(numerator.ToString());
                }

                return;
        }

        var quotient = Math.DivRem(numerator, denominator, out var remainder);

        // decimal number
        const int bufferSize = 45;
        Span<char> charBuffer = stackalloc char[bufferSize];
#if NET
        quotient.TryFormat(charBuffer, out var charsWritten);
#else
        var quotientString = quotient.ToString();
        quotientString.AsSpan().CopyTo(charBuffer);
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
                if ((numberHandling & JsonNumberHandling.WriteAsString) == 0)
                {
                    writer.WriteRawValue(charBuffer.Slice(0, charsWritten), true);
                }
                else
                {
                    writer.WriteStringValue(charBuffer.Slice(0, charsWritten));
                }

                return;
            }
        } while (charsWritten < bufferSize);

        // failed to format the value as a decimal number

        // note: the following code is equivalent to the string interpolation:
        // writer.WriteStringValue($"{numerator}/{denominator}");
#if NET
        numerator.TryFormat(charBuffer, out var numeratorLength);
        charBuffer[numeratorLength] = '/';
        denominator.TryFormat(charBuffer[(numeratorLength + 1)..], out var denominatorLength);
        writer.WriteStringValue(charBuffer[..(numeratorLength + denominatorLength + 1)]);
#else
        ReadOnlySpan<char> numeratorSpan = numerator.ToString().AsSpan();
        numeratorSpan.CopyTo(charBuffer);
        charBuffer[numeratorSpan.Length] = '/';
        ReadOnlySpan<char> denominatorSpan = denominator.ToString().AsSpan();
        denominatorSpan.CopyTo(charBuffer.Slice(numeratorSpan.Length + 1));
        writer.WriteStringValue(charBuffer.Slice(0, numeratorSpan.Length + denominatorSpan.Length + 1));
#endif
    }
}
