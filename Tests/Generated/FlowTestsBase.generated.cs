// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Flow.
    /// </summary>
    public abstract partial class FlowTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        protected abstract double CubicMetersPerHourInOneCubicMeterPerSecond { get; }
        protected abstract double CubicMetersPerSecondInOneCubicMeterPerSecond { get; }

        [Test]
        public void CubicMeterPerSecondToFlowUnits()
        {
            Flow cubicmeterpersecond = Flow.FromCubicMetersPerSecond(1);
            Assert.AreEqual(CubicMetersPerHourInOneCubicMeterPerSecond, cubicmeterpersecond.CubicMetersPerHour, Delta);
            Assert.AreEqual(CubicMetersPerSecondInOneCubicMeterPerSecond, cubicmeterpersecond.CubicMetersPerSecond, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Flow cubicmeterpersecond = Flow.FromCubicMetersPerSecond(1); 
            Assert.AreEqual(1, Flow.FromCubicMetersPerHour(cubicmeterpersecond.CubicMetersPerHour).CubicMetersPerSecond, Delta);
            Assert.AreEqual(1, Flow.FromCubicMetersPerSecond(cubicmeterpersecond.CubicMetersPerSecond).CubicMetersPerSecond, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Flow v = Flow.FromCubicMetersPerSecond(1);
            Assert.AreEqual(-1, -v.CubicMetersPerSecond, Delta);
            Assert.AreEqual(2, (Flow.FromCubicMetersPerSecond(3)-v).CubicMetersPerSecond, Delta);
            Assert.AreEqual(2, (v + v).CubicMetersPerSecond, Delta);
            Assert.AreEqual(10, (v*10).CubicMetersPerSecond, Delta);
            Assert.AreEqual(10, (10*v).CubicMetersPerSecond, Delta);
            Assert.AreEqual(2, (Flow.FromCubicMetersPerSecond(10)/5).CubicMetersPerSecond, Delta);
            Assert.AreEqual(2, Flow.FromCubicMetersPerSecond(10)/Flow.FromCubicMetersPerSecond(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Flow oneCubicMeterPerSecond = Flow.FromCubicMetersPerSecond(1);
            Flow twoCubicMetersPerSecond = Flow.FromCubicMetersPerSecond(2);

            Assert.True(oneCubicMeterPerSecond < twoCubicMetersPerSecond);
            Assert.True(oneCubicMeterPerSecond <= twoCubicMetersPerSecond);
            Assert.True(twoCubicMetersPerSecond > oneCubicMeterPerSecond);
            Assert.True(twoCubicMetersPerSecond >= oneCubicMeterPerSecond);

            Assert.False(oneCubicMeterPerSecond > twoCubicMetersPerSecond);
            Assert.False(oneCubicMeterPerSecond >= twoCubicMetersPerSecond);
            Assert.False(twoCubicMetersPerSecond < oneCubicMeterPerSecond);
            Assert.False(twoCubicMetersPerSecond <= oneCubicMeterPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Flow cubicmeterpersecond = Flow.FromCubicMetersPerSecond(1);
            Assert.AreEqual(0, cubicmeterpersecond.CompareTo(cubicmeterpersecond));
            Assert.Greater(cubicmeterpersecond.CompareTo(Flow.Zero), 0);
            Assert.Less(Flow.Zero.CompareTo(cubicmeterpersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Flow cubicmeterpersecond = Flow.FromCubicMetersPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            cubicmeterpersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Flow cubicmeterpersecond = Flow.FromCubicMetersPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            cubicmeterpersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Flow a = Flow.FromCubicMetersPerSecond(1);
            Flow b = Flow.FromCubicMetersPerSecond(2);

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
            Flow v = Flow.FromCubicMetersPerSecond(1);
            Assert.IsTrue(v.Equals(Flow.FromCubicMetersPerSecond(1)));
            Assert.IsFalse(v.Equals(Flow.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Flow cubicmeterpersecond = Flow.FromCubicMetersPerSecond(1);
            Assert.IsFalse(cubicmeterpersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Flow cubicmeterpersecond = Flow.FromCubicMetersPerSecond(1);
            Assert.IsFalse(cubicmeterpersecond.Equals(null));
        }
    }
}
