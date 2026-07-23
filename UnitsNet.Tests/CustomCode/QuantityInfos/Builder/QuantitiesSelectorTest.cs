// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.QuantityInfos.Builder;

public class QuantitiesSelectorTest
{
    [Fact]
    public void Constructor_InitializesQuantitiesSelected()
    {
        var selector = new QuantitiesSelector(() => []);
        Assert.Empty(selector.GetQuantityInfos());
    }

    [Fact]
    public void WithAdditionalQuantities_AddsQuantities()
    {
        QuantitiesSelector selector = new QuantitiesSelector(() => [Length.Info])
            .WithAdditionalQuantities([Mass.Info]);

        Assert.Equal([Length.Info, Mass.Info], selector.GetQuantityInfos());
    }

    [Fact]
    public void Configure_AddsCustomConfiguration()
    {
        var selector = new QuantitiesSelector(() => [Length.Info, Mass.Info]);
        var customLengthConfig =
            new QuantityInfo<Length, LengthUnit>(LengthUnit.Centimeter, Length.LengthInfo.GetDefaultMappings(), BaseDimensions.Dimensionless, Length.From);

        selector.Configure(() => customLengthConfig);

        Assert.Equal([customLengthConfig, Mass.Info], selector.GetQuantityInfos());
        Assert.Equal(customLengthConfig, selector.CreateOrDefault(() => Length.Info));
        Assert.Equal(Mass.Info, selector.CreateOrDefault(() => Mass.Info));
    }

    [Fact]
    public void Configure_AdditionalQuantity_AddsCustomConfiguration()
    {
        QuantitiesSelector selector = new QuantitiesSelector(() => [Mass.Info]).WithAdditionalQuantities([Length.Info]);
        var customLengthConfig =
            new QuantityInfo<Length, LengthUnit>(LengthUnit.Centimeter, Length.LengthInfo.GetDefaultMappings(), BaseDimensions.Dimensionless, Length.From);

        selector.Configure(() => customLengthConfig);

        Assert.Equal([Mass.Info, customLengthConfig], selector.GetQuantityInfos());
        Assert.Equal(customLengthConfig, selector.CreateOrDefault(() => Length.Info));
        Assert.Equal(Mass.Info, selector.CreateOrDefault(() => Mass.Info));
    }

    [Fact]
    public void BuildSelection_ReturnsDefaultQuantities_WhenNoAdditionalOrCustomQuantities()
    {
        var selector = new QuantitiesSelector(() => [Length.Info]);

        IEnumerable<QuantityInfo> result = selector.GetQuantityInfos();

        Assert.Equal([Length.Info], result);
    }
}
