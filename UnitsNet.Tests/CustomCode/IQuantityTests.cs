// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests;

// ReSharper disable once InconsistentNaming
public partial class IQuantityTests
{
    [Fact]
    public void As_GivenWrongUnitType_ThrowsArgumentException()
    {
        Assert.All(Quantity.Infos.Select(x => x.Zero), quantity => { Assert.Throws<ArgumentException>(() => quantity.As(ComparisonType.Absolute)); });
    }

    [Fact]
    public void ToUnit_GivenWrongUnitType_ThrowsArgumentException()
    {
        Assert.All(Quantity.Infos.Select(x => x.Zero), quantity => { Assert.Throws<ArgumentException>(() => quantity.ToUnit(ComparisonType.Absolute)); });
    }

    [Fact]
    public virtual void ToUnit_UnitSystem_SI_ReturnsQuantityInSIUnits()
    {
        var quantity = new Mass(1, Mass.BaseUnit);
        MassUnit expectedUnit = Mass.Info.GetDefaultUnit(UnitSystem.SI);
        var expectedValue = quantity.As(expectedUnit);

        Assert.Multiple(() =>
        {
            IQuantity<MassUnit> quantityToConvert = quantity;

            IQuantity<MassUnit> convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

            Assert.Equal(expectedUnit, convertedQuantity.Unit);
            Assert.Equal(expectedValue, convertedQuantity.Value);
        }, () =>
        {
            IQuantity quantityToConvert = quantity;

            IQuantity convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

            Assert.Equal(expectedUnit, convertedQuantity.Unit);
            Assert.Equal(expectedValue, convertedQuantity.Value);
        });
    }

    [Fact]
    public void ToUnit_UnitSystem_ThrowsArgumentNullExceptionIfNull()
    {
        UnitSystem nullUnitSystem = null!;
        Assert.Multiple(() =>
        {
            IQuantity<MassUnit> quantity = new Mass(1, Mass.BaseUnit);
            Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
        }, () =>
        {
            IQuantity quantity = new Mass(1, Mass.BaseUnit);
            Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
        });
    }

    [Fact]
    public void ToUnit_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
    {
        var unsupportedUnitSystem = new UnitSystem(new BaseUnits(
            (LengthUnit)(-1),
            (MassUnit)(-1),
            (DurationUnit)(-1),
            (ElectricCurrentUnit)(-1),
            (TemperatureUnit)(-1),
            (AmountOfSubstanceUnit)(-1),
            (LuminousIntensityUnit)(-1)));

        Assert.Multiple(() =>
        {
            IQuantity<MassUnit> quantity = new Mass(1, Mass.BaseUnit);
            Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
        }, () =>
        {
            IQuantity quantity = new Mass(1, Mass.BaseUnit);
            Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
        });
    }
}
