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
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class ElectricResistivityTests : ElectricResistivityTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override double KiloohmsCentimeterInOneOhmMeter => 1e-1;

        protected override double KiloohmMetersInOneOhmMeter => 1e-3;

        protected override double MegaohmsCentimeterInOneOhmMeter => 1e-4;

        protected override double MegaohmMetersInOneOhmMeter => 1e-6;

        protected override double MicroohmsCentimeterInOneOhmMeter => 1e8;

        protected override double MicroohmMetersInOneOhmMeter => 1e6;

        protected override double MilliohmsCentimeterInOneOhmMeter => 1e5;

        protected override double MilliohmMetersInOneOhmMeter => 1e3;

        protected override double NanoohmsCentimeterInOneOhmMeter => 1e11;

        protected override double NanoohmMetersInOneOhmMeter => 1e9;

        protected override double OhmsCentimeterInOneOhmMeter => 1e2;

        protected override double OhmMetersInOneOhmMeter => 1;

        protected override double PicoohmsCentimeterInOneOhmMeter => 1e14;

        protected override double PicoohmMetersInOneOhmMeter => 1e+12;

        [Theory]
        [InlineData( -1.0, -1.0 )]
        [InlineData( -2.0, -0.5 )]
        [InlineData( 0.0, 0.0 )]
        [InlineData( 1.0, 1.0 )]
        [InlineData( 2.0, 0.5 )]
        public static void InverseTest( double value, double expected )
        {
            var unit = new ElectricResistivity( value, ElectricResistivityUnit.OhmMeter );
            var inverse = unit.Inverse();

            Assert.Equal( expected, inverse.SiemensPerMeter );
        }
    }
}
