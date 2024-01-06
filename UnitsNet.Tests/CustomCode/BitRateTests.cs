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

namespace UnitsNet.Tests.CustomCode
{
    public class BitRateTests : BitRateTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;

        protected override double BitsPerSecondInOneBitPerSecond => 1;
        protected override double BytesPerSecondInOneBitPerSecond => 1.25E-1;

        protected override double KilobitsPerSecondInOneBitPerSecond => 1E-3;
        protected override double KilobytesPerSecondInOneBitPerSecond => 1.25E-4;
        protected override double KibibitsPerSecondInOneBitPerSecond => 0.0009765625;
        protected override double KibibytesPerSecondInOneBitPerSecond => 0.0001220703125;

        protected override double MegabitsPerSecondInOneBitPerSecond => 1E-6;
        protected override double MegabytesPerSecondInOneBitPerSecond => 1.25E-07;
        protected override double MebibitsPerSecondInOneBitPerSecond => 9.5367431640625E-07;
        protected override double MebibytesPerSecondInOneBitPerSecond => 1.19209289550781E-07;

        protected override double GigabitsPerSecondInOneBitPerSecond => 1E-9;
        protected override double GigabytesPerSecondInOneBitPerSecond => 1.25E-10;
        protected override double GibibitsPerSecondInOneBitPerSecond => 9.31322574615479E-10;
        protected override double GibibytesPerSecondInOneBitPerSecond => 1.16415321826935E-10;

        protected override double TerabitsPerSecondInOneBitPerSecond => 1E-12;
        protected override double TerabytesPerSecondInOneBitPerSecond => 1.25E-13;
        protected override double TebibitsPerSecondInOneBitPerSecond => 9.09494701772928E-13;
        protected override double TebibytesPerSecondInOneBitPerSecond => 1.13686837721616E-13;

        protected override double PetabitsPerSecondInOneBitPerSecond => 1E-15;
        protected override double PetabytesPerSecondInOneBitPerSecond => 1.25E-16;
        protected override double PebibitsPerSecondInOneBitPerSecond => 8.88178419700125E-16;
        protected override double PebibytesPerSecondInOneBitPerSecond => 1.11022302462516E-16;

        protected override double ExabitsPerSecondInOneBitPerSecond => 1E-18;
        protected override double ExabytesPerSecondInOneBitPerSecond => 1.25E-19;
        protected override double ExbibitsPerSecondInOneBitPerSecond => 8.67361738E-19;
        protected override double ExbibytesPerSecondInOneBitPerSecond => 1.0842021724855E-19;
    }
}
