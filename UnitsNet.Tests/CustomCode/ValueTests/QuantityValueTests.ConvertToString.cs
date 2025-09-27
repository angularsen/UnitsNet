using System.Globalization;
using System.Linq;
using System.Numerics;
using Xunit.Abstractions;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    public class ConvertToStringTests
    {
        internal static readonly QuantityValueData[] TerminatingFractions =
        [
            0, 1, -1, 10, -10, 100, -100, 1000, -1000, 10000, -10000, 100000, -100000,
            0.1m, -0.1m, 0.2m, -0.2m, 0.5m, -0.5m, 1.2m, -1.2m, 1.5m, -1.5m, 1.95m, -1.95m, 2.5m, -2.5m,
            2.001234m, -2.001234m, // rounds to 2
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
            1554566.5434654m, -1554566.5434654m,
            new QuantityValue(10, 20), new QuantityValue(-10, 20),
            // 128 in binary is 10000000, so its bit length is 8. 1400 is between 2^10 (1024) and 2^11 (2048), so its bit length is 11.
            new QuantityValue(128, 1400), new QuantityValue(-128, 1400), 
        ];

        internal static readonly QuantityValueData[] NonTerminatingFractions =
        [
            new QuantityValue(1, 3), new QuantityValue(-1, 3),
            new QuantityValue(2, 3), new QuantityValue(-2, 3),
            new QuantityValue(19999991, 3),
            new QuantityValue(-19999991, 3), // note: for all but the percent (P) format we could be using two more digits ('99')
            new QuantityValue(20000001, 3),
            new QuantityValue(-20000001, 3), // note: for all but the percent (P) format we could be using two more digits ('00')
            new QuantityValue(4, 3), new QuantityValue(-4, 3),
            new QuantityValue(5, 3), new QuantityValue(-5, 3),
            new QuantityValue(7, 3), new QuantityValue(-7, 3)
        ];
        
        /// <summary>
        ///     Represents a pair consisting of a <see cref="QuantityValue" /> and its associated format string.
        /// </summary>
        /// <remarks>
        ///     This class is primarily used in unit tests to validate the behavior of <see cref="QuantityValue" />
        ///     when formatted as a string using specific format strings.
        ///     It also implements <see cref="IXunitSerializable" /> to facilitate serialization and deserialization
        ///     of test data for xUnit test cases.
        /// </remarks>
        public class ValueFormatPair : IXunitSerializable
        {
            private QuantityValueData _value;

            public ValueFormatPair(QuantityValueData value, string format)
            {
                _value = value;
                Format = format;
            }

            public QuantityValue Value
            {
                get => _value;
                private set => _value = value;
            }

            public string Format { get; private set; }

            public void Deconstruct(out QuantityValue value, out string format)
            {
                value = Value;
                format = Format;
            }

            public override string ToString()
            {
                var fraction = Value;
                return $"{fraction.Numerator}/{fraction.Denominator} : {Format}";
            }

            #region Implementation of IXunitSerializable

            public ValueFormatPair()
            {
                _value = null!;
                Format = null!;
            }

            public void Serialize(IXunitSerializationInfo info)
            {
                info.AddValue("v1", _value);
                info.AddValue("v2", Format);
            }

            public void Deserialize(IXunitSerializationInfo info)
            {
                Value = info.GetValue<QuantityValueData>("v1");
                Format = info.GetValue<string>("v2");
            }

            #endregion
        }

        /// <summary>
        ///     The general ("G") format specifier converts a number to the more compact of either fixed-point or scientific
        ///     notation, depending on the type of the number and whether a precision specifier is present. The precision specifier
        ///     defines the maximum number of significant digits that can appear in the result string. If the precision specifier
        ///     is omitted or zero, the type of the number determines the default precision.
        /// </summary>
        public class GeneralFormatTests
        {
            private static readonly string[] GeneralFormats = ["G1", "G2", "G3", "G4", "G5", "G6", "g1", "g6", "G27"];

            [Theory]
            [ClassData(typeof(TerminatingFractionCases))]
            public void ToString_WithTerminatingFraction(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format);
                Assert.Equal(expected, result);
            }

            [Theory]
            [ClassData(typeof(NonTerminatingFractionCases))]
            public void ToString_WithNonTerminatingFraction(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format);
                Assert.Equal(expected, result);
            }

            [Fact]
            public void ToString_WithoutFormatSpecifier()
            {
                var value = new QuantityValue(1, 3);
#if NET
                Assert.Equal(value.ToString("G16", CultureInfo.CurrentCulture), value.ToString("G"));
#else
                Assert.Equal(value.ToString("G15", CultureInfo.CurrentCulture), value.ToString("G"));
#endif
                Assert.Equal(value.ToString("G", CultureInfo.CurrentCulture), value.ToString("G0", null));
            }

            #if NET
        
            [Fact]
            public void TryFormat_Zero_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = 0;
                var destination = new Span<char>(new char[1]);
                var result = value.TryFormat(destination, out var charsWritten, "G", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(1, charsWritten);
                Assert.Equal("0", destination[Range.EndAt(charsWritten)]);
            }
        
            [Fact]
            public void TryFormat_WithG0AndValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = 123.456m;
                var destination = new Span<char>(new char[10]);
                var result = value.TryFormat(destination, out var charsWritten, "G0", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(7, charsWritten);
                Assert.Equal("123.456", destination[Range.EndAt(charsWritten)]);
            }
        
            [Fact]
            public void TryFormat_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = 123.456m;
                var destination = new Span<char>(new char[10]);
                var result = value.TryFormat(destination, out var charsWritten, "G", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(7, charsWritten);
                Assert.Equal("123.456", destination[Range.EndAt(charsWritten)]);
            }

            [Theory]
            [InlineData(123400, "G6", 5)]
            [InlineData(123400, "G1", 0)]
            [InlineData(123400, "G2", 0)]
            [InlineData(123400, "G2", 1)]
            [InlineData(123400, "G2", 3)]
            [InlineData(123.456, "G2", 4)]
            [InlineData(123.456, "G2", 5)]
            [InlineData(0.000123, "G5", 5)]
            public void TryFormat_WithInvalidSpanLength_ReturnsFalse(decimal decimalValue, string format, int testLength)
            {
                QuantityValue value = decimalValue;
                var destination = new Span<char>(new char[testLength]);
                var result = value.TryFormat(destination, out var charsWritten, format, CultureInfo.InvariantCulture);
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
            }

            [Theory]
            [InlineData(-1234, -10, "G1", 0)]
            [InlineData(-1234, -10, "G2", 3)]
            [InlineData(-1234, -10, "G2", 4)]
            [InlineData(-1234, -10, "G2", 5)]
            [InlineData(-1234, -10, "G20", 1)]
            [InlineData(-1234, -10, "G20", 2)]
            [InlineData(-1234, -10, "G20", 5)]
            [InlineData(1, -1000, "G1", 2)]
            public void TryFormat_FromPowerOfTen_WithInvalidSpanLength_ReturnsFalse(int number, int powerOfTen, string format, int testLength)
            {
                var value = QuantityValue.FromPowerOfTen(number, powerOfTen);
                var destination = new Span<char>(new char[testLength]);
                var result = value.TryFormat(destination, out var charsWritten, format, CultureInfo.InvariantCulture);
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
            }
            
            #endif

            public sealed class TerminatingFractionCases : TheoryData<ValueFormatPair, string>
            {
                public TerminatingFractionCases()
                {
                    foreach (var value in TerminatingFractions)
                    {
                        foreach (var format in GeneralFormats)
                        {
                            Add(new ValueFormatPair(value, format), value.Value.ToDecimal().ToString(format));
                        }
                    }
                }
            }

            public sealed class NonTerminatingFractionCases : TheoryData<ValueFormatPair, string>
            {
                public NonTerminatingFractionCases()
                {
                    foreach (var value in NonTerminatingFractions)
                    {
                        foreach (var format in GeneralFormats)
                        {
                            Add(new ValueFormatPair(value, format), value.Value.ToDecimal().ToString(format));
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     The fixed-point ("F") format specifier converts a number to a string of the form "-ddd.ddd…" where each "d"
        ///     indicates a digit (0-9). The string starts with a minus sign if the number is negative.
        ///     The precision specifier indicates the desired number of decimal places. If the precision specifier is omitted, the
        ///     current NumberFormatInfo.NumberDecimalDigits property supplies the numeric precision.
        /// </summary>
        public class FixedPointFormatTests
        {
            private static readonly string[] FixedPointFormats = ["F", "F0", "F1", "F2", "F3", "F4", "F5", "F6", "F27"];

            [Theory]
            [ClassData(typeof(TerminatingFractionCases))]
            public void ToString_WithTerminatingFraction(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format);
                Assert.Equal(expected, result);
            }

            public sealed class TerminatingFractionCases : TheoryData<ValueFormatPair, string>
            {
                public TerminatingFractionCases()
                {
                    foreach (var value in TerminatingFractions)
                    {
                        foreach (var format in FixedPointFormats)
                        {
                            Add(new ValueFormatPair(value, format), value.Value.ToDecimal().ToString(format));
                        }
                    }
                }
            }

            [Fact]
            public void ToString_F250_ReturnsTheExpectedResult()
            {
                QuantityValue value = 4.2;
                var expected = "4.2" + new string(Enumerable.Repeat('0', 249).ToArray());

                var result = value.ToString("F250", CultureInfo.InvariantCulture);

                Assert.Equal(expected, result);
            }

#if NET
            [Fact]
            public void TryFormat_Zero_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = 0;
                var destination = new Span<char>(new char[4]);
                var result = value.TryFormat(destination, out var charsWritten, "F2", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(4, charsWritten);
                Assert.Equal("0.00", destination[Range.EndAt(charsWritten)]);
            }

            [Fact]
            public void TryFormat_NegativeInteger_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = -42;
                var destination = new Span<char>(new char[6]);
                var result = value.TryFormat(destination, out var charsWritten, "F2", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(6, charsWritten);
                Assert.Equal("-42.00", destination[Range.EndAt(charsWritten)]);
            }

            [Fact]
            public void TryFormat_NegativeDecimal_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = -4.2;
                var destination = new Span<char>(new char[5]);
                var result = value.TryFormat(destination, out var charsWritten, "F2", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(5, charsWritten);
                Assert.Equal("-4.20", destination[Range.EndAt(charsWritten)]);
            }

            [Theory]
            [InlineData(-123.4, "F1", 0)]
            [InlineData(-123.4, "F1", 4)]
            [InlineData(-123.4, "F1", 5)]
            [InlineData(-123.4, "F20", 3)]
            [InlineData(-123.4, "F20", 4)]
            [InlineData(-123.4, "F20", 5)]
            public void TryFormat_Decimal_WithInvalidSpanLength_ReturnsFalse(decimal decimalValue, string format, int testLength)
            {
                QuantityValue value = decimalValue;
                var destination = new Span<char>(new char[testLength]);
                var result = value.TryFormat(destination, out var charsWritten, format, CultureInfo.InvariantCulture);
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
            }

            [Fact]
            public void TryFormat_PreciseDecimal_WithInvalidSpanLength_ReturnsFalse()
            {
                // 1e-20: should return 22 characters: "0.000..1"
                var value = QuantityValue.FromPowerOfTen(1, 1, -20);
                var destination = new Span<char>(new char[21]);
                var result = value.TryFormat(destination, out var charsWritten, "F20", CultureInfo.InvariantCulture);
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
                
            }
#endif
        }

        /// <summary>
        ///     The numeric ("N") format specifier converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-" indicates
        ///     a negative number symbol if required, "d" indicates a digit (0-9), "," indicates a group separator, and "."
        ///     indicates a decimal point symbol. The precision specifier indicates the desired number of digits after the decimal
        ///     point. If the precision specifier is omitted, the number of decimal places is defined by the current
        ///     NumberFormatInfo.NumberDecimalDigits property.
        /// </summary>
        public class NumericFormatTests
        {
            private static readonly string[] NumberFormats = ["N", "N0", "N1", "N2", "N3", "N4", "N5", "N6"];

            private static readonly int[] NumberNegativePatterns =
            [
                0, // (n)
                1, // -n
                2, // - n
                3, // n-
                4 // n -
            ];

            [Fact]
            public void NumberFormat_WithInvalidNumberNegativePatterns_ThrowsArgumentOutOfRangeException()
            {
                var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                var numberFormat = formatProvider.NumberFormat;
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.NumberNegativePattern = -1);
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.NumberNegativePattern = 5);
            }

            [Fact]
            public void NumberFormat_WithInvalidNumberDecimalDigits_ThrowsArgumentOutOfRangeException()
            {
                var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                var numberFormat = formatProvider.NumberFormat;
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.NumberDecimalDigits = -1);
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.NumberDecimalDigits = 100);
            }

            [Theory]
            [ClassData(typeof(TerminatingFractionCases))]
            public void ToString_WithTerminatingFraction(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format);
                Assert.Equal(expected, result);
            }

            [Theory]
            [ClassData(typeof(NonTerminatingFractionCases))]
            public void ToString_WithNonTerminatingFraction(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format);
                Assert.Equal(expected, result);
            }

            [Theory]
            [ClassData(typeof(NegativePatternCases))]
            public void ToString_WithCustomNegativePattern(ValueFormatPair testCase, int pattern, string expected)
            {
                // Arrange
                var (value, format) = testCase;
                var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                formatProvider.NumberFormat.NumberNegativePattern = pattern;
                // Act
                var result = value.ToString(format, formatProvider);
                // Assert
                Assert.Equal(expected, result);
            }

            [Fact]
            public void ToString_N250_ReturnsTheExpectedResult()
            {
                // Arrange
                QuantityValue value = 4.2;
                var expected = "4.2" + new string(Enumerable.Repeat('0', 249).ToArray());
                // Act
                var result = value.ToString("N250", CultureInfo.InvariantCulture);
                // Assert
                Assert.Equal(expected, result);
            }
            
