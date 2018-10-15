// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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

#if !WINDOWS_UWP
    internal delegate TQuantity QuantityFromDelegate<out TQuantity, in TUnitType>(QuantityValue value, TUnitType fromUnit)
        where TQuantity : IQuantity
        where TUnitType : Enum;
#else
    internal delegate TQuantity QuantityFromDelegate<out TQuantity, in TUnitType>(double value, TUnitType fromUnit)
        where TQuantity : IQuantity
        where TUnitType : Enum;
#endif

    internal class QuantityParser
    {
        /// <summary>
        /// Allow integer, floating point or exponential number formats.
        /// </summary>
        private const NumberStyles ParseNumberStyles = NumberStyles.Number | NumberStyles.Float | NumberStyles.AllowExponent;

        private readonly UnitAbbreviationsCache _unitAbbreviationsCache;
        private UnitParser _unitParser;

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
