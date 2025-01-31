// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
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
        ///     The default singleton instance for parsing units from the default configured unit abbreviations.
        /// </summary>
        /// <remarks>
        ///     Convenience shortcut for <see cref="UnitsNetSetup"/>.<see cref="UnitsNetSetup.Default"/>.<see cref="UnitsNetSetup.UnitParser"/>.
        /// </remarks>
        public static UnitParser Default => UnitsNetSetup.Default.UnitParser;

        /// <summary>
        ///     Create a parser using the given unit abbreviations cache.
        /// </summary>
        /// <param name="unitAbbreviationsCache">The unit abbreviations to parse with.</param>
        /// <exception cref="ArgumentNullException">No unit abbreviations cache was given.</exception>
        public UnitParser(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            _unitAbbreviationsCache = unitAbbreviationsCache ?? throw new ArgumentNullException(nameof(unitAbbreviationsCache));
        }

        /// <summary>
        /// Parses a unit abbreviation for a given unit enumeration type.
        /// Example: Parse&lt;LengthUnit&gt;("km") => LengthUnit.Kilometer
        /// </summary>
        /// <param name="unitAbbreviation"></param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <typeparam name="TUnitType"></typeparam>
        /// <returns></returns>
        public TUnitType Parse<TUnitType>(string unitAbbreviation, IFormatProvider? formatProvider = null)
            where TUnitType : struct, Enum
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
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <returns>Unit enum value, such as <see cref="MassUnit.Kilogram" />.</returns>
        /// <exception cref="UnitNotFoundException">No units match the abbreviation.</exception>
        /// <exception cref="AmbiguousUnitParseException">More than one unit matches the abbreviation.</exception>
        public Enum Parse(string unitAbbreviation, Type unitType, IFormatProvider? formatProvider = null)
        {
            if (unitAbbreviation == null) throw new ArgumentNullException(nameof(unitAbbreviation));
            unitAbbreviation = unitAbbreviation.Trim();
            Enum[] enumValues = Enum.GetValues(unitType).Cast<Enum>().ToArray();
            while (true)
            {
                (Enum Unit, string Abbreviation)[] matches = FindMatchingUnits(unitAbbreviation, enumValues, formatProvider);
                switch(matches.Length)
                {
                    case 1:
                        return matches[0].Unit;
                    case 0:
                        // Retry with fallback culture, if different.
                        if (Equals(formatProvider, UnitAbbreviationsCache.FallbackCulture))
                        {
                            throw new UnitNotFoundException($"Unit not found with abbreviation [{unitAbbreviation}] for unit type [{unitType}].");
                        }

                        formatProvider = UnitAbbreviationsCache.FallbackCulture;
                        continue;
                    default:
                        var unitsCsv = string.Join(", ", matches.Select(x => $"{Enum.GetName(unitType, x.Unit)} (\"{x.Abbreviation}\")").OrderBy(x => x));
                        throw new AmbiguousUnitParseException($"Cannot parse \"{unitAbbreviation}\" since it matches multiple units: {unitsCsv}.");
                }
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
        public bool TryParse<TUnitType>([NotNullWhen(true)]string? unitAbbreviation, out TUnitType unit)
            where TUnitType : struct, Enum
        {
            return TryParse(unitAbbreviation, null, out unit);
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <typeparam name="TUnitType">Type of unit enum.</typeparam>
        /// <returns>True if successful.</returns>
        public bool TryParse<TUnitType>([NotNullWhen(true)]string? unitAbbreviation, IFormatProvider? formatProvider, out TUnitType unit)
            where TUnitType : struct, Enum
        {
            unit = default;

            if (!TryParse(unitAbbreviation, typeof(TUnitType), formatProvider, out var unitObj))
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
        public bool TryParse([NotNullWhen(true)] string? unitAbbreviation, Type unitType, [NotNullWhen(true)] out Enum? unit)
        {
            return TryParse(unitAbbreviation, unitType, null, out unit);
        }

        /// <summary>
        /// Try to parse a unit abbreviation.
        /// </summary>
        /// <param name="unitAbbreviation">The string value.</param>
        /// <param name="unitType">Type of unit enum.</param>
        /// <param name="formatProvider">The format provider to use for lookup. Defaults to <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <param name="unit">The unit enum value as out result.</param>
        /// <returns>True if successful.</returns>
        public bool TryParse([NotNullWhen(true)] string? unitAbbreviation, Type unitType, IFormatProvider? formatProvider, [NotNullWhen(true)] out Enum? unit)
        {
            unit = null;
            if (unitAbbreviation == null)
            {
                return false;
            }

            unitAbbreviation = unitAbbreviation.Trim();
            Enum[] enumValues = Enum.GetValues(unitType).Cast<Enum>().ToArray();
            (Enum Unit, string Abbreviation)[] matches = FindMatchingUnits(unitAbbreviation, enumValues, formatProvider);

            if (matches.Length == 1)
            {
                unit = matches[0].Unit;
                return true;
            }

            if (matches.Length != 0 || Equals(formatProvider, UnitAbbreviationsCache.FallbackCulture))
            {
                return false; // either there are duplicates or nothing was matched and we're already using the fallback culture
            }

            // retry the lookup using the fallback culture
            matches = FindMatchingUnits(unitAbbreviation, enumValues, UnitAbbreviationsCache.FallbackCulture);
            if (matches.Length != 1)
            {
                return false;
            }

            unit = matches[0].Unit;
            return true;
        }

        private (Enum Unit, string Abbreviation)[] FindMatchingUnits(string unitAbbreviation, IEnumerable<Enum> enumValues, IFormatProvider? formatProvider)
        {
            // TODO see about optimizing this method: both Parse and TryParse only care about having one match (in case of a failure we could return the number of matches)
            List<(Enum Unit, string Abbreviation)> stringUnitPairs = _unitAbbreviationsCache.GetStringUnitPairs(enumValues, formatProvider);
            (Enum Unit, string Abbreviation)[] matches =
                stringUnitPairs.Where(pair => pair.Abbreviation.Equals(unitAbbreviation, StringComparison.OrdinalIgnoreCase)).ToArray();

            if (matches.Length == 0)
            {
                var normalizeUnitString = NormalizeUnitString(unitAbbreviation);
                if (unitAbbreviation != normalizeUnitString)
                {
                    unitAbbreviation = normalizeUnitString;
                    matches = stringUnitPairs.Where(pair => pair.Abbreviation.Equals(unitAbbreviation, StringComparison.OrdinalIgnoreCase)).ToArray();
                }
            }

            if (matches.Length == 1)
            {
                return matches;
            }
            
            // Narrow the search if too many hits, for example Megabar "Mbar" and Millibar "mbar" need to be distinguished
            (Enum Unit, string Abbreviation)[] caseSensitiveMatches = stringUnitPairs.Where(pair => pair.Abbreviation.Equals(unitAbbreviation)).ToArray();
            return caseSensitiveMatches.Length == 0 ? matches : caseSensitiveMatches;
        }

        /// <summary>
        ///     Retrieves the unit information from the given unit abbreviation.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations
        ///     each time.<br />
        ///     Unit abbreviation matching in the <see cref="TryParse{TUnitType}(string?,out TUnitType)" />
        ///     overload is case-insensitive.<br />
        ///     <br />
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br />
        /// </remarks>
        /// <param name="unitAbbreviation">The unit abbreviation to parse.</param>
        /// <param name="formatProvider">The format provider to use for culture-specific formatting. Can be null.</param>
        /// <returns>The unit information corresponding to the given unit abbreviation.</returns>
        /// <exception cref="UnitNotFoundException">
        ///     Thrown when the unit abbreviation is not recognized as a valid unit for the specified culture.
        /// </exception>
        /// <exception cref="AmbiguousUnitParseException">
        ///     Thrown when multiple units are found matching the given unit abbreviation.
        /// </exception>
        internal UnitInfo GetUnitFromAbbreviation(string unitAbbreviation, IFormatProvider? formatProvider)
        {
            List<UnitInfo> units = _unitAbbreviationsCache.GetUnitsForAbbreviation(formatProvider, unitAbbreviation);
            return units.Count switch
            {
                0 => throw new UnitNotFoundException(
                    $"The unit abbreviation '{unitAbbreviation}' is not recognized as a valid unit for the specified culture."),
                1 => units[0],
                _ => throw new AmbiguousUnitParseException(
                    $"Cannot parse \"{unitAbbreviation}\" since it matches multiple units: {string.Join(", ", units.Select(x => x.Name).OrderBy(x => x))}.")
            };
        }

        /// <summary>
        ///     Attempts to parse the specified unit abbreviation into an <see cref="UnitInfo" /> object.
        /// </summary>
        /// <remarks>
        ///     This method is currently not optimized for performance and will enumerate all units and their unit abbreviations
        ///     each time.<br />
        ///     Unit abbreviation matching in the <see cref="TryParse{TUnitType}(string,out TUnitType)" />
        ///     overload is case-insensitive.<br />
        ///     <br />
        ///     This will fail if more than one unit across all quantities share the same unit abbreviation.<br />
        /// </remarks>
        /// <param name="unitAbbreviation">The unit abbreviation to parse.</param>
        /// <param name="formatProvider">The format provider to use for parsing, or <c>null</c> to use the current culture.</param>
        /// <param name="unit">
        ///     When this method returns, contains the parsed <see cref="UnitInfo" /> object if the parsing succeeded,
        ///     or <c>null</c> if the parsing failed. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the unit abbreviation was successfully parsed; otherwise, <c>false</c>.
        /// </returns>
        internal bool TryGetUnitFromAbbreviation([NotNullWhen(true)]string? unitAbbreviation, IFormatProvider? formatProvider, [NotNullWhen(true)] out UnitInfo? unit)
        {
            if (unitAbbreviation == null)
            {
                unit = null;
                return false;
            }

            List<UnitInfo> units = _unitAbbreviationsCache.GetUnitsForAbbreviation(formatProvider, unitAbbreviation);
            if (units.Count == 1)
            {
                unit = units[0];
                return true;
            }

            unit = null;
            return false;
        }
    }
}
