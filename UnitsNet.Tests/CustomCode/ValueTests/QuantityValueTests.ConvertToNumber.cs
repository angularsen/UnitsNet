using System.Numerics;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    public class ConvertToNumberTests
    {
        public class ToDecimalTests
        {
            [Fact]
            public void ToDecimal_WithNaNOrInfinity_ThrowsOverflowException()
            {
                Assert.Throws<OverflowException>(() => QuantityValue.NaN.ToDecimal());
                Assert.Throws<OverflowException>(() => QuantityValue.PositiveInfinity.ToDecimal());
                Assert.Throws<OverflowException>(() => QuantityValue.NegativeInfinity.ToDecimal());
            }

            [Fact]
            public void ToDecimal_WithValueOutsideTheDecimalRange_ThrowsOverflowException()
            {
                var largeNumber = 2 * new BigInteger(decimal.MaxValue);
                Assert.Throws<OverflowException>(() => new QuantityValue(largeNumber).ToDecimal());
                Assert.Throws<OverflowException>(() => new QuantityValue(-largeNumber).ToDecimal());
                Assert.Throws<OverflowException>(() => new QuantityValue(1, largeNumber).ToDecimal());
                Assert.Throws<OverflowException>(() => new QuantityValue(-1, largeNumber).ToDecimal());
            }

            [Theory]
            [ClassData(typeof(ToDecimalTestData))]
            public void ToDecimal_WithAValueWithinTheDecimalRange_ReturnsTheExpectedResult(BigInteger numerator, BigInteger denominator, decimal expected)
            {
                var quantityValue = new QuantityValue(numerator, denominator);
                Assert.Equal(expected, quantityValue.ToDecimal());
            }

            public class ToDecimalTestData : TheoryData<BigInteger, BigInteger, decimal>
            {
                public ToDecimalTestData()
                {
                    var largeNumber = 2 * new BigInteger(decimal.MaxValue);
                    // Zero cases
                    Add(0, 1, 0.0m); // 0 / 1
                    Add(0, 10, 0.0m); // 0 / 10
                    Add(0, largeNumber, 0.0m); // 0 / largeNumber
                    // Positive cases
                    Add(2, 1, 2.0m); // 2 / 1
                    Add(1, 2, 0.5m); // 1 / 2
                    Add(1, 3, 1.0m / 3.0m); // 1 / 3
                    Add(largeNumber, 4, decimal.MaxValue / 2); // 2 * maxValue / 4
                    Add(4, largeNumber, 2 / decimal.MaxValue); // 4 / (maxValue * 2)
                    Add(3, largeNumber, 1.5m / decimal.MaxValue); // 3 / (maxValue * 2)
                    Add(largeNumber, largeNumber, 1.0m); // largeNumber / largeNumber
                    Add(2 * largeNumber, largeNumber, 2.0m); // 2 * largeNumber / largeNumber
                    Add(largeNumber, 2 * largeNumber, 0.5m); // largeNumber / 2 * largeNumber
                    Add(3 * largeNumber, 2 * largeNumber, 1.5m); // 3 * largeNumber / 2 * largeNumber
                    Add(2 * largeNumber, 3 * largeNumber, 2.0m / 3.0m); // 2 * largeNumber / 3 * largeNumber
                    // Negative cases
                    Add(-2, 1, -2.0m); // -2 / 1
                    Add(-1, 2, -0.5m); // -1 / 2
                    Add(-1, 3, -1.0m / 3.0m); // -1 / 3
                    Add(-largeNumber, 4, decimal.MinValue / 2); // -2 * maxValue / 4
                    Add(-4, largeNumber, -2 / decimal.MaxValue); // -4 / (maxValue * 2)
                    Add(-3, largeNumber, -1.5m / decimal.MaxValue); // -3 / (maxValue * 2)
                    Add(-largeNumber, largeNumber, -1.0m); // -largeNumber / largeNumber
                    Add(-2 * largeNumber, largeNumber, -2.0m); // -2 * largeNumber / largeNumber
                    Add(-largeNumber, 2 * largeNumber, -0.5m); // -largeNumber / 2 * largeNumber
                    Add(-3 * largeNumber, 2 * largeNumber, -1.5m); // -3 * largeNumber / 2 * largeNumber
                    Add(-2 * largeNumber, 3 * largeNumber, -2.0m / 3.0m); // -2 * largeNumber / 3 * largeNumber
                }
            }
        }

        public class ToDecimalSaturatingTests
        {
            [Theory]
            [ClassData(typeof(ToDecimalSaturatingTestData))]
            public void ToDecimalSaturating_ConvertsTheValueToTheDecimalRange(BigInteger numerator, BigInteger denominator, decimal expected)
            {
                var quantityValue = new QuantityValue(numerator, denominator);
                Assert.Equal(expected, quantityValue.ToDecimalSaturating());
            }

            public class ToDecimalSaturatingTestData : TheoryData<BigInteger, BigInteger, decimal>
            {
                public ToDecimalSaturatingTestData()
                {
                    var largeNumber = 2 * new BigInteger(decimal.MaxValue);
                    // Zero cases
                    Add(0, 1, 0.0m); // 0 / 1
                    Add(0, 10, 0.0m); // 0 / 10
                    Add(0, largeNumber, 0.0m); // 0 / largeNumber
                    // Positive cases
                    Add(2, 1, 2.0m); // 2 / 1
                    Add(1, 2, 0.5m); // 1 / 2
                    Add(1, 3, 1.0m / 3.0m); // 1 / 3
                    Add(largeNumber, 4, decimal.MaxValue / 2); // 2 * maxValue / 4
                    Add(4, largeNumber, 2 / decimal.MaxValue); // 4 / (maxValue * 2)
                    Add(3, largeNumber, 1.5m / decimal.MaxValue); // 3 / (maxValue * 2)
                    Add(largeNumber, largeNumber, 1.0m); // largeNumber / largeNumber
                    Add(2 * largeNumber, largeNumber, 2.0m); // 2 * largeNumber / largeNumber
                    Add(largeNumber, 2 * largeNumber, 0.5m); // largeNumber / 2 * largeNumber
                    Add(3 * largeNumber, 2 * largeNumber, 1.5m); // 3 * largeNumber / 2 * largeNumber
                    Add(2 * largeNumber, 3 * largeNumber, 2.0m / 3.0m); // 2 * largeNumber / 3 * largeNumber
                    // Negative cases
                    Add(-2, 1, -2.0m); // -2 / 1
                    Add(-1, 2, -0.5m); // -1 / 2
                    Add(-1, 3, -1.0m / 3.0m); // -1 / 3
                    Add(-largeNumber, 4, decimal.MinValue / 2); // -2 * maxValue / 4
                    Add(-4, largeNumber, -2 / decimal.MaxValue); // -4 / (maxValue * 2)
                    Add(-3, largeNumber, -1.5m / decimal.MaxValue); // -3 / (maxValue * 2)
                    Add(-largeNumber, largeNumber, -1.0m); // -largeNumber / largeNumber
                    Add(-2 * largeNumber, largeNumber, -2.0m); // -2 * largeNumber / largeNumber
                    Add(-largeNumber, 2 * largeNumber, -0.5m); // -largeNumber / 2 * largeNumber
                    Add(-3 * largeNumber, 2 * largeNumber, -1.5m); // -3 * largeNumber / 2 * largeNumber
                    Add(-2 * largeNumber, 3 * largeNumber, -2.0m / 3.0m); // -2 * largeNumber / 3 * largeNumber
                    // overflowing cases
                    Add(largeNumber, 1, decimal.MaxValue);
                    Add(-largeNumber, 1, decimal.MinValue);
                    Add(2 * largeNumber, 2, decimal.MaxValue);
                    Add(-2 * largeNumber, 2, decimal.MinValue);
                    Add(1, largeNumber, 0m);
                    Add(-1, largeNumber, 0m);
                    // special values
                    Add(0, 0, 0m); // NaN
                    Add(1, 0, decimal.MaxValue); // PositiveInfinity
                    Add(-1, 0, decimal.MinValue); // NegativeInfinity
                }
            }
        }

        public class ToDoubleTests
        {
            [Theory]
            [ClassData(typeof(ToDoubleTestData))]
            public void ToDouble_ConvertsTheValueToTheDoubleRange(BigInteger numerator, BigInteger denominator, double expected)
            {
                var quantityValue = new QuantityValue(numerator, denominator);
                Assert.Equal(expected, quantityValue.ToDouble());
            }

            public class ToDoubleTestData : TheoryData<BigInteger, BigInteger, double>
            {
                public ToDoubleTestData()
                {
                    var largeNumber = 2 * new BigInteger(double.MaxValue);
                    // Zero cases
                    Add(0, 1, 0.0); // 0 / 1
                    Add(0, 10, 0.0); // 0 / 10
                    Add(0, largeNumber, 0.0); // 0 / largeNumber
                    // Positive cases
                    Add(2, 1, 2.0); // 2 / 1
                    Add(1, 2, 0.5); // 1 / 2
                    Add(1, 3, 1.0 / 3.0); // 1 / 3
                    Add(largeNumber, 4, double.MaxValue / 2); // 2 * maxValue / 4
                    Add(4, largeNumber, 2 / double.MaxValue); // 4 / (maxValue * 2)
                    Add(3, largeNumber, 1.5 / double.MaxValue); // 3 / (maxValue * 2)
                    Add(largeNumber, largeNumber, 1.0); // largeNumber / largeNumber
                    Add(2 * largeNumber, largeNumber, 2.0); // 2 * largeNumber / largeNumber
                    Add(largeNumber, 2 * largeNumber, 0.5); // largeNumber / 2 * largeNumber
                    Add(3 * largeNumber, 2 * largeNumber, 1.5); // 3 * largeNumber / 2 * largeNumber
                    Add(2 * largeNumber, 3 * largeNumber, 2.0 / 3.0); // 2 * largeNumber / 3 * largeNumber
                    // Negative cases
                    Add(-2, 1, -2.0); // -2 / 1
                    Add(-1, 2, -0.5); // -1 / 2
                    Add(-1, 3, -1.0 / 3.0); // -1 / 3
                    Add(-largeNumber, 4, double.MinValue / 2); // -2 * maxValue / 4
                    Add(-4, largeNumber, -2 / double.MaxValue); // -4 / (maxValue * 2)
                    Add(-3, largeNumber, -1.5 / double.MaxValue); // -3 / (maxValue * 2)
                    Add(-largeNumber, largeNumber, -1.0); // -largeNumber / largeNumber
                    Add(-2 * largeNumber, largeNumber, -2.0); // -2 * largeNumber / largeNumber
                    Add(-largeNumber, 2 * largeNumber, -0.5); // -largeNumber / 2 * largeNumber
                    Add(-3 * largeNumber, 2 * largeNumber, -1.5); // -3 * largeNumber / 2 * largeNumber
                    Add(-2 * largeNumber, 3 * largeNumber, -2.0 / 3.0); // -2 * largeNumber / 3 * largeNumber
                    // overflowing cases
                    Add(largeNumber, 1, double.PositiveInfinity);
                    Add(-largeNumber, 1, double.NegativeInfinity);
                    Add(2 * largeNumber, 2, double.PositiveInfinity);
                    Add(-2 * largeNumber, 2, double.NegativeInfinity);
                    Add(1, largeNumber, 0);
                    Add(-1, largeNumber, 0);
                    // special values
                    Add(0, 0, double.NaN); // NaN
                    Add(1, 0, double.PositiveInfinity); // PositiveInfinity
                    Add(-1, 0, double.NegativeInfinity); // NegativeInfinity
                }
            }
        }

        public class ExplicitConversionTests
        {
            [Fact]
            public void ExplicitConversionToDecimal()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal(quantityValue.ToDecimal(), (decimal)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToDouble()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4.2, (double)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToFloat()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4.2, (float)quantityValue, 2);
            }

            [Fact]
            public void ExplicitConversionToBigInteger()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4, (BigInteger)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToLong()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4, (long)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToULong()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4ul, (ulong)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToInteger()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4, (int)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToUInt()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4u, (uint)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToShort()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4, (short)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToUShort()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal((ushort)4, (ushort)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToByte()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal((byte)4, (byte)quantityValue);
            }

#if NET
            [Fact]
            public void ExplicitConversionToHalf()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal((Half)4.2, (Half)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToInt128()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4, (Int128)quantityValue);
            }

            [Fact]
            public void ExplicitConversionToUInt128()
            {
                var quantityValue = new QuantityValue(42, 10);
                Assert.Equal((UInt128)4, (UInt128)quantityValue);
            }
