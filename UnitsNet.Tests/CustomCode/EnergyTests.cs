// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class EnergyTests : EnergyTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;
        protected override double ThermsImperialInOneJoule => 9.478171203551087813109937767482e-9;

        protected override double JoulesInOneJoule => 1;

        protected override double KilobritishThermalUnitsInOneJoule => 9.4781712e-7;

        protected override double KilojoulesInOneJoule => 1E-3;

        protected override double MegabritishThermalUnitsInOneJoule => 9.4781712e-10;

        protected override double MegacaloriesInOneJoule => 0.239005736e-6;

        protected override double MegajoulesInOneJoule => 1E-6;

        protected override double TerajoulesInOneJoule => 1E-12;

        protected override double PetajoulesInOneJoule => 1E-15;
        
        protected override double BritishThermalUnitsInOneJoule => 0.00094781712;

        protected override double CaloriesInOneJoule => 0.239005736;

        protected override double DecathermsEcInOneJoule => 9.478171203133172e-10;

        protected override double DecathermsImperialInOneJoule => 9.478171203551087813109937767482e-10;

        protected override double DecathermsUsInOneJoule => 9.480434279733486e-10;

        protected override double ErgsInOneJoule => 10000000;

        protected override double MillijoulesInOneJoule => 1000;

        protected override double MicrojoulesInOneJoule => 1E6;

        protected override double NanojoulesInOneJoule => 1E9;

        protected override double TerawattHoursInOneJoule => 2.77777778e-16;

        protected override double TerawattDaysInOneJoule => 1.157407407407410E-17;

        protected override double ThermsEcInOneJoule => 9.4781712031331720001278504447561e-9;

        protected override double FootPoundsInOneJoule => 0.737562149;

        protected override double GigabritishThermalUnitsInOneJoule => 9.4781712e-13;

        protected override double GigajoulesInOneJoule => 1e-9;

        protected override double GigawattHoursInOneJoule => 2.77777778e-13;

        protected override double GigawattDaysInOneJoule => 1.157407407407410E-14;

        protected override double KilocaloriesInOneJoule => 0.00023900573614;

        protected override double KilowattHoursInOneJoule => 2.77777778e-7;

        protected override double KilowattDaysInOneJoule => 1.157407407407410E-08;

        protected override double MegawattHoursInOneJoule => 2.77777778e-10;

        protected override double MegawattDaysInOneJoule => 1.157407407407410E-11;

        protected override double ThermsUsInOneJoule => 9.4804342797334860315281322406817e-9;

        protected override double WattHoursInOneJoule => 0.000277777778;

        protected override double WattDaysInOneJoule => 1.157407407407410E-05;

        protected override double ElectronVoltsInOneJoule => 6.241509343260179e18;

        protected override double KiloelectronVoltsInOneJoule => 6.2415093433e+15;

        protected override double MegaelectronVoltsInOneJoule => 6.2415093433e+12;

        protected override double GigaelectronVoltsInOneJoule => 6.2415093433e+9;

        protected override double TeraelectronVoltsInOneJoule => 6.2415093433e+6;

        protected override double HorsepowerHoursInOneJoule => 3.725061361111e-7;

        [Fact]
        public void Constructor_UnitSystemSI_AssignsSIUnit()
        {
            var energy = new Energy(1.0, UnitSystem.SI);
            Assert.Equal(EnergyUnit.Joule, energy.Unit);
        }

        [Fact]
        public void As_GivenSIUnitSystem_ReturnsSIValue()
        {
            var btus = new Energy(2.0, EnergyUnit.BritishThermalUnit);
            Assert.Equal(2110.11170524, btus.As(UnitSystem.SI));
        }

        [Fact]
        public void ToUnit_GivenSIUnitSystem_ReturnsSIQuantity()
        {
            var btus = new Energy(2.0, EnergyUnit.BritishThermalUnit);

            var inSI = btus.ToUnit(UnitSystem.SI);

            Assert.Equal(2110.11170524, inSI.Value);
            Assert.Equal(EnergyUnit.Joule, inSI.Unit);
        }

        [Fact]
        public void EnergyDividedByTimeSpanEqualsPower()
        {
            Power p = Energy.FromWattHours(10) / TimeSpan.FromHours(2);
            Assert.Equal(5, p.Watts);
        }

        [Fact]
        public void EnergyDividedByDurationEqualsPower()
        {
            Power p = Energy.FromWattHours(20) / Duration.FromHours(5);
            Assert.Equal(4, p.Watts);
        }

        [Fact]
        public void EnergyDividedByPowerEqualsDuration()
        {
            Duration d = Energy.FromKilowattHours(100) / Power.FromKilowatts(20);
            Assert.Equal(5, d.Hours);
        }

        [Fact]
        public void EnergyDividedByElectricPotentialEqualsElectricCharge()
        {
            ElectricCharge c = Energy.FromJoules(20) / ElectricPotential.FromVolts(5);
            Assert.Equal(4, c.Coulombs);
        }

        [Fact]
        public void EnergyDividedByElectricChargeEqualsElectricPotential()
        {
            ElectricPotential v = Energy.FromJoules(20) / ElectricCharge.FromCoulombs(5);
            Assert.Equal(4, v.Volts);
        }

        [Fact]
        public void EnergyTimesFrequencyEqualsPower()
        {
            Power p = Energy.FromJoules(25) * Frequency.FromPerSecond(5);
            Assert.Equal(125, p.Watts);
        }

        [Fact]
        public void FrequencyTimesEnergyEqualsPower()
        {
            Power p = Frequency.FromCyclesPerHour(100) * Energy.FromWattHours(2);
            Assert.Equal(200, p.Watts);
        }

        [Fact]
        public void EnergyDividedByTemperatureDeltaEqualsEntropy()
        {
            Entropy e = Energy.FromJoules(16) / TemperatureDelta.FromKelvins(8);
            Assert.Equal(Entropy.FromJoulesPerKelvin(2), e);
        }

        [Fact]
        public void EnergyDividedByEntropyEqualsTemperatureDelta()
        {
            TemperatureDelta t = Energy.FromJoules(15) / Entropy.FromJoulesPerKelvin(3);
            Assert.Equal(TemperatureDelta.FromKelvins(5), t);
        }

        [Fact]
        public void EnergyDividedByMassEqualsSpecificEnergy()
        {
            SpecificEnergy e = Energy.FromJoules(10) / Mass.FromKilograms(2);
            Assert.Equal(SpecificEnergy.FromJoulesPerKilogram(5), e);
        }

        [Fact]
        public void EnergyDividedBySpecificEnergyEqualsMass()
        {
            Mass m = Energy.FromJoules(24) / SpecificEnergy.FromJoulesPerKilogram(8);
            Assert.Equal(Mass.FromKilograms(3), m);
        }
    }
}
