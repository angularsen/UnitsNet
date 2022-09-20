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

using OasysUnits.NumberExtensions.NumberToStrain;
using Xunit;

namespace OasysUnits.Tests
{
    public class NumberToStrainExtensionsTests
    {
        [Fact]
        public void NumberToMicroStrainTest() =>
            Assert.Equal(Strain.FromMicroStrain(2), 2.MicroStrain());

        [Fact]
        public void NumberToMilliStrainTest() =>
            Assert.Equal(Strain.FromMilliStrain(2), 2.MilliStrain());

        [Fact]
        public void NumberToPercentTest() =>
            Assert.Equal(Strain.FromPercent(2), 2.Percent());

        [Fact]
        public void NumberToRatioTest() =>
            Assert.Equal(Strain.FromRatio(2), 2.Ratio());

    }
}
