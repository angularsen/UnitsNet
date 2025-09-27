// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
#if !NET
using System.Text;
#endif

namespace UnitsNet;

public partial struct QuantityValue
{
    /// <summary>Returns the string representation of the numeric value.</summary>
    public override string ToString()
    {
        return ToString("G");
    }

    /// <summary>
    ///     Returns the string representation of the numeric value, formatted using the given standard numeric format string
    /// </summary>
    /// <param name="format">
    ///     A standard numeric format string (must be valid for either double or decimal, depending on the
    ///     base type)
    /// </param>
    /// <returns>The string representation</returns>
    public string ToString(string format)
    {
        return ToString(format, NumberFormatInfo.CurrentInfo);
    }

    /// <summary>
    ///     Returns the string representation of the numeric value, formatted using the given standard numeric format string
    /// </summary>
    /// <param name="formatProvider">The culture to use</param>
    /// <returns>The string representation</returns>
    public string ToString(IFormatProvider? formatProvider)
    {
        return ToString(null, formatProvider);
    }

    /// <summary>
    ///     Returns the string representation of the underlying value
    /// </summary>
    /// <param name="format">
    ///     Standard format specifiers. Because the underlying value can be double or decimal, the meaning can
    ///     vary
    /// </param>
    /// <param name="formatProvider">Culture specific settings</param>
    /// <returns>A string representation of the number</returns>
    /// <remarks>
    ///     This method supports the following format strings:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-general-g-format-specifier">
    ///                     'G'
    ///                     or 'g'
    ///                 </see>
    ///                 : General format. Example: 400/3 formatted with 'G2' gives "1.3E+02".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-fixed-point-f-format-specifier">
    ///                     'F'
    ///                     or 'f'
    ///                 </see>
    ///                 : Fixed-point format. Example: 12345/10 formatted with 'F2' gives "1234.50".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-number-n-format-specifier">
    ///                     'N'
    ///                     or 'n'
    ///                 </see>
    ///                 : Standard Numeric format. Example: 1234567/1000 formatted with 'N2' gives "1,234.57".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-exponential-e-format-specifier">
    ///                     'E'
    ///                     or 'e'
    ///                 </see>
    ///                 : Scientific format. Example: 1234567/1000 formatted with 'E2' gives "1.23E+003".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-percent-p-format-specifier">
    ///                     'P'
    ///                     or 'p'
    ///                 </see>
    ///                 : Percent format. Example: 2/3 formatted with 'P2' gives "66.67 %".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-currency-c-format-specifier">
    ///                     'C'
    ///                     or 'c'
    ///                 </see>
    ///                 : Currency format. Example: 1234567/1000 formatted with 'C2' gives "$1,234.57".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#RFormatString">
    ///                     'R'
    ///                     or 'r'
    ///                 </see>
    ///                 : Round-trip format. Example: 1234567/1000 formatted with 'R' gives "1234.567".
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 <see
    ///                     href="https://github.com/danm-de/Fractions?tab=readme-ov-file#significant-digits-after-radix-format">
    ///                     'S'
    ///                     or 's'
    ///                 </see>
    ///                 : Significant Digits After Radix format. Example: 400/3 formatted with 'S2' gives
    ///                 "133.33".
    ///             </description>
    ///         </item>
    ///     </list>
    ///     Note: The 'R' format and custom formats do not support precision specifiers and are handed over to the `double`
    ///     type for formatting, which may result in a loss of precision.
    ///     For more information about the formatter, see the
    ///     <see href="https://github.com/danm-de/Fractions?tab=readme-ov-file#decimalnotationformatter">
    ///         DecimalNotationFormatter
    ///         section
    ///     </see>
    ///     in the GitHub README.
    /// </remarks>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return DecimalNotationFormatter.Format(this, format, formatProvider);
    }

#if NET7_0_OR_GREATER
    /// <inheritdoc />
    public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
    {
        return DecimalNotationFormatter.TryFormat(destination, out charsWritten, this, format, provider);
    }
#endif

