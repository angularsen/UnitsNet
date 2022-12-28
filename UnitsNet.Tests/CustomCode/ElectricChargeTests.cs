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
    }
}
