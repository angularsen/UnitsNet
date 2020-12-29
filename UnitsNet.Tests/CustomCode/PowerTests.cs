// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class PowerTests : PowerTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override double FemtowattsInOneWatt => 1e15;

        protected override double GigajoulesPerHourInOneWatt => 3600e-9;

        protected override double PicowattsInOneWatt => 1e12;

        protected override double NanowattsInOneWatt => 1e9;

        protected override double MicrowattsInOneWatt => 1e6;

        protected override double MillijoulesPerHourInOneWatt => 3600e3;

        protected override double MilliwattsInOneWatt => 1e3;

        protected override double DeciwattsInOneWatt => 1e1;

        protected override double WattsInOneWatt => 1;

        protected override double DecawattsInOneWatt => 1e-1;

        protected override double KilojoulesPerHourInOneWatt => 3600e-3;

        protected override double KilowattsInOneWatt => 1e-3;

        protected override double MegajoulesPerHourInOneWatt => 3600e-6;

        protected override double MegawattsInOneWatt => 1e-6;

        protected override double GigawattsInOneWatt => 1e-9;

        protected override double TerawattsInOneWatt => 1e-12;

        protected override double PetawattsInOneWatt => 1e-15;

        protected override double JoulesPerHourInOneWatt => 3600;

        protected override double KilobritishThermalUnitsPerHourInOneWatt => 3.412141633e-3;

        protected override double BoilerHorsepowerInOneWatt => 1.0191082802547770700636942675159e-4;

        protected override double BritishThermalUnitsPerHourInOneWatt => 3.412141633;

        protected override double ElectricalHorsepowerInOneWatt => 0.00134048257372654155495978552279;

        protected override double HydraulicHorsepowerInOneWatt => 0.00134102207184949258114167291719;

        protected override double MechanicalHorsepowerInOneWatt => 0.00134103984229371454625916935992;

        protected override double MetricHorsepowerInOneWatt => 0.00135962161730390432342679032425;

        [Fact]
        public void DurationTimesPowerEqualsEnergy()
        {
            var energy = Duration<double>.FromSeconds(8.0) * Power<double>.FromWatts(5.0);
            Assert.Equal(energy, Energy<double>.FromJoules(40.0));
        }

        [Fact]
        public void PowerDividedByRotationalSpeedEqualsForce()
        {
            var torque = Power<double>.FromWatts(15.0) / RotationalSpeed<double>.FromRadiansPerSecond(3);
            Assert.Equal(torque, Torque<double>.FromNewtonMeters(5));
        }

        [Fact]
        public void PowerDividedBySpeedEqualsForce()
        {
            var force = Power<double>.FromWatts(15.0) / Speed<double>.FromMetersPerSecond(3);
            Assert.Equal(force, Force<double>.FromNewtons(5));
        }

        [Fact]
        public void PowerDividedByTorqueEqualsRotationalSpeed()
        {
            var rotationalSpeed = Power<double>.FromWatts(15.0) / Torque<double>.FromNewtonMeters(3);
            Assert.Equal(rotationalSpeed, RotationalSpeed<double>.FromRadiansPerSecond(5));
        }

        [Fact]
        public void PowerTimesDurationEqualsEnergy()
        {
            var energy = Power<double>.FromWatts(5.0) * Duration<double>.FromSeconds(8.0);
            Assert.Equal(energy, Energy<double>.FromJoules(40.0));
        }

        [Fact]
        public void PowerTimesTimeSpanEqualsEnergy()
        {
            var energy = Power<double>.FromWatts(5.0) * TimeSpan.FromSeconds(8.0);
            Assert.Equal(energy, Energy<double>.FromJoules(40.0));
        }

        [Fact]
        public void TimeSpanTimesPowerEqualsEnergy()
        {
            var energy = TimeSpan.FromSeconds(8.0) * Power<double>.FromWatts(5.0);
            Assert.Equal(energy, Energy<double>.FromJoules(40.0));
        }

        [Fact]
        public void PowerTimesBrakeSpecificFuelConsumptionEqualsMassFlow()
        {
            var massFlow = Power<double>.FromKilowatts(20.0 / 24.0 * 1e6 / 180.0) * BrakeSpecificFuelConsumption<double>.FromGramsPerKiloWattHour(180.0);
            AssertEx.EqualTolerance(massFlow.TonnesPerDay, 20.0, 1e-11);
        }

        [Fact]
        public void PowerDividedByMassFlowEqualsSpecificEnergy()
        {
            var specificEnergy = Power<double>.FromWatts(15.0) / MassFlow<double>.FromKilogramsPerSecond(3);
            Assert.Equal(specificEnergy, SpecificEnergy<double>.FromJoulesPerKilogram(5));
        }

        [Fact]
        public void PowerDividedBySpecificEnergyEqualsMassFlow()
        {
            var massFlow = Power<double>.FromWatts(15.0) / SpecificEnergy<double>.FromJoulesPerKilogram(3);
            Assert.Equal(massFlow, MassFlow<double>.FromKilogramsPerSecond(5));
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
