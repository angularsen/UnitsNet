// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitsNet.Serialization.SystemTextJson;

/// <summary>
///     Provides a custom JSON converter for <see cref="UnitsNet.IQuantity" />.
///     This converter handles serialization and deserialization of quantities,
///     ensuring that <see cref="UnitsNet.IQuantity" /> objects are correctly
///     represented in JSON format.
/// </summary>
public abstract class InterfaceQuantityConverterBase<TJsonUnit> : JsonConverter<IQuantity>
{
    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, IQuantity quantity, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        JsonEncodedText valueProperty, unitProperty, typeProperty;
        if (options.PropertyNamesShouldStartWithLowercase())
        {
            valueProperty = JsonQuantityPropertyNames.ValuePropertyName_Lowercase;
            unitProperty = JsonQuantityPropertyNames.UnitPropertyName_Lowercase;
            typeProperty = JsonQuantityPropertyNames.TypePropertyName_Lowercase;
        }
        else
        {
            valueProperty = JsonQuantityPropertyNames.ValuePropertyName;
            unitProperty = JsonQuantityPropertyNames.UnitPropertyName;
            typeProperty = JsonQuantityPropertyNames.TypePropertyName;
        }

        if (options.DefaultIgnoreCondition == JsonIgnoreCondition.WhenWritingDefault)
        {
            if (!QuantityValue.IsZero(quantity.Value))
            {
                // write the Value property
                writer.WritePropertyName(valueProperty);
                WriteValueProperty(writer, quantity, options);
            }

            if (quantity.UnitKey.UnitValue != quantity.QuantityInfo.BaseUnitInfo.UnitKey.UnitValue)
            {
                // write the Unit property
                writer.WritePropertyName(unitProperty);
                WriteUnitProperty(writer, quantity, options);
            }
        }
        else
        {
            // write the Value property
            writer.WritePropertyName(valueProperty);
            WriteValueProperty(writer, quantity, options);
            // write the Unit property 
            writer.WritePropertyName(unitProperty);
            WriteUnitProperty(writer, quantity, options);
        }

        // write the Type property (disambiguation based on the quantity name)
        writer.WriteString(typeProperty, quantity.QuantityInfo.Name);

        writer.WriteEndObject();
    }
    
    /// <inheritdoc />
    public override IQuantity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        QuantityValue value = QuantityValue.Zero;
        TJsonUnit? unit = default;
        string? quantityName = null;
        JsonEncodedText valueProperty, unitProperty, typeProperty;
        if (options.PropertyNamesShouldStartWithLowercase())
        {
            valueProperty = JsonQuantityPropertyNames.ValuePropertyName_Lowercase;
            unitProperty = JsonQuantityPropertyNames.UnitPropertyName_Lowercase;
            typeProperty = JsonQuantityPropertyNames.TypePropertyName_Lowercase;
        }
        else
        {
            valueProperty = JsonQuantityPropertyNames.ValuePropertyName;
            unitProperty = JsonQuantityPropertyNames.UnitPropertyName;
            typeProperty = JsonQuantityPropertyNames.TypePropertyName;
        }

        if (options.PropertyNameCaseInsensitive)
        {
            while (reader.ReadNextProperty())
            {
                var propertyName = reader.GetString();
                reader.Read();
                if (StringComparer.OrdinalIgnoreCase.Equals(propertyName, valueProperty.Value))
                {
                    value = ReadValueProperty(ref reader, options);
                }
                else if (StringComparer.OrdinalIgnoreCase.Equals(propertyName, unitProperty.Value))
                {
                    unit = ReadUnitProperty(ref reader, options);
                }
                else if (StringComparer.OrdinalIgnoreCase.Equals(propertyName, typeProperty.Value))
                {
                    quantityName = reader.GetString();
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
                if (reader.ValueTextEquals(valueProperty.EncodedUtf8Bytes))
                {
                    reader.Read();
                    value = ReadValueProperty(ref reader, options);
                }
                else if (reader.ValueTextEquals(unitProperty.EncodedUtf8Bytes))
                {
                    reader.Read();
                    unit = ReadUnitProperty(ref reader, options);
                }
                else if (reader.ValueTextEquals(typeProperty.EncodedUtf8Bytes))
                {
                    reader.Read();
                    quantityName = reader.GetString();
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

        return CreateQuantity(value, unit, quantityName);
    }
    
    /// <summary>
    ///     Writes the value property of the quantity to the JSON output.
    /// </summary>
    /// <param name="writer">
    ///     The <see cref="Utf8JsonWriter" /> used to write the JSON output.
    /// </param>
    /// <param name="quantity">
    ///     The quantity whose "Value" property is being written.
    /// </param>
    /// <param name="options">
    ///     The <see cref="JsonSerializerOptions" /> that specify options for JSON serialization.
    /// </param>
    protected abstract void WriteValueProperty(Utf8JsonWriter writer, IQuantity quantity, JsonSerializerOptions options);

    /// <summary>
    ///     Writes the unit property of the quantity to the JSON output.
    /// </summary>
    /// <param name="writer">
    ///     The <see cref="Utf8JsonWriter" /> used to write the JSON output.
    /// </param>
    /// <param name="quantity">
    ///     The quantity whose unit is being written.
    /// </param>
    /// <param name="options">
    ///     The <see cref="JsonSerializerOptions" /> that specify options for JSON serialization.
    /// </param>
    protected abstract void WriteUnitProperty(Utf8JsonWriter writer, IQuantity quantity, JsonSerializerOptions options);

    /// <summary>
    ///     Reads the value property of a JSON object representing a quantity.
    /// </summary>
    /// <param name="reader">
    ///     The <see cref="Utf8JsonReader" /> used to read the JSON data.
    /// </param>
    /// <param name="options">
    ///     The <see cref="JsonSerializerOptions" /> that specify options for deserialization.
    /// </param>
    /// <returns>
    ///     A <see cref="QuantityValue" /> representing the value of the quantity read from the JSON data.
    /// </returns>
    protected abstract QuantityValue ReadValueProperty(ref Utf8JsonReader reader, JsonSerializerOptions options);

    /// <summary>
    ///     Reads the "Unit" property of a JSON object representing a quantity.
    /// </summary>
    /// <param name="reader">
    ///     The <see cref="Utf8JsonReader" /> used to read the JSON data.
    /// </param>
    /// <param name="options">
    ///     The <see cref="JsonSerializerOptions" /> that specify options for deserialization.
    /// </param>
    /// <returns>
    ///     A <see cref="UnitInfo" /> representing the matching unit of the quantity read from the JSON data.
    /// </returns>
    /// <remarks>
    ///     This method is virtual, allowing derived classes to customize how the value property is read.
    /// </remarks>
    protected abstract TJsonUnit ReadUnitProperty(ref Utf8JsonReader reader, JsonSerializerOptions options);
    
    /// <summary>
    /// Creates an instance of <see cref="UnitsNet.IQuantity" /> using the specified value, unit, and quantity name.
    /// </summary>
    /// <param name="value">The numerical value of the quantity.</param>
    /// <param name="unit">The unit associated with the quantity.</param>
    /// <param name="quantityName">The name used to identify the type of quantity.</param>
    /// <returns>An instance of <see cref="UnitsNet.IQuantity" /> representing the specified value and unit.</returns>
    protected abstract IQuantity CreateQuantity(QuantityValue value, TJsonUnit? unit, string? quantityName);
}
