// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class SpeedTests : SpeedTestsBase
    {
        protected override double FeetPerSecondInOneMeterPerSecond => 3.28084;

        protected override double KilometersPerHourInOneMeterPerSecond => 3.6;

        protected override double KnotsInOneMeterPerSecond => 1.94384;

        protected override double MetersPerSecondInOneMeterPerSecond => 1;

        protected override double MilesPerHourInOneMeterPerSecond => 2.23694;

        protected override double NanometersPerSecondInOneMeterPerSecond => 1E9;

        protected override double MicrometersPerSecondInOneMeterPerSecond => 1E6;

        protected override double MillimetersPerSecondInOneMeterPerSecond => 1E3;

        protected override double CentimetersPerSecondInOneMeterPerSecond => 1E2;

        protected override double DecimetersPerSecondInOneMeterPerSecond => 1E1;

        protected override double KilometersPerSecondInOneMeterPerSecond => 1E-3;

        protected override double MetersPerHourInOneMeterPerSecond => 3.6E3;

        protected override double NanometersPerMinutesInOneMeterPerSecond => 6E10;

        protected override double MicrometersPerMinutesInOneMeterPerSecond => 6E7;

        protected override double MillimetersPerMinutesInOneMeterPerSecond => 6E4;

        protected override double CentimetersPerMinutesInOneMeterPerSecond => 6E3;

        protected override double DecimetersPerMinutesInOneMeterPerSecond => 6E2;

        protected override double MetersPerMinutesInOneMeterPerSecond => 6E1;

        protected override double KilometersPerMinutesInOneMeterPerSecond => 6E-2;

        protected override double CentimetersPerHourInOneMeterPerSecond => 3.6E5;

        protected override double MillimetersPerHourInOneMeterPerSecond => 3.6E6;

        protected override double FeetPerHourInOneMeterPerSecond => 1.1811023622E4;

        protected override double FeetPerMinuteInOneMeterPerSecond => 1.96850393701E2;

        protected override double InchesPerHourInOneMeterPerSecond => 1.41732283465E5;

        protected override double InchesPerMinuteInOneMeterPerSecond => 2.36220472441E3;

        protected override double InchesPerSecondInOneMeterPerSecond => 3.93700787402E1;

        protected override double YardsPerHourInOneMeterPerSecond => 3.93700787402E3;

        protected override double YardsPerMinuteInOneMeterPerSecond => 6.56167979003E1;

        protected override double YardsPerSecondInOneMeterPerSecond => 1.093613298338;

        protected override double UsSurveyFeetPerSecondInOneMeterPerSecond => 3.280833333333;

        protected override double UsSurveyFeetPerMinuteInOneMeterPerSecond => 1.9685E2;

        protected override double UsSurveyFeetPerHourInOneMeterPerSecond => 1.1811E4;

        [Fact]
        public void DurationSpeedTimesEqualsLength()
        {
            var length = Duration<double>.FromSeconds(2)*Speed<double>.FromMetersPerSecond(20);
            Assert.Equal(length, Length<double>.FromMeters(40));
        }

        [Fact]
        public void LengthDividedByDurationEqualsSpeed()
        {
            var speed = Length<double>.FromMeters(20)/Duration<double>.FromSeconds(2);
            Assert.Equal(speed, Speed<double>.FromMetersPerSecond(10));
        }

        [Fact]
        public void LengthDividedByTimeSpanEqualsSpeed()
        {
            var speed = Length<double>.FromMeters(20)/TimeSpan.FromSeconds(2);
            Assert.Equal(speed, Speed<double>.FromMetersPerSecond(10));
        }

        [Fact]
        public void SpeedDividedByDurationEqualsAcceleration()
        {
            var acceleration = Speed<double>.FromMetersPerSecond(20)/Duration<double>.FromSeconds(2);
            Assert.Equal(acceleration, Acceleration<double>.FromMetersPerSecondSquared(10));
        }

        [Fact]
        public void SpeedDividedByTimeSpanEqualsAcceleration()
        {
            var acceleration = Speed<double>.FromMetersPerSecond(20)/TimeSpan.FromSeconds(2);
            Assert.Equal(acceleration, Acceleration<double>.FromMetersPerSecondSquared(10));
        }

        [Fact]
        public void SpeedTimesDurationEqualsLength()
        {
            var length = Speed<double>.FromMetersPerSecond(20)*Duration<double>.FromSeconds(2);
            Assert.Equal(length, Length<double>.FromMeters(40));
        }

        [Fact]
        public void SpeedTimesTimeSpanEqualsLength()
        {
            var length = Speed<double>.FromMetersPerSecond(20)*TimeSpan.FromSeconds(2);
            Assert.Equal(length, Length<double>.FromMeters(40));
        }

        [Fact]
        public void TimeSpanTimesSpeedEqualsLength()
        {
            var length = TimeSpan.FromSeconds(2)*Speed<double>.FromMetersPerSecond(20);
            Assert.Equal(length, Length<double>.FromMeters(40));
        }

        [Fact]
        public void SpeedTimesLengthEqualsKinematicViscosity()
        {
            var kinematicViscosity = Length<double>.FromMeters(20) * Speed<double>.FromMetersPerSecond(2);
            Assert.Equal(KinematicViscosity<double>.FromSquareMetersPerSecond(40), kinematicViscosity);
        }

        [Fact]
        public void SpeedTimesSpeedEqualsSpecificEnergy()
        {
            //m^2/s^2 = kg*m*m/(s^2*kg) = J/kg
            var length = Speed<double>.FromMetersPerSecond(2) * Speed<double>.FromMetersPerSecond(20);
            Assert.Equal(length, SpecificEnergy<double>.FromJoulesPerKilogram(40));
        }

        [Fact]
        public void SpeedTimesDensityEqualsMassFlux()
        {
            var massFlux = Speed<double>.FromMetersPerSecond(20) * Density<double>.FromKilogramsPerCubicMeter(2);
            Assert.Equal(massFlux, MassFlux<double>.FromKilogramsPerSecondPerSquareMeter(40));
        }

        [Fact]
        public void SpeedTimesAreaEqualsVolumeFlow()
        {
            var volumeFlow = Speed<double>.FromMetersPerSecond(2) * Area<double>.FromSquareMeters(20);
            Assert.Equal(VolumeFlow<double>.FromCubicMetersPerSecond(40), volumeFlow);
        }
    }
}
