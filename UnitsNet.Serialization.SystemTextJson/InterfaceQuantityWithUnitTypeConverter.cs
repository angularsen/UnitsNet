// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using System.Text.Json.Serialization;
#if NET
using System.Collections.Frozen;
using System.Text;
using System.Diagnostics.CodeAnalysis;
#endif

namespace UnitsNet.Serialization.SystemTextJson;

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
public class InterfaceQuantityWithUnitTypeConverter : JsonConverter<IQuantity>
{
    private readonly bool _ignoreCase;
#if NET
    private readonly FrozenDictionary<string, QuantityInfo> _quantities;
#else
    private readonly Dictionary<string, QuantityInfo> _quantities;
#endif

    /// <summary>
    ///     Initializes a new instance of the <see cref="AbbreviatedInterfaceQuantityWithAvailableValueConverter" /> class with case-sensitive
    ///     unit matching.
    /// </summary>
    /// <remarks>
    ///     This constructor uses the default <see cref="QuantityInfoLookup" /> from <see cref="UnitsNetSetup.Default" />
    ///     to resolve unit names during JSON serialization and deserialization.
    /// </remarks>
    public InterfaceQuantityWithUnitTypeConverter()
        : this(UnitsNetSetup.Default.QuantityInfoLookup)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="InterfaceQuantityWithUnitTypeConverter" /> class
    ///     with an option to specify case sensitivity.
    /// </summary>
    /// <remarks>
    ///     This constructor uses the default <see cref="QuantityInfoLookup" /> from <see cref="UnitsNetSetup.Default" />
    ///     to resolve unit names during JSON serialization and deserialization.
    /// </remarks>
    public InterfaceQuantityWithUnitTypeConverter(bool ignoreCase)
        : this(UnitsNetSetup.Default.QuantityInfoLookup, ignoreCase)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="InterfaceQuantityWithUnitTypeConverter" /> class with the specified
    ///     <see cref="QuantityInfoLookup" />  and an option to specify case sensitivity.
    /// </summary>
    /// <param name="quantities">
    ///     The <see cref="QuantityInfoLookup" /> instance used to resolve quantity and unit information
    ///     during JSON serialization and deserialization.
    /// </param>
    /// <param name="ignoreCase">
    ///     A boolean value indicating whether the unit name comparison should ignore case during JSON serialization and
    ///     deserialization.
    /// </param>
    /// <remarks>
    ///     This constructor allows customization of the <see cref="QuantityInfoLookup" /> used for parsing and
    ///     formatting unit names, enabling advanced scenarios where specific quantity and unit information is required.
    /// </remarks>
    public InterfaceQuantityWithUnitTypeConverter(QuantityInfoLookup quantities, bool ignoreCase = false)
    {
        StringComparer comparer = ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal;
#if NET
        _quantities = quantities.Infos.ToFrozenDictionary(info => info.UnitType.Name, comparer);
#else
        _quantities = quantities.Infos.ToDictionary(info => info.UnitType.Name, comparer);
#endif
        _ignoreCase = ignoreCase;
    }

    /// <inheritdoc />
    public override IQuantity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        QuantityValue value = QuantityValue.Zero;
        UnitInfo? unitInfo = null;
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
                    unitInfo = ReadUnitInfoProperty(ref reader);
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
                    unitInfo = ReadUnitInfoProperty(ref reader);
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

        if (unitInfo == null)
        {
            throw new JsonException($"The {unitProperty} property is missing from the JSON");
        }

        return unitInfo.From(value);
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
#if NET
    [RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
    [RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
#endif
    protected virtual QuantityValue ReadValueProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<QuantityValue>(ref reader, options);
    }

    private UnitInfo ReadUnitInfoProperty(ref Utf8JsonReader reader)
    {
#if NET
        var charCount = Encoding.UTF8.GetCharCount(reader.ValueSpan);
        if (charCount == 0)
        {
            throw new JsonException("Missing unit");
        }

        Span<char> charBuffer = charCount <= 256 ? stackalloc char[charCount] : new char[charCount];
        Encoding.UTF8.GetChars(reader.ValueSpan, charBuffer);
        ReadOnlySpan<char> unitSpan = charBuffer;
        if (!unitSpan.TrySplit('.', out ReadOnlySpan<char> unitTypeNameSpan, out ReadOnlySpan<char> unitNameSpan))
        {
            throw new JsonException($"Invalid unit format: \"{unitSpan}\"");
        }
#else
        var unitString = reader.GetString(); // TODO see about using a span here
        if (string.IsNullOrEmpty(unitString))
        {
            throw new JsonException("Missing unit");
        }

        ReadOnlySpan<char> unitSpan = unitString.AsSpan();
        if (!unitSpan.TrySplit('.', out ReadOnlySpan<char> unitTypeNameSpan, out ReadOnlySpan<char> unitNameSpan))
        {
            throw new JsonException($"Invalid unit format: \"{unitString}\"");
        }
#endif

        var unitTypeName = unitTypeNameSpan.ToString();
        if (!_quantities.TryGetValue(unitTypeName, out QuantityInfo? quantityInfo))
        {
            throw new QuantityNotFoundException($"No quantity in the current configuration contains a unit with the specified type name: '{unitTypeName}'");
        }

        IReadOnlyList<UnitInfo> unitInfos = quantityInfo.UnitInfos;
        var nbUnits = unitInfos.Count;
        if (_ignoreCase)
        {
            for (var i = 0; i < nbUnits; i++)
            {
                UnitInfo unitInfo = unitInfos[i];
                if (unitNameSpan.Equals(unitInfo.Name.AsSpan(), StringComparison.OrdinalIgnoreCase))
                {
                    return unitInfo;
                }
            }
        }
        else
        {
            for (var i = 0; i < nbUnits; i++)
            {
                UnitInfo unitInfo = unitInfos[i];
                if (unitNameSpan.SequenceEqual(unitInfo.Name.AsSpan()))
                {
                    return unitInfo;
                }
            }
        }

        var unitNamePart = unitNameSpan.ToString();
        throw new UnitNotFoundException($"No unit was found for quantity '{quantityInfo.Name}' with the name: '{unitNamePart}'.")
        {
            Data = { ["quantityName"] = quantityInfo.Name, ["unitName"] = unitNamePart }
        };
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
    protected virtual void WriteValueProperty(Utf8JsonWriter writer, IQuantity quantity, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, quantity.Value, options);
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, IQuantity quantity, JsonSerializerOptions options)
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

        if (options.DefaultIgnoreCondition != JsonIgnoreCondition.WhenWritingDefault || !QuantityValue.IsZero(quantity.Value))
        {
            // write the Value property (with the default converter)
            writer.WritePropertyName(valueProperty);
            WriteValueProperty(writer, quantity, options);
        }

        QuantityInfo quantityInfo = quantity.QuantityInfo;
        var unitFormat = $"{quantityInfo.UnitType.Name}.{quantityInfo[quantity.UnitKey].Name}";
        writer.WriteString(unitProperty, unitFormat);

        writer.WriteEndObject();
    }
}