#endif
        }
       
        public class ConvertibleTests
        {
            [Fact]
            public void ToDecimal_ConvertsChecked()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4.2m, quantityValue.ToDecimal(null));
            }

            [Fact]
            public void ToDouble_ConvertsSaturating()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4.2, quantityValue.ToDouble(null));
            }

            [Fact]
            public void ToSingle_ConvertsSaturating()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4.2f, quantityValue.ToSingle(null), 2);
            }

            [Fact]
            public void ToInt64_ConvertsChecked()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4L, quantityValue.ToInt64(null));
            }

            [Fact]
            public void ToUInt64_ConvertsChecked()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4ul, quantityValue.ToUInt64(null));
            }

            [Fact]
            public void ToInt32_ConvertsChecked()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4, quantityValue.ToInt32(null));
            }

            [Fact]
            public void ToUInt32_ConvertsChecked()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4u, quantityValue.ToUInt32(null));
            }

            [Fact]
            public void ToUInt16_ConvertsChecked()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal((ushort)4, quantityValue.ToUInt16(null));
            }

            [Fact]
            public void ToInt16_ConvertsChecked()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal((short)4, quantityValue.ToInt16(null));
            }

            [Fact]
            public void ToByte_ConvertsChecked()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal((byte)4, quantityValue.ToByte(null));
            }

            [Fact]
            public void ToSByte_ConvertsChecked()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal((sbyte)4, quantityValue.ToSByte(null));
            }

            [Fact]
            public void ToChar_ThrowsInvalidCastException()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Throws<InvalidCastException>(() => quantityValue.ToChar(null));
            }

            [Fact]
            public void ToBoolean_ThrowsInvalidCastException()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Throws<InvalidCastException>(() => quantityValue.ToBoolean(null));
            }

            [Fact]
            public void ToDateTime_ThrowsInvalidCastException()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Throws<InvalidCastException>(() => quantityValue.ToDateTime(null));
            }

            [Fact]
            public void ToString_ReturnsTheValueAsString()
            {
                var valueToConvert = new QuantityValue(42, 10);
                IFormatProvider? formatProvider = null;
                var expectedFormat = valueToConvert.ToString(null, formatProvider);
                IConvertible quantityValue = valueToConvert;
                Assert.Equal(expectedFormat, quantityValue.ToString(formatProvider));
            }

            [Fact]
            public void GetTypeCode_ReturnsObject()
            {
                IConvertible quantityValue = QuantityValue.One;
                Assert.Equal(TypeCode.Object, quantityValue.GetTypeCode());
            }

            [Fact]
            public void ToType_WithNumericType_ReturnsTheExpectedResult()
            {
                IConvertible quantityValue = new QuantityValue(42, 10);
                Assert.Equal(4.2, quantityValue.ToType(typeof(double), null));
                Assert.Equal(4.2m, quantityValue.ToType(typeof(decimal), null));
                Assert.Equal(4.2, (float)quantityValue.ToType(typeof(float), null), 2);
                Assert.Equal(4L, quantityValue.ToType(typeof(long), null));
                Assert.Equal(4ul, quantityValue.ToType(typeof(ulong), null));
                Assert.Equal(4, quantityValue.ToType(typeof(int), null));
                Assert.Equal(4u, quantityValue.ToType(typeof(uint), null));
                Assert.Equal((short)4, quantityValue.ToType(typeof(short), null));
                Assert.Equal((ushort)4, quantityValue.ToType(typeof(ushort), null));
                Assert.Equal((byte)4, quantityValue.ToType(typeof(byte), null));
                Assert.Equal((sbyte)4, quantityValue.ToType(typeof(sbyte), null));
            }

            [Fact]
            public void ToType_WithTypeOfString_ReturnsTheValueAsString()
            {
                var valueToConvert = new QuantityValue(42, 10);
                IFormatProvider? formatProvider = null;
                var expectedFormat = valueToConvert.ToString(null, formatProvider);
                IConvertible quantityValue = valueToConvert;
                Assert.Equal(expectedFormat, quantityValue.ToType(typeof(string), formatProvider));
            }

            [Fact]
            public void ToType_WithUnsupportedType_ThrowsInvalidCastException()
            {
                IConvertible valueToConvert = QuantityValue.One;
                Assert.Throws<InvalidCastException>(() => valueToConvert.ToType(typeof(bool), null));
            }

            [Fact]
            public void ToType_WithNullType_ThrowsArgumentNullException()
            {
                IConvertible valueToConvert = QuantityValue.One;
                Assert.Throws<ArgumentNullException>(() => valueToConvert.ToType(null!, null));
            }
        }