#if NET
            [Fact]
            public void TryFormat_Zero_WithValidSpanLength_ReturnsTrue()
            {
                // Arrange
                QuantityValue value = 0;
                var destination = new Span<char>(new char[4]);
                // Act
                var result = value.TryFormat(destination, out var charsWritten, "N", CultureInfo.InvariantCulture);
                // Assert
                Assert.True(result);
                Assert.Equal(4, charsWritten);
                Assert.Equal("0.00", destination[Range.EndAt(charsWritten)]);
            }
            
            [Fact]
            public void TryFormat_NegativeInteger_WithValidSpanLength_ReturnsTrue()
            {
                // Arrange
                QuantityValue value = -4200;
                var destination = new Span<char>(new char[9]);
                // Act
                var result = value.TryFormat(destination, out var charsWritten, "N", CultureInfo.InvariantCulture);
                // Assert
                Assert.True(result);
                Assert.Equal(9, charsWritten);
                Assert.Equal("-4,200.00", destination[Range.EndAt(charsWritten)]);
            }
            
            [Fact]
            public void TryFormat_NegativeDecimal_WithValidSpanLength_ReturnsTrue()
            {
                // Arrange
                QuantityValue value = -4.2;
                var destination = new Span<char>(new char[5]);
                // Act
                var result = value.TryFormat(destination, out var charsWritten, "N", CultureInfo.InvariantCulture);
                // Assert
                Assert.True(result);
                Assert.Equal(5, charsWritten);
                Assert.Equal("-4.20", destination[Range.EndAt(charsWritten)]);
            }

            [Theory]
            [InlineData(-0.1, "N1", 0, 0)] // (n)
            [InlineData(-0.1, "N1", 0, 1)] // (n)
            [InlineData(-0.1, "N1", 0, 4)] // (n)
            [InlineData(-0.1, "N1", 1, 0)] // -n
            [InlineData(-0.1, "N1", 2, 0)] // - n
            [InlineData(-0.1, "N1", 2, 1)] // - n
            [InlineData(-0.1, "N1", 3, 3)] // n-
            [InlineData(-0.1, "N1", 4, 3)] // n -
            [InlineData(-0.1, "N1", 4, 4)] // n -
            public void TryFormat_NegativeNumber_WithInvalidSpanLength_ReturnsFalse(decimal decimalValue, string format, int pattern, int testLength)
            {
                // Arrange
                var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                formatProvider.NumberFormat.NumberNegativePattern = pattern;
                QuantityValue value = decimalValue;
                var destination = new Span<char>(new char[testLength]);
                // Act
                var result = value.TryFormat(destination, out var charsWritten, format, formatProvider);
                // Assert
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
            }
