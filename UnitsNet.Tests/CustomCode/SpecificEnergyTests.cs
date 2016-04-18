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

using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    public class SpecificEnergyTests : SpecificEnergyTestsBase
    {
        protected override double JoulesPerKilogramInOneJoulePerKilogram => 1.0;

        protected override double CaloriesPerGramInOneJoulePerKilogram => 1.0/4.184E3;

        protected override double KilocaloriesPerGramInOneJoulePerKilogram => 1.0/4.184E6;


        protected override double KilojoulesPerKilogramInOneJoulePerKilogram => 1.0E-3;

        protected override double KilowattHoursPerKilogramInOneJoulePerKilogram => 2.77777778e-7;

        protected override double MegajoulesPerKilogramInOneJoulePerKilogram => 1.0E-6;

        protected override double MegawattHoursPerKilogramInOneJoulePerKilogram => 2.77777778E-10;

        protected override double WattHoursPerKilogramInOneJoulePerKilogram => 1.0/3.6e3;

        [Test]
        public void MassTimesSpecificEnergyEqualsEnergy()
        {
            Energy energy = Mass.FromKilograms(20.0)*SpecificEnergy.FromJoulesPerKilogram(10.0);
            Assert.AreEqual(energy, Energy.FromJoules(200.0));
        }

        [Test]
        public void SpecificEnergyTimesMassEqualsEnergy()
        {
            Energy energy = SpecificEnergy.FromJoulesPerKilogram(10.0)*Mass.FromKilograms(20.0);
            Assert.AreEqual(energy, Energy.FromJoules(200.0));
        }

        [Test]
        public void DoubleDividedBySpecificEnergyEqualsBrakeSpecificFuelConsumption()
        {
            BrakeSpecificFuelConsumption bsfc = 2.0 / SpecificEnergy.FromJoulesPerKilogram(4.0);
            Assert.AreEqual(BrakeSpecificFuelConsumption.FromKilogramsPerJoule(0.5), bsfc);
        }

        [Test]
        public void SpecificEnergyTimesMassFlowEqualsPower()
        {
            Power power = SpecificEnergy.FromJoulesPerKilogram(10.0) * MassFlow.FromKilogramsPerSecond(20.0);
            Assert.AreEqual(power, Power.FromWatts(200.0));
        }

        [Test]
        public void SpecificEnergyTimesBrakeSpecificFuelConsumptionEqualsEnergy()
        {
            double value = SpecificEnergy.FromJoulesPerKilogram(10.0) * BrakeSpecificFuelConsumption.FromKilogramsPerJoule(20.0);
            Assert.AreEqual(value, 200.0);
        }
    }
}