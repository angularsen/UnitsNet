// Copyright ?2007 by Initial Force AS.  All rights reserved.
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
    /// Test of Acceleration.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class AccelerationTestsBase
    {
        protected abstract double MetrePerSecondSquaredInOneMetrePerSecondSquared { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double MetrePerSecondSquaredTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void MetrePerSecondSquaredToAccelerationUnits()
        {
            Acceleration metrepersecondsquared = Acceleration.FromMetrePerSecondSquared(1);
            Assert.AreEqual(MetrePerSecondSquaredInOneMetrePerSecondSquared, metrepersecondsquared.MetrePerSecondSquared, MetrePerSecondSquaredTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Acceleration.From(1, AccelerationUnit.MetrePerSecondSquared).MetrePerSecondSquared, MetrePerSecondSquaredTolerance);
        }

        [Test]
        public void As()
        {
            var metrepersecondsquared = Acceleration.FromMetrePerSecondSquared(1);
            Assert.AreEqual(MetrePerSecondSquaredInOneMetrePerSecondSquared, metrepersecondsquared.As(AccelerationUnit.MetrePerSecondSquared), MetrePerSecondSquaredTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Acceleration metrepersecondsquared = Acceleration.FromMetrePerSecondSquared(1);
            Assert.AreEqual(1, Acceleration.FromMetrePerSecondSquared(metrepersecondsquared.MetrePerSecondSquared).MetrePerSecondSquared, MetrePerSecondSquaredTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Acceleration v = Acceleration.FromMetrePerSecondSquared(1);
            Assert.AreEqual(-1, -v.MetrePerSecondSquared, MetrePerSecondSquaredTolerance);
            Assert.AreEqual(2, (Acceleration.FromMetrePerSecondSquared(3)-v).MetrePerSecondSquared, MetrePerSecondSquaredTolerance);
            Assert.AreEqual(2, (v + v).MetrePerSecondSquared, MetrePerSecondSquaredTolerance);
            Assert.AreEqual(10, (v*10).MetrePerSecondSquared, MetrePerSecondSquaredTolerance);
            Assert.AreEqual(10, (10*v).MetrePerSecondSquared, MetrePerSecondSquaredTolerance);
            Assert.AreEqual(2, (Acceleration.FromMetrePerSecondSquared(10)/5).MetrePerSecondSquared, MetrePerSecondSquaredTolerance);
            Assert.AreEqual(2, Acceleration.FromMetrePerSecondSquared(10)/Acceleration.FromMetrePerSecondSquared(5), MetrePerSecondSquaredTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Acceleration oneMetrePerSecondSquared = Acceleration.FromMetrePerSecondSquared(1);
            Acceleration twoMetrePerSecondSquared = Acceleration.FromMetrePerSecondSquared(2);

            Assert.True(oneMetrePerSecondSquared < twoMetrePerSecondSquared);
            Assert.True(oneMetrePerSecondSquared <= twoMetrePerSecondSquared);
            Assert.True(twoMetrePerSecondSquared > oneMetrePerSecondSquared);
            Assert.True(twoMetrePerSecondSquared >= oneMetrePerSecondSquared);

            Assert.False(oneMetrePerSecondSquared > twoMetrePerSecondSquared);
            Assert.False(oneMetrePerSecondSquared >= twoMetrePerSecondSquared);
            Assert.False(twoMetrePerSecondSquared < oneMetrePerSecondSquared);
            Assert.False(twoMetrePerSecondSquared <= oneMetrePerSecondSquared);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Acceleration metrepersecondsquared = Acceleration.FromMetrePerSecondSquared(1);
            Assert.AreEqual(0, metrepersecondsquared.CompareTo(metrepersecondsquared));
            Assert.Greater(metrepersecondsquared.CompareTo(Acceleration.Zero), 0);
            Assert.Less(Acceleration.Zero.CompareTo(metrepersecondsquared), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Acceleration metrepersecondsquared = Acceleration.FromMetrePerSecondSquared(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            metrepersecondsquared.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Acceleration metrepersecondsquared = Acceleration.FromMetrePerSecondSquared(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            metrepersecondsquared.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Acceleration a = Acceleration.FromMetrePerSecondSquared(1);
            Acceleration b = Acceleration.FromMetrePerSecondSquared(2);

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
            Acceleration v = Acceleration.FromMetrePerSecondSquared(1);
            Assert.IsTrue(v.Equals(Acceleration.FromMetrePerSecondSquared(1)));
            Assert.IsFalse(v.Equals(Acceleration.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Acceleration metrepersecondsquared = Acceleration.FromMetrePerSecondSquared(1);
            Assert.IsFalse(metrepersecondsquared.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Acceleration metrepersecondsquared = Acceleration.FromMetrePerSecondSquared(1);
            Assert.IsFalse(metrepersecondsquared.Equals(null));
        }
    }
}
