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
        /// The available UnitsNet custom format specifiers.
        /// </summary>
        private static readonly char[] UnitsNetFormatSpecifiers = { 'A', 'a', 'G', 'g', 'Q', 'q', 'S', 's', 'U', 'u', 'V', 'v' };

        /// <summary>
        /// Formats a quantity using the given format string and format provider.
        /// </summary>
        /// <typeparam name="TUnitType">The quantity's unit type, for example <see cref="LengthUnit"/>.</typeparam>
        /// <param name="quantity">The quantity to format.</param>
        /// <param name="format">The format string.</param>
        /// <remarks>
        /// The valid format strings are as follows:
        /// <list type="bullet">
        ///     <item>
        ///         <term>A standard numeric format string.</term>
        ///         <description>Any of the standard numeric format for <see cref="IQuantity.Value" />, except for "G" or "g", which have a special implementation.
        ///         "C" or "c", "E" or "e", "F" or "f", "N" or "n", "P" or "p", "R" or "r" are all accepted.
        ///         See https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#standard-format-specifiers.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"G" or "g".</term>
        ///         <description>The value with 2 significant digits after the radix followed by the unit abbreviation, such as "1.23 m".</description>
        ///     </item>
        ///     <item>
        ///         <term>"A" or "a".</term>
        ///         <description>The default unit abbreviation for <see cref="IQuantity{TUnitType}.Unit" />, such as "m".</description>
        ///     </item>
        ///     <item>
        ///         <term>"A0", "A1", ..., "An" or "a0", "a1", ..., "an".</term>
        ///         <description>The n-th unit abbreviation for <see cref="IQuantity{TUnitType}.Unit" />. "a0" is the same as "a".
        ///         A <see cref="FormatException"/> will be thrown if the requested abbreviation index does not exist.</description>
        ///     </item>
        ///     <item>
        ///         <term>"U" or "u".</term>
        ///         <description>The enum name of <see cref="IQuantity{TUnitType}.Unit" />, such as "Meter".</description>
        ///     </item>
        ///     <item>
        ///         <term>"Q" or "q".</term>
        ///         <description>The quantity name, such as "Length".</description>
        ///     </item>
        /// </list>
        /// </remarks>
        /// <returns>The string representation.</returns>
        public static string Format<TUnitType>(IQuantity<TUnitType> quantity, string format)
            where TUnitType : Enum
        {
            return Format(quantity, format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Formats a quantity using the given format string and format provider.
        /// </summary>
        /// <typeparam name="TUnitType">The quantity's unit type, for example <see cref="LengthUnit"/>.</typeparam>
        /// <param name="quantity">The quantity to format.</param>
        /// <param name="format">The format string.</param>
        /// <param name="formatProvider">The format provider to use for localization and number formatting. Defaults to
        /// <see cref="CultureInfo.CurrentCulture" /> if null.</param>
        /// <remarks>
        /// The valid format strings are as follows:
        /// <list type="bullet">
        ///     <item>
        ///         <term>A standard numeric format string.</term>
        ///         <description>Any of the standard numeric format for <see cref="IQuantity.Value" />, except for "G" or "g", which have a special implementation.
        ///         "C" or "c", "E" or "e", "F" or "f", "N" or "n", "P" or "p", "R" or "r" are all accepted.
        ///         See https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#standard-format-specifiers.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <term>"G" or "g".</term>
        ///         <description>The value with 2 significant digits after the radix followed by the unit abbreviation, such as "1.23 m".</description>
        ///     </item>
        ///     <item>
        ///         <term>"A" or "a".</term>
        ///         <description>The default unit abbreviation for <see cref="IQuantity{TUnitType}.Unit" />, such as "m".</description>
        ///     </item>
        ///     <item>
        ///         <term>"A0", "A1", ..., "An" or "a0", "a1", ..., "an".</term>
        ///         <description>The n-th unit abbreviation for <see cref="IQuantity{TUnitType}.Unit" />. "a0" is the same as "a".
        ///         A <see cref="FormatException"/> will be thrown if the requested abbreviation index does not exist.</description>
        ///     </item>
        ///     <item>
        ///         <term>"U" or "u".</term>
        ///         <description>The enum name of <see cref="IQuantity{TUnitType}.Unit" />, such as "Meter".</description>
        ///     </item>
        ///     <item>
        ///         <term>"Q" or "q".</term>
        ///         <description>The quantity name, such as "Length".</description>
        ///     </item>
        /// </list>
        /// </remarks>
        /// <returns>The string representation.</returns>
        public static string Format<TUnitType>(IQuantity<TUnitType> quantity, string? format, IFormatProvider? formatProvider)
            where TUnitType : Enum
        {
            formatProvider ??= CultureInfo.CurrentCulture;
            return FormatUntrimmed(quantity, format, formatProvider).TrimEnd();
        }

        private static string FormatUntrimmed<TUnitType>(IQuantity<TUnitType> quantity, string? format, IFormatProvider? formatProvider)
            where TUnitType : Enum
        {
            formatProvider ??= CultureInfo.CurrentCulture;

            if (string.IsNullOrWhiteSpace(format))
                format = "g";

            char formatSpecifier = format![0]; // netstandard2.0 nullable quirk

            if (UnitsNetFormatSpecifiers.Any(unitsNetFormatSpecifier => unitsNetFormatSpecifier == formatSpecifier))
            {
                // UnitsNet custom format string

                int precisionSpecifier = 0;

                switch(formatSpecifier)
                {
                    case 'A':
                    case 'a':
                    case 'S':
                    case 's':
                        if (format.Length > 1 && !int.TryParse(format.Substring(1), out precisionSpecifier))
                            throw new FormatException($"The {format} format string is not supported.");
                        break;
                }

                switch(formatSpecifier)
                {
                    case 'G':
                    case 'g':
                        return ToStringWithSignificantDigitsAfterRadix(quantity, formatProvider, 2);
                    case 'A':
                    case 'a':
                        var abbreviations = UnitAbbreviationsCache.Default.GetUnitAbbreviations(quantity.Unit, formatProvider);

                        if (precisionSpecifier >= abbreviations.Length)
                            throw new FormatException($"The {format} format string is invalid because the abbreviation index does not exist.");

                        return abbreviations[precisionSpecifier];
                    case 'V':
                    case 'v':
                        return quantity.Value.ToString(formatProvider);
                    case 'U':
                    case 'u':
                        return quantity.Unit.ToString();
                    case 'Q':
                    case 'q':
                        return quantity.QuantityInfo.Name;
                    case 'S':
                    case 's':
                        return ToStringWithSignificantDigitsAfterRadix(quantity, formatProvider, precisionSpecifier);
                    default:
                        throw new FormatException($"The {format} format string is not supported.");
                }
            }
            else
            {
                // Anything else is a standard numeric format string with default unit abbreviation postfix.

                var abbreviations = UnitAbbreviationsCache.Default.GetUnitAbbreviations(quantity.Unit, formatProvider);
                return string.Format(formatProvider, $"{{0:{format}}} {{1}}", quantity.Value, abbreviations.First());
            }
        }

        private static string ToStringWithSignificantDigitsAfterRadix<TUnitType>(IQuantity<TUnitType> quantity, IFormatProvider formatProvider, int number) where TUnitType : Enum
        {
            // When a fixed number of digits after the dot is expected, double and decimal behave the same.
            var value = (double)quantity.Value;
            string formatForSignificantDigits = UnitFormatter.GetFormat(value, number);
            object[] formatArgs = UnitFormatter.GetFormatArgs(quantity.Unit, value, formatProvider, Enumerable.Empty<object>());
            return string.Format(formatProvider, formatForSignificantDigits, formatArgs);
        }
    }
}