#endif

            public sealed class TerminatingFractionCases : TheoryData<ValueFormatPair, string>
            {
                public TerminatingFractionCases()
                {
                    foreach (var value in TerminatingFractions)
                    {
                        foreach (var format in NumberFormats)
                        {
                            Add(new ValueFormatPair(value, format), value.Value.ToDecimal().ToString(format));
                        }
                    }
                }
            }

            public sealed class NonTerminatingFractionCases : TheoryData<ValueFormatPair, string>
            {
                public NonTerminatingFractionCases()
                {
                    foreach (var value in NonTerminatingFractions)
                    {
                        foreach (var format in NumberFormats)
                        {
                            Add(new ValueFormatPair(value, format), value.Value.ToDecimal().ToString(format));
                        }
                    }
                }
            }

            public sealed class NegativePatternCases : TheoryData<ValueFormatPair, int, string>
            {
                public NegativePatternCases()
                {
                    QuantityValue[] valuesToTest = [1, 0, -0.1m, -1, -1.23456789m];
                    foreach (var pattern in NumberNegativePatterns)
                    {
                        var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                        formatProvider.NumberFormat.NumberNegativePattern = pattern;
                        foreach (var format in NumberFormats)
                        {
                            foreach (var value in valuesToTest)
                            {
                                Add(new ValueFormatPair(value, format), pattern, value.ToDecimal().ToString(format, formatProvider));
                            }
                        }
                    }
                }
            }
        }

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
        public class ExponentialFormatTests
        {
            private static readonly string[] ScientificFormats = ["E", "E0", "E1", "E2", "E3", "E4", "E5", "E6", "e1", "e6"];

            [Theory]
            [ClassData(typeof(TerminatingFractionCases))]
            public void ToString_WithTerminatingFraction(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format);
                Assert.Equal(expected, result);
            }

            public sealed class TerminatingFractionCases : TheoryData<ValueFormatPair, string>
            {
                public TerminatingFractionCases()
                {
                    foreach (var value in TerminatingFractions)
                    {
                        foreach (var format in ScientificFormats)
                        {
                            Add(new ValueFormatPair(value, format), value.Value.ToDecimal().ToString(format));
                        }
                    }
                }
            }    
            
#if NET
            [Fact]
            public void TryFormat_Zero_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = 0;
                var destination = new Span<char>(new char[13]);
                var result = value.TryFormat(destination, out var charsWritten, "E", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(13, charsWritten);
                Assert.Equal("0.000000E+000", destination[Range.EndAt(charsWritten)]);
            }
            
            [Fact]
            public void TryFormat_NegativeNumber_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = -42;
                var destination = new Span<char>(new char[14]);
                var result = value.TryFormat(destination, out var charsWritten, "E", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(14, charsWritten);
                Assert.Equal("-4.200000E+001", destination[Range.EndAt(charsWritten)]);
            }
            
            [Fact]
            public void TryFormat_SmallNegativeNumber_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = -0.00042;
                var destination = new Span<char>(new char[14]);
                var result = value.TryFormat(destination, out var charsWritten, "E", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(14, charsWritten);
                Assert.Equal("-4.200000E-004", destination[Range.EndAt(charsWritten)]);
            }

            [Theory]
            [InlineData(-1.5, "E0", 0)]
            [InlineData(1.5, "E0", 0)]
            [InlineData(123.456, "E2", 3)] // 1.2[3E+002]
            [InlineData(123.456, "E2", 4)] // 1.23[E+002]
            [InlineData(123.456, "E2", 5)] // 1.23E[+002]
            [InlineData(123.456, "E2", 8)] // 1.23E+00[2]
            public void TryFormat_WithInvalidSpanLength_ReturnsFalse(decimal decimalValue, string format, int testLength)
            {
                QuantityValue value= decimalValue;
                var destination = new Span<char>(new char[testLength]);
                var result = value.TryFormat(destination, out var charsWritten, format, CultureInfo.InvariantCulture);
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
            }
