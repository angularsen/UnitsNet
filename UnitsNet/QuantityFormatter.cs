// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;

namespace UnitsNet;

/// <summary>
///     The QuantityFormatter class is responsible for formatting a quantity using the given format string.
/// </summary>
public class QuantityFormatter
{
    /// <summary>
    ///     Formats a quantity using the given format string and format provider.
    /// </summary>
    /// <param name="quantity">The quantity to format.</param>
    /// <param name="format">The format string.</param>
    /// <remarks>
    ///     The valid format strings are as follows:
    ///     <list type="bullet">
    ///         <item>
    ///             <term>A standard numeric format string.</term>
    ///             <description>
    ///                 Any of the
    ///                 <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#standard-format-specifiers">
    ///                     Standard format specifiers
    ///                 </see>.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>"A" or "a".</term>
    ///             <description>The default unit abbreviation for <see cref="IQuantity{TUnitType}.Unit" />, such as "m".</description>
    ///         </item>
    ///         <item>
    ///             <term>"A0", "A1", ..., "An" or "a0", "a1", ..., "an".</term>
    ///             <description>
    ///                 The n-th unit abbreviation for the <see cref="IQuantity{TUnitType}.Unit" />. "a0" is the same as "a".
    ///                 <para>A <see cref="FormatException" /> will be thrown if the requested abbreviation index does not exist.</para>
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>"S" or "s".</term>
    ///             <description>
    ///                 The value with 2 significant digits after the radix followed by the unit abbreviation, such as
    ///                 "1.23 m".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>"S0", "S1", ..., "Sn" or "s0", "s1", ..., "sn".</term>
    ///             <description>
    ///                 The value with n significant digits after the radix followed by the unit abbreviation. "S2"
    ///                 and "s2" is the same as "s".
    ///             </description>
    ///         </item>
    ///     </list>
    ///     For more information about the formatter, see the
    ///     <see href="https://github.com/angularsen/UnitsNet?tab=readme-ov-file#culture-and-localization">
    ///         QuantityFormatter
    ///         section
    ///     </see>.
    /// </remarks>
    /// <returns>The string representation.</returns>
    /// <exception cref="FormatException">Thrown when the format specifier is invalid.</exception>
    public static string Format<TUnitType>(IQuantity<TUnitType> quantity, string format)
        where TUnitType : struct, Enum
    {
        return Format(quantity, format, CultureInfo.CurrentCulture);
    }

    /// <summary>
    ///     Formats a quantity using the given format string and format provider.
    /// </summary>
    /// <param name="quantity">The quantity to format.</param>
    /// <param name="format">The format string.</param>
    /// <param name="formatProvider">
    ///     The format provider to use for localization and number formatting. Defaults to
    ///     <see cref="CultureInfo.CurrentCulture" /> if null.
    /// </param>
    /// <remarks>
    ///     The valid format strings are as follows:
    ///     <list type="bullet">
    ///         <item>
    ///             <term>A standard numeric format string.</term>
    ///             <description>
    ///                 Any of the
    ///                 <see href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#standard-format-specifiers">
    ///                     Standard format specifiers
    ///                 </see>.
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>"A" or "a".</term>
    ///             <description>The default unit abbreviation for <see cref="IQuantity{TUnitType}.Unit" />, such as "m".</description>
    ///         </item>
    ///         <item>
    ///             <term>"A0", "A1", ..., "An" or "a0", "a1", ..., "an".</term>
    ///             <description>
    ///                 The n-th unit abbreviation for the <see cref="IQuantity{TUnitType}.Unit" />. "a0" is the same as "a".
    ///                 <para>A <see cref="FormatException" /> will be thrown if the requested abbreviation index does not exist.</para>
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>"S" or "s".</term>
    ///             <description>
    ///                 The value with 2 significant digits after the radix followed by the unit abbreviation, such as
    ///                 "1.23 m".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <term>"S0", "S1", ..., "Sn" or "s0", "s1", ..., "sn".</term>
    ///             <description>
    ///                 The value with n significant digits after the radix followed by the unit abbreviation. "S2"
    ///                 and "s2" is the same as "s".
    ///             </description>
    ///         </item>
    ///     </list>
    ///     For more information about the formatter, see the
    ///     <see href="https://github.com/angularsen/UnitsNet?tab=readme-ov-file#culture-and-localization">
    ///         QuantityFormatter
    ///         section
    ///     </see>.
    /// </remarks>
    /// <returns>The string representation.</returns>
    /// <exception cref="FormatException">Thrown when the format specifier is invalid.</exception>
    public static string Format<TUnitType>(IQuantity<TUnitType> quantity, string? format, IFormatProvider? formatProvider)
        where TUnitType : struct, Enum
    {
        return FormatUntrimmed(quantity, format, formatProvider).TrimEnd();
    }

