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

using UnitsNet.NumberExtensions.NumberToRadiationEquivalentDose;
using Xunit;

namespace UnitsNet.Tests
{
    public class NumberToRadiationEquivalentDoseExtensionsTests
    {
        [Fact]
        public void NumberToMicrosievertsTest() =>
            Assert.Equal(RadiationEquivalentDose.FromMicrosieverts(2), 2.Microsieverts());

        [Fact]
        public void NumberToMilliroentgensEquivalentManTest() =>
            Assert.Equal(RadiationEquivalentDose.FromMilliroentgensEquivalentMan(2), 2.MilliroentgensEquivalentMan());

        [Fact]
        public void NumberToMillisievertsTest() =>
            Assert.Equal(RadiationEquivalentDose.FromMillisieverts(2), 2.Millisieverts());

        [Fact]
        public void NumberToNanosievertsTest() =>
            Assert.Equal(RadiationEquivalentDose.FromNanosieverts(2), 2.Nanosieverts());

        [Fact]
        public void NumberToRoentgensEquivalentManTest() =>
            Assert.Equal(RadiationEquivalentDose.FromRoentgensEquivalentMan(2), 2.RoentgensEquivalentMan());

        [Fact]
        public void NumberToSievertsTest() =>
            Assert.Equal(RadiationEquivalentDose.FromSieverts(2), 2.Sieverts());

    }
}
