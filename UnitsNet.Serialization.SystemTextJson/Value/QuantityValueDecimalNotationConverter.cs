// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
#if NETSTANDARD2_0
using System.Buffers;
#endif

namespace UnitsNet.Serialization.SystemTextJson.Value;

/// <summary>
///     Provides functionality to convert <see cref="QuantityValue" /> instances to and from their JSON representation
///     using decimal notation, which supports arbitrary scale and precision.
/// </summary>
/// <remarks>
///     This converter is designed to handle serialization and deserialization of <see cref="QuantityValue" /> objects
///     using decimal notation. A configurable maximum number of significant digits, corresponding to the `G` format
///     specifier, can be used to control the precision of the serialized output.
///     <para>
///         While this converter supports arbitrary precision, without any limits on the scale, it should be noted that
///         the serialized payload may fall outside the capabilities of the standard numeric types.
///     </para>
///     <para>Values such as 1/3 cannot be represented exactly.</para>
/// </remarks>
public class QuantityValueDecimalNotationConverter : JsonConverter<QuantityValue>
{
    private const int StackAllocThreshold = 512;
    
    private readonly string _serializationFormat;

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityValueDecimalNotationConverter" /> class
    ///     with a default maximum number of significant digits set to 17.
    /// </summary>
    /// <remarks>
    ///     This constructor simplifies the creation of the converter by using a default precision of 17 significant digits,
    ///     which corresponds to the `G17` format specifier.
    /// </remarks>
    public QuantityValueDecimalNotationConverter()
        : this(17)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityValueDecimalNotationConverter" /> class with an optional
    ///     maximum number of significant digits for serialization.
    /// </summary>
    /// <param name="maxNumberOfSignificantDigits">
    ///     The maximum number of significant digits to use during serialization.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     Thrown when <paramref name="maxNumberOfSignificantDigits" /> is less than 0.
    /// </exception>
    /// <remarks>
    ///     This constructor allows configuring the precision of the serialized output by specifying the maximum
    ///     number of significant digits, which corresponds to the `G` format specifier.
    /// </remarks>
    public QuantityValueDecimalNotationConverter(int maxNumberOfSignificantDigits)
    {
        if (maxNumberOfSignificantDigits < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(maxNumberOfSignificantDigits), "The number of significant digits must greater or equal to 0.");
        }

        _serializationFormat = "G" + maxNumberOfSignificantDigits;
    }

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
                if ((options.NumberHandling & (JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals)) == 0)
                {
                    throw new JsonException(
                        "String tokens are not supported with the current `NumberHandling` settings. Consider specifying 'JsonNumberHandling.AllowReadingFromString' (see https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonnumberhandling)");
                }

                var nbBytes = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
                Span<char> charBuffer = nbBytes <= StackAllocThreshold ? stackalloc char[nbBytes] : new char[nbBytes];
                var charsWritten = reader.CopyString(charBuffer);
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

        
//         if (reader.TokenType is not (JsonTokenType.Number or JsonTokenType.String))
//         {
//             throw new JsonException($"Expected a string or a number, not a {reader.TokenType}");
//         }
//
//         if (reader.TokenType == JsonTokenType.String && (options.NumberHandling & (JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals)) == 0)
//         {
//             throw new JsonException("Reading numbers from string tokens is not allowed. Consider specifying 'JsonNumberHandling.AllowReadingFromString' (see https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonnumberhandling)");
//         }
// #if NET
//         ReadOnlySpan<byte> bytes = reader.ValueSpan;
//         var charCount = Encoding.UTF8.GetCharCount(bytes);
//         Span<char> charBuffer = charCount <= 256 ? stackalloc char[charCount] : new char[charCount];
//         Encoding.UTF8.GetChars(bytes, charBuffer);
//         return QuantityValue.Parse(charBuffer, NumberStyles.Float, CultureInfo.InvariantCulture);
// #else
//         var bytes = reader.ValueSpan.ToArray();
//         var charCount = Encoding.UTF8.GetCharCount(bytes);
//         var charBuffer = new char[charCount];
//         Encoding.UTF8.GetChars(bytes, 0, bytes.Length, charBuffer, 0);
//         return QuantityValue.Parse(new string(charBuffer), NumberStyles.Float, CultureInfo.InvariantCulture);
// #endif
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, QuantityValue value, JsonSerializerOptions options)
    {
        if ((options.NumberHandling & JsonNumberHandling.WriteAsString) != 0)
        {
            writer.WriteStringValue(value.ToString(_serializationFormat, CultureInfo.InvariantCulture));
        }
        else if (QuantityValue.IsNaN(value) || QuantityValue.IsInfinity(value))
        {
            if ((options.NumberHandling & JsonNumberHandling.AllowNamedFloatingPointLiterals) == 0)
            {
                throw new JsonException($"Serializing '{value}' is not allowed. Consider specifying 'JsonNumberHandling.AllowNamedFloatingPointLiterals' (see https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonnumberhandling)");
            }

            writer.WriteStringValue(value.ToString(_serializationFormat, CultureInfo.InvariantCulture));
        }
        else
        {
#if NET
            Span<char> charBuffer = stackalloc char[256];
            int charsWritten;
            while (!value.TryFormat(charBuffer, out charsWritten, _serializationFormat, CultureInfo.InvariantCulture))
            {
                charBuffer = new char[charBuffer.Length * 2];
            }
            
            writer.WriteRawValue(charBuffer[..charsWritten], true);   
#else
            writer.WriteRawValue(value.ToString(_serializationFormat, CultureInfo.InvariantCulture), true);
#endif
        }
    }
}
