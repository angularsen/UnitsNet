// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests;

public class UnitInfoTests
{
    [Fact]
    public void UnitInfo_QuantityInfo_ReturnsTheParentQuantityInfo()
    {
        Assert.Multiple(() =>
        {
            UnitInfo<Mass, MassUnit> unitInfo = Mass.Info.BaseUnitInfo;

            QuantityInfo<Mass, MassUnit> quantityInfo = unitInfo.QuantityInfo;

            Assert.Equal(Mass.Info, quantityInfo);
        }, () =>
        {
            UnitInfo unitInfo = Mass.Info.BaseUnitInfo;

            QuantityInfo quantityInfo = unitInfo.QuantityInfo;

            Assert.Equal(Mass.Info, quantityInfo);
        });
    }

    [Fact]
    public void UnitInfo_QuantityName_ReturnsTheParentQuantityName()
    {
        Assert.Equal(Mass.Info.Name, Mass.Info.BaseUnitInfo.QuantityName);
    }

    [Fact]
    public void UnitInfo_Value_ReturnsTheUnitValue()
    {
        Assert.Multiple(() =>
        {
            UnitInfo<Mass, MassUnit> unitInfo = Mass.Info.BaseUnitInfo;

            MassUnit unitInfoValue = unitInfo.Value;

            Assert.Equal(Mass.BaseUnit, unitInfoValue);
        }, () =>
        {
            UnitInfo<MassUnit> unitInfo = Mass.Info.BaseUnitInfo;

            MassUnit unitInfoValue = unitInfo.Value;

            Assert.Equal(Mass.BaseUnit, unitInfoValue);
        }, () =>
        {
            UnitInfo unitInfo = Mass.Info.BaseUnitInfo;

            Enum unitInfoValue = unitInfo.Value;

            Assert.Equal(Mass.BaseUnit, unitInfoValue);
        });
    }

    [Fact]
    public void UnitInfo_UnitKey_ReturnsTheUnitKey()
    {
        Assert.Multiple(() =>
        {
            UnitInfo<Mass, MassUnit> unitInfo = Mass.Info.BaseUnitInfo;

            UnitKey unitInfoValue = unitInfo.UnitKey;

            Assert.Equal(Mass.BaseUnit, unitInfoValue);
        }, () =>
        {
            UnitInfo<MassUnit> unitInfo = Mass.Info.BaseUnitInfo;
            
            UnitKey unitInfoValue = unitInfo.UnitKey;

            Assert.Equal(Mass.BaseUnit, unitInfoValue);
        }, () =>
        {
            UnitInfo unitInfo = Mass.Info.BaseUnitInfo;
            
            UnitKey unitInfoValue = unitInfo.UnitKey;

            Assert.Equal(Mass.BaseUnit, unitInfoValue);
        });
    }
    
    [Theory]
    [InlineData(1, MassUnit.Kilogram)]
    [InlineData(2, MassUnit.Milligram)]
    public void UnitInfo_FromValueAndUnit_ReturnsTheExpectedQuantity(double value, MassUnit unit)
    {
        var expectedQuantity = new Mass(value, unit);
        Assert.Multiple(() =>
        {
            UnitInfo<Mass, MassUnit> unitInfo = Mass.Info[unit];

            Mass quantity = unitInfo.From(value);

            Assert.Equal(expectedQuantity, quantity);
        }, () =>
        {
            UnitInfo<MassUnit> unitInfo = Mass.Info[unit];
            
            IQuantity quantity = unitInfo.From(value);

            Assert.Equal(expectedQuantity, quantity);
        }, () =>
        {
            UnitInfo unitInfo = Mass.Info[unit];
            
            IQuantity quantity = unitInfo.From(value);

            Assert.Equal(expectedQuantity, quantity);
        });
    }

    [Fact]
    public void ToString_ReturnsTheUnitName()
    {
        UnitInfo<Mass, MassUnit> unitInfo = Mass.Info.BaseUnitInfo;
        
        Assert.Equal(unitInfo.Name, unitInfo.ToString());
    }
}
