// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitsNet.Serialization.SystemTextJson.Value;

/// <summary>
///     A JSON converter for <see cref="QuantityValue" /> that serializes and deserializes values using the decimal type.
/// </summary>
/// <remarks>
///     This converter is tailored for handling <see cref="QuantityValue" /> objects, ensuring precise serialization and
///     deserialization with support for arbitrary scale and precision. The value is written and read as a regular decimal,
///     with overflow behavior when the number exceeds the range of a decimal. Additionally, it supports <see cref="JsonNumberHandling" />
///     options, including reading and writing from strings and handling named floating-point literals.
/// </remarks>
public class QuantityValueDecimalConverter : JsonConverter<QuantityValue>
{
    /// <inheritdoc />
    public override QuantityValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        decimal value;
        if (reader.TokenType == JsonTokenType.String)
        {
            var stringValue = reader.GetString()!;
            CultureInfo culture = CultureInfo.InvariantCulture;
            // TODO see if we want to support the named literals
            if ((options.NumberHandling & JsonNumberHandling.AllowNamedFloatingPointLiterals) != 0)
            {
                if (stringValue == culture.NumberFormat.NaNSymbol)
                {
                    return QuantityValue.NaN;
                }

                if (stringValue == culture.NumberFormat.PositiveInfinitySymbol)
                {
                    return QuantityValue.PositiveInfinity;
                }

                if (stringValue == culture.NumberFormat.NegativeInfinitySymbol)
                {
                    return QuantityValue.NegativeInfinity;
                }
            }
            
            if ((options.NumberHandling & JsonNumberHandling.AllowReadingFromString) == 0)
            {
                throw new JsonException(
                    "String tokens are not supported with the current `NumberHandling` settings. Consider specifying 'JsonNumberHandling.AllowReadingFromString' (see https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonnumberhandling)");
            }

            value = decimal.Parse(stringValue, culture);
        }
        else
        {
            value = reader.GetDecimal();
        }

        return new QuantityValue(value);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, QuantityValue value, JsonSerializerOptions options)
    {
        if ((options.NumberHandling & JsonNumberHandling.WriteAsString) != 0)
        {
            writer.WriteStringValue(value.ToDecimal().ToString(CultureInfo.InvariantCulture));
        }
        else if (QuantityValue.IsNaN(value) || QuantityValue.IsInfinity(value))
        {
            if ((options.NumberHandling & JsonNumberHandling.AllowNamedFloatingPointLiterals) == 0)
            {
                throw new JsonException(
                    $"Serializing '{value}' is not allowed. Consider specifying 'JsonNumberHandling.AllowNamedFloatingPointLiterals' (see https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonnumberhandling)");
            }

            writer.WriteStringValue(value.ToString(CultureInfo.InvariantCulture));
        }
        else
        {
            writer.WriteNumberValue(value.ToDecimal());
        }
    }
}