#endif
        }

        /// <summary>
        ///     The "C" (or currency) format specifier converts a number to a string that represents a currency amount. The
        ///     precision specifier indicates the desired number of decimal places in the result string. If the precision specifier
        ///     is omitted, the default precision is defined by the NumberFormatInfo.CurrencyDecimalDigits property.
        ///     If the value to be formatted has more than the specified or default number of decimal places, the fractional value
        ///     is rounded in the result string. If the value to the right of the number of specified decimal places is 5 or
        ///     greater, the last digit in the result string is rounded away from zero.
        /// </summary>
        public class CurrencyFormatTests
        {
            private static readonly string[] CurrencyFormats = ["C", "C0", "C1", "C2", "C3", "C4", "C5", "C6"];

            public static readonly int[] CurrencyPositivePatterns =
            [
                00, // $n
                01, // n$
                02, // $ n
                03 // n $
            ];

            public static readonly int[] CurrencyNegativePatterns =
            [
                00, // ($n)
                01, // -$n
                02, // $-n
                03, // $n-
                04, // (n$)
                05, // -n$
                06, // n-$
                07, // n$-
                08, // -n $
                09, // -$ n
                10, // n $-
                11, // $ n-
                12, // $ -n
                13, // n- $
                14, // ($ n)
                15, // (n $)
#if NET
                16, // $- n
#endif
            ];

            [Fact]
            public void CurrencyPositivePattern_WithInvalidValue_ThrowsArgumentOutOfRangeException()
            {
                var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                var numberFormat = formatProvider.NumberFormat;
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.CurrencyPositivePattern = -1);
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.CurrencyPositivePattern = 4);
            }

            [Fact]
            public void CurrencyNegativePattern_WithInvalidValue_ThrowsArgumentOutOfRangeException()
            {
                var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                var numberFormat = formatProvider.NumberFormat;
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.CurrencyNegativePattern = -1);
#if NET
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.CurrencyNegativePattern = 17);
#else
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.CurrencyNegativePattern = 16);
#endif
            }

            [Theory]
            [ClassData(typeof(TerminatingFractionCases))]
            public void ToString_WithTerminatingFraction(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format);
                Assert.Equal(expected, result);
            }

            [Fact]
            public void ToString_C250_ReturnsTheExpectedResult()
            {
                QuantityValue value = 4.2;
                var expected = "$4.2" + new string(Enumerable.Repeat('0', 249).ToArray());
                
                var result = value.ToString("C250", CultureInfo.GetCultureInfo("en-US"));
                
                Assert.Equal(expected, result);
            }

#if NET
            [Fact]
            public void TryFormat_Zero_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = 0;
                var destination = new Span<char>(new char[5]);
                var result = value.TryFormat(destination, out var charsWritten, "C", CultureInfo.GetCultureInfo("en-US"));
                Assert.True(result);
                Assert.Equal(5, charsWritten);
                Assert.Equal("$0.00", destination[Range.EndAt(charsWritten)]);
            }
            
            [Fact]
            public void TryFormat_NegativeInteger_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = -42;
                var destination = new Span<char>(new char[7]);
                var result = value.TryFormat(destination, out var charsWritten, "C", CultureInfo.GetCultureInfo("en-US"));
                Assert.True(result);
                Assert.Equal(7, charsWritten);
                Assert.Equal("-$42.00", destination[Range.EndAt(charsWritten)]);
            }
            
            [Fact]
            public void TryFormat_NegativeDecimal_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = -4.2;
                var destination = new Span<char>(new char[6]);
                var result = value.TryFormat(destination, out var charsWritten, "C", CultureInfo.GetCultureInfo("en-US"));
                Assert.True(result);
                Assert.Equal(6, charsWritten);
                Assert.Equal("-$4.20", destination[Range.EndAt(charsWritten)]);
            }
            
            [Theory]
            [InlineData(0.1, "C1", 0, 0)] // $n
            [InlineData(0.1, "C1", 0, 3)] // $n
            [InlineData(0.1, "C1", 1, 3)] // n$ 
            [InlineData(0.1, "C1", 2, 1)] // $ n
            [InlineData(0.1, "C1", 3, 4)] // n $
            // [InlineData(0.1, "C0", 2, 1)] // $ n
            // [InlineData(0.1, "C1", 3, 0)] // n $
            // [InlineData(0.1, "C1", 3, 1)] // n $
            public void TryFormat_PositiveNumber_WithInvalidSpanLength_ReturnsFalse(decimal decimalValue, string format, int pattern, int testLength)
            {
                // Arrange
                var formatProvider = (CultureInfo)CultureInfo.GetCultureInfo("en-US").Clone();
                formatProvider.NumberFormat.CurrencyPositivePattern = pattern;
                QuantityValue value = decimalValue;
                var destination = new Span<char>(new char[testLength]);
                // Act
                var result = value.TryFormat(destination, out var charsWritten, format, formatProvider);
                // Assert
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
            }
            
            [Theory]
            [InlineData(-0.1, "C1", 0, 3)] // ($n)
            [InlineData(-0.1, "C1", 0, 4)] // ($n)
            [InlineData(-0.1, "C1", 0, 5)] // ($n)
            [InlineData(-0.1, "C1", 1, 2)] // -$n
            [InlineData(-0.1, "C1", 2, 2)] // $-n
            [InlineData(-0.1, "C1", 3, 2)] // $n-
            [InlineData(-0.1, "C1", 3, 4)] // $n-
            [InlineData(-0.1, "C1", 4, 3)] // (n$)
            [InlineData(-0.1, "C1", 4, 5)] // (n$)
            [InlineData(-0.1, "C1", 5, 2)] // -n$
            [InlineData(-0.1, "C1", 5, 4)] // -n$
            [InlineData(-0.1, "C1", 6, 4)] // n-$
            [InlineData(-0.1, "C1", 7, 4)] // n$-
            [InlineData(-0.1, "C1", 8, 3)] // -n $
            [InlineData(-0.1, "C1", 8, 5)] // -n $
            [InlineData(-0.1, "C1", 9, 3)] // -$ n
            [InlineData(-0.1, "C1", 10, 5)] // n $-
            [InlineData(-0.1, "C1", 11, 3)] // $ n-
            [InlineData(-0.1, "C1", 11, 5)] // $ n-
            [InlineData(-0.1, "C1", 12, 3)] // $ -n
            [InlineData(-0.1, "C1", 13, 5)] // n- $
            [InlineData(-0.1, "C1", 14, 4)] // ($ n)
            [InlineData(-0.1, "C1", 14, 6)] // ($ n)
            [InlineData(-0.1, "C1", 15, 4)] // (n $)
            [InlineData(-0.1, "C1", 15, 6)] // (n $)
            [InlineData(-0.1, "C1", 16, 3)] // $- n
            public void TryFormat_NegativeNumber_WithInvalidSpanLength_ReturnsFalse(decimal decimalValue, string format, int pattern, int testLength)
            {
                // Arrange
                var formatProvider = (CultureInfo)CultureInfo.GetCultureInfo("en-US").Clone();
                formatProvider.NumberFormat.CurrencyNegativePattern = pattern;
                QuantityValue value = decimalValue;
                var destination = new Span<char>(new char[testLength]);
                // Act
                var result = value.TryFormat(destination, out var charsWritten, format, formatProvider);
                // Assert
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
            }
