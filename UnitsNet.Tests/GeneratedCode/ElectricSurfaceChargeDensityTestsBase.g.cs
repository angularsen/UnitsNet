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
using System.Linq;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of ElectricSurfaceChargeDensity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricSurfaceChargeDensityTestsBase
    {
        protected abstract double CoulombsPerSquareCentimeterInOneCoulombPerSquareMeter { get; }
        protected abstract double CoulombsPerSquareInchInOneCoulombPerSquareMeter { get; }
        protected abstract double CoulombsPerSquareMeterInOneCoulombPerSquareMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CoulombsPerSquareCentimeterTolerance { get { return 1e-5; } }
        protected virtual double CoulombsPerSquareInchTolerance { get { return 1e-5; } }
        protected virtual double CoulombsPerSquareMeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricSurfaceChargeDensity<double>((double)0.0, ElectricSurfaceChargeDensityUnit.Undefined));
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricSurfaceChargeDensity<double>(double.PositiveInfinity, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter));
            Assert.Throws<ArgumentException>(() => new ElectricSurfaceChargeDensity<double>(double.NegativeInfinity, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricSurfaceChargeDensity<double>(double.NaN, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter));
        }

        [Fact]
        public void CoulombPerSquareMeterToElectricSurfaceChargeDensityUnits()
        {
            ElectricSurfaceChargeDensity<double> coulombpersquaremeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            AssertEx.EqualTolerance(CoulombsPerSquareCentimeterInOneCoulombPerSquareMeter, coulombpersquaremeter.CoulombsPerSquareCentimeter, CoulombsPerSquareCentimeterTolerance);
            AssertEx.EqualTolerance(CoulombsPerSquareInchInOneCoulombPerSquareMeter, coulombpersquaremeter.CoulombsPerSquareInch, CoulombsPerSquareInchTolerance);
            AssertEx.EqualTolerance(CoulombsPerSquareMeterInOneCoulombPerSquareMeter, coulombpersquaremeter.CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, ElectricSurfaceChargeDensity<double>.From(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter).CoulombsPerSquareCentimeter, CoulombsPerSquareCentimeterTolerance);
            AssertEx.EqualTolerance(1, ElectricSurfaceChargeDensity<double>.From(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch).CoulombsPerSquareInch, CoulombsPerSquareInchTolerance);
            AssertEx.EqualTolerance(1, ElectricSurfaceChargeDensity<double>.From(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
        }

        [Fact]
        public void FromCoulombsPerSquareMeter_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(double.NegativeInfinity));
        }

        [Fact]
        public void FromCoulombsPerSquareMeter_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(double.NaN));
        }

        [Fact]
        public void As()
        {
            var coulombpersquaremeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            AssertEx.EqualTolerance(CoulombsPerSquareCentimeterInOneCoulombPerSquareMeter, coulombpersquaremeter.As(ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter), CoulombsPerSquareCentimeterTolerance);
            AssertEx.EqualTolerance(CoulombsPerSquareInchInOneCoulombPerSquareMeter, coulombpersquaremeter.As(ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch), CoulombsPerSquareInchTolerance);
            AssertEx.EqualTolerance(CoulombsPerSquareMeterInOneCoulombPerSquareMeter, coulombpersquaremeter.As(ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter), CoulombsPerSquareMeterTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var coulombpersquaremeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);

            var coulombpersquarecentimeterQuantity = coulombpersquaremeter.ToUnit(ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter);
            AssertEx.EqualTolerance(CoulombsPerSquareCentimeterInOneCoulombPerSquareMeter, (double)coulombpersquarecentimeterQuantity.Value, CoulombsPerSquareCentimeterTolerance);
            Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter, coulombpersquarecentimeterQuantity.Unit);

            var coulombpersquareinchQuantity = coulombpersquaremeter.ToUnit(ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch);
            AssertEx.EqualTolerance(CoulombsPerSquareInchInOneCoulombPerSquareMeter, (double)coulombpersquareinchQuantity.Value, CoulombsPerSquareInchTolerance);
            Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch, coulombpersquareinchQuantity.Unit);

            var coulombpersquaremeterQuantity = coulombpersquaremeter.ToUnit(ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter);
            AssertEx.EqualTolerance(CoulombsPerSquareMeterInOneCoulombPerSquareMeter, (double)coulombpersquaremeterQuantity.Value, CoulombsPerSquareMeterTolerance);
            Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter, coulombpersquaremeterQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ElectricSurfaceChargeDensity<double> coulombpersquaremeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            AssertEx.EqualTolerance(1, ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareCentimeter(coulombpersquaremeter.CoulombsPerSquareCentimeter).CoulombsPerSquareMeter, CoulombsPerSquareCentimeterTolerance);
            AssertEx.EqualTolerance(1, ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareInch(coulombpersquaremeter.CoulombsPerSquareInch).CoulombsPerSquareMeter, CoulombsPerSquareInchTolerance);
            AssertEx.EqualTolerance(1, ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(coulombpersquaremeter.CoulombsPerSquareMeter).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ElectricSurfaceChargeDensity<double> v = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            AssertEx.EqualTolerance(-1, -v.CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(3)-v).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(10)/5).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(2, ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(10)/ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(5), CoulombsPerSquareMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ElectricSurfaceChargeDensity<double> oneCoulombPerSquareMeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            ElectricSurfaceChargeDensity<double> twoCoulombsPerSquareMeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(2);

            Assert.True(oneCoulombPerSquareMeter < twoCoulombsPerSquareMeter);
            Assert.True(oneCoulombPerSquareMeter <= twoCoulombsPerSquareMeter);
            Assert.True(twoCoulombsPerSquareMeter > oneCoulombPerSquareMeter);
            Assert.True(twoCoulombsPerSquareMeter >= oneCoulombPerSquareMeter);

            Assert.False(oneCoulombPerSquareMeter > twoCoulombsPerSquareMeter);
            Assert.False(oneCoulombPerSquareMeter >= twoCoulombsPerSquareMeter);
            Assert.False(twoCoulombsPerSquareMeter < oneCoulombPerSquareMeter);
            Assert.False(twoCoulombsPerSquareMeter <= oneCoulombPerSquareMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ElectricSurfaceChargeDensity<double> coulombpersquaremeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            Assert.Equal(0, coulombpersquaremeter.CompareTo(coulombpersquaremeter));
            Assert.True(coulombpersquaremeter.CompareTo(ElectricSurfaceChargeDensity<double>.Zero) > 0);
            Assert.True(ElectricSurfaceChargeDensity<double>.Zero.CompareTo(coulombpersquaremeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricSurfaceChargeDensity<double> coulombpersquaremeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            Assert.Throws<ArgumentException>(() => coulombpersquaremeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ElectricSurfaceChargeDensity<double> coulombpersquaremeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            Assert.Throws<ArgumentNullException>(() => coulombpersquaremeter.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            var b = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(2);

 // ReSharper disable EqualExpressionComparison

            Assert.True(a == a);
            Assert.False(a != a);

            Assert.True(a != b);
            Assert.False(a == b);

            Assert.False(a == null);
            Assert.False(null == a);

// ReSharper restore EqualExpressionComparison
        }

        [Fact]
        public void EqualsIsImplemented()
        {
            var a = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            var b = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {
            var v = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            Assert.True(v.Equals(ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1), CoulombsPerSquareMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ElectricSurfaceChargeDensity<double>.Zero, CoulombsPerSquareMeterTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricSurfaceChargeDensity<double> coulombpersquaremeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            Assert.False(coulombpersquaremeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricSurfaceChargeDensity<double> coulombpersquaremeter = ElectricSurfaceChargeDensity<double>.FromCoulombsPerSquareMeter(1);
            Assert.False(coulombpersquaremeter.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(ElectricSurfaceChargeDensityUnit.Undefined, ElectricSurfaceChargeDensity<double>.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ElectricSurfaceChargeDensityUnit)).Cast<ElectricSurfaceChargeDensityUnit>();
            foreach(var unit in units)
            {
                if(unit == ElectricSurfaceChargeDensityUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ElectricSurfaceChargeDensity<double>.BaseDimensions is null);
        }
    }
}
