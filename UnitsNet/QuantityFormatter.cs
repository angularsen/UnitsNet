// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;

namespace UnitsNet;

/// <summary>
///     The QuantityFormatter class is responsible for formatting a quantity using the given format string.
/// </summary>
public class QuantityFormatter
{
    private readonly UnitAbbreviationsCache _unitAbbreviations;

    /// <summary>
    ///     Initializes a new instance of the <see cref="QuantityFormatter" /> class.
    /// </summary>
    /// <param name="unitAbbreviations">The cache of unit abbreviations used for formatting quantities.</param>
    public QuantityFormatter(UnitAbbreviationsCache unitAbbreviations)
    {
        _unitAbbreviations = unitAbbreviations ?? throw new ArgumentNullException(nameof(unitAbbreviations));
    }

    /// <summary>
    ///     Gets the default instance of the <see cref="QuantityFormatter" /> class.
    /// </summary>
    /// <value>
    ///     The default <see cref="QuantityFormatter" /> instance, initialized with the default
    ///     <see cref="UnitAbbreviationsCache" />.
    /// </value>
    public static QuantityFormatter Default => UnitsNetSetup.Default.Formatter;
    // public static QuantityFormatter Default { get; } = UnitsNetSetup.Default.Formatter;

    /// <inheritdoc cref="Format{TUnitType}(UnitsNet.IQuantity{TUnitType},string,IFormatProvider)" />
    [Obsolete("Consider switching to one of the more performant instance methods available on QuantityFormatter.Default.")]
    public static string Format<TUnitType>(IQuantity<TUnitType> quantity, string format)
        where TUnitType : struct, Enum
    {
        return Format(quantity, format, CultureInfo.CurrentCulture);
    }

    /// <inheritdoc cref="Format{TQuantity}(TQuantity,string,IFormatProvider)" />
    [Obsolete("Consider switching to one of the more performant instance methods available on QuantityFormatter.Default.")]
    public static string Format<TUnitType>(IQuantity<TUnitType> quantity, string? format, IFormatProvider? formatProvider)
        where TUnitType : struct, Enum
    {
        return Default.Format(quantity, format, formatProvider);
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
    ///                 <see
    ///                     href="https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#standard-format-specifiers">
    ///                     Standard format specifiers
    ///                 </see>
    ///                 .
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
    ///                 <para>
    ///                     A <see cref="FormatException" /> will be thrown if the requested abbreviation index does not
    ///                     exist.
    ///                 </para>
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
    ///     </see>
    ///     .
    /// </remarks>
    /// <returns>The string representation.</returns>
    /// <exception cref="FormatException">Thrown when the format specifier is invalid.</exception>
    public string Format<TQuantity>(TQuantity quantity, string? format, IFormatProvider? formatProvider)
        where TQuantity : IQuantity
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
                case 'S':
                {
                    format = "S15";
                    break;
                }
                case 's':
                {
                    format = "s15";
                    break;
                }
                case 'A' or 'a':
                    return _unitAbbreviations.GetDefaultAbbreviation(quantity.UnitKey, formatProvider as CultureInfo);
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
                case 'A' or 'a' when int.TryParse(format.AsSpan(1), out var abbreviationIndex):
                {
                    IReadOnlyList<string> abbreviations = _unitAbbreviations.GetUnitAbbreviations(quantity.UnitKey, formatProvider as CultureInfo);

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
                case 'A' or 'a' when int.TryParse(format.Substring(1), out var abbreviationIndex):
                {
                    IReadOnlyList<string> abbreviations = _unitAbbreviations.GetUnitAbbreviations(quantity.UnitKey, formatProvider as CultureInfo);

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
 
        var abbreviation = _unitAbbreviations.GetDefaultAbbreviation(quantity.UnitKey, formatProvider as CultureInfo);
        if (abbreviation.Length == 0)
        {
            return quantity.Value.ToString(format, formatProvider);
        }

#if NET
        // TODO see about using the Span<char> overloads (net 8+)
        return quantity.Value.ToString(format, formatProvider) + ' ' + abbreviation;
#else
        return quantity.Value.ToString(format, formatProvider) + ' ' + abbreviation;
#endif
    }

    /// <summary>
    ///     Formats a <typeparamref name="TQuantity" /> using the given format string using
    ///     <see cref="CultureInfo.CurrentCulture" />.
    /// </summary>
    /// <inheritdoc cref="Format{TQuantity}(TQuantity,string,IFormatProvider)" />
    public string Format<TQuantity>(TQuantity quantity, string? format)
        where TQuantity : IQuantity
    {
        return Format(quantity, format, null);
    }

    /// <summary>
    ///     Formats a <typeparamref name="TQuantity" /> using the "G" format and the <see cref="CultureInfo.CurrentCulture" />.
    /// </summary>
    /// <typeparam name="TQuantity">
    ///     The type of the quantity to format. Must implement <see cref="IQuantity" />.
    /// </typeparam>
    /// <param name="quantity">
    ///     The quantity to format.
    /// </param>
    /// <returns>
    ///     A string representation of the quantity, formatted using the "G" format and the current culture.
    /// </returns>
    public string Format<TQuantity>(TQuantity quantity)
        where TQuantity : IQuantity
    {
        return Format(quantity, null, null);
    }
}