#endif

            [Theory]
            [ClassData(typeof(NegativePatternCases))]
            public void ToString_WithCustomNegativePattern(ValueFormatPair testCase, int pattern, string expected)
            {
                // Arrange
                var (value, format) = testCase;
                var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                formatProvider.NumberFormat.CurrencyNegativePattern = pattern;
                // Act
                var result = value.ToString(format, formatProvider);
                // Assert
                Assert.Equal(expected, result);
            }

            [Theory]
            [ClassData(typeof(PositivePatternCases))]
            public void ToString_WithCustomPositivePattern(ValueFormatPair testCase, int pattern, string expected)
            {
                // Arrange
                var (value, format) = testCase;
                var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                formatProvider.NumberFormat.CurrencyPositivePattern = pattern;
                // Act
                var result = value.ToString(format, formatProvider);
                // Assert
                Assert.Equal(expected, result);
            }

            public sealed class TerminatingFractionCases : TheoryData<ValueFormatPair, string>
            {
                public TerminatingFractionCases()
                {
                    foreach (var value in TerminatingFractions)
                    {
                        foreach (var format in CurrencyFormats)
                        {
                            Add(new ValueFormatPair(value, format), value.Value.ToDecimal().ToString(format));
                        }
                    }
                }
            }

            public sealed class NegativePatternCases : TheoryData<ValueFormatPair, int, string>
            {
                public NegativePatternCases()
                {
                    QuantityValue[] valuesToTest = [1, 0, -0.1m, -1, -1.23456789m];
                    foreach (var pattern in CurrencyNegativePatterns)
                    {
                        var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                        formatProvider.NumberFormat.CurrencyNegativePattern = pattern;
                        foreach (var format in CurrencyFormats)
                        {
                            foreach (var value in valuesToTest)
                            {
                                Add(new ValueFormatPair(value, format), pattern, value.ToDecimal().ToString(format, formatProvider));
                            }
                        }
                    }
                }
            }

            public sealed class PositivePatternCases : TheoryData<ValueFormatPair, int, string>
            {
                public PositivePatternCases()
                {
                    QuantityValue[] valuesToTest = [-1, 0, 0.1m, 1, 1.2345789m];
                    foreach (var pattern in CurrencyPositivePatterns)
                    {
                        var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                        formatProvider.NumberFormat.CurrencyPositivePattern = pattern;
                        foreach (var format in CurrencyFormats)
                        {
                            foreach (var value in valuesToTest)
                            {
                                Add(new ValueFormatPair(value, format), pattern, value.ToDecimal().ToString(format, formatProvider));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     The percent ("P") format specifier multiplies a number by 100 and converts it to a string that represents a
        ///     percentage. The precision specifier indicates the desired number of decimal places. If the precision specifier is
        ///     omitted, the default numeric precision supplied by the current PercentDecimalDigits property is used.
        /// </summary>
        public class PercentageFormatTests
        {
            private static readonly string[] PercentFormats = ["P", "P0", "P1", "P2", "P3", "P4", "P5", "P6"];

            public static readonly int[] PercentPositivePatterns =
            [
                00, // n %
                01, // n%
                02, // %n
                03 // % n
            ];

            public static readonly int[] PercentNegativePatterns =
            [
                00, // -n %
                01, // -n%
                02, // -%n
                03, // %-n
                04, // n- %
                05, // n-%
                06, // %n-
                07, // n %-
                08, // -% n
                09, // %- n
                10, // n %- 
                11 // % n-
            ];

            [Fact]
            public void PercentPositivePattern_WithInvalidValue_ThrowsArgumentOutOfRangeException()
            {
                var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                var numberFormat = formatProvider.NumberFormat;
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.PercentPositivePattern = -1);
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.PercentPositivePattern = 4);
            }

            [Fact]
            public void PercentNegativePattern_WithInvalidValue_ThrowsArgumentOutOfRangeException()
            {
                var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                var numberFormat = formatProvider.NumberFormat;
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.PercentNegativePattern = -1);
                Assert.Throws<ArgumentOutOfRangeException>(() => numberFormat.PercentNegativePattern = 12);
            }

            [Theory]
            [ClassData(typeof(TerminatingFractionCases))]
            public void ToString_WithTerminatingFraction(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format);
                Assert.Equal(expected, result);
            }

            [Theory]
            [ClassData(typeof(NegativePatternCases))]
            public void ToString_WithCustomNegativePattern(ValueFormatPair testCase, int pattern, string expected)
            {
                // Arrange
                var (value, format) = testCase;
                var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                formatProvider.NumberFormat.PercentNegativePattern = pattern;
                // Act
                var result = value.ToString(format, formatProvider);
                // Assert
                Assert.Equal(expected, result);
            }

            [Theory]
            [ClassData(typeof(PositivePatternCases))]
            public void ToString_WithCustomPositivePattern(ValueFormatPair testCase, int pattern, string expected)
            {
                // Arrange
                var (value, format) = testCase;
                var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                formatProvider.NumberFormat.PercentPositivePattern = pattern;
                // Act
                var result = value.ToString(format, formatProvider);
                // Assert
                Assert.Equal(expected, result);
            }

            [Fact]
            public void ToString_P250_ReturnsTheExpectedResult()
            {
                QuantityValue value = 0.042;
                var expected = "4.2" + new string(Enumerable.Repeat('0', 249).Append(' ').Append('%').ToArray());
                
                var result = value.ToString("P250", CultureInfo.InvariantCulture);
                
                Assert.Equal(expected, result);
            }
            
#if NET
            [Fact]
            public void TryFormat_Zero_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = 0;
                var destination = new Span<char>(new char[6]);
                var result = value.TryFormat(destination, out var charsWritten, "P", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(6, charsWritten);
                Assert.Equal("0.00 %", destination[Range.EndAt(charsWritten)]);
            }
            
            [Fact]
            public void TryFormat_NegativeInteger_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = -2;
                var destination = new Span<char>(new char[9]);
                var result = value.TryFormat(destination, out var charsWritten, "P", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(9, charsWritten);
                Assert.Equal("-200.00 %", destination[Range.EndAt(charsWritten)]);
            }
            
            [Fact]
            public void TryFormat_NegativeDecimal_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = -0.042;
                var destination = new Span<char>(new char[7]);
                var result = value.TryFormat(destination, out var charsWritten, "P", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(7, charsWritten);
                Assert.Equal("-4.20 %", destination[Range.EndAt(charsWritten)]);
            }
            
            [Theory]
            [InlineData(0.1, "P1", 0, 0)] // n %
            [InlineData(0.1, "P1", 0, 4)] // n %
            [InlineData(0.1, "P1", 0, 5)] // n %
            [InlineData(0.1, "P0", 1, 2)] // n% 
            [InlineData(0.1, "P0", 2, 0)] // %n
            [InlineData(0.1, "P0", 2, 1)] // %n
            [InlineData(0.1, "P1", 3, 0)] // % n
            [InlineData(0.1, "P1", 3, 1)] // % n
            public void TryFormat_PositiveNumber_WithInvalidSpanLength_ReturnsFalse(decimal decimalValue, string format, int pattern, int testLength)
            {
                // Arrange
                var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                formatProvider.NumberFormat.PercentPositivePattern = pattern;
                QuantityValue value = decimalValue;
                var destination = new Span<char>(new char[testLength]);
                // Act
                var result = value.TryFormat(destination, out var charsWritten, format, formatProvider);
                // Assert
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
            }
            
            [Theory]
            [InlineData(-0.1, "P1", 0, 0)] // -n %
            [InlineData(-0.1, "P1", 0, 4)] // -n %
            [InlineData(-0.1, "P1", 0, 5)] // -n %
            [InlineData(-0.1, "P1", 0, 6)] // -n %
            [InlineData(-0.1, "P1", 1, 0)] // -n%
            [InlineData(-0.1, "P1", 1, 5)] // -n%
            [InlineData(-0.1, "P0", 2, 0)] // -%n
            [InlineData(-0.1, "P0", 2, 1)] // -%n
            [InlineData(-0.1, "P0", 2, 3)] // -%n
            [InlineData(-0.1, "P0", 3, 0)] // %-n
            [InlineData(-0.1, "P0", 3, 1)] // %-n
            [InlineData(-0.1, "P0", 4, 0)] // %n-
            [InlineData(-0.1, "P0", 4, 3)] // %n-
            [InlineData(-0.1, "P0", 5, 2)] // n-%
            [InlineData(-0.1, "P0", 5, 3)] // n-%
            [InlineData(-0.1, "P0", 6, 2)] // n%-
            [InlineData(-0.1, "P0", 6, 3)] // n%-
            [InlineData(-0.1, "P0", 7, 0)] // -% n
            [InlineData(-0.1, "P0", 7, 1)] // -% n
            [InlineData(-0.1, "P0", 7, 2)] // -% n
            [InlineData(-0.1, "P0", 8, 4)] // n %-
            [InlineData(-0.1, "P0", 9, 0)] // % n
            [InlineData(-0.1, "P0", 9, 1)] // % n
            [InlineData(-0.1, "P0", 9, 4)] // % n
            [InlineData(-0.1, "P0", 10, 0)] // % -n
            [InlineData(-0.1, "P0", 10, 1)] // % -n
            [InlineData(-0.1, "P0", 10, 2)] // % -n
            [InlineData(-0.1, "P0", 11, 2)] // n- %
            [InlineData(-0.1, "P0", 11, 3)] // n- %
            [InlineData(-0.1, "P0", 11, 4)] // n- %
            public void TryFormat_NegativeNumber_WithInvalidSpanLength_ReturnsFalse(decimal decimalValue, string format, int pattern, int testLength)
            {
                // Arrange
                var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                formatProvider.NumberFormat.PercentNegativePattern = pattern;
                QuantityValue value = decimalValue;
                var destination = new Span<char>(new char[testLength]);
                // Act
                var result = value.TryFormat(destination, out var charsWritten, format, formatProvider);
                // Assert
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
            }
#endif

            public sealed class TerminatingFractionCases : TheoryData<ValueFormatPair, string>
            {
                public TerminatingFractionCases()
                {
                    foreach (var value in TerminatingFractions)
                    {
                        foreach (var format in PercentFormats)
                        {
                            Add(new ValueFormatPair(value, format), value.Value.ToDecimal().ToString(format));
                            // Add(new ValueFormatPair(value, format), value.Value.ToDouble().ToString(format));
                        }
                    }
                }
            }

            public sealed class PositivePatternCases : TheoryData<ValueFormatPair, int, string>
            {
                public PositivePatternCases()
                {
                    QuantityValue[] valuesToTest = [-1, 0, 0.1m, 1, 1.2345789m];
                    foreach (var pattern in PercentPositivePatterns)
                    {
                        var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                        formatProvider.NumberFormat.PercentPositivePattern = pattern;
                        foreach (var format in PercentFormats)
                        {
                            foreach (var value in valuesToTest)
                            {
                                Add(new ValueFormatPair(value, format), pattern, value.ToDecimal().ToString(format, formatProvider));
                            }
                        }
                    }
                }
            }

            public sealed class NegativePatternCases : TheoryData<ValueFormatPair, int, string>
            {
                public NegativePatternCases()
                {
                    QuantityValue[] valuesToTest = [1, 0, -0.1m, -1, -1.23456789m];
                    foreach (var pattern in PercentNegativePatterns)
                    {
                        var formatProvider = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                        formatProvider.NumberFormat.PercentNegativePattern = pattern;
                        foreach (var format in PercentFormats)
                        {
                            foreach (var value in valuesToTest)
                            {
                                Add(new ValueFormatPair(value, format), pattern, value.ToDecimal().ToString(format, formatProvider));
                            }
                        }
                    }
                }
            }
        }


        /// <summary>
        ///     The significant digits after radix ("S") format specifier converts a number to a string that preserves the
        ///     precision of the Fraction object with a variable number of digits after the radix point.
        /// </summary>
        public class SignificantDigitsAfterTheRadixFormatTests
        {
            [Theory]
            [ClassData(typeof(NormalValueCases))]
            public void ToString_WithNormalValues(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format, CultureInfo.InvariantCulture);
                Assert.Equal(expected, result);
            }

            [Theory]
            [ClassData(typeof(SmallAbsoluteValueCases))]
            public void ToString_WithSmallAbsoluteValue(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format, CultureInfo.InvariantCulture);
                Assert.Equal(expected, result);
            }

            [Theory]
            [ClassData(typeof(LargePositiveValueCases))]
            public void ToString_WithLargePositiveValue(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format, CultureInfo.InvariantCulture);
                Assert.Equal(expected, result);
            }

            [Theory]
            [ClassData(typeof(LargeNegativeValueCases))]
            public void ToString_LargeNegativeValue(ValueFormatPair testCase, string expected)
            {
                var (value, format) = testCase;
                var result = value.ToString(format, CultureInfo.InvariantCulture);
                Assert.Equal(expected, result);
            }

            [Fact]
            public void ToString_WithVeryLargePositiveNumber()
            {
                var value = new QuantityValue(1234 * BigInteger.Pow(10, 1000));

                var actualValue = value.ToString("s", CultureInfo.InvariantCulture);

                Assert.Equal("1.23e+1003", actualValue);
            }

            [Fact]
            public void ToString_WithVerySmallPositiveNumber()
            {
                var value = new QuantityValue(1234, BigInteger.Pow(10, 1004));

                var actualValue = value.ToString("s", CultureInfo.InvariantCulture);

                Assert.Equal("1.23e-1001", actualValue);
            }
            
