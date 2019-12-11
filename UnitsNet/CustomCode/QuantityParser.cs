// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace UnitsNet
{

    internal delegate TQuantity QuantityFromDelegate<out TQuantity, in TUnitType>(QuantityValue value, TUnitType fromUnit)
        where TQuantity : IQuantity
        where TUnitType : Enum;

    internal class QuantityParser
    {
        /// <summary>
        /// Allow integer, floating point or exponential number formats.
        /// </summary>
        private const NumberStyles ParseNumberStyles = NumberStyles.Number | NumberStyles.Float | NumberStyles.AllowExponent;

        private readonly UnitAbbreviationsCache _unitAbbreviationsCache;
        private readonly UnitParser _unitParser;

        public static QuantityParser Default { get; }

        public QuantityParser(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            _unitAbbreviationsCache = unitAbbreviationsCache ?? UnitAbbreviationsCache.Default;
            _unitParser = new UnitParser(_unitAbbreviationsCache);
        }

        static QuantityParser()
        {
            Default = new QuantityParser(UnitAbbreviationsCache.Default);
        }

        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        internal TQuantity Parse<TQuantity, TUnitType>([NotNull] string str,
            [CanBeNull] IFormatProvider formatProvider,
            [NotNull] QuantityFromDelegate<TQuantity, TUnitType> fromDelegate)
            where TQuantity : IQuantity
            where TUnitType : Enum
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            str = str.Trim();

            var numFormat = formatProvider != null
                ? (NumberFormatInfo) formatProvider.GetFormat(typeof(NumberFormatInfo))
                : NumberFormatInfo.CurrentInfo;

            if (numFormat == null)
                throw new InvalidOperationException($"No number format was found for the given format provider: {formatProvider}");

            var regex = CreateRegexForQuantity<TUnitType>(formatProvider);

            if (!ExtractValueAndUnit(regex, str, out var valueString, out var unitString))
            {
                var ex = new FormatException("Unable to parse quantity. Expected the form \"{value} {unit abbreviation}\", such as \"5.5 m\". The spacing is optional.");
                ex.Data["input"] = str;
                throw ex;
            }

            return ParseWithRegex(valueString, unitString, fromDelegate, formatProvider);
        }

        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        internal bool TryParse<TQuantity, TUnitType>([NotNull] string str,
            [CanBeNull] IFormatProvider formatProvider,
            [NotNull] QuantityFromDelegate<TQuantity, TUnitType> fromDelegate,
            out TQuantity result)
            where TQuantity : IQuantity
            where TUnitType : Enum
        {
            result = default;

            if(string.IsNullOrWhiteSpace(str)) return false;
            str = str.Trim();

            var numFormat = formatProvider != null
                ? (NumberFormatInfo) formatProvider.GetFormat(typeof(NumberFormatInfo))
                : NumberFormatInfo.CurrentInfo;

            if(numFormat == null)
                return false;

            var regex = CreateRegexForQuantity<TUnitType>(formatProvider);

            if (!ExtractValueAndUnit(regex, str, out var valueString, out var unitString))
                return false;

            return TryParseWithRegex(valueString, unitString, fromDelegate, formatProvider, out result);
        }

        /// <summary>
        ///     Workaround for C# not allowing to pass on 'out' param from type Length to IQuantity, even though the are compatible.
        /// </summary>
        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        internal bool TryParse<TQuantity, TUnitType>([NotNull] string str,
            [CanBeNull] IFormatProvider formatProvider,
            [NotNull] QuantityFromDelegate<TQuantity, TUnitType> fromDelegate,
            out IQuantity result)
            where TQuantity : IQuantity
            where TUnitType : Enum
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
            IFormatProvider formatProvider,
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
            IFormatProvider formatProvider)
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
        private bool TryParseWithRegex<TQuantity, TUnitType>(string valueString,
            string unitString,
            QuantityFromDelegate<TQuantity, TUnitType> fromDelegate,
            IFormatProvider formatProvider,
            out TQuantity result)
            where TQuantity : IQuantity
            where TUnitType : Enum
        {
            result = default;

            if (!double.TryParse(valueString, ParseNumberStyles, formatProvider, out var value))
                    return false;

            if (!_unitParser.TryParse<TUnitType>(unitString, formatProvider, out var parsedUnit))
                    return false;

            result = fromDelegate(value, parsedUnit);
            return true;
        }

        private static bool ExtractValueAndUnit(Regex regex, string str, out string valueString, out string unitString)
        {
            var match = regex.Match(str);

            // the regex coming in contains all allowed units as strings.
            // That means if the unit in str is not formatted right
            // the regex.Match will ether put str or string.empty into Groups[0] and Groups[1]
            // Therefor a mismatch can be detected by comparing the values of this two groups.
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

        private string CreateRegexPatternForQuantity<TUnitType>(IFormatProvider formatProvider) where TUnitType : Enum
        {
            var unitAbbreviations = _unitAbbreviationsCache.GetAllUnitAbbreviationsForQuantity(typeof(TUnitType), formatProvider);
            var pattern = GetRegexPatternForUnitAbbreviations(unitAbbreviations);

            // Match entire string exactly
            return $"^{pattern}$";
        }

        private Regex CreateRegexForQuantity<TUnitType>([CanBeNull] IFormatProvider formatProvider) where TUnitType : Enum
        {
            var pattern = CreateRegexPatternForQuantity<TUnitType>(formatProvider);
            return new Regex(pattern, RegexOptions.Singleline);
        }
    }
}
