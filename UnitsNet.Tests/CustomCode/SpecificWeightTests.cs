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
    public class SpecificWeightTests : SpecificWeightTestsBase
    {
        protected override double KilogramsForcePerCubicCentimeterInOneNewtonPerCubicMeter => 1.019716212977928e-7;

        protected override double KilogramsForcePerCubicMeterInOneNewtonPerCubicMeter => 0.101971621;

        protected override double KilogramsForcePerCubicMillimeterInOneNewtonPerCubicMeter => 1.019716212977928e-10;

        protected override double KilonewtonsPerCubicCentimeterInOneNewtonPerCubicMeter => 1e-9;

        protected override double KilonewtonsPerCubicMeterInOneNewtonPerCubicMeter => 1e-3;

        protected override double KilonewtonsPerCubicMillimeterInOneNewtonPerCubicMeter => 1e-12;

        protected override double KilopoundsForcePerCubicFootInOneNewtonPerCubicMeter => 6.365880354264159e-6;

        protected override double KilopoundsForcePerCubicInchInOneNewtonPerCubicMeter => 3.683958538347314e-9;

        protected override double NewtonsPerCubicCentimeterInOneNewtonPerCubicMeter => 1e-6;

        protected override double NewtonsPerCubicMeterInOneNewtonPerCubicMeter => 1;

        protected override double NewtonsPerCubicMillimeterInOneNewtonPerCubicMeter => 1e-9;

        protected override double PoundsForcePerCubicFootInOneNewtonPerCubicMeter => 6.365880354264159e-3;

        protected override double PoundsForcePerCubicInchInOneNewtonPerCubicMeter => 3.683958538347314e-6;

        protected override double TonnesForcePerCubicCentimeterInOneNewtonPerCubicMeter => 1.019716212977928e-10;

        protected override double TonnesForcePerCubicMeterInOneNewtonPerCubicMeter => 1.019716212977928e-4;

        protected override double TonnesForcePerCubicMillimeterInOneNewtonPerCubicMeter => 1.019716212977928e-13;

        protected override double MeganewtonsPerCubicMeterInOneNewtonPerCubicMeter => 1e-6;

        [Fact]
        public void SpecificWeightTimesLengthEqualsPressure()
        {
            Pressure pressure = SpecificWeight.FromNewtonsPerCubicMeter(10) * Length.FromMeters(2);
            Assert.Equal(Pressure.FromPascals(20), pressure);
        }

        [Fact]
        public void SpecificWeightDividedByDensityEqualsAcceleration()
        {
            Acceleration acceleration = SpecificWeight.FromNewtonsPerCubicMeter(40) / Density.FromKilogramsPerCubicMeter(4);
            Assert.Equal(Acceleration.FromMetersPerSecondSquared(10), acceleration);
        }

        [Fact]
        public void SpecificWeightDividedByAccelerationEqualsDensity()
        {
            Density density = SpecificWeight.FromNewtonsPerCubicMeter(20) / Acceleration.FromMetersPerSecondSquared(2);
            Assert.Equal(Density.FromKilogramsPerCubicMeter(10), density);
        }
    }
}
