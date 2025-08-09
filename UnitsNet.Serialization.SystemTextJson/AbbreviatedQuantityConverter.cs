// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using UnitsNet.Serialization.SystemTextJson.Unit;
using UnitsNet.Serialization.SystemTextJson.Value;

namespace UnitsNet.Serialization.SystemTextJson;

/// <inheritdoc />
#if NET
[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
#endif
public class AbbreviatedQuantityConverter : JsonQuantityConverter
{
    private readonly CultureInfo _culture;
    private readonly UnitParser _unitParser;
    private readonly JsonConverter<QuantityValue> _valueConverter;

    /// <inheritdoc />
    public AbbreviatedQuantityConverter()
        : this(QuantityValueFractionalNotationConverter.Default)
    {
    }

    /// <inheritdoc />
    public AbbreviatedQuantityConverter(JsonConverter<QuantityValue> valueConverter)
        : this(valueConverter, UnitParser.Default)
    {
    }

    /// <inheritdoc />
    public AbbreviatedQuantityConverter(JsonConverter<QuantityValue> valueConverter, UnitParser unitParser)
        : this(valueConverter, unitParser, CultureInfo.InvariantCulture)
    {
    }

    /// <inheritdoc />
    public AbbreviatedQuantityConverter(JsonConverter<QuantityValue> valueConverter, UnitParser unitParser, CultureInfo culture)
        : base(unitParser.Quantities)
    {
        _valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
        _unitParser = unitParser;
        _culture = culture ?? throw new ArgumentNullException(nameof(culture));
    }

    /// <inheritdoc />
    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (!TryGetQuantityInfo(typeToConvert, out QuantityInfo? quantityInfo))
        {
            return null;
        }

        Type converterType = typeof(AbbreviatedQuantityConverter<,>).MakeGenericType(typeToConvert, quantityInfo.UnitType);
        return (JsonConverter?)Activator.CreateInstance(converterType, quantityInfo, _valueConverter, _unitParser, _culture);
    }
}

