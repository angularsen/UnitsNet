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

using OasysUnitsNet.NumberExtensions.NumberToRatio;
using Xunit;

namespace OasysUnitsNet.Tests
{
    public class NumberToRatioExtensionsTests
    {
        [Fact]
        public void NumberToDecimalFractionsTest() =>
            Assert.Equal(Ratio.FromDecimalFractions(2), 2.DecimalFractions());

        [Fact]
        public void NumberToPartsPerBillionTest() =>
            Assert.Equal(Ratio.FromPartsPerBillion(2), 2.PartsPerBillion());

        [Fact]
        public void NumberToPartsPerMillionTest() =>
            Assert.Equal(Ratio.FromPartsPerMillion(2), 2.PartsPerMillion());

        [Fact]
        public void NumberToPartsPerThousandTest() =>
            Assert.Equal(Ratio.FromPartsPerThousand(2), 2.PartsPerThousand());

        [Fact]
        public void NumberToPartsPerTrillionTest() =>
            Assert.Equal(Ratio.FromPartsPerTrillion(2), 2.PartsPerTrillion());

        [Fact]
        public void NumberToPercentTest() =>
            Assert.Equal(Ratio.FromPercent(2), 2.Percent());

    }
}
