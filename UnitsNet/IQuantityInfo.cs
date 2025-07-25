// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Resources;
using UnitsNet.Units;

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
public interface IQuantityInfo
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
    ///     Configures the default unit conversions for this quantity, or null if no conversions are configured.
    /// </summary>
    Action<UnitConverter>? RegisterUnitConversions { get; }

    /// <summary>
    ///     Gets the <see cref="UnitInfo" /> associated with the specified unit.
    /// </summary>
    /// <param name="unit">The unit for which to get the <see cref="UnitInfo" />.</param>
    /// <returns>The <see cref="UnitInfo" /> associated with the specified unit.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the specified unit is not found.</exception>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the type of <see cref="UnitType"/>> does not match the type of the current <see cref="UnitKey.UnitEnumType" />.
    /// </exception>
    UnitInfo this[UnitKey unit] { get; }

    // /// <summary>
    // ///     Attempts to retrieve the unit information for the specified unit.
    // /// </summary>
    // /// <param name="unit">The unit for which to retrieve information.</param>
    // /// <param name="unitInfo">
    // ///     When this method returns, contains the unit information associated with the specified unit,
    // ///     if the unit is found; otherwise, <c>null</c>. This parameter is passed uninitialized.
    // /// </param>
    // /// <returns>
    // ///     <c>true</c> if the unit information was found; otherwise, <c>false</c>.
    // /// </returns>
    // bool TryGetUnitInfo(UnitKey unit, [NotNullWhen(true)] out UnitInfo? unitInfo);

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

    // /// <summary>
    // ///     Creates an instance of <see cref="IQuantity" /> from the specified value and unit.
    // /// </summary>
    // /// <param name="value">The numerical value of the quantity.</param>
    // /// <param name="unit">The unit of the quantity, represented as an enumeration.</param>
    // /// <returns>An instance of <see cref="IQuantity" /> representing the specified value and unit.</returns>
    // /// <exception cref="ArgumentNullException">Thrown when <paramref name="unit" /> is null.</exception>
    // /// <exception cref="ArgumentException">Thrown when <paramref name="unit" /> is not a valid unit for this quantity.</exception>
    // IQuantity From(QuantityValue value, Enum unit);
}

// /// <inheritdoc cref="IQuantityInfo" />
// /// <remarks>
// ///     This is a specialization of <see cref="IQuantityInfo" />, for when the unit type is known.
// ///     Typically, you obtain this by looking it up statically from <see cref="Length.Info" /> or
// ///     <see cref="Length.QuantityInfo" />, or dynamically via <see cref="IQuantity{TUnitType}.QuantityInfo" />.
// /// </remarks>
// /// <typeparam name="TUnit">The unit enum type, such as <see cref="LengthUnit" />. </typeparam>
// public interface IQuantityInfo<TUnit> : IQuantityInfo
//     where TUnit : struct, Enum
// {
//     /// <inheritdoc cref="IQuantityInfo.Zero" />
//     new IQuantity<TUnit> Zero { get; }
//
//     /// <inheritdoc cref="IQuantityInfo.UnitInfos" />
//     new IReadOnlyCollection<UnitInfo<TUnit>> UnitInfos { get; }
//
//     /// <inheritdoc cref="IQuantityInfo.BaseUnitInfo" />
//     new UnitInfo<TUnit> BaseUnitInfo { get; }
//
//     /// <inheritdoc cref="IQuantityInfo.this" />
//     UnitInfo<TUnit> this[TUnit unit] { get; }
//
//     /// <inheritdoc cref="IQuantityInfo.TryGetUnitInfo" />
//     bool TryGetUnitInfo(TUnit unit, [NotNullWhen(true)] out UnitInfo<TUnit>? unitInfo);
//
//     /// <inheritdoc cref="IQuantityInfo.GetUnitInfoFor" />
//     new UnitInfo<TUnit> GetUnitInfoFor(BaseUnits baseUnits);
//
//     /// <inheritdoc cref="IQuantityInfo.GetUnitInfosFor" />
//     new IEnumerable<UnitInfo<TUnit>> GetUnitInfosFor(BaseUnits baseUnits);
//
//     /// <inheritdoc cref="IQuantityInfo.From" />
//     IQuantity<TUnit> From(QuantityValue value, TUnit unit);
// }

/// <inheritdoc cref="IQuantityInfo" />
/// <remarks>
///     This is a specialization of <see cref="IQuantityInfo" /> that is used (internally) for constraining certain
///     methods, without having to include the unit type as additional generic parameter.
/// </remarks>
public interface IQuantityInstanceInfo<out TQuantity> : IQuantityInfo
    where TQuantity : IQuantity
{
    /// <inheritdoc cref="IQuantityInfo.Zero" />
    new TQuantity Zero { get; }

    internal TQuantity Create(double value, UnitKey unitKey);
}

// /// <inheritdoc cref="IQuantityInfo{TUnit}" />
// public interface IQuantityInfo<TQuantity, TUnit> : IQuantityInfo<TUnit>, IQuantityInstanceInfo<TQuantity>
//     where TQuantity : IQuantity<TUnit>
//     where TUnit : struct, Enum
// {
//     /// <inheritdoc cref="IQuantityInfo.Zero" />
//     new TQuantity Zero { get; }
//
//     /// <inheritdoc cref="IQuantityInfo.UnitInfos" />
//     new IReadOnlyCollection<UnitInfo<TQuantity, TUnit>> UnitInfos { get; }
//
//     /// <inheritdoc cref="IQuantityInfo.BaseUnitInfo" />
//     new UnitInfo<TQuantity, TUnit> BaseUnitInfo { get; }
//
//     /// <inheritdoc cref="IQuantityInfo.this" />
//     new UnitInfo<TQuantity, TUnit> this[TUnit unit] { get; }
//
//     /// <inheritdoc cref="IQuantityInfo.GetUnitInfoFor" />
//     new UnitInfo<TQuantity, TUnit> GetUnitInfoFor(BaseUnits baseUnits);
//
//     /// <inheritdoc cref="IQuantityInfo.GetUnitInfosFor" />
//     new IEnumerable<UnitInfo<TQuantity, TUnit>> GetUnitInfosFor(BaseUnits baseUnits);
//
//     /// <inheritdoc cref="IQuantityInfo.From" />
//     new TQuantity From(QuantityValue value, TUnit unit);
//
//     // #if NET
//     //
//     // #region Implementation of IQuantityInstanceInfo<out TQuantity>
//     //
//     // TQuantity IQuantityInstanceInfo<TQuantity>.Create(QuantityValue value, UnitKey unitKey)
//     // {
//     //     return From(value, unitKey.ToUnit<TUnit>());
//     // }
//     //
//     // #endregion
//     //
//     // #endif
// }
