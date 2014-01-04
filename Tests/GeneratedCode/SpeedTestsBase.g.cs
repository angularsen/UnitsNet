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
    /// Test of Speed.
    /// </summary>
    [TestFixture]
    public abstract partial class SpeedTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        public abstract double FeetPerSecondInOneMeterPerSecond { get; }
        public abstract double KilometersPerHourInOneMeterPerSecond { get; }
        public abstract double KnotsInOneMeterPerSecond { get; }
        public abstract double MetersPerSecondInOneMeterPerSecond { get; }
        public abstract double MilesPerHourInOneMeterPerSecond { get; }

        [Test]
        public void MeterPerSecondToSpeedUnits()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(FeetPerSecondInOneMeterPerSecond, meterpersecond.FeetPerSecond, Delta);
            Assert.AreEqual(KilometersPerHourInOneMeterPerSecond, meterpersecond.KilometersPerHour, Delta);
            Assert.AreEqual(KnotsInOneMeterPerSecond, meterpersecond.Knots, Delta);
            Assert.AreEqual(MetersPerSecondInOneMeterPerSecond, meterpersecond.MetersPerSecond, Delta);
            Assert.AreEqual(MilesPerHourInOneMeterPerSecond, meterpersecond.MilesPerHour, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1); 
            Assert.AreEqual(1, Speed.FromFeetPerSecond(meterpersecond.FeetPerSecond).MetersPerSecond, Delta);
            Assert.AreEqual(1, Speed.FromKilometersPerHour(meterpersecond.KilometersPerHour).MetersPerSecond, Delta);
            Assert.AreEqual(1, Speed.FromKnots(meterpersecond.Knots).MetersPerSecond, Delta);
            Assert.AreEqual(1, Speed.FromMetersPerSecond(meterpersecond.MetersPerSecond).MetersPerSecond, Delta);
            Assert.AreEqual(1, Speed.FromMilesPerHour(meterpersecond.MilesPerHour).MetersPerSecond, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Speed v = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(-1, -v.MetersPerSecond, Delta);
            Assert.AreEqual(2, (Speed.FromMetersPerSecond(3)-v).MetersPerSecond, Delta);
            Assert.AreEqual(2, (v + v).MetersPerSecond, Delta);
            Assert.AreEqual(10, (v*10).MetersPerSecond, Delta);
            Assert.AreEqual(10, (10*v).MetersPerSecond, Delta);
            Assert.AreEqual(2, (Speed.FromMetersPerSecond(10)/5).MetersPerSecond, Delta);
            Assert.AreEqual(2, Speed.FromMetersPerSecond(10)/Speed.FromMetersPerSecond(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Speed oneMeterPerSecond = Speed.FromMetersPerSecond(1);
            Speed twoMetersPerSecond = Speed.FromMetersPerSecond(2);

            Assert.True(oneMeterPerSecond < twoMetersPerSecond);
            Assert.True(oneMeterPerSecond <= twoMetersPerSecond);
            Assert.True(twoMetersPerSecond > oneMeterPerSecond);
            Assert.True(twoMetersPerSecond >= oneMeterPerSecond);

            Assert.False(oneMeterPerSecond > twoMetersPerSecond);
            Assert.False(oneMeterPerSecond >= twoMetersPerSecond);
            Assert.False(twoMetersPerSecond < oneMeterPerSecond);
            Assert.False(twoMetersPerSecond <= oneMeterPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(0, meterpersecond.CompareTo(meterpersecond));
            Assert.Greater(meterpersecond.CompareTo(Speed.Zero), 0);
            Assert.Less(Speed.Zero.CompareTo(meterpersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meterpersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meterpersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Speed a = Speed.FromMetersPerSecond(1);
            Speed b = Speed.FromMetersPerSecond(2);

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
            Speed v = Speed.FromMetersPerSecond(1);
            Assert.IsTrue(v.Equals(Speed.FromMetersPerSecond(1)));
            Assert.IsFalse(v.Equals(Speed.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.IsFalse(meterpersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.IsFalse(meterpersecond.Equals(null));
        }
    }
}
