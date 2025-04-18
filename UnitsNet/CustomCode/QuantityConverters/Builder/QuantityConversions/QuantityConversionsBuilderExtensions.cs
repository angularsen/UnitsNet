using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using ConversionEntry = System.Collections.Generic.KeyValuePair<UnitsNet.QuantityConversionKey, UnitsNet.QuantityConversionFunction>;

namespace UnitsNet;

/// <summary>
///     Provides extension methods for building implicit conversions for quantities.
/// </summary>
internal static class QuantityConversionsBuilderExtensions
{
    /// <summary>
    ///     Retrieves a collection of quantity conversions based on the provided conversion mappings.
    /// </summary>
    /// <param name="quantities">The lookup containing quantity information.</param>
    /// <param name="conversionMappings">The mappings defining the conversions between quantity types.</param>
    /// <returns>
    ///     An enumerable collection of <see cref="QuantityConversion" /> representing the implicit conversions between
    ///     quantities.
    /// </returns>
    public static IEnumerable<QuantityConversion> GetQuantityConversions(this QuantityInfoLookup quantities,
        IEnumerable<QuantityConversionMapping> conversionMappings)
    {
        foreach (QuantityConversionMapping conversionMapping in conversionMappings)
        {
            if (quantities.TryGetQuantityInfo(conversionMapping.FirstQuantityType, out QuantityInfo? fromQuantity) &&
                quantities.TryGetQuantityInfo(conversionMapping.SecondQuantityType, out QuantityInfo? toQuantity))
            {
                yield return new QuantityConversion(fromQuantity, toQuantity);
            }
        }
    }

    /// <summary>
    ///     Retrieves a dictionary of custom quantity conversion mapping options based on the specified custom conversion
    ///     options.
    /// </summary>
    /// <param name="quantities">The lookup containing information about available quantities and their units.</param>
    /// <param name="customOptions">The custom conversion options that define specific conversion functions and units.</param>
    /// <returns>
    ///     A dictionary where each key is a <see cref="UnitsNet.QuantityConversion" /> representing a conversion between two
    ///     quantities,
    ///     and each value is a <see cref="UnitsNet.QuantityConversionMappingOptions" /> containing the mapping options for that
    ///     conversion.
    /// </returns>
    /// <remarks>
    ///     This method processes custom conversion functions and units specified in <paramref name="customOptions" /> to build
    ///     a comprehensive set of conversion mappings. It ensures that only valid conversions, where both source and target
    ///     units
    ///     are recognized, are included in the resulting dictionary.
    /// </remarks>
    internal static Dictionary<QuantityConversion, QuantityConversionMappingOptions> GetQuantityConversionMappingOptions(this QuantityInfoLookup quantities,
        QuantityConversionOptions customOptions)
    {
        var conversionOptions = new Dictionary<QuantityConversion, QuantityConversionMappingOptions>();

        foreach (KeyValuePair<UnitConversionMapping, ConversionExpression> customConversion in customOptions.CustomConversionFunctions)
        {
            UnitConversionMapping unitConversionMapping = customConversion.Key;
            if (!quantities.TryGetUnitInfo(unitConversionMapping.FromUnitKey, out UnitInfo? fromUnitInfo) ||
                !quantities.TryGetUnitInfo(unitConversionMapping.ToUnitKey, out UnitInfo? toUnitInfo))
            {
                continue;
            }

            var conversionMapping = new QuantityConversion(fromUnitInfo.QuantityInfo, toUnitInfo.QuantityInfo);
            if (!conversionOptions.TryGetValue(conversionMapping, out QuantityConversionMappingOptions? conversionMappingOptions))
            {
                conversionMappingOptions = conversionOptions[conversionMapping] = new QuantityConversionMappingOptions();
            }

            conversionMappingOptions.ConversionExpressions.Add(unitConversionMapping,
                new CustomQuantityConversionExpressionMapping(fromUnitInfo, toUnitInfo, customConversion.Value));
        }

        foreach (UnitConversionMapping unitConversionMapping in customOptions.ConversionUnits)
        {
            if (!quantities.TryGetUnitInfo(unitConversionMapping.FromUnitKey, out UnitInfo? fromUnitInfo) ||
                !quantities.TryGetUnitInfo(unitConversionMapping.ToUnitKey, out UnitInfo? toUnitInfo))
            {
                continue;
            }

            var conversionMapping = new QuantityConversion(fromUnitInfo.QuantityInfo, toUnitInfo.QuantityInfo);
            if (!conversionOptions.TryGetValue(conversionMapping, out QuantityConversionMappingOptions? conversionMappingOptions))
            {
                conversionMappingOptions = conversionOptions[conversionMapping] = new QuantityConversionMappingOptions();
                conversionMappingOptions.CustomUnitMappings.Add(unitConversionMapping, new CustomQuantityConversionUnitMapping(fromUnitInfo, toUnitInfo));
            }
            else if (!conversionMappingOptions.ConversionExpressions.ContainsKey(unitConversionMapping))
            {
                conversionMappingOptions.CustomUnitMappings.Add(unitConversionMapping, new CustomQuantityConversionUnitMapping(fromUnitInfo, toUnitInfo));
            }
        }

        return conversionOptions;
    }

