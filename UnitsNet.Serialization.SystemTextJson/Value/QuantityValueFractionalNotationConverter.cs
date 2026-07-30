// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitsNet.Serialization.SystemTextJson.Value;

/// <summary>
///     Provides functionality for serializing and deserializing <see cref="QuantityValue" /> objects
///     to and from JSON format.
/// </summary>
/// <remarks>
///     This converter handles the serialization and deserialization of <see cref="QuantityValue" /> objects
///     by utilizing a custom <see cref="QuantityValue" /> for <see cref="JsonConverter{T}" /> values.
///     It ensures that the numerator and denominator properties of <see cref="BigInteger" /> are
///     properly processed during JSON operations.
/// </remarks>
public class QuantityValueFractionalNotationConverter : JsonConverter<QuantityValue>
{
    private static readonly JsonEncodedText PropName_Numerator = JsonEncodedText.Encode("N");
    private static readonly JsonEncodedText PropName_Numerator_Lowercase = JsonEncodedText.Encode("n");

    private static readonly JsonEncodedText PropName_Denominator = JsonEncodedText.Encode("D");
    private static readonly JsonEncodedText PropName_Denominator_Lowercase = JsonEncodedText.Encode("d");

    private readonly JsonConverter<BigInteger> _bigIntegerConverter;
    private readonly bool _reduceTerms;

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityValue" /> class
    ///     with default settings.
    /// </summary>
    /// <remarks>
    ///     This constructor sets up the converter to handle the serialization and deserialization
    ///     of <see cref="QuantityValueFractionalNotationConverter" /> objects in JSON format, using default behavior.
    /// </remarks>
    public QuantityValueFractionalNotationConverter()
        : this(false)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityValueFractionalNotationConverter" /> class
    ///     with the default configuration.
    /// </summary>
    /// <remarks>
    ///     This constructor sets up the converter with default settings, where terms are not reduced
    ///     during serialization and deserialization.
    /// </remarks>
    public QuantityValueFractionalNotationConverter(bool reduceTerms)
        : this(BigIntegerConverter.Default, reduceTerms)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityValueFractionalNotationConverter" /> class
    ///     with the specified <see cref="JsonConverter{T}" /> for <see cref="BigInteger" /> values and an option
    ///     to reduce terms during serialization.
    /// </summary>
    /// <param name="bigIntegerConverter">
    ///     The <see cref="JsonConverter{T}" /> used to handle serialization and deserialization of <see cref="BigInteger" />
    ///     values.
    /// </param>
    /// <param name="reduceTerms">
    ///     A boolean value indicating whether the terms should be reduced before serializing.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the <paramref name="bigIntegerConverter" /> is <c>null</c>.
    /// </exception>
    public QuantityValueFractionalNotationConverter(JsonConverter<BigInteger> bigIntegerConverter, bool reduceTerms = false)
    {
        _bigIntegerConverter = bigIntegerConverter ?? throw new ArgumentNullException(nameof(bigIntegerConverter));
        _reduceTerms = reduceTerms;
    }

    /// <summary>
    ///     Gets the default instance of the <see cref="QuantityValueFractionalNotationConverter" />.
    /// </summary>
    /// <remarks>
    ///     This property provides a pre-configured, shared instance of the converter
    ///     with default settings, simplifying the serialization and deserialization
    ///     of <see cref="QuantityValue" /> objects in JSON format.
    /// </remarks>
    public static QuantityValueFractionalNotationConverter Default { get; } = new();

    /// <summary>
    ///     Gets an instance of <see cref="QuantityValueFractionalNotationConverter" /> configured to reduce terms
    ///     during serialization and deserialization.
    /// </summary>
    /// <remarks>
    ///     This property provides a pre-configured converter that simplifies fractional representations
    ///     by reducing the numerator and denominator to their smallest terms.
    /// </remarks>
    public static QuantityValueFractionalNotationConverter Reducing { get; } = new(true);

