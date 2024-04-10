// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using Xunit;

namespace UnitsNet.Tests;

public class DefaultQuantityValueFormatterTests
{
    private const string AmericanCultureName = "en-US";
    private const string RussianCultureName = "ru-RU";
    private const string NorwegianCultureName = "nb-NO";

    /// <summary>
    ///     The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific
    ///     notation, depending on the type of the number and whether a precision specifier is present. The precision specifier
    ///     defines the maximum number of significant digits that can appear in the result string. If the precision specifier
    ///     is omitted or zero, the type of the number determines the default precision.
    /// </summary>
    private static readonly string[] GeneralFormats =
        ["G", "G0", "G1", "G2", "G3", "G4", "G5", "G6", "g", "g0", "g1", "g2", "g3", "g4", "g5", "g6"];

    /// <summary>
    ///     The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each "d"
    ///     indicates a digit (0-9). The string starts with a minus sign if the number is negative.
    ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
    ///     current NumberFormatInfo.NumberDecimalDigits property supplies the numeric precision.
    /// </summary>
    private static readonly string[] FixedPointFormats =
        ["F", "F0", "F1", "F2", "F3", "F4", "F5", "F6", "f", "f0", "f1", "f2", "f3", "f4", "f5", "f6"];

    /// <summary>
    ///     The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-" indicates
    ///     a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "."
    ///     indicates a decimal point symbol. The precision specifier indicates the desired number of digits after the decimal
    ///     point. If the precision specifier is omitted, the number of decimal places is defined by the current
    ///     NumberFormatInfo.NumberDecimalDigits property.
    /// </summary>
    private static readonly string[] NumberFormats =
        ["N", "N0", "N1", "N2", "N3", "N4", "N5", "N6", "n", "n0", "n1", "n2", "n3", "n4", "n5", "n6"];

    /// <summary>
    ///     Exponential format specifier (E)
    ///     The exponential ("E") format specifier converts a number to a string of the form "-d.ddd…E+ddd" or "-d.ddd…e+ddd",
    ///     where each "d" indicates a digit (0-9). The string starts with a minus sign if the number is negative. Exactly one
    ///     digit always precedes the decimal point.
    ///     The precision specifier indicates the desired number of digits after the decimal point. If the precision specifier
    ///     is omitted, a default of six digits after the decimal point is used.
    ///     The case of the format specifier indicates whether to prefix the exponent with an "E" or an "e". The exponent
    ///     always consists of a plus or minus sign and a minimum of three digits. The exponent is padded with zeros to meet
    ///     this minimum, if required.
    /// </summary>
    private static readonly string[] ScientificFormats =
        ["E", "E0", "E1", "E2", "E3", "E4", "E5", "E6", "e", "e0", "e1", "e2", "e3", "e4", "e5", "e6"];

    /// <summary>
    ///     The "C" (or currency) format specifier converts a number to a string that represents a currency amount. The
    ///     precision specifier indicates the desired number of decimal places in the result string. If the precision specifier
    ///     is omitted, the default precision is defined by the NumberFormatInfo.CurrencyDecimalDigits property.
    ///     If the value to be formatted has more than the specified or default number of decimal places, the fractional value
    ///     is rounded in the result string. If the value to the right of the number of specified decimal places is 5 or
    ///     greater, the last digit in the result string is rounded away from zero.
    /// </summary>
    private static readonly string[] CurrencyFormats =
        ["C", "C0", "C1", "C2", "C3", "C4", "C5", "C6", "c", "c0", "c1", "c2", "c3", "c4", "c5", "c6"];

    /// <summary>
    ///     The percent ("P") format specifier multiplies a number by 100 and converts it to a string that represents a
    ///     percentage. The precision specifier indicates the desired number of decimal places. If the precision specifier is
    ///     omitted, the default numeric precision supplied by the current PercentDecimalDigits property is used.
    /// </summary>
    private static readonly string[] PercentageFormats =
        ["P", "P0", "P1", "P2", "P3", "P4", "P5", "P6", "p", "p0", "p1", "p2", "p3", "p4", "p5", "p6"];

    private static readonly IFormatProvider AmericanCulture = CultureInfo.GetCultureInfo(AmericanCultureName);
    private static readonly IFormatProvider NorwegianCulture = CultureInfo.GetCultureInfo(NorwegianCultureName);
    private static readonly IFormatProvider RussianCulture = CultureInfo.GetCultureInfo(RussianCultureName);

    private static readonly string[] TestCulturesNames = [AmericanCultureName, NorwegianCultureName, RussianCultureName];

