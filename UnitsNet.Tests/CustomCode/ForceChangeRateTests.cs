// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class ForceChangeRateTests : ForceChangeRateTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override double NewtonsPerMinuteInOneNewtonPerSecond => 60;
        protected override double DecanewtonsPerMinuteInOneNewtonPerSecond => 6;
        protected override double KilonewtonsPerMinuteInOneNewtonPerSecond => 0.06;
        protected override double KilonewtonsPerSecondInOneNewtonPerSecond => 1E-3;
        protected override double KilopoundsForcePerMinuteInOneNewtonPerSecond => 0.22481e-3*60;
        protected override double KilopoundsForcePerSecondInOneNewtonPerSecond => 0.22481e-3;
        protected override double DecanewtonsPerSecondInOneNewtonPerSecond => 1E-1;
        protected override double NewtonsPerSecondInOneNewtonPerSecond => 1;
        protected override double PoundsForcePerMinuteInOneNewtonPerSecond => 0.22481 * 60;
        protected override double PoundsForcePerSecondInOneNewtonPerSecond => 0.22481;
        protected override double DecinewtonsPerSecondInOneNewtonPerSecond => 1E1;
        protected override double CentinewtonsPerSecondInOneNewtonPerSecond => 1E2;
        protected override double MillinewtonsPerSecondInOneNewtonPerSecond => 1E3;
        protected override double MicronewtonsPerSecondInOneNewtonPerSecond => 1E6;
        protected override double NanonewtonsPerSecondInOneNewtonPerSecond => 1E9;

        [Fact]
        public void DurationTimesForceChangeRate()
        {
            Force force = ForceChangeRate.FromNewtonsPerSecond(100) * Duration.FromSeconds(10);
            Assert.Equal(Force.FromNewtons(1000), force);
        }
    }
}
