// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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
