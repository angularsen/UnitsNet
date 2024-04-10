// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Tests.CustomCode
{
    public class RadiationEquivalentDoseTests : RadiationEquivalentDoseTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;

        protected override double SievertsInOneSievert => 1;
        protected override double MillisievertsInOneSievert => 1e+3;
        protected override double MicrosievertsInOneSievert => 1e+6;
        protected override double NanosievertsInOneSievert => 1e+9;
        protected override double MilliroentgensEquivalentManInOneSievert => 1e+5;
        protected override double RoentgensEquivalentManInOneSievert => 100;
    }
}
