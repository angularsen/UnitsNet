// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.CustomCode.Units;
using UnitsNet.CustomCode.Wrappers;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class PressureTests : PressureTestsBase
    {
        protected override double AtmospheresInOnePascal => 9.8692 * 1E-6;

        protected override double BarsInOnePascal => 1E-5;

        protected override double KilogramsForcePerSquareCentimeterInOnePascal => 1.019716212977928e-5;

        protected override double KilogramsForcePerSquareMeterInOnePascal => 0.101971621;

        protected override double KilogramsForcePerSquareMillimeterInOnePascal => 1.019716212977928e-7;

        protected override double KilonewtonsPerSquareCentimeterInOnePascal => 1e-7;

        protected override double KilonewtonsPerSquareMeterInOnePascal => 0.001;

        protected override double KilonewtonsPerSquareMillimeterInOnePascal => 1e-9;

        protected override double KilopascalsInOnePascal => 1e-3;

        protected override double KilopoundsForcePerSquareFootInOnePascal => 2.088543423315013e-5;

        protected override double KilopoundsForcePerSquareInchInOnePascal => 1.450377377302092e-7;

        protected override double MegapascalsInOnePascal => 1E-6;

        protected override double MetersOfHeadInOnePascal => 0.00010199773339984054;

        protected override double MeganewtonsPerSquareMeterInOnePascal => 1E-6;

        protected override double NewtonsPerSquareCentimeterInOnePascal => 1E-4;

        protected override double NewtonsPerSquareMeterInOnePascal => 1;

        protected override double NewtonsPerSquareMillimeterInOnePascal => 1E-6;

        protected override double PascalsInOnePascal => 1;

        protected override double PoundsForcePerSquareFootInOnePascal => 0.0208854342;

        protected override double PoundsForcePerSquareInchInOnePascal => 1.450377377302092e-4;

        protected override double TechnicalAtmospheresInOnePascal => 1.0197 * 1E-5;

        protected override double TonnesForcePerSquareCentimeterInOnePascal => 1.019716212977928e-8;

        protected override double TonnesForcePerSquareMeterInOnePascal => 1.019716212977928e-4;

        protected override double TonnesForcePerSquareMillimeterInOnePascal => 1.019716212977928e-10;

        protected override double TorrsInOnePascal => 7.5006 * 1E-3;

        protected override double CentibarsInOnePascal => 1e-3;

        protected override double DecapascalsInOnePascal => 1e-1;

        protected override double DecibarsInOnePascal => 1e-4;
        protected override double FeetOfHeadInOnePascal => 0.000334552565551;

        protected override double GigapascalsInOnePascal => 1e-9;

        protected override double HectopascalsInOnePascal => 1e-2;

        protected override double KilobarsInOnePascal => 1e-8;

        protected override double MegabarsInOnePascal => 1e-11;

        protected override double MicropascalsInOnePascal => 1e6;

        protected override double MillibarsInOnePascal => 1e-2;

        protected override double MicrobarsInOnePascal => 1.0e1;

        protected override double MillimetersOfMercuryInOnePascal => 7.50061561302643e-3;

        protected override double InchesOfMercuryInOnePascal => 2.95299830714159e-4;

        protected override double InchesOfWaterColumnInOnePascal => 4.014630786617777e-3;

        protected override double DynesPerSquareCentimeterInOnePascal => 1.0e1;

        protected override double PoundsPerInchSecondSquaredInOnePascal => 5.599741459495891e-2;

        protected override double MillipascalsInOnePascal => 1e3;

        [Fact]
        public void Absolute_WithAbsolutePressureReference_IsEqual()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(3), PressureReference.Absolute);
            AssertEx.EqualTolerance(3, refPressure.Absolute.Atmospheres, AtmospheresTolerance);
        }

        [Fact]
        public void Absolute_WithDefaultPressureReference_IsEqual()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(3));
            AssertEx.EqualTolerance(3, refPressure.Absolute.Atmospheres, AtmospheresTolerance);
        }

        [Fact]
        public void Absolute_WithGaugePressureReference_IsOneMore()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(3), PressureReference.Gauge);
            AssertEx.EqualTolerance(4, refPressure.Absolute.Atmospheres, AtmospheresTolerance);
        }

        [Fact]
        public void Absolute_WithNegativeAbsolutePressureReference_ThrowsArgumentOutOfRangeException()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(-3), PressureReference.Absolute);
            Assert.Throws<ArgumentOutOfRangeException>(() => refPressure.Absolute.Atmospheres);
        }

        [Fact]
        public void Absolute_WithNegativeGaugePressureReference_ThrowsArgumentOutOfRangeException()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(-3), PressureReference.Gauge);
            Assert.Throws<ArgumentOutOfRangeException>(() => refPressure.Absolute.Atmospheres);
        }

        [Fact]
        public void Absolute_WithVacuumPressureReference_IsOneLessAtmosphereNegative()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(1), PressureReference.Vacuum);
            AssertEx.EqualTolerance(0, refPressure.Absolute.Atmospheres, AtmospheresTolerance);
        }

        [Fact]
        public void Absolute_WithVacuumPressureReference_ThrowsArgumentOutOfRangeException()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(3), PressureReference.Vacuum);
            Assert.Throws<ArgumentOutOfRangeException>(() => refPressure.Absolute.Atmospheres);
        }

        [Fact]
        public void AreaTimesPressureEqualsForce()
        {
            var force = Area.FromSquareMeters(3) * Pressure.FromPascals(20);
            Assert.Equal(force, Force.FromNewtons(60));
        }

        [Fact]
        public void Gauge_WithDefaultPressureReference_IsOneLessAtmosphere()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(3));
            AssertEx.EqualTolerance(2, refPressure.Gauge.Atmospheres, AtmospheresTolerance);
        }

        [Fact]
        public void Gauge_WithGaugePressureReference_IsEqual()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(3), PressureReference.Gauge);
            AssertEx.EqualTolerance(3, refPressure.Gauge.Atmospheres, AtmospheresTolerance);
        }

        [Fact]
        public void Gauge_WithVacuumPressureReference_IsNegative()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(1), PressureReference.Vacuum);
            AssertEx.EqualTolerance(-1, refPressure.Gauge.Atmospheres, AtmospheresTolerance);
        }

        [Fact]
        public void Gauge_WithVacuumPressureReference_ThrowsArgumentOutOfRangeException()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(3), PressureReference.Vacuum);
            Assert.Throws<ArgumentOutOfRangeException>(() => refPressure.Gauge.Atmospheres);
        }

        [Fact]
        public void PressureDividedByLengthEqualsSpecificWeight()
        {
            var specificWeight = Pressure.FromPascals(20) / Length.FromMeters(2);
            Assert.Equal(SpecificWeight.FromNewtonsPerCubicMeter(10), specificWeight);
        }

        [Fact]
        public void PressureDividedBySpecificWeightEqualsLength()
        {
            var length = Pressure.FromPascals(20) / SpecificWeight.FromNewtonsPerCubicMeter(2);
            Assert.Equal(Length.FromMeters(10), length);
        }

        [Fact]
        public void PressureTimesAreaEqualsForce()
        {
            var force = Pressure.FromPascals(20) * Area.FromSquareMeters(3);
            Assert.Equal(force, Force.FromNewtons(60));
        }

        // Pressure Measurement References
        [Fact]
        public void Reference_WithDefaultPressureReference_IsAbsolute()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(3));
            Equals(PressureReference.Absolute, refPressure.Reference);
        }

        [Fact]
        public void ReferencesDoesNotContainUndefined()
        {
            Assert.DoesNotContain(PressureReference.Undefined, ReferencePressure.References);
        }

        [Fact]
        public void Vacuum_WithDefaultPressureReference_IsOneLessAtmosphereNegative()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(3));
            AssertEx.EqualTolerance(-2, refPressure.Vacuum.Atmospheres, AtmospheresTolerance);
        }

        [Fact]
        public void Vacuum_WithGaugePressureReference_IsNegative()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(3), PressureReference.Gauge);
            AssertEx.EqualTolerance(-3, refPressure.Vacuum.Atmospheres, AtmospheresTolerance);
        }

        [Fact]
        public void Vacuum_WithVacuumPressureReference_IsEqual()
        {
            var refPressure = new ReferencePressure(Pressure.FromAtmospheres(1), PressureReference.Vacuum);
            AssertEx.EqualTolerance(1, refPressure.Vacuum.Atmospheres, AtmospheresTolerance);
        }
    }
}
