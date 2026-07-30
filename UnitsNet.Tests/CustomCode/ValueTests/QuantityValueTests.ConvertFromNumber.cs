using System.Numerics;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    public class ConvertFromNumberTests
    {
        [Theory]
        [InlineData(2.5123, 1, 3, 1)]
        [InlineData(2.5123, 2, 25, 10)]
        [InlineData(2.5123, 3, 251, 100)]
        [InlineData(25.123, 1, 25, 1)]
        [InlineData(251.23, 1, 250, 1)]
        [InlineData(double.PositiveInfinity, 1, 1, 0)]
        [InlineData(double.NegativeInfinity, 1, -1, 0)]
        [InlineData(double.NaN, 1, 0, 0)]
        public void FromDoubleRounded(double value, byte digits, BigInteger numerator, BigInteger denominator)
        {
            var convertedValue = QuantityValue.FromDoubleRounded(value, digits);
            Assert.Equal(numerator, convertedValue.Numerator);
            Assert.Equal(denominator, convertedValue.Denominator);
        }

        [Fact]
        public void FromDoubleRounded_WithZeroSignificantDigits_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => QuantityValue.FromDoubleRounded(2.5123, 0));
        }

        [Fact]
        public void FromDoubleRounded_WithMoreThan17SignificantDigits_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => QuantityValue.FromDoubleRounded(2.5123, 18));
        }

        [Theory]
        [InlineData(2, 3, 2, 3)]
        [InlineData(-2, -3, 2, 3)]
        [InlineData(-2, 3, -2, 3)]
        [InlineData(2, -3, -2, 3)]
        public void FromTerms_ReturnsTheExpectedResult(BigInteger numerator, BigInteger denominator, BigInteger expectedNumerator, BigInteger expectedDenominator)
        {
            Assert.Equal(new QuantityValue(expectedNumerator, expectedDenominator), QuantityValue.FromTerms(numerator, denominator));
        }

        [Theory]
        [InlineData(2, 3, 3, 2e3, 3)]
        [InlineData(-2, -3, 3, 2e3, 3)]
        [InlineData(-2, 3, 3, -2e3, 3)]
        [InlineData(2, -3, 3, -2e3, 3)]
        [InlineData(2, 3, -3, 2, 3e3)]
        [InlineData(-2, -3, -3, 2, 3e3)]
        [InlineData(-2, 3, -3, -2, 3e3)]
        [InlineData(2, -3, -3, -2, 3e3)]
        public void FromPowerOfTen_ReturnsTheExpectedResult(BigInteger numerator, BigInteger denominator, int powerOfTen, BigInteger expectedNumerator, BigInteger expectedDenominator)
        {
            Assert.Equal(new QuantityValue(expectedNumerator, expectedDenominator), QuantityValue.FromPowerOfTen(numerator, denominator, powerOfTen));
        }

        [Fact]
        public void FromPowerOfTen_WithWholeNumber_ReturnsTheExpectedResult()
        {
            Assert.Equal(0.05m, QuantityValue.FromPowerOfTen(5, -2));
        }

        public class ImplicitConversionTests
        {
            [Fact]
            public void ImplicitConversionFromByte()
            {
                const byte valueToConvert = 10;
                QuantityValue convertedValue = valueToConvert;
                Assert.Equal(convertedValue.Numerator, valueToConvert);
                Assert.Equal(convertedValue.Denominator, BigInteger.One);
            }
            
            [Fact]
            public void ImplicitConversionFromSByte()
            {
                const sbyte valueToConvert = -10;
                QuantityValue convertedValue = valueToConvert;
                Assert.Equal(convertedValue.Numerator, valueToConvert);
                Assert.Equal(convertedValue.Denominator, BigInteger.One);
            }

            [Fact]
            public void ImplicitConversionFromShort()
            {
                const short valueToConvert = 10;
                QuantityValue convertedValue = valueToConvert;
                Assert.Equal(convertedValue.Numerator, valueToConvert);
                Assert.Equal(convertedValue.Denominator, BigInteger.One);
            }

            [Fact]
            public void ImplicitConversionFromUShort()
            {
                const ushort valueToConvert = 10;
                QuantityValue convertedValue = valueToConvert;
                Assert.Equal(convertedValue.Numerator, valueToConvert);
                Assert.Equal(convertedValue.Denominator, BigInteger.One);
            }

            [Fact]
            public void ImplicitConversionFromInt()
            {
                const int valueToConvert = 10;
                QuantityValue convertedValue = valueToConvert;
                Assert.Equal(convertedValue.Numerator, valueToConvert);
                Assert.Equal(convertedValue.Denominator, BigInteger.One);
            }

            [Fact]
            public void ImplicitConversionFromUInt()
            {
                const uint valueToConvert = 10;
                QuantityValue convertedValue = valueToConvert;
                Assert.Equal(convertedValue.Numerator, valueToConvert);
                Assert.Equal(convertedValue.Denominator, BigInteger.One);
            }

            [Fact]
            public void ImplicitConversionFromLong()
            {
                const long valueToConvert = 10;
                QuantityValue convertedValue = valueToConvert;
                Assert.Equal(convertedValue.Numerator, valueToConvert);
                Assert.Equal(convertedValue.Denominator, BigInteger.One);
            }

            [Fact]
            public void ImplicitConversionFromULong()
            {
                const ulong valueToConvert = 10;
                QuantityValue convertedValue = valueToConvert;
                Assert.Equal(convertedValue.Numerator, valueToConvert);
                Assert.Equal(convertedValue.Denominator, BigInteger.One);
            }

            [Theory]
            [InlineData(2.5, 25, 10)]
            [InlineData(-2.5, -25, 10)]
            public void ImplicitConversionFromDecimal(decimal value, BigInteger numerator, BigInteger denominator)
            {
                QuantityValue convertedValue = value;
                Assert.Equal(numerator, convertedValue.Numerator);
                Assert.Equal(denominator, convertedValue.Denominator);
            }

            [Fact]
            public void ImplicitConversionFromFloat()
            {
                const float valueToConvert = 10.5f;
                QuantityValue convertedValue = valueToConvert;
                Assert.Equal(convertedValue.Numerator, 105);
                Assert.Equal(convertedValue.Denominator, 10);
            }

            [Theory]
            [InlineData(0, 0, 1)]
            [InlineData(double.NaN, 0, 0)]
            [InlineData(double.PositiveInfinity, 1, 0)]
            [InlineData(double.NegativeInfinity, -1, 0)]
            [InlineData(2, 2, 1)]
            [InlineData(2.5, 25, 10)]
            [InlineData(-2.5, -25, 10)]
            [InlineData(0.123, 123, 1000)]
            public void ImplicitConversionFromDouble(double value, BigInteger numerator, BigInteger denominator)
            {
                QuantityValue convertedValue = value;
                Assert.Equal(numerator, convertedValue.Numerator);
                Assert.Equal(denominator, convertedValue.Denominator);
            }
        }

