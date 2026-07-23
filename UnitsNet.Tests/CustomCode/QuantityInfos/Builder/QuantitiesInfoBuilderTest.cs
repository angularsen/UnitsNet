// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.QuantityInfos.Builder;

public class QuantitiesInfoBuilderTest
{
    [Fact]
    public void ConfigureQuantity_ValidInput_AddsCustomization()
    {
        var builder = new QuantitiesInfoBuilder();

        builder.ConfigureQuantity(() =>
            new QuantityInfo<Length, LengthUnit>(LengthUnit.Centimeter, Length.LengthInfo.GetDefaultMappings(), BaseDimensions.Dimensionless, Length.From));

        QuantityInfo result = builder.CreateOrDefault(Length.Info);

        Assert.Equal(LengthUnit.Centimeter, result.BaseUnitInfo.Value);
        Assert.Equal(BaseDimensions.Dimensionless, result.BaseDimensions);
    }

    [Fact]
    public void ConfigureQuantity_NullDelegate_ThrowsArgumentNullException()
    {
        var builder = new QuantitiesInfoBuilder();

        Assert.Throws<ArgumentNullException>(() =>
            builder.ConfigureQuantity<Length, LengthUnit>(null!));
    }

    [Fact]
    public void CreateOrDefault_NoCustomization_ReturnsDefault()
    {
        var builder = new QuantitiesInfoBuilder();
        QuantityInfo<Length, LengthUnit> defaultConfig = Length.Info;

        QuantityInfo result = builder.CreateOrDefault(defaultConfig);

        Assert.Equal(defaultConfig, result);
    }

    [Fact]
    public void CreateOrDefault_Generic_NoCustomization_ReturnsDefault()
    {
        var builder = new QuantitiesInfoBuilder();

        QuantityInfo<Length, LengthUnit> result = builder.CreateOrDefault(() => Length.Info);

        Assert.Equal(Length.Info, result);
    }

    [Fact]
    public void CreateOrDefault_Generic_WithCustomization_ReturnsCustomized()
    {
        var builder = new QuantitiesInfoBuilder();
        
        builder.ConfigureQuantity(() =>
            new QuantityInfo<Length, LengthUnit>(LengthUnit.Centimeter, Length.LengthInfo.GetDefaultMappings(), BaseDimensions.Dimensionless, Length.From));

        QuantityInfo<Length, LengthUnit> result = builder.CreateOrDefault(() => Length.Info);

        Assert.Equal(LengthUnit.Centimeter, result.BaseUnitInfo.Value);
        Assert.Equal(BaseDimensions.Dimensionless, result.BaseDimensions);
    }
}
