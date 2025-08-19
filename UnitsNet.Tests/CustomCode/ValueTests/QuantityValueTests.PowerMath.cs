using System.Globalization;
using System.Numerics;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    public class PowerMathTests
    {
        [Theory]
        [InlineData(18)]
        [InlineData(19)]
        [InlineData(36)]
        [InlineData(37)]
        [InlineData(54)]
        [InlineData(55)]
        public void PowerOfTen_Equals_BigIntegerPow(int power)
        {
            BigInteger powerOfTen = QuantityValue.PowerOfTen(power);
            var bigIntegerPower = BigInteger.Pow(10, power);
            Assert.Equal(bigIntegerPower, powerOfTen);
        }
        
        [Theory]
        [InlineData(0, 1, 1, 0, 1)] // 0^1 == 0
        [InlineData(2, 1, 0, 1, 1)] // 2^0 == 1
        [InlineData(2, 1, -1, 1, 2)] // 2^-1 == 1/2
        [InlineData(2, 1, -2, 1, 4)] // 2^-2 == 1/4
        [InlineData(-2, 1, -1, -1, 2)] // 2^-1 == -1/2
        [InlineData(-2, 1, -2, 1, 4)] // -2^-2 == 1/4
        [InlineData(0, 1, -2, 1, 0)] // 0^-2 == PositiveInfinity
        [InlineData(2, 1, 1, 2, 1)]
        [InlineData(1, 1, 2, 1, 1)]
        [InlineData(2, 1, 2, 4, 1)]
        [InlineData(3, 1, 2, 9, 1)]
        [InlineData(1, 2, 2, 1, 4)]
        public void PowTests(BigInteger num, BigInteger den, int power, BigInteger expectedNum, BigInteger expectedDen)
        {
            var value = new QuantityValue(num, den);
            var expected = new QuantityValue(expectedNum, expectedDen);

            var result = QuantityValue.Pow(value, power);

#if NET
            Assert.Equal(double.Pow(value.ToDouble(), power), result.ToDouble(), 15);
#endif
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(double.NaN, -2, double.NaN)]
        [InlineData(double.NaN, -1, double.NaN)]
        [InlineData(double.NaN, 0, 1)]
        [InlineData(double.NaN, 1, double.NaN)]
        [InlineData(double.NaN, 2, double.NaN)]
        [InlineData(double.PositiveInfinity, -2, 0)]
        [InlineData(double.PositiveInfinity, -1, 0)]
        [InlineData(double.PositiveInfinity, 0, 1)]
        [InlineData(double.PositiveInfinity, 1, double.PositiveInfinity)]
        [InlineData(double.PositiveInfinity, 2, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, -2, 0)]
        [InlineData(double.NegativeInfinity, -1, 0)]
        [InlineData(double.NegativeInfinity, 0, 1)]
        [InlineData(double.NegativeInfinity, 1, double.NegativeInfinity)]
        [InlineData(double.NegativeInfinity, 2, double.PositiveInfinity)]
        public void PowWithNaNOrInfinityTests(double number, int power, double expectedResult)
        {
            var result = QuantityValue.Pow(number, power);
#if NET
            Assert.Equal(double.Pow(number, power), result.ToDouble());
#endif
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(2, 1, 1, 1, 2, 1)]
        [InlineData(1, 1, 2, 1, 1, 1)]
        [InlineData(2, 1, 2, 2, 2, 1)]
        [InlineData(2, 1, 4, 2, 4, 1)]
        [InlineData(81, 1, 1, 2, 9, 1)]
        [InlineData(81, 1, 1, 4, 3, 1)]
        [InlineData(81, 1, 1, 10, 155184557391536, 100000000000000)]
        public void PowRationalTests(BigInteger num, BigInteger den, BigInteger powerNum, BigInteger powerDen, BigInteger expectedNum, BigInteger expectedDen)
        {
            var value = new QuantityValue(num, den);
            var power = new QuantityValue(powerNum, powerDen);
            var expected = new QuantityValue(expectedNum, expectedDen);
            Assert.Equal(expected, QuantityValue.Pow(value, power, 15));
        }

        [Theory]
        [InlineData(double.NaN, -3, double.NaN)]
        [InlineData(double.NaN, -2, double.NaN)]
        [InlineData(double.NaN, -1, double.NaN)]
        [InlineData(double.NaN, 0, 1)]
        [InlineData(double.NaN, 1, double.NaN)]
        [InlineData(double.NaN, 2, double.NaN)]
        [InlineData(double.NaN, 3, double.NaN)]
        [InlineData(double.PositiveInfinity, -3, 0)]
        [InlineData(double.PositiveInfinity, -2, 0)]
        [InlineData(double.PositiveInfinity, -1, 0)]
        [InlineData(double.PositiveInfinity, 0, 1)]
        [InlineData(double.PositiveInfinity, 1, double.PositiveInfinity)]
        [InlineData(double.PositiveInfinity, 2, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, -3, 0)]
        [InlineData(double.NegativeInfinity, -2, 0)]
        [InlineData(double.NegativeInfinity, -1, 0)]
        [InlineData(double.NegativeInfinity, 0, 1)]
        [InlineData(double.NegativeInfinity, 1, double.NegativeInfinity)]
        [InlineData(double.NegativeInfinity, 2, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, 3, double.NegativeInfinity)]
        public void PowRationalWithNaNOrInfinityTests(double number, double power, double expectedResult)
        {
            var result = QuantityValue.Pow(number, power);
#if NET
            Assert.Equal(double.Pow(number, power), result.ToDouble());
#endif
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sqrt_WithNegativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => QuantityValue.Sqrt(QuantityValue.One, -1));
        }

        [Theory]
        [InlineData(double.NaN)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Sqrt_WithSpecialValues_MatchesTheOutputOfMathSqrt(double doubleValue)
        {
            var expected = Math.Sqrt(doubleValue);

            var actual = QuantityValue.Sqrt(doubleValue);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0.1)]
        [InlineData(12.34)]
        [InlineData(0.01234)]
        [InlineData(123.45)]
        [InlineData(0.0012345)]
        public void Sqrt_WithLowAccuracy_MatchesTheOutputOfMathSqrt(double doubleValue)
        {
            var expected = Math.Sqrt(doubleValue);

            var actual = QuantityValue.Sqrt(doubleValue, 15);

            Assert.Equal(expected, actual.ToDouble(), 15);
        }

        [Theory]
        [InlineData(2, 1, 5)]
        [InlineData(10, 1, 5)]
        [InlineData(30, 20, 5)]
        [InlineData(4, 3, 5)]
        [InlineData(5, 3, 5)]
        [InlineData(12345678, 9, 5)] // reduced to 1371742/1
        [InlineData(123456789, 2, 7)]
        [InlineData(1, 2, 5)]
        [InlineData(1, 3, 5)]
        [InlineData(1, 10, 5)]
        [InlineData(2, 3, 5)]
        [InlineData(20, 30, 5)]
        [InlineData(9, 12345678, 5)] // reduced to 1/1371742
        [InlineData(2, 123456789, 7)]
        public void Sqrt_WithExactRoot_CalculatesExactly(int numerator, int denominator, int accuracy)
        {
            var expectedValue = new QuantityValue(numerator, denominator);
            var quantityValue = expectedValue * expectedValue;

            var actualValue = QuantityValue.Sqrt(quantityValue, accuracy);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void Sqrt_ReturnsNoLessThanTheSpecifiedNumberOfCorrectDigits()
        {
            // these are the first 100 decimal places (from http://www.numberworld.org/digits/Sqrt(2)/)
            const string firstOneHundredDecimals = "1.4142135623730950488016887242096980785696718753769480731766797379907324784621070388503875343276415727";
            var expected = QuantityValue.Parse(firstOneHundredDecimals, CultureInfo.InvariantCulture);
            Assert.All(Enumerable.Range(1, 100), digits =>
            {
                var result = QuantityValue.Sqrt(2, digits);
                AssertEx.EqualTolerance(expected, result, new QuantityValue(1, BigInteger.Pow(10, digits)));
            });
        }

        [Fact]
        public void Sqrt_ReturnsMoreThanTheSpecifiedNumberOfDigits()
        {
            // Sqrt(2, 1) ~= 14/10, Sqrt(2, 2) ~= 141/100.. Sqrt(2, n) = a/b with len(a) ~= n
            var tolerance = new QuantityValue(2038, 10000); // ~20.38%
            Assert.All(Enumerable.Range(1, 1000), digits =>
            {
                var result = QuantityValue.Sqrt(2, digits);
                var (numerator, _) = result;
                AssertEx.EqualTolerance(digits + 1, numerator.ToString().Length, tolerance);
            });
        }

        [Fact]
        public void Sqrt_WithVeryPreciseQuantityValue_CalculatesCorrectly()
        {
            // Arrange: a very precise quantity value ~ {0.3160846809101182}
            var numerator = BigInteger.Parse(
                "7017075566499415481183895525487656110361817123500083731653571771256593466607002465509486669805631606869622837818618382797847715440102824717432866745242640865976075222884078899654447525335854152217507362365722656250000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            var denominator = BigInteger.Parse(
                "22199986238797791147406259737557652523540869928960600626046611277198843489042928693958126769955174387224059480985453176875329090776309059513483264000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            var quantityValue = new QuantityValue(numerator, denominator);
            // Act
            var result = QuantityValue.Sqrt(quantityValue, 5);
            // Assert
            AssertEx.EqualTolerance(result, 0.56m, 0.1);
#if NET
            Assert.Equal(573312, result.Numerator);
            Assert.Equal(1019740, result.Denominator);
#else
            // since we don't have access to BigInteger.GetBitLength we are slightly more conservative (using a larger shift)
            Assert.Equal(1146624, result.Numerator);
            Assert.Equal(2039480, result.Denominator);
#endif
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(10, 1)]
        [InlineData(30, 20)]
        [InlineData(200, 300)]
        [InlineData(1234, 56789)]
        public void Sqrt_WithVeryLargeValue_CalculatesCorrectly(int numeratorScale, int denominatorScale)
        {
            var expectedValue = new QuantityValue(numeratorScale, denominatorScale) * double.MaxValue;
            var quantityValue = expectedValue * expectedValue;

            var actualValue = QuantityValue.Sqrt(quantityValue, 190); // double.MaxValue ~= 1.8e308 but the exact value is found early

            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(1, 10)]
        [InlineData(20, 30)]
        [InlineData(200, 300)]
        [InlineData(1234, 56789)]
        public void Sqrt_WithVerySmallValue_CalculatesCorrectly(int numeratorScale, int denominatorScale)
        {
            var expectedValue = new QuantityValue(numeratorScale, denominatorScale) / double.MaxValue;
            var quantityValue = expectedValue * expectedValue;

            var actualValue = QuantityValue.Sqrt(quantityValue, 190); // double.MaxValue ~= 1.8e308 but the exact value is found early

            Assert.Equal(expectedValue, actualValue);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(20)]
        [InlineData(300000)]
        [InlineData(9007199254740993)]
        [InlineData(long.MaxValue)]
        [InlineData(ulong.MaxValue)]
        public void Sqrt_WithWholeNumber_CalculatesWithTheSpecifiedAccuracy(ulong expectedValue)
        {
            var squaredValue = BigInteger.Pow(expectedValue, 2);
            var expectedString = expectedValue.ToString("G");
            var maxDigits = expectedString.Length;

            for (var digits = 1; digits < maxDigits; digits++)
            {
                var result = QuantityValue.Sqrt(squaredValue, digits);

                if (result == expectedValue)
                {
                    break; // the extra digits happened to be correct (compounding probability)
                }

                AssertEx.EqualTolerance(expectedValue, result, new QuantityValue(1, BigInteger.Pow(10, digits)));
            }

            Assert.Equal(expectedValue, QuantityValue.Sqrt(squaredValue, maxDigits));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(20)]
        [InlineData(300000)]
        [InlineData(9007199254740993)]
        [InlineData(long.MaxValue)]
        [InlineData(ulong.MaxValue)]
        public void Sqrt_WithLargeWholeNumber_CalculatesWithTheSpecifiedAccuracy(ulong scale)
        {
            var expectedValue = scale * (BigInteger)double.MaxValue;
            var squaredValue = BigInteger.Pow(expectedValue, 2);
            var expectedString = expectedValue.ToString("G");
            var maxDigits = expectedString.Length;

            for (var digits = 1; digits < maxDigits; digits++)
            {
                var result = QuantityValue.Sqrt(squaredValue, digits);

                if (result == expectedValue)
                {
                    break; // the extra digits happened to be correct (compounding probability)
                }

                AssertEx.EqualTolerance(expectedValue, result, new QuantityValue(1, BigInteger.Pow(10, digits)));
            }

            Assert.Equal(expectedValue, QuantityValue.Sqrt(squaredValue, maxDigits));
        }

        [Theory]
        // (x, -3)
        [InlineData(-3, -3, -0.693361274350635)]
        [InlineData(-2, -3, -0.7937005259841)]
        [InlineData(-1, -3, -1)]
        [InlineData(0, -3, double.PositiveInfinity)]
        [InlineData(1, -3, 1)]
        [InlineData(2, -3, 0.7937005259841)]
        [InlineData(3, -3, 0.693361274350635)]
        // (x, -2)
        [InlineData(-3, -2, double.NaN)]
        [InlineData(-2, -2, double.NaN)]
        [InlineData(-1, -2, double.NaN)]
        [InlineData(0, -2, double.PositiveInfinity)]
        [InlineData(1, -2, 1)]
        [InlineData(2, -2, 0.70710678118654802)]
        [InlineData(3, -2, 0.577350269189626)]
        // (x, -1)
        [InlineData(-3, -1, -0.333333333333333)]
        [InlineData(-2, -1, -0.5)]
        [InlineData(-1, -1, -1)]
        [InlineData(0, -1, double.PositiveInfinity)]
        [InlineData(1, -1, 1)]
        [InlineData(2, -1, 0.5)]
        [InlineData(3, -1, 0.333333333333333)]
        // (x, 0)
        [InlineData(-3, 0, double.NaN)] // NaN
        [InlineData(-2, 0, double.NaN)] // NaN
        [InlineData(-1, 0, double.NaN)] // NaN
        [InlineData(0, 0, double.NaN)] // NaN
        [InlineData(1, 0, double.NaN)] // NaN
        [InlineData(2, 0, double.NaN)] // NaN
        [InlineData(3, 0, double.NaN)] // NaN
        // (x, 1)
        [InlineData(-3, 1, -3)]
        [InlineData(-2, 1, -2)]
        [InlineData(-1, 1, -1)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 1, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(3, 1, 3)]
        // (x, 2)
        [InlineData(-3, 2, double.NaN)]
        [InlineData(-2, 2, double.NaN)]
        [InlineData(-1, 2, double.NaN)]
        [InlineData(0, 2, 0)]
        [InlineData(1, 2, 1)]
        [InlineData(2, 2, 1.414213562373095)]
        [InlineData(3, 2, 1.732050807568877)]
        // (x, 3)
        [InlineData(-3, 3, -1.4422495703074081)]
        [InlineData(-2, 3, -1.259921049894873)]
        [InlineData(-1, 3, -1)]
        [InlineData(0, 3, 0)]
        [InlineData(1, 3, 1)]
        [InlineData(2, 3, 1.259921049894873)]
        [InlineData(3, 3, 1.4422495703074081)]
        [InlineData(8, 3, 2)]
        [InlineData(27, 3, 3)]
        // (x, 4)
        [InlineData(16, 4, 2)]
        [InlineData(0.0625, 4, 0.5)]
        public void RootTests(double number, int root, double expectedValue)
        {
            QuantityValue quantityValue = number;

            var result = QuantityValue.RootN(quantityValue, root);
#if NET
            Assert.Equal(double.RootN(number, root), result.ToDouble(), 15);
#endif
            Assert.Equal(expectedValue, result.ToDouble(), 15);
        }

        [Theory]
        [InlineData(double.NaN, -3, double.NaN)]
        [InlineData(double.NaN, -2, double.NaN)]
        [InlineData(double.NaN, -1, double.NaN)]
        [InlineData(double.NaN, 0, double.NaN)]
        [InlineData(double.NaN, 1, double.NaN)]
        [InlineData(double.NaN, 2, double.NaN)]
        [InlineData(double.NaN, 3, double.NaN)]
        [InlineData(double.PositiveInfinity, -3, 0)]
        [InlineData(double.PositiveInfinity, -2, 0)]
        [InlineData(double.PositiveInfinity, -1, 0)]
        [InlineData(double.PositiveInfinity, 0, double.NaN)]
        [InlineData(double.PositiveInfinity, 1, double.PositiveInfinity)]
        [InlineData(double.PositiveInfinity, 2, double.PositiveInfinity)]
        [InlineData(double.NegativeInfinity, -3, 0)]
        [InlineData(double.NegativeInfinity, -2, double.NaN)]
        [InlineData(double.NegativeInfinity, -1, 0)]
        [InlineData(double.NegativeInfinity, 0, double.NaN)]
        [InlineData(double.NegativeInfinity, 1, double.NegativeInfinity)]
        [InlineData(double.NegativeInfinity, 2, double.NaN)]
        [InlineData(double.NegativeInfinity, 3, double.NegativeInfinity)]
        public void RootWithNaNOrInfinityTests(double number, int root, double expectedResult)
        {
            var result = QuantityValue.RootN(number, root);
#if NET
            Assert.Equal(double.RootN(number, root), result.ToDouble());
#endif
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void RootWithNegativeAccuracyThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => QuantityValue.RootN(1, 1, -1));
        }
    }
}
