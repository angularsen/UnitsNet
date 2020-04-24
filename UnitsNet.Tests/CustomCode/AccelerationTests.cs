// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class AccelerationTests : AccelerationTestsBase
    {
        protected override double KilometersPerSecondSquaredInOneMeterPerSecondSquared => 1E-3;

        protected override double MetersPerSecondSquaredInOneMeterPerSecondSquared => 1;

        protected override double DecimetersPerSecondSquaredInOneMeterPerSecondSquared => 1E1;

        protected override double CentimetersPerSecondSquaredInOneMeterPerSecondSquared => 1E2;

        protected override double MillimetersPerSecondSquaredInOneMeterPerSecondSquared => 1E3;

        protected override double MicrometersPerSecondSquaredInOneMeterPerSecondSquared => 1E6;

        protected override double NanometersPerSecondSquaredInOneMeterPerSecondSquared => 1E9;

        protected override double StandardGravityInOneMeterPerSecondSquared => 1.019716212977928e-1;

        protected override double InchesPerSecondSquaredInOneMeterPerSecondSquared => 39.3700787;

        protected override double FeetPerSecondSquaredInOneMeterPerSecondSquared => 3.28084;

        protected override double KnotsPerHourInOneMeterPerSecondSquared => 6.99784017278618E3;

        protected override double KnotsPerMinuteInOneMeterPerSecondSquared => 1.16630669546436E2;

        protected override double KnotsPerSecondInOneMeterPerSecondSquared => 1.94384449244060;

        [Fact]
        public void AccelerationTimesDensityEqualsSpecificWeight()
        {
            SpecificWeight specificWeight = Acceleration.FromMetersPerSecondSquared(10) * Density.FromKilogramsPerCubicMeter(2);
            Assert.Equal(SpecificWeight.FromNewtonsPerCubicMeter(20), specificWeight);
        }
    }
}
