// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests.CustomCode
{
    public class ElectricResistanceTests : ElectricResistanceTestsBase
    {
        protected override double MilliohmsInOneOhm => 1000;

        protected override double OhmsInOneOhm => 1;

        protected override double KiloohmsInOneOhm => 1e-3;

        protected override double MegaohmsInOneOhm => 1e-6;

        protected override double GigaohmsInOneOhm => 1e-9;
    }
}
