// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using UnitsNet.Units;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{
    /// <summary>
    ///     A method signature for creating a quantity given a numeric value and a strongly typed unit, for example 1.0 and <see cref="LengthUnit.Meter"/>.
    /// </summary>
    /// <typeparam name="TQuantity">The type of quantity to create, such as <see cref="Length"/>.</typeparam>
    /// <typeparam name="TUnitType">The type of unit enum that belongs to this quantity, such as <see cref="LengthUnit"/> for <see cref="Length"/>.</typeparam>
    public delegate TQuantity QuantityFromDelegate<out TQuantity, in TUnitType>(QuantityValue value, TUnitType fromUnit)
        where TQuantity : IQuantity
        where TUnitType : Enum;

    /// <summary>
    ///     Parses quantities from strings, such as "1.2 kg" to <see cref="Length"/> or "100 cm" to <see cref="Mass"/>.
    /// </summary>
    public class QuantityParser
    {
        /// <summary>
        /// Allow integer, floating point or exponential number formats.
        /// </summary>
        private const NumberStyles ParseNumberStyles = NumberStyles.Number | NumberStyles.Float | NumberStyles.AllowExponent;

        private readonly UnitAbbreviationsCache _unitAbbreviationsCache;
        private readonly UnitParser _unitParser;

        /// <summary>
        ///     The default instance of <see cref="QuantityParser"/>, which uses <see cref="UnitAbbreviationsCache.Default"/> unit abbreviations.
        /// </summary>
        [Obsolete("Use UnitsNetSetup.Default.QuantityParser instead.")]
        public static QuantityParser Default => UnitsNetSetup.Default.QuantityParser;

        /// <summary>
        ///     Creates an instance of <see cref="QuantityParser"/>, optionally specifying an <see cref="UnitAbbreviationsCache"/>
        ///     with unit abbreviations to use when parsing.
        /// </summary>
        /// <param name="unitAbbreviationsCache">(Optional) The unit abbreviations cache, or specify <c>null</c> to use <see cref="UnitAbbreviationsCache.Default"/>.</param>
        public QuantityParser(UnitAbbreviationsCache? unitAbbreviationsCache = null)
        {
            _unitAbbreviationsCache = unitAbbreviationsCache ?? UnitAbbreviationsCache.Default;
            _unitParser = new UnitParser(_unitAbbreviationsCache);
        }

        /// <summary>
        ///     Parses a quantity from a string, such as "1.2 kg" to <see cref="Length"/> or "100 cm" to <see cref="Mass"/>.
        /// </summary>
        /// <param name="str">The string to parse, such as "1.2 kg".</param>
        /// <param name="formatProvider">The culture for looking up localized unit abbreviations for a language, and for parsing the number formatted in this culture. Defaults to <see cref="CultureInfo.CurrentCulture"/>.</param>
        /// <param name="fromDelegate">A function to create a quantity given a numeric value and a unit enum value.</param>
        /// <typeparam name="TQuantity">The type of quantity to create, such as <see cref="Length"/>.</typeparam>
        /// <typeparam name="TUnitType">The type of unit enum that belongs to this quantity, such as <see cref="LengthUnit"/> for <see cref="Length"/>.</typeparam>
        /// <returns>The parsed quantity if successful.</returns>
        /// <exception cref="ArgumentNullException">The string was null.</exception>
        /// <exception cref="FormatException">Failed to parse quantity.</exception>
        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        public TQuantity Parse<TQuantity, TUnitType>(string str,
            IFormatProvider? formatProvider,
            QuantityFromDelegate<TQuantity, TUnitType> fromDelegate)
            where TQuantity : IQuantity
            where TUnitType : Enum
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            str = str.Trim();

            var regex = CreateRegexForQuantity<TUnitType>(formatProvider);

            if (!TryExtractValueAndUnit(regex, str, out var valueString, out var unitString))
            {
                var ex = new FormatException("Unable to parse quantity. Expected the form \"{value} {unit abbreviation}\", such as \"5.5 m\". The spacing is optional.");
                ex.Data["input"] = str;
                throw ex;
            }

            return ParseWithRegex(valueString, unitString, fromDelegate, formatProvider);
        }

        /// <summary>
        ///     Tries to parse a quantity from a string, such as "1.2 kg" to <see cref="Length"/> or "100 cm" to <see cref="Mass"/>.
        /// </summary>
        /// <param name="str">The string to parse, such as "1.2 kg".</param>
        /// <param name="formatProvider">The culture for looking up localized unit abbreviations for a language, and for parsing the number formatted in this culture. Defaults to <see cref="CultureInfo.CurrentCulture"/>.</param>
        /// <param name="fromDelegate">A function to create a quantity given a numeric value and a unit enum value.</param>
        /// <param name="result">The parsed quantity if successful, otherwise null.</param>
        /// <typeparam name="TQuantity">The type of quantity to create, such as <see cref="Length"/>.</typeparam>
        /// <typeparam name="TUnitType">The type of unit enum that belongs to this quantity, such as <see cref="LengthUnit"/> for <see cref="Length"/>.</typeparam>
        /// <returns>True if successful.</returns>
        /// <exception cref="ArgumentNullException">The string was null.</exception>
        /// <exception cref="FormatException">Failed to parse quantity.</exception>
        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        public bool TryParse<TQuantity, TUnitType>(string? str,
            IFormatProvider? formatProvider,
            QuantityFromDelegate<TQuantity, TUnitType> fromDelegate,
            out TQuantity result)
            where TQuantity : struct, IQuantity
            where TUnitType : struct, Enum
        {
            result = default;

            if (string.IsNullOrWhiteSpace(str)) return false;
            str = str!.Trim(); // netstandard2.0 nullable quirk

            var regex = CreateRegexForQuantity<TUnitType>(formatProvider);

            return TryExtractValueAndUnit(regex, str, out var valueString, out var unitString) &&
                   TryParseWithRegex(valueString, unitString, fromDelegate, formatProvider, out result);
        }

        /// <summary>
        ///     Tries to parse a quantity from a string, such as "1.2 kg" to <see cref="Length"/> or "100 cm" to <see cref="Mass"/>.
        /// </summary>
        /// <remarks>
        ///     Similar to <see cref="TryParse{TQuantity,TUnitType}(string?,System.IFormatProvider?,UnitsNet.QuantityFromDelegate{TQuantity,TUnitType},out TQuantity)"/>,
        ///     but returns <see cref="IQuantity"/> instead. This is workaround for C# not allowing to pass on 'out' param from type Length to IQuantity,
        ///     even though the are compatible.
        /// </remarks>
        /// <param name="str">The string to parse, such as "1.2 kg".</param>
        /// <param name="formatProvider">The culture for looking up localized unit abbreviations for a language, and for parsing the number formatted in this culture. Defaults to <see cref="CultureInfo.CurrentCulture"/>.</param>
        /// <param name="fromDelegate">A function to create a quantity given a numeric value and a unit enum value.</param>
        /// <param name="result">The parsed quantity if successful, otherwise null.</param>
        /// <typeparam name="TQuantity">The type of quantity to create, such as <see cref="Length"/>.</typeparam>
        /// <typeparam name="TUnitType">The type of unit enum that belongs to this quantity, such as <see cref="LengthUnit"/> for <see cref="Length"/>.</typeparam>
        /// <returns>True if successful.</returns>
        /// <exception cref="ArgumentNullException">The string was null.</exception>
        /// <exception cref="FormatException">Failed to parse quantity.</exception>
        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        public bool TryParse<TQuantity, TUnitType>(string str,
            IFormatProvider? formatProvider,
            QuantityFromDelegate<TQuantity, TUnitType> fromDelegate,
            out IQuantity? result)
            where TQuantity : struct, IQuantity
            where TUnitType : struct, Enum
        {
            if (TryParse(str, formatProvider, fromDelegate, out TQuantity parsedQuantity))
            {
                result = parsedQuantity;
                return true;
            }

            result = default;
            return false;
        }

        internal string CreateRegexPatternForUnit<TUnitType>(
            TUnitType unit,
            IFormatProvider? formatProvider,
            bool matchEntireString = true)
            where TUnitType : Enum
        {
            var unitAbbreviations = _unitAbbreviationsCache.GetUnitAbbreviations(unit, formatProvider);
            var pattern = GetRegexPatternForUnitAbbreviations(unitAbbreviations);
            return matchEntireString ? $"^{pattern}$" : pattern;
        }

        private static string GetRegexPatternForUnitAbbreviations(IEnumerable<string> abbreviations)
        {
            var orderedAbbreviations = abbreviations
                .OrderByDescending(s => s.Length) // Important to order by length -- if "m" is before "mm" and the input is "mm", it will match just "m"
                .Select(Regex.Escape) // Escape special regex characters
                .ToArray();

            var abbreviationsPiped = $"{string.Join("|", orderedAbbreviations)}";
            return $@"(?<value>.*?)\s?(?<unit>{abbreviationsPiped})";
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private TQuantity ParseWithRegex<TQuantity, TUnitType>(string valueString,
            string unitString,
            QuantityFromDelegate<TQuantity, TUnitType> fromDelegate,
            IFormatProvider? formatProvider)
            where TQuantity : IQuantity
            where TUnitType : Enum
        {
            var value = double.Parse(valueString, ParseNumberStyles, formatProvider);
            var parsedUnit = _unitParser.Parse<TUnitType>(unitString, formatProvider);
            return fromDelegate(value, parsedUnit);
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private bool TryParseWithRegex<TQuantity, TUnitType>(string? valueString,
            string? unitString,
            QuantityFromDelegate<TQuantity, TUnitType> fromDelegate,
            IFormatProvider? formatProvider,
            out TQuantity result)
            where TQuantity : struct, IQuantity
            where TUnitType : struct, Enum
        {
            result = default;

            if (!double.TryParse(valueString, ParseNumberStyles, formatProvider, out var value))
                    return false;

            if (!_unitParser.TryParse<TUnitType>(unitString, formatProvider, out var parsedUnit))
                    return false;

            result = fromDelegate(value, parsedUnit);
            return true;
        }

        private static bool TryExtractValueAndUnit(Regex regex, string str, [NotNullWhen(true)] out string? valueString, [NotNullWhen(true)] out string? unitString)
        {
            var match = regex.Match(str);

            // the regex coming in contains all allowed units as strings.
            // That means if the unit in str is not formatted right
            // the regex.Match will ether put str or string.empty into Groups[0] and Groups[1]
            // Therefore a mismatch can be detected by comparing the values of this two groups.
            if (match.Groups[0].Value == match.Groups[1].Value)
            {
                str = UnitParser.NormalizeUnitString(str);
                match = regex.Match(str);
            }

            var groups = match.Groups;

            var valueGroup = groups["value"];
            var unitGroup = groups["unit"];
            if (!valueGroup.Success || !unitGroup.Success)
            {
                valueString = null;
                unitString = null;
                return false;
            }

            valueString = valueGroup.Value;
            unitString = unitGroup.Value;
            return true;
        }

        private string CreateRegexPatternForQuantity<TUnitType>(IFormatProvider? formatProvider) where TUnitType : Enum
        {
            var unitAbbreviations = _unitAbbreviationsCache.GetAllUnitAbbreviationsForQuantity(typeof(TUnitType), formatProvider);
            var pattern = GetRegexPatternForUnitAbbreviations(unitAbbreviations);

            // Match entire string exactly
            return $"^{pattern}$";
        }

        private Regex CreateRegexForQuantity<TUnitType>(IFormatProvider? formatProvider) where TUnitType : Enum
        {
            var pattern = CreateRegexPatternForQuantity<TUnitType>(formatProvider);
            return new Regex(pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }
    }
}
