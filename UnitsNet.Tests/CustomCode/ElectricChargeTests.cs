// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class ElectricChargeTests : ElectricChargeTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override double CoulombsInOneCoulomb => 1;
        protected override double MilliampereHoursInOneCoulomb => 2.77777777777e-1;
        protected override double AmpereHoursInOneCoulomb => 2.77777777777e-4;
        protected override double KiloampereHoursInOneCoulomb => 2.77777777777e-7;
        protected override double MegaampereHoursInOneCoulomb => 2.77777777777e-10;

        protected override double KilocoulombsInOneCoulomb => 1e-3;

        protected override double MegacoulombsInOneCoulomb => 1e-6;

        protected override double MicrocoulombsInOneCoulomb => 1e6;

        protected override double MillicoulombsInOneCoulomb => 1e3;

        protected override double NanocoulombsInOneCoulomb => 1e9;

        protected override double PicocoulombsInOneCoulomb => 1e12;

        [Fact]
        public void ElectricChargeDividedByElectricCurrentEqualsDuration()
        {
            Duration t = ElectricCharge.FromAmpereHours(20) / ElectricCurrent.FromAmperes(5);
            Assert.Equal(4, t.Hours);
        }

        [Fact]
        public void ElectricChargeDividedByDurationEqualsElectricCurrent()
        {
            ElectricCurrent i = ElectricCharge.FromAmpereHours(20) / Duration.FromHours(4);
            Assert.Equal(5, i.Amperes);
        }
        
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(0, int.MaxValue, 0)]
        [InlineData(10, 2, 20)]
        [InlineData(-10, 2, -20)]
        [InlineData(-10, -2, 20)]
        public void ElectricChargeMultipliedByElectricPotentialEqualsEnergy(float current, float potential, float expected)
        {
            Energy j = ElectricCharge.FromCoulombs(current) * ElectricPotential.FromVolts(potential);
            Assert.Equal(expected, j.Joules);
        }
    }
}
