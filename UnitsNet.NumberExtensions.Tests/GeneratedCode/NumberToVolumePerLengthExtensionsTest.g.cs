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
using UnitsNet.NumberExtensions.NumberToVolumePerLength;
using Xunit;

namespace UnitsNet.Tests
{
    public class NumberToVolumePerLengthExtensionsTests
    {
        [Fact]
        public void NumberToCubicMetersPerMeterTest() =>
            Assert.Equal(VolumePerLength.FromCubicMetersPerMeter(2), 2.CubicMetersPerMeter());

        [Fact]
        public void NumberToCubicYardsPerFootTest() =>
            Assert.Equal(VolumePerLength.FromCubicYardsPerFoot(2), 2.CubicYardsPerFoot());

        [Fact]
        public void NumberToCubicYardsPerUsSurveyFootTest() =>
            Assert.Equal(VolumePerLength.FromCubicYardsPerUsSurveyFoot(2), 2.CubicYardsPerUsSurveyFoot());

        [Fact]
        public void NumberToLitersPerKilometerTest() =>
            Assert.Equal(VolumePerLength.FromLitersPerKilometer(2), 2.LitersPerKilometer());

        [Fact]
        public void NumberToLitersPerMeterTest() =>
            Assert.Equal(VolumePerLength.FromLitersPerMeter(2), 2.LitersPerMeter());

        [Fact]
        public void NumberToLitersPerMillimeterTest() =>
            Assert.Equal(VolumePerLength.FromLitersPerMillimeter(2), 2.LitersPerMillimeter());

        [Fact]
        public void NumberToOilBarrelsPerFootTest() =>
            Assert.Equal(VolumePerLength.FromOilBarrelsPerFoot(2), 2.OilBarrelsPerFoot());

    }
}
