﻿// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace OasysUnitsNet.Tests.CustomCode
{
    public class VitaminATests : VitaminATestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override double InternationalUnitsInOneInternationalUnit => 1;
    }
}
