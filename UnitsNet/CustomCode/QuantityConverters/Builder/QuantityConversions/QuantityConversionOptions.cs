// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;

namespace UnitsNet;

internal record CustomQuantityConversionUnitMapping
{
    public CustomQuantityConversionUnitMapping(UnitInfo sourceUnit, UnitInfo targetUnit)
    {
        SourceUnit = sourceUnit;
        TargetUnit = targetUnit;
    }

    public UnitInfo SourceUnit { get; }
    public UnitInfo TargetUnit { get; }
}

internal record CustomQuantityConversionExpressionMapping
{
    public CustomQuantityConversionExpressionMapping(UnitInfo sourceUnit, UnitInfo targetUnit, ConversionExpression conversionExpression)
    {
        TargetUnit = targetUnit;
        ConversionExpression = conversionExpression;
        SourceUnit = sourceUnit;
    }

    public UnitInfo SourceUnit { get; }
    public UnitInfo TargetUnit { get; }
    public ConversionExpression ConversionExpression { get; }
}

internal sealed class QuantityConversionMappingOptions
{
    internal Dictionary<UnitConversionMapping, CustomQuantityConversionUnitMapping> CustomUnitMappings { get; } = [];
    internal Dictionary<UnitConversionMapping, CustomQuantityConversionExpressionMapping> ConversionExpressions { get; } = [];
}

/// <summary>
///     Represents options for configuring implicit conversions between different quantities and units.
///     This class allows the specification of custom conversions and conversion units to be used during implicit
///     conversions.
/// </summary>
public sealed class QuantityConversionOptions
{
    internal HashSet<QuantityConversionMapping> CustomConversions { get; } = [];

    internal HashSet<UnitConversionMapping> ConversionUnits { get; } = [];
    
    internal Dictionary<UnitConversionMapping, ConversionExpression> CustomConversionFunctions { get; } = new();

    /// <summary>
    ///     Adds a custom conversion between two quantities to the implicit conversion options.
    /// </summary>
    /// <typeparam name="TFromQuantity">The type of the quantity to convert from.</typeparam>
    /// <typeparam name="TToQuantity">The type of the quantity to convert to.</typeparam>
    /// <returns>
    ///     The current instance of <see cref="QuantityConversionOptions" /> with the specified custom conversion configured.
    /// </returns>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when attempting to map conversion units for different quantities using the same quantity type.
    /// </exception>
    /// <remarks>
    ///     The association is created in both directions.
    /// </remarks>
    public QuantityConversionOptions SetCustomConversion<TFromQuantity, TToQuantity>()
        where TFromQuantity : IQuantity
        where TToQuantity : IQuantity
    {
        if (typeof(TFromQuantity) == typeof(TToQuantity))
        {
            throw new InvalidConversionException(
                $"Mapping conversion units for different quantities using the same quantity type ({typeof(TFromQuantity).Name}) is not allowed.");
        }

        CustomConversions.Add(QuantityConversionMapping.Create<TFromQuantity, TToQuantity>());
        return this;
    }

    /// <summary>
    ///     Configures the implicit conversion options by specifying the units to be used for conversion.
    /// </summary>
    /// <typeparam name="TFromUnit">The type of the unit to convert from, which must be a struct and an enumeration.</typeparam>
    /// <typeparam name="TToUnit">The type of the unit to convert to, which must be a struct and an enumeration.</typeparam>
    /// <param name="fromUnit">The unit to convert from.</param>
    /// <param name="toUnit">The unit to convert to.</param>
    /// <param name="mapBothDirections">
    ///     A boolean value indicating whether the conversion should be bidirectional. If true, the conversion
    ///     will be configured in both directions.
    /// </param>
    /// <returns>
    ///     The current instance of <see cref="QuantityConversionOptions" /> with the specified conversion units
    ///     configured.
    /// </returns>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when attempting to map conversion units for different quantities using the same unit type.
    /// </exception>
    public QuantityConversionOptions SetConversionUnits<TFromUnit, TToUnit>(TFromUnit fromUnit, TToUnit toUnit, bool mapBothDirections = false)
        where TFromUnit : struct, Enum
        where TToUnit : struct, Enum
    {
        if (typeof(TFromUnit) == typeof(TToUnit))
        {
            throw new InvalidConversionException(
                $"Mapping conversion units for different quantities using the same unit type ({typeof(TFromUnit).Name}) is not allowed.");
        }

        var fromUnitConversionKey = UnitConversionMapping.Create(fromUnit, toUnit);
        ConversionUnits.Add(fromUnitConversionKey);
        if (mapBothDirections)
        {
            ConversionUnits.Add(new UnitConversionMapping(fromUnitConversionKey.ToUnitKey, fromUnitConversionKey.FromUnitKey));
        }

        return this;
    }

