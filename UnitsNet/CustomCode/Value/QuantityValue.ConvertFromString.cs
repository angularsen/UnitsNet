// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace UnitsNet;

public partial struct QuantityValue
{
    private const NumberStyles DefaultNumberStyles = NumberStyles.Integer | NumberStyles.Number | NumberStyles.Float;

    /// <summary>
    ///     Parses a string representation of a quantity value into a QuantityValue object.
    /// </summary>
    /// <param name="s">The string representation of the quantity value.</param>
    /// <param name="provider">
    ///     A NumberStyles value that indicates the style elements that can be present in
    ///     valueString.
    /// </param>
    /// <returns>A QuantityValue object that represents the parsed string.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown when the provided string argument is null.</exception>
    /// <exception cref="System.FormatException">
    ///     Thrown when the format of the provided string argument is invalid and cannot
    ///     be successfully parsed into a QuantityValue.
    /// </exception>
    public static QuantityValue Parse(string s, IFormatProvider? provider)
    {
        return Parse(s, DefaultNumberStyles, provider);
    }

    /// <summary>
    ///     Parses a string representation of a quantity value into a QuantityValue object.
    /// </summary>
    /// <param name="s">The string representation of the quantity value.</param>
    /// <param name="style">
    ///     A NumberStyles value that indicates the style elements that can be present in
    ///     valueString.
    /// </param>
    /// <param name="provider">
    ///     An IFormatProvider that supplies culture-specific formatting information about
    ///     valueString.
    /// </param>
    /// <returns>A QuantityValue object that represents the parsed string.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown when the provided string argument is null.</exception>
    /// <exception cref="System.FormatException">
    ///     Thrown when the format of the provided string argument is invalid and cannot
    ///     be successfully parsed into a QuantityValue.
    /// </exception>
    public static QuantityValue Parse(string s, NumberStyles style, IFormatProvider? provider)
    {
        if (TryParse(s, style, provider, out var valueParsed))
        {
            return valueParsed;
        }

        throw new FormatException(
            $"The format of the provided string argument '{s}' is invalid and cannot be successfully parsed into a QuantityValue.");
    }

    /// <summary>
    ///     Tries to convert the string representation of a quantity value to its QuantityValue equivalent, and returns a value
    ///     that indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="s">A string containing a quantity value to convert.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information about s.</param>
    /// <param name="result">
    ///     When this method returns, contains the QuantityValue equivalent to the quantity value contained in
    ///     s, if the conversion succeeded, or zero if the conversion failed. The conversion fails if the s parameter is null
    ///     or is not of the correct format. This parameter is passed uninitialized; any value originally supplied in result
    ///     will be overwritten.
    /// </param>
    /// <returns>true if s was converted successfully; otherwise, false.</returns>
    public static bool TryParse(string? s, IFormatProvider? provider, out QuantityValue result)
    {
        return TryParse(s, DefaultNumberStyles, provider, out result);
    }

#if NET
    /// <inheritdoc />
    public static QuantityValue Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
    {
        return Parse(s, DefaultNumberStyles, provider);
    }

    /// <inheritdoc />
    public static QuantityValue Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
    {
        if (TryParse(s, style, provider, out var quantityValue))
        {
            return quantityValue;
        }

        throw new FormatException(
            $"The format of the provided string argument '{s}' is invalid and cannot be successfully parsed into a QuantityValue.");
    }

    /// <inheritdoc />
    public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out QuantityValue result)
    {
        return TryParse(s, DefaultNumberStyles, provider, out result);
    }
    
    /// <inheritdoc />
    public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, out QuantityValue result)
    {
        return TryParse(s.AsSpan(), style, provider, out result);
    }

    /// <summary>
    ///     Attempts to parse a ReadOnlySpan of characters into a QuantityValue.
    /// </summary>
    /// <param name="value">
    ///     The input string to parse. The numerator and denominator must be separated by a '/' (slash) character.
    ///     For example, "3/4". If the string is not in this format, the parsing behavior is influenced by the
    ///     <paramref name="numberStyles" /> and <paramref name="formatProvider" /> parameters.
    /// </param>
    /// <param name="numberStyles">
    ///     A bitwise combination of number styles permitted in the input string. This is relevant when the string
    ///     is not in the numerator/denominator format. For instance, <see cref="NumberStyles.Float" /> allows decimal
    ///     points and scientific notation.
    /// </param>
    /// <param name="formatProvider">
    ///     An <see cref="IFormatProvider" /> that supplies culture-specific information used to parse the input string.
    ///     This is relevant when the string is not in the numerator/denominator format. For example,
    ///     <c>CultureInfo.GetCultureInfo("en-US")</c> for US English culture.
    /// </param>
    /// <param name="quantityValue">
    ///     When this method returns, contains the parsed QuantityValue if the operation was successful; otherwise,
    ///     it contains the default value of <see cref="QuantityValue" />.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the input string is well-formed and could be parsed into a QuantityValue; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    ///     The <paramref name="numberStyles" /> parameter allows you to specify which number styles are allowed in the input
    ///     string while the <paramref name="formatProvider" /> parameter provides culture-specific formatting information.
    ///     <para>
    ///         Here are some examples of how to use the
    ///         <see cref="TryParse(ReadOnlySpan{char}, NumberStyles, IFormatProvider, out QuantityValue)" /> method:
    ///         <example>
    ///             <code>
    /// QuantityValue.TryParse("3/4", NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), true, out var QuantityValue);
    ///         </code>
    ///             This example parses the string "3/4" into a <see cref="QuantityValue" /> object with a numerator of 3 and a
    ///             denominator of 4.
    ///             <code>
    /// QuantityValue.TryParse("1.25", NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), true, out var QuantityValue);
    ///         </code>
    ///             This example parses the string "1.25" into a <see cref="QuantityValue" /> object with a numerator of 5 and
    ///             a
    ///             denominator of 4.
    ///             <code>
    /// QuantityValue.TryParse("1,234.56", NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), false, out var QuantityValue);
    ///         </code>
    ///             This example parses the string "1,234.56" into a <see cref="QuantityValue" /> object with a numerator of
    ///             12345
    ///             and a
    ///             denominator of 100.
    ///             <code>
    /// QuantityValue.TryParse("1.23e-2", NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), false, out var QuantityValue);
    ///         </code>
    ///             This example parses the string "1.23e-2" into a <see cref="QuantityValue" /> object with a numerator of 123
    ///             and
    ///             a
    ///             denominator of 10000.
    ///         </example>
    ///     </para>
    /// </remarks>
    public static bool TryParse(ReadOnlySpan<char> value, NumberStyles numberStyles, IFormatProvider? formatProvider, out QuantityValue quantityValue)
    {
        if (value.IsEmpty)
        {
            return CannotParse(out quantityValue);
        }
        
        var numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);

        if (value.Length == 1)
        {
            if (!byte.TryParse(value, numberStyles, formatProvider, out var singleDigit))
            {
                if (value.SequenceEqual(numberFormatInfo.PositiveInfinitySymbol))
                {
                    quantityValue = PositiveInfinity;
                    return true;
                }

                if (value.SequenceEqual(numberFormatInfo.NegativeInfinitySymbol))
                {
                    quantityValue = NegativeInfinity;
                    return true;
                }

                if (value.SequenceEqual(numberFormatInfo.NaNSymbol))
                {
                    quantityValue = NaN;
                    return true;
                }

                return CannotParse(out quantityValue);
            }

            quantityValue = singleDigit;
            return true;
        }

        // TODO see if we want to support this
