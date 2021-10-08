// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.InternalHelpers;
using UnitsNet.Units;

using UnitTypeToLookup = System.Collections.Generic.Dictionary<System.Type, UnitsNet.UnitValueToStringLookup>;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    /// Cache of the mapping between unit enum values and unit strings (abbreviation, singular or plural names) for one or more cultures.
    /// This class is used internally by any cache of licalized string representation of a unit value (abbreviation, singular name, plural name)
    /// in order to offer ToString() and Parse() of quantities and units.
    /// </summary>
    public class UnitLocalizationCache
    {
        private readonly string _stringName;
        private readonly Dictionary<IFormatProvider, UnitTypeToLookup> _lookupsForCulture;

        /// <summary>
        ///     Fallback culture used by <see cref="GetUnitStrings{TUnitType}" /> and <see cref="GetDefaultString{TUnitType}" />
        ///     if no abbreviations are found with a given culture.
        /// </summary>
        /// <example>
        ///     User wants to call <see cref="UnitParser.Parse{TUnitType}" /> or <see cref="Length.ToString()" /> with Russian
        ///     culture, but no translation is defined, so we return the US English definition as a last resort. If it's not
        ///     defined there either, an exception is thrown.
        /// </example>
        private static readonly CultureInfo FallbackCulture = new("en-US");

        /// <summary>
        /// Create an instance of the cache
        /// </summary>
        /// <param name="stringName">Information about what the stored strings represents (abbreviation, singular name, ...). It could be useful for error messages or debug logs</param>
        /// <param name="generatedLocalizedStrings">For each culture, for each unit type, for each vlaue, give a localized representation of the unit value</param>
        public UnitLocalizationCache(string stringName, (string CultureName, Type UnitType, int UnitValue, string[] Strings)[] generatedLocalizedStrings)
        {
            _stringName = stringName;
            _lookupsForCulture = new Dictionary<IFormatProvider, UnitTypeToLookup>();
            LoadGeneratedStrings(generatedLocalizedStrings);
        }

        /// <summary>
        /// Create an instance of the cache
        /// </summary>
        /// <param name="generatedLocalizedStrings">For each culture, for each unit type, for each vlaue, give a localized representation of the unit value</param>
        public UnitLocalizationCache((string CultureName, Type UnitType, int UnitValue, string[] Strings)[] generatedLocalizedStrings) :
            this("localized string", generatedLocalizedStrings)
        {
        }

        /// <summary>
        /// Adds one or more unit string for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultString{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="strings">Unit strings to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToStrings<TUnitType>(TUnitType unit, params string[] strings) where TUnitType : Enum =>
            MapUnitToStrings(typeof(TUnitType), Convert.ToInt32(unit), CultureInfo.CurrentUICulture, strings);

        /// <summary>
        /// Adds a unit string for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="UnitsNet.Units.LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultString{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="string">Unit string to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToDefaultString<TUnitType>(TUnitType unit, string @string) where TUnitType : Enum =>
            MapUnitToDefaultString(typeof(TUnitType), Convert.ToInt32(unit), CultureInfo.CurrentUICulture, @string);

        /// <summary>
        /// Adds one or more unit string for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultString{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="strings">Unit strings to add.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToStrings<TUnitType>(TUnitType unit, IFormatProvider formatProvider, params string[] strings) where TUnitType : Enum
        {
            // Assuming TUnitType is an enum, this conversion is safe. Seems not possible to enforce this today.
            // Src: http://stackoverflow.com/questions/908543/how-to-convert-from-system-enum-to-base-integer
            // http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
            var unitValue = Convert.ToInt32(unit);
            var unitType = typeof(TUnitType);

            MapUnitToStrings(unitType, unitValue, formatProvider, strings);
        }

        /// <summary>
        /// Adds a unit string for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultString{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="str">Unit string to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToString<TUnitType>(TUnitType unit, IFormatProvider formatProvider, string str) where TUnitType : Enum
        {
            // Assuming TUnitType is an enum, this conversion is safe. Seems not possible to enforce this today.
            // Src: http://stackoverflow.com/questions/908543/how-to-convert-from-system-enum-to-base-integer
            // http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
            var unitValue = Convert.ToInt32(unit);
            var unitType = typeof(TUnitType);

            MapUnitToDefaultString(unitType, unitValue, formatProvider, str);
        }

        /// <summary>
        /// Adds one or more unit string for the given unit enum value.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultString{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="strings">Unit strings to add.</param>
        public void MapUnitToStrings(Type unitType, int unitValue, IFormatProvider formatProvider, [NotNull] params string[] strings) =>
            PerformStringsMapping(unitType, unitValue, formatProvider, false, strings);


        /// <summary>
        /// Adds a unit string for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultString{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="str">Unit str to add as default.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        public void MapUnitToDefaultString<TUnitType>(TUnitType unit, IFormatProvider formatProvider, string str) where TUnitType : Enum
        {
            // Assuming TUnitType is an enum, this conversion is safe. Seems not possible to enforce this today.
            // Src: http://stackoverflow.com/questions/908543/how-to-convert-from-system-enum-to-base-integer
            // http://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
            var unitValue = Convert.ToInt32(unit);
            var unitType = typeof(TUnitType);

            MapUnitToDefaultString(unitType, unitValue, formatProvider, str);
        }

        /// <summary>
        /// Adds a unit string for the given unit enum value and sets it as the default.
        /// This is used to dynamically add abbreviations for existing unit enums such as <see cref="LengthUnit"/> or to extend with third-party unit enums
        /// in order to <see cref="UnitParser.Parse{TUnitType}"/> or <see cref="GetDefaultString{TUnitType}"/> on them later.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="str">Unit abbreviation to add as default.</param>
        public void MapUnitToDefaultString(Type unitType, int unitValue, IFormatProvider formatProvider, [NotNull] string str) =>
            PerformStringsMapping(unitType, unitValue, formatProvider, true, str);

        private void PerformStringsMapping(Type unitType, int unitValue, IFormatProvider formatProvider, bool setAsDefault, [NotNull] params string[] strings)
        {
            if (!unitType.Wrap().IsEnum)
                throw new ArgumentException("Must be an enum type.", nameof(unitType));

            if (strings == null)
                throw new ArgumentNullException(nameof(strings));

            formatProvider ??= CultureInfo.CurrentUICulture;

            if (!_lookupsForCulture.TryGetValue(formatProvider, out var quantitiesForProvider))
                quantitiesForProvider = _lookupsForCulture[formatProvider] = new UnitTypeToLookup();

            if (!quantitiesForProvider.TryGetValue(unitType, out var unitToStrings))
                unitToStrings = quantitiesForProvider[unitType] = new UnitValueToStringLookup();

            foreach (var str in strings)
            {
                unitToStrings.Add(unitValue, str, setAsDefault);
            }
        }

        /// <summary>
        /// Gets the default string for a given unit. If a unit has more than one abbreviation defined, then it returns the first one.
        /// </summary>
        /// <param name="unit">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <typeparam name="TUnitType">The type of unit enum.</typeparam>
        /// <returns>The default unit string.</returns>
        public string GetDefaultString<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : Enum
        {
            var unitType = typeof(TUnitType);

            if (!TryGetUnitValueStringLookup(unitType, formatProvider, out var lookup))
            {
                if (formatProvider != FallbackCulture)
                    return GetDefaultString(unit, FallbackCulture);
                else
                    throw new NotImplementedException($"No {_stringName} is specified for {unitType.Name}.{unit}");
            }

            var abbreviations = lookup!.GetStringsForUnit(unit);
            if (abbreviations.Count == 0)
            {
                if (formatProvider != FallbackCulture)
                    return GetDefaultString(unit, FallbackCulture);
                else
                    throw new NotImplementedException($"No {_stringName} is specified for {unitType.Name}.{unit}");
            }

            return abbreviations.First();
        }

        /// <summary>
        /// Gets the default string for a given unit type and its numeric enum value.
        /// If a unit has more than one string defined, then it returns the first one.
        /// </summary>
        /// <param name="unitType">The unit enum type.</param>
        /// <param name="unitValue">The unit enum value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>The default unit string.</returns>
        public string GetDefaultString(Type unitType, int unitValue, IFormatProvider? formatProvider = null)
        {
            if (!TryGetUnitValueStringLookup(unitType, formatProvider, out var lookup))
            {
                if (formatProvider != FallbackCulture)
                    return GetDefaultString(unitType, unitValue, FallbackCulture);
                else
                    throw new NotImplementedException($"No abbreviation is specified for {unitType.Name} with numeric value {unitValue}.");
            }

            var strings = lookup!.GetStringsForUnit(unitValue);
            if (strings.Count == 0)
            {
                if (formatProvider != FallbackCulture)
                    return GetDefaultString(unitType, unitValue, FallbackCulture);
                else
                    throw new NotImplementedException($"No {_stringName} is specified for {unitType.Name} with numeric value {unitValue}.");
            }

            return strings.First();
        }

        /// <summary>
        /// Get all strings for unit.
        /// </summary>
        /// <typeparam name="TUnitType">Enum type for units.</typeparam>
        /// <param name="unit">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit strings associated with unit.</returns>
        public string[] GetUnitStrings<TUnitType>(TUnitType unit, IFormatProvider? formatProvider = null) where TUnitType : Enum
        {
            return GetUnitStrings(typeof(TUnitType), Convert.ToInt32(unit), formatProvider);
        }

        /// <summary>
        ///     Get all strings for unit.
        /// </summary>
        /// <param name="unitType">Enum type for unit.</param>
        /// <param name="unitValue">Enum value for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit strings associated with unit.</returns>
        public string[] GetUnitStrings(Type unitType, int unitValue, IFormatProvider? formatProvider = null)
        {
            formatProvider ??= CultureInfo.CurrentUICulture;

            if (!TryGetUnitValueStringLookup(unitType, formatProvider, out var lookup))
                return formatProvider != FallbackCulture ? GetUnitStrings(unitType, unitValue, FallbackCulture) : new string[] { };

            var strings = lookup!.GetStringsForUnit(unitValue);
            if (strings.Count == 0)
                return formatProvider != FallbackCulture ? GetUnitStrings(unitType, unitValue, FallbackCulture) : new string[] { };

            return strings.ToArray();
        }

        /// <summary>
        ///     Get all strings for all units of a quantity.
        /// </summary>
        /// <param name="unitEnumType">Enum type for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit strings associated with unit.</returns>
        public string[] GetAllUnitStringsForQuantity(Type unitEnumType, IFormatProvider? formatProvider = null)
        {
            formatProvider ??= CultureInfo.CurrentUICulture;

            if (!TryGetUnitValueStringLookup(unitEnumType, formatProvider, out var lookup))
                return formatProvider != FallbackCulture ? GetAllUnitStringsForQuantity(unitEnumType, FallbackCulture) : new string[] { };

            return lookup!.GetAllUnitStringsForQuantity();
        }

        internal bool TryGetUnitValueStringLookup(Type unitType, IFormatProvider? formatProvider, out UnitValueToStringLookup? unitToStrings)
        {
            unitToStrings = null;

            formatProvider ??= CultureInfo.CurrentUICulture;

            if (!_lookupsForCulture.TryGetValue(formatProvider, out var quantitiesForProvider))
                return formatProvider != FallbackCulture && TryGetUnitValueStringLookup(unitType, FallbackCulture, out unitToStrings);

            if (!quantitiesForProvider.TryGetValue(unitType, out unitToStrings))
                return formatProvider != FallbackCulture && TryGetUnitValueStringLookup(unitType, FallbackCulture, out unitToStrings);

            return true;
        }

        private void LoadGeneratedStrings((string CultureName, Type UnitType, int UnitValue, string[] Strings)[] generatedLocalizedStrings)
        {
            foreach (var localization in generatedLocalizedStrings)
            {

                var culture = new CultureInfo(localization.CultureName);
                MapUnitToStrings(localization.UnitType, localization.UnitValue, culture, localization.Strings);
            }
        }
    }
}
