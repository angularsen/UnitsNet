using System.Numerics;
using JetBrains.Annotations;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    [TestSubject(typeof(QuantityValue.QuantityValueDebugView))]
    public class DebugViewTests
    {
        [Theory]
        [InlineData(1, 1, true, 2)]
        [InlineData(2, 4, false, 5)]
        [InlineData(0, 1, true, 1)]
        [InlineData(1, 0, true, 1)] // Corner case: Denominator is zero
        [InlineData(-200, 1, true, 9)] // Negative numerator
        [InlineData(0, 0, true, 0)] // Both numerator and denominator are zero
        public void QuantityValueDebugView_Properties_ShouldReturnExpectedValues(
            int numerator, int denominator, bool expectedIsReduced, long expectedNbBits)
        {
            var value = new QuantityValue(new BigInteger(numerator), new BigInteger(denominator));
            var debugView = new QuantityValue.QuantityValueDebugView(value);

            Assert.Equal(expectedIsReduced, debugView.IsReduced);
            Assert.Equal(expectedNbBits, debugView.NbBits);
        }

        [Theory]
        [InlineData(1, 1, "1/1")]
        [InlineData(2, 4, "1/2")]
        [InlineData(0, 1, "0/1")]
        [InlineData(1, 0, "1/0")] // Corner case: Denominator is zero
        [InlineData(-1, 1, "-1/1")] // Negative numerator
        [InlineData(0, 0, "0/0")] // Both numerator and denominator are zero
        public void StringFormatsView_SimplifiedFraction_ShouldReturnExpectedString(
            int numerator, int denominator, string expectedSimplifiedFraction)
        {
            var value = new QuantityValue(new BigInteger(numerator), new BigInteger(denominator));
            var debugView = new QuantityValue.QuantityValueDebugView(value);

            Assert.Equal(expectedSimplifiedFraction, debugView.StringFormats.SimplifiedFraction);
        }
        
        [Theory]
        [InlineData(1.23)]
        [InlineData(-1.23)]
        [InlineData(100000)]
        [InlineData(0.00001)]
        public void StringFormatsView_GeneralFormat_ShouldReturnExpectedString(double decimalValue)
        {
            QuantityValue value = decimalValue;
            var debugView = new QuantityValue.QuantityValueDebugView(value);

            Assert.Equal(value.ToString("G"), debugView.StringFormats.GeneralFormat);
        }
        
        [Theory]
        [InlineData(1.23)]
        [InlineData(-1.23)]
        [InlineData(100000)]
        [InlineData(0.00001)]
        public void StringFormatsView_ShortFormat_ShouldReturnExpectedString(double decimalValue)
        {
            QuantityValue value = decimalValue;
            var debugView = new QuantityValue.QuantityValueDebugView(value);

            Assert.Equal(value.ToString("S"), debugView.StringFormats.ShortFormat);
        }

        [Theory]
        [InlineData(1, 1, 1, 1.0, 1.0)]
        [InlineData(2, 1, 2, 2.0, 2.0)]
        [InlineData(1, 2, 0, 0.5, 0.5)]
        [InlineData(0, 1, 0, 0.0, 0.0)]
        [InlineData(-1, 1, -1, -1.0, -1.0)] // Negative numerator
        [InlineData(1, -1, -1, -1.0, -1.0)] // Negative denominator
        public void NumericFormatsView_Properties_ShouldReturnExpectedValues(
            int numerator, int denominator, int expectedInteger, double expectedDouble, decimal expectedDecimal)
        {
            var value = new QuantityValue(new BigInteger(numerator), new BigInteger(denominator));
            var debugView = new QuantityValue.QuantityValueDebugView(value);

            Assert.Equal(expectedInteger, debugView.ValueFormats.Integer);
            Assert.Equal(expectedInteger, debugView.ValueFormats.Long);
            Assert.Equal(expectedDouble, debugView.ValueFormats.Double);
            Assert.Equal(expectedDecimal, debugView.ValueFormats.Decimal);
        }
    }
}