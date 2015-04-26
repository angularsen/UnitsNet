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
    /// Test of Speed.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class SpeedTestsBase
    {
        protected abstract double FeetPerSecondInOneMeterPerSecond { get; }
        protected abstract double KilometersPerHourInOneMeterPerSecond { get; }
        protected abstract double KnotsInOneMeterPerSecond { get; }
        protected abstract double MetersPerSecondInOneMeterPerSecond { get; }
        protected abstract double MilesPerHourInOneMeterPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double FeetPerSecondTolerance { get { return 1e-5; } }
        protected virtual double KilometersPerHourTolerance { get { return 1e-5; } }
        protected virtual double KnotsTolerance { get { return 1e-5; } }
        protected virtual double MetersPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MilesPerHourTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void MeterPerSecondToSpeedUnits()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(FeetPerSecondInOneMeterPerSecond, meterpersecond.FeetPerSecond, FeetPerSecondTolerance);
            Assert.AreEqual(KilometersPerHourInOneMeterPerSecond, meterpersecond.KilometersPerHour, KilometersPerHourTolerance);
            Assert.AreEqual(KnotsInOneMeterPerSecond, meterpersecond.Knots, KnotsTolerance);
            Assert.AreEqual(MetersPerSecondInOneMeterPerSecond, meterpersecond.MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(MilesPerHourInOneMeterPerSecond, meterpersecond.MilesPerHour, MilesPerHourTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.FootPerSecond).FeetPerSecond, FeetPerSecondTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.KilometerPerHour).KilometersPerHour, KilometersPerHourTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.Knot).Knots, KnotsTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.MeterPerSecond).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.MilePerHour).MilesPerHour, MilesPerHourTolerance);
        }

        [Test]
        public void As()
        {
            var meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(FeetPerSecondInOneMeterPerSecond, meterpersecond.As(SpeedUnit.FootPerSecond), FeetPerSecondTolerance);
            Assert.AreEqual(KilometersPerHourInOneMeterPerSecond, meterpersecond.As(SpeedUnit.KilometerPerHour), KilometersPerHourTolerance);
            Assert.AreEqual(KnotsInOneMeterPerSecond, meterpersecond.As(SpeedUnit.Knot), KnotsTolerance);
            Assert.AreEqual(MetersPerSecondInOneMeterPerSecond, meterpersecond.As(SpeedUnit.MeterPerSecond), MetersPerSecondTolerance);
            Assert.AreEqual(MilesPerHourInOneMeterPerSecond, meterpersecond.As(SpeedUnit.MilePerHour), MilesPerHourTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(1, Speed.FromFeetPerSecond(meterpersecond.FeetPerSecond).MetersPerSecond, FeetPerSecondTolerance);
            Assert.AreEqual(1, Speed.FromKilometersPerHour(meterpersecond.KilometersPerHour).MetersPerSecond, KilometersPerHourTolerance);
            Assert.AreEqual(1, Speed.FromKnots(meterpersecond.Knots).MetersPerSecond, KnotsTolerance);
            Assert.AreEqual(1, Speed.FromMetersPerSecond(meterpersecond.MetersPerSecond).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(1, Speed.FromMilesPerHour(meterpersecond.MilesPerHour).MetersPerSecond, MilesPerHourTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Speed v = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(-1, -v.MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(2, (Speed.FromMetersPerSecond(3)-v).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(2, (v + v).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(10, (v*10).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(10, (10*v).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(2, (Speed.FromMetersPerSecond(10)/5).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(2, Speed.FromMetersPerSecond(10)/Speed.FromMetersPerSecond(5), MetersPerSecondTolerance);
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
