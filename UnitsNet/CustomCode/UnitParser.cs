// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     Parses units given a unit abbreviations cache.
    ///     The static instance <see cref="Default"/> is used internally to parse quantities and units using the
    ///     default abbreviations cache for all units and abbreviations defined in the library.
    /// </summary>
    public sealed class UnitParser
    {
        private readonly UnitAbbreviationsCache _unitAbbreviationsCache;

        /// <summary>
        ///     The default static instance used internally to parse quantities and units using the
        ///     default abbreviations cache for all units and abbreviations defined in the library.
        /// </summary>
        public static UnitParser Default { get; }

        /// <summary>
        ///     Create a parser using the given unit abbreviations cache.
        /// </summary>
        /// <param name="unitAbbreviationsCache"></param>
        public UnitParser(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            _unitAbbreviationsCache = unitAbbreviationsCache ?? UnitAbbreviationsCache.Default;
        }

        static UnitParser()
        {
            Default = new UnitParser(UnitAbbreviationsCache.Default);
        }

        /// <summary>
        /// Parses a unit abbreviation for a given unit enumeration type.
        /// Example: Parse&lt;LengthUnit&gt;("km") => LengthUnit.Kilometer
        /// </summary>
        /// <param name="unitAbbreviation"></param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <typeparam name="TUnitType"></typeparam>
        /// <returns></returns>
        [PublicAPI]
        public TUnitType Parse<TUnitType>(string unitAbbreviation, [CanBeNull] IFormatProvider formatProvider = null) where TUnitType : Enum
        {
            return (TUnitType)Parse(unitAbbreviation, typeof(TUnitType), formatProvider);
        }

        /// <summary>
        ///     Parse a unit abbreviation, such as "kg" or "m", to the unit enum value of the enum type
        ///     <paramref name="unitType" />.
        /// </summary>
        /// <param name="unitAbbreviation">
        ///     Unit abbreviation, such as "kg" or "m" for <see cref="MassUnit.Kilogram" /> and
        ///     <see cref="LengthUnit.Meter" /> respectively.
        /// </param>
        /// <param name="unitType">Unit enum type, such as <see cref="MassUnit" /> and <see cref="LengthUnit" />.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <returns>Unit enum value, such as <see cref="MassUnit.Kilogram" />.</returns>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        [PublicAPI]
        public Enum Parse([NotNull] string unitAbbreviation, Type unitType, [CanBeNull] IFormatProvider formatProvider = null)
        {
            if (unitAbbreviation == null) throw new ArgumentNullException(nameof(unitAbbreviation));
            unitAbbreviation = unitAbbreviation.Trim();

            if(!_unitAbbreviationsCache.TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var abbreviations))
                throw new UnitNotFoundException($"No abbreviations defined for unit type [{unitType}] for culture [{formatProvider}].");

            var unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation, ignoreCase: true);

            if (unitIntValues.Count == 0)
            {
                unitAbbreviation = NormalizeUnitString(unitAbbreviation);
                unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation, ignoreCase: true);
            }

            // Narrow the search if too many hits, for example Megabar "Mbar" and Millibar "mbar" need to be distinguished
            if (unitIntValues.Count > 1)
                unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation, ignoreCase: false);

            switch (unitIntValues.Count)
            {
                case 1:
                    return (Enum) Enum.ToObject(unitType, unitIntValues[0]);
                case 0:
                    throw new UnitNotFoundException($"Unit not found with abbreviation [{unitAbbreviation}] for unit type [{unitType}].");
                default:
                    string unitsCsv = string.Join(", ", unitIntValues.Select(x => Enum.GetName(unitType, x)).ToArray());
                    throw new AmbiguousUnitParseException(
                        $"Cannot parse \"{unitAbbreviation}\" since it could be either of these: {unitsCsv}");
            }
        }

        internal static string NormalizeUnitString(string unitAbbreviation)
        {
            // remove all whitespace in the string
            unitAbbreviation = new string(unitAbbreviation.Where(c => !char.IsWhiteSpace(c)).ToArray());

            unitAbbreviation = unitAbbreviation.Replace("^-9", "⁻⁹");
            unitAbbreviation = unitAbbreviation.Replace("^-8", "⁻⁸");
            unitAbbreviation = unitAbbreviation.Replace("^-7", "⁻⁷");
            unitAbbreviation = unitAbbreviation.Replace("^-6", "⁻⁶");
            unitAbbreviation = unitAbbreviation.Replace("^-5", "⁻⁵");
            unitAbbreviation = unitAbbreviation.Replace("^-4", "⁻⁴");
            unitAbbreviation = unitAbbreviation.Replace("^-3", "⁻³");
            unitAbbreviation = unitAbbreviation.Replace("^-2", "⁻²");
            unitAbbreviation = unitAbbreviation.Replace("^-1", "⁻¹");
            unitAbbreviation = unitAbbreviation.Replace("^1", "");
            unitAbbreviation = unitAbbreviation.Replace("^2", "²");
            unitAbbreviation = unitAbbreviation.Replace("^3", "³");
            unitAbbreviation = unitAbbreviation.Replace("^4", "⁴");
            unitAbbreviation = unitAbbreviation.Replace("^5", "⁵");
            unitAbbreviation = unitAbbreviation.Replace("^6", "⁶");
            unitAbbreviation = unitAbbreviation.Replace("^7", "⁷");
            unitAbbreviation = unitAbbreviation.Replace("^8", "⁸");
            unitAbbreviation = unitAbbreviation.Replace("^9", "⁹");
            unitAbbreviation = unitAbbreviation.Replace("*", "·");
            // "\u03bc" = Lower case Greek letter 'Mu'
            // "\u00b5" = Micro sign
            unitAbbreviation = unitAbbreviation.Replace("\u03bc", "\u00b5");

            return unitAbbreviation;
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <typeparam name="TUnitType">Type of unit enum.</typeparam>
        /// <returns>True if successful.</returns>
        [PublicAPI]
        public bool TryParse<TUnitType>(string unitAbbreviation, out TUnitType unit) where TUnitType : Enum
        {
            return TryParse(unitAbbreviation, null, out unit);
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <typeparam name="TUnitType">Type of unit enum.</typeparam>
        /// <returns>True if successful.</returns>
        [PublicAPI]
        public bool TryParse<TUnitType>(string unitAbbreviation, [CanBeNull] IFormatProvider formatProvider, out TUnitType unit) where TUnitType : Enum
        {
            unit = default;

            if(!TryParse(unitAbbreviation, typeof(TUnitType), formatProvider, out var unitObj))
                return false;

            unit = (TUnitType)unitObj;
            return true;
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="unitType">Type of unit enum.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <returns>True if successful.</returns>
        [PublicAPI]
        public bool TryParse(string unitAbbreviation, Type unitType, out Enum unit)
        {
            return TryParse(unitAbbreviation, unitType, null, out unit);
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="unitType">Type of unit enum.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <returns>True if successful.</returns>
        [PublicAPI]
        public bool TryParse(string unitAbbreviation, Type unitType, [CanBeNull] IFormatProvider formatProvider, out Enum unit)
        {
            if (unitAbbreviation == null)
            {
                unit = default;
                return false;
            }

            unitAbbreviation = unitAbbreviation.Trim();
            unit = default;

            if(!_unitAbbreviationsCache.TryGetUnitValueAbbreviationLookup(unitType, formatProvider, out var abbreviations))
                return false;

            var unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation, ignoreCase: true);

            if (unitIntValues.Count == 0)
            {
                unitAbbreviation = NormalizeUnitString(unitAbbreviation);
                unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation, ignoreCase: true);
            }

            // Narrow the search if too many hits, for example Megabar "Mbar" and Millibar "mbar" need to be distinguished
            if (unitIntValues.Count > 1)
                unitIntValues = abbreviations.GetUnitsForAbbreviation(unitAbbreviation, ignoreCase: false);

            if(unitIntValues.Count != 1)
                return false;

            unit = (Enum)Enum.ToObject(unitType, unitIntValues[0]);
            return true;
        }
    }
}
