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
    /// Test of PowerRatio.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class PowerRatioTestsBase
    {
        protected abstract double DecibelMilliwattsInOneDecibelWatt { get; }
        protected abstract double DecibelWattsInOneDecibelWatt { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DecibelMilliwattsTolerance { get { return 1e-5; } }
        protected virtual double DecibelWattsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void DecibelWattToPowerRatioUnits()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.AreEqual(DecibelMilliwattsInOneDecibelWatt, decibelwatt.DecibelMilliwatts, DecibelMilliwattsTolerance);
            Assert.AreEqual(DecibelWattsInOneDecibelWatt, decibelwatt.DecibelWatts, DecibelWattsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, PowerRatio.From(1, PowerRatioUnit.DecibelMilliwatt).DecibelMilliwatts, DecibelMilliwattsTolerance);
            Assert.AreEqual(1, PowerRatio.From(1, PowerRatioUnit.DecibelWatt).DecibelWatts, DecibelWattsTolerance);
        }

        [Test]
        public void As()
        {
            var decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.AreEqual(DecibelMilliwattsInOneDecibelWatt, decibelwatt.As(PowerRatioUnit.DecibelMilliwatt), DecibelMilliwattsTolerance);
            Assert.AreEqual(DecibelWattsInOneDecibelWatt, decibelwatt.As(PowerRatioUnit.DecibelWatt), DecibelWattsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.AreEqual(1, PowerRatio.FromDecibelMilliwatts(decibelwatt.DecibelMilliwatts).DecibelWatts, DecibelMilliwattsTolerance);
            Assert.AreEqual(1, PowerRatio.FromDecibelWatts(decibelwatt.DecibelWatts).DecibelWatts, DecibelWattsTolerance);
        }

        [Test]
        public void LogarithmicArithmeticOperators()
        {
            PowerRatio v = PowerRatio.FromDecibelWatts(40);
            Assert.AreEqual(-40, -v.DecibelWatts, DecibelWattsTolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            Assert.AreEqual(50, (v*10).DecibelWatts, DecibelWattsTolerance);
            Assert.AreEqual(50, (10*v).DecibelWatts, DecibelWattsTolerance);
            Assert.AreEqual(35, (v/5).DecibelWatts, DecibelWattsTolerance);
            Assert.AreEqual(35, v/PowerRatio.FromDecibelWatts(5), DecibelWattsTolerance);
        }

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();

        [Test]
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

        [Test]
        public void CompareToIsImplemented()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.AreEqual(0, decibelwatt.CompareTo(decibelwatt));
            Assert.Greater(decibelwatt.CompareTo(PowerRatio.Zero), 0);
            Assert.Less(PowerRatio.Zero.CompareTo(decibelwatt), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            decibelwatt.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            decibelwatt.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            PowerRatio a = PowerRatio.FromDecibelWatts(1);
            PowerRatio b = PowerRatio.FromDecibelWatts(2);

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
            PowerRatio v = PowerRatio.FromDecibelWatts(1);
            Assert.IsTrue(v.Equals(PowerRatio.FromDecibelWatts(1)));
            Assert.IsFalse(v.Equals(PowerRatio.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.IsFalse(decibelwatt.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            PowerRatio decibelwatt = PowerRatio.FromDecibelWatts(1);
            Assert.IsFalse(decibelwatt.Equals(null));
        }
    }
}
