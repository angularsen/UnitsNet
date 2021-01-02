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

using UnitsNet.NumberExtensions.NumberToElectricPotential;
using Xunit;

namespace UnitsNet.Tests
{
    public class NumberToElectricPotentialExtensionsTests
    {
        [Fact]
        public void NumberToKilovoltsTest() =>
            Assert.Equal(ElectricPotential<double>.FromKilovolts(2), 2.Kilovolts());

        [Fact]
        public void NumberToMegavoltsTest() =>
            Assert.Equal(ElectricPotential<double>.FromMegavolts(2), 2.Megavolts());

        [Fact]
        public void NumberToMicrovoltsTest() =>
            Assert.Equal(ElectricPotential<double>.FromMicrovolts(2), 2.Microvolts());

        [Fact]
        public void NumberToMillivoltsTest() =>
            Assert.Equal(ElectricPotential<double>.FromMillivolts(2), 2.Millivolts());

        [Fact]
        public void NumberToVoltsTest() =>
            Assert.Equal(ElectricPotential<double>.FromVolts(2), 2.Volts());

    }
}
