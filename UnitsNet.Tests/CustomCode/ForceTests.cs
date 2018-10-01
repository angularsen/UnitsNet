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
    public class ForceTests : ForceTestsBase
    {
        protected override double DecanewtonsInOneNewton => 1E-1;
        protected override double DyneInOneNewton => 1E5;

        protected override double KilogramsForceInOneNewton => 0.101972;

        protected override double MeganewtonsInOneNewton => 1E-6;
        protected override double KilonewtonsInOneNewton => 1E-3;

        protected override double KiloPondsInOneNewton => 0.101972;

        protected override double NewtonsInOneNewton => 1;

        protected override double PoundalsInOneNewton => 7.23301;

        protected override double PoundsForceInOneNewton => 0.22481;

        protected override double TonnesForceInOneNewton => 1.019716212977928e-4;

        [Fact]
        public void ForceDividedByAreaEqualsPressure()
        {
            Pressure pressure = Force.FromNewtons(90)/Area.FromSquareMeters(9);
            Assert.Equal(pressure, Pressure.FromNewtonsPerSquareMeter(10));
        }

        [Fact]
        public void PressureByAreaEqualsForce()
        {
            Force force = Force.FromPressureByArea(Pressure.FromNewtonsPerSquareMeter(5), Area.FromSquareMeters(7));
            Assert.Equal(force, Force.FromNewtons(35));
        }

        [Fact]
        public void ForceDividedByMassEqualsAcceleration()
        {
            Acceleration acceleration = Force.FromNewtons(27)/Mass.FromKilograms(9);
            Assert.Equal(acceleration, Acceleration.FromMetersPerSecondSquared(3));
        }

        [Fact]
        public void ForceDividedByAccelerationEqualsMass()
        {
          Mass acceleration = Force.FromNewtons(200)/Acceleration.FromMetersPerSecondSquared(50);
          Assert.Equal(acceleration, Mass.FromKilograms(4));
        }

        [Fact]
        public void ForceDividedByLengthEqualsForcePerLength()
        {
            ForcePerLength forcePerLength = Force.FromNewtons(200) / Length.FromMeters(50);
            Assert.Equal(forcePerLength, ForcePerLength.FromNewtonsPerMeter(4));
        }

        [Fact]
        public void MassByAccelerationEqualsForce()
        {
            Force force = Force.FromMassByAcceleration(Mass.FromKilograms(85), Acceleration.FromMetersPerSecondSquared(-4));
            Assert.Equal(force, Force.FromNewtons(-340));
        }

        [Fact]
        public void ForceTimesSpeedEqualsPower()
        {
            Power power = Force.FromNewtons(27.0)*Speed.FromMetersPerSecond(10.0);
            Assert.Equal(power, Power.FromWatts(270));
        }

        [Fact]
        public void SpeedTimesForceEqualsPower()
        {
            Power power = Speed.FromMetersPerSecond(10.0)*Force.FromNewtons(27.0);
            Assert.Equal(power, Power.FromWatts(270));
        }
    }
}
