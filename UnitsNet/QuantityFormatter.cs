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
using System.Globalization;
using System.Linq;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    /// The QuantityFormatter class is responsible for formatting a quantity using the given format string.
    /// </summary>
    public class QuantityFormatter
    {
        /// <summary>
        /// Formats the given quantity using the given format string and format provider.
        /// </summary>
        /// <typeparam name="TUnitType">The quantity's unit type, for example <see cref="LengthUnit"/>.</typeparam>
        /// <param name="quantity">The quantity to format.</param>
        /// <param name="format">The format string.</param>
        /// <param name="formatProvider">The format provider to use for localization and number formatting. Defaults to
        /// <see cref="CultureInfo.CurrentUICulture" /> if null.</param>
        /// <remarks>
        /// The valid format strings are as follows:
        /// "g": The value with 2 significant digits after the radix followed by the unit abbreviation, such as "1.23 m".
        /// "a": The default unit abbreviation for <see cref="IQuantity{TUnitType}.Unit" />, such as "m".
        /// "a0", "a1", ..., "aN": The Nth unit abbreviation for <see cref="IQuantity{TUnitType}.Unit" />. "a0" is the same as "a".
        /// A <see cref="FormatException"/> will be thrown if the requested abbreviation index does not exist.
        /// "v": String representation of <see cref="IQuantity.Value" />.
        /// "u": The enum name of <see cref="IQuantity{TUnitType}.Unit" />, such as "Meter".
        /// "q": The quantity name, such as "Length".
        /// "s1", "s2", ..., "sN": The value with N significant digits after the radix followed by the unit abbreviation. For example,
        /// "s4" would return "1.2345 m" if <see cref="IQuantity.Value" /> is 1.2345678. Trailing zeros are omitted.
        /// </remarks>
        /// <returns>The string representation.</returns>
        public static string Format<TUnitType>(IQuantity<TUnitType> quantity, string format, IFormatProvider formatProvider)
            where TUnitType : Enum
        {
            formatProvider = formatProvider ?? CultureInfo.CurrentUICulture;

            var number = 0;
            var formatString = format;

            if(string.IsNullOrEmpty(formatString))
                formatString = "g";

            if(formatString.StartsWith("a") || formatString.StartsWith("s"))
            {
                if(formatString.Length > 1 && !int.TryParse(formatString.Substring(1), out number))
                    throw new FormatException($"The {format} format string is not supported.");

                formatString = formatString.Substring(0, 1);
            }

            switch(formatString)
            {
                case "g":
                    return ToStringWithSignificantDigitsAfterRadix(quantity, formatProvider, 2);
                case "a":
                    var abbreviations = UnitAbbreviationsCache.Default.GetUnitAbbreviations(quantity.Unit, formatProvider);

                    if(number >= abbreviations.Length)
                        throw new FormatException($"The {format} format string is invalid because the abbreviation index does not exist.");

                    return abbreviations[number];
                case "v":
                    return quantity.Value.ToString(formatProvider);
                case "u":
                    return quantity.Unit.ToString();
                case "q":
                    return quantity.QuantityInfo.Name;
                case "s":
                    return ToStringWithSignificantDigitsAfterRadix(quantity, formatProvider, number);
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }

        private static string ToStringWithSignificantDigitsAfterRadix<TUnitType>(IQuantity<TUnitType> quantity, IFormatProvider formatProvider, int number) where TUnitType : Enum
        {
            string formatForSignificantDigits = UnitFormatter.GetFormat(quantity.Value, number);
            object[] formatArgs = UnitFormatter.GetFormatArgs(quantity.Unit, quantity.Value, formatProvider, Enumerable.Empty<object>());
            return string.Format(formatProvider, formatForSignificantDigits, formatArgs);
        }
    }
}
