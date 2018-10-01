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
    /// Test of Magnetization.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MagnetizationTestsBase
    {
        protected abstract double AmperesPerMeterInOneAmperePerMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double AmperesPerMeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void ConstructorWithUndefinedUnitThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Magnetization((double)0.0, MagnetizationUnit.Undefined));
        }

        [Fact]
        public void AmperePerMeterToMagnetizationUnits()
        {
            Magnetization amperepermeter = Magnetization.FromAmperesPerMeter(1);
            AssertEx.EqualTolerance(AmperesPerMeterInOneAmperePerMeter, amperepermeter.AmperesPerMeter, AmperesPerMeterTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, Magnetization.From(1, MagnetizationUnit.AmperePerMeter).AmperesPerMeter, AmperesPerMeterTolerance);
        }

        [Fact]
        public void As()
        {
            var amperepermeter = Magnetization.FromAmperesPerMeter(1);
            AssertEx.EqualTolerance(AmperesPerMeterInOneAmperePerMeter, amperepermeter.As(MagnetizationUnit.AmperePerMeter), AmperesPerMeterTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var amperepermeter = Magnetization.FromAmperesPerMeter(1);

            var amperepermeterQuantity = amperepermeter.ToUnit(MagnetizationUnit.AmperePerMeter);
            AssertEx.EqualTolerance(AmperesPerMeterInOneAmperePerMeter, (double)amperepermeterQuantity.Value, AmperesPerMeterTolerance);
            Assert.Equal(MagnetizationUnit.AmperePerMeter, amperepermeterQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Magnetization amperepermeter = Magnetization.FromAmperesPerMeter(1);
            AssertEx.EqualTolerance(1, Magnetization.FromAmperesPerMeter(amperepermeter.AmperesPerMeter).AmperesPerMeter, AmperesPerMeterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Magnetization v = Magnetization.FromAmperesPerMeter(1);
            AssertEx.EqualTolerance(-1, -v.AmperesPerMeter, AmperesPerMeterTolerance);
            AssertEx.EqualTolerance(2, (Magnetization.FromAmperesPerMeter(3)-v).AmperesPerMeter, AmperesPerMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).AmperesPerMeter, AmperesPerMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).AmperesPerMeter, AmperesPerMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).AmperesPerMeter, AmperesPerMeterTolerance);
            AssertEx.EqualTolerance(2, (Magnetization.FromAmperesPerMeter(10)/5).AmperesPerMeter, AmperesPerMeterTolerance);
            AssertEx.EqualTolerance(2, Magnetization.FromAmperesPerMeter(10)/Magnetization.FromAmperesPerMeter(5), AmperesPerMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            Magnetization oneAmperePerMeter = Magnetization.FromAmperesPerMeter(1);
            Magnetization twoAmperesPerMeter = Magnetization.FromAmperesPerMeter(2);

            Assert.True(oneAmperePerMeter < twoAmperesPerMeter);
            Assert.True(oneAmperePerMeter <= twoAmperesPerMeter);
            Assert.True(twoAmperesPerMeter > oneAmperePerMeter);
            Assert.True(twoAmperesPerMeter >= oneAmperePerMeter);

            Assert.False(oneAmperePerMeter > twoAmperesPerMeter);
            Assert.False(oneAmperePerMeter >= twoAmperesPerMeter);
            Assert.False(twoAmperesPerMeter < oneAmperePerMeter);
            Assert.False(twoAmperesPerMeter <= oneAmperePerMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Magnetization amperepermeter = Magnetization.FromAmperesPerMeter(1);
            Assert.Equal(0, amperepermeter.CompareTo(amperepermeter));
            Assert.True(amperepermeter.CompareTo(Magnetization.Zero) > 0);
            Assert.True(Magnetization.Zero.CompareTo(amperepermeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Magnetization amperepermeter = Magnetization.FromAmperesPerMeter(1);
            Assert.Throws<ArgumentException>(() => amperepermeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Magnetization amperepermeter = Magnetization.FromAmperesPerMeter(1);
            Assert.Throws<ArgumentNullException>(() => amperepermeter.CompareTo(null));
        }

        [Fact]
        public void EqualsIsImplemented()
        {
            Magnetization v = Magnetization.FromAmperesPerMeter(1);
            Assert.True(v.Equals(Magnetization.FromAmperesPerMeter(1), AmperesPerMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Magnetization.Zero, AmperesPerMeterTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Magnetization amperepermeter = Magnetization.FromAmperesPerMeter(1);
            Assert.False(amperepermeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Magnetization amperepermeter = Magnetization.FromAmperesPerMeter(1);
            Assert.False(amperepermeter.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(MagnetizationUnit.Undefined, Magnetization.Units);
        }
    }
}
