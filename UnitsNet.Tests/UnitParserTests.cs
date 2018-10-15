// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    [Collection( nameof( UnitAbbreviationsCacheFixture ) )]
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
        public void Parse_UnknownAbbreviationThrowsUnitNotFoundException()
        {
            Assert.Throws<UnitNotFoundException>(() => UnitParser.Default.Parse<AreaUnit>("nonexistingunit"));
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
    }
}
