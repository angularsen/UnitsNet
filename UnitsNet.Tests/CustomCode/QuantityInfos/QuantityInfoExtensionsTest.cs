// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.QuantityInfos;

public class QuantityInfoExtensionsTest
{
    [Fact]
    public void GetDefaultUnit_ThrowsException_WhenUnitSystemIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => Length.Info.GetDefaultUnit(null!));
    }

    [Fact]
    public void GetDefaultUnit_ThrowsArgumentException_WhenNoUnitsFoundForUnitSystem()
    {
        // simulating a combination of units that won't match anything
        var unsupportedUnitSystem = new UnitSystem(new BaseUnits(
            (LengthUnit)(-1),
            (MassUnit)(-1),
            (DurationUnit)(-1),
            (ElectricCurrentUnit)(-1),
            (TemperatureUnit)(-1),
            (AmountOfSubstanceUnit)(-1),
            (LuminousIntensityUnit)(-1)));

        Assert.Throws<ArgumentException>(() => Length.Info.GetDefaultUnit(unsupportedUnitSystem));
    }

    [Fact]
    public void GetDefaultUnit_ReturnsCorrectUnit_ForSpecificUnitSystem()
    {
        LengthUnit defaultUnit = Length.Info.GetDefaultUnit(UnitSystem.SI);

        Assert.Equal(LengthUnit.Meter, defaultUnit);
    }

    [Fact]
    public void GetDefaultUnit_ReturnsFirstUnit_WhenMultipleUnitsExistForUnitSystem()
    {
        // Arrange
        var unitSystem = new UnitSystem(new BaseUnits(
            LengthUnit.Decimeter,
            (MassUnit)(-1),
            (DurationUnit)(-1),
            (ElectricCurrentUnit)(-1),
            (TemperatureUnit)(-1),
            (AmountOfSubstanceUnit)(-1),
            (LuminousIntensityUnit)(-1)));

        // Act
        VolumeUnit defaultUnit = Volume.Info.GetDefaultUnit(unitSystem);

        // Assert
        Assert.Equal(VolumeUnit.CubicDecimeter, defaultUnit);
    }

    [Fact]
    public void GetDefaultUnit_ReturnsTheBaseUnit_WhenGivenADimensionlessQuantity()
    {
        Assert.Multiple(
            () => Assert.Equal(RatioUnit.DecimalFraction, Ratio.Info.GetDefaultUnit(UnitSystem.SI)),
            () => Assert.Equal(MassFractionUnit.DecimalFraction, MassFraction.Info.GetDefaultUnit(UnitSystem.SI)),
            () => Assert.Equal(AngleUnit.Radian, Angle.Info.GetDefaultUnit(UnitSystem.SI)),
            () => Assert.Equal(SolidAngleUnit.Steradian, SolidAngle.Info.GetDefaultUnit(UnitSystem.SI)));
    }
}
