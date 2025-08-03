// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests.QuantityInfos.Builder;

public class QuantityInfoBuilderExtensionsTest
{
    [Fact]
    public void SelectUnits_FiltersCorrectly()
    {
        LengthUnit[] filterUnits = [LengthUnit.Centimeter, LengthUnit.Inch];

        IEnumerable<UnitDefinition<LengthUnit>> result = Length.LengthInfo.GetDefaultMappings().SelectUnits(filterUnits);

        Assert.Equal(filterUnits, result.Select(u => u.Value).ToArray());
    }

    [Fact]
    public void ExcludeUnits_FiltersCorrectly()
    {
        var unitDefinitions = Length.LengthInfo.GetDefaultMappings()
            .Where(x => x.Value is LengthUnit.Centimeter or LengthUnit.Meter or LengthUnit.Foot)
            .ToList();

        IEnumerable<UnitDefinition<LengthUnit>> result = unitDefinitions.ExcludeUnits(LengthUnit.Meter, LengthUnit.Centimeter);

        Assert.Single(result, unitDefinition => unitDefinition.Value == LengthUnit.Foot);
    }

    [Fact]
    public void Configure_UpdatesSpecificUnit()
    {
        var unitDefinitions = Length.LengthInfo.GetDefaultMappings()
            .Where(x => x.Value is LengthUnit.Centimeter or LengthUnit.Meter or LengthUnit.Foot)
            .ToList();
        var customMeterDefinition = new UnitDefinition<LengthUnit>(LengthUnit.Meter, "UpdatedMeter", "UpdatedMeters", BaseUnits.Undefined);

        var result = unitDefinitions.Configure(LengthUnit.Meter, _ => customMeterDefinition).ToList();

        Assert.Equal("UpdatedMeter", result.First(u => u.Value == LengthUnit.Meter).Name);
        Assert.Equal("Centimeter", result.First(u => u.Value == LengthUnit.Centimeter).Name);
        Assert.Equal("Foot", result.First(u => u.Value == LengthUnit.Foot).Name);
    }

    [Fact]
    public void WithConversionFromBase_CreatesNewDefinition()
    {
        UnitDefinition<LengthUnit> oldDefinition = Length.LengthInfo.GetDefaultMappings().First();
        
        UnitDefinition<LengthUnit> newDefinition = oldDefinition.WithConversionFromBase(20);

        Assert.Equal(oldDefinition.Value, newDefinition.Value);
        Assert.Equal(oldDefinition.Name, newDefinition.Name);
        Assert.Equal(oldDefinition.PluralName, newDefinition.PluralName);
        Assert.Equal(20, newDefinition.ConversionFromBase);
        Assert.Equal(QuantityValue.Inverse(20), newDefinition.ConversionToBase);
        Assert.Equal(oldDefinition.BaseUnits, newDefinition.BaseUnits);
    }

    [Fact]
    public void WithConversionToBase_CreatesNewDefinition()
    {
        UnitInfo<Length, LengthUnit> oldDefinition = Length.Info.BaseUnitInfo;

        UnitDefinition<LengthUnit> newDefinition = oldDefinition.WithConversionToBase(20);

        Assert.Equal(oldDefinition.Value, newDefinition.Value);
        Assert.Equal(oldDefinition.Name, newDefinition.Name);
        Assert.Equal(oldDefinition.PluralName, newDefinition.PluralName);
        Assert.Equal(QuantityValue.Inverse(20), newDefinition.ConversionFromBase);
        Assert.Equal(20, newDefinition.ConversionToBase);
        Assert.Equal(oldDefinition.BaseUnits, newDefinition.BaseUnits);
    }

    [Fact]
    public void WithConversionExpression_CreatesNewDefinition()
    {
        UnitInfo<Length, LengthUnit> oldDefinition = Length.Info.BaseUnitInfo;
        var conversionFromBase = new ConversionExpression(20);
        var conversionToBase = new ConversionExpression(0.05);

        UnitDefinition<LengthUnit> newDefinition = oldDefinition.WithConversionExpression(conversionFromBase, conversionToBase);

        Assert.Equal(oldDefinition.Value, newDefinition.Value);
        Assert.Equal(oldDefinition.Name, newDefinition.Name);
        Assert.Equal(oldDefinition.PluralName, newDefinition.PluralName);
        Assert.Equal(conversionFromBase, newDefinition.ConversionFromBase);
        Assert.Equal(conversionToBase, newDefinition.ConversionToBase);
        Assert.Equal(oldDefinition.BaseUnits, newDefinition.BaseUnits);
    }
}
