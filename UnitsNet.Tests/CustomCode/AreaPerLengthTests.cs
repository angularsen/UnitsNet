// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Tests.CustomCode
{
    public class AreaPerLengthTests : AreaPerLengthTestsBase
    {
        protected override double SquareMetersPerMeterInOneSquareMeterPerMeter => 1;

        protected override double SquareCentimetersPerMeterInOneSquareMeterPerMeter => 1E4;

        protected override double SquareMillimetersPerMeterInOneSquareMeterPerMeter => 1E6;
        
        protected override double SquareInchesPerFootInOneSquareMeterPerMeter => 472.44094488188976;

        protected override double SquareInchesPerInchInOneSquareMeterPerMeter => 39.370078740157481;

        protected override double SquareFeetPerFootInOneSquareMeterPerMeter => 3.2808398950131234;
    }
}
