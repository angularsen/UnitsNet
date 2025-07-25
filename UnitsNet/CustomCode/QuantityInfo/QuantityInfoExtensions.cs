using System;
using System.Collections.Generic;
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
    /// <typeparam name="TUnit">The type of the unit, which is a value type and an enumeration.</typeparam>
    /// <param name="quantityInfo">
    ///     The <see cref="QuantityInfo{TUnit}" /> instance containing information about the
    ///     quantity.
    /// </param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> for which the default unit is to be retrieved.</param>
    /// <returns>The default unit of type <typeparamref name="TUnit" /> for the specified quantity and unit system.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="unitSystem" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentException">Thrown when no units are found for the given <paramref name="unitSystem" />.</exception>
    /// <example>
    ///     <code>Length.Info.GetDefaultUnit(UnitSystem.SI)</code>
    /// </example>
    internal static TUnit GetDefaultUnit<TUnit>(this QuantityInfo<TUnit> quantityInfo, UnitSystem unitSystem)
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

        IEnumerable<UnitInfo<TUnit>> unitInfos = quantityInfo.GetUnitInfosFor(unitSystem.BaseUnits);

        UnitInfo<TUnit>? firstUnitInfo = unitInfos.FirstOrDefault();
        if (firstUnitInfo == null)
        {
            throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));
        }

        return firstUnitInfo.Value;
    }
}
