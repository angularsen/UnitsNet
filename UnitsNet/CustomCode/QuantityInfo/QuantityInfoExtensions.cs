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
    ///     Filters a collection of unit information based on the specified base units.
    /// </summary>
    /// <typeparam name="TUnitInfo">The type of the unit information.</typeparam>
    /// <param name="unitInfos">The collection of unit information to filter.</param>
    /// <param name="baseUnits">The base units to filter by.</param>
    /// <returns>An <see cref="IEnumerable{T}" /> containing the unit information that matches the specified base units.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="baseUnits" /> is null.</exception>
    public static IEnumerable<TUnitInfo> GetUnitInfosFor<TUnitInfo>(this IEnumerable<TUnitInfo> unitInfos, BaseUnits baseUnits)
        where TUnitInfo : UnitInfo
    {
        if (baseUnits is null)
        {
            throw new ArgumentNullException(nameof(baseUnits));
        }

        return unitInfos.Where(unitInfo => unitInfo.BaseUnits.IsSubsetOf(baseUnits));
    }

    /// <summary>
    ///     Gets the <see cref="UnitInfo" /> whose <see cref="BaseUnits" /> is a subset of <paramref name="baseUnits" />.
    /// </summary>
    /// <example>
    ///     Length.Info.GetUnitInfoFor(unitSystemWithFootAsLengthUnit) returns <see cref="UnitInfo" /> for
    ///     <see cref="LengthUnit.Foot" />.
    /// </example>
    /// <param name="unitInfos">The collection of unit information to filter.</param>
    /// <param name="baseUnits">The <see cref="BaseUnits" /> to check against.</param>
    /// <returns>
    ///     The <see cref="UnitInfo" /> that has <see cref="BaseUnits" /> that is a subset of
    ///     <paramref name="baseUnits" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="baseUnits" /> is null.</exception>
    /// <exception cref="InvalidOperationException">No unit was found that is a subset of <paramref name="baseUnits" />.</exception>
    /// <exception cref="InvalidOperationException">
    ///     More than one unit was found that is a subset of
    ///     <paramref name="baseUnits" />.
    /// </exception>
    public static TUnitInfo GetUnitInfoFor<TUnitInfo>(this IEnumerable<TUnitInfo> unitInfos, BaseUnits baseUnits)
        where TUnitInfo : UnitInfo
    {
        using IEnumerator<TUnitInfo> enumerator = unitInfos.GetUnitInfosFor(baseUnits).GetEnumerator();
        if (!enumerator.MoveNext())
        {
            throw new InvalidOperationException($"No unit was found that is a subset of {nameof(baseUnits)}");
        }

        TUnitInfo firstUnitInfo = enumerator.Current!;
        if (enumerator.MoveNext())
        {
            throw new InvalidOperationException($"More than one unit was found that is a subset of {nameof(baseUnits)}");
        }

        return firstUnitInfo;
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