    // we want to access these via the dictionary in order to enable the "selective test debugging" (IFormatProvider not serializable by xUnit)
    private static readonly Dictionary<string, IFormatProvider> FormatProviders = new()
    {
        { AmericanCultureName, AmericanCulture }, { NorwegianCultureName, NorwegianCulture }, { RussianCultureName, RussianCulture }
    };

    private static readonly decimal[] TerminatingFractions =
    [
        0, 1, -1, 10, -10, 100, -100, 1000, -1000, 10000, -10000, 100000, -100000,
        0.1m, -0.1m, 0.2m, -0.2m, 0.5m, -0.5m, 1.2m, -1.2m, 1.5m, -1.5m, 2.5m, -2.5m,
        0.000015545665434654m, -0.000015545665434654m,
        0.00015545665434654m, -0.00015545665434654m,
        0.0015545665434654m, -0.0015545665434654m,
        0.015545665434654m, -0.015545665434654m,
        0.15545665434654m, -0.15545665434654m,
        1.5545665434654m, -1.5545665434654m,
        15.545665434654m, -15.545665434654m,
        155.45665434654m, -155.45665434654m,
        1554.5665434654m, -1554.5665434654m,
        15545.665434654m, -15545.665434654m,
        155456.65434654m, -155456.65434654m,
        1554566.5434654m, -1554566.5434654m
    ];

    private static IEnumerable<string> SupportedFormatsToTest => GeneralFormats.Concat(FixedPointFormats).Concat(NumberFormats).Concat(ScientificFormats)
        .Concat(CurrencyFormats).Concat(PercentageFormats); // these two are currently only supported by converting to double (limited precision)

    /// <summary>
    ///     Tests to ensure `QuantityValue.ToString(...)` matches `double.ToString(...)` for all standard formats.
    /// </summary>
    /// <remarks>
    ///     Tests cover general, fixed point, number, scientific, currency, and percentage formats.
    /// </remarks>
    public class StandardFormatsCompatibilityTests
    {
        public static IEnumerable<object[]> GeneralFormatsToTest =>
            from stringFormat in GeneralFormats
            from valueToTest in TerminatingFractions
            from cultureToTest in TestCulturesNames
            select new object[] { valueToTest, stringFormat, cultureToTest };

        public static IEnumerable<object[]> FixedPointFormatsToTest =>
            from stringFormat in FixedPointFormats
            from valueToTest in TerminatingFractions
            from cultureToTest in TestCulturesNames
            select new object[] { valueToTest, stringFormat, cultureToTest };

        public static IEnumerable<object[]> NumberFormatsToTest =>
            from stringFormat in NumberFormats
            from valueToTest in TerminatingFractions
            from cultureToTest in TestCulturesNames
            select new object[] { valueToTest, stringFormat, cultureToTest };

        public static IEnumerable<object[]> ScientificFormatsToTest =>
            from stringFormat in ScientificFormats
            from valueToTest in TerminatingFractions
            from cultureToTest in TestCulturesNames
            select new object[] { valueToTest, stringFormat, cultureToTest };

        // this currency format is currently implemented via the ToDouble().ToString(..) so there isn't any need to test with the cultures
        public static IEnumerable<object[]> CurrencyFormatsToTest =>
            from stringFormat in CurrencyFormats
            from valueToTest in TerminatingFractions
            select new object[] { valueToTest, stringFormat };

        // the percentage format is currently implemented via the ToDouble().ToString(..) so there isn't any need to test with the cultures
        public static IEnumerable<object[]> PercentageFormatsToTest =>
            from stringFormat in PercentageFormats
            from valueToTest in TerminatingFractions
            select new object[] { valueToTest, stringFormat };

