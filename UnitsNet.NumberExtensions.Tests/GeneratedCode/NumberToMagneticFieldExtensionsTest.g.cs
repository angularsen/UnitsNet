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
using UnitsNet.NumberExtensions.NumberToMagneticField;
using Xunit;

namespace UnitsNet.Tests
{
    public class NumberToMagneticFieldExtensionsTests
    {
        [Fact]
        public void NumberToGaussesTest() =>
            Assert.Equal(MagneticField.FromGausses(2), 2.Gausses());

        [Fact]
        public void NumberToMicroteslasTest() =>
            Assert.Equal(MagneticField.FromMicroteslas(2), 2.Microteslas());

        [Fact]
        public void NumberToMilligaussesTest() =>
            Assert.Equal(MagneticField.FromMilligausses(2), 2.Milligausses());

        [Fact]
        public void NumberToMilliteslasTest() =>
            Assert.Equal(MagneticField.FromMilliteslas(2), 2.Milliteslas());

        [Fact]
        public void NumberToNanoteslasTest() =>
            Assert.Equal(MagneticField.FromNanoteslas(2), 2.Nanoteslas());

        [Fact]
        public void NumberToTeslasTest() =>
            Assert.Equal(MagneticField.FromTeslas(2), 2.Teslas());

    }
}
