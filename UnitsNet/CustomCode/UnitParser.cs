// Copyright © 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
// https://github.com/anjdreas/UnitsNet
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

namespace UnitsNet
{
    internal delegate TUnit ParseUnit<out TUnit>(string value, string unit, IFormatProvider formatProvider = null);

    internal static class UnitParser
    {
        [SuppressMessage("ReSharper", "UseStringInterpolation")]
        internal static TUnit ParseUnit<TUnit>([NotNull] string str,
            [CanBeNull] IFormatProvider formatProvider,
            [NotNull] ParseUnit<TUnit> parseUnit,
            [NotNull] Func<TUnit, TUnit, TUnit> add)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            if (parseUnit == null) throw new ArgumentNullException(nameof(parseUnit));
            if (add == null) throw new ArgumentNullException(nameof(add));

            NumberFormatInfo numFormat = formatProvider != null
                ? (NumberFormatInfo) formatProvider.GetFormat(typeof(NumberFormatInfo))
                : NumberFormatInfo.CurrentInfo;

            string numRegex = string.Format(@"[\d., {0}{1}]*\d",
                // allows digits, dots, commas, and spaces in the quantity (must end in digit)
                numFormat.NumberGroupSeparator, // adds provided (or current) culture's group separator
                numFormat.NumberDecimalSeparator); // adds provided (or current) culture's decimal separator

            const string exponentialRegex = @"(?:[eE][-+]?\d+)?)";

            string regexString = string.Format(@"(?:\s*(?<value>[-+]?{0}{1}{2}{3})?",
                numRegex, // capture base (integral) Quantity value
                exponentialRegex, // capture exponential (if any), end of Quantity capturing
                @"\s?", // ignore whitespace (allows both "1kg", "1 kg")
                @"(?<unit>[^\d]+)"); // capture Unit (non-numeric)

            //remove separators
            str = str.Replace("and", ""); 

            List<TUnit> quantities = ParseWithRegex(regexString, str, parseUnit, formatProvider);
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
        private static List<TUnit> ParseWithRegex<TUnit>(string regexString, string str, ParseUnit<TUnit> parseUnit,
            IFormatProvider formatProvider = null)
        {
            var regex = new Regex(regexString);
            MatchCollection matches = regex.Matches(str.Trim());
            var converted = new List<TUnit>();

            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;

                string valueString = groups["value"].Value;
                string unitString = groups["unit"].Value;

                if ((valueString == "") && (unitString == "")) continue;

                try
                {
                    converted.Add(parseUnit(valueString, unitString, formatProvider));
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
    }
}