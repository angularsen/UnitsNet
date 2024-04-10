// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using System.Numerics;
using Fractions;

namespace UnitsNet;

public readonly partial struct QuantityValue
{
    internal static readonly BigInteger Ten = 10;
    
    /// <summary>
    ///     Parses a string representation of a quantity value into a QuantityValue object.
    /// </summary>
    /// <param name="valueString">The string representation of the quantity value.</param>
    /// <param name="parseNumberStyles">
    ///     A NumberStyles value that indicates the style elements that can be present in
    ///     valueString.
    /// </param>
    /// <returns>A QuantityValue object that represents the parsed string.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown when the provided string argument is null.</exception>
    /// <exception cref="System.FormatException">
    ///     Thrown when the format of the provided string argument is invalid and cannot
    ///     be successfully parsed into a Fraction.
    /// </exception>
    public static QuantityValue Parse(string valueString, IFormatProvider? parseNumberStyles)
    {
        return Parse(valueString, NumberStyles.Float, parseNumberStyles);
    }

    /// <summary>
    ///     Parses a string representation of a quantity value into a QuantityValue object.
    /// </summary>
    /// <param name="valueString">The string representation of the quantity value.</param>
    /// <param name="parseNumberStyles">
    ///     A NumberStyles value that indicates the style elements that can be present in
    ///     valueString.
    /// </param>
    /// <param name="formatProvider">
    ///     An IFormatProvider that supplies culture-specific formatting information about
    ///     valueString.
    /// </param>
    /// <returns>A QuantityValue object that represents the parsed string.</returns>
    /// <exception cref="System.ArgumentNullException">Thrown when the provided string argument is null.</exception>
    /// <exception cref="System.FormatException">
    ///     Thrown when the format of the provided string argument is invalid and cannot
    ///     be successfully parsed into a Fraction.
    /// </exception>
    public static QuantityValue Parse(string valueString, NumberStyles parseNumberStyles, IFormatProvider? formatProvider)
    {
        if (TryParse(valueString, parseNumberStyles, formatProvider, out QuantityValue valueParsed))
        {
            return valueParsed;
        }
        
        throw new FormatException(
            $"The format of the provided string argument '{valueString}' is invalid and cannot be successfully parsed into a QuantityValue.");
    }

    /// <summary>
    ///     Tries to convert the string representation of a quantity value to its QuantityValue equivalent, and returns a value
    ///     that indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="valueString">The string representation of a quantity value. This parameter can be null.</param>
    /// <param name="parseNumberStyles">
    ///     A NumberStyles value that indicates the style elements that can be present in
    ///     valueString.
    /// </param>
    /// <param name="formatProvider">
    ///     An IFormatProvider that supplies culture-specific formatting information about
    ///     valueString. This parameter can be null.
    /// </param>
    /// <param name="quantityValue">
    ///     When this method returns, contains the QuantityValue equivalent to the quantity value
    ///     contained in valueString, if the conversion succeeded, or zero if the conversion failed. The conversion fails if
    ///     the valueString parameter is null or is not of the correct format. This parameter is passed uninitialized.
    /// </param>
    /// <returns>true if valueString was converted successfully; otherwise, false.</returns>
    public static bool TryParse(string? valueString, NumberStyles parseNumberStyles, IFormatProvider? formatProvider, out QuantityValue quantityValue)
    {
        // check out the code dotnet runtime: src/libraries/System.Private.CoreLib/src/System/Number.Parsing.cs
        if (string.IsNullOrEmpty(valueString))
        {
            quantityValue = default;
            return false;
        }
        
        if (parseNumberStyles.HasFlag(NumberStyles.AllowExponent))
        {
            return TryParseWithExponent(valueString!, parseNumberStyles, formatProvider, out quantityValue); 
        }

        if (parseNumberStyles.HasFlag(NumberStyles.AllowDecimalPoint))
        {
            return TryParseDecimalNumber(valueString!, parseNumberStyles, formatProvider, out quantityValue);
        }

        if(BigInteger.TryParse(valueString!, parseNumberStyles, formatProvider, out BigInteger bigInteger))
        {
            quantityValue = bigInteger;
            return true;
        }

        quantityValue = default;
        return false;
    }

    private static bool TryParseWithExponent(string valueString, NumberStyles parseNumberStyles, IFormatProvider? formatProvider, out QuantityValue quantityValue)
    {
        parseNumberStyles &= ~NumberStyles.AllowExponent;
        var exponentIndex = valueString.IndexOfAny(['e', 'E'], 1);
        if (exponentIndex == -1)
        {
            return parseNumberStyles.HasFlag(NumberStyles.AllowDecimalPoint)
                ? TryParseDecimalNumber(valueString, parseNumberStyles, formatProvider, out quantityValue)
                : TryParseInteger(valueString, parseNumberStyles, formatProvider, out quantityValue);
        }

        var exponentString = valueString.Substring(exponentIndex + 1);
        if (!int.TryParse(exponentString, parseNumberStyles, formatProvider, out var exponent))
        {
            quantityValue = default;
            return false;
        }

        // we've got an exponent: try to parse the coefficient
        var coefficientString = valueString.Substring(0, exponentIndex);
        if (parseNumberStyles.HasFlag(NumberStyles.AllowDecimalPoint))
        {
            if (!TryParseDecimalNumber(coefficientString, parseNumberStyles, formatProvider, out quantityValue))
            {
                return false;
            }
        }
        else
        {
            if (!TryParseInteger(coefficientString, parseNumberStyles, formatProvider, out quantityValue))
            {
                return false;
            }
        }

        quantityValue *= Pow(Ten, exponent);
        return true;
    }

    private static bool TryParseDecimalNumber(string valueString, NumberStyles parseNumberStyles, IFormatProvider? formatProvider, out QuantityValue quantityValue)
    {
        // valueString can be either a big-integer expression or one of the form "123.456...890" (possibly longer than the decimal range/precision)
        // // TODO test the short-path
        // if (valueString.Length < 30 && decimal.TryParse(valueString, parseNumberStyles, formatProvider, out var decimalValue))
        // {
        //     quantityValue = decimalValue;
        //     return true;
        // }
        // note: this whole function could probably be implemented without any string allocations
        // 1. clean up the whitespaces
        if (parseNumberStyles.HasFlag(NumberStyles.AllowLeadingWhite) && parseNumberStyles.HasFlag(NumberStyles.AllowTrailingWhite))
        {
            valueString = valueString.Trim();
            parseNumberStyles &= ~(NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite);
        }
        else if (parseNumberStyles.HasFlag(NumberStyles.AllowLeadingWhite))
        {
            valueString = valueString.TrimStart();
            parseNumberStyles &= ~NumberStyles.AllowLeadingWhite;
        }
        else if (parseNumberStyles.HasFlag(NumberStyles.AllowTrailingWhite))
        {
            valueString = valueString.TrimEnd();
            parseNumberStyles &= ~NumberStyles.AllowTrailingWhite;
        }

        // 2. find the position of the decimal separator (if any)
        var numberFormatInfo = NumberFormatInfo.GetInstance(formatProvider);
        var decimalSeparatorIndex = valueString.IndexOf(numberFormatInfo.NumberDecimalSeparator, 0, StringComparison.Ordinal);
        if (decimalSeparatorIndex == -1)
        {
            return TryParseInteger(valueString, parseNumberStyles, formatProvider, out quantityValue); // TODO check if the parseNumberStyles need to be adjusted
        }

        // 3. try to parse the numerator
        var numeratorString = valueString.Substring(0, decimalSeparatorIndex) + valueString.Substring(decimalSeparatorIndex + 1);
        if (!BigInteger.TryParse(numeratorString, parseNumberStyles, formatProvider, out BigInteger numerator))
        {
            quantityValue = default;
            return false;
        }

        // 4. construct the fraction using the corresponding decimal power for the denominator
        var nbDecimals = valueString.Length - decimalSeparatorIndex - 1;
        var denominator = BigInteger.Pow(Ten, nbDecimals);
        quantityValue = new QuantityValue(numerator, denominator);
        return true;
    }

    private static bool TryParseInteger(string valueString, NumberStyles parseNumberStyles, IFormatProvider? formatProvider, out QuantityValue quantityValue)
    {
        if (BigInteger.TryParse(valueString, parseNumberStyles, formatProvider, out BigInteger bigInteger))
        {
            quantityValue = new QuantityValue(bigInteger);
            return true;
        }
        
        quantityValue = default;
        return false;
    }

}
