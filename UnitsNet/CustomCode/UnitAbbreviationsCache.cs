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
        private readonly Dictionary<IFormatProvider, UnitTypeToLookup> _lookupsForCulture;

        /// <summary>
        ///     Fallback culture used by <see cref="GetUnitAbbreviations{TUnitType}" /> and <see cref="GetDefaultAbbreviation{TUnitType}" />
        ///     if no abbreviations are found with a given culture.
        /// </summary>
        /// <example>
        ///     User wants to call <see cref="UnitParser.Parse{TUnitType}" /> or <see cref="Length.ToString()" /> with Russian
        ///     culture, but no translation is defined, so we return the US English definition as a last resort. If it's not
        ///     defined there either, an exception is thrown.
        /// </example>
        private static readonly CultureInfo FallbackCulture = new CultureInfo("en-US");

        /// <summary>
        ///     The static instance used internally for ToString() and Parse() of quantities and units.
        /// </summary>
        public static UnitAbbreviationsCache Default { get; }

        /// <summary>
        ///     Create an instance of the cache and load all the abbreviations defined in the library.
        /// </summary>
        public UnitAbbreviationsCache()
        {
            _lookupsForCulture = new Dictionary<IFormatProvider, UnitTypeToLookup>();

            LoadGeneratedAbbreviations();
        }

        static UnitAbbreviationsCache()
        {
            Default = new UnitAbbreviationsCache();
        }

        private void LoadGeneratedAbbreviations()
        {
            foreach(var localization in GeneratedLocalizations)
            {
                var culture = new CultureInfo(localization.CultureName);
                MapUnitToAbbreviation(localization.UnitType, localization.UnitValue, culture, localization.UnitAbbreviations);
            }
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
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, params string[] abbreviations) where TUnitType : Enum
        {
            MapUnitToAbbreviation(typeof(TUnitType), Convert.ToInt32(unit), CultureInfo.CurrentUICulture, abbreviations);
        }

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="abbreviation">Unit abbreviations to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, string abbreviation) where TUnitType : Enum
        {
            MapUnitToDefaultAbbreviation(typeof(TUnitType), Convert.ToInt32(unit), CultureInfo.CurrentUICulture, abbreviation);
        }

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
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, IFormatProvider formatProvider, params string[] abbreviations) where TUnitType : Enum
        {
            // Assuming TUnitType is an enum, this conversion is safe. Seems not possible to enforce this today.
            // Src: http://stackoverflow.com/questions/908543/how-to-convert-from-system-enum-to-base-integer
            // http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
            var unitValue = Convert.ToInt32(unit);
            var unitType = typeof(TUnitType);

            MapUnitToAbbreviation(unitType, unitValue, formatProvider, abbreviations);
        }

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
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider formatProvider, string abbreviation) where TUnitType : Enum
        {
            // Assuming TUnitType is an enum, this conversion is safe. Seems not possible to enforce this today.
            // Src: http://stackoverflow.com/questions/908543/how-to-convert-from-system-enum-to-base-integer
            // http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
            var unitValue = Convert.ToInt32(unit);
            var unitType = typeof(TUnitType);

            MapUnitToDefaultAbbreviation(unitType, unitValue, formatProvider, abbreviation);
        }

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
        public void MapUnitToAbbreviation(Type unitType, int unitValue, IFormatProvider formatProvider, [NotNull] params string[] abbreviations)
        {
            PerformAbbreviationMapping(unitType, unitValue, formatProvider, false, abbreviations);
        }

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
        public void MapUnitToDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider formatProvider, [NotNull] string abbreviation)
        {
            PerformAbbreviationMapping(unitType, unitValue, formatProvider, true, abbreviation);
        }

        private void PerformAbbreviationMapping(Type unitType, int unitValue, IFormatProvider formatProvider, bool setAsDefault, [NotNull] params string[] abbreviations)
        {
            if (!unitType.Wrap().IsEnum)
                throw new ArgumentException("Must be an enum type.", nameof(unitType));

            if (abbreviations == null)
                throw new ArgumentNullException(nameof(abbreviations));

            formatProvider = formatProvider ?? CultureInfo.CurrentUICulture;

            if (!_lookupsForCulture.TryGetValue(formatProvider, out var quantitiesForProvider))
                quantitiesForProvider = _lookupsForCulture[formatProvider] = new UnitTypeToLookup();

            if (!quantitiesForProvider.TryGetValue(unitType, out var unitToAbbreviations))
                unitToAbbreviations = quantitiesForProvider[unitType] = new UnitValueAbbreviationLookup();

            foreach (var abbr in abbreviations)
            {
                unitToAbbreviations.Add(unitValue, abbr, setAsDefault);
            }
        }

        /// <summary>
        /// Gets the default abbreviation for a given unit. If a unit has more than one abbreviation defined, then it returns the first one.
        /// Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(LengthUnit.Kilometer) => "km"
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <returns>The default unit abbreviation string.</returns>
        [PublicAPI]
        public string GetDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider formatProvider = null) where TUnitType : Enum
        {
            var unitType = typeof(TUnitType);

            if(!TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var lookup))
            {
                if(formatProvider != FallbackCulture)
                    return GetDefaultAbbreviation(unit, FallbackCulture);
                else
                    throw new NotImplementedException($"No abbreviation is specified for {unitType.Name}.{unit}");
            }

            var abbreviations = lookup.GetAbbreviationsForUnit(unit);
            if(abbreviations.Count == 0)
            {
                if(formatProvider != FallbackCulture)
                    return GetDefaultAbbreviation(unit, FallbackCulture);
                else
                    throw new NotImplementedException($"No abbreviation is specified for {unitType.Name}.{unit}");
            }

            return abbreviations.First();
        }

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
        public string GetDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider formatProvider = null)
        {
            if(!TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var lookup))
            {
                if(formatProvider != FallbackCulture)
                    return GetDefaultAbbreviation(unitType, unitValue, FallbackCulture);
                else
                    throw new NotImplementedException($"No abbreviation is specified for {unitType.Name} with numeric value {unitValue}.");
            }

            var abbreviations = lookup.GetAbbreviationsForUnit(unitValue);
            if(abbreviations.Count == 0)
            {
                if(formatProvider != FallbackCulture)
                    return GetDefaultAbbreviation(unitType, unitValue, FallbackCulture);
                else
                    throw new NotImplementedException($"No abbreviation is specified for {unitType.Name} with numeric value {unitValue}.");
            }

            return abbreviations.First();
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <typeparam name="TUnitType">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        public string[] GetUnitAbbreviations<TUnitType>(TUnitType unit, IFormatProvider formatProvider = null) where TUnitType : Enum
        {
            return GetUnitAbbreviations(typeof(TUnitType), Convert.ToInt32(unit), formatProvider);
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        public string[] GetUnitAbbreviations(Type unitType, int unitValue, IFormatProvider formatProvider = null)
        {
            formatProvider = formatProvider ?? CultureInfo.CurrentUICulture;

            if(!TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var lookup))
                return formatProvider != FallbackCulture ? GetUnitAbbreviations(unitType, unitValue, FallbackCulture) : new string[] { };

            var abbreviations = lookup.GetAbbreviationsForUnit(unitValue);
            if(abbreviations.Count == 0)
                return formatProvider != FallbackCulture ? GetUnitAbbreviations(unitType, unitValue, FallbackCulture) : new string[] { };

            return abbreviations.ToArray();
        }

        /// <summary>
        ///     Get all abbreviations for all units of a quantity.
        /// </summary>
        /// <param name="unitEnumType">Enum type for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        [PublicAPI]
        public string[] GetAllUnitAbbreviationsForQuantity(Type unitEnumType, IFormatProvider formatProvider = null)
        {
            formatProvider = formatProvider ?? CultureInfo.CurrentUICulture;

            if(!TryGetUnitValueAbbreviationLookup(unitEnumType, formatProvider, out var lookup))
                return formatProvider != FallbackCulture ? GetAllUnitAbbreviationsForQuantity(unitEnumType, FallbackCulture) : new string[] { };

            return lookup.GetAllUnitAbbreviationsForQuantity();
        }

        internal bool TryGetUnitValueAbbreviationLookup(Type unitType, IFormatProvider formatProvider, out UnitValueAbbreviationLookup unitToAbbreviations)
        {
            unitToAbbreviations = null;

            formatProvider = formatProvider ?? CultureInfo.CurrentUICulture;

            if(!_lookupsForCulture.TryGetValue(formatProvider, out var quantitiesForProvider))
                return formatProvider != FallbackCulture ? TryGetUnitValueAbbreviationLookup(unitType, FallbackCulture, out unitToAbbreviations) : false;

            if(!quantitiesForProvider.TryGetValue(unitType, out unitToAbbreviations))
                return formatProvider != FallbackCulture ? TryGetUnitValueAbbreviationLookup(unitType, FallbackCulture, out unitToAbbreviations) : false;

            return true;
        }
    }
}
