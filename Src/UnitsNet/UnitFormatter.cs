// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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

namespace UnitsNet
{
    /// <summary>
    /// Utility class for formatting units and values.
    /// </summary>
    public static class UnitFormatter
    {
        /// <summary>
        /// Gets the default ToString format for the specified value.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <param name="digitsAfterRadix">The number of digits after the radix point to display in the formatted string.</param>
        /// <returns>A ToString format for the specified value.</returns>
        public static string GetFormat(double value, int digitsAfterRadix)
        {
            var digitsAfterRadixStr = new string('#', digitsAfterRadix);
            string format;
            if (NearlyEqual(value, 0))
            {
                format = "{0} {1}";
            }
            // Very small values are always displayed in scientific notation.
            else if (value < 1e-4)
            {
                format = "{0:0." + digitsAfterRadixStr + "e-00} {1}";
            }
            // Medium-small values use 'general' formatting with the specified precision.
            else if (value > 1e-4 && value < 1)
            {
                format = "{0:g" + digitsAfterRadix + "} {1}";
            }
            // Medium-large values use default formatting.
            else if (value >= 1 && value < 1e6)
            {
                format = "{0:0." + digitsAfterRadixStr + "} {1}";
            }
            // Very large values use scientific notation.
            else
            {
                format = "{0:0." + digitsAfterRadixStr + "e00} {1}";
            }

            return format;
        }

        private static bool NearlyEqual(double a, double b)
        {
            return Math.Abs(a - b) < 1e-20;
        }

        /// <summary>
        /// Gets ToString format arguments.
        /// </summary>
        /// <typeparam name="TUnit">The type of units to format.</typeparam>
        /// <param name="unit">The units</param>
        /// <param name="value">The unit value to format.</param>
        /// <param name="culture">The current culture.</param>
        /// <param name="args">The list of format arguments.</param>
        /// <returns>An array of ToString format arguments.</returns>
        public static object[] GetFormatArgs<TUnit>(TUnit unit, double value, CultureInfo culture, object[] args)
            where TUnit : struct, IComparable, IFormattable
        {
            string abbreviation = UnitSystem.GetCached(culture).GetDefaultAbbreviation(unit);
            return new object[] { value, abbreviation }.Concat(args).ToArray();
        }
    }
}