    /// <summary>
    ///     Retrieves conversion expressions for a collection of quantity conversions based on the specified caching mode and
    ///     constant reduction option.
    /// </summary>
    /// <param name="conversions">The collection of quantity conversions to process.</param>
    /// <param name="cachingMode">The caching mode to use for the conversions.</param>
    /// <param name="reduceConstants">Indicates whether to reduce constants in the conversion expressions.</param>
    /// <returns>
    ///     An enumerable collection of key-value pairs, where the key is a <see cref="QuantityConversionKey" /> and the
    ///     value is a <see cref="QuantityConversionFunction" />.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when an invalid caching mode is specified.</exception>
    public static IEnumerable<ConversionEntry> GetConversionFunctions(this IEnumerable<QuantityConversion> conversions,
        ConversionCachingMode cachingMode, bool reduceConstants = true)
    {
        return cachingMode switch
        {
            ConversionCachingMode.None => [],
            ConversionCachingMode.BaseOnly => conversions.SelectMany(conversion => conversion.GetConversionsWithBaseUnits()),
            ConversionCachingMode.All => conversions.SelectMany(conversion => conversion.GetConversionsWithAllUnits(reduceConstants)),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    /// <summary>
    ///     Retrieves conversion expressions for a given set of quantity conversions, applying custom caching options if
    ///     provided.
    /// </summary>
    /// <param name="conversions">The collection of quantity conversions to process.</param>
    /// <param name="defaultCachingMode">The default caching mode to use if no custom options are specified.</param>
    /// <param name="defaultConstantsReduction">Indicates whether to reduce constants by default.</param>
    /// <param name="customCachingOptions">A dictionary of custom caching options keyed by quantity type.</param>
    /// <returns>
    ///     An enumerable of key-value pairs, where the key is a <see cref="QuantityConversionKey" /> and the value is a
    ///     <see cref="QuantityConversionFunction" />.
    /// </returns>
    public static IEnumerable<ConversionEntry> GetConversionFunctions(this IEnumerable<QuantityConversion> conversions,
        ConversionCachingMode defaultCachingMode, bool defaultConstantsReduction,
        IReadOnlyDictionary<Type, ConversionCacheOptions> customCachingOptions)
    {
        return customCachingOptions.Count == 0
            ? conversions.GetConversionFunctions(defaultCachingMode, defaultConstantsReduction)
            : conversions.SelectMany(conversion => conversion.GetConversionFunctions(defaultCachingMode, defaultConstantsReduction, customCachingOptions));
    }

    private static IEnumerable<ConversionEntry> GetConversionFunctions(this QuantityConversion conversion, ConversionCachingMode defaultCachingMode, bool defaultConstantsReduction,
        IReadOnlyDictionary<Type, ConversionCacheOptions> customCachingOptions)
    {
        (QuantityInfo leftQuantity, QuantityInfo rightQuantity) = conversion;
        if (customCachingOptions.TryGetValue(leftQuantity.QuantityType, out ConversionCacheOptions? leftCacheOptions) &&
            (leftCacheOptions.CachingMode != defaultCachingMode || leftCacheOptions.ReduceConstants != defaultConstantsReduction))
        {
            if (customCachingOptions.TryGetValue(rightQuantity.QuantityType, out ConversionCacheOptions? rightCacheOptions))
            {
                return leftCacheOptions == rightCacheOptions
                    ? conversion.GetQuantityConversions(leftCacheOptions.CachingMode, leftCacheOptions.ReduceConstants)
                    : leftQuantity.GetConversionsTo(rightQuantity, leftCacheOptions.CachingMode, leftCacheOptions.ReduceConstants)
                        .Concat(rightQuantity.GetConversionsTo(leftQuantity, rightCacheOptions.CachingMode, rightCacheOptions.ReduceConstants));
            }

            return leftQuantity.GetConversionsTo(rightQuantity, leftCacheOptions.CachingMode, leftCacheOptions.ReduceConstants)
                .Concat(rightQuantity.GetConversionsTo(leftQuantity, defaultCachingMode, defaultConstantsReduction));
        }
        else if (customCachingOptions.TryGetValue(rightQuantity.QuantityType, out ConversionCacheOptions? rightCacheOptions) &&
                 (rightCacheOptions.CachingMode != defaultCachingMode || rightCacheOptions.ReduceConstants != defaultConstantsReduction))
        {
            return leftQuantity.GetConversionsTo(rightQuantity, defaultCachingMode, defaultConstantsReduction)
                .Concat(rightQuantity.GetConversionsTo(leftQuantity, rightCacheOptions.CachingMode, rightCacheOptions.ReduceConstants));
        }
        else // using the default options
        {
            return conversion.GetQuantityConversions(defaultCachingMode, defaultConstantsReduction);
        }
    }

    /// <summary>
    ///     Retrieves conversion expressions for a given set of quantity conversions.
    /// </summary>
    /// <param name="conversions">The collection of quantity conversions to process.</param>
    /// <param name="customUnitConversions">A dictionary containing custom unit conversions.</param>
    /// <param name="defaultCachingMode">The default caching mode to use if no custom caching options are provided.</param>
    /// <param name="defaultConstantsReduction">A flag indicating whether constants reduction should be applied by default.</param>
    /// <param name="customCachingOptions">A dictionary containing custom caching options for specific types.</param>
    /// <returns>
    ///     An enumerable collection of key-value pairs, where each key is a <see cref="QuantityConversionKey" /> and each
    ///     value is a <see cref="QuantityConversionFunction" />.
    /// </returns>
    public static IEnumerable<ConversionEntry> GetConversionFunctions(this IEnumerable<QuantityConversion> conversions,
        IReadOnlyDictionary<QuantityConversion, QuantityConversionMappingOptions> customUnitConversions,
        ConversionCachingMode defaultCachingMode, bool defaultConstantsReduction,
        IReadOnlyDictionary<Type, ConversionCacheOptions> customCachingOptions)
    {
        if (customUnitConversions.Count == 0)
        {
            return conversions.GetConversionFunctions(defaultCachingMode, defaultConstantsReduction, customCachingOptions);
        }
        
        return conversions.SelectMany(conversion => customUnitConversions.TryGetValue(conversion, out QuantityConversionMappingOptions? conversionMappingOptions)
            ? conversion.GetConversionFunctions(conversionMappingOptions, defaultCachingMode, defaultConstantsReduction, customCachingOptions)
            : conversion.GetConversionFunctions(defaultCachingMode, defaultConstantsReduction, customCachingOptions));
    }

    private static IEnumerable<ConversionEntry> GetConversionFunctions(this QuantityConversion conversion, QuantityConversionMappingOptions customUnitConversions,
        ConversionCachingMode defaultCachingMode, bool defaultConstantsReduction, IReadOnlyDictionary<Type, ConversionCacheOptions> customCachingOptions)
    {
        (QuantityInfo leftQuantity, QuantityInfo rightQuantity) = conversion;
        if (customCachingOptions.TryGetValue(leftQuantity.QuantityType, out ConversionCacheOptions? leftCacheOptions) &&
            (leftCacheOptions.CachingMode != defaultCachingMode || leftCacheOptions.ReduceConstants != defaultConstantsReduction))
        {
            if (customCachingOptions.TryGetValue(rightQuantity.QuantityType, out ConversionCacheOptions? rightCacheOptions))
            {
                return leftCacheOptions == rightCacheOptions
                    ? conversion.GetQuantityConversions(customUnitConversions, leftCacheOptions.CachingMode, leftCacheOptions.ReduceConstants)
                    : leftQuantity.GetConversionsTo(rightQuantity, customUnitConversions, leftCacheOptions.CachingMode, leftCacheOptions.ReduceConstants)
                        .Concat(rightQuantity.GetConversionsTo(leftQuantity, customUnitConversions, rightCacheOptions.CachingMode,
                            rightCacheOptions.ReduceConstants));
            }

            return leftQuantity.GetConversionsTo(rightQuantity, customUnitConversions, leftCacheOptions.CachingMode, leftCacheOptions.ReduceConstants)
                .Concat(rightQuantity.GetConversionsTo(leftQuantity, customUnitConversions, defaultCachingMode, defaultConstantsReduction));
        }
        else if (customCachingOptions.TryGetValue(rightQuantity.QuantityType, out ConversionCacheOptions? rightCacheOptions) &&
                 (rightCacheOptions.CachingMode != defaultCachingMode || rightCacheOptions.ReduceConstants != defaultConstantsReduction))
        {
            return leftQuantity.GetConversionsTo(rightQuantity, customUnitConversions, defaultCachingMode, defaultConstantsReduction)
                .Concat(rightQuantity.GetConversionsTo(leftQuantity, customUnitConversions, rightCacheOptions.CachingMode, rightCacheOptions.ReduceConstants));
        }
        else // using the default options
        {
            return conversion.GetQuantityConversions(customUnitConversions, defaultCachingMode, defaultConstantsReduction);
        }
    }

    private static IEnumerable<ConversionEntry> GetQuantityConversions(this QuantityConversion conversion, ConversionCachingMode cachingMode, bool reduceConstants)
    {
        return cachingMode switch
        {
            ConversionCachingMode.None => [],
            ConversionCachingMode.BaseOnly => conversion.GetConversionsWithBaseUnits(),
            ConversionCachingMode.All => conversion.GetConversionsWithAllUnits(reduceConstants),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static IEnumerable<ConversionEntry> GetConversionsTo(this QuantityInfo fromQuantity, QuantityInfo toQuantity, ConversionCachingMode cachingMode, bool reduceConstants)
    {
        return cachingMode switch
        {
            ConversionCachingMode.None => [],
            ConversionCachingMode.BaseOnly => fromQuantity.GetConversionsWithBaseUnits(toQuantity),
            ConversionCachingMode.All => fromQuantity.GetConversionsWithAllUnits(toQuantity, reduceConstants),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static IEnumerable<ConversionEntry> GetQuantityConversions(this QuantityConversion conversion, QuantityConversionMappingOptions customUnitConversions, ConversionCachingMode cachingMode, bool reduceConstants)
    {
        return conversion.LeftQuantity.GetConversionsTo(conversion.RightQuantity, customUnitConversions, cachingMode, reduceConstants)
            .Concat(conversion.RightQuantity.GetConversionsTo(conversion.LeftQuantity, customUnitConversions, cachingMode, reduceConstants));
    }

    private static IEnumerable<ConversionEntry> GetConversionsTo(this QuantityInfo fromQuantity, QuantityInfo toQuantity, QuantityConversionMappingOptions customUnitConversions,
        ConversionCachingMode cachingMode, bool reduceConstants)
    {
        // filter the customUnitConversions for specified conversion direction
        Type sourceUnitType = fromQuantity.UnitType;
        var unitMappings = customUnitConversions.CustomUnitMappings.Where(x => x.Key.FromUnitKey.UnitType == sourceUnitType)
            .ToDictionary(x => x.Key.FromUnitKey, pair => pair.Value);
        var conversionExpressions = customUnitConversions.ConversionExpressions.Where(x => x.Key.FromUnitKey.UnitType == sourceUnitType)
            .ToDictionary(x => x.Key.FromUnitKey, pair => pair.Value);
        // if there are any custom conversionExpressions we ignore the caching mode and calculate an expression for all units
        if (conversionExpressions.Count != 0)
        {
            return fromQuantity.GetConversionsWithAllUnits(toQuantity, unitMappings, conversionExpressions, reduceConstants);
        }
        
        return cachingMode switch
        {
            ConversionCachingMode.None => fromQuantity.GetConversionsWithCustomUnits(toQuantity, unitMappings, reduceConstants),
            ConversionCachingMode.BaseOnly => fromQuantity.GetConversionsWithBaseUnits(toQuantity, unitMappings, reduceConstants),
            ConversionCachingMode.All => fromQuantity.GetConversionsWithAllUnits(toQuantity, unitMappings, conversionExpressions, reduceConstants),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    private static IEnumerable<ConversionEntry> GetConversionsWithBaseUnits(this QuantityConversion conversion)
    {
        (QuantityInfo leftQuantity, QuantityInfo rightQuantity) = conversion;
        ConvertValueDelegate conversionDelegate = leftQuantity.BaseDimensions.GetConversionDelegate(rightQuantity.BaseDimensions);
        return conversion.LeftQuantity.GetConversionsWithBaseUnits(conversion.RightQuantity, conversionDelegate)
            .Concat(conversion.RightQuantity.GetConversionsWithBaseUnits(conversion.LeftQuantity, conversionDelegate));
    }

    private static IEnumerable<ConversionEntry> GetConversionsWithBaseUnits(this QuantityInfo fromQuantity, QuantityInfo toQuantity)
    {
        return fromQuantity.GetConversionsWithBaseUnits(toQuantity, fromQuantity.BaseDimensions.GetConversionDelegate(toQuantity.BaseDimensions));
    }
    
    private static IEnumerable<ConversionEntry> GetConversionsWithBaseUnits(this QuantityInfo fromQuantity, QuantityInfo toQuantity, ConvertValueDelegate conversionExpression)
    {
        foreach (UnitInfo fromUnit in fromQuantity.UnitInfos)
        {
            if (fromUnit.BaseUnits == BaseUnits.Undefined || !toQuantity.UnitInfos.TryGetUnitWithBase(fromUnit.BaseUnits, out UnitInfo? toUnit))
            {
                continue;
            }

            var conversionKey = new QuantityConversionKey(fromUnit.UnitKey, toQuantity.UnitType);
            var conversionResult = new QuantityConversionFunction(conversionExpression, toUnit.UnitKey);
            yield return new ConversionEntry(conversionKey, conversionResult);
        }
    }

    private static IEnumerable<ConversionEntry> GetConversionsWithAllUnits(this QuantityConversion conversion, bool reduceConstants = true)
    {
        ConversionExpression conversionExpression = conversion.LeftQuantity.BaseDimensions.GetConversionExpression(conversion.RightQuantity.BaseDimensions);

        return conversion.LeftQuantity.GetConversionsWithAllUnits(conversion.RightQuantity, conversionExpression, reduceConstants)
            .Concat(conversion.RightQuantity.GetConversionsWithAllUnits(conversion.LeftQuantity, conversionExpression, reduceConstants));
    }

    private static IEnumerable<ConversionEntry> GetConversionsWithAllUnits(this QuantityInfo fromQuantity, QuantityInfo toQuantity, bool reduceConstants = true)
    {
        return fromQuantity.GetConversionsWithAllUnits(toQuantity, fromQuantity.BaseDimensions.GetConversionExpression(toQuantity.BaseDimensions), reduceConstants);
    }
    
    private static IEnumerable<ConversionEntry> GetConversionsWithAllUnits(this QuantityInfo fromQuantity, QuantityInfo toQuantity, ConversionExpression conversionExpression,
        bool reduceConstants = true)
    {
        foreach (UnitInfo fromUnit in fromQuantity.UnitInfos)
        {
            if (toQuantity.TryGetConversionFrom(fromUnit, conversionExpression, reduceConstants, out QuantityConversionFunction conversionFunction))
            {
                yield return new ConversionEntry(new QuantityConversionKey(fromUnit.UnitKey, conversionFunction.TargetUnit.UnitType), conversionFunction);
            }
            else
            {
                throw InvalidConversionException.CreateIncompatibleUnitsException(fromUnit, toQuantity);
            }
        }
    }

    private static IEnumerable<ConversionEntry> GetConversionsWithCustomUnits(this QuantityInfo fromQuantity, QuantityInfo toQuantity,
        Dictionary<UnitKey, CustomQuantityConversionUnitMapping> unitMappings,
        bool reduceConstants)
    {
        Type targetUnitType = toQuantity.UnitType;
        ConversionExpression conversionWithBaseUnits = fromQuantity.BaseDimensions.GetConversionExpression(toQuantity.BaseDimensions);
        foreach (KeyValuePair<UnitKey, CustomQuantityConversionUnitMapping> unitMapping in unitMappings)
        {
            // a custom target unit was specified for the conversion (without specifying an expression)
            UnitKey fromUnitKey = unitMapping.Key;
            UnitInfo fromUnit = unitMapping.Value.SourceUnit;
            UnitInfo targetUnit = unitMapping.Value.TargetUnit;
            ConversionExpression expressionForUnits = conversionWithBaseUnits.GetExpressionForUnits(fromUnit, targetUnit, reduceConstants);
            var conversionKey = new QuantityConversionKey(fromUnitKey, targetUnitType);
            yield return new ConversionEntry(conversionKey, new QuantityConversionFunction(expressionForUnits, targetUnit.UnitKey));
        }
    }

    private static IEnumerable<ConversionEntry> GetConversionsWithBaseUnits(this QuantityInfo fromQuantity, QuantityInfo toQuantity,
        Dictionary<UnitKey, CustomQuantityConversionUnitMapping> unitMappings,
        bool reduceConstants)
    {
        // no conversion functions provided: constructing the expressions using the BaseDimensions
        Type targetUnitType = toQuantity.UnitType;
        ConversionExpression conversionWithBaseUnits = fromQuantity.BaseDimensions.GetConversionExpression(toQuantity.BaseDimensions);
        IReadOnlyList<UnitInfo> unitInfos = fromQuantity.UnitInfos;
        var nbUnits = unitInfos.Count;
        for (var i = 0; i < nbUnits; i++)
        {
            UnitInfo fromUnit = unitInfos[i];
            var conversionKey = new QuantityConversionKey(fromUnit.UnitKey, targetUnitType);
            if (unitMappings.TryGetValue(conversionKey.FromUnit, out CustomQuantityConversionUnitMapping? customQuantityConversion))
            {
                // a custom target unit was specified for the conversion (without specifying an expression)
                UnitInfo targetUnit = customQuantityConversion.TargetUnit;
                ConversionExpression expressionForUnits = conversionWithBaseUnits.GetExpressionForUnits(fromUnit, targetUnit, reduceConstants);
                yield return new ConversionEntry(conversionKey, new QuantityConversionFunction(expressionForUnits, targetUnit.UnitKey));
            }
            else if (fromUnit.BaseUnits != BaseUnits.Undefined)
            {
                if (toQuantity.TryGetConversionFrom(fromUnit, conversionWithBaseUnits, reduceConstants, out QuantityConversionFunction conversionFunction))
                {
                    yield return new ConversionEntry(conversionKey, conversionFunction);
                }
                else
                {
                    throw InvalidConversionException.CreateIncompatibleUnitsException(fromUnit, toQuantity);
                }
            }
        }
    }
    
    private static IEnumerable<ConversionEntry> GetConversionsWithAllUnits(this QuantityInfo fromQuantity, QuantityInfo toQuantity,
        Dictionary<UnitKey, CustomQuantityConversionUnitMapping> unitMappings,
        Dictionary<UnitKey, CustomQuantityConversionExpressionMapping> conversionExpressions,
        bool reduceConstants)
    {
        // there are two supported scenarios:
        // 1. the two quantities have compatible BaseDimensions (i.e. equal or inverse) and there are units with compatible BaseUnits
        // 2. the conversionOptions provide at least one conversion expression that can be used as the "conversion base" for the rest of the units
        IReadOnlyList<UnitInfo> fromQuantityUnits = fromQuantity.UnitInfos;
        var fromQuantityUnitsCount = fromQuantityUnits.Count;
        if (conversionExpressions.Count == 0)
        {
            // 1. no conversion functions provided: constructing the expressions using the BaseDimensions
            ConversionExpression conversionWithBaseUnits = fromQuantity.BaseDimensions.GetConversionExpression(toQuantity.BaseDimensions);
            for (var i = 0; i < fromQuantityUnitsCount; i++)
            {
                UnitInfo fromUnit = fromQuantityUnits[i];
                var conversionKey = new QuantityConversionKey(fromUnit.UnitKey, toQuantity.UnitType);
                if (unitMappings.TryGetValue(conversionKey.FromUnit, out CustomQuantityConversionUnitMapping? customQuantityConversion))
                {
                    // a custom target unit was specified for the conversion (without specifying an expression)
                    UnitInfo targetUnit = customQuantityConversion.TargetUnit;
                    ConversionExpression expressionForUnits = conversionWithBaseUnits.GetExpressionForUnits(fromUnit, targetUnit, reduceConstants);
                    yield return new ConversionEntry(conversionKey, new QuantityConversionFunction(expressionForUnits, targetUnit.UnitKey));
                }
                else if (toQuantity.TryGetConversionFrom(fromUnit, conversionWithBaseUnits, reduceConstants, out QuantityConversionFunction conversionFunction))
                {
                    yield return new ConversionEntry(conversionKey, conversionFunction);
                }
                else
                {
                    throw InvalidConversionException.CreateIncompatibleUnitsException(fromUnit, toQuantity);
                }
            }
        }
        else
        {
            // 2. an explicit conversion function was provided and will be used as the base for the rest of the units
            CustomQuantityConversionExpressionMapping customConversion = conversionExpressions.First().Value;
            UnitInfo sourceConversionBase = customConversion.SourceUnit;
            UnitInfo targetConversionBase = customConversion.TargetUnit;
            ConversionExpression conversionWithBase = customConversion.ConversionExpression;
            for (var i = 0; i < fromQuantityUnitsCount; i++)
            {
                UnitInfo fromUnit = fromQuantityUnits[i];
                var conversionKey = new QuantityConversionKey(fromUnit.UnitKey, toQuantity.UnitType);
                if (unitMappings.TryGetValue(conversionKey.FromUnit, out CustomQuantityConversionUnitMapping? unitMapping))
                {
                    // a custom target unit was specified for the conversion (without specifying an expression)
                    ConversionExpression conversionToSourceBase = fromUnit.GetUnitConversionExpressionTo(sourceConversionBase, false);
                    ConversionExpression conversionToTargetBase = conversionWithBase.Evaluate(conversionToSourceBase);
                    ConversionExpression conversionToTargetUnit = targetConversionBase.GetUnitConversionExpressionTo(unitMapping.TargetUnit, false);
                    ConversionExpression conversionToTarget = conversionToTargetUnit.Evaluate(conversionToTargetBase, reduceConstants);
                    yield return new ConversionEntry(conversionKey, new QuantityConversionFunction(conversionToTarget, unitMapping.TargetUnit.UnitKey));
                }
                else if (conversionExpressions.TryGetValue(conversionKey.FromUnit, out CustomQuantityConversionExpressionMapping? expressionMapping))
                {
                    // a custom target unit was specified for the conversion (including the corresponding expression)
                    var conversionFunction = new QuantityConversionFunction(expressionMapping.ConversionExpression, expressionMapping.TargetUnit.UnitKey);
                    yield return new ConversionEntry(conversionKey, conversionFunction);
                }
                else
                {
                    // nothing was specified for the conversion: automatically select the target unit
                    ConversionExpression conversionToSourceBase = fromUnit.GetUnitConversionExpressionTo(sourceConversionBase, false);
                    ConversionExpression conversionToTargetBase = conversionWithBase.Evaluate(conversionToSourceBase, reduceConstants);
                    QuantityConversionFunction conversion = toQuantity.GetConversionWithBase(targetConversionBase, conversionToTargetBase, reduceConstants);
                    yield return new ConversionEntry(conversionKey, conversion);
                }
            }
        }
    }

    private static ConversionExpression GetConversionExpression(this BaseDimensions fromDimensions, BaseDimensions toDimensions)
    {
        if (fromDimensions.IsInverseOf(toDimensions))
        {
            return new ConversionExpression(1, null, -1);
        }

        if (fromDimensions == toDimensions)
        {
            return QuantityValue.One;
        }

        // note: technically we could to attempt to work with the powers, but currently there aren't any such cases
        throw InvalidConversionException.CreateIncompatibleDimensionsException(fromDimensions, toDimensions);
    }
    
    private static bool TryGetConversionExpression(this BaseDimensions fromDimensions, BaseDimensions toDimensions, out ConversionExpression conversionExpression)
    {
        if (fromDimensions.IsInverseOf(toDimensions))
        {
            conversionExpression = new ConversionExpression(1, null, -1);
            return true;
        }

        if (fromDimensions == toDimensions)
        {
            conversionExpression = QuantityValue.One;
            return true;
        }

        // note: technically we could to attempt to work with the powers, but currently there aren't any such cases
        conversionExpression = default;
        return false;
    }
    
    private static ConvertValueDelegate GetConversionDelegate(this BaseDimensions fromDimensions, BaseDimensions toDimensions)
    {
        if (fromDimensions.IsInverseOf(toDimensions))
        {
            return QuantityValue.Inverse;
        }

        if (fromDimensions == toDimensions)
        {
            return value => value;
        }

        // note: technically we could to attempt to work with the powers, but currently there aren't any such cases
        throw InvalidConversionException.CreateIncompatibleDimensionsException(fromDimensions, toDimensions);
    }

    /// <summary>
    ///     Retrieves a conversion expression for converting to a target quantity from the unit of another quantity type.
    /// </summary>
    /// <param name="toQuantity">The target quantity information.</param>
    /// <param name="fromUnit">The source unit information.</param>
    /// <param name="reduceConstants">Indicates whether to reduce constants in the conversion expression. Default is true.</param>
    /// <returns>A <see cref="QuantityConversionFunction" /> representing the conversion expression and the target unit key.</returns>
    /// <exception cref="InvalidConversionException">Thrown when no matching base units are found for the conversion operation.</exception>
    /// <remarks>
    ///     This method is optimized for selecting the target unit that is closest in magnitude to the
    ///     <paramref name="fromUnit" />.
    /// </remarks>
    public static QuantityConversionFunction GetQuantityConversionFrom(this QuantityInfo toQuantity, UnitInfo fromUnit, bool reduceConstants = true)
    {
        QuantityInfo fromQuantityInfo = fromUnit.QuantityInfo;
        ConversionExpression conversionExpression = fromQuantityInfo.BaseDimensions.GetConversionExpression(toQuantity.BaseDimensions);

        if (toQuantity.TryGetConversionFrom(fromUnit, conversionExpression, reduceConstants, out QuantityConversionFunction conversionFunction))
        {
            return conversionFunction;
        }
        
        throw InvalidConversionException.CreateIncompatibleUnitsException(fromUnit, toQuantity);
    }

    /// <summary>
    ///     Attempts to get a quantity conversion expression from the specified unit to the target quantity.
    /// </summary>
    /// <param name="toQuantity">The target quantity information.</param>
    /// <param name="fromUnit">The source unit information.</param>
    /// <param name="reduceConstants">Indicates whether to reduce constants in the conversion expression.</param>
    /// <param name="conversionFunction">
    ///     When this method returns, contains the quantity conversion function if the conversion was successful; otherwise,
    ///     <c>null</c>.
    ///     This parameter is passed uninitialized.
    /// </param>
    /// <returns><c>true</c> if the conversion expression was successfully retrieved; otherwise, <c>false</c>.</returns>
    public static bool TryGetQuantityConversionFrom(this QuantityInfo toQuantity, UnitInfo fromUnit, bool reduceConstants,
        out QuantityConversionFunction conversionFunction)
    {
        if (fromUnit.QuantityInfo.BaseDimensions.TryGetConversionExpression(toQuantity.BaseDimensions, out ConversionExpression conversionExpression))
        {
            return toQuantity.TryGetConversionFrom(fromUnit, conversionExpression, reduceConstants, out conversionFunction);
        }

        conversionFunction = default;
        return false;
    }

    private static bool TryGetConversionFrom(this QuantityInfo toQuantity, UnitInfo fromUnit, ConversionExpression conversionWithBase, bool reduceConstants,
        out QuantityConversionFunction conversionFunction)
    {
        QuantityInfo fromQuantityInfo = fromUnit.QuantityInfo;
        if (fromUnit.BaseUnits != BaseUnits.Undefined)
        {
            if (toQuantity.UnitInfos.TryGetUnitWithBase(fromUnit.BaseUnits, out UnitInfo? matchingBaseUnit))
            {
                conversionFunction = new QuantityConversionFunction(conversionWithBase, matchingBaseUnit.UnitKey);
                return true;
            }
        }

        if (fromQuantityInfo.TryGetSIBaseUnit(out UnitInfo? sourceSI) && toQuantity.TryGetSIBaseUnit(out UnitInfo? targetSI))
        {
            ConversionExpression conversionToSI = fromUnit.GetUnitConversionExpressionTo(sourceSI, false);
            ConversionExpression fromUnitToTargetSI = conversionWithBase.Evaluate(conversionToSI, reduceConstants);
            conversionFunction = toQuantity.GetConversionWithBase(targetSI, fromUnitToTargetSI, reduceConstants);
            return true;
        }

        // one of the quantities doesn't have any SI units: attempt find an exactly matching base
        IReadOnlyList<UnitInfo> fromQuantityUnits = fromQuantityInfo.UnitInfos;
        var fromQuantityUnitsCount = fromQuantityUnits.Count;
        for (var i = 0; i < fromQuantityUnitsCount; i++)
        {
            UnitInfo sourceUnit = fromQuantityUnits[i];
            if (sourceUnit.BaseUnits == BaseUnits.Undefined || sourceUnit.BaseUnits == fromUnit.BaseUnits)
            {
                continue;
            }

            if (!toQuantity.UnitInfos.TryGetUnitWithBase(sourceUnit.BaseUnits, out UnitInfo? matchingUnit))
            {
                continue;
            }

            ConversionExpression conversionToUnit = fromUnit.GetUnitConversionExpressionTo(sourceUnit, false);
            ConversionExpression fromUnitToMatchingUnit = conversionWithBase.Evaluate(conversionToUnit, reduceConstants);
            conversionFunction = toQuantity.GetConversionWithBase(matchingUnit, fromUnitToMatchingUnit, reduceConstants);
            return true;
        }

        conversionFunction = default;
        return false;
    }

    private static QuantityConversionFunction GetConversionWithBase(this QuantityInfo quantity, UnitInfo baseUnit, ConversionExpression conversionToBase,
        bool reduceConstants)
    {
        UnitInfo currentlySelectedUnit = baseUnit;
        ConversionExpression conversionToSelectedUnit = conversionToBase;
        QuantityValue currentFactor = GetFactorMagnitude(conversionToBase.Coefficient);
        if (currentFactor == QuantityValue.One)
        {
            return new QuantityConversionFunction(conversionToBase, baseUnit.UnitKey);
        }

        IReadOnlyList<UnitInfo> unitInfos = quantity.UnitInfos;
        var nbUnits = unitInfos.Count;
        for (var i = 0; i < nbUnits; i++)
        {
            UnitInfo toUnitInfo = unitInfos[i];
            if (toUnitInfo == baseUnit)
            {
                continue;
            }

            ConversionExpression fromBaseToUnitConversion = baseUnit.GetUnitConversionExpressionTo(toUnitInfo, false);
            ConversionExpression expressionToUnit = fromBaseToUnitConversion.Evaluate(conversionToBase, reduceConstants);
            QuantityValue expressionFactor = GetFactorMagnitude(expressionToUnit.Coefficient);
            if (expressionFactor >= currentFactor)
            {
                continue;
            }

            currentlySelectedUnit = toUnitInfo;
            conversionToSelectedUnit = expressionToUnit;
            currentFactor = expressionFactor;
            if (currentFactor == QuantityValue.One)
            {
                break; // found the best possible option
            }
        }

        return new QuantityConversionFunction(conversionToSelectedUnit, currentlySelectedUnit.UnitKey);

        static QuantityValue GetFactorMagnitude(QuantityValue conversionFactor)
        {
            conversionFactor = QuantityValue.Abs(conversionFactor);
            return conversionFactor < QuantityValue.One ? QuantityValue.Inverse(conversionFactor) : conversionFactor;
        }
    }

    /// <summary>
    ///     Gets the conversion expression to convert a quantity from the specified unit of the source quantity type to the
    ///     specified unit of the target quantity type.
    /// </summary>
    /// <param name="fromUnitInfo">The unit information of the source quantity type.</param>
    /// <param name="toUnitInfo">The unit information of the target quantity type.</param>
    /// <param name="reduceConstants">
    ///     A boolean value indicating whether to reduce constants in the conversion expression.
    ///     Default is true.
    /// </param>
    /// <returns>
    ///     A <see cref="ConversionExpression" /> representing the conversion from the specified unit of the source quantity
    ///     type to the specified unit of the target quantity type.
    /// </returns>
    /// <exception cref="InvalidOperationException">Thrown when no matching base units are found for the conversion operation.</exception>
    public static ConversionExpression GetQuantityConversionExpressionTo(this UnitInfo fromUnitInfo, UnitInfo toUnitInfo, bool reduceConstants = true)
    {
        ConversionExpression conversionWithBaseUnits = fromUnitInfo.QuantityInfo.BaseDimensions.GetConversionExpression(toUnitInfo.QuantityInfo.BaseDimensions);
        return conversionWithBaseUnits.GetExpressionForUnits(fromUnitInfo, toUnitInfo, reduceConstants);
    }

    private static ConversionExpression GetExpressionForUnits(this ConversionExpression conversionWithBaseUnits, UnitInfo fromUnitInfo, UnitInfo toUnitInfo,
        bool reduceConstants)
    {
        if (fromUnitInfo.BaseUnits != BaseUnits.Undefined && fromUnitInfo.BaseUnits == toUnitInfo.BaseUnits)
        {
            return conversionWithBaseUnits;
        }

        QuantityInfo fromQuantityInfo = fromUnitInfo.QuantityInfo;
        QuantityInfo toQuantityInfo = toUnitInfo.QuantityInfo;
        if (fromQuantityInfo.TryGetSIBaseUnit(out UnitInfo? sourceSI) && toQuantityInfo.TryGetSIBaseUnit(out UnitInfo? targetSI))
        {
            ConversionExpression fromUnitToTargetSI = conversionWithBaseUnits.Evaluate(fromUnitInfo.GetUnitConversionExpressionTo(sourceSI));
            ConversionExpression fromUnitToTargetUnit = targetSI.GetUnitConversionExpressionTo(toUnitInfo).Evaluate(fromUnitToTargetSI, reduceConstants);
            return fromUnitToTargetUnit;
        }

        IReadOnlyList<UnitInfo> fromQuantityUnits = fromQuantityInfo.UnitInfos;
        var fromQuantityUnitsCount = fromQuantityUnits.Count;
        for (var i = 0; i < fromQuantityUnitsCount; i++)
        {
            UnitInfo sourceUnit = fromQuantityUnits[i];
            if (sourceUnit.BaseUnits == BaseUnits.Undefined || !toQuantityInfo.UnitInfos.TryGetUnitWithBase(sourceUnit.BaseUnits, out UnitInfo? matchingUnit))
            {
                continue;
            }

            ConversionExpression fromUnitToMatchingUnit = conversionWithBaseUnits.Evaluate(fromUnitInfo.GetUnitConversionExpressionTo(sourceUnit, false));
            ConversionExpression fromUnitToTargetUnit = matchingUnit.GetUnitConversionExpressionTo(toUnitInfo, false).Evaluate(fromUnitToMatchingUnit, true);
            return fromUnitToTargetUnit;
        }
        
        throw InvalidConversionException.CreateIncompatibleUnitsException(fromUnitInfo, toQuantityInfo);
    }

    /// <summary>
    ///     Attempts to get the conversion expression to convert a quantity from the specified unit of the source quantity type 
    ///     to the specified unit of the target quantity type.
    /// </summary>
    /// <param name="fromUnitInfo">The unit information of the source quantity type.</param>
    /// <param name="toUnitInfo">The unit information of the target quantity type.</param>
    /// <param name="reduceConstants">
    ///     A boolean value indicating whether to reduce constants in the conversion expression.
    ///     Default is true.
    /// </param>
    /// <param name="conversionExpression">
    ///     When this method returns, contains the conversion expression from the specified unit of the source quantity type 
    ///     to the specified unit of the target quantity type, if the conversion is successful; otherwise, null.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the conversion expression was successfully retrieved; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="InvalidOperationException">Thrown when no matching base units are found for the conversion operation.</exception>
    public static bool TryGetQuantityConversionExpressionTo(this UnitInfo fromUnitInfo, UnitInfo toUnitInfo, bool reduceConstants, [NotNullWhen(true)] out ConversionExpression? conversionExpression)
    {
        QuantityInfo fromQuantityInfo = fromUnitInfo.QuantityInfo;
        QuantityInfo toQuantityInfo = toUnitInfo.QuantityInfo;

        if (!fromQuantityInfo.BaseDimensions.TryGetConversionExpression(toQuantityInfo.BaseDimensions, out ConversionExpression quantityConversionExpression))
        {
            conversionExpression = null;
            return false;
        }
        
        if (fromUnitInfo.BaseUnits != BaseUnits.Undefined && fromUnitInfo.BaseUnits == toUnitInfo.BaseUnits)
        {
            conversionExpression = quantityConversionExpression;
            return true;
        }

        if (fromQuantityInfo.TryGetSIBaseUnit(out UnitInfo? sourceSI) && toQuantityInfo.TryGetSIBaseUnit(out UnitInfo? targetSI))
        {
            ConversionExpression fromUnitToTargetSI = quantityConversionExpression.Evaluate(fromUnitInfo.GetUnitConversionExpressionTo(sourceSI));
            conversionExpression = targetSI.GetUnitConversionExpressionTo(toUnitInfo).Evaluate(fromUnitToTargetSI, reduceConstants);
            return true;
        }

        IReadOnlyList<UnitInfo> fromQuantityUnits = fromQuantityInfo.UnitInfos;
        var fromQuantityUnitsCount = fromQuantityUnits.Count;
        for (var i = 0; i < fromQuantityUnitsCount; i++)
        {
            UnitInfo sourceUnit = fromQuantityUnits[i];
            if (sourceUnit.BaseUnits == BaseUnits.Undefined || !toQuantityInfo.UnitInfos.TryGetUnitWithBase(sourceUnit.BaseUnits, out UnitInfo? matchingUnit))
            {
                continue;
            }

            ConversionExpression fromUnitToMatchingUnit = quantityConversionExpression.Evaluate(fromUnitInfo.GetUnitConversionExpressionTo(sourceUnit, false));
            conversionExpression = matchingUnit.GetUnitConversionExpressionTo(toUnitInfo, false).Evaluate(fromUnitToMatchingUnit, true);
            return true;
        }

        conversionExpression = null;
        return false;
    }
}
