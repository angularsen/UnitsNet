// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

using UnitTypeToLookup = System.Collections.Generic.Dictionary<System.Type, UnitsNet.UnitValueAbbreviationLookup>;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Cache of the mapping between unit enum values and unit abbreviation strings for one or more cultures.
    ///     A static instance <see cref="Default"/> is used internally for ToString() and Parse() of quantities and units.
    /// </summary>
    public sealed partial class UnitAbbreviationsCache
    {
        private readonly UnitLocalizationCache _cache;

        /// <summary>
        ///     The static instance used internally for ToString() and Parse() of quantities and units.
        /// </summary>
        public static UnitAbbreviationsCache Default { get; }

        /// <summary>
        ///     Create an instance of the cache and load all the abbreviations defined in the library.
        /// </summary>
        public UnitAbbreviationsCache()
        {
            _cache = new UnitLocalizationCache("abbreviation", GeneratedLocalizations);
        }

        static UnitAbbreviationsCache()
        {
            Default = new UnitAbbreviationsCache();
        }


        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        [PublicAPI]
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, params string[] abbreviations) where TUnitType : Enum =>
            _cache.MapUnitToStrings(unit, abbreviations);

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="abbreviation">Unit abbreviations to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, string abbreviation) where TUnitType : Enum =>
            _cache.MapUnitToDefaultString(unit, abbreviation);

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        [PublicAPI]
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, IFormatProvider formatProvider, params string[] abbreviations) where TUnitType : Enum =>
            MapUnitToAbbreviation(unit, formatProvider, abbreviations);

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="abbreviation">Unit abbreviation to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        [PublicAPI]
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider formatProvider, string abbreviation) where TUnitType : Enum =>
            _cache.MapUnitToDefaultString(unit, formatProvider, abbreviation);

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        [PublicAPI]
        public void MapUnitToAbbreviation(Type unitType, int unitValue, IFormatProvider formatProvider, [NotNull] params string[] abbreviations) =>
            _cache.MapUnitToStrings(unitType, unitValue, formatProvider, abbreviations);

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="abbreviation">Unit abbreviation to add as default.</param>
        [PublicAPI]
        public void MapUnitToDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider formatProvider, [NotNull] string abbreviation) =>
            _cache.MapUnitToDefaultString(unitType, unitValue, formatProvider, abbreviation);


        /// <summary>
        /// Gets the default abbreviation for a given unit. If a unit has more than one abbreviation defined, then it returns the first one.
        /// Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(LengthUnit.Kilometer) => "km"
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <returns>The default unit abbreviation string.</returns>
        [PublicAPI]
        public string GetDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : Enum =>
            _cache.GetDefaultString(unit, formatProvider);

        /// <summary>
        /// Gets the default abbreviation for a given unit type and its numeric enum value.
        /// If a unit has more than one abbreviation defined, then it returns the first one.
        /// Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(typeof(LengthUnit), 1) => "cm"
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>The default unit abbreviation string.</returns>
        [PublicAPI]
        public string GetDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider = null) =>
            _cache.GetDefaultString(unitType, unitValue, formatProvider);

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <typeparam name="TUnitType">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        public string[] GetUnitAbbreviations<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : Enum =>
            _cache.GetUnitStrings(unit, formatProvider);

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        public string[] GetUnitAbbreviations(Type unitType, int unitValue, IFormatProvider? formatProvider = null) =>
            _cache.GetUnitStrings(unitType, unitValue, formatProvider);

        /// <summary>
        ///     Get all abbreviations for all units of a quantity.
        /// </summary>
        /// <param name="unitEnumType">Enum type for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        public string[] GetAllUnitAbbreviationsForQuantity(Type unitEnumType, IFormatProvider? formatProvider = null) =>
            _cache.GetAllUnitStringsForQuantity(unitEnumType, formatProvider);

        internal bool TryGetUnitValueAbbreviationLookup(Type unitType, IFormatProvider? formatProvider, out UnitValueToStringLookup? unitToAbbreviations) =>
            _cache.TryGetUnitValueStringLookup(unitType, formatProvider, out unitToAbbreviations);

    }
}