#if NET
        public class ConvertFromCheckedTests
        {
            private static TNumber CreateChecked<TNumber, TOther>(TOther value)
                where TNumber : INumberBase<TNumber>
                where TOther : INumberBase<TOther>
            {
                return TNumber.CreateChecked(value);
            }

            private static QuantityValue CreateChecked<TOther>(TOther number) where TOther : INumberBase<TOther>
            {
                return CreateChecked<QuantityValue, TOther>(number);
            }

            [Fact]
            public void CreateChecked_WithARealFiniteNumber_ShouldReturnTheConvertedValue()
            {
                Assert.Equal(new QuantityValue(1, 3), CreateChecked(new QuantityValue(1, 3)));
                Assert.Equal(new QuantityValue(3, 2), CreateChecked(1.5));
                Assert.Equal(new QuantityValue(3, 2), CreateChecked(new Complex(1.5, 0)));
                Assert.Equal(new QuantityValue(3, 2), CreateChecked(1.5m));
                Assert.Equal(new QuantityValue(3, 2), CreateChecked((Half)1.5));
                Assert.Equal(QuantityValue.One, CreateChecked(BigInteger.One));
                Assert.Equal(QuantityValue.One, CreateChecked(Int128.One));
                Assert.Equal(QuantityValue.One, CreateChecked(UInt128.One));
                Assert.Equal(QuantityValue.One, CreateChecked(1L));
                Assert.Equal(QuantityValue.One, CreateChecked(1UL));
                Assert.Equal(QuantityValue.One, CreateChecked(1));
                Assert.Equal(QuantityValue.One, CreateChecked(1U));
                Assert.Equal(QuantityValue.One, CreateChecked((nint)1));
                Assert.Equal(QuantityValue.One, CreateChecked((UIntPtr)1));
                Assert.Equal(QuantityValue.One, CreateChecked((short)1));
                Assert.Equal(QuantityValue.One, CreateChecked((ushort)1));
                Assert.Equal(QuantityValue.One, CreateChecked((byte)1));
                Assert.Equal(QuantityValue.One, CreateChecked((sbyte)1));
                Assert.Equal(new QuantityValue(97), CreateChecked('a'));
            }

            [Fact]
            public void CreateChecked_WithANaN_ShouldReturnNaN()
            {
                Assert.Equal(QuantityValue.NaN, CreateChecked(QuantityValue.NaN));
                Assert.Equal(QuantityValue.NaN, CreateChecked(double.NaN));
                Assert.Equal(QuantityValue.NaN, CreateChecked(float.NaN));
                Assert.Equal(QuantityValue.NaN, CreateChecked(Half.NaN));
                Assert.Equal(QuantityValue.NaN, CreateChecked(Complex.NaN));
            }

            [Fact]
            public void CreateChecked_WithARealPositiveInfinity_ShouldReturnPositiveInfinity()
            {
                Assert.Equal(QuantityValue.PositiveInfinity, CreateChecked(QuantityValue.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateChecked(double.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateChecked(float.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateChecked(Half.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateChecked(new Complex(double.PositiveInfinity, 0)));
            }

            [Fact]
            public void CreateChecked_WithARealNegativeInfinity_ShouldReturnNegativeInfinity()
            {
                Assert.Equal(QuantityValue.NegativeInfinity, CreateChecked(QuantityValue.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateChecked(double.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateChecked(float.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateChecked(Half.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateChecked(new Complex(double.NegativeInfinity, 0)));
            }

            [Fact]
            public void CreateChecked_WithAComplexNumberHavingAnImaginaryPart_ShouldReturnNaN()
            {
                Assert.Equal(QuantityValue.NaN, CreateChecked(Complex.ImaginaryOne));
                Assert.Equal(QuantityValue.NaN, CreateChecked(Complex.Infinity));
            }

            [Fact]
            public void CreateChecked_WithAnUnsupportedType_ThrowsNotSupportedException()
            {
                Assert.Throws<NotSupportedException>(() => CreateChecked(FakeNumber.Zero));
            }
        }

        public class ConvertFromSaturatingTests
        {
            private static TNumber CreateSaturating<TNumber, TOther>(TOther value)
                where TNumber : INumberBase<TNumber>
                where TOther : INumberBase<TOther>
            {
                return TNumber.CreateSaturating(value);
            }

            private static QuantityValue CreateSaturating<TOther>(TOther number) where TOther : INumberBase<TOther>
            {
                return CreateSaturating<QuantityValue, TOther>(number);
            }

            [Fact]
            public void CreateSaturating_WithARealFiniteNumber_ShouldReturnTheConvertedQuantityValue()
            {
                Assert.Equal(new QuantityValue(1, 3), CreateSaturating(new QuantityValue(1, 3)));
                Assert.Equal(new QuantityValue(3, 2), CreateSaturating(1.5));
                Assert.Equal(new QuantityValue(3, 2), CreateSaturating(new Complex(1.5, 0)));
                Assert.Equal(new QuantityValue(3, 2), CreateSaturating(1.5m));
                Assert.Equal(new QuantityValue(3, 2), CreateSaturating((Half)1.5));
                Assert.Equal(QuantityValue.One, CreateSaturating(BigInteger.One));
                Assert.Equal(QuantityValue.One, CreateSaturating(Int128.One));
                Assert.Equal(QuantityValue.One, CreateSaturating(UInt128.One));
                Assert.Equal(QuantityValue.One, CreateSaturating(1L));
                Assert.Equal(QuantityValue.One, CreateSaturating(1UL));
                Assert.Equal(QuantityValue.One, CreateSaturating(1));
                Assert.Equal(QuantityValue.One, CreateSaturating(1U));
                Assert.Equal(QuantityValue.One, CreateSaturating((nint)1));
                Assert.Equal(QuantityValue.One, CreateSaturating((UIntPtr)1));
                Assert.Equal(QuantityValue.One, CreateSaturating((short)1));
                Assert.Equal(QuantityValue.One, CreateSaturating((ushort)1));
                Assert.Equal(QuantityValue.One, CreateSaturating((byte)1));
                Assert.Equal(QuantityValue.One, CreateSaturating((sbyte)1));
                Assert.Equal(new QuantityValue(97), CreateSaturating('a'));
            }

            [Fact]
            public void CreateSaturating_WithANaN_ShouldReturnNaN()
            {
                Assert.Equal(QuantityValue.NaN, CreateSaturating(QuantityValue.NaN));
                Assert.Equal(QuantityValue.NaN, CreateSaturating(double.NaN));
                Assert.Equal(QuantityValue.NaN, CreateSaturating(float.NaN));
                Assert.Equal(QuantityValue.NaN, CreateSaturating(Half.NaN));
                Assert.Equal(QuantityValue.NaN, CreateSaturating(Complex.NaN));
            }

            [Fact]
            public void CreateSaturating_WithARealPositiveInfinity_ShouldReturnPositiveInfinity()
            {
                Assert.Equal(QuantityValue.PositiveInfinity, CreateSaturating(QuantityValue.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateSaturating(double.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateSaturating(float.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateSaturating(Half.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateSaturating(new Complex(double.PositiveInfinity, 0)));
            }

            [Fact]
            public void CreateSaturating_WithARealNegativeInfinity_ShouldReturnNegativeInfinity()
            {
                Assert.Equal(QuantityValue.NegativeInfinity, CreateSaturating(QuantityValue.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateSaturating(double.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateSaturating(float.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateSaturating(Half.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateSaturating(new Complex(double.NegativeInfinity, 0)));
            }

            [Fact]
            public void CreateSaturating_WithAComplexNumberHavingAnImaginaryPart_ShouldReturnNaN()
            {
                Assert.Equal(0, CreateSaturating<double, Complex>(Complex.ImaginaryOne));
                Assert.Equal(QuantityValue.Zero, CreateSaturating(Complex.ImaginaryOne));
                Assert.Equal(double.PositiveInfinity, CreateSaturating<double, Complex>(Complex.Infinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateSaturating(Complex.Infinity));
            }

            [Fact]
            public void CreateSaturating_WithAnUnsupportedType_ThrowsNotSupportedException()
            {
                Assert.Throws<NotSupportedException>(() => CreateSaturating(FakeNumber.Zero));
            }
        }

        public class ConvertFromTruncatingTests
        {
            private static TNumber CreateTruncating<TNumber, TOther>(TOther value)
                where TNumber : INumberBase<TNumber>
                where TOther : INumberBase<TOther>
            {
                return TNumber.CreateTruncating(value);
            }

            private static QuantityValue CreateTruncating<TOther>(TOther number) where TOther : INumberBase<TOther>
            {
                return CreateTruncating<QuantityValue, TOther>(number);
            }

            [Fact]
            public void CreateTruncating_WithARealFiniteNumber_ShouldReturnTheConvertedQuantityValue()
            {
                Assert.Equal(new QuantityValue(1, 3), CreateTruncating(new QuantityValue(1, 3)));
                Assert.Equal(new QuantityValue(3, 2), CreateTruncating(1.5));
                Assert.Equal(new QuantityValue(3, 2), CreateTruncating(new Complex(1.5, 0)));
                Assert.Equal(new QuantityValue(3, 2), CreateTruncating(1.5m));
                Assert.Equal(new QuantityValue(3, 2), CreateTruncating((Half)1.5));
                Assert.Equal(QuantityValue.One, CreateTruncating(BigInteger.One));
                Assert.Equal(QuantityValue.One, CreateTruncating(Int128.One));
                Assert.Equal(QuantityValue.One, CreateTruncating(UInt128.One));
                Assert.Equal(QuantityValue.One, CreateTruncating(1L));
                Assert.Equal(QuantityValue.One, CreateTruncating(1UL));
                Assert.Equal(QuantityValue.One, CreateTruncating(1));
                Assert.Equal(QuantityValue.One, CreateTruncating(1U));
                Assert.Equal(QuantityValue.One, CreateTruncating((nint)1));
                Assert.Equal(QuantityValue.One, CreateTruncating((UIntPtr)1));
                Assert.Equal(QuantityValue.One, CreateTruncating((short)1));
                Assert.Equal(QuantityValue.One, CreateTruncating((ushort)1));
                Assert.Equal(QuantityValue.One, CreateTruncating((byte)1));
                Assert.Equal(QuantityValue.One, CreateTruncating((sbyte)1));
                Assert.Equal(new QuantityValue(97), CreateTruncating('a'));
            }

            [Fact]
            public void CreateTruncating_WithANaN_ShouldReturnNaN()
            {
                Assert.Equal(QuantityValue.NaN, CreateTruncating(QuantityValue.NaN));
                Assert.Equal(QuantityValue.NaN, CreateTruncating(double.NaN));
                Assert.Equal(QuantityValue.NaN, CreateTruncating(float.NaN));
                Assert.Equal(QuantityValue.NaN, CreateTruncating(Half.NaN));
                Assert.Equal(QuantityValue.NaN, CreateTruncating(Complex.NaN));
            }

            [Fact]
            public void CreateTruncating_WithARealPositiveInfinity_ShouldReturnPositiveInfinity()
            {
                Assert.Equal(QuantityValue.PositiveInfinity, CreateTruncating(QuantityValue.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateTruncating(double.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateTruncating(float.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateTruncating(Half.PositiveInfinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateTruncating(new Complex(double.PositiveInfinity, 0)));
            }

            [Fact]
            public void CreateTruncating_WithARealNegativeInfinity_ShouldReturnNegativeInfinity()
            {
                Assert.Equal(QuantityValue.NegativeInfinity, CreateTruncating(QuantityValue.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateTruncating(double.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateTruncating(float.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateTruncating(Half.NegativeInfinity));
                Assert.Equal(QuantityValue.NegativeInfinity, CreateTruncating(new Complex(double.NegativeInfinity, 0)));
            }

            [Fact]
            public void CreateTruncating_WithAComplexNumberHavingAnImaginaryPart_ShouldReturnNaN()
            {
                Assert.Equal(0, CreateTruncating<double, Complex>(Complex.ImaginaryOne));
                Assert.Equal(QuantityValue.Zero, CreateTruncating(Complex.ImaginaryOne));
                Assert.Equal(double.PositiveInfinity, CreateTruncating<double, Complex>(Complex.Infinity));
                Assert.Equal(QuantityValue.PositiveInfinity, CreateTruncating(Complex.Infinity));
            }

            [Fact]
            public void CreateTruncating_WithAnUnsupportedType_ThrowsNotSupportedException()
            {
                Assert.Throws<NotSupportedException>(() => CreateTruncating(FakeNumber.Zero));
            }
        }

#endif
    }
}
