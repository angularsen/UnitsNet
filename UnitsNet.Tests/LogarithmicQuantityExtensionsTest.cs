// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.


namespace UnitsNet.Tests;

public class LogarithmicQuantityExtensionsTest
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(100, 110)]
    [InlineData(100, 90)]
    public void Equals_TQuantity_ComparesInLinearSpace(double firstValue, double secondValue)
    {
        var quantity = PowerRatio.FromDecibelWatts(firstValue);
        var otherQuantity = PowerRatio.FromDecibelWatts(secondValue);
        PowerRatio maxTolerance = quantity > otherQuantity ? quantity - otherQuantity : otherQuantity - quantity;
        PowerRatio largerTolerance = maxTolerance * 1.1;
        PowerRatio smallerTolerance = maxTolerance / 1.1;
        Assert.True(quantity.Equals(quantity, PowerRatio.Zero));
        Assert.True(quantity.Equals(quantity, maxTolerance));
        Assert.True(quantity.Equals(otherQuantity, largerTolerance));
        Assert.False(quantity.Equals(otherQuantity, smallerTolerance));
        // note: it's currently not possible to test this due to the rounding error from (quantity - otherQuantity) 
        // Assert.True(quantity.Equals(otherQuantity, maxTolerance));
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(100, 110)]
    [InlineData(100, 90)]
    public void Equals_IQuantity_ComparesInLinearSpace(double firstValue, double secondValue)
    {
        var quantity = PowerRatio.FromDecibelWatts(firstValue);
        var otherQuantity = PowerRatio.FromDecibelWatts(secondValue);
        PowerRatio maxTolerance = quantity > otherQuantity ? quantity - otherQuantity : otherQuantity - quantity;
        PowerRatio largerTolerance = maxTolerance * 1.1;
        PowerRatio smallerTolerance = maxTolerance / 1.1;
        Assert.True(quantity.Equals((IQuantity)quantity, PowerRatio.Zero));
        Assert.True(quantity.Equals((IQuantity)quantity, maxTolerance));
        Assert.True(quantity.Equals((IQuantity)otherQuantity, largerTolerance));
        Assert.False(quantity.Equals((IQuantity)otherQuantity, smallerTolerance));
        // note: it's currently not possible to test this due to the rounding error from (quantity - otherQuantity) 
        // Assert.True(quantity.Equals((IQuantity)otherQuantity, maxTolerance));
    }

    [Fact]
    public void Equals_NullQuantity_ReturnsFalse()
    {
        var quantity = PowerRatio.FromDecibelWatts(1);
        var tolerance = PowerRatio.FromDecibelWatts(1);
        Assert.False(quantity.Equals(null, tolerance));
    }
    
    [Fact(Skip = "Currently throws a NotImplementedException")]
    public void Equals_TQuantity_WithUnknownUnits_ThrowsUnitNotFoundException()
    {
        var quantity = PowerRatio.FromDecibelWatts(1);
        var invalidQuantity = new PowerRatio(1, (PowerRatioUnit)(-1));
        Assert.Throws<UnitNotFoundException>(() => invalidQuantity.Equals(quantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => quantity.Equals(invalidQuantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => quantity.Equals(quantity, invalidQuantity));
    }
    
    [Fact(Skip = "Currently throws a NotImplementedException")]
    public void Equals_IQuantity_WithUnknownUnits_ThrowsUnitNotFoundException()
    {
        var quantity = PowerRatio.FromDecibelWatts(1);
        var invalidQuantity = new PowerRatio(1, (PowerRatioUnit)(-1));
        Assert.Throws<UnitNotFoundException>(() => invalidQuantity.Equals((IQuantity)quantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => quantity.Equals((IQuantity)invalidQuantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => quantity.Equals((IQuantity)quantity, invalidQuantity));
    }

    [Fact]
    public void Equals_WithNegativeTolerance_DoesNotThrowArgumentOutOfRangeException()
    {
        // note: unlike with vector quantities- a small tolerance maybe positive in one unit and negative in another
        var quantity = PowerRatio.FromDecibelWatts(1);
        var negativeTolerance = PowerRatio.FromDecibelWatts(-1);
        Assert.True(quantity.Equals(quantity, negativeTolerance));
        Assert.True(quantity.Equals((IQuantity)quantity, negativeTolerance));
    }

    [Fact]
    public void Sum_ThrowsOnEmptyCollection()
    {
        PowerRatio[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.Sum());
    }

    [Fact]
    public void Sum_WithSelector_ThrowsOnEmptyCollection()
    {
        PowerRatio[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.Sum(x => x));
    }

    [Fact]
    public void Sum_WithUnit_ThrowsOnEmptyCollection()
    {
        PowerRatio[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.Sum(PowerRatioUnit.DecibelWatt));
    }

    [Fact]
    public void Sum_WithSelectorAndUnit_ThrowsOnEmptyCollection()
    {
        PowerRatio[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.Sum(x => x, PowerRatioUnit.DecibelWatt));
    }

    [Fact]
    public void Sum_WithNullSequence_ThrowsArgumentNullException()
    {
        PowerRatio[] quantities = null!;

        Assert.Throws<ArgumentNullException>(() => quantities.Sum());
    }

    [Fact]
    public void Sum_WithNullSequenceAndUnit_ThrowsArgumentNullException()
    {
        PowerRatio[] quantities = null!;

        Assert.Throws<ArgumentNullException>(() => quantities.Sum(PowerRatioUnit.DecibelWatt));
    }

    [Fact]
    public void Sum_WithNullSelector_ThrowsArgumentNullException()
    {
        PowerRatio[] quantities = null!;

        Assert.Throws<ArgumentNullException>(() => quantities.Sum(x => x, PowerRatioUnit.DecibelWatt));
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt)]
    public void Sum_SingleQuantity_ReturnsCorrectSum(double value, PowerRatioUnit unit)
    {
        var quantity = new PowerRatio(value, unit);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity };

        PowerRatio result = quantities.Sum();

        Assert.Equal(quantity.Value, result.Value, 1e-5);
        Assert.Equal(quantity.Unit, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt)]
    public void Sum_SingleQuantity_WithSelector_ReturnsCorrectSum(double value, PowerRatioUnit unit)
    {
        var quantity = new PowerRatio(value, unit);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity };

        PowerRatio result = quantities.Sum(x => x);
        
        Assert.Equal(quantity.Value, result.Value, 1e-5);
        Assert.Equal(quantity.Unit, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(0, PowerRatioUnit.DecibelWatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, -1, PowerRatioUnit.DecibelWatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -10, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -2, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(10, PowerRatioUnit.DecibelWatt, 100, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(-10, PowerRatioUnit.DecibelMilliwatt, 20, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NaN, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.PositiveInfinity, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NegativeInfinity, PowerRatioUnit.DecibelWatt)]
    public void Sum_ReturnsCorrectSum(double value1, PowerRatioUnit unit1, double value2, PowerRatioUnit unit2)
    {
        var quantity1 = new PowerRatio(value1, unit1);
        var quantity2 = new PowerRatio(value2, unit2);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity1, quantity2 };
        PowerRatio expectedValue = quantity1 + quantity2;

        PowerRatio result = quantities.Sum();

        Assert.Equal(expectedValue.Value, result.Value, 1e-5);
        Assert.Equal(unit1, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(0, PowerRatioUnit.DecibelWatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, -1, PowerRatioUnit.DecibelWatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -10, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -2, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(10, PowerRatioUnit.DecibelWatt, 100, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(-10, PowerRatioUnit.DecibelMilliwatt, 20, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NaN, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.PositiveInfinity, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NegativeInfinity, PowerRatioUnit.DecibelWatt)]
    public void Sum_WithSelector_ReturnsCorrectSum(double value1, PowerRatioUnit unit1, double value2, PowerRatioUnit unit2)
    {
        var quantity1 = new PowerRatio(value1, unit1);
        var quantity2 = new PowerRatio(value2, unit2);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity1, quantity2 };
        PowerRatio expectedValue = quantity1 + quantity2;

        PowerRatio result = quantities.Sum(x => x);
        
        Assert.Equal(expectedValue.Value, result.Value, 1e-5);
        Assert.Equal(unit1, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(0, PowerRatioUnit.DecibelWatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, -1, PowerRatioUnit.DecibelWatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -10, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -2, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(10, PowerRatioUnit.DecibelWatt, 100, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(-10, PowerRatioUnit.DecibelMilliwatt, 20, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NaN, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.PositiveInfinity, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NegativeInfinity, PowerRatioUnit.DecibelWatt)]
    public void Sum_WithSelectorAndUnit_ReturnsCorrectSum(double value1, PowerRatioUnit unit1, double value2, PowerRatioUnit unit2)
    {
        var quantity1 = new PowerRatio(value1, unit1);
        var quantity2 = new PowerRatio(value2, unit2);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity1, quantity2 };
        PowerRatio expectedValue = quantity1 + quantity2;

        PowerRatio result = quantities.Sum(x => x, unit1);
        
        Assert.Equal(expectedValue.Value, result.Value, 1e-5);
        Assert.Equal(unit1, result.Unit);
    }

    [Fact]
    public void ArithmeticMean_ThrowsOnEmptyCollection()
    {
        PowerRatio[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => LogarithmicQuantityExtensions.ArithmeticMean(quantities));
    }

    [Fact]
    public void ArithmeticMean_WithSelector_ThrowsOnEmptyCollection()
    {
        PowerRatio[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.ArithmeticMean(x => x));
    }

    [Fact]
    public void ArithmeticMean_WithSelectorAndUnit_ThrowsOnEmptyCollection()
    {
        PowerRatio[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.ArithmeticMean(x => x, PowerRatioUnit.DecibelWatt));
    }

    [Fact]
    public void ArithmeticMean_WithNullSequence_ThrowsArgumentNullException()
    {
        PowerRatio[] quantities = null!;

        Assert.Throws<ArgumentNullException>(() => LogarithmicQuantityExtensions.ArithmeticMean(quantities));
    }

    [Fact]
    public void ArithmeticMean_WithNullSequenceAndUnit_ThrowsArgumentNullException()
    {
        PowerRatio[] quantities = null!;

        Assert.Throws<ArgumentNullException>(() => LogarithmicQuantityExtensions.ArithmeticMean(quantities, PowerRatioUnit.DecibelWatt));
    }

    [Fact]
    public void ArithmeticMean_WithNullSelector_ThrowsArgumentNullException()
    {
        PowerRatio[] quantities = null!;

        Assert.Throws<ArgumentNullException>(() => quantities.ArithmeticMean(x => x, PowerRatioUnit.DecibelWatt));
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt)]
    public void ArithmeticMean_SingleQuantity_ReturnsCorrectMean(double value, PowerRatioUnit unit)
    {
        var quantity = new PowerRatio(value, unit);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity };

        PowerRatio result = LogarithmicQuantityExtensions.ArithmeticMean(quantities);

        Assert.Equal(quantity.Value, result.Value, 1e-5);
        Assert.Equal(quantity.Unit, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt)]
    public void ArithmeticMean_SingleQuantity_WithSelector_ReturnsCorrectMean(double value, PowerRatioUnit unit)
    {
        var quantity = new PowerRatio(value, unit);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity };

        PowerRatio result = quantities.ArithmeticMean(x => x);
        
        Assert.Equal(quantity.Value, result.Value, 1e-5);
        Assert.Equal(quantity.Unit, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(0, PowerRatioUnit.DecibelWatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, -1, PowerRatioUnit.DecibelWatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -10, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -2, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(10, PowerRatioUnit.DecibelWatt, 100, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(-10, PowerRatioUnit.DecibelMilliwatt, 20, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NaN, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.PositiveInfinity, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NegativeInfinity, PowerRatioUnit.DecibelWatt)]
    public void ArithmeticMean_ReturnsCorrectMean(double value1, PowerRatioUnit unit1, double value2, PowerRatioUnit unit2)
    {
        var quantity1 = new PowerRatio(value1, unit1);
        var quantity2 = new PowerRatio(value2, unit2);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity1, quantity2 };
        var scalingFactor = PowerRatio.LogarithmicScalingFactor;
        var expectedValue =
            ((quantity1.Value.ToLinearSpace(scalingFactor) + quantity2.As(unit1).ToLinearSpace(scalingFactor)) / 2).ToLogSpace(scalingFactor);

        PowerRatio result = LogarithmicQuantityExtensions.ArithmeticMean(quantities);

        Assert.Equal(expectedValue, result.Value, 1e-5);
        Assert.Equal(unit1, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(0, PowerRatioUnit.DecibelWatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, -1, PowerRatioUnit.DecibelWatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -10, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -2, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(10, PowerRatioUnit.DecibelWatt, 100, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(-10, PowerRatioUnit.DecibelMilliwatt, 20, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NaN, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.PositiveInfinity, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NegativeInfinity, PowerRatioUnit.DecibelWatt)]
    public void ArithmeticMean_WithSelector_ReturnsCorrectMean(double value1, PowerRatioUnit unit1, double value2, PowerRatioUnit unit2)
    {
        var quantity1 = new PowerRatio(value1, unit1);
        var quantity2 = new PowerRatio(value2, unit2);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity1, quantity2 };
        var scalingFactor = PowerRatio.LogarithmicScalingFactor;
        var expectedValue =
            ((quantity1.Value.ToLinearSpace(scalingFactor) + quantity2.As(unit1).ToLinearSpace(scalingFactor)) / 2).ToLogSpace(scalingFactor);

        PowerRatio result = quantities.ArithmeticMean(x => x);

        Assert.Equal(expectedValue, result.Value, 1e-5);
        Assert.Equal(unit1, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(0, PowerRatioUnit.DecibelWatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, -1, PowerRatioUnit.DecibelWatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -10, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -2, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(10, PowerRatioUnit.DecibelWatt, 100, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(-10, PowerRatioUnit.DecibelMilliwatt, 20, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NaN, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.PositiveInfinity, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NegativeInfinity, PowerRatioUnit.DecibelWatt)]
    public void ArithmeticMean_WithSelectorAndUnit_ReturnsCorrectMean(double value1, PowerRatioUnit unit1, double value2, PowerRatioUnit unit2)
    {
        var quantity1 = new PowerRatio(value1, unit1);
        var quantity2 = new PowerRatio(value2, unit2);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity1, quantity2 };
        var scalingFactor = PowerRatio.LogarithmicScalingFactor;
        var expectedValue =
            ((quantity1.Value.ToLinearSpace(scalingFactor) + quantity2.As(unit1).ToLinearSpace(scalingFactor)) / 2).ToLogSpace(scalingFactor);

        PowerRatio result = quantities.ArithmeticMean(x => x, unit1);

        Assert.Equal(expectedValue, result.Value, 1e-5);
        Assert.Equal(unit1, result.Unit);
    }

    [Fact]
    public void GeometricMean_ThrowsOnEmptyCollection()
    {
        PowerRatio[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.GeometricMean());
    }

    [Fact]
    public void GeometricMean_WithSelector_ThrowsOnEmptyCollection()
    {
        PowerRatio[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.GeometricMean(x => x));
    }

    [Fact]
    public void GeometricMean_WithUnitAndSelector_ThrowsOnEmptyCollection()
    {
        PowerRatio[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.GeometricMean(x => x, PowerRatioUnit.DecibelWatt));
    }

    [Fact]
    public void GeometricMean_WithNullSequence_ThrowsArgumentNullException()
    {
        PowerRatio[] quantities = null!;

        Assert.Throws<ArgumentNullException>(() => quantities.GeometricMean());
    }

    [Fact]
    public void GeometricMean_WithNullSequenceAndUnit_ThrowsArgumentNullException()
    {
        PowerRatio[] quantities = null!;

        Assert.Throws<ArgumentNullException>(() => quantities.GeometricMean(PowerRatioUnit.DecibelWatt));
    }

    [Fact]
    public void GeometricMean_WithNullSelector_ThrowsArgumentNullException()
    {
        PowerRatio[] quantities = null!;

        Assert.Throws<ArgumentNullException>(() => quantities.GeometricMean(x => x, PowerRatioUnit.DecibelWatt));
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt)]
    public void GeometricMean_SingleQuantity_ReturnsCorrectMean(double value, PowerRatioUnit unit)
    {
        var quantity = new PowerRatio(value, unit);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity };

        PowerRatio result = quantities.GeometricMean();

        Assert.Equal(quantity.Value, result.Value, 1e-5);
        Assert.Equal(quantity.Unit, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt)]
    public void GeometricMean_SingleQuantity_WithSelector_ReturnsCorrectMean(double value, PowerRatioUnit unit)
    {
        var quantity = new PowerRatio(value, unit);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity };

        PowerRatio result = quantities.GeometricMean(x => x);

        Assert.Equal(quantity.Value, result.Value, 1e-5);
        Assert.Equal(quantity.Unit, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(0, PowerRatioUnit.DecibelWatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, -1, PowerRatioUnit.DecibelWatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -10, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -2, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(10, PowerRatioUnit.DecibelWatt, 100, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(-10, PowerRatioUnit.DecibelMilliwatt, 20, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NaN, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.PositiveInfinity, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NegativeInfinity, PowerRatioUnit.DecibelWatt)]
    public void GeometricMean_ReturnsCorrectMean(double value1, PowerRatioUnit unit1, double value2, PowerRatioUnit unit2)
    {
        var quantity1 = new PowerRatio(value1, unit1);
        var quantity2 = new PowerRatio(value2, unit2);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity1, quantity2 };
        var expectedValue = double.RootN(quantity1.Value + quantity2.As(unit1), 2);

        PowerRatio result = quantities.GeometricMean();

        Assert.Equal(expectedValue, result.Value, 1e-5);
        Assert.Equal(unit1, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(0, PowerRatioUnit.DecibelWatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, -1, PowerRatioUnit.DecibelWatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -10, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -2, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(10, PowerRatioUnit.DecibelWatt, 100, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(-10, PowerRatioUnit.DecibelMilliwatt, 20, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NaN, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.PositiveInfinity, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NegativeInfinity, PowerRatioUnit.DecibelWatt)]
    public void GeometricMean_WithSelector_ReturnsCorrectMean(double value1, PowerRatioUnit unit1, double value2, PowerRatioUnit unit2)
    {
        var quantity1 = new PowerRatio(value1, unit1);
        var quantity2 = new PowerRatio(value2, unit2);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity1, quantity2 };
        var expectedValue = double.RootN(quantity1.Value + quantity2.As(unit1), 2);

        PowerRatio result = quantities.GeometricMean(x => x);

        Assert.Equal(expectedValue, result.Value, 1e-5);
        Assert.Equal(unit1, result.Unit);
    }

    [Theory]
    [InlineData(0, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(0, PowerRatioUnit.DecibelWatt, 1, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, -1, PowerRatioUnit.DecibelWatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -10, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(2, PowerRatioUnit.DecibelMilliwatt, -2, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(10, PowerRatioUnit.DecibelWatt, 100, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(-10, PowerRatioUnit.DecibelMilliwatt, 20, PowerRatioUnit.DecibelMilliwatt)]
    [InlineData(double.NaN, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.PositiveInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(double.NegativeInfinity, PowerRatioUnit.DecibelMilliwatt, 1, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NaN, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.PositiveInfinity, PowerRatioUnit.DecibelWatt)]
    [InlineData(1, PowerRatioUnit.DecibelMilliwatt, double.NegativeInfinity, PowerRatioUnit.DecibelWatt)]
    public void GeometricMean_WithUnitAndSelector_ReturnsCorrectMean(double value1, PowerRatioUnit unit1, double value2, PowerRatioUnit unit2)
    {
        var quantity1 = new PowerRatio(value1, unit1);
        var quantity2 = new PowerRatio(value2, unit2);
        IEnumerable<PowerRatio> quantities = new List<PowerRatio> { quantity1, quantity2 };
        var expectedValue = double.RootN(quantity1.Value + quantity2.As(unit1), 2);

        PowerRatio result = quantities.GeometricMean(x => x, unit1);

        Assert.Equal(expectedValue, result.Value, 1e-5);
        Assert.Equal(unit1, result.Unit);
    }
}
