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

using OasysUnitsNet.NumberExtensions.NumberToTemperature;
using Xunit;

namespace OasysUnitsNet.Tests
{
    public class NumberToTemperatureExtensionsTests
    {
        [Fact]
        public void NumberToDegreesCelsiusTest() =>
            Assert.Equal(Temperature.FromDegreesCelsius(2), 2.DegreesCelsius());

        [Fact]
        public void NumberToDegreesDelisleTest() =>
            Assert.Equal(Temperature.FromDegreesDelisle(2), 2.DegreesDelisle());

        [Fact]
        public void NumberToDegreesFahrenheitTest() =>
            Assert.Equal(Temperature.FromDegreesFahrenheit(2), 2.DegreesFahrenheit());

        [Fact]
        public void NumberToDegreesNewtonTest() =>
            Assert.Equal(Temperature.FromDegreesNewton(2), 2.DegreesNewton());

        [Fact]
        public void NumberToDegreesRankineTest() =>
            Assert.Equal(Temperature.FromDegreesRankine(2), 2.DegreesRankine());

        [Fact]
        public void NumberToDegreesReaumurTest() =>
            Assert.Equal(Temperature.FromDegreesReaumur(2), 2.DegreesReaumur());

        [Fact]
        public void NumberToDegreesRoemerTest() =>
            Assert.Equal(Temperature.FromDegreesRoemer(2), 2.DegreesRoemer());

        [Fact]
        public void NumberToKelvinsTest() =>
            Assert.Equal(Temperature.FromKelvins(2), 2.Kelvins());

        [Fact]
        public void NumberToMillidegreesCelsiusTest() =>
            Assert.Equal(Temperature.FromMillidegreesCelsius(2), 2.MillidegreesCelsius());

        [Fact]
        public void NumberToSolarTemperaturesTest() =>
            Assert.Equal(Temperature.FromSolarTemperatures(2), 2.SolarTemperatures());

    }
}
