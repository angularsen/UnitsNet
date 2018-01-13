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

        protected override double MetersPerHourInOneMeterPerSecond => 3600.0;

        protected override double NanometersPerMinutesInOneMeterPerSecond => 60000000000;

        protected override double MicrometersPerMinutesInOneMeterPerSecond => 60000000;

        protected override double MillimetersPerMinutesInOneMeterPerSecond => 60000;

        protected override double CentimetersPerMinutesInOneMeterPerSecond => 6000;

        protected override double DecimetersPerMinutesInOneMeterPerSecond => 600;

        protected override double MetersPerMinutesInOneMeterPerSecond => 60;

        protected override double KilometersPerMinutesInOneMeterPerSecond => 0.06;

        protected override double CentimetersPerHourInOneMeterPerSecond => 360000;

        protected override double MillimetersPerHourInOneMeterPerSecond => 3600000;

        protected override double FeetPerHourInOneMeterPerSecond => 11811.023622;

        protected override double FeetPerMinuteInOneMeterPerSecond => 196.850393701;

        protected override double InchesPerHourInOneMeterPerSecond => 141732.283465;

        protected override double InchesPerMinuteInOneMeterPerSecond => 2362.20472441;

        protected override double InchesPerSecondInOneMeterPerSecond => 39.3700787402;

        protected override double YardsPerHourInOneMeterPerSecond => 3937.00787402;

        protected override double YardsPerMinuteInOneMeterPerSecond => 65.6167979003;

        protected override double YardsPerSecondInOneMeterPerSecond => 1.093613298338;

        protected override double UsSurveyFeetPerSecondInOneMeterPerSecond => 3.280833333333;

        protected override double UsSurveyFeetPerMinuteInOneMeterPerSecond => 196.85;

        protected override double UsSurveyFeetPerHourInOneMeterPerSecond => 1.1811E4;

        [Fact]
        public void DurationSpeedTimesEqualsLength()
        {
            Length length = Duration.FromSeconds(2)*Speed.FromMetersPerSecond(20);
            Assert.Equal(length, Length.FromMeters(40));
        }

        [Fact]
        public void LengthDividedByDurationEqualsSpeed()
        {
            Speed speed = Length.FromMeters(20)/Duration.FromSeconds(2);
            Assert.Equal(speed, Speed.FromMetersPerSecond(10));
        }

        [Fact]
        public void LengthDividedByTimeSpanEqualsSpeed()
        {
            Speed speed = Length.FromMeters(20)/TimeSpan.FromSeconds(2);
            Assert.Equal(speed, Speed.FromMetersPerSecond(10));
        }

        [Fact]
        public void SpeedDividedByDurationEqualsAcceleration()
        {
            Acceleration acceleration = Speed.FromMetersPerSecond(20)/Duration.FromSeconds(2);
            Assert.Equal(acceleration, Acceleration.FromMeterPerSecondSquared(10));
        }

        [Fact]
        public void SpeedDividedByTimeSpanEqualsAcceleration()
        {
            Acceleration acceleration = Speed.FromMetersPerSecond(20)/TimeSpan.FromSeconds(2);
            Assert.Equal(acceleration, Acceleration.FromMeterPerSecondSquared(10));
        }

        [Fact]
        public void SpeedTimesDurationEqualsLength()
        {
            Length length = Speed.FromMetersPerSecond(20)*Duration.FromSeconds(2);
            Assert.Equal(length, Length.FromMeters(40));
        }

        [Fact]
        public void SpeedTimesTimeSpanEqualsLength()
        {
            Length length = Speed.FromMetersPerSecond(20)*TimeSpan.FromSeconds(2);
            Assert.Equal(length, Length.FromMeters(40));
        }

        [Fact]
        public void TimeSpanTimesSpeedEqualsLength()
        {
            Length length = TimeSpan.FromSeconds(2)*Speed.FromMetersPerSecond(20);
            Assert.Equal(length, Length.FromMeters(40));
        }

        [Fact]
        public void SpeedTimesLengthEqualsKinematicViscosity()
        {
            KinematicViscosity kinematicViscosity = Length.FromMeters(20) * Speed.FromMetersPerSecond(2);
            Assert.Equal(KinematicViscosity.FromSquareMetersPerSecond(40), kinematicViscosity);
        }

        [Fact]
        public void SpeedTimesSpeedEqualsSpecificEnergy()
        {
            //m^2/s^2 = kg*m*m/(s^2*kg) = J/kg
            SpecificEnergy length = Speed.FromMetersPerSecond(2) * Speed.FromMetersPerSecond(20);
            Assert.Equal(length, SpecificEnergy.FromJoulesPerKilogram(40));
        }

        [Fact]
        public void SpeedTimesDensityEqualsMassFlux()
        {
            MassFlux massFlux = Speed.FromMetersPerSecond(20) * Density.FromKilogramsPerCubicMeter(2);
            Assert.Equal(massFlux, MassFlux.FromKilogramsPerSecondPerSquareMeter(40));
        }
    }
}
