// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace UnitsNet.Serialization.SystemTextJson;

internal static class JsonExtensions
{
    public static bool ReadNextProperty(this ref Utf8JsonReader reader)
    {
        reader.Read();
        return reader.TokenType switch
        {
            JsonTokenType.PropertyName => true,
            JsonTokenType.EndObject => false,
            _ => throw new JsonException("Expected PropertyName token.")
        };
    }

    [SuppressMessage("ReSharper", "ReplaceSliceWithRangeIndexer")]
    public static bool TrySplit(this ReadOnlySpan<char> span, char separator, out ReadOnlySpan<char> firstSpan, out ReadOnlySpan<char> secondSpan)
    {
        var separatorIndex = span.IndexOf(separator);

        if (separatorIndex < 0)
        {
            firstSpan = span;
            secondSpan = ReadOnlySpan<char>.Empty;
            return false;
        }

        firstSpan = span.Slice(0, separatorIndex);
        secondSpan = span.Slice(separatorIndex + 1);
        return true;
    }


    public static bool PropertyNamesShouldStartWithLowercase(this JsonSerializerOptions options)
    {
        JsonNamingPolicy? namingPolicy = options.PropertyNamingPolicy;
        return namingPolicy == JsonNamingPolicy.CamelCase || namingPolicy == JsonNamingPolicy.KebabCaseLower || namingPolicy == JsonNamingPolicy.SnakeCaseLower;
    }
    
    public static void WriteStringValues(this Utf8JsonWriter writer, ReadOnlySpan<char> first, char separator, ReadOnlySpan<char> second)
    {
        var requiredLength = first.Length + second.Length + 1;
        Span<char> charBuffer = requiredLength <= 512 ? stackalloc char[requiredLength] : new char[requiredLength];
        CombineSpansWithSeparator(first, separator, second, charBuffer);
        writer.WriteStringValue(charBuffer);
    }
    
    public static void WriteValuesAsPropertyName(this Utf8JsonWriter writer, ReadOnlySpan<char> first, char separator, ReadOnlySpan<char> second)
    {
        var requiredLength = first.Length + second.Length + 1;
        Span<char> charBuffer = requiredLength <= 512 ? stackalloc char[requiredLength] : new char[requiredLength];
        CombineSpansWithSeparator(first, separator, second, charBuffer);
        writer.WritePropertyName(charBuffer);
    }
    
    // ReSharper disable once ReplaceSliceWithRangeIndexer
    private static void CombineSpansWithSeparator(ReadOnlySpan<char> first, char separator, ReadOnlySpan<char> second, Span<char> charBuffer)
    {
        first.CopyTo(charBuffer);
        charBuffer[first.Length] = separator;
        second.CopyTo(charBuffer.Slice(first.Length + 1));
    }

#if NET
    public static void WriteValuesAsString<TValue>(this Utf8JsonWriter writer, TValue first, char separator, TValue second, IFormatProvider? formatProvider = null, int stackAlloc = 512)
        where TValue: ISpanFormattable
    {
        Span<char> charBuffer = stackalloc char[stackAlloc];
        int firstCharsWritten;
        while (!first.TryFormat(charBuffer, out firstCharsWritten, ReadOnlySpan<char>.Empty, formatProvider))
        {
            charBuffer = new char[charBuffer.Length * 2];
        }

        if (firstCharsWritten == charBuffer.Length)
        {
            var extendedBuffer = new char[charBuffer.Length * 2];
            charBuffer.CopyTo(extendedBuffer);
            charBuffer = extendedBuffer;
        }
        
        charBuffer[firstCharsWritten] = separator;

        int secondCharsWritten;
        while (!second.TryFormat(charBuffer[(firstCharsWritten + 1)..], out secondCharsWritten, ReadOnlySpan<char>.Empty, formatProvider))
        {
            var extendedBuffer = new char[charBuffer.Length * 2];
            charBuffer.CopyTo(extendedBuffer);
            charBuffer = extendedBuffer;
        }

        writer.WriteStringValue(charBuffer[..(firstCharsWritten + secondCharsWritten + 1)]);
    }

#endif


