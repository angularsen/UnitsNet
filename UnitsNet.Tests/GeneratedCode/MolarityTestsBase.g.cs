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
//     Add Extensions\MyQuantityExtensions.cs to decorate quantities with new behavior.
//     Add UnitDefinitions\MyQuantity.json and run GeneratUnits.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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
            Molarity a = Molarity.FromMolesPerCubicMeter(1);
            Molarity b = Molarity.FromMolesPerCubicMeter(2);

// ReSharper disable EqualExpressionComparison
            Assert.True(a == a);
            Assert.True(a != b);

            Assert.False(a == b);
            Assert.False(a != a);
// ReSharper restore EqualExpressionComparison
        }

        [Fact]
        public void EqualsIsImplemented()
        {
            Molarity v = Molarity.FromMolesPerCubicMeter(1);
            Assert.True(v.Equals(Molarity.FromMolesPerCubicMeter(1), Molarity.FromMolesPerCubicMeter(MolesPerCubicMeterTolerance)));
            Assert.False(v.Equals(Molarity.Zero, Molarity.FromMolesPerCubicMeter(MolesPerCubicMeterTolerance)));
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

    }
}
