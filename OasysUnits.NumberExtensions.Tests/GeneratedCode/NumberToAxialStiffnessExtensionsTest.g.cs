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

using OasysUnits.NumberExtensions.NumberToAxialStiffness;
using Xunit;

namespace OasysUnits.Tests
{
    public class NumberToAxialStiffnessExtensionsTests
    {
        [Fact]
        public void NumberToDecanewtonsTest() =>
            Assert.Equal(AxialStiffness.FromDecanewtons(2), 2.Decanewtons());

        [Fact]
        public void NumberToDyneTest() =>
            Assert.Equal(AxialStiffness.FromDyne(2), 2.Dyne());

        [Fact]
        public void NumberToKilogramsForceTest() =>
            Assert.Equal(AxialStiffness.FromKilogramsForce(2), 2.KilogramsForce());

        [Fact]
        public void NumberToKilonewtonsTest() =>
            Assert.Equal(AxialStiffness.FromKilonewtons(2), 2.Kilonewtons());

        [Fact]
        public void NumberToKiloPondsTest() =>
            Assert.Equal(AxialStiffness.FromKiloPonds(2), 2.KiloPonds());

        [Fact]
        public void NumberToKilopoundsForceTest() =>
            Assert.Equal(AxialStiffness.FromKilopoundsForce(2), 2.KilopoundsForce());

        [Fact]
        public void NumberToMeganewtonsTest() =>
            Assert.Equal(AxialStiffness.FromMeganewtons(2), 2.Meganewtons());

        [Fact]
        public void NumberToMicronewtonsTest() =>
            Assert.Equal(AxialStiffness.FromMicronewtons(2), 2.Micronewtons());

        [Fact]
        public void NumberToMillinewtonsTest() =>
            Assert.Equal(AxialStiffness.FromMillinewtons(2), 2.Millinewtons());

        [Fact]
        public void NumberToNewtonsTest() =>
            Assert.Equal(AxialStiffness.FromNewtons(2), 2.Newtons());

        [Fact]
        public void NumberToOunceForceTest() =>
            Assert.Equal(AxialStiffness.FromOunceForce(2), 2.OunceForce());

        [Fact]
        public void NumberToPoundalsTest() =>
            Assert.Equal(AxialStiffness.FromPoundals(2), 2.Poundals());

        [Fact]
        public void NumberToPoundsForceTest() =>
            Assert.Equal(AxialStiffness.FromPoundsForce(2), 2.PoundsForce());

        [Fact]
        public void NumberToShortTonsForceTest() =>
            Assert.Equal(AxialStiffness.FromShortTonsForce(2), 2.ShortTonsForce());

        [Fact]
        public void NumberToTonnesForceTest() =>
            Assert.Equal(AxialStiffness.FromTonnesForce(2), 2.TonnesForce());

    }
}
