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
    /// Test of ElectricChargeDensity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricChargeDensityTestsBase
    {
        protected abstract double CoulombsPerCubicMeterInOneCoulombPerCubicMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CoulombsPerCubicMeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricChargeDensity<double>((double)0.0, ElectricChargeDensityUnit.Undefined));
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricChargeDensity<double>(double.PositiveInfinity, ElectricChargeDensityUnit.CoulombPerCubicMeter));
            Assert.Throws<ArgumentException>(() => new ElectricChargeDensity<double>(double.NegativeInfinity, ElectricChargeDensityUnit.CoulombPerCubicMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricChargeDensity<double>(double.NaN, ElectricChargeDensityUnit.CoulombPerCubicMeter));
        }

        [Fact]
        public void CoulombPerCubicMeterToElectricChargeDensityUnits()
        {
            ElectricChargeDensity<double> coulombpercubicmeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            AssertEx.EqualTolerance(CoulombsPerCubicMeterInOneCoulombPerCubicMeter, coulombpercubicmeter.CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, ElectricChargeDensity<double>.From(1, ElectricChargeDensityUnit.CoulombPerCubicMeter).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
        }

        [Fact]
        public void FromCoulombsPerCubicMeter_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(double.NegativeInfinity));
        }

        [Fact]
        public void FromCoulombsPerCubicMeter_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(double.NaN));
        }

        [Fact]
        public void As()
        {
            var coulombpercubicmeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            AssertEx.EqualTolerance(CoulombsPerCubicMeterInOneCoulombPerCubicMeter, coulombpercubicmeter.As(ElectricChargeDensityUnit.CoulombPerCubicMeter), CoulombsPerCubicMeterTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var coulombpercubicmeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);

            var coulombpercubicmeterQuantity = coulombpercubicmeter.ToUnit(ElectricChargeDensityUnit.CoulombPerCubicMeter);
            AssertEx.EqualTolerance(CoulombsPerCubicMeterInOneCoulombPerCubicMeter, (double)coulombpercubicmeterQuantity.Value, CoulombsPerCubicMeterTolerance);
            Assert.Equal(ElectricChargeDensityUnit.CoulombPerCubicMeter, coulombpercubicmeterQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ElectricChargeDensity<double> coulombpercubicmeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            AssertEx.EqualTolerance(1, ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(coulombpercubicmeter.CoulombsPerCubicMeter).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ElectricChargeDensity<double> v = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            AssertEx.EqualTolerance(-1, -v.CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(3)-v).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(10)/5).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(10)/ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(5), CoulombsPerCubicMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ElectricChargeDensity<double> oneCoulombPerCubicMeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            ElectricChargeDensity<double> twoCoulombsPerCubicMeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(2);

            Assert.True(oneCoulombPerCubicMeter < twoCoulombsPerCubicMeter);
            Assert.True(oneCoulombPerCubicMeter <= twoCoulombsPerCubicMeter);
            Assert.True(twoCoulombsPerCubicMeter > oneCoulombPerCubicMeter);
            Assert.True(twoCoulombsPerCubicMeter >= oneCoulombPerCubicMeter);

            Assert.False(oneCoulombPerCubicMeter > twoCoulombsPerCubicMeter);
            Assert.False(oneCoulombPerCubicMeter >= twoCoulombsPerCubicMeter);
            Assert.False(twoCoulombsPerCubicMeter < oneCoulombPerCubicMeter);
            Assert.False(twoCoulombsPerCubicMeter <= oneCoulombPerCubicMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ElectricChargeDensity<double> coulombpercubicmeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            Assert.Equal(0, coulombpercubicmeter.CompareTo(coulombpercubicmeter));
            Assert.True(coulombpercubicmeter.CompareTo(ElectricChargeDensity<double>.Zero) > 0);
            Assert.True(ElectricChargeDensity<double>.Zero.CompareTo(coulombpercubicmeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricChargeDensity<double> coulombpercubicmeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            Assert.Throws<ArgumentException>(() => coulombpercubicmeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ElectricChargeDensity<double> coulombpercubicmeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            Assert.Throws<ArgumentNullException>(() => coulombpercubicmeter.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            var b = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(2);

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
            var a = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            var b = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {
            var v = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            Assert.True(v.Equals(ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1), CoulombsPerCubicMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ElectricChargeDensity<double>.Zero, CoulombsPerCubicMeterTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricChargeDensity<double> coulombpercubicmeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            Assert.False(coulombpercubicmeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricChargeDensity<double> coulombpercubicmeter = ElectricChargeDensity<double>.FromCoulombsPerCubicMeter(1);
            Assert.False(coulombpercubicmeter.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(ElectricChargeDensityUnit.Undefined, ElectricChargeDensity<double>.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ElectricChargeDensityUnit)).Cast<ElectricChargeDensityUnit>();
            foreach(var unit in units)
            {
                if(unit == ElectricChargeDensityUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ElectricChargeDensity<double>.BaseDimensions is null);
        }
    }
}
