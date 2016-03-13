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
    public class AmplitudeRatioTests : AmplitudeRatioTestsBase
    {
        protected override double DecibelMicrovoltsInOneDecibelVolt => 121;

        protected override double DecibelMillivoltsInOneDecibelVolt => 61;

        protected override double DecibelVoltsInOneDecibelVolt => 1;

        protected override void AssertLogarithmicAddition()
        {
            AmplitudeRatio v = AmplitudeRatio.FromDecibelVolts(40);
            Assert.AreEqual(46.0205999133, (v + v).DecibelVolts, DecibelVoltsTolerance);
        }

        protected override void AssertLogarithmicSubtraction()
        {
            AmplitudeRatio v = AmplitudeRatio.FromDecibelVolts(40);
            Assert.AreEqual(46.6982292275, (AmplitudeRatio.FromDecibelVolts(50) - v).DecibelVolts, DecibelVoltsTolerance);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void InvalidVoltage_ExpectArgumentOutOfRangeException(double voltage)
        {
            ElectricPotential invalidVoltage = ElectricPotential.FromVolts(voltage);

            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentOutOfRangeException>(() => new AmplitudeRatio(invalidVoltage));
        }

        [TestCase(1, Result = 0)]
        [TestCase(10, Result = 20)]
        [TestCase(100, Result = 40)]
        [TestCase(1000, Result = 60)]
        public double ExpectVoltageConvertedToAmplitudeRatioCorrectly(double voltage)
        {
            // Amplitude ratio increases linearly by 20 dBV with power-of-10 increases of voltage.
            ElectricPotential v = ElectricPotential.FromVolts(voltage);

            return AmplitudeRatio.FromElectricPotential(v).DecibelVolts;
        }

        [TestCase(-40, Result = 0.01)]
        [TestCase(-20, Result = 0.1)]
        [TestCase(0, Result = 1)]
        [TestCase(20, Result = 10)]
        [TestCase(40, Result = 100)]
        public double ExpectAmplitudeRatioConvertedToVoltageCorrectly(double amplitudeRatio)
        {
            // Voltage increases by powers of 10 for every 20 dBV increase in amplitude ratio.
            AmplitudeRatio ar = AmplitudeRatio.FromDecibelVolts(amplitudeRatio);

            return AmplitudeRatio.ToElectricPotential(ar).Volts;
        }

        // http://www.maximintegrated.com/en/app-notes/index.mvp/id/808

        [TestCase(8, Result = -38.99)]
        [TestCase(20, Result = -26.99)]
        [TestCase(40, Result = -6.99)]
        [TestCase(60, Result = 13.01)]
        public double AmplitudeRatioToPowerRatio_50OhmImpedance(double dBmV)
        {
            AmplitudeRatio ampRatio = AmplitudeRatio.FromDecibelMillivolts(dBmV);

            return Math.Round(ampRatio.ToPowerRatio(ElectricResistance.FromOhms(50)).DecibelMilliwatts, 2);
        }

        [TestCase(8, Result = -40.75)]
        [TestCase(20, Result = -28.75)]
        [TestCase(40, Result = -8.75)]
        [TestCase(60, Result = 11.25)]
        public double AmplitudeRatioToPowerRatio_75OhmImpedance(double dBmV)
        {
            AmplitudeRatio ampRatio = AmplitudeRatio.FromDecibelMillivolts(dBmV);

            return Math.Round(ampRatio.ToPowerRatio(ElectricResistance.FromOhms(75)).DecibelMilliwatts, 2);
        }
    }
}