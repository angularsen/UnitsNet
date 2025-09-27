using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNet;

internal static class UnitConversionsBuilderExtensions
{
    /// <summary>
    /// Retrieves a collection of conversion expressions for the specified quantities.
    /// </summary>
    /// <param name="quantities">The collection of quantities for which to get conversion expressions.</param>
    /// <param name="cachingMode">The caching mode to use for the conversion expressions.</param>
    /// <param name="reduceConstants">A boolean value indicating whether to reduce constants in the conversion expressions. Defaults to true.</param>
    /// <returns>An enumerable collection of key-value pairs where the key is a <see cref="UnitConversionKey"/> and the value is a <see cref="ConvertValueDelegate"/> representing the conversion expression.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when an invalid caching mode is specified.</exception>
    public static IEnumerable<KeyValuePair<UnitConversionKey, ConvertValueDelegate>> GetUnitConversionFunctions(this IEnumerable<QuantityInfo> quantities, ConversionCachingMode cachingMode, bool reduceConstants = true)
    {
        return cachingMode switch
        {
            ConversionCachingMode.None => [],
            ConversionCachingMode.BaseOnly => quantities.SelectMany(GetBaseConversions),
            ConversionCachingMode.All => quantities.SelectMany(x => GetExpandedConversions(x, reduceConstants)),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    /// <summary>
    /// Retrieves the conversion expressions for the specified quantities, considering the provided caching mode, 
    /// constant reduction option, and custom quantity options.
    /// </summary>
    /// <param name="quantities">The collection of quantity information objects.</param>
    /// <param name="defaultCachingMode">The default caching mode to use if no custom options are specified.</param>
    /// <param name="defaultConstantsReduction">Indicates whether to reduce constants by default.</param>
    /// <param name="customQuantityOptions">A dictionary of custom quantity options, keyed by quantity type.</param>
    /// <returns>An enumerable of key-value pairs, where the key is a <see cref="UnitConversionKey"/> and the value is a <see cref="ConvertValueDelegate"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when an invalid caching mode is encountered.</exception>
    public static IEnumerable<KeyValuePair<UnitConversionKey, ConvertValueDelegate>> GetUnitConversionFunctions(this IEnumerable<QuantityInfo> quantities, ConversionCachingMode defaultCachingMode, bool defaultConstantsReduction,
        IReadOnlyDictionary<Type, ConversionCacheOptions> customQuantityOptions)
    {
        if (customQuantityOptions.Count == 0)
        {
            return quantities.GetUnitConversionFunctions(defaultCachingMode, defaultConstantsReduction);
        }

        return quantities.SelectMany(quantityInfo =>
            customQuantityOptions.TryGetValue(quantityInfo.QuantityType, out ConversionCacheOptions? customCacheOptions)
                ? customCacheOptions.CachingMode switch
                {
                    ConversionCachingMode.None => [],
                    ConversionCachingMode.BaseOnly => GetBaseConversions(quantityInfo),
                    ConversionCachingMode.All => GetExpandedConversions(quantityInfo, customCacheOptions.ReduceConstants),
                    _ => throw new ArgumentOutOfRangeException()
                }
                : defaultCachingMode switch
                {
                    ConversionCachingMode.None => [],
                    ConversionCachingMode.BaseOnly => GetBaseConversions(quantityInfo),
                    ConversionCachingMode.All => GetExpandedConversions(quantityInfo, defaultConstantsReduction),
                    _ => throw new ArgumentOutOfRangeException()
                });
    }

    private static IEnumerable<KeyValuePair<UnitConversionKey, ConvertValueDelegate>> GetExpandedConversions(QuantityInfo quantityInfo, bool reduceConstants)
    {
        UnitInfo baseUnit = quantityInfo.BaseUnitInfo;
        UnitKey baseUnitKey = baseUnit.UnitKey;
        IReadOnlyList<UnitInfo> unitInfos = quantityInfo.UnitInfos;
        var nbUnits = unitInfos.Count;
        for (var i = 0; i < nbUnits; i++)
        {
            UnitInfo fromUnit = unitInfos[i];
            if (fromUnit == baseUnit)
            {
                foreach (KeyValuePair<UnitConversionKey, ConvertValueDelegate> keyValuePair in GetConversionsWithBase(quantityInfo, baseUnit, baseUnitKey))
                {
                    yield return keyValuePair;
                }
            }
            else
            {
                UnitKey fromUnitKey = fromUnit.UnitKey;
                // yield return new UnitConversionMapping(UnitConversionKey.ToSelf(fromUnitKey), value => value);
                for (var p = 0; p < nbUnits; p++)
                {
                    if (i == p) continue;
                    UnitInfo toUnit = unitInfos[p];
                    if (toUnit == baseUnit)
                    {
                        continue;
                    }

                    var conversionKey = UnitConversionKey.Create(fromUnitKey, toUnit.UnitKey);
                    ConversionExpression conversion = toUnit.ConversionFromBase.Evaluate(fromUnit.ConversionToBase, reduceConstants);
                    yield return new KeyValuePair<UnitConversionKey, ConvertValueDelegate>(conversionKey, conversion);
                }
            }
        }
    }

    private static IEnumerable<KeyValuePair<UnitConversionKey, ConvertValueDelegate>> GetBaseConversions(QuantityInfo quantityInfo)
    {
        return GetConversionsWithBase(quantityInfo, quantityInfo.BaseUnitInfo, quantityInfo.BaseUnitInfo.UnitKey);
    }

    private static IEnumerable<KeyValuePair<UnitConversionKey, ConvertValueDelegate>> GetConversionsWithBase(QuantityInfo quantityInfo, UnitInfo baseUnit, UnitKey baseUnitKey)
    {
        IReadOnlyList<UnitInfo> unitInfos = quantityInfo.UnitInfos;
        var nbUnits = unitInfos.Count;
        for (var i = 0; i < nbUnits; i++)
        {
            UnitInfo unit = unitInfos[i];
            if (unit == baseUnit)
            {
                continue; // yield return new UnitConversionMapping(UnitConversionKey.ToSelf(baseUnitKey), value => value);
            }

            UnitKey unitKey = unit.UnitKey;
            yield return new KeyValuePair<UnitConversionKey, ConvertValueDelegate>(UnitConversionKey.Create(baseUnitKey, unitKey), unit.ConversionFromBase);
            yield return new KeyValuePair<UnitConversionKey, ConvertValueDelegate>(UnitConversionKey.Create(unitKey, baseUnitKey), unit.ConversionToBase);
        }
    }
    
    /// <summary>
    ///     Gets the conversion expression between two units.
    /// </summary>
    /// <param name="fromUnitInfo">The unit information of the source unit.</param>
    /// <param name="toUnitInfo">The unit information of the target unit.</param>
    /// <param name="reduceConstants">
    ///     Indicates whether to reduce constants in the conversion expression. Defaults to
    ///     <c>true</c>.
    /// </param>
    /// <returns>A <see cref="ConversionExpression" /> representing the conversion from the source unit to the target unit.</returns>
    /// <remarks>
    ///     If the source unit is the base unit, the conversion from the base unit to the target unit is returned.
    ///     If the target unit is the base unit, the conversion from the source unit to the base unit is returned.
    ///     Otherwise, the conversion is evaluated using the conversion expressions from the source unit to the base unit and
    ///     from the base unit to the target unit.
    /// </remarks>
    internal static ConversionExpression GetUnitConversionExpressionTo(this UnitInfo fromUnitInfo, UnitInfo toUnitInfo, bool reduceConstants = true)
    {
        // if we're here, then units are very likely to be different
        UnitInfo baseUnit = fromUnitInfo.QuantityInfo.BaseUnitInfo;
        if (fromUnitInfo == baseUnit)
        {
            return toUnitInfo.ConversionFromBase;
        }

        if (toUnitInfo == baseUnit)
        {
            return fromUnitInfo.ConversionToBase;
        }

        return toUnitInfo.ConversionFromBase.Evaluate(fromUnitInfo.ConversionToBase, reduceConstants);
    }
}
