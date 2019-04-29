// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    [Collection(nameof(UnitAbbreviationsCacheFixture))]
    public class UnitParserTests
    {
        [Theory]
        [InlineData("m^^2", AreaUnit.SquareMeter)]
        [InlineData("cm^^2", AreaUnit.SquareCentimeter)]
        public void Parse_ReturnsUnitMappedByCustomAbbreviation(string customAbbreviation, AreaUnit expected)
        {
            var abbrevCache = new UnitAbbreviationsCache();
            abbrevCache.MapUnitToAbbreviation(expected, customAbbreviation);
            var parser = new UnitParser(abbrevCache);

            var actual = parser.Parse<AreaUnit>(customAbbreviation);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AbbreviationCaseInsensitive_Lowercase_years()
        {
            var abbreviation = "years";
            var expected = DurationUnit.Year365;
            var parser = UnitParser.Default;

            var actual = parser.Parse<DurationUnit>(abbreviation);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_AbbreviationCaseInsensitive_Uppercase_Years()
        {
            var abbreviation = "Years";
            var expected = DurationUnit.Year365;
            var parser = UnitParser.Default;

            var actual = parser.Parse<DurationUnit>(abbreviation);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Parse_GivenAbbreviationsThatAreAmbiguousWhenLowerCase_ReturnsCorrectUnit()
        {
            Assert.Equal(PressureUnit.Megabar, Pressure.ParseUnit("Mbar"));
            Assert.Equal(PressureUnit.Millibar, Pressure.ParseUnit("mbar"));
        }

        [Fact]
        public void Parse_UnknownAbbreviationThrowsUnitNotFoundException()
        {
            Assert.Throws<UnitNotFoundException>(() => UnitParser.Default.Parse<AreaUnit>("nonexistingunit"));
        }

        [Theory]
        [InlineData("m", typeof(LengthUnit), LengthUnit.Meter)]
        [InlineData("m^1", typeof(LengthUnit), LengthUnit.Meter)]
        [InlineData("m²", typeof(AreaUnit), AreaUnit.SquareMeter)]
        [InlineData("m^2", typeof(AreaUnit), AreaUnit.SquareMeter)]
        [InlineData("m³", typeof(VolumeUnit), VolumeUnit.CubicMeter)]
        [InlineData("m^3", typeof(VolumeUnit), VolumeUnit.CubicMeter)]
        [InlineData("m⁴", typeof(AreaMomentOfInertiaUnit), AreaMomentOfInertiaUnit.MeterToTheFourth)]
        [InlineData("m^4", typeof(AreaMomentOfInertiaUnit), AreaMomentOfInertiaUnit.MeterToTheFourth)]
        [InlineData("K⁻¹", typeof(CoefficientOfThermalExpansionUnit), CoefficientOfThermalExpansionUnit.InverseKelvin)]
        [InlineData("K^-1", typeof(CoefficientOfThermalExpansionUnit), CoefficientOfThermalExpansionUnit.InverseKelvin)]
        [InlineData("kg·s⁻¹·m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("kg·s^-1·m^-2", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        public void Parse_CanParseUnitsWithPowers(string unitAbbreviation, Type unitType, Enum resultUnitType)
        {
            Assert.Equal(resultUnitType, UnitParser.Default.Parse(unitAbbreviation, unitType));
        }

        [Theory]
        [InlineData("kg·s⁻¹·m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("kg*s⁻¹*m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("kg·s⁻¹*m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        public void Parse_CanParseMultiplySigns(string unitAbbreviation, Type unitType, Enum resultUnitType)
        {
            Assert.Equal(resultUnitType, UnitParser.Default.Parse(unitAbbreviation, unitType));
        }

        [Theory]
        [InlineData("kg·s⁻¹·m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData(" kg·s⁻¹·m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("kg·s⁻¹·m⁻² ", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("kg· s⁻¹·m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        [InlineData("kg·s⁻¹ ·m⁻²", typeof(MassFluxUnit), MassFluxUnit.KilogramPerSecondPerSquareMeter)]
        public void Parse_CanParseWithWithspacesInUnit(string unitAbbreviation, Type unitType, Enum resultUnitType)
        {
            Assert.Equal(resultUnitType, UnitParser.Default.Parse(unitAbbreviation, unitType));
        }

        [Fact]
        public void ParseUnit_ShouldUseCorrectMicroSign()
        {
            // "\u00b5" = Micro sign
            Assert.Equal(AccelerationUnit.MicrometerPerSecondSquared, Acceleration.ParseUnit("\u00b5m/s²"));
            Assert.Equal(AmplitudeRatioUnit.DecibelMicrovolt, AmplitudeRatio.ParseUnit("dB\u00b5V"));
            Assert.Equal(AngleUnit.Microdegree, Angle.ParseUnit("\u00b5°"));
            Assert.Equal(AngleUnit.Microradian, Angle.ParseUnit("\u00b5rad"));
            Assert.Equal(AreaUnit.SquareMicrometer, Area.ParseUnit("\u00b5m²"));
            Assert.Equal(DurationUnit.Microsecond, Duration.ParseUnit("\u00b5s"));
            Assert.Equal(ElectricCurrentUnit.Microampere, ElectricCurrent.ParseUnit("\u00b5A"));
            Assert.Equal(ElectricPotentialUnit.Microvolt, ElectricPotential.ParseUnit("\u00b5V"));
            Assert.Equal(ForceChangeRateUnit.MicronewtonPerSecond, ForceChangeRate.ParseUnit("\u00b5N/s"));
            Assert.Equal(ForcePerLengthUnit.MicronewtonPerMeter, ForcePerLength.ParseUnit("\u00b5N/m"));
            Assert.Equal(KinematicViscosityUnit.Microstokes, KinematicViscosity.ParseUnit("\u00b5St"));
            Assert.Equal(LengthUnit.Microinch, Length.ParseUnit("\u00b5in"));
            Assert.Equal(LengthUnit.Micrometer, Length.ParseUnit("\u00b5m"));
            Assert.Equal(MassFlowUnit.MicrogramPerSecond, MassFlow.ParseUnit("\u00b5g/S"));
            Assert.Equal(MassUnit.Microgram, Mass.ParseUnit("\u00b5g"));
            Assert.Equal(PowerUnit.Microwatt, Power.ParseUnit("\u00b5W"));
            Assert.Equal(PressureUnit.Micropascal, Pressure.ParseUnit("\u00b5Pa"));
            Assert.Equal(RotationalSpeedUnit.MicrodegreePerSecond, RotationalSpeed.ParseUnit("\u00b5°/s"));
            Assert.Equal(RotationalSpeedUnit.MicroradianPerSecond, RotationalSpeed.ParseUnit("\u00b5rad/s"));
            Assert.Equal(SpeedUnit.MicrometerPerMinute, Speed.ParseUnit("\u00b5m/min"));
            Assert.Equal(SpeedUnit.MicrometerPerSecond, Speed.ParseUnit("\u00b5m/s"));
            Assert.Equal(TemperatureChangeRateUnit.MicrodegreeCelsiusPerSecond, TemperatureChangeRate.ParseUnit("\u00b5°C/s"));
            Assert.Equal(VolumeUnit.Microliter, Volume.ParseUnit("\u00b5l"));
            Assert.Equal(VolumeUnit.CubicMicrometer, Volume.ParseUnit("\u00b5m³"));
            Assert.Equal(VolumeFlowUnit.MicroliterPerMinute, VolumeFlow.ParseUnit("\u00b5LPM"));

            // "\u03bc" = Lower case greek letter 'Mu'
            Assert.Throws<UnitNotFoundException>(() => Acceleration.ParseUnit("\u03bcm/s²"));
            Assert.Throws<UnitNotFoundException>(() => AmplitudeRatio.ParseUnit("dB\u03bcV"));
            Assert.Throws<UnitNotFoundException>(() => Angle.ParseUnit("\u03bc°"));
            Assert.Throws<UnitNotFoundException>(() => Angle.ParseUnit("\u03bcrad"));
            Assert.Throws<UnitNotFoundException>(() => Area.ParseUnit("\u03bcm²"));
            Assert.Throws<UnitNotFoundException>(() => Duration.ParseUnit("\u03bcs"));
            Assert.Throws<UnitNotFoundException>(() => ElectricCurrent.ParseUnit("\u03bcA"));
            Assert.Throws<UnitNotFoundException>(() => ElectricPotential.ParseUnit("\u03bcV"));
            Assert.Throws<UnitNotFoundException>(() => ForceChangeRate.ParseUnit("\u03bcN/s"));
            Assert.Throws<UnitNotFoundException>(() => ForcePerLength.ParseUnit("\u03bcN/m"));
            Assert.Throws<UnitNotFoundException>(() => KinematicViscosity.ParseUnit("\u03bcSt"));
            Assert.Throws<UnitNotFoundException>(() => Length.ParseUnit("\u03bcin"));
            Assert.Throws<UnitNotFoundException>(() => Length.ParseUnit("\u03bcm"));
            Assert.Throws<UnitNotFoundException>(() => MassFlow.ParseUnit("\u03bcg/S"));
            Assert.Throws<UnitNotFoundException>(() => Mass.ParseUnit("\u03bcg"));
            Assert.Throws<UnitNotFoundException>(() => Power.ParseUnit("\u03bcW"));
            Assert.Throws<UnitNotFoundException>(() => Pressure.ParseUnit("\u03bcPa"));
            Assert.Throws<UnitNotFoundException>(() => RotationalSpeed.ParseUnit("\u03bc°/s"));
            Assert.Throws<UnitNotFoundException>(() => RotationalSpeed.ParseUnit("\u03bcrad/s"));
            Assert.Throws<UnitNotFoundException>(() => Speed.ParseUnit("\u03bcm/min"));
            Assert.Throws<UnitNotFoundException>(() => Speed.ParseUnit("\u03bcm/s"));
            Assert.Throws<UnitNotFoundException>(() => TemperatureChangeRate.ParseUnit("\u03bc°C/s"));
            Assert.Throws<UnitNotFoundException>(() => Volume.ParseUnit("\u03bcl"));
            Assert.Throws<UnitNotFoundException>(() => Volume.ParseUnit("\u03bcm³"));
            Assert.Throws<UnitNotFoundException>(() => VolumeFlow.ParseUnit("\u03bcLPM"));
        }

        [Fact]
        public void Parse_AmbiguousUnitsThrowsException()
        {
            // Act 1
            var exception1 = Assert.Throws<AmbiguousUnitParseException>(() => UnitParser.Default.Parse<LengthUnit>("pt"));

            // Act 2
            var exception2 = Assert.Throws<AmbiguousUnitParseException>(() => Length.Parse("1 pt"));

            // Assert
            Assert.Equal("Cannot parse \"pt\" since it could be either of these: DtpPoint, PrinterPoint", exception1.Message);
            Assert.Equal("Cannot parse \"pt\" since it could be either of these: DtpPoint, PrinterPoint", exception2.Message);
        }

        [Theory]
        [InlineData("ng", "en-US", MassUnit.Nanogram)]
        [InlineData("нг", "ru-RU", MassUnit.Nanogram)]
        [InlineData("g", "en-US", MassUnit.Gram)]
        [InlineData("г", "ru-RU", MassUnit.Gram)]
        [InlineData("kg", "en-US", MassUnit.Kilogram)]
        [InlineData("кг", "ru-RU", MassUnit.Kilogram)]
        public void ParseMassUnit_GivenCulture(string str, string cultureName, Enum expectedUnit)
        {
            Assert.Equal(expectedUnit, UnitParser.Default.Parse<MassUnit>(str, new CultureInfo(cultureName)));
        }
    }
}
