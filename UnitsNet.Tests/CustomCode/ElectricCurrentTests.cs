// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests.CustomCode
{
    public class ElectricCurrentTests : ElectricCurrentTestsBase
    {
        protected override double PicoamperesInOneAmpere => 1e12;

        protected override double NanoamperesInOneAmpere => 1e9;

        protected override double MicroamperesInOneAmpere => 1e6;

        protected override double MilliamperesInOneAmpere => 1e3;

        protected override double CentiamperesInOneAmpere => 1e2;

        protected override double AmperesInOneAmpere => 1;

        protected override double KiloamperesInOneAmpere => 1e-3;

        protected override double MegaamperesInOneAmpere => 1e-6;

    }
}
