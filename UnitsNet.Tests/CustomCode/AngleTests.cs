// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class AngleTests : AngleTestsBase
    {
        protected override double DegreesInOneDegree => 1;

        protected override double GradiansInOneDegree => 400 / 360.0;

        protected override double ArcminutesInOneDegree => 60.0;

        protected override double RadiansInOneDegree => Math.PI / 2 / 90;

        protected override double MillidegreesInOneDegree => 1E3;

        protected override double MicrodegreesInOneDegree => 1E6;

        protected override double NanodegreesInOneDegree => 1E9;

        protected override double NanoradiansInOneDegree => Math.PI / 2 / 90 * 1E9;

        protected override double MicroradiansInOneDegree => Math.PI / 2 / 90 * 1E6;

        protected override double MilliradiansInOneDegree => Math.PI / 2 / 90 * 1E3;

        protected override double CentiradiansInOneDegree => Math.PI / 2 / 90 * 1E2;

        protected override double DeciradiansInOneDegree => Math.PI / 2 / 90 * 1E1;

        protected override double ArcsecondsInOneDegree => 3600.0;

        protected override double RevolutionsInOneDegree => 2.777777777777777e-3;

        [Fact]
        public void AngleDividedByDurationEqualsRotationalSpeed()
        {
            RotationalSpeed rotationalSpeed = Angle.FromRadians(10) / Duration.FromSeconds(5);
            Assert.Equal(rotationalSpeed, RotationalSpeed.FromRadiansPerSecond(2));
        }

        [Fact]
        public void AngleDividedByTimeSpanEqualsRotationalSpeed()
        {
            RotationalSpeed rotationalSpeed = Angle.FromRadians(10) / TimeSpan.FromSeconds(5);
            Assert.Equal(rotationalSpeed, RotationalSpeed.FromRadiansPerSecond(2));
        }
    }
}