/// <inheritdoc />
public class AbbreviatedQuantityConverter<TQuantity, TUnit> : JsonQuantityConverterBase<TQuantity, TUnit>
    where TQuantity : IQuantity<TQuantity, TUnit>
    where TUnit : struct, Enum
{
    private readonly JsonConverter<TUnit> _unitConverter;
    private readonly JsonConverter<QuantityValue> _valueConverter;

    /// <inheritdoc />
    public AbbreviatedQuantityConverter()
        // TODO what should be the default
        : this(QuantityValueFractionalNotationConverter.Default)
    {
    }

#if NET
    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedQuantityConverter{TQuantity, TUnit}" /> class
    ///     with the specified JSON converter for <see cref="QuantityValue" />.
    /// </summary>
    /// <param name="valueConverter">
    ///     The JSON converter used to handle serialization and deserialization of <see cref="QuantityValue" />.
    /// </param>
    /// <remarks>
    ///     This constructor allows customization of the <see cref="QuantityValue" /> conversion logic
    ///     by providing a specific <see cref="JsonConverter{T}" /> implementation.
    /// </remarks>
    public AbbreviatedQuantityConverter(JsonConverter<QuantityValue> valueConverter)
        // : this((QuantityInfo<TQuantity, TUnit>)UnitsNetSetup.Default.QuantityInfoLookup.GetQuantityInfo(typeof(TQuantity)), valueConverter)
        // TODO see if we want to expose the QuantityInfo (a.k.a. the static "Info" property) on the IQuantity<TQuantity, TUnit> interface
        : this(TQuantity.From(QuantityValue.Zero, default).QuantityInfo, valueConverter)
    {
    }
#else
    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedQuantityConverter{TQuantity, TUnit}" /> class
    ///     with a specified JSON converter for <see cref="QuantityValue" />.
    /// </summary>
    /// <param name="valueConverter">
    ///     The <see cref="JsonConverter{T}" /> used to convert <see cref="QuantityValue" /> instances during serialization and
    ///     deserialization.
    /// </param>
    public AbbreviatedQuantityConverter(JsonConverter<QuantityValue> valueConverter)
        : this((QuantityInfo<TQuantity, TUnit>)UnitsNetSetup.Default.Quantities.GetQuantityInfo(typeof(TQuantity)), valueConverter)
    {
    }
#endif

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedQuantityConverter{TQuantity, TUnit}" /> class.
    /// </summary>
    /// <param name="quantityInfo">
    ///     The <see cref="QuantityInfo{TQuantity, TUnit}" /> containing metadata about the quantity type and its units.
    /// </param>
    /// <param name="valueConverter">
    ///     The <see cref="JsonConverter{T}" /> used to convert the quantity value.
    /// </param>
    /// <remarks>
    ///     This constructor allows specifying the quantity information and a custom value converter for serialization and
    ///     deserialization.
    /// </remarks>
    public AbbreviatedQuantityConverter(QuantityInfo<TQuantity, TUnit> quantityInfo, JsonConverter<QuantityValue> valueConverter)
        : this(quantityInfo, valueConverter, UnitParser.Default)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedQuantityConverter{TQuantity, TUnit}" /> class
    ///     with the specified quantity information, value converter, unit parser, and culture settings.
    /// </summary>
    /// <param name="quantityInfo">
    ///     The <see cref="QuantityInfo{TQuantity, TUnit}" /> containing metadata about the quantity type and its units.
    /// </param>
    /// <param name="valueConverter">
    ///     The <see cref="JsonConverter{T}" /> used to serialize and deserialize the quantity value.
    /// </param>
    /// <param name="unitParser">
    ///     The <see cref="UnitParser" /> used to parse unit abbreviations.
    /// </param>
    public AbbreviatedQuantityConverter(QuantityInfo<TQuantity, TUnit> quantityInfo, JsonConverter<QuantityValue> valueConverter, UnitParser unitParser)
        : this(quantityInfo, valueConverter, unitParser, CultureInfo.InvariantCulture)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedQuantityConverter{TQuantity, TUnit}" /> class.
    /// </summary>
    /// <param name="quantityInfo">
    ///     The <see cref="QuantityInfo{TQuantity, TUnit}" /> containing metadata about the quantity type and its units.
    /// </param>
    /// <param name="valueConverter">
    ///     The <see cref="JsonConverter{T}" /> used to serialize and deserialize the quantity value.
    /// </param>
    /// <param name="unitParser">
    ///     The <see cref="UnitParser" /> used to parse unit abbreviations.
    /// </param>
    /// <param name="culture">
    ///     The <see cref="CultureInfo" /> used for culture-specific formatting and parsing.
    /// </param>
    public AbbreviatedQuantityConverter(QuantityInfo<TQuantity, TUnit> quantityInfo, JsonConverter<QuantityValue> valueConverter, UnitParser unitParser,
        CultureInfo culture)
        : this(quantityInfo, valueConverter, new AbbreviatedUnitConverter<TUnit>(unitParser, culture))
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedQuantityConverter{TQuantity, TUnit}" /> class.
    /// </summary>
    /// <param name="quantityInfo">The quantity information used for serialization and deserialization.</param>
    /// <param name="valueConverter">The JSON converter for handling <see cref="QuantityValue" /> instances.</param>
    /// <param name="unitConverter">The JSON converter for handling unit types of <typeparamref name="TUnit" />.</param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="valueConverter" /> or <paramref name="unitConverter" /> is <c>null</c>.
    /// </exception>
    public AbbreviatedQuantityConverter(QuantityInfo<TQuantity, TUnit> quantityInfo, JsonConverter<QuantityValue> valueConverter,
        JsonConverter<TUnit> unitConverter)
        : base(quantityInfo)
    {
        _valueConverter = valueConverter ?? throw new ArgumentNullException(nameof(valueConverter));
        _unitConverter = unitConverter ?? throw new ArgumentNullException(nameof(unitConverter));
    }

    /// <inheritdoc />
    protected override TUnit? ReadUnitProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        return _unitConverter.Read(ref reader, typeof(TUnit), options);
    }

    /// <inheritdoc />
    protected override QuantityValue ReadValueProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        return _valueConverter.Read(ref reader, typeof(QuantityValue), options);
    }

    /// <inheritdoc />
    protected override void WriteUnitProperty(Utf8JsonWriter writer, TQuantity quantity, JsonSerializerOptions options)
    {
        _unitConverter.Write(writer, quantity.Unit, options);
    }

    /// <inheritdoc />
    protected override void WriteValueProperty(Utf8JsonWriter writer, TQuantity quantity, JsonSerializerOptions options)
    {
        _valueConverter.Write(writer, quantity.Value, options);
    }
}
