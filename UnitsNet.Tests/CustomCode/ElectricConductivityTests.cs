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
    public class ElectricConductivityTests : ElectricConductivityTestsBase
    {
        protected override double SiemensPerMeterInOneSiemensPerMeter => 1;
        protected override double SiemensPerInchInOneSiemensPerMeter => 2.54e-2;
        protected override double SiemensPerFootInOneSiemensPerMeter => 3.048e-1;
        protected override double SiemensPerCentimeterInOneSiemensPerMeter => 1e-2;
        protected override double MillisiemensPerCentimeterInOneSiemensPerMeter => 1e1;
        protected override double MicrosiemensPerCentimeterInOneSiemensPerMeter => 1e4;

        [Theory]
        [InlineData( -1.0, -1.0 )]
        [InlineData( -2.0, -0.5 )]
        [InlineData( 0.0, double.PositiveInfinity )]
        [InlineData( 1.0, 1.0 )]
        [InlineData( 2.0, 0.5 )]
        public static void InverseTest( double value, double expected )
        {
            var unit = new ElectricConductivity( value, ElectricConductivityUnit.SiemensPerMeter );
            var inverse = unit.Inverse();

            Assert.Equal( expected, inverse.OhmMeters );
        }
    }
}