#if NET
            [Fact]
            public void TryFormat_Zero_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = 0;
                var destination = new Span<char>(new char[1]);
                var result = value.TryFormat(destination, out var charsWritten, "S", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(1, charsWritten);
                Assert.Equal("0", destination[Range.EndAt(charsWritten)]);
            }
            
            [Fact]
            public void TryFormat_NegativeNumber_WithValidSpanLength_ReturnsTrue()
            {
                QuantityValue value = -4.2;
                var destination = new Span<char>(new char[4]);
                var result = value.TryFormat(destination, out var charsWritten, "S", CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(4, charsWritten);
                Assert.Equal("-4.2", destination[Range.EndAt(charsWritten)]);
            }

            [Theory]
            [InlineData(-1, "S0", 0)]
            [InlineData(1, "S0", 0)]
            [InlineData(0.1, "S1", 2)]
            [InlineData(0.0001, "S4", 0)] // "1E-04"
            [InlineData(0.0001, "S4", 4)] // "1E-04"
            [InlineData(1e6, "S4", 0)] // "1E+06"
            [InlineData(1e6, "S4", 4)] // "1E+06"
            public void TryFormat_WithInvalidSpanLength_ReturnsFalse(decimal decimalValue, string format, int testLength)
            {
                QuantityValue value= decimalValue;
                var destination = new Span<char>(new char[testLength]);
                var result = value.TryFormat(destination, out var charsWritten, format, CultureInfo.InvariantCulture);
                Assert.False(result);
                // Assert.Equal(0, charsWritten); // TODO should we make sure that nothing was written?
            }
#endif

            /// <summary>
            ///     Values with exponent in the interval [-3 ≤ e ≤ 5] are formatted using the decimal point notation (no extra digits).
            /// </summary>
            public sealed class NormalValueCases : TheoryData<ValueFormatPair, string>
            {
                public NormalValueCases()
                {
                    foreach (var format in new[] { "S2", "s2" })
                    {
                        // from -1000000 to -1
                        Add(new ValueFormatPair(-999999.99m, format), "-999,999.99");
                        Add(new ValueFormatPair(-111000, format), "-111,000");
                        Add(new ValueFormatPair(-11000, format), "-11,000");
                        Add(new ValueFormatPair(-1000, format), "-1,000");
                        Add(new ValueFormatPair(-999.99m, format), "-999.99");
                        Add(new ValueFormatPair(-2.001234m, format), "-2"); 
                        Add(new ValueFormatPair(-1.1m, format), "-1.1");
                        Add(new ValueFormatPair(-1, format), "-1");
                        // from -1 to 0
                        Add(new ValueFormatPair(-0.1m, format), "-0.1");
                        Add(new ValueFormatPair(-0.01m, format), "-0.01");
                        Add(new ValueFormatPair(-0.001m, format), "-0.001");
                        // from 0 to 1
                        Add(new ValueFormatPair(0, format), "0");
                        Add(new ValueFormatPair(0.001m, format), "0.001");
                        Add(new ValueFormatPair(0.01m, format), "0.01");
                        Add(new ValueFormatPair(0.1m, format), "0.1");
                        // from 1 to 1000000
                        Add(new ValueFormatPair(1, format), "1");
                        Add(new ValueFormatPair(1.1m, format), "1.1");
                        Add(new ValueFormatPair(2.001234m, format), "2"); 
                        Add(new ValueFormatPair(999.99m, format), "999.99");
                        Add(new ValueFormatPair(1000, format), "1,000");
                        Add(new ValueFormatPair(11000, format), "11,000");
                        Add(new ValueFormatPair(111000, format), "111,000");
                        Add(new ValueFormatPair(999999.99m, format), "999,999.99");
                    }
                }
            }

            /// <summary>
            ///     Values with exponent in the interval [-inf ≤ e ≤ -4] are formatted in scientific notation.
            /// </summary>
            public sealed class SmallAbsoluteValueCases : TheoryData<ValueFormatPair, string>
            {
                public SmallAbsoluteValueCases()
                {
                    // uppercase letter
                    Add(new ValueFormatPair(1.99e-4m, "S2"), "1.99E-04");
                    Add(new ValueFormatPair(-1.99e-4m, "S2"), "-1.99E-04");
                    Add(new ValueFormatPair(0.0000111m, "S2"), "1.11E-05");
                    Add(new ValueFormatPair(-0.0000111m, "S2"), "-1.11E-05");
                    Add(new ValueFormatPair(1.23e-120, "S2"), "1.23E-120");
                    Add(new ValueFormatPair(-1.23e-120, "S2"), "-1.23E-120");
                    // lowercase letter
                    Add(new ValueFormatPair(1.99e-4m, "s2"), "1.99e-04");
                    Add(new ValueFormatPair(-1.99e-4m, "s2"), "-1.99e-04");
                    Add(new ValueFormatPair(0.0000111m, "s2"), "1.11e-05");
                    Add(new ValueFormatPair(-0.0000111m, "s2"), "-1.11e-05");
                    Add(new ValueFormatPair(1.23e-120, "s2"), "1.23e-120");
                    Add(new ValueFormatPair(-1.23e-120, "s2"), "-1.23e-120");
                }
            }

            /// <summary>
            ///     Any value in the interval [1e+06 ≤ x ≤ +inf] is formatted in scientific notation.
            /// </summary>
            public sealed class LargePositiveValueCases : TheoryData<ValueFormatPair, string>
            {
                public LargePositiveValueCases()
                {
                    // from 1E+6 to +inf (uppercase)
                    Add(new ValueFormatPair(1000000, "S2"), "1E+06");
                    Add(new ValueFormatPair(11100000, "S2"), "1.11E+07");
                    Add(new ValueFormatPair(double.MaxValue, "S2"), "1.8E+308");
                    // from 1e+6 to +inf (lowercase)
                    Add(new ValueFormatPair(1000000, "s2"), "1e+06");
                    Add(new ValueFormatPair(11100000, "s2"), "1.11e+07");
                    Add(new ValueFormatPair(double.MaxValue, "s2"), "1.8e+308");
                }
            }

            /// <summary>
            ///     Any value in the interval [-inf ≤ x ≤ 1e-04] is formatted in scientific notation.
            /// </summary>
            public sealed class LargeNegativeValueCases : TheoryData<ValueFormatPair, string>
            {
                public LargeNegativeValueCases()
                {
                    // from -inf up to -1E+6 (uppercase)
                    Add(new ValueFormatPair(double.MinValue, "S2"), "-1.8E+308");
                    Add(new ValueFormatPair(-11100000, "S2"), "-1.11E+07");
                    Add(new ValueFormatPair(-1000000, "S2"), "-1E+06");
                    // from -inf up to -1e+6 (lowercase)
                    Add(new ValueFormatPair(double.MinValue, "s2"), "-1.8e+308");
                    Add(new ValueFormatPair(-11100000, "s2"), "-1.11e+07");
                    Add(new ValueFormatPair(-1000000, "s2"), "-1e+06");
                }
            }
        }

        public class CustomFormatTests
        {
            [Theory]
            [ClassData(typeof(CustomFormatCases))]
            public void ToString_WithCustomFormat(ValueFormatPair pair, string expected)
            {
                var (value, format) = pair;
                var actual = value.ToString(format, CultureInfo.InvariantCulture);
                Assert.Equal(expected, actual);
            }

#if NET
            [Theory]
            [ClassData(typeof(CustomFormatCases))]
            public void TryFormat_WithCustomFormat(ValueFormatPair pair, string expected)
            {
                var (value, format) = pair;
                var destination = new Span<char>(new char[100]);
                var result = value.TryFormat(destination, out var charsWritten, format, CultureInfo.InvariantCulture);
                Assert.True(result);
                Assert.Equal(expected, destination[Range.EndAt(charsWritten)]);
            }
#endif

            [Fact]
            public void NumberFormat_WithEmptySign_DoesNotThrow()
            {
                var formatProvider = (CultureInfo)CultureInfo.InvariantCulture.Clone();
                var numberFormat = formatProvider.NumberFormat;
                Assert.Equal("", numberFormat.NegativeSign = "");
                Assert.Equal(" ", numberFormat.NegativeSign = " ");
                Assert.Equal("1", numberFormat.NegativeSign = "1");
            }

            public sealed class CustomFormatCases : TheoryData<ValueFormatPair, string>
            {
                public CustomFormatCases()
                {
                    var oneHalf = new QuantityValue(1, 2);
                    Add(new ValueFormatPair(oneHalf, "Test: 0.00"), "Test: 0.50");
                    Add(new ValueFormatPair(oneHalf, "Guess: 0.00"), "Guess: 0.50");
                    Add(new ValueFormatPair(oneHalf, "Feet: 0.00"), "Feet: 0.50");
                    Add(new ValueFormatPair(oneHalf, "Number: 0.00"), "Number: 0.50");
                    Add(new ValueFormatPair(oneHalf, "Eons: 0.00"), "Eons: 0.50");
                    Add(new ValueFormatPair(oneHalf, "Cans: 0.00"), "Cans: 0.50");
                    Add(new ValueFormatPair(oneHalf, "Parsecs: 0.00"), "Parsecs: 0.50");
                    Add(new ValueFormatPair(oneHalf, "Some: 0.00"), "Some: 0.50");
                }
            }
        }

        [Fact]
        public void ToString_DefaultsToTheGeneralFormat_WithCurrentCulture()
        {
            var value = new QuantityValue(1, 3);
            // ReSharper disable once SpecifyACultureInStringConversionExplicitly
            Assert.Equal(value.ToString("G", CultureInfo.CurrentCulture), value.ToString());
            Assert.Equal(value.ToString("G", CultureInfo.CurrentCulture), value.ToString(string.Empty));
            Assert.Equal(value.ToString("G", CultureInfo.CurrentCulture), value.ToString(null, null));
        }

        [Fact]
        public void ToString_WithTheRoundTrippingFormat_ReturnsTheDoubleRepresentation()
        {
            QuantityValue value = 123.456m;
            var expectedValue = value.ToDouble().ToString("R");
            var result = value.ToString("R");
            Assert.Equal(expectedValue, result);
        }

        [Fact]
        public void ToString_WithNaNOrInfinity_ReturnsTheCorrespondingSymbol()
        {
            Assert.Multiple(
                () => Assert.Equal(double.NaN.ToString(null, null), QuantityValue.NaN.ToString(null, null)),
                () => Assert.Equal(double.PositiveInfinity.ToString(null, null), QuantityValue.PositiveInfinity.ToString(null, null)),
                () => Assert.Equal(double.NegativeInfinity.ToString(null, null), QuantityValue.NegativeInfinity.ToString(null, null))
            );
        }

