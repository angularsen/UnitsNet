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

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class MassFlowTests : MassFlowTestsBase
    {
        protected override double GramsPerSecondInOneGramPerSecond => 1;

        protected override double DecagramsPerSecondInOneGramPerSecond => 1E-1;

        protected override double HectogramsPerSecondInOneGramPerSecond => 1E-2;

        protected override double KilogramsPerHourInOneGramPerSecond => 3.6;

        protected override double TonnesPerHourInOneGramPerSecond => 3.6E-3;

        protected override double KilogramsPerSecondInOneGramPerSecond => 1E-3;

        protected override double MegapoundsPerHourInOneGramPerSecond => 7.93664e-6;

        protected override double DecigramsPerSecondInOneGramPerSecond => 1E1;

        protected override double CentigramsPerSecondInOneGramPerSecond => 1E2;

        protected override double MilligramsPerSecondInOneGramPerSecond => 1E3;

        protected override double MicrogramsPerSecondInOneGramPerSecond => 1E6;

        protected override double NanogramsPerSecondInOneGramPerSecond => 1E9;

        protected override double ShortTonsPerHourInOneGramPerSecond => 3.96832e-3;

        protected override double TonnesPerDayInOneGramPerSecond => 60.0*60*24/1E6;

        protected override double PoundsPerHourInOneGramPerSecond => 7.93664;

        protected override double PoundsPerMinuteInOneGramPerSecond => 0.132277;

        protected override double MegapoundsPerMinuteInOneGramPerSecond => 0.132277e-6;

        protected override double KilogramsPerMinuteInOneGramPerSecond => 0.01666667e-3;

        [Fact]
        public void DurationTimesMassFlowEqualsMass()
        {
            Mass mass = Duration.FromSeconds(4.0)*MassFlow.FromKilogramsPerSecond(20.0);
            Assert.Equal(mass, Mass.FromKilograms(80.0));
        }

        [Fact]
        public void MassFlowTimesDurationEqualsMass()
        {
            Mass mass = MassFlow.FromKilogramsPerSecond(20.0)*Duration.FromSeconds(4.0);
            Assert.Equal(mass, Mass.FromKilograms(80.0));
        }

        [Fact]
        public void MassFlowTimesTimeSpanEqualsMass()
        {
            Mass mass = MassFlow.FromKilogramsPerSecond(20.0)*TimeSpan.FromSeconds(4.0);
            Assert.Equal(mass, Mass.FromKilograms(80.0));
        }

        [Fact]
        public void TimeSpanTimesMassFlowEqualsMass()
        {
            Mass mass = TimeSpan.FromSeconds(4.0)*MassFlow.FromKilogramsPerSecond(20.0);
            Assert.Equal(mass, Mass.FromKilograms(80.0));
        }

        [Fact]
        public void MassFlowDividedByBrakeSpecificFuelConsumptionEqualsPower()
        {
            Power power = MassFlow.FromTonnesPerDay(20) / BrakeSpecificFuelConsumption.FromGramsPerKiloWattHour(180.0);
            Assert.Equal(20.0 / 24.0 * 1e6 / 180.0, power.Kilowatts);
        }

        [Fact]
        public void MassFlowDividedByPowerEqualsBrakeSpecificFuelConsumption()
        {
            BrakeSpecificFuelConsumption bsfc = MassFlow.FromTonnesPerDay(20) / Power.FromKilowatts(20.0 / 24.0 * 1e6 / 180.0);
            AssertEx.EqualTolerance(180.0, bsfc.GramsPerKiloWattHour, 1e-11);
        }

        [Fact]
        public void MassFlowTimesSpecificEnergyEqualsPower()
        {
            Power power = MassFlow.FromKilogramsPerSecond(20.0) * SpecificEnergy.FromJoulesPerKilogram(10.0);
            Assert.Equal(200, power.Watts);
        }

        [Fact]
        public void MassFlowDividedByAreaEqualsMassFlux()
        {
            MassFlux massFlux = MassFlow.FromKilogramsPerSecond(20) / Area.FromSquareMeters(2);
            Assert.Equal(10, massFlux.KilogramsPerSecondPerSquareMeter);
        }

        [Fact]
        public void MassFlowDividedByMassFluxEqualsArea()
        {
            Area area = MassFlow.FromKilogramsPerSecond(20) / MassFlux.FromKilogramsPerSecondPerSquareMeter(2);
            Assert.Equal(10, area.SquareMeters);
        }

        [Fact]
        public void MassFlowDividedByVolumeFlowEqualsDensity()
        {
            Density density = MassFlow.FromKilogramsPerSecond(12) / VolumeFlow.FromCubicMetersPerSecond(3);
            Assert.Equal(4, density.KilogramsPerCubicMeter);
        }

        [Fact]
        public void MassFlowDividedByDensityEqualsVolumeFlow()
        {
            VolumeFlow volumeFlow = MassFlow.FromKilogramsPerSecond(20) / Density.FromKilogramsPerCubicMeter(4);
            Assert.Equal(5, volumeFlow.CubicMetersPerSecond);
        }
    }
}
