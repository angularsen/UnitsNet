// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
    /// Test of MassFlow.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MassFlowTestsBase
    {
        protected abstract double KilogramsPerSecondInOneKilogramPerSecond { get; }
        protected abstract double TonnesPerDayInOneKilogramPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KilogramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double TonnesPerDayTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void KilogramPerSecondToMassFlowUnits()
        {
            MassFlow kilogrampersecond = MassFlow.FromKilogramsPerSecond(1);
            Assert.AreEqual(KilogramsPerSecondInOneKilogramPerSecond, kilogrampersecond.KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(TonnesPerDayInOneKilogramPerSecond, kilogrampersecond.TonnesPerDay, TonnesPerDayTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.KilogramPerSecond).KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.TonnePerDay).TonnesPerDay, TonnesPerDayTolerance);
        }

        [Test]
        public void As()
        {
            var kilogrampersecond = MassFlow.FromKilogramsPerSecond(1);
            Assert.AreEqual(KilogramsPerSecondInOneKilogramPerSecond, kilogrampersecond.As(MassFlowUnit.KilogramPerSecond), KilogramsPerSecondTolerance);
            Assert.AreEqual(TonnesPerDayInOneKilogramPerSecond, kilogrampersecond.As(MassFlowUnit.TonnePerDay), TonnesPerDayTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            MassFlow kilogrampersecond = MassFlow.FromKilogramsPerSecond(1);
            Assert.AreEqual(1, MassFlow.FromKilogramsPerSecond(kilogrampersecond.KilogramsPerSecond).KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.FromTonnesPerDay(kilogrampersecond.TonnesPerDay).KilogramsPerSecond, TonnesPerDayTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            MassFlow v = MassFlow.FromKilogramsPerSecond(1);
            Assert.AreEqual(-1, -v.KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(2, (MassFlow.FromKilogramsPerSecond(3)-v).KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(2, (v + v).KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(10, (v*10).KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(10, (10*v).KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(2, (MassFlow.FromKilogramsPerSecond(10)/5).KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(2, MassFlow.FromKilogramsPerSecond(10)/MassFlow.FromKilogramsPerSecond(5), KilogramsPerSecondTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            MassFlow oneKilogramPerSecond = MassFlow.FromKilogramsPerSecond(1);
            MassFlow twoKilogramsPerSecond = MassFlow.FromKilogramsPerSecond(2);

            Assert.True(oneKilogramPerSecond < twoKilogramsPerSecond);
            Assert.True(oneKilogramPerSecond <= twoKilogramsPerSecond);
            Assert.True(twoKilogramsPerSecond > oneKilogramPerSecond);
            Assert.True(twoKilogramsPerSecond >= oneKilogramPerSecond);

            Assert.False(oneKilogramPerSecond > twoKilogramsPerSecond);
            Assert.False(oneKilogramPerSecond >= twoKilogramsPerSecond);
            Assert.False(twoKilogramsPerSecond < oneKilogramPerSecond);
            Assert.False(twoKilogramsPerSecond <= oneKilogramPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            MassFlow kilogrampersecond = MassFlow.FromKilogramsPerSecond(1);
            Assert.AreEqual(0, kilogrampersecond.CompareTo(kilogrampersecond));
            Assert.Greater(kilogrampersecond.CompareTo(MassFlow.Zero), 0);
            Assert.Less(MassFlow.Zero.CompareTo(kilogrampersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            MassFlow kilogrampersecond = MassFlow.FromKilogramsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogrampersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            MassFlow kilogrampersecond = MassFlow.FromKilogramsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogrampersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            MassFlow a = MassFlow.FromKilogramsPerSecond(1);
            MassFlow b = MassFlow.FromKilogramsPerSecond(2);

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
            MassFlow v = MassFlow.FromKilogramsPerSecond(1);
            Assert.IsTrue(v.Equals(MassFlow.FromKilogramsPerSecond(1)));
            Assert.IsFalse(v.Equals(MassFlow.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            MassFlow kilogrampersecond = MassFlow.FromKilogramsPerSecond(1);
            Assert.IsFalse(kilogrampersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            MassFlow kilogrampersecond = MassFlow.FromKilogramsPerSecond(1);
            Assert.IsFalse(kilogrampersecond.Equals(null));
        }
    }
}