#if NET
        [Fact]
        public void TryFormat_DefaultsToTheGeneralFormat_WithCurrentCulture()
        {
            var value = new QuantityValue(1, 3);
            Span<char> buffer = stackalloc char[32];
            Assert.True(value.TryFormat(buffer, out var charsWritten, default, null));
            Assert.Equal(value.ToString("G", CultureInfo.CurrentCulture), buffer[..charsWritten]);
        }
        
        [Fact]
        public void TryFormat_NaNOrInfinity_ReturnsTheCorrespondingSymbol()
        {
            Assert.Multiple(
                () =>
                {
                    Span<char> buffer = stackalloc char[32];
                    Assert.True(QuantityValue.NaN.TryFormat(buffer, out var charsWritten, null, null));
                    Assert.Equal(double.NaN.ToString(null, null), new string(buffer[..charsWritten]));
                },
                () =>
                {
                    Span<char> buffer = stackalloc char[32];
                    Assert.True(QuantityValue.PositiveInfinity.TryFormat(buffer, out var charsWritten, null, null));
                    Assert.Equal(double.PositiveInfinity.ToString(null, null), new string(buffer[..charsWritten]));
                },
                () =>
                {
                    Span<char> buffer = stackalloc char[32];
                    Assert.True(QuantityValue.NegativeInfinity.TryFormat(buffer, out var charsWritten, null, null));
                    Assert.Equal(double.NegativeInfinity.ToString(null, null), new string(buffer[..charsWritten]));
                }
            );
        }

        [Fact]
        public void TryFormat_NaNOrInfinity_WithInvalidSpanLength_ReturnsFalse()
        {
            Assert.Multiple(
                () =>
                {
                    Assert.False(QuantityValue.NaN.TryFormat(Span<char>.Empty, out var charsWritten, null, null));
                    Assert.Equal(0, charsWritten);
                },
                () =>
                {
                    Assert.False(QuantityValue.PositiveInfinity.TryFormat(Span<char>.Empty, out var charsWritten, null, null));
                    Assert.Equal(0, charsWritten);
                },
                () =>
                {
                    Assert.False(QuantityValue.NegativeInfinity.TryFormat(Span<char>.Empty, out var charsWritten, null, null));
                    Assert.Equal(0, charsWritten);
                }
            );
        }
#endif
    }
}
