// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnitsNet.Serialization.SystemTextJson;

internal static class JsonQuantityPropertyNames
{
    public static readonly JsonEncodedText ValuePropertyName = JsonEncodedText.Encode("Value");
    public static readonly JsonEncodedText ValuePropertyName_Lowercase = JsonEncodedText.Encode("value");

    public static readonly JsonEncodedText UnitPropertyName = JsonEncodedText.Encode("Unit");
    public static readonly JsonEncodedText UnitPropertyName_Lowercase = JsonEncodedText.Encode("unit");
    
    public static readonly JsonEncodedText TypePropertyName = JsonEncodedText.Encode("Type");
    public static readonly JsonEncodedText TypePropertyName_Lowercase = JsonEncodedText.Encode("type");
}

/// <summary>
///     Provides a custom JSON converter for quantities implementing <see cref="UnitsNet.IQuantity{TSelf, TUnitType}" />.
///     This generic converter handles serialization and deserialization of quantities,
///     ensuring that objects of type <typeparamref name="TQuantity" /> are correctly
///     represented in JSON format.
/// </summary>
/// <typeparam name="TQuantity">
///     The type of the quantity being serialized or deserialized, which must implement
///     <see cref="UnitsNet.IQuantity{TSelf, TUnitType}" />.
/// </typeparam>
/// <typeparam name="TUnit">
///     The type of the unit enumeration associated with the quantity, which must be a value type and an enumeration.
/// </typeparam>
/// <remarks>
///     In order to use this converter directly, you need to make sure that the <see cref="JsonSerializerOptions" />
///     contains a converter for both the <see cref="IQuantity{TUnitType}.Unit" /> and the
///     <see cref="IQuantity.Value" /> of the quantity.
/// </remarks>
public abstract class JsonQuantityConverterBase<TQuantity, TUnit> : JsonConverter<TQuantity>
    where TQuantity : IQuantity<TQuantity, TUnit>
    where TUnit : struct, Enum
{
    private readonly QuantityInfo<TQuantity, TUnit> _quantityInfo;

    /// <summary>
    ///     Initializes a new instance of the converter using the default <see cref="QuantityInfo{TQuantity, TUnit}" /> of the specified quantity type.
    /// </summary>
    /// <remarks>
    ///     This constructor creates a converter that uses the default <see cref="QuantityInfo{TQuantity, TUnit}" />
    ///     for the specified quantity type <typeparamref name="TQuantity" />. It is particularly useful when
    ///     no custom <see cref="QuantityInfo{TQuantity, TUnit}" /> is required for serialization or deserialization.
    /// </remarks>
    protected JsonQuantityConverterBase()
#if NET
        // TODO see if we want to expose the QuantityInfo (a.k.a. the static "Info" property) on the IQuantity<TQuantity, TUnit> interface
        : this(TQuantity.From(QuantityValue.Zero, default).QuantityInfo)
#else
        : this((QuantityInfo<TQuantity, TUnit>)UnitsNetSetup.Default.Quantities.GetQuantityInfo(typeof(TQuantity)))
#endif
    {
    }

    /// <summary>
    ///     Initializes a new instance of the converter with the specified <see cref="QuantityInfo{TQuantity, TUnit}" />.
    /// </summary>
    /// <param name="quantityInfo">
    ///     The <see cref="QuantityInfo{TQuantity, TUnit}" /> instance that provides metadata and configuration
    ///     for the quantity type <typeparamref name="TQuantity" /> and its associated unit type <typeparamref name="TUnit" />.
    /// </param>
    protected JsonQuantityConverterBase(QuantityInfo<TQuantity, TUnit> quantityInfo)
    {
        _quantityInfo = quantityInfo ?? throw new ArgumentNullException(nameof(quantityInfo));
    }

    /// <inheritdoc />
    public override TQuantity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        QuantityValue value = QuantityValue.Zero;
        TUnit? unit = null;
        JsonEncodedText valueProperty, unitProperty;
        if (options.PropertyNamesShouldStartWithLowercase())
        {
            valueProperty = JsonQuantityPropertyNames.ValuePropertyName_Lowercase;
            unitProperty = JsonQuantityPropertyNames.UnitPropertyName_Lowercase;
        }
        else
        {
            valueProperty = JsonQuantityPropertyNames.ValuePropertyName;
            unitProperty = JsonQuantityPropertyNames.UnitPropertyName;
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

        // note: we could be using TQuantity.From(value, unit.Value) instead
        return unit == null ? _quantityInfo.BaseUnitInfo.From(value) : _quantityInfo.From(value, unit.Value);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, TQuantity quantity, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        JsonEncodedText valueProperty, unitProperty;
        if (options.PropertyNamesShouldStartWithLowercase())
        {
            valueProperty = JsonQuantityPropertyNames.ValuePropertyName_Lowercase;
            unitProperty = JsonQuantityPropertyNames.UnitPropertyName_Lowercase;
        }
        else
        {
            valueProperty = JsonQuantityPropertyNames.ValuePropertyName;
            unitProperty = JsonQuantityPropertyNames.UnitPropertyName;
        }

        if (options.DefaultIgnoreCondition == JsonIgnoreCondition.WhenWritingDefault)
        {
            if (!QuantityValue.IsZero(quantity.Value))
            {
                writer.WritePropertyName(valueProperty);
                WriteValueProperty(writer, quantity, options);
            }

            if (!EqualityComparer<TUnit>.Default.Equals(quantity.Unit, _quantityInfo.BaseUnitInfo.Value))
            {
                writer.WritePropertyName(unitProperty);
                WriteUnitProperty(writer, quantity, options);
            }
        }
        else
        {
            writer.WritePropertyName(valueProperty);
            WriteValueProperty(writer, quantity, options);
            writer.WritePropertyName(unitProperty);
            WriteUnitProperty(writer, quantity, options);
        }

        writer.WriteEndObject();
    }

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
    /// <remarks>
    ///     This method is virtual, allowing derived classes to customize how the value property is read.
    /// </remarks>
    /// <exception cref="JsonException">
    ///     Thrown if the JSON data is invalid or cannot be deserialized into a <see cref="QuantityValue" />.
    /// </exception>
    protected abstract QuantityValue ReadValueProperty(ref Utf8JsonReader reader, JsonSerializerOptions options);

    /// <summary>
    ///     Reads the unit property from the JSON input.
    /// </summary>
    /// <param name="reader">
    ///     The <see cref="Utf8JsonReader" /> used to read the JSON input.
    /// </param>
    /// <param name="options">
    ///     The <see cref="JsonSerializerOptions" /> that specify options for deserialization.
    /// </param>
    /// <returns>
    ///     The deserialized unit of type <typeparamref name="TUnit" />, or <c>null</c> if the unit could not be read.
    /// </returns>
    /// <exception cref="JsonException">
    ///     Thrown if the JSON input is invalid or does not contain a valid unit property.
    /// </exception>
    protected abstract TUnit? ReadUnitProperty(ref Utf8JsonReader reader, JsonSerializerOptions options);

    /// <summary>
    ///     Writes the "Value" property of the quantity to the JSON output.
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
    protected abstract void WriteValueProperty(Utf8JsonWriter writer, TQuantity quantity, JsonSerializerOptions options);

    /// <summary>
    ///     Writes the unit property of the quantity to the JSON output.
    /// </summary>
    /// <param name="writer">
    ///     The <see cref="Utf8JsonWriter" /> used to write the JSON output.
    /// </param>
    /// <param name="quantity">
    ///     The quantity whose unit property is being written.
    /// </param>
    /// <param name="options">
    ///     The <see cref="JsonSerializerOptions" /> that specify options for JSON serialization.
    /// </param>
    /// <remarks>
    ///     This method writes the unit property name and its value to the JSON output.
    ///     The property name is determined by the <see cref="JsonSerializerOptions.PropertyNamingPolicy" /> if specified,
    ///     otherwise it defaults to the value of <c>UnitPropertyName</c>.
    /// </remarks>
    protected abstract void WriteUnitProperty(Utf8JsonWriter writer, TQuantity quantity, JsonSerializerOptions options);
}

