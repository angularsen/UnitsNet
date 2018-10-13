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
    internal delegate TUnitType ParseUnitDelegate<out TUnitType>(string unitString, IFormatProvider formatProvider) where TUnitType : Enum;
    internal delegate bool TryParseUnitDelegate<TUnitType>(string unitString, IFormatProvider formatProvider, out TUnitType unit) where TUnitType : Enum;

#if !WINDOWS_UWP
    internal delegate TQuantity QuantityFromDelegate<out TQuantity, TUnitType>(QuantityValue value, TUnitType fromUnit)
        where TQuantity : IQuantity
        where TUnitType : Enum;
#else
    internal delegate TQuantity QuantityFromDelegate<out TQuantity, TUnitType>(double value, TUnitType fromUnit)
        where TQuantity : IQuantity
        where TUnitType : Enum;
#endif

    internal class QuantityParser
    {
        private readonly UnitAbbreviationsCache unitAbbreviationsCache;

        public static QuantityParser Default { get; }

        public QuantityParser(UnitAbbreviationsCache unitAbbreviationsCache)
        {
            this.unitAbbreviationsCache = unitAbbreviationsCache ?? UnitAbbreviationsCache.Default;
        }

        static QuantityParser()
        {
            Default = new QuantityParser(UnitAbbreviationsCache.Default);
        }

        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        internal TQuantity Parse<TQuantity, TUnitType>([NotNull] string str,
            [CanBeNull] IFormatProvider formatProvider,
            [NotNull] ParseUnitDelegate<TUnitType> parseUnit,
            [NotNull] QuantityFromDelegate<TQuantity, TUnitType> fromDelegate,
            [NotNull] Func<TQuantity, TQuantity, TQuantity> add)
            where TQuantity : IQuantity
            where TUnitType : Enum
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            if (parseUnit == null) throw new ArgumentNullException(nameof(parseUnit));
            if (add == null) throw new ArgumentNullException(nameof(add));

            var numFormat = formatProvider != null
                ? (NumberFormatInfo) formatProvider.GetFormat(typeof(NumberFormatInfo))
                : NumberFormatInfo.CurrentInfo;

            if (numFormat == null)
                throw new InvalidOperationException($"No number format was found for the given format provider: {formatProvider}");

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",
                // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                numFormat.NumberGroupSeparator, // adds provided (or current) culture's group separator
                numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator

            const string exponentialRegex = @"(?:[eE][-+]?\d+)?)";

            var unitAbbreviations = unitAbbreviationsCache.GetAllAbbreviations(typeof(TUnitType))
                .OrderByDescending(s => s.Length)       // Important to order by length -- if "m" is before "mm" and the input is "mm", it will match just "m" and throw invalid string error
                .Select(Regex.Escape)                   // Escape special regex characters
                .ToArray();

            var unitsRegex = $"({String.Join("|", unitAbbreviations)})";

            var regexString = string.Format(@"(?:\s*(?<value>[-+]?{0}{1}{2}{3})?{4}{5}",
                numRegex, // capture base (integral) Quantity value
                exponentialRegex, // capture exponential (if any), end of Quantity capturing
                @"\s?", // ignore whitespace (allows both "1kg", "1 kg")
                $@"(?<unit>{unitsRegex})", // capture Unit by list of abbreviations
                @"(and)?,?", // allow "and" & "," separators between quantities
                @"(?<invalid>[a-z]*)?"); // capture invalid input

            var quantities = ParseWithRegex(regexString, str, parseUnit, fromDelegate, formatProvider);
            if (quantities.Count == 0)
            {
                throw new ArgumentException(
                    "Expected string to have at least one pair of quantity and unit in the format"
                    + " \"&lt;quantity&gt; &lt;unit&gt;\". Eg. \"5.5 m\" or \"1ft 2in\"");
            }

            return quantities.Aggregate(add);
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static List<TQuantity> ParseWithRegex<TQuantity, TUnitType>(string regexString, string str, ParseUnitDelegate<TUnitType> parseUnit,
            QuantityFromDelegate<TQuantity, TUnitType> fromDelegate, IFormatProvider formatProvider = null)
            where TQuantity : IQuantity
            where TUnitType : Enum
        {
            var regex = new Regex(regexString);
            var matches = regex.Matches(str.Trim());
            var converted = new List<TQuantity>();

            foreach (Match match in matches)
            {
                var groups = match.Groups;

                var valueString = groups["value"].Value;
                var unitString = groups["unit"].Value;
                if (groups["invalid"].Value != string.Empty)
                {
                    var newEx = new UnitsNetException("Invalid string detected: " + groups["invalid"].Value);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider?.ToString();
                    throw newEx;
                }

                if ((valueString == string.Empty) && (unitString == string.Empty))
                    continue;

                try
                {
                    var value = double.Parse(valueString, formatProvider);
                    var parsedUnit = parseUnit(unitString, formatProvider);
                    var quantity = fromDelegate(value, parsedUnit);

                    converted.Add(quantity);
                }
                catch (AmbiguousUnitParseException)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    var newEx = new UnitsNetException("Error parsing string.", ex);
                    newEx.Data["input"] = str;
                    newEx.Data["matched value"] = valueString;
                    newEx.Data["matched unit"] = unitString;
                    newEx.Data["formatprovider"] = formatProvider?.ToString();
                    throw newEx;
                }
            }

            return converted;
        }

        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        internal bool TryParse<TQuantity, TUnitType>([NotNull] string str,
            [CanBeNull] IFormatProvider formatProvider,
            [NotNull] TryParseUnitDelegate<TUnitType> parseUnit,
            [NotNull] QuantityFromDelegate<TQuantity, TUnitType> fromDelegate,
            [NotNull] Func<TQuantity, TQuantity, TQuantity> add, out TQuantity value)
            where TQuantity : IQuantity
            where TUnitType : Enum
        {
            value = default(TQuantity);

            if(string.IsNullOrWhiteSpace(str)) return false;
            if(parseUnit == null) return false;
            if(add == null) return false;

            var numFormat = formatProvider != null
                ? (NumberFormatInfo) formatProvider.GetFormat(typeof(NumberFormatInfo))
                : NumberFormatInfo.CurrentInfo;

            if(numFormat == null)
                return false;

            var numRegex = string.Format(@"[\d., {0}{1}]*\d",
                // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                numFormat.NumberGroupSeparator, // adds provided (or current) culture's group separator
                numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator

            const string exponentialRegex = @"(?:[eE][-+]?\d+)?)";

            var unitAbbreviations = unitAbbreviationsCache.GetAllAbbreviations(typeof(TUnitType))
                .OrderByDescending(s => s.Length)       // Important to order by length -- if "m" is before "mm" and the input is "mm", it will match just "m" and throw invalid string error
                .Select(Regex.Escape)                   // Escape special regex characters
                .ToArray();

            var unitsRegex = $"({String.Join("|", unitAbbreviations)})";

            var regexString = string.Format(@"(?:\s*(?<value>[-+]?{0}{1}{2}{3})?{4}{5}",
                numRegex, // capture base (integral) Quantity value
                exponentialRegex, // capture exponential (if any), end of Quantity capturing
                @"\s?", // ignore whitespace (allows both "1kg", "1 kg")
                $@"(?<unit>{unitsRegex})", // capture Unit by list of abbreviations
                @"(and)?,?", // allow "and" & "," separators between quantities
                @"(?<invalid>[a-z]*)?"); // capture invalid input

            if(!TryParseWithRegex<TQuantity, TUnitType>(regexString, str, parseUnit, fromDelegate, formatProvider, out var quantities))
                return false;

            value = quantities.Aggregate(add);
            return true;
        }

        /// <summary>
        ///     Parse a string given a particular regular expression.
        /// </summary>
        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        private static bool TryParseWithRegex<TQuantity, TUnitType>(string regexString, string str, TryParseUnitDelegate<TUnitType> tryParseUnit,
            QuantityFromDelegate<TQuantity, TUnitType> fromDelegate, IFormatProvider formatProvider, out List<TQuantity> converted)
            where TQuantity : IQuantity
            where TUnitType : Enum
        {
            converted = new List<TQuantity>();

            var regex = new Regex(regexString);
            var matches = regex.Matches(str.Trim());

            foreach(Match match in matches)
            {
                var groups = match.Groups;

                var valueString = groups["value"].Value;
                var unitString = groups["unit"].Value;
                if(groups["invalid"].Value != string.Empty)
                    return false;

                if((valueString == string.Empty) && (unitString == string.Empty))
                    continue;

                if(!double.TryParse(valueString, NumberStyles.Any, formatProvider, out var value))
                    return false;

                if(!tryParseUnit(unitString, formatProvider, out var parsedUnit))
                    return false;

                var quantity = fromDelegate(value, parsedUnit);

                converted.Add(quantity);
            }

            return true;
        }
    }
}
