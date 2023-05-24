// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

using UnitTypeToLookup = System.Collections.Generic.Dictionary<System.Type, UnitsNet.UnitValueAbbreviationLookup>;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Cache of the mapping between unit enum values and unit abbreviation strings for one or more cultures.
    ///     A static instance <see cref="Default"/> is used internally for ToString() and Parse() of quantities and units.
    /// </summary>
    public sealed class UnitAbbreviationsCache
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
        internal static readonly CultureInfo FallbackCulture = new("en-US");

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
            foreach (TypeInfo quantityType in Quantity.QuantityTypes)
            {
                // TODO Cache reflection.
                var mapGeneratedLocalizationsMethod = quantityType.GetMethod("MapGeneratedLocalizations", BindingFlags.NonPublic | BindingFlags.Static);
                mapGeneratedLocalizationsMethod?.Invoke(null, new object[]{this});
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
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, params string[] abbreviations) where TUnitType : Enum
        {
            PerformAbbreviationMapping(unit, CultureInfo.CurrentCulture, false, true, abbreviations);
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
            PerformAbbreviationMapping(unit, CultureInfo.CurrentCulture, true, true, abbreviation);
        }

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider, params string[] abbreviations) where TUnitType : Enum
        {
            PerformAbbreviationMapping(unit, formatProvider, false, true, abbreviations);
        }

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviation">Unit abbreviation to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider, string abbreviation) where TUnitType : Enum
        {
            PerformAbbreviationMapping(unit, formatProvider, true, true, abbreviation);
        }

        /// <summary>
        /// Adds one or more unit abbreviation for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviations">Unit abbreviations to add.</param>
        public void MapUnitToAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider, params string[] abbreviations)
        {
            var enumValue = (Enum)Enum.ToObject(unitType, unitValue);
            PerformAbbreviationMapping(enumValue, formatProvider, false, true, abbreviations);
        }

        /// <summary>
        /// Adds a unit abbreviation for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultAbbreviation{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="abbreviation">Unit abbreviation to add as default.</param>
        public void MapUnitToDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider, string abbreviation)
        {
            var enumValue = (Enum)Enum.ToObject(unitType, unitValue);
            PerformAbbreviationMapping(enumValue, formatProvider, true, true, abbreviation);
        }

        internal void PerformAbbreviationMapping(Enum unitValue, IFormatProvider? formatProvider, bool setAsDefault, bool allowAbbreviationLookup, params string[] abbreviations)
        {
            if (abbreviations == null)
                throw new ArgumentNullException(nameof(abbreviations));

            formatProvider ??= CultureInfo.CurrentCulture;

            if (!_lookupsForCulture.TryGetValue(formatProvider, out var quantitiesForProvider))
                quantitiesForProvider = _lookupsForCulture[formatProvider] = new UnitTypeToLookup();

            var unitType = unitValue.GetType();
            if (!quantitiesForProvider.TryGetValue(unitType, out var unitToAbbreviations))
                unitToAbbreviations = quantitiesForProvider[unitType] = new UnitValueAbbreviationLookup();

            var unitValueAsInt = Convert.ToInt32(unitValue);
            foreach (var abbr in abbreviations)
            {
                unitToAbbreviations.Add(unitValueAsInt, abbr, setAsDefault, allowAbbreviationLookup);
            }
        }

        /// <summary>
        /// Gets the default abbreviation for a given unit. If a unit has more than one abbreviation defined, then it returns the first one.
        /// Example: GetDefaultAbbreviation&lt;LengthUnit&gt;(LengthUnit.Kilometer) => "km"
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <returns>The default unit abbreviation string.</returns>
        public string GetDefaultAbbreviation<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : Enum
        {
            var unitType = typeof(TUnitType);

            if (!TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var lookup))
            {
                return !Equals(formatProvider, FallbackCulture)
                    ? GetDefaultAbbreviation(unit, FallbackCulture)
                    : throw new NotImplementedException($"No abbreviation is specified for {unitType.Name}.{unit}");
            }

            var abbreviations = lookup!.GetAbbreviationsForUnit(unit);
            if (abbreviations.Count == 0)
            {
                return !Equals(formatProvider, FallbackCulture)
                    ? GetDefaultAbbreviation(unit, FallbackCulture)
                    : throw new NotImplementedException($"No abbreviation is specified for {unitType.Name}.{unit}");
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
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>The default unit abbreviation string.</returns>
        public string GetDefaultAbbreviation(Type unitType, int unitValue, IFormatProvider? formatProvider = null)
        {
            if (!TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var lookup))
            {
                return !Equals(formatProvider, FallbackCulture)
                    ? GetDefaultAbbreviation(unitType, unitValue, FallbackCulture)
                    : throw new NotImplementedException($"No abbreviation is specified for {unitType.Name} with numeric value {unitValue}.");
            }

            var abbreviations = lookup!.GetAbbreviationsForUnit(unitValue);
            if (abbreviations.Count == 0)
            {
                return !Equals(formatProvider, FallbackCulture)
                    ? GetDefaultAbbreviation(unitType, unitValue, FallbackCulture)
                    : throw new NotImplementedException($"No abbreviation is specified for {unitType.Name} with numeric value {unitValue}.");
            }

            return abbreviations.First();
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <typeparam name="TUnitType">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        public string[] GetUnitAbbreviations<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : Enum
        {
            return GetUnitAbbreviations(typeof(TUnitType), Convert.ToInt32(unit), formatProvider);
        }

        /// <summary>
        ///     Get all abbreviations for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        public string[] GetUnitAbbreviations(Type unitType, int unitValue, IFormatProvider? formatProvider = null)
        {
            formatProvider ??= CultureInfo.CurrentCulture;

            if (!TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var lookup))
            {
                return !Equals(formatProvider, FallbackCulture)
                    ? GetUnitAbbreviations(unitType, unitValue, FallbackCulture)
                    : new string[] { };
            }

            var abbreviations = lookup!.GetAbbreviationsForUnit(unitValue);
            if (abbreviations.Count == 0)
            {
                return !Equals(formatProvider, FallbackCulture)
                    ? GetUnitAbbreviations(unitType, unitValue, FallbackCulture)
                    : new string[] { };
            }

            return abbreviations.ToArray();
        }

        /// <summary>
        ///     Get all abbreviations for all units of a quantity.
        /// </summary>
        /// <param name="unitEnumType">Enum type for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        public IReadOnlyList<string> GetAllUnitAbbreviationsForQuantity(Type unitEnumType, IFormatProvider? formatProvider = null)
        {
            formatProvider ??= CultureInfo.CurrentCulture;

            if (!TryGetUnitValueAbbreviationLookup(unitEnumType, formatProvider, out var lookup))
            {
                return !Equals(formatProvider, FallbackCulture)
                    ? GetAllUnitAbbreviationsForQuantity(unitEnumType, FallbackCulture)
                    : new string[] { };
            }

            return lookup!.GetAllUnitAbbreviationsForQuantity();
        }

        internal bool TryGetUnitValueAbbreviationLookup(Type unitType, IFormatProvider? formatProvider, out UnitValueAbbreviationLookup? unitToAbbreviations)
        {
            unitToAbbreviations = null;

            formatProvider ??= CultureInfo.CurrentCulture;

            if (!_lookupsForCulture.TryGetValue(formatProvider, out UnitTypeToLookup? quantitiesForProvider))
            {
                return !Equals(formatProvider, FallbackCulture) &&
                       TryGetUnitValueAbbreviationLookup(unitType, FallbackCulture, out unitToAbbreviations);
            }

            if (!quantitiesForProvider.TryGetValue(unitType, out unitToAbbreviations))
            {
                return !Equals(formatProvider, FallbackCulture) &&
                       TryGetUnitValueAbbreviationLookup(unitType, FallbackCulture, out unitToAbbreviations);
            }

            return true;
        }
    }
}
