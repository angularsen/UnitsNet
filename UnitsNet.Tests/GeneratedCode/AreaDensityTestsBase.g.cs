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
    /// Test of AreaDensity.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class AreaDensityTestsBase
    {
        protected abstract double KilgramsPerHectareInOneKilogramPerSquareMeter { get; }
        protected abstract double KilogramsPerSquareMeterInOneKilogramPerSquareMeter { get; }
        protected abstract double PoundsPerAcreInOneKilogramPerSquareMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KilgramsPerHectareTolerance { get { return 1e-5; } }
        protected virtual double KilogramsPerSquareMeterTolerance { get { return 1e-5; } }
        protected virtual double PoundsPerAcreTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void KilogramPerSquareMeterToAreaDensityUnits()
        {
            AreaDensity kilogrampersquaremeter = AreaDensity.FromKilogramsPerSquareMeter(1);
            Assert.AreEqual(KilgramsPerHectareInOneKilogramPerSquareMeter, kilogrampersquaremeter.KilgramsPerHectare, KilgramsPerHectareTolerance);
            Assert.AreEqual(KilogramsPerSquareMeterInOneKilogramPerSquareMeter, kilogrampersquaremeter.KilogramsPerSquareMeter, KilogramsPerSquareMeterTolerance);
            Assert.AreEqual(PoundsPerAcreInOneKilogramPerSquareMeter, kilogrampersquaremeter.PoundsPerAcre, PoundsPerAcreTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, AreaDensity.From(1, AreaDensityUnit.KilogramPerHectare).KilgramsPerHectare, KilgramsPerHectareTolerance);
            Assert.AreEqual(1, AreaDensity.From(1, AreaDensityUnit.KilogramPerSquareMeter).KilogramsPerSquareMeter, KilogramsPerSquareMeterTolerance);
            Assert.AreEqual(1, AreaDensity.From(1, AreaDensityUnit.PoundPerAcre).PoundsPerAcre, PoundsPerAcreTolerance);
        }

        [Test]
        public void As()
        {
            var kilogrampersquaremeter = AreaDensity.FromKilogramsPerSquareMeter(1);
            Assert.AreEqual(KilgramsPerHectareInOneKilogramPerSquareMeter, kilogrampersquaremeter.As(AreaDensityUnit.KilogramPerHectare), KilgramsPerHectareTolerance);
            Assert.AreEqual(KilogramsPerSquareMeterInOneKilogramPerSquareMeter, kilogrampersquaremeter.As(AreaDensityUnit.KilogramPerSquareMeter), KilogramsPerSquareMeterTolerance);
            Assert.AreEqual(PoundsPerAcreInOneKilogramPerSquareMeter, kilogrampersquaremeter.As(AreaDensityUnit.PoundPerAcre), PoundsPerAcreTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            AreaDensity kilogrampersquaremeter = AreaDensity.FromKilogramsPerSquareMeter(1);
            Assert.AreEqual(1, AreaDensity.FromKilgramsPerHectare(kilogrampersquaremeter.KilgramsPerHectare).KilogramsPerSquareMeter, KilgramsPerHectareTolerance);
            Assert.AreEqual(1, AreaDensity.FromKilogramsPerSquareMeter(kilogrampersquaremeter.KilogramsPerSquareMeter).KilogramsPerSquareMeter, KilogramsPerSquareMeterTolerance);
            Assert.AreEqual(1, AreaDensity.FromPoundsPerAcre(kilogrampersquaremeter.PoundsPerAcre).KilogramsPerSquareMeter, PoundsPerAcreTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            AreaDensity v = AreaDensity.FromKilogramsPerSquareMeter(1);
            Assert.AreEqual(-1, -v.KilogramsPerSquareMeter, KilogramsPerSquareMeterTolerance);
            Assert.AreEqual(2, (AreaDensity.FromKilogramsPerSquareMeter(3)-v).KilogramsPerSquareMeter, KilogramsPerSquareMeterTolerance);
            Assert.AreEqual(2, (v + v).KilogramsPerSquareMeter, KilogramsPerSquareMeterTolerance);
            Assert.AreEqual(10, (v*10).KilogramsPerSquareMeter, KilogramsPerSquareMeterTolerance);
            Assert.AreEqual(10, (10*v).KilogramsPerSquareMeter, KilogramsPerSquareMeterTolerance);
            Assert.AreEqual(2, (AreaDensity.FromKilogramsPerSquareMeter(10)/5).KilogramsPerSquareMeter, KilogramsPerSquareMeterTolerance);
            Assert.AreEqual(2, AreaDensity.FromKilogramsPerSquareMeter(10)/AreaDensity.FromKilogramsPerSquareMeter(5), KilogramsPerSquareMeterTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            AreaDensity oneKilogramPerSquareMeter = AreaDensity.FromKilogramsPerSquareMeter(1);
            AreaDensity twoKilogramsPerSquareMeter = AreaDensity.FromKilogramsPerSquareMeter(2);

            Assert.True(oneKilogramPerSquareMeter < twoKilogramsPerSquareMeter);
            Assert.True(oneKilogramPerSquareMeter <= twoKilogramsPerSquareMeter);
            Assert.True(twoKilogramsPerSquareMeter > oneKilogramPerSquareMeter);
            Assert.True(twoKilogramsPerSquareMeter >= oneKilogramPerSquareMeter);

            Assert.False(oneKilogramPerSquareMeter > twoKilogramsPerSquareMeter);
            Assert.False(oneKilogramPerSquareMeter >= twoKilogramsPerSquareMeter);
            Assert.False(twoKilogramsPerSquareMeter < oneKilogramPerSquareMeter);
            Assert.False(twoKilogramsPerSquareMeter <= oneKilogramPerSquareMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            AreaDensity kilogrampersquaremeter = AreaDensity.FromKilogramsPerSquareMeter(1);
            Assert.AreEqual(0, kilogrampersquaremeter.CompareTo(kilogrampersquaremeter));
            Assert.Greater(kilogrampersquaremeter.CompareTo(AreaDensity.Zero), 0);
            Assert.Less(AreaDensity.Zero.CompareTo(kilogrampersquaremeter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            AreaDensity kilogrampersquaremeter = AreaDensity.FromKilogramsPerSquareMeter(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogrampersquaremeter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            AreaDensity kilogrampersquaremeter = AreaDensity.FromKilogramsPerSquareMeter(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogrampersquaremeter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            AreaDensity a = AreaDensity.FromKilogramsPerSquareMeter(1);
            AreaDensity b = AreaDensity.FromKilogramsPerSquareMeter(2);

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
            AreaDensity v = AreaDensity.FromKilogramsPerSquareMeter(1);
            Assert.IsTrue(v.Equals(AreaDensity.FromKilogramsPerSquareMeter(1)));
            Assert.IsFalse(v.Equals(AreaDensity.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            AreaDensity kilogrampersquaremeter = AreaDensity.FromKilogramsPerSquareMeter(1);
            Assert.IsFalse(kilogrampersquaremeter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            AreaDensity kilogrampersquaremeter = AreaDensity.FromKilogramsPerSquareMeter(1);
            Assert.IsFalse(kilogrampersquaremeter.Equals(null));
        }
    }
}
