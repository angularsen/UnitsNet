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
            Area area = Duration.FromSeconds(2)*KinematicViscosity.FromSquareMetersPerSecond(4);
            Assert.Equal(area, Area.FromSquareMeters(8));
        }

        [Fact]
        public static void KinematicViscosityDividedByLengthEqualsSpeed()
        {
            Speed speed = KinematicViscosity.FromSquareMetersPerSecond(4)/Length.FromMeters(2);
            Assert.Equal(speed, Speed.FromMetersPerSecond(2));
        }

        [Fact]
        public static void KinematicViscosityTimesDurationEqualsArea()
        {
            Area area = KinematicViscosity.FromSquareMetersPerSecond(4)*Duration.FromSeconds(2);
            Assert.Equal(area, Area.FromSquareMeters(8));
        }

        [Fact]
        public static void KinematicViscosityTimesTimeSpanEqualsArea()
        {
            Area area = KinematicViscosity.FromSquareMetersPerSecond(4)*TimeSpan.FromSeconds(2);
            Assert.Equal(area, Area.FromSquareMeters(8));
        }

        [Fact]
        public static void TimeSpanTimesKinematicViscosityEqualsArea()
        {
            Area area = TimeSpan.FromSeconds(2)*KinematicViscosity.FromSquareMetersPerSecond(4);
            Assert.Equal(area, Area.FromSquareMeters(8));
        }

        [Fact]
        public static void KinematicViscosityTimesDensityEqualsDynamicViscosity()
        {
            DynamicViscosity dynamicViscosity = KinematicViscosity.FromSquareMetersPerSecond(10) * Density.FromKilogramsPerCubicMeter(2);
            Assert.Equal(dynamicViscosity, DynamicViscosity.FromNewtonSecondsPerMeterSquared(20));
        }
    }
}
