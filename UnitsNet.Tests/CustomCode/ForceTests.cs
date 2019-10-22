// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class ForceTests : ForceTestsBase
    {
        protected override double DecanewtonsInOneNewton => 1E-1;
        protected override double DyneInOneNewton => 1E5;

        protected override double KilogramsForceInOneNewton => 0.101972;

        protected override double MeganewtonsInOneNewton => 1E-6;
        protected override double KilonewtonsInOneNewton => 1E-3;

        protected override double KiloPondsInOneNewton => 0.101972;

        protected override double NewtonsInOneNewton => 1;

        protected override double PoundalsInOneNewton => 7.23301;

        protected override double PoundsForceInOneNewton => 0.22481;

        protected override double TonnesForceInOneNewton => 1.019716212977928e-4;

        protected override double MillinewtonsInOneNewton => 1.0e3;

        protected override double MicronewtonsInOneNewton => 1.0e6;

        protected override double OunceForceInOneNewton => 3.596943089595368;

        [Fact]
        public void ForceDividedByAreaEqualsPressure()
        {
            var pressure = Force<double>.FromNewtons(90)/Area<double>.FromSquareMeters(9);
            Assert.Equal(pressure, Pressure<double>.FromNewtonsPerSquareMeter(10));
        }

        [Fact]
        public void PressureByAreaEqualsForce()
        {
            var force = Force<double>.FromPressureByArea(Pressure<double>.FromNewtonsPerSquareMeter(5), Area<double>.FromSquareMeters(7));
            Assert.Equal(force, Force<double>.FromNewtons(35));
        }

        [Fact]
        public void ForceDividedByMassEqualsAcceleration()
        {
            var acceleration = Force<double>.FromNewtons(27)/Mass<double>.FromKilograms(9);
            Assert.Equal(acceleration, Acceleration<double>.FromMetersPerSecondSquared(3));
        }

        [Fact]
        public void ForceDividedByAccelerationEqualsMass()
        {
          var mass = Force<double>.FromNewtons(200)/Acceleration<double>.FromMetersPerSecondSquared(50);
          Assert.Equal(mass, Mass<double>.FromKilograms(4));
        }

        [Fact]
        public void ForceDividedByLengthEqualsForcePerLength()
        {
            var forcePerLength = Force<double>.FromNewtons(200) / Length<double>.FromMeters(50);
            Assert.Equal(forcePerLength, ForcePerLength<double>.FromNewtonsPerMeter(4));
        }

        [Fact]
        public void MassByAccelerationEqualsForce()
        {
            var force = Force<double>.FromMassByAcceleration(Mass<double>.FromKilograms(85), Acceleration<double>.FromMetersPerSecondSquared(-4));
            Assert.Equal(force, Force<double>.FromNewtons(-340));
        }

        [Fact]
        public void ForceTimesSpeedEqualsPower()
        {
            var power = Force<double>.FromNewtons(27.0)*Speed<double>.FromMetersPerSecond(10.0);
            Assert.Equal(power, Power<double>.FromWatts(270));
        }

        [Fact]
        public void SpeedTimesForceEqualsPower()
        {
            var power = Speed<double>.FromMetersPerSecond(10.0)*Force<double>.FromNewtons(27.0);
            Assert.Equal(power, Power<double>.FromWatts(270));
        }
    }
}
