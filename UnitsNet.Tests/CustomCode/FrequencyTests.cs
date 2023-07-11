// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Tests
{
    public class FrequencyTests : FrequencyTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        
        protected override double MicrohertzInOneHertz => 1e6;
        
        protected override double MillihertzInOneHertz => 1e3;
        
        protected override double HertzInOneHertz => 1;

        protected override double KilohertzInOneHertz => 1e-3;

        protected override double MegahertzInOneHertz => 1e-6;

        protected override double GigahertzInOneHertz => 1e-9;

        protected override double TerahertzInOneHertz => 1e-12;

        protected override double PerSecondInOneHertz => 1;

        protected override double CyclesPerHourInOneHertz => 3600;

        protected override double CyclesPerMinuteInOneHertz => 60;

        protected override double RadiansPerSecondInOneHertz => 2 * Math.PI;

        protected override double BeatsPerMinuteInOneHertz => 60;

        protected override double BUnitsInOneHertz => 0.001;
    }
}