/// <summary>
///     Provides a custom JSON converter for quantities implementing <see cref="UnitsNet.IQuantity{TSelf, TUnitType}" />.
///     This generic converter handles serialization and deserialization of quantities,
///     ensuring that objects of type <typeparamref name="TQuantity" /> are correctly
///     represented in JSON format.
/// </summary>
/// <typeparam name="TQuantity">
///     The type of the quantity being serialized or deserialized, which must implement
///     <see cref="UnitsNet.IQuantity{TSelf, TUnitType}" />.
/// </typeparam>
/// <typeparam name="TUnit">
///     The type of the unit enumeration associated with the quantity, which must be a value type and an enumeration.
/// </typeparam>
/// <remarks>
///     In order to use this converter directly, you need to make sure that the <see cref="JsonSerializerOptions" />
///     contains a converter for both the <see cref="IQuantity{TUnitType}.Unit" /> and the
///     <see cref="IQuantity.Value" /> of the quantity.
/// </remarks>
#if NET
[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
#endif
public class JsonQuantityConverter<TQuantity, TUnit> : JsonQuantityConverterBase<TQuantity, TUnit>
    where TQuantity : IQuantity<TQuantity, TUnit>
    where TUnit : struct, Enum
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="JsonQuantityConverter{TQuantity,TUnit}" /> class
    ///     using the default <see cref="QuantityInfo{TQuantity, TUnit}" /> of the specified quantity type.
    /// </summary>
    /// <remarks>
    ///     This constructor creates a converter that uses the default <see cref="QuantityInfo{TQuantity, TUnit}" />
    ///     for the specified quantity type <typeparamref name="TQuantity" />. It is particularly useful when
    ///     no custom <see cref="QuantityInfo{TQuantity, TUnit}" /> is required for serialization or deserialization.
    /// </remarks>
    public JsonQuantityConverter()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="JsonQuantityConverter{TQuantity,TUnit}" /> class
    ///     with the specified <see cref="QuantityInfo{TQuantity, TUnit}" />.
    /// </summary>
    /// <param name="quantityInfo">
    ///     The <see cref="QuantityInfo{TQuantity, TUnit}" /> instance that provides metadata and configuration
    ///     for the quantity type <typeparamref name="TQuantity" /> and its associated unit type <typeparamref name="TUnit" />.
    /// </param>
    public JsonQuantityConverter(QuantityInfo<TQuantity, TUnit> quantityInfo)
        : base(quantityInfo)
    {
    }

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
    /// <remarks>
    ///     This method is virtual, allowing derived classes to customize how the value property is read.
    /// </remarks>
    /// <exception cref="JsonException">
    ///     Thrown if the JSON data is invalid or cannot be deserialized into a <see cref="QuantityValue" />.
    /// </exception>
    protected override QuantityValue ReadValueProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        QuantityValue value = JsonSerializer.Deserialize<QuantityValue>(ref reader, options);
        return value;
    }

    /// <summary>
    ///     Reads the unit property from the JSON input.
    /// </summary>
    /// <param name="reader">
    ///     The <see cref="Utf8JsonReader" /> used to read the JSON input.
    /// </param>
    /// <param name="options">
    ///     The <see cref="JsonSerializerOptions" /> that specify options for deserialization.
    /// </param>
    /// <returns>
    ///     The deserialized unit of type <typeparamref name="TUnit" />, or <c>null</c> if the unit could not be read.
    /// </returns>
    /// <exception cref="JsonException">
    ///     Thrown if the JSON input is invalid or does not contain a valid unit property.
    /// </exception>
    protected override TUnit? ReadUnitProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        TUnit? unit = JsonSerializer.Deserialize<TUnit>(ref reader, options);
        return unit;
    }

    /// <summary>
    ///     Writes the "Value" property of the quantity to the JSON output.
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
    protected override void WriteValueProperty(Utf8JsonWriter writer, TQuantity quantity, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, quantity.Value, options);
    }

    /// <summary>
    ///     Writes the unit property of the quantity to the JSON output.
    /// </summary>
    /// <param name="writer">
    ///     The <see cref="Utf8JsonWriter" /> used to write the JSON output.
    /// </param>
    /// <param name="quantity">
    ///     The quantity whose unit property is being written.
    /// </param>
    /// <param name="options">
    ///     The <see cref="JsonSerializerOptions" /> that specify options for JSON serialization.
    /// </param>
    /// <remarks>
    ///     This method writes the unit property name and its value to the JSON output.
    ///     The property name is determined by the <see cref="JsonSerializerOptions.PropertyNamingPolicy" /> if specified,
    ///     otherwise it defaults to the value of <c>UnitPropertyName</c>.
    /// </remarks>
    protected override void WriteUnitProperty(Utf8JsonWriter writer, TQuantity quantity, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, quantity.Unit, options);
    }
}

