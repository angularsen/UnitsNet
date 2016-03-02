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
    /// Test of DynamicViscosity.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class DynamicViscosityTestsBase
    {
        protected abstract double CentipoiseInOneNewtonSecondPerMeterSquared { get; }
        protected abstract double MillipascalSecondsInOneNewtonSecondPerMeterSquared { get; }
        protected abstract double NewtonSecondsPerMeterSquaredInOneNewtonSecondPerMeterSquared { get; }
        protected abstract double PascalSecondsInOneNewtonSecondPerMeterSquared { get; }
        protected abstract double PoiseInOneNewtonSecondPerMeterSquared { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentipoiseTolerance { get { return 1e-5; } }
        protected virtual double MillipascalSecondsTolerance { get { return 1e-5; } }
        protected virtual double NewtonSecondsPerMeterSquaredTolerance { get { return 1e-5; } }
        protected virtual double PascalSecondsTolerance { get { return 1e-5; } }
        protected virtual double PoiseTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void NewtonSecondPerMeterSquaredToDynamicViscosityUnits()
        {
            DynamicViscosity newtonsecondpermetersquared = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
            Assert.AreEqual(CentipoiseInOneNewtonSecondPerMeterSquared, newtonsecondpermetersquared.Centipoise, CentipoiseTolerance);
            Assert.AreEqual(MillipascalSecondsInOneNewtonSecondPerMeterSquared, newtonsecondpermetersquared.MillipascalSeconds, MillipascalSecondsTolerance);
            Assert.AreEqual(NewtonSecondsPerMeterSquaredInOneNewtonSecondPerMeterSquared, newtonsecondpermetersquared.NewtonSecondsPerMeterSquared, NewtonSecondsPerMeterSquaredTolerance);
            Assert.AreEqual(PascalSecondsInOneNewtonSecondPerMeterSquared, newtonsecondpermetersquared.PascalSeconds, PascalSecondsTolerance);
            Assert.AreEqual(PoiseInOneNewtonSecondPerMeterSquared, newtonsecondpermetersquared.Poise, PoiseTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, DynamicViscosity.From(1, DynamicViscosityUnit.Centipoise).Centipoise, CentipoiseTolerance);
            Assert.AreEqual(1, DynamicViscosity.From(1, DynamicViscosityUnit.MillipascalSecond).MillipascalSeconds, MillipascalSecondsTolerance);
            Assert.AreEqual(1, DynamicViscosity.From(1, DynamicViscosityUnit.NewtonSecondPerMeterSquared).NewtonSecondsPerMeterSquared, NewtonSecondsPerMeterSquaredTolerance);
            Assert.AreEqual(1, DynamicViscosity.From(1, DynamicViscosityUnit.PascalSecond).PascalSeconds, PascalSecondsTolerance);
            Assert.AreEqual(1, DynamicViscosity.From(1, DynamicViscosityUnit.Poise).Poise, PoiseTolerance);
        }

        [Test]
        public void As()
        {
            var newtonsecondpermetersquared = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
            Assert.AreEqual(CentipoiseInOneNewtonSecondPerMeterSquared, newtonsecondpermetersquared.As(DynamicViscosityUnit.Centipoise), CentipoiseTolerance);
            Assert.AreEqual(MillipascalSecondsInOneNewtonSecondPerMeterSquared, newtonsecondpermetersquared.As(DynamicViscosityUnit.MillipascalSecond), MillipascalSecondsTolerance);
            Assert.AreEqual(NewtonSecondsPerMeterSquaredInOneNewtonSecondPerMeterSquared, newtonsecondpermetersquared.As(DynamicViscosityUnit.NewtonSecondPerMeterSquared), NewtonSecondsPerMeterSquaredTolerance);
            Assert.AreEqual(PascalSecondsInOneNewtonSecondPerMeterSquared, newtonsecondpermetersquared.As(DynamicViscosityUnit.PascalSecond), PascalSecondsTolerance);
            Assert.AreEqual(PoiseInOneNewtonSecondPerMeterSquared, newtonsecondpermetersquared.As(DynamicViscosityUnit.Poise), PoiseTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            DynamicViscosity newtonsecondpermetersquared = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
            Assert.AreEqual(1, DynamicViscosity.FromCentipoise(newtonsecondpermetersquared.Centipoise).NewtonSecondsPerMeterSquared, CentipoiseTolerance);
            Assert.AreEqual(1, DynamicViscosity.FromMillipascalSeconds(newtonsecondpermetersquared.MillipascalSeconds).NewtonSecondsPerMeterSquared, MillipascalSecondsTolerance);
            Assert.AreEqual(1, DynamicViscosity.FromNewtonSecondsPerMeterSquared(newtonsecondpermetersquared.NewtonSecondsPerMeterSquared).NewtonSecondsPerMeterSquared, NewtonSecondsPerMeterSquaredTolerance);
            Assert.AreEqual(1, DynamicViscosity.FromPascalSeconds(newtonsecondpermetersquared.PascalSeconds).NewtonSecondsPerMeterSquared, PascalSecondsTolerance);
            Assert.AreEqual(1, DynamicViscosity.FromPoise(newtonsecondpermetersquared.Poise).NewtonSecondsPerMeterSquared, PoiseTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            DynamicViscosity v = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
            Assert.AreEqual(-1, -v.NewtonSecondsPerMeterSquared, NewtonSecondsPerMeterSquaredTolerance);
            Assert.AreEqual(2, (DynamicViscosity.FromNewtonSecondsPerMeterSquared(3)-v).NewtonSecondsPerMeterSquared, NewtonSecondsPerMeterSquaredTolerance);
            Assert.AreEqual(2, (v + v).NewtonSecondsPerMeterSquared, NewtonSecondsPerMeterSquaredTolerance);
            Assert.AreEqual(10, (v*10).NewtonSecondsPerMeterSquared, NewtonSecondsPerMeterSquaredTolerance);
            Assert.AreEqual(10, (10*v).NewtonSecondsPerMeterSquared, NewtonSecondsPerMeterSquaredTolerance);
            Assert.AreEqual(2, (DynamicViscosity.FromNewtonSecondsPerMeterSquared(10)/5).NewtonSecondsPerMeterSquared, NewtonSecondsPerMeterSquaredTolerance);
            Assert.AreEqual(2, DynamicViscosity.FromNewtonSecondsPerMeterSquared(10)/DynamicViscosity.FromNewtonSecondsPerMeterSquared(5), NewtonSecondsPerMeterSquaredTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            DynamicViscosity oneNewtonSecondPerMeterSquared = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
            DynamicViscosity twoNewtonSecondsPerMeterSquared = DynamicViscosity.FromNewtonSecondsPerMeterSquared(2);

            Assert.True(oneNewtonSecondPerMeterSquared < twoNewtonSecondsPerMeterSquared);
            Assert.True(oneNewtonSecondPerMeterSquared <= twoNewtonSecondsPerMeterSquared);
            Assert.True(twoNewtonSecondsPerMeterSquared > oneNewtonSecondPerMeterSquared);
            Assert.True(twoNewtonSecondsPerMeterSquared >= oneNewtonSecondPerMeterSquared);

            Assert.False(oneNewtonSecondPerMeterSquared > twoNewtonSecondsPerMeterSquared);
            Assert.False(oneNewtonSecondPerMeterSquared >= twoNewtonSecondsPerMeterSquared);
            Assert.False(twoNewtonSecondsPerMeterSquared < oneNewtonSecondPerMeterSquared);
            Assert.False(twoNewtonSecondsPerMeterSquared <= oneNewtonSecondPerMeterSquared);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            DynamicViscosity newtonsecondpermetersquared = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
            Assert.AreEqual(0, newtonsecondpermetersquared.CompareTo(newtonsecondpermetersquared));
            Assert.Greater(newtonsecondpermetersquared.CompareTo(DynamicViscosity.Zero), 0);
            Assert.Less(DynamicViscosity.Zero.CompareTo(newtonsecondpermetersquared), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            DynamicViscosity newtonsecondpermetersquared = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newtonsecondpermetersquared.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            DynamicViscosity newtonsecondpermetersquared = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newtonsecondpermetersquared.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            DynamicViscosity a = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
            DynamicViscosity b = DynamicViscosity.FromNewtonSecondsPerMeterSquared(2);

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
            DynamicViscosity v = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
            Assert.IsTrue(v.Equals(DynamicViscosity.FromNewtonSecondsPerMeterSquared(1)));
            Assert.IsFalse(v.Equals(DynamicViscosity.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            DynamicViscosity newtonsecondpermetersquared = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
            Assert.IsFalse(newtonsecondpermetersquared.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            DynamicViscosity newtonsecondpermetersquared = DynamicViscosity.FromNewtonSecondsPerMeterSquared(1);
            Assert.IsFalse(newtonsecondpermetersquared.Equals(null));
        }
    }
}
