﻿// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests
{
    public class TemperatureChangeRateTests : TemperatureChangeRateTestsBase
    {
        protected override double DegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1;

        protected override double DecadegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E-1;

        protected override double HectodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E-2;

        protected override double KilodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E-3;

        protected override double DecidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E1;

        protected override double CentidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E2;

        protected override double MillidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E3;

        protected override double MicrodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E6;

        protected override double NanodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond => 1E9;

        protected override double DegreesCelsiusPerMinuteInOneDegreeCelsiusPerSecond => 60;

        protected override double DegreesKelvinPerMinuteInOneDegreeCelsiusPerSecond => 60;

        protected override double DegreesFahrenheitPerHourInOneDegreeCelsiusPerSecond => 6480;

        protected override double DegreesFahrenheitPerMinuteInOneDegreeCelsiusPerSecond => 108;

        protected override double DegreesFahrenheitPerSecondInOneDegreeCelsiusPerSecond => 1.8;

        protected override double DegreesKelvinPerHourInOneDegreeCelsiusPerSecond => 3600;

        protected override double DegreesKelvinPerSecondInOneDegreeCelsiusPerSecond => 1;

        protected override double DegreesCelsiusPerHourInOneDegreeCelsiusPerSecond => 3600;


        [Fact(Skip = "See about changing the BaseUnit to KelvinPerSecond")]
        public override void BaseUnit_HasSIBase()
        {
            base.BaseUnit_HasSIBase();
        }

        [Fact]
        public void TemperatureChangeRateMultipliedWithTimeSpanEqualsTemperatureDelta()
        {
            TemperatureDelta d = TemperatureChangeRate.FromDegreesCelsiusPerSecond(2) * new TimeSpan(0, 0, 10);
            Assert.Equal(TemperatureDelta.FromDegreesCelsius(20), d);
        }

        [Fact]
        public void TemperatureChangeRateMultipliedWithDurationEqualsTemperatureDelta()
        {
            TemperatureDelta d = TemperatureChangeRate.FromDegreesCelsiusPerSecond(2) * Duration.FromSeconds(10);
            Assert.Equal(TemperatureDelta.FromDegreesCelsius(20), d);
        }

        [Fact]
        public void DurationMultipliedWithTemperatureChangeRateEqualsTemperatureDelta()
        {
            TemperatureDelta d = Duration.FromSeconds(-10) * TemperatureChangeRate.FromDegreesCelsiusPerSecond(2);
            Assert.Equal(TemperatureDelta.FromDegreesCelsius(-20), d);
        }
    }
}
