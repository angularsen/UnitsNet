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
            var energy = Mass<double>.FromKilograms(20.0)*SpecificEnergy<double>.FromJoulesPerKilogram(10.0);
            Assert.Equal(200d, energy.Joules);
        }

        [Fact]
        public void SpecificEnergyTimesMassEqualsEnergy()
        {
            var energy = SpecificEnergy<double>.FromJoulesPerKilogram(10.0)*Mass<double>.FromKilograms(20.0);
            Assert.Equal(200d, energy.Joules);
        }

        [Fact]
        public void DoubleDividedBySpecificEnergyEqualsBrakeSpecificFuelConsumption()
        {
            var bsfc = 2.0 / SpecificEnergy<double>.FromJoulesPerKilogram(4.0);
            Assert.Equal(BrakeSpecificFuelConsumption<double>.FromKilogramsPerJoule(0.5), bsfc);
        }

        [Fact]
        public void SpecificEnergyTimesMassFlowEqualsPower()
        {
            var power = SpecificEnergy<double>.FromJoulesPerKilogram(10.0) * MassFlow<double>.FromKilogramsPerSecond(20.0);
            Assert.Equal(200d, power.Watts);
        }

        [Fact]
        public void SpecificEnergyTimesBrakeSpecificFuelConsumptionEqualsEnergy()
        {
            double value = SpecificEnergy<double>.FromJoulesPerKilogram(10.0) * BrakeSpecificFuelConsumption<double>.FromKilogramsPerJoule(20.0);
            Assert.Equal(200d, value);
        }
    }
}
