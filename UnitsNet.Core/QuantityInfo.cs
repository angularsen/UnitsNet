// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace UnitsNet
{
    /// <summary>
    ///     Delegate to construct a quantity from a value and unit.
    /// </summary>
    public delegate IQuantity QuantityFactory(QuantityValue value, Enum unit);

    /// <summary>
    ///     Information about the quantity, such as names, unit values and zero quantity.
    ///     This is useful to enumerate units and present names with quantities and units
    ///     chose dynamically at runtime, such as unit conversion apps or allowing the user to change the
    ///     unit representation.
    /// </summary>
    /// <remarks>
    ///     Typically you obtain this by looking it up via <see cref="IQuantity.QuantityInfo" />.
    /// </remarks>
    public class QuantityInfo
    {
        private readonly QuantityFactory _quantityFactory;

        /// <summary>
        ///     Constructs an instance.
        /// </summary>
        /// <param name="name">Name of the quantity.</param>
        /// <param name="unitType">The unit enum type, such as <see cref="LengthUnit" />.</param>
        /// <param name="unitInfos">The information about the units for this quantity.</param>
        /// <param name="baseUnit">The base unit enum value.</param>
        /// <param name="zero">The zero quantity.</param>
        /// <param name="baseDimensions">The base dimensions of the quantity.</param>
        /// <param name="quantityFactory">The quantity factory.</param>
        /// <exception cref="ArgumentException">Quantity type can not be undefined.</exception>
        /// <exception cref="ArgumentNullException">If units -or- baseUnit -or- zero -or- baseDimensions is null.</exception>
        public QuantityInfo(string name, Type unitType, UnitInfo[] unitInfos, Enum baseUnit, IQuantity zero, BaseDimensions baseDimensions, QuantityFactory quantityFactory)
        {
            if (baseUnit == null) throw new ArgumentNullException(nameof(baseUnit));
            BaseDimensions = baseDimensions ?? throw new ArgumentNullException(nameof(baseDimensions));
            _quantityFactory = quantityFactory ?? throw new ArgumentNullException(nameof(quantityFactory));
            Zero = zero ?? throw new ArgumentNullException(nameof(zero));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            UnitType = unitType ?? throw new ArgumentNullException(nameof(unitType));
            UnitInfos = unitInfos ?? throw new ArgumentNullException(nameof(unitInfos));
            AbbreviationsForAllUnits = unitInfos.SelectMany(ui => ui.Abbreviations).ToArray();

            BaseUnitInfo = UnitInfos.First(unitInfo => unitInfo.Value.Equals(baseUnit));
            ValueType = zero.GetType();
        }

        /// <summary>
        ///     Quantity name, such as "Length" or "Mass".
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     All unit abbreviations for all units of this quantity.
        /// </summary>
        public IReadOnlyList<string> AbbreviationsForAllUnits { get; }

        /// <summary>
        ///     The units for this quantity.
        /// </summary>
        public UnitInfo[] UnitInfos { get; }

        /// <summary>
        ///     The base unit of this quantity.
        /// </summary>
        public UnitInfo BaseUnitInfo { get; }

        /// <summary>
        ///     Zero value of quantity, such as <see cref="Length.Zero" />.
        /// </summary>
        public IQuantity Zero { get; }

        /// <summary>
        ///     Unit enum type, such as <see cref="LengthUnit"/> or <see cref="MassUnit"/>.
        /// </summary>
        public Type UnitType { get; }

        /// <summary>
        ///     Quantity value type, such as <see cref="Length"/> or <see cref="Mass"/>.
        /// </summary>
        public Type ValueType { get; }

        /// <summary>
        ///     The <see cref="BaseDimensions" /> for a quantity.
        /// </summary>
        public BaseDimensions BaseDimensions { get; }

        /// <summary>
        ///     Construct a quantity from a value and unit.
        /// </summary>
        public IQuantity CreateQuantity(QuantityValue value, Enum unit)
        {
            return _quantityFactory(value, unit);
        }

        // /// <summary>
        // /// Gets the <see cref="UnitInfo"/> whose <see cref="BaseUnits"/> is a subset of <paramref name="baseUnits"/>.
        // /// </summary>
        // /// <example>Length.Info.GetUnitInfoFor(unitSystemWithFootAsLengthUnit) returns <see cref="UnitInfo" /> for <see cref="LengthUnit.Foot" />.</example>
        // /// <param name="baseUnits">The <see cref="BaseUnits"/> to check against.</param>
        // /// <returns>The <see cref="UnitInfo"/> that has <see cref="BaseUnits"/> that is a subset of <paramref name="baseUnits"/>.</returns>
        // /// <exception cref="ArgumentNullException"><paramref name="baseUnits"/> is null.</exception>
        // /// <exception cref="InvalidOperationException">No unit was found that is a subset of <paramref name="baseUnits"/>.</exception>
        // /// <exception cref="InvalidOperationException">More than one unit was found that is a subset of <paramref name="baseUnits"/>.</exception>
        // public UnitInfo GetUnitInfoFor(BaseUnits baseUnits)
        // {
        //     if (baseUnits is null)
        //         throw new ArgumentNullException(nameof(baseUnits));
        //
        //     var matchingUnitInfos = GetUnitInfosFor(baseUnits)
        //         .Take(2)
        //         .ToArray();
        //
        //     var firstUnitInfo = matchingUnitInfos.FirstOrDefault();
        //     if (firstUnitInfo == null)
        //         throw new InvalidOperationException($"No unit was found that is a subset of {nameof(baseUnits)}");
        //
        //     if (matchingUnitInfos.Length > 1)
        //         throw new InvalidOperationException($"More than one unit was found that is a subset of {nameof(baseUnits)}");
        //
        //     return firstUnitInfo;
        // }
        //
        // /// <summary>
        // /// Gets an <see cref="IEnumerable{T}"/> of <see cref="UnitInfo"/> that have <see cref="BaseUnits"/> that is a subset of <paramref name="baseUnits"/>.
        // /// </summary>
        // /// <param name="baseUnits">The <see cref="BaseUnits"/> to check against.</param>
        // /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="UnitInfo"/> that have <see cref="BaseUnits"/> that is a subset of <paramref name="baseUnits"/>.</returns>
        // /// <exception cref="ArgumentNullException"><paramref name="baseUnits"/> is null.</exception>
        // public IEnumerable<UnitInfo> GetUnitInfosFor(BaseUnits baseUnits)
        // {
        //     if (baseUnits is null)
        //         throw new ArgumentNullException(nameof(baseUnits));
        //
        //     return UnitInfos.Where(unitInfo => unitInfo.BaseUnits.IsSubsetOf(baseUnits));
        // }

        /// <summary>
        ///     Try to parse a quantity of type <see cref="ValueType"/> from a string.
        /// </summary>
        /// <param name="formatProvider">The format provider, for number formatting and localization of unit abbreviations.</param>
        /// <param name="quantityString">The string to parse, such as "1.5 m".</param>
        /// <param name="quantity">The parsed quantity, or null if not successful.</param>
        /// <returns>True if successful.</returns>
        public bool TryParse(IFormatProvider? formatProvider, string quantityString, [NotNullWhen(true)] out IQuantity? quantity)
        {
            return QuantityParser.Default.TryParse(quantityString, formatProvider, UnitType, AbbreviationsForAllUnits, CreateQuantity, out quantity);
        }
    }

    /// <inheritdoc cref="QuantityInfo" />
    /// <remarks>
    ///     This is a specialization of <see cref="QuantityInfo" />, for when the unit type is known.
    ///     Typically you obtain this by looking it up statically from <see cref="Length.Info" /> or
    ///     <see cref="Length.QuantityInfo" />, or dynamically via <see cref="IQuantity{TUnitType}.QuantityInfo" />.
    /// </remarks>
    /// <typeparam name="TUnit">The unit enum type, such as <see cref="LengthUnit" />. </typeparam>
    public class QuantityInfo<TUnit> : QuantityInfo
        where TUnit : Enum
    {
        /// <inheritdoc />
        public QuantityInfo(string name, UnitInfo<TUnit>[] unitInfos, TUnit baseUnit, IQuantity<TUnit> zero, BaseDimensions baseDimensions, QuantityFactory quantityFactory)
            : base(name, typeof(TUnit), unitInfos.ToArray<UnitInfo>(), baseUnit, zero, baseDimensions, quantityFactory)
        {
            Zero = zero;
            UnitInfos = unitInfos ?? throw new ArgumentNullException(nameof(unitInfos));
            BaseUnitInfo = UnitInfos.First(unitInfo => unitInfo.Value.Equals(baseUnit));
            UnitType = baseUnit;
        }

        /// <inheritdoc cref="QuantityInfo.UnitInfos" />
        public new UnitInfo<TUnit>[] UnitInfos { get; }

        /// <inheritdoc cref="QuantityInfo.BaseUnitInfo" />
        public new UnitInfo<TUnit> BaseUnitInfo { get; }

        /// <inheritdoc cref="QuantityInfo.Zero" />
        public new IQuantity<TUnit> Zero { get; }

        /// <inheritdoc cref="QuantityInfo.UnitType" />
        public new TUnit UnitType { get; }

        // /// <inheritdoc cref="QuantityInfo.GetUnitInfoFor" />
        // public new UnitInfo<TUnit> GetUnitInfoFor(BaseUnits baseUnits)
        // {
        //     return (UnitInfo<TUnit>)base.GetUnitInfoFor(baseUnits);
        // }
        //
        // /// <inheritdoc cref="QuantityInfo.GetUnitInfosFor" />
        // public new IEnumerable<UnitInfo<TUnit>> GetUnitInfosFor(BaseUnits baseUnits)
        // {
        //     return base.GetUnitInfosFor(baseUnits).Cast<UnitInfo<TUnit>>();
        // }
    }
}
