// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Cache of the mapping between unit enum values and unit abbreviation strings for one or more cultures.
    ///     A static instance <see cref="Default"/> is used internally for ToString() and Parse() of quantities and units.
    /// </summary>
    public sealed class UnitAbbreviationsCache
    {
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
            throw new NotImplementedException();
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
            return GetDefaultAbbreviation(unitType, Convert.ToInt32(unit), formatProvider);
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
            var abbreviations = GetUnitAbbreviations(unitType, unitValue, formatProvider);
            return abbreviations.Length > 0 ? abbreviations[0] : string.Empty;
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
            var name = Enum.GetName(unitType, unitValue);
            var enumInstance = (Enum)Enum.Parse(unitType, name!);

            if(!Quantity.TryFrom(0.0, enumInstance, out var quantity))
                throw new NotImplementedException($"No abbreviation is specified for {unitType.Name} with numeric value {unitValue}.");

            var unitInfo = Quantity.GetUnitInfo(enumInstance);
            return unitInfo.GetAbbreviations(formatProvider!).ToArray();
        }

        /// <summary>
        ///     Get all abbreviations for all units of a quantity.
        /// </summary>
        /// <param name="unitEnumType">Enum type for unit.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit abbreviations associated with unit.</returns>
        public IReadOnlyList<string> GetAllUnitAbbreviationsForQuantity(Type unitEnumType, IFormatProvider? formatProvider = null)
        {
            var enumValues = Enum.GetValues(unitEnumType).Cast<Enum>();
            var all = GetStringUnitPairs(enumValues, formatProvider);
            return all.Select(pair => pair.Item1).ToList();
        }

        internal List<(string Abbreviation, Enum Unit)> GetStringUnitPairs(IEnumerable<Enum> enumValues, IFormatProvider? formatProvider = null)
        {
            var ret = new List<(string, Enum)>();

            foreach(var enumValue in enumValues)
            {
                var abbreviations = GetUnitAbbreviations(enumValue.GetType(), Convert.ToInt32(enumValue), formatProvider);

                foreach(var abbrev in abbreviations)
                {
                    ret.Add((abbrev, enumValue));
                }
            }

            return ret;
        }
    }
}
