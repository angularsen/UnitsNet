// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Tests.CustomCode
{
    public class RadioactivityTests : RadioactivityTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;

        protected override double BecquerelsInOneBecquerel => 1;
        protected override double CuriesInOneBecquerel => 2.702702702703e-11;
        protected override double ExabecquerelsInOneBecquerel => 1e-18;
        protected override double GigabecquerelsInOneBecquerel => 1e-9;
        protected override double GigacuriesInOneBecquerel => 2.702702702703e-20;
        protected override double GigarutherfordsInOneBecquerel => 1e-15;
        protected override double KilobecquerelsInOneBecquerel => 1e-3;
        protected override double KilocuriesInOneBecquerel => 2.702702702703e-14;
        protected override double KilorutherfordsInOneBecquerel => 1e-9;
        protected override double MegabecquerelsInOneBecquerel => 1e-6;
        protected override double MegacuriesInOneBecquerel => 2.702702702703e-17;
        protected override double MegarutherfordsInOneBecquerel => 1e-12;
        protected override double MicrobecquerelsInOneBecquerel => 1e+6;
        protected override double MicrocuriesInOneBecquerel => 2.702702702703e-5;
        protected override double MicrorutherfordsInOneBecquerel => 1;
        protected override double MillibecquerelsInOneBecquerel => 1e+3;
        protected override double MillicuriesInOneBecquerel => 2.702702702703e-8;
        protected override double MillirutherfordsInOneBecquerel => 1e-3;
        protected override double NanobecquerelsInOneBecquerel => 1e+9;
        protected override double NanocuriesInOneBecquerel => 0.02702702702703;
        protected override double NanorutherfordsInOneBecquerel => 1e+3;
        protected override double PetabecquerelsInOneBecquerel => 1e-15;
        protected override double PicobecquerelsInOneBecquerel => 1e+12;
        protected override double PicocuriesInOneBecquerel => 27.02702702703;
        protected override double PicorutherfordsInOneBecquerel => 1e+6;
        protected override double RutherfordsInOneBecquerel => 1e-6;
        protected override double TerabecquerelsInOneBecquerel => 1e-12;
        protected override double TeracuriesInOneBecquerel => 2.702702702703e-23;
        protected override double TerarutherfordsInOneBecquerel => 1e-18;
    }
}