#if NET7_0_OR_GREATER

        public class ConvertToCheckedTests
        {
            private static TNumber CreateChecked<TNumber, TOther>(TOther value)
                where TNumber : INumberBase<TNumber>
                where TOther : INumberBase<TOther>
            {
                return TNumber.CreateChecked(value);
            }

            [Fact]
            public void CreateChecked_FromFinitePositiveValue_ShouldReturnTheExpectedValue()
            {
                var quantityValue = new QuantityValue(3, 2);
                Assert.Equal(1.5, double.CreateChecked(quantityValue));
                Assert.Equal(new Complex(1.5, 0), Complex.CreateChecked(quantityValue));
                Assert.Equal(1.5m, decimal.CreateChecked(quantityValue));
                Assert.Equal(1.5f, float.CreateChecked(quantityValue));
                Assert.Equal((Half)1.5, Half.CreateChecked(quantityValue));
                Assert.Equal(1, BigInteger.CreateChecked(quantityValue));
                Assert.Equal(1, Int128.CreateChecked(quantityValue));
                Assert.Equal(1u, UInt128.CreateChecked(quantityValue));
                Assert.Equal(1, long.CreateChecked(quantityValue));
                Assert.Equal((ulong)1, ulong.CreateChecked(quantityValue));
                Assert.Equal(1, int.CreateChecked(quantityValue));
                Assert.Equal((uint)1, uint.CreateChecked(quantityValue));
                Assert.Equal(1, nint.CreateChecked(quantityValue));
                Assert.Equal((UIntPtr)1, UIntPtr.CreateChecked(quantityValue));
                Assert.Equal((short)1, short.CreateChecked(quantityValue));
                Assert.Equal((ushort)1, ushort.CreateChecked(quantityValue));
                Assert.Equal((byte)1, byte.CreateChecked(quantityValue));
                Assert.Equal((sbyte)1, sbyte.CreateChecked(quantityValue));
                // although there isn't any char.CreateChecked(..) method, all numeric types support this conversion as well
                Assert.Equal('a', CreateChecked<char, double>(97.9));
                Assert.Equal('a', CreateChecked<char, QuantityValue>(new QuantityValue(979, 10)));
            }

            [Fact]
            public void CreateChecked_FromFiniteNegativeValue_ShouldReturnTheExpectedValue()
            {
                var fraction = new QuantityValue(-3, 2);
                Assert.Equal(-1.5, double.CreateChecked(fraction));
                Assert.Equal(new Complex(-1.5, 0), Complex.CreateChecked(fraction));
                Assert.Equal(-1.5m, decimal.CreateChecked(fraction));
                Assert.Equal(-1.5f, float.CreateChecked(fraction));
                Assert.Equal((Half)(-1.5), Half.CreateChecked(fraction));
                Assert.Equal(-1, BigInteger.CreateChecked(fraction));
                Assert.Equal(-1, Int128.CreateChecked(fraction));
                Assert.Throws<OverflowException>(() => UInt128.CreateChecked(fraction));
                Assert.Equal(-1, long.CreateChecked(fraction));
                Assert.Throws<OverflowException>(() => ulong.CreateChecked(fraction));
                Assert.Equal(-1, int.CreateChecked(fraction));
                Assert.Throws<OverflowException>(() => uint.CreateChecked(fraction));
                Assert.Equal(-1, nint.CreateChecked(fraction));
                Assert.Throws<OverflowException>(() => UIntPtr.CreateChecked(fraction));
                Assert.Equal((short)-1, short.CreateChecked(fraction));
                Assert.Throws<OverflowException>(() => ushort.CreateChecked(fraction));
                Assert.Throws<OverflowException>(() => byte.CreateChecked(fraction));
                Assert.Equal((sbyte)-1, sbyte.CreateChecked(fraction));
                // although there isn't any char.CreateChecked(..) method, all numeric types support this conversion as well
                Assert.Throws<OverflowException>(() => CreateChecked<char, double>(-1.5));
                Assert.Throws<OverflowException>(() => CreateChecked<char, QuantityValue>(fraction));
            }

            [Fact]
            public void CreateChecked_FromNaN_ShouldReturnNaNOrThrowAnException()
            {
                Assert.Equal(double.NaN, double.CreateChecked(QuantityValue.NaN));
                Assert.Equal(new Complex(double.NaN, 0), Complex.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => decimal.CreateChecked(QuantityValue.NaN));
                Assert.Equal(float.NaN, float.CreateChecked(QuantityValue.NaN));
                Assert.Equal(Half.NaN, Half.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => BigInteger.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => Int128.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => UInt128.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => long.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => ulong.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => int.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => uint.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => nint.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => UIntPtr.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => short.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => ushort.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => byte.CreateChecked(QuantityValue.NaN));
                Assert.Throws<OverflowException>(() => sbyte.CreateChecked(QuantityValue.NaN));
                // although there isn't any char.CreateChecked(..) method, all numeric types support this conversion as well
                Assert.Throws<OverflowException>(() => CreateChecked<char, double>(double.NaN));
                Assert.Throws<OverflowException>(() => CreateChecked<char, QuantityValue>(QuantityValue.NaN));
            }

            [Fact]
            public void CreateChecked_FromPositiveInfinity_ShouldReturnPositiveInfinityOrThrowOverflowException()
            {
                Assert.Equal(double.PositiveInfinity, double.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Equal(new Complex(double.PositiveInfinity, 0), Complex.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => decimal.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Equal(float.PositiveInfinity, float.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Equal(Half.PositiveInfinity, Half.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => BigInteger.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => Int128.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => UInt128.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => long.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => ulong.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => int.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => uint.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => nint.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => UIntPtr.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => short.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => ushort.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => byte.CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Throws<OverflowException>(() => sbyte.CreateChecked(QuantityValue.PositiveInfinity));
                // although there isn't any char.CreateChecked(..) method, all numeric types support this conversion as well
                Assert.Throws<OverflowException>(() => CreateChecked<char, double>(double.PositiveInfinity));
                Assert.Throws<OverflowException>(() => CreateChecked<char, QuantityValue>(QuantityValue.PositiveInfinity));
            }

            [Fact]
            public void CreateChecked_FromNegativeInfinity_ShouldReturnNegativeInfinityOrThrowOverflowException()
            {
                Assert.Equal(double.NegativeInfinity, double.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Equal(new Complex(double.NegativeInfinity, 0), Complex.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => decimal.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Equal(float.NegativeInfinity, float.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Equal(Half.NegativeInfinity, Half.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => BigInteger.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => Int128.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => UInt128.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => long.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => ulong.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => int.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => uint.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => nint.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => UIntPtr.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => short.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => ushort.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => byte.CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Throws<OverflowException>(() => sbyte.CreateChecked(QuantityValue.NegativeInfinity));
                // although there isn't any char.CreateChecked(..) method, all numeric types support this conversion as well
                Assert.Throws<OverflowException>(() => CreateChecked<char, double>(double.NegativeInfinity));
                Assert.Throws<OverflowException>(() => CreateChecked<char, QuantityValue>(QuantityValue.NegativeInfinity));
            }

            [Fact]
            public void CreateChecked_WithUnsupportedType_ThrowsNotSupportedException()
            {
                Assert.Throws<NotSupportedException>(() => CreateChecked<FakeNumber, QuantityValue>(QuantityValue.One));
            }
        }

        public class ConvertToSaturatingTests
        {
            private static TNumber CreateSaturating<TNumber, TOther>(TOther value)
                where TNumber : INumberBase<TNumber>
                where TOther : INumberBase<TOther>
            {
                return TNumber.CreateSaturating(value);
            }

            [Fact]
            public void CreateSaturating_FromFinitePositiveValue_ShouldReturnTheExpectedValue()
            {
                var quantityValue = new QuantityValue(3, 2);
                Assert.Equal(1.5, double.CreateSaturating(quantityValue));
                Assert.Equal(new Complex(1.5, 0), Complex.CreateSaturating(quantityValue));
                Assert.Equal(1.5m, decimal.CreateSaturating(quantityValue));
                Assert.Equal(1.5f, float.CreateSaturating(quantityValue));
                Assert.Equal((Half)1.5, Half.CreateSaturating(quantityValue));
                Assert.Equal(1, BigInteger.CreateSaturating(quantityValue));
                Assert.Equal(1, Int128.CreateSaturating(quantityValue));
                Assert.Equal(1u, UInt128.CreateSaturating(quantityValue));
                Assert.Equal(1, long.CreateSaturating(quantityValue));
                Assert.Equal((ulong)1, ulong.CreateSaturating(quantityValue));
                Assert.Equal(1, int.CreateSaturating(quantityValue));
                Assert.Equal((uint)1, uint.CreateSaturating(quantityValue));
                Assert.Equal(1, nint.CreateSaturating(quantityValue));
                Assert.Equal((UIntPtr)1, UIntPtr.CreateSaturating(quantityValue));
                Assert.Equal((short)1, short.CreateSaturating(quantityValue));
                Assert.Equal((ushort)1, ushort.CreateSaturating(quantityValue));
                Assert.Equal((byte)1, byte.CreateSaturating(quantityValue));
                Assert.Equal((sbyte)1, sbyte.CreateSaturating(quantityValue));
                // although there isn't any char.CreateSaturating(..) method, all numeric types support this conversion as well
                Assert.Equal('a', CreateSaturating<char, double>(97.9));
                Assert.Equal('a', CreateSaturating<char, QuantityValue>(new QuantityValue(979, 10)));
            }

            [Fact]
            public void CreateSaturating_FromFiniteNegativeValue_ShouldReturnTheExpectedValue()
            {
                var fraction = new QuantityValue(-3, 2);
                Assert.Equal(-1.5, double.CreateSaturating(fraction));
                Assert.Equal(new Complex(-1.5, 0), Complex.CreateSaturating(fraction));
                Assert.Equal(-1.5m, decimal.CreateSaturating(fraction));
                Assert.Equal(-1.5f, float.CreateSaturating(fraction));
                Assert.Equal((Half)(-1.5), Half.CreateSaturating(fraction));
                Assert.Equal(-1, BigInteger.CreateSaturating(fraction));
                Assert.Equal(-1, Int128.CreateSaturating(fraction));
                Assert.Equal(0u, UInt128.CreateSaturating(fraction));
                Assert.Equal(-1, long.CreateSaturating(fraction));
                Assert.Equal(0UL, ulong.CreateSaturating(fraction));
                Assert.Equal(-1, int.CreateSaturating(fraction));
                Assert.Equal(0U, uint.CreateSaturating(fraction));
                Assert.Equal(-1, nint.CreateSaturating(fraction));
                Assert.Equal((UIntPtr)0, UIntPtr.CreateSaturating(fraction));
                Assert.Equal((short)-1, short.CreateSaturating(fraction));
                Assert.Equal((ushort)0, ushort.CreateSaturating(fraction));
                Assert.Equal((byte)0, byte.CreateSaturating(fraction));
                Assert.Equal((sbyte)-1, sbyte.CreateSaturating(fraction));
                // although there isn't any char.CreateSaturating(..) method, all numeric types support this conversion as well
                Assert.Equal(char.MinValue, CreateSaturating<char, double>(-1.5));
                Assert.Equal(char.MinValue, CreateSaturating<char, QuantityValue>(fraction));
            }

            [Fact]
            public void CreateSaturating_FromNaN_ShouldReturnZeroOrNaN()
            {
                Assert.Equal(double.NaN, double.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(new Complex(double.NaN, 0), Complex.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(decimal.Zero, decimal.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(float.NaN, float.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(Half.NaN, Half.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(BigInteger.Zero, BigInteger.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(Int128.Zero, Int128.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(UInt128.Zero, UInt128.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(0, long.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(0UL, ulong.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(0, int.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(0U, uint.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(nint.Zero, nint.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(UIntPtr.Zero, UIntPtr.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(default, short.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(default, ushort.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(default, byte.CreateSaturating(QuantityValue.NaN));
                Assert.Equal(default, sbyte.CreateSaturating(QuantityValue.NaN));
                // although there isn't any char.CreateChecked(..) method, all numeric types support this conversion as well
                Assert.Equal('\0', CreateSaturating<char, double>(double.NaN));
                Assert.Equal('\0', CreateSaturating<char, QuantityValue>(QuantityValue.NaN));
            }

            [Fact]
            public void CreateSaturating_BigInteger_FromPositiveInfinity_ShouldThrowOverflowException()
            {
                Assert.Throws<OverflowException>(() => BigInteger.CreateSaturating(QuantityValue.PositiveInfinity));
            }

            [Fact]
            public void CreateSaturating_FromPositiveInfinity_ShouldReturnMaxValueOrPositiveInfinity()
            {
                Assert.Equal(double.PositiveInfinity, double.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(new Complex(double.PositiveInfinity, 0), Complex.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(decimal.MaxValue, decimal.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(float.PositiveInfinity, float.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(Half.PositiveInfinity, Half.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(Int128.MaxValue, Int128.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(UInt128.MaxValue, UInt128.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(long.MaxValue, long.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(ulong.MaxValue, ulong.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(int.MaxValue, int.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(uint.MaxValue, uint.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(nint.MaxValue, nint.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(UIntPtr.MaxValue, UIntPtr.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(short.MaxValue, short.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(ushort.MaxValue, ushort.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(byte.MaxValue, byte.CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(sbyte.MaxValue, sbyte.CreateSaturating(QuantityValue.PositiveInfinity));
                // although there isn't any char.CreateSaturating(..) method, all numeric types support this conversion as well
                Assert.Equal(char.MaxValue, CreateSaturating<char, double>(double.PositiveInfinity));
                Assert.Equal(char.MaxValue, CreateSaturating<char, QuantityValue>(QuantityValue.PositiveInfinity));
            }

            [Fact]
            public void CreateSaturating_BigInteger_FromNegativeInfinity_ShouldThrowOverflowException()
            {
                Assert.Throws<OverflowException>(() => BigInteger.CreateSaturating(QuantityValue.NegativeInfinity));
            }

            [Fact]
            public void CreateSaturating_FromNegativeInfinity_ShouldReturnMinValueOrNegativeInfinity()
            {
                Assert.Equal(double.NegativeInfinity, double.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(new Complex(double.NegativeInfinity, 0), Complex.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(decimal.MinValue, decimal.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(float.NegativeInfinity, float.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(Half.NegativeInfinity, Half.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(Int128.MinValue, Int128.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(UInt128.MinValue, UInt128.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(long.MinValue, long.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(ulong.MinValue, ulong.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(int.MinValue, int.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(uint.MinValue, uint.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(nint.MinValue, nint.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(UIntPtr.MinValue, UIntPtr.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(short.MinValue, short.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(ushort.MinValue, ushort.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(byte.MinValue, byte.CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(sbyte.MinValue, sbyte.CreateSaturating(QuantityValue.NegativeInfinity));
                // although there isn't any char.CreateSaturating(..) method, all numeric types support this conversion as well
                Assert.Equal(char.MinValue, CreateSaturating<char, double>(double.NegativeInfinity));
                Assert.Equal(char.MinValue, CreateSaturating<char, QuantityValue>(QuantityValue.NegativeInfinity));
            }

            [Fact]
            public void CreateSaturating_WithUnsupportedType_ThrowsNotSupportedException()
            {
                Assert.Throws<NotSupportedException>(() => CreateSaturating<FakeNumber, QuantityValue>(QuantityValue.One));
            }
        }

        public class ConvertToTruncatingTests
        {
            private static TNumber CreateTruncating<TNumber, TOther>(TOther value)
                where TNumber : INumberBase<TNumber>
                where TOther : INumberBase<TOther>
            {
                return TNumber.CreateTruncating(value);
            }

            [Fact]
            public void CreateTruncating_FromFinitePositiveValue_ShouldReturnTheExpectedValue()
            {
                var quantityValue = new QuantityValue(3, 2);
                Assert.Equal(1.5, double.CreateTruncating(quantityValue));
                Assert.Equal(new Complex(1.5, 0), Complex.CreateTruncating(quantityValue));
                Assert.Equal(1.5m, decimal.CreateTruncating(quantityValue));
                Assert.Equal(1.5f, float.CreateTruncating(quantityValue));
                Assert.Equal((Half)1.5, Half.CreateTruncating(quantityValue));
                Assert.Equal(1, BigInteger.CreateTruncating(quantityValue));
                Assert.Equal(1, Int128.CreateTruncating(quantityValue));
                Assert.Equal(1u, UInt128.CreateTruncating(quantityValue));
                Assert.Equal(1, long.CreateTruncating(quantityValue));
                Assert.Equal((ulong)1, ulong.CreateTruncating(quantityValue));
                Assert.Equal(1, int.CreateTruncating(quantityValue));
                Assert.Equal((uint)1, uint.CreateTruncating(quantityValue));
                Assert.Equal(1, nint.CreateTruncating(quantityValue));
                Assert.Equal((UIntPtr)1, UIntPtr.CreateTruncating(quantityValue));
                Assert.Equal((short)1, short.CreateTruncating(quantityValue));
                Assert.Equal((ushort)1, ushort.CreateTruncating(quantityValue));
                Assert.Equal((byte)1, byte.CreateTruncating(quantityValue));
                Assert.Equal((sbyte)1, sbyte.CreateTruncating(quantityValue));
                // although there isn't any char.CreateTruncating(..) method, all numeric types support this conversion as well
                Assert.Equal('a', CreateTruncating<char, double>(97.9));
                Assert.Equal('a', CreateTruncating<char, QuantityValue>(new QuantityValue(979, 10)));
            }

            [Fact]
            public void CreateTruncating_FromFiniteNegativeValue_ShouldReturnTheExpectedValue()
            {
                var fraction = new QuantityValue(-3, 2);
                Assert.Equal(-1.5, double.CreateTruncating(fraction));
                Assert.Equal(new Complex(-1.5, 0), Complex.CreateTruncating(fraction));
                Assert.Equal(-1.5m, decimal.CreateTruncating(fraction));
                Assert.Equal(-1.5f, float.CreateTruncating(fraction));
                Assert.Equal((Half)(-1.5), Half.CreateTruncating(fraction));
                Assert.Equal(-1, BigInteger.CreateTruncating(fraction));
                Assert.Equal(-1, Int128.CreateTruncating(fraction));
                Assert.Equal(new UInt128(18446744073709551615, 18446744073709551615), UInt128.CreateTruncating(fraction));
                Assert.Equal(-1, long.CreateTruncating(fraction));
                Assert.Equal(ulong.MaxValue, ulong.CreateTruncating(fraction));
                Assert.Equal(-1, int.CreateTruncating(fraction));
                Assert.Equal(uint.MaxValue, uint.CreateTruncating(fraction));
                Assert.Equal(-1, nint.CreateTruncating(fraction));
                Assert.Equal(new UIntPtr(18446744073709551615), UIntPtr.CreateTruncating(fraction));
                Assert.Equal((short)-1, short.CreateTruncating(fraction));
                Assert.Equal(ushort.MaxValue, ushort.CreateTruncating(fraction));
                Assert.Equal(byte.MaxValue, byte.CreateTruncating(fraction));
                Assert.Equal((sbyte)-1, sbyte.CreateTruncating(fraction));
                // although there isn't any char.CreateTruncating(..) method, all numeric types support this conversion as well
                // note: for some reason the floating point types don't care implement an independent truncating method, instead they return the saturated result
                Assert.Equal(char.MinValue, CreateTruncating<char, double>(-1.5));
                Assert.Equal(char.MaxValue, CreateTruncating<char, int>(-1));
                Assert.Equal(char.MaxValue, CreateTruncating<char, QuantityValue>(fraction));
            }

            [Fact]
            public void CreateTruncating_FromNaN_ShouldReturnZeroOrNaN()
            {
                Assert.Equal(double.NaN, double.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(new Complex(double.NaN, 0), Complex.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(decimal.Zero, decimal.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(float.NaN, float.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(Half.NaN, Half.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(BigInteger.Zero, BigInteger.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(Int128.Zero, Int128.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(UInt128.Zero, UInt128.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(0, long.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(0UL, ulong.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(0, int.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(0U, uint.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(nint.Zero, nint.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(UIntPtr.Zero, UIntPtr.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(default, short.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(default, ushort.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(default, byte.CreateTruncating(QuantityValue.NaN));
                Assert.Equal(default, sbyte.CreateTruncating(QuantityValue.NaN));
                // although there isn't any char.CreateTruncating(..) method, all numeric types support this conversion as well
                Assert.Equal('\0', CreateTruncating<char, double>(double.NaN));
                Assert.Equal('\0', CreateTruncating<char, QuantityValue>(QuantityValue.NaN));
            }

            [Fact]
            public void CreateTruncating_BigInteger_FromPositiveInfinity_ShouldThrowOverflowException()
            {
                Assert.Throws<OverflowException>(() => BigInteger.CreateTruncating(QuantityValue.PositiveInfinity));
            }

            [Fact]
            public void CreateTruncating_FromPositiveInfinity_ShouldReturnMaxValueOrPositiveInfinity()
            {
                Assert.Equal(double.PositiveInfinity, double.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(new Complex(double.PositiveInfinity, 0), Complex.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(decimal.MaxValue, decimal.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(float.PositiveInfinity, float.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(Half.PositiveInfinity, Half.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(Int128.MaxValue, Int128.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(UInt128.MaxValue, UInt128.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(long.MaxValue, long.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(ulong.MaxValue, ulong.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(int.MaxValue, int.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(uint.MaxValue, uint.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(nint.MaxValue, nint.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(UIntPtr.MaxValue, UIntPtr.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(short.MaxValue, short.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(ushort.MaxValue, ushort.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(byte.MaxValue, byte.CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(sbyte.MaxValue, sbyte.CreateTruncating(QuantityValue.PositiveInfinity));
                // although there isn't any char.CreateTruncating(..) method, all numeric types support this conversion as well
                Assert.Equal(char.MaxValue, CreateTruncating<char, double>(double.PositiveInfinity));
                Assert.Equal(char.MaxValue, CreateTruncating<char, QuantityValue>(QuantityValue.PositiveInfinity));
            }

            [Fact]
            public void CreateTruncating_FromNegativeInfinity_BigInteger_ShouldThrowOverflowException()
            {
                Assert.Throws<OverflowException>(() => BigInteger.CreateTruncating(QuantityValue.NegativeInfinity));
            }

            [Fact]
            public void CreateTruncating_FromNegativeInfinity_ShouldReturnMinValueOrNegativeInfinity()
            {
                Assert.Equal(double.NegativeInfinity, double.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(new Complex(double.NegativeInfinity, 0), Complex.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(decimal.MinValue, decimal.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(float.NegativeInfinity, float.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(Half.NegativeInfinity, Half.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(Int128.MinValue, Int128.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(UInt128.MinValue, UInt128.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(long.MinValue, long.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(ulong.MinValue, ulong.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(int.MinValue, int.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(uint.MinValue, uint.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(nint.MinValue, nint.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(UIntPtr.MinValue, UIntPtr.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(short.MinValue, short.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(ushort.MinValue, ushort.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(byte.MinValue, byte.CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(sbyte.MinValue, sbyte.CreateTruncating(QuantityValue.NegativeInfinity));
                // although there isn't any char.CreateTruncating(..) method, all numeric types support this conversion as well
                Assert.Equal(char.MinValue, CreateTruncating<char, double>(double.NegativeInfinity));
                Assert.Equal(char.MinValue, CreateTruncating<char, QuantityValue>(QuantityValue.NegativeInfinity));
            }

            [Fact]
            public void CreateTruncating_WithUnsupportedType_ThrowsNotSupportedException()
            {
                Assert.Throws<NotSupportedException>(() => CreateTruncating<FakeNumber, QuantityValue>(QuantityValue.One));
            }
        }
#endif
    }
}
