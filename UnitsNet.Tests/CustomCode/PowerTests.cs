// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class PowerTests : PowerTestsBase
    {
        protected override double FemtowattsInOneWatt => 1e15;

        protected override double PicowattsInOneWatt => 1e12;

        protected override double NanowattsInOneWatt => 1e9;

        protected override double MicrowattsInOneWatt => 1e6;

        protected override double MilliwattsInOneWatt => 1e3;

        protected override double DeciwattsInOneWatt => 1e1;

        protected override double WattsInOneWatt => 1;

        protected override double DecawattsInOneWatt => 1e-1;

        protected override double KilowattsInOneWatt => 1e-3;

        protected override double MegawattsInOneWatt => 1e-6;

        protected override double GigawattsInOneWatt => 1e-9;

        protected override double TerawattsInOneWatt => 1e-12;

        protected override double PetawattsInOneWatt => 1e-15;

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
    }
}
