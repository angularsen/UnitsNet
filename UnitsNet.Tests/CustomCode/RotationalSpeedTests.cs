// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

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

        [Fact]
        public void DurationTimesRotationalSpeedEqualsAngle()
        {
            Angle angle = Duration.FromSeconds(9.0)*RotationalSpeed.FromRadiansPerSecond(10.0);
            Assert.Equal(angle, Angle.FromRadians(90.0));
        }

        [Fact]
        public void RotationalSpeedTimesDurationEqualsAngle()
        {
            Angle angle = RotationalSpeed.FromRadiansPerSecond(10.0)*Duration.FromSeconds(9.0);
            Assert.Equal(angle, Angle.FromRadians(90.0));
        }

        [Fact]
        public void RotationalSpeedTimesTimeSpanEqualsAngle()
        {
            Angle angle = RotationalSpeed.FromRadiansPerSecond(10.0)*TimeSpan.FromSeconds(9.0);
            Assert.Equal(angle, Angle.FromRadians(90.0));
        }

        [Fact]
        public void TimeSpanTimesRotationalSpeedEqualsAngle()
        {
            Angle angle = TimeSpan.FromSeconds(9.0)*RotationalSpeed.FromRadiansPerSecond(10.0);
            Assert.Equal(angle, Angle.FromRadians(90.0));
        }
    }
}
