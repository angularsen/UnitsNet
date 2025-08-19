using JetBrains.Annotations;

namespace UnitsNet.Tests;

public partial class QuantityValueTests
{
    [TestSubject(typeof(QuantityValueExtensions))]
    public class ExtensionTests
    {
        [Fact]
        public void Sum_WithQuantityValues_ReturnsCorrectSum()
        {
            IEnumerable<QuantityValue> values = [1.0m, 2.0m, 3.0m];
            QuantityValue result = values.Sum();
            Assert.Equal(6.0m, result);
        }

        [Fact]
        public void Sum_WithEmptyCollection_ReturnsZero()
        {
            QuantityValue result = Array.Empty<QuantityValue>().Sum();
            Assert.Equal(QuantityValue.Zero, result);
        }

        [Fact]
        public void Sum_WithEmptySelector_ReturnsZero()
        {
            IEnumerable<QuantityValue> empty = Array.Empty<QuantityValue>();
            Assert.Equal(QuantityValue.Zero, empty.Select(value => value).Sum());
        }

        [Fact]
        public void Average_WithASingleValues_ReturnsTheSameValue()
        {
            IEnumerable<QuantityValue> values = [42];
            QuantityValue result = values.Average();
            Assert.Equal(42, result);
        }

        [Fact]
        public void Average_WithQuantityValues_ReturnsCorrectAverage()
        {
            IEnumerable<QuantityValue> values = [1.0m, 2.0m, 3.0m];
            QuantityValue result = values.Average();
            Assert.Equal(2.0m, result);
        }

        [Fact]
        public void Average_WithSelector_ReturnsCorrectAverage()
        {
            IEnumerable<QuantityValue> values = [1.0m, 2.0m, 3.0m];
            QuantityValue result = values.Select(v => v).Average();
            Assert.Equal(2.0m, result);
        }

