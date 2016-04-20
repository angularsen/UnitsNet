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
using UnitsNet.CustomCode.Extensions;

namespace UnitsNet.Tests.CustomCode
{
    public class PowerRatioTests : PowerRatioTestsBase
    {
        protected override double DecibelMilliwattsInOneDecibelWatt => 31;

        protected override double DecibelWattsInOneDecibelWatt => 1;

        protected override void AssertLogarithmicAddition()
        {
            PowerRatio v = PowerRatio.FromDecibelWatts(40);
            Assert.AreEqual(43.0102999566, (v + v).DecibelWatts, DecibelWattsTolerance);
        }

        protected override void AssertLogarithmicSubtraction()
        {
            PowerRatio v = PowerRatio.FromDecibelWatts(40);
            Assert.AreEqual(49.5424250944, (PowerRatio.FromDecibelWatts(50) - v).DecibelWatts, DecibelWattsTolerance);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void InvalidPower_ExpectArgumentOutOfRangeException(double power)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => PowerRatio.FromPower(Power.FromWatts(power)));
        }

        [TestCase(1, Result = 0)]
        [TestCase(10, Result = 10)]
        [TestCase(100, Result = 20)]
        public double ExpectPowerConvertedCorrectly(double power)
        {
            Power p = Power.FromWatts(power);

            return PowerRatio.FromPower(p).DecibelWatts;
        }

        [TestCase(-20, Result = 0.01)]
        [TestCase(-10, Result = 0.1)]
        [TestCase(0, Result = 1)]
        [TestCase(10, Result = 10)]
        [TestCase(20, Result = 100)]
        public double ExpectPowerRatioConvertedCorrectly(double powerRatio)
        {
            PowerRatio pr = PowerRatio.FromDecibelWatts(powerRatio);

            return PowerRatio.ToPower(pr).Watts;
        }

        // http://www.maximintegrated.com/en/app-notes/index.mvp/id/808

        [TestCase(-36.99, Result = 10)]
        [TestCase(-26.99, Result = 20)]
        [TestCase(-16.99, Result = 30)]
        [TestCase(-6.99, Result = 40)]
        public double PowerRatioToAmplitudeRatio_50OhmImpedance(double dBmW)
        {
            PowerRatio powerRatio = PowerRatio.FromDecibelMilliwatts(dBmW);

            return Math.Round(powerRatio.ToAmplitudeRatio(ElectricResistance.FromOhms(50)).DecibelMillivolts, 2);
        }

        [TestCase(-38.75, Result = 10)]
        [TestCase(-28.75, Result = 20)]
        [TestCase(-18.75, Result = 30)]
        [TestCase(-8.75, Result = 40)]
        public double PowerRatioToAmplitudeRatio_75OhmImpedance(double dBmW)
        {
            PowerRatio powerRatio = PowerRatio.FromDecibelMilliwatts(dBmW);

            return Math.Round(powerRatio.ToAmplitudeRatio(ElectricResistance.FromOhms(75)).DecibelMillivolts, 2);
        }
    }
}