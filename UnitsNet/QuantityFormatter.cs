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

    /// <inheritdoc cref="Format{TUnitType}(UnitsNet.IQuantity{TUnitType},string,IFormatProvider)" />
    [Obsolete("Consider switching to one of the more performant instance methods available on QuantityFormatter.Default.")]
    public static string Format<TUnitType>(
        IQuantity<TUnitType> quantity,
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] string format)
        where TUnitType : struct, Enum
    {
        return Format(quantity, format, CultureInfo.CurrentCulture);
    }

    /// <inheritdoc cref="Format{TQuantity}(TQuantity,string,IFormatProvider)" />
    [Obsolete("Consider switching to one of the more performant instance methods available on QuantityFormatter.Default.")]
    public static string Format<TUnitType>(
        IQuantity<TUnitType> quantity,
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format,
        IFormatProvider? formatProvider)
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
    ///     The format is applied to the numeric value and the localized unit abbreviation is appended. Use a
    ///     <see href="https://learn.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings">
    ///         standard numeric format string
    ///     </see>
    ///     or a
    ///     <see href="https://learn.microsoft.com/dotnet/standard/base-types/custom-numeric-format-strings">
    ///         custom numeric format string
    ///     </see>.
    ///     For more information about the formatter, see the
    ///     <see href="https://github.com/angularsen/UnitsNet?tab=readme-ov-file#culture-and-localization">
    ///         QuantityFormatter
    ///         section
    ///     </see>
    ///     .
    /// </remarks>
    /// <returns>The string representation.</returns>
    /// <exception cref="FormatException">Thrown when the format specifier is invalid.</exception>
    public string Format<TQuantity>(
        TQuantity quantity,
        [StringSyntax(StringSyntaxAttribute.NumericFormat)] string? format = null,
        IFormatProvider? formatProvider = null)
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
                case 'A' or 'a':
                    throw new FormatException(
                        $"The \"{format}\" abbreviation format is no longer supported; use the generated quantity's GetAbbreviation method or UnitAbbreviationsCache.");
                case 'S' or 's':
                    throw new FormatException(
                        $"The \"{format}\" significant-digits format is no longer supported; use a standard or custom numeric format string.");
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
                case 'A' or 'a' when int.TryParse(format.AsSpan(1), CultureInfo.InvariantCulture, out _):
                    throw new FormatException(
                        $"The \"{format}\" abbreviation format is no longer supported; use UnitAbbreviationsCache.GetUnitAbbreviations.");
                case 'S' or 's' when int.TryParse(format.AsSpan(1), CultureInfo.InvariantCulture, out _):
                    throw new FormatException(
                        $"The \"{format}\" significant-digits format is no longer supported; use a standard or custom numeric format string.");
                case 'C' or 'c' when int.TryParse(format.AsSpan(1), CultureInfo.InvariantCulture, out _):
                    throw new FormatException($"The \"{format}\" (currency) format is not supported.");
                case 'P' or 'p' when int.TryParse(format.AsSpan(1), CultureInfo.InvariantCulture, out _):
                    throw new FormatException($"The \"{format}\" (percent) format is not supported.");
#else
                case 'A' or 'a' when int.TryParse(format.Substring(1), NumberStyles.Integer, CultureInfo.InvariantCulture, out _):
                    throw new FormatException(
                        $"The \"{format}\" abbreviation format is no longer supported; use UnitAbbreviationsCache.GetUnitAbbreviations.");
                case 'S' or 's' when int.TryParse(format.Substring(1), NumberStyles.Integer, CultureInfo.InvariantCulture, out _):
                    throw new FormatException(
                        $"The \"{format}\" significant-digits format is no longer supported; use a standard or custom numeric format string.");
                case 'C' or 'c' when int.TryParse(format.Substring(1), NumberStyles.Integer, CultureInfo.InvariantCulture, out _):
                    throw new FormatException($"The \"{format}\" (currency) format is not supported.");
                case 'P' or 'p' when int.TryParse(format.Substring(1), NumberStyles.Integer, CultureInfo.InvariantCulture, out _):
                    throw new FormatException($"The \"{format}\" (percent) format is not supported.");
#endif
            }
        }

        var abbreviation = _unitAbbreviations.GetDefaultAbbreviation(quantity.UnitKey, formatProvider);
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
}
