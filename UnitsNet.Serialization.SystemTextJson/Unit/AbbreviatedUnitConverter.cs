// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
#if NET
using System.Diagnostics.CodeAnalysis;
#endif

namespace UnitsNet.Serialization.SystemTextJson.Unit;

/// <summary>
///     Converter to convert unit-enums to and from abbreviated strings.
/// </summary>
/// <remarks>
///     Reading is case-insensitive, with case-sensitive disambiguation.
/// </remarks>
#if NET
[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
[RequiresUnreferencedCode(
    "If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
#endif
public class AbbreviatedUnitConverter : JsonConverterFactory
{
    private readonly UnitParser _unitParser;
    private readonly CultureInfo _culture = CultureInfo.InvariantCulture;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedUnitConverter" /> class
    ///     using the default <see cref="UnitParser" />.
    /// </summary>
    /// <remarks>
    ///     This constructor sets up the converter to use the default <see cref="UnitParser" />
    ///     for resolving unit abbreviations during JSON serialization and deserialization.
    /// </remarks>
    public AbbreviatedUnitConverter()
        : this(UnitParser.Default)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedUnitConverter" /> class with the specified unit parser.
    /// </summary>
    /// <param name="unitParser">
    ///     The <see cref="UnitParser" /> used for deserializing an abbreviation back into its
    ///     corresponding unit.
    /// </param>
    /// <remarks>
    ///     This constructor sets up the converter to utilize the provided <see cref="UnitParser" />
    ///     for managing unit abbreviations and parsing during JSON operations.
    /// </remarks>
    public AbbreviatedUnitConverter(UnitParser unitParser)
    {
        _unitParser = unitParser ?? throw new ArgumentNullException(nameof(unitParser));
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedUnitConverter" /> class with the specified unit parser and culture.
    /// </summary>
    /// <param name="unitParser">
    ///     The <see cref="UnitParser" /> used for deserializing an abbreviation back into its
    ///     corresponding unit.
    /// </param>
    /// <param name="culture">The <see cref="CultureInfo" /> used for parsing and formatting unit abbreviations.</param>
    /// <remarks>
    ///     This constructor allows customization of both the unit abbreviations cache and the culture used for parsing and
    ///     formatting unit abbreviations.
    /// </remarks>
    public AbbreviatedUnitConverter(UnitParser unitParser, CultureInfo culture)
    {
        _unitParser = unitParser ?? throw new ArgumentNullException(nameof(unitParser));
        _culture = culture ?? throw new ArgumentNullException(nameof(culture));
    }

    /// <inheritdoc />
    public sealed override bool CanConvert(Type typeToConvert)
    {
        return _unitParser.Quantities.TryGetQuantityByUnitType(typeToConvert, out _);
    }

    /// <inheritdoc />
    public sealed override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        // QuantityInfo quantityInfo = _unitParser.Quantities.GetQuantityByUnitType(typeToConvert);
        Type converterType = typeof(AbbreviatedUnitConverter<>).MakeGenericType(typeToConvert);
        return (JsonConverter?)Activator.CreateInstance(converterType, _unitParser, _culture);
    }
}

/// <summary>
///     Converter to convert unit-enums to and from abbreviated strings.
/// </summary>
/// <remarks>
///     Reading is case-insensitive, with case-sensitive disambiguation.
/// </remarks>
public class AbbreviatedUnitConverter<TUnit> : JsonConverter<TUnit> where TUnit : struct, Enum
{
    private readonly UnitParser _unitParser;
    private readonly CultureInfo _culture = CultureInfo.InvariantCulture;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedUnitConverter" /> class
    ///     using the default <see cref="UnitParser" />.
    /// </summary>
    /// <remarks>
    ///     This constructor sets up the converter to use the default <see cref="UnitParser" />
    ///     for resolving unit abbreviations during JSON serialization and deserialization.
    /// </remarks>
    public AbbreviatedUnitConverter()
        : this(UnitParser.Default)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedUnitConverter" /> class with the specified unit parser.
    /// </summary>
    /// <param name="unitParser">
    ///     The <see cref="UnitParser" /> used for deserializing an abbreviation back into its
    ///     corresponding unit.
    /// </param>
    /// <remarks>
    ///     This constructor sets up the converter to utilize the provided <see cref="UnitParser" />
    ///     for managing unit abbreviations and parsing during JSON operations.
    /// </remarks>
    public AbbreviatedUnitConverter(UnitParser unitParser)
    {
        _unitParser = unitParser ?? throw new ArgumentNullException(nameof(unitParser));
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedUnitConverter" /> class with the specified unit parser and culture.
    /// </summary>
    /// <param name="unitParser">
    ///     The <see cref="UnitParser" /> used for deserializing an abbreviation back into its
    ///     corresponding unit.
    /// </param>
    /// <param name="culture">The <see cref="CultureInfo" /> used for parsing and formatting unit abbreviations.</param>
    /// <remarks>
    ///     This constructor allows customization of both the unit abbreviations cache and the culture used for parsing and
    ///     formatting unit abbreviations.
    /// </remarks>
    public AbbreviatedUnitConverter(UnitParser unitParser, CultureInfo culture)
    {
        _unitParser = unitParser ?? throw new ArgumentNullException(nameof(unitParser));
        _culture = culture ?? throw new ArgumentNullException(nameof(culture));
    }

    /// <inheritdoc />
    public override TUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return _unitParser.Parse<TUnit>(reader.GetString()!, _culture);
    }

    /// <inheritdoc />
    public override TUnit ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Read(ref reader, typeToConvert, options);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, TUnit value, JsonSerializerOptions options)
    {
        var abbreviation = _unitParser.Abbreviations.GetDefaultAbbreviation(value, _culture);
        writer.WriteStringValue(abbreviation);
    }

    /// <inheritdoc />
    public override void WriteAsPropertyName(Utf8JsonWriter writer, TUnit value, JsonSerializerOptions options)
    {
        writer.WritePropertyName(_unitParser.Abbreviations.GetDefaultAbbreviation(value, _culture));
    }
}
