// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests.CustomCode
{
    public class RatioTests : RatioTestsBase
    {
        protected override double DecimalFractionsInOneDecimalFraction => 1;

        protected override double PartsPerBillionInOneDecimalFraction => 1e9;

        protected override double PartsPerMillionInOneDecimalFraction => 1e6;

        protected override double PartsPerThousandInOneDecimalFraction => 1e3;

        protected override double PartsPerTrillionInOneDecimalFraction => 1e12;

        protected override double PercentInOneDecimalFraction => 100;
    }
}
