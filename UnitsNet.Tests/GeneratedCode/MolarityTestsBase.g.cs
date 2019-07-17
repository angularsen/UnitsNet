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
    /// Test of Molarity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MolarityTestsBase
    {
        protected abstract double CentimolesPerLiterInOneMolesPerCubicMeter { get; }
        protected abstract double DecimolesPerLiterInOneMolesPerCubicMeter { get; }
        protected abstract double MicromolesPerLiterInOneMolesPerCubicMeter { get; }
        protected abstract double MillimolesPerLiterInOneMolesPerCubicMeter { get; }
        protected abstract double MolesPerCubicMeterInOneMolesPerCubicMeter { get; }
        protected abstract double MolesPerLiterInOneMolesPerCubicMeter { get; }
        protected abstract double NanomolesPerLiterInOneMolesPerCubicMeter { get; }
        protected abstract double PicomolesPerLiterInOneMolesPerCubicMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentimolesPerLiterTolerance { get { return 1e-5; } }
        protected virtual double DecimolesPerLiterTolerance { get { return 1e-5; } }
        protected virtual double MicromolesPerLiterTolerance { get { return 1e-5; } }
        protected virtual double MillimolesPerLiterTolerance { get { return 1e-5; } }
        protected virtual double MolesPerCubicMeterTolerance { get { return 1e-5; } }
        protected virtual double MolesPerLiterTolerance { get { return 1e-5; } }
        protected virtual double NanomolesPerLiterTolerance { get { return 1e-5; } }
        protected virtual double PicomolesPerLiterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Molarity((double)0.0, MolarityUnit.Undefined));
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Molarity(double.PositiveInfinity, MolarityUnit.MolesPerCubicMeter));
            Assert.Throws<ArgumentException>(() => new Molarity(double.NegativeInfinity, MolarityUnit.MolesPerCubicMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Molarity(double.NaN, MolarityUnit.MolesPerCubicMeter));
        }

        [Fact]
        public void MolesPerCubicMeterToMolarityUnits()
        {
            Molarity molespercubicmeter = Molarity.FromMolesPerCubicMeter(1);
            AssertEx.EqualTolerance(CentimolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.CentimolesPerLiter, CentimolesPerLiterTolerance);
            AssertEx.EqualTolerance(DecimolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.DecimolesPerLiter, DecimolesPerLiterTolerance);
            AssertEx.EqualTolerance(MicromolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.MicromolesPerLiter, MicromolesPerLiterTolerance);
            AssertEx.EqualTolerance(MillimolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.MillimolesPerLiter, MillimolesPerLiterTolerance);
            AssertEx.EqualTolerance(MolesPerCubicMeterInOneMolesPerCubicMeter, molespercubicmeter.MolesPerCubicMeter, MolesPerCubicMeterTolerance);
            AssertEx.EqualTolerance(MolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.MolesPerLiter, MolesPerLiterTolerance);
            AssertEx.EqualTolerance(NanomolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.NanomolesPerLiter, NanomolesPerLiterTolerance);
            AssertEx.EqualTolerance(PicomolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.PicomolesPerLiter, PicomolesPerLiterTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, Molarity.From(1, MolarityUnit.CentimolesPerLiter).CentimolesPerLiter, CentimolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.From(1, MolarityUnit.DecimolesPerLiter).DecimolesPerLiter, DecimolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.From(1, MolarityUnit.MicromolesPerLiter).MicromolesPerLiter, MicromolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.From(1, MolarityUnit.MillimolesPerLiter).MillimolesPerLiter, MillimolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.From(1, MolarityUnit.MolesPerCubicMeter).MolesPerCubicMeter, MolesPerCubicMeterTolerance);
            AssertEx.EqualTolerance(1, Molarity.From(1, MolarityUnit.MolesPerLiter).MolesPerLiter, MolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.From(1, MolarityUnit.NanomolesPerLiter).NanomolesPerLiter, NanomolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.From(1, MolarityUnit.PicomolesPerLiter).PicomolesPerLiter, PicomolesPerLiterTolerance);
        }

        [Fact]
        public void FromMolesPerCubicMeter_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Molarity.FromMolesPerCubicMeter(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => Molarity.FromMolesPerCubicMeter(double.NegativeInfinity));
        }

        [Fact]
        public void FromMolesPerCubicMeter_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Molarity.FromMolesPerCubicMeter(double.NaN));
        }

        [Fact]
        public void As()
        {
            var molespercubicmeter = Molarity.FromMolesPerCubicMeter(1);
            AssertEx.EqualTolerance(CentimolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.As(MolarityUnit.CentimolesPerLiter), CentimolesPerLiterTolerance);
            AssertEx.EqualTolerance(DecimolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.As(MolarityUnit.DecimolesPerLiter), DecimolesPerLiterTolerance);
            AssertEx.EqualTolerance(MicromolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.As(MolarityUnit.MicromolesPerLiter), MicromolesPerLiterTolerance);
            AssertEx.EqualTolerance(MillimolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.As(MolarityUnit.MillimolesPerLiter), MillimolesPerLiterTolerance);
            AssertEx.EqualTolerance(MolesPerCubicMeterInOneMolesPerCubicMeter, molespercubicmeter.As(MolarityUnit.MolesPerCubicMeter), MolesPerCubicMeterTolerance);
            AssertEx.EqualTolerance(MolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.As(MolarityUnit.MolesPerLiter), MolesPerLiterTolerance);
            AssertEx.EqualTolerance(NanomolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.As(MolarityUnit.NanomolesPerLiter), NanomolesPerLiterTolerance);
            AssertEx.EqualTolerance(PicomolesPerLiterInOneMolesPerCubicMeter, molespercubicmeter.As(MolarityUnit.PicomolesPerLiter), PicomolesPerLiterTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var molespercubicmeter = Molarity.FromMolesPerCubicMeter(1);

            var centimolesperliterQuantity = molespercubicmeter.ToUnit(MolarityUnit.CentimolesPerLiter);
            AssertEx.EqualTolerance(CentimolesPerLiterInOneMolesPerCubicMeter, (double)centimolesperliterQuantity.Value, CentimolesPerLiterTolerance);
            Assert.Equal(MolarityUnit.CentimolesPerLiter, centimolesperliterQuantity.Unit);

            var decimolesperliterQuantity = molespercubicmeter.ToUnit(MolarityUnit.DecimolesPerLiter);
            AssertEx.EqualTolerance(DecimolesPerLiterInOneMolesPerCubicMeter, (double)decimolesperliterQuantity.Value, DecimolesPerLiterTolerance);
            Assert.Equal(MolarityUnit.DecimolesPerLiter, decimolesperliterQuantity.Unit);

            var micromolesperliterQuantity = molespercubicmeter.ToUnit(MolarityUnit.MicromolesPerLiter);
            AssertEx.EqualTolerance(MicromolesPerLiterInOneMolesPerCubicMeter, (double)micromolesperliterQuantity.Value, MicromolesPerLiterTolerance);
            Assert.Equal(MolarityUnit.MicromolesPerLiter, micromolesperliterQuantity.Unit);

            var millimolesperliterQuantity = molespercubicmeter.ToUnit(MolarityUnit.MillimolesPerLiter);
            AssertEx.EqualTolerance(MillimolesPerLiterInOneMolesPerCubicMeter, (double)millimolesperliterQuantity.Value, MillimolesPerLiterTolerance);
            Assert.Equal(MolarityUnit.MillimolesPerLiter, millimolesperliterQuantity.Unit);

            var molespercubicmeterQuantity = molespercubicmeter.ToUnit(MolarityUnit.MolesPerCubicMeter);
            AssertEx.EqualTolerance(MolesPerCubicMeterInOneMolesPerCubicMeter, (double)molespercubicmeterQuantity.Value, MolesPerCubicMeterTolerance);
            Assert.Equal(MolarityUnit.MolesPerCubicMeter, molespercubicmeterQuantity.Unit);

            var molesperliterQuantity = molespercubicmeter.ToUnit(MolarityUnit.MolesPerLiter);
            AssertEx.EqualTolerance(MolesPerLiterInOneMolesPerCubicMeter, (double)molesperliterQuantity.Value, MolesPerLiterTolerance);
            Assert.Equal(MolarityUnit.MolesPerLiter, molesperliterQuantity.Unit);

            var nanomolesperliterQuantity = molespercubicmeter.ToUnit(MolarityUnit.NanomolesPerLiter);
            AssertEx.EqualTolerance(NanomolesPerLiterInOneMolesPerCubicMeter, (double)nanomolesperliterQuantity.Value, NanomolesPerLiterTolerance);
            Assert.Equal(MolarityUnit.NanomolesPerLiter, nanomolesperliterQuantity.Unit);

            var picomolesperliterQuantity = molespercubicmeter.ToUnit(MolarityUnit.PicomolesPerLiter);
            AssertEx.EqualTolerance(PicomolesPerLiterInOneMolesPerCubicMeter, (double)picomolesperliterQuantity.Value, PicomolesPerLiterTolerance);
            Assert.Equal(MolarityUnit.PicomolesPerLiter, picomolesperliterQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Molarity molespercubicmeter = Molarity.FromMolesPerCubicMeter(1);
            AssertEx.EqualTolerance(1, Molarity.FromCentimolesPerLiter(molespercubicmeter.CentimolesPerLiter).MolesPerCubicMeter, CentimolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.FromDecimolesPerLiter(molespercubicmeter.DecimolesPerLiter).MolesPerCubicMeter, DecimolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.FromMicromolesPerLiter(molespercubicmeter.MicromolesPerLiter).MolesPerCubicMeter, MicromolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.FromMillimolesPerLiter(molespercubicmeter.MillimolesPerLiter).MolesPerCubicMeter, MillimolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.FromMolesPerCubicMeter(molespercubicmeter.MolesPerCubicMeter).MolesPerCubicMeter, MolesPerCubicMeterTolerance);
            AssertEx.EqualTolerance(1, Molarity.FromMolesPerLiter(molespercubicmeter.MolesPerLiter).MolesPerCubicMeter, MolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.FromNanomolesPerLiter(molespercubicmeter.NanomolesPerLiter).MolesPerCubicMeter, NanomolesPerLiterTolerance);
            AssertEx.EqualTolerance(1, Molarity.FromPicomolesPerLiter(molespercubicmeter.PicomolesPerLiter).MolesPerCubicMeter, PicomolesPerLiterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Molarity v = Molarity.FromMolesPerCubicMeter(1);
            AssertEx.EqualTolerance(-1, -v.MolesPerCubicMeter, MolesPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, (Molarity.FromMolesPerCubicMeter(3)-v).MolesPerCubicMeter, MolesPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).MolesPerCubicMeter, MolesPerCubicMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).MolesPerCubicMeter, MolesPerCubicMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).MolesPerCubicMeter, MolesPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, (Molarity.FromMolesPerCubicMeter(10)/5).MolesPerCubicMeter, MolesPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, Molarity.FromMolesPerCubicMeter(10)/Molarity.FromMolesPerCubicMeter(5), MolesPerCubicMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            Molarity oneMolesPerCubicMeter = Molarity.FromMolesPerCubicMeter(1);
            Molarity twoMolesPerCubicMeter = Molarity.FromMolesPerCubicMeter(2);

            Assert.True(oneMolesPerCubicMeter < twoMolesPerCubicMeter);
            Assert.True(oneMolesPerCubicMeter <= twoMolesPerCubicMeter);
            Assert.True(twoMolesPerCubicMeter > oneMolesPerCubicMeter);
            Assert.True(twoMolesPerCubicMeter >= oneMolesPerCubicMeter);

            Assert.False(oneMolesPerCubicMeter > twoMolesPerCubicMeter);
            Assert.False(oneMolesPerCubicMeter >= twoMolesPerCubicMeter);
            Assert.False(twoMolesPerCubicMeter < oneMolesPerCubicMeter);
            Assert.False(twoMolesPerCubicMeter <= oneMolesPerCubicMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Molarity molespercubicmeter = Molarity.FromMolesPerCubicMeter(1);
            Assert.Equal(0, molespercubicmeter.CompareTo(molespercubicmeter));
            Assert.True(molespercubicmeter.CompareTo(Molarity.Zero) > 0);
            Assert.True(Molarity.Zero.CompareTo(molespercubicmeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Molarity molespercubicmeter = Molarity.FromMolesPerCubicMeter(1);
            Assert.Throws<ArgumentException>(() => molespercubicmeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Molarity molespercubicmeter = Molarity.FromMolesPerCubicMeter(1);
            Assert.Throws<ArgumentNullException>(() => molespercubicmeter.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = Molarity.FromMolesPerCubicMeter(1);
            var b = Molarity.FromMolesPerCubicMeter(2);

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
            var a = Molarity.FromMolesPerCubicMeter(1);
            var b = Molarity.FromMolesPerCubicMeter(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {
            var v = Molarity.FromMolesPerCubicMeter(1);
            Assert.True(v.Equals(Molarity.FromMolesPerCubicMeter(1), MolesPerCubicMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Molarity.Zero, MolesPerCubicMeterTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Molarity molespercubicmeter = Molarity.FromMolesPerCubicMeter(1);
            Assert.False(molespercubicmeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Molarity molespercubicmeter = Molarity.FromMolesPerCubicMeter(1);
            Assert.False(molespercubicmeter.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(MolarityUnit.Undefined, Molarity.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(MolarityUnit)).Cast<MolarityUnit>();
            foreach(var unit in units)
            {
                if(unit == MolarityUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(Molarity.BaseDimensions is null);
        }
    }
}
