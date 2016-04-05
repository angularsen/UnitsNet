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

using System;
using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    public class RotationalSpeedTests : RotationalSpeedTestsBase
    {
        protected override double RadiansPerSecondInOneRadianPerSecond => 1;

        protected override double DeciradiansPerSecondInOneRadianPerSecond => 1E1;

        protected override double CentiradiansPerSecondInOneRadianPerSecond => 1E2;

        protected override double MilliradiansPerSecondInOneRadianPerSecond => 1E3;

        protected override double MicroradiansPerSecondInOneRadianPerSecond => 1E6;

        protected override double NanoradiansPerSecondInOneRadianPerSecond => 1E9;

        protected override double RevolutionsPerMinuteInOneRadianPerSecond => 9.54929659;

        protected override double RevolutionsPerSecondInOneRadianPerSecond => 0.15915494;

        protected override double DegreesPerSecondInOneRadianPerSecond => 57.29577951308;

        protected override double MillidegreesPerSecondInOneRadianPerSecond => 57295.77951308;

        protected override double MicrodegreesPerSecondInOneRadianPerSecond => 57295779.51308232;

        protected override double NanodegreesPerSecondInOneRadianPerSecond => 57295779513.08232087;

        protected override double DegreesPerMinuteInOneRadianPerSecond => 3437.74677;

        [Test]
        public void DurationTimesRotationalSpeedEqualsAngle()
        {
            Angle angle = Duration.FromSeconds(9.0)*RotationalSpeed.FromRadiansPerSecond(10.0);
            Assert.AreEqual(angle, Angle.FromRadians(90.0));
        }

        [Test]
        public void RotationalSpeedTimesDurationEqualsAngle()
        {
            Angle angle = RotationalSpeed.FromRadiansPerSecond(10.0)*Duration.FromSeconds(9.0);
            Assert.AreEqual(angle, Angle.FromRadians(90.0));
        }

        [Test]
        public void RotationalSpeedTimesTimeSpanEqualsAngle()
        {
            Angle angle = RotationalSpeed.FromRadiansPerSecond(10.0)*TimeSpan.FromSeconds(9.0);
            Assert.AreEqual(angle, Angle.FromRadians(90.0));
        }

        [Test]
        public void TimeSpanTimesRotationalSpeedEqualsAngle()
        {
            Angle angle = TimeSpan.FromSeconds(9.0)*RotationalSpeed.FromRadiansPerSecond(10.0);
            Assert.AreEqual(angle, Angle.FromRadians(90.0));
        }
    }
}