    /// <summary>
    ///     Adds a custom conversion function between two specified units.
    /// </summary>
    /// <typeparam name="TFromUnit">The type of the source unit, which must be a struct and an enumeration.</typeparam>
    /// <typeparam name="TToUnit">The type of the target unit, which must be a struct and an enumeration.</typeparam>
    /// <param name="fromUnit">The source unit to convert from.</param>
    /// <param name="toUnit">The target unit to convert to.</param>
    /// <param name="conversionFunction">The function that performs the conversion from the source unit to the target unit.</param>
    /// <returns>The current <see cref="QuantityConversionOptions" /> instance with the custom conversion added.</returns>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when attempting to map conversion units for different quantities using the same unit type.
    /// </exception>
    /// <remarks>
    ///     This method allows you to define a custom conversion function between two units, enabling precise control over the
    ///     conversion process.
    /// </remarks>
    public QuantityConversionOptions SetCustomConversion<TFromUnit, TToUnit>(TFromUnit fromUnit, TToUnit toUnit, ConvertValueDelegate conversionFunction)
        where TFromUnit : struct, Enum
        where TToUnit : struct, Enum
    {
        return SetCustomConversion(fromUnit, toUnit, new ConversionExpression(QuantityValue.One, conversionFunction));
    }

    /// <summary>
    ///     Adds a custom conversion function between two specified units.
    /// </summary>
    /// <typeparam name="TFromUnit">The type of the source unit, which must be a struct and an enumeration.</typeparam>
    /// <typeparam name="TToUnit">The type of the target unit, which must be a struct and an enumeration.</typeparam>
    /// <param name="fromUnit">The source unit to convert from.</param>
    /// <param name="toUnit">The target unit to convert to.</param>
    /// <param name="conversionFunction">The function that performs the conversion from the source unit to the target unit.</param>
    /// <returns>The current <see cref="QuantityConversionOptions" /> instance with the custom conversion added.</returns>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when attempting to map conversion units for different quantities using the same unit type.
    /// </exception>
    /// <remarks>
    ///     This method allows you to define a custom conversion function between two units, enabling precise control over the
    ///     conversion process.
    /// </remarks>
    public QuantityConversionOptions SetCustomConversion<TFromUnit, TToUnit>(TFromUnit fromUnit, TToUnit toUnit, ConversionExpression conversionFunction)
        where TFromUnit : struct, Enum
        where TToUnit : struct, Enum
    {
        if (typeof(TFromUnit) == typeof(TToUnit))
        {
            throw new InvalidConversionException(
                $"Mapping conversion units for different quantities using the same unit type ({typeof(TFromUnit).Name}) is not allowed.");
        }

        var fromUnitKey = UnitKey.ForUnit(fromUnit);
        var toUnitKey = UnitKey.ForUnit(toUnit);
        CustomConversionFunctions[new UnitConversionMapping(fromUnitKey, toUnitKey)] = conversionFunction;
        return this;
    }
    
    /// <summary>
    ///     Adds a custom conversion function between two specified units.
    /// </summary>
    /// <typeparam name="TFromUnit">The type of the source unit, which must be a struct and an enumeration.</typeparam>
    /// <typeparam name="TToUnit">The type of the target unit, which must be a struct and an enumeration.</typeparam>
    /// <param name="fromUnit">The source unit to convert from.</param>
    /// <param name="toUnit">The target unit to convert to.</param>
    /// <param name="conversionCoefficient">The used to performs the conversion from the source unit to the target unit.</param>
    /// <param name="mapBothDirections">
    ///     A boolean value indicating whether the conversion should be bidirectional. If true, the conversion
    ///     will be configured in both directions, by creating an expression with the reciprocal coefficient.
    /// </param>
    /// <returns>The current <see cref="QuantityConversionOptions" /> instance with the custom conversion added.</returns>
    /// <exception cref="InvalidConversionException">
    ///     Thrown when attempting to map conversion units for different quantities using the same unit type.
    /// </exception>
    /// <remarks>
    ///     This method allows you to define a custom conversion function between two units, enabling precise control over the
    ///     conversion process.
    /// </remarks>
    public QuantityConversionOptions SetCustomConversion<TFromUnit, TToUnit>(TFromUnit fromUnit, TToUnit toUnit, QuantityValue conversionCoefficient, bool mapBothDirections = false)
        where TFromUnit : struct, Enum
        where TToUnit : struct, Enum
    {
        if (typeof(TFromUnit) == typeof(TToUnit))
        {
            throw new InvalidConversionException(
                $"Mapping conversion units for different quantities using the same unit type ({typeof(TFromUnit).Name}) is not allowed.");
        }

        var fromUnitKey = UnitKey.ForUnit(fromUnit);
        var toUnitKey = UnitKey.ForUnit(toUnit);
        CustomConversionFunctions[new UnitConversionMapping(fromUnitKey, toUnitKey)] = conversionCoefficient;
        if (mapBothDirections)
        {
            CustomConversionFunctions[new UnitConversionMapping(toUnitKey, fromUnitKey)] = QuantityValue.Inverse(conversionCoefficient);
        }
        
        return this;
    }
}
