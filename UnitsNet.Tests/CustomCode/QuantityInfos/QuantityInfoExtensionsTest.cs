// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Tests.CustomQuantities;

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
    
    [Fact]
    public void ConvertValueToBaseUnit_ReturnsValueInBaseUnit()
    {
        Assert.Equal(1000, Length.Info[LengthUnit.Kilometer].ConvertValueToBaseUnit(1));
    }

    [Fact]
    public void ConvertValueToFromUnit_ReturnsValueInTargetUnit()
    {
        Assert.Equal(1, Length.Info[LengthUnit.Kilometer].ConvertValueFromBaseUnit(1000));
    }

    [Fact]
    public void GetValueFrom_ReturnsValueInTargetUnit()
    {
        QuantityValue valueToConvert = 123.45m;
        foreach (QuantityInfo quantityInfo in Quantity.Infos)
        {
            foreach (UnitInfo fromUnit in quantityInfo.UnitInfos)
            {
                IQuantity fromQuantity = quantityInfo.From(valueToConvert, fromUnit.Value);
                foreach (UnitInfo toUnit in quantityInfo.UnitInfos)
                {
                    QuantityValue expectedValue = fromQuantity.As(toUnit.Value);
                    Assert.Equal(expectedValue, toUnit.GetValueFrom(valueToConvert, fromUnit));
                }
            }
        }
    }

    [Theory]
    [InlineData(AreaUnit.SquareMeter, ReciprocalAreaUnit.InverseSquareMeter)]
    [InlineData(AreaUnit.SquareCentimeter, ReciprocalAreaUnit.InverseSquareCentimeter)]
    [InlineData(AreaUnit.SquareFoot, ReciprocalAreaUnit.InverseSquareFoot)]
    [InlineData(AreaUnit.Acre, ReciprocalAreaUnit.InverseSquareMeter)]
    public void TryToConvertFrom_QuantityWithInverseDimensions_ToQuantity(AreaUnit fromUnit, ReciprocalAreaUnit expectedUnit)
    {
        QuantityValue valueToConvert = 100;
        UnitInfo fromUnitInfo = Area.Info[fromUnit];
        ReciprocalArea expectedResult = Area.From(valueToConvert, fromUnit).Inverse();

        var success = ReciprocalArea.Info.TryConvertFrom(valueToConvert, fromUnitInfo, out ReciprocalArea result);

        Assert.True(success);
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedUnit, result.Unit);
    }

    [Theory]
    [InlineData(AreaUnit.SquareMeter, ReciprocalAreaUnit.InverseSquareMeter)]
    [InlineData(AreaUnit.SquareCentimeter, ReciprocalAreaUnit.InverseSquareCentimeter)]
    [InlineData(AreaUnit.SquareFoot, ReciprocalAreaUnit.InverseSquareFoot)]
    [InlineData(AreaUnit.Acre, ReciprocalAreaUnit.InverseSquareMeter)]
    public void TryToConvertFrom_QuantityWithInverseDimensions_ToIQuantity(AreaUnit fromUnit, ReciprocalAreaUnit expectedUnit)
    {
        QuantityValue valueToConvert = 100;
        UnitInfo fromUnitInfo = Area.Info[fromUnit];
        QuantityInfo targetQuantityInfo = ReciprocalArea.Info;

        IQuantity expectedResult = Area.From(valueToConvert, fromUnit).Inverse();

        var success = targetQuantityInfo.TryConvertFrom(valueToConvert, fromUnitInfo, out IQuantity? result);

        Assert.True(success);
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedUnit, result!.Unit);
    }

    [Theory]
    [InlineData(AreaUnit.SquareMeter, ReciprocalAreaUnit.InverseSquareMeter)]
    [InlineData(AreaUnit.SquareCentimeter, ReciprocalAreaUnit.InverseSquareCentimeter)]
    [InlineData(AreaUnit.SquareFoot, ReciprocalAreaUnit.InverseSquareFoot)]
    [InlineData(AreaUnit.Acre, ReciprocalAreaUnit.InverseSquareMeter)]
    public void ConvertFrom_QuantityWithInverseDimensions_ToQuantity(AreaUnit fromUnit, ReciprocalAreaUnit expectedUnit)
    {
        QuantityValue valueToConvert = 100;
        UnitInfo fromUnitInfo = Area.Info[fromUnit];

        ReciprocalArea expectedResult = Area.From(valueToConvert, fromUnit).Inverse();

        ReciprocalArea convertedQuantity = ReciprocalArea.Info.ConvertFrom(valueToConvert, fromUnitInfo);

        Assert.Equal(expectedResult, convertedQuantity);
        Assert.Equal(expectedUnit, convertedQuantity.Unit);
    }

    [Theory]
    [InlineData(AreaUnit.SquareMeter, ReciprocalAreaUnit.InverseSquareMeter)]
    [InlineData(AreaUnit.SquareCentimeter, ReciprocalAreaUnit.InverseSquareCentimeter)]
    [InlineData(AreaUnit.SquareFoot, ReciprocalAreaUnit.InverseSquareFoot)]
    [InlineData(AreaUnit.Acre, ReciprocalAreaUnit.InverseSquareMeter)]
    public void ConvertFrom_QuantityWithInverseDimensions_ToIQuantity(AreaUnit fromUnit, ReciprocalAreaUnit expectedUnit)
    {
        QuantityValue valueToConvert = 100;
        UnitInfo fromUnitInfo = Area.Info[fromUnit];
        QuantityInfo targetQuantityInfo = ReciprocalArea.Info;

        IQuantity expectedResult = Area.From(valueToConvert, fromUnit).Inverse();

        IQuantity convertedQuantity = targetQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);

        Assert.Equal(expectedResult, convertedQuantity);
        Assert.Equal(expectedUnit, convertedQuantity.Unit);
    }

    [Theory]
    [InlineData(MassConcentrationUnit.KilogramPerCubicMeter, DensityUnit.KilogramPerCubicMeter)]
    [InlineData(MassConcentrationUnit.GramPerCubicMeter, DensityUnit.GramPerCubicMeter)]
    [InlineData(MassConcentrationUnit.PoundPerCubicFoot, DensityUnit.PoundPerCubicFoot)]
    [InlineData(MassConcentrationUnit.GramPerLiter, DensityUnit.GramPerLiter)]
    [InlineData(MassConcentrationUnit.PoundPerUSGallon, DensityUnit.KilogramPerCubicMeter)]
    public void TryToConvertFrom_QuantityWithSameDimensions_ToQuantity(MassConcentrationUnit fromUnit, DensityUnit expectedUnit)
    {
        QuantityValue valueToConvert = 100;
        UnitInfo fromUnitInfo = MassConcentration.Info[fromUnit];

        var expectedResult = Density.From(MassConcentration.From(valueToConvert, fromUnit).KilogramsPerCubicMeter, DensityUnit.KilogramPerCubicMeter);

        var success = Density.Info.TryConvertFrom(valueToConvert, fromUnitInfo, out Density result);

        Assert.True(success);
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedUnit, result.Unit);
    }

    [Theory]
    [InlineData(MassConcentrationUnit.KilogramPerCubicMeter, DensityUnit.KilogramPerCubicMeter)]
    [InlineData(MassConcentrationUnit.GramPerCubicMeter, DensityUnit.GramPerCubicMeter)]
    [InlineData(MassConcentrationUnit.PoundPerCubicFoot, DensityUnit.PoundPerCubicFoot)]
    [InlineData(MassConcentrationUnit.GramPerLiter, DensityUnit.GramPerLiter)]
    [InlineData(MassConcentrationUnit.PoundPerUSGallon, DensityUnit.KilogramPerCubicMeter)]
    public void TryToConvertFrom_QuantityWithSameDimensions_ToIQuantity(MassConcentrationUnit fromUnit, DensityUnit expectedUnit)
    {
        QuantityValue valueToConvert = 100;
        UnitInfo fromUnitInfo = MassConcentration.Info[fromUnit];
        QuantityInfo targetQuantityInfo = Density.Info;

        IQuantity expectedResult = Density.From(MassConcentration.From(valueToConvert, fromUnit).KilogramsPerCubicMeter, DensityUnit.KilogramPerCubicMeter);

        var success = targetQuantityInfo.TryConvertFrom(valueToConvert, fromUnitInfo, out IQuantity? result);

        Assert.True(success);
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedUnit, result!.Unit);
    }

    [Theory]
    [InlineData(MassFractionUnit.DecimalFraction, RatioUnit.DecimalFraction)]
    [InlineData(MassFractionUnit.Percent, RatioUnit.DecimalFraction)]
    [InlineData(MassFractionUnit.GramPerKilogram, RatioUnit.DecimalFraction)]
    public void TryToConvertFrom_DimensionlessQuantity_ToQuantity(MassFractionUnit fromUnit, RatioUnit expectedUnit)
    {
        QuantityValue valueToConvert = 100;
        UnitInfo fromUnitInfo = MassFraction.Info[fromUnit];

        var expectedResult = Ratio.From(MassFraction.From(valueToConvert, fromUnit).DecimalFractions, RatioUnit.DecimalFraction);

        var success = Ratio.Info.TryConvertFrom(valueToConvert, fromUnitInfo, out Ratio result);

        Assert.True(success);
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedUnit, result.Unit);
    }

    [Theory]
    [InlineData(MassFractionUnit.DecimalFraction, RatioUnit.DecimalFraction)]
    [InlineData(MassFractionUnit.Percent, RatioUnit.DecimalFraction)]
    [InlineData(MassFractionUnit.GramPerKilogram, RatioUnit.DecimalFraction)]
    public void TryToConvertFrom_DimensionlessQuantity_ToIQuantity(MassFractionUnit fromUnit, RatioUnit expectedUnit)
    {
        QuantityValue valueToConvert = 100;
        UnitInfo fromUnitInfo = MassFraction.Info[fromUnit];

        var expectedResult = Ratio.From(MassFraction.From(valueToConvert, fromUnit).DecimalFractions, RatioUnit.DecimalFraction);

        var success = Ratio.Info.TryConvertFrom(valueToConvert, fromUnitInfo, out IQuantity? result);

        Assert.True(success);
        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedUnit, result!.Unit);
    }

    [Theory]
    [InlineData(HowMuchUnit.ATon, MassUnit.Tonne, 1)]
    [InlineData(HowMuchUnit.Some, MassUnit.Tonne, 0.1)]
    [InlineData(HowMuchUnit.AShitTon, MassUnit.Tonne, 10)]
    public void TryToConvertFrom_QuantityWithoutSIBase_ToQuantity(HowMuchUnit fromUnit, MassUnit expectedUnit, double expectedValue)
    {
        QuantityValue valueToConvert = QuantityValue.One;
        UnitInfo fromUnitInfo = HowMuch.Info[fromUnit];

        var success = Mass.Info.TryConvertFrom(valueToConvert, fromUnitInfo, out Mass result);

        Assert.True(success);
        Assert.Equal(expectedValue, result.Value);
        Assert.Equal(expectedUnit, result.Unit);
    }

    [Theory]
    [InlineData(MassUnit.Tonne, HowMuchUnit.ATon, 1)]
    [InlineData(MassUnit.Kilogram, HowMuchUnit.ATon, 0.001)]
    [InlineData(MassUnit.Gram, HowMuchUnit.ATon, 0.000001)]
    public void TryToConvertFrom_QuantityWithoutMatchingSIBase_ToIQuantity(MassUnit fromUnit, HowMuchUnit expectedUnit, double expectedValue)
    {
        QuantityValue valueToConvert = QuantityValue.One;
        UnitInfo fromUnitInfo = Mass.Info[fromUnit];
        var success = HowMuch.Info.TryConvertFrom(valueToConvert, fromUnitInfo, out IQuantity? result);

        Assert.True(success);
        Assert.Equal(expectedValue, result!.Value);
        Assert.Equal(expectedUnit, result.Unit);
    }

    [Theory]
    [InlineData(TemperatureChangeRateUnit.DegreeKelvinPerSecond, TemperatureChangeRateUnit.DegreeKelvinPerSecond, 1)]
    [InlineData(TemperatureChangeRateUnit.DegreeCelsiusPerSecond, TemperatureChangeRateUnit.DegreeCelsiusPerSecond, 1)]
    [InlineData(TemperatureChangeRateUnit.DecadegreeCelsiusPerSecond, TemperatureChangeRateUnit.DegreeCelsiusPerSecond, 10)]
    public void TryToConvertFrom_QuantityBaseDifferentFromSI_ToQuantity(TemperatureChangeRateUnit fromUnit, TemperatureChangeRateUnit expectedUnit,
        double expectedValue)
    {
        QuantityValue valueToConvert = QuantityValue.One;
        UnitInfo fromUnitInfo = TemperatureChangeRate.Info[fromUnit];
        // we simulate a different quantity type, having a non-standard base unit (note: the "official" TemperatureChangeRate is currently using DegreeCelsiusPerSecond)
        var customQuantityInfo = new TemperatureChangeRate.TemperatureChangeRateInfo("TestTemperature", TemperatureChangeRateUnit.DegreeKelvinPerSecond,
            TemperatureChangeRate.TemperatureChangeRateInfo.GetDefaultMappings(), TemperatureChangeRate.Zero, TemperatureChangeRate.BaseDimensions);

        var success = customQuantityInfo.TryConvertFrom(valueToConvert, fromUnitInfo, out TemperatureChangeRate result);

        Assert.True(success);
        Assert.Equal(expectedValue, result.Value);
        Assert.Equal(expectedUnit, result.Unit);
    }

    [Theory]
    [InlineData(TemperatureChangeRateUnit.DegreeKelvinPerSecond, TemperatureChangeRateUnit.DegreeKelvinPerSecond, 1)]
    [InlineData(TemperatureChangeRateUnit.DegreeCelsiusPerSecond, TemperatureChangeRateUnit.DegreeCelsiusPerSecond, 1)]
    [InlineData(TemperatureChangeRateUnit.DecadegreeCelsiusPerSecond, TemperatureChangeRateUnit.DegreeCelsiusPerSecond, 10)]
    public void TryToConvertFrom_QuantityBaseDifferentFromSI_ToIQuantity(TemperatureChangeRateUnit fromUnit, TemperatureChangeRateUnit expectedUnit,
        double expectedValue)
    {
        QuantityValue valueToConvert = QuantityValue.One;
        UnitInfo fromUnitInfo = TemperatureChangeRate.Info[fromUnit];
        // we simulate a different quantity type, having a non-standard base unit (note: the "official" TemperatureChangeRate is currently using DegreeCelsiusPerSecond)
        QuantityInfo customQuantityInfo = new TemperatureChangeRate.TemperatureChangeRateInfo("TestTemperature", TemperatureChangeRateUnit.DegreeKelvinPerSecond,
            TemperatureChangeRate.TemperatureChangeRateInfo.GetDefaultMappings(), TemperatureChangeRate.Zero, TemperatureChangeRate.BaseDimensions);

        var success = customQuantityInfo.TryConvertFrom(valueToConvert, fromUnitInfo, out IQuantity? result);

        Assert.True(success);
        Assert.Equal(expectedValue, result!.Value);
        Assert.Equal(expectedUnit, result.Unit);
    }

    [Theory]
    [InlineData(MassConcentrationUnit.KilogramPerCubicMeter, DensityUnit.KilogramPerCubicMeter)]
    [InlineData(MassConcentrationUnit.GramPerCubicMeter, DensityUnit.GramPerCubicMeter)]
    [InlineData(MassConcentrationUnit.PoundPerCubicFoot, DensityUnit.PoundPerCubicFoot)]
    [InlineData(MassConcentrationUnit.GramPerLiter, DensityUnit.GramPerLiter)]
    [InlineData(MassConcentrationUnit.PoundPerUSGallon, DensityUnit.KilogramPerCubicMeter)]
    public void ConvertFrom_QuantityWithSameDimensions_ToQuantity(MassConcentrationUnit fromUnit, DensityUnit expectedUnit)
    {
        QuantityValue valueToConvert = 100;
        UnitInfo fromUnitInfo = MassConcentration.Info[fromUnit];

        var expectedResult = Density.From(MassConcentration.From(valueToConvert, fromUnit).KilogramsPerCubicMeter, DensityUnit.KilogramPerCubicMeter);

        Density result = Density.Info.ConvertFrom(valueToConvert, fromUnitInfo);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedUnit, result.Unit);
    }

    [Theory]
    [InlineData(MassConcentrationUnit.KilogramPerCubicMeter, DensityUnit.KilogramPerCubicMeter)]
    [InlineData(MassConcentrationUnit.GramPerCubicMeter, DensityUnit.GramPerCubicMeter)]
    [InlineData(MassConcentrationUnit.PoundPerCubicFoot, DensityUnit.PoundPerCubicFoot)]
    [InlineData(MassConcentrationUnit.GramPerLiter, DensityUnit.GramPerLiter)]
    [InlineData(MassConcentrationUnit.PoundPerUSGallon, DensityUnit.KilogramPerCubicMeter)]
    public void ConvertFrom_QuantityWithSameDimensions_ToIQuantity(MassConcentrationUnit fromUnit, DensityUnit expectedUnit)
    {
        QuantityValue valueToConvert = 100;
        UnitInfo fromUnitInfo = MassConcentration.Info[fromUnit];
        QuantityInfo targetQuantityInfo = Density.Info;

        IQuantity expectedResult = Density.From(MassConcentration.From(valueToConvert, fromUnit).KilogramsPerCubicMeter, DensityUnit.KilogramPerCubicMeter);

        IQuantity result = targetQuantityInfo.ConvertFrom(valueToConvert, fromUnitInfo);

        Assert.Equal(expectedResult, result);
        Assert.Equal(expectedUnit, result.Unit);
    }

    [Fact]
    public void TryToConvertFrom_QuantityWithIncompatibleDimensions_ToQuantity_ReturnsFalse()
    {
        UnitInfo fromUnitInfo = MassConcentration.Info[MassConcentrationUnit.GramPerCubicMeter];

        var success = Volume.Info.TryConvertFrom(1, fromUnitInfo, out Volume _);

        Assert.False(success);
    }

    [Fact]
    public void TryToConvertFrom_QuantityWithIncompatibleDimensions_ToIQuantity_ReturnsFalse()
    {
        UnitInfo fromUnitInfo = MassConcentration.Info[MassConcentrationUnit.GramPerCubicMeter];
        QuantityInfo targetQuantityInfo = Volume.Info;

        var success = targetQuantityInfo.TryConvertFrom(1, fromUnitInfo, out IQuantity? _);

        Assert.False(success);
    }

    [Fact]
    public void TryToConvertFrom_QuantityWithNoMatchingBaseUnits_ToQuantity_ReturnsFalse()
    {
        UnitInfo fromUnitInfo = MassConcentration.Info[MassConcentrationUnit.GramPerCubicMeter];
        // we simulate a target quantity without any base units
        var targetQuantityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
            unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));

        var success = targetQuantityInfo.TryConvertFrom(1, fromUnitInfo, out Density _);

        Assert.False(success);
    }

    [Fact]
    public void TryToConvertFrom_QuantityWithNoMatchingBaseUnits_ToIQuantity_ReturnsFalse()
    {
        UnitInfo fromUnitInfo = MassConcentration.Info[MassConcentrationUnit.GramPerCubicMeter];
        // we simulate a target quantity without any base units
        QuantityInfo targetQuantityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
            unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));

        var success = targetQuantityInfo.TryConvertFrom(1, fromUnitInfo, out IQuantity? _);

        Assert.False(success);
    }

    [Fact]
    public void ConvertFrom_QuantityWithIncompatibleDimensions_ToQuantity_ThrowsInvalidConversionException()
    {
        UnitInfo fromUnitInfo = MassConcentration.Info[MassConcentrationUnit.GramPerCubicMeter];

        Assert.Throws<InvalidConversionException>(() => Volume.Info.ConvertFrom(1, fromUnitInfo));
    }

    [Fact]
    public void ConvertFrom_QuantityWithIncompatibleDimensions_ToIQuantity_ThrowsInvalidConversionException()
    {
        UnitInfo fromUnitInfo = MassConcentration.Info[MassConcentrationUnit.GramPerCubicMeter];
        QuantityInfo targetQuantityInfo = Volume.Info;

        Assert.Throws<InvalidConversionException>(() => targetQuantityInfo.ConvertFrom(1, fromUnitInfo));
    }

    [Fact]
    public void ConvertFrom_QuantityWithNoMatchingBaseUnits_ToQuantity_ThrowsInvalidConversionException()
    {
        UnitInfo fromUnitInfo = MassConcentration.Info[MassConcentrationUnit.GramPerCubicMeter];
        // we simulate a target quantity without any base units
        var targetQuantityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
            unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));

        Assert.Throws<InvalidConversionException>(() => targetQuantityInfo.ConvertFrom(1, fromUnitInfo));
    }

    [Fact]
    public void ConvertFrom_QuantityWithNoMatchingBaseUnits_ToIQuantity_ThrowsInvalidConversionException()
    {
        UnitInfo fromUnitInfo = MassConcentration.Info[MassConcentrationUnit.GramPerCubicMeter];
        // we simulate a target quantity without any base units
        QuantityInfo targetQuantityInfo = Density.DensityInfo.CreateDefault(unitInfos =>
            unitInfos.Select(x => new UnitDefinition<DensityUnit>(x.Value, x.PluralName, BaseUnits.Undefined)));

        Assert.Throws<InvalidConversionException>(() => targetQuantityInfo.ConvertFrom(1, fromUnitInfo));
    }

    [Theory]
    [InlineData(1, 0, 0, 0, 0, 0, 0)]
    [InlineData(0, 1, 0, 0, 0, 0, 0)]
    [InlineData(0, 0, 1, 0, 0, 0, 0)]
    [InlineData(0, 0, 0, 1, 0, 0, 0)]
    [InlineData(0, 0, 0, 0, 1, 0, 0)]
    [InlineData(0, 0, 0, 0, 0, 1, 0)]
    [InlineData(0, 0, 0, 0, 0, 0, 1)]
    public void IsInverse_BaseDimension_ReturnsTheExpectedValue(int length, int mass, int time, int current, int temperature, int amount, int luminousIntensity)
    {
        var baseDimensions = new BaseDimensions(length, mass, time, current, temperature, amount, luminousIntensity);
        var inverseDimensions = new BaseDimensions(-length, -mass, -time, -current, -temperature, -amount, -luminousIntensity);
        Assert.True(baseDimensions.IsInverseOf(inverseDimensions));
        Assert.True(inverseDimensions.IsInverseOf(baseDimensions));
        Assert.False(baseDimensions.IsInverseOf(baseDimensions));
        Assert.False(baseDimensions.IsInverseOf(BaseDimensions.Dimensionless));
        Assert.False(BaseDimensions.Dimensionless.IsInverseOf(baseDimensions));
    }
}
