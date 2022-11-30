// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class ForceTests : ForceTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;
        protected override double DecanewtonsInOneNewton => 1E-1;
        protected override double DyneInOneNewton => 1E5;

        protected override double KilogramsForceInOneNewton => 0.101972;

        protected override double KilopoundsForceInOneNewton => 0.22481e-3;
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

        protected override double ShortTonsForceInOneNewton => 1.12404471549816e-4;

        [Fact]
        public void ForceDividedByAreaEqualsPressure()
        {
            Pressure pressure = Force.FromNewtons(90)/Area.FromSquareMeters(9);
            Assert.Equal(10, pressure.NewtonsPerSquareMeter);
        }

        [Fact]
        public void PressureByAreaEqualsForce()
        {
            Force force = Force.FromPressureByArea(Pressure.FromNewtonsPerSquareMeter(5), Area.FromSquareMeters(7));
            Assert.Equal(force, Force.FromNewtons(35));
        }

        [Fact]
        public void ForceDividedByMassEqualsAcceleration()
        {
            Acceleration acceleration = Force.FromNewtons(27)/Mass.FromKilograms(9);
            Assert.Equal(acceleration, Acceleration.FromMetersPerSecondSquared(3));
        }

        [Fact]
        public void ForceDividedByAccelerationEqualsMass()
        {
          Mass acceleration = Force.FromNewtons(200)/Acceleration.FromMetersPerSecondSquared(50);
          Assert.Equal(acceleration, Mass.FromKilograms(4));
        }

        [Fact]
        public void ForceDividedByLengthEqualsForcePerLength()
        {
            ForcePerLength forcePerLength = Force.FromNewtons(200) / Length.FromMeters(50);
            Assert.Equal(forcePerLength, ForcePerLength.FromNewtonsPerMeter(4));
        }

        [Fact]
        public void MassByAccelerationEqualsForce()
        {
            Force force = Force.FromMassByAcceleration(Mass.FromKilograms(85), Acceleration.FromMetersPerSecondSquared(-4));
            Assert.Equal(force, Force.FromNewtons(-340));
        }

        [Fact]
        public void ForceTimesSpeedEqualsPower()
        {
            Power power = Force.FromNewtons(27.0)*Speed.FromMetersPerSecond(10.0);
            Assert.Equal(power, Power.FromWatts(270));
        }

        [Fact]
        public void SpeedTimesForceEqualsPower()
        {
            Power power = Speed.FromMetersPerSecond(10.0)*Force.FromNewtons(27.0);
            Assert.Equal(power, Power.FromWatts(270));
        }

        [Fact]
        public void ForceTimesReciprocalAreaEqualsPressure()
        {
            Pressure pressure = Force.FromNewtons(2) * ReciprocalArea.FromInverseSquareMeters(25);
            Assert.Equal(pressure, Pressure.FromNewtonsPerSquareMeter(50));
        }

        [Fact]
        public void ForceDividedByForceChangeRateEqualsDuration()
        {
            Duration duration = Force.FromNewtons(200) / ForceChangeRate.FromNewtonsPerSecond(50);
            Assert.Equal(duration, Duration.FromSeconds(4));
        }
    }
}
