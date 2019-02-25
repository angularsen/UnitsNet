// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests.CustomCode
{
    public class ElectricPotentialTests : ElectricPotentialTestsBase
    {
        protected override double MicrovoltsInOneVolt => 1e6;

        protected override double MillivoltsInOneVolt => 1e3;

        protected override double VoltsInOneVolt => 1;

        protected override double KilovoltsInOneVolt => 1e-3;

        protected override double MegavoltsInOneVolt => 1e-6;
    }
}
