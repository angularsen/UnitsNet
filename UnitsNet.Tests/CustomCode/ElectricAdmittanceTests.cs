﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated (once) by \generate-code.bat, but will not be
//     regenerated when it already exists. The purpose of creating this file is to make
//     it easier to remember to implement all the unit conversion test cases.
//
//     Whenever a new unit is added to this unit class and \generate-code.bat is run,
//     the base test class will get a new abstract property and cause a compile error
//     in this derived class, reminding the developer to implement the test case
//     for the new unit.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\UnitClasses\MyQuantity.extra.cs files to add code to generated unit classes.
//     Add UnitDefinitions\MyQuantity.json and run GeneratUnits.bat to generate new units or unit classes.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.


using System;

namespace UnitsNet.Tests.CustomCode
{
    public class ElectricAdmittanceTests : ElectricAdmittanceTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;

        protected override double MicrosiemensInOneSiemens => 1e+6;

        protected override double MillisiemensInOneSiemens => 1000;

        protected override double NanosiemensInOneSiemens => 1e+9;

        protected override double SiemensInOneSiemens => 1;
    }
}