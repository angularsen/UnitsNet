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
    public class KinematicViscosityTests : KinematicViscosityTestsBase
    {
        protected override double CentistokesInOneSquareMeterPerSecond => 1e6;

        protected override double DecistokesInOneSquareMeterPerSecond => 1e5;

        protected override double KilostokesInOneSquareMeterPerSecond => 10;

        protected override double MicrostokesInOneSquareMeterPerSecond => 1e10;

        protected override double MillistokesInOneSquareMeterPerSecond => 1e7;

        protected override double NanostokesInOneSquareMeterPerSecond => 1e13;

        protected override double SquareMetersPerSecondInOneSquareMeterPerSecond => 1;

        protected override double StokesInOneSquareMeterPerSecond => 1e4;

        [Test]
        public static void DurationTimesKinematicViscosityEqualsArea()
        {
            Area area = Duration.FromSeconds(2)*KinematicViscosity.FromSquareMetersPerSecond(4);
            Assert.AreEqual(area, Area.FromSquareMeters(8));
        }

        [Test]
        public static void KinematicViscosityDividedByLengthEqualsSpeed()
        {
            Speed speed = KinematicViscosity.FromSquareMetersPerSecond(4)/Length.FromMeters(2);
            Assert.AreEqual(speed, Speed.FromMetersPerSecond(2));
        }

        [Test]
        public static void KinematicViscosityTimesDurationEqualsArea()
        {
            Area area = KinematicViscosity.FromSquareMetersPerSecond(4)*Duration.FromSeconds(2);
            Assert.AreEqual(area, Area.FromSquareMeters(8));
        }

        [Test]
        public static void KinematicViscosityTimesTimeSpanEqualsArea()
        {
            Area area = KinematicViscosity.FromSquareMetersPerSecond(4)*TimeSpan.FromSeconds(2);
            Assert.AreEqual(area, Area.FromSquareMeters(8));
        }

        [Test]
        public static void TimeSpanTimesKinematicViscosityEqualsArea()
        {
            Area area = TimeSpan.FromSeconds(2)*KinematicViscosity.FromSquareMetersPerSecond(4);
            Assert.AreEqual(area, Area.FromSquareMeters(8));
        }

        [Test]
        public static void KinematicViscosityTimesDensityEqualsDynamicViscosity()
        {
            DynamicViscosity dynamicViscosity = KinematicViscosity.FromSquareMetersPerSecond(10) * Density.FromKilogramsPerCubicMeter(2);
            Assert.AreEqual(dynamicViscosity, DynamicViscosity.FromNewtonSecondsPerMeterSquared(20));
        }
    }
}