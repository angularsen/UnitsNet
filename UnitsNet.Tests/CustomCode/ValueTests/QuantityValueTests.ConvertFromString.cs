using System.Globalization;
using System.Numerics;
using UnitsNet.Tests.Helpers;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    public static class ConversionFromStringTests
    {
        public class ParsingWithInvariantCulture
        {
            [Theory]
            [InlineData("")]
            [InlineData(" ")]
            [InlineData("  ")]
            [InlineData(null)]
            public void ShouldNotWorkWithNullOrEmptyString(string? valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse!, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData(" 1")]
            [InlineData(" +1")]
            [InlineData(" -1")]
            [InlineData(" 1-")]
            [InlineData(" (1)")]
            public void ShouldNotWorkWithLeadingWhitespaceWhenItIsNotAllowed(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any & ~NumberStyles.AllowLeadingWhite, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("1 ")]
            [InlineData("+1 ")]
            [InlineData("-1 ")]
            [InlineData("1- ")]
            [InlineData("(1) ")]
            public void ShouldNotWorkWithTrailingWhitespaceWhenItIsNotAllowed(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any & ~NumberStyles.AllowTrailingWhite, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("-123456789987654321.123456789987654321")]
            [InlineData("+123456789987654321.123456789987654321")]
            public void ShouldNotWorkWithLeadingSignWhenItIsNotAllowed(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any & ~NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("123456789987654321.123456789987654321-")]
            [InlineData("123456789987654321.123456789987654321+")]
            public void ShouldNotWorkWithTrailingSignWhenItIsNotAllowed(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any & ~NumberStyles.AllowTrailingSign, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("-123456789987654321.123456789987654321-")]
            [InlineData("+123456789987654321.123456789987654321+")]
            [InlineData("+123456789987654321.123456789987654321-")]
            [InlineData("-123456789987654321.123456789987654321+")]
            [InlineData("-3.5+")]
            [InlineData("-(3.5)")]
            [InlineData("(3.5)-")]
            public void ShouldNotWorkWithSignsOnBothSides(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("1.53")]
            [InlineData("-1.53")]
            public void ShouldNotWorkWithDecimalSymbolWhenItIsNotAllowed(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any & ~NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("1 234")]
            [InlineData("-1 234")]
            [InlineData("1 234.5")]
            [InlineData("-1 234.5")]
            public void ShouldNotWorkWithGroupSeparatorWhenItIsNotAllowed(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any & ~NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("123456789987654321.123456789,987654321")]
            [InlineData("123456789987654321.,123456789987654321")]
            public void ShouldNotWorkWithGroupsInTheMiddle(string valueToParse)
            {
                Assert.False(double.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _), "The format isn't supposed to be recognized by double.TryParse");
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("123456789987654321.-123456789987654321")]
            [InlineData("123456789987654321-.123456789987654321")]
            [InlineData("123456789987654321.+123456789987654321")]
            [InlineData("123456789987654321+.123456789987654321")]
            public void ShouldNotWorkWithSignsInTheMiddle(string valueToParse)
            {
                Assert.False(double.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _), "The format isn't supposed to be recognized by double.TryParse");
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("(1)")]
            [InlineData(" (1) ")]
            [InlineData("-(1)")]
            [InlineData("(-1)")]
            [InlineData("+(1)")]
            [InlineData("(1)+")]
            [InlineData("(1 234)")]
            [InlineData("(1234.5)")]
            public void ShouldNotWorkWithParenthesesWhenItIsNotAllowed(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any & ~NumberStyles.AllowParentheses, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("(")]
            [InlineData("1(")]
            [InlineData("1)")]
            [InlineData(")1")]
            [InlineData("¤(")]
            [InlineData("¤(.")]
            [InlineData(")")]
            [InlineData("(1")]
            [InlineData(" 1) ")]
            [InlineData("-1)")]
            [InlineData("- 1)")]
            [InlineData("+1)")]
            [InlineData("-(1")]
            [InlineData("(1-")]
            [InlineData("+(1-")]
            [InlineData("(1 234")]
            [InlineData("(1234.5")]
            public void ShouldNotWorkWithParenthesesOnOneSide(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("(1(")]
            [InlineData("((1")]
            [InlineData(")1)")]
            [InlineData("1))")]
            [InlineData("((1))")]
            [InlineData("(())")]
            public void ShouldNotWorkWithMultipleParenthesesOnEitherSide(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData(" ")]
            [InlineData(".")]
            [InlineData(" .")]
            [InlineData(". ")]
            [InlineData("-")]
            [InlineData("+")]
            [InlineData(" .-")]
            [InlineData("+.")]
            [InlineData("+. ")]
            [InlineData("()")]
            [InlineData("(.)")]
            [InlineData("-(.) ")]
            [InlineData("+(.)")]
            [InlineData("(.)-")]
            [InlineData("¤()")]
            public void ShouldNotWorkWithoutDigits(string valueToParse)
            {
                Assert.False(double.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _), "The format isn't supposed to be recognized by double.TryParse");
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("1x2")]
            [InlineData("1.x2")]
            [InlineData("x1.2")]
            [InlineData("1.2x")]
            [InlineData("1.2x-")]
            [InlineData("-1.2x")]
            public void ShouldNotWorkWithInvalidCharactersInTheString(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Fact]
            public void Parsing_NaN_or_Infinity_ShouldReturnTheExpectedResult()
            {
                Assert.Equal(QuantityValue.NaN, QuantityValue.Parse("NaN", CultureInfo.InvariantCulture));
                Assert.Equal(QuantityValue.PositiveInfinity, QuantityValue.Parse("Infinity", CultureInfo.InvariantCulture));
                Assert.Equal(QuantityValue.NegativeInfinity, QuantityValue.Parse("-Infinity", CultureInfo.InvariantCulture));
            }

            [Theory]
            [ClassData(typeof(ValidDecimalStringCases))]
            public void ShouldReturnTheExpectedValueWhenTheStringIsValid(string valueToParse, QuantityValueData expectedResult)
            {
                Assert.True(double.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _), "The format is also recognized by double.TryParse");
                var result = QuantityValue.Parse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture);
                Assert.Equal(expectedResult.Value, result);
            }

            public class ValidDecimalStringCases : TheoryData<string, QuantityValueData>
            {
                public ValidDecimalStringCases()
                {
                    // Zero
                    AddZeroCases();
                    // +42 without a decimal separator
                    AddPositiveIntegerCases();
                    // -5 without a decimal separator
                    AddNegativeIntegerCases();
                    // Negative decimals
                    AddNegativeDecimalCases();
                    // Negative integers that also contain a decimal point
                    AddNegativeIntegerWithDecimalSeparatorCases();
                    // 0.1 written as "-.1" (and other sign variants)
                    AddPositiveDecimalWithoutLeadingZeroCases();
                    // -0.1 written as "-.1" (and other sign variants)
                    AddNegativeDecimalWithoutLeadingZeroCases();
                }

                private void AddZeroCases()
                {
                    QuantityValueData zero = QuantityValue.Zero;
                    Add("0", zero);
                    Add("0.", zero);
                    Add(".0", zero);
                    Add("000000000000000000.0000000000000000000", zero);
                    Add("-000000000000000000.0000000000000000000", zero);
                }

                private void AddPositiveIntegerCases()
                {
                    QuantityValueData quantityValueData = 42;
                    Add("42", quantityValueData);
                    Add(" 42 ", quantityValueData);
                    Add("+42", quantityValueData);
                    Add(" +42", quantityValueData);
                    Add("42+", quantityValueData);
                    Add("42+ ", quantityValueData);
                    Add(" 42+ ", quantityValueData);
                    Add(" 42 + ", quantityValueData); // any spaces before or after the trailing sign are ok
                }

                private void AddNegativeIntegerCases()
                {
                    QuantityValueData expectedValue = -5;
                    Add("-5", expectedValue);
                    Add("5-", expectedValue);
                    Add(" -5", expectedValue);
                    Add("5- ", expectedValue);
                    Add("5 - ", expectedValue); // any spaces before or after the trailing sign are ok 
                    Add("(5)", expectedValue);
                    Add(" (5)", expectedValue);
                    Add(" (5) ", expectedValue);
                }

                private void AddNegativeDecimalCases()
                {
                    QuantityValueData expectedValue = new QuantityValue(BigInteger.Parse("-123456789987654321123456789987654321"), BigInteger.Pow(10, 18));
                    Add("-123456789987654321.1234567899876543210", expectedValue);
                    Add("123456789987654321.1234567899876543210-", expectedValue);
                    Add("1234,56789987654321.1234567899876543210-", expectedValue);
                    Add("(1234,56789987654321.1234567899876543210)", expectedValue);
                    Add(" (1234,56789987654321.1234567899876543210)", expectedValue);
                    Add(" (1234,56789987654321.1234567899876543210) ", expectedValue);
                    Add(" (1234,56789987654321.1234567899876543210 ) ", expectedValue);
                }

                private void AddNegativeIntegerWithDecimalSeparatorCases()
                {
                    QuantityValueData expectedValue = new QuantityValue(BigInteger.Parse("-123456789987654321"));
                    Add("-123456789987654321.0", expectedValue);
                    Add("123456789987654321.0-", expectedValue);
                    Add("1234,56789987654321.0-", expectedValue);
                    Add("-123456789987654321.", expectedValue);
                    Add("123456789987654321.-", expectedValue);
                    Add("1234,56789987654321.-", expectedValue);
                    Add("(1234,56789987654321.)", expectedValue);
                    Add(" (1234,56789987654321.)", expectedValue);
                    Add(" (1234,56789987654321.) ", expectedValue);
                    Add(" (1234,56789987654321. ) ", expectedValue);
                }

                private void AddPositiveDecimalWithoutLeadingZeroCases()
                {
                    var expectedValue = new QuantityValue(1, 10);
                    Add(".10", expectedValue);
                    Add(" .10", expectedValue);
                    Add(".10 ", expectedValue);
                    Add("+.10", expectedValue);
                    Add(".10+", expectedValue);
                    Add(" +.10", expectedValue);
                    Add(".10+ ", expectedValue);
                }

                private void AddNegativeDecimalWithoutLeadingZeroCases()
                {
                    var expectedValue = new QuantityValue(-1, 10);
                    Add("-.10", expectedValue);
                    Add(".10-", expectedValue);
                    Add(" -.10", expectedValue);
                    Add(".10- ", expectedValue);
                    Add("(.10)", expectedValue);
                    Add(" (.10)", expectedValue);
                    Add(" (.10) ", expectedValue);
                }
            }
        }

        public class ParsingWithScientificNotation
        {
            [Theory]
            [InlineData("1.23456789987654321E+41.5")]
            [InlineData("1.23456789987654321e+41.5")]
            [InlineData("-1.23456789987654321E+41.5")]
            [InlineData("-1.23456789987654321e+41.5")]
            public void Parsing_StringWithDecimalExponent_ShouldThrow_FormatException(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("1.2345+9876+E5")]
            [InlineData("1.2345-9876+E5")]
            [InlineData("1.2345+9876-E5")]
            [InlineData("1.2345-9876-E5")]
            public void Parsing_StringWithSignInTheMiddle_ShouldThrow_FormatException(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("1.23456789,987654321E-24")]
            [InlineData("1.23456789,987654321e-24")]
            [InlineData("-1.23456789,987654321E-24")]
            [InlineData("-1.23456789,987654321e-24")]
            public void Parsing_StringWithGroupInTheMiddle_ShouldThrow_FormatException(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("1.2345E")]
            [InlineData("1.2345e")]
            public void Parsing_StringWithNothingAfterTheExponent_ShouldThrow_FormatException(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData(".E1")]
            [InlineData(".e1")]
            public void Parsing_StringWithNothingBeforeTheExponent_ShouldThrow_FormatException(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("1.5E3")]
            [InlineData("1.5e3")]
            public void Parsing_ExponentStringWithDecimalSeparator_With_NumberStyle_ExcludingDecimals_ShouldThrow_FormatException(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Any & ~NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out _));
            }

            [Fact]
            public void Parsing_ExponentStringWithoutDecimalSeparator_With_NumberStyle_ExcludingDecimals_ShouldReturnTheExpectedResult()
            {
                var result = QuantityValue.Parse("1e3", NumberStyles.Any & ~ NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
                Assert.Equal(1e3, result);
            }

            [Theory]
            [ClassData(typeof(ValidExponentialStringCases))]
            public void Parsing_ExponentString_With_NumberStyle_Number_ShouldThrow_FormatException(string valueToParse, QuantityValueData _)
            {
                Assert.Throws<FormatException>(() => QuantityValue.Parse(valueToParse, NumberStyles.Number, CultureInfo.InvariantCulture));
            }

            [Theory]
            [ClassData(typeof(ValidExponentialStringCases))]
            public void Parsing_ValidExponentString_ShouldReturnTheExpectedResult(string valueToParse, QuantityValueData expectedResult)
            {
                Assert.True(double.TryParse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture, out _), "The format is also recognized by double.TryParse");
                var result = QuantityValue.Parse(valueToParse, NumberStyles.Any, CultureInfo.InvariantCulture);
                Assert.Equal(expectedResult.Value, result);
            }

            public class ValidExponentialStringCases : TheoryData<string, QuantityValueData>
            {
                public ValidExponentialStringCases()
                {
                    AddPositiveIntegerCases();
                    AddNegativeIntegerCases();
                    AddLargePositiveCases();
                    AddLargeNegativeCases();
                    AddSmallPositiveCases();
                    AddSmallNegativeCases();
                }

                private void AddPositiveIntegerCases()
                {
                    QuantityValueData expectedValue = new QuantityValue(new BigInteger(123456789987654321) * BigInteger.Pow(10, 5));
                    Add("123456789987654321E+5", expectedValue);
                    Add("123456789987654321e+5", expectedValue);
                }

                private void AddNegativeIntegerCases()
                {
                    QuantityValueData expectedValue = new QuantityValue(new BigInteger(-123456789987654321) * BigInteger.Pow(10, 5));
                    Add("-123456789987654321E+5", expectedValue);
                    Add("-123456789987654321e+5", expectedValue);
                }

                private void AddLargePositiveCases()
                {
                    QuantityValueData expectedValue = new QuantityValue(new BigInteger(123456789987654321) * BigInteger.Pow(10, 24));
                    Add("1.23456789987654321E+41", expectedValue);
                    Add("1.23456789987654321e+41", expectedValue);
                    Add("1.234567899876543210E+41", expectedValue);
                    Add("1.234567899876543210e+41", expectedValue);
                }

                private void AddLargeNegativeCases()
                {
                    QuantityValueData expectedValue = new QuantityValue(new BigInteger(-123456789987654321) * BigInteger.Pow(10, 24));
                    Add("-1.23456789987654321E+41", expectedValue);
                    Add("-1.23456789987654321e+41", expectedValue);
                    Add("-1.234567899876543210E+41", expectedValue);
                    Add("-1.234567899876543210e+41", expectedValue);
                }

                private void AddSmallPositiveCases()
                {
                    QuantityValueData expectedValue = new QuantityValue(new BigInteger(123456789987654321), BigInteger.Pow(10, 41));
                    Add("1.23456789987654321E-24", expectedValue);
                    Add("1.23456789987654321e-24", expectedValue);
                    Add("1.234567899876543210E-24", expectedValue);
                    Add("1.234567899876543210e-24", expectedValue);
                    Add("1.23456789987654321E-24+", expectedValue);
                    Add("1.23456789987654321e-24+", expectedValue);
                    Add("1.234567899876543210E-24+", expectedValue);
                    Add("1.234567899876543210e-24+", expectedValue);
                    Add("12345.6789987654321E-28", expectedValue);
                    Add("12345.6789987654321e-28", expectedValue);
                    Add("12345.67899876543210E-28", expectedValue);
                    Add("12345.67899876543210e-28", expectedValue);
                    Add("12,345.6789987654321E-28", expectedValue);
                    Add("12,345.6789987654321e-28", expectedValue);
                    Add("12,345.67899876543210E-28", expectedValue);
                    Add("12,345.67899876543210e-28", expectedValue);
                }

                private void AddSmallNegativeCases()
                {
                    QuantityValueData expectedValue = new QuantityValue(new BigInteger(-123456789987654321), BigInteger.Pow(10, 41));
                    Add("-1.23456789987654321E-24", expectedValue);
                    Add("-1.23456789987654321e-24", expectedValue);
                    Add("-1.234567899876543210E-24", expectedValue);
                    Add("-1.234567899876543210e-24", expectedValue);
                }
            }
        }

        public class ParsingWithHexNotation
        {
            [Theory]
            [InlineData("2A")]
            public void ShouldNotWorkWhenParsingAsNumber(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.Number, CultureInfo.InvariantCulture, out _));
            }

            [Theory]
            [InlineData("2A")]
            [InlineData("2A ")]
            [InlineData(" 2A")]
            [InlineData(" 2A ")]
            public void TheResultShouldBe42WhenParsingAsHex(string valueToParse)
            {
                var expectedValue = new QuantityValue(42);
                var result = QuantityValue.Parse(valueToParse, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                Assert.Equal(expectedValue, result);
            }

            [Theory]
            [InlineData("2 A")]
            public void ShouldNotWorkWithSpacesInTheMiddle(string valueToParse)
            {
                Assert.False(QuantityValue.TryParse(valueToParse, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out _));
            }
        }

        public class ParsingWithCurrencySymbol
        {
            [Theory]
            [InlineData("€3,5")]
            [InlineData("€ 3,5")]
            [InlineData("€3,5 ")]
            [InlineData("€+3,5")]
            [InlineData("€ +3,5")]
            [InlineData("€+3,5 ")]
            [InlineData("+€3,5")]
            [InlineData("€3,5+")]
            [InlineData("€3,5+ ")]
            [InlineData("€3,5 + ")]
            [InlineData(" €3,5 + ")]
            [InlineData("€ 3,5+")]
            [InlineData(" € 3,5+")]
            [InlineData(" € 3,5 +")]
            [InlineData(" € 3,5 + ")]
            [InlineData("3,5€")]
            [InlineData(" 3,5€")]
            [InlineData("3,5 € ")]
            [InlineData("+3,5€")]
            [InlineData(" +3,5€")]
            [InlineData("+3,5 €")]
            [InlineData(" +3,5 €")]
            [InlineData(" +3,5 € ")]
            [InlineData("3,5€+")]
            [InlineData(" 3,5€+")]
            [InlineData("3,5 €+ ")]
            [InlineData("3,5 € + ")]
            [InlineData(" 3,5 € + ")]
            [InlineData("3,5 €+")]
            [InlineData(" 3,5€ +")]
            [InlineData(" 3,5+ €")]
            [InlineData(" 3,5 + € ")]
            [InlineData("€+ 3,5")]
            [InlineData("+€ 3,5")]
            [InlineData(" € + 3,5")]
            [InlineData(" +€ 3,5")]
            public void Parsing_ValidCurrencyString_ShouldReturnTheExpectedResult(string value)
            {
                var germanCulture = CultureInfo.GetCultureInfo("de-DE");
                Assert.True(double.TryParse(value, NumberStyles.Any, germanCulture, out _), "making sure the format is also recognized by double.TryParse");
                var result = QuantityValue.Parse(value, NumberStyles.Any, germanCulture);
                Assert.Equal(new QuantityValue(35, 10), result);
            }

            [Theory]
            [InlineData("-€3,5")]
            [InlineData("€3,5-")]
            [InlineData("€3,5- ")]
            [InlineData("€3,5 - ")]
            [InlineData(" €3,5 - ")]
            [InlineData("€ 3,5-")]
            [InlineData(" € 3,5-")]
            [InlineData(" € 3,5 -")]
            [InlineData(" € 3,5 - ")]
            [InlineData("-3,5€")]
            [InlineData(" -3,5€")]
            [InlineData("-3,5 €")]
            [InlineData(" -3,5 €")]
            [InlineData(" -3,5 € ")]
            [InlineData("3,5€-")]
            [InlineData(" 3,5€-")]
            [InlineData("3,5 €- ")]
            [InlineData("3,5 € - ")]
            [InlineData(" 3,5 € - ")]
            [InlineData("3,5 €-")]
            [InlineData(" 3,5€ -")]
            [InlineData(" 3,5- €")]
            [InlineData(" 3,5 - € ")]
            [InlineData("€- 3,5")]
            [InlineData("-€ 3,5")]
            [InlineData(" € - 3,5")]
            [InlineData(" -€ 3,5")]
            [InlineData("€ (3,5)")] // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
            [InlineData("(€ 3,5)")] // any number of white-spaces are allowed following a leading currency symbol (but no other signs)
            public void Parsing_NegativeCurrencyString_ShouldReturnTheExpectedResult(string value)
            {
                var germanCulture = CultureInfo.GetCultureInfo("de-DE");
                Assert.True(double.TryParse(value, NumberStyles.Any, germanCulture, out _), "making sure the format is also recognized by double.TryParse");
                var result = QuantityValue.Parse(value, NumberStyles.Any, germanCulture);
                Assert.Equal(new QuantityValue(-35, 10), result);
            }

            [Theory]
            [InlineData("+ 3,5€")]
            [InlineData("+ €3,5")]
            [InlineData("+ € 3,5")]
            [InlineData("- 3,5€")]
            [InlineData("- €3,5")]
            [InlineData("- € 3,5")] // this one is peculiar: any spaces after the leading sign are rejected (as long as there isn't a currency symbol preceding it)
            public void Parsing_WithInvalidSpaces_ShouldNotWork(string value)
            {
                var germanCulture = CultureInfo.GetCultureInfo("de-DE");
                Assert.False(double.TryParse(value, NumberStyles.Any, germanCulture, out _), "the format isn't supposed to be recognized by double.TryParse");
                Assert.False(QuantityValue.TryParse(value, NumberStyles.Any, germanCulture, out _));
            }

            [Theory]
            [InlineData("€3,5€")]
            [InlineData("€+3,5€")]
            [InlineData("+€3,5€")]
            [InlineData("€3,5€+")]
            [InlineData("€3,5+€")]
            [InlineData("€-3,5€")]
            [InlineData("-€3,5€")]
            [InlineData("€3,5€-")]
            [InlineData("€3,5-€")]
            [InlineData("(€")]
            public void Parsing_WithMultipleCurrencySymbols_ShouldNotWork(string value)
            {
                var germanCulture = CultureInfo.GetCultureInfo("de-DE");
                Assert.False(double.TryParse(value, NumberStyles.Any, germanCulture, out _), "the format isn't supposed to be recognized by double.TryParse");
                Assert.False(QuantityValue.TryParse(value, germanCulture, out _));
            }

            [Fact]
            public void Parsing_CurrencyStringWithMultiCharacterSymbol_ShouldReturnTheExpectedResult()
            {
                var customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                customCulture.NumberFormat.CurrencySymbol = "EUR";
                Assert.False(QuantityValue.TryParse("(1", NumberStyles.Any, customCulture, out _));
            }

            [Fact]
            public void Parsing_WithCurrency_WhenTheCurrencyParsingIsDisabled_ShouldNotWork()
            {
                var germanCulture = CultureInfo.GetCultureInfo("de-DE");
                Assert.False(QuantityValue.TryParse("1€", NumberStyles.Any & ~NumberStyles.AllowCurrencySymbol, germanCulture, out _));
            }

            public class ParsingWithDefaultCulture
            {
                [Fact]
                public void Parsing_NaN_or_InfinitySymbol_WithGermanCulture_ShouldReturnTheExpectedValue()
                {
                    var formatProvider = CultureInfo.GetCultureInfo("de-DE");
                    Assert.Equal(QuantityValue.NaN, QuantityValue.Parse("NaN", formatProvider));
                    Assert.Equal(QuantityValue.PositiveInfinity, QuantityValue.Parse("∞", formatProvider));
                    Assert.Equal(QuantityValue.NegativeInfinity, QuantityValue.Parse("-∞", formatProvider));
                }

                [Fact]
                public void TryParse_WithValidString_ShouldReturnTheExpectedValue()
                {
                    using var _ = new CultureScope("de-DE");
                    Assert.True(QuantityValue.TryParse("123,45", null, out var result));
                    Assert.Equal(new QuantityValue(12345, 100), result);
                }

                [Fact]
                public void TryParse_WithInvalidString_ShouldReturnFalse()
                {
                    using var _ = new CultureScope("de-DE");
                    Assert.False(QuantityValue.TryParse("12 345", null, out var _));
                }

#if NET
                [Fact]
                public void Parse_ReadOnlySpan_WithValidString_ShouldReturnTheExpectedValue()
                {
                    using var _ = new CultureScope("de-DE");
                    ReadOnlySpan<char> input = "123,45";
                    var result = QuantityValue.Parse(input, null);
                    Assert.Equal(new QuantityValue(12345, 100), result);
                }

                [Fact]
                public void Parse_ReadOnlySpan_WithInvalidString_ShouldThrow_FormatException()
                {
                    using var _ = new CultureScope("de-DE");
                    Assert.Throws<FormatException>(() => QuantityValue.Parse("12 345".AsSpan(), null));
                }

                [Fact]
                public void TryParse_ReadOnlySpan_WithValidString_ShouldReturnTheExpectedValue()
                {
                    using var _ = new CultureScope("de-DE");
                    ReadOnlySpan<char> input = "123,45";
                    Assert.True(QuantityValue.TryParse(input, null, out var result));
                    Assert.Equal(new QuantityValue(12345, 100), result);
                }

                [Fact]
                public void TryParse_ReadOnlySpan_WithInvalidString_ShouldReturnFalse()
                {
                    using var _ = new CultureScope("de-DE");
                    Assert.False(QuantityValue.TryParse("12 345".AsSpan(), null, out var _));
                }
#endif
            }

            public class ParsingWithCustomCulture
            {
                [Fact]
                public void Parsing_WithCustomizedCulture_RespectsTheCultureFormat()
                {
                    // Arrange
                    var customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                    customCulture.NumberFormat.NegativeSign = "_minus_";
                    customCulture.NumberFormat.NumberGroupSeparator = "_group_";
                    customCulture.NumberFormat.NumberDecimalSeparator = "_decimal_";
                    var valueToParse = "_minus_1_group_234_decimal_56";
                    QuantityValue expectedValue = -1234.56m;

                    // Act
                    var parsedValue = QuantityValue.Parse(valueToParse, NumberStyles.Number, customCulture);

                    // Assert
                    Assert.Equal(expectedValue, parsedValue);
                }

                [Fact]
                public void Parsing_NaN_or_InfinitySymbol_WithCustomCulture_ShouldReturnTheExpectedValue()
                {
                    // Arrange
                    var customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                    customCulture.NumberFormat.NaNSymbol = "Q";
                    customCulture.NumberFormat.PositiveInfinitySymbol = "P";
                    customCulture.NumberFormat.NegativeInfinitySymbol = "N";
                    Assert.Equal(QuantityValue.NaN, QuantityValue.Parse("Q", customCulture));
                    Assert.Equal(QuantityValue.PositiveInfinity, QuantityValue.Parse("P", customCulture));
                    Assert.Equal(QuantityValue.NegativeInfinity, QuantityValue.Parse("N", customCulture));
                }

                [Fact]
                public void Parsing_CurrencyStringWithCustomCultureWithoutCurrencySymbol_ShouldNotWork()
                {
                    // Arrange
                    var customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                    customCulture.NumberFormat.CurrencySymbol = string.Empty;
                    Assert.False(QuantityValue.TryParse("1.5€", NumberStyles.Any, customCulture, out _));
                }

                [Fact]
                public void NumberFormat_WithEmptyDecimalSeparator_ThrowsArgumentException()
                {
                    var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                    Assert.Throws<ArgumentException>(() => formatProvider.NumberFormat.NumberDecimalSeparator = string.Empty);
                    Assert.Equal("1", formatProvider.NumberFormat.NumberDecimalSeparator = "1");
                }
            }
        }
    }
}
