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
    /// Test of RatioChangeRate.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class RatioChangeRateTestsBase
    {
        protected abstract double DecimalFractionsPerSecondInOnePercentPerSecond { get; }
        protected abstract double PercentsPerSecondInOnePercentPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DecimalFractionsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double PercentsPerSecondTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void PercentPerSecondToRatioChangeRateUnits()
        {
            RatioChangeRate percentpersecond = RatioChangeRate.FromPercentsPerSecond(1);
            Assert.AreEqual(DecimalFractionsPerSecondInOnePercentPerSecond, percentpersecond.DecimalFractionsPerSecond, DecimalFractionsPerSecondTolerance);
            Assert.AreEqual(PercentsPerSecondInOnePercentPerSecond, percentpersecond.PercentsPerSecond, PercentsPerSecondTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, RatioChangeRate.From(1, RatioChangeRateUnit.DecimalFractionPerSecond).DecimalFractionsPerSecond, DecimalFractionsPerSecondTolerance);
            Assert.AreEqual(1, RatioChangeRate.From(1, RatioChangeRateUnit.PercentPerSecond).PercentsPerSecond, PercentsPerSecondTolerance);
        }

        [Test]
        public void As()
        {
            var percentpersecond = RatioChangeRate.FromPercentsPerSecond(1);
            Assert.AreEqual(DecimalFractionsPerSecondInOnePercentPerSecond, percentpersecond.As(RatioChangeRateUnit.DecimalFractionPerSecond), DecimalFractionsPerSecondTolerance);
            Assert.AreEqual(PercentsPerSecondInOnePercentPerSecond, percentpersecond.As(RatioChangeRateUnit.PercentPerSecond), PercentsPerSecondTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            RatioChangeRate percentpersecond = RatioChangeRate.FromPercentsPerSecond(1);
            Assert.AreEqual(1, RatioChangeRate.FromDecimalFractionsPerSecond(percentpersecond.DecimalFractionsPerSecond).PercentsPerSecond, DecimalFractionsPerSecondTolerance);
            Assert.AreEqual(1, RatioChangeRate.FromPercentsPerSecond(percentpersecond.PercentsPerSecond).PercentsPerSecond, PercentsPerSecondTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            RatioChangeRate v = RatioChangeRate.FromPercentsPerSecond(1);
            Assert.AreEqual(-1, -v.PercentsPerSecond, PercentsPerSecondTolerance);
            Assert.AreEqual(2, (RatioChangeRate.FromPercentsPerSecond(3)-v).PercentsPerSecond, PercentsPerSecondTolerance);
            Assert.AreEqual(2, (v + v).PercentsPerSecond, PercentsPerSecondTolerance);
            Assert.AreEqual(10, (v*10).PercentsPerSecond, PercentsPerSecondTolerance);
            Assert.AreEqual(10, (10*v).PercentsPerSecond, PercentsPerSecondTolerance);
            Assert.AreEqual(2, (RatioChangeRate.FromPercentsPerSecond(10)/5).PercentsPerSecond, PercentsPerSecondTolerance);
            Assert.AreEqual(2, RatioChangeRate.FromPercentsPerSecond(10)/RatioChangeRate.FromPercentsPerSecond(5), PercentsPerSecondTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            RatioChangeRate onePercentPerSecond = RatioChangeRate.FromPercentsPerSecond(1);
            RatioChangeRate twoPercentsPerSecond = RatioChangeRate.FromPercentsPerSecond(2);

            Assert.True(onePercentPerSecond < twoPercentsPerSecond);
            Assert.True(onePercentPerSecond <= twoPercentsPerSecond);
            Assert.True(twoPercentsPerSecond > onePercentPerSecond);
            Assert.True(twoPercentsPerSecond >= onePercentPerSecond);

            Assert.False(onePercentPerSecond > twoPercentsPerSecond);
            Assert.False(onePercentPerSecond >= twoPercentsPerSecond);
            Assert.False(twoPercentsPerSecond < onePercentPerSecond);
            Assert.False(twoPercentsPerSecond <= onePercentPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            RatioChangeRate percentpersecond = RatioChangeRate.FromPercentsPerSecond(1);
            Assert.AreEqual(0, percentpersecond.CompareTo(percentpersecond));
            Assert.Greater(percentpersecond.CompareTo(RatioChangeRate.Zero), 0);
            Assert.Less(RatioChangeRate.Zero.CompareTo(percentpersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            RatioChangeRate percentpersecond = RatioChangeRate.FromPercentsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            percentpersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            RatioChangeRate percentpersecond = RatioChangeRate.FromPercentsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            percentpersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            RatioChangeRate a = RatioChangeRate.FromPercentsPerSecond(1);
            RatioChangeRate b = RatioChangeRate.FromPercentsPerSecond(2);

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
            RatioChangeRate v = RatioChangeRate.FromPercentsPerSecond(1);
            Assert.IsTrue(v.Equals(RatioChangeRate.FromPercentsPerSecond(1)));
            Assert.IsFalse(v.Equals(RatioChangeRate.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            RatioChangeRate percentpersecond = RatioChangeRate.FromPercentsPerSecond(1);
            Assert.IsFalse(percentpersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            RatioChangeRate percentpersecond = RatioChangeRate.FromPercentsPerSecond(1);
            Assert.IsFalse(percentpersecond.Equals(null));
        }
    }
}
