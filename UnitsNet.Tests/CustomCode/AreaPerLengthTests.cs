// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class AreaPerLengthTests : AreaPerLengthTestsBase
    {
        // NIST: https://www.nist.gov/pml/us-surveyfoot
        // The international foot is exactly 0.3048 m.
        // Since one foot is exactly 12 inches, one inch is exactly 0.0254 m.
        private const double MetersPerFoot = 0.3048;
        private const double MetersPerInch = MetersPerFoot / 12;

        protected override double SquareMetersPerMeterInOneSquareMeterPerMeter => 1;

        protected override double SquareCentimetersPerMeterInOneSquareMeterPerMeter => 1E4;

        protected override double SquareMillimetersPerMeterInOneSquareMeterPerMeter => 1E6;

        protected override double SquareInchesPerFootInOneSquareMeterPerMeter => MetersPerFoot / (MetersPerInch * MetersPerInch);

        protected override double SquareInchesPerInchInOneSquareMeterPerMeter => MetersPerInch / (MetersPerInch * MetersPerInch);

        protected override double SquareFeetPerFootInOneSquareMeterPerMeter => MetersPerFoot / (MetersPerFoot * MetersPerFoot);

        [Fact]
        public void AreaPerLengthTimesLengthEqualsArea()
        {
            Area area = AreaPerLength.FromSquareMillimetersPerMeter(500) * Length.FromMeters(10);
            Assert.Equal(5000, area.SquareMillimeters);
        }

        [Fact]
        public void LengthTimesAreaPerLengthEqualsArea()
        {
            Area area = Length.FromFeet(20) * AreaPerLength.FromSquareInchesPerFoot(3);
            Assert.Equal(60, area.SquareInches, 12);
        }
    }
}
