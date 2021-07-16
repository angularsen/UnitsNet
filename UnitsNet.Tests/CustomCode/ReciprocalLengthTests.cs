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

using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class ReciprocalLengthTests : ReciprocalLengthTestsBase
    {
        protected override bool SupportsSIUnitSystem => false;

        protected override double InverseMeterInOneInverseMeter => 1;
        protected override double InverseCentimeterInOneInverseMeter => 1E-2;
        protected override double InverseMillimeterInOneInverseMeter => 1E-3;

        protected override double InverseMileInOneInverseMeter => 1 / 0.000621371;
        protected override double InverseYardInOneInverseMeter => 1 / 1.09361;
        protected override double InverseFootInOneInverseMeter => 1 / 3.28084;

        protected override double InverseUsSurveyFeetInOneInverseMeter => 1 / 3.280833333333333;

        protected override double InverseInchInOneInverseMeter => 1 / 39.37007874;
        protected override double InverseMilInOneInverseMeter => 1 / 39370.07874015;
        protected override double InverseMicroinchInOneInverseMeter => 1 / 39370078.74015748;

        [Theory]
        [InlineData(-1.0, -1.0)]
        [InlineData(-2.0, -0.5)]
        [InlineData(0.0, 0.0)]
        [InlineData(1.0, 1.0)]
        [InlineData(2.0, 0.5)]
        public static void InverseTest(double value, double expected)
        {
            var inverseLength = new ReciprocalLength(value, ReciprocalLengthUnit.InverseMeter);
            var length = inverseLength.Inverse();

            AssertEx.Equals(expected, length.Meters);
        }

        [Fact]
        public static void ForcePerLengthTimesReciprocalLengthEqualsPressure()
        {
            Pressure pressure = ForcePerLength.FromNewtonsPerMeter(10) * ReciprocalLength.FromInverseMeter(5);
            Assert.Equal(pressure, Pressure.FromNewtonsPerSquareMeter(50));
        }

        [Fact]
        public static void ForcePerLengthDividedByReciprocalLengthEqualsForce()
        {
            Force force = ForcePerLength.FromNewtonsPerMeter(10) / ReciprocalLength.FromInverseMeter(5);
            Assert.Equal(force, Force.FromNewtons(2));
        }
    }
}
