// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text.Json;
using System.Text.Json.Serialization;
#if NET
using System.Text;
using System.Diagnostics.CodeAnalysis;
#endif

namespace UnitsNet.Serialization.SystemTextJson.Unit;

/// <summary>
///     Provides functionality for converting units of a specific type to and from their string representations
///     in JSON serialization and deserialization processes.
/// </summary>
/// <remarks>
///     This converter uses the <see cref="UnitInfo.Name" /> corresponding to the given unit in the provided
///     <see cref="QuantityInfoLookup" />.
///     <para>It supports case-sensitive or case-insensitive comparisons based on the specified configuration.</para>
/// </remarks>
/// <seealso cref="System.Text.Json.Serialization.JsonConverter{T}" />
/// <seealso cref="System.Text.Json.Serialization.JsonConverterFactory" />
#if NET
[RequiresDynamicCode("The native code for this instantiation might not be available at runtime.")]
[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
#endif
public class UnitTypeAndNameConverter : JsonConverterFactory
{
    private readonly bool _ignoreCase;
    private readonly QuantityInfoLookup _quantities;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitTypeAndNameConverter" /> class with case-sensitive unit matching.
    /// </summary>
    /// <remarks>
    ///     This constructor uses the default <see cref="QuantityInfoLookup" /> from <see cref="UnitsNetSetup.Default" />
    ///     to resolve unit names during JSON serialization and deserialization.
    /// </remarks>
    public UnitTypeAndNameConverter()
        : this(UnitsNetSetup.Default.Quantities)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitTypeAndNameConverter" /> class
    ///     with an option to specify case sensitivity.
    /// </summary>
    /// <remarks>
    ///     This constructor uses the default <see cref="QuantityInfoLookup" /> from <see cref="UnitsNetSetup.Default" />
    ///     to resolve unit names during JSON serialization and deserialization.
    /// </remarks>
    public UnitTypeAndNameConverter(bool ignoreCase)
        : this(UnitsNetSetup.Default.Quantities, ignoreCase)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitTypeAndNameConverter" /> class with the specified
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
    public UnitTypeAndNameConverter(QuantityInfoLookup quantities, bool ignoreCase = false)
    {
        _quantities = quantities;
        _ignoreCase = ignoreCase;
    }

    /// <inheritdoc />
    public sealed override bool CanConvert(Type typeToConvert)
    {
        return _quantities.TryGetQuantityByUnitType(typeToConvert, out _);
    }

    /// <inheritdoc />
    public sealed override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        QuantityInfo quantityInfo = _quantities.GetQuantityByUnitType(typeToConvert);
        Type converterType = typeof(UnitTypeAndNameConverter<>).MakeGenericType(typeToConvert);
        return (JsonConverter?)Activator.CreateInstance(converterType, quantityInfo, _ignoreCase);
    }
}

/// <summary>
///     Provides functionality for converting units of a specific type to and from their string representations
///     in JSON serialization and deserialization processes.
/// </summary>
/// <typeparam name="TUnit">
///     The type of the unit being converted, which must be a struct and an enumeration.
/// </typeparam>
/// <remarks>
///     This converter uses the <see cref="UnitInfo.Name" /> corresponding to the given unit in the
///     provided <see cref="QuantityInfo{TUnit}" />.
///     <para>It supports case-sensitive or case-insensitive comparisons based on the specified configuration.</para>
/// </remarks>
/// <seealso cref="System.Text.Json.Serialization.JsonConverter{T}" />
/// <seealso cref="System.Text.Json.Serialization.JsonConverterFactory" />
public class UnitTypeAndNameConverter<TUnit> : JsonConverter<TUnit> where TUnit : struct, Enum
{
    private const int StackAllocThreshold = 512;
    
    private readonly bool _ignoreCase;
    private readonly QuantityInfo<TUnit> _quantityInfo;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitTypeAndNameConverter{TUnit}" /> class with the specified
    ///     quantity information and an option to configure case sensitivity for unit name comparisons.
    /// </summary>
    /// <param name="quantityInfo">
    ///     The quantity information that provides metadata about the unit type, including unit abbreviations and the base
    ///     unit.
    /// </param>
    /// <param name="ignoreCase">
    ///     A boolean value indicating whether the unit name comparison should ignore case during JSON serialization and
    ///     deserialization.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="quantityInfo" /> is <c>null</c>.
    /// </exception>
    public UnitTypeAndNameConverter(QuantityInfo<TUnit> quantityInfo, bool ignoreCase = false)
    {
        _quantityInfo = quantityInfo ?? throw new ArgumentNullException(nameof(quantityInfo));
        _ignoreCase = ignoreCase;
    }

    /// <inheritdoc />
    public override TUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var nbBytes = reader.HasValueSequence ? checked((int)reader.ValueSequence.Length) : reader.ValueSpan.Length;
        Span<char> charBuffer = nbBytes <= StackAllocThreshold ? stackalloc char[nbBytes] : new char[nbBytes];
        var charsWritten = reader.CopyString(charBuffer);
        ReadOnlySpan<char> unitSpan = charBuffer.Slice(0, charsWritten);
        if (!unitSpan.TrySplit('.', out _, out ReadOnlySpan<char> unitName))
        {
#if NET
            throw new JsonException($"Invalid unit format: \"{unitSpan}\"");
#else
            throw new JsonException($"Invalid unit format: \"{unitSpan.ToString()}\"");
#endif
        }

        IReadOnlyList<UnitInfo<TUnit>> unitInfos = _quantityInfo.UnitInfos;
        var nbUnits = unitInfos.Count;
        if (_ignoreCase)
        {
            for (var i = 0; i < nbUnits; i++)
            {
                UnitInfo<TUnit> unitInfo = unitInfos[i];
                if (unitName.Equals(unitInfo.Name.AsSpan(), StringComparison.OrdinalIgnoreCase))
                {
                    return unitInfo.Value;
                }
            }
        }
        else
        {
            // TODO see if we want to also validate the first part of the format
            for (var i = 0; i < nbUnits; i++)
            {
                UnitInfo<TUnit> unitInfo = unitInfos[i];
                if (unitName.SequenceEqual(unitInfo.Name.AsSpan()))
                {
                    return unitInfo.Value;
                }
            }
        }

        var unitNamePart = unitName.ToString();
        throw new UnitNotFoundException($"No unit was found for quantity '{_quantityInfo.Name}' with the name: '{unitNamePart}'.")
        {
            Data = { ["quantityName"] = _quantityInfo.Name, ["unitName"] = unitNamePart }
        };
    }

    /// <inheritdoc />
    public override TUnit ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Read(ref reader, typeToConvert, options);
    }
    
    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, TUnit value, JsonSerializerOptions options)
    {
        writer.WriteStringValues(typeof(TUnit).Name.AsSpan(), '.', _quantityInfo[value].Name.AsSpan());
    }

    /// <inheritdoc />
    public override void WriteAsPropertyName(Utf8JsonWriter writer, TUnit value, JsonSerializerOptions options)
    {
        writer.WriteValuesAsPropertyName(typeof(TUnit).Name.AsSpan(), '.', _quantityInfo[value].Name.AsSpan());
    }
}
