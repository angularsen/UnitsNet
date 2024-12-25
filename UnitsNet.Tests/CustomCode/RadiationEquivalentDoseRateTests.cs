// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class RadiationEquivalentDoseRateTests : RadiationEquivalentDoseRateTestsBase
    {
        // Override properties in base class here
        protected override bool SupportsSIUnitSystem => false;
        protected override double SievertsPerSecondInOneSievertPerSecond => 1;
        protected override double MillisievertsPerSecondInOneSievertPerSecond => 1e+3;
        protected override double MicrosievertsPerSecondInOneSievertPerSecond => 1e+6;
        protected override double NanosievertsPerSecondInOneSievertPerSecond => 1e+9;
        protected override double SievertsPerHourInOneSievertPerSecond => 3600;
        protected override double MillisievertsPerHourInOneSievertPerSecond => 3.6e+6;
        protected override double MicrosievertsPerHourInOneSievertPerSecond => 3.6e+9;
        protected override double NanosievertsPerHourInOneSievertPerSecond => 3.6e+12;
        protected override double RoentgensEquivalentManPerHourInOneSievertPerSecond => 3.6e+5;
        protected override double MilliroentgensEquivalentManPerHourInOneSievertPerSecond => 3.6e+8;

        [Fact]
        public void RadiationEquivalentDoseRateTimesTimeSpanEqualsRadiationEquivalentDose()
        {
            RadiationEquivalentDose dose = RadiationEquivalentDoseRate.FromSievertsPerHour(20) * TimeSpan.FromHours(2);
            Assert.Equal(dose, RadiationEquivalentDose.FromSieverts(40));
        }

        [Fact]
        public void RadiationEquivalentDoseRateTimesDurationEqualsRadiationEquivalentDose()
        {
            RadiationEquivalentDose dose = RadiationEquivalentDoseRate.FromSievertsPerHour(20) * Duration.FromHours(2);
            Assert.Equal(dose, RadiationEquivalentDose.FromSieverts(40));
        }
    }
}
