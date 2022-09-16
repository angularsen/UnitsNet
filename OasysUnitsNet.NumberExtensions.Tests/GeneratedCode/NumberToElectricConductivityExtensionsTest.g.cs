//------------------------------------------------------------------------------
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

using OasysUnitsNet.NumberExtensions.NumberToElectricConductivity;
using Xunit;

namespace OasysUnitsNet.Tests
{
    public class NumberToElectricConductivityExtensionsTests
    {
        [Fact]
        public void NumberToMicrosiemensPerCentimeterTest() =>
            Assert.Equal(ElectricConductivity.FromMicrosiemensPerCentimeter(2), 2.MicrosiemensPerCentimeter());

        [Fact]
        public void NumberToMillisiemensPerCentimeterTest() =>
            Assert.Equal(ElectricConductivity.FromMillisiemensPerCentimeter(2), 2.MillisiemensPerCentimeter());

        [Fact]
        public void NumberToSiemensPerCentimeterTest() =>
            Assert.Equal(ElectricConductivity.FromSiemensPerCentimeter(2), 2.SiemensPerCentimeter());

        [Fact]
        public void NumberToSiemensPerFootTest() =>
            Assert.Equal(ElectricConductivity.FromSiemensPerFoot(2), 2.SiemensPerFoot());

        [Fact]
        public void NumberToSiemensPerInchTest() =>
            Assert.Equal(ElectricConductivity.FromSiemensPerInch(2), 2.SiemensPerInch());

        [Fact]
        public void NumberToSiemensPerMeterTest() =>
            Assert.Equal(ElectricConductivity.FromSiemensPerMeter(2), 2.SiemensPerMeter());

    }
}
