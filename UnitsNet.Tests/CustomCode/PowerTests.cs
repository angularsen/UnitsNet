// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests
{
    public class PowerTests : PowerTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;
        protected override decimal FemtowattsInOneWatt => 1e15m;

        protected override decimal GigajoulesPerHourInOneWatt => 3600e-9m;

        protected override decimal PicowattsInOneWatt => 1e12m;

        protected override decimal NanowattsInOneWatt => 1e9m;

        protected override decimal MicrowattsInOneWatt => 1e6m;

        protected override decimal MillijoulesPerHourInOneWatt => 3600e3m;

        protected override decimal MilliwattsInOneWatt => 1e3m;

        protected override decimal DeciwattsInOneWatt => 1e1m;

        protected override decimal TonsOfRefrigerationInOneWatt => 2.8434512332474516279184828026648e-4m;
        protected override decimal WattsInOneWatt => 1;

        protected override decimal DecawattsInOneWatt => 1e-1m;

        protected override decimal KilojoulesPerHourInOneWatt => 3600e-3m;

        protected override decimal KilowattsInOneWatt => 1e-3m;

        protected override decimal MegajoulesPerHourInOneWatt => 3600e-6m;

        protected override decimal MegawattsInOneWatt => 1e-6m;

        protected override decimal GigawattsInOneWatt => 1e-9m;

        protected override decimal TerawattsInOneWatt => 1e-12m;

        protected override decimal PetawattsInOneWatt => 1e-15m;

        protected override decimal JoulesPerHourInOneWatt => 3600;

        protected override decimal KilobritishThermalUnitsPerHourInOneWatt => 3.412141633e-3m;

        protected override decimal BoilerHorsepowerInOneWatt => 1.0191082802547770700636942675159e-4m;

        protected override decimal MegabritishThermalUnitsPerHourInOneWatt => 3.412141633e-6m;

        protected override decimal BritishThermalUnitsPerHourInOneWatt => 3.412141633m;

        protected override decimal ElectricalHorsepowerInOneWatt => 0.00134048257372654155495978552279m;

        protected override decimal HydraulicHorsepowerInOneWatt => 0.00134102207184949258114167291719m;

        protected override decimal MechanicalHorsepowerInOneWatt => 0.00134103984229371454625916935992m;

        protected override decimal MetricHorsepowerInOneWatt => 0.00135962161730390432342679032425m;

        [Fact]
        public void DurationTimesPowerEqualsEnergy()
        {
            Energy energy = Duration.FromSeconds(8.0) * Power.FromWatts(5.0);
            Assert.Equal(energy, Energy.FromJoules(40.0));
        }

        [Fact]
        public void PowerDividedByRotationalSpeedEqualsForce()
        {
            Torque torque = Power.FromWatts(15.0) / RotationalSpeed.FromRadiansPerSecond(3);
            Assert.Equal(torque, Torque.FromNewtonMeters(5));
        }

        [Fact]
        public void PowerDividedBySpeedEqualsForce()
        {
            Force force = Power.FromWatts(15.0) / Speed.FromMetersPerSecond(3);
            Assert.Equal(force, Force.FromNewtons(5));
        }

        [Fact]
        public void PowerDividedByTorqueEqualsRotationalSpeed()
        {
            RotationalSpeed rotationalSpeed = Power.FromWatts(15.0) / Torque.FromNewtonMeters(3);
            Assert.Equal(rotationalSpeed, RotationalSpeed.FromRadiansPerSecond(5));
        }

        [Fact]
        public void PowerTimesDurationEqualsEnergy()
        {
            Energy energy = Power.FromWatts(5.0) * Duration.FromSeconds(8.0);
            Assert.Equal(energy, Energy.FromJoules(40.0));
        }

        [Fact]
        public void PowerTimesTimeSpanEqualsEnergy()
        {
            Energy energy = Power.FromWatts(5.0) * TimeSpan.FromSeconds(8.0);
            Assert.Equal(energy, Energy.FromJoules(40.0));
        }

        [Fact]
        public void TimeSpanTimesPowerEqualsEnergy()
        {
            Energy energy = TimeSpan.FromSeconds(8.0) * Power.FromWatts(5.0);
            Assert.Equal(energy, Energy.FromJoules(40.0));
        }

        [Fact]
        public void PowerTimesBrakeSpecificFuelConsumptionEqualsMassFlow()
        {
            MassFlow massFlow = Power.FromKilowatts(20.0 / 24.0 * 1e6 / 180.0) * BrakeSpecificFuelConsumption.FromGramsPerKiloWattHour(180.0);
            AssertEx.EqualTolerance(massFlow.TonnesPerDay, 20.0, 1e-11);
        }

        [Fact]
        public void PowerDividedByMassFlowEqualsSpecificEnergy()
        {
            SpecificEnergy specificEnergy = Power.FromWatts(15.0) / MassFlow.FromKilogramsPerSecond(3);
            Assert.Equal(specificEnergy, SpecificEnergy.FromJoulesPerKilogram(5));
        }

        [Fact]
        public void PowerDividedBySpecificEnergyEqualsMassFlow()
        {
            MassFlow massFlow = Power.FromWatts(15.0) / SpecificEnergy.FromJoulesPerKilogram(3);
            Assert.Equal(massFlow, MassFlow.FromKilogramsPerSecond(5));
        }

        [Fact]
        public void PowerDividedByElectricCurrentEqualsElectricPotential()
        {
            ElectricPotential u = Power.FromWatts(10) / ElectricCurrent.FromAmperes(2);
            Assert.Equal(5, u.Volts);
        }

        [Fact]
        public void PowerDividedByElectricPotentialEqualsElectricCurrent()
        {
            ElectricCurrent i = Power.FromWatts(20) / ElectricPotential.FromVolts(5);
            Assert.Equal(4, i.Amperes);
        }
    }
}
