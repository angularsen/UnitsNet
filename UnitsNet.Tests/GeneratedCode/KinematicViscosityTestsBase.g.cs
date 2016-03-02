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
    /// Test of KinematicViscosity.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class KinematicViscosityTestsBase
    {
        protected abstract double CentistokesInOneSquareMeterPerSecond { get; }
        protected abstract double DecistokesInOneSquareMeterPerSecond { get; }
        protected abstract double KilostokesInOneSquareMeterPerSecond { get; }
        protected abstract double MicrostokesInOneSquareMeterPerSecond { get; }
        protected abstract double MillistokesInOneSquareMeterPerSecond { get; }
        protected abstract double NanostokesInOneSquareMeterPerSecond { get; }
        protected abstract double SquareMetersPerSecondInOneSquareMeterPerSecond { get; }
        protected abstract double StokesInOneSquareMeterPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentistokesTolerance { get { return 1e-5; } }
        protected virtual double DecistokesTolerance { get { return 1e-5; } }
        protected virtual double KilostokesTolerance { get { return 1e-5; } }
        protected virtual double MicrostokesTolerance { get { return 1e-5; } }
        protected virtual double MillistokesTolerance { get { return 1e-5; } }
        protected virtual double NanostokesTolerance { get { return 1e-5; } }
        protected virtual double SquareMetersPerSecondTolerance { get { return 1e-5; } }
        protected virtual double StokesTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void SquareMeterPerSecondToKinematicViscosityUnits()
        {
            KinematicViscosity squaremeterpersecond = KinematicViscosity.FromSquareMetersPerSecond(1);
            Assert.AreEqual(CentistokesInOneSquareMeterPerSecond, squaremeterpersecond.Centistokes, CentistokesTolerance);
            Assert.AreEqual(DecistokesInOneSquareMeterPerSecond, squaremeterpersecond.Decistokes, DecistokesTolerance);
            Assert.AreEqual(KilostokesInOneSquareMeterPerSecond, squaremeterpersecond.Kilostokes, KilostokesTolerance);
            Assert.AreEqual(MicrostokesInOneSquareMeterPerSecond, squaremeterpersecond.Microstokes, MicrostokesTolerance);
            Assert.AreEqual(MillistokesInOneSquareMeterPerSecond, squaremeterpersecond.Millistokes, MillistokesTolerance);
            Assert.AreEqual(NanostokesInOneSquareMeterPerSecond, squaremeterpersecond.Nanostokes, NanostokesTolerance);
            Assert.AreEqual(SquareMetersPerSecondInOneSquareMeterPerSecond, squaremeterpersecond.SquareMetersPerSecond, SquareMetersPerSecondTolerance);
            Assert.AreEqual(StokesInOneSquareMeterPerSecond, squaremeterpersecond.Stokes, StokesTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, KinematicViscosity.From(1, KinematicViscosityUnit.Centistokes).Centistokes, CentistokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.From(1, KinematicViscosityUnit.Decistokes).Decistokes, DecistokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.From(1, KinematicViscosityUnit.Kilostokes).Kilostokes, KilostokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.From(1, KinematicViscosityUnit.Microstokes).Microstokes, MicrostokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.From(1, KinematicViscosityUnit.Millistokes).Millistokes, MillistokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.From(1, KinematicViscosityUnit.Nanostokes).Nanostokes, NanostokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.From(1, KinematicViscosityUnit.SquareMeterPerSecond).SquareMetersPerSecond, SquareMetersPerSecondTolerance);
            Assert.AreEqual(1, KinematicViscosity.From(1, KinematicViscosityUnit.Stokes).Stokes, StokesTolerance);
        }

        [Test]
        public void As()
        {
            var squaremeterpersecond = KinematicViscosity.FromSquareMetersPerSecond(1);
            Assert.AreEqual(CentistokesInOneSquareMeterPerSecond, squaremeterpersecond.As(KinematicViscosityUnit.Centistokes), CentistokesTolerance);
            Assert.AreEqual(DecistokesInOneSquareMeterPerSecond, squaremeterpersecond.As(KinematicViscosityUnit.Decistokes), DecistokesTolerance);
            Assert.AreEqual(KilostokesInOneSquareMeterPerSecond, squaremeterpersecond.As(KinematicViscosityUnit.Kilostokes), KilostokesTolerance);
            Assert.AreEqual(MicrostokesInOneSquareMeterPerSecond, squaremeterpersecond.As(KinematicViscosityUnit.Microstokes), MicrostokesTolerance);
            Assert.AreEqual(MillistokesInOneSquareMeterPerSecond, squaremeterpersecond.As(KinematicViscosityUnit.Millistokes), MillistokesTolerance);
            Assert.AreEqual(NanostokesInOneSquareMeterPerSecond, squaremeterpersecond.As(KinematicViscosityUnit.Nanostokes), NanostokesTolerance);
            Assert.AreEqual(SquareMetersPerSecondInOneSquareMeterPerSecond, squaremeterpersecond.As(KinematicViscosityUnit.SquareMeterPerSecond), SquareMetersPerSecondTolerance);
            Assert.AreEqual(StokesInOneSquareMeterPerSecond, squaremeterpersecond.As(KinematicViscosityUnit.Stokes), StokesTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            KinematicViscosity squaremeterpersecond = KinematicViscosity.FromSquareMetersPerSecond(1);
            Assert.AreEqual(1, KinematicViscosity.FromCentistokes(squaremeterpersecond.Centistokes).SquareMetersPerSecond, CentistokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.FromDecistokes(squaremeterpersecond.Decistokes).SquareMetersPerSecond, DecistokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.FromKilostokes(squaremeterpersecond.Kilostokes).SquareMetersPerSecond, KilostokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.FromMicrostokes(squaremeterpersecond.Microstokes).SquareMetersPerSecond, MicrostokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.FromMillistokes(squaremeterpersecond.Millistokes).SquareMetersPerSecond, MillistokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.FromNanostokes(squaremeterpersecond.Nanostokes).SquareMetersPerSecond, NanostokesTolerance);
            Assert.AreEqual(1, KinematicViscosity.FromSquareMetersPerSecond(squaremeterpersecond.SquareMetersPerSecond).SquareMetersPerSecond, SquareMetersPerSecondTolerance);
            Assert.AreEqual(1, KinematicViscosity.FromStokes(squaremeterpersecond.Stokes).SquareMetersPerSecond, StokesTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            KinematicViscosity v = KinematicViscosity.FromSquareMetersPerSecond(1);
            Assert.AreEqual(-1, -v.SquareMetersPerSecond, SquareMetersPerSecondTolerance);
            Assert.AreEqual(2, (KinematicViscosity.FromSquareMetersPerSecond(3)-v).SquareMetersPerSecond, SquareMetersPerSecondTolerance);
            Assert.AreEqual(2, (v + v).SquareMetersPerSecond, SquareMetersPerSecondTolerance);
            Assert.AreEqual(10, (v*10).SquareMetersPerSecond, SquareMetersPerSecondTolerance);
            Assert.AreEqual(10, (10*v).SquareMetersPerSecond, SquareMetersPerSecondTolerance);
            Assert.AreEqual(2, (KinematicViscosity.FromSquareMetersPerSecond(10)/5).SquareMetersPerSecond, SquareMetersPerSecondTolerance);
            Assert.AreEqual(2, KinematicViscosity.FromSquareMetersPerSecond(10)/KinematicViscosity.FromSquareMetersPerSecond(5), SquareMetersPerSecondTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            KinematicViscosity oneSquareMeterPerSecond = KinematicViscosity.FromSquareMetersPerSecond(1);
            KinematicViscosity twoSquareMetersPerSecond = KinematicViscosity.FromSquareMetersPerSecond(2);

            Assert.True(oneSquareMeterPerSecond < twoSquareMetersPerSecond);
            Assert.True(oneSquareMeterPerSecond <= twoSquareMetersPerSecond);
            Assert.True(twoSquareMetersPerSecond > oneSquareMeterPerSecond);
            Assert.True(twoSquareMetersPerSecond >= oneSquareMeterPerSecond);

            Assert.False(oneSquareMeterPerSecond > twoSquareMetersPerSecond);
            Assert.False(oneSquareMeterPerSecond >= twoSquareMetersPerSecond);
            Assert.False(twoSquareMetersPerSecond < oneSquareMeterPerSecond);
            Assert.False(twoSquareMetersPerSecond <= oneSquareMeterPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            KinematicViscosity squaremeterpersecond = KinematicViscosity.FromSquareMetersPerSecond(1);
            Assert.AreEqual(0, squaremeterpersecond.CompareTo(squaremeterpersecond));
            Assert.Greater(squaremeterpersecond.CompareTo(KinematicViscosity.Zero), 0);
            Assert.Less(KinematicViscosity.Zero.CompareTo(squaremeterpersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            KinematicViscosity squaremeterpersecond = KinematicViscosity.FromSquareMetersPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            squaremeterpersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            KinematicViscosity squaremeterpersecond = KinematicViscosity.FromSquareMetersPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            squaremeterpersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            KinematicViscosity a = KinematicViscosity.FromSquareMetersPerSecond(1);
            KinematicViscosity b = KinematicViscosity.FromSquareMetersPerSecond(2);

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
            KinematicViscosity v = KinematicViscosity.FromSquareMetersPerSecond(1);
            Assert.IsTrue(v.Equals(KinematicViscosity.FromSquareMetersPerSecond(1)));
            Assert.IsFalse(v.Equals(KinematicViscosity.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            KinematicViscosity squaremeterpersecond = KinematicViscosity.FromSquareMetersPerSecond(1);
            Assert.IsFalse(squaremeterpersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            KinematicViscosity squaremeterpersecond = KinematicViscosity.FromSquareMetersPerSecond(1);
            Assert.IsFalse(squaremeterpersecond.Equals(null));
        }
    }
}
