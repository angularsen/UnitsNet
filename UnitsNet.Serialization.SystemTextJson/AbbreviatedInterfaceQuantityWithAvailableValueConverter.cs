// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
#if NET
using System.Diagnostics.CodeAnalysis;
#endif

namespace UnitsNet.Serialization.SystemTextJson;

/// <summary>
///     Provides a custom JSON converter for <see cref="UnitsNet.IQuantity" />.
///     This converter handles serialization and deserialization of quantities,
///     ensuring that <see cref="UnitsNet.IQuantity" /> objects are correctly
///     represented in JSON format.
/// </summary>
public abstract class AbbreviatedInterfaceQuantityConverterBase : InterfaceQuantityConverterBase<string?>
{
    private readonly CultureInfo _culture = CultureInfo.InvariantCulture;
    private readonly UnitParser _unitParser;

    /// <summary>
    ///     Initializes a new instance of the converter using the default  <see cref="UnitParser" />.
    /// </summary>
    protected AbbreviatedInterfaceQuantityConverterBase()
        : this(UnitParser.Default)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the converter using the provided <see cref="UnitParser" />.
    /// </summary>
    /// <param name="unitParser">
    ///     The <see cref="UnitParser" /> used for deserializing an abbreviation back into its
    ///     corresponding unit.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the <paramref name="unitParser" /> parameter is <c>null</c>.
    /// </exception>
    protected AbbreviatedInterfaceQuantityConverterBase(UnitParser unitParser)
    {
        _unitParser = unitParser ?? throw new ArgumentNullException(nameof(unitParser));
    }

    /// <summary>
    ///     Initializes a new instance of the converter using the provided <see cref="UnitParser" />.
    /// </summary>
    /// <param name="unitParser">
    ///     The <see cref="UnitParser" /> used for deserializing an abbreviation back into its
    ///     corresponding unit.
    /// </param>
    /// <param name="culture">The primary culture that is used for the unit abbreviations.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the <paramref name="unitParser" /> parameter is <c>null</c>.
    /// </exception>
    protected AbbreviatedInterfaceQuantityConverterBase(UnitParser unitParser, CultureInfo culture)
    {
        _unitParser = unitParser ?? throw new ArgumentNullException(nameof(unitParser));
        _culture = culture ?? throw new ArgumentNullException(nameof(culture));
    }

    /// <inheritdoc />
    protected override void WriteUnitProperty(Utf8JsonWriter writer, IQuantity quantity, JsonSerializerOptions options)
    {
        writer.WriteStringValue(_unitParser.Abbreviations.GetDefaultAbbreviation(quantity.UnitKey, _culture));
    }

    /// <inheritdoc />
    protected override string? ReadUnitProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        return reader.GetString();
    }

    /// <inheritdoc />
    protected override IQuantity CreateQuantity(QuantityValue value, string? unitAbbreviation, string? quantityName)
    {
        UnitInfo unitInfo;
        if (quantityName != null && unitAbbreviation != null)
        {
            unitInfo = _unitParser.GetUnitFromAbbreviation(quantityName, unitAbbreviation, _culture);
        }
        else if (unitAbbreviation != null)
        {
            unitInfo = _unitParser.GetUnitFromAbbreviation(unitAbbreviation, _culture);
        }
        else if (quantityName != null)
        {
            unitInfo = _unitParser.Quantities.GetQuantityByName(quantityName).BaseUnitInfo;
        }
        else
        {
            throw new JsonException("Both the quantity name and unit abbreviation are missing from the JSON.");
        }

        return unitInfo.From(value);
    }
}

/// <summary>
///     Provides a specialized JSON converter for <see cref="UnitsNet.IQuantity" /> that utilizes a custom
///     <see cref="System.Text.Json.Serialization.JsonConverter{T}" /> for handling the value property of quantities.
///     This class extends the functionality of <see cref="AbbreviatedInterfaceQuantityWithAvailableValueConverter" /> by
///     enabling
///     the use of a specific value converter for serialization and deserialization of the quantity's value.
/// </summary>
public class AbbreviatedInterfaceQuantityWithValueConverter : AbbreviatedInterfaceQuantityConverterBase
{
    private readonly JsonConverter<QuantityValue> _valueConverter;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedInterfaceQuantityWithValueConverter" /> class
    ///     with the specified value converter for handling the <see cref="QuantityValue" /> property of quantities.
    /// </summary>
    /// <param name="valueConverter">
    ///     The <see cref="JsonConverter{T}" /> to be used for serializing and deserializing the <see cref="QuantityValue" />
    ///     property.
    /// </param>
    public AbbreviatedInterfaceQuantityWithValueConverter(JsonConverter<QuantityValue> valueConverter)
        : this(valueConverter, UnitParser.Default)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="AbbreviatedInterfaceQuantityWithValueConverter" /> class
    ///     with the specified value converter and unit parser.
    /// </summary>
    /// <param name="valueConverter">
    ///     The <see cref="System.Text.Json.Serialization.JsonConverter{T}" /> used to handle the serialization and
    ///     deserialization of the value property of quantities.
    /// </param>
    /// <param name="unitParser">
    ///     The <see cref="UnitsNet.UnitParser" /> used to parse and interpret unit abbreviations.
    /// </param>
    /// <exception cref="System.ArgumentNullException">
    ///     Thrown when <paramref name="valueConverter" /> is <c>null</c>.
    /// </exception>
    public AbbreviatedInterfaceQuantityWithValueConverter(JsonConverter<QuantityValue> valueConverter, UnitParser unitParser)
        : base(unitParser)
    {
        _valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
    }

    /// <inheritdoc />
    protected override QuantityValue ReadValueProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        return _valueConverter.Read(ref reader, typeof(QuantityValue), options);
    }

    /// <inheritdoc />
    protected override void WriteValueProperty(Utf8JsonWriter writer, IQuantity quantity, JsonSerializerOptions options)
    {
        _valueConverter.Write(writer, quantity.Value, options);
    }
}

/// <summary>
///     Provides a custom JSON converter for <see cref="UnitsNet.IQuantity" />.
///     This converter handles serialization and deserialization of quantities,
///     ensuring that <see cref="UnitsNet.IQuantity" /> objects are correctly
///     represented in JSON format.
/// </summary>
#if NET
[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
[RequiresUnreferencedCode(
    "If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
#endif
public class AbbreviatedInterfaceQuantityWithAvailableValueConverter : AbbreviatedInterfaceQuantityConverterBase
{
    /// <inheritdoc />
    public AbbreviatedInterfaceQuantityWithAvailableValueConverter()
    {
    }

    /// <inheritdoc />
    public AbbreviatedInterfaceQuantityWithAvailableValueConverter(UnitParser unitParser)
        : base(unitParser)
    {
    }

    /// <inheritdoc />
    public AbbreviatedInterfaceQuantityWithAvailableValueConverter(UnitParser unitParser, CultureInfo culture)
        : base(unitParser, culture)
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
        return JsonSerializer.Deserialize<QuantityValue>(ref reader, options);
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
    protected override void WriteValueProperty(Utf8JsonWriter writer, IQuantity quantity, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, quantity.Value, options);
    }
}
