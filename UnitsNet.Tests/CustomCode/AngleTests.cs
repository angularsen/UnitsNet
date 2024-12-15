// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests
{
    public class AngleTests : AngleTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override double RadiansInOneRadian => 1;
        protected override double DeciradiansInOneRadian => 1E1;
        protected override double CentiradiansInOneRadian => 1E2;
        protected override double MilliradiansInOneRadian  => 1E3;
        protected override double MicroradiansInOneRadian  => 1E6;
        protected override double NanoradiansInOneRadian  => 1E9;
        protected override double DegreesInOneRadian => 180 / Math.PI;
        protected override double MillidegreesInOneRadian => 1E3 * 180 / Math.PI;
        protected override double MicrodegreesInOneRadian => 1E6 * 180 / Math.PI;
        protected override double NanodegreesInOneRadian => 1E9 * 180 / Math.PI;
        protected override double ArcminutesInOneRadian => 180 * 60 / Math.PI;
        protected override double ArcsecondsInOneRadian => 180 * 3600 / Math.PI;
        protected override double GradiansInOneRadian => 200 / Math.PI;
        protected override double NatoMilsInOneRadian => 6400 / (2 * Math.PI);
        protected override double RevolutionsInOneRadian => 1 / (2 * Math.PI);

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
