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
    public class PowerRatioTests : PowerRatioTestsBase
    {
        protected override double DecibelMilliwattsInOneDecibelWatt => 31;

        protected override double DecibelWattsInOneDecibelWatt => 1;

        protected override void AssertLogarithmicAddition()
        {
            PowerRatio v = PowerRatio.FromDecibelWatts(40);
            AssertEx.EqualTolerance(43.0102999566, (v + v).DecibelWatts, DecibelWattsTolerance);
        }

        protected override void AssertLogarithmicSubtraction()
        {
            PowerRatio v = PowerRatio.FromDecibelWatts(40);
            AssertEx.EqualTolerance(49.5424250944, (PowerRatio.FromDecibelWatts(50) - v).DecibelWatts, DecibelWattsTolerance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void InvalidPower_ExpectArgumentOutOfRangeException(double power)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => PowerRatio.FromPower(Power.FromWatts(power)));
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(10, 10)]
        [InlineData(100, 20)]
        public void ExpectPowerConvertedCorrectly(double power, double expected)
        {
            Power p = Power.FromWatts(power);
            double actual = PowerRatio.FromPower(p).DecibelWatts;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-20, 0.01)]
        [InlineData(-10, 0.1)]
        [InlineData(0, 1)]
        [InlineData(10, 10)]
        [InlineData(20, 100)]
        public void ExpectPowerRatioConvertedCorrectly(double powerRatio, double expected)
        {
            PowerRatio pr = PowerRatio.FromDecibelWatts(powerRatio);
            double actual = pr.ToPower().Watts;
            Assert.Equal(expected, actual);
        }

        // http://www.maximintegrated.com/en/app-notes/index.mvp/id/808

        [Theory]
        [InlineData(-36.99, 10)]
        [InlineData(-26.99, 20)]
        [InlineData(-16.99, 30)]
        [InlineData(-6.99, 40)]
        public void PowerRatioToAmplitudeRatio_50OhmImpedance(double dBmW, double expected)
        {
            PowerRatio powerRatio = PowerRatio.FromDecibelMilliwatts(dBmW);

            double actual = Math.Round(powerRatio.ToAmplitudeRatio(ElectricResistance.FromOhms(50)).DecibelMillivolts, 2);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-38.75, 10)]
        [InlineData(-28.75, 20)]
        [InlineData(-18.75, 30)]
        [InlineData(-8.75, 40)]
        public void PowerRatioToAmplitudeRatio_75OhmImpedance(double dBmW, double expected)
        {
            PowerRatio powerRatio = PowerRatio.FromDecibelMilliwatts(dBmW);

            double actual = Math.Round(powerRatio.ToAmplitudeRatio(ElectricResistance.FromOhms(75)).DecibelMillivolts, 2);
            Assert.Equal(expected, actual);
        }
    }
}
