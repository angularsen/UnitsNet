// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class AreaPerLengthTests : AreaPerLengthTestsBase
    {
        // Sanity checked against area-per-length conversion tables:
        // - Cognite PROSPER units: https://docs.cognite.com/cdf/integration/guides/simulators/connectors/prosper/prosper_units
        // - Nucor Skyline technical product manual: https://www.nucorskyline.com/file%20library/document%20library/english/brochures/product_manual_en.pdf

        protected override double SquareMetersPerMeterInOneSquareMeterPerMeter => 1;

        protected override double SquareCentimetersPerMeterInOneSquareMeterPerMeter => 1E4;

        protected override double SquareMillimetersPerMeterInOneSquareMeterPerMeter => 1E6;

        protected override double SquareInchesPerFootInOneSquareMeterPerMeter => 472.44094488188976;

        protected override double SquareInchesPerInchInOneSquareMeterPerMeter => 39.370078740157481;

        protected override double SquareFeetPerFootInOneSquareMeterPerMeter => 3.2808398950131234;

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
