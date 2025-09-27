// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Numerics;
using Newtonsoft.Json;

namespace UnitsNet.Serialization.JsonNet.Value;

/// <summary>
///     A custom JSON converter for serializing and deserializing <see cref="QuantityValue" /> objects.
/// </summary>
/// <remarks>
///     This converter handles the serialization of <see cref="QuantityValue" /> as a fraction,
///     represented by its numerator and denominator, to ensure precise representation of values.
/// </remarks>
public class QuantityValueFractionalNotationConverter : JsonConverter<QuantityValue>
{
    private const string NumeratorPropertyName = "N";
    private const string DenominatorPropertyName = "D";
    private readonly bool _reduceTerms;

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
    {
        _reduceTerms = reduceTerms;
    }

    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, QuantityValue value, JsonSerializer serializer)
    {
        (BigInteger numerator, BigInteger denominator) = _reduceTerms ? QuantityValue.Reduce(value) : value;
        
        writer.WriteStartObject();

        if((serializer.DefaultValueHandling & DefaultValueHandling.Ignore) != 0)
        {
            // Write only if the property is non-default.
            if (!numerator.IsZero)
            {
                writer.WritePropertyName(NumeratorPropertyName);
                serializer.Serialize(writer, numerator);
            }

            if (!denominator.IsOne)
            {
                writer.WritePropertyName(DenominatorPropertyName);
                serializer.Serialize(writer, denominator);
            }
        }
        else
        {
            writer.WritePropertyName(NumeratorPropertyName);
            serializer.Serialize(writer, numerator);
            writer.WritePropertyName(DenominatorPropertyName);
            serializer.Serialize(writer, denominator);
        }

        writer.WriteEndObject();
    }

    /// <inheritdoc />
    public override QuantityValue ReadJson(JsonReader reader, Type objectType, QuantityValue existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        BigInteger? numerator = null;
        BigInteger? denominator = null;
        // Ensure the reader is at the start of an object
        if (reader.TokenType != JsonToken.StartObject)
        {
            throw new JsonSerializationException("Expected StartObject token.");
        }

        // Read through the JSON object
        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.EndObject)
            {
                break; // End of the object
            }

            if (reader.TokenType == JsonToken.PropertyName)
            {
                var propertyName = (string)reader.Value!;
                reader.Read(); // Move to the value
                if (string.Equals(propertyName, NumeratorPropertyName, StringComparison.OrdinalIgnoreCase))
                {
                    numerator = serializer.Deserialize<BigInteger>(reader);
                }
                else if (string.Equals(propertyName, DenominatorPropertyName, StringComparison.OrdinalIgnoreCase))
                {
                    denominator = serializer.Deserialize<BigInteger>(reader);
                }
                else if (serializer.MissingMemberHandling == MissingMemberHandling.Ignore)
                {
                    reader.Skip();
                }
                else
                {
                    throw new JsonException($"'{propertyName}' was no found in the list of members of '{objectType}'.");
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
}
