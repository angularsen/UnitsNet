// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Tests.CustomCode
{
    public class MolalityTests : MolalityTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;

        protected override double MolesPerKilogramInOneMolePerKilogram => 1;
        protected override double MolesPerGramInOneMolePerKilogram => 1e-3;
        protected override double MillimolesPerKilogramInOneMolePerKilogram => 1e3;
    }
}
