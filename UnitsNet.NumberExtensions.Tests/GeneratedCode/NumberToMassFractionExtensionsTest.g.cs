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

using UnitsNet.NumberExtensions.NumberToMassFraction;
using Xunit;

namespace UnitsNet.Tests
{
    public class NumberToMassFractionExtensionsTests
    {
        [Fact]
        public void NumberToCentigramsPerGramTest() =>
            Assert.Equal(MassFraction<double>.FromCentigramsPerGram(2), 2.CentigramsPerGram());

        [Fact]
        public void NumberToCentigramsPerKilogramTest() =>
            Assert.Equal(MassFraction<double>.FromCentigramsPerKilogram(2), 2.CentigramsPerKilogram());

        [Fact]
        public void NumberToDecagramsPerGramTest() =>
            Assert.Equal(MassFraction<double>.FromDecagramsPerGram(2), 2.DecagramsPerGram());

        [Fact]
        public void NumberToDecagramsPerKilogramTest() =>
            Assert.Equal(MassFraction<double>.FromDecagramsPerKilogram(2), 2.DecagramsPerKilogram());

        [Fact]
        public void NumberToDecigramsPerGramTest() =>
            Assert.Equal(MassFraction<double>.FromDecigramsPerGram(2), 2.DecigramsPerGram());

        [Fact]
        public void NumberToDecigramsPerKilogramTest() =>
            Assert.Equal(MassFraction<double>.FromDecigramsPerKilogram(2), 2.DecigramsPerKilogram());

        [Fact]
        public void NumberToDecimalFractionsTest() =>
            Assert.Equal(MassFraction<double>.FromDecimalFractions(2), 2.DecimalFractions());

        [Fact]
        public void NumberToGramsPerGramTest() =>
            Assert.Equal(MassFraction<double>.FromGramsPerGram(2), 2.GramsPerGram());

        [Fact]
        public void NumberToGramsPerKilogramTest() =>
            Assert.Equal(MassFraction<double>.FromGramsPerKilogram(2), 2.GramsPerKilogram());

        [Fact]
        public void NumberToHectogramsPerGramTest() =>
            Assert.Equal(MassFraction<double>.FromHectogramsPerGram(2), 2.HectogramsPerGram());

        [Fact]
        public void NumberToHectogramsPerKilogramTest() =>
            Assert.Equal(MassFraction<double>.FromHectogramsPerKilogram(2), 2.HectogramsPerKilogram());

        [Fact]
        public void NumberToKilogramsPerGramTest() =>
            Assert.Equal(MassFraction<double>.FromKilogramsPerGram(2), 2.KilogramsPerGram());

        [Fact]
        public void NumberToKilogramsPerKilogramTest() =>
            Assert.Equal(MassFraction<double>.FromKilogramsPerKilogram(2), 2.KilogramsPerKilogram());

        [Fact]
        public void NumberToMicrogramsPerGramTest() =>
            Assert.Equal(MassFraction<double>.FromMicrogramsPerGram(2), 2.MicrogramsPerGram());

        [Fact]
        public void NumberToMicrogramsPerKilogramTest() =>
            Assert.Equal(MassFraction<double>.FromMicrogramsPerKilogram(2), 2.MicrogramsPerKilogram());

        [Fact]
        public void NumberToMilligramsPerGramTest() =>
            Assert.Equal(MassFraction<double>.FromMilligramsPerGram(2), 2.MilligramsPerGram());

        [Fact]
        public void NumberToMilligramsPerKilogramTest() =>
            Assert.Equal(MassFraction<double>.FromMilligramsPerKilogram(2), 2.MilligramsPerKilogram());

        [Fact]
        public void NumberToNanogramsPerGramTest() =>
            Assert.Equal(MassFraction<double>.FromNanogramsPerGram(2), 2.NanogramsPerGram());

        [Fact]
        public void NumberToNanogramsPerKilogramTest() =>
            Assert.Equal(MassFraction<double>.FromNanogramsPerKilogram(2), 2.NanogramsPerKilogram());

        [Fact]
        public void NumberToPartsPerBillionTest() =>
            Assert.Equal(MassFraction<double>.FromPartsPerBillion(2), 2.PartsPerBillion());

        [Fact]
        public void NumberToPartsPerMillionTest() =>
            Assert.Equal(MassFraction<double>.FromPartsPerMillion(2), 2.PartsPerMillion());

        [Fact]
        public void NumberToPartsPerThousandTest() =>
            Assert.Equal(MassFraction<double>.FromPartsPerThousand(2), 2.PartsPerThousand());

        [Fact]
        public void NumberToPartsPerTrillionTest() =>
            Assert.Equal(MassFraction<double>.FromPartsPerTrillion(2), 2.PartsPerTrillion());

        [Fact]
        public void NumberToPercentTest() =>
            Assert.Equal(MassFraction<double>.FromPercent(2), 2.Percent());

    }
}
