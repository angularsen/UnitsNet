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
        /// <param name="formatProvider">The format provider to use for localization and number formatting. Defaults to <see cref="GlobalConfiguration.DefaultCulture" /> if null.</param>
        /// <returns>The string representation.</returns>
        public static string Format<TUnitType>(IQuantity<TUnitType> quantity, string format, IFormatProvider formatProvider)
            where TUnitType : Enum
        {
            formatProvider = formatProvider ?? GlobalConfiguration.DefaultCulture;

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
                    return quantity.ToString(formatProvider, 2);
                case "a":
                    var abbreviations = UnitAbbreviationsCache.Default.GetUnitAbbreviations(quantity.Unit, formatProvider);
                    return abbreviations[number];
                case "v":
                    return quantity.Value.ToString(formatProvider);
                case "u":
                    return quantity.Unit.ToString();
                case "q":
                    return quantity.QuantityInfo.Name;
                case "s":
                    return quantity.ToString(formatProvider, number);
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }
    }
}
