// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitsNet.Serialization.SystemTextJson.Value;

/// <summary>
///     Provides functionality to convert <see cref="QuantityValue" /> instances to and from their JSON representation
///     using double-precision floating-point notation.
/// </summary>
/// <remarks>
///     This converter is designed to handle serialization and deserialization of <see cref="QuantityValue" /> objects
///     using double-precision floating-point notation. The configurable maximum number of significant digits is only
///     applied during deserialization to control the precision of the parsed input.
///     <para>
///         Additionally, this converter supports the <see cref="JsonNumberHandling.WriteAsString" /> option for writing
///         numeric values as strings during serialization, and the
///         <see cref="JsonNumberHandling.AllowNamedFloatingPointLiterals" />
///         option for deserializing named floating-point literals such as "NaN", "Infinity", and "-Infinity".
///     </para>
/// </remarks>
public class QuantityValueDoubleConverter : JsonConverter<QuantityValue>
{
    private readonly byte _maxNumberOfSignificantDigits;

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityValueDoubleConverter" /> class
    ///     with a default maximum number of significant digits set to 15.
    /// </summary>
    /// <remarks>
    ///     This constructor simplifies the creation of the converter by using a default serialization precision of 15
    ///     significant digits.
    /// </remarks>
    public QuantityValueDoubleConverter()
        : this(15)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityValueDoubleConverter" /> class with an optional
    ///     maximum number of significant digits for serialization.
    /// </summary>
    /// <param name="maxNumberOfSignificantDigits">
    ///     The maximum number of significant digits to use during serialization.
    /// </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    ///     Thrown when the number of significant digits is less than 1 or greater than 17.
    /// </exception>
    /// <remarks>
    ///     This constructor allows configuring the precision of the precision used when converting from double.
    /// </remarks>
    public QuantityValueDoubleConverter(byte maxNumberOfSignificantDigits)
    {
        if (maxNumberOfSignificantDigits is < 1 or > 17)
        {
            throw new ArgumentOutOfRangeException(nameof(maxNumberOfSignificantDigits), maxNumberOfSignificantDigits,
                "The maximum number of significant digits must be between 1 and 17.");
        }
        
        _maxNumberOfSignificantDigits = maxNumberOfSignificantDigits;
    }

    /// <inheritdoc />
    public override QuantityValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        double value;
        if (reader.TokenType == JsonTokenType.String)
        {
            if ((options.NumberHandling & (JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.AllowNamedFloatingPointLiterals)) == 0)
            {
                throw new JsonException(
                    "String tokens are not supported with the current `NumberHandling` settings. Consider specifying 'JsonNumberHandling.AllowReadingFromString' (see https://learn.microsoft.com/dotnet/api/system.text.json.serialization.jsonnumberhandling)");
            }

            value = double.Parse(reader.GetString()!, CultureInfo.InvariantCulture);
        }
        else
        {
            value = reader.GetDouble();
        }

        return QuantityValue.FromDoubleRounded(value, _maxNumberOfSignificantDigits);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, QuantityValue value, JsonSerializerOptions options)
    {
        if ((options.NumberHandling & JsonNumberHandling.WriteAsString) != 0)
        {
            writer.WriteStringValue(value.ToString("R", CultureInfo.InvariantCulture));
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
            writer.WriteNumberValue(value.ToDouble());
        }
    }
}
