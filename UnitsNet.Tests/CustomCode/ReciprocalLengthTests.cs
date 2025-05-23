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
        protected override double InverseMetersInOneInverseMeter => 1;
        protected override double InverseCentimetersInOneInverseMeter => 1E-2;
        protected override double InverseMillimetersInOneInverseMeter => 1E-3;

        protected override double InverseMilesInOneInverseMeter => 1609.344;
        protected override double InverseYardsInOneInverseMeter => 0.914402;
        protected override double InverseFeetInOneInverseMeter => 0.3048;

        protected override double InverseUsSurveyFeetInOneInverseMeter => 0.3048;

        protected override double InverseInchesInOneInverseMeter => 2.54E-2;
        protected override double InverseMilsInOneInverseMeter => 2.54E-5;
        protected override double InverseMicroinchesInOneInverseMeter => 2.54E-8;

        [Theory]
        [InlineData(-1.0, -1.0)]
        [InlineData(-2.0, -0.5)]
        [InlineData(0.0, double.PositiveInfinity)]
        [InlineData(1.0, 1.0)]
        [InlineData(2.0, 0.5)]
        public static void InverseReturnsLength(double value, double expected)
        {
            var inverseLength = new ReciprocalLength(value, ReciprocalLengthUnit.InverseMeter);
            var length = inverseLength.Inverse();

            Assert.Equal(expected, length.Meters);
        }

        [Fact]
        public static void ForcePerLengthTimesReciprocalLengthEqualsPressure()
        {
            Pressure pressure = ForcePerLength.FromNewtonsPerMeter(10) * ReciprocalLength.FromInverseMeters(5);
            Assert.Equal(pressure, Pressure.FromNewtonsPerSquareMeter(50));
        }

        [Fact]
        public static void ForcePerLengthDividedByReciprocalLengthEqualsForce()
        {
            Force force = ForcePerLength.FromNewtonsPerMeter(10) / ReciprocalLength.FromInverseMeters(5);
            Assert.Equal(force, Force.FromNewtons(2));
        }

        [Fact]
        public static void ForceTimesReciprocalLengthEqualsForcePerLength()
        {
            ForcePerLength forcePerLength = Force.FromNewtons(10) * ReciprocalLength.FromInverseMeters(5);
            Assert.Equal(forcePerLength, ForcePerLength.FromNewtonsPerMeter(50));
        }

        [Fact]
        public static void PressureDividedByReciprocalLengthEqualsForcePerLength()
        {
            ForcePerLength forcePerLength = Pressure.FromPascals(50) / ReciprocalLength.FromInverseMeters(5);
            Assert.Equal(forcePerLength, ForcePerLength.FromNewtonsPerMeter(10));
        }

        [Fact]
        public static void ReciprocalLengthTimesForcePerLengthEqualsPressure()
        {
            Pressure pressure = ReciprocalLength.FromInverseMeters(5) *ForcePerLength.FromNewtonsPerMeter(10);
            Assert.Equal(pressure, Pressure.FromNewtonsPerSquareMeter(50));
        }

        [Fact]
        public static void ReciprocalLengthTimesForceEqualsForcePerLength()
        {
            ForcePerLength forcePerLength = ReciprocalLength.FromInverseMeters(5) * Force.FromNewtons(10);
            Assert.Equal(forcePerLength, ForcePerLength.FromNewtonsPerMeter(50));
        }

        [Fact]
        public void ReciprocalLengthTimesReciprocalLengthEqualsReciprocalArea()
        {
            ReciprocalArea reciprocalArea = ReciprocalLength.FromInverseMeters(10) * ReciprocalLength.FromInverseMeters(20);
            Assert.Equal(reciprocalArea, ReciprocalArea.FromInverseSquareMeters(200));
        }

        [Fact]
        public void ReciprocalLengthDividedByReciprocalAreaEqualsLength()
        {
            Length length = ReciprocalLength.FromInverseMeters(5) / ReciprocalArea.FromInverseSquareMeters(10);
            Assert.Equal(length, Length.FromMeters(0.5));
        }
    }
}
