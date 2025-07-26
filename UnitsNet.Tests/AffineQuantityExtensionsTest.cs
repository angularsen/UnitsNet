// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests;

public class AffineQuantityExtensionsTest
{
    [Theory]
    [InlineData(25.0, 25.0, 0.1, true)] // Equal values
    [InlineData(25.0, 25.1, 0.1, true)] // Within tolerance
    [InlineData(25.0, 25.2, 0.1, false)] // Outside tolerance
    [InlineData(25.0, 25.0, 0.0, true)] // Zero tolerance, equal values
    [InlineData(25.0, 25.1, 0.0, false)] // Zero tolerance, different values
    public void Equals_Temperature_TemperatureDelta(double value1, double value2, double toleranceValue, bool expected)
    {
        var temperature1 = Temperature.FromDegreesCelsius(value1);
        var temperature2 = Temperature.FromDegreesCelsius(value2);
        var tolerance = TemperatureDelta.FromDegreesCelsius(toleranceValue);

        var result = temperature1.Equals(temperature2, tolerance);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Equals_WithToleranceAtTheLimit_ReturnsTrue()
    {
        var quantity = Temperature.FromDegreesCelsius(1);
        var otherQuantity = Temperature.FromMillidegreesCelsius(999);
        var tolerance = TemperatureDelta.FromMillidegreesCelsius(1);

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

    [Fact]
    public void Equals_Temperature_TemperatureDelta_ThrowsArgumentOutOfRangeException_ForNegativeTolerance()
    {
        var temperature1 = Temperature.FromDegreesCelsius(25.0);
        var temperature2 = Temperature.FromDegreesCelsius(25.0);
        var negativeTolerance = TemperatureDelta.FromDegreesCelsius(-0.1);

        Assert.Throws<ArgumentOutOfRangeException>(() => temperature1.Equals(temperature2, negativeTolerance));
    }

    [Theory]
    [InlineData(25.0, 25.0, 0.1, true)] // Equal values
    [InlineData(25.0, 25.1, 0.1, true)] // Within tolerance
    [InlineData(25.0, 25.2, 0.1, false)] // Outside tolerance
    [InlineData(25.0, 25.0, 0.0, true)] // Zero tolerance, equal values
    [InlineData(25.0, 25.1, 0.0, false)] // Zero tolerance, different values
    public void Equals_Temperature_IQuantity(double value1, double value2, double toleranceValue, bool expected)
    {
        var temperature1 = Temperature.FromDegreesCelsius(value1);
        IQuantity temperature2 = Temperature.FromDegreesCelsius(value2);
        var tolerance = TemperatureDelta.FromDegreesCelsius(toleranceValue);

        var result = temperature1.Equals(temperature2, tolerance);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Equals_Temperature_IQuantity_WithDifferentType_ReturnsFalse()
    {
        var temperature1 = Temperature.FromDegreesCelsius(25.0);
        IQuantity length = Length.From(QuantityValue.One, LengthUnit.Meter);
        var tolerance = TemperatureDelta.FromDegreesCelsius(1);

        var result = temperature1.Equals(length, tolerance);

        Assert.False(result);
    }

    [Fact]
    public void Equals_WithNullOther_ReturnsFalse()
    {
        var quantity = Temperature.FromDegreesCelsius(25);
        IQuantity? other = null;
        var tolerance = TemperatureDelta.FromDegreesCelsius(25);

        var result = quantity.Equals(other, tolerance);

        Assert.False(result);
    }

    [Fact]
    public void Equals_IQuantity_WithNullOther_ReturnsFalse()
    {
        var quantity = Temperature.FromDegreesCelsius(25.0);
        var tolerance = TemperatureDelta.FromDegreesCelsius(25.0);

        var result = quantity.Equals(null, tolerance);

        Assert.False(result);
    }

    [Theory]
    [InlineData(25.0, 25.0, 0.1, true)] // Equal values
    [InlineData(25.0, 25.1, 0.1, true)] // Within tolerance
    [InlineData(25.0, 25.2, 0.1, false)] // Outside tolerance
    [InlineData(25.0, 25.0, 0.0, true)] // Zero tolerance, equal values
    [InlineData(25.0, 25.1, 0.0, false)] // Zero tolerance, different values
    public void EqualsAbsolute_Temperature_TemperatureDelta(double value1, double value2, double toleranceValue, bool expected)
    {
        var temperature1 = Temperature.FromDegreesCelsius(value1);
        var temperature2 = Temperature.FromDegreesCelsius(value2);
        var tolerance = TemperatureDelta.FromDegreesCelsius(toleranceValue);

        var result = temperature1.EqualsAbsolute(temperature2, tolerance);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void EqualsAbsolute_Temperature_TemperatureDelta_ThrowsArgumentOutOfRangeException_ForNegativeTolerance()
    {
        var temperature1 = Temperature.FromDegreesCelsius(25.0);
        var temperature2 = Temperature.FromDegreesCelsius(25.0);
        var negativeTolerance = TemperatureDelta.FromDegreesCelsius(-0.1);

        Assert.Throws<ArgumentOutOfRangeException>(() => temperature1.EqualsAbsolute(temperature2, negativeTolerance));
    }

    [Theory]
    [InlineData(new[] { 25.0, 30.0, 35.0 }, 30.0)] // Average of three values
    [InlineData(new[] { 25.0 }, 25.0)] // Single value
    public void Average_Temperature(double[] values, double expectedAverage)
    {
        Temperature[] temperatures = Array.ConvertAll(values, value => Temperature.FromDegreesCelsius(value));

        Temperature result = temperatures.Average();
        
        Assert.Equal(expectedAverage, result.Value);
        Assert.Equal(TemperatureUnit.DegreeCelsius, result.Unit);
    }

    [Fact]
    public void Average_TemperaturesWithDifferentUnits()
    {
        Temperature[] temperatures =
        [
            Temperature.FromDegreesCelsius(25.0),
            Temperature.FromDegreesFahrenheit(77.0), // equivalent to 25.0°C
            Temperature.FromKelvins(298.15) // equivalent to 25.0°C
        ];

        Temperature result = temperatures.Average();

        Assert.Equal(25, result.Value);
        Assert.Equal(TemperatureUnit.DegreeCelsius, result.Unit);
    }

    [Fact]
    public void Average_Temperature_ThrowsArgumentNullException_ForNullCollection()
    {
        IEnumerable<Temperature> temperatures = null!;

        Assert.Throws<ArgumentNullException>(() => temperatures.Average());
    }

    [Fact]
    public void Average_Temperature_ThrowsInvalidOperationException_ForEmptyCollection()
    {
        Temperature[] temperatures = [];
        
        Assert.Throws<InvalidOperationException>(() => temperatures.Average());
    }

    [Theory]
    [InlineData(new[] { 25.0, 30.0, 35.0 }, TemperatureUnit.DegreeCelsius, 30.0)] // Average in Celsius
    [InlineData(new[] { 77.0, 86.0, 95.0 }, TemperatureUnit.DegreeFahrenheit, 86.0)] // Average in Fahrenheit
    public void Average_Temperature_WithUnit(double[] values, TemperatureUnit unit, double expectedAverage)
    {
        Temperature[] temperatures = Array.ConvertAll(values, value => Temperature.From(value, unit));

        Temperature result = temperatures.Average(unit);

        Assert.Equal(expectedAverage, result.Value);
        Assert.Equal(unit, result.Unit);
    }
    
    [Fact]
    public void Average_TemperaturesWithDifferentUnits_WithTargetUnit()
    {
        Temperature[] temperatures =
        [
            Temperature.FromKelvins(298.15), // equivalent to 25.0°C
            Temperature.FromDegreesCelsius(25.0),
            Temperature.FromDegreesFahrenheit(77.0) // equivalent to 25.0°C
        ];

        Temperature result = temperatures.Average(TemperatureUnit.DegreeCelsius);

        Assert.Equal(25, result.Value);
        Assert.Equal(TemperatureUnit.DegreeCelsius, result.Unit);
    }

    [Fact]
    public void Average_Temperature_WithUnit_ThrowsArgumentNullException_ForNullCollection()
    {
        IEnumerable<Temperature> temperatures = null!;

        Assert.Throws<ArgumentNullException>(() => temperatures.Average(TemperatureUnit.DegreeCelsius));
    }

    [Fact]
    public void Average_Temperature_WithUnit_ThrowsInvalidOperationException_ForEmptyCollection()
    {
        Assert.Throws<InvalidOperationException>(() => Array.Empty<Temperature>().Average(TemperatureUnit.DegreeCelsius));
    }
}
