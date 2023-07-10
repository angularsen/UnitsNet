// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class ElectricPotentialTests : ElectricPotentialTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;
        protected override double MicrovoltsInOneVolt => 1e6;

        protected override double MillivoltsInOneVolt => 1e3;

        protected override double VoltsInOneVolt => 1;

        protected override double KilovoltsInOneVolt => 1e-3;

        protected override double MegavoltsInOneVolt => 1e-6;

        protected override double NanovoltsInOneVolt => 1e9;

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(0, int.MaxValue, 0)]
        [InlineData(10, 2, 5)]
        [InlineData(-10, 2, -5)]
        [InlineData(-10, -2, 5)]
        public void ElectricPotentialDividedByElectricCurrentEqualsElectricResistance(float potential, float current, float expected)
        {
            ElectricResistance resistance = ElectricPotential.FromVolts(potential) / ElectricCurrent.FromAmperes(current);
            Assert.Equal(expected, resistance.Ohms);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(0, int.MaxValue, 0)]
        [InlineData(10, 2, 5)]
        [InlineData(-10, 2, -5)]
        [InlineData(-10, -2, 5)]
        public void ElectricPotentialDividedByElectricResistanceEqualsElectricCurrent(float potential, float resistance, float expected)
        {
            ElectricCurrent current = ElectricPotential.FromVolts(potential) / ElectricResistance.FromOhms(resistance);
            Assert.Equal(expected, current.Amperes);
        }

        [Fact]
        public void ElectricPotentialMultipliedByElectricCurrentEqualsPower()
        {
            Power p = ElectricPotential.FromVolts(10) * ElectricCurrent.FromAmperes(2);
            Assert.Equal(20, p.Watts);
        }
        
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(0, int.MaxValue, 0)]
        [InlineData(10, 2, 20)]
        [InlineData(-10, 2, -20)]
        [InlineData(-10, -2, 20)]
        public void ElectricPotentialMultipliedByElectricChargeEqualsEnergy(float potential, float current, float expected)
        {
            Energy j = ElectricPotential.FromVolts(potential) * ElectricCharge.FromCoulombs(current);
            Assert.Equal(expected, j.Joules);
        }
    }
}
