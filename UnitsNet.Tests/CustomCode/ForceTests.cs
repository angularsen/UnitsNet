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
    public class ForceTests : ForceTestsBase
    {
        protected override double DyneInOneNewton => 1E5;

        protected override double KilogramsForceInOneNewton => 1/Constants.Gravity;

        protected override double KilonewtonsInOneNewton => 1E-3;

        protected override double KiloPondsInOneNewton => 1/Constants.Gravity;

        protected override double NewtonsInOneNewton => 1;

        protected override double PoundalsInOneNewton => 7.23301;

        protected override double PoundsForceInOneNewton => 0.22481;

        protected override double TonnesForceInOneNewton => 1.02e-4;

        [Test]
        public void ForceDividedByAreaEqualsPressure()
        {
            Pressure pressure = Force.FromNewtons(81)/Area.FromSquareMeters(9);
            Assert.AreEqual(pressure, Pressure.FromNewtonsPerSquareMeter(9));
        }

        [Test]
        public void ForceDividedByMassEqualsAcceleration()
        {
            Acceleration acceleration = Force.FromNewtons(27)/Mass.FromKilograms(9);
            Assert.AreEqual(acceleration, Acceleration.FromMeterPerSecondSquared(3));
        }

        [Test]
        public void ForceTimesSpeedEqualsPower()
        {
            Power power = Force.FromNewtons(27.0)*Speed.FromMetersPerSecond(10.0);
            Assert.AreEqual(power, Power.FromWatts(270));
        }

        [Test]
        public void SpeedTimesForceEqualsPower()
        {
            Power power = Speed.FromMetersPerSecond(10.0)*Force.FromNewtons(27.0);
            Assert.AreEqual(power, Power.FromWatts(270));
        }
    }
}