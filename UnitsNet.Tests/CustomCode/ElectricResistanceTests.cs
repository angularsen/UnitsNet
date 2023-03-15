// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class ElectricResistanceTests : ElectricResistanceTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override double MicroohmsInOneOhm => 1e6;

        protected override double MilliohmsInOneOhm => 1000;

        protected override double OhmsInOneOhm => 1;

        protected override double KiloohmsInOneOhm => 1e-3;

        protected override double MegaohmsInOneOhm => 1e-6;

        protected override double GigaohmsInOneOhm => 1e-9;

        protected override double TeraohmsInOneOhm => 1e-12;

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(0, int.MaxValue, 0)]
        [InlineData(10, 2, 20)]
        [InlineData(-10, 2, -20)]
        [InlineData(-10, -2, 20)]
        public void ElectricResistanceTimesElectricCurrentEqualsElectricPotential(float resistance, float current, float expected)
        {
            ElectricPotential potential = ElectricResistance.FromOhms(resistance) * ElectricCurrent.FromAmperes(current);
            Assert.Equal(expected, potential.Volts);
        }
    }
}
