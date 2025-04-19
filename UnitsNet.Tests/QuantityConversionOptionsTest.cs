// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests;

public class QuantityConversionOptionsTest
{
    [Fact]
    public void CustomConversions_ShouldBeEmpty_WhenInitialized()
    {
        var options = new QuantityConversionOptions();
        Assert.Empty(options.CustomConversions);
    }

    [Fact]
    public void ConversionUnits_ShouldBeEmpty_WhenInitialized()
    {
        var options = new QuantityConversionOptions();
        Assert.Empty(options.ConversionUnits);
    }

    [Fact]
    public void CustomConversionFunctions_ShouldBeEmpty_WhenInitialized()
    {
        var options = new QuantityConversionOptions();
        Assert.Empty(options.CustomConversionFunctions);
    }

    [Fact]
    public void SetCustomConversion_ShouldAddConversionMapping()
    {
        var expectedConversion = QuantityConversionMapping.Create<Length, Mass>();
        var options = new QuantityConversionOptions();
        options.SetCustomConversion<Length, Mass>();
        Assert.Single(options.CustomConversions, expectedConversion);
    }

    [Fact]
    public void SetConversionUnits_ShouldAddUnitConversionMapping()
    {
        var options = new QuantityConversionOptions();
        options.SetConversionUnits(LengthUnit.Meter, MassUnit.Kilogram);

        Assert.Contains(options.ConversionUnits, mapping =>
            mapping.FromUnitKey.UnitEnumType == typeof(LengthUnit) && mapping.ToUnitKey.UnitEnumType == typeof(MassUnit));
    }

    [Fact]
    public void SetCustomConversionFunction_ShouldAddConversionFunction()
    {
        var options = new QuantityConversionOptions();
        ConvertValueDelegate conversionFunction = value => value * 2;
        options.SetCustomConversion(LengthUnit.Meter, MassUnit.Kilogram, conversionFunction);

        var key = new UnitConversionMapping(UnitKey.ForUnit(LengthUnit.Meter), UnitKey.ForUnit(MassUnit.Kilogram));
        Assert.True(options.CustomConversionFunctions.ContainsKey(key));
        Assert.Equal(conversionFunction, options.CustomConversionFunctions[key]);
    }

    [Fact]
    public void SetCustomConversion_ShouldThrowException_WhenSameType()
    {
        var options = new QuantityConversionOptions();
        Assert.Throws<InvalidConversionException>(() => options.SetCustomConversion<Length, Length>());
    }

    [Fact]
    public void SetConversionUnits_ShouldThrowException_WhenSameUnit()
    {
        var options = new QuantityConversionOptions();
        Assert.Throws<InvalidConversionException>(() => options.SetConversionUnits(LengthUnit.Meter, LengthUnit.Centimeter));
    }

    [Fact]
    public void SetCustomConversion_ShouldThrowException_WhenSameUnit()
    {
        var options = new QuantityConversionOptions();
        Assert.Throws<InvalidConversionException>(() => options.SetCustomConversion(LengthUnit.Meter, LengthUnit.Centimeter, 2));
    }

    [Fact]
    public void SetCustomConversionFunction_ShouldThrowException_WhenSameUnit()
    {
        var options = new QuantityConversionOptions();
        ConvertValueDelegate conversionFunction = value => value * 2;
        Assert.Throws<InvalidConversionException>(() => options.SetCustomConversion(LengthUnit.Meter, LengthUnit.Centimeter, conversionFunction));
    }

    [Fact]
    public void SetCustomConversion_ShouldBeCommutative()
    {
        var options = new QuantityConversionOptions();
        options.SetCustomConversion<Length, Mass>();

        Assert.Contains(QuantityConversionMapping.Create<Mass, Length>(), options.CustomConversions);
    }

    [Fact]
    public void SetConversionUnits_ShouldMapBothDirections_WhenMapBothDirectionsIsTrue()
    {
        var options = new QuantityConversionOptions();
        options.SetConversionUnits(LengthUnit.Meter, MassUnit.Kilogram, true);
        Assert.Contains(UnitConversionMapping.Create(MassUnit.Kilogram, LengthUnit.Meter), options.ConversionUnits);
    }
    
    [Fact]
    public void SetConversionUnits_ShouldNotMapBothDirections_WhenMapBothDirectionsIsFalse()
    {
        var options = new QuantityConversionOptions();
        options.SetConversionUnits(LengthUnit.Meter, MassUnit.Kilogram, false);
        Assert.DoesNotContain(UnitConversionMapping.Create(MassUnit.Kilogram, LengthUnit.Meter), options.ConversionUnits);
    }

    [Fact]
    public void SetCustomConversion_ShouldMapBothDirections_WhenMapBothDirectionsIsTrue()
    {
        var options = new QuantityConversionOptions();
        options.SetCustomConversion(LengthUnit.Meter, MassUnit.Kilogram, 2, true);

        Assert.Contains(new UnitConversionMapping(UnitKey.ForUnit(LengthUnit.Meter), UnitKey.ForUnit(MassUnit.Kilogram)), options.CustomConversionFunctions);
        Assert.Contains(new UnitConversionMapping(UnitKey.ForUnit(MassUnit.Kilogram), UnitKey.ForUnit(LengthUnit.Meter)), options.CustomConversionFunctions);
    }
    
    [Fact]
    public void SetCustomConversion_ShouldNotMapBothDirections_WhenMapBothDirectionsIsFalse()
    {
        var options = new QuantityConversionOptions();
        options.SetCustomConversion(LengthUnit.Meter, MassUnit.Kilogram, 2, false);
        
        Assert.Contains(new UnitConversionMapping(UnitKey.ForUnit(LengthUnit.Meter), UnitKey.ForUnit(MassUnit.Kilogram)), options.CustomConversionFunctions);
        Assert.DoesNotContain(new UnitConversionMapping(UnitKey.ForUnit(MassUnit.Kilogram), UnitKey.ForUnit(LengthUnit.Meter)), options.CustomConversionFunctions);
    }

    [Fact]
    public void SetCustomConversionFunction_ShouldNotBeCommutative()
    {
        var options = new QuantityConversionOptions();
        options.SetCustomConversion(LengthUnit.Meter, MassUnit.Kilogram, value => value * 2);

        Assert.DoesNotContain(new UnitConversionMapping(UnitKey.ForUnit(MassUnit.Kilogram), UnitKey.ForUnit(LengthUnit.Meter)), options.CustomConversionFunctions);
    }
}
