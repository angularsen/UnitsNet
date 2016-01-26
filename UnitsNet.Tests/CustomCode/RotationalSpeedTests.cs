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

namespace UnitsNet.Tests.CustomCode
{

    public class RotationalSpeedTests : RotationalSpeedTestsBase
    {
        [Test]
        public void RotationalSpeedTimesTimeSpanEqualsAngle()
        {
            var angle = RotationalSpeed.FromRadiansPerSecond(10.0) * TimeSpan.FromSeconds(9.0);
            Assert.AreEqual(angle, Angle.FromRadians(90.0));
        }

        [Test]
        public void TimeSpanTimesRotationalSpeedEqualsAngle()
        {
            var angle = TimeSpan.FromSeconds(9.0) * RotationalSpeed.FromRadiansPerSecond(10.0) ;
            Assert.AreEqual(angle, Angle.FromRadians(90.0));
        }

        [Test]
        public void RotationalSpeedTimesDurationEqualsAngle()
        {
            var angle = RotationalSpeed.FromRadiansPerSecond(10.0) * Duration.FromSeconds(9.0);
            Assert.AreEqual(angle, Angle.FromRadians(90.0));
        }

        [Test]
        public void DurationTimesRotationalSpeedEqualsAngle()
        {
            var angle = Duration.FromSeconds(9.0) * RotationalSpeed.FromRadiansPerSecond(10.0);
            Assert.AreEqual(angle, Angle.FromRadians(90.0));
        }

        [Test]
        public void RotationalSpeedTimesForceEqualsPower()
        {
            var power = RotationalSpeed.FromRadiansPerSecond(10.0) * Force.FromNewtons(2.0);
            Assert.AreEqual(power, Power.FromWatts(20.0));
        }

        [Test]
        public void ForceTimesRotationalSpeedEqualsPower()
        {
            var power = Force.FromNewtons(2.0) * RotationalSpeed.FromRadiansPerSecond(10.0) ;
            Assert.AreEqual(power, Power.FromWatts(20.0));
        }

        protected override double RadiansPerSecondInOneRadianPerSecond
        {
            get { return 1; }
        }

        protected override double DeciradiansPerSecondInOneRadianPerSecond
            {
            get { return 1E1; }
            }

        protected override double CentiradiansPerSecondInOneRadianPerSecond
        {
            get { return 1E2; }
        }

        protected override double MilliradiansPerSecondInOneRadianPerSecond
        {
            get { return 1E3; }
        }

        protected override double MicroradiansPerSecondInOneRadianPerSecond
        {
            get { return 1E6; }
        }

        protected override double NanoradiansPerSecondInOneRadianPerSecond
        {
            get { return 1E9; }
    }

        protected override double RevolutionsPerMinuteInOneRadianPerSecond
        {
            get { return (60*1) / (2 * Math.PI); }
        }

        protected override double RevolutionsPerSecondInOneRadianPerSecond
        {
            get { return 1/(2*Math.PI); }
        }
    }
}