    private static string FormatUntrimmed<TUnitType>(IQuantity<TUnitType> quantity, string? format, IFormatProvider? formatProvider)
        where TUnitType : struct, Enum
    {
        formatProvider ??= CultureInfo.CurrentCulture;
        if (format is null)
        {
            format = "G";
        }
        else if (format.Length == 1)
        {
            switch (format[0])
            {
                case 'G' or 'g':
                    return FormatWithValueAndAbbreviation(quantity, format, formatProvider);
                case 'S' or 's':
                    return ToStringWithSignificantDigitsAfterRadix(quantity, formatProvider, 0);
                case 'A' or 'a':
                    return UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(quantity.Unit, formatProvider);
                case 'U' or 'u':
                    throw new FormatException($"The \"{format}\" format is no longer supported: consider using the Unit property.");
                case 'V' or 'v':
                    throw new FormatException($"The \"{format}\" format is no longer supported: consider using the Value property.");
                case 'Q' or 'q':
                    throw new FormatException($"The \"{format}\" format is no longer supported: consider using the QuantityInfo property.");
                case 'C' or 'c':
                    throw new FormatException($"The \"{format}\" (currency) format is not supported.");
                case 'P' or 'p':
                    throw new FormatException($"The \"{format}\" (percent) format is not supported.");
            }
        }
        else if(format.Length > 1)
        {
            switch (format[0])
            {
#if NET
                case 'S' or 's' when int.TryParse(format.AsSpan(1), out var precisionSpecifier):
                    return ToStringWithSignificantDigitsAfterRadix(quantity, formatProvider, precisionSpecifier);
                case 'A' or 'a' when int.TryParse(format.AsSpan(1), out var abbreviationIndex):
                {
                    var abbreviations = UnitsNetSetup.Default.UnitAbbreviations.GetUnitAbbreviations(quantity.Unit, formatProvider);

                    if (abbreviationIndex >= abbreviations.Count)
                    {
                        throw new FormatException($"The \"{format}\" format string is invalid because the index is out of range.");
                    }

                    return abbreviations[abbreviationIndex];
                }
                case 'C' or 'c' when int.TryParse(format.AsSpan(1), out _):
                    throw new FormatException($"The \"{format}\" (currency) format is not supported.");
                case 'P' or 'p' when int.TryParse(format.AsSpan(1), out _):
                    throw new FormatException($"The \"{format}\" (percent) format is not supported.");
#else
                case 'S' or 's' when int.TryParse(format.Substring(1), out var precisionSpecifier):
                    return ToStringWithSignificantDigitsAfterRadix(quantity, formatProvider, precisionSpecifier);
                case 'A' or 'a' when int.TryParse(format.Substring(1), out var abbreviationIndex):
                {
                    var abbreviations = UnitsNetSetup.Default.UnitAbbreviations.GetUnitAbbreviations(quantity.Unit, formatProvider);

                    if (abbreviationIndex >= abbreviations.Count)
                    {
                        throw new FormatException($"The \"{format}\" format string is invalid because the index is out of range.");
                    }

                    return abbreviations[abbreviationIndex];
                }
                case 'C' or 'c' when int.TryParse(format.Substring(1), out _):
                    throw new FormatException($"The \"{format}\" (currency) format is not supported.");
                case 'P' or 'p' when int.TryParse(format.Substring(1), out _):
                    throw new FormatException($"The \"{format}\" (percent) format is not supported.");
#endif
            }
        }

        // Anything else is a standard numeric format string with default unit abbreviation postfix.
        return FormatWithValueAndAbbreviation(quantity, format, formatProvider);
    }

    private static string FormatWithValueAndAbbreviation<TUnitType>(IQuantity<TUnitType> quantity, string format, IFormatProvider formatProvider)
        where TUnitType : struct, Enum
    {
        var abbreviation = UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(quantity.Unit, formatProvider);
        return string.Format(formatProvider, $"{{0:{format}}} {{1}}", quantity.Value, abbreviation);
    }

    private static string ToStringWithSignificantDigitsAfterRadix<TUnitType>(IQuantity<TUnitType> quantity, IFormatProvider formatProvider, int number)
        where TUnitType : struct, Enum
    {
        var formatForSignificantDigits = UnitFormatter.GetFormat(quantity.Value, number);
        var formatArgs = UnitFormatter.GetFormatArgs(quantity.Unit, quantity.Value, formatProvider, []);
        return string.Format(formatProvider, formatForSignificantDigits, formatArgs);
    }
}
