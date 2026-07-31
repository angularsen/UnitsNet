// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnitsNet.Units;

namespace UnitsNet;

/// <summary>
///     Provides extension methods for filtering and retrieving unit information based on base units.
/// </summary>
internal static class QuantityInfoExtensions
{
    /// <summary>
    ///     Get a list of quantities having the given base dimensions.
    /// </summary>
    /// <param name="quantityInfos">The type of quantity mapping information.</param>
    /// <param name="baseDimensions">The base dimensions to match.</param>
    public static IEnumerable<QuantityInfo> GetQuantitiesWithBaseDimensions(this IEnumerable<QuantityInfo> quantityInfos,
        BaseDimensions baseDimensions)
    {
        if (baseDimensions is null)
        {
            throw new ArgumentNullException(nameof(baseDimensions));
        }

        return quantityInfos.Where(info => info.BaseDimensions.Equals(baseDimensions));
    }

    /// <summary>
    ///     Retrieves the default unit for a specified quantity and unit system.
    /// </summary>
    /// <typeparam name="TQuantity">The type of the quantity, which implements <see cref="IQuantity{TSelf, TUnitType}" />.</typeparam>
    /// <typeparam name="TUnit">The type of the unit, which is a value type and an enumeration.</typeparam>
    /// <param name="quantityInfo">
    ///     The <see cref="QuantityInfo{TQuantity, TUnit}" /> instance containing information about the
    ///     quantity.
    /// </param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> for which the default unit is to be retrieved.</param>
    /// <returns>The default unit of type <typeparamref name="TUnit" /> for the specified quantity and unit system.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitSystem" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when no units are found for the given <paramref name="unitSystem" />.</exception>
    internal static TUnit GetDefaultUnit<TQuantity, TUnit>(this QuantityInfo<TQuantity, TUnit> quantityInfo, UnitSystem unitSystem)
        where TQuantity : IQuantity<TQuantity, TUnit>
        where TUnit : struct, Enum
    {
        if (unitSystem is null)
        {
            throw new ArgumentNullException(nameof(unitSystem));
        }

        if (quantityInfo.BaseDimensions.IsDimensionless())
        {
            return quantityInfo.BaseUnitInfo.Value;
        }

        IEnumerable<UnitInfo<TQuantity, TUnit>> unitInfos = quantityInfo.GetUnitInfosFor(unitSystem.BaseUnits);

        UnitInfo<TQuantity, TUnit>? firstUnitInfo = unitInfos.FirstOrDefault();
        if (firstUnitInfo == null)
        {
            throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));
        }

        return firstUnitInfo.Value;
    }

    /// <summary>
    ///     Retrieves the default unit for a specified quantity and unit system.
    /// </summary>
    /// <param name="quantityInfo">
    ///     The <see cref="QuantityInfo{TQuantity, TUnit}" /> instance containing information about the
    ///     quantity.
    /// </param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> for which the default unit is to be retrieved.</param>
    /// <returns>The default unit information for the specified quantity and unit system.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitSystem" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when no units are found for the given <paramref name="unitSystem" />.</exception>
    internal static UnitInfo GetDefaultUnit(this QuantityInfo quantityInfo, UnitSystem unitSystem)
    {
        if (unitSystem is null)
        {
            throw new ArgumentNullException(nameof(unitSystem));
        }

        if (quantityInfo.BaseDimensions.IsDimensionless())
        {
            return quantityInfo.BaseUnitInfo;
        }

        IEnumerable<UnitInfo> unitInfos = quantityInfo.GetUnitInfosFor(unitSystem.BaseUnits);

        UnitInfo? firstUnitInfo = unitInfos.FirstOrDefault();
        if (firstUnitInfo == null)
        {
            throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));
        }

        return firstUnitInfo;
    }

    /// <summary>
    ///     Retrieves the default unit for a specified quantity and unit system.
    /// </summary>
    /// <param name="quantityInfo">
    ///     The <see cref="QuantityInfo{TQuantity, TUnit}" /> instance containing information about the
    ///     quantity.
    /// </param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> for which the default unit is to be retrieved.</param>
    /// <returns>The default unit information for the specified quantity and unit system.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitSystem" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when no units are found for the given <paramref name="unitSystem" />.</exception>
    internal static UnitInfo<TUnit> GetDefaultUnit<TUnit>(this QuantityInfo<TUnit> quantityInfo, UnitSystem unitSystem)
        where TUnit : struct, Enum
    {
        if (unitSystem is null)
        {
            throw new ArgumentNullException(nameof(unitSystem));
        }

        if (quantityInfo.BaseDimensions.IsDimensionless())
        {
            return quantityInfo.BaseUnitInfo;
        }

        IEnumerable<UnitInfo<TUnit>> unitInfos = quantityInfo.GetUnitInfosFor(unitSystem.BaseUnits);

        UnitInfo<TUnit>? firstUnitInfo = unitInfos.FirstOrDefault();
        if (firstUnitInfo == null)
        {
            throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));
        }

        return firstUnitInfo;
    }

    /// <summary>
    ///     Attempts to find a unit that matches the specified base units from a collection of units.
    /// </summary>
    /// <typeparam name="TUnitInfo">The type of the unit information, which must implement <see cref="UnitInfo" />.</typeparam>
    /// <param name="units">The collection of units to search through.</param>
    /// <param name="baseUnits">The base units to match against.</param>
    /// <param name="matchingUnit">
    ///     When this method returns, contains the unit that matches the specified base units, if found;
    ///     otherwise, the default value for the type of the <paramref name="matchingUnit" /> parameter.
    ///     This parameter is passed uninitialized.
    /// </param>
    /// <returns><c>true</c> if a unit matching the specified base units is found; otherwise, <c>false</c>.</returns>
    internal static bool TryGetUnitWithBase<TUnitInfo>(this IReadOnlyList<TUnitInfo> units, BaseUnits baseUnits, [NotNullWhen(true)] out TUnitInfo? matchingUnit)
        where TUnitInfo : UnitInfo
    {
        var nbUnits = units.Count;
        for (var i = 0; i < nbUnits; i++)
        {
            TUnitInfo unitInfo = units[i];
            if (unitInfo.BaseUnits == baseUnits)
            {
                matchingUnit = unitInfo;
                return true;
            }
        }

        matchingUnit = null;
        return false;
    }

    /// <summary>
    ///     Converts a value from one unit to another unit within the same quantity.
    /// </summary>
    /// <param name="toUnit">The target unit information to which the value will be converted.</param>
    /// <param name="value">The value to be converted.</param>
    /// <param name="fromUnit">The source unit information from which the value will be converted.</param>
    /// <returns>The converted value in the target unit.</returns>
    /// <remarks>
    ///     Since we cannot constrain the units to be of the same quantity, I think it is better to keep this overload
    ///     internal.
    /// </remarks>
    internal static QuantityValue GetValueFrom(this UnitInfo toUnit, QuantityValue value, UnitInfo fromUnit)
    {
        if (fromUnit == toUnit)
        {
            return value;
        }

        UnitInfo baseUnit = toUnit.QuantityInfo.BaseUnitInfo;
        if (toUnit == baseUnit)
        {
            return fromUnit.ConversionToBase.Evaluate(value);
        }

        if (fromUnit == baseUnit)
        {
            return toUnit.ConversionFromBase.Evaluate(value);
        }

        QuantityValue valueInBase = fromUnit.ConversionToBase.Evaluate(value);
        return toUnit.ConversionFromBase.Evaluate(valueInBase);
    }

    /// <summary>
    ///     Converts a given value from a specified unit to the base unit of the quantity.
    /// </summary>
    /// <param name="fromUnit">The unit from which the value is to be converted.</param>
    /// <param name="value">The value to be converted.</param>
    /// <returns>The value converted to the base unit of the quantity.</returns>
    internal static QuantityValue ConvertValueToBaseUnit(this UnitInfo fromUnit, QuantityValue value)
    {
        return fromUnit == fromUnit.QuantityInfo.BaseUnitInfo ? value : fromUnit.ConversionToBase.Evaluate(value);
    }

    /// <summary>
    ///     Converts a value from the base unit to the specified unit.
    /// </summary>
    /// <param name="toUnit">The unit to convert the value to.</param>
    /// <param name="value">The value in the base unit to be converted.</param>
    /// <returns>The converted value in the specified unit.</returns>
    internal static QuantityValue ConvertValueFromBaseUnit(this UnitInfo toUnit, QuantityValue value)
    {
        return toUnit == toUnit.QuantityInfo.BaseUnitInfo ? value : toUnit.ConversionFromBase.Evaluate(value);
    }

    /// <summary>
    ///     Retrieves the quantities that are connected to the specified <paramref name="quantityInfo" />
    ///     through the provided collection of <see cref="QuantityConversion" /> instances.
    /// </summary>
    /// <param name="conversions">
    ///     The collection of <see cref="QuantityConversion" /> instances to search for conversions.
    /// </param>
    /// <param name="quantityInfo">
    ///     The <see cref="QuantityInfo" /> for which to find connected quantities.
    /// </param>
    /// <returns>
    ///     An enumerable of <see cref="QuantityInfo" /> instances that are connected to the specified
    ///     <paramref name="quantityInfo" /> through the provided conversions.
    /// </returns>
    internal static IEnumerable<QuantityInfo> GetConversionsFrom(this IEnumerable<QuantityConversion> conversions, QuantityInfo quantityInfo)
    {
        foreach (QuantityConversion conversion in conversions)
        {
            if (conversion.LeftQuantity == quantityInfo)
            {
                yield return conversion.RightQuantity;
            }
            else if (conversion.RightQuantity == quantityInfo)
            {
                yield return conversion.LeftQuantity;
            }
        }
    }

    /// <summary>
    ///     Attempts to retrieve the SI base unit for the specified quantity.
    /// </summary>
    /// <param name="quantityInfo">The quantity information to search within.</param>
    /// <param name="matchingUnitInfo">
    ///     When this method returns, contains the SI base unit if found; otherwise, <c>null</c>.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the SI base unit is found; otherwise, <c>false</c>.
    /// </returns>
    internal static bool TryGetSIBaseUnit(this QuantityInfo quantityInfo, [NotNullWhen(true)] out UnitInfo? matchingUnitInfo)
    {
        if (quantityInfo.BaseDimensions.IsDimensionless() ||
            quantityInfo.BaseUnitInfo.BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits)) // this should be the default case
        {
            matchingUnitInfo = quantityInfo.BaseUnitInfo;
            return true;
        }

        return quantityInfo.UnitInfos.TryGetUnitWithBase(UnitSystem.SI.BaseUnits, out matchingUnitInfo);
    }
    
    /// <summary>
    ///     Attempts to convert a quantity value from a source unit to a target quantity type and unit.
    /// </summary>
    /// <typeparam name="TTargetQuantity">The target quantity type.</typeparam>
    /// <typeparam name="TTargetUnit">The target unit type.</typeparam>
    /// <param name="sourceUnit">The source unit information.</param>
    /// <param name="sourceValue">The source quantity value.</param>
    /// <param name="targetQuantityInfo">The target quantity information.</param>
    /// <param name="result">
    ///     When this method returns, contains the converted quantity value if the conversion succeeded,
    ///     or the default value of <typeparamref name="TTargetQuantity" /> if the conversion failed.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the conversion succeeded; otherwise, <c>false</c>.
    /// </returns>
    internal static bool TryConvertFrom<TTargetQuantity, TTargetUnit>(this QuantityInfo<TTargetQuantity, TTargetUnit> targetQuantityInfo,
        QuantityValue sourceValue, UnitInfo sourceUnit, [NotNullWhen(true)] out TTargetQuantity? result)
        where TTargetQuantity : IQuantity<TTargetQuantity, TTargetUnit>
        where TTargetUnit : struct, Enum
    {
        ConvertValueDelegate conversionExpression;
        QuantityInfo sourceQuantityInfo = sourceUnit.QuantityInfo;
        if (sourceQuantityInfo.BaseDimensions.IsInverseOf(targetQuantityInfo.BaseDimensions))
        {
            conversionExpression = QuantityValue.Inverse;
        }
        else if (sourceQuantityInfo.BaseDimensions == targetQuantityInfo.BaseDimensions)
        {
            if (targetQuantityInfo.BaseDimensions.IsDimensionless())
            {
                QuantityValue dimensionlessValue = sourceUnit.ConvertValueToBaseUnit(sourceValue);
                result = targetQuantityInfo.From(dimensionlessValue, targetQuantityInfo.BaseUnitInfo.Value);
                return true;
            }

            conversionExpression = value => value;
        }
        else
        {
            result = default;
            return false;
        }

        UnitInfo sourceBaseUnit = sourceQuantityInfo.BaseUnitInfo;
        if (sourceUnit.BaseUnits != BaseUnits.Undefined && sourceUnit.BaseUnits != sourceBaseUnit.BaseUnits)
        {
            if (targetQuantityInfo.UnitInfos.TryGetUnitWithBase(sourceUnit.BaseUnits, out UnitInfo<TTargetQuantity, TTargetUnit>? targetUnit))
            {
                result = targetUnit.From(conversionExpression(sourceValue));
                return true;
            }
        }

        if (sourceBaseUnit.BaseUnits != BaseUnits.Undefined)
        {
            // attempt to convert via the base (typically SI) unit
            if (targetQuantityInfo.BaseUnitInfo.BaseUnits == sourceBaseUnit.BaseUnits)
            {
                QuantityValue convertedValue = conversionExpression(sourceUnit.ConvertValueToBaseUnit(sourceValue));
                result = targetQuantityInfo.BaseUnitInfo.From(convertedValue);
                return true;
            }

            // attempt to find another unit that matches the source base
            if (targetQuantityInfo.UnitInfos.TryGetUnitWithBase(sourceBaseUnit.BaseUnits, out UnitInfo<TTargetQuantity, TTargetUnit>? targetUnit))
            {
                QuantityValue convertedValue = conversionExpression(sourceUnit.ConvertValueToBaseUnit(sourceValue));
                result = targetUnit.From(convertedValue);
                return true;
            }
        }

        // no compatible units found with either the sourceUnit or the sourceBaseUnit: looking for intersections with any of the other units
        IReadOnlyList<UnitInfo> sourceUnits = sourceQuantityInfo.UnitInfos;
        var nbSourceUnits = sourceUnits.Count;
        for (var i = 0; i < nbSourceUnits; i++)
        {
            UnitInfo otherUnit = sourceUnits[i];
            if (otherUnit.BaseUnits == BaseUnits.Undefined ||
                otherUnit.BaseUnits == sourceUnit.BaseUnits ||
                otherUnit.BaseUnits == sourceBaseUnit.BaseUnits)
            {
                continue;
            }

            if (targetQuantityInfo.UnitInfos.TryGetUnitWithBase(otherUnit.BaseUnits, out UnitInfo<TTargetQuantity, TTargetUnit>? targetUnit))
            {
                QuantityValue convertedValue = conversionExpression(otherUnit.GetValueFrom(sourceValue, sourceUnit));
                result = targetUnit.From(convertedValue);
                return true;
            }
        }

        result = default;
        return false;
    }
    
    /// <summary>
    ///     Converts a quantity value from a source unit to a target quantity.
    /// </summary>
    /// <param name="targetQuantityInfo">The target quantity information.</param>
    /// <param name="sourceValue">The value of the source quantity.</param>
    /// <param name="sourceUnit">The unit of the source quantity.</param>
    /// <returns>The converted quantity.</returns>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when the dimensions of the source quantity are not compatible with the dimensions of the target quantity,
    ///     or when no compatible base units are found for the conversion.
    /// </exception>
    internal static TTargetQuantity ConvertFrom<TTargetQuantity, TTargetUnit>(this QuantityInfo<TTargetQuantity, TTargetUnit> targetQuantityInfo, QuantityValue sourceValue, UnitInfo sourceUnit)
        where TTargetQuantity : IQuantity<TTargetQuantity, TTargetUnit>
        where TTargetUnit : struct, Enum
    {
        if(targetQuantityInfo.TryConvertFrom(sourceValue, sourceUnit, out TTargetQuantity? convertedValue))
        {
            return convertedValue;
        }

        QuantityInfo sourceQuantityInfo = sourceUnit.QuantityInfo;
        if (sourceQuantityInfo.BaseDimensions != targetQuantityInfo.BaseDimensions &&
            !sourceQuantityInfo.BaseDimensions.IsInverseOf(targetQuantityInfo.BaseDimensions))
        {
            throw InvalidConversionException.CreateIncompatibleDimensionsException(sourceQuantityInfo, targetQuantityInfo);
        }
        
        throw InvalidConversionException.CreateIncompatibleUnitsException(sourceUnit, targetQuantityInfo);
    }
    
    /// <summary>
    ///     Attempts to convert a quantity value from one unit to another within the specified target quantity information.
    /// </summary>
    /// <param name="sourceUnit">The source unit information.</param>
    /// <param name="sourceValue">The value in the source unit to be converted.</param>
    /// <param name="targetQuantityInfo">The target quantity information to which the value should be converted.</param>
    /// <param name="result">
    ///     When this method returns, contains the converted quantity if the conversion succeeded, or <c>null</c> if the
    ///     conversion failed.
    ///     This parameter is passed uninitialized.
    /// </param>
    /// <returns><c>true</c> if the conversion succeeded; otherwise, <c>false</c>.</returns>
    internal static bool TryConvertFrom(this QuantityInfo targetQuantityInfo, QuantityValue sourceValue,
        UnitInfo sourceUnit, [NotNullWhen(true)] out IQuantity? result)
    {
        ConvertValueDelegate conversionExpression;
        QuantityInfo sourceQuantityInfo = sourceUnit.QuantityInfo;
        if (sourceQuantityInfo.BaseDimensions.IsInverseOf(targetQuantityInfo.BaseDimensions))
        {
            conversionExpression = QuantityValue.Inverse;
        }
        else if (sourceQuantityInfo.BaseDimensions == targetQuantityInfo.BaseDimensions)
        {
            if (targetQuantityInfo.BaseDimensions.IsDimensionless())
            {
                QuantityValue dimensionlessValue = sourceUnit.ConvertValueToBaseUnit(sourceValue);
                result = targetQuantityInfo.BaseUnitInfo.From(dimensionlessValue);
                return true;
            }

            conversionExpression = value => value;
        }
        else
        {
            result = null;
            return false;
        }

        UnitInfo sourceBaseUnit = sourceQuantityInfo.BaseUnitInfo;
        if (sourceUnit.BaseUnits != BaseUnits.Undefined && sourceUnit.BaseUnits != sourceBaseUnit.BaseUnits)
        {
            if (targetQuantityInfo.UnitInfos.TryGetUnitWithBase(sourceUnit.BaseUnits, out UnitInfo? targetUnit))
            {
                result = targetUnit.From(conversionExpression(sourceValue));
                return true;
            }
        }

        if (sourceBaseUnit.BaseUnits != BaseUnits.Undefined)
        {
            // attempt to convert via the base (typically SI) unit
            if (targetQuantityInfo.BaseUnitInfo.BaseUnits == sourceBaseUnit.BaseUnits)
            {
                QuantityValue convertedValue = conversionExpression(sourceUnit.ConvertValueToBaseUnit(sourceValue));
                result = targetQuantityInfo.BaseUnitInfo.From(convertedValue);
                return true;
            }

            // attempt to find another unit that matches the source base
            if (targetQuantityInfo.UnitInfos.TryGetUnitWithBase(sourceBaseUnit.BaseUnits, out UnitInfo? targetUnit))
            {
                QuantityValue convertedValue = conversionExpression(sourceUnit.ConvertValueToBaseUnit(sourceValue));
                result = targetUnit.From(convertedValue);
                return true;
            }
        }

        // no compatible units found with either the sourceUnit or the sourceBaseUnit: looking for intersections with any of the other units
        IReadOnlyList<UnitInfo> sourceUnits = sourceQuantityInfo.UnitInfos;
        var nbSourceUnits = sourceUnits.Count;
        for (var i = 0; i < nbSourceUnits; i++)
        {
            UnitInfo otherUnit = sourceUnits[i];
            if (otherUnit.BaseUnits == BaseUnits.Undefined ||
                otherUnit.BaseUnits == sourceUnit.BaseUnits ||
                otherUnit.BaseUnits == sourceBaseUnit.BaseUnits)
            {
                continue;
            }

            if (targetQuantityInfo.UnitInfos.TryGetUnitWithBase(otherUnit.BaseUnits, out UnitInfo? targetUnit))
            {
                QuantityValue convertedValue = conversionExpression(otherUnit.GetValueFrom(sourceValue, sourceUnit));
                result = targetUnit.From(convertedValue);
                return true;
            }
        }

        result = null;
        return false;
    }

    /// <summary>
    ///     Converts a quantity value from a source unit to a target quantity.
    /// </summary>
    /// <param name="targetQuantityInfo">The target quantity information.</param>
    /// <param name="sourceValue">The value of the source quantity.</param>
    /// <param name="sourceUnit">The unit of the source quantity.</param>
    /// <returns>The converted quantity.</returns>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when the dimensions of the source quantity are not compatible with the dimensions of the target quantity,
    ///     or when no compatible base units are found for the conversion.
    /// </exception>
    internal static IQuantity ConvertFrom(this QuantityInfo targetQuantityInfo, QuantityValue sourceValue, UnitInfo sourceUnit)
    {
        if(targetQuantityInfo.TryConvertFrom(sourceValue, sourceUnit, out IQuantity? convertedValue))
        {
            return convertedValue;
        }

        QuantityInfo sourceQuantityInfo = sourceUnit.QuantityInfo;
        if (sourceQuantityInfo.BaseDimensions != targetQuantityInfo.BaseDimensions &&
            !sourceQuantityInfo.BaseDimensions.IsInverseOf(targetQuantityInfo.BaseDimensions))
        {
            throw InvalidConversionException.CreateIncompatibleDimensionsException(sourceQuantityInfo, targetQuantityInfo);
        }

        throw InvalidConversionException.CreateIncompatibleUnitsException(sourceUnit, targetQuantityInfo);
    }

    internal static bool IsInverseOf(this BaseDimensions first, BaseDimensions second)
    {
        if (first.Amount != -second.Amount)
        {
            return false;
        }

        if (first.Current != -second.Current)
        {
            return false;
        }

        if (first.Length != -second.Length)
        {
            return false;
        }

        if (first.Mass != -second.Mass)
        {
            return false;
        }

        if (first.LuminousIntensity != -second.LuminousIntensity)
        {
            return false;
        }

        if (first.Temperature != -second.Temperature)
        {
            return false;
        }

        if (first.Time != -second.Time)
        {
            return false;
        }

        return !first.IsDimensionless();
    }
}
