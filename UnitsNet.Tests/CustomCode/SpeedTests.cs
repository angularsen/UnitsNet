// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
using System;

namespace UnitsNet.Tests.CustomCode
{
    public class SpeedTests : SpeedTestsBase
    {

        [Test]
        public void SpeedDevidedByTimespanEqualsAcceleration()
        {
            var acceleration = Speed.FromMetersPerSecond(20) / TimeSpan.FromSeconds(2);
            Assert.AreEqual(acceleration, Acceleration.FromMeterPerSecondSquared(10));
        }
        [Test]
        public void SpeedTimesTimespanEqualsLength()
        {
            var length= Speed.FromMetersPerSecond(20) * TimeSpan.FromSeconds(2);
            Assert.AreEqual(length, Length.FromMeters(40));
        }


        protected override double FeetPerSecondInOneMeterPerSecond
        {
            get { return 3.28084; }
        }

        protected override double KilometersPerHourInOneMeterPerSecond
        {
            get { return 3.6; }
        }

        protected override double KnotsInOneMeterPerSecond
        {
            get { return 1.94384; }
        }

        protected override double MetersPerSecondInOneMeterPerSecond
        {
            get { return 1; }
        }

        protected override double MilesPerHourInOneMeterPerSecond
        {
            get { return 2.23694; }
        }

        protected override double NanometersPerSecondInOneMeterPerSecond
        {
            get { return 1E9; }
        }

        protected override double MicrometersPerSecondInOneMeterPerSecond
        {
            get { return 1E6; }
        }

        protected override double MillimetersPerSecondInOneMeterPerSecond
        {
            get { return 1E3; }
        }

        protected override double CentimetersPerSecondInOneMeterPerSecond
        {
            get { return 1E2; }
        }

        protected override double DecimetersPerSecondInOneMeterPerSecond
        {
            get { return 1E1; }
        }

        protected override double KilometersPerSecondInOneMeterPerSecond
        {
            get { return 1E-3; }
        }

        protected override double MetersPerHourInOneMeterPerSecond
        {
            get
            {
                return 3600.0;
            }
        }
    }
}