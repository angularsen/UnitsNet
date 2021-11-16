// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Cache of the mapping between unit enum values and unit singular names for one or more cultures.
    /// </summary>
    public sealed partial class UnitSingularNamesCache
    {
        private readonly UnitLocalizationCache _cache;

        /// <summary>
        ///     The static instance used internally
        /// </summary>
        public static UnitSingularNamesCache Default { get; }

        /// <summary>
        ///     Create an instance of the cache and load all the singularNames defined in the library.
        /// </summary>
        public UnitSingularNamesCache()
        {
            _cache = new UnitLocalizationCache("singular name", GeneratedLocalizations);
        }

        static UnitSingularNamesCache()
        {
            Default = new UnitSingularNamesCache();
        }

        /// <summary>
        /// Adds one or more unit singularName for the given unit enum value.
        /// This is used to dynamically add singularNames for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetUnitSingularName(Type, int, IFormatProvider?)"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="singularNames">Unit singularNames to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        [PublicAPI]
        public void MapUnitToSingularName<TUnitType>(TUnitType unit, params string[] singularNames) where TUnitType : Enum =>
            _cache.MapUnitToStrings(unit, singularNames);


        /// <summary>
        /// Adds one or more unit singularName for the given unit enum value.
        /// This is used to dynamically add singularNames for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetUnitSingularName(Type, int, IFormatProvider?)"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="singularNames">Unit singularNames to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        [PublicAPI]
        public void MapUnitToSingularName<TUnitType>(TUnitType unit, IFormatProvider formatProvider, params string[] singularNames) where TUnitType : Enum =>
            MapUnitToSingularName(unit, formatProvider, singularNames);

        /// <summary>
        /// Adds one or more unit singularName for the given unit enum value.
        /// This is used to dynamically add singularNames for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetUnitSingularName(Type, int, IFormatProvider?)"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="singularNames">Unit singularNames to add.</param>
        [PublicAPI]
        public void MapUnitToSingularName(Type unitType, int unitValue, IFormatProvider formatProvider, [NotNull] params string[] singularNames) =>
            _cache.MapUnitToStrings(unitType, unitValue, formatProvider, singularNames);


        /// <summary>
        ///     Get the singular Name of a given unit.
        /// </summary>
        /// <typeparam name="TUnitType">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>The singular name associated with the unit.</returns>
        [PublicAPI]
        public string GetUnitSingularName<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : Enum =>
            _cache.GetUnitStrings(unit, formatProvider)[0]; //only one singular name is supported

        /// <summary>
        ///     Get the singular Name of a given unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>The singular name associated with the unit.</returns>
        [PublicAPI]
        public string GetUnitSingularName(Type unitType, int unitValue, IFormatProvider? formatProvider = null) =>
            _cache.GetUnitStrings(unitType, unitValue, formatProvider)[0]; //only one singular name is supported

        /// <summary>
        ///     Get all singularNames for all units of a quantity.
        /// </summary>
        /// <param name="unitEnumType">Enum type for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit singularNames associated with unit.</returns>
        [PublicAPI]
        public string[] GetAllUnitSingularNamesForQuantity(Type unitEnumType, IFormatProvider? formatProvider = null) =>
            _cache.GetAllUnitStringsForQuantity(unitEnumType, formatProvider);

        internal bool TryGetUnitValueSingularNameLookup(Type unitType, IFormatProvider? formatProvider, out UnitValueToStringLookup? unitToSingularNames) =>
            _cache.TryGetUnitValueStringLookup(unitType, formatProvider, out unitToSingularNames);
    }
}
