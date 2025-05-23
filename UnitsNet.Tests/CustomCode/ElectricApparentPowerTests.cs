﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run generate-code.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet.Tests.CustomCode
{
    public class ElectricApparentPowerTests : ElectricApparentPowerTestsBase
    {
        protected override double VoltamperesInOneVoltampere => 1;

        protected override double KilovoltamperesInOneVoltampere => 1E-3;

        protected override double MegavoltamperesInOneVoltampere => 1E-6;

        protected override double GigavoltamperesInOneVoltampere => 1E-9;

        protected override double MicrovoltamperesInOneVoltampere => 1E6;

        protected override double MillivoltamperesInOneVoltampere => 1E3;
    }
}
