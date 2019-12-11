// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Tests.CustomCode
{
    public class FrequencyTests : FrequencyTestsBase
    {
        protected override double HertzInOneHertz => 1;

        protected override double KilohertzInOneHertz => 1e-3;

        protected override double MegahertzInOneHertz => 1e-6;

        protected override double GigahertzInOneHertz => 1e-9;

        protected override double TerahertzInOneHertz => 1e-12;

        protected override double CyclesPerHourInOneHertz => 3600;

        protected override double CyclesPerMinuteInOneHertz => 60;

        protected override double RadiansPerSecondInOneHertz => 2*Math.PI;

        protected override double BeatsPerMinuteInOneHertz => 60;
    }
}
