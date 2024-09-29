// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
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

        protected override double FemtometersInOneMeter => 1E+15;
        protected override double FeetInOneMeter => 3.28083989501;

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

        protected override double PicometersInOneMeter => 1E+12;
        protected override double PrinterPicasInOneMeter => 237.10630158;
        protected override double PrinterPointsInOneMeter => 2845.2755906;

        protected override double ShacklesInOneMeter => 0.0364538;

        protected override double NauticalMilesInOneMeter => 1.0/1852.0;

        protected override double HandsInOneMeter => 9.8425196850393701;

        protected override double AstronomicalUnitsInOneMeter => 6.6845871222684500000000000E-12;

        protected override double KilolightYearsInOneMeter => 1.0570008340247000000000000E-19;

        protected override double KiloparsecsInOneMeter => 3.2407790389471100000000000E-20;

        protected override double KiloyardsInOneMeter => 1.0936132983E-3;

        protected override double LightYearsInOneMeter => 1.0570008340247000000000000E-16;

        protected override double MegalightYearsInOneMeter => 1.0570008340247000000000000E-22;

        protected override double MegaparsecsInOneMeter => 3.2407790389471100000000000E-23;

        protected override double ParsecsInOneMeter => 3.2407790389471100000000000E-17;

        protected override double SolarRadiusesInOneMeter => 1.4374011786689664E-09;

        protected override double ChainsInOneMeter => 0.0497096953789867;

        protected override double DecametersInOneMeter => 1e-1;

        protected override double AngstromsInOneMeter => 1e10;

        protected override double DataMilesInOneMeter => 0.000546807;

        protected override double MegametersInOneMeter => 1e-6;
        protected override double GigametersInOneMeter => 1e-9;

        protected override double KilofeetInOneMeter => 3.28083989501e-3;

        [ Fact]
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
        public void LengthDividedByAreaEqualsReciprocalLength()
        {
            ReciprocalLength reciprocalLength = Length.FromMeters(20) / Area.FromSquareMeters(2);
            Assert.Equal(ReciprocalLength.FromInverseMeters(10), reciprocalLength);
        }

        [Fact]
        public void LengthDividedByVolumeEqualsReciprocalArea()
        {
            ReciprocalArea reciprocalArea = Length.FromMeters(20) / Volume.FromCubicMeters(2);
            Assert.Equal(ReciprocalArea.FromInverseSquareMeters(10), reciprocalArea);
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
            string meterString = meter.ToString(CultureInfo.InvariantCulture);
            Assert.Equal("5 m", meterString);
        }

        [Fact]
        public void ToStringReturnsCorrectNumberAndUnitWithCentimeterAsDefualtUnit()
        {
            var value = Length.From(2, LengthUnit.Centimeter);
            string valueString = value.ToString(CultureInfo.InvariantCulture);
            Assert.Equal("2 cm", valueString);
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
            Assert.Throws<ArgumentNullException>(() => new Length(1.0, unitSystem: null!));
        }

        [Fact]
        public void Constructor_UnitSystemSI_AssignsSIUnit()
        {
            var length = new Length(1.0, UnitSystem.SI);
            Assert.Equal(LengthUnit.Meter, length.Unit);
        }

        [Fact]
        public void Constructor_UnitSystemWithNoMatchingBaseUnits_ThrowsArgumentException()
        {
            // AmplitudeRatio is unitless. Can't have any matches :)
            Assert.Throws<ArgumentException>(() => new AmplitudeRatio(1.0, UnitSystem.SI));
        }

        [Fact]
        public void As_GivenSIUnitSystem_ReturnsSIValue()
        {
            var inches = new Length(2.0, LengthUnit.Inch);
            Assert.Equal(0.0508, inches.As(UnitSystem.SI));
        }

        [Fact]
        public void ToUnit_GivenSIUnitSystem_ReturnsSIQuantity()
        {
            var inches = new Length(2.0, LengthUnit.Inch);

            var inSI = inches.ToUnit(UnitSystem.SI);

            Assert.Equal(0.0508, inSI.Value);
            Assert.Equal(LengthUnit.Meter, inSI.Unit);
        }

        [Theory]
        [InlineData(-1.0, -1.0)]
        [InlineData(-2.0, -0.5)]
        [InlineData(0.0, 0.0)]
        [InlineData(1.0, 1.0)]
        [InlineData(2.0, 0.5)]
        public static void InverseReturnsReciprocalLength(double value, double expected)
        {
            var length = new Length(value, LengthUnit.Meter);
            var inverseLength = length.Inverse();

            Assert.Equal(expected, inverseLength.InverseMeters);
        }

        [Theory]
        [InlineData(3, 2.563, 16, "3' - 2 9/16\"")]
        [InlineData(3, 2.563, 32, "3' - 2 9/16\"")]
        [InlineData(3, 2, 16, "3' - 2\"")]
        [InlineData(3, 2.5, 1, "3' - 2\"")]
        [InlineData(0, 2, 32, "2\"")]
        [InlineData(3, 2.6, 1, "3' - 3\"")]
        [InlineData(3, 2.6, 2, "3' - 2 1/2\"")]
        [InlineData(3, 2.6, 4, "3' - 2 1/2\"")]
        [InlineData(3, 2.6, 8, "3' - 2 5/8\"")]
        [InlineData(3, 2.6, 16, "3' - 2 5/8\"")]
        [InlineData(3, 2.6, 32, "3' - 2 19/32\"")]
        [InlineData(3, 2.6, 128, "3' - 2 77/128\"")]
        public static void ToArchitecturalString_ReturnsFormatted(double ft, double inch, int fractionDenominator, string expected)
        {
            var length = Length.FromFeetInches(ft, inch);

            Assert.Equal(expected, length.FeetInches.ToArchitecturalString(fractionDenominator));
        }

        [Fact]
        public static void ToArchitecturalString_DenomLessThan1_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Length.FromFeetInches(1, 2).FeetInches.ToArchitecturalString(0));
        }
    }
}
