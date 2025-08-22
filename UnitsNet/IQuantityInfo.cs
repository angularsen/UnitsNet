// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Resources;

namespace UnitsNet;

/// <summary>
///     Information about the quantity, such as names, unit values and zero quantity.
///     This is useful to enumerate units and present names with quantities and units
///     chose dynamically at runtime, such as unit conversion apps or allowing the user to change the
///     unit representation.
/// </summary>
/// <remarks>
///     Typically you obtain this by looking it up via <see cref="IQuantity.QuantityInfo" />.
/// </remarks>
#if NETSTANDARD2_0
public
#else
internal
#endif
interface IQuantityInfo 
{
    /// <summary>
    ///     Quantity name, such as "Length" or "Mass".
    /// </summary>
    string Name { get; }

    /// <summary>
    ///     The units for this quantity.
    /// </summary>
    IReadOnlyList<UnitInfo> UnitInfos { get; }

    /// <summary>
    ///     The base unit of this quantity.
    /// </summary>
    UnitInfo BaseUnitInfo { get; }

    /// <summary>
    ///     Zero value of quantity, such as <see cref="Length.Zero" />.
    /// </summary>
    IQuantity Zero { get; }

    /// <summary>
    ///     Quantity value type, such as <see cref="Length" /> or <see cref="Mass" />.
    /// </summary>
    Type QuantityType { get; }

    /// <summary>
    ///     Unit enum type, such as <see cref="LengthUnit" /> or <see cref="MassUnit" />.
    /// </summary>
    Type UnitType { get; }

    /// <summary>
    ///     The <see cref="BaseDimensions" /> for a quantity.
    /// </summary>
    BaseDimensions BaseDimensions { get; }

    /// <summary>
    ///     Used for loading the localization resources associated with the current quantity.
    /// </summary>
    ResourceManager? UnitAbbreviations { get; }

    /// <summary>
    ///     Gets the <see cref="UnitInfo" /> associated with the specified unit.
    /// </summary>
    /// <param name="unit">The unit for which to get the <see cref="UnitInfo" />.</param>
    /// <returns>The <see cref="UnitInfo" /> associated with the specified unit.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the specified unit is not found.</exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the type of <see cref="UnitType" />> does not match the type of the current
    ///     <see cref="UnitKey.UnitEnumType" />.
    /// </exception>
    UnitInfo this[UnitKey unit] { get; }

    /// <summary>
    ///     Gets the <see cref="UnitInfo" /> whose <see cref="BaseUnits" /> is a subset of <paramref name="baseUnits" />.
    /// </summary>
    /// <example>
    ///     Length.Info.GetUnitInfoFor(unitSystemWithFootAsLengthUnit) returns <see cref="UnitInfo" /> for
    ///     <see cref="LengthUnit.Foot" />.
    /// </example>
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
    UnitInfo GetUnitInfoFor(BaseUnits baseUnits);

    /// <summary>
    ///     Gets an <see cref="IEnumerable{T}" /> of <see cref="UnitInfo" /> that have <see cref="BaseUnits" /> that is a
    ///     subset of <paramref name="baseUnits" />.
    /// </summary>
    /// <param name="baseUnits">The <see cref="BaseUnits" /> to check against.</param>
    /// <returns>
    ///     An <see cref="IEnumerable{T}" /> of <see cref="UnitInfo" /> that have <see cref="BaseUnits" /> that is a
    ///     subset of <paramref name="baseUnits" />.
    /// </returns>
    /// <exception cref="ArgumentNullException"><paramref name="baseUnits" /> is null.</exception>
    IEnumerable<UnitInfo> GetUnitInfosFor(BaseUnits baseUnits);
}

/// <inheritdoc cref="IQuantityInfo" />
/// <remarks>
///     This is a specialization of <see cref="IQuantityInfo" /> that is used (internally) for constraining certain
///     methods, without having to include the unit type as additional generic parameter.
/// </remarks>
#if NETSTANDARD2_0
public
#else
internal
#endif
interface IQuantityInstanceInfo<out TQuantity> : IQuantityInfo
    where TQuantity : IQuantity
{
    /// <inheritdoc cref="IQuantityInfo.Zero" />
    new TQuantity Zero { get; }
    
    /// <summary>
    ///     Creates an instance of the quantity from a specified value and unit.
    /// </summary>
    /// <param name="value">The numerical value of the quantity.</param>
    /// <param name="unitKey">The unit key of the quantity.</param>
    /// <returns>An instance of the quantity with the specified value and unit.</returns>
    public TQuantity Create(double value, UnitKey unitKey);
}
