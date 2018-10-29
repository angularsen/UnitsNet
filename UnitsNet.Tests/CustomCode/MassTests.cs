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
    public class MassTests : MassTestsBase
    {
        protected override double CentigramsInOneKilogram => 1E5;

        protected override double DecagramsInOneKilogram => 1E2;

        protected override double DecigramsInOneKilogram => 1E4;

        protected override double GramsInOneKilogram => 1E3;

        protected override double HectogramsInOneKilogram => 10;

        protected override double KilogramsInOneKilogram => 1;

        protected override double KilopoundsInOneKilogram => 2.2046226218487757e-3;

        protected override double KilotonnesInOneKilogram => 1E-6;

        protected override double LongTonsInOneKilogram => 9.842065276110606e-4;

        protected override double MegapoundsInOneKilogram => 2.2046226218487757e-6;

        protected override double MegatonnesInOneKilogram => 1E-9;

        protected override double MicrogramsInOneKilogram => 1E9;

        protected override double MilligramsInOneKilogram => 1E6;

        protected override double NanogramsInOneKilogram => 1E12;

        protected override double NanogramsTolerance => 1E-3;

        protected override double OuncesInOneKilogram => 35.2739619;

        protected override double PoundsInOneKilogram => 2.2046226218487757d;

        protected override double ShortTonsInOneKilogram => 1.102311310924388e-3;

        protected override double SlugsInOneKilogram => 6.852176556196105e-2;

        protected override double StoneInOneKilogram => 0.1574731728702698;

        protected override double TonnesInOneKilogram => 1E-3;
        
        protected override double LongHundredweightInOneKilogram => 0.01968413055222121;

        protected override double ShortHundredweightInOneKilogram => 0.022046226218487758;

        [Fact]
        public void AccelerationTimesMassEqualsForce()
        {
            Force force = Acceleration.FromMetersPerSecondSquared(3)*Mass.FromKilograms(18);
            Assert.Equal(force, Force.FromNewtons(54));
        }

        [Fact]
        public void MassDividedByDurationEqualsMassFlow()
        {
            MassFlow massFlow = Mass.FromKilograms(18.0)/Duration.FromSeconds(6);
            Assert.Equal(massFlow, MassFlow.FromKilogramsPerSecond(3.0));
        }

        [Fact]
        public void MassDividedByTimeSpanEqualsMassFlow()
        {
            MassFlow massFlow = Mass.FromKilograms(18.0)/TimeSpan.FromSeconds(6);
            Assert.Equal(massFlow, MassFlow.FromKilogramsPerSecond(3.0));
        }

        [Fact]
        public void MassDividedByVolumeEqualsDensity()
        {
            Density density = Mass.FromKilograms(18)/Volume.FromCubicMeters(3);
            Assert.Equal(density, Density.FromKilogramsPerCubicMeter(6));
        }

        [Fact]
        public void MassTimesAccelerationEqualsForce()
        {
            Force force = Mass.FromKilograms(18)*Acceleration.FromMetersPerSecondSquared(3);
            Assert.Equal(force, Force.FromNewtons(54));
        }
    }
}
