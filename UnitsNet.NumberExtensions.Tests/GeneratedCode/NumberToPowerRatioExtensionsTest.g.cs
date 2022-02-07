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
using UnitsNet.NumberExtensions.NumberToPowerRatio;
using Xunit;

namespace UnitsNet.Tests
{
    public class NumberToPowerRatioExtensionsTests
    {
        [Fact]
        public void NumberToDecibelMilliwattsTest() =>
            Assert.Equal(PowerRatio.FromDecibelMilliwatts(2), 2.DecibelMilliwatts());

        [Fact]
        public void NumberToDecibelWattsTest() =>
            Assert.Equal(PowerRatio.FromDecibelWatts(2), 2.DecibelWatts());

    }
}