#if NET

    /// <summary>
    ///     Provides functionality to format the value of a QuantityValue object into a decimal string representation following
    ///     the
    ///     standard numeric formats, as implemented by the double type.
    /// </summary>
    private static class DecimalNotationFormatter
    {
        /// <summary>
        ///     <list type="bullet">
        ///         <item>
        ///             On .NET Framework and .NET Core up to .NET Core 2.0, the runtime selects the result with the greater least
        ///             significant digit (that is, using <see cref="MidpointRounding.AwayFromZero" />).
        ///         </item>
        ///         <item>
        ///             On .NET Core 2.1 and later, the runtime selects the result with an even least significant digit (that is,
        ///             using  <see cref="MidpointRounding.ToEven" />).
        ///         </item>
        ///     </list>
        /// </summary>
        private const MidpointRounding DefaultMidpointRoundingMode = MidpointRounding.AwayFromZero;

        /// <summary>
        ///     The default precision used for the general format specifier (G)
        /// </summary>
        private const int DefaultGeneralFormatPrecision = 16;

        /// <summary>
        ///     The default precision used for the exponential (scientific) format specifier (E)
        /// </summary>
        private const int DefaultScientificFormatPrecision = 6;

        private const int StackLimit = 250; // Safe limit for stackalloc (512 chars)


        private static readonly double Log10Of2 = Math.Log10(2);


        /// <summary>
        ///     Formats the value of the specified Fraction as a string using the specified format.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="fraction">The Fraction object to be formatted.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        ///     The string representation of the value of the Fraction object as specified by the format and formatProvider
        ///     parameters.
        /// </returns>
        /// <remarks>
        ///     This method supports the following format strings:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-general-g-format-specifier">
        ///                     'G'
        ///                     or 'g'
        ///                 </see>
        ///                 : General format. Example: 400/3 formatted with 'G2' gives "1.3E+02".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-fixed-point-f-format-specifier">
        ///                     'F'
        ///                     or 'f'
        ///                 </see>
        ///                 : Fixed-point format. Example: 12345/10 formatted with 'F2' gives "1234.50".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-number-n-format-specifier">
        ///                     'N'
        ///                     or 'n'
        ///                 </see>
        ///                 : Standard Numeric format. Example: 1234567/1000 formatted with 'N2' gives "1,234.57".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-exponential-e-format-specifier">
        ///                     'E'
        ///                     or 'e'
        ///                 </see>
        ///                 : Scientific format. Example: 1234567/1000 formatted with 'E2' gives "1.23E+003".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-percent-p-format-specifier">
        ///                     'P'
        ///                     or 'p'
        ///                 </see>
        ///                 : Percent format. Example: 2/3 formatted with 'P2' gives "66.67 %".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-currency-c-format-specifier">
        ///                     'C'
        ///                     or 'c'
        ///                 </see>
        ///                 : Currency format. Example: 1234567/1000 formatted with 'C2' gives "$1,234.57".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#RFormatString">
        ///                     'R'
        ///                     or 'r'
        ///                 </see>
        ///                 : Round-trip format. Example: 1234567/1000 formatted with 'R' gives "1234.567".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://github.com/danm-de/Fractions?tab=readme-ov-file#significant-digits-after-radix-format">
        ///                     'S'
        ///                     or 's'
        ///                 </see>
        ///                 : Significant Digits After Radix format. Example: 400/3 formatted with 'S2' gives
        ///                 "133.33".
        ///             </description>
        ///         </item>
        ///     </list>
        ///     Note: The 'R' format and custom formats do not support precision specifiers and are handed over to the `double`
        ///     type for formatting, which may result in a loss of precision.
        ///     For more information about the formatter, see the
        ///     <see href="https://github.com/danm-de/Fractions?tab=readme-ov-file#decimalnotationformatter">
        ///         DecimalNotationFormatter
        ///         section
        ///     </see>
        ///     in the GitHub README.
        /// </remarks>
        public static string Format(QuantityValue fraction, string? format, IFormatProvider? formatProvider)
        {
            var numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);
            BigInteger numerator = fraction.Numerator;
            BigInteger denominator = fraction.Denominator;
            if (denominator.Sign == 0)
            {
                return numerator.Sign switch
                {
                    1 => numberFormatInfo.PositiveInfinitySymbol,
                    -1 => numberFormatInfo.NegativeInfinitySymbol,
                    _ => numberFormatInfo.NaNSymbol
                };
            }

            if (string.IsNullOrEmpty(format))
            {
                return FormatGeneral(numerator, denominator, "G", numberFormatInfo);
            }

            var formatCharacter = format[0];
            return formatCharacter switch
            {
                'G' or 'g' => FormatGeneral(numerator, denominator, format, numberFormatInfo),
                'F' or 'f' => FormatWithFixedPointFormat(numerator, denominator, format, numberFormatInfo),
                'N' or 'n' => FormatWithStandardNumericFormat(numerator, denominator, format, numberFormatInfo),
                'E' or 'e' => FormatWithScientificFormat(numerator, denominator, format, numberFormatInfo),
                'P' or 'p' => FormatWithPercentFormat(numerator, denominator, format, numberFormatInfo),
                'C' or 'c' => FormatWithCurrencyFormat(numerator, denominator, format, numberFormatInfo),
                'S' or 's' => FormatWithSignificantDigitsAfterRadix(numerator, denominator, format, numberFormatInfo),
                _ => // 'R', 'r' and the custom formats are handed over to the double (possible loss of precision) 
                    fraction.ToDouble().ToString(format, numberFormatInfo)
            };
        }

        public static bool TryFormat(Span<char> destination, out int charsWritten, QuantityValue fraction, ReadOnlySpan<char> format, IFormatProvider? formatProvider)
        {
            var numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);
            BigInteger numerator = fraction.Numerator;
            BigInteger denominator = fraction.Denominator;
            if (denominator.Sign == 0)
            {
                charsWritten = 0;
                switch (numerator.Sign)
                {
                    case 1:
                        if (!numberFormatInfo.PositiveInfinitySymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = numberFormatInfo.PositiveInfinitySymbol.Length;
                        return true;
                    case -1:
                        if (!numberFormatInfo.NegativeInfinitySymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = numberFormatInfo.NegativeInfinitySymbol.Length;
                        return true;
                    default:
                        if (!numberFormatInfo.NaNSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = numberFormatInfo.NaNSymbol.Length;
                        return true;
                }
            }

            if (format.IsEmpty)
            {
                return TryFormatGeneral(destination, out charsWritten, numerator, denominator, "G", numberFormatInfo);
            }

            var formatCharacter = format[0];
            return formatCharacter switch
            {
                'G' or 'g' => TryFormatGeneral(destination, out charsWritten, numerator, denominator, format, numberFormatInfo),
                'F' or 'f' => TryFormatWithFixedPointFormat(destination, out charsWritten, numerator, denominator, format, numberFormatInfo),
                'N' or 'n' => TryFormatWithStandardNumericFormat(destination, out charsWritten, numerator, denominator, format, numberFormatInfo),
                'E' or 'e' => TryFormatWithScientificFormat(destination, out charsWritten, numerator, denominator, format, numberFormatInfo),
                'P' or 'p' => TryFormatWithPercentFormat(destination, out charsWritten, numerator, denominator, format, numberFormatInfo),
                'C' or 'c' => TryFormatWithCurrencyFormat(destination, out charsWritten, numerator, denominator, format, numberFormatInfo),
                'S' or 's' => TryFormatWithSignificantDigitsAfterRadix(destination, out charsWritten, numerator, denominator, format, numberFormatInfo),
                _ => // 'R', 'r' and the custom formats are handed over to the double (possible loss of precision) 
                    fraction.ToDouble().TryFormat(destination, out charsWritten, format, numberFormatInfo)
            };
        }

        private static bool TryGetPrecisionDigits(ReadOnlySpan<char> format, int defaultPrecision, out int maxNbDecimals)
        {
            if (format.Length == 1)
            {
                // The number of digits is not specified, use default precision.
                maxNbDecimals = defaultPrecision;
                return true;
            }

            if (int.TryParse(format[1..], out maxNbDecimals))
            {
                return true;
            }

            // Seems to be some kind of custom format we do not understand, fallback to default precision.
            maxNbDecimals = defaultPrecision;
            return false;
        }

        /// <summary>
        ///     The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each "d"
        ///     indicates a digit (0-9). The string starts with a minus sign if the number is negative.
        /// </summary>
        /// <remarks>
        ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
        ///     current <see cref="NumberFormatInfo.NumberDecimalDigits" /> property supplies the numeric precision.
        /// </remarks>
        private static string FormatWithFixedPointFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.ToString(format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, formatProvider.NumberDecimalDigits, out var maxNbDecimalsAfterRadix))
            {
                // not a valid "F" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            Span<char> buffer = stackalloc char[StackLimit]; // Use stack memory
            int charsWritten;
            while (!TryFormatWithFixedPointFormat(buffer, out charsWritten, numerator, denominator, format, formatProvider, maxNbDecimalsAfterRadix))
            {
                buffer = new char[buffer.Length * 2]; // Use heap if needed
            }

            return new string(buffer[..charsWritten]);
        }

        private static bool TryFormatWithFixedPointFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, ReadOnlySpan<char> format,
            NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, formatProvider.NumberDecimalDigits, out var maxNbDecimalsAfterRadix))
            {
                // not a valid "F" format: assuming a custom format
                return TryFormatWithCustomFormat(destination, out charsWritten, numerator, denominator, format, formatProvider);
            }

            return TryFormatWithFixedPointFormat(destination, out charsWritten, numerator, denominator, format, formatProvider, maxNbDecimalsAfterRadix);
        }

        private static bool TryFormatWithFixedPointFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, ReadOnlySpan<char> format,
            NumberFormatInfo formatProvider, int maxNbDecimalsAfterRadix)
        {
            if (maxNbDecimalsAfterRadix == 0)
            {
                var roundedValue = RoundToBigInteger(numerator, denominator, DefaultMidpointRoundingMode);
                return roundedValue.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            var (roundedNumerator, roundedDenominator) = Round(numerator, denominator, maxNbDecimalsAfterRadix, DefaultMidpointRoundingMode);

            switch (roundedNumerator.Sign)
            {
                case 0:
                    return 0.TryFormat(destination, out charsWritten, format, formatProvider);
                case 1:
                    return TryAppendDecimals(destination, out charsWritten, roundedNumerator, roundedDenominator, formatProvider, maxNbDecimalsAfterRadix, "F0");
                default:
                {
                    if (!formatProvider.NegativeSign.TryCopyTo(destination))
                    {
                        charsWritten = 0;
                        return false;
                    }

                    charsWritten = formatProvider.NegativeSign.Length;

                    roundedNumerator = -roundedNumerator;
                    if (!TryAppendDecimals(destination[charsWritten..], out var digitsWritten, roundedNumerator, roundedDenominator, formatProvider, maxNbDecimalsAfterRadix, "F0"))
                    {
                        return false;
                    }

                    charsWritten += digitsWritten;
                    return true;
                }
            }
        }

        /// <summary>
        ///     The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-"
        ///     indicates
        ///     a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "."
        ///     indicates a decimal point symbol.
        /// </summary>
        /// <remarks>
        ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
        ///     current <see cref="NumberFormatInfo.NumberDecimalDigits" /> property supplies the numeric precision.
        /// </remarks>
        private static string FormatWithStandardNumericFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.ToString(format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, formatProvider.NumberDecimalDigits, out var maxNbDecimals))
            {
                // not a valid "N" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            Span<char> buffer = stackalloc char[StackLimit]; // Use stack memory
            int charsWritten;
            while (!TryFormatWithStandardNumericFormat(buffer, out charsWritten, numerator, denominator, format, formatProvider, maxNbDecimals))
            {
                buffer = new char[buffer.Length * 2]; // Use heap if needed
            }

            return new string(buffer[..charsWritten]);
        }

        private static bool TryFormatWithStandardNumericFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator,
            ReadOnlySpan<char> format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, formatProvider.NumberDecimalDigits, out var maxNbDecimals))
            {
                // not a valid "N" format: assuming a custom format
                return TryFormatWithCustomFormat(destination, out charsWritten, numerator, denominator, format, formatProvider);
            }

            return TryFormatWithStandardNumericFormat(destination, out charsWritten, numerator, denominator, format, formatProvider, maxNbDecimals);
        }

        private static bool TryFormatWithStandardNumericFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator,
            ReadOnlySpan<char> format,
            NumberFormatInfo formatProvider, int maxNbDecimals)
        {
            if (maxNbDecimals == 0)
            {
                var roundedValue = RoundToBigInteger(numerator, denominator, DefaultMidpointRoundingMode);
                return roundedValue.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            var (roundedNumerator, roundedDenominator) = Round(numerator, denominator, maxNbDecimals, DefaultMidpointRoundingMode);
            switch (roundedNumerator.Sign)
            {
                case 0:
                    return 0.TryFormat(destination, out charsWritten, format, formatProvider);
                case 1:
                    return TryAppendDecimals(destination, out charsWritten, roundedNumerator, roundedDenominator, formatProvider, maxNbDecimals, "N0");
                default:
                    if (!TryAppendLeadingNegativePattern(destination, out charsWritten, formatProvider.NegativeSign, formatProvider.NumberNegativePattern))
                    {
                        return false;
                    }

                    roundedNumerator = -roundedNumerator;
                    if (!TryAppendDecimals(destination[charsWritten..], out var decimalsWritten, roundedNumerator, roundedDenominator, formatProvider, maxNbDecimals, "N0"))
                    {
                        return false;
                    }

                    charsWritten += decimalsWritten;
                    if (!TryAppendTrailingNegativePattern(destination[charsWritten..], out var trailingCharsWritten, formatProvider.NegativeSign,
                            formatProvider.NumberNegativePattern))
                    {
                        return false;
                    }

                    charsWritten += trailingCharsWritten;
                    return true;
            }

            static bool TryAppendLeadingNegativePattern(Span<char> destination, out int charsWritten, string negativeSignSymbol, int pattern)
            {
                charsWritten = 0;
                switch (pattern)
                {
                    case 0: // (n) : leading is '('
                        if (destination.IsEmpty)
                        {
                            return false;
                        }

                        destination[0] = '(';
                        charsWritten = 1;
                        return true;
                    case 1: // -n : leading is negativeSignSymbol
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        return true;
                    case 2: // - n : leading is negativeSignSymbol + ' '
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        if (charsWritten == destination.Length)
                        {
                            return false;
                        }

                        destination[charsWritten] = ' ';
                        charsWritten++;
                        return true;
                    default: //"n-" and "n -" : no leading addition
                        return true;
                }
            }

            static bool TryAppendTrailingNegativePattern(Span<char> destination, out int charsWritten, string negativeSignSymbol, int pattern)
            {
                charsWritten = 0;
                switch (pattern)
                {
                    case 0: // (n) : trailing is ')'
                        if (destination.IsEmpty)
                        {
                            return false;
                        }

                        destination[0] = ')';
                        charsWritten = 1;
                        return true;
                    case 3: // n- : trailing is negativeSignSymbol
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        return true;
                    case 4: // n - : trailing is ' ' + negativeSignSymbol
                        if (destination.IsEmpty)
                        {
                            return false;
                        }

                        destination[0] = ' ';
                        charsWritten = 1;
                        if (!negativeSignSymbol.TryCopyTo(destination[charsWritten..]))
                        {
                            return false;
                        }

                        charsWritten += negativeSignSymbol.Length;
                        return true;
                    default: // -n and - n cases are handled in leading function
                        return true;
                }
            }
        }

        /// <summary>
        ///     The percent ("P") format specifier multiplies a number by 100 and converts it to a string that represents a
        ///     percentage.
        /// </summary>
        /// <remarks>
        ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted,
        ///     the default numeric precision supplied by the current <see cref="NumberFormatInfo.PercentDecimalDigits" /> property
        ///     is used.
        /// </remarks>
        private static string FormatWithPercentFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.ToString(format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, formatProvider.PercentDecimalDigits, out var maxNbDecimals))
            {
                // not a valid "P" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            Span<char> buffer = stackalloc char[StackLimit]; // Use stack memory
            int charsWritten;
            while (!TryFormatWithPercentFormat(buffer, out charsWritten, numerator, denominator, format, formatProvider, maxNbDecimals))
            {
                buffer = new char[buffer.Length * 2]; // Use heap if needed
            }

            return new string(buffer[..charsWritten]);
        }

        private static bool TryFormatWithPercentFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, ReadOnlySpan<char> format,
            NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, formatProvider.PercentDecimalDigits, out var maxNbDecimals))
            {
                // not a valid "P" format: assuming a custom format
                return TryFormatWithCustomFormat(destination, out charsWritten, numerator, denominator, format, formatProvider);
            }

            return TryFormatWithPercentFormat(destination, out charsWritten, numerator, denominator, format, formatProvider, maxNbDecimals);
        }

        private static bool TryFormatWithPercentFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, ReadOnlySpan<char> format,
            NumberFormatInfo formatProvider, int maxNbDecimals)
        {
            if (maxNbDecimals == 0)
            {
                var roundedValue = RoundToBigInteger(100 * numerator, denominator, DefaultMidpointRoundingMode);
                if (roundedValue.IsZero)
                {
                    return 0.TryFormat(destination, out charsWritten, format, formatProvider);
                }

                var percentFormatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = formatProvider.PercentDecimalSeparator,
                    NumberGroupSeparator = formatProvider.PercentGroupSeparator,
                    NumberGroupSizes = formatProvider.PercentGroupSizes,
                    NativeDigits = formatProvider.NativeDigits,
                    DigitSubstitution = formatProvider.DigitSubstitution
                };

                if (roundedValue.Sign >= 0)
                {
                    if (!TryAppendLeadingPositivePercentPattern(destination, out charsWritten, formatProvider.PercentSymbol, formatProvider.PercentPositivePattern))
                    {
                        return false;
                    }

                    if (!roundedValue.TryFormat(destination[charsWritten..], out var decimalsWritten, "N0", percentFormatInfo))
                    {
                        return false;
                    }

                    charsWritten += decimalsWritten;

                    if (!TryAppendTrailingPositivePercentPattern(destination[charsWritten..], out var trailingCharsWritten, formatProvider.PercentSymbol,
                            formatProvider.PercentPositivePattern))
                    {
                        return false;
                    }

                    charsWritten += trailingCharsWritten;
                }
                else
                {
                    if (!TryAppendLeadingNegativePercentPattern(destination, out charsWritten, formatProvider.PercentSymbol, formatProvider.NegativeSign,
                            formatProvider.PercentNegativePattern))
                    {
                        return false;
                    }

                    roundedValue = -roundedValue;
                    if (!roundedValue.TryFormat(destination[charsWritten..], out var decimalsWritten, "N0", percentFormatInfo))
                    {
                        return false;
                    }

                    charsWritten += decimalsWritten;

                    if (!TryAppendTrailingNegativePercentPattern(destination[charsWritten..], out var trailingCharsWritten, formatProvider.PercentSymbol,
                            formatProvider.NegativeSign,
                            formatProvider.PercentNegativePattern))
                    {
                        return false;
                    }

                    charsWritten += trailingCharsWritten;
                }
            }
            else
            {
                var (roundedNumerator, roundedDenominator) = Round(numerator * 100, denominator, maxNbDecimals, DefaultMidpointRoundingMode);
                if (roundedNumerator.IsZero)
                {
                    return 0.TryFormat(destination, out charsWritten, format, formatProvider);
                }

                var percentFormatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = formatProvider.PercentDecimalSeparator,
                    NumberGroupSeparator = formatProvider.PercentGroupSeparator,
                    NumberGroupSizes = formatProvider.PercentGroupSizes,
                    NativeDigits = formatProvider.NativeDigits,
                    DigitSubstitution = formatProvider.DigitSubstitution
                };

                if (roundedNumerator.Sign > 0)
                {
                    if (!TryAppendLeadingPositivePercentPattern(destination, out charsWritten, formatProvider.PercentSymbol, formatProvider.PercentPositivePattern))
                    {
                        return false;
                    }

                    if (!TryAppendDecimals(destination[charsWritten..], out var decimalsWritten, roundedNumerator, roundedDenominator, percentFormatInfo, maxNbDecimals, "N0"))
                    {
                        return false;
                    }

                    charsWritten += decimalsWritten;

                    if (!TryAppendTrailingPositivePercentPattern(destination[charsWritten..], out var trailingCharsWritten, formatProvider.PercentSymbol,
                            formatProvider.PercentPositivePattern))
                    {
                        return false;
                    }

                    charsWritten += trailingCharsWritten;
                }
                else
                {
                    if (!TryAppendLeadingNegativePercentPattern(destination, out charsWritten, formatProvider.PercentSymbol, formatProvider.NegativeSign,
                            formatProvider.PercentNegativePattern))
                    {
                        return false;
                    }

                    roundedNumerator = -roundedNumerator;
                    if (!TryAppendDecimals(destination[charsWritten..], out var decimalsWritten, roundedNumerator, roundedDenominator, percentFormatInfo, maxNbDecimals, "N0"))
                    {
                        return false;
                    }

                    charsWritten += decimalsWritten;

                    if (!TryAppendTrailingNegativePercentPattern(destination[charsWritten..], out var trailingCharsWritten, formatProvider.PercentSymbol,
                            formatProvider.NegativeSign, formatProvider.PercentNegativePattern))
                    {
                        return false;
                    }

                    charsWritten += trailingCharsWritten;
                }
            }

            return true;

            static bool TryAppendLeadingPositivePercentPattern(Span<char> destination, out int charsWritten, string percentSymbol, int pattern)
            {
                charsWritten = 0;
                switch (pattern)
                {
                    case 0: // n % : no leading addition
                    case 1: // n%  : no leading addition
                        return true;
                    case 2: // %n  : leading is percentSymbol only
                        if (!percentSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = percentSymbol.Length;
                        return true;
                    default: // % n : leading is percentSymbol + ' '
                        if (!percentSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = percentSymbol.Length;
                        if (destination.Length == charsWritten)
                        {
                            return false;
                        }

                        destination[charsWritten] = ' ';
                        charsWritten++;
                        return true;
                }
            }

            static bool TryAppendTrailingPositivePercentPattern(Span<char> destination, out int charsWritten, string percentSymbol, int pattern)
            {
                charsWritten = 0;
                switch (pattern)
                {
                    case 0: // n % : trailing is ' ' + percentSymbol
                        if (destination.IsEmpty)
                        {
                            return false;
                        }

                        destination[0] = ' ';
                        charsWritten = 1;
                        if (!percentSymbol.TryCopyTo(destination[charsWritten..]))
                        {
                            return false;
                        }

                        charsWritten += percentSymbol.Length;
                        return true;
                    case 1: // n%  : trailing is percentSymbol only
                        if (!percentSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = percentSymbol.Length;
                        return true;
                    default: // "%n" and "% n" : no trailing addition
                        return true;
                }
            }

            static bool TryAppendLeadingNegativePercentPattern(Span<char> destination, out int charsWritten, string percentSymbol, string negativeSignSymbol, int pattern)
            {
                charsWritten = 0;
                switch (pattern)
                {
                    case 0: // -n %
                    case 1: // -n%
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        return true;
                    case 2: // -%n
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        if (!percentSymbol.TryCopyTo(destination[charsWritten..]))
                        {
                            return false;
                        }

                        charsWritten += percentSymbol.Length;
                        return true;
                    case 3: // %-n
                        if (!percentSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = percentSymbol.Length;
                        if (!negativeSignSymbol.TryCopyTo(destination[charsWritten..]))
                        {
                            return false;
                        }

                        charsWritten += negativeSignSymbol.Length;
                        return true;
                    case 4: // %n-
                        if (!percentSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = percentSymbol.Length;
                        return true;
                    case 5: // n-%
                    case 6: // n%-
                        return true;
                    case 7: // -% n
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        if (!percentSymbol.TryCopyTo(destination[charsWritten..]))
                        {
                            return false;
                        }

                        charsWritten += percentSymbol.Length;
                        if (charsWritten == destination.Length)
                        {
                            return false;
                        }
                        
                        destination[charsWritten] = ' ';
                        charsWritten++;
                        return true;
                    case 8: // n %-
                        return true;
                    case 9: // % n-
                        if (!percentSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = percentSymbol.Length;
                        if (charsWritten == destination.Length)
                        {
                            return false;
                        }

                        destination[charsWritten] = ' ';
                        charsWritten++;
                        return true;
                    case 10: // % -n
                        if (!percentSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = percentSymbol.Length;
                        if (charsWritten == destination.Length)
                        {
                            return false;
                        }

                        destination[charsWritten] = ' ';
                        charsWritten++;

                        if (!negativeSignSymbol.TryCopyTo(destination[charsWritten..]))
                        {
                            return false;
                        }

                        charsWritten += negativeSignSymbol.Length;
                        return true;
                    default: // n- %
                        // No leading part required for other patterns
                        return true;
                }
            }

            static bool TryAppendTrailingNegativePercentPattern(Span<char> destination, out int charsWritten, string percentSymbol, string negativeSignSymbol, int pattern)
            {
                charsWritten = 0;
                switch (pattern)
                {
                    case 0: // -n %: trailing is " " + percentSymbol
                        if (destination.IsEmpty)
                        {
                            return false;
                        }

                        destination[0] = ' ';
                        charsWritten = 1;
                        if (!percentSymbol.TryCopyTo(destination[charsWritten..]))
                        {
                            return false;
                        }

                        charsWritten += percentSymbol.Length;
                        return true;
                    case 1: // -n%: trailing is percentSymbol
                        if (!percentSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = percentSymbol.Length;
                        return true;
                    case 2: // -%n: no trailing addition
                    case 3: // %-n: no trailing addition
                        return true;
                    case 4: // %n-: trailing is negativeSignSymbol
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        return true;
                    case 5: // n-%: trailing is negativeSignSymbol + percentSymbol
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        if (!percentSymbol.TryCopyTo(destination[charsWritten..]))
                        {
                            return false;
                        }

                        charsWritten += percentSymbol.Length;
                        return true;
                    case 6: // n%-: trailing is percentSymbol + negativeSignSymbol
                        if (!percentSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = percentSymbol.Length;
                        if (!negativeSignSymbol.TryCopyTo(destination[charsWritten..]))
                        {
                            return false;
                        }

                        charsWritten += negativeSignSymbol.Length;
                        return true;
                    case 7: // -% n: no trailing addition
                        return true;
                    case 8: // n %-: trailing is " " + percentSymbol + negativeSignSymbol
                        if (destination.Length < 1 + percentSymbol.Length + negativeSignSymbol.Length)
                        {
                            return false;
                        }

                        destination[0] = ' ';
                        charsWritten = 1;
                        percentSymbol.CopyTo(destination[charsWritten..]);
                        charsWritten += percentSymbol.Length;
                        negativeSignSymbol.CopyTo(destination[charsWritten..]);
                        charsWritten += negativeSignSymbol.Length;
                        return true;
                    case 9: // % n-: trailing is negativeSignSymbol
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        return true;
                    case 10: // % -n: no trailing addition
                        return true;
                    default: // n- %: trailing is negativeSignSymbol + " " + percentSymbol
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        if (destination.Length == charsWritten)
                        {
                            return false;
                        }

                        destination[charsWritten] = ' ';
                        charsWritten++;
                        if (!percentSymbol.TryCopyTo(destination[charsWritten..]))
                        {
                            return false;
                        }

                        charsWritten += percentSymbol.Length;
                        return true;
                }
            }
        }

        /// <summary>
        ///     The "C" (or currency) format specifier converts a number to a string that represents a currency amount. The
        ///     precision specifier indicates the desired number of decimal places in the result string. If the precision specifier
        ///     is omitted, the default precision is defined by the <see cref="NumberFormatInfo.CurrencyDecimalDigits" /> property.
        /// </summary>
        /// <remarks>
        ///     If the value to be formatted has more than the specified or default number of decimal places, the fractional
        ///     value is rounded in the result string. If the value to the right of the number of specified decimal places is 5 or
        ///     greater, the last digit in the result string is rounded away from zero.
        /// </remarks>
        private static string FormatWithCurrencyFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.ToString(format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, formatProvider.CurrencyDecimalDigits, out var maxNbDecimals))
            {
                // not a valid "C" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            Span<char> buffer = stackalloc char[StackLimit]; // Use stack memory
            int charsWritten;
            while (!TryFormatWithCurrencyFormat(buffer, out charsWritten, numerator, denominator, format, formatProvider, maxNbDecimals))
            {
                buffer = new char[buffer.Length * 2]; // Use heap if needed
            }

            return new string(buffer[..charsWritten]);
        }

        private static bool TryFormatWithCurrencyFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, ReadOnlySpan<char> format,
            NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, formatProvider.CurrencyDecimalDigits, out var maxNbDecimals))
            {
                // not a valid "C" format: assuming a custom format
                return TryFormatWithCustomFormat(destination, out charsWritten, numerator, denominator, format, formatProvider);
            }

            return TryFormatWithCurrencyFormat(destination, out charsWritten, numerator, denominator, format, formatProvider, maxNbDecimals);
        }

        private static bool TryFormatWithCurrencyFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, ReadOnlySpan<char> format,
            NumberFormatInfo formatProvider,
            int maxNbDecimals)
        {
            if (maxNbDecimals == 0)
            {
                var roundedValue = RoundToBigInteger(numerator, denominator, DefaultMidpointRoundingMode);
                return roundedValue.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            var (roundedNumerator, roundedDenominator) = Round(numerator, denominator, maxNbDecimals, DefaultMidpointRoundingMode);
            if (roundedNumerator.IsZero)
            {
                return 0.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            var currencyFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = formatProvider.CurrencyDecimalSeparator,
                NumberGroupSeparator = formatProvider.CurrencyGroupSeparator,
                NumberGroupSizes = formatProvider.CurrencyGroupSizes,
                NativeDigits = formatProvider.NativeDigits,
                DigitSubstitution = formatProvider.DigitSubstitution
            };

            if (roundedNumerator.Sign > 0)
            {
                if (!TryAppendLeadingSymbolsWithPositivePattern(destination, out charsWritten, formatProvider.CurrencySymbol, formatProvider.CurrencyPositivePattern))
                {
                    return false;
                }

                if (!TryAppendDecimals(destination[charsWritten..], out var decimalsWritten, roundedNumerator, roundedDenominator, currencyFormatInfo, maxNbDecimals, "N0"))
                {
                    return false;
                }

                charsWritten += decimalsWritten;
                if (!TryAppendTrailingSymbolsWithPositivePattern(destination[charsWritten..], out var trailingCharsWritten, formatProvider.CurrencySymbol,
                        formatProvider.CurrencyPositivePattern))
                {
                    return false;
                }

                charsWritten += trailingCharsWritten;
            }
            else
            {
                if (!TryAppendLeadingSymbolsWithNegativePattern(destination, out charsWritten, formatProvider.CurrencySymbol, formatProvider.NegativeSign,
                        formatProvider.CurrencyNegativePattern))
                {
                    return false;
                }

                roundedNumerator = -roundedNumerator;
                if (!TryAppendDecimals(destination[charsWritten..], out var decimalsWritten, roundedNumerator, roundedDenominator, currencyFormatInfo, maxNbDecimals, "N0"))
                {
                    return false;
                }

                charsWritten += decimalsWritten;
                if (!TryAppendTrailingSymbolsWithNegativePattern(destination[charsWritten..], out var trailingCharsWritten, formatProvider.CurrencySymbol,
                        formatProvider.NegativeSign,
                        formatProvider.CurrencyNegativePattern))
                {
                    return false;
                }

                charsWritten += trailingCharsWritten;
            }

            return true;

            static bool TryAppendLeadingSymbolsWithPositivePattern(Span<char> destination, out int charsWritten, string currencySymbol, int pattern)
            {
                charsWritten = 0;
                switch (pattern)
                {
                    case 0: // $n
                        if (!currencySymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = currencySymbol.Length;
                        return true;
                    case 1: // n$
                        return true;
                    case 2: // $ n
                        if (destination.Length < currencySymbol.Length + 1)
                        {
                            return false;
                        }

                        currencySymbol.CopyTo(destination);
                        destination[currencySymbol.Length] = ' ';
                        charsWritten = currencySymbol.Length + 1;
                        return true;
                    default: // n $
                        return true;
                }
            }

            static bool TryAppendTrailingSymbolsWithPositivePattern(Span<char> destination, out int charsWritten, string currencySymbol, int pattern)
            {
                charsWritten = 0;
                switch (pattern)
                {
                    case 0: // $n
                        return true;
                    case 1: // n$
                        if (!currencySymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = currencySymbol.Length;
                        return true;
                    case 2: // $ n
                        return true;
                    default: // n $
                        if (destination.Length < currencySymbol.Length + 1)
                        {
                            return false;
                        }

                        destination[0] = ' ';
                        currencySymbol.CopyTo(destination[1..]);
                        charsWritten = currencySymbol.Length + 1;
                        return true;
                }
            }

            static bool TryAppendLeadingSymbolsWithNegativePattern(Span<char> destination, out int charsWritten, string currencySymbol, string negativeSignSymbol, int pattern)
            {
                charsWritten = 0;
                switch (pattern)
                {
                    case 0: // ($n)
                        if (destination.Length < currencySymbol.Length + 3)
                        {
                            return false;
                        }

                        destination[0] = '(';
                        currencySymbol.CopyTo(destination[1..]);
                        charsWritten = currencySymbol.Length + 1;
                        return true;
                    case 1: // -$n
                        if (destination.Length < currencySymbol.Length + negativeSignSymbol.Length + 1)
                        {
                            return false;
                        }

                        negativeSignSymbol.CopyTo(destination);
                        currencySymbol.CopyTo(destination[negativeSignSymbol.Length..]);
                        charsWritten = negativeSignSymbol.Length + currencySymbol.Length;
                        return true;
                    case 2: // $-n
                        if (destination.Length < currencySymbol.Length + negativeSignSymbol.Length + 1)
                        {
                            return false;
                        }

                        currencySymbol.CopyTo(destination);
                        negativeSignSymbol.CopyTo(destination[currencySymbol.Length..]);
                        charsWritten = currencySymbol.Length + negativeSignSymbol.Length;
                        return true;
                    case 3: // $n-
                        if (destination.Length < currencySymbol.Length + negativeSignSymbol.Length + 1)
                        {
                            return false;
                        }

                        currencySymbol.CopyTo(destination);
                        charsWritten = currencySymbol.Length;
                        return true;
                    case 4: // (n$)
                        if (destination.Length < currencySymbol.Length + 3)
                        {
                            return false;
                        }

                        destination[0] = '(';
                        charsWritten = 1;
                        return true;
                    case 5: // -n$
                        if (destination.Length < currencySymbol.Length + negativeSignSymbol.Length + 1)
                        {
                            return false;
                        }

                        negativeSignSymbol.CopyTo(destination);
                        charsWritten = negativeSignSymbol.Length;
                        return true;
                    case 6: // n-$
                    case 7: // n$-
                        return true;
                    case 8: // -n $
                        if (destination.Length < currencySymbol.Length + negativeSignSymbol.Length + 2)
                        {
                            return false;
                        }

                        negativeSignSymbol.CopyTo(destination);
                        charsWritten = negativeSignSymbol.Length;
                        return true;
                    case 9: // -$ n
                        if (destination.Length < negativeSignSymbol.Length + currencySymbol.Length + 2)
                        {
                            return false;
                        }

                        negativeSignSymbol.CopyTo(destination);
                        currencySymbol.CopyTo(destination[negativeSignSymbol.Length..]);
                        destination[negativeSignSymbol.Length + currencySymbol.Length] = ' ';
                        charsWritten = negativeSignSymbol.Length + currencySymbol.Length + 1;
                        return true;
                    case 10: // n $-
                        return true;
                    case 11: // $ n-
                        if (destination.Length < currencySymbol.Length + negativeSignSymbol.Length + 2)
                        {
                            return false;
                        }

                        currencySymbol.CopyTo(destination);
                        destination[currencySymbol.Length] = ' ';
                        charsWritten = currencySymbol.Length + 1;
                        return true;
                    case 12: // $ -n
                        if (destination.Length < currencySymbol.Length + negativeSignSymbol.Length + 2)
                        {
                            return false;
                        }

                        currencySymbol.CopyTo(destination);
                        destination[currencySymbol.Length] = ' ';
                        negativeSignSymbol.CopyTo(destination[(currencySymbol.Length + 1)..]);
                        charsWritten = currencySymbol.Length + negativeSignSymbol.Length + 1;
                        return true;
                    case 13: // n- $
                        return true;
                    case 14: // ($ n)
                        if (destination.Length < currencySymbol.Length + 4)
                        {
                            return false;
                        }

                        destination[0] = '(';
                        currencySymbol.CopyTo(destination[1..]);
                        destination[currencySymbol.Length + 1] = ' ';
                        charsWritten = currencySymbol.Length + 2;
                        return true;
                    case 15: // (n $)
                        if (destination.Length < currencySymbol.Length + 4)
                        {
                            return false;
                        }

                        destination[0] = '(';
                        charsWritten = 1;
                        return true;
                    default: // $- n
                        if (destination.Length < currencySymbol.Length + negativeSignSymbol.Length + 2)
                        {
                            return false;
                        }

                        currencySymbol.CopyTo(destination);
                        negativeSignSymbol.CopyTo(destination[currencySymbol.Length..]);
                        destination[currencySymbol.Length + negativeSignSymbol.Length] = ' ';
                        charsWritten = currencySymbol.Length + negativeSignSymbol.Length + 1;
                        return true;
                }
            }

            static bool TryAppendTrailingSymbolsWithNegativePattern(Span<char> destination, out int charsWritten, string currencySymbol, string negativeSignSymbol, int pattern)
            {
                charsWritten = 0;
                switch (pattern)
                {
                    case 0: // ($n)
                        if (destination.IsEmpty)
                        {
                            return false;
                        }

                        destination[0] = ')';
                        charsWritten = 1;
                        return true;
                    case 1: // -$n
                        return true;
                    case 2: // $-n
                        return true;
                    case 3: // $n-
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        return true;
                    case 4: // (n$)
                        if (destination.Length < currencySymbol.Length + 1)
                        {
                            return false;
                        }

                        currencySymbol.CopyTo(destination);
                        destination[currencySymbol.Length] = ')';
                        charsWritten = currencySymbol.Length + 1;
                        return true;
                    case 5: // -n$
                        if (!currencySymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = currencySymbol.Length;
                        return true;
                    case 6: // n-$
                        if (destination.Length < negativeSignSymbol.Length + currencySymbol.Length)
                        {
                            return false;
                        }

                        negativeSignSymbol.CopyTo(destination);
                        currencySymbol.CopyTo(destination[negativeSignSymbol.Length..]);
                        charsWritten = negativeSignSymbol.Length + currencySymbol.Length;
                        return true;
                    case 7: // n$-
                        if (destination.Length < currencySymbol.Length + negativeSignSymbol.Length)
                        {
                            return false;
                        }

                        currencySymbol.CopyTo(destination);
                        negativeSignSymbol.CopyTo(destination[currencySymbol.Length..]);
                        charsWritten = currencySymbol.Length + negativeSignSymbol.Length;
                        return true;
                    case 8: // -n $
                        if (destination.Length < currencySymbol.Length + 1)
                        {
                            return false;
                        }

                        destination[0] = ' ';
                        currencySymbol.CopyTo(destination[1..]);
                        charsWritten = currencySymbol.Length + 1;
                        return true;
                    case 9: // -$ n
                        return true;
                    case 10: // n $-
                        if (destination.Length < 1 + currencySymbol.Length + negativeSignSymbol.Length)
                        {
                            return false;
                        }

                        destination[0] = ' ';
                        currencySymbol.CopyTo(destination[1..]);
                        negativeSignSymbol.CopyTo(destination[(currencySymbol.Length + 1)..]);
                        charsWritten = 1 + currencySymbol.Length + negativeSignSymbol.Length;
                        return true;
                    case 11: // $ n-
                        if (!negativeSignSymbol.TryCopyTo(destination))
                        {
                            return false;
                        }

                        charsWritten = negativeSignSymbol.Length;
                        return true;
                    case 12: // $ -n
                        return true;
                    case 13: // n- $
                        if (destination.Length < negativeSignSymbol.Length + 1 + currencySymbol.Length)
                        {
                            return false;
                        }

                        negativeSignSymbol.CopyTo(destination);
                        destination[negativeSignSymbol.Length] = ' ';
                        currencySymbol.CopyTo(destination[(negativeSignSymbol.Length + 1)..]);
                        charsWritten = negativeSignSymbol.Length + 1 + currencySymbol.Length;
                        return true;
                    case 14: // ($ n)
                        if (destination.IsEmpty)
                        {
                            return false;
                        }

                        destination[0] = ')';
                        charsWritten = 1;
                        return true;
                    case 15: // (n $)
                        if (destination.Length < currencySymbol.Length + 2)
                        {
                            return false;
                        }

                        destination[0] = ' ';
                        currencySymbol.CopyTo(destination[1..]);
                        destination[1 + currencySymbol.Length] = ')';
                        charsWritten = 1 + currencySymbol.Length + 1;
                        return true;
                    default: // $- n
                        return true;
                }
            }
        }

        /// <summary>
        ///     Exponential format specifier (E)
        ///     The exponential ("E") format specifier converts a number to a string of the form "-d.ddd…E+ddd" or "-d.ddd…e+ddd",
        ///     where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative. Exactly one
        ///     digit always precedes the decimal point.
        /// </summary>
        /// <remarks>
        ///     The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier
        ///     is omitted, a default of six digits after the decimal point is used.
        ///     The case of the format specifier indicates whether to prefix the exponent with an "E" or an "e". The exponent
        ///     always consists of a plus or minus sign and a minimum of three digits. The exponent is padded with zeros to meet
        ///     this minimum, if required.
        /// </remarks>
        private static string FormatWithScientificFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.ToString(format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, DefaultScientificFormatPrecision, out var maxNbDecimals))
            {
                // not a valid "E" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            // worst case: -1.23E+123456
            var significantDigitsLength = maxNbDecimals + 1;
            // assuming a maximum exponent equal to 10^999999
            var exponentDigitsLength = 1 + int.Max(formatProvider.NegativeSign.Length, formatProvider.PositiveSign.Length) + 6;
            var maxLength = formatProvider.NegativeSign.Length + formatProvider.NumberDecimalSeparator.Length + significantDigitsLength + exponentDigitsLength;

            var buffer = maxLength <= StackLimit
                ? stackalloc char[maxLength] // Use stack memory
                : new char[maxLength]; // Use heap if needed

            TryFormatWithScientificFormat(buffer, out var charsWritten, numerator, denominator, formatProvider, maxNbDecimals, format[0]);
            return new string(buffer[..charsWritten]);
        }

        private static bool TryFormatWithScientificFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, ReadOnlySpan<char> format,
            NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, DefaultScientificFormatPrecision, out var maxNbDecimals))
            {
                // not a valid "E" format: assuming a custom format
                return TryFormatWithCustomFormat(destination, out charsWritten, numerator, denominator, format, formatProvider);
            }

            return TryFormatWithScientificFormat(destination, out charsWritten, numerator, denominator, formatProvider, maxNbDecimals, format[0]);
        }

        private static bool TryFormatWithScientificFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator,
            NumberFormatInfo formatProvider, int maxNbDecimals, char exponentSymbol)
        {
            charsWritten = 0;
            if (numerator.Sign < 0)
            {
                if (!formatProvider.NegativeSign.TryCopyTo(destination))
                {
                    return false;
                }

                charsWritten += formatProvider.NegativeSign.Length;
                numerator = -numerator;
            }

            var exponent = GetExponentPower(numerator, denominator, out var exponentTerm);
            var mantissa = exponent switch
            {
                0 => Round(numerator, denominator, maxNbDecimals, DefaultMidpointRoundingMode),
                > 0 => Round(numerator, denominator * exponentTerm, maxNbDecimals, DefaultMidpointRoundingMode),
                _ => Round(numerator * exponentTerm, denominator, maxNbDecimals, DefaultMidpointRoundingMode)
            };

            if (mantissa.Denominator.IsOne)
            {
                Span<char> formatSpan = stackalloc char[11]; // "F" + up to 10 digits
                formatSpan[0] = 'F';
                maxNbDecimals.TryFormat(formatSpan[1..], out var formatCharsWritten, default, CultureInfo.InvariantCulture);
                if (!mantissa.Numerator.TryFormat(destination[charsWritten..], out var written, formatSpan[..(formatCharsWritten + 1)], formatProvider))
                {
                    return false;
                }

                charsWritten += written;
            }
            else
            {
                if (!TryAppendDecimals(destination[charsWritten..], out var written, mantissa.Numerator, mantissa.Denominator, formatProvider, maxNbDecimals, "F0"))
                {
                    return false;
                }

                charsWritten += written;
            }

            if (charsWritten == destination.Length)
            {
                return false;
            }

            destination[charsWritten] = exponentSymbol;
            charsWritten++;
            if (exponent >= 0)
            {
                if (!formatProvider.PositiveSign.TryCopyTo(destination[charsWritten..]))
                {
                    return false;
                }

                charsWritten += formatProvider.PositiveSign.Length;
            }

            // note: for the standard numeric types this is fixed to "D3" (but we could go higher)
            ReadOnlySpan<char> exponentFormat = exponent < 1000 ? "D3" : Span<char>.Empty;
            if (!exponent.TryFormat(destination[charsWritten..], out var exponentCharsWritten, exponentFormat, formatProvider))
            {
                return false;
            }

            charsWritten += exponentCharsWritten;
            return true;
        }

        /// <summary>
        ///     The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific
        ///     notation, depending on the type of the number and whether a precision specifier is present.
        /// </summary>
        /// <remarks>
        ///     The precision specifier
        ///     defines the maximum number of significant digits that can appear in the result string. If the precision specifier
        ///     is omitted or zero, the type of the number determines the default precision.
        /// </remarks>
        private static string FormatGeneral(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, DefaultGeneralFormatPrecision, out var maxNbDecimals))
            {
                // not a valid "G" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            if (maxNbDecimals == 0)
            {
                maxNbDecimals = DefaultGeneralFormatPrecision;
            }

            // worst case: -1.23E+123456
            var significantDigitsLength = maxNbDecimals;
            // assuming a maximum exponent equal to 10^999999
            var exponentDigitsLength = 1 + int.Max(formatProvider.NegativeSign.Length, formatProvider.PositiveSign.Length) + 6;
            var maxLength = formatProvider.NegativeSign.Length + formatProvider.NumberDecimalSeparator.Length + significantDigitsLength + exponentDigitsLength;

            var buffer = maxLength <= StackLimit
                ? stackalloc char[maxLength] // Use stack memory
                : new char[maxLength]; // Use heap if needed

            TryFormatGeneral(buffer, out var charsWritten, numerator, denominator, formatProvider, maxNbDecimals, format[0] is 'g');
            return new string(buffer[..charsWritten]);
        }

        private static bool TryFormatGeneral(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, ReadOnlySpan<char> format,
            NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.TryFormat(destination, out charsWritten, format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, DefaultGeneralFormatPrecision, out var maxNbDecimals))
            {
                // not a valid "G" format: assuming a custom format
                return TryFormatWithCustomFormat(destination, out charsWritten, numerator, denominator, format, formatProvider);
            }

            if (maxNbDecimals == 0)
            {
                maxNbDecimals = DefaultGeneralFormatPrecision;
            }

            return TryFormatGeneral(destination, out charsWritten, numerator, denominator, formatProvider, maxNbDecimals, format[0] == 'g');
        }

        private static bool TryFormatGeneral(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, NumberFormatInfo formatProvider,
            int maxNbDecimals, bool lowerCase)
        {
            charsWritten = 0;
            if (numerator.Sign < 0)
            {
                if (!formatProvider.NegativeSign.TryCopyTo(destination))
                {
                    return false;
                }

                charsWritten += formatProvider.NegativeSign.Length;
                numerator = -numerator;
            }

            var exponent = GetExponentPower(numerator, denominator, out var exponentTerm);

            if (exponent == maxNbDecimals - 1)
            {
                // integral result: both 123400 (1.234e5) and 123400.01 (1.234001e+005) result in "123400" with the "G6" format
                var roundedValue = RoundToBigInteger(numerator, denominator, DefaultMidpointRoundingMode);
                if (!roundedValue.TryFormat(destination[charsWritten..], out var written))
                {
                    return false;
                }

                charsWritten += written;
                return true;
            }

            if (exponent > maxNbDecimals - 1)
            {
                // we are required to shorten down a number of the form 123400 (1.234E+05)
                if (maxNbDecimals == 1)
                {
                    var roundedValue = RoundToBigInteger(numerator, denominator * exponentTerm, DefaultMidpointRoundingMode);
                    if (!roundedValue.TryFormat(destination[charsWritten..], out var written))
                    {
                        return false;
                    }

                    charsWritten += written;
                }
                else
                {
                    var mantissa = Round(numerator, denominator * exponentTerm, maxNbDecimals - 1, DefaultMidpointRoundingMode);
                    if (!TryAppendSignificantDecimals(destination[charsWritten..], out var written, mantissa, formatProvider, maxNbDecimals - 1, "F0"))
                    {
                        return false;
                    }

                    charsWritten += written;
                }

                if (!TryAppendExponentWithSignificantDigits(destination[charsWritten..], out var exponentCharsWritten, exponent, formatProvider, lowerCase ? 'e' : 'E'))
                {
                    return false;
                }

                charsWritten += exponentCharsWritten;
                return true;
            }

            if (exponent <= -5)
            {
                // the largest value would have the form: 1.23e-5 (0.0000123)
                var mantissa = Round(numerator * exponentTerm, denominator, maxNbDecimals - 1, DefaultMidpointRoundingMode);
                if (!TryAppendSignificantDecimals(destination[charsWritten..], out var written, mantissa, formatProvider, maxNbDecimals - 1, "F0"))
                {
                    return false;
                }

                charsWritten += written;
                if (!TryAppendExponentWithSignificantDigits(destination[charsWritten..], out written, exponent, formatProvider, lowerCase ? 'e' : 'E'))
                {
                    return false;
                }

                charsWritten += written;
            }
            else
            {
                // the smallest value would have the form: 1.23e-4 (0.000123)
                var roundedDecimal = Round(numerator, denominator, maxNbDecimals - exponent - 1, DefaultMidpointRoundingMode);
                if (!TryAppendSignificantDecimals(destination[charsWritten..], out var written, roundedDecimal, formatProvider, maxNbDecimals - exponent - 1, "F0"))
                {
                    return false;
                }

                charsWritten += written;
            }

            return true;
        }

        /// <summary>
        ///     Formats a fraction as a string with a specified number of significant digits after the radix point.
        /// </summary>
        /// <param name="numerator">The numerator of the fraction.</param>
        /// <param name="denominator">The denominator of the fraction.</param>
        /// <param name="format">
        ///     The format string to use, which specifies the maximum number of digits after the radix point.
        /// </param>
        /// <param name="formatProvider">An object that provides culture-specific formatting information.</param>
        /// <returns>
        ///     A string representation of the fraction, formatted with the specified number of significant digits after the
        ///     radix point.
        /// </returns>
        /// <remarks>
        ///     The method determines the formatting style based on the magnitude of the fraction:
        ///     <list type="bullet">
        ///         <item>
        ///             For values greater than 1e5, the fraction is formatted in scientific notation (e.g., 1.23e6 for 1230000).
        ///         </item>
        ///         <item>
        ///             For values less than or equal to 1e-4, the fraction is formatted in scientific notation (e.g., 1.23e-4 for
        ///             0.000123).
        ///         </item>
        ///         <item>
        ///             For values between 1e-3 and 1e5, the fraction is formatted as a decimal number.
        ///         </item>
        ///     </list>
        /// </remarks>
        private static string FormatWithSignificantDigitsAfterRadix(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(formatProvider);
            }

            if (!TryGetPrecisionDigits(format, 2, out var maxDigitsAfterRadix))
            {
                // not a valid "S" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            // typical worst case: -1.23E+123456
            var significantDigitsLength = maxDigitsAfterRadix;
            // assuming a maximum exponent equal to 10^999999
            var exponentDigitsLength = 1 + int.Max(formatProvider.NegativeSign.Length, formatProvider.PositiveSign.Length) + 6;
            // worst case for grouping is "1_2_3_0_0_0" with every '_' representing a group separator (up to 9 characters) 
            var maxGroupsLength = 5 * formatProvider.NumberGroupSeparator.Length;
            var maxLength = formatProvider.NegativeSign.Length + formatProvider.NumberDecimalSeparator.Length + significantDigitsLength +
                            int.Max(maxGroupsLength, exponentDigitsLength); // we can either have groups or an exponent

            var buffer = maxLength <= StackLimit
                ? stackalloc char[maxLength] // Use stack memory
                : new char[maxLength]; // Use heap if needed

            TryFormatWithSignificantDigitsAfterRadix(buffer, out var charsWritten, numerator, denominator, formatProvider, maxDigitsAfterRadix, format[0] is 's');
            return new string(buffer[..charsWritten]);
        }

        private static bool TryFormatWithSignificantDigitsAfterRadix(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator,
            ReadOnlySpan<char> format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.TryFormat(destination, out charsWritten, default, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, 2, out var maxDigitsAfterRadix))
            {
                // not a valid "S" format: assuming a custom format
                return TryFormatWithCustomFormat(destination, out charsWritten, numerator, denominator, format, formatProvider);
            }

            return TryFormatWithSignificantDigitsAfterRadix(destination, out charsWritten, numerator, denominator, formatProvider, maxDigitsAfterRadix, format[0] is 's');
        }

        private static bool TryFormatWithSignificantDigitsAfterRadix(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator,
            NumberFormatInfo formatProvider, int maxDigitsAfterRadix, bool lowerCase)
        {
            charsWritten = 0;
            if (numerator.Sign < 0)
            {
                if (!formatProvider.NegativeSign.TryCopyTo(destination))
                {
                    return false;
                }

                charsWritten += formatProvider.NegativeSign.Length;
                numerator = -numerator;
            }

            const string quotientFormat = "N0";
            var exponent = GetExponentPower(numerator, denominator, out var exponentTerm);
            QuantityValue mantissa;
            switch (exponent)
            {
                case > 5:
                {
                    // the smallest value would have the form: 1.23e6 (1230000)
                    mantissa = Round(numerator, denominator * exponentTerm, maxDigitsAfterRadix, DefaultMidpointRoundingMode);
                    if (!TryAppendSignificantDecimals(destination[charsWritten..], out var written, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat))
                    {
                        return false;
                    }

                    charsWritten += written;
                    if (!TryAppendExponentWithSignificantDigits(destination[charsWritten..], out written, exponent, formatProvider, lowerCase ? 'e' : 'E'))
                    {
                        return false;
                    }

                    charsWritten += written;
                    return true;
                }
                case <= -4:
                {
                    // the largest value would have the form: 1.23e-4 (0.000123)
                    mantissa = Round(numerator * exponentTerm, denominator, maxDigitsAfterRadix, DefaultMidpointRoundingMode);
                    if (!TryAppendSignificantDecimals(destination[charsWritten..], out var written, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat))
                    {
                        return false;
                    }

                    charsWritten += written;
                    if (!TryAppendExponentWithSignificantDigits(destination[charsWritten..], out written, exponent, formatProvider, lowerCase ? 'e' : 'E'))
                    {
                        return false;
                    }

                    charsWritten += written;
                    return true;
                }
                case < 0:
                {
                    // the smallest value would have the form: 1.23e-3 (0.00123)
                    var leadingZeroes = -exponent;
                    maxDigitsAfterRadix += leadingZeroes - 1;
                    mantissa = Round(numerator, denominator, maxDigitsAfterRadix, DefaultMidpointRoundingMode);
                    if (!TryAppendSignificantDecimals(destination[charsWritten..], out var written, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat))
                    {
                        return false;
                    }

                    charsWritten += written;
                    return true;
                }
                default:
                {
                    // the largest value would have the form: 1.23e5 (123000)
                    mantissa = Round(numerator, denominator, maxDigitsAfterRadix, DefaultMidpointRoundingMode);
                    if (!TryAppendSignificantDecimals(destination[charsWritten..], out var written, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat))
                    {
                        return false;
                    }

                    charsWritten += written;
                    return true;
                }
            }
        }

        private static string FormatWithCustomFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            return new QuantityValue(numerator, denominator).ToDouble().ToString(format, formatProvider);
        }

        private static bool TryFormatWithCustomFormat(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, ReadOnlySpan<char> format,
            NumberFormatInfo formatProvider)
        {
            return new QuantityValue(numerator, denominator).ToDouble().TryFormat(destination, out charsWritten, format, formatProvider);
        }

        /// <summary>
        ///     Attempts to append the decimal representation of a fraction to the specified destination span.
        /// </summary>
        /// <param name="destination">
        ///     The <see cref="Span{T}" /> of characters to which the decimal representation will be appended.
        /// </param>
        /// <param name="charsWritten">
        ///     When this method returns, contains the number of characters written to the <paramref name="destination" />.
        /// </param>
        /// <param name="numerator">
        ///     The numerator of the fraction.
        /// </param>
        /// <param name="denominator">
        ///     The denominator of the fraction. It should be a power of 10, corresponding to the specified
        ///     <paramref name="nbDecimals" />.
        /// </param>
        /// <param name="formatProvider">
        ///     The <see cref="NumberFormatInfo" /> that provides culture-specific formatting information.
        /// </param>
        /// <param name="nbDecimals">
        ///     The maximum number of decimal places to include in the representation.
        /// </param>
        /// <param name="quotientFormat">
        ///     An optional format string for formatting the quotient part of the fraction. Defaults to <c>"F0"</c>.
        /// </param>
        /// <returns>
        ///     <c>true</c> if the decimal representation was successfully appended to the <paramref name="destination" />;
        ///     otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        ///     This method calculates the decimal representation of the given fraction by dividing the numerator
        ///     by the denominator and appending the result to the <paramref name="destination" />. It ensures that the specified
        ///     number of decimal places is respected by padding with "0" if necessary.
        ///     <para>
        ///         The fraction must represent a value with a denominator that is a power of 10, corresponding to the specified
        ///         <paramref name="nbDecimals" />.
        ///     </para>
        /// </remarks>
        private static bool TryAppendDecimals(Span<char> destination, out int charsWritten, BigInteger numerator, BigInteger denominator, NumberFormatInfo formatProvider,
            int nbDecimals, ReadOnlySpan<char> quotientFormat)
        {
            if (denominator <= long.MaxValue / 10 && numerator <= long.MaxValue && numerator >= long.MinValue)
            {
                return TryAppendDecimals(destination, out charsWritten, (long)numerator, (long)denominator, formatProvider, nbDecimals, quotientFormat);
            }
            
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);

            if (!quotient.TryFormat(destination, out charsWritten, quotientFormat, formatProvider))
            {
                return false;
            }

            if (!formatProvider.NumberDecimalSeparator.TryCopyTo(destination[charsWritten..]))
            {
                return false;
            }

            charsWritten += formatProvider.NumberDecimalSeparator.Length;

            var decimalsAdded = 0;
            while (!remainder.IsZero && decimalsAdded++ < nbDecimals - 1)
            {
                if (charsWritten == destination.Length)
                {
                    return false;
                }
                
                denominator = PreviousPowerOfTen(denominator, nbDecimals - decimalsAdded + 1);
                var digit = (char)('0' + (int)BigInteger.DivRem(remainder, denominator, out remainder));
                destination[charsWritten] = digit;
                charsWritten ++;
            }

            if (remainder.IsZero)
            {
                var zerosRemaining = nbDecimals - decimalsAdded;
                if (charsWritten + zerosRemaining > destination.Length)
                {
                    return false;
                }
                
                destination.Slice(charsWritten, zerosRemaining).Fill('0');
                charsWritten += zerosRemaining;
            }
            else if (charsWritten == destination.Length)
            {
                return false;
            }
            else
            {
                var digit = (char)('0' + (int)remainder);
                destination[charsWritten] = digit;
                charsWritten ++;
            }
            
            return true;
        }

        private static bool TryAppendDecimals(Span<char> destination, out int charsWritten, long numerator, long denominator, NumberFormatInfo formatProvider,
            int nbDecimals, ReadOnlySpan<char> quotientFormat)
        {
            var (quotient, remainder) = long.DivRem(numerator, denominator);

            if (!quotient.TryFormat(destination, out charsWritten, quotientFormat, formatProvider))
            {
                return false;
            }

            if (!formatProvider.NumberDecimalSeparator.TryCopyTo(destination[charsWritten..]))
            {
                return false;
            }

            charsWritten += formatProvider.NumberDecimalSeparator.Length;

            var decimalsAdded = 0;
            while (remainder != 0 && decimalsAdded++ < nbDecimals)
            {
                if (charsWritten == destination.Length)
                {
                    return false;
                }

                (var digit, remainder) = long.DivRem(remainder * 10, denominator);
                destination[charsWritten] = (char)(digit + '0');
                charsWritten++;
            }

            if (remainder == 0)
            {
                var zerosRemaining = nbDecimals - decimalsAdded;
                if (charsWritten + zerosRemaining > destination.Length)
                {
                    return false;
                }
                
                destination.Slice(charsWritten, zerosRemaining).Fill('0');
                charsWritten += zerosRemaining;
            }

            return true;
        }

        /// <summary>
        ///     Attempts to append the significant decimal digits of a fractional number to the specified destination span.
        /// </summary>
        /// <param name="destination">
        ///     The <see cref="Span{T}" /> of characters to which the significant decimal digits will be appended.
        /// </param>
        /// <param name="charsWritten">
        ///     When this method returns, contains the number of characters written to the <paramref name="destination" />.
        /// </param>
        /// <param name="decimalFraction">
        ///     The fractional number whose significant decimal digits are to be appended.
        ///     The denominator of this fraction must be a power of 10, corresponding to the <paramref name="maxNbDecimals" />.
        /// </param>
        /// <param name="formatProvider">
        ///     The <see cref="NumberFormatInfo" /> that provides culture-specific formatting information.
        /// </param>
        /// <param name="maxNbDecimals">
        ///     The maximum number of decimal digits to append.
        /// </param>
        /// <param name="quotientFormat">
        ///     An optional format string that specifies the format of the quotient.
        /// </param>
        /// <returns>
        ///     <see langword="true" /> if the significant decimal digits were successfully appended; otherwise,
        ///     <see langword="false" />.
        /// </returns>
        /// <remarks>
        ///     This method calculates and appends the significant decimal digits of the given fractional number.
        ///     It ensures that the number of appended decimal digits does not exceed the specified maximum.
        ///     <para>
        ///         The <paramref name="decimalFraction" /> must represent a value with a denominator that is a power of 10,
        ///         equal to the specified <paramref name="maxNbDecimals" />.
        ///     </para>
        ///     <para>
        ///         The method writes the quotient to the <paramref name="destination" /> span using the specified
        ///         <paramref name="quotientFormat" /> and appends the decimal separator followed by the significant decimal
        ///         digits.
        ///     </para>
        /// </remarks>
        private static bool TryAppendSignificantDecimals(Span<char> destination, out int charsWritten, QuantityValue decimalFraction, NumberFormatInfo formatProvider,
            int maxNbDecimals, ReadOnlySpan<char> quotientFormat)
        {
            var numerator = decimalFraction.Numerator;
            var denominator = decimalFraction.Denominator;
            if (denominator <= long.MaxValue / 10 && numerator <= long.MaxValue && numerator >= long.MinValue)
            {
                return TryAppendSignificantDecimals(destination, out charsWritten, (long)numerator, (long)denominator, formatProvider, maxNbDecimals, quotientFormat);
            }
            
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);

            if (!quotient.TryFormat(destination, out charsWritten, quotientFormat, formatProvider))
            {
                return false;
            }

            if (remainder.IsZero)
            {
                return true;
            }

            if (!formatProvider.NumberDecimalSeparator.TryCopyTo(destination[charsWritten..]))
            {
                return false;
            }

            charsWritten += formatProvider.NumberDecimalSeparator.Length;
            
            var decimalsRemaining = maxNbDecimals;
            do
            {
                if (charsWritten == destination.Length)
                {
                    return false;
                }
                
                denominator = PreviousPowerOfTen(denominator, decimalsRemaining);
                var digit = (char)('0' + (int)BigInteger.DivRem(remainder, denominator, out remainder));
                destination[charsWritten] = digit;
                charsWritten ++;
                decimalsRemaining--;
            } while (!remainder.IsZero && decimalsRemaining > 0);

            return true;
        }
        
        private static bool TryAppendSignificantDecimals(Span<char> destination, out int charsWritten, long numerator, long denominator, NumberFormatInfo formatProvider,
            int maxNbDecimals, ReadOnlySpan<char> quotientFormat)
        {
            var (quotient, remainder) = long.DivRem(numerator, denominator);

            if (!quotient.TryFormat(destination, out charsWritten, quotientFormat, formatProvider))
            {
                return false;
            }

            if (remainder == 0)
            {
                return true;
            }

            if (!formatProvider.NumberDecimalSeparator.TryCopyTo(destination[charsWritten..]))
            {
                return false;
            }

            charsWritten += formatProvider.NumberDecimalSeparator.Length;
            
            var decimalsRemaining = maxNbDecimals;
            do
            {
                if (charsWritten == destination.Length)
                {
                    return false;
                }
                
                (var digit, remainder) = long.DivRem(remainder * 10, denominator);
                destination[charsWritten++] = (char)(digit + '0');
                decimalsRemaining--;
            } while (remainder != 0 && decimalsRemaining > 0);

            return true;
        }

        private static bool TryAppendExponentWithSignificantDigits(Span<char> destination, out int charsWritten, int exponent,
            NumberFormatInfo formatProvider, char exponentSymbol)
        {
            charsWritten = 0;
            if (destination.IsEmpty)
            {
                return false;
            }

            destination[0] = exponentSymbol;
            charsWritten++;
            switch (exponent)
            {
                case <= -1000:
                {
                    if (!exponent.TryFormat(destination[charsWritten..], out var written, default, formatProvider))
                    {
                        return false;
                    }

                    charsWritten += written;
                    return true;
                }
                case <= 0:
                {
                    if (!exponent.TryFormat(destination[charsWritten..], out var written, "D2", formatProvider))
                    {
                        return false;
                    }

                    charsWritten += written;
                    return true;
                }
            }

            // exponent > 0
            if (!formatProvider.PositiveSign.TryCopyTo(destination[charsWritten..]))
            {
                return false;
            }

            charsWritten += formatProvider.PositiveSign.Length;
            ReadOnlySpan<char> exponentFormat = exponent switch
            {
                < 100 => "D2",
                < 1000 => "D3",
                _ => Span<char>.Empty
            };

            if (!exponent.TryFormat(destination[charsWritten..], out var exponentCharsWritten, exponentFormat, formatProvider))
            {
                return false;
            }

            charsWritten += exponentCharsWritten;
            return true;
        }

        /// <summary>
        ///     Calculates the exponent power for the given fraction terms.
        /// </summary>
        /// <param name="numerator">The numerator of the fraction.</param>
        /// <param name="denominator">The denominator of the fraction.</param>
        /// <param name="powerOfTen">
        ///     Output parameter that returns the power of ten that corresponds to the calculated exponent
        ///     power.
        /// </param>
        /// <returns>The exponent power for the given fraction.</returns>
        /// <remarks>It is expected that both terms have the same sign (i.e. the Fraction is positive)</remarks>
        private static int GetExponentPower(BigInteger numerator, BigInteger denominator, out BigInteger powerOfTen)
        {
            // Preconditions: numerator > 0, denominator > 0.
            var numLen = numerator.GetBitLength();
            var denLen = denominator.GetBitLength();
            // If the two numbers have equal bit-length, then their ratio is in [1,2) if numerator >= denominator,
            // or in (0,1) if numerator < denominator. In these cases the scientific exponent is fixed.
            if (numLen == denLen)
            {
                if (numerator >= denominator)
                {
                    powerOfTen = BigInteger.One; // 10^0
                    return 0;
                }

                // When numerator < denominator, ratio < 1, and normalization requires multiplying by 10 once.
                powerOfTen = Ten; // 10^1, leading to an exponent of -1.
                return -1;
            }

            if (numLen > denLen)
            {
                // Case: number >= 1, so the scientific exponent is positive.
                // The adjusted candidate uses (diffBits - 1) because an L-bit number is at least 2^(L-1).
                var diffBits = numLen - denLen;
                var exponent = (int)Math.Floor((diffBits - 1) * Log10Of2) + 1;
                powerOfTen = PowerOfTen(exponent);

                // Adjustment: if our candidate powerOfTen is too high,
                // then the quotient doesn't reach that many digits.
                if (numerator >= denominator * powerOfTen)
                {
                    return exponent;
                }

                powerOfTen = PreviousPowerOfTen(powerOfTen, exponent);
                return exponent - 1;
            }
            else
            {
                // Case: number < 1, so the scientific exponent is negative.
                // We need the smallest k such that numerator * 10^k >= denominator.
                var diffBits = denLen - numLen;
                var exponent = (int)Math.Ceiling(diffBits * Log10Of2) - 1;
                powerOfTen = PowerOfTen(exponent);

                // First, check if one fewer factor of Ten would suffice.
                if (numerator * powerOfTen >= denominator)
                {
                    return -exponent;
                }

                // Select the next guess as 10^exponent
                powerOfTen = NextPowerOfTen(powerOfTen, exponent++);

                // Then, check if our candidate is too low.
                if (numerator * powerOfTen < denominator)
                {
                    powerOfTen = NextPowerOfTen(powerOfTen, exponent++);
                }

                // For numbers < 1, the scientific exponent is -k.
                return -exponent;
            }
        }

        private static BigInteger PreviousPowerOfTen(BigInteger powerOfTen, int exponent)
        {
            return exponent <= PowersOfTen.Length ? PowersOfTen[exponent - 1] : powerOfTen / Ten;
        }

        private static BigInteger NextPowerOfTen(BigInteger powerOfTen, int exponent)
        {
            return exponent + 1 < PowersOfTen.Length ? PowersOfTen[exponent + 1] : powerOfTen * Ten;
        }
    }

