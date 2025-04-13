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

namespace UnitsNet.Tests.CustomCode
{
    public class SpecificEntropyTests : SpecificEntropyTestsBase
    {
        protected override double JoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin => 1e0;
        protected override double JoulesPerKilogramKelvinInOneJoulePerKilogramKelvin => 1e0;
        protected override double KilojoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin => 1e-3;
        protected override double KilojoulesPerKilogramKelvinInOneJoulePerKilogramKelvin => 1e-3;
        protected override double MegajoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin => 1e-6;
        protected override double MegajoulesPerKilogramKelvinInOneJoulePerKilogramKelvin => 1e-6;
        protected override double CaloriesPerGramKelvinInOneJoulePerKilogramKelvin => 2.390057e-4;
        protected override double KilocaloriesPerGramKelvinInOneJoulePerKilogramKelvin => 2.390057e-7;
        protected override double BtusPerPoundFahrenheitInOneJoulePerKilogramKelvin => 2.3884589662749594e-4;

        [Fact]
        public void SpecificEntropyTimesMassEqualsEntropy()
        {
            Entropy e = SpecificEntropy.FromJoulesPerKilogramKelvin(24) * Mass.FromKilograms(2);
            Assert.Equal(Entropy.FromJoulesPerKelvin(48), e);
        }

        [Fact]
        public void MassTimesSpecificEntropyEqualsEntropy()
        {
            Entropy e = Mass.FromKilograms(5) * SpecificEntropy.FromJoulesPerKilogramKelvin(7);
            Assert.Equal(Entropy.FromJoulesPerKelvin(35), e);
        }
    }
}
