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
    /// Test of Energy.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class EnergyTestsBase
    {
        protected abstract double JoulesInOneJoule { get; }
        protected abstract double KilojoulesInOneJoule { get; }
        protected abstract double MegajoulesInOneJoule { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double JoulesTolerance { get { return 1e-5; } }
        protected virtual double KilojoulesTolerance { get { return 1e-5; } }
        protected virtual double MegajoulesTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void JouleToEnergyUnits()
        {
            Energy joule = Energy.FromJoules(1);
            Assert.AreEqual(JoulesInOneJoule, joule.Joules, JoulesTolerance);
            Assert.AreEqual(KilojoulesInOneJoule, joule.Kilojoules, KilojoulesTolerance);
            Assert.AreEqual(MegajoulesInOneJoule, joule.Megajoules, MegajoulesTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.Joule).Joules, JoulesTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.Kilojoule).Kilojoules, KilojoulesTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.Megajoule).Megajoules, MegajoulesTolerance);
        }

        [Test]
        public void As()
        {
            var joule = Energy.FromJoules(1);
            Assert.AreEqual(JoulesInOneJoule, joule.As(EnergyUnit.Joule), JoulesTolerance);
            Assert.AreEqual(KilojoulesInOneJoule, joule.As(EnergyUnit.Kilojoule), KilojoulesTolerance);
            Assert.AreEqual(MegajoulesInOneJoule, joule.As(EnergyUnit.Megajoule), MegajoulesTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Energy joule = Energy.FromJoules(1);
            Assert.AreEqual(1, Energy.FromJoules(joule.Joules).Joules, JoulesTolerance);
            Assert.AreEqual(1, Energy.FromKilojoules(joule.Kilojoules).Joules, KilojoulesTolerance);
            Assert.AreEqual(1, Energy.FromMegajoules(joule.Megajoules).Joules, MegajoulesTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Energy v = Energy.FromJoules(1);
            Assert.AreEqual(-1, -v.Joules, JoulesTolerance);
            Assert.AreEqual(2, (Energy.FromJoules(3)-v).Joules, JoulesTolerance);
            Assert.AreEqual(2, (v + v).Joules, JoulesTolerance);
            Assert.AreEqual(10, (v*10).Joules, JoulesTolerance);
            Assert.AreEqual(10, (10*v).Joules, JoulesTolerance);
            Assert.AreEqual(2, (Energy.FromJoules(10)/5).Joules, JoulesTolerance);
            Assert.AreEqual(2, Energy.FromJoules(10)/Energy.FromJoules(5), JoulesTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Energy oneJoule = Energy.FromJoules(1);
            Energy twoJoules = Energy.FromJoules(2);

            Assert.True(oneJoule < twoJoules);
            Assert.True(oneJoule <= twoJoules);
            Assert.True(twoJoules > oneJoule);
            Assert.True(twoJoules >= oneJoule);

            Assert.False(oneJoule > twoJoules);
            Assert.False(oneJoule >= twoJoules);
            Assert.False(twoJoules < oneJoule);
            Assert.False(twoJoules <= oneJoule);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Energy joule = Energy.FromJoules(1);
            Assert.AreEqual(0, joule.CompareTo(joule));
            Assert.Greater(joule.CompareTo(Energy.Zero), 0);
            Assert.Less(Energy.Zero.CompareTo(joule), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Energy joule = Energy.FromJoules(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            joule.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Energy joule = Energy.FromJoules(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            joule.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Energy a = Energy.FromJoules(1);
            Energy b = Energy.FromJoules(2);

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
            Energy v = Energy.FromJoules(1);
            Assert.IsTrue(v.Equals(Energy.FromJoules(1)));
            Assert.IsFalse(v.Equals(Energy.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Energy joule = Energy.FromJoules(1);
            Assert.IsFalse(joule.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Energy joule = Energy.FromJoules(1);
            Assert.IsFalse(joule.Equals(null));
        }
    }
}
