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
    /// Test of PowerRatio.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class PowerRatioTestsBase
    {
        protected abstract double DecibelMilliwattsInOneDecibelWatt { get; }
        protected abstract double DecibelWattsInOneDecibelWatt { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DecibelMilliwattsTolerance { get { return 1e-5; } }
        protected virtual double DecibelWattsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PowerRatio<double>((double)0.0, PowerRatioUnit.Undefined));
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PowerRatio<double>(double.PositiveInfinity, PowerRatioUnit.DecibelWatt));
            Assert.Throws<ArgumentException>(() => new PowerRatio<double>(double.NegativeInfinity, PowerRatioUnit.DecibelWatt));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PowerRatio<double>(double.NaN, PowerRatioUnit.DecibelWatt));
        }

        [Fact]
        public void DecibelWattToPowerRatioUnits()
        {
            PowerRatio<double> decibelwatt = PowerRatio<double>.FromDecibelWatts(1);
            AssertEx.EqualTolerance(DecibelMilliwattsInOneDecibelWatt, decibelwatt.DecibelMilliwatts, DecibelMilliwattsTolerance);
            AssertEx.EqualTolerance(DecibelWattsInOneDecibelWatt, decibelwatt.DecibelWatts, DecibelWattsTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, PowerRatio<double>.From(1, PowerRatioUnit.DecibelMilliwatt).DecibelMilliwatts, DecibelMilliwattsTolerance);
            AssertEx.EqualTolerance(1, PowerRatio<double>.From(1, PowerRatioUnit.DecibelWatt).DecibelWatts, DecibelWattsTolerance);
        }

        [Fact]
        public void FromDecibelWatts_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => PowerRatio<double>.FromDecibelWatts(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => PowerRatio<double>.FromDecibelWatts(double.NegativeInfinity));
        }

        [Fact]
        public void FromDecibelWatts_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => PowerRatio<double>.FromDecibelWatts(double.NaN));
        }

        [Fact]
        public void As()
        {
            var decibelwatt = PowerRatio<double>.FromDecibelWatts(1);
            AssertEx.EqualTolerance(DecibelMilliwattsInOneDecibelWatt, decibelwatt.As(PowerRatioUnit.DecibelMilliwatt), DecibelMilliwattsTolerance);
            AssertEx.EqualTolerance(DecibelWattsInOneDecibelWatt, decibelwatt.As(PowerRatioUnit.DecibelWatt), DecibelWattsTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var decibelwatt = PowerRatio<double>.FromDecibelWatts(1);

            var decibelmilliwattQuantity = decibelwatt.ToUnit(PowerRatioUnit.DecibelMilliwatt);
            AssertEx.EqualTolerance(DecibelMilliwattsInOneDecibelWatt, (double)decibelmilliwattQuantity.Value, DecibelMilliwattsTolerance);
            Assert.Equal(PowerRatioUnit.DecibelMilliwatt, decibelmilliwattQuantity.Unit);

            var decibelwattQuantity = decibelwatt.ToUnit(PowerRatioUnit.DecibelWatt);
            AssertEx.EqualTolerance(DecibelWattsInOneDecibelWatt, (double)decibelwattQuantity.Value, DecibelWattsTolerance);
            Assert.Equal(PowerRatioUnit.DecibelWatt, decibelwattQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            PowerRatio<double> decibelwatt = PowerRatio<double>.FromDecibelWatts(1);
            AssertEx.EqualTolerance(1, PowerRatio<double>.FromDecibelMilliwatts(decibelwatt.DecibelMilliwatts).DecibelWatts, DecibelMilliwattsTolerance);
            AssertEx.EqualTolerance(1, PowerRatio<double>.FromDecibelWatts(decibelwatt.DecibelWatts).DecibelWatts, DecibelWattsTolerance);
        }

        [Fact]
        public void LogarithmicArithmeticOperators()
        {
            PowerRatio<double> v = PowerRatio<double>.FromDecibelWatts(40);
            AssertEx.EqualTolerance(-40, -v.DecibelWatts, DecibelWattsTolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            AssertEx.EqualTolerance(50, (v*10).DecibelWatts, DecibelWattsTolerance);
            AssertEx.EqualTolerance(50, (10*v).DecibelWatts, DecibelWattsTolerance);
            AssertEx.EqualTolerance(35, (v/5).DecibelWatts, DecibelWattsTolerance);
            AssertEx.EqualTolerance(35, v/PowerRatio<double>.FromDecibelWatts(5), DecibelWattsTolerance);
        }

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();

        [Fact]
        public void ComparisonOperators()
        {
            PowerRatio<double> oneDecibelWatt = PowerRatio<double>.FromDecibelWatts(1);
            PowerRatio<double> twoDecibelWatts = PowerRatio<double>.FromDecibelWatts(2);

            Assert.True(oneDecibelWatt < twoDecibelWatts);
            Assert.True(oneDecibelWatt <= twoDecibelWatts);
            Assert.True(twoDecibelWatts > oneDecibelWatt);
            Assert.True(twoDecibelWatts >= oneDecibelWatt);

            Assert.False(oneDecibelWatt > twoDecibelWatts);
            Assert.False(oneDecibelWatt >= twoDecibelWatts);
            Assert.False(twoDecibelWatts < oneDecibelWatt);
            Assert.False(twoDecibelWatts <= oneDecibelWatt);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            PowerRatio<double> decibelwatt = PowerRatio<double>.FromDecibelWatts(1);
            Assert.Equal(0, decibelwatt.CompareTo(decibelwatt));
            Assert.True(decibelwatt.CompareTo(PowerRatio<double>.Zero) > 0);
            Assert.True(PowerRatio<double>.Zero.CompareTo(decibelwatt) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            PowerRatio<double> decibelwatt = PowerRatio<double>.FromDecibelWatts(1);
            Assert.Throws<ArgumentException>(() => decibelwatt.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            PowerRatio<double> decibelwatt = PowerRatio<double>.FromDecibelWatts(1);
            Assert.Throws<ArgumentNullException>(() => decibelwatt.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = PowerRatio<double>.FromDecibelWatts(1);
            var b = PowerRatio<double>.FromDecibelWatts(2);

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
            var a = PowerRatio<double>.FromDecibelWatts(1);
            var b = PowerRatio<double>.FromDecibelWatts(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {
            var v = PowerRatio<double>.FromDecibelWatts(1);
            Assert.True(v.Equals(PowerRatio<double>.FromDecibelWatts(1), DecibelWattsTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(PowerRatio<double>.Zero, DecibelWattsTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            PowerRatio<double> decibelwatt = PowerRatio<double>.FromDecibelWatts(1);
            Assert.False(decibelwatt.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            PowerRatio<double> decibelwatt = PowerRatio<double>.FromDecibelWatts(1);
            Assert.False(decibelwatt.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(PowerRatioUnit.Undefined, PowerRatio<double>.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(PowerRatioUnit)).Cast<PowerRatioUnit>();
            foreach(var unit in units)
            {
                if(unit == PowerRatioUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(PowerRatio<double>.BaseDimensions is null);
        }
    }
}