#else
    /// <summary>
    ///     Provides functionality to format the value of a QuantityValue object into a decimal string representation following
    ///     the
    ///     standard numeric formats, as implemented by the double type.
    /// </summary>
    private static class DecimalNotationFormatter
    {
        /// <summary>
        ///     <list type="bullet">
        ///         <item>
        ///             On .NET Framework and .NET Core up to .NET Core 2.0, the runtime selects the result with the greater least
        ///             significant digit (that is, using <see cref="MidpointRounding.AwayFromZero" />).
        ///         </item>
        ///         <item>
        ///             On .NET Core 2.1 and later, the runtime selects the result with an even least significant digit (that is,
        ///             using  <see cref="MidpointRounding.ToEven" />).
        ///         </item>
        ///     </list>
        /// </summary>
        private const MidpointRounding DefaultMidpointRoundingMode = MidpointRounding.AwayFromZero;

        /// <summary>
        ///     The default precision used for the general format specifier (G)
        /// </summary>
        private const int DefaultGeneralFormatPrecision =
#if NETCOREAPP2_0_OR_GREATER
            16;
#else
            15;
#endif

        /// <summary>
        ///     The default precision used for the exponential (scientific) format specifier (E)
        /// </summary>
        private const int DefaultScientificFormatPrecision = 6;

        private static readonly double Log10Of2 = Math.Log10(2);


        /// <summary>
        ///     Formats the value of the specified Fraction as a string using the specified format.
        /// </summary>
        /// <param name="format">A standard or custom numeric format string.</param>
        /// <param name="fraction">The Fraction object to be formatted.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        ///     The string representation of the value of the Fraction object as specified by the format and formatProvider
        ///     parameters.
        /// </returns>
        /// <remarks>
        ///     This method supports the following format strings:
        ///     <list type="bullet">
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-general-g-format-specifier">
        ///                     'G'
        ///                     or 'g'
        ///                 </see>
        ///                 : General format. Example: 400/3 formatted with 'G2' gives "1.3E+02".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-fixed-point-f-format-specifier">
        ///                     'F'
        ///                     or 'f'
        ///                 </see>
        ///                 : Fixed-point format. Example: 12345/10 formatted with 'F2' gives "1234.50".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-number-n-format-specifier">
        ///                     'N'
        ///                     or 'n'
        ///                 </see>
        ///                 : Standard Numeric format. Example: 1234567/1000 formatted with 'N2' gives "1,234.57".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-exponential-e-format-specifier">
        ///                     'E'
        ///                     or 'e'
        ///                 </see>
        ///                 : Scientific format. Example: 1234567/1000 formatted with 'E2' gives "1.23E+003".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-percent-p-format-specifier">
        ///                     'P'
        ///                     or 'p'
        ///                 </see>
        ///                 : Percent format. Example: 2/3 formatted with 'P2' gives "66.67 %".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://docs.microsoft.com/dotnet/standard/base-types/standard-numeric-format-strings#the-currency-c-format-specifier">
        ///                     'C'
        ///                     or 'c'
        ///                 </see>
        ///                 : Currency format. Example: 1234567/1000 formatted with 'C2' gives "$1,234.57".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#RFormatString">
        ///                     'R'
        ///                     or 'r'
        ///                 </see>
        ///                 : Round-trip format. Example: 1234567/1000 formatted with 'R' gives "1234.567".
        ///             </description>
        ///         </item>
        ///         <item>
        ///             <description>
        ///                 <see
        ///                     href="https://github.com/danm-de/Fractions?tab=readme-ov-file#significant-digits-after-radix-format">
        ///                     'S'
        ///                     or 's'
        ///                 </see>
        ///                 : Significant Digits After Radix format. Example: 400/3 formatted with 'S2' gives
        ///                 "133.33".
        ///             </description>
        ///         </item>
        ///     </list>
        ///     Note: The 'R' format and custom formats do not support precision specifiers and are handed over to the `double`
        ///     type for formatting, which may result in a loss of precision.
        ///     For more information about the formatter, see the
        ///     <see href="https://github.com/danm-de/Fractions?tab=readme-ov-file#decimalnotationformatter">
        ///         DecimalNotationFormatter
        ///         section
        ///     </see>
        ///     in the GitHub README.
        /// </remarks>
        public static string Format(QuantityValue fraction, string? format, IFormatProvider? formatProvider)
        {
            formatProvider ??= CultureInfo.CurrentCulture;
            var numberFormatInfo = (NumberFormatInfo)formatProvider.GetFormat(typeof(NumberFormatInfo))!;

            var numerator = fraction.Numerator;
            var denominator = fraction.Denominator;
            if (denominator.Sign == 0)
            {
                return numerator.Sign switch
                {
                    1 => numberFormatInfo.PositiveInfinitySymbol,
                    -1 => numberFormatInfo.NegativeInfinitySymbol,
                    _ => numberFormatInfo.NaNSymbol
                };
            }

            if (string.IsNullOrEmpty(format))
            {
                return FormatGeneral(numerator, denominator, "G", numberFormatInfo);
            }

            var formatCharacter = format![0];
            return formatCharacter switch
            {
                'G' or 'g' => FormatGeneral(numerator, denominator, format, numberFormatInfo),
                'F' or 'f' => FormatWithFixedPointFormat(numerator, denominator, format, numberFormatInfo),
                'N' or 'n' => FormatWithStandardNumericFormat(numerator, denominator, format, numberFormatInfo),
                'E' or 'e' => FormatWithScientificFormat(numerator, denominator, format, numberFormatInfo),
                'P' or 'p' => FormatWithPercentFormat(numerator, denominator, format, numberFormatInfo),
                'C' or 'c' => FormatWithCurrencyFormat(numerator, denominator, format, numberFormatInfo),
                'S' or 's' => FormatWithSignificantDigitsAfterRadix(numerator, denominator, format, numberFormatInfo),
                _ => // 'R', 'r' and the custom formats are handed over to the double (possible loss of precision) 
                    fraction.ToDouble().ToString(format, formatProvider)
            };
        }

        private static bool TryGetPrecisionDigits(string format, int defaultPrecision, out int maxNbDecimals)
        {
            if (format.Length == 1)
            {
                // The number of digits is not specified, use default precision.
                maxNbDecimals = defaultPrecision;
                return true;
            }

#if NET
            if (int.TryParse(format.AsSpan(1), out maxNbDecimals))
            {
                return true;
            }
#else
            if (int.TryParse(format.Substring(1), out maxNbDecimals))
            {
                return true;
            }
#endif

            // Seems to be some kind of custom format we do not understand, fallback to default precision.
            maxNbDecimals = defaultPrecision;
            return false;
        }

        /// <summary>
        ///     The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each "d"
        ///     indicates a digit (0-9). The string starts with a minus sign if the number is negative.
        /// </summary>
        /// <remarks>
        ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
        ///     current <see cref="NumberFormatInfo.NumberDecimalDigits" /> property supplies the numeric precision.
        /// </remarks>
        private static string FormatWithFixedPointFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.ToString(format, formatProvider)!;
            }

            if (!TryGetPrecisionDigits(format, formatProvider.NumberDecimalDigits, out var maxNbDecimalsAfterRadix))
            {
                // not a valid "F" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            if (maxNbDecimalsAfterRadix == 0)
            {
                return RoundToBigInteger(numerator, denominator, DefaultMidpointRoundingMode).ToString(format, formatProvider)!;
            }

            var (roundedNumerator, roundedDenominator) = Round(numerator, denominator, maxNbDecimalsAfterRadix, DefaultMidpointRoundingMode);
            bool isPositive;
            switch (roundedNumerator.Sign)
            {
                case 0:
                    return 0.ToString(format, formatProvider);
                case 1:
                    isPositive = true;
                    break;
                default:
                    isPositive = false;
                    roundedNumerator = -roundedNumerator;
                    break;
            }

            var sb = new StringBuilder(12 + maxNbDecimalsAfterRadix);
            if (!isPositive)
            {
                sb.Append(formatProvider.NegativeSign);
            }

            return AppendDecimals(sb, roundedNumerator, roundedDenominator, formatProvider, maxNbDecimalsAfterRadix).ToString();
        }

        /// <summary>
        ///     The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-"
        ///     indicates
        ///     a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "."
        ///     indicates a decimal point symbol.
        /// </summary>
        /// <remarks>
        ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
        ///     current <see cref="NumberFormatInfo.NumberDecimalDigits" /> property supplies the numeric precision.
        /// </remarks>
        private static string FormatWithStandardNumericFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.ToString(format, formatProvider)!;
            }

            if (!TryGetPrecisionDigits(format, formatProvider.NumberDecimalDigits, out var maxNbDecimals))
            {
                // not a valid "N" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            if (maxNbDecimals == 0)
            {
                var roundedValue = RoundToBigInteger(numerator, denominator, DefaultMidpointRoundingMode);
                return roundedValue.ToString(format, formatProvider)!;
            }

            var (roundedNumerator, roundedDenominator) = Round(numerator, denominator, maxNbDecimals, DefaultMidpointRoundingMode);
            bool isPositive;
            switch (roundedNumerator.Sign)
            {
                case 0:
                    return 0.ToString(format, formatProvider);
                case 1:
                    isPositive = true;
                    break;
                default:
                    isPositive = false;
                    roundedNumerator = -roundedNumerator;
                    break;
            }

            var sb = AppendDecimals(new StringBuilder(6 + maxNbDecimals), roundedNumerator, roundedDenominator, formatProvider, maxNbDecimals, "N0");
            return isPositive
                ? sb.ToString()
                : WithNegativeSign(sb, formatProvider.NegativeSign, formatProvider.NumberNegativePattern);

            static string WithNegativeSign(StringBuilder sb, string negativeSignSymbol, int pattern)
            {
                return pattern switch
                {
                    0 => // (n)
                        sb.Insert(0, '(').Append(')').ToString(),
                    1 => // -n
                        sb.Insert(0, negativeSignSymbol).ToString(),
                    2 => // - n
                        sb.Insert(0, negativeSignSymbol + ' ').ToString(),
                    3 => // n-
                        sb.Append(negativeSignSymbol).ToString(),
                    _ => // n -
                        sb.Append(' ').Append(negativeSignSymbol).ToString()
                };
            }
        }

        /// <summary>
        ///     The percent ("P") format specifier multiplies a number by 100 and converts it to a string that represents a
        ///     percentage.
        /// </summary>
        /// <remarks>
        ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted,
        ///     the default numeric precision supplied by the current <see cref="NumberFormatInfo.PercentDecimalDigits" /> property
        ///     is used.
        /// </remarks>
        private static string FormatWithPercentFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.ToString(format, formatProvider)!;
            }

            if (!TryGetPrecisionDigits(format, formatProvider.PercentDecimalDigits, out var maxNbDecimals))
            {
                // not a valid "P" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            StringBuilder sb;
            bool isPositive;
            if (maxNbDecimals == 0)
            {
                var roundedValue = RoundToBigInteger(numerator * 100, denominator, DefaultMidpointRoundingMode);
                switch (roundedValue.Sign)
                {
                    case 0:
                        return 0.ToString(format, formatProvider);
                    case 1:
                        isPositive = true;
                        break;
                    default:
                        isPositive = false;
                        roundedValue = -roundedValue;
                        break;
                }

                var percentFormatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = formatProvider.PercentDecimalSeparator,
                    NumberGroupSeparator = formatProvider.PercentGroupSeparator,
                    NumberGroupSizes = formatProvider.PercentGroupSizes,
                    NativeDigits = formatProvider.NativeDigits,
                    DigitSubstitution = formatProvider.DigitSubstitution
                };
                sb = new StringBuilder(roundedValue.ToString("N0", percentFormatInfo));
            }
            else
            {
                var (roundedNumerator, roundedDenominator) = Round(numerator * 100, denominator, maxNbDecimals, DefaultMidpointRoundingMode);
                switch (roundedNumerator.Sign)
                {
                    case 0:
                        return 0.ToString(format, formatProvider);
                    case 1:
                        isPositive = true;
                        break;
                    default:
                        isPositive = false;
                        roundedNumerator = -roundedNumerator;
                        break;
                }

                var percentFormatInfo = new NumberFormatInfo
                {
                    NumberDecimalSeparator = formatProvider.PercentDecimalSeparator,
                    NumberGroupSeparator = formatProvider.PercentGroupSeparator,
                    NumberGroupSizes = formatProvider.PercentGroupSizes,
                    NativeDigits = formatProvider.NativeDigits,
                    DigitSubstitution = formatProvider.DigitSubstitution
                };
                sb = AppendDecimals(new StringBuilder(8 + maxNbDecimals), roundedNumerator, roundedDenominator, percentFormatInfo, maxNbDecimals, "N0");
            }

            return isPositive
                ? WithPositiveSign(sb, formatProvider.PercentSymbol, formatProvider.PercentPositivePattern)
                : WithNegativeSign(sb, formatProvider.PercentSymbol, formatProvider.NegativeSign, formatProvider.PercentNegativePattern);

            static string WithPositiveSign(StringBuilder sb, string percentSymbol, int pattern)
            {
                return pattern switch
                {
                    0 => // n %
                        sb.Append(' ').Append(percentSymbol).ToString(),
                    1 => // n%
                        sb.Append(percentSymbol).ToString(),
                    2 => // %n
                        sb.Insert(0, percentSymbol).ToString(),
                    _ => // % n
                        sb.Insert(0, percentSymbol + ' ').ToString()
                };
            }

            static string WithNegativeSign(StringBuilder sb, string percentSymbol, string negativeSignSymbol, int pattern)
            {
                return pattern switch
                {
                    0 => // -n %
                        sb.Insert(0, negativeSignSymbol).Append(' ').Append(percentSymbol).ToString(),
                    1 => // -n%
                        sb.Insert(0, negativeSignSymbol).Append(percentSymbol).ToString(),
                    2 => // -%n
                        sb.Insert(0, negativeSignSymbol + percentSymbol).ToString(),
                    3 => // %-n
                        sb.Insert(0, percentSymbol + negativeSignSymbol).ToString(),
                    4 => // %n-
                        sb.Insert(0, percentSymbol).Append(negativeSignSymbol).ToString(),
                    5 => // n-%
                        sb.Append(negativeSignSymbol).Append(percentSymbol).ToString(),
                    6 => // n%-
                        sb.Append(percentSymbol).Append(negativeSignSymbol).ToString(),
                    7 => // -% n
                        sb.Insert(0, negativeSignSymbol + percentSymbol + ' ').ToString(),
                    8 => // n %-
                        sb.Append(' ').Append(percentSymbol).Append(negativeSignSymbol).ToString(),
                    9 => // % n-
                        sb.Insert(0, percentSymbol + ' ').Append(negativeSignSymbol).ToString(),
                    10 => // % -n
                        sb.Insert(0, percentSymbol + ' ').Insert(2, negativeSignSymbol).ToString(),
                    _ => // n- %
                        sb.Append(negativeSignSymbol).Append(' ').Append(percentSymbol).ToString()
                };
            }
        }


        /// <summary>
        ///     The "C" (or currency) format specifier converts a number to a string that represents a currency amount. The
        ///     precision specifier indicates the desired number of decimal places in the result string. If the precision specifier
        ///     is omitted, the default precision is defined by the <see cref="NumberFormatInfo.CurrencyDecimalDigits" /> property.
        /// </summary>
        /// <remarks>
        ///     If the value to be formatted has more than the specified or default number of decimal places, the fractional
        ///     value is rounded in the result string. If the value to the right of the number of specified decimal places is 5 or
        ///     greater, the last digit in the result string is rounded away from zero.
        /// </remarks>
        private static string FormatWithCurrencyFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.ToString(format, formatProvider)!;
            }

            if (!TryGetPrecisionDigits(format, formatProvider.CurrencyDecimalDigits, out var maxNbDecimals))
            {
                // not a valid "C" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            if (maxNbDecimals == 0)
            {
                var roundedValue = RoundToBigInteger(numerator, denominator, DefaultMidpointRoundingMode);
                return roundedValue.ToString(format, formatProvider)!;
            }

            var (roundedNumerator, roundedDenominator) = Round(numerator, denominator, maxNbDecimals, DefaultMidpointRoundingMode);

            bool isPositive;
            switch (roundedNumerator.Sign)
            {
                case 0:
                    return 0.ToString(format, formatProvider);
                case 1:
                    isPositive = true;
                    break;
                default:
                    isPositive = false;
                    roundedNumerator = -roundedNumerator;
                    break;
            }

            var currencyFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = formatProvider.CurrencyDecimalSeparator,
                NumberGroupSeparator = formatProvider.CurrencyGroupSeparator,
                NumberGroupSizes = formatProvider.CurrencyGroupSizes,
                NativeDigits = formatProvider.NativeDigits,
                DigitSubstitution = formatProvider.DigitSubstitution
            };

            var sb = AppendDecimals(new StringBuilder(8 + maxNbDecimals), roundedNumerator, roundedDenominator, currencyFormatInfo, maxNbDecimals, "N0");
            return isPositive
                ? WithPositiveSign(sb, formatProvider.CurrencySymbol, formatProvider.CurrencyPositivePattern)
                : WithNegativeSign(sb, formatProvider.CurrencySymbol, formatProvider.NegativeSign,
                    formatProvider.CurrencyNegativePattern);

            static string WithPositiveSign(StringBuilder sb, string currencySymbol, int pattern)
            {
                return pattern switch
                {
                    0 => // $n
                        sb.Insert(0, currencySymbol).ToString(),
                    1 => // n$
                        sb.Append(currencySymbol).ToString(),
                    2 => // $ n
                        sb.Insert(0, currencySymbol + ' ').ToString(),
                    _ => // n $
                        sb.Append(' ').Append(currencySymbol).ToString()
                };
            }

            static string WithNegativeSign(StringBuilder sb, string currencySymbol, string negativeSignSymbol,
                int pattern)
            {
                return pattern switch
                {
                    0 => // ($n)
                        sb.Insert(0, '(').Insert(1, currencySymbol).Append(')').ToString(),
                    1 => // -$n
                        sb.Insert(0, negativeSignSymbol + currencySymbol).ToString(),
                    2 => // $-n
                        sb.Insert(0, currencySymbol + negativeSignSymbol).ToString(),
                    3 => // $n-
                        sb.Insert(0, currencySymbol).Append(negativeSignSymbol).ToString(),
                    4 => // (n$)
                        sb.Insert(0, '(').Append(currencySymbol).Append(')').ToString(),
                    5 => // -n$
                        sb.Insert(0, negativeSignSymbol).Append(currencySymbol).ToString(),
                    6 => // n-$
                        sb.Append(negativeSignSymbol).Append(currencySymbol).ToString(),
                    7 => // n$-
                        sb.Append(currencySymbol).Append(negativeSignSymbol).ToString(),
                    8 => // -n $
                        sb.Insert(0, negativeSignSymbol).Append(' ').Append(currencySymbol).ToString(),
                    9 => // -$ n
                        sb.Insert(0, negativeSignSymbol + currencySymbol + ' ').ToString(),
                    10 => // n $-
                        sb.Append(' ').Append(currencySymbol).Append(negativeSignSymbol).ToString(),
                    11 => // $ n-
                        sb.Insert(0, currencySymbol + ' ').Append(negativeSignSymbol).ToString(),
                    12 => // $ -n
                        sb.Insert(0, currencySymbol + ' ' + negativeSignSymbol).ToString(),
                    13 => // n- $
                        sb.Append(negativeSignSymbol).Append(' ').Append(currencySymbol).ToString(),
                    14 => // ($ n)
                        sb.Insert(0, '(').Insert(1, currencySymbol + ' ').Append(')').ToString(),
#if NETSTANDARD
                    _ => // (n $)
                        sb.Insert(0, '(').Append(' ').Append(currencySymbol).Append(')').ToString(),
#else
                    15 => // (n $)
                        sb.Insert(0, '(').Append(' ').Append(currencySymbol).Append(')').ToString(),
                    _ => // $- n
                        sb.Insert(0, currencySymbol + negativeSignSymbol + ' ').ToString(),
#endif
                };
            }
        }

        /// <summary>
        ///     Exponential format specifier (E)
        ///     The exponential ("E") format specifier converts a number to a string of the form "-d.ddd…E+ddd" or "-d.ddd…e+ddd",
        ///     where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative. Exactly one
        ///     digit always precedes the decimal point.
        /// </summary>
        /// <remarks>
        ///     The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier
        ///     is omitted, a default of six digits after the decimal point is used.
        ///     The case of the format specifier indicates whether to prefix the exponent with an "E" or an "e". The exponent
        ///     always consists of a plus or minus sign and a minimum of three digits. The exponent is padded with zeros to meet
        ///     this minimum, if required.
        /// </remarks>
        private static string FormatWithScientificFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (denominator.IsOne)
            {
                return numerator.ToString(format, formatProvider)!;
            }

            if (!TryGetPrecisionDigits(format, DefaultScientificFormatPrecision, out var maxNbDecimals))
            {
                // not a valid "E" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            var sb = new StringBuilder(DefaultScientificFormatPrecision + maxNbDecimals);

            if (numerator.Sign < 0)
            {
                sb.Append(formatProvider.NegativeSign);
                numerator = -numerator;
            }

            var exponent = GetExponentPower(numerator, denominator, out var exponentTerm);
            var mantissa = exponent switch
            {
                0 => Round(numerator, denominator, maxNbDecimals, DefaultMidpointRoundingMode),
                > 0 => Round(numerator, denominator * exponentTerm, maxNbDecimals, DefaultMidpointRoundingMode),
                _ => Round(numerator * exponentTerm, denominator, maxNbDecimals, DefaultMidpointRoundingMode)
            };

            if (mantissa.Denominator.IsOne)
            {
                sb.Append(mantissa.Numerator.ToString($"F{maxNbDecimals}", formatProvider));
            }
            else
            {
                AppendDecimals(sb, mantissa.Numerator, mantissa.Denominator, formatProvider, maxNbDecimals);
            }

            return WithAppendedExponent(sb, exponent, formatProvider, format[0]);

            static string WithAppendedExponent(StringBuilder sb, int exponent, NumberFormatInfo numberFormat,
                char exponentSymbol)
            {
                return exponent >= 0
                    ? sb.Append(exponentSymbol).Append(numberFormat.PositiveSign)
                        .Append(exponent.ToString("D3", numberFormat)).ToString()
                    : sb.Append(exponentSymbol).Append(exponent.ToString("D3", numberFormat)).ToString();
            }
        }

        /// <summary>
        ///     The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific
        ///     notation, depending on the type of the number and whether a precision specifier is present.
        /// </summary>
        /// <remarks>
        ///     The precision specifier
        ///     defines the maximum number of significant digits that can appear in the result string. If the precision specifier
        ///     is omitted or zero, the type of the number determines the default precision.
        /// </remarks>
        private static string FormatGeneral(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(format, formatProvider);
            }

            if (!TryGetPrecisionDigits(format, DefaultGeneralFormatPrecision, out var maxNbDecimals))
            {
                // not a valid "G" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            if (maxNbDecimals == 0)
            {
                maxNbDecimals = DefaultGeneralFormatPrecision;
            }

            var sb = new StringBuilder(3 + maxNbDecimals);

            if (numerator.Sign < 0)
            {
                sb.Append(formatProvider.NegativeSign);
                numerator = -numerator;
            }

            var exponent = GetExponentPower(numerator, denominator, out var exponentTerm);

            if (exponent == maxNbDecimals - 1)
            {
                // integral result: both 123400 (1.234e5) and 123400.01 (1.234001e+005) result in "123400" with the "G6" format
                return sb.Append(RoundToBigInteger(numerator, denominator, DefaultMidpointRoundingMode)).ToString();
            }

            if (exponent > maxNbDecimals - 1)
            {
                // we are required to shorten down a number of the form 123400 (1.234E+05)
                if (maxNbDecimals == 1)
                {
                    sb.Append(RoundToBigInteger(numerator, denominator * exponentTerm, DefaultMidpointRoundingMode));
                }
                else
                {
                    var mantissa = Round(numerator, denominator * exponentTerm, maxNbDecimals - 1, DefaultMidpointRoundingMode);
                    AppendSignificantDecimals(sb, mantissa, formatProvider, maxNbDecimals - 1);
                }

                return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 'g' ? 'e' : 'E').ToString();
            }

            if (exponent <= -5)
            {
                // the largest value would have the form: 1.23e-5 (0.0000123)
                var mantissa = Round(numerator * exponentTerm, denominator, maxNbDecimals - 1, DefaultMidpointRoundingMode);
                AppendSignificantDecimals(sb, mantissa, formatProvider, maxNbDecimals - 1);
                return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 'g' ? 'e' : 'E')
                    .ToString();
            }

            // the smallest value would have the form: 1.23e-4 (0.000123)
            var roundedDecimal = Round(numerator, denominator, maxNbDecimals - exponent - 1, DefaultMidpointRoundingMode);
            return AppendSignificantDecimals(sb, roundedDecimal, formatProvider, maxNbDecimals - exponent - 1)
                .ToString();
        }

        private static string FormatWithCustomFormat(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            return new QuantityValue(numerator, denominator).ToDouble().ToString(format, formatProvider);
        }

        /// <summary>
        ///     Formats a fraction as a string with a specified number of significant digits after the radix point.
        /// </summary>
        /// <param name="numerator">The numerator of the fraction.</param>
        /// <param name="denominator">The denominator of the fraction.</param>
        /// <param name="format">
        ///     The format string to use, which specifies the maximum number of digits after the radix point.
        /// </param>
        /// <param name="formatProvider">An object that provides culture-specific formatting information.</param>
        /// <returns>
        ///     A string representation of the fraction, formatted with the specified number of significant digits after the
        ///     radix point.
        /// </returns>
        /// <remarks>
        ///     The method determines the formatting style based on the magnitude of the fraction:
        ///     <list type="bullet">
        ///         <item>
        ///             For values greater than 1e5, the fraction is formatted in scientific notation (e.g., 1.23e6 for 1230000).
        ///         </item>
        ///         <item>
        ///             For values less than or equal to 1e-4, the fraction is formatted in scientific notation (e.g., 1.23e-4 for
        ///             0.000123).
        ///         </item>
        ///         <item>
        ///             For values between 1e-3 and 1e5, the fraction is formatted as a decimal number.
        ///         </item>
        ///     </list>
        /// </remarks>
        private static string FormatWithSignificantDigitsAfterRadix(BigInteger numerator, BigInteger denominator, string format, NumberFormatInfo formatProvider)
        {
            if (numerator.IsZero)
            {
                return 0.ToString(formatProvider);
            }

            const string quotientFormat = "N0";

            if (!TryGetPrecisionDigits(format, 2, out var maxDigitsAfterRadix))
            {
                // not a valid "S" format: assuming a custom format
                return FormatWithCustomFormat(numerator, denominator, format, formatProvider);
            }

            var sb = new StringBuilder(3 + maxDigitsAfterRadix);

            if (numerator.Sign < 0)
            {
                sb.Append(formatProvider.NegativeSign);
                numerator = -numerator;
            }

            var exponent = GetExponentPower(numerator, denominator, out var exponentTerm);
            QuantityValue mantissa;
            switch (exponent)
            {
                case > 5:
                    // the smallest value would have the form: 1.23e6 (1230000)
                    mantissa = Round(numerator, denominator * exponentTerm, maxDigitsAfterRadix, DefaultMidpointRoundingMode);
                    AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat);
                    return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 's' ? 'e' : 'E')
                        .ToString();
                case <= -4:
                    // the largest value would have the form: 1.23e-4 (0.000123)
                    mantissa = Round(numerator * exponentTerm, denominator, maxDigitsAfterRadix, DefaultMidpointRoundingMode);
                    AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat);
                    return AppendExponentWithSignificantDigits(sb, exponent, formatProvider, format[0] is 's' ? 'e' : 'E')
                        .ToString();
                case < 0:
                    // the smallest value would have the form: 1.23e-3 (0.00123)
                    var leadingZeroes = -exponent;
                    maxDigitsAfterRadix += leadingZeroes - 1;
                    mantissa = Round(numerator, denominator, maxDigitsAfterRadix, DefaultMidpointRoundingMode);
                    return AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat)
                        .ToString();
                default:
                    // the largest value would have the form: 1.23e5 (123000)
                    mantissa = Round(numerator, denominator, maxDigitsAfterRadix, DefaultMidpointRoundingMode);
                    return AppendSignificantDecimals(sb, mantissa, formatProvider, maxDigitsAfterRadix, quotientFormat)
                        .ToString();
            }
        }

        /// <summary>
        ///     Appends the decimal representation of a fraction to the specified <see cref="StringBuilder" />.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder" /> to which the decimal representation will be appended.</param>
        /// <param name="numerator">The numerator of the fraction.</param>
        /// <param name="denominator">
        ///     The denominator of the fraction: should be a power of 10, equal to the specified
        ///     <paramref name="nbDecimals" />
        /// </param>
        /// <param name="formatProvider">The <see cref="NumberFormatInfo" /> that provides culture-specific formatting information.</param>
        /// <param name="nbDecimals">The maximum number of decimal places to include in the representation.</param>
        /// <param name="quotientFormat">
        ///     An optional format string for formatting the quotient part of the fraction.
        ///     Defaults to <c>"F0"</c>.
        /// </param>
        /// <returns>The <see cref="StringBuilder" /> with the appended decimal representation.</returns>
        /// <remarks>
        ///     This method calculates the decimal representation of the given fraction by dividing the numerator
        ///     by the denominator and appending the result to the <paramref name="sb" />, padding with "0" to ensure the specified
        ///     number of decimal places is respected.
        ///     <para>
        ///         The fraction must represent a value with a denominator that is a power of 10, equal to the specified
        ///         <paramref name="nbDecimals" />.
        ///     </para>
        /// </remarks>
        private static StringBuilder AppendDecimals(StringBuilder sb, BigInteger numerator, BigInteger denominator, NumberFormatInfo formatProvider,
            int nbDecimals, string quotientFormat = "F0")
        {
            if (denominator <= long.MaxValue / 10 && numerator <= long.MaxValue && numerator >= long.MinValue)
            {
                return AppendDecimals(sb, (long)numerator, (long)denominator, formatProvider, nbDecimals, quotientFormat);
            }
            
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);

            sb.Append(quotient.ToString(quotientFormat, formatProvider)).Append(formatProvider.NumberDecimalSeparator);

            var decimalsAdded = 0;
            while (!remainder.IsZero && decimalsAdded++ < nbDecimals - 1)
            {
                denominator = PreviousPowerOfTen(denominator, nbDecimals - decimalsAdded + 1);
                var digit = (char)('0' + (int)BigInteger.DivRem(remainder, denominator, out remainder));
                sb.Append(digit);
            }

            if (remainder.IsZero)
            {
                sb.Append('0', nbDecimals - decimalsAdded);
            }
            else
            {
                sb.Append((char)('0' + (int)remainder));
            }

            return sb;
        }
        
        private static StringBuilder AppendDecimals(StringBuilder sb, long numerator, long denominator, NumberFormatInfo formatProvider,
            int nbDecimals, string quotientFormat = "F0")
        {
            var quotient = numerator / denominator;
            var remainder = numerator % denominator;

            sb.Append(quotient.ToString(quotientFormat, formatProvider)).Append(formatProvider.NumberDecimalSeparator);

            var decimalsAdded = 0;
            while (remainder != 0 && decimalsAdded++ < nbDecimals)
            {
                sb.Append((char)('0' + remainder * 10 / denominator));
                remainder = remainder * 10 % denominator;
            }

            if (remainder == 0)
            {
                sb.Append('0', nbDecimals - decimalsAdded);
            }

            return sb;
        }

        /// <summary>
        ///     Appends the significant decimal digits of a fractional number to the specified <see cref="StringBuilder" />.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder" /> to which the significant decimal digits will be appended.</param>
        /// <param name="decimalFraction">
        ///     The fractional number whose significant decimal digits are to be appended.
        ///     The denominator of this fraction must be a power of 10, corresponding to the <paramref name="maxNbDecimals" />.
        /// </param>
        /// <param name="formatProvider">The <see cref="NumberFormatInfo" /> that provides culture-specific formatting information.</param>
        /// <param name="maxNbDecimals">The maximum number of decimal digits to append.</param>
        /// <param name="quotientFormat">
        ///     An optional format string that specifies the format of the quotient. Defaults to "F0".
        /// </param>
        /// <returns>
        ///     The <see cref="StringBuilder" /> instance with the appended significant decimal digits.
        /// </returns>
        /// <remarks>
        ///     This method calculates and appends the significant decimal digits of the given fractional number.
        ///     It ensures that the number of appended decimal digits does not exceed the specified maximum.
        ///     <para>
        ///         The <paramref name="decimalFraction" /> must represent a value with a denominator that is a power of 10,
        ///         equal to the specified <paramref name="maxNbDecimals" />.
        ///     </para>
        /// </remarks>
        private static StringBuilder AppendSignificantDecimals(StringBuilder sb, QuantityValue decimalFraction, NumberFormatInfo formatProvider,
            int maxNbDecimals, string quotientFormat = "F0")
        {
            var numerator = decimalFraction.Numerator;
            var denominator = decimalFraction.Denominator;
            if (denominator <= long.MaxValue / 10 && numerator <= long.MaxValue && numerator >= long.MinValue)
            {
                return AppendSignificantDecimals(sb, (long)numerator, (long)denominator, formatProvider, maxNbDecimals, quotientFormat);
            }
            
            var quotient = BigInteger.DivRem(numerator, denominator, out var remainder);

            sb.Append(quotient.ToString(quotientFormat, formatProvider));

            if (remainder.IsZero)
            {
                return sb;
            }

            sb.Append(formatProvider.NumberDecimalSeparator);

            var decimalsRemaining = maxNbDecimals;
            do
            {
                denominator = PreviousPowerOfTen(denominator, decimalsRemaining);
                var digit = (char)('0' + (int)BigInteger.DivRem(remainder, denominator, out remainder));
                sb.Append(digit);
                decimalsRemaining--;
            } while (!remainder.IsZero && decimalsRemaining > 0);

            return sb;
        }

        private static StringBuilder AppendSignificantDecimals(StringBuilder sb, long numerator, long denominator, NumberFormatInfo formatProvider,
            int maxNbDecimals, string quotientFormat = "F0")
        {
            var quotient = numerator / denominator;
            var remainder = numerator % denominator;

            sb.Append(quotient.ToString(quotientFormat, formatProvider));

            if (remainder == 0)
            {
                return sb;
            }

            sb.Append(formatProvider.NumberDecimalSeparator);
            
            var decimalsRemaining = maxNbDecimals;
            do
            {
                sb.Append((char)('0' + remainder * 10 / denominator));
                remainder = remainder * 10 % denominator;
                decimalsRemaining--;
            } while (remainder != 0 && decimalsRemaining > 0);

            return sb;
        }

        private static StringBuilder AppendExponentWithSignificantDigits(StringBuilder sb, int exponent, NumberFormatInfo formatProvider, char exponentSymbol)
        {
            return exponent switch
            {
                <= -1000 => sb.Append(exponentSymbol).Append(exponent.ToString(formatProvider)),
                <= 0 => sb.Append(exponentSymbol).Append(exponent.ToString("D2", formatProvider)),
                < 100 => sb.Append(exponentSymbol).Append(formatProvider.PositiveSign)
                    .Append(exponent.ToString("D2", formatProvider)),
                < 1000 => sb.Append(exponentSymbol).Append(formatProvider.PositiveSign)
                    .Append(exponent.ToString("D3", formatProvider)),
                _ => sb.Append(exponentSymbol).Append(formatProvider.PositiveSign).Append(exponent.ToString(formatProvider))
            };
        }

        /// <summary>
        ///     Calculates the exponent power for the given fraction terms.
        /// </summary>
        /// <param name="numerator">The numerator of the fraction.</param>
        /// <param name="denominator">The denominator of the fraction.</param>
        /// <param name="powerOfTen">
        ///     Output parameter that returns the power of ten that corresponds to the calculated exponent
        ///     power.
        /// </param>
        /// <returns>The exponent power for the given fraction.</returns>
        /// <remarks>It is expected that both terms have the same sign (i.e. the Fraction is positive)</remarks>
        private static int GetExponentPower(BigInteger numerator, BigInteger denominator, out BigInteger powerOfTen)
        {
            // Preconditions: numerator > 0, denominator > 0.
#if NET
            var numLen = numerator.GetBitLength();
            var denLen = denominator.GetBitLength();
#else
            var numLen = GetBitLength(numerator);
            var denLen = GetBitLength(denominator);
#endif
            // If the two numbers have equal bit-length, then their ratio is in [1,2) if numerator >= denominator,
            // or in (0,1) if numerator < denominator. In these cases the scientific exponent is fixed.
            if (numLen == denLen)
            {
                if (numerator >= denominator)
                {
                    powerOfTen = BigInteger.One; // 10^0
                    return 0;
                }

                // When numerator < denominator, ratio < 1, and normalization requires multiplying by 10 once.
                powerOfTen = Ten; // 10^1, leading to an exponent of -1.
                return -1;
            }

            if (numLen > denLen)
            {
                // Case: number >= 1, so the scientific exponent is positive.
                // The adjusted candidate uses (diffBits - 1) because an L-bit number is at least 2^(L-1).
                var diffBits = numLen - denLen;
                var exponent = (int)Math.Floor((diffBits - 1) * Log10Of2) + 1;
                powerOfTen = PowerOfTen(exponent);

                // Adjustment: if our candidate powerOfTen is too high,
                // then the quotient doesn't reach that many digits.
                if (numerator >= denominator * powerOfTen)
                {
                    return exponent;
                }

                powerOfTen = PreviousPowerOfTen(powerOfTen, exponent);
                return exponent - 1;
            }
            else
            {
                // Case: number < 1, so the scientific exponent is negative.
                // We need the smallest k such that numerator * 10^k >= denominator.
                var diffBits = denLen - numLen;
                var exponent = (int)Math.Ceiling(diffBits * Log10Of2) - 1;
                powerOfTen = PowerOfTen(exponent);

                // First, check if one fewer factor of Ten would suffice.
                if (numerator * powerOfTen >= denominator)
                {
                    return -exponent;
                }

                // Select the next guess as 10^exponent
                powerOfTen = NextPowerOfTen(powerOfTen, exponent++);

                // Then, check if our candidate is too low.
                if (numerator * powerOfTen < denominator)
                {
                    powerOfTen = NextPowerOfTen(powerOfTen, exponent++);
                }

                // For numbers < 1, the scientific exponent is -k.
                return -exponent;
            }

#if NETSTANDARD
            static long GetBitLength(BigInteger value)
            {
                // Using BigInteger.Log(value, 2) avoids creating a byte array.
                // Note: For value > 0 this returns a double that we floor and add 1.
                return (long)Math.Floor(BigInteger.Log(value, 2)) + 1;
            }
#endif
        }

        private static BigInteger PreviousPowerOfTen(BigInteger powerOfTen, int exponent)
        {
            return exponent <= PowersOfTen.Length ? PowersOfTen[exponent - 1] : powerOfTen / Ten;
        }

        private static BigInteger NextPowerOfTen(BigInteger powerOfTen, int exponent)
        {
            return exponent + 1 < PowersOfTen.Length ? PowersOfTen[exponent + 1] : powerOfTen * Ten;
        }
    }


#endif
}