    /// <inheritdoc />
    public override QuantityValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected StartObject token.");
        }

        BigInteger? numerator = null;
        BigInteger? denominator = null;
        JsonEncodedText numeratorProperty, denominatorProperty;
        if (options.PropertyNamesShouldStartWithLowercase())
        {
            numeratorProperty = PropName_Numerator_Lowercase;
            denominatorProperty = PropName_Denominator_Lowercase;
        }
        else
        {
            numeratorProperty = PropName_Numerator;
            denominatorProperty = PropName_Denominator;
        }

        if (options.PropertyNameCaseInsensitive)
        {
            while (reader.ReadNextProperty())
            {
                var propertyName = reader.GetString();
                reader.Read();
                if (StringComparer.OrdinalIgnoreCase.Equals(propertyName, numeratorProperty.Value))
                {
                    numerator = _bigIntegerConverter.Read(ref reader, typeof(BigInteger), options);
                }
                else if (StringComparer.OrdinalIgnoreCase.Equals(propertyName, denominatorProperty.Value))
                {
                    denominator = _bigIntegerConverter.Read(ref reader, typeof(BigInteger), options);
                }
                else if (options.UnmappedMemberHandling == JsonUnmappedMemberHandling.Skip)
                {
                    reader.Skip(); // Skip unknown properties
                }
                else
                {
                    throw new JsonException($"'{propertyName}' was no found in the list of members of '{typeToConvert}'.");
                }
            }
        }
        else
        {
            while (reader.ReadNextProperty())
            {
                if (reader.ValueTextEquals(numeratorProperty.EncodedUtf8Bytes))
                {
                    reader.Read();
                    numerator = _bigIntegerConverter.Read(ref reader, typeof(BigInteger), options);
                }
                else if (reader.ValueTextEquals(denominatorProperty.EncodedUtf8Bytes))
                {
                    reader.Read();
                    denominator = _bigIntegerConverter.Read(ref reader, typeof(BigInteger), options);
                }
                else if (options.UnmappedMemberHandling == JsonUnmappedMemberHandling.Skip)
                {
                    reader.Skip(); // Skip unknown properties
                }
                else
                {
                    throw new JsonException($"'{reader.GetString()}' was no found in the list of members of '{typeToConvert}'.");
                }
            }
        }

        if (numerator.HasValue && denominator.HasValue)
        {
            return QuantityValue.FromTerms(numerator.Value, denominator.Value);
        }

        if (numerator.HasValue)
        {
            return numerator.Value;
        }

        return denominator.HasValue ? QuantityValue.FromTerms(BigInteger.Zero, denominator.Value) : QuantityValue.Zero;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, QuantityValue value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        (BigInteger numerator, BigInteger denominator) = _reduceTerms ? QuantityValue.Reduce(value) : value;
        JsonEncodedText numeratorProperty, denominatorProperty;
        if (options.PropertyNamesShouldStartWithLowercase())
        {
            numeratorProperty = PropName_Numerator_Lowercase;
            denominatorProperty = PropName_Denominator_Lowercase;
        }
        else
        {
            numeratorProperty = PropName_Numerator;
            denominatorProperty = PropName_Denominator;
        }

        if (options.DefaultIgnoreCondition == JsonIgnoreCondition.WhenWritingDefault)
        {
            // Write only if the property is non-default.
            if (!numerator.IsZero)
            {
                WriteBigInteger(writer, options, numeratorProperty, numerator);
            }

            if (!denominator.IsOne)
            {
                WriteBigInteger(writer, options, denominatorProperty, denominator);
            }
        }
        else // For example, when DefaultIgnoreCondition is Never.
        {
            WriteBigInteger(writer, options, numeratorProperty, numerator);
            WriteBigInteger(writer, options, denominatorProperty, denominator);
        }

        writer.WriteEndObject();
    }

    private void WriteBigInteger(Utf8JsonWriter writer, JsonSerializerOptions options, JsonEncodedText propertyName, BigInteger value)
    {
        writer.WritePropertyName(propertyName);
        _bigIntegerConverter.Write(writer, value, options);
    }
}
