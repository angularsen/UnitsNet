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
    /// Test of RotationalSpeedChangeRate.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class RotationalSpeedChangeRateTestsBase
    {
        protected abstract double RevolutionsPerMinutePerSecondInOneRevolutionPerSquareSecond { get; }
        protected abstract double RevolutionsPerSquareSecondInOneRevolutionPerSquareSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double RevolutionsPerMinutePerSecondTolerance { get { return 1e-5; } }
        protected virtual double RevolutionsPerSquareSecondTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void RevolutionPerSquareSecondToRotationalSpeedChangeRateUnits()
        {
            RotationalSpeedChangeRate revolutionpersquaresecond = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
            Assert.AreEqual(RevolutionsPerMinutePerSecondInOneRevolutionPerSquareSecond, revolutionpersquaresecond.RevolutionsPerMinutePerSecond, RevolutionsPerMinutePerSecondTolerance);
            Assert.AreEqual(RevolutionsPerSquareSecondInOneRevolutionPerSquareSecond, revolutionpersquaresecond.RevolutionsPerSquareSecond, RevolutionsPerSquareSecondTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, RotationalSpeedChangeRate.From(1, RotationalSpeedChangeRateUnit.RevolutionPerMinutePerSecond).RevolutionsPerMinutePerSecond, RevolutionsPerMinutePerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeedChangeRate.From(1, RotationalSpeedChangeRateUnit.RevolutionPerSquareSecond).RevolutionsPerSquareSecond, RevolutionsPerSquareSecondTolerance);
        }

        [Test]
        public void As()
        {
            var revolutionpersquaresecond = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
            Assert.AreEqual(RevolutionsPerMinutePerSecondInOneRevolutionPerSquareSecond, revolutionpersquaresecond.As(RotationalSpeedChangeRateUnit.RevolutionPerMinutePerSecond), RevolutionsPerMinutePerSecondTolerance);
            Assert.AreEqual(RevolutionsPerSquareSecondInOneRevolutionPerSquareSecond, revolutionpersquaresecond.As(RotationalSpeedChangeRateUnit.RevolutionPerSquareSecond), RevolutionsPerSquareSecondTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            RotationalSpeedChangeRate revolutionpersquaresecond = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
            Assert.AreEqual(1, RotationalSpeedChangeRate.FromRevolutionsPerMinutePerSecond(revolutionpersquaresecond.RevolutionsPerMinutePerSecond).RevolutionsPerSquareSecond, RevolutionsPerMinutePerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(revolutionpersquaresecond.RevolutionsPerSquareSecond).RevolutionsPerSquareSecond, RevolutionsPerSquareSecondTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            RotationalSpeedChangeRate v = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
            Assert.AreEqual(-1, -v.RevolutionsPerSquareSecond, RevolutionsPerSquareSecondTolerance);
            Assert.AreEqual(2, (RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(3)-v).RevolutionsPerSquareSecond, RevolutionsPerSquareSecondTolerance);
            Assert.AreEqual(2, (v + v).RevolutionsPerSquareSecond, RevolutionsPerSquareSecondTolerance);
            Assert.AreEqual(10, (v*10).RevolutionsPerSquareSecond, RevolutionsPerSquareSecondTolerance);
            Assert.AreEqual(10, (10*v).RevolutionsPerSquareSecond, RevolutionsPerSquareSecondTolerance);
            Assert.AreEqual(2, (RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(10)/5).RevolutionsPerSquareSecond, RevolutionsPerSquareSecondTolerance);
            Assert.AreEqual(2, RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(10)/RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(5), RevolutionsPerSquareSecondTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            RotationalSpeedChangeRate oneRevolutionPerSquareSecond = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
            RotationalSpeedChangeRate twoRevolutionsPerSquareSecond = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(2);

            Assert.True(oneRevolutionPerSquareSecond < twoRevolutionsPerSquareSecond);
            Assert.True(oneRevolutionPerSquareSecond <= twoRevolutionsPerSquareSecond);
            Assert.True(twoRevolutionsPerSquareSecond > oneRevolutionPerSquareSecond);
            Assert.True(twoRevolutionsPerSquareSecond >= oneRevolutionPerSquareSecond);

            Assert.False(oneRevolutionPerSquareSecond > twoRevolutionsPerSquareSecond);
            Assert.False(oneRevolutionPerSquareSecond >= twoRevolutionsPerSquareSecond);
            Assert.False(twoRevolutionsPerSquareSecond < oneRevolutionPerSquareSecond);
            Assert.False(twoRevolutionsPerSquareSecond <= oneRevolutionPerSquareSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            RotationalSpeedChangeRate revolutionpersquaresecond = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
            Assert.AreEqual(0, revolutionpersquaresecond.CompareTo(revolutionpersquaresecond));
            Assert.Greater(revolutionpersquaresecond.CompareTo(RotationalSpeedChangeRate.Zero), 0);
            Assert.Less(RotationalSpeedChangeRate.Zero.CompareTo(revolutionpersquaresecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            RotationalSpeedChangeRate revolutionpersquaresecond = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            revolutionpersquaresecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            RotationalSpeedChangeRate revolutionpersquaresecond = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            revolutionpersquaresecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            RotationalSpeedChangeRate a = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
            RotationalSpeedChangeRate b = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(2);

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
            RotationalSpeedChangeRate v = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
            Assert.IsTrue(v.Equals(RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1)));
            Assert.IsFalse(v.Equals(RotationalSpeedChangeRate.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            RotationalSpeedChangeRate revolutionpersquaresecond = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
            Assert.IsFalse(revolutionpersquaresecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            RotationalSpeedChangeRate revolutionpersquaresecond = RotationalSpeedChangeRate.FromRevolutionsPerSquareSecond(1);
            Assert.IsFalse(revolutionpersquaresecond.Equals(null));
        }
    }
}
