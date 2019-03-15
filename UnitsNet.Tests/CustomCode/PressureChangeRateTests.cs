// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests.CustomCode
{
    public class PressureChangeRateTests : PressureChangeRateTestsBase
    {
        protected override double AtmospheresPerSecondInOnePascalPerSecond => 9.8692*1E-6;

        protected override double KilopascalsPerSecondInOnePascalPerSecond => 1e-3;

        protected override double MegapascalsPerSecondInOnePascalPerSecond => 1E-6;

        protected override double PascalsPerSecondInOnePascalPerSecond => 1;

        protected override double MegapascalsPerMinuteInOnePascalPerSecond => 6e-5;

        protected override double KilopascalsPerMinuteInOnePascalPerSecond => 6e-2;

        protected override double PascalsPerMinuteInOnePascalPerSecond => 60;
    }
}
