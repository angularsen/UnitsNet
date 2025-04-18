using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UnitsNet.Serialization.JsonNet
{
    /// <summary>
    ///     JSON.net converter for all <see cref="IQuantity" /> types (e.g. all units in UnitsNet)
    ///     Use this converter to serialize and deserialize UnitsNet types to and from JSON using the unit abbreviation schema.
    /// </summary>
    /// <example>
    /// <code>
    /// {
    ///     "Value": 1.2,
    ///     "Unit": "mg",
    ///     "Type": "Mass"
    /// }
    /// </code>
    /// </example>
    /// <inheritdoc />
    public class AbbreviatedUnitsConverter : NullableQuantityConverter<IQuantity>
    {
        private const string ValueProperty = "Value";
        private const string UnitProperty = "Unit";
        private const string TypeProperty = "Type";

        private readonly QuantityValueSerializationFormat _valueSerializationFormat;
        private readonly QuantityValueDeserializationFormat _valueDeserializationFormat;
        private readonly IEqualityComparer<string?> _propertyComparer;

        private readonly UnitParser _unitParser;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="AbbreviatedUnitsConverter" /> class using the default
        ///     case-insensitive comparer and the specified <see cref="QuantityValueFormatOptions" />.
        /// </summary>
        /// <param name="valueFormatOptions">
        ///     The options for formatting quantity values during serialization and deserialization.
        ///     Defaults to a new instance of <see cref="QuantityValueFormatOptions" /> if not specified.
        /// </param>
        public AbbreviatedUnitsConverter(QuantityValueFormatOptions valueFormatOptions = new())
            : this(StringComparer.OrdinalIgnoreCase, valueFormatOptions)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AbbreviatedUnitsConverter" /> class.
        /// </summary>
        /// <param name="comparer">
        ///     The equality comparer used to compare property or quantity names, such as
        ///     <see cref="StringComparer.OrdinalIgnoreCase" />.
        /// </param>
        /// <param name="valueFormatOptions">
        ///     Options for formatting the quantity value during serialization and deserialization.
        /// </param>
        /// <remarks>
        ///     The <paramref name="comparer" /> is used exclusively for property name matching.
        ///     Quantity names are matched using the default comparer of <see cref="Quantity.ByName" />,
        ///     which is currently <see cref="StringComparer.OrdinalIgnoreCase" />.
        /// </remarks>
        public AbbreviatedUnitsConverter(IEqualityComparer<string?> comparer, QuantityValueFormatOptions valueFormatOptions = new())
            : this(UnitParser.Default, comparer, valueFormatOptions)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AbbreviatedUnitsConverter" /> class.
        /// </summary>
        /// <param name="unitParser">
        ///     The <see cref="UnitParser" /> used for deserializing an abbreviation back into its
        ///     corresponding unit.
        /// </param>
        /// <param name="valueFormatOptions">
        ///     The options specifying how values should be serialized and deserialized.
        ///     Defaults to a new instance of <see cref="QuantityValueFormatOptions" /> if not provided.
        /// </param>
        public AbbreviatedUnitsConverter(UnitParser unitParser, QuantityValueFormatOptions valueFormatOptions = new())
            : this(unitParser, StringComparer.OrdinalIgnoreCase, valueFormatOptions)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AbbreviatedUnitsConverter" /> class.
        /// </summary>
        /// <param name="unitParser">
        ///     The <see cref="UnitParser" /> used for deserializing an abbreviation back into its
        ///     corresponding unit.
        /// </param>
        /// <param name="propertyComparer">
        ///     The comparer used to compare property names during serialization and deserialization.
        ///     For example, <see cref="StringComparer.OrdinalIgnoreCase" /> can be used for case-insensitive comparisons.
        /// </param>
        /// <param name="valueFormatOptions">
        ///     The options specifying how values should be serialized and deserialized.
        ///     Defaults to a new instance of <see cref="QuantityValueFormatOptions" /> if not provided.
        /// </param>
        public AbbreviatedUnitsConverter(UnitParser unitParser, IEqualityComparer<string?> propertyComparer,
            QuantityValueFormatOptions valueFormatOptions = new())
        {
            _unitParser = unitParser ?? throw new ArgumentNullException(nameof(unitParser));
            _propertyComparer = propertyComparer?? throw new ArgumentNullException(nameof(propertyComparer));
            _valueSerializationFormat = valueFormatOptions.SerializationFormat;
            _valueDeserializationFormat = valueFormatOptions.DeserializationFormat;
        }
        
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, IQuantity? quantity, JsonSerializer serializer)
        {
            if (quantity is null)
            {
                writer.WriteNull();
                return;
            }
            
            writer.WriteStartObject();

            WriteValueProperty(writer, quantity, serializer);
            WriteUnitProperty(writer, quantity, serializer);
            WriteTypeProperty(writer, quantity, serializer);

            writer.WriteEndObject();
        }

        /// <summary>
        /// Writes the 'Value' property of the specified quantity to the JSON output.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> used to write the JSON data.</param>
        /// <param name="quantity">The <see cref="IQuantity"/> instance whose 'Value' property is to be written.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <remarks>
        /// This method writes the numerical value of the quantity using the general ("G") format and invariant culture.
        /// It can be overridden to customize the representation of the value, such as using a fractional format or a different numeric type.
        /// </remarks>
        protected virtual void WriteValueProperty(JsonWriter writer, IQuantity quantity, JsonSerializer serializer)
        {
            writer.WritePropertyName(ValueProperty);
            writer.WriteValue(quantity.Value, serializer, _valueSerializationFormat);
        }

        /// <summary>
        /// Writes the 'Unit' property to the JSON output.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> used to write the JSON content.</param>
        /// <param name="quantity">The <see cref="IQuantity"/> instance whose unit is being written.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <remarks>
        /// This method can be overridden to customize the format or type of the 'Unit' property in the JSON payload.
        /// </remarks>
        protected virtual void WriteUnitProperty(JsonWriter writer, IQuantity quantity, JsonSerializer serializer)
        {
            writer.WritePropertyName(UnitProperty);
            writer.WriteValue(_unitParser.Abbreviations.GetDefaultAbbreviation(quantity.UnitKey, serializer.Culture));
        }

        /// <summary>
        ///     Writes the 'Type' property.
        /// </summary>
        /// <param name="writer">The JsonWriter to write to.</param>
        /// <param name="quantity"></param>
        /// <param name="serializer">The calling serializer.</param>
        /// <remarks>
        ///     This method can be overridden to customize the payload type or format.
        /// </remarks>
        protected virtual void WriteTypeProperty(JsonWriter writer, IQuantity quantity, JsonSerializer serializer)
        {
            writer.WritePropertyName(TypeProperty);
            writer.WriteValue(quantity.QuantityInfo.Name);
        }

        /// <summary>
        ///     Reads the "Value" property from the JSON reader and converts it to a <see cref="QuantityValue" />.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader" /> to read the value from.</param>
        /// <param name="objectType">The type of the object to deserialize.</param>
        /// <param name="serializer">The <see cref="JsonSerializer" /> used for deserialization.</param>
        /// <returns>The parsed <see cref="QuantityValue" />.</returns>
        /// <exception cref="JsonSerializationException">
        ///     Thrown if the value cannot be read or converted to a <see cref="QuantityValue" />.
        /// </exception>
        protected virtual QuantityValue ReadValueProperty(JsonReader reader, Type objectType, JsonSerializer serializer)
        {
            return reader.ReadValue(serializer, _valueDeserializationFormat);
        }

        /// <summary>
        ///     Reads the unit abbreviation property from the JSON reader.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader" /> instance to read from.</param>
        /// <param name="objectType">The type of the object to deserialize.</param>
        /// <param name="serializer">The <see cref="JsonSerializer"/> used for deserialization.</param>
        /// <returns>
        ///     The unit abbreviation as a <see cref="string" /> if present; otherwise, <c>null</c>.
        /// </returns>
        /// <exception cref="JsonReaderException">
        ///     Thrown if the JSON reader is not positioned at a valid string value for the unit abbreviation.
        /// </exception>
        protected virtual string? ReadUnitAbbreviationProperty(JsonReader reader, Type objectType, JsonSerializer serializer)
        {
            return reader.ReadAsString();
        }

        /// <summary>
        ///     Reads the quantity name property from the JSON reader.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader" /> instance used to read the JSON data.</param>
        /// <param name="objectType">The type of the object to deserialize.</param>
        /// <param name="serializer">The <see cref="JsonSerializer"/> used for deserialization.</param>
        /// <returns>
        ///     The quantity name as a string, or <c>null</c> if the value is not present or cannot be read.
        /// </returns>
        /// <remarks>
        ///     This method is used to extract the name of the quantity type from the JSON data.
        ///     The quantity name is typically used to identify the type of measurement (e.g., "Mass", "Length").
        /// </remarks>
        protected virtual string? ReadQuantityNameProperty(JsonReader reader, Type objectType, JsonSerializer serializer)
        {
            return reader.ReadAsString();
        }
        
        /// <inheritdoc />
        public override IQuantity? ReadJson(JsonReader reader, Type objectType, IQuantity? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return objectType == typeof(IQuantity) || typeof(IQuantity).IsAssignableFrom(Nullable.GetUnderlyingType(objectType))
                    ? null
                    : _unitParser.Quantities.GetQuantityInfo(objectType).Zero;
            }

            QuantityValue value = QuantityValue.Zero;
            string? unitAbbreviation = null, quantityName = null;
            if (reader.TokenType == JsonToken.StartObject)
            {
                while (reader.Read() && reader.TokenType != JsonToken.EndObject)
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        var propertyName = reader.Value as string;
                        if (_propertyComparer.Equals(propertyName, ValueProperty))
                        {
                            value = ReadValueProperty(reader, objectType, serializer);
                        }
                        else if (_propertyComparer.Equals(propertyName, UnitProperty))
                        {
                            unitAbbreviation = ReadUnitAbbreviationProperty(reader, objectType, serializer);
                        }
                        else if (_propertyComparer.Equals(propertyName, TypeProperty))
                        {
                            quantityName = ReadQuantityNameProperty(reader, objectType, serializer);
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
            }
            
            UnitInfo unitInfo;
            if (quantityName != null && unitAbbreviation != null)
            {
                unitInfo = _unitParser.GetUnitFromAbbreviation(quantityName, unitAbbreviation, serializer.Culture);
            }
            else if (unitAbbreviation != null)
            {
                unitInfo = objectType == typeof(IQuantity)
                    ? _unitParser.GetUnitFromAbbreviation(unitAbbreviation, serializer.Culture)
                    : _unitParser.GetUnitFromAbbreviation(Nullable.GetUnderlyingType(objectType) ?? objectType, unitAbbreviation, serializer.Culture);
            }
            else if (quantityName != null)
            {
                unitInfo = _unitParser.Quantities.GetQuantityByName(quantityName).BaseUnitInfo;
            }
            else if (objectType != typeof(IQuantity))
            {
                unitInfo = _unitParser.Quantities.GetQuantityInfo(Nullable.GetUnderlyingType(objectType) ?? objectType).BaseUnitInfo;
            }
            else
            {
                throw new FormatException("The target unit cannot be determined from the provided JSON.");
            }

            return unitInfo.From(value);
        }
    }
}
