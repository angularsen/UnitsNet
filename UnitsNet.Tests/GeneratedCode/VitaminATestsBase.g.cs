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
    /// Test of VitaminA.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class VitaminATestsBase
    {
        protected abstract double InternationalUnitsInOneInternationalUnit { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double InternationalUnitsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void InternationalUnitToVitaminAUnits()
        {
            VitaminA internationalunit = VitaminA.FromInternationalUnits(1);
            Assert.AreEqual(InternationalUnitsInOneInternationalUnit, internationalunit.InternationalUnits, InternationalUnitsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, VitaminA.From(1, VitaminAUnit.InternationalUnit).InternationalUnits, InternationalUnitsTolerance);
        }

        [Test]
        public void As()
        {
            var internationalunit = VitaminA.FromInternationalUnits(1);
            Assert.AreEqual(InternationalUnitsInOneInternationalUnit, internationalunit.As(VitaminAUnit.InternationalUnit), InternationalUnitsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            VitaminA internationalunit = VitaminA.FromInternationalUnits(1);
            Assert.AreEqual(1, VitaminA.FromInternationalUnits(internationalunit.InternationalUnits).InternationalUnits, InternationalUnitsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            VitaminA v = VitaminA.FromInternationalUnits(1);
            Assert.AreEqual(-1, -v.InternationalUnits, InternationalUnitsTolerance);
            Assert.AreEqual(2, (VitaminA.FromInternationalUnits(3)-v).InternationalUnits, InternationalUnitsTolerance);
            Assert.AreEqual(2, (v + v).InternationalUnits, InternationalUnitsTolerance);
            Assert.AreEqual(10, (v*10).InternationalUnits, InternationalUnitsTolerance);
            Assert.AreEqual(10, (10*v).InternationalUnits, InternationalUnitsTolerance);
            Assert.AreEqual(2, (VitaminA.FromInternationalUnits(10)/5).InternationalUnits, InternationalUnitsTolerance);
            Assert.AreEqual(2, VitaminA.FromInternationalUnits(10)/VitaminA.FromInternationalUnits(5), InternationalUnitsTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            VitaminA oneInternationalUnit = VitaminA.FromInternationalUnits(1);
            VitaminA twoInternationalUnits = VitaminA.FromInternationalUnits(2);

            Assert.True(oneInternationalUnit < twoInternationalUnits);
            Assert.True(oneInternationalUnit <= twoInternationalUnits);
            Assert.True(twoInternationalUnits > oneInternationalUnit);
            Assert.True(twoInternationalUnits >= oneInternationalUnit);

            Assert.False(oneInternationalUnit > twoInternationalUnits);
            Assert.False(oneInternationalUnit >= twoInternationalUnits);
            Assert.False(twoInternationalUnits < oneInternationalUnit);
            Assert.False(twoInternationalUnits <= oneInternationalUnit);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            VitaminA internationalunit = VitaminA.FromInternationalUnits(1);
            Assert.AreEqual(0, internationalunit.CompareTo(internationalunit));
            Assert.Greater(internationalunit.CompareTo(VitaminA.Zero), 0);
            Assert.Less(VitaminA.Zero.CompareTo(internationalunit), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            VitaminA internationalunit = VitaminA.FromInternationalUnits(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            internationalunit.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            VitaminA internationalunit = VitaminA.FromInternationalUnits(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            internationalunit.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            VitaminA a = VitaminA.FromInternationalUnits(1);
            VitaminA b = VitaminA.FromInternationalUnits(2);

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
            VitaminA v = VitaminA.FromInternationalUnits(1);
            Assert.IsTrue(v.Equals(VitaminA.FromInternationalUnits(1)));
            Assert.IsFalse(v.Equals(VitaminA.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            VitaminA internationalunit = VitaminA.FromInternationalUnits(1);
            Assert.IsFalse(internationalunit.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            VitaminA internationalunit = VitaminA.FromInternationalUnits(1);
            Assert.IsFalse(internationalunit.Equals(null));
        }
    }
}
