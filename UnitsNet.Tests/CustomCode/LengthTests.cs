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
        protected override bool SupportsSIUnitSystem => true;
        protected override double CentimetersInOneMeter => 100;

        protected override double DecimetersInOneMeter => 10;
        protected override double DtpPicasInOneMeter => 236.22047244;
        protected override double DtpPointsInOneMeter => 2834.6456693;

        protected override double FeetInOneMeter => 3.28084;

        protected override double HectometersInOneMeter => 1E-2;

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

        protected override double HandsInOneMeter => 9.8425196850393701;

        protected override double AstronomicalUnitsInOneMeter => 6.6845871222684500000000000E-12;

        protected override double KilolightYearsInOneMeter => 1.0570008340247000000000000E-19;

        protected override double KiloparsecsInOneMeter => 3.2407790389471100000000000E-20;

        protected override double LightYearsInOneMeter => 1.0570008340247000000000000E-16;

        protected override double MegalightYearsInOneMeter => 1.0570008340247000000000000E-22;

        protected override double MegaparsecsInOneMeter => 3.2407790389471100000000000E-23;

        protected override double ParsecsInOneMeter => 3.2407790389471100000000000E-17;

        protected override double SolarRadiusesInOneMeter => 1.43779384911791000E-09;

        protected override double ChainsInOneMeter => 0.0497096953789867;

        [ Fact]
        public void AreaTimesLengthEqualsVolume()
        {
            var volume = Area<double>.FromSquareMeters(10)*Length<double>.FromMeters(3);
            Assert.Equal(volume, Volume<double>.FromCubicMeters(30));
        }

        [Fact]
        public void ForceTimesLengthEqualsTorque()
        {
            var torque = Force<double>.FromNewtons(1)*Length<double>.FromMeters(3);
            Assert.Equal(torque, Torque<double>.FromNewtonMeters(3));
        }

        [Fact]
        public void LengthTimesAreaEqualsVolume()
        {
            var volume = Length<double>.FromMeters(3)*Area<double>.FromSquareMeters(9);
            Assert.Equal(volume, Volume<double>.FromCubicMeters(27));
        }

        [Fact]
        public void LengthTimesForceEqualsTorque()
        {
            var torque = Length<double>.FromMeters(3)*Force<double>.FromNewtons(1);
            Assert.Equal(torque, Torque<double>.FromNewtonMeters(3));
        }

        [Fact]
        public void LengthTimesLengthEqualsArea()
        {
            var area = Length<double>.FromMeters(10)*Length<double>.FromMeters(2);
            Assert.Equal(area, Area<double>.FromSquareMeters(20));
        }

        [Fact]
        public void LengthDividedBySpeedEqualsDuration()
        {
            var duration = Length<double>.FromMeters(20) / Speed<double>.FromMetersPerSecond(2);
            Assert.Equal(Duration<double>.FromSeconds(10), duration);
        }

        [Fact]
        public void LengthTimesSpeedEqualsKinematicViscosity()
        {
            var kinematicViscosity = Length<double>.FromMeters(20) * Speed<double>.FromMetersPerSecond(2);
            Assert.Equal(KinematicViscosity<double>.FromSquareMetersPerSecond(40), kinematicViscosity);
        }

        [Fact]
        public void LengthTimesSpecificWeightEqualsPressure()
        {
            var pressure = Length<double>.FromMeters(2) * SpecificWeight<double>.FromNewtonsPerCubicMeter(10);
            Assert.Equal(Pressure<double>.FromPascals(20), pressure);
        }

        [Fact]
        public void ToStringReturnsCorrectNumberAndUnitWithDefaultUnitWhichIsMeter()
        {
            var meter = Length<double>.FromMeters(5);
            string meterString = meter.ToString();
            Assert.Equal("5 m", meterString);
        }

        [Fact]
        public void ToStringReturnsCorrectNumberAndUnitWithCentimeterAsDefualtUnit()
        {
            var value = Length<double>.From(2, LengthUnit.Centimeter);
            string valueString = value.ToString();
            Assert.Equal("2 cm", valueString);
        }

        [Fact]
        public void MaxValueIsCorrectForUnitWithBaseTypeDouble()
        {
            Assert.Equal(double.MaxValue, Length<double>.MaxValue.Meters);
        }

        [Fact]
        public void MinValueIsCorrectForUnitWithBaseTypeDouble()
        {
            Assert.Equal(double.MinValue, Length<double>.MinValue.Meters);
        }

        [Fact]
        public void NegativeLengthToStonePoundsReturnsCorrectValues()
        {
            var negativeLength = Length<double>.FromInches(-1.0);
            var feetInches = negativeLength.FeetInches;

            Assert.Equal(0, feetInches.Feet);
            Assert.Equal(-1.0, feetInches.Inches);

            negativeLength = Length<double>.FromInches(-25.0);
            feetInches = negativeLength.FeetInches;

            Assert.Equal(-2.0, feetInches.Feet);
            Assert.Equal(-1.0, feetInches.Inches);
        }

        [Fact]
        public void Constructor_UnitSystemNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Length<double>(1.0, (UnitSystem)null));
        }

        [Fact]
        public void Constructor_UnitSystemSI_AssignsSIUnit()
        {
            var length = new Length<double>(1.0, UnitSystem.SI);
            Assert.Equal(LengthUnit.Meter, length.Unit);
        }

        [Fact]
        public void Constructor_UnitSystemWithNoMatchingBaseUnits_ThrowsArgumentException()
        {
            // AmplitudeRatio is unitless. Can't have any matches :)
            Assert.Throws<ArgumentException>(() => new AmplitudeRatio<double>( 1.0, UnitSystem.SI));
        }

        [Fact]
        public void As_GivenSIUnitSystem_ReturnsSIValue()
        {
            var inches = new Length<double>(2.0, LengthUnit.Inch);
            Assert.Equal(0.0508, inches.As(UnitSystem.SI));
        }

        [Fact]
        public void ToUnit_GivenSIUnitSystem_ReturnsSIQuantity()
        {
            var inches = new Length<double>(2.0, LengthUnit.Inch);

            var inSI = inches.ToUnit(UnitSystem.SI);

            Assert.Equal(0.0508, inSI.Value);
            Assert.Equal(LengthUnit.Meter, inSI.Unit);
        }
    }
}
