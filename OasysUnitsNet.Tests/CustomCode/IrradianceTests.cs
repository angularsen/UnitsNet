﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated (once) by \generate-code.bat, but will not be
//     regenerated when it already exists. The purpose of creating this file is to make
//     it easier to remember to implement all the unit conversion test cases.
//
//     Whenever a new unit is added to this quantity and \generate-code.bat is run,
//     the base test class will get a new abstract property and cause a compile error
//     in this derived class, reminding the developer to implement the test case
//     for the new unit.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run GeneratUnits.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.


using System;

namespace OasysUnitsNet.Tests.CustomCode
{
    public class IrradianceTests : IrradianceTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override double KilowattsPerSquareCentimeterInOneWattPerSquareMeter => 1e-7;

        protected override double KilowattsPerSquareMeterInOneWattPerSquareMeter => 1e-3;

        protected override double MegawattsPerSquareCentimeterInOneWattPerSquareMeter => 1e-10;

        protected override double MegawattsPerSquareMeterInOneWattPerSquareMeter => 1e-6;

        protected override double MicrowattsPerSquareCentimeterInOneWattPerSquareMeter => 100;

        protected override double MicrowattsPerSquareMeterInOneWattPerSquareMeter => 1e6;

        protected override double MilliwattsPerSquareCentimeterInOneWattPerSquareMeter => 0.1;

        protected override double MilliwattsPerSquareMeterInOneWattPerSquareMeter => 1e3;

        protected override double NanowattsPerSquareCentimeterInOneWattPerSquareMeter => 1e5;

        protected override double NanowattsPerSquareMeterInOneWattPerSquareMeter => 1e+9;

        protected override double PicowattsPerSquareCentimeterInOneWattPerSquareMeter => 1e+8;

        protected override double PicowattsPerSquareMeterInOneWattPerSquareMeter => 1e+12;

        protected override double WattsPerSquareCentimeterInOneWattPerSquareMeter => 1e-4;

        protected override double WattsPerSquareMeterInOneWattPerSquareMeter => 1;
    }
}
