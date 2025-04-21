// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;
using UnitsNet.Units;

namespace UnitsNet;

/// <summary>
///     Provides extension methods for building and configuring unit mappings within the UnitsNet library.
/// </summary>
public static class QuantityInfoBuilderExtensions
{
    /// <summary>
    ///     Filters the collection of unit mappings to include only the specified units.
    /// </summary>
    /// <typeparam name="TUnitDefinition">The type of the unit definition.</typeparam>
    /// <typeparam name="TUnit">The type of the unit enumeration, such as <see cref="LengthUnit"/>.</typeparam>
    /// <param name="unitMappings">The collection of unit mappings to filter, such as the ones provided by <see cref="Length.LengthInfo.GetDefaultMappings"/>.</param>
    /// <param name="units">The units to include in the filtered collection.</param>
    /// <returns>An enumerable collection of unit definitions that includes only the specified units.</returns>
    public static IEnumerable<TUnitDefinition> SelectUnits<TUnitDefinition, TUnit>(this IEnumerable<TUnitDefinition> unitMappings, params IEnumerable<TUnit> units)
        where TUnitDefinition : IUnitDefinition<TUnit>
        where TUnit : struct, Enum
    {
        return unitMappings.Where(x => units.Contains(x.Value));
    }

    /// <summary>
    ///     Filters the collection of unit mappings to exclude the specified units.
    /// </summary>
    /// <typeparam name="TUnitDefinition">The type of the unit definition.</typeparam>
    /// <typeparam name="TUnit">The type of the unit enumeration, such as <see cref="LengthUnit"/>.</typeparam>
    /// <param name="unitMappings">The collection of unit mappings to filter, such as the ones provided by <see cref="Length.LengthInfo.GetDefaultMappings"/>.</param>
    /// <param name="units">The units to exclude from the filtered collection.</param>
    /// <returns>An enumerable collection of unit definitions that excludes the specified units.</returns>
    public static IEnumerable<TUnitDefinition> ExcludeUnits<TUnitDefinition, TUnit>(this IEnumerable<TUnitDefinition> unitMappings, params IEnumerable<TUnit> units)
        where TUnitDefinition : IUnitDefinition<TUnit>
        where TUnit : struct, Enum
    {
        return unitMappings.Where(x => !units.Contains(x.Value));
    }

    /// <summary>
    ///     Configures a specific unit within a collection of unit mappings.
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit enumeration.</typeparam>
    /// <typeparam name="TUnitDefinition"></typeparam>
    /// <param name="unitMappings">The collection of unit mappings to configure, such as the ones provided by <see cref="Length.LengthInfo.GetDefaultMappings"/>.</param>
    /// <param name="unit">The unit to configure, such as <see cref="LengthUnit"/>.</param>
    /// <param name="unitConfiguration">A function that defines the configuration for the specified unit.</param>
    /// <returns>An enumerable collection of unit definitions with the specified unit configured.</returns>
    public static IEnumerable<TUnitDefinition> Configure<TUnitDefinition, TUnit>(this IEnumerable<TUnitDefinition> unitMappings, TUnit unit,
        Func<TUnitDefinition, TUnitDefinition> unitConfiguration)
        where TUnitDefinition : IUnitDefinition<TUnit>
        where TUnit : struct, Enum
    {
        #if NET
        EqualityComparer<TUnit> comparer = EqualityComparer<TUnit>.Default;
        #else
        UnitEqualityComparer<TUnit> comparer = UnitEqualityComparer<TUnit>.Default;
        #endif
        foreach (TUnitDefinition unitMapping in unitMappings)
        {
            if (comparer.Equals(unitMapping.Value, unit))
            {
                yield return unitConfiguration(unitMapping);
            }
            else
            {
                yield return unitMapping;
            }
        }
    }

    /// <summary>
    ///     Creates a new unit definition by specifying a new conversion factor from the base unit.
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit enumeration, such as <see cref="LengthUnit"/>.</typeparam>
    /// <param name="unitDefinition">The unit definition to which the conversion factor will be added.</param>
    /// <param name="conversionFromBase">The conversion factor from the base unit to the specified unit.</param>
    /// <returns>A new <see cref="UnitDefinition{TUnit}" /> instance with the specified conversion factor from the base unit.</returns>
    public static UnitDefinition<TUnit> WithConversionFromBase<TUnit>(this IUnitDefinition<TUnit> unitDefinition, QuantityValue conversionFromBase)
        where TUnit : struct, Enum
    {
        return new UnitDefinition<TUnit>(unitDefinition.Value, unitDefinition.Name, unitDefinition.PluralName, unitDefinition.BaseUnits, conversionFromBase);
    }

    /// <summary>
    ///     Creates a new unit definition by specifying a new conversion factor to the base unit.
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit enumeration.</typeparam>
    /// <param name="unitDefinition">The unit definition to which the conversion factor will be added.</param>
    /// <param name="conversionToBase">The conversion factor to the base unit from the specified unit.</param>
    /// <returns>A new <see cref="UnitDefinition{TUnit}" /> instance with the specified conversion factor to the base unit.</returns>
    public static UnitDefinition<TUnit> WithConversionToBase<TUnit>(this IUnitDefinition<TUnit> unitDefinition, QuantityValue conversionToBase)
        where TUnit : struct, Enum
    {
        return new UnitDefinition<TUnit>(unitDefinition.Value, unitDefinition.Name, unitDefinition.PluralName, unitDefinition.BaseUnits,
            QuantityValue.Inverse(conversionToBase), conversionToBase);
    }

    /// <summary>
    ///     Creates a new unit definition by specifying conversion expressions for both conversion from the base unit and
    ///     conversion to the base unit.
    /// </summary>
    /// <typeparam name="TUnit">The type of the unit enumeration.</typeparam>
    /// <param name="unitDefinition">The unit definition to which the conversion expressions will be added.</param>
    /// <param name="conversionFromBase">The conversion expression from the base unit to the specified unit.</param>
    /// <param name="conversionToBase">The conversion expression from the specified unit to the base unit.</param>
    /// <returns>A new <see cref="UnitDefinition{TUnit}" /> instance with the specified conversion expressions.</returns>
    public static UnitDefinition<TUnit> WithConversionExpression<TUnit>(this IUnitDefinition<TUnit> unitDefinition, ConversionExpression conversionFromBase,
        ConversionExpression conversionToBase)
        where TUnit : struct, Enum
    {
        return new UnitDefinition<TUnit>(unitDefinition.Value, unitDefinition.Name, unitDefinition.PluralName, unitDefinition.BaseUnits, conversionFromBase,
            conversionToBase);
    }
}
