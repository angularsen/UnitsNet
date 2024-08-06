// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Tests.CustomCode
{
    public class RadiationExposureTests : RadiationExposureTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;
        protected override double CoulombsPerKilogramInOneCoulombPerKilogram => 1;
        protected override double MillicoulombsPerKilogramInOneCoulombPerKilogram => 1e+3;
        protected override double MicrocoulombsPerKilogramInOneCoulombPerKilogram => 1e+6;
        protected override double NanocoulombsPerKilogramInOneCoulombPerKilogram => 1e+9;
        protected override double PicocoulombsPerKilogramInOneCoulombPerKilogram => 1e+12;
        protected override double RoentgensInOneCoulombPerKilogram => 3875.9689922;
        protected override double MilliroentgensInOneCoulombPerKilogram => 3875.9689922e+3;
        protected override double MicroroentgensInOneCoulombPerKilogram => 3875.9689922e+6;
    }
}
