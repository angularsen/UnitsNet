// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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
///     Provides a custom JSON converter for <see cref="System.Numerics.BigInteger" />.
///     This converter serializes <see cref="System.Numerics.BigInteger" /> values as JSON strings
///     and deserializes JSON strings back into <see cref="System.Numerics.BigInteger" /> values.
/// </summary>
public class BigIntegerConverter : JsonConverter<BigInteger>
{
    /// <summary>
    ///     Gets the default instance of the <see cref="BigIntegerConverter" />.
    /// </summary>
    /// <remarks>
    ///     This instance can be used as a singleton for converting <see cref="System.Numerics.BigInteger" />
    ///     values to and from JSON without the need to create a new instance of <see cref="BigIntegerConverter" />.
    /// </remarks>
    public static BigIntegerConverter Default { get; } = new();

    /// <inheritdoc />
    public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Number:
            {
#if NET
                var nbBytes = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
                Span<char> charBuffer = nbBytes <= 512 ? stackalloc char[nbBytes] : new char[nbBytes];
                var charsWritten = reader.HasValueSequence
                    ? Encoding.UTF8.GetChars(reader.ValueSequence, charBuffer)
                    : Encoding.UTF8.GetChars(reader.ValueSpan, charBuffer);
                return BigInteger.Parse(charBuffer[..charsWritten], CultureInfo.InvariantCulture);
#else
                var bytes = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan.ToArray();
                var charBuffer = new char[bytes.Length];
                var charsWritten = Encoding.UTF8.GetChars(bytes, 0, bytes.Length, charBuffer, 0);
                return BigInteger.Parse(new string(charBuffer, 0, charsWritten), CultureInfo.InvariantCulture);
#endif
            }
            case JsonTokenType.String:
            {
                if ((options.NumberHandling & JsonNumberHandling.AllowReadingFromString) == 0)
                {
                    throw new JsonException(
                        "String tokens are not supported with the current `NumberHandling` settings. Consider specifying 'JsonNumberHandling.AllowReadingFromString' (see https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonnumberhandling)");
                }

#if NET
                var nbBytes = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
                Span<char> charBuffer = nbBytes <= 512 ? stackalloc char[nbBytes] : new char[nbBytes];
                var charsWritten = reader.CopyString(charBuffer);
                return BigInteger.Parse(charBuffer[..charsWritten], CultureInfo.InvariantCulture);
#else
                return BigInteger.Parse(reader.GetString()!, CultureInfo.InvariantCulture);
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

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
    {
        if ((options.NumberHandling & JsonNumberHandling.WriteAsString) == 0)
        {
#if NET
            Span<char> charBuffer = stackalloc char[512];
            if (value.TryFormat(charBuffer, out var charsWritten, provider: NumberFormatInfo.InvariantInfo))
            {
                writer.WriteRawValue(charBuffer[..charsWritten], true);
            }
            else // the number did not fit into the buffer
            {
                writer.WriteRawValue(value.ToString(NumberFormatInfo.InvariantInfo), true);
            }
#else
            writer.WriteRawValue(value.ToString(NumberFormatInfo.InvariantInfo), true);
#endif
        }
        else
        {
#if NET
            Span<char> charBuffer = stackalloc char[512];
            if (value.TryFormat(charBuffer, out var charsWritten, provider: NumberFormatInfo.InvariantInfo))
            {
                writer.WriteStringValue(charBuffer[..charsWritten]);
            }
            else // the number did not fit into the buffer
            {
                writer.WriteStringValue(value.ToString(NumberFormatInfo.InvariantInfo));
            }
#else
            writer.WriteStringValue(value.ToString(NumberFormatInfo.InvariantInfo));
#endif
        }
    }
}