#if FRACTION_PARSING_ENABLED
        var ranges = new Span<Range>(new Range[2]);
        var nbRangesFilled = value.Split(ranges, '/');

        if (nbRangesFilled == 2)
        {
            var numeratorValue = value[ranges[0]];
            var denominatorValue = value[ranges[1]];

            var withoutDecimalPoint = numberStyles & ~NumberStyles.AllowDecimalPoint;
            if (!BigInteger.TryParse(
                    numeratorValue,
                    withoutDecimalPoint,
                    formatProvider,
                    out var numerator)
                || !BigInteger.TryParse(
                    denominatorValue,
                    withoutDecimalPoint,
                    formatProvider,
                    out var denominator))
            {
                return CannotParse(out quantityValue);
            }

            quantityValue = FromTerms(numerator, denominator);
            return true;
        }
#endif

        // parsing a number using to the selected NumberStyles: e.g. " $ 12345.1234321e-4- " should result in -1.23451234321 with NumberStyles.Any
        // check for any of the special symbols (these cannot be combined with anything else)
        if (value.SequenceEqual(numberFormatInfo.NaNSymbol.AsSpan()))
        {
            quantityValue = NaN;
            return true;
        }

        if (value.SequenceEqual(numberFormatInfo.PositiveInfinitySymbol.AsSpan()))
        {
            quantityValue = PositiveInfinity;
            return true;
        }

        if (value.SequenceEqual(numberFormatInfo.NegativeInfinitySymbol.AsSpan()))
        {
            quantityValue = NegativeInfinity;
            return true;
        }

        var currencyAllowed = (numberStyles & NumberStyles.AllowCurrencySymbol) != 0;
        // there "special" rules regarding the white-spaces after a leading currency symbol is detected
        var currencyDetected = false;
        ReadOnlySpan<char> currencySymbol;
        if (currencyAllowed)
        {
            currencySymbol = numberFormatInfo.CurrencySymbol.AsSpan();
            if (currencySymbol.IsEmpty)
            {
                currencyAllowed = false;
                numberStyles &= ~NumberStyles.AllowCurrencySymbol; // no currency symbol available
            }
        }
        else
        {
            currencySymbol = [];
        }

        // note: decimal.TryParse relies on the CurrencySymbol (when currency is detected)
        var decimalsAllowed = (numberStyles & NumberStyles.AllowDecimalPoint) != 0;
        var decimalSeparator = decimalsAllowed ? numberFormatInfo.NumberDecimalSeparator.AsSpan() : [];

        var startIndex = 0;
        var endIndex = value.Length;
        var isNegative = false;

        // examine the leading characters
        do
        {
            var character = value[startIndex];
            if (char.IsDigit(character))
            {
                break;
            }

            if (char.IsWhiteSpace(character))
            {
                if ((numberStyles & NumberStyles.AllowLeadingWhite) == 0)
                {
                    return CannotParse(out quantityValue);
                }

                startIndex++;
                continue;
            }

            if (character == '(')
            {
                if ((numberStyles & NumberStyles.AllowParentheses) == 0)
                {
                    return CannotParse(out quantityValue); // not allowed
                }

                if (startIndex == endIndex - 1)
                {
                    return CannotParse(out quantityValue); // not enough characters
                }

                startIndex++; // consume the current character
                isNegative = true; // the closing parenthesis will be validated in the backwards iteration

                if (currencyDetected)
                {
                    // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                    numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                      NumberStyles.AllowTrailingSign |
                                      NumberStyles.AllowHexSpecifier);
                }
                else if (currencyAllowed && value[startIndex..].StartsWith(currencySymbol))
                {
                    // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                    currencyDetected = true;
                    startIndex += currencySymbol.Length;
                    numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                      NumberStyles.AllowTrailingSign |
                                      NumberStyles.AllowCurrencySymbol |
                                      NumberStyles.AllowHexSpecifier);
                }
                else
                {
                    // if next character is a white space the format should be rejected
                    numberStyles &= ~(NumberStyles.AllowLeadingWhite |
                                      NumberStyles.AllowLeadingSign |
                                      NumberStyles.AllowTrailingSign |
                                      NumberStyles.AllowHexSpecifier);
                    break;
                }

                continue;
            }

            if ((numberStyles & NumberStyles.AllowLeadingSign) != 0)
            {
                if (numberFormatInfo.NegativeSign.AsSpan() is { IsEmpty: false } negativeSign && value[startIndex..].StartsWith(negativeSign))
                {
                    isNegative = true;
                    startIndex += negativeSign.Length;
                    if (currencyDetected)
                    {
                        // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowHexSpecifier);
                    }
                    else if (currencyAllowed && value[startIndex..].StartsWith(currencySymbol))
                    {
                        // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                        currencyDetected = true;
                        startIndex += currencySymbol.Length;
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowCurrencySymbol |
                                          NumberStyles.AllowHexSpecifier);
                    }
                    else
                    {
                        // if next character is a white space the format should be rejected
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowLeadingWhite |
                                          NumberStyles.AllowHexSpecifier);
                        break;
                    }

                    continue;
                }

                if (numberFormatInfo.PositiveSign.AsSpan() is { IsEmpty: false } positiveSign && value[startIndex..].StartsWith(positiveSign))
                {
                    isNegative = false;
                    startIndex += positiveSign.Length;
                    if (currencyDetected)
                    {
                        // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowHexSpecifier);
                    }
                    else if (currencyAllowed && value[startIndex..].StartsWith(currencySymbol))
                    {
                        // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                        currencyDetected = true;
                        startIndex += currencySymbol.Length;
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowCurrencySymbol |
                                          NumberStyles.AllowHexSpecifier);
                    }
                    else
                    {
                        // if next character is a white space the format should be rejected
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowLeadingWhite |
                                          NumberStyles.AllowHexSpecifier);
                        break;
                    }

                    continue;
                }
            }

            if (currencyAllowed && !currencyDetected && value[startIndex..].StartsWith(currencySymbol))
            {
                // there can be no more currency symbols but there could be more white-spaces (we skip and continue)
                currencyDetected = true;
                numberStyles &= ~NumberStyles.AllowCurrencySymbol;
                startIndex += currencySymbol.Length;
                continue;
            }

            if (decimalsAllowed && value[startIndex..].StartsWith(decimalSeparator))
            {
                break; // decimal string with no leading zeros
            }

            // this is either an expected hex string or an invalid format
            return (numberStyles & NumberStyles.AllowHexSpecifier) != 0
                ? TryParseInteger(value[startIndex..endIndex], numberStyles & ~NumberStyles.AllowTrailingSign,
                    formatProvider, isNegative, out quantityValue)
                : CannotParse(out quantityValue); // unexpected character
        } while (startIndex < endIndex);

        if (startIndex >= endIndex)
        {
            return CannotParse(out quantityValue);
        }

        if (isNegative)
        {
            numberStyles &= ~(NumberStyles.AllowLeadingWhite |
                              NumberStyles.AllowLeadingSign);
        }
        else
        {
            numberStyles &= ~(NumberStyles.AllowLeadingWhite |
                              NumberStyles.AllowLeadingSign |
                              NumberStyles.AllowParentheses);
        }

        // examine the trailing characters
        do
        {
            var character = value[endIndex - 1];
            if (char.IsDigit(character))
            {
                break;
            }

            if (char.IsWhiteSpace(character))
            {
                if ((numberStyles & NumberStyles.AllowTrailingWhite) == 0)
                {
                    return CannotParse(out quantityValue);
                }

                endIndex--;
                continue;
            }

            if (character == ')')
            {
                if ((numberStyles & NumberStyles.AllowParentheses) == 0)
                {
                    return CannotParse(out quantityValue); // not allowed
                }

                numberStyles &= ~(NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol);
                endIndex--;
                continue;
            }

            if ((numberStyles & NumberStyles.AllowTrailingSign) != 0)
            {
                if (numberFormatInfo.NegativeSign.AsSpan() is { IsEmpty: false } negativeSign && value[..endIndex].EndsWith(negativeSign))
                {
                    isNegative = true;
                    numberStyles &= ~(NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                    endIndex -= negativeSign.Length;
                    continue;
                }

                if (numberFormatInfo.PositiveSign.AsSpan() is { IsEmpty: false } positiveSign && value[..endIndex].EndsWith(positiveSign))
                {
                    isNegative = false;
                    numberStyles &= ~(NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                    endIndex -= positiveSign.Length;
                    continue;
                }
            }

            if (currencyAllowed && !currencyDetected && value[..endIndex].EndsWith(currencySymbol))
            {
                // there can be no more currency symbols but there could be more white-spaces (we skip and continue)
                currencyDetected = true;
                numberStyles &= ~NumberStyles.AllowCurrencySymbol;
                endIndex -= currencySymbol.Length;
                continue;
            }

            if (decimalsAllowed && value[..endIndex].EndsWith(decimalSeparator))
            {
                break;
            }

            // this is either an expected hex string or an invalid format
            return (numberStyles & NumberStyles.AllowHexSpecifier) != 0
                ? TryParseInteger(value[startIndex..endIndex], numberStyles & ~NumberStyles.AllowTrailingSign,
                    formatProvider, isNegative, out quantityValue)
                : CannotParse(out quantityValue); // unexpected character
        } while (startIndex < endIndex);

        if (startIndex >= endIndex)
        {
            return CannotParse(out quantityValue); // not enough characters
        }

        if (isNegative && (numberStyles & NumberStyles.AllowParentheses) != 0)
        {
            return CannotParse(out quantityValue); // failed to find a closing parentheses
        }

        numberStyles &= ~(NumberStyles.AllowTrailingWhite |
                          NumberStyles.AllowTrailingSign |
                          NumberStyles.AllowCurrencySymbol);
        // at this point value[startIndex, endIndex] should correspond to the number without the sign (or the format is invalid)
        var unsignedValue = value[startIndex..endIndex];

        if (unsignedValue.Length == 1)
        {
            // this can only be a single digit (integer)
            return TryParseInteger(unsignedValue, numberStyles, formatProvider, isNegative, out quantityValue);
        }

        if ((numberStyles & NumberStyles.AllowExponent) != 0)
        {
            return TryParseWithExponent(unsignedValue, numberStyles, numberFormatInfo, isNegative, out quantityValue);
        }

        return decimalsAllowed
            ? TryParseDecimalNumber(unsignedValue, numberStyles, numberFormatInfo, isNegative, out quantityValue)
            : TryParseInteger(unsignedValue, numberStyles, formatProvider, isNegative, out quantityValue);
    }

    private static bool TryParseWithExponent(ReadOnlySpan<char> value, NumberStyles parseNumberStyles,
        NumberFormatInfo numberFormatInfo, bool isNegative, out QuantityValue quantityValue)
    {
        // 1. try to find the exponent character (extracting the left and right sides)
        parseNumberStyles &= ~NumberStyles.AllowExponent;
        if (!TrySplitAny(value, ['E', 'e'], out ReadOnlySpan<char> coefficientSpan, out ReadOnlySpan<char> exponentSpan))
        {
            // no exponent found
            return (parseNumberStyles & NumberStyles.AllowDecimalPoint) != 0
                ? TryParseDecimalNumber(value, parseNumberStyles, numberFormatInfo, isNegative, out quantityValue)
                : TryParseInteger(value, parseNumberStyles, numberFormatInfo, isNegative, out quantityValue);
        }

        // 2. try to parse the exponent (w.r.t. the scientific notation format)
        if (!int.TryParse(exponentSpan, NumberStyles.AllowLeadingSign | NumberStyles.Integer, numberFormatInfo,
                out var exponent))
        {
            return CannotParse(out quantityValue);
        }

        // 3. try to parse the coefficient (w.r.t. the decimal separator allowance)
        if (coefficientSpan.Length == 1 || (parseNumberStyles & NumberStyles.AllowDecimalPoint) == 0)
        {
            if (!TryParseInteger(coefficientSpan, parseNumberStyles, numberFormatInfo, isNegative, out quantityValue))
            {
                return false;
            }
        }
        else
        {
            if (!TryParseDecimalNumber(coefficientSpan, parseNumberStyles, numberFormatInfo, isNegative, out quantityValue))
            {
                return false;
            }
        }

        // 4. multiply the coefficient by 10 to the power of the exponent
        quantityValue = new QuantityValue(quantityValue.Numerator, quantityValue.Denominator, exponent);
        return true;
    }

    private static bool TryParseDecimalNumber(ReadOnlySpan<char> value, NumberStyles parseNumberStyles,
        NumberFormatInfo numberFormatInfo, bool isNegative, out QuantityValue quantityValue)
    {
        // 1. try to find the decimal separator (extracting the left and right sides)
        if (!TrySplit(value, numberFormatInfo.NumberDecimalSeparator, out ReadOnlySpan<char> integerSpan, out ReadOnlySpan<char> fractionalSpan))
        {
            return TryParseInteger(value, parseNumberStyles, numberFormatInfo, isNegative, out quantityValue);
        }
        
        // 2. validate the format of the string after the radix
        if (fractionalSpan.IsEmpty)
        {
            // after excluding the sign, the input was reduced to just an integer part (e.g. "1 234.")
            return TryParseInteger(integerSpan, parseNumberStyles, numberFormatInfo, isNegative, out quantityValue);
        }

        if ((parseNumberStyles & NumberStyles.AllowThousands) != 0)
        {
            if (fractionalSpan.Contains(numberFormatInfo.NumberGroupSeparator, StringComparison.Ordinal))
            {
                return CannotParse(out quantityValue); // number group separator detected in the fractional part (e.g. "1.2 34")
            }
        }

        // 3. extract the value of the string corresponding to the number without the decimal separator: "0.123 " should return "0123"
        var integerString = string.Concat(integerSpan, fractionalSpan);
        if (!BigInteger.TryParse(integerString, parseNumberStyles, numberFormatInfo, out var numerator))
        {
            return CannotParse(out quantityValue);
        }

        if (numerator.IsZero)
        {
            quantityValue = Zero;
            return true;
        }

        if (isNegative)
        {
            numerator = -numerator;
        }

        // 4. construct the fractional part using the corresponding decimal power for the denominator
        var nbDecimals = fractionalSpan.Length;
        BigInteger denominator = PowerOfTen(nbDecimals);
        quantityValue = new QuantityValue(numerator, denominator);
        return true;
    }

    private static bool TryParseInteger(ReadOnlySpan<char> value, NumberStyles parseNumberStyles,
        IFormatProvider? formatProvider, bool isNegative, out QuantityValue quantityValue)
    {
        if (!BigInteger.TryParse(value, parseNumberStyles, formatProvider, out var bigInteger))
        {
            return CannotParse(out quantityValue);
        }

        quantityValue = isNegative ? -bigInteger : bigInteger;
        return true;
    }
    
    private static bool TrySplit(ReadOnlySpan<char> span, ReadOnlySpan<char> separator, out ReadOnlySpan<char> firstSpan, out ReadOnlySpan<char> secondSpan)
    {
        var separatorIndex = span.IndexOf(separator);
            
        if (separatorIndex < 0)
        {
            firstSpan = span;
            secondSpan = ReadOnlySpan<char>.Empty;
            return false;
        }
        
        firstSpan = span[..separatorIndex];
        secondSpan = span[(separatorIndex + separator.Length)..];
        return true;
    }
    
    private static bool TrySplitAny(ReadOnlySpan<char> span, ReadOnlySpan<char> separators, out ReadOnlySpan<char> firstSpan, out ReadOnlySpan<char> secondSpan)
    {
        var separatorIndex = span.IndexOfAny(separators);
            
        if (separatorIndex < 0)
        {
            firstSpan = span;
            secondSpan = ReadOnlySpan<char>.Empty;
            return false;
        }
        
        firstSpan = span[..separatorIndex];
        secondSpan = span[(separatorIndex + 1)..];
        return true;
    }
#else
    /// <summary>
    ///     Attempts to parse a string of characters into a QuantityValue, and returns a value
    ///     that indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="value">
    ///     The input string to parse. The numerator and denominator must be separated by a '/' (slash) character.
    ///     For example, "3/4". If the string is not in this format, the parsing behavior is influenced by the
    ///     <paramref name="numberStyles" /> and <paramref name="formatProvider" /> parameters.
    /// </param>
    /// <param name="numberStyles">
    ///     A bitwise combination of number styles permitted in the input string. This is relevant when the string
    ///     is not in the numerator/denominator format. For instance, <see cref="NumberStyles.Float" /> allows decimal
    ///     points and scientific notation.
    /// </param>
    /// <param name="formatProvider">
    ///     An <see cref="IFormatProvider" /> that supplies culture-specific information used to parse the input string.
    ///     This is relevant when the string is not in the numerator/denominator format. For example,
    ///     <c>CultureInfo.GetCultureInfo("en-US")</c> for US English culture.
    /// </param>
    /// <param name="quantityValue">
    ///     When this method returns, contains the parsed fraction if the operation was successful; otherwise,
    ///     it contains the default value of <see cref="QuantityValue" />.
    /// </param>
    /// <returns>
    ///     <c>true</c> if the input string is well-formed and could be parsed into a fraction; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    ///     The <paramref name="numberStyles" /> parameter allows you to specify which number styles are allowed in the input
    ///     string.
    ///     For example, <see cref="NumberStyles.Float" /> allows decimal points and scientific notation.
    ///     The <paramref name="formatProvider" /> parameter provides culture-specific formatting information.
    ///     For example, you can use <c>CultureInfo.GetCultureInfo("en-US")</c> for US English culture.
    ///     Here are some examples of how to use the
    ///     <see cref="TryParse(string, NumberStyles, IFormatProvider, out QuantityValue)" /> method:
    ///     <example>
    ///         <code>
    /// QuantityValue.TryParse("3/4", NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), true, out var fraction);
    /// </code>
    ///         This example parses the string "3/4" into a <see cref="QuantityValue" /> object with a numerator of 3 and a
    ///         denominator of 4.
    ///         <code>
    /// QuantityValue.TryParse("1.25", NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), true, out var fraction);
    /// </code>
    ///         This example parses the string "1.25" into a <see cref="QuantityValue" /> object with a numerator of 5 and a
    ///         denominator of 4.
    ///         <code>
    /// QuantityValue.TryParse("1.23e-2", NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), true, out var fraction);
    /// </code>
    ///         This example parses the string "1.23e-2" into a <see cref="QuantityValue" /> object with a numerator of 123 and
    ///         a
    ///         denominator of 10000.
    ///     </example>
    /// </remarks>
    public static bool TryParse(string? value, NumberStyles numberStyles, IFormatProvider? formatProvider, out QuantityValue quantityValue)
    {
        if (string.IsNullOrEmpty(value))
        {
            return CannotParse(out quantityValue);
        }
        
        var numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);

        if (value!.Length == 1)
        {
            if (!byte.TryParse(value, numberStyles, formatProvider, out var singleDigit))
            {
                if (value.SequenceEqual(numberFormatInfo.PositiveInfinitySymbol))
                {
                    quantityValue = PositiveInfinity;
                    return true;
                }

                if (value.SequenceEqual(numberFormatInfo.NegativeInfinitySymbol))
                {
                    quantityValue = NegativeInfinity;
                    return true;
                }

                if (value.SequenceEqual(numberFormatInfo.NaNSymbol))
                {
                    quantityValue = NaN;
                    return true;
                }

                return CannotParse(out quantityValue);
            }

            quantityValue = new QuantityValue(singleDigit);
            return true;
        }

        // TODO see if we want to support this
#if FRACTION_PARSING_ENABLED
        var components = value.Split('/');
        if (components.Length >= 2)
        {
            var numeratorString = components[0];
            var denominatorString = components[1];

            var withoutDecimalPoint = numberStyles & ~NumberStyles.AllowDecimalPoint;
            if (!BigInteger.TryParse(
                    numeratorString,
                    withoutDecimalPoint,
                    formatProvider,
                    out var numerator)
                || !BigInteger.TryParse(
                    denominatorString,
                    withoutDecimalPoint,
                    formatProvider,
                    out var denominator))
            {
                return CannotParse(out quantityValue);
            }

            quantityValue = FromTerms(numerator, denominator);
            return true;
        }
#endif

        // parsing a number using to the selected NumberStyles: e.g. " $ 12345.1234321e-4- " should result in -1.23451234321 with NumberStyles.Any
        // check for any of the special symbols (these cannot be combined with anything else)
        if (value == numberFormatInfo.NaNSymbol)
        {
            quantityValue = NaN;
            return true;
        }

        if (value == numberFormatInfo.PositiveInfinitySymbol)
        {
            quantityValue = PositiveInfinity;
            return true;
        }

        if (value == numberFormatInfo.NegativeInfinitySymbol)
        {
            quantityValue = NegativeInfinity;
            return true;
        }

        var currencyAllowed = (numberStyles & NumberStyles.AllowCurrencySymbol) != 0;

        // there "special" rules regarding the white-spaces after a leading currency symbol is detected
        var currencyDetected = false;

        var currencySymbol = numberFormatInfo.CurrencySymbol;
        if (currencyAllowed && string.IsNullOrEmpty(currencySymbol))
        {
            numberStyles &= ~NumberStyles.AllowCurrencySymbol; // no currency symbol available
            currencyAllowed = false;
        }

        // note: decimal.TryParse relies on the CurrencySymbol (when currency is detected)
        var decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
        var decimalsAllowed = (numberStyles & NumberStyles.AllowDecimalPoint) != 0;

        var startIndex = 0;
        var endIndex = value.Length;
        var isNegative = false;

        // examine the leading characters
        do
        {
            var character = value[startIndex];
            if (char.IsDigit(character))
            {
                break;
            }

            if (char.IsWhiteSpace(character))
            {
                if ((numberStyles & NumberStyles.AllowLeadingWhite) == 0)
                {
                    return CannotParse(out quantityValue);
                }

                startIndex++;
                continue;
            }

            if (character == '(')
            {
                if ((numberStyles & NumberStyles.AllowParentheses) == 0)
                {
                    return CannotParse(out quantityValue); // not allowed
                }

                if (startIndex == endIndex - 1)
                {
                    return CannotParse(out quantityValue); // not enough characters
                }

                startIndex++; // consume the current character
                isNegative = true; // the closing parenthesis will be validated in the backwards iteration

                if (currencyDetected)
                {
                    // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                    numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                      NumberStyles.AllowTrailingSign |
                                      NumberStyles.AllowHexSpecifier);
                }
                else if (currencyAllowed && StartsWith(value, currencySymbol, startIndex))
                {
                    // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                    currencyDetected = true;
                    startIndex += currencySymbol.Length;
                    numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                      NumberStyles.AllowTrailingSign |
                                      NumberStyles.AllowCurrencySymbol |
                                      NumberStyles.AllowHexSpecifier);
                }
                else
                {
                    // if next character is a white space the format should be rejected
                    numberStyles &= ~(NumberStyles.AllowLeadingWhite |
                                      NumberStyles.AllowLeadingSign |
                                      NumberStyles.AllowTrailingSign |
                                      NumberStyles.AllowHexSpecifier);
                    break;
                }

                continue;
            }

            if ((numberStyles & NumberStyles.AllowLeadingSign) != 0)
            {
                if (numberFormatInfo.NegativeSign is { Length: > 0 } negativeSign &&
                    StartsWith(value, negativeSign, startIndex))
                {
                    isNegative = true;
                    startIndex += negativeSign.Length;
                    if (currencyDetected)
                    {
                        // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowHexSpecifier);
                    }
                    else if (currencyAllowed && StartsWith(value, currencySymbol, startIndex))
                    {
                        // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                        currencyDetected = true;
                        startIndex += currencySymbol.Length;
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowCurrencySymbol |
                                          NumberStyles.AllowHexSpecifier);
                    }
                    else
                    {
                        // if next character is a white space the format should be rejected
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowLeadingWhite |
                                          NumberStyles.AllowHexSpecifier);
                        break;
                    }

                    continue;
                }

                if (numberFormatInfo.PositiveSign is { Length: > 0 } positiveSign &&
                    StartsWith(value, positiveSign, startIndex))
                {
                    isNegative = false;
                    startIndex += positiveSign.Length;
                    if (currencyDetected)
                    {
                        // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowHexSpecifier);
                    }
                    else if (currencyAllowed && StartsWith(value, currencySymbol, startIndex))
                    {
                        // there can be no more currency symbols but there could be more white-spaces (we skip and continue) 
                        currencyDetected = true;
                        startIndex += currencySymbol.Length;
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowCurrencySymbol |
                                          NumberStyles.AllowHexSpecifier);
                    }
                    else
                    {
                        // if next character is a white space the format should be rejected
                        numberStyles &= ~(NumberStyles.AllowLeadingSign |
                                          NumberStyles.AllowTrailingSign |
                                          NumberStyles.AllowParentheses |
                                          NumberStyles.AllowLeadingWhite |
                                          NumberStyles.AllowHexSpecifier);
                        break;
                    }

                    continue;
                }
            }

            if (currencyAllowed && !currencyDetected && StartsWith(value, currencySymbol, startIndex))
            {
                // there can be no more currency symbols but there could be more white-spaces (we skip and continue)
                currencyDetected = true;
                numberStyles &= ~NumberStyles.AllowCurrencySymbol;
                startIndex += currencySymbol.Length;
                continue;
            }

            if (decimalsAllowed && StartsWith(value, decimalSeparator, startIndex))
            {
                break; // decimal string with no leading zeros
            }

            // this is either an expected hex string or an invalid format
            return (numberStyles & NumberStyles.AllowHexSpecifier) != 0
                ? TryParseInteger(value, numberStyles & ~NumberStyles.AllowTrailingSign, formatProvider, startIndex,
                    endIndex, isNegative, out quantityValue)
                : CannotParse(out quantityValue); // unexpected character
        } while (startIndex < endIndex);

        if (startIndex >= endIndex)
        {
            return CannotParse(out quantityValue);
        }

        if (isNegative)
        {
            numberStyles &= ~(NumberStyles.AllowLeadingWhite |
                              NumberStyles.AllowLeadingSign);
        }
        else
        {
            numberStyles &= ~(NumberStyles.AllowLeadingWhite |
                              NumberStyles.AllowLeadingSign |
                              NumberStyles.AllowParentheses);
        }

        // examine the trailing characters
        do
        {
            var character = value[endIndex - 1];
            if (char.IsDigit(character))
            {
                break;
            }

            if (char.IsWhiteSpace(character))
            {
                if ((numberStyles & NumberStyles.AllowTrailingWhite) == 0)
                {
                    return CannotParse(out quantityValue);
                }

                endIndex--;
                continue;
            }

            if (character == ')')
            {
                if ((numberStyles & NumberStyles.AllowParentheses) == 0)
                {
                    return CannotParse(out quantityValue); // not allowed
                }

                numberStyles &= ~(NumberStyles.AllowParentheses | NumberStyles.AllowCurrencySymbol);
                endIndex--;
                continue;
            }

            if ((numberStyles & NumberStyles.AllowTrailingSign) != 0)
            {
                if (numberFormatInfo.NegativeSign is { Length: > 0 } negativeSign &&
                    EndsWith(value, negativeSign, endIndex))
                {
                    isNegative = true;
                    numberStyles &= ~(NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                    endIndex -= negativeSign.Length;
                    continue;
                }

                if (numberFormatInfo.PositiveSign is { Length: > 0 } positiveSign &&
                    EndsWith(value, positiveSign, endIndex))
                {
                    isNegative = false;
                    numberStyles &= ~(NumberStyles.AllowTrailingSign | NumberStyles.AllowHexSpecifier);
                    endIndex -= positiveSign.Length;
                    continue;
                }
            }

            if (currencyAllowed && !currencyDetected && EndsWith(value, currencySymbol, endIndex))
            {
                // there can be no more currency symbols but there could be more white-spaces (we skip and continue)
                currencyDetected = true;
                numberStyles &= ~NumberStyles.AllowCurrencySymbol;
                endIndex -= currencySymbol.Length;
                continue;
            }

            if (decimalsAllowed && EndsWith(value, decimalSeparator, endIndex))
            {
                break;
            }

            // this is either an expected hex string or an invalid format
            return (numberStyles & NumberStyles.AllowHexSpecifier) != 0
                ? TryParseInteger(value, numberStyles & ~NumberStyles.AllowTrailingSign, formatProvider, startIndex,
                    endIndex, isNegative, out quantityValue)
                : CannotParse(out quantityValue); // unexpected character
        } while (startIndex < endIndex);

        if (startIndex >= endIndex)
        {
            return CannotParse(out quantityValue); // not enough characters
        }

        if (isNegative && (numberStyles & NumberStyles.AllowParentheses) != 0)
        {
            return CannotParse(out quantityValue); // failed to find a closing parentheses
        }

        numberStyles &= ~(NumberStyles.AllowTrailingWhite |
                          NumberStyles.AllowTrailingSign |
                          NumberStyles.AllowCurrencySymbol);
        // at this point value[startIndex, endIndex] should correspond to the number without the sign (or the format is invalid)

        if (startIndex == endIndex - 1)
        {
            // this can only be a single digit (integer)
            return TryParseInteger(value, numberStyles, formatProvider, startIndex, endIndex, isNegative, out quantityValue);
        }

        if ((numberStyles & NumberStyles.AllowExponent) != 0)
        {
            return TryParseWithExponent(value, numberStyles, numberFormatInfo, startIndex, endIndex, isNegative, out quantityValue);
        }

        return decimalsAllowed
            ? TryParseDecimalNumber(value, numberStyles, numberFormatInfo, startIndex, endIndex, isNegative, out quantityValue)
            : TryParseInteger(value, numberStyles, formatProvider, startIndex, endIndex, isNegative, out quantityValue);

        static bool StartsWith(string fractionString, string testString, int startIndex)
        {
            var stringLength = testString.Length;
            if (fractionString.Length - startIndex < stringLength)
            {
                return false;
            }

            for (var i = 0; i < stringLength; i++)
            {
                if (testString[i] != fractionString[startIndex + i])
                {
                    return false;
                }
            }

            return true;
        }

        static bool EndsWith(string fractionString, string testString, int endIndex)
        {
            return endIndex >= testString.Length && StartsWith(fractionString, testString, endIndex - testString.Length);
        }
    }

    private static bool TryParseWithExponent(string valueString, NumberStyles parseNumberStyles,
        NumberFormatInfo numberFormatInfo,
        int startIndex, int endIndex, bool isNegative, out QuantityValue quantityValue)
    {
        // 1. try to find the exponent character index
        parseNumberStyles &= ~NumberStyles.AllowExponent;
        var exponentIndex = valueString.IndexOfAny(['e', 'E'], startIndex + 1, endIndex - startIndex - 1);
        if (exponentIndex == -1)
        {
            // no exponent found
            return (parseNumberStyles & NumberStyles.AllowDecimalPoint) != 0
                ? TryParseDecimalNumber(valueString, parseNumberStyles, numberFormatInfo, startIndex, endIndex,
                    isNegative, out quantityValue)
                : TryParseInteger(valueString, parseNumberStyles, numberFormatInfo, startIndex, endIndex, isNegative,
                    out quantityValue);
        }

        // 2. try to parse the exponent (w.r.t. the scientific notation format)
        var exponentString = valueString.Substring(exponentIndex + 1, endIndex - exponentIndex - 1);
        if (!int.TryParse(exponentString, NumberStyles.AllowLeadingSign | NumberStyles.Integer, numberFormatInfo,
                out var exponent))
        {
            return CannotParse(out quantityValue);
        }

        // 3. try to parse the coefficient (w.r.t. the decimal separator allowance)
        if (startIndex == endIndex - 1 || (parseNumberStyles & NumberStyles.AllowDecimalPoint) == 0)
        {
            if (!TryParseInteger(valueString, parseNumberStyles, numberFormatInfo, startIndex, exponentIndex,
                    isNegative, out quantityValue))
            {
                return false;
            }
        }
        else
        {
            if (!TryParseDecimalNumber(valueString, parseNumberStyles, numberFormatInfo, startIndex, exponentIndex, isNegative, out quantityValue))
            {
                return false;
            }
        }

        // 4. multiply the coefficient by 10 to the power of the exponent
        quantityValue = new QuantityValue(quantityValue.Numerator, quantityValue.Denominator, exponent);
        return true;
    }

    private static bool TryParseDecimalNumber(string valueString, NumberStyles parseNumberStyles, NumberFormatInfo numberFormatInfo,
        int startIndex, int endIndex, bool isNegative, out QuantityValue fraction)
    {
        // 1. find the position of the decimal separator (if any)
        var decimalSeparatorIndex = valueString.IndexOf(numberFormatInfo.NumberDecimalSeparator, startIndex,
            endIndex - startIndex, StringComparison.Ordinal);
        if (decimalSeparatorIndex == -1)
        {
            return TryParseInteger(valueString, parseNumberStyles, numberFormatInfo, startIndex, endIndex, isNegative,
                out fraction);
        }

        // 2. validate the format of the string after the radix
        var decimalSeparatorLength = numberFormatInfo.NumberDecimalSeparator.Length;
        if (startIndex + decimalSeparatorLength == endIndex)
        {
            // after excluding the sign, the input was reduced to just the decimal separator (with nothing on either sides)
            return CannotParse(out fraction);
        }

        if ((parseNumberStyles & NumberStyles.AllowThousands) != 0)
        {
            if (valueString.IndexOf(numberFormatInfo.NumberGroupSeparator,
                    decimalSeparatorIndex + decimalSeparatorLength, StringComparison.Ordinal) != -1)
            {
                return CannotParse(out fraction);
            }
        }

        // 3. extract the value of the string corresponding to the number without the decimal separator: " 0.123 " should return "0123"
        var integerString = string.Concat(
            valueString.Substring(startIndex, decimalSeparatorIndex - startIndex),
            valueString.Substring(decimalSeparatorIndex + decimalSeparatorLength,
                endIndex - decimalSeparatorIndex - decimalSeparatorLength));

        if (!BigInteger.TryParse(integerString, parseNumberStyles, numberFormatInfo, out var numerator))
        {
            return CannotParse(out fraction);
        }

        if (numerator.IsZero)
        {
            fraction = Zero;
            return true;
        }

        if (isNegative)
        {
            numerator = -numerator;
        }

        var nbDecimals = endIndex - decimalSeparatorIndex - decimalSeparatorLength;
        if (nbDecimals == 0)
        {
            fraction = new QuantityValue(numerator);
            return true;
        }

        // 4. construct the fractional part using the corresponding decimal power for the denominator
        var denominator = PowerOfTen(nbDecimals);
        fraction = new QuantityValue(numerator, denominator);
        return true;
    }

    private static bool TryParseInteger(string valueString, NumberStyles parseNumberStyles,
        IFormatProvider? formatProvider,
        int startIndex, int endIndex, bool isNegative, out QuantityValue fraction)
    {
        if (!BigInteger.TryParse(valueString.Substring(startIndex, endIndex - startIndex), parseNumberStyles,
                formatProvider, out var bigInteger))
        {
            return CannotParse(out fraction);
        }

        fraction = new QuantityValue(isNegative ? -bigInteger : bigInteger);
        return true;
    }
#endif


    /// <summary>
    ///     Sets the out parameter to the default value of QuantityValue and returns false.
    ///     This method is used when the parsing of a string to a QuantityValue fails.
    /// </summary>
    /// <param name="quantityValue">The QuantityValue object that will be set to its default value.</param>
    /// <returns>Always returns false.</returns>
    private static bool CannotParse(out QuantityValue quantityValue)
    {
        quantityValue = default;
        return false;
    }
}
