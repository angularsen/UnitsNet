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
    /// Test of Level.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class LevelTestsBase
    {
        protected abstract double DecibelsInOneDecibel { get; }
        protected abstract double NepersInOneDecibel { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DecibelsTolerance { get { return 1e-5; } }
        protected virtual double NepersTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void ConstructorWithUndefinedUnitThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Level((double)0.0, LevelUnit.Undefined));
        }

        [Fact]
        public void DecibelToLevelUnits()
        {
            Level decibel = Level.FromDecibels(1);
            AssertEx.EqualTolerance(DecibelsInOneDecibel, decibel.Decibels, DecibelsTolerance);
            AssertEx.EqualTolerance(NepersInOneDecibel, decibel.Nepers, NepersTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, Level.From(1, LevelUnit.Decibel).Decibels, DecibelsTolerance);
            AssertEx.EqualTolerance(1, Level.From(1, LevelUnit.Neper).Nepers, NepersTolerance);
        }

        [Fact]
        public void As()
        {
            var decibel = Level.FromDecibels(1);
            AssertEx.EqualTolerance(DecibelsInOneDecibel, decibel.As(LevelUnit.Decibel), DecibelsTolerance);
            AssertEx.EqualTolerance(NepersInOneDecibel, decibel.As(LevelUnit.Neper), NepersTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var decibel = Level.FromDecibels(1);

            var decibelQuantity = decibel.ToUnit(LevelUnit.Decibel);
            AssertEx.EqualTolerance(DecibelsInOneDecibel, (double)decibelQuantity.Value, DecibelsTolerance);
            Assert.Equal(LevelUnit.Decibel, decibelQuantity.Unit);

            var neperQuantity = decibel.ToUnit(LevelUnit.Neper);
            AssertEx.EqualTolerance(NepersInOneDecibel, (double)neperQuantity.Value, NepersTolerance);
            Assert.Equal(LevelUnit.Neper, neperQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Level decibel = Level.FromDecibels(1);
            AssertEx.EqualTolerance(1, Level.FromDecibels(decibel.Decibels).Decibels, DecibelsTolerance);
            AssertEx.EqualTolerance(1, Level.FromNepers(decibel.Nepers).Decibels, NepersTolerance);
        }

        [Fact]
        public void LogarithmicArithmeticOperators()
        {
            Level v = Level.FromDecibels(40);
            AssertEx.EqualTolerance(-40, -v.Decibels, NepersTolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            AssertEx.EqualTolerance(50, (v*10).Decibels, NepersTolerance);
            AssertEx.EqualTolerance(50, (10*v).Decibels, NepersTolerance);
            AssertEx.EqualTolerance(35, (v/5).Decibels, NepersTolerance);
            AssertEx.EqualTolerance(35, v/Level.FromDecibels(5), NepersTolerance);
        }

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();


        [Fact]
        public void ComparisonOperators()
        {
            Level oneDecibel = Level.FromDecibels(1);
            Level twoDecibels = Level.FromDecibels(2);

            Assert.True(oneDecibel < twoDecibels);
            Assert.True(oneDecibel <= twoDecibels);
            Assert.True(twoDecibels > oneDecibel);
            Assert.True(twoDecibels >= oneDecibel);

            Assert.False(oneDecibel > twoDecibels);
            Assert.False(oneDecibel >= twoDecibels);
            Assert.False(twoDecibels < oneDecibel);
            Assert.False(twoDecibels <= oneDecibel);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.Equal(0, decibel.CompareTo(decibel));
            Assert.True(decibel.CompareTo(Level.Zero) > 0);
            Assert.True(Level.Zero.CompareTo(decibel) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.Throws<ArgumentException>(() => decibel.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.Throws<ArgumentNullException>(() => decibel.CompareTo(null));
        }

        [Fact]
        public void EqualsIsImplemented()
        {
            Level v = Level.FromDecibels(1);
            Assert.True(v.Equals(Level.FromDecibels(1), DecibelsTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Level.Zero, DecibelsTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.False(decibel.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.False(decibel.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(LevelUnit.Undefined, Level.Units);
        }
    }
}
