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
    public class AccelerationTests : AccelerationTestsBase
    {
        protected override double KilometersPerSecondSquaredInOneMeterPerSecondSquared => 1E-3;

        protected override double MetersPerSecondSquaredInOneMeterPerSecondSquared => 1;

        protected override double DecimetersPerSecondSquaredInOneMeterPerSecondSquared => 1E1;

        protected override double CentimetersPerSecondSquaredInOneMeterPerSecondSquared => 1E2;

        protected override double MillimetersPerSecondSquaredInOneMeterPerSecondSquared => 1E3;

        protected override double MicrometersPerSecondSquaredInOneMeterPerSecondSquared => 1E6;

        protected override double NanometersPerSecondSquaredInOneMeterPerSecondSquared => 1E9;

        protected override double StandardGravityInOneMeterPerSecondSquared => 1.019716212977928e-1;

        protected override double InchesPerSecondSquaredInOneMeterPerSecondSquared => 39.3700787;

        protected override double FeetPerSecondSquaredInOneMeterPerSecondSquared => 3.28084;

        protected override double KnotsPerHourInOneMeterPerSecondSquared => 6.99784017278618E3;

        protected override double KnotsPerMinuteInOneMeterPerSecondSquared => 1.16630669546436E2;

        protected override double KnotsPerSecondInOneMeterPerSecondSquared => 1.94384449244060;

        [Fact]
        public void AccelerationTimesDensityEqualsSpecificWeight()
        {
            SpecificWeight specificWeight = Acceleration.FromMetersPerSecondSquared(10) * Density.FromKilogramsPerCubicMeter(2);
            Assert.Equal(SpecificWeight.FromNewtonsPerCubicMeter(20), specificWeight);
        }
    }
}
