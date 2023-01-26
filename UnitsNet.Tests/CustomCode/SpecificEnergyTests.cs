// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class SpecificEnergyTests : SpecificEnergyTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override double JoulesPerKilogramInOneJoulePerKilogram => 1e0;
        protected override double KilojoulesPerKilogramInOneJoulePerKilogram => 1e-3;
        protected override double MegajoulesPerKilogramInOneJoulePerKilogram => 1e-6;
        protected override double MegaJoulesPerTonneInOneJoulePerKilogram => 1e-3;

        protected override double BtuPerPoundInOneJoulePerKilogram => 4.299226e-4;

        protected override double CaloriesPerGramInOneJoulePerKilogram => 2.3900573613766730401529636711281e-4;
        protected override double KilocaloriesPerGramInOneJoulePerKilogram => 2.3900573613766730401529636711281e-7;

        protected override double WattHoursPerKilogramInOneJoulePerKilogram => 2.77777778e-4;
        protected override double KilowattHoursPerKilogramInOneJoulePerKilogram => 2.77777778e-7;
        protected override double MegawattHoursPerKilogramInOneJoulePerKilogram => 2.77777778e-10;
        protected override double GigawattHoursPerKilogramInOneJoulePerKilogram => 2.77777778e-13;

        protected override double WattHoursPerPoundInOneJoulePerKilogram => 1.2599788055556e-4;
        protected override double KilowattHoursPerPoundInOneJoulePerKilogram => 1.2599788055556e-7;
        protected override double MegawattHoursPerPoundInOneJoulePerKilogram => 1.2599788055556e-10;
        protected override double GigawattHoursPerPoundInOneJoulePerKilogram => 1.2599788055556e-13;

        protected override double WattDaysPerKilogramInOneJoulePerKilogram => 1.15740741E-5;
        protected override double KilowattDaysPerKilogramInOneJoulePerKilogram => 1.15740741E-8;
        protected override double MegawattDaysPerKilogramInOneJoulePerKilogram => 1.15740741E-11;
        protected override double GigawattDaysPerKilogramInOneJoulePerKilogram => 1.15740741E-14;
        protected override double TerawattDaysPerKilogramInOneJoulePerKilogram => 1.15740741E-17;

        protected override double WattDaysPerShortTonInOneJoulePerKilogram => 1.04998234E-2;
        protected override double KilowattDaysPerShortTonInOneJoulePerKilogram => 1.04998234E-5;
        protected override double MegawattDaysPerShortTonInOneJoulePerKilogram => 1.04998234E-8;
        protected override double GigawattDaysPerShortTonInOneJoulePerKilogram => 1.04998234E-11;
        protected override double TerawattDaysPerShortTonInOneJoulePerKilogram => 1.04998234E-14;

        protected override double WattDaysPerTonneInOneJoulePerKilogram => 1.15740741E-2;
        protected override double KilowattDaysPerTonneInOneJoulePerKilogram => 1.15740741E-5;
        protected override double MegawattDaysPerTonneInOneJoulePerKilogram => 1.15740741E-8;
        protected override double GigawattDaysPerTonneInOneJoulePerKilogram => 1.15740741E-11;
        protected override double TerawattDaysPerTonneInOneJoulePerKilogram => 1.15740741E-14;

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
            Assert.Equal(200m, power.Watts);
        }

        [Fact]
        public void SpecificEnergyTimesBrakeSpecificFuelConsumptionEqualsEnergy()
        {
            double value = SpecificEnergy.FromJoulesPerKilogram(10.0) * BrakeSpecificFuelConsumption.FromKilogramsPerJoule(20.0);
            Assert.Equal(200d, value);
        }

        [Fact]
        public void SpecificEnergyDividedByTemperatureDeltaEqualsSpecificEntropy()
        {
            SpecificEntropy specificEntropy = SpecificEnergy.FromJoulesPerKilogram(4) / TemperatureDelta.FromKelvins(0.5);
            Assert.Equal(SpecificEntropy.FromJoulesPerKilogramKelvin(8), specificEntropy);
        }
    }
}
