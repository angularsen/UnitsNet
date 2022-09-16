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

using System;
using Xunit;

namespace OasysUnitsNet.Tests.CustomCode
{
    public class BendingStiffnessTests : BendingStiffnessTestsBase
    {
        protected override bool SupportsSIUnitSystem => true;

        protected override double KilonewtonSquareMetersInOneNewtonSquareMeter => 1e-3;

        protected override double KilonewtonSquareMillimetersInOneNewtonSquareMeter => 1e3;

        protected override double NewtonSquareMetersInOneNewtonSquareMeter => 1;

        protected override double NewtonSquareMillimetersInOneNewtonSquareMeter => 1e6;

        protected override double PoundsForceSquareFeetInOneNewtonSquareMeter => 1 / (4.4482216152605095551842641431421 * 0.3048 * 0.3048);

        protected override double PoundsForceSquareInchesInOneNewtonSquareMeter => 1 / (4.4482216152605095551842641431421 * 2.54e-2 * 2.54e-2);

        [Fact]
        public void BendingStiffnessTimesCurvatureEqualsMoment()
        {
            Moment moment = BendingStiffness.FromNewtonSquareMeters(2) * Curvature.FromPerMeters(2);
            Assert.Equal(moment, Moment.FromNewtonMeters(4));
        }
    }
}
