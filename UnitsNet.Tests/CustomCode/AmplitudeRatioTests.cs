// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class AmplitudeRatioTests : AmplitudeRatioTestsBase
    {
        protected override double DecibelMicrovoltsInOneDecibelVolt => 121;

        protected override double DecibelMillivoltsInOneDecibelVolt => 61;

        protected override double DecibelsUnloadedInOneDecibelVolt => 3.218487499;

        protected override double DecibelVoltsInOneDecibelVolt => 1;

        protected override void AssertLogarithmicAddition()
        {
            AmplitudeRatio v = AmplitudeRatio.FromDecibelVolts(40);
            AssertEx.EqualTolerance(46.0205999133, (v + v).DecibelVolts, DecibelVoltsTolerance);
        }

        protected override void AssertLogarithmicSubtraction()
        {
            AmplitudeRatio v = AmplitudeRatio.FromDecibelVolts(40);
            AssertEx.EqualTolerance(46.6982292275, (AmplitudeRatio.FromDecibelVolts(50) - v).DecibelVolts, DecibelVoltsTolerance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public void InvalidVoltage_ExpectArgumentOutOfRangeException(double voltage)
        {
            ElectricPotential invalidVoltage = ElectricPotential.FromVolts(voltage);

            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentOutOfRangeException>(() => new AmplitudeRatio(invalidVoltage));
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(10, 20)]
        [InlineData(100, 40)]
        [InlineData(1000, 60)]
        public void ExpectVoltageConvertedToAmplitudeRatioCorrectly(double voltage, double expected)
        {
            // Amplitude ratio increases linearly by 20 dBV with power-of-10 increases of voltage.
            ElectricPotential v = ElectricPotential.FromVolts(voltage);

            double actual = AmplitudeRatio.FromElectricPotential(v).DecibelVolts;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-40, 0.01)]
        [InlineData(-20, 0.1)]
        [InlineData(0, 1)]
        [InlineData(20, 10)]
        [InlineData(40, 100)]
        public void ExpectAmplitudeRatioConvertedToVoltageCorrectly(double amplitudeRatio, double expected)
        {
            // Voltage increases by powers of 10 for every 20 dBV increase in amplitude ratio.
            AmplitudeRatio ar = AmplitudeRatio.FromDecibelVolts(amplitudeRatio);

            double actual = ar.ToElectricPotential().Volts;
            Assert.Equal(expected, actual);
        }

        // http://www.maximintegrated.com/en/app-notes/index.mvp/id/808

        [Theory]
        [InlineData(8, -38.99)]
        [InlineData(20, -26.99)]
        [InlineData(40, -6.99)]
        [InlineData(60, 13.01)]
        public void AmplitudeRatioToPowerRatio_50OhmImpedance(double dBmV, double expected)
        {
            AmplitudeRatio ampRatio = AmplitudeRatio.FromDecibelMillivolts(dBmV);

            double actual = Math.Round(ampRatio.ToPowerRatio(ElectricResistance.FromOhms(50)).DecibelMilliwatts, 2);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(8, -40.75)]
        [InlineData(20, -28.75)]
        [InlineData(40, -8.75)]
        [InlineData(60, 11.25)]
        public void AmplitudeRatioToPowerRatio_75OhmImpedance(double dBmV, double expected)
        {
            AmplitudeRatio ampRatio = AmplitudeRatio.FromDecibelMillivolts(dBmV);

            double actual = Math.Round(ampRatio.ToPowerRatio(ElectricResistance.FromOhms(75)).DecibelMilliwatts, 2);
            Assert.Equal(expected, actual);
        }
    }
}
