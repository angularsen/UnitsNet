// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class SpecificEnergyTests : SpecificEnergyTestsBase
    {
        protected override double JoulesPerKilogramInOneJoulePerKilogram => 1e0;
        protected override double KilojoulesPerKilogramInOneJoulePerKilogram => 1e-3;
        protected override double MegajoulesPerKilogramInOneJoulePerKilogram => 1e-6;
        protected override double BtuPerPoundInOneJoulePerKilogram => 4.299226e-4;
        protected override double CaloriesPerGramInOneJoulePerKilogram => 2.3900573613766730401529636711281e-4;
        protected override double KilocaloriesPerGramInOneJoulePerKilogram => 2.3900573613766730401529636711281e-7;
        protected override double WattHoursPerKilogramInOneJoulePerKilogram => 2.77777778e-4;
        protected override double KilowattHoursPerKilogramInOneJoulePerKilogram => 2.77777778e-7;
        protected override double MegawattHoursPerKilogramInOneJoulePerKilogram => 2.77777778e-10;

        [Fact]
        public void MassTimesSpecificEnergyEqualsEnergy()
        {
            Energy energy = Mass.FromKilograms(20.0)*SpecificEnergy.FromJoulesPerKilogram(10.0);
            Assert.Equal(200d, energy.Joules);
        }

        [Fact]
        public void SpecificEnergyTimesMassEqualsEnergy()
        {
            Energy energy = SpecificEnergy.FromJoulesPerKilogram(10.0)*Mass.FromKilograms(20.0);
            Assert.Equal(200d, energy.Joules);
        }

        [Fact]
        public void DoubleDividedBySpecificEnergyEqualsBrakeSpecificFuelConsumption()
        {
            BrakeSpecificFuelConsumption bsfc = 2.0 / SpecificEnergy.FromJoulesPerKilogram(4.0);
            Assert.Equal(BrakeSpecificFuelConsumption.FromKilogramsPerJoule(0.5), bsfc);
        }

        [Fact]
        public void SpecificEnergyTimesMassFlowEqualsPower()
        {
            Power power = SpecificEnergy.FromJoulesPerKilogram(10.0) * MassFlow.FromKilogramsPerSecond(20.0);
            Assert.Equal(200d, power.Watts);
        }

        [Fact]
        public void SpecificEnergyTimesBrakeSpecificFuelConsumptionEqualsEnergy()
        {
            double value = SpecificEnergy.FromJoulesPerKilogram(10.0) * BrakeSpecificFuelConsumption.FromKilogramsPerJoule(20.0);
            Assert.Equal(200d, value);
        }
    }
}
