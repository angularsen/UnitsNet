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
    /// Test of Density.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class DensityTestsBase
    {
        protected abstract double KilogramPerCubicMeterInOneKilogramPerCubicMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KilogramPerCubicMeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void KilogramPerCubicMeterToDensityUnits()
        {
            Density kilogrampercubicmeter = Density.FromKilogramPerCubicMeter(1);
            Assert.AreEqual(KilogramPerCubicMeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.KilogramPerCubicMeter, KilogramPerCubicMeterTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Density.From(1, DensityUnit.KilogramPerCubicMeter).KilogramPerCubicMeter, KilogramPerCubicMeterTolerance);
        }

        [Test]
        public void As()
        {
            var kilogrampercubicmeter = Density.FromKilogramPerCubicMeter(1);
            Assert.AreEqual(KilogramPerCubicMeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.KilogramPerCubicMeter), KilogramPerCubicMeterTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Density kilogrampercubicmeter = Density.FromKilogramPerCubicMeter(1);
            Assert.AreEqual(1, Density.FromKilogramPerCubicMeter(kilogrampercubicmeter.KilogramPerCubicMeter).KilogramPerCubicMeter, KilogramPerCubicMeterTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Density v = Density.FromKilogramPerCubicMeter(1);
            Assert.AreEqual(-1, -v.KilogramPerCubicMeter, KilogramPerCubicMeterTolerance);
            Assert.AreEqual(2, (Density.FromKilogramPerCubicMeter(3)-v).KilogramPerCubicMeter, KilogramPerCubicMeterTolerance);
            Assert.AreEqual(2, (v + v).KilogramPerCubicMeter, KilogramPerCubicMeterTolerance);
            Assert.AreEqual(10, (v*10).KilogramPerCubicMeter, KilogramPerCubicMeterTolerance);
            Assert.AreEqual(10, (10*v).KilogramPerCubicMeter, KilogramPerCubicMeterTolerance);
            Assert.AreEqual(2, (Density.FromKilogramPerCubicMeter(10)/5).KilogramPerCubicMeter, KilogramPerCubicMeterTolerance);
            Assert.AreEqual(2, Density.FromKilogramPerCubicMeter(10)/Density.FromKilogramPerCubicMeter(5), KilogramPerCubicMeterTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Density oneKilogramPerCubicMeter = Density.FromKilogramPerCubicMeter(1);
            Density twoKilogramPerCubicMeter = Density.FromKilogramPerCubicMeter(2);

            Assert.True(oneKilogramPerCubicMeter < twoKilogramPerCubicMeter);
            Assert.True(oneKilogramPerCubicMeter <= twoKilogramPerCubicMeter);
            Assert.True(twoKilogramPerCubicMeter > oneKilogramPerCubicMeter);
            Assert.True(twoKilogramPerCubicMeter >= oneKilogramPerCubicMeter);

            Assert.False(oneKilogramPerCubicMeter > twoKilogramPerCubicMeter);
            Assert.False(oneKilogramPerCubicMeter >= twoKilogramPerCubicMeter);
            Assert.False(twoKilogramPerCubicMeter < oneKilogramPerCubicMeter);
            Assert.False(twoKilogramPerCubicMeter <= oneKilogramPerCubicMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Density kilogrampercubicmeter = Density.FromKilogramPerCubicMeter(1);
            Assert.AreEqual(0, kilogrampercubicmeter.CompareTo(kilogrampercubicmeter));
            Assert.Greater(kilogrampercubicmeter.CompareTo(Density.Zero), 0);
            Assert.Less(Density.Zero.CompareTo(kilogrampercubicmeter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Density kilogrampercubicmeter = Density.FromKilogramPerCubicMeter(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogrampercubicmeter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Density kilogrampercubicmeter = Density.FromKilogramPerCubicMeter(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogrampercubicmeter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Density a = Density.FromKilogramPerCubicMeter(1);
            Density b = Density.FromKilogramPerCubicMeter(2);

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
            Density v = Density.FromKilogramPerCubicMeter(1);
            Assert.IsTrue(v.Equals(Density.FromKilogramPerCubicMeter(1)));
            Assert.IsFalse(v.Equals(Density.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Density kilogrampercubicmeter = Density.FromKilogramPerCubicMeter(1);
            Assert.IsFalse(kilogrampercubicmeter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Density kilogrampercubicmeter = Density.FromKilogramPerCubicMeter(1);
            Assert.IsFalse(kilogrampercubicmeter.Equals(null));
        }
    }
}
