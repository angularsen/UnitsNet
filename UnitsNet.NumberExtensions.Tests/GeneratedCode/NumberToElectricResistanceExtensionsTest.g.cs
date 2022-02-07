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

using System;
using UnitsNet.NumberExtensions.NumberToElectricResistance;
using Xunit;

namespace UnitsNet.Tests
{
    public class NumberToElectricResistanceExtensionsTests
    {
        [Fact]
        public void NumberToGigaohmsTest() =>
            Assert.Equal(ElectricResistance.FromGigaohms(2), 2.Gigaohms());

        [Fact]
        public void NumberToKiloohmsTest() =>
            Assert.Equal(ElectricResistance.FromKiloohms(2), 2.Kiloohms());

        [Fact]
        public void NumberToMegaohmsTest() =>
            Assert.Equal(ElectricResistance.FromMegaohms(2), 2.Megaohms());

        [Fact]
        public void NumberToMicroohmsTest() =>
            Assert.Equal(ElectricResistance.FromMicroohms(2), 2.Microohms());

        [Fact]
        public void NumberToMilliohmsTest() =>
            Assert.Equal(ElectricResistance.FromMilliohms(2), 2.Milliohms());

        [Fact]
        public void NumberToOhmsTest() =>
            Assert.Equal(ElectricResistance.FromOhms(2), 2.Ohms());

    }
}
