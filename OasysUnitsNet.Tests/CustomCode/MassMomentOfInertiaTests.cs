﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated (once) by \generate-code.bat, but will not be
//     regenerated when it already exists. The purpose of creating this file is to make
//     it easier to remember to implement all the unit conversion test cases.
//
//     Whenever a new unit is added to this unit class and \generate-code.bat is run,
//     the base test class will get a new abstract property and cause a compile error
//     in this derived class, reminding the developer to implement the test case
//     for the new unit.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\UnitClasses\MyQuantity.extra.cs files to add code to generated unit classes.
//     Add UnitDefinitions\MyQuantity.json and run GeneratUnits.bat to generate new units or unit classes.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.


using System;

namespace OasysUnitsNet.Tests.CustomCode
{
    public class MassMomentOfInertiaTests : MassMomentOfInertiaTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;

        protected override double GramSquareCentimetersInOneKilogramSquareMeter => 1e7;

        protected override double GramSquareDecimetersInOneKilogramSquareMeter => 1e5;

        protected override double GramSquareMetersInOneKilogramSquareMeter => 1e3;

        protected override double GramSquareMillimetersInOneKilogramSquareMeter => 1e9;

        protected override double KilogramSquareCentimetersInOneKilogramSquareMeter => 1e4;

        protected override double KilogramSquareDecimetersInOneKilogramSquareMeter => 1e2;

        protected override double KilogramSquareMetersInOneKilogramSquareMeter => 1;

        protected override double KilogramSquareMillimetersInOneKilogramSquareMeter => 1e6;

        protected override double MilligramSquareCentimetersInOneKilogramSquareMeter => 1e10;

        protected override double MilligramSquareDecimetersInOneKilogramSquareMeter => 1e8;

        protected override double MilligramSquareMetersInOneKilogramSquareMeter => 1e6;

        protected override double MilligramSquareMillimetersInOneKilogramSquareMeter => 1e12;

        protected override double PoundSquareFeetInOneKilogramSquareMeter => 1 / 4.21401101e-2;

        protected override double PoundSquareInchesInOneKilogramSquareMeter => 1 / 2.9263965e-4;

        protected override double SlugSquareFeetInOneKilogramSquareMeter => 1 / 1.3558179619;

        protected override double SlugSquareInchesInOneKilogramSquareMeter => 1 / 9.41540242e-3;

        protected override double KilotonneSquareCentimetersInOneKilogramSquareMeter => 1e-2;

        protected override double KilotonneSquareDecimetersInOneKilogramSquareMeter => 1e-4;

        protected override double KilotonneSquareMetersInOneKilogramSquareMeter => 1e-6;

        protected override double KilotonneSquareMilimetersInOneKilogramSquareMeter => 1e0;

        protected override double MegatonneSquareCentimetersInOneKilogramSquareMeter => 1e-5;

        protected override double MegatonneSquareDecimetersInOneKilogramSquareMeter => 1e-7;

        protected override double MegatonneSquareMetersInOneKilogramSquareMeter => 1e-9;

        protected override double MegatonneSquareMilimetersInOneKilogramSquareMeter => 1e-3;

        protected override double TonneSquareCentimetersInOneKilogramSquareMeter => 1e1;

        protected override double TonneSquareDecimetersInOneKilogramSquareMeter => 1e-1;

        protected override double TonneSquareMetersInOneKilogramSquareMeter => 1e-3;

        protected override double TonneSquareMilimetersInOneKilogramSquareMeter => 1e3;
    }
}
