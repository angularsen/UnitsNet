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
    /// Test of SpecificWeight.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class SpecificWeightTestsBase
    {
        protected abstract double KilogramsForcePerCubicCentimeterInOneNewtonPerCubicMeter { get; }
        protected abstract double KilogramsForcePerCubicMeterInOneNewtonPerCubicMeter { get; }
        protected abstract double KilogramsForcePerCubicMillimeterInOneNewtonPerCubicMeter { get; }
        protected abstract double KilonewtonsPerCubicCentimeterInOneNewtonPerCubicMeter { get; }
        protected abstract double KilonewtonsPerCubicMeterInOneNewtonPerCubicMeter { get; }
        protected abstract double KilonewtonsPerCubicMillimeterInOneNewtonPerCubicMeter { get; }
        protected abstract double KilopoundsForcePerCubicFootInOneNewtonPerCubicMeter { get; }
        protected abstract double KilopoundsForcePerCubicInchInOneNewtonPerCubicMeter { get; }
        protected abstract double NewtonsPerCubicCentimeterInOneNewtonPerCubicMeter { get; }
        protected abstract double NewtonsPerCubicMeterInOneNewtonPerCubicMeter { get; }
        protected abstract double NewtonsPerCubicMillimeterInOneNewtonPerCubicMeter { get; }
        protected abstract double PoundsForcePerCubicFootInOneNewtonPerCubicMeter { get; }
        protected abstract double PoundsForcePerCubicInchInOneNewtonPerCubicMeter { get; }
        protected abstract double TonnesForcePerCubicCentimeterInOneNewtonPerCubicMeter { get; }
        protected abstract double TonnesForcePerCubicMeterInOneNewtonPerCubicMeter { get; }
        protected abstract double TonnesForcePerCubicMillimeterInOneNewtonPerCubicMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KilogramsForcePerCubicCentimeterTolerance { get { return 1e-5; } }
        protected virtual double KilogramsForcePerCubicMeterTolerance { get { return 1e-5; } }
        protected virtual double KilogramsForcePerCubicMillimeterTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonsPerCubicCentimeterTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonsPerCubicMeterTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonsPerCubicMillimeterTolerance { get { return 1e-5; } }
        protected virtual double KilopoundsForcePerCubicFootTolerance { get { return 1e-5; } }
        protected virtual double KilopoundsForcePerCubicInchTolerance { get { return 1e-5; } }
        protected virtual double NewtonsPerCubicCentimeterTolerance { get { return 1e-5; } }
        protected virtual double NewtonsPerCubicMeterTolerance { get { return 1e-5; } }
        protected virtual double NewtonsPerCubicMillimeterTolerance { get { return 1e-5; } }
        protected virtual double PoundsForcePerCubicFootTolerance { get { return 1e-5; } }
        protected virtual double PoundsForcePerCubicInchTolerance { get { return 1e-5; } }
        protected virtual double TonnesForcePerCubicCentimeterTolerance { get { return 1e-5; } }
        protected virtual double TonnesForcePerCubicMeterTolerance { get { return 1e-5; } }
        protected virtual double TonnesForcePerCubicMillimeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void NewtonPerCubicMeterToSpecificWeightUnits()
        {
            SpecificWeight newtonpercubicmeter = SpecificWeight.FromNewtonsPerCubicMeter(1);
            Assert.AreEqual(KilogramsForcePerCubicCentimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.KilogramsForcePerCubicCentimeter, KilogramsForcePerCubicCentimeterTolerance);
            Assert.AreEqual(KilogramsForcePerCubicMeterInOneNewtonPerCubicMeter, newtonpercubicmeter.KilogramsForcePerCubicMeter, KilogramsForcePerCubicMeterTolerance);
            Assert.AreEqual(KilogramsForcePerCubicMillimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.KilogramsForcePerCubicMillimeter, KilogramsForcePerCubicMillimeterTolerance);
            Assert.AreEqual(KilonewtonsPerCubicCentimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.KilonewtonsPerCubicCentimeter, KilonewtonsPerCubicCentimeterTolerance);
            Assert.AreEqual(KilonewtonsPerCubicMeterInOneNewtonPerCubicMeter, newtonpercubicmeter.KilonewtonsPerCubicMeter, KilonewtonsPerCubicMeterTolerance);
            Assert.AreEqual(KilonewtonsPerCubicMillimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.KilonewtonsPerCubicMillimeter, KilonewtonsPerCubicMillimeterTolerance);
            Assert.AreEqual(KilopoundsForcePerCubicFootInOneNewtonPerCubicMeter, newtonpercubicmeter.KilopoundsForcePerCubicFoot, KilopoundsForcePerCubicFootTolerance);
            Assert.AreEqual(KilopoundsForcePerCubicInchInOneNewtonPerCubicMeter, newtonpercubicmeter.KilopoundsForcePerCubicInch, KilopoundsForcePerCubicInchTolerance);
            Assert.AreEqual(NewtonsPerCubicCentimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.NewtonsPerCubicCentimeter, NewtonsPerCubicCentimeterTolerance);
            Assert.AreEqual(NewtonsPerCubicMeterInOneNewtonPerCubicMeter, newtonpercubicmeter.NewtonsPerCubicMeter, NewtonsPerCubicMeterTolerance);
            Assert.AreEqual(NewtonsPerCubicMillimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.NewtonsPerCubicMillimeter, NewtonsPerCubicMillimeterTolerance);
            Assert.AreEqual(PoundsForcePerCubicFootInOneNewtonPerCubicMeter, newtonpercubicmeter.PoundsForcePerCubicFoot, PoundsForcePerCubicFootTolerance);
            Assert.AreEqual(PoundsForcePerCubicInchInOneNewtonPerCubicMeter, newtonpercubicmeter.PoundsForcePerCubicInch, PoundsForcePerCubicInchTolerance);
            Assert.AreEqual(TonnesForcePerCubicCentimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.TonnesForcePerCubicCentimeter, TonnesForcePerCubicCentimeterTolerance);
            Assert.AreEqual(TonnesForcePerCubicMeterInOneNewtonPerCubicMeter, newtonpercubicmeter.TonnesForcePerCubicMeter, TonnesForcePerCubicMeterTolerance);
            Assert.AreEqual(TonnesForcePerCubicMillimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.TonnesForcePerCubicMillimeter, TonnesForcePerCubicMillimeterTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.KilogramForcePerCubicCentimeter).KilogramsForcePerCubicCentimeter, KilogramsForcePerCubicCentimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.KilogramForcePerCubicMeter).KilogramsForcePerCubicMeter, KilogramsForcePerCubicMeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.KilogramForcePerCubicMillimeter).KilogramsForcePerCubicMillimeter, KilogramsForcePerCubicMillimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.KilonewtonPerCubicCentimeter).KilonewtonsPerCubicCentimeter, KilonewtonsPerCubicCentimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.KilonewtonPerCubicMeter).KilonewtonsPerCubicMeter, KilonewtonsPerCubicMeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.KilonewtonPerCubicMillimeter).KilonewtonsPerCubicMillimeter, KilonewtonsPerCubicMillimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.KilopoundForcePerCubicFoot).KilopoundsForcePerCubicFoot, KilopoundsForcePerCubicFootTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.KilopoundForcePerCubicInch).KilopoundsForcePerCubicInch, KilopoundsForcePerCubicInchTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.NewtonPerCubicCentimeter).NewtonsPerCubicCentimeter, NewtonsPerCubicCentimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.NewtonPerCubicMeter).NewtonsPerCubicMeter, NewtonsPerCubicMeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.NewtonPerCubicMillimeter).NewtonsPerCubicMillimeter, NewtonsPerCubicMillimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.PoundForcePerCubicFoot).PoundsForcePerCubicFoot, PoundsForcePerCubicFootTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.PoundForcePerCubicInch).PoundsForcePerCubicInch, PoundsForcePerCubicInchTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.TonneForcePerCubicCentimeter).TonnesForcePerCubicCentimeter, TonnesForcePerCubicCentimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.TonneForcePerCubicMeter).TonnesForcePerCubicMeter, TonnesForcePerCubicMeterTolerance);
            Assert.AreEqual(1, SpecificWeight.From(1, SpecificWeightUnit.TonneForcePerCubicMillimeter).TonnesForcePerCubicMillimeter, TonnesForcePerCubicMillimeterTolerance);
        }

        [Test]
        public void As()
        {
            var newtonpercubicmeter = SpecificWeight.FromNewtonsPerCubicMeter(1);
            Assert.AreEqual(KilogramsForcePerCubicCentimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.KilogramForcePerCubicCentimeter), KilogramsForcePerCubicCentimeterTolerance);
            Assert.AreEqual(KilogramsForcePerCubicMeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.KilogramForcePerCubicMeter), KilogramsForcePerCubicMeterTolerance);
            Assert.AreEqual(KilogramsForcePerCubicMillimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.KilogramForcePerCubicMillimeter), KilogramsForcePerCubicMillimeterTolerance);
            Assert.AreEqual(KilonewtonsPerCubicCentimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.KilonewtonPerCubicCentimeter), KilonewtonsPerCubicCentimeterTolerance);
            Assert.AreEqual(KilonewtonsPerCubicMeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.KilonewtonPerCubicMeter), KilonewtonsPerCubicMeterTolerance);
            Assert.AreEqual(KilonewtonsPerCubicMillimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.KilonewtonPerCubicMillimeter), KilonewtonsPerCubicMillimeterTolerance);
            Assert.AreEqual(KilopoundsForcePerCubicFootInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.KilopoundForcePerCubicFoot), KilopoundsForcePerCubicFootTolerance);
            Assert.AreEqual(KilopoundsForcePerCubicInchInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.KilopoundForcePerCubicInch), KilopoundsForcePerCubicInchTolerance);
            Assert.AreEqual(NewtonsPerCubicCentimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.NewtonPerCubicCentimeter), NewtonsPerCubicCentimeterTolerance);
            Assert.AreEqual(NewtonsPerCubicMeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.NewtonPerCubicMeter), NewtonsPerCubicMeterTolerance);
            Assert.AreEqual(NewtonsPerCubicMillimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.NewtonPerCubicMillimeter), NewtonsPerCubicMillimeterTolerance);
            Assert.AreEqual(PoundsForcePerCubicFootInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.PoundForcePerCubicFoot), PoundsForcePerCubicFootTolerance);
            Assert.AreEqual(PoundsForcePerCubicInchInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.PoundForcePerCubicInch), PoundsForcePerCubicInchTolerance);
            Assert.AreEqual(TonnesForcePerCubicCentimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.TonneForcePerCubicCentimeter), TonnesForcePerCubicCentimeterTolerance);
            Assert.AreEqual(TonnesForcePerCubicMeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.TonneForcePerCubicMeter), TonnesForcePerCubicMeterTolerance);
            Assert.AreEqual(TonnesForcePerCubicMillimeterInOneNewtonPerCubicMeter, newtonpercubicmeter.As(SpecificWeightUnit.TonneForcePerCubicMillimeter), TonnesForcePerCubicMillimeterTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            SpecificWeight newtonpercubicmeter = SpecificWeight.FromNewtonsPerCubicMeter(1);
            Assert.AreEqual(1, SpecificWeight.FromKilogramsForcePerCubicCentimeter(newtonpercubicmeter.KilogramsForcePerCubicCentimeter).NewtonsPerCubicMeter, KilogramsForcePerCubicCentimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromKilogramsForcePerCubicMeter(newtonpercubicmeter.KilogramsForcePerCubicMeter).NewtonsPerCubicMeter, KilogramsForcePerCubicMeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromKilogramsForcePerCubicMillimeter(newtonpercubicmeter.KilogramsForcePerCubicMillimeter).NewtonsPerCubicMeter, KilogramsForcePerCubicMillimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromKilonewtonsPerCubicCentimeter(newtonpercubicmeter.KilonewtonsPerCubicCentimeter).NewtonsPerCubicMeter, KilonewtonsPerCubicCentimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromKilonewtonsPerCubicMeter(newtonpercubicmeter.KilonewtonsPerCubicMeter).NewtonsPerCubicMeter, KilonewtonsPerCubicMeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromKilonewtonsPerCubicMillimeter(newtonpercubicmeter.KilonewtonsPerCubicMillimeter).NewtonsPerCubicMeter, KilonewtonsPerCubicMillimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromKilopoundsForcePerCubicFoot(newtonpercubicmeter.KilopoundsForcePerCubicFoot).NewtonsPerCubicMeter, KilopoundsForcePerCubicFootTolerance);
            Assert.AreEqual(1, SpecificWeight.FromKilopoundsForcePerCubicInch(newtonpercubicmeter.KilopoundsForcePerCubicInch).NewtonsPerCubicMeter, KilopoundsForcePerCubicInchTolerance);
            Assert.AreEqual(1, SpecificWeight.FromNewtonsPerCubicCentimeter(newtonpercubicmeter.NewtonsPerCubicCentimeter).NewtonsPerCubicMeter, NewtonsPerCubicCentimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromNewtonsPerCubicMeter(newtonpercubicmeter.NewtonsPerCubicMeter).NewtonsPerCubicMeter, NewtonsPerCubicMeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromNewtonsPerCubicMillimeter(newtonpercubicmeter.NewtonsPerCubicMillimeter).NewtonsPerCubicMeter, NewtonsPerCubicMillimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromPoundsForcePerCubicFoot(newtonpercubicmeter.PoundsForcePerCubicFoot).NewtonsPerCubicMeter, PoundsForcePerCubicFootTolerance);
            Assert.AreEqual(1, SpecificWeight.FromPoundsForcePerCubicInch(newtonpercubicmeter.PoundsForcePerCubicInch).NewtonsPerCubicMeter, PoundsForcePerCubicInchTolerance);
            Assert.AreEqual(1, SpecificWeight.FromTonnesForcePerCubicCentimeter(newtonpercubicmeter.TonnesForcePerCubicCentimeter).NewtonsPerCubicMeter, TonnesForcePerCubicCentimeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromTonnesForcePerCubicMeter(newtonpercubicmeter.TonnesForcePerCubicMeter).NewtonsPerCubicMeter, TonnesForcePerCubicMeterTolerance);
            Assert.AreEqual(1, SpecificWeight.FromTonnesForcePerCubicMillimeter(newtonpercubicmeter.TonnesForcePerCubicMillimeter).NewtonsPerCubicMeter, TonnesForcePerCubicMillimeterTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            SpecificWeight v = SpecificWeight.FromNewtonsPerCubicMeter(1);
            Assert.AreEqual(-1, -v.NewtonsPerCubicMeter, NewtonsPerCubicMeterTolerance);
            Assert.AreEqual(2, (SpecificWeight.FromNewtonsPerCubicMeter(3)-v).NewtonsPerCubicMeter, NewtonsPerCubicMeterTolerance);
            Assert.AreEqual(2, (v + v).NewtonsPerCubicMeter, NewtonsPerCubicMeterTolerance);
            Assert.AreEqual(10, (v*10).NewtonsPerCubicMeter, NewtonsPerCubicMeterTolerance);
            Assert.AreEqual(10, (10*v).NewtonsPerCubicMeter, NewtonsPerCubicMeterTolerance);
            Assert.AreEqual(2, (SpecificWeight.FromNewtonsPerCubicMeter(10)/5).NewtonsPerCubicMeter, NewtonsPerCubicMeterTolerance);
            Assert.AreEqual(2, SpecificWeight.FromNewtonsPerCubicMeter(10)/SpecificWeight.FromNewtonsPerCubicMeter(5), NewtonsPerCubicMeterTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            SpecificWeight oneNewtonPerCubicMeter = SpecificWeight.FromNewtonsPerCubicMeter(1);
            SpecificWeight twoNewtonsPerCubicMeter = SpecificWeight.FromNewtonsPerCubicMeter(2);

            Assert.True(oneNewtonPerCubicMeter < twoNewtonsPerCubicMeter);
            Assert.True(oneNewtonPerCubicMeter <= twoNewtonsPerCubicMeter);
            Assert.True(twoNewtonsPerCubicMeter > oneNewtonPerCubicMeter);
            Assert.True(twoNewtonsPerCubicMeter >= oneNewtonPerCubicMeter);

            Assert.False(oneNewtonPerCubicMeter > twoNewtonsPerCubicMeter);
            Assert.False(oneNewtonPerCubicMeter >= twoNewtonsPerCubicMeter);
            Assert.False(twoNewtonsPerCubicMeter < oneNewtonPerCubicMeter);
            Assert.False(twoNewtonsPerCubicMeter <= oneNewtonPerCubicMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            SpecificWeight newtonpercubicmeter = SpecificWeight.FromNewtonsPerCubicMeter(1);
            Assert.AreEqual(0, newtonpercubicmeter.CompareTo(newtonpercubicmeter));
            Assert.Greater(newtonpercubicmeter.CompareTo(SpecificWeight.Zero), 0);
            Assert.Less(SpecificWeight.Zero.CompareTo(newtonpercubicmeter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            SpecificWeight newtonpercubicmeter = SpecificWeight.FromNewtonsPerCubicMeter(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newtonpercubicmeter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            SpecificWeight newtonpercubicmeter = SpecificWeight.FromNewtonsPerCubicMeter(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newtonpercubicmeter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            SpecificWeight a = SpecificWeight.FromNewtonsPerCubicMeter(1);
            SpecificWeight b = SpecificWeight.FromNewtonsPerCubicMeter(2);

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
            SpecificWeight v = SpecificWeight.FromNewtonsPerCubicMeter(1);
            Assert.IsTrue(v.Equals(SpecificWeight.FromNewtonsPerCubicMeter(1)));
            Assert.IsFalse(v.Equals(SpecificWeight.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            SpecificWeight newtonpercubicmeter = SpecificWeight.FromNewtonsPerCubicMeter(1);
            Assert.IsFalse(newtonpercubicmeter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            SpecificWeight newtonpercubicmeter = SpecificWeight.FromNewtonsPerCubicMeter(1);
            Assert.IsFalse(newtonpercubicmeter.Equals(null));
        }
    }
}
