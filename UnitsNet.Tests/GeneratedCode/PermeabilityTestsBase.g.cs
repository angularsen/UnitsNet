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
    /// Test of Permeability.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class PermeabilityTestsBase
    {
        protected abstract double HenriesPerMeterInOneHenryPerMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double HenriesPerMeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Permeability<double>((double)0.0, PermeabilityUnit.Undefined));
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Permeability<double>(double.PositiveInfinity, PermeabilityUnit.HenryPerMeter));
            Assert.Throws<ArgumentException>(() => new Permeability<double>(double.NegativeInfinity, PermeabilityUnit.HenryPerMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Permeability<double>(double.NaN, PermeabilityUnit.HenryPerMeter));
        }

        [Fact]
        public void HenryPerMeterToPermeabilityUnits()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            AssertEx.EqualTolerance(HenriesPerMeterInOneHenryPerMeter, henrypermeter.HenriesPerMeter, HenriesPerMeterTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, Permeability<double>.From(1, PermeabilityUnit.HenryPerMeter).HenriesPerMeter, HenriesPerMeterTolerance);
        }

        [Fact]
        public void FromHenriesPerMeter_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Permeability<double>.FromHenriesPerMeter(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => Permeability<double>.FromHenriesPerMeter(double.NegativeInfinity));
        }

        [Fact]
        public void FromHenriesPerMeter_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Permeability<double>.FromHenriesPerMeter(double.NaN));
        }

        [Fact]
        public void As()
        {
            var henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            AssertEx.EqualTolerance(HenriesPerMeterInOneHenryPerMeter, henrypermeter.As(PermeabilityUnit.HenryPerMeter), HenriesPerMeterTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var henrypermeter = Permeability<double>.FromHenriesPerMeter(1);

            var henrypermeterQuantity = henrypermeter.ToUnit(PermeabilityUnit.HenryPerMeter);
            AssertEx.EqualTolerance(HenriesPerMeterInOneHenryPerMeter, (double)henrypermeterQuantity.Value, HenriesPerMeterTolerance);
            Assert.Equal(PermeabilityUnit.HenryPerMeter, henrypermeterQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            AssertEx.EqualTolerance(1, Permeability<double>.FromHenriesPerMeter(henrypermeter.HenriesPerMeter).HenriesPerMeter, HenriesPerMeterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Permeability<double> v = Permeability<double>.FromHenriesPerMeter(1);
            AssertEx.EqualTolerance(-1, -v.HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(2, (Permeability<double>.FromHenriesPerMeter(3)-v).HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(2, (Permeability<double>.FromHenriesPerMeter(10)/5).HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(2, Permeability<double>.FromHenriesPerMeter(10)/Permeability<double>.FromHenriesPerMeter(5), HenriesPerMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            Permeability<double> oneHenryPerMeter = Permeability<double>.FromHenriesPerMeter(1);
            Permeability<double> twoHenriesPerMeter = Permeability<double>.FromHenriesPerMeter(2);

            Assert.True(oneHenryPerMeter < twoHenriesPerMeter);
            Assert.True(oneHenryPerMeter <= twoHenriesPerMeter);
            Assert.True(twoHenriesPerMeter > oneHenryPerMeter);
            Assert.True(twoHenriesPerMeter >= oneHenryPerMeter);

            Assert.False(oneHenryPerMeter > twoHenriesPerMeter);
            Assert.False(oneHenryPerMeter >= twoHenriesPerMeter);
            Assert.False(twoHenriesPerMeter < oneHenryPerMeter);
            Assert.False(twoHenriesPerMeter <= oneHenryPerMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            Assert.Equal(0, henrypermeter.CompareTo(henrypermeter));
            Assert.True(henrypermeter.CompareTo(Permeability<double>.Zero) > 0);
            Assert.True(Permeability<double>.Zero.CompareTo(henrypermeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            Assert.Throws<ArgumentException>(() => henrypermeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            Assert.Throws<ArgumentNullException>(() => henrypermeter.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = Permeability<double>.FromHenriesPerMeter(1);
            var b = Permeability<double>.FromHenriesPerMeter(2);

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
            var a = Permeability<double>.FromHenriesPerMeter(1);
            var b = Permeability<double>.FromHenriesPerMeter(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {
            var v = Permeability<double>.FromHenriesPerMeter(1);
            Assert.True(v.Equals(Permeability<double>.FromHenriesPerMeter(1), HenriesPerMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Permeability<double>.Zero, HenriesPerMeterTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            Assert.False(henrypermeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            Assert.False(henrypermeter.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(PermeabilityUnit.Undefined, Permeability<double>.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(PermeabilityUnit)).Cast<PermeabilityUnit>();
            foreach(var unit in units)
            {
                if(unit == PermeabilityUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(Permeability<double>.BaseDimensions is null);
        }
    }
}
