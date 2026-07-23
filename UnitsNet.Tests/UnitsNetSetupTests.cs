// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Tests.CustomQuantities;
using UnitsNet.Units;

namespace UnitsNet.Tests;

public class UnitsNetSetupTests
{
    [Fact]
    public void Create_WithSelectedQuantities_WiresIsolatedComponentsToSameCatalog()
    {
        UnitsNetSetup setup = UnitsNetSetup.Create(builder => builder.WithQuantities([Mass.Info]));

        Assert.Equal([Mass.Info], setup.Quantities.Infos);
        Assert.Same(setup.Quantities, setup.UnitAbbreviations.Quantities);
        Assert.Same(setup.UnitAbbreviations, setup.UnitParser.Abbreviations);
        Assert.NotSame(UnitsNetSetup.Default, setup);
        Assert.Throws<UnitNotFoundException>(() => setup.Quantities.GetQuantityByUnitType(typeof(LengthUnit)));
    }

    [Fact]
    public void Create_WithAdditionalQuantities_AppendsToSelectedCatalog()
    {
        UnitsNetSetup setup = UnitsNetSetup.Create(builder => builder
            .WithQuantities([Mass.Info])
            .WithAdditionalQuantities([HowMuch.Info]));

        Assert.Equal([Mass.Info, HowMuch.Info], setup.Quantities.Infos);
    }

    [Fact]
    public void Create_WithSelectedAndAdditionalQuantities_AppendsToSelectedCatalog()
    {
        UnitsNetSetup setup = UnitsNetSetup.Create(builder => builder.WithQuantities([Mass.Info],
            selector => selector.WithAdditionalQuantities([HowMuch.Info])));

        Assert.Equal([Mass.Info, HowMuch.Info], setup.Quantities.Infos);
    }

    [Fact]
    public void FactoryMethods_WithNullArguments_ThrowArgumentNullException()
    {
        var builder = new UnitsNetSetup.DefaultConfigurationBuilder();

        Assert.Multiple(checks:
        [
            () => Assert.Equal("configuration",
                Assert.Throws<ArgumentNullException>(() => UnitsNetSetup.Create(null!)).ParamName),
            () => Assert.Equal("quantities",
                Assert.Throws<ArgumentNullException>(() => builder.WithQuantities((IEnumerable<QuantityInfo>)null!)).ParamName),
            () => Assert.Equal("quantities",
                Assert.Throws<ArgumentNullException>(() => builder.WithQuantities((Func<IEnumerable<QuantityInfo>>)null!)).ParamName),
            () => Assert.Equal("quantities",
                Assert.Throws<ArgumentNullException>(() => builder.WithQuantities((IEnumerable<QuantityInfo>)null!, _ => { })).ParamName),
            () => Assert.Equal("configureQuantities",
                Assert.Throws<ArgumentNullException>(() => builder.WithQuantities(() => [Mass.Info], null!)).ParamName)
        ]);
    }

    [Fact]
    public void Builder_WithQuantitiesTwice_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => UnitsNetSetup.Create(builder => builder
            .WithQuantities([Mass.Info])
            .WithQuantities([Length.Info])));
    }
}
