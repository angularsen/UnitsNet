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
    /// Test of Force.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ForceTestsBase
    {
        protected abstract double DyneInOneNewton { get; }
        protected abstract double KilogramsForceInOneNewton { get; }
        protected abstract double KilonewtonsInOneNewton { get; }
        protected abstract double KiloPondsInOneNewton { get; }
        protected abstract double NewtonsInOneNewton { get; }
        protected abstract double PoundalsInOneNewton { get; }
        protected abstract double PoundsForceInOneNewton { get; }
        protected abstract double TonnesForceInOneNewton { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DyneTolerance { get { return 1e-5; } }
        protected virtual double KilogramsForceTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonsTolerance { get { return 1e-5; } }
        protected virtual double KiloPondsTolerance { get { return 1e-5; } }
        protected virtual double NewtonsTolerance { get { return 1e-5; } }
        protected virtual double PoundalsTolerance { get { return 1e-5; } }
        protected virtual double PoundsForceTolerance { get { return 1e-5; } }
        protected virtual double TonnesForceTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void NewtonToForceUnits()
        {
            Force newton = Force.FromNewtons(1);
            Assert.AreEqual(DyneInOneNewton, newton.Dyne, DyneTolerance);
            Assert.AreEqual(KilogramsForceInOneNewton, newton.KilogramsForce, KilogramsForceTolerance);
            Assert.AreEqual(KilonewtonsInOneNewton, newton.Kilonewtons, KilonewtonsTolerance);
            Assert.AreEqual(KiloPondsInOneNewton, newton.KiloPonds, KiloPondsTolerance);
            Assert.AreEqual(NewtonsInOneNewton, newton.Newtons, NewtonsTolerance);
            Assert.AreEqual(PoundalsInOneNewton, newton.Poundals, PoundalsTolerance);
            Assert.AreEqual(PoundsForceInOneNewton, newton.PoundsForce, PoundsForceTolerance);
            Assert.AreEqual(TonnesForceInOneNewton, newton.TonnesForce, TonnesForceTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Force.From(1, ForceUnit.Dyn).Dyne, DyneTolerance);
            Assert.AreEqual(1, Force.From(1, ForceUnit.KilogramForce).KilogramsForce, KilogramsForceTolerance);
            Assert.AreEqual(1, Force.From(1, ForceUnit.Kilonewton).Kilonewtons, KilonewtonsTolerance);
            Assert.AreEqual(1, Force.From(1, ForceUnit.KiloPond).KiloPonds, KiloPondsTolerance);
            Assert.AreEqual(1, Force.From(1, ForceUnit.Newton).Newtons, NewtonsTolerance);
            Assert.AreEqual(1, Force.From(1, ForceUnit.Poundal).Poundals, PoundalsTolerance);
            Assert.AreEqual(1, Force.From(1, ForceUnit.PoundForce).PoundsForce, PoundsForceTolerance);
            Assert.AreEqual(1, Force.From(1, ForceUnit.TonneForce).TonnesForce, TonnesForceTolerance);
        }

        [Test]
        public void As()
        {
            var newton = Force.FromNewtons(1);
            Assert.AreEqual(DyneInOneNewton, newton.As(ForceUnit.Dyn), DyneTolerance);
            Assert.AreEqual(KilogramsForceInOneNewton, newton.As(ForceUnit.KilogramForce), KilogramsForceTolerance);
            Assert.AreEqual(KilonewtonsInOneNewton, newton.As(ForceUnit.Kilonewton), KilonewtonsTolerance);
            Assert.AreEqual(KiloPondsInOneNewton, newton.As(ForceUnit.KiloPond), KiloPondsTolerance);
            Assert.AreEqual(NewtonsInOneNewton, newton.As(ForceUnit.Newton), NewtonsTolerance);
            Assert.AreEqual(PoundalsInOneNewton, newton.As(ForceUnit.Poundal), PoundalsTolerance);
            Assert.AreEqual(PoundsForceInOneNewton, newton.As(ForceUnit.PoundForce), PoundsForceTolerance);
            Assert.AreEqual(TonnesForceInOneNewton, newton.As(ForceUnit.TonneForce), TonnesForceTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Force newton = Force.FromNewtons(1);
            Assert.AreEqual(1, Force.FromDyne(newton.Dyne).Newtons, DyneTolerance);
            Assert.AreEqual(1, Force.FromKilogramsForce(newton.KilogramsForce).Newtons, KilogramsForceTolerance);
            Assert.AreEqual(1, Force.FromKilonewtons(newton.Kilonewtons).Newtons, KilonewtonsTolerance);
            Assert.AreEqual(1, Force.FromKiloPonds(newton.KiloPonds).Newtons, KiloPondsTolerance);
            Assert.AreEqual(1, Force.FromNewtons(newton.Newtons).Newtons, NewtonsTolerance);
            Assert.AreEqual(1, Force.FromPoundals(newton.Poundals).Newtons, PoundalsTolerance);
            Assert.AreEqual(1, Force.FromPoundsForce(newton.PoundsForce).Newtons, PoundsForceTolerance);
            Assert.AreEqual(1, Force.FromTonnesForce(newton.TonnesForce).Newtons, TonnesForceTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Force v = Force.FromNewtons(1);
            Assert.AreEqual(-1, -v.Newtons, NewtonsTolerance);
            Assert.AreEqual(2, (Force.FromNewtons(3)-v).Newtons, NewtonsTolerance);
            Assert.AreEqual(2, (v + v).Newtons, NewtonsTolerance);
            Assert.AreEqual(10, (v*10).Newtons, NewtonsTolerance);
            Assert.AreEqual(10, (10*v).Newtons, NewtonsTolerance);
            Assert.AreEqual(2, (Force.FromNewtons(10)/5).Newtons, NewtonsTolerance);
            Assert.AreEqual(2, Force.FromNewtons(10)/Force.FromNewtons(5), NewtonsTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Force oneNewton = Force.FromNewtons(1);
            Force twoNewtons = Force.FromNewtons(2);

            Assert.True(oneNewton < twoNewtons);
            Assert.True(oneNewton <= twoNewtons);
            Assert.True(twoNewtons > oneNewton);
            Assert.True(twoNewtons >= oneNewton);

            Assert.False(oneNewton > twoNewtons);
            Assert.False(oneNewton >= twoNewtons);
            Assert.False(twoNewtons < oneNewton);
            Assert.False(twoNewtons <= oneNewton);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Force newton = Force.FromNewtons(1);
            Assert.AreEqual(0, newton.CompareTo(newton));
            Assert.Greater(newton.CompareTo(Force.Zero), 0);
            Assert.Less(Force.Zero.CompareTo(newton), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Force newton = Force.FromNewtons(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newton.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Force newton = Force.FromNewtons(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newton.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Force a = Force.FromNewtons(1);
            Force b = Force.FromNewtons(2);

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
            Force v = Force.FromNewtons(1);
            Assert.IsTrue(v.Equals(Force.FromNewtons(1)));
            Assert.IsFalse(v.Equals(Force.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Force newton = Force.FromNewtons(1);
            Assert.IsFalse(newton.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Force newton = Force.FromNewtons(1);
            Assert.IsFalse(newton.Equals(null));
        }
    }
}