    // private const int StackallocByteThreshold = 512;
    //
    // internal static int CopyValue(this ref Utf8JsonReader reader, Span<char> destination)
    // {
    //     // Debug.Assert(_tokenType is JsonTokenType.String or JsonTokenType.PropertyName or JsonTokenType.Number);
    //     // Debug.Assert(_tokenType != JsonTokenType.Number || !ValueIsEscaped, "Numbers can't contain escape characters.");
    //
    //     scoped ReadOnlySpan<byte> unescapedSource;
    //     byte[]? rentedBuffer = null;
    //     int valueLength;
    //
    //     if (reader.ValueIsEscaped)
    //     {
    //         valueLength = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
    //
    //         Span<byte> unescapedBuffer = valueLength <= StackallocByteThreshold ?
    //             stackalloc byte[StackallocByteThreshold] :
    //             (rentedBuffer = ArrayPool<byte>.Shared.Rent(valueLength));
    //
    //         bool success = TryCopyEscapedString(ref reader, unescapedBuffer, out int bytesWritten);
    //         // Debug.Assert(success);
    //         unescapedSource = unescapedBuffer.Slice(0, bytesWritten);
    //     }
    //     else
    //     {
    //         if (reader.HasValueSequence)
    //         {
    //             ReadOnlySequence<byte> valueSequence = reader.ValueSequence;
    //             valueLength = checked((int)valueSequence.Length);
    //
    //             Span<byte> intermediate = valueLength <= StackallocByteThreshold ?
    //                 stackalloc byte[StackallocByteThreshold] :
    //                 (rentedBuffer = ArrayPool<byte>.Shared.Rent(valueLength));
    //
    //             valueSequence.CopyTo(intermediate);
    //             unescapedSource = intermediate.Slice(0, valueLength);
    //         }
    //         else
    //         {
    //             unescapedSource = reader.ValueSpan;
    //         }
    //     }
    //
    //     int charsWritten = JsonReaderHelper.TranscodeHelper(unescapedSource, destination);
    //
    //     if (rentedBuffer != null)
    //     {
    //         new Span<byte>(rentedBuffer, 0, unescapedSource.Length).Clear();
    //         ArrayPool<byte>.Shared.Return(rentedBuffer);
    //     }
    //
    //     return charsWritten;
    // }
    //
    // private static bool TryCopyEscapedString(this ref Utf8JsonReader reader, Span<byte> destination, out int bytesWritten)
    // {
    //     Debug.Assert(_tokenType is JsonTokenType.String or JsonTokenType.PropertyName);
    //     Debug.Assert(ValueIsEscaped);
    //
    //     byte[]? rentedBuffer = null;
    //     scoped ReadOnlySpan<byte> source;
    //
    //     if (reader.HasValueSequence)
    //     {
    //         ReadOnlySequence<byte> valueSequence = reader.ValueSequence;
    //         int sequenceLength = checked((int)valueSequence.Length);
    //
    //         Span<byte> intermediate = sequenceLength <= StackallocByteThreshold ?
    //             stackalloc byte[StackallocByteThreshold] :
    //             (rentedBuffer = ArrayPool<byte>.Shared.Rent(sequenceLength));
    //
    //         valueSequence.CopyTo(intermediate);
    //         source = intermediate.Slice(0, sequenceLength);
    //     }
    //     else
    //     {
    //         source = reader.ValueSpan;
    //     }
    //
    //     bool success = JsonReaderHelper.TryUnescape(source, destination, out bytesWritten);
    //
    //     if (rentedBuffer != null)
    //     {
    //         new Span<byte>(rentedBuffer, 0, source.Length).Clear();
    //         ArrayPool<byte>.Shared.Return(rentedBuffer);
    //     }
    //
    //     Debug.Assert(bytesWritten < source.Length, "source buffer must contain at least one escape sequence");
    //     return success;
    // }
}
