using System.Numerics;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    public class FractionTests
    {
        [Theory]
        [InlineData(1, 1, 1, 1)]
        [InlineData(2, 1, 1, 2)]
        public void InverseTests(BigInteger num, BigInteger den, BigInteger expectedNum, BigInteger expectedDen)
        {
            var value = new QuantityValue(num, den);
            var expected = new QuantityValue(expectedNum, expectedDen);
            Assert.Equal(expected, QuantityValue.Inverse(value));
        }

        [Theory]
        [InlineData(0, 0, 0, 0)] // NaN
        [InlineData(1, 0, 1, 0)] // PositiveInfinity
        [InlineData(-1, 0, -1, 0)] // NegativeInfinity
        [InlineData(0, 1, 0, 1)] // Zero
        [InlineData(1, 1, 1, 1)] // One
        [InlineData(-1, 1, -1, 1)] // MinusOne
        [InlineData(2, 1, 2, 1)] // Two (whole number)
        [InlineData(2, 4, 1, 2)] // 2/4 -> 1/2 
        [InlineData(2, 5, 2, 5)] // 2/5 -> 2/5 (unchanged) 
        public void ReduceTests(BigInteger num, BigInteger den, BigInteger expectedNum, BigInteger expectedDen)
        {
            var value = new QuantityValue(num, den);
            var (numerator, denominator) = QuantityValue.Reduce(value);
            Assert.Equal(expectedNum, numerator);
            Assert.Equal(expectedDen, denominator);
        }
    }
}