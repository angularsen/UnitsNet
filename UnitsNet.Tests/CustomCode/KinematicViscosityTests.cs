// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class KinematicViscosityTests : KinematicViscosityTestsBase
    {
        protected override double CentistokesInOneSquareMeterPerSecond => 1e6;

        protected override double DecistokesInOneSquareMeterPerSecond => 1e5;

        protected override double KilostokesInOneSquareMeterPerSecond => 10;

        protected override double MicrostokesInOneSquareMeterPerSecond => 1e10;

        protected override double MillistokesInOneSquareMeterPerSecond => 1e7;

        protected override double NanostokesInOneSquareMeterPerSecond => 1e13;

        protected override double SquareMetersPerSecondInOneSquareMeterPerSecond => 1;

        protected override double StokesInOneSquareMeterPerSecond => 1e4;

        [Fact]
        public static void DurationTimesKinematicViscosityEqualsArea()
        {
            var area = Duration<double>.FromSeconds(2)*KinematicViscosity<double>.FromSquareMetersPerSecond(4);
            Assert.Equal(area, Area<double>.FromSquareMeters(8));
        }

        [Fact]
        public static void KinematicViscosityDividedByLengthEqualsSpeed()
        {
            var speed = KinematicViscosity<double>.FromSquareMetersPerSecond(4)/Length<double>.FromMeters(2);
            Assert.Equal(speed, Speed<double>.FromMetersPerSecond(2));
        }

        [Fact]
        public static void KinematicViscosityTimesDurationEqualsArea()
        {
            var area = KinematicViscosity<double>.FromSquareMetersPerSecond(4)*Duration<double>.FromSeconds(2);
            Assert.Equal(area, Area<double>.FromSquareMeters(8));
        }

        [Fact]
        public static void KinematicViscosityTimesTimeSpanEqualsArea()
        {
            var area = KinematicViscosity<double>.FromSquareMetersPerSecond(4)*TimeSpan.FromSeconds(2);
            Assert.Equal(area, Area<double>.FromSquareMeters(8));
        }

        [Fact]
        public static void TimeSpanTimesKinematicViscosityEqualsArea()
        {
            var area = TimeSpan.FromSeconds(2)*KinematicViscosity<double>.FromSquareMetersPerSecond(4);
            Assert.Equal(area, Area<double>.FromSquareMeters(8));
        }

        [Fact]
        public static void KinematicViscosityTimesDensityEqualsDynamicViscosity()
        {
            var dynamicViscosity = KinematicViscosity<double>.FromSquareMetersPerSecond(10) * Density<double>.FromKilogramsPerCubicMeter(2);
            Assert.Equal(dynamicViscosity, DynamicViscosity<double>.FromNewtonSecondsPerMeterSquared(20));
        }
    }
}
