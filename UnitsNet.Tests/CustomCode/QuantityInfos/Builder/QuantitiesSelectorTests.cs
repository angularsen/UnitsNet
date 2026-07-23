// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests.QuantityInfos.Builder;

public class QuantitiesSelectorTests
{
    [Fact]
    public void GetQuantityInfos_WithoutAdditions_ReturnsBaseSelection()
    {
        var selector = new QuantitiesSelector(() => [Length.Info]);

        Assert.Equal([Length.Info], selector.GetQuantityInfos());
    }

    [Fact]
    public void WithAdditionalQuantities_AppendsAllSelectionsInOrder()
    {
        QuantitiesSelector selector = new QuantitiesSelector(() => [Length.Info])
            .WithAdditionalQuantities([Mass.Info])
            .WithAdditionalQuantities([Duration.Info]);

        Assert.Equal([Length.Info, Mass.Info, Duration.Info], selector.GetQuantityInfos());
    }

    [Fact]
    public void WithAdditionalQuantities_WithNull_ThrowsArgumentNullException()
    {
        var selector = new QuantitiesSelector(() => [Length.Info]);

        Assert.Throws<ArgumentNullException>(() => selector.WithAdditionalQuantities(null!));
    }
}