/// <summary>
///     Provides a factory for creating JSON converters that handle serialization and deserialization
///     of quantities and their associated units.
/// </summary>
/// <remarks>
///     This class leverages the <see cref="QuantityInfoLookup" /> to resolve quantity and unit information
///     during JSON serialization and deserialization.
///     <para>
///         In order to use this converter directly, you need to make sure that the <see cref="JsonSerializerOptions" />
///         contains a converter for both the <see cref="IQuantity{TUnitType}.Unit" /> and the
///         <see cref="IQuantity.Value" /> of the quantity.
///     </para>
/// </remarks>
#if NET
[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
#endif
public class JsonQuantityConverter : JsonConverterFactory
{
    private readonly QuantityInfoLookup _quantities;

    /// <summary>
    ///     Initializes a new instance of the <see cref="JsonQuantityConverter" /> class
    ///     with an option to specify case sensitivity.
    /// </summary>
    /// <remarks>
    ///     This constructor uses the default <see cref="QuantityInfoLookup" /> from <see cref="UnitsNetSetup.Default" />
    ///     to resolve unit names during JSON serialization and deserialization.
    /// </remarks>
    public JsonQuantityConverter()
        : this(UnitsNetSetup.Default.Quantities)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="JsonQuantityConverter" /> class with the specified
    ///     <see cref="QuantityInfoLookup" /> and case-sensitivity configuration.
    /// </summary>
    /// <param name="quantities">
    ///     The <see cref="QuantityInfoLookup" /> instance used to resolve quantity and unit information
    ///     during JSON serialization and deserialization.
    /// </param>
    /// <remarks>
    ///     This constructor allows customization of the <see cref="QuantityInfoLookup" /> used for parsing and
    ///     formatting unit names, enabling advanced scenarios where specific quantity and unit information is required.
    /// </remarks>
    public JsonQuantityConverter(QuantityInfoLookup quantities)
    {
        _quantities = quantities ?? throw new ArgumentNullException(nameof(quantities));
    }

    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        return TryGetQuantityInfo(typeToConvert, out _);
    }

    /// <inheritdoc />
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (!TryGetQuantityInfo(typeToConvert, out QuantityInfo? quantityInfo))
        {
            return null;
        }

        Type converterType = typeof(JsonQuantityConverter<,>).MakeGenericType(typeToConvert, quantityInfo.UnitType);
        return (JsonConverter?)Activator.CreateInstance(converterType, quantityInfo);
    }

    /// <summary>
    ///     Try to get the <see cref="QuantityInfo" /> for a given quantity type.
    /// </summary>
    protected bool TryGetQuantityInfo(Type typeToConvert, [NotNullWhen(true)] out QuantityInfo? quantityInfo)
    {
        return _quantities.TryGetQuantityInfo(typeToConvert, out quantityInfo);
    }
}
