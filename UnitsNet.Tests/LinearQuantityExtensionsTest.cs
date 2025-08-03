// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests;

public class LinearQuantityExtensionsTest
{
    [Theory]
    [InlineData(2.0, 2.0, 0.1, true)]
    [InlineData(2.0, 2.1, 0.1, true)]
    [InlineData(2.0, 2.2, 0.1, false)]
    [InlineData(2.0, 2.0, 0.0, true)]
    [InlineData(2.0, 2.1, 0.0, false)]
    public void Equals_WithTolerance_ReturnsExpectedResult(double value1, double value2, double tolerance, bool expected)
    {
        var quantity1 = Length.FromMeters(value1);
        var quantity2 = Length.FromMeters(value2);
        var toleranceQuantity = Length.FromMeters(tolerance);

        var result = quantity1.Equals(quantity2, toleranceQuantity);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Equals_WithToleranceAtTheLimit_ReturnsTrue()
    {
        var quantity = Length.FromMeters(1);
        var otherQuantity = Length.FromCentimeters(99);
        var tolerance = Length.FromMillimeters(10);

        Assert.Multiple(() =>
        {
            Assert.True(quantity.Equals(otherQuantity, tolerance), "Difference == Tolerance");
            Assert.True(quantity.Equals(otherQuantity, tolerance * 2), "Difference < Tolerance");
            Assert.False(quantity.Equals(otherQuantity, tolerance / 2), "Difference > Tolerance");
        },
        () =>
        {
            Assert.True(otherQuantity.Equals(quantity, tolerance), "Difference == Tolerance");
            Assert.True(otherQuantity.Equals(quantity, tolerance * 2), "Difference < Tolerance");
            Assert.False(otherQuantity.Equals(quantity, tolerance / 2), "Difference > Tolerance");
        });
    }

    [Theory]
    [InlineData(2.0, 2.0, 0.1, true)]
    [InlineData(2.0, 2.1, 0.1, true)]
    [InlineData(2.0, 2.2, 0.1, false)]
    [InlineData(2.0, 2.0, 0.0, true)]
    [InlineData(2.0, 2.1, 0.0, false)]
    public void Equals_IQuantityWithTolerance_ReturnsExpectedResult(double value1, double value2, double tolerance, bool expected)
    {
        var quantity1 = Length.FromMeters(value1);
        IQuantity quantity2 = Length.FromMeters(value2);
        var toleranceQuantity = Length.FromMeters(tolerance);

        var result = quantity1.Equals(quantity2, toleranceQuantity);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Equals_WithNullOther_ReturnsFalse()
    {
        var quantity = Length.FromMeters(2.0);
        var tolerance = Length.FromMeters(0.1);

        var result = quantity.Equals(null, tolerance);

        Assert.False(result);
    }

    [Fact]
    public void Equals_TQuantity_WithUnknownUnits_ThrowsUnitNotFoundException()
    {
        var quantity = Length.FromMeters(1);
        var invalidQuantity = new Length(1, (LengthUnit)(-1));
        Assert.Throws<UnitNotFoundException>(() => invalidQuantity.Equals(quantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => quantity.Equals(invalidQuantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => quantity.Equals(quantity, invalidQuantity));
    }

    [Fact]
    public void Equals_IQuantity_WithUnknownUnits_ThrowsUnitNotFoundException()
    {
        var quantity = Length.FromMeters(1);
        var invalidQuantity = new Length(1, (LengthUnit)(-1));
        Assert.Throws<UnitNotFoundException>(() => invalidQuantity.Equals((IQuantity)quantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => quantity.Equals((IQuantity)invalidQuantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => quantity.Equals((IQuantity)quantity, invalidQuantity));
    }

    [Fact]
    public void Equals_WithNegativeTolerance_ThrowsArgumentOutOfRangeException()
    {
        var quantity = Length.FromMeters(2.0);
        var other = Length.FromMeters(2.0);
        var tolerance = Length.FromMeters(-0.1);

        Assert.Throws<ArgumentOutOfRangeException>(() => quantity.Equals(other, tolerance));
        Assert.Throws<ArgumentOutOfRangeException>(() => quantity.Equals((IQuantity)other, tolerance));
    }

    [Fact]
    public void Sum_WithEmptyCollection_ReturnsZero()
    {
        Length[] quantities = [];

        Length result = quantities.Sum();

        Assert.Equal(Length.Zero, result);
    }

    [Fact]
    public void Sum_WithQuantities_ReturnsExpectedSum()
    {
        Length[] quantities = [Length.FromMeters(1.0), Length.FromCentimeters(200), Length.FromMeters(3.0)];

        Length result = quantities.Sum();

        Assert.Equal(Length.FromMeters(6.0), result);
    }

    [Fact]
    public void Sum_WithSelector_ReturnsExpectedSum()
    {
        Length[] quantities = [Length.FromMeters(1.0), Length.FromCentimeters(200), Length.FromMeters(3.0)];

        Length result = quantities.Sum(length => length);

        Assert.Equal(Length.FromMeters(6.0), result);
    }

    [Fact]
    public void Sum_WithSelectorAndUnit_ReturnsExpectedSum()
    {
        Length[] quantities = [Length.FromMeters(1.0), Length.FromCentimeters(200), Length.FromMeters(3.0)];

        Length result = quantities.Sum(length => length, LengthUnit.Centimeter);

        Assert.Equal(600, result.Value);
        Assert.Equal(LengthUnit.Centimeter, result.Unit);
    }

    [Fact]
    public void Average_WithEmptyCollection_ThrowsInvalidOperationException()
    {
        Length[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.Average());
    }

    [Fact]
    public void Average_WithSelector_ThrowsOnEmptyCollection()
    {
        Length[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.Average(length => length));
    }

    [Fact]
    public void Average_WithSelectorAndUnit_ThrowsOnEmptyCollection()
    {
        Length[] quantities = [];

        Assert.Throws<InvalidOperationException>(() => quantities.Average(length => length, LengthUnit.Centimeter));
    }

    [Fact]
    public void Average_WithQuantities_ReturnsExpectedAverage()
    {
        Length[] quantities = [Length.FromMeters(1.0), Length.FromMeters(2.0), Length.FromMeters(3.0)];

        Length result = quantities.Average();

        Assert.Equal(Length.FromMeters(2.0), result);
    }

    [Fact]
    public void Average_WithSelector_ReturnsExpectedAverage()
    {
        Length[] quantities = [Length.FromMeters(1.0), Length.FromCentimeters(200), Length.FromMeters(3.0)];

        Length result = quantities.Average(length => length);

        Assert.Equal(Length.FromMeters(2.0), result);
    }

    [Fact]
    public void Average_WithSelectorAndUnit_ReturnsExpectedAverage()
    {
        Length[] quantities = [Length.FromMeters(1.0), Length.FromCentimeters(200), Length.FromMeters(3.0)];

        Length result = quantities.Average(length => length, LengthUnit.Centimeter);

        Assert.Equal(200, result.Value);
        Assert.Equal(LengthUnit.Centimeter, result.Unit);
    }
}
