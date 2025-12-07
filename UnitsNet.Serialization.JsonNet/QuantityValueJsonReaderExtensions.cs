// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Numerics;
using Newtonsoft.Json;

namespace UnitsNet.Serialization.JsonNet;

internal static class QuantityValueJsonReaderExtensions
{
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
