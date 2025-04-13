using System.Numerics;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    public class RoundingTests
    {
        private static readonly QuantityValueData[] DecimalFractions = [
            0, 1, -1, 10, -10,
            0.5m, -0.5m, 0.55m, -0.55m, 1.5m, -1.5m, 1.55m, -1.55m,
            0.1m, -0.1m, 0.15m, -0.15m, 1.2m, -1.2m, 1.25m, -1.25m,
            1.5545665434654m, -1.5545665434654m,
            15.545665434654m, -15.545665434654m,
            155.45665434654m, -155.45665434654m,
            1554.5665434654m, -1554.5665434654m,
            15545.665434654m, -15545.665434654m,
            155456.65434654m, -155456.65434654m,
            new QuantityValue(1, 3), new QuantityValue(-1, 3),
            new QuantityValue(2, 3), new QuantityValue(-2, 3),
            new QuantityValue(1999999999999999991, 3), new QuantityValue(-1999999999999999991, 3),
            new QuantityValue(2000000000000000001, 3), new QuantityValue(-2000000000000000001, 3),
        ];
        
        private static readonly MidpointRounding[] RoundingModes = [
            MidpointRounding.ToEven,
            MidpointRounding.AwayFromZero,
#if NET
            MidpointRounding.ToZero,
            MidpointRounding.ToNegativeInfinity,
            MidpointRounding.ToPositiveInfinity
#endif
        ];

        public sealed class BigIntegerTestCases : TheoryData<QuantityValueData, MidpointRounding, BigInteger>
        {
            public BigIntegerTestCases()
            {
                foreach (var roundingMode in RoundingModes)
                {
                    foreach (var decimalFraction in DecimalFractions)
                    {
                        Add(decimalFraction, roundingMode, (BigInteger)Math.Round(decimalFraction.Value.ToDecimal(), roundingMode));
                    }
                }
            }
        }

        [Theory]
        [ClassData(typeof(BigIntegerTestCases))]
        public void RoundToBigInteger_ReturnsTheExpectedResult(QuantityValueData value, MidpointRounding mode, BigInteger expected)
        {
            Assert.Equal(expected, QuantityValue.Round(value, mode));
        }

        [Fact]
        public void RoundToBigInteger_Given_NaN_or_Infinity_ThrowsDivideByZeroException()
        {
            Assert.Throws<OverflowException>(() => QuantityValue.Round(QuantityValue.NaN, MidpointRounding.ToEven));
            Assert.Throws<OverflowException>(() => QuantityValue.Round(QuantityValue.PositiveInfinity, MidpointRounding.ToEven));
            Assert.Throws<OverflowException>(() => QuantityValue.Round(QuantityValue.NegativeInfinity, MidpointRounding.ToEven));
        }
        
        [Fact]
        public void RoundToBigInteger_WithInvalidRoundingMode_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => QuantityValue.Round(new QuantityValue(1, 2), (MidpointRounding)5));
        }
        
        [Fact]
        public void Round_ToNegativeDecimals_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => QuantityValue.Round(new QuantityValue(1, 2), -1));
        }

        public sealed class DecimalFractionsFractionTestCases : TheoryData<QuantityValueData, MidpointRounding, int, QuantityValueData>
        {
            private static readonly int[] DecimalPlaces = Enumerable.Range(0, 6).ToArray();
            
            public DecimalFractionsFractionTestCases()
            {
                foreach (var roundingMode in RoundingModes)
                {
                    foreach (var nbDecimals in DecimalPlaces)
                    {
                        foreach (var decimalFraction in DecimalFractions)
                        {
                            Add(decimalFraction, roundingMode, nbDecimals, Math.Round(decimalFraction.Value.ToDecimal(), nbDecimals, roundingMode));
                        }
                    }
                }
            }
        }
        
        [Theory]
        [ClassData(typeof(DecimalFractionsFractionTestCases))]
        public void Round_ReturnsTheExpectedResult(QuantityValueData value, MidpointRounding mode, int decimals, QuantityValueData expected)
        {
            Assert.Equal(expected.Value, QuantityValue.Round(value.Value, decimals, mode));
        }
    }
}
