// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests.CustomCode
{
    public class ForceChangeRateTests : ForceChangeRateTestsBase
    {
        protected override double NewtonsPerMinuteInOneNewtonPerSecond => 60;
        protected override double DecanewtonsPerMinuteInOneNewtonPerSecond => 6;
        protected override double KilonewtonsPerMinuteInOneNewtonPerSecond => 0.06;
        protected override double KilonewtonsPerSecondInOneNewtonPerSecond => 1E-3;
        protected override double DecanewtonsPerSecondInOneNewtonPerSecond => 1E-1;
        protected override double NewtonsPerSecondInOneNewtonPerSecond => 1;
        protected override double DecinewtonsPerSecondInOneNewtonPerSecond => 1E1;
        protected override double CentinewtonsPerSecondInOneNewtonPerSecond => 1E2;
        protected override double MillinewtonsPerSecondInOneNewtonPerSecond => 1E3;
        protected override double MicronewtonsPerSecondInOneNewtonPerSecond => 1E6;
        protected override double NanonewtonsPerSecondInOneNewtonPerSecond => 1E9;
    }
}
