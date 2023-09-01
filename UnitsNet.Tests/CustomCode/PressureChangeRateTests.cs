// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

using Xunit;

namespace UnitsNet.Tests
{
    public class PressureChangeRateTests : PressureChangeRateTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;
        protected override double AtmospheresPerSecondInOnePascalPerSecond => 9.8692 * 1E-6;

        protected override double KilopascalsPerSecondInOnePascalPerSecond => 1e-3;

        protected override double KilopoundsForcePerSquareInchPerMinuteInOnePascalPerSecond => 1.450377377302092e-7 * 60;

        protected override double KilopoundsForcePerSquareInchPerSecondInOnePascalPerSecond => 1.450377377302092e-7;

        protected override double MegapascalsPerSecondInOnePascalPerSecond => 1E-6;

        protected override double MegapoundsForcePerSquareInchPerMinuteInOnePascalPerSecond => 1.450377377302092e-10 * 60;

        protected override double MegapoundsForcePerSquareInchPerSecondInOnePascalPerSecond => 1.450377377302092e-10;

        protected override double PascalsPerSecondInOnePascalPerSecond => 1;

        protected override double PoundsForcePerSquareInchPerMinuteInOnePascalPerSecond => 1.450377377302092e-4 * 60;

        protected override double PoundsForcePerSquareInchPerSecondInOnePascalPerSecond => 1.450377377302092e-4;

        protected override double MegapascalsPerMinuteInOnePascalPerSecond => 6e-5;

        protected override double KilopascalsPerMinuteInOnePascalPerSecond => 6e-2;

        protected override double PascalsPerMinuteInOnePascalPerSecond => 60;

        protected override double MillimetersOfMercuryPerSecondInOnePascalPerSecond => 7.500637554192106e-3;

        protected override double BarsPerMinuteInOnePascalPerSecond => 6e-4;

        protected override double BarsPerSecondInOnePascalPerSecond => 1e-5;

        protected override double MillibarsPerMinuteInOnePascalPerSecond => 0.6;

        protected override double MillibarsPerSecondInOnePascalPerSecond => 1e-2;

        [Fact]
        public void PressureChangeRateTimesDurationEqualsPressure()
        {
            Pressure pressure = PressureChangeRate.FromPascalsPerSecond(500) * Duration.FromSeconds(2);
            Assert.Equal(Pressure.FromPascals(1000), pressure);
        }

        [Fact]
        public void PressureChangeRateTimesTimeSpanEqualsPressure()
        {
            Pressure pressure = PressureChangeRate.FromPascalsPerSecond(500) * TimeSpan.FromSeconds(2);
            Assert.Equal(Pressure.FromPascals(1000), pressure);
        }
    }
}
