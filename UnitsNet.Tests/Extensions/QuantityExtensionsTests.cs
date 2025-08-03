// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Diagnostics.CodeAnalysis;

namespace UnitsNet.Tests.Extensions;

[SuppressMessage("ReSharper", "InvokeAsExtensionMethod")]
public class QuantityExtensionsTests
{
    [Theory]
    [InlineData(25.0, 25.0, 0.1, true)] // Equal values
    // [InlineData(25.0, 25.1, 0.1, true)] // Within tolerance (but fails due to rounding)
    [InlineData(25.0, 25.1, 0.10001, true)] // Within tolerance
    [InlineData(25.0, 25.2, 0.1, false)] // Outside tolerance
    [InlineData(25.0, 25.0, 0.0, true)] // Zero tolerance, equal values
    [InlineData(25.0, 25.1, 0.0, false)] // Zero tolerance, different values
    public void Equals_Affine_IQuantity(double value1, double value2, double toleranceValue, bool expected)
    {
        var temperature1 = Temperature.FromDegreesCelsius(value1);
        IQuantity temperature2 = Temperature.FromDegreesCelsius(value2);
        var tolerance = TemperatureDelta.FromDegreesCelsius(toleranceValue);

        var result = QuantityExtensions.Equals(temperature1, temperature2, tolerance);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Equals_Affine_IQuantity_WithDifferentType_ReturnsFalse()
    {
        var temperature1 = Temperature.FromDegreesCelsius(25.0);
        IQuantity length = Length.From(1, LengthUnit.Meter); // no other affine quantity to compare with
        var tolerance = TemperatureDelta.FromDegreesCelsius(1);

        var result = QuantityExtensions.Equals(temperature1, length, tolerance);

        Assert.False(result);
    }

    [Fact]
    public void Equals_Linear_IQuantity_WithDifferentType_ReturnsFalse()
    {
        var mass = Mass.FromKilograms(25.0);
        IQuantity length = Length.From(1, LengthUnit.Meter);
        var tolerance = Mass.FromKilograms(1);

        var result = QuantityExtensions.Equals(mass, length, tolerance);

        Assert.False(result);
    }

    [Fact]
    public void Equals_Logarithmic_IQuantity_WithDifferentType_ReturnsFalse()
    {
        var powerRatio = PowerRatio.FromDecibelWatts(25.0);
        IQuantity level = Level.From(1, LevelUnit.Decibel);
        var tolerance = PowerRatio.FromDecibelWatts(1);

        var result = QuantityExtensions.Equals(powerRatio, level, tolerance);

        Assert.False(result);
    }

    [Fact]
    public void Equals_Affine_WithNullOther_ReturnsFalse()
    {
        var quantity = Temperature.FromDegreesCelsius(25.0);
        var tolerance = TemperatureDelta.FromDegreesCelsius(25.0);

        var result = QuantityExtensions.Equals(quantity, null, tolerance);

        Assert.False(result);
    }

    [Fact]
    public void Equals_Linear_WithNullOther_ReturnsFalse()
    {
        var quantity = Length.FromMeters(2.0);
        var tolerance = Length.FromMeters(0.1);

        var result = QuantityExtensions.Equals(quantity, null, tolerance);

        Assert.False(result);
    }

    [Fact]
    public void Equals_Logarithmic_WithNullOther_ReturnsFalse()
    {
        var quantity = PowerRatio.FromDecibelWatts(2.0);
        var tolerance = PowerRatio.FromDecibelWatts(0.1);

        var result = QuantityExtensions.Equals(quantity, null, tolerance);

        Assert.False(result);
    }

    [Theory]
    [InlineData(2.0, 2.0, 0.1, true)]
    // [InlineData(2.0, 2.1, 0.1, true)] // should be equal but fails due to rounding
    [InlineData(2.0, 2.1, 0.10001, true)]
    [InlineData(2.0, 2.2, 0.1, false)]
    [InlineData(2.0, 2.0, 0.0, true)]
    [InlineData(2.0, 2.1, 0.0, false)]
    public void IQuantity_Equals_IQuantity_ReturnsExpectedResult(double value1, double value2, double tolerance, bool expected)
    {
        IQuantity untypedQuantity1 = Length.FromMeters(value1);
        IQuantity untypedQuantity2 = Length.FromMeters(value2);
        IQuantity untypedToleranceQuantity = Length.FromMeters(tolerance);

        var result = QuantityExtensions.Equals(untypedQuantity1, untypedQuantity2, untypedToleranceQuantity);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2.0, 2.0, 0.1, true)]
    // [InlineData(2.0, 2.1, 0.1, true)] // should be equal but fails due to rounding
    [InlineData(2.0, 2.1, 0.10001, true)]
    [InlineData(2.0, 2.2, 0.1, false)]
    [InlineData(2.0, 2.0, 0.0, true)]
    [InlineData(2.0, 2.1, 0.0, false)]
    public void Equals_WithUntypedOtherAndTolerance_ReturnsExpectedResult(double value1, double value2, double tolerance, bool expected)
    {
        var quantity1 = Length.FromMeters(value1);
        IQuantity untypedQuantity2 = Length.FromMeters(value2);
        var toleranceQuantity = Length.FromMeters(tolerance);

        var result = QuantityExtensions.Equals(quantity1, untypedQuantity2, toleranceQuantity);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2.0, 2.0, 0.1, true)]
    // [InlineData(2.0, 2.1, 0.1, true)]  // should be equal but fails due to rounding
    [InlineData(2.0, 2.1, 0.10001, true)]
    [InlineData(2.0, 2.2, 0.1, false)]
    [InlineData(2.0, 2.0, 0.0, true)]
    [InlineData(2.0, 2.1, 0.0, false)]
    public void Equals_IQuantityWithTolerance_ReturnsExpectedResult(double value1, double value2, double tolerance, bool expected)
    {
        var quantity1 = Length.FromMeters(value1);
        IQuantity quantity2 = Length.FromMeters(value2);
        var toleranceQuantity = Length.FromMeters(tolerance);

        var result = QuantityExtensions.Equals(quantity1, quantity2, toleranceQuantity);

        Assert.Equal(expected, result);
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
        Assert.True(QuantityExtensions.Equals(quantity, (IQuantity)quantity, PowerRatio.Zero));
        Assert.True(QuantityExtensions.Equals(quantity, (IQuantity)quantity, maxTolerance));
        Assert.True(QuantityExtensions.Equals(quantity, (IQuantity)otherQuantity, largerTolerance));
        Assert.False(QuantityExtensions.Equals(quantity, (IQuantity)otherQuantity, smallerTolerance));
        // note: it's currently not possible to test this due to the rounding error from (quantity - otherQuantity)
        // Assert.True(quantity.Equals((IQuantity)otherQuantity, maxTolerance));
    }

    [Fact]
    public void Equals_Logarithmic_NullQuantity_ReturnsFalse()
    {
        var quantity = PowerRatio.FromDecibelWatts(1);
        var tolerance = PowerRatio.FromDecibelWatts(1);
        Assert.False(QuantityExtensions.Equals(quantity, null, tolerance));
    }

    [Fact(Skip = "Currently throws a NotImplementedException")]
    public void Equals_Linear_IQuantity_WithUnknownUnits_ThrowsUnitNotFoundException()
    {
        var quantity = Length.FromMeters(1);
        var invalidQuantity = new Length(1, (LengthUnit)(-1));
        Assert.Throws<UnitNotFoundException>(() => invalidQuantity.Equals((IQuantity)quantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => quantity.Equals((IQuantity)invalidQuantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => quantity.Equals((IQuantity)quantity, invalidQuantity));
    }

    [Fact(Skip = "Currently throws a NotImplementedException")]
    public void Equals_Logarithmic_IQuantity_WithUnknownUnits_ThrowsUnitNotFoundException()
    {
        var quantity = PowerRatio.FromDecibelWatts(1);
        var invalidQuantity = new PowerRatio(1, (PowerRatioUnit)(-1));
        Assert.Throws<UnitNotFoundException>(() => QuantityExtensions.Equals(invalidQuantity, (IQuantity)quantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => QuantityExtensions.Equals(quantity, (IQuantity)invalidQuantity, quantity));
        Assert.Throws<UnitNotFoundException>(() => QuantityExtensions.Equals(quantity, (IQuantity)quantity, invalidQuantity));
    }

    [Fact]
    public void Equals_Affine_WithNegativeTolerance_ThrowsArgumentOutOfRangeException()
    {
        var quantity = Temperature.FromDegreesCelsius(20);
        var other = Temperature.FromDegreesCelsius(21);
        var tolerance = TemperatureDelta.FromDegreesCelsius(-0.1);

        Assert.Throws<ArgumentOutOfRangeException>(() => quantity.Equals((IQuantity)other, tolerance));
    }

    [Fact]
    public void Equals_Linear_WithNegativeTolerance_ThrowsArgumentOutOfRangeException()
    {
        var quantity = Length.FromMeters(2.0);
        var other = Length.FromMeters(2.0);
        var tolerance = Length.FromMeters(-0.1);

        Assert.Throws<ArgumentOutOfRangeException>(() => quantity.Equals((IQuantity)other, tolerance));
    }

    [Fact]
    public void Equals_Logarithmic_WithNegativeTolerance_DoesNotThrowArgumentOutOfRangeException()
    {
        // note: unlike with vector quantities- a small tolerance maybe positive in one unit and negative in another
        var quantity = PowerRatio.FromDecibelWatts(1);
        var negativeTolerance = PowerRatio.FromDecibelWatts(-1);
        Assert.True(QuantityExtensions.Equals(quantity, (IQuantity)quantity, negativeTolerance));
    }

}
