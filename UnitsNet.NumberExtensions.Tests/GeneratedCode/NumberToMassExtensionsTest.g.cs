﻿//------------------------------------------------------------------------------
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

using UnitsNet.NumberExtensions.NumberToMass;
using Xunit;

namespace UnitsNet.Tests
{
    public class NumberToMassExtensionsTests
    {
        [Fact]
        public void NumberToCentigramsTest() =>
            Assert.Equal(Mass<double>.FromCentigrams(2), 2.Centigrams());

        [Fact]
        public void NumberToDecagramsTest() =>
            Assert.Equal(Mass<double>.FromDecagrams(2), 2.Decagrams());

        [Fact]
        public void NumberToDecigramsTest() =>
            Assert.Equal(Mass<double>.FromDecigrams(2), 2.Decigrams());

        [Fact]
        public void NumberToEarthMassesTest() =>
            Assert.Equal(Mass<double>.FromEarthMasses(2), 2.EarthMasses());

        [Fact]
        public void NumberToGrainsTest() =>
            Assert.Equal(Mass<double>.FromGrains(2), 2.Grains());

        [Fact]
        public void NumberToGramsTest() =>
            Assert.Equal(Mass<double>.FromGrams(2), 2.Grams());

        [Fact]
        public void NumberToHectogramsTest() =>
            Assert.Equal(Mass<double>.FromHectograms(2), 2.Hectograms());

        [Fact]
        public void NumberToKilogramsTest() =>
            Assert.Equal(Mass<double>.FromKilograms(2), 2.Kilograms());

        [Fact]
        public void NumberToKilopoundsTest() =>
            Assert.Equal(Mass<double>.FromKilopounds(2), 2.Kilopounds());

        [Fact]
        public void NumberToKilotonnesTest() =>
            Assert.Equal(Mass<double>.FromKilotonnes(2), 2.Kilotonnes());

        [Fact]
        public void NumberToLongHundredweightTest() =>
            Assert.Equal(Mass<double>.FromLongHundredweight(2), 2.LongHundredweight());

        [Fact]
        public void NumberToLongTonsTest() =>
            Assert.Equal(Mass<double>.FromLongTons(2), 2.LongTons());

        [Fact]
        public void NumberToMegapoundsTest() =>
            Assert.Equal(Mass<double>.FromMegapounds(2), 2.Megapounds());

        [Fact]
        public void NumberToMegatonnesTest() =>
            Assert.Equal(Mass<double>.FromMegatonnes(2), 2.Megatonnes());

        [Fact]
        public void NumberToMicrogramsTest() =>
            Assert.Equal(Mass<double>.FromMicrograms(2), 2.Micrograms());

        [Fact]
        public void NumberToMilligramsTest() =>
            Assert.Equal(Mass<double>.FromMilligrams(2), 2.Milligrams());

        [Fact]
        public void NumberToNanogramsTest() =>
            Assert.Equal(Mass<double>.FromNanograms(2), 2.Nanograms());

        [Fact]
        public void NumberToOuncesTest() =>
            Assert.Equal(Mass<double>.FromOunces(2), 2.Ounces());

        [Fact]
        public void NumberToPoundsTest() =>
            Assert.Equal(Mass<double>.FromPounds(2), 2.Pounds());

        [Fact]
        public void NumberToShortHundredweightTest() =>
            Assert.Equal(Mass<double>.FromShortHundredweight(2), 2.ShortHundredweight());

        [Fact]
        public void NumberToShortTonsTest() =>
            Assert.Equal(Mass<double>.FromShortTons(2), 2.ShortTons());

        [Fact]
        public void NumberToSlugsTest() =>
            Assert.Equal(Mass<double>.FromSlugs(2), 2.Slugs());

        [Fact]
        public void NumberToSolarMassesTest() =>
            Assert.Equal(Mass<double>.FromSolarMasses(2), 2.SolarMasses());

        [Fact]
        public void NumberToStoneTest() =>
            Assert.Equal(Mass<double>.FromStone(2), 2.Stone());

        [Fact]
        public void NumberToTonnesTest() =>
            Assert.Equal(Mass<double>.FromTonnes(2), 2.Tonnes());

    }
}
