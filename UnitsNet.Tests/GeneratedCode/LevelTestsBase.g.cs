// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/anjdreas/UnitsNet
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
using NUnit.Framework;
using UnitsNet.Units;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Level.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class LevelTestsBase
    {
        protected abstract double DecibelsInOneDecibel { get; }
        protected abstract double NepersInOneDecibel { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DecibelsTolerance { get { return 1e-5; } }
        protected virtual double NepersTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void DecibelToLevelUnits()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.AreEqual(DecibelsInOneDecibel, decibel.Decibels, DecibelsTolerance);
            Assert.AreEqual(NepersInOneDecibel, decibel.Nepers, NepersTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Level.From(1, LevelUnit.Decibel).Decibels, DecibelsTolerance);
            Assert.AreEqual(1, Level.From(1, LevelUnit.Neper).Nepers, NepersTolerance);
        }

        [Test]
        public void As()
        {
            var decibel = Level.FromDecibels(1);
            Assert.AreEqual(DecibelsInOneDecibel, decibel.As(LevelUnit.Decibel), DecibelsTolerance);
            Assert.AreEqual(NepersInOneDecibel, decibel.As(LevelUnit.Neper), NepersTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.AreEqual(1, Level.FromDecibels(decibel.Decibels).Decibels, DecibelsTolerance);
            Assert.AreEqual(1, Level.FromNepers(decibel.Nepers).Decibels, NepersTolerance);
        }

        [Test]
        public void LogarithmicArithmeticOperators()
        {
            Level v = Level.FromDecibels(40);
            Assert.AreEqual(-40, -v.Decibels, NepersTolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            Assert.AreEqual(50, (v*10).Decibels, NepersTolerance);
            Assert.AreEqual(50, (10*v).Decibels, NepersTolerance);
            Assert.AreEqual(35, (v/5).Decibels, NepersTolerance);
            Assert.AreEqual(35, v/Level.FromDecibels(5), NepersTolerance);
        }

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();

        [Test]
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

        [Test]
        public void CompareToIsImplemented()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.AreEqual(0, decibel.CompareTo(decibel));
            Assert.Greater(decibel.CompareTo(Level.Zero), 0);
            Assert.Less(Level.Zero.CompareTo(decibel), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Level decibel = Level.FromDecibels(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            decibel.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Level decibel = Level.FromDecibels(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            decibel.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Level a = Level.FromDecibels(1);
            Level b = Level.FromDecibels(2);

// ReSharper disable EqualExpressionComparison
            Assert.True(a == a);
            Assert.True(a != b);

            Assert.False(a == b);
            Assert.False(a != a);
// ReSharper restore EqualExpressionComparison
        }

        [Test]
        public void EqualsIsImplemented()
        {
            Level v = Level.FromDecibels(1);
            Assert.IsTrue(v.Equals(Level.FromDecibels(1)));
            Assert.IsFalse(v.Equals(Level.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.IsFalse(decibel.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Level decibel = Level.FromDecibels(1);
            Assert.IsFalse(decibel.Equals(null));
        }
    }
}