        [Theory]
        [MemberData(nameof(GeneralFormatsToTest))]
        public static void ToStringWithGeneralFormats_ShouldEqual_DoubleToString(QuantityValue valueToTest, string stringFormat, string formatProviderName)
        {
            // Arrange
            var doubleValue = valueToTest.ToDouble();
            IFormatProvider formatProvider = FormatProviders[formatProviderName];
            // Act
            var expected = doubleValue.ToString(stringFormat, formatProvider);
            var actual = valueToTest.ToString(stringFormat, formatProvider);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(FixedPointFormatsToTest))]
        public static void ToStringWithFixedPointFormats_ShouldEqual_DoubleToString(QuantityValue valueToTest, string stringFormat, string formatProviderName)
        {
            // Arrange
            var doubleValue = valueToTest.ToDouble();
            IFormatProvider formatProvider = FormatProviders[formatProviderName];
            // Act
            var expected = doubleValue.ToString(stringFormat, formatProvider);
            var actual = valueToTest.ToString(stringFormat, formatProvider);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(NumberFormatsToTest))]
        public static void ToStringWithNumberFormats_ShouldEqual_DoubleToString(QuantityValue valueToTest, string stringFormat, string formatProviderName)
        {
            // Arrange
            var doubleValue = valueToTest.ToDouble();
            IFormatProvider formatProvider = FormatProviders[formatProviderName];
            // Act
            var expected = doubleValue.ToString(stringFormat, formatProvider);
            var actual = valueToTest.ToString(stringFormat, formatProvider);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(ScientificFormatsToTest))]
        public static void ToStringWithScientificFormats_ShouldEqual_DoubleToString(QuantityValue valueToTest, string stringFormat, string formatProviderName)
        {
            // Arrange
            var doubleValue = valueToTest.ToDouble();
            IFormatProvider formatProvider = FormatProviders[formatProviderName];
            // Act
            var expected = doubleValue.ToString(stringFormat, formatProvider);
            var actual = valueToTest.ToString(stringFormat, formatProvider);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(CurrencyFormatsToTest))]
        public static void ToStringWithCurrencyFormats_ShouldEqual_DoubleToString(QuantityValue valueToTest, string stringFormat)
        {
            // Arrange
            var doubleValue = valueToTest.ToDouble();
            // Act
            var expected = doubleValue.ToString(stringFormat);
            var actual = valueToTest.ToString(stringFormat);
            // Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [MemberData(nameof(PercentageFormatsToTest))]
        public static void ToStringWithPercentageFormats_ShouldEqual_DoubleToString(QuantityValue valueToTest, string stringFormat)
        {
            // Arrange
            var doubleValue = valueToTest.ToDouble();
            // Act
            var expected = doubleValue.ToString(stringFormat);
            var actual = valueToTest.ToString(stringFormat);
            // Assert
            Assert.Equal(expected, actual);
        }
    }

    /// <summary>
    ///     Contains unit tests for the ToString method of the QuantityValue struct with high precision values.
    /// </summary>
    /// <remarks>
    ///     These tests ensure that the ToString method correctly formats high precision values (such as "G36") in various
    ///     formats (fixed point, number, scientific, and general).
    /// </remarks>
    public class ToStringWithHighPrecisionTests
    {
        [Fact]
        public static void ToStringWithFixedPointFormats_Support_HighPrecision()
        {
            // Arrange
            var a = new BigInteger(123456789987654321);
            BigInteger b = new BigInteger(123456789987654321) * BigInteger.Pow(10, 18);
            BigInteger largeValue = a + b; // should represent the value 123456789987654321123456789987654321
            var valueToTest = new QuantityValue(largeValue, BigInteger.Pow(10, 18)); // place the decimal point in the middle

            // Assert
            Assert.Equal("123456789987654321.12345678998765432", valueToTest.ToString("F17"));
            Assert.Equal("123456789987654321.123456789987654321", valueToTest.ToString("F18"));
            Assert.Equal("123456789987654321.1234567899876543210", valueToTest.ToString("F19"));
        }

        [Fact]
        public static void ToStringWithNumberFormats_Support_HighPrecision()
        {
            // Arrange
            var a = new BigInteger(123456789987654321);
            BigInteger b = new BigInteger(123456789987654321) * BigInteger.Pow(10, 18);
            BigInteger largeValue = a + b; // should represent the value 123456789987654321123456789987654321
            var valueToTest = new QuantityValue(largeValue, BigInteger.Pow(10, 18)); // place the decimal point in the middle

            // Assert
            Assert.Equal("123 456 789 987 654 321.12345678998765432", valueToTest.ToString("N17"));
            Assert.Equal("123 456 789 987 654 321.123456789987654321", valueToTest.ToString("N18"));
            Assert.Equal("123 456 789 987 654 321.1234567899876543210", valueToTest.ToString("N19"));
        }

        [Fact]
        public static void ToStringWithScientificFormats_Support_HighPrecision()
        {
            // Arrange
            var a = new BigInteger(123456789987654321);
            BigInteger b = new BigInteger(123456789987654321) * BigInteger.Pow(10, 18);
            BigInteger largeValue = a + b; // should represent the value 123456789987654321123456789987654321
            var valueToTest = new QuantityValue(largeValue, BigInteger.Pow(10, 18)); // place the decimal point in the middle

            // Assert
            Assert.Equal("1.2345678998765432E+017", valueToTest.ToString("E16"));
            Assert.Equal("1.23456789987654321E+017", valueToTest.ToString("E17"));
            Assert.Equal("1.234567899876543211E+017", valueToTest.ToString("E18"));
            Assert.Equal("1.2345678998765432112345678998765432E+017", valueToTest.ToString("E34"));
            Assert.Equal("1.23456789987654321123456789987654321E+017", valueToTest.ToString("E35"));
            Assert.Equal("1.234567899876543211234567899876543210E+017", valueToTest.ToString("E36"));
        }

        [Fact]
        public static void ToStringWithGeneralFormats_Support_HighPrecision()
        {
            // Arrange
            var a = new BigInteger(123456789987654321);
            BigInteger b = new BigInteger(123456789987654321) * BigInteger.Pow(10, 18);
            BigInteger largeValue = a + b; // should represent the value 123456789987654321123456789987654321
            var valueToTest = new QuantityValue(largeValue, BigInteger.Pow(10, 18)); // place the decimal point in the middle

            // Assert
            Assert.Equal("1.2345678998765432E+17", valueToTest.ToString("G17"));
            Assert.Equal("123456789987654321", valueToTest.ToString("G18"));
            Assert.Equal("123456789987654321.1", valueToTest.ToString("G19"));
            Assert.Equal("123456789987654321.12345678998765432", valueToTest.ToString("G35"));
            Assert.Equal("123456789987654321.123456789987654321", valueToTest.ToString("G36"));
            Assert.Equal("123456789987654321.123456789987654321", valueToTest.ToString("G37"));
        }
    }

    /// <summary>
    ///     Tests for the (custom) 'Sx' format (Significant Digits After Radix)
    /// </summary>
    public class SignificantDigitsAfterRadixFormatTests
    {
        // Due to rounding, the values will result in the same string representation regardless of the number of significant digits (up to a certain point)
        [Theory]
        [InlineData(0.819999999999, "s2", "0.82")]
        [InlineData(0.819999999999, "s4", "0.82")]
        [InlineData(0.00299999999, "s2", "0.003")]
        [InlineData(0.00299999999, "s4", "0.003")]
        [InlineData(0.0003000001, "s2", "3e-04")]
        [InlineData(0.0003000001, "s4", "3e-04")]
        public void RoundingErrorsWithSignificantDigitsAfterRadixFormatting(double value,
            string significantDigitsAfterRadixFormatString, string expected)
        {
            // Arrange
            var quantityValue = QuantityValue.FromDoubleRounded(value);
            // Act
            var actual = quantityValue.ToString(significantDigitsAfterRadixFormatString, AmericanCulture);
            // Assert
            Assert.Equal(expected, actual);
        }

        // Any value in the interval (-inf ≤ x < 1e-03] is formatted in scientific notation
        [Theory]
        [InlineData(double.MinValue, "-1.8e+308")]
        [InlineData(1.23e-120, "1.23e-120")]
        [InlineData(0.0000111, "1.11e-05")]
        [InlineData(1.99e-4, "1.99e-04")]
        public void ScientificNotationLowerInterval(double value, string expected)
        {
            // Arrange
            var quantityValue = QuantityValue.FromDoubleRounded(value);
            // Act
            var actual = quantityValue.ToString("s", AmericanCulture);
            // Assert
            Assert.Equal(expected, actual);
        }

        // Any value in the interval [1e-03 ≤ x < 1e+03] is formatted in fixed point notation.
        [Theory]
        [InlineData(1e-3, "0.001")]
        [InlineData(1.1, "1.1")]
        [InlineData(999.99, "999.99")]
        public void FixedPointNotationIntervalFormatting(double value, string expected)
        {
            // Arrange
            var quantityValue = QuantityValue.FromDoubleRounded(value);
            // Act
            var actual = quantityValue.ToString("s", AmericanCulture);
            // Assert
            Assert.Equal(expected, actual);
        }

        // Any value in the interval [1e+03 ≤ x < 1e+06] is formatted in fixed point notation with digit grouping.
        [Theory]
        [InlineData(1000, "1,000")]
        [InlineData(11000, "11,000")]
        [InlineData(111000, "111,000")]
        [InlineData(999999.99, "999,999.99")]
        public void FixedPointNotationWithDigitGroupingIntervalFormatting(double value, string expected)
        {
            // Arrange
            var quantityValue = QuantityValue.FromDoubleRounded(value);
            // Act
            var actual = quantityValue.ToString("s", AmericanCulture);
            // Assert
            Assert.Equal(expected, actual);
        }

        // Any value in the interval [1e+06 ≤ x ≤ +inf) is formatted in scientific notation.
        [Theory]
        [InlineData(1e6, "1e+06")]
        [InlineData(11100000, "1.11e+07")]
        [InlineData(double.MaxValue, "1.8e+308")]
        public void ScientificNotationUpperIntervalFormatting(double value, string expected)
        {
            // Arrange
            var quantityValue = QuantityValue.FromDoubleRounded(value);
            // Act
            var actual = quantityValue.ToString("s", AmericanCulture);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
