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
using System;

namespace UnitsNet.Tests.CustomCode
{
    public class BrakeSpecificFuelConsumptionTests : BrakeSpecificFuelConsumptionTestsBase
    {
        protected override double GramsPerKiloWattHourInOneKilogramPerJoule => 3600000000;

        protected override double KilogramsPerJouleInOneKilogramPerJoule => 1.0;

        protected override double PoundsPerMechanicalHorsepowerHourInOneKilogramPerJoule => 5918352.5016;

        [Fact]
        public void PowerTimesBrakeSpecificFuelConsumptionEqualsMassFlow()
        {
            MassFlow massFlow = BrakeSpecificFuelConsumption.FromGramsPerKiloWattHour(180.0) * Power.FromKilowatts(20.0 / 24.0 * 1e6 / 180.0);
            AssertEx.EqualTolerance(20.0, massFlow.TonnesPerDay, 1e-11);
        }

        [Fact]
        public void DoubleDividedByBrakeSpecificFuelConsumptionEqualsSpecificEnergy()
        {
            SpecificEnergy massFlow = 2.0 / BrakeSpecificFuelConsumption.FromKilogramsPerJoule(4.0);
            Assert.Equal(SpecificEnergy.FromJoulesPerKilogram(0.5), massFlow);
        }

        [Fact]
        public void BrakeSpecificFuelConsumptionTimesSpecificEnergyEqualsEnergy()
        {
            double value = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(20.0) * SpecificEnergy.FromJoulesPerKilogram(10.0);
            Assert.Equal(200.0, value);
        }
    }
}
