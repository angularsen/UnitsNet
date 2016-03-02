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
    /// Test of ElectricCurrent.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricCurrentTestsBase
    {
        protected abstract double AmperesInOneAmpere { get; }
        protected abstract double KiloamperesInOneAmpere { get; }
        protected abstract double MegaamperesInOneAmpere { get; }
        protected abstract double MicroamperesInOneAmpere { get; }
        protected abstract double MilliamperesInOneAmpere { get; }
        protected abstract double NanoamperesInOneAmpere { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double AmperesTolerance { get { return 1e-5; } }
        protected virtual double KiloamperesTolerance { get { return 1e-5; } }
        protected virtual double MegaamperesTolerance { get { return 1e-5; } }
        protected virtual double MicroamperesTolerance { get { return 1e-5; } }
        protected virtual double MilliamperesTolerance { get { return 1e-5; } }
        protected virtual double NanoamperesTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void AmpereToElectricCurrentUnits()
        {
            ElectricCurrent ampere = ElectricCurrent.FromAmperes(1);
            Assert.AreEqual(AmperesInOneAmpere, ampere.Amperes, AmperesTolerance);
            Assert.AreEqual(KiloamperesInOneAmpere, ampere.Kiloamperes, KiloamperesTolerance);
            Assert.AreEqual(MegaamperesInOneAmpere, ampere.Megaamperes, MegaamperesTolerance);
            Assert.AreEqual(MicroamperesInOneAmpere, ampere.Microamperes, MicroamperesTolerance);
            Assert.AreEqual(MilliamperesInOneAmpere, ampere.Milliamperes, MilliamperesTolerance);
            Assert.AreEqual(NanoamperesInOneAmpere, ampere.Nanoamperes, NanoamperesTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, ElectricCurrent.From(1, ElectricCurrentUnit.Ampere).Amperes, AmperesTolerance);
            Assert.AreEqual(1, ElectricCurrent.From(1, ElectricCurrentUnit.Kiloampere).Kiloamperes, KiloamperesTolerance);
            Assert.AreEqual(1, ElectricCurrent.From(1, ElectricCurrentUnit.Megaampere).Megaamperes, MegaamperesTolerance);
            Assert.AreEqual(1, ElectricCurrent.From(1, ElectricCurrentUnit.Microampere).Microamperes, MicroamperesTolerance);
            Assert.AreEqual(1, ElectricCurrent.From(1, ElectricCurrentUnit.Milliampere).Milliamperes, MilliamperesTolerance);
            Assert.AreEqual(1, ElectricCurrent.From(1, ElectricCurrentUnit.Nanoampere).Nanoamperes, NanoamperesTolerance);
        }

        [Test]
        public void As()
        {
            var ampere = ElectricCurrent.FromAmperes(1);
            Assert.AreEqual(AmperesInOneAmpere, ampere.As(ElectricCurrentUnit.Ampere), AmperesTolerance);
            Assert.AreEqual(KiloamperesInOneAmpere, ampere.As(ElectricCurrentUnit.Kiloampere), KiloamperesTolerance);
            Assert.AreEqual(MegaamperesInOneAmpere, ampere.As(ElectricCurrentUnit.Megaampere), MegaamperesTolerance);
            Assert.AreEqual(MicroamperesInOneAmpere, ampere.As(ElectricCurrentUnit.Microampere), MicroamperesTolerance);
            Assert.AreEqual(MilliamperesInOneAmpere, ampere.As(ElectricCurrentUnit.Milliampere), MilliamperesTolerance);
            Assert.AreEqual(NanoamperesInOneAmpere, ampere.As(ElectricCurrentUnit.Nanoampere), NanoamperesTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            ElectricCurrent ampere = ElectricCurrent.FromAmperes(1);
            Assert.AreEqual(1, ElectricCurrent.FromAmperes(ampere.Amperes).Amperes, AmperesTolerance);
            Assert.AreEqual(1, ElectricCurrent.FromKiloamperes(ampere.Kiloamperes).Amperes, KiloamperesTolerance);
            Assert.AreEqual(1, ElectricCurrent.FromMegaamperes(ampere.Megaamperes).Amperes, MegaamperesTolerance);
            Assert.AreEqual(1, ElectricCurrent.FromMicroamperes(ampere.Microamperes).Amperes, MicroamperesTolerance);
            Assert.AreEqual(1, ElectricCurrent.FromMilliamperes(ampere.Milliamperes).Amperes, MilliamperesTolerance);
            Assert.AreEqual(1, ElectricCurrent.FromNanoamperes(ampere.Nanoamperes).Amperes, NanoamperesTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            ElectricCurrent v = ElectricCurrent.FromAmperes(1);
            Assert.AreEqual(-1, -v.Amperes, AmperesTolerance);
            Assert.AreEqual(2, (ElectricCurrent.FromAmperes(3)-v).Amperes, AmperesTolerance);
            Assert.AreEqual(2, (v + v).Amperes, AmperesTolerance);
            Assert.AreEqual(10, (v*10).Amperes, AmperesTolerance);
            Assert.AreEqual(10, (10*v).Amperes, AmperesTolerance);
            Assert.AreEqual(2, (ElectricCurrent.FromAmperes(10)/5).Amperes, AmperesTolerance);
            Assert.AreEqual(2, ElectricCurrent.FromAmperes(10)/ElectricCurrent.FromAmperes(5), AmperesTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            ElectricCurrent oneAmpere = ElectricCurrent.FromAmperes(1);
            ElectricCurrent twoAmperes = ElectricCurrent.FromAmperes(2);

            Assert.True(oneAmpere < twoAmperes);
            Assert.True(oneAmpere <= twoAmperes);
            Assert.True(twoAmperes > oneAmpere);
            Assert.True(twoAmperes >= oneAmpere);

            Assert.False(oneAmpere > twoAmperes);
            Assert.False(oneAmpere >= twoAmperes);
            Assert.False(twoAmperes < oneAmpere);
            Assert.False(twoAmperes <= oneAmpere);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            ElectricCurrent ampere = ElectricCurrent.FromAmperes(1);
            Assert.AreEqual(0, ampere.CompareTo(ampere));
            Assert.Greater(ampere.CompareTo(ElectricCurrent.Zero), 0);
            Assert.Less(ElectricCurrent.Zero.CompareTo(ampere), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricCurrent ampere = ElectricCurrent.FromAmperes(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            ampere.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            ElectricCurrent ampere = ElectricCurrent.FromAmperes(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            ampere.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            ElectricCurrent a = ElectricCurrent.FromAmperes(1);
            ElectricCurrent b = ElectricCurrent.FromAmperes(2);

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
            ElectricCurrent v = ElectricCurrent.FromAmperes(1);
            Assert.IsTrue(v.Equals(ElectricCurrent.FromAmperes(1)));
            Assert.IsFalse(v.Equals(ElectricCurrent.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricCurrent ampere = ElectricCurrent.FromAmperes(1);
            Assert.IsFalse(ampere.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricCurrent ampere = ElectricCurrent.FromAmperes(1);
            Assert.IsFalse(ampere.Equals(null));
        }
    }
}