        [Fact]
        public void Average_WithEmptyCollection_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => Array.Empty<QuantityValue>().Average());
        }

        [Fact]
        public void Average_WithEmptySelector_ThrowsInvalidOperationException()
        {
            IEnumerable<QuantityValue> empty = Array.Empty<QuantityValue>();
            Assert.Throws<InvalidOperationException>(() => empty.Select(v => v).Average());
        }

        [Theory]
        [InlineData(-1, 1, 0.1)]
        [InlineData(0, 1, 1)]
        [InlineData(1.0, 1, 10.0)]
        [InlineData(2.0, 1, 100.0)]
        [InlineData(3.0, 1, 1000.0)]
        [InlineData(4.2, 1, 15848.93192)]
        [InlineData(-10, 10, 0.1)]
        [InlineData(0, 10, 1)]
        [InlineData(10, 10, 10.0)]
        [InlineData(20, 10, 100.0)]
        [InlineData(30, 10, 1000.0)]
        public void ToLinearSpace_ReturnsCorrectLinearValue(decimal logValue, decimal scalingFactor, double expected)
        {
            var result = ((QuantityValue)logValue).ToLinearSpace(scalingFactor);
            Assert.Equal(expected, result, 5);
        }

        [Theory]
        [InlineData(-1, 1, 15, 0.1)]
        [InlineData(0, 1, 15, 1)]
        [InlineData(1.0, 1, 15, 10.0)]
        [InlineData(2.0, 1, 15, 100.0)]
        [InlineData(3.0, 1, 15, 1000.0)]
        [InlineData(4.2, 1, 8, 15848.932)]
        [InlineData(-10, 10, 15, 0.1)]
        [InlineData(0, 10, 15, 1)]
        [InlineData(10, 10, 5, 10.0)]
        [InlineData(20, 10, 5, 100.0)]
        [InlineData(30, 10, 5, 1000.0)]
        public void ToLinearSpace_WithSignificantDigits_ReturnsCorrectLinearValue(decimal logValue, decimal scalingFactor, byte significantDigits, decimal expected)
        {
            QuantityValue result = ((QuantityValue)logValue).ToLinearSpace(scalingFactor, significantDigits);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 1, 15, 0)]
        [InlineData(10.0, 1, 15, 1.0)]
        [InlineData(100.0, 1, 15, 2.0)]
        [InlineData(1000.0, 1, 15, 3.0)]
        [InlineData(100.0, 10, 15, 20)]
        [InlineData(1000.0, 10, 15, 30)]
        [InlineData(10000.0, 10, 15, 40)]
        public void ToLogSpace_ReturnsCorrectLogValue(decimal value, decimal scalingFactor, byte significantDigits, decimal expected)
        {
            QuantityValue result = ((QuantityValue)value).ToLogSpace(scalingFactor, significantDigits);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10.0, 1, 5, 1.0)]
        [InlineData(100.0, 1, 5, 2.0)]
        [InlineData(1000.0, 1, 5, 3.0)]
        [InlineData(100.0, 10, 15, 20)]
        [InlineData(1000.0, 10, 15, 30)]
        [InlineData(10000.0, 10, 15, 40)]
        public void ToLogSpace_WithQuantityValue_ReturnsCorrectLogValue(decimal value, decimal scalingFactor, byte significantDigits, decimal expected)
        {
            QuantityValue result = ((QuantityValue)value).ToLogSpace(scalingFactor, significantDigits);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public void ToLogSpace_WithZero_ReturnsNegativeInfinity(decimal scalingFactor)
        {
            QuantityValue result = QuantityValue.Zero.ToLogSpace(scalingFactor);
            Assert.True(QuantityValue.IsNegativeInfinity(result));
        }

        [Theory]
        [InlineData(-0.1, 1)]
        [InlineData(-1.0, 1)]
        [InlineData(-10, 1)]
        [InlineData(-0.1, 10)]
        [InlineData(-1, 10)]
        [InlineData(-10, 10)]
        public void ToLogSpace_WithNegativeValues_ReturnsNaN(decimal logValue, decimal scalingFactor)
        {
            QuantityValue result = ((QuantityValue)logValue).ToLogSpace(scalingFactor);
            Assert.True(QuantityValue.IsNaN(result));
        }

        [Theory]
        [InlineData(1.0, 1.0, 1, 2, 1.30)]
        [InlineData(1.0, 1.0, 1, 5, 1.3010)]
        [InlineData(2.0, 2.0, 1, 5, 2.301)]
        [InlineData(3.0, 3.0, 1, 5, 3.301)]
        [InlineData(1.0, -1.0, 1, 5, 1.0043)]
        [InlineData(1.0, -2.0, 1, 5, 1.0004)]
        [InlineData(0, -2.0, 1, 5, 0.0043214)]
        [InlineData(-1.0, -2.0, 1, 5, -0.95861)]
        [InlineData(1.0, 1.0, 10, 5, 4.0103)]
        [InlineData(2.0, 2.0, 10, 5, 5.0103)]
        [InlineData(3.0, 3.0, 10, 5, 6.0103)]
        [InlineData(10, 30, 20, 5, 30.828)]
        [InlineData(20, 30, 20, 5, 32.386)]
        [InlineData(30, 30, 20, 5, 36.020)]
        public void AddWithLogScaling_ReturnsCorrectLogSum(decimal leftValue, decimal rightValue, decimal scalingFactor, byte significantDigits, decimal expected)
        {
            QuantityValue result = QuantityValueExtensions.AddWithLogScaling(leftValue, rightValue, scalingFactor, significantDigits);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2.0, 1.0, 1, 5, 1.9542)]
        [InlineData(3.0, 1.0, 1, 5, 2.9956)]
        [InlineData(20, 10, 1, 12, 20)]
        [InlineData(30, 10, 1, 15, 30)]
        [InlineData(40, 10, 1, 15, 40)]
        [InlineData(2.0, 1.0, 10, 5, -4.8683)]
        [InlineData(3.0, 1.0, 10, 5, -1.3292)]
        [InlineData(20, 10, 10, 5, 19.542)]
        [InlineData(30, 10, 10, 5, 29.956)]
        [InlineData(40, 10, 10, 5, 39.996)]
        [InlineData(200, 100, 10, 12, 200)]
        [InlineData(300, 100, 10, 15, 300)]
        [InlineData(400, 100, 10, 15, 400)]
        public void SubtractWithLogScaling_ReturnsCorrectLogDifference(decimal leftValue, decimal rightValue, decimal scalingFactor, byte significantDigits,
            decimal expected)
        {
            QuantityValue result = QuantityValueExtensions.SubtractWithLogScaling(leftValue, rightValue, scalingFactor, significantDigits);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1.0, 1.0, 1, 5)]
        [InlineData(-1.0, -1.0, 1, 5)]
        [InlineData(1.0, 1.0, 10, 5)]
        [InlineData(-1.0, -1.0, 10, 5)]
        public void SubtractWithLogScaling_WithSameValues_ReturnsNegativeInfinity(decimal leftValue, decimal rightValue, decimal scalingFactor,
            byte significantDigits)
        {
            QuantityValue result = QuantityValueExtensions.SubtractWithLogScaling(leftValue, rightValue, scalingFactor, significantDigits);
            Assert.True(QuantityValue.IsNegativeInfinity(result));
        }

        [Theory]
        [InlineData(-20.0, 1, 1, 5)]
        [InlineData(-20.0, 1, 10, 5)]
        [InlineData(-1.0, 20, 1, 5)]
        [InlineData(-1.0, 20, 10, 5)]
        public void SubtractWithLogScaling_WithNegativeValues_ReturnsNaN(decimal leftValue, decimal rightValue, decimal scalingFactor, byte significantDigits)
        {
            QuantityValue result = QuantityValueExtensions.SubtractWithLogScaling(leftValue, rightValue, scalingFactor, significantDigits);
            Assert.True(QuantityValue.IsNaN(result));
        }
    }
}