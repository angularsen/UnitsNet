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
    /// Test of ForceChangeRate.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ForceChangeRateTestsBase
    {
        protected abstract double CentinewtonsPerSecondInOneNewtonPerSecond { get; }
        protected abstract double DecinewtonsPerSecondInOneNewtonPerSecond { get; }
        protected abstract double KilonewtonsPerSecondInOneNewtonPerSecond { get; }
        protected abstract double MicronewtonsPerSecondInOneNewtonPerSecond { get; }
        protected abstract double MillinewtonsPerSecondInOneNewtonPerSecond { get; }
        protected abstract double NanonewtonsPerSecondInOneNewtonPerSecond { get; }
        protected abstract double NewtonsPerSecondInOneNewtonPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentinewtonsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double DecinewtonsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MicronewtonsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MillinewtonsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double NanonewtonsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double NewtonsPerSecondTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void NewtonPerSecondToForceChangeRateUnits()
        {
            ForceChangeRate newtonpersecond = ForceChangeRate.FromNewtonsPerSecond(1);
            Assert.AreEqual(CentinewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.CentinewtonsPerSecond, CentinewtonsPerSecondTolerance);
            Assert.AreEqual(DecinewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.DecinewtonsPerSecond, DecinewtonsPerSecondTolerance);
            Assert.AreEqual(KilonewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.KilonewtonsPerSecond, KilonewtonsPerSecondTolerance);
            Assert.AreEqual(MicronewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.MicronewtonsPerSecond, MicronewtonsPerSecondTolerance);
            Assert.AreEqual(MillinewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.MillinewtonsPerSecond, MillinewtonsPerSecondTolerance);
            Assert.AreEqual(NanonewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.NanonewtonsPerSecond, NanonewtonsPerSecondTolerance);
            Assert.AreEqual(NewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.NewtonsPerSecond, NewtonsPerSecondTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, ForceChangeRate.From(1, ForceChangeRateUnit.CentinewtonPerSecond).CentinewtonsPerSecond, CentinewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.From(1, ForceChangeRateUnit.DecinewtonPerSecond).DecinewtonsPerSecond, DecinewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.From(1, ForceChangeRateUnit.KilonewtonPerSecond).KilonewtonsPerSecond, KilonewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.From(1, ForceChangeRateUnit.MicronewtonPerSecond).MicronewtonsPerSecond, MicronewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.From(1, ForceChangeRateUnit.MillinewtonPerSecond).MillinewtonsPerSecond, MillinewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.From(1, ForceChangeRateUnit.NanonewtonPerSecond).NanonewtonsPerSecond, NanonewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.From(1, ForceChangeRateUnit.NewtonPerSecond).NewtonsPerSecond, NewtonsPerSecondTolerance);
        }

        [Test]
        public void As()
        {
            var newtonpersecond = ForceChangeRate.FromNewtonsPerSecond(1);
            Assert.AreEqual(CentinewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.As(ForceChangeRateUnit.CentinewtonPerSecond), CentinewtonsPerSecondTolerance);
            Assert.AreEqual(DecinewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.As(ForceChangeRateUnit.DecinewtonPerSecond), DecinewtonsPerSecondTolerance);
            Assert.AreEqual(KilonewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.As(ForceChangeRateUnit.KilonewtonPerSecond), KilonewtonsPerSecondTolerance);
            Assert.AreEqual(MicronewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.As(ForceChangeRateUnit.MicronewtonPerSecond), MicronewtonsPerSecondTolerance);
            Assert.AreEqual(MillinewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.As(ForceChangeRateUnit.MillinewtonPerSecond), MillinewtonsPerSecondTolerance);
            Assert.AreEqual(NanonewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.As(ForceChangeRateUnit.NanonewtonPerSecond), NanonewtonsPerSecondTolerance);
            Assert.AreEqual(NewtonsPerSecondInOneNewtonPerSecond, newtonpersecond.As(ForceChangeRateUnit.NewtonPerSecond), NewtonsPerSecondTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            ForceChangeRate newtonpersecond = ForceChangeRate.FromNewtonsPerSecond(1);
            Assert.AreEqual(1, ForceChangeRate.FromCentinewtonsPerSecond(newtonpersecond.CentinewtonsPerSecond).NewtonsPerSecond, CentinewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.FromDecinewtonsPerSecond(newtonpersecond.DecinewtonsPerSecond).NewtonsPerSecond, DecinewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.FromKilonewtonsPerSecond(newtonpersecond.KilonewtonsPerSecond).NewtonsPerSecond, KilonewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.FromMicronewtonsPerSecond(newtonpersecond.MicronewtonsPerSecond).NewtonsPerSecond, MicronewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.FromMillinewtonsPerSecond(newtonpersecond.MillinewtonsPerSecond).NewtonsPerSecond, MillinewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.FromNanonewtonsPerSecond(newtonpersecond.NanonewtonsPerSecond).NewtonsPerSecond, NanonewtonsPerSecondTolerance);
            Assert.AreEqual(1, ForceChangeRate.FromNewtonsPerSecond(newtonpersecond.NewtonsPerSecond).NewtonsPerSecond, NewtonsPerSecondTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            ForceChangeRate v = ForceChangeRate.FromNewtonsPerSecond(1);
            Assert.AreEqual(-1, -v.NewtonsPerSecond, NewtonsPerSecondTolerance);
            Assert.AreEqual(2, (ForceChangeRate.FromNewtonsPerSecond(3)-v).NewtonsPerSecond, NewtonsPerSecondTolerance);
            Assert.AreEqual(2, (v + v).NewtonsPerSecond, NewtonsPerSecondTolerance);
            Assert.AreEqual(10, (v*10).NewtonsPerSecond, NewtonsPerSecondTolerance);
            Assert.AreEqual(10, (10*v).NewtonsPerSecond, NewtonsPerSecondTolerance);
            Assert.AreEqual(2, (ForceChangeRate.FromNewtonsPerSecond(10)/5).NewtonsPerSecond, NewtonsPerSecondTolerance);
            Assert.AreEqual(2, ForceChangeRate.FromNewtonsPerSecond(10)/ForceChangeRate.FromNewtonsPerSecond(5), NewtonsPerSecondTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            ForceChangeRate oneNewtonPerSecond = ForceChangeRate.FromNewtonsPerSecond(1);
            ForceChangeRate twoNewtonsPerSecond = ForceChangeRate.FromNewtonsPerSecond(2);

            Assert.True(oneNewtonPerSecond < twoNewtonsPerSecond);
            Assert.True(oneNewtonPerSecond <= twoNewtonsPerSecond);
            Assert.True(twoNewtonsPerSecond > oneNewtonPerSecond);
            Assert.True(twoNewtonsPerSecond >= oneNewtonPerSecond);

            Assert.False(oneNewtonPerSecond > twoNewtonsPerSecond);
            Assert.False(oneNewtonPerSecond >= twoNewtonsPerSecond);
            Assert.False(twoNewtonsPerSecond < oneNewtonPerSecond);
            Assert.False(twoNewtonsPerSecond <= oneNewtonPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            ForceChangeRate newtonpersecond = ForceChangeRate.FromNewtonsPerSecond(1);
            Assert.AreEqual(0, newtonpersecond.CompareTo(newtonpersecond));
            Assert.Greater(newtonpersecond.CompareTo(ForceChangeRate.Zero), 0);
            Assert.Less(ForceChangeRate.Zero.CompareTo(newtonpersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            ForceChangeRate newtonpersecond = ForceChangeRate.FromNewtonsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newtonpersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            ForceChangeRate newtonpersecond = ForceChangeRate.FromNewtonsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newtonpersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            ForceChangeRate a = ForceChangeRate.FromNewtonsPerSecond(1);
            ForceChangeRate b = ForceChangeRate.FromNewtonsPerSecond(2);

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
            ForceChangeRate v = ForceChangeRate.FromNewtonsPerSecond(1);
            Assert.IsTrue(v.Equals(ForceChangeRate.FromNewtonsPerSecond(1)));
            Assert.IsFalse(v.Equals(ForceChangeRate.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ForceChangeRate newtonpersecond = ForceChangeRate.FromNewtonsPerSecond(1);
            Assert.IsFalse(newtonpersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            ForceChangeRate newtonpersecond = ForceChangeRate.FromNewtonsPerSecond(1);
            Assert.IsFalse(newtonpersecond.Equals(null));
        }
    }
}
