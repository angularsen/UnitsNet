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
    /// Test of Area.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class AreaTestsBase
    {
        protected abstract double CentisquareMetersInOneSquareMeter { get; }
        protected abstract double DecisquareMetersInOneSquareMeter { get; }
        protected abstract double KilosquareMetersInOneSquareMeter { get; }
        protected abstract double MicrosquareMetersInOneSquareMeter { get; }
        protected abstract double MillisquareMetersInOneSquareMeter { get; }
        protected abstract double NanosquareMetersInOneSquareMeter { get; }
        protected abstract double SquareFeetInOneSquareMeter { get; }
        protected abstract double SquareInchesInOneSquareMeter { get; }
        protected abstract double SquareMetersInOneSquareMeter { get; }
        protected abstract double SquareMilesInOneSquareMeter { get; }
        protected abstract double SquareYardsInOneSquareMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentisquareMetersTolerance { get { return 1e-5; } }
        protected virtual double DecisquareMetersTolerance { get { return 1e-5; } }
        protected virtual double KilosquareMetersTolerance { get { return 1e-5; } }
        protected virtual double MicrosquareMetersTolerance { get { return 1e-5; } }
        protected virtual double MillisquareMetersTolerance { get { return 1e-5; } }
        protected virtual double NanosquareMetersTolerance { get { return 1e-5; } }
        protected virtual double SquareFeetTolerance { get { return 1e-5; } }
        protected virtual double SquareInchesTolerance { get { return 1e-5; } }
        protected virtual double SquareMetersTolerance { get { return 1e-5; } }
        protected virtual double SquareMilesTolerance { get { return 1e-5; } }
        protected virtual double SquareYardsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void SquareMeterToAreaUnits()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.AreEqual(CentisquareMetersInOneSquareMeter, squaremeter.CentisquareMeters, CentisquareMetersTolerance);
            Assert.AreEqual(DecisquareMetersInOneSquareMeter, squaremeter.DecisquareMeters, DecisquareMetersTolerance);
            Assert.AreEqual(KilosquareMetersInOneSquareMeter, squaremeter.KilosquareMeters, KilosquareMetersTolerance);
            Assert.AreEqual(MicrosquareMetersInOneSquareMeter, squaremeter.MicrosquareMeters, MicrosquareMetersTolerance);
            Assert.AreEqual(MillisquareMetersInOneSquareMeter, squaremeter.MillisquareMeters, MillisquareMetersTolerance);
            Assert.AreEqual(NanosquareMetersInOneSquareMeter, squaremeter.NanosquareMeters, NanosquareMetersTolerance);
            Assert.AreEqual(SquareFeetInOneSquareMeter, squaremeter.SquareFeet, SquareFeetTolerance);
            Assert.AreEqual(SquareInchesInOneSquareMeter, squaremeter.SquareInches, SquareInchesTolerance);
            Assert.AreEqual(SquareMetersInOneSquareMeter, squaremeter.SquareMeters, SquareMetersTolerance);
            Assert.AreEqual(SquareMilesInOneSquareMeter, squaremeter.SquareMiles, SquareMilesTolerance);
            Assert.AreEqual(SquareYardsInOneSquareMeter, squaremeter.SquareYards, SquareYardsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Area.From(1, AreaUnit.CentisquareMeter).CentisquareMeters, CentisquareMetersTolerance);
            Assert.AreEqual(1, Area.From(1, AreaUnit.DecisquareMeter).DecisquareMeters, DecisquareMetersTolerance);
            Assert.AreEqual(1, Area.From(1, AreaUnit.KilosquareMeter).KilosquareMeters, KilosquareMetersTolerance);
            Assert.AreEqual(1, Area.From(1, AreaUnit.MicrosquareMeter).MicrosquareMeters, MicrosquareMetersTolerance);
            Assert.AreEqual(1, Area.From(1, AreaUnit.MillisquareMeter).MillisquareMeters, MillisquareMetersTolerance);
            Assert.AreEqual(1, Area.From(1, AreaUnit.NanosquareMeter).NanosquareMeters, NanosquareMetersTolerance);
            Assert.AreEqual(1, Area.From(1, AreaUnit.SquareFoot).SquareFeet, SquareFeetTolerance);
            Assert.AreEqual(1, Area.From(1, AreaUnit.SquareInch).SquareInches, SquareInchesTolerance);
            Assert.AreEqual(1, Area.From(1, AreaUnit.SquareMeter).SquareMeters, SquareMetersTolerance);
            Assert.AreEqual(1, Area.From(1, AreaUnit.SquareMile).SquareMiles, SquareMilesTolerance);
            Assert.AreEqual(1, Area.From(1, AreaUnit.SquareYard).SquareYards, SquareYardsTolerance);
        }

        [Test]
        public void As()
        {
            var squaremeter = Area.FromSquareMeters(1);
            Assert.AreEqual(CentisquareMetersInOneSquareMeter, squaremeter.As(AreaUnit.CentisquareMeter), CentisquareMetersTolerance);
            Assert.AreEqual(DecisquareMetersInOneSquareMeter, squaremeter.As(AreaUnit.DecisquareMeter), DecisquareMetersTolerance);
            Assert.AreEqual(KilosquareMetersInOneSquareMeter, squaremeter.As(AreaUnit.KilosquareMeter), KilosquareMetersTolerance);
            Assert.AreEqual(MicrosquareMetersInOneSquareMeter, squaremeter.As(AreaUnit.MicrosquareMeter), MicrosquareMetersTolerance);
            Assert.AreEqual(MillisquareMetersInOneSquareMeter, squaremeter.As(AreaUnit.MillisquareMeter), MillisquareMetersTolerance);
            Assert.AreEqual(NanosquareMetersInOneSquareMeter, squaremeter.As(AreaUnit.NanosquareMeter), NanosquareMetersTolerance);
            Assert.AreEqual(SquareFeetInOneSquareMeter, squaremeter.As(AreaUnit.SquareFoot), SquareFeetTolerance);
            Assert.AreEqual(SquareInchesInOneSquareMeter, squaremeter.As(AreaUnit.SquareInch), SquareInchesTolerance);
            Assert.AreEqual(SquareMetersInOneSquareMeter, squaremeter.As(AreaUnit.SquareMeter), SquareMetersTolerance);
            Assert.AreEqual(SquareMilesInOneSquareMeter, squaremeter.As(AreaUnit.SquareMile), SquareMilesTolerance);
            Assert.AreEqual(SquareYardsInOneSquareMeter, squaremeter.As(AreaUnit.SquareYard), SquareYardsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.AreEqual(1, Area.FromCentisquareMeters(squaremeter.CentisquareMeters).SquareMeters, CentisquareMetersTolerance);
            Assert.AreEqual(1, Area.FromDecisquareMeters(squaremeter.DecisquareMeters).SquareMeters, DecisquareMetersTolerance);
            Assert.AreEqual(1, Area.FromKilosquareMeters(squaremeter.KilosquareMeters).SquareMeters, KilosquareMetersTolerance);
            Assert.AreEqual(1, Area.FromMicrosquareMeters(squaremeter.MicrosquareMeters).SquareMeters, MicrosquareMetersTolerance);
            Assert.AreEqual(1, Area.FromMillisquareMeters(squaremeter.MillisquareMeters).SquareMeters, MillisquareMetersTolerance);
            Assert.AreEqual(1, Area.FromNanosquareMeters(squaremeter.NanosquareMeters).SquareMeters, NanosquareMetersTolerance);
            Assert.AreEqual(1, Area.FromSquareFeet(squaremeter.SquareFeet).SquareMeters, SquareFeetTolerance);
            Assert.AreEqual(1, Area.FromSquareInches(squaremeter.SquareInches).SquareMeters, SquareInchesTolerance);
            Assert.AreEqual(1, Area.FromSquareMeters(squaremeter.SquareMeters).SquareMeters, SquareMetersTolerance);
            Assert.AreEqual(1, Area.FromSquareMiles(squaremeter.SquareMiles).SquareMeters, SquareMilesTolerance);
            Assert.AreEqual(1, Area.FromSquareYards(squaremeter.SquareYards).SquareMeters, SquareYardsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Area v = Area.FromSquareMeters(1);
            Assert.AreEqual(-1, -v.SquareMeters, SquareMetersTolerance);
            Assert.AreEqual(2, (Area.FromSquareMeters(3)-v).SquareMeters, SquareMetersTolerance);
            Assert.AreEqual(2, (v + v).SquareMeters, SquareMetersTolerance);
            Assert.AreEqual(10, (v*10).SquareMeters, SquareMetersTolerance);
            Assert.AreEqual(10, (10*v).SquareMeters, SquareMetersTolerance);
            Assert.AreEqual(2, (Area.FromSquareMeters(10)/5).SquareMeters, SquareMetersTolerance);
            Assert.AreEqual(2, Area.FromSquareMeters(10)/Area.FromSquareMeters(5), SquareMetersTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Area oneSquareMeter = Area.FromSquareMeters(1);
            Area twoSquareMeters = Area.FromSquareMeters(2);

            Assert.True(oneSquareMeter < twoSquareMeters);
            Assert.True(oneSquareMeter <= twoSquareMeters);
            Assert.True(twoSquareMeters > oneSquareMeter);
            Assert.True(twoSquareMeters >= oneSquareMeter);

            Assert.False(oneSquareMeter > twoSquareMeters);
            Assert.False(oneSquareMeter >= twoSquareMeters);
            Assert.False(twoSquareMeters < oneSquareMeter);
            Assert.False(twoSquareMeters <= oneSquareMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.AreEqual(0, squaremeter.CompareTo(squaremeter));
            Assert.Greater(squaremeter.CompareTo(Area.Zero), 0);
            Assert.Less(Area.Zero.CompareTo(squaremeter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Area squaremeter = Area.FromSquareMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            squaremeter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Area squaremeter = Area.FromSquareMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            squaremeter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Area a = Area.FromSquareMeters(1);
            Area b = Area.FromSquareMeters(2);

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
            Area v = Area.FromSquareMeters(1);
            Assert.IsTrue(v.Equals(Area.FromSquareMeters(1)));
            Assert.IsFalse(v.Equals(Area.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.IsFalse(squaremeter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.IsFalse(squaremeter.Equals(null));
        }
    }
}
