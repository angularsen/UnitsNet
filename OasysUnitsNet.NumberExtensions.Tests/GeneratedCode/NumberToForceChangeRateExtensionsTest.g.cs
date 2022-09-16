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

using OasysUnitsNet.NumberExtensions.NumberToForceChangeRate;
using Xunit;

namespace OasysUnitsNet.Tests
{
    public class NumberToForceChangeRateExtensionsTests
    {
        [Fact]
        public void NumberToCentinewtonsPerSecondTest() =>
            Assert.Equal(ForceChangeRate.FromCentinewtonsPerSecond(2), 2.CentinewtonsPerSecond());

        [Fact]
        public void NumberToDecanewtonsPerMinuteTest() =>
            Assert.Equal(ForceChangeRate.FromDecanewtonsPerMinute(2), 2.DecanewtonsPerMinute());

        [Fact]
        public void NumberToDecanewtonsPerSecondTest() =>
            Assert.Equal(ForceChangeRate.FromDecanewtonsPerSecond(2), 2.DecanewtonsPerSecond());

        [Fact]
        public void NumberToDecinewtonsPerSecondTest() =>
            Assert.Equal(ForceChangeRate.FromDecinewtonsPerSecond(2), 2.DecinewtonsPerSecond());

        [Fact]
        public void NumberToKilonewtonsPerMinuteTest() =>
            Assert.Equal(ForceChangeRate.FromKilonewtonsPerMinute(2), 2.KilonewtonsPerMinute());

        [Fact]
        public void NumberToKilonewtonsPerSecondTest() =>
            Assert.Equal(ForceChangeRate.FromKilonewtonsPerSecond(2), 2.KilonewtonsPerSecond());

        [Fact]
        public void NumberToKilopoundsForcePerMinuteTest() =>
            Assert.Equal(ForceChangeRate.FromKilopoundsForcePerMinute(2), 2.KilopoundsForcePerMinute());

        [Fact]
        public void NumberToKilopoundsForcePerSecondTest() =>
            Assert.Equal(ForceChangeRate.FromKilopoundsForcePerSecond(2), 2.KilopoundsForcePerSecond());

        [Fact]
        public void NumberToMicronewtonsPerSecondTest() =>
            Assert.Equal(ForceChangeRate.FromMicronewtonsPerSecond(2), 2.MicronewtonsPerSecond());

        [Fact]
        public void NumberToMillinewtonsPerSecondTest() =>
            Assert.Equal(ForceChangeRate.FromMillinewtonsPerSecond(2), 2.MillinewtonsPerSecond());

        [Fact]
        public void NumberToNanonewtonsPerSecondTest() =>
            Assert.Equal(ForceChangeRate.FromNanonewtonsPerSecond(2), 2.NanonewtonsPerSecond());

        [Fact]
        public void NumberToNewtonsPerMinuteTest() =>
            Assert.Equal(ForceChangeRate.FromNewtonsPerMinute(2), 2.NewtonsPerMinute());

        [Fact]
        public void NumberToNewtonsPerSecondTest() =>
            Assert.Equal(ForceChangeRate.FromNewtonsPerSecond(2), 2.NewtonsPerSecond());

        [Fact]
        public void NumberToPoundsForcePerMinuteTest() =>
            Assert.Equal(ForceChangeRate.FromPoundsForcePerMinute(2), 2.PoundsForcePerMinute());

        [Fact]
        public void NumberToPoundsForcePerSecondTest() =>
            Assert.Equal(ForceChangeRate.FromPoundsForcePerSecond(2), 2.PoundsForcePerSecond());

    }
}
