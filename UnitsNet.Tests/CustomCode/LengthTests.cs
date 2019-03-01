// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;
using UnitsNet.Units;
using System;

namespace UnitsNet.Tests.CustomCode
{
    // Avoid accessing static prop DefaultToString in parallel from multiple tests:
    // UnitSystemTests.DefaultToStringFormatting()
    // LengthTests.ToStringReturnsCorrectNumberAndUnitWithCentimeterAsDefualtUnit()
    [Collection(nameof(UnitAbbreviationsCacheFixture))]
    public class LengthTests : LengthTestsBase
    {
        protected override double CentimetersInOneMeter => 100;

        protected override double DecimetersInOneMeter => 10;
        protected override double DtpPicasInOneMeter => 236.22047244;
        protected override double DtpPointsInOneMeter => 2834.6456693;

        protected override double FeetInOneMeter => 3.28084;

        protected override double TwipsInOneMeter => 56692.913386;
        protected override double UsSurveyFeetInOneMeter => 3.280833333333333;

        protected override double InchesInOneMeter => 39.37007874;

        protected override double KilometersInOneMeter => 1E-3;

        protected override double MetersInOneMeter => 1;

        protected override double MicroinchesInOneMeter => 39370078.74015748;

        protected override double MicrometersInOneMeter => 1E6;

        protected override double MilsInOneMeter => 39370.07874015;

        protected override double MilesInOneMeter => 0.000621371;

        protected override double MillimetersInOneMeter => 1E3;

        protected override double NanometersInOneMeter => 1E9;

        protected override double YardsInOneMeter => 1.09361;

        protected override double FathomsInOneMeter => 0.546806649;

        protected override double PrinterPicasInOneMeter => 237.10630158;
        protected override double PrinterPointsInOneMeter => 2845.2755906;

        protected override double ShacklesInOneMeter => 0.0364538;

        protected override double NauticalMilesInOneMeter => 1.0/1852.0;

        [Fact]
        public void AreaTimesLengthEqualsVolume()
        {
            Volume volume = Area.FromSquareMeters(10)*Length.FromMeters(3);
            Assert.Equal(volume, Volume.FromCubicMeters(30));
        }

        [Fact]
        public void ForceTimesLengthEqualsTorque()
        {
            Torque torque = Force.FromNewtons(1)*Length.FromMeters(3);
            Assert.Equal(torque, Torque.FromNewtonMeters(3));
        }

        [Fact]
        public void LengthTimesAreaEqualsVolume()
        {
            Volume volume = Length.FromMeters(3)*Area.FromSquareMeters(9);
            Assert.Equal(volume, Volume.FromCubicMeters(27));
        }

        [Fact]
        public void LengthTimesForceEqualsTorque()
        {
            Torque torque = Length.FromMeters(3)*Force.FromNewtons(1);
            Assert.Equal(torque, Torque.FromNewtonMeters(3));
        }

        [Fact]
        public void LengthTimesLengthEqualsArea()
        {
            Area area = Length.FromMeters(10)*Length.FromMeters(2);
            Assert.Equal(area, Area.FromSquareMeters(20));
        }

        [Fact]
        public void LengthDividedBySpeedEqualsDuration()
        {
            Duration duration = Length.FromMeters(20) / Speed.FromMetersPerSecond(2);
            Assert.Equal(Duration.FromSeconds(10), duration);
        }

        [Fact]
        public void LengthTimesSpeedEqualsKinematicViscosity()
        {
            KinematicViscosity kinematicViscosity = Length.FromMeters(20) * Speed.FromMetersPerSecond(2);
            Assert.Equal(KinematicViscosity.FromSquareMetersPerSecond(40), kinematicViscosity);
        }

        [Fact]
        public void LengthTimesSpecificWeightEqualsPressure()
        {
            Pressure pressure = Length.FromMeters(2) * SpecificWeight.FromNewtonsPerCubicMeter(10);
            Assert.Equal(Pressure.FromPascals(20), pressure);
        }

        [Fact]
        public void ToStringReturnsCorrectNumberAndUnitWithDefaultUnitWhichIsMeter()
        {
            var meter = Length.FromMeters(5);
            string meterString = meter.ToString();
            Assert.Equal("5 m", meterString);
        }

        [Fact]
        public void ToStringReturnsCorrectNumberAndUnitWithCentimeterAsDefualtUnit()
        {
            var value = Length.From(2, LengthUnit.Centimeter);
            string valueString = value.ToString();
            Assert.Equal("2 cm", valueString);
        }

        [Fact]
        public void MaxValueIsCorrectForUnitWithBaseTypeDouble()
        {
            Assert.Equal(double.MaxValue, Length.MaxValue.Meters);
        }

        [Fact]
        public void MinValueIsCorrectForUnitWithBaseTypeDouble()
        {
            Assert.Equal(double.MinValue, Length.MinValue.Meters);
        }

        [Fact]
        public void NegativeLengthToStonePoundsReturnsCorrectValues()
        {
            var negativeLength = Length.FromInches(-1.0);
            var feetInches = negativeLength.FeetInches;

            Assert.Equal(0, feetInches.Feet);
            Assert.Equal(-1.0, feetInches.Inches);

            negativeLength = Length.FromInches(-25.0);
            feetInches = negativeLength.FeetInches;

            Assert.Equal(-2.0, feetInches.Feet);
            Assert.Equal(-1.0, feetInches.Inches);
        }

        [Fact]
        public void Constructor_UnitSystemNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Length(1.0, (UnitSystem)null));
        }

        [Fact]
        public void Constructor_UnitSystemSI_AssignsSIUnit()
        {
            var length = new Length(1.0, UnitSystem.SI);
            Assert.Equal(LengthUnit.Meter, length.Unit);
        }
    }
}
