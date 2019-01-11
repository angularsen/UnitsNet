// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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

using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class SpecificEnergyTests : SpecificEnergyTestsBase
    {
        protected override double JoulesPerKilogramInOneJoulePerKilogram => 1e0;
        protected override double KilojoulesPerKilogramInOneJoulePerKilogram => 1e-3;
        protected override double MegajoulesPerKilogramInOneJoulePerKilogram => 1e-6;
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