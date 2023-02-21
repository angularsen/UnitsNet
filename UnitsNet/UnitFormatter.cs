// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitsNet
{
    /// <summary>
    ///     Utility class for formatting units and values.
    /// </summary>
    internal static class UnitFormatter
    {
        /// <summary>
        ///     Gets the default ToString format for the specified value.
        /// </summary>
        /// <param name="value">The value to format.</param>
        /// <param name="significantDigitsAfterRadix">
        ///     The number of digits after the radix point to display in the formatted
        ///     string.
        /// </param>
        /// <returns>A ToString format for the specified value.</returns>
        public static string GetFormat(double value, int significantDigitsAfterRadix)
        {
            double v = Math.Abs(value);
            var sigDigitsAfterRadixStr = new string('#', significantDigitsAfterRadix);
            string format;

            if (NearlyEqual(v, 0))
            {
                format = "{0} {1}";
            }
            // Values below 1e-3 are displayed in scientific notation.
            else if (v < 1e-3)
            {
                format = "{0:0." + sigDigitsAfterRadixStr + "e-00} {1}";
            }
            // Values from 1e-3 to 1 use fixed point notation.
            else if ((v > 1e-4) && (v < 1))
            {
                format = "{0:g" + significantDigitsAfterRadix + "} {1}";
            }
            // Values between 1 and 1e5 use fixed point notation with digit grouping.
            else if ((v >= 1) && (v < 1e6))
            {
                // The comma will be automatically replaced with the correct digit separator if a different culture is used.
                format = "{0:#,0." + sigDigitsAfterRadixStr + "} {1}";
            }
            // Values above 1e5 use scientific notation.
            else
            {
                format = "{0:0." + sigDigitsAfterRadixStr + "e+00} {1}";
            }

            return format;
        }

        private static bool NearlyEqual(double a, double b)
        {
            return Math.Abs(a - b) < 1e-150;
        }

        /// <summary>
        ///     Gets ToString format arguments.
        /// </summary>
        /// <typeparam name="TUnitType">The type of units to format.</typeparam>
        /// <param name="unit">The units</param>
        /// <param name="value">The unit value to format.</param>
        /// <param name="culture">The current culture.</param>
        /// <param name="args">The list of format arguments.</param>
        /// <returns>An array of ToString format arguments.</returns>
        public static object[] GetFormatArgs<TUnitType>(TUnitType unit, double value, IFormatProvider? culture, IEnumerable<object> args)
            where TUnitType : Enum
        {
            string abbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(typeof(TUnitType), Convert.ToInt32(unit), culture);
            return new object[] {value, abbreviation}.Concat(args).ToArray();
        }
    }
}
