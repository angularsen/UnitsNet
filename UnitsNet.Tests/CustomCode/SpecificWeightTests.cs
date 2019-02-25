// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class SpecificWeightTests : SpecificWeightTestsBase
    {
        protected override double KilogramsForcePerCubicCentimeterInOneNewtonPerCubicMeter => 1.019716212977928e-7;

        protected override double KilogramsForcePerCubicMeterInOneNewtonPerCubicMeter => 0.101971621;

        protected override double KilogramsForcePerCubicMillimeterInOneNewtonPerCubicMeter => 1.019716212977928e-10;

        protected override double KilonewtonsPerCubicCentimeterInOneNewtonPerCubicMeter => 1e-9;

        protected override double KilonewtonsPerCubicMeterInOneNewtonPerCubicMeter => 1e-3;

        protected override double KilonewtonsPerCubicMillimeterInOneNewtonPerCubicMeter => 1e-12;

        protected override double KilopoundsForcePerCubicFootInOneNewtonPerCubicMeter => 6.365880354264159e-6;

        protected override double KilopoundsForcePerCubicInchInOneNewtonPerCubicMeter => 3.683958538347314e-9;

        protected override double NewtonsPerCubicCentimeterInOneNewtonPerCubicMeter => 1e-6;

        protected override double NewtonsPerCubicMeterInOneNewtonPerCubicMeter => 1;

        protected override double NewtonsPerCubicMillimeterInOneNewtonPerCubicMeter => 1e-9;

        protected override double PoundsForcePerCubicFootInOneNewtonPerCubicMeter => 6.365880354264159e-3;

        protected override double PoundsForcePerCubicInchInOneNewtonPerCubicMeter => 3.683958538347314e-6;

        protected override double TonnesForcePerCubicCentimeterInOneNewtonPerCubicMeter => 1.019716212977928e-10;

        protected override double TonnesForcePerCubicMeterInOneNewtonPerCubicMeter => 1.019716212977928e-4;

        protected override double TonnesForcePerCubicMillimeterInOneNewtonPerCubicMeter => 1.019716212977928e-13;

        protected override double MeganewtonsPerCubicMeterInOneNewtonPerCubicMeter => 1e-6;

        [Fact]
        public void SpecificWeightTimesLengthEqualsPressure()
        {
            Pressure pressure = SpecificWeight.FromNewtonsPerCubicMeter(10) * Length.FromMeters(2);
            Assert.Equal(Pressure.FromPascals(20), pressure);
        }

        [Fact]
        public void SpecificWeightDividedByDensityEqualsAcceleration()
        {
            Acceleration acceleration = SpecificWeight.FromNewtonsPerCubicMeter(40) / Density.FromKilogramsPerCubicMeter(4);
            Assert.Equal(Acceleration.FromMetersPerSecondSquared(10), acceleration);
        }

        [Fact]
        public void SpecificWeightDividedByAccelerationEqualsDensity()
        {
            Density density = SpecificWeight.FromNewtonsPerCubicMeter(20) / Acceleration.FromMetersPerSecondSquared(2);
            Assert.Equal(Density.FromKilogramsPerCubicMeter(10), density);
        }
    }
}
