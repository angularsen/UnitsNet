// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class JerkTests : JerkTestsBase
    {
        // Override properties in base class here
        protected override double CentimetersPerSecondCubedInOneMeterPerSecondCubed => 1E2;

        protected override double DecimetersPerSecondCubedInOneMeterPerSecondCubed => 1E1;

        protected override double FeetPerSecondCubedInOneMeterPerSecondCubed => 3.28084;

        protected override double InchesPerSecondCubedInOneMeterPerSecondCubed => 39.3700787;

        protected override double KilometersPerSecondCubedInOneMeterPerSecondCubed => 1E-3;

        protected override double MetersPerSecondCubedInOneMeterPerSecondCubed => 1;

        protected override double MicrometersPerSecondCubedInOneMeterPerSecondCubed => 1E6;

        protected override double MillimetersPerSecondCubedInOneMeterPerSecondCubed => 1E3;

        protected override double MillistandardGravitiesPerSecondInOneMeterPerSecondCubed => 101.9716212977928;

        protected override double NanometersPerSecondCubedInOneMeterPerSecondCubed => 1E9;

        protected override double StandardGravitiesPerSecondInOneMeterPerSecondCubed => 1.019716212977928e-1;

        protected override bool SupportsSIUnitSystem => true;

        [Fact]
        public void AccelerationDividedByDurationEqualsJerk()
        {
            Jerk jerk = Acceleration.FromMetersPerSecondSquared(10) / Duration.FromSeconds(2);

            Assert.Equal(Jerk.FromMetersPerSecondCubed(5), jerk);
        }
    }
}
