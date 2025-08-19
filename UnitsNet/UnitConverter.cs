// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using UnitsNet.InternalHelpers;

#if NET
using System.Collections.Frozen;
#endif

namespace UnitsNet;

/// <summary>
///     Convert between units of a quantity, such as converting from meters to centimeters of a given length.
/// </summary>
public class UnitConverter
{
    #if NET
    private readonly FrozenSet<QuantityConversion> _quantityConversions;
    #else
    private readonly HashSet<QuantityConversion> _quantityConversions;
    #endif

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitConverter" /> class with the specified
    ///     <see cref="UnitParser" />.
    /// </summary>
    /// <param name="unitParser">The <see cref="UnitParser" /> used for parsing units.</param>
    public UnitConverter(UnitParser unitParser)
        : this(unitParser, unitParser.Quantities.GetQuantityConversions(Quantity.DefaultProvider.Conversions))
    {
        UnitParser = unitParser;
    }

    internal UnitConverter(UnitParser unitParser, IEnumerable<QuantityConversion> quantityConversions)
    {
        UnitParser = unitParser;
#if NET
        _quantityConversions = quantityConversions.ToFrozenSet();
#else
        _quantityConversions = [..quantityConversions];
#endif
    }


    /// <summary>
    ///     Gets the <see cref="UnitParser" /> instance used to parse unit abbreviations.
    /// </summary>
    private UnitParser UnitParser { get; }

    /// <summary>
    ///     Gets the lookup for quantity information, which provides access to details about available quantities,
    ///     their associated units, and related metadata.
    /// </summary>
    /// <remarks>
    ///     It enables retrieval of unit and quantity information for conversion operations.
    /// </remarks>
    public QuantityInfoLookup Quantities
    {
        get => UnitParser.Quantities;
    }

    /// <summary>
    ///     Gets the default instance of the <see cref="UnitConverter" /> class.
    /// </summary>
    /// <value>
    ///     The default <see cref="UnitConverter" /> instance configured by <see cref="UnitsNetSetup.Default" />.
    /// </value>
    public static UnitConverter Default => UnitsNetSetup.Default.UnitConverter;

    /// <summary>
    ///     Creates a new instance of the <see cref="UnitConverter" /> class.
    /// </summary>
    /// <param name="unitParser">The parser used to interpret unit abbreviations and symbols.</param>
    /// <param name="options">
    ///     Options for building the quantity converter, including whether to freeze
    ///     the converter.
    /// </param>
    /// <returns>A new instance of <see cref="UnitConverter" /> configured according to the provided options.</returns>
    /// <remarks>
    ///     If <paramref name="options" /> specifies freezing, a <see cref="FrozenQuantityConverter" />
    ///     is created.
    ///     Otherwise, a <see cref="DynamicQuantityConverter" /> is created.
    /// </remarks>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when failing to create a conversion expression for one of the user-specified quantity-conversions.
    /// </exception>
    public static UnitConverter Create(UnitParser unitParser, QuantityConverterBuildOptions options)
    {
        if (options is { DefaultCachingMode: ConversionCachingMode.None, CustomQuantityOptions.Count: 0, QuantityConversionOptions: null, Freeze: true })
        {
            return new NoCachingConverter(unitParser); // this is just a sealed version of the default converter
        }

        QuantityInfoLookup quantityLookup = unitParser.Quantities;
        IEnumerable<KeyValuePair<UnitConversionKey, ConvertValueDelegate>> unitConversionFunctions =
            quantityLookup.Infos.GetUnitConversionFunctions(options.DefaultCachingMode, options.ReduceConstants, options.CustomQuantityOptions);

        var quantityConversions = new HashSet<QuantityConversion>(quantityLookup.GetQuantityConversions(Quantity.DefaultProvider.Conversions));

        IEnumerable<KeyValuePair<QuantityConversionKey, QuantityConversionFunction>> quantityConversionFunctions;
        if (options.QuantityConversionOptions is { } customConversionOptions)
        {
            Dictionary<QuantityConversion, QuantityConversionMappingOptions> conversionOptions = quantityLookup.GetQuantityConversionMappingOptions(customConversionOptions);
            quantityConversions.UnionWith(quantityLookup.GetQuantityConversions(customConversionOptions.CustomConversions).Concat(conversionOptions.Keys));
            quantityConversionFunctions = quantityConversions.GetConversionFunctions(conversionOptions, options.DefaultCachingMode, options.ReduceConstants, options.CustomQuantityOptions);
        }
        else
        {
            quantityConversionFunctions = quantityConversions.GetConversionFunctions(options.DefaultCachingMode, options.ReduceConstants, options.CustomQuantityOptions);
        }
        
        if (options.Freeze)
        {
            return new FrozenQuantityConverter(unitParser, quantityConversions, unitConversionFunctions, quantityConversionFunctions);
        }

        return new DynamicQuantityConverter(unitParser, quantityConversions, unitConversionFunctions, quantityConversionFunctions, options.ReduceConstants);
    }

    /// <summary>
    ///     Attempts to convert the specified quantity to the specified unit.
    /// </summary>
    /// <param name="quantity">The quantity to convert. Must not be null.</param>
    /// <param name="toUnitKey">The unit to convert the quantity to.</param>
    /// <param name="convertedQuantity">
    ///     When this method returns, contains the converted quantity if the conversion succeeded, or <c>null</c> if the
    ///     conversion failed.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the conversion succeeded; otherwise, <c>false</c>.
    /// </returns>
    public bool TryConvertTo<TQuantity>(TQuantity quantity, UnitKey toUnitKey, [NotNullWhen(true)] out IQuantity? convertedQuantity)
        where TQuantity : IQuantity
    {
        QuantityInfo quantityInfo = quantity.QuantityInfo;
        if (quantityInfo.UnitType == toUnitKey.UnitEnumType)
        {
            if (TryConvertValue(quantity.Value, quantity.UnitKey, toUnitKey, out QuantityValue convertedValue))
            {
                convertedQuantity = quantityInfo.From(convertedValue, toUnitKey);
                return true;
            }
        }
        else if (TryGetUnitInfo(quantity.UnitKey, out UnitInfo? fromUnitInfo) && TryGetUnitInfo(toUnitKey, out UnitInfo? toUnitInfo) &&
                 TryConvertValueInternal(quantity.Value, fromUnitInfo, toUnitInfo, out QuantityValue convertedValue))
        {
            convertedQuantity = toUnitInfo.From(convertedValue);
            return true;    
        }

        convertedQuantity = null;
        return false;
    }

