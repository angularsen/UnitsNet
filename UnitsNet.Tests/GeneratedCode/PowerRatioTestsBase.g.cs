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
        public void ConstructorWithUndefinedUnitThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PowerRatio((double)0.0, PowerRatioUnit.Undefined));
        }

        [Fact]
        public void DecibelWattToPowerRatioUnits()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            AssertEx.EqualTolerance(DecibelMilliwattsInOneDecibelWatt, decibelwatt.DecibelMilliwatts, DecibelMilliwattsTolerance);
            AssertEx.EqualTolerance(DecibelWattsInOneDecibelWatt, decibelwatt.DecibelWatts, DecibelWattsTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, PowerRatio.From(1, PowerRatioUnit.DecibelMilliwatt).DecibelMilliwatts, DecibelMilliwattsTolerance);
            AssertEx.EqualTolerance(1, PowerRatio.From(1, PowerRatioUnit.DecibelWatt).DecibelWatts, DecibelWattsTolerance);
        }

        [Fact]
        public void As()
        {
            var decibelwatt = PowerRatio.FromDecibelWatts(1);
            AssertEx.EqualTolerance(DecibelMilliwattsInOneDecibelWatt, decibelwatt.As(PowerRatioUnit.DecibelMilliwatt), DecibelMilliwattsTolerance);
            AssertEx.EqualTolerance(DecibelWattsInOneDecibelWatt, decibelwatt.As(PowerRatioUnit.DecibelWatt), DecibelWattsTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var decibelwatt = PowerRatio.FromDecibelWatts(1);

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
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            AssertEx.EqualTolerance(1, PowerRatio.FromDecibelMilliwatts(decibelwatt.DecibelMilliwatts).DecibelWatts, DecibelMilliwattsTolerance);
            AssertEx.EqualTolerance(1, PowerRatio.FromDecibelWatts(decibelwatt.DecibelWatts).DecibelWatts, DecibelWattsTolerance);
        }

        [Fact]
        public void LogarithmicArithmeticOperators()
        {
            PowerRatio v = PowerRatio.FromDecibelWatts(40);
            AssertEx.EqualTolerance(-40, -v.DecibelWatts, DecibelWattsTolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            AssertEx.EqualTolerance(50, (v*10).DecibelWatts, DecibelWattsTolerance);
            AssertEx.EqualTolerance(50, (10*v).DecibelWatts, DecibelWattsTolerance);
            AssertEx.EqualTolerance(35, (v/5).DecibelWatts, DecibelWattsTolerance);
            AssertEx.EqualTolerance(35, v/PowerRatio.FromDecibelWatts(5), DecibelWattsTolerance);
        }

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();


        [Fact]
        public void ComparisonOperators()
        {
            PowerRatio oneDecibelWatt = PowerRatio.FromDecibelWatts(1);
            PowerRatio twoDecibelWatts = PowerRatio.FromDecibelWatts(2);

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
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.Equal(0, decibelwatt.CompareTo(decibelwatt));
            Assert.True(decibelwatt.CompareTo(PowerRatio.Zero) > 0);
            Assert.True(PowerRatio.Zero.CompareTo(decibelwatt) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.Throws<ArgumentException>(() => decibelwatt.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.Throws<ArgumentNullException>(() => decibelwatt.CompareTo(null));
        }

        [Fact]
        public void EqualsIsImplemented()
        {
            PowerRatio v = PowerRatio.FromDecibelWatts(1);
            Assert.True(v.Equals(PowerRatio.FromDecibelWatts(1), DecibelWattsTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(PowerRatio.Zero, DecibelWattsTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.False(decibelwatt.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.False(decibelwatt.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(PowerRatioUnit.Undefined, PowerRatio.Units);
        }
    }
}
