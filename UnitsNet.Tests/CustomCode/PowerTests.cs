// Copyright(c) 2007 Andreas Gullberg Larsen
// https://github.com/anjdreas/UnitsNet
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    public class PowerTests : PowerTestsBase
    {
        protected override double FemtowattsInOneWatt => 1e15;

        protected override double PicowattsInOneWatt => 1e12;

        protected override double NanowattsInOneWatt => 1e9;

        protected override double MicrowattsInOneWatt => 1e6;

        protected override double MilliwattsInOneWatt => 1e3;

        protected override double WattsInOneWatt => 1;

        protected override double KilowattsInOneWatt => 1e-3;

        protected override double MegawattsInOneWatt => 1e-6;

        protected override double GigawattsInOneWatt => 1e-9;

        protected override double TerawattsInOneWatt => 1e-12;

        protected override double PetawattsInOneWatt => 1e-15;

        protected override double BoilerHorsepowerInOneWatt => 1.0191082802547770700636942675159e-4;

        protected override double ElectricalHorsepowerInOneWatt => 0.00134048257372654155495978552279;

        protected override double HydraulicHorsepowerInOneWatt => 0.00134102207184949258114167291719;

        protected override double MechanicalHorsepowerInOneWatt => 0.00134103984229371454625916935992;

        protected override double MetricHorsepowerInOneWatt => 0.00135962161730390432342679032425;

        [Test]
        public void DurationTimesPowerEqualsEnergy()
        {
            Energy energy = Duration.FromSeconds(8.0)*Power.FromWatts(5.0);
            Assert.AreEqual(energy, Energy.FromJoules(40.0));
        }

        [Test]
        public void PowerDividedByRotationalSpeedEqualsForce()
        {
            Torque torque = Power.FromWatts(15.0)/RotationalSpeed.FromRadiansPerSecond(3);
            Assert.AreEqual(torque, Torque.FromNewtonMeters(5));
        }

        [Test]
        public void PowerDividedBySpeedEqualsForce()
        {
            Force force = Power.FromWatts(15.0)/Speed.FromMetersPerSecond(3);
            Assert.AreEqual(force, Force.FromNewtons(5));
        }

        [Test]
        public void PowerDividedByTorqueEqualsRotationalSpeed()
        {
            RotationalSpeed rotationalSpeed = Power.FromWatts(15.0)/Torque.FromNewtonMeters(3);
            Assert.AreEqual(rotationalSpeed, RotationalSpeed.FromRadiansPerSecond(5));
        }

        [Test]
        public void PowerTimesDurationEqualsEnergy()
        {
            Energy energy = Power.FromWatts(5.0)*Duration.FromSeconds(8.0);
            Assert.AreEqual(energy, Energy.FromJoules(40.0));
        }

        [Test]
        public void PowerTimesTimeSpanEqualsEnergy()
        {
            Energy energy = Power.FromWatts(5.0)*TimeSpan.FromSeconds(8.0);
            Assert.AreEqual(energy, Energy.FromJoules(40.0));
        }

        [Test]
        public void TimeSpanTimesPowerEqualsEnergy()
        {
            Energy energy = TimeSpan.FromSeconds(8.0)*Power.FromWatts(5.0);
            Assert.AreEqual(energy, Energy.FromJoules(40.0));
        }

        [Test]
        public void PowerTimesBrakeSpecificFuelConsumptionEqualsMassFlow()
        {
            MassFlow massFlow = Power.FromKilowatts(20.0 / 24.0 * 1e6 / 180.0) * BrakeSpecificFuelConsumption.FromGramsPerKiloWattHour(180.0);
            Assert.AreEqual(massFlow.TonnesPerDay, 20.0, 1e-11);
        }

        [Test]
        public void PowerDividedByMassFlowEqualsSpecificEnergy()
        {
            SpecificEnergy specificEnergy = Power.FromWatts(15.0) / MassFlow.FromKilogramsPerSecond(3);
            Assert.AreEqual(specificEnergy, SpecificEnergy.FromJoulesPerKilogram(5));
        }

        [Test]
        public void PowerDividedBySpecificEnergyEqualsMassFlow()
        {
            MassFlow massFlow = Power.FromWatts(15.0) / SpecificEnergy.FromJoulesPerKilogram(3);
            Assert.AreEqual(massFlow, MassFlow.FromKilogramsPerSecond(5));
        }
    }
}