    /// <summary>
    ///     Attempts to convert a quantity to a specified unit.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity.</typeparam>
    /// <typeparam name="TUnit">The type of the unit.</typeparam>
    /// <param name="quantity">The quantity to convert.</param>
    /// <param name="toUnit">The unit to convert to.</param>
    /// <param name="convertedQuantity">
    ///     When this method returns, contains the converted quantity if the conversion succeeded, or <c>null</c> if the
    ///     conversion failed.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the conversion succeeded; otherwise, <c>false</c>.
    /// </returns>
    public bool TryConvertToUnit<TQuantity, TUnit>(TQuantity quantity, TUnit toUnit, [NotNullWhen(true)] out TQuantity? convertedQuantity)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        if (TryConvertValue(quantity.Value, quantity.Unit, toUnit, out QuantityValue convertedValue))
        {
            convertedQuantity = quantity.QuantityInfo.From(convertedValue, toUnit);
            return true;
        }

        convertedQuantity = default;
        return false;
    }

    /// <summary>
    ///     Attempts to retrieve information about a specified unit.
    /// </summary>
    /// <param name="unit">The unit for which information is being requested.</param>
    /// <param name="unitInfo">
    ///     When this method returns, contains the unit information associated with the specified unit,
    ///     if the unit is found; otherwise, <c>null</c>. This parameter is passed uninitialized.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the unit information was found; otherwise, <c>false</c>.
    /// </returns>
    protected bool TryGetUnitInfo(UnitKey unit, [NotNullWhen(true)] out UnitInfo? unitInfo)
    {
        return Quantities.TryGetUnitInfo(unit, out unitInfo);
    }
    
    /// <summary>
    ///     Determines whether a conversion is defined between the specified source and target quantities.
    /// </summary>
    /// <param name="sourceQuantity">The source quantity information.</param>
    /// <param name="targetQuantity">The target quantity information.</param>
    /// <returns>
    ///     <c>true</c> if a conversion is defined between the source and target quantities; otherwise, <c>false</c>.
    /// </returns>
    protected bool ConversionDefined(QuantityInfo sourceQuantity, QuantityInfo targetQuantity)
    {
        return _quantityConversions.Contains(new QuantityConversion(sourceQuantity, targetQuantity));
    }

    /// <summary>
    ///     Gets the collection of quantity conversions available in this <see cref="UnitConverter" />.
    /// </summary>
    /// <remarks>
    ///     A quantity conversion defines the relationship between two quantities, enabling conversions
    ///     between them. This property provides access to all such conversions configured for this instance.
    /// </remarks>
    internal IReadOnlyCollection<QuantityConversion> QuantityConversions => _quantityConversions;

    /// <summary>
    ///     Attempts to convert the specified quantity to a different unit.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity to be converted.</typeparam>
    /// <typeparam name="TUnit">The type of the unit to convert to.</typeparam>
    /// <param name="quantity">The quantity to be converted.</param>
    /// <param name="toUnit">The unit to convert the quantity to.</param>
    /// <param name="convertedValue">
    ///     When this method returns, contains the converted value if the conversion succeeded; otherwise, the default value
    ///     for the type of the converted value.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the conversion succeeded; otherwise, <c>false</c>.
    /// </returns>
    public bool TryConvertValue<TQuantity, TUnit>(TQuantity quantity, TUnit toUnit, out QuantityValue convertedValue)
        where TQuantity : IQuantity<TUnit>
        where TUnit : struct, Enum
    {
        return TryConvertValue(quantity.Value, quantity.Unit, toUnit, out convertedValue);
    }

    /// <summary>
    ///     Attempts to convert a quantity value from one unit to another.
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit enumeration.</typeparam>
    /// <param name="value">The quantity value to be converted.</param>
    /// <param name="fromUnit">The unit of the quantity value to convert from.</param>
    /// <param name="toUnit">The unit of the quantity value to convert to.</param>
    /// <param name="convertedValue">
    ///     When this method returns, contains the converted quantity value if the conversion succeeded,
    ///     or <c>null</c> if the conversion failed. This parameter is passed uninitialized.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the conversion succeeded; otherwise, <c>false</c>.
    /// </returns>
    public virtual bool TryConvertValue<TUnit>(QuantityValue value, TUnit fromUnit, TUnit toUnit, out QuantityValue convertedValue)
        where TUnit : struct, Enum
    {
        var fromUnitKey = UnitKey.ForUnit(fromUnit);
        var toUnitKey = UnitKey.ForUnit(toUnit);
        if (fromUnitKey == toUnitKey)
        {
            convertedValue = value;
            return true;
        }
        
        if (TryGetUnitInfo(fromUnitKey, out UnitInfo? fromUnitInfo) && TryGetUnitInfo(toUnitKey, out UnitInfo? toUnitInfo))
        {
            convertedValue = toUnitInfo.GetValueFrom(value, fromUnitInfo);
            return true;
        }

        convertedValue = default;
        return false;
    }

    /// <summary>
    ///     Attempts to convert a quantity value from one unit to another.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <param name="fromUnitKey">The unit of the value to be converted from.</param>
    /// <param name="toUnitKey">The unit of the value to be converted to.</param>
    /// <param name="convertedValue">
    ///     When this method returns, contains the converted value if the conversion succeeded,
    ///     or <c>null</c> if the conversion failed. This parameter is passed uninitialized.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the conversion succeeded; otherwise, <c>false</c>.
    /// </returns>
    public virtual bool TryConvertValue(QuantityValue value, UnitKey fromUnitKey, UnitKey toUnitKey, out QuantityValue convertedValue)
    {
        if (fromUnitKey == toUnitKey)
        {
            convertedValue = value;
            return true;
        }
        
        if (TryGetUnitInfo(fromUnitKey, out UnitInfo? fromUnitInfo) && TryGetUnitInfo(toUnitKey, out UnitInfo? toUnitInfo))
        {
            return TryConvertValueInternal(value, fromUnitInfo, toUnitInfo, out convertedValue);
        }

        convertedValue = default;
        return false;
    }

    /// <summary>
    ///     Attempts to convert a quantity value from one unit to another.
    /// </summary>
    /// <param name="value">The quantity value to convert.</param>
    /// <param name="fromUnitInfo">The unit information of the source unit.</param>
    /// <param name="toUnitInfo">The unit information of the target unit.</param>
    /// <param name="convertedValue">
    ///     When this method returns, contains the converted quantity value if the conversion succeeded,
    ///     or <c>null</c> if the conversion failed. This parameter is passed uninitialized.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the conversion succeeded; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    ///     This method should succeed for any two units of the same quantity, but may fail if the units are from two
    ///     incompatible quantities.
    /// </remarks>
    protected virtual bool TryConvertValueInternal(QuantityValue value, UnitInfo fromUnitInfo, UnitInfo toUnitInfo, out QuantityValue convertedValue)
    {
        if (fromUnitInfo.QuantityInfo != toUnitInfo.QuantityInfo)
        {
            return TryConvertValueFromOneQuantityToAnother(value, fromUnitInfo, toUnitInfo, out convertedValue);
        }

        convertedValue = toUnitInfo.GetValueFrom(value, fromUnitInfo);
        return true;
    }

    /// <summary>
    ///     Attempts to convert a value from one quantity to another.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <param name="fromUnit">The unit of the value to be converted.</param>
    /// <param name="toUnit">The unit to which the value should be converted.</param>
    /// <param name="convertedValue">The converted value if the conversion is successful; otherwise, the default value.</param>
    /// <returns>
    ///     <c>true</c> if the conversion is successful; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    ///     This method handles conversions between quantities with matching or inverse base dimensions.
    /// </remarks>
    protected bool TryConvertValueFromOneQuantityToAnother(QuantityValue value, UnitInfo fromUnit, UnitInfo toUnit, out QuantityValue convertedValue)
    {
        QuantityInfo sourceQuantity = fromUnit.QuantityInfo;
        QuantityInfo targetQuantity = toUnit.QuantityInfo;
        if (!ConversionDefined(sourceQuantity, targetQuantity))
        {
            convertedValue = default;
            return false; 
        }
        
        ConvertValueDelegate conversionExpression;
        if (sourceQuantity.BaseDimensions.IsInverseOf(targetQuantity.BaseDimensions))
        {
            conversionExpression = QuantityValue.Inverse;
        }
        else if (sourceQuantity.BaseDimensions == targetQuantity.BaseDimensions)
        {
            if (sourceQuantity.BaseDimensions.IsDimensionless())
            {
                convertedValue = toUnit.ConvertValueFromBaseUnit(fromUnit.ConvertValueToBaseUnit(value));
                return true;
            }

            conversionExpression = sourceValue => sourceValue;
        }
        else
        {
            convertedValue = default;
            return false;
        }

        if (fromUnit.BaseUnits != BaseUnits.Undefined)
        {
            if (toUnit.BaseUnits == fromUnit.BaseUnits)
            {
                convertedValue = conversionExpression(value);
                return true;
            }

            if (targetQuantity.UnitInfos.TryGetUnitWithBase(fromUnit.BaseUnits, out UnitInfo? matchingUnit))
            {
                convertedValue = ConvertValueInternal(conversionExpression(value), matchingUnit, toUnit);
                return true;
            }

            UnitInfo fromBaseUnit = sourceQuantity.BaseUnitInfo;
            if (fromUnit.BaseUnits != fromBaseUnit.BaseUnits && fromBaseUnit.BaseUnits != BaseUnits.Undefined)
            {
                if (toUnit.QuantityInfo.BaseUnitInfo.BaseUnits == fromBaseUnit.BaseUnits)
                {
                    convertedValue = toUnit.ConvertValueFromBaseUnit(conversionExpression(fromUnit.ConversionToBase.Evaluate(value)));
                    return true;
                }
            }
        }
        else if (toUnit.BaseUnits != BaseUnits.Undefined)
        {
            if (sourceQuantity.UnitInfos.TryGetUnitWithBase(toUnit.BaseUnits, out UnitInfo? matchingUnit))
            {
                convertedValue = conversionExpression(ConvertValueInternal(value, fromUnit, matchingUnit));
                return true;
            }

            UnitInfo toBaseUnit = targetQuantity.BaseUnitInfo;
            if (toUnit.BaseUnits != toBaseUnit.BaseUnits && toBaseUnit.BaseUnits != BaseUnits.Undefined)
            {
                if (sourceQuantity.BaseUnitInfo.BaseUnits == toBaseUnit.BaseUnits)
                {
                    convertedValue = toUnit.ConversionFromBase.Evaluate(conversionExpression(fromUnit.ConvertValueToBaseUnit(value)));
                    return true;
                }
            }
        }

        foreach (UnitInfo sourceUnit in sourceQuantity.UnitInfos)
        {
            if (sourceUnit.BaseUnits == BaseUnits.Undefined || sourceUnit.BaseUnits == fromUnit.BaseUnits)
            {
                continue;
            }

            if (targetQuantity.UnitInfos.TryGetUnitWithBase(sourceUnit.BaseUnits, out UnitInfo? matchingUnit))
            {
                convertedValue = ConvertValueInternal(conversionExpression(ConvertValueInternal(value, fromUnit, sourceUnit)), matchingUnit, toUnit);
                return true;
            }
        }

        convertedValue = default;
        return false;
    }

    /// <summary>
    ///     Attempts to convert a quantity value from a source unit to a target quantity type and unit.
    /// </summary>
    /// <typeparam name="TSourceUnit">The type of the source unit enumeration.</typeparam>
    /// <typeparam name="TTargetQuantity">The type of the target quantity.</typeparam>
    /// <typeparam name="TTargetUnit">The type of the target unit enumeration.</typeparam>
    /// <param name="value">The quantity value to convert.</param>
    /// <param name="fromUnit">The source unit of the quantity value.</param>
    /// <param name="targetQuantityInfo">The information about the target quantity type and unit.</param>
    /// <param name="convertedQuantity">
    ///     When this method returns, contains the converted quantity if the conversion succeeded, or <c>null</c> if the
    ///     conversion failed.
    /// </param>
    /// <returns><c>true</c> if the conversion succeeded; otherwise, <c>false</c>.</returns>
    public virtual bool TryConvertTo<TSourceUnit, TTargetQuantity, TTargetUnit>(QuantityValue value, TSourceUnit fromUnit,
        QuantityInfo<TTargetQuantity, TTargetUnit> targetQuantityInfo, [MaybeNullWhen(false)] out TTargetQuantity convertedQuantity)
        where TSourceUnit : struct, Enum
        where TTargetQuantity : IQuantity<TTargetQuantity, TTargetUnit>
        where TTargetUnit : struct, Enum
    {
        if (TryGetUnitInfo(UnitKey.ForUnit(fromUnit), out UnitInfo? fromUnitInfo) && ConversionDefined(fromUnitInfo.QuantityInfo, targetQuantityInfo))
        {
            return targetQuantityInfo.TryConvertFrom(value, fromUnitInfo, out convertedQuantity);
        }

        convertedQuantity = default;
        return false;
    }

    /// <inheritdoc cref="TryConvertTo{TSourceUnit,TTargetQuantity,TTargetUnit}" />
    public virtual bool TryConvertTo(QuantityValue value, UnitKey fromUnitKey, QuantityInfo targetQuantityInfo,
        [NotNullWhen(true)] out IQuantity? convertedQuantity)
    {
        if (TryGetUnitInfo(fromUnitKey, out UnitInfo? fromUnitInfo) && ConversionDefined(fromUnitInfo.QuantityInfo, targetQuantityInfo))
        {
            return targetQuantityInfo.TryConvertFrom(value, fromUnitInfo, out convertedQuantity);
        }

        convertedQuantity = null;
        return false;
    }
    
    /// <summary>
    ///     Converts the quantity to the specified unit.
    /// </summary>
    /// <param name="quantity">The quantity to convert. Must not be null.</param>
    /// <param name="toUnitKey">The unit to convert the quantity to.</param>
    /// When this method returns, contains the converted quantity if the conversion succeeded, or
    /// <c>null</c>
    /// if the
    /// conversion failed.
    /// <returns>
    ///     A new instance of <typeparamref name="TQuantity" /> representing the converted value in the specified unit.
    /// </returns>
    /// <exception cref="UnitNotFoundException">Thrown when no unit information is found for the specified enum value.</exception>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when the conversion between the specified units is not possible.
    /// </exception>
    /// <remarks>
    ///     This method should succeed for any two units of the same quantity, but may fail if the units are not found or are
    ///     found to be from two
    ///     incompatible quantities.
    /// </remarks>
    public IQuantity ConvertTo<TQuantity>(TQuantity quantity, UnitKey toUnitKey)
        where TQuantity : IQuantity
    {
        QuantityInfo quantityInfo = quantity.QuantityInfo;
        if (quantityInfo.UnitType == toUnitKey.UnitEnumType)
        {
            QuantityValue convertedValue = ConvertValue(quantity.Value, quantity.UnitKey, toUnitKey);
            return quantityInfo.From(convertedValue, toUnitKey);
        }
        else
        {
            UnitInfo fromUnitInfo = GetUnitInfo(quantity.UnitKey);
            UnitInfo toUnitInfo = GetUnitInfo(toUnitKey);
            QuantityValue convertedValue = ConvertValueInternal(quantity.Value, fromUnitInfo, toUnitInfo);
            return toUnitInfo.From(convertedValue);
        }
    }

    /// <summary>
    ///     Converts a quantity from its current unit to the specified unit.
    /// </summary>
    /// <typeparam name="TQuantity">
    ///     The type of the quantity being converted. Must implement <see cref="IQuantity{TSelf, TUnitType}" />.
    /// </typeparam>
    /// <typeparam name="TUnit">
    ///     The type of the unit to convert to. Must be an enumeration.
    /// </typeparam>
    /// <param name="quantity">
    ///     The quantity to be converted, including its value and current unit.
    /// </param>
    /// <param name="toUnit">
    ///     The target unit to which the quantity should be converted.
    /// </param>
    /// <returns>
    ///     A new instance of <typeparamref name="TQuantity" /> representing the converted value in the specified unit.
    /// </returns>
    /// <exception cref="UnitNotFoundException">Thrown when an unknown unit is provided.</exception>
    public TQuantity ConvertToUnit<TQuantity, TUnit>(TQuantity quantity, TUnit toUnit)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        QuantityValue convertedValue = ConvertValue(quantity.Value, quantity.Unit, toUnit);
        return quantity.QuantityInfo.From(convertedValue, toUnit);
    }

    /// <summary>
    ///     Retrieves information about a specific unit.
    /// </summary>
    /// <param name="unit">The unit for which information is being requested.</param>
    /// <returns>An <see cref="UnitInfo" /> object containing details about the specified unit.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="unit" /> is null.</exception>
    /// <exception cref="UnitNotFoundException">Thrown when the <paramref name="unit" /> is not recognized.</exception>
    protected UnitInfo GetUnitInfo(UnitKey unit)
    {
        return Quantities.GetUnitInfo(unit);
    }

    /// <summary>
    ///     Converts the value of a quantity to a specified unit.
    /// </summary>
    /// <typeparam name="TQuantity">The type of quantity to use as the source of the conversion.</typeparam>
    /// <typeparam name="TUnit">The type of the unit to convert to. Must be a struct and an enum.</typeparam>
    /// <param name="quantity">The quantity to convert.</param>
    /// <param name="toUnit">The unit to convert the quantity to.</param>
    /// <returns>The converted quantity value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="quantity" /> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the conversion is not possible.</exception>
    /// <exception cref="UnitNotFoundException">Thrown when <paramref name="toUnit" /> is not found.</exception>
    public QuantityValue ConvertValue<TQuantity, TUnit>(TQuantity quantity, TUnit toUnit)
        where TQuantity : IQuantity<TUnit>
        where TUnit : struct, Enum
    {
        return ConvertValue(quantity.Value, quantity.Unit, toUnit);
    }

    /// <summary>
    ///     Converts a quantity value from one unit to another using the specified quantity information.
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit.</typeparam>
    /// <param name="value">The value to be converted.</param>
    /// <param name="fromUnit">The unit of the value to be converted.</param>
    /// <param name="toUnit">The unit to which the value should be converted.</param>
    /// <exception cref="UnitNotFoundException">Thrown when either <paramref name="fromUnit" /> or <paramref name="toUnit" /> is not found.</exception>
    /// <returns>The converted quantity value.</returns>
    public virtual QuantityValue ConvertValue<TUnit>(QuantityValue value, TUnit fromUnit, TUnit toUnit)
        where TUnit : struct, Enum
    {
        var fromUnitKey = UnitKey.ForUnit(fromUnit);
        var toUnitKey = UnitKey.ForUnit(toUnit);
        if (fromUnitKey.UnitEnumValue == toUnitKey.UnitEnumValue)
        {
            return value;
        }
        
        UnitInfo fromUnitInfo = GetUnitInfo(fromUnitKey);
        UnitInfo toUnitInfo = GetUnitInfo(toUnitKey);
        return toUnitInfo.GetValueFrom(value, fromUnitInfo);
    }

    /// <summary>
    ///     Converts a quantity value from one unit to another using the specified quantity information.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <param name="fromUnitKey">The unit of the value to be converted from.</param>
    /// <param name="toUnitKey">The unit of the value to be converted to.</param>
    /// <returns>The converted quantity value.</returns>
    /// <exception cref="UnitNotFoundException">Thrown when no unit information is found for the specified enum value.</exception>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when the conversion between the specified units is not possible.
    /// </exception>
    /// <remarks>
    ///     This method should succeed for any two units of the same quantity, but may fail if the units are not found or are
    ///     found to be from two
    ///     incompatible quantities.
    /// </remarks>
    public virtual QuantityValue ConvertValue(QuantityValue value, UnitKey fromUnitKey, UnitKey toUnitKey)
    {
        if (fromUnitKey == toUnitKey)
        {
            return value;
        }
        
        UnitInfo fromUnitInfo = GetUnitInfo(fromUnitKey);
        UnitInfo toUnitInfo = GetUnitInfo(toUnitKey);
        return ConvertValueInternal(value, fromUnitInfo, toUnitInfo);
    }

    /// <summary>
    ///     Converts a quantity value from one unit to another.
    /// </summary>
    /// <param name="value">The quantity value to convert.</param>
    /// <param name="fromUnitInfo">The unit information of the source unit.</param>
    /// <param name="toUnitInfo">The unit information of the target unit.</param>
    /// <returns>The converted quantity value.</returns>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when the conversion between the specified units is not possible.
    /// </exception>
    /// <remarks>
    ///     This method should succeed for any two units of the same quantity, but may fail if the units are from two
    ///     incompatible quantities.
    /// </remarks>
    protected virtual QuantityValue ConvertValueInternal(QuantityValue value, UnitInfo fromUnitInfo, UnitInfo toUnitInfo)
    {
        return fromUnitInfo.QuantityInfo == toUnitInfo.QuantityInfo
            ? toUnitInfo.GetValueFrom(value, fromUnitInfo)
            : ConvertValueFromOneQuantityToAnother(value, fromUnitInfo, toUnitInfo);
    }

    /// <summary>
    ///     Converts a value from one quantity to another, considering the units and their base dimensions.
    /// </summary>
    /// <param name="value">The value to be converted.</param>
    /// <param name="fromUnitInfo">Information about the unit of the source quantity.</param>
    /// <param name="toUnitInfo">Information about the unit of the target quantity.</param>
    /// <returns>The converted value in the target quantity's unit.</returns>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when no implicit conversion exists between the source and target quantities,
    ///     or when no compatible units are found for the conversion.
    /// </exception>
    /// <remarks>
    ///     This method handles conversions between quantities with matching or inverse base dimensions.
    /// </remarks>
    protected QuantityValue ConvertValueFromOneQuantityToAnother(QuantityValue value, UnitInfo fromUnitInfo, UnitInfo toUnitInfo)
    {
        QuantityInfo sourceQuantity = fromUnitInfo.QuantityInfo;
        QuantityInfo targetQuantity = toUnitInfo.QuantityInfo;
        if (!ConversionDefined(sourceQuantity, targetQuantity))
        {
            throw InvalidConversionException.CreateImplicitConversionException(sourceQuantity, targetQuantity);
        }
        
        ConvertValueDelegate conversionExpression;
        if (sourceQuantity.BaseDimensions.IsInverseOf(targetQuantity.BaseDimensions))
        {
            conversionExpression = QuantityValue.Inverse;
        }
        else if (sourceQuantity.BaseDimensions == targetQuantity.BaseDimensions)
        {
            if (sourceQuantity.BaseDimensions.IsDimensionless())
            {
                return toUnitInfo.ConvertValueFromBaseUnit(fromUnitInfo.ConvertValueToBaseUnit(value));
            }

            conversionExpression = sourceValue => sourceValue;
        }
        else
        {
            throw InvalidConversionException.CreateIncompatibleDimensionsException(sourceQuantity, targetQuantity);
        }

        if (fromUnitInfo.BaseUnits != BaseUnits.Undefined)
        {
            if (toUnitInfo.BaseUnits == fromUnitInfo.BaseUnits)
            {
                return conversionExpression(value);
            }

            if (targetQuantity.UnitInfos.TryGetUnitWithBase(fromUnitInfo.BaseUnits, out UnitInfo? matchingUnit))
            {
                return ConvertValueInternal(conversionExpression(value), matchingUnit, toUnitInfo);
            }

            UnitInfo fromBaseUnit = sourceQuantity.BaseUnitInfo;
            if (fromUnitInfo.BaseUnits != fromBaseUnit.BaseUnits && fromBaseUnit.BaseUnits != BaseUnits.Undefined)
            {
                if (toUnitInfo.QuantityInfo.BaseUnitInfo.BaseUnits == fromBaseUnit.BaseUnits)
                {
                    return toUnitInfo.ConvertValueFromBaseUnit(conversionExpression(fromUnitInfo.ConversionToBase.Evaluate(value)));
                }
            }
        }
        else if (toUnitInfo.BaseUnits != BaseUnits.Undefined)
        {
            if (sourceQuantity.UnitInfos.TryGetUnitWithBase(toUnitInfo.BaseUnits, out UnitInfo? matchingUnit))
            {
                return conversionExpression(ConvertValueInternal(value, fromUnitInfo, matchingUnit));
            }

            UnitInfo toBaseUnit = targetQuantity.BaseUnitInfo;
            if (toUnitInfo.BaseUnits != toBaseUnit.BaseUnits && toBaseUnit.BaseUnits != BaseUnits.Undefined)
            {
                if (sourceQuantity.BaseUnitInfo.BaseUnits == toBaseUnit.BaseUnits)
                {
                    return toUnitInfo.ConversionFromBase.Evaluate(conversionExpression(fromUnitInfo.ConvertValueToBaseUnit(value)));
                }
            }
        }

        IReadOnlyList<UnitInfo> sourceQuantityUnits = sourceQuantity.UnitInfos;
        var nbSourceUnits = sourceQuantityUnits.Count;
        for (var i = 0; i < nbSourceUnits; i++)
        {
            UnitInfo sourceUnit = sourceQuantityUnits[i];
            if (sourceUnit.BaseUnits == BaseUnits.Undefined || sourceUnit.BaseUnits == fromUnitInfo.BaseUnits)
            {
                continue;
            }

            if (targetQuantity.UnitInfos.TryGetUnitWithBase(sourceUnit.BaseUnits, out UnitInfo? matchingUnit))
            {
                return ConvertValueInternal(conversionExpression(ConvertValueInternal(value, fromUnitInfo, sourceUnit)), matchingUnit, toUnitInfo);
            }
        }
        
        throw InvalidConversionException.CreateIncompatibleUnitsException(fromUnitInfo, targetQuantity);
    }

    /// <summary>
    ///     Converts a quantity value from one unit to another specified unit type.
    /// </summary>
    /// <typeparam name="TSourceUnit">The type of the source unit.</typeparam>
    /// <typeparam name="TTargetQuantity">The type of the target quantity.</typeparam>
    /// <typeparam name="TTargetUnit">The type of the target unit.</typeparam>
    /// <param name="value">The quantity value to convert.</param>
    /// <param name="fromUnit">The source unit of the quantity value.</param>
    /// <param name="targetQuantityInfo">The target quantity information which includes the target unit.</param>
    /// <returns>The converted quantity in the target unit type.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="targetQuantityInfo" /> is null.</exception>
    /// <exception cref="UnitNotFoundException">Thrown when the source unit is not found.</exception>
    /// <exception cref="InvalidConversionException">Thrown when the conversion cannot be performed.</exception>
    public virtual TTargetQuantity ConvertTo<TSourceUnit, TTargetQuantity, TTargetUnit>(QuantityValue value, TSourceUnit fromUnit,
        QuantityInfo<TTargetQuantity, TTargetUnit> targetQuantityInfo)
        where TSourceUnit : struct, Enum
        where TTargetQuantity : IQuantity<TTargetQuantity, TTargetUnit>
        where TTargetUnit : struct, Enum
    {
        UnitInfo fromUnitInfo = GetUnitInfo(UnitKey.ForUnit(fromUnit));
        QuantityInfo sourceQuantityInfo = fromUnitInfo.QuantityInfo;
        if (!ConversionDefined(sourceQuantityInfo, targetQuantityInfo))
        {
            throw InvalidConversionException.CreateImplicitConversionException(sourceQuantityInfo, targetQuantityInfo);
        }
        
        return targetQuantityInfo.ConvertFrom(value, fromUnitInfo);
    }

    /// <inheritdoc cref="ConvertTo{TSourceUnit,TTargetQuantity,TTargetUnit}" />
    public virtual IQuantity ConvertTo(QuantityValue value, UnitKey fromUnitKey, QuantityInfo targetQuantityInfo)
    {
        UnitInfo fromUnitInfo = GetUnitInfo(fromUnitKey);
        QuantityInfo sourceQuantityInfo = fromUnitInfo.QuantityInfo;
        if (!ConversionDefined(sourceQuantityInfo, targetQuantityInfo))
        {
            throw InvalidConversionException.CreateImplicitConversionException(sourceQuantityInfo, targetQuantityInfo);
        }
        
        return targetQuantityInfo.ConvertFrom(value, fromUnitInfo);
    }

    /// <summary>
    ///     Gets a conversion function that converts a value from one unit to another.
    /// </summary>
    /// <param name="fromUnitKey">The key representing the unit to convert from.</param>
    /// <param name="toUnitKey">The key representing the unit to convert to.</param>
    /// <returns>
    ///     A delegate that converts a <see cref="QuantityValue" /> from the specified <paramref name="fromUnitKey" /> to
    ///     the specified <paramref name="toUnitKey" />.
    /// </returns>
    /// <exception cref="UnitNotFoundException">
    ///     Thrown if the specified <paramref name="fromUnitKey" /> or <paramref name="toUnitKey" /> does not exist.
    /// </exception>
    /// <exception cref="InvalidConversionException">
    ///     Thrown if the quantities are different and no conversion function exists between them.
    /// </exception>
    /// <remarks>
    ///     If the <paramref name="fromUnitKey" /> and <paramref name="toUnitKey" /> are the same, the returned function will
    ///     be an identity function.
    /// </remarks>
    public virtual ConvertValueDelegate GetConversionFunction(UnitKey fromUnitKey, UnitKey toUnitKey)
    {
        if (fromUnitKey == toUnitKey)
        {
            return value => value;
        }

        UnitInfo fromUnitInfo = GetUnitInfo(fromUnitKey);
        UnitInfo toUnitInfo = GetUnitInfo(toUnitKey);
        return fromUnitKey.UnitEnumType == toUnitKey.UnitEnumType
            ? fromUnitInfo.GetUnitConversionExpressionTo(toUnitInfo)
            : GetConversionFromOneQuantityToAnother(fromUnitInfo, toUnitInfo);
    }

    /// <summary>
    ///     Retrieves the conversion expression required to convert a value from one unit of quantity to another.
    /// </summary>
    /// <param name="fromUnitInfo">The unit information of the source quantity.</param>
    /// <param name="toUnitInfo">The unit information of the target quantity.</param>
    /// <param name="reduceConstants">
    ///     A boolean value indicating whether to reduce constants in the conversion expression.
    ///     Default is true.
    /// </param>
    /// <returns>A <see cref="ConversionExpression" /> representing the conversion from the source unit to the target unit.</returns>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when no implicit conversion exists between the specified source and target quantities.
    /// </exception>
    protected ConversionExpression GetConversionFromOneQuantityToAnother(UnitInfo fromUnitInfo, UnitInfo toUnitInfo, bool reduceConstants = true)
    {
        QuantityInfo sourceQuantity = fromUnitInfo.QuantityInfo;
        QuantityInfo targetQuantity = toUnitInfo.QuantityInfo;
        if (!ConversionDefined(sourceQuantity, targetQuantity))
        {
            throw InvalidConversionException.CreateImplicitConversionException(sourceQuantity, targetQuantity);
        }

        return fromUnitInfo.GetQuantityConversionExpressionTo(toUnitInfo);
    }

    /// <summary>
    ///     Attempts to get a conversion function that converts a value from one unit to another.
    /// </summary>
    /// <param name="fromUnitKey">The key representing the unit to convert from.</param>
    /// <param name="toUnitKey">The key representing the unit to convert to.</param>
    /// <param name="conversionFunction">
    ///     When this method returns, contains the conversion function if the conversion is possible; otherwise, <c>null</c>.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the conversion function was successfully retrieved; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    ///     If the <paramref name="fromUnitKey" /> and <paramref name="toUnitKey" /> are the same, the returned function will
    ///     be an identity function.
    /// </remarks>
    public virtual bool TryGetConversionFunction(UnitKey fromUnitKey, UnitKey toUnitKey, [NotNullWhen(true)] out ConvertValueDelegate? conversionFunction)
    {
        if (fromUnitKey == toUnitKey)
        {
            conversionFunction = value => value;
            return true;
        }

        if (!TryGetUnitInfo(fromUnitKey, out UnitInfo? fromUnitInfo) || !TryGetUnitInfo(toUnitKey, out UnitInfo? toUnitInfo))
        {
            conversionFunction = null;
            return false;
        }

        if (fromUnitKey.UnitEnumType != toUnitKey.UnitEnumType)
        {
            return TryGetConversionFromOneQuantityToAnother(fromUnitInfo, toUnitInfo, out conversionFunction);
        }

        conversionFunction = fromUnitInfo.GetUnitConversionExpressionTo(toUnitInfo);
        return true;
    }

    /// <summary>
    ///     Attempts to retrieve a conversion function that converts a value from one unit to another unit of a different
    ///     quantity.
    /// </summary>
    /// <param name="fromUnitInfo">The unit information of the source unit.</param>
    /// <param name="toUnitInfo">The unit information of the target unit.</param>
    /// <param name="conversionFunction">
    ///     When this method returns, contains the conversion function if the conversion is defined; otherwise, <c>null</c>.
    /// </param>
    /// <returns>
    ///     <c>true</c> if a conversion function is successfully retrieved; otherwise, <c>false</c>.
    /// </returns>
    protected bool TryGetConversionFromOneQuantityToAnother(UnitInfo fromUnitInfo, UnitInfo toUnitInfo, out ConvertValueDelegate? conversionFunction)
    {
        if (ConversionDefined(fromUnitInfo.QuantityInfo, toUnitInfo.QuantityInfo) &&
            fromUnitInfo.TryGetQuantityConversionExpressionTo(toUnitInfo, true, out ConversionExpression? conversionExpression))
        {
            conversionFunction = conversionExpression;
            return true;
        }

        conversionFunction = null;
        return false;
    }

    /// <summary>
    ///     Convert between any two quantity units by their names, such as converting a "Length" of N "Meter" to "Centimeter".
    ///     This is particularly useful for creating things like a generated unit conversion UI,
    ///     where you list some selectors:
    ///     a) Quantity: Length, Mass, Force etc.
    ///     b) From unit: Meter, Centimeter etc if Length is selected
    ///     c) To unit: Meter, Centimeter etc if Length is selected
    /// </summary>
    /// <param name="fromValue">
    ///     Input value, which together with <paramref name="fromUnitName" /> represents the quantity to
    ///     convert from.
    /// </param>
    /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
    /// <param name="fromUnitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
    /// <param name="toUnitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
    /// <example>double centimeters = ConvertByName(5, "Length", "Meter", "Centimeter"); // 500</example>
    /// <returns>Output value as the result of converting to <paramref name="toUnitName" />.</returns>
    /// <exception cref="QuantityNotFoundException">
    ///     Thrown when no quantity information is found for the specified quantity name.
    /// </exception>
    /// <exception cref="UnitNotFoundException">No units match the provided unit name.</exception>
    /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
    public QuantityValue ConvertValueByName(QuantityValue fromValue, string quantityName, string fromUnitName, string toUnitName)
    {
        UnitInfo fromUnitInfo = Quantities.GetUnitByName(quantityName, fromUnitName);
        UnitInfo toUnitInfo = Quantities.GetUnitByName(quantityName, toUnitName);
        return ConvertValueInternal(fromValue, fromUnitInfo, toUnitInfo);
    }

    /// <summary>
    ///     Convert between any two quantity units by their names, such as converting a "Length" of N "Meter" to "Centimeter".
    ///     This is particularly useful for creating things like a generated unit conversion UI,
    ///     where you list some selectors:
    ///     a) Quantity: Length, Mass, Force etc.
    ///     b) From unit: Meter, Centimeter etc if Length is selected
    ///     c) To unit: Meter, Centimeter etc if Length is selected
    /// </summary>
    /// <param name="inputValue">
    ///     Input value, which together with <paramref name="fromUnitName" /> represents the quantity to
    ///     convert from.
    /// </param>
    /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
    /// <param name="fromUnitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
    /// <param name="toUnitName">The invariant unit enum name, such as "Meter". Does not support localization.</param>
    /// <param name="result">Result if conversion was successful, 0 if not.</param>
    /// <example>bool ok = TryConvertByName(5, "Length", "Meter", "Centimeter", out double centimeters); // 500</example>
    /// <returns>True if conversion was successful.</returns>
    public bool TryConvertValueByName(QuantityValue inputValue, string quantityName, string fromUnitName, string toUnitName, out QuantityValue result)
    {
        if (Quantities.TryGetUnitByName(quantityName, fromUnitName, out UnitInfo? fromUnitInfo) &&
            Quantities.TryGetUnitByName(quantityName, toUnitName, out UnitInfo? toUnitInfo))
        {
            return TryConvertValueInternal(inputValue, fromUnitInfo, toUnitInfo, out result);
        }

        result = default;
        return false;
    }
    
    /// <summary>
    ///     Convert between any two quantity units by their abbreviations, such as converting a "Length" of N "m" to "cm".
    ///     This is particularly useful for creating things like a generated unit conversion UI,
    ///     where you list some selectors:
    ///     a) Quantity: Length, Mass, Force etc.
    ///     b) From unit: Meter, Centimeter etc if Length is selected
    ///     c) To unit: Meter, Centimeter etc if Length is selected
    /// </summary>
    /// <param name="fromValue">
    ///     Input value, which together with <paramref name="fromUnitAbbrev" /> represents the quantity to
    ///     convert from.
    /// </param>
    /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
    /// <param name="fromUnitAbbrev">The abbreviation of the unit in the thread's current culture, such as "m".</param>
    /// <param name="toUnitAbbrev">The abbreviation of the unit in the thread's current culture, such as "m".</param>
    /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
    /// <returns>Output value as the result of converting to <paramref name="toUnitAbbrev" />.</returns>
    /// <exception cref="QuantityNotFoundException">
    ///     Thrown when no quantity information is found for the specified quantity name.
    /// </exception>
    /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
    /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
    public QuantityValue ConvertValueByAbbreviation(QuantityValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev)
    {
        return ConvertValueByAbbreviation(fromValue, quantityName, fromUnitAbbrev, toUnitAbbrev, null);
    }

    /// <summary>
    ///     Convert between any two quantity units by their abbreviations, such as converting a "Length" of N "m" to "cm".
    ///     This is particularly useful for creating things like a generated unit conversion UI,
    ///     where you list some selectors:
    ///     a) Quantity: Length, Mass, Force etc.
    ///     b) From unit: Meter, Centimeter etc if Length is selected
    ///     c) To unit: Meter, Centimeter etc if Length is selected
    /// </summary>
    /// <param name="fromValue">
    ///     Input value, which together with <paramref name="fromUnitAbbrev" /> represents the quantity to
    ///     convert from.
    /// </param>
    /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
    /// <param name="fromUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
    /// <param name="toUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
    /// <param name="culture">The unit localization culture. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
    /// <returns>Output value as the result of converting to <paramref name="toUnitAbbrev" />.</returns>
    /// <exception cref="QuantityNotFoundException">
    ///     Thrown when no quantity information is found for the specified quantity name.
    /// </exception>
    /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
    /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
    public QuantityValue ConvertValueByAbbreviation(QuantityValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, CultureInfo? culture)
    {
        QuantityInfo quantityInfo = Quantities.GetQuantityByName(quantityName);
        UnitInfo fromUnitInfo = UnitParser.Parse(fromUnitAbbrev, quantityInfo.UnitInfos, culture); // ex: ("m", LengthUnit) => LengthUnit.Meter
        UnitInfo toUnitInfo = UnitParser.Parse(toUnitAbbrev, quantityInfo.UnitInfos, culture); // ex:("cm", LengthUnit) => LengthUnit.Centimeter
        return ConvertValueInternal(fromValue, fromUnitInfo, toUnitInfo);
    }

    /// <summary>
    ///     Convert between any two quantity units by their abbreviations, such as converting a "Length" of N "m" to "cm".
    ///     This is particularly useful for creating things like a generated unit conversion UI,
    ///     where you list some selectors:
    ///     a) Quantity: Length, Mass, Force etc.
    ///     b) From unit: Meter, Centimeter etc if Length is selected
    ///     c) To unit: Meter, Centimeter etc if Length is selected
    /// </summary>
    /// <param name="fromValue">
    ///     Input value, which together with <paramref name="fromUnitAbbrev" /> represents the quantity to
    ///     convert from.
    /// </param>
    /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
    /// <param name="fromUnitAbbrev">The abbreviation of the unit in the thread's current culture, such as "m".</param>
    /// <param name="toUnitAbbrev">The abbreviation of the unit in the thread's current culture, such as "m".</param>
    /// <param name="result">Result if conversion was successful, 0 if not.</param>
    /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
    /// <returns>True if conversion was successful.</returns>
    public bool TryConvertValueByAbbreviation(QuantityValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out QuantityValue result)
    {
        return TryConvertValueByAbbreviation(fromValue, quantityName, fromUnitAbbrev, toUnitAbbrev, null, out result);
    }

    /// <summary>
    ///     Convert between any two quantity units by their abbreviations, such as converting a "Length" of N "m" to "cm".
    ///     This is particularly useful for creating things like a generated unit conversion UI,
    ///     where you list some selectors:
    ///     a) Quantity: Length, Mass, Force etc.
    ///     b) From unit: Meter, Centimeter etc if Length is selected
    ///     c) To unit: Meter, Centimeter etc if Length is selected
    /// </summary>
    /// <param name="fromValue">
    ///     Input value, which together with <paramref name="fromUnitAbbrev" /> represents the quantity to
    ///     convert from.
    /// </param>
    /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
    /// <param name="fromUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
    /// <param name="toUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
    /// <param name="culture">The unit localization culture. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
    /// <param name="result">Result if conversion was successful, 0 if not.</param>
    /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
    /// <returns>True if conversion was successful.</returns>
    public bool TryConvertValueByAbbreviation(QuantityValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, CultureInfo? culture,
        out QuantityValue result)  
    {
        if (!Quantities.TryGetQuantityByName(quantityName, out QuantityInfo? quantityInfo))
        {
            result = default;
            return false;
        }

        if (UnitParser.TryParse(fromUnitAbbrev, quantityInfo.UnitInfos, culture, out UnitInfo? fromUnitInfo) &&
            UnitParser.TryParse(toUnitAbbrev, quantityInfo.UnitInfos, culture, out UnitInfo? toUnitInfo))
        {
            result = ConvertValueInternal(fromValue, fromUnitInfo, toUnitInfo);
            return true;
        }

        result = default;
        return false;
    }

    #region Static methods
    
    /// <inheritdoc cref="ConvertValue"/>
    public static QuantityValue Convert(QuantityValue value, UnitKey fromUnitKey, UnitKey toUnitKey)
    {
        return Default.ConvertValue(value, fromUnitKey, toUnitKey);
    }

    /// <inheritdoc cref="TryConvertValue"/>
    public static bool TryConvert(QuantityValue value, UnitKey fromUnitKey, UnitKey toUnitKey, out QuantityValue result)
    {
        return Default.TryConvertValue(value, fromUnitKey, toUnitKey, out result);
    }

    /// <inheritdoc cref="ConvertValueByName"/>
    public static QuantityValue ConvertByName(QuantityValue inputValue, string quantityName, string fromUnitName, string toUnitName)
    {
        return Default.ConvertValueByName(inputValue, quantityName, fromUnitName, toUnitName);
    }

    /// <inheritdoc cref="TryConvertByName"/>
    public static bool TryConvertByName(QuantityValue inputValue, string quantityName, string fromUnitName, string toUnitName, out QuantityValue result)
    {
        return Default.TryConvertValueByName(inputValue, quantityName, fromUnitName, toUnitName, out result);
    }

    /// <inheritdoc cref="ConvertValueByAbbreviation(UnitsNet.QuantityValue,string,string,string)"/>
    public static QuantityValue ConvertByAbbreviation(QuantityValue inputValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev)
    {
        return Default.ConvertValueByAbbreviation(inputValue, quantityName, fromUnitAbbrev, toUnitAbbrev);
    }

    /// <inheritdoc cref="TryConvertValueByAbbreviation(UnitsNet.QuantityValue,string,string,string,out UnitsNet.QuantityValue)"/>
    public static bool TryConvertByAbbreviation(QuantityValue inputValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out QuantityValue result)
    {
        return Default.TryConvertValueByAbbreviation(inputValue, quantityName, fromUnitAbbrev, toUnitAbbrev, out result);
    }

    /// <inheritdoc cref="ConvertValueByAbbreviation(UnitsNet.QuantityValue,string,string,string,CultureInfo?)"/>
    public static QuantityValue ConvertByAbbreviation(QuantityValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, CultureInfo? culture)
    {
        return Default.ConvertValueByAbbreviation(fromValue, quantityName, fromUnitAbbrev, toUnitAbbrev, culture);
    }

    /// <inheritdoc cref="TryConvertValueByAbbreviation(UnitsNet.QuantityValue,string,string,string,CultureInfo?,out UnitsNet.QuantityValue)"/>
    public static bool TryConvertByAbbreviation(QuantityValue inputValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, CultureInfo? culture, out QuantityValue result) 
    {
        return Default.TryConvertValueByAbbreviation(inputValue, quantityName, fromUnitAbbrev, toUnitAbbrev, culture, out result);
    }

    /// <summary>
    ///     Convert between any two quantity units by their abbreviations, such as converting a "Length" of N "m" to "cm".
    ///     This is particularly useful for creating things like a generated unit conversion UI,
    ///     where you list some selectors:
    ///     a) Quantity: Length, Mass, Force etc.
    ///     b) From unit: Meter, Centimeter etc if Length is selected
    ///     c) To unit: Meter, Centimeter etc if Length is selected
    /// </summary>
    /// <param name="fromValue">
    ///     Input value, which together with <paramref name="fromUnitAbbrev" /> represents the quantity to
    ///     convert from.
    /// </param>
    /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
    /// <param name="fromUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
    /// <param name="toUnitAbbrev">The abbreviation of the unit in the given culture, such as "m".</param>
    /// <param name="culture">Culture to parse abbreviations with.</param>
    /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
    /// <returns>Output value as the result of converting to <paramref name="toUnitAbbrev" />.</returns>
    /// <exception cref="QuantityNotFoundException">
    ///     Thrown when no quantity information is found for the specified quantity name.
    /// </exception>
    /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
    /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
    [Obsolete("Methods accepting a culture name are deprecated in favor of using an instance of CultureInfo.")]
    public static QuantityValue ConvertByAbbreviation(QuantityValue fromValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, string? culture)
    {
        return Default.ConvertValueByAbbreviation(fromValue, quantityName, fromUnitAbbrev, toUnitAbbrev, CultureHelper.GetCultureOrInvariant(culture));
    }
    
    /// <summary>
    ///     Convert between any two quantity units by their abbreviations, such as converting a "Length" of N "m" to "cm".
    ///     This is particularly useful for creating things like a generated unit conversion UI,
    ///     where you list some selectors:
    ///     a) Quantity: Length, Mass, Force etc.
    ///     b) From unit: Meter, Centimeter etc if Length is selected
    ///     c) To unit: Meter, Centimeter etc if Length is selected
    /// </summary>
    /// <param name="inputValue">
    ///     Input value, which together with <paramref name="fromUnitAbbrev" /> represents the quantity to
    ///     convert from.
    /// </param>
    /// <param name="quantityName">The invariant quantity name, such as "Length". Does not support localization.</param>
    /// <param name="fromUnitAbbrev">The abbreviation of the unit in the thread's current culture, such as "m".</param>
    /// <param name="toUnitAbbrev">The abbreviation of the unit in the thread's current culture, such as "m".</param>
    /// <param name="culture">Culture to parse abbreviations with.</param>
    /// <param name="result">Result if conversion was successful, 0 if not.</param>
    /// <example>double centimeters = ConvertByName(5, "Length", "m", "cm"); // 500</example>
    /// <returns>True if conversion was successful.</returns>
    [Obsolete("Methods accepting a culture name are deprecated in favor of using an instance of CultureInfo.")]
    public static bool TryConvertByAbbreviation(QuantityValue inputValue, string quantityName, string fromUnitAbbrev, string toUnitAbbrev, out QuantityValue result, string? culture) 
    {
        return Default.TryConvertValueByAbbreviation(inputValue, quantityName, fromUnitAbbrev, toUnitAbbrev, CultureHelper.GetCultureOrInvariant(culture), out result);
    }

    #endregion
}
