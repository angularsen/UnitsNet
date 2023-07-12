// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

using Xunit;

namespace UnitsNet.Tests
{
    public class ElectricCurrentTests : ElectricCurrentTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;

        protected override double FemtoamperesInOneAmpere => 1e15;

        protected override double PicoamperesInOneAmpere => 1e12;

        protected override double NanoamperesInOneAmpere => 1e9;

        protected override double MicroamperesInOneAmpere => 1e6;

        protected override double MilliamperesInOneAmpere => 1e3;

        protected override double CentiamperesInOneAmpere => 1e2;

        protected override double AmperesInOneAmpere => 1;

        protected override double KiloamperesInOneAmpere => 1e-3;

        protected override double MegaamperesInOneAmpere => 1e-6;

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(0, int.MaxValue, 0)]
        [InlineData(10, 2, 20)]
        [InlineData(-10, 2, -20)]
        [InlineData(-10, -2, 20)]
        public void ElectricCurrentTimesElectricResistanceEqualsElectricPotential(float current, float resistance, float expected)
        {
            ElectricPotential potential = ElectricCurrent.FromAmperes(current) * ElectricResistance.FromOhms(resistance);
            Assert.Equal(expected, potential.Volts);
        }

        [Fact]
        public void ElectricCurrentMultipliedByElectricPotentialEqualsPower()
        {
            Power p = ElectricCurrent.FromAmperes(2) * ElectricPotential.FromVolts(10);
            Assert.Equal(20, p.Watts);
        }

        [Fact]
        public void ElectricCurrentMultipliedByDurationEqualsElectricCharge()
        {
            ElectricCharge ah = ElectricCurrent.FromAmperes(4) * Duration.FromHours(5);
            Assert.Equal(20, ah.AmpereHours);
        }

        [Fact]
        public void ElectricCurrentDividedByDurationEqualsElectricCurrentGradient()
        {
            ElectricCurrentGradient electricCurrentGradient = ElectricCurrent.FromAmperes(10) / Duration.FromSeconds(2);
            Assert.Equal(ElectricCurrentGradient.FromAmperesPerSecond(5), electricCurrentGradient);
        }

        [Fact]
        public void ElectricCurrentDividedByTimeSpanEqualsElectricCurrentGradient()
        {
            ElectricCurrentGradient electricCurrentGradient = ElectricCurrent.FromAmperes(10) / TimeSpan.FromSeconds(2);
            Assert.Equal(ElectricCurrentGradient.FromAmperesPerSecond(5), electricCurrentGradient);
        }
    }
}
