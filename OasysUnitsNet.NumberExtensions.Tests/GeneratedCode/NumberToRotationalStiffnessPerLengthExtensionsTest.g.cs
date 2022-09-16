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

using OasysUnitsNet.NumberExtensions.NumberToRotationalStiffnessPerLength;
using Xunit;

namespace OasysUnitsNet.Tests
{
    public class NumberToRotationalStiffnessPerLengthExtensionsTests
    {
        [Fact]
        public void NumberToKilonewtonMetersPerRadianPerMeterTest() =>
            Assert.Equal(RotationalStiffnessPerLength.FromKilonewtonMetersPerRadianPerMeter(2), 2.KilonewtonMetersPerRadianPerMeter());

        [Fact]
        public void NumberToKilopoundForceFeetPerDegreesPerFeetTest() =>
            Assert.Equal(RotationalStiffnessPerLength.FromKilopoundForceFeetPerDegreesPerFeet(2), 2.KilopoundForceFeetPerDegreesPerFeet());

        [Fact]
        public void NumberToMeganewtonMetersPerRadianPerMeterTest() =>
            Assert.Equal(RotationalStiffnessPerLength.FromMeganewtonMetersPerRadianPerMeter(2), 2.MeganewtonMetersPerRadianPerMeter());

        [Fact]
        public void NumberToNewtonMetersPerRadianPerMeterTest() =>
            Assert.Equal(RotationalStiffnessPerLength.FromNewtonMetersPerRadianPerMeter(2), 2.NewtonMetersPerRadianPerMeter());

        [Fact]
        public void NumberToPoundForceFeetPerDegreesPerFeetTest() =>
            Assert.Equal(RotationalStiffnessPerLength.FromPoundForceFeetPerDegreesPerFeet(2), 2.PoundForceFeetPerDegreesPerFeet());

    }
}
