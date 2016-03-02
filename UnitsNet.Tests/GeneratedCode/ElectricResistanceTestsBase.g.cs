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
    /// Test of ElectricResistance.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricResistanceTestsBase
    {
        protected abstract double KiloohmsInOneOhm { get; }
        protected abstract double MegaohmsInOneOhm { get; }
        protected abstract double OhmsInOneOhm { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KiloohmsTolerance { get { return 1e-5; } }
        protected virtual double MegaohmsTolerance { get { return 1e-5; } }
        protected virtual double OhmsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void OhmToElectricResistanceUnits()
        {
            ElectricResistance ohm = ElectricResistance.FromOhms(1);
            Assert.AreEqual(KiloohmsInOneOhm, ohm.Kiloohms, KiloohmsTolerance);
            Assert.AreEqual(MegaohmsInOneOhm, ohm.Megaohms, MegaohmsTolerance);
            Assert.AreEqual(OhmsInOneOhm, ohm.Ohms, OhmsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, ElectricResistance.From(1, ElectricResistanceUnit.Kiloohm).Kiloohms, KiloohmsTolerance);
            Assert.AreEqual(1, ElectricResistance.From(1, ElectricResistanceUnit.Megaohm).Megaohms, MegaohmsTolerance);
            Assert.AreEqual(1, ElectricResistance.From(1, ElectricResistanceUnit.Ohm).Ohms, OhmsTolerance);
        }

        [Test]
        public void As()
        {
            var ohm = ElectricResistance.FromOhms(1);
            Assert.AreEqual(KiloohmsInOneOhm, ohm.As(ElectricResistanceUnit.Kiloohm), KiloohmsTolerance);
            Assert.AreEqual(MegaohmsInOneOhm, ohm.As(ElectricResistanceUnit.Megaohm), MegaohmsTolerance);
            Assert.AreEqual(OhmsInOneOhm, ohm.As(ElectricResistanceUnit.Ohm), OhmsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            ElectricResistance ohm = ElectricResistance.FromOhms(1);
            Assert.AreEqual(1, ElectricResistance.FromKiloohms(ohm.Kiloohms).Ohms, KiloohmsTolerance);
            Assert.AreEqual(1, ElectricResistance.FromMegaohms(ohm.Megaohms).Ohms, MegaohmsTolerance);
            Assert.AreEqual(1, ElectricResistance.FromOhms(ohm.Ohms).Ohms, OhmsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            ElectricResistance v = ElectricResistance.FromOhms(1);
            Assert.AreEqual(-1, -v.Ohms, OhmsTolerance);
            Assert.AreEqual(2, (ElectricResistance.FromOhms(3)-v).Ohms, OhmsTolerance);
            Assert.AreEqual(2, (v + v).Ohms, OhmsTolerance);
            Assert.AreEqual(10, (v*10).Ohms, OhmsTolerance);
            Assert.AreEqual(10, (10*v).Ohms, OhmsTolerance);
            Assert.AreEqual(2, (ElectricResistance.FromOhms(10)/5).Ohms, OhmsTolerance);
            Assert.AreEqual(2, ElectricResistance.FromOhms(10)/ElectricResistance.FromOhms(5), OhmsTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            ElectricResistance oneOhm = ElectricResistance.FromOhms(1);
            ElectricResistance twoOhms = ElectricResistance.FromOhms(2);

            Assert.True(oneOhm < twoOhms);
            Assert.True(oneOhm <= twoOhms);
            Assert.True(twoOhms > oneOhm);
            Assert.True(twoOhms >= oneOhm);

            Assert.False(oneOhm > twoOhms);
            Assert.False(oneOhm >= twoOhms);
            Assert.False(twoOhms < oneOhm);
            Assert.False(twoOhms <= oneOhm);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            ElectricResistance ohm = ElectricResistance.FromOhms(1);
            Assert.AreEqual(0, ohm.CompareTo(ohm));
            Assert.Greater(ohm.CompareTo(ElectricResistance.Zero), 0);
            Assert.Less(ElectricResistance.Zero.CompareTo(ohm), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricResistance ohm = ElectricResistance.FromOhms(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            ohm.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            ElectricResistance ohm = ElectricResistance.FromOhms(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            ohm.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            ElectricResistance a = ElectricResistance.FromOhms(1);
            ElectricResistance b = ElectricResistance.FromOhms(2);

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
            ElectricResistance v = ElectricResistance.FromOhms(1);
            Assert.IsTrue(v.Equals(ElectricResistance.FromOhms(1)));
            Assert.IsFalse(v.Equals(ElectricResistance.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricResistance ohm = ElectricResistance.FromOhms(1);
            Assert.IsFalse(ohm.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricResistance ohm = ElectricResistance.FromOhms(1);
            Assert.IsFalse(ohm.Equals(null));
        }
    }
}
