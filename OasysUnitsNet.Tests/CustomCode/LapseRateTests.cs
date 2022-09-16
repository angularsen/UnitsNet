﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated (once) by \generate-code.bat, but will not be
//     regenerated when it already exists. The purpose of creating this file is to make
//     it easier to remember to implement all the unit conversion test cases.
//
//     Whenever a new unit is added to this quantity and \generate-code.bat is run,
//     the base test class will get a new abstract property and cause a compile error
//     in this derived class, reminding the developer to implement the test case
//     for the new unit.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run GeneratUnits.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.


using System;
using Xunit;

namespace OasysUnitsNet.Tests.CustomCode
{
    public class LapseRateTests : LapseRateTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;
        protected override double DegreesCelciusPerKilometerInOneDegreeCelsiusPerKilometer => 1e0;

        [Fact]
        public void TemperatureDeltaDividedByLapseRateEqualsLength()
        {
            Length length = TemperatureDelta.FromDegreesCelsius(50) / LapseRate.FromDegreesCelciusPerKilometer(5);
            Assert.Equal(length, Length.FromKilometers(10));
        }

        [Fact]
        public void LengthMultipliedByLapseRateEqualsTemperatureDelta()
        {
            TemperatureDelta temperatureDelta = Length.FromKilometers(10) * LapseRate.FromDegreesCelciusPerKilometer(5);
            Assert.Equal(temperatureDelta, TemperatureDelta.FromDegreesCelsius(50));
        }

        [Fact]
        public void LapseRateMultipliedByLengthEqualsTemperatureDelta()
        {
            TemperatureDelta temperatureDelta = LapseRate.FromDegreesCelciusPerKilometer(5) * Length.FromKilometers(10);
            Assert.Equal(temperatureDelta, TemperatureDelta.FromDegreesCelsius(50));
        }
    }
}
