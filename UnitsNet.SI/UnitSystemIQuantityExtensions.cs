// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNet;

/// <summary>
///     Extension methods for <see cref="IQuantity" /> to add support for conversions involving UnitSystem.
/// </summary>
public static class UnitSystemIQuantityExtensions
{
    /// <summary>
    ///     Converts to a quantity with a unit determined by the given <see cref="UnitSystem"/>, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
    ///     If multiple units were found for the given <see cref="UnitSystem"/>, the first match will be used.
    /// </summary>
    /// <param name="quantity">The quantity.</param>
    /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity to.</param>
    /// <returns>A new quantity with the determined unit.</returns>
    public static TQuantity ToUnit<TQuantity>(this TQuantity quantity, UnitSystem unitSystem)
        where TQuantity : IQuantity
    {
        if (unitSystem == null) throw new ArgumentNullException(nameof(unitSystem));

        Enum unitEnumValue = GetUnitEnumValue(quantity, unitSystem);

        return (TQuantity)quantity.ToUnit(unitEnumValue);
    }

    /// <summary>
    ///     Converts to a quantity with a unit determined by the given <see cref="UnitSystem"/>, which affects things like <see cref="IQuantity.ToString(System.IFormatProvider)"/>.
    ///     If multiple units were found for the given <see cref="UnitSystem"/>, the first match will be used.
    /// </summary>
    /// <param name="quantity">The quantity.</param>
    /// <param name="unitSystem">The <see cref="UnitSystem"/> to convert the quantity to.</param>
    /// <returns>A new quantity with the determined unit.</returns>
    public static IQuantity ToUnit(this IQuantity quantity, UnitSystem unitSystem)
    {
        if (unitSystem == null) throw new ArgumentNullException(nameof(unitSystem));

        Enum unitEnumValue = GetUnitEnumValue(quantity, unitSystem);

        return quantity.ToUnit(unitEnumValue);
    }

    /// <summary>
    ///     Gets the value in the unit determined by the given <see cref="UnitSystem" />. If multiple units were found for the
    ///     given <see cref="UnitSystem" />,
    ///     the first match will be used.
    /// </summary>
    /// <param name="quantity">The quantity.</param>
    /// <param name="unitSystem">The <see cref="UnitSystem" /> to convert the quantity value to.</param>
    /// <returns>The converted value.</returns>
    public static double As(this IQuantity quantity, UnitSystem unitSystem)
    {
        if (unitSystem == null) throw new ArgumentNullException(nameof(unitSystem));

        Enum unitEnumValue = GetUnitEnumValue(quantity, unitSystem);
        return quantity.As(unitEnumValue);
    }

    /// <summary>
    ///     Gets the unit enum value for the given quantity as configured by the SI base units in the given unit system.
    /// </summary>
    /// <param name="quantity">The quantity.</param>
    /// <param name="unitSystem">The unit system with configured SI base units.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">quantity or unitSystem was null.</exception>
    /// <exception cref="ArgumentException">No units were found for the given UnitSystem.</exception>
    public static Enum GetUnitEnumValue(this IQuantity quantity, UnitSystem unitSystem)
    {
        if (quantity == null) throw new ArgumentNullException(nameof(quantity));
        if (unitSystem == null) throw new ArgumentNullException(nameof(unitSystem));

        IEnumerable<UnitInfo> unitInfos = GetUnitInfosFor(quantity.QuantityInfo, unitSystem.BaseUnits);

        UnitInfo firstUnitInfo = unitInfos.FirstOrDefault()
                                 ?? throw new ArgumentException("No units were found for the given UnitSystem.", nameof(unitSystem));

        return firstUnitInfo.Value;
    }

    /// <summary>
    ///     Gets an <see cref="IEnumerable{T}" /> of <see cref="UnitInfo" /> that have <see cref="BaseUnits" /> that is a
    ///     subset of <paramref name="baseUnits" />.
    /// </summary>
    /// <param name="quantityInfo">The quantity info.</param>
    /// <param name="baseUnits">The <see cref="BaseUnits" /> to check against.</param>
    /// <returns>
    ///     An <see cref="IEnumerable{T}" /> of <see cref="UnitInfo" /> that have <see cref="BaseUnits" /> that is a
    ///     subset of <paramref name="baseUnits" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="baseUnits" /> is null.</exception>
    public static IEnumerable<UnitInfo> GetUnitInfosFor(this QuantityInfo quantityInfo, BaseUnits baseUnits)
    {
        if (baseUnits is null)
        {
            throw new ArgumentNullException(nameof(baseUnits));
        }

        return quantityInfo.UnitInfos.Where(unitInfo => unitInfo.BaseUnits.IsSubsetOf(baseUnits));
    }

        /// <summary>
        /// Gets the <see cref="UnitInfo"/> whose <see cref="BaseUnits"/> is a subset of <paramref name="baseUnits"/>.
        /// </summary>
        /// <example>Length.Info.GetUnitInfoFor(unitSystemWithFootAsLengthUnit) returns <see cref="UnitInfo" /> for LengthUnit.Foot.</example>
        /// <param name="quantityInfo">The quantity info.</param>
        /// <param name="baseUnits">The <see cref="BaseUnits"/> to check against.</param>
        /// <returns>The <see cref="UnitInfo"/> that has <see cref="BaseUnits"/> that is a subset of <paramref name="baseUnits"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="baseUnits"/> is null.</exception>
        /// <exception cref="InvalidOperationException">No unit was found that is a subset of <paramref name="baseUnits"/>.</exception>
        /// <exception cref="InvalidOperationException">More than one unit was found that is a subset of <paramref name="baseUnits"/>.</exception>
        public static UnitInfo GetUnitInfoFor(this QuantityInfo quantityInfo, BaseUnits baseUnits)
        {
            if (baseUnits is null)
                throw new ArgumentNullException(nameof(baseUnits));

            var matchingUnitInfos = GetUnitInfosFor(quantityInfo, baseUnits)
                .Take(2)
                .ToArray();

            if (matchingUnitInfos.Length > 1)
                throw new InvalidOperationException($"More than one unit was found that is a subset of {nameof(baseUnits)}");

            UnitInfo? firstUnitInfo = matchingUnitInfos.FirstOrDefault();
            if (firstUnitInfo == null)
                throw new InvalidOperationException($"No unit was found that is a subset of {nameof(baseUnits)}");

            return firstUnitInfo;
        }

}
