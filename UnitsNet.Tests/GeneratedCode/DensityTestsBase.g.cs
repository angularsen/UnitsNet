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
    /// Test of Density.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class DensityTestsBase
    {
        protected abstract double KilogramsPerCubicCentimeterInOneKilogramPerCubicMeter { get; }
        protected abstract double KilogramsPerCubicMeterInOneKilogramPerCubicMeter { get; }
        protected abstract double KilogramsPerCubicMillimeterInOneKilogramPerCubicMeter { get; }
        protected abstract double KilopoundsPerCubicFootInOneKilogramPerCubicMeter { get; }
        protected abstract double KilopoundsPerCubicInchInOneKilogramPerCubicMeter { get; }
        protected abstract double PoundsPerCubicFootInOneKilogramPerCubicMeter { get; }
        protected abstract double PoundsPerCubicInchInOneKilogramPerCubicMeter { get; }
        protected abstract double TonnesPerCubicCentimeterInOneKilogramPerCubicMeter { get; }
        protected abstract double TonnesPerCubicMeterInOneKilogramPerCubicMeter { get; }
        protected abstract double TonnesPerCubicMillimeterInOneKilogramPerCubicMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KilogramsPerCubicCentimeterTolerance { get { return 1e-5; } }
        protected virtual double KilogramsPerCubicMeterTolerance { get { return 1e-5; } }
        protected virtual double KilogramsPerCubicMillimeterTolerance { get { return 1e-5; } }
        protected virtual double KilopoundsPerCubicFootTolerance { get { return 1e-5; } }
        protected virtual double KilopoundsPerCubicInchTolerance { get { return 1e-5; } }
        protected virtual double PoundsPerCubicFootTolerance { get { return 1e-5; } }
        protected virtual double PoundsPerCubicInchTolerance { get { return 1e-5; } }
        protected virtual double TonnesPerCubicCentimeterTolerance { get { return 1e-5; } }
        protected virtual double TonnesPerCubicMeterTolerance { get { return 1e-5; } }
        protected virtual double TonnesPerCubicMillimeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void KilogramPerCubicMeterToDensityUnits()
        {
            Density kilogrampercubicmeter = Density.FromKilogramsPerCubicMeter(1);
            Assert.AreEqual(KilogramsPerCubicCentimeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.KilogramsPerCubicCentimeter, KilogramsPerCubicCentimeterTolerance);
            Assert.AreEqual(KilogramsPerCubicMeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.KilogramsPerCubicMeter, KilogramsPerCubicMeterTolerance);
            Assert.AreEqual(KilogramsPerCubicMillimeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.KilogramsPerCubicMillimeter, KilogramsPerCubicMillimeterTolerance);
            Assert.AreEqual(KilopoundsPerCubicFootInOneKilogramPerCubicMeter, kilogrampercubicmeter.KilopoundsPerCubicFoot, KilopoundsPerCubicFootTolerance);
            Assert.AreEqual(KilopoundsPerCubicInchInOneKilogramPerCubicMeter, kilogrampercubicmeter.KilopoundsPerCubicInch, KilopoundsPerCubicInchTolerance);
            Assert.AreEqual(PoundsPerCubicFootInOneKilogramPerCubicMeter, kilogrampercubicmeter.PoundsPerCubicFoot, PoundsPerCubicFootTolerance);
            Assert.AreEqual(PoundsPerCubicInchInOneKilogramPerCubicMeter, kilogrampercubicmeter.PoundsPerCubicInch, PoundsPerCubicInchTolerance);
            Assert.AreEqual(TonnesPerCubicCentimeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.TonnesPerCubicCentimeter, TonnesPerCubicCentimeterTolerance);
            Assert.AreEqual(TonnesPerCubicMeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.TonnesPerCubicMeter, TonnesPerCubicMeterTolerance);
            Assert.AreEqual(TonnesPerCubicMillimeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.TonnesPerCubicMillimeter, TonnesPerCubicMillimeterTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Density.From(1, DensityUnit.KilogramPerCubicCentimeter).KilogramsPerCubicCentimeter, KilogramsPerCubicCentimeterTolerance);
            Assert.AreEqual(1, Density.From(1, DensityUnit.KilogramPerCubicMeter).KilogramsPerCubicMeter, KilogramsPerCubicMeterTolerance);
            Assert.AreEqual(1, Density.From(1, DensityUnit.KilogramPerCubicMillimeter).KilogramsPerCubicMillimeter, KilogramsPerCubicMillimeterTolerance);
            Assert.AreEqual(1, Density.From(1, DensityUnit.KilopoundPerCubicFoot).KilopoundsPerCubicFoot, KilopoundsPerCubicFootTolerance);
            Assert.AreEqual(1, Density.From(1, DensityUnit.KilopoundPerCubicInch).KilopoundsPerCubicInch, KilopoundsPerCubicInchTolerance);
            Assert.AreEqual(1, Density.From(1, DensityUnit.PoundPerCubicFoot).PoundsPerCubicFoot, PoundsPerCubicFootTolerance);
            Assert.AreEqual(1, Density.From(1, DensityUnit.PoundPerCubicInch).PoundsPerCubicInch, PoundsPerCubicInchTolerance);
            Assert.AreEqual(1, Density.From(1, DensityUnit.TonnePerCubicCentimeter).TonnesPerCubicCentimeter, TonnesPerCubicCentimeterTolerance);
            Assert.AreEqual(1, Density.From(1, DensityUnit.TonnePerCubicMeter).TonnesPerCubicMeter, TonnesPerCubicMeterTolerance);
            Assert.AreEqual(1, Density.From(1, DensityUnit.TonnePerCubicMillimeter).TonnesPerCubicMillimeter, TonnesPerCubicMillimeterTolerance);
        }

        [Test]
        public void As()
        {
            var kilogrampercubicmeter = Density.FromKilogramsPerCubicMeter(1);
            Assert.AreEqual(KilogramsPerCubicCentimeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.KilogramPerCubicCentimeter), KilogramsPerCubicCentimeterTolerance);
            Assert.AreEqual(KilogramsPerCubicMeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.KilogramPerCubicMeter), KilogramsPerCubicMeterTolerance);
            Assert.AreEqual(KilogramsPerCubicMillimeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.KilogramPerCubicMillimeter), KilogramsPerCubicMillimeterTolerance);
            Assert.AreEqual(KilopoundsPerCubicFootInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.KilopoundPerCubicFoot), KilopoundsPerCubicFootTolerance);
            Assert.AreEqual(KilopoundsPerCubicInchInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.KilopoundPerCubicInch), KilopoundsPerCubicInchTolerance);
            Assert.AreEqual(PoundsPerCubicFootInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.PoundPerCubicFoot), PoundsPerCubicFootTolerance);
            Assert.AreEqual(PoundsPerCubicInchInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.PoundPerCubicInch), PoundsPerCubicInchTolerance);
            Assert.AreEqual(TonnesPerCubicCentimeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.TonnePerCubicCentimeter), TonnesPerCubicCentimeterTolerance);
            Assert.AreEqual(TonnesPerCubicMeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.TonnePerCubicMeter), TonnesPerCubicMeterTolerance);
            Assert.AreEqual(TonnesPerCubicMillimeterInOneKilogramPerCubicMeter, kilogrampercubicmeter.As(DensityUnit.TonnePerCubicMillimeter), TonnesPerCubicMillimeterTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Density kilogrampercubicmeter = Density.FromKilogramsPerCubicMeter(1);
            Assert.AreEqual(1, Density.FromKilogramsPerCubicCentimeter(kilogrampercubicmeter.KilogramsPerCubicCentimeter).KilogramsPerCubicMeter, KilogramsPerCubicCentimeterTolerance);
            Assert.AreEqual(1, Density.FromKilogramsPerCubicMeter(kilogrampercubicmeter.KilogramsPerCubicMeter).KilogramsPerCubicMeter, KilogramsPerCubicMeterTolerance);
            Assert.AreEqual(1, Density.FromKilogramsPerCubicMillimeter(kilogrampercubicmeter.KilogramsPerCubicMillimeter).KilogramsPerCubicMeter, KilogramsPerCubicMillimeterTolerance);
            Assert.AreEqual(1, Density.FromKilopoundsPerCubicFoot(kilogrampercubicmeter.KilopoundsPerCubicFoot).KilogramsPerCubicMeter, KilopoundsPerCubicFootTolerance);
            Assert.AreEqual(1, Density.FromKilopoundsPerCubicInch(kilogrampercubicmeter.KilopoundsPerCubicInch).KilogramsPerCubicMeter, KilopoundsPerCubicInchTolerance);
            Assert.AreEqual(1, Density.FromPoundsPerCubicFoot(kilogrampercubicmeter.PoundsPerCubicFoot).KilogramsPerCubicMeter, PoundsPerCubicFootTolerance);
            Assert.AreEqual(1, Density.FromPoundsPerCubicInch(kilogrampercubicmeter.PoundsPerCubicInch).KilogramsPerCubicMeter, PoundsPerCubicInchTolerance);
            Assert.AreEqual(1, Density.FromTonnesPerCubicCentimeter(kilogrampercubicmeter.TonnesPerCubicCentimeter).KilogramsPerCubicMeter, TonnesPerCubicCentimeterTolerance);
            Assert.AreEqual(1, Density.FromTonnesPerCubicMeter(kilogrampercubicmeter.TonnesPerCubicMeter).KilogramsPerCubicMeter, TonnesPerCubicMeterTolerance);
            Assert.AreEqual(1, Density.FromTonnesPerCubicMillimeter(kilogrampercubicmeter.TonnesPerCubicMillimeter).KilogramsPerCubicMeter, TonnesPerCubicMillimeterTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Density v = Density.FromKilogramsPerCubicMeter(1);
            Assert.AreEqual(-1, -v.KilogramsPerCubicMeter, KilogramsPerCubicMeterTolerance);
            Assert.AreEqual(2, (Density.FromKilogramsPerCubicMeter(3)-v).KilogramsPerCubicMeter, KilogramsPerCubicMeterTolerance);
            Assert.AreEqual(2, (v + v).KilogramsPerCubicMeter, KilogramsPerCubicMeterTolerance);
            Assert.AreEqual(10, (v*10).KilogramsPerCubicMeter, KilogramsPerCubicMeterTolerance);
            Assert.AreEqual(10, (10*v).KilogramsPerCubicMeter, KilogramsPerCubicMeterTolerance);
            Assert.AreEqual(2, (Density.FromKilogramsPerCubicMeter(10)/5).KilogramsPerCubicMeter, KilogramsPerCubicMeterTolerance);
            Assert.AreEqual(2, Density.FromKilogramsPerCubicMeter(10)/Density.FromKilogramsPerCubicMeter(5), KilogramsPerCubicMeterTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Density oneKilogramPerCubicMeter = Density.FromKilogramsPerCubicMeter(1);
            Density twoKilogramsPerCubicMeter = Density.FromKilogramsPerCubicMeter(2);

            Assert.True(oneKilogramPerCubicMeter < twoKilogramsPerCubicMeter);
            Assert.True(oneKilogramPerCubicMeter <= twoKilogramsPerCubicMeter);
            Assert.True(twoKilogramsPerCubicMeter > oneKilogramPerCubicMeter);
            Assert.True(twoKilogramsPerCubicMeter >= oneKilogramPerCubicMeter);

            Assert.False(oneKilogramPerCubicMeter > twoKilogramsPerCubicMeter);
            Assert.False(oneKilogramPerCubicMeter >= twoKilogramsPerCubicMeter);
            Assert.False(twoKilogramsPerCubicMeter < oneKilogramPerCubicMeter);
            Assert.False(twoKilogramsPerCubicMeter <= oneKilogramPerCubicMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Density kilogrampercubicmeter = Density.FromKilogramsPerCubicMeter(1);
            Assert.AreEqual(0, kilogrampercubicmeter.CompareTo(kilogrampercubicmeter));
            Assert.Greater(kilogrampercubicmeter.CompareTo(Density.Zero), 0);
            Assert.Less(Density.Zero.CompareTo(kilogrampercubicmeter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Density kilogrampercubicmeter = Density.FromKilogramsPerCubicMeter(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogrampercubicmeter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Density kilogrampercubicmeter = Density.FromKilogramsPerCubicMeter(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogrampercubicmeter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Density a = Density.FromKilogramsPerCubicMeter(1);
            Density b = Density.FromKilogramsPerCubicMeter(2);

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
            Density v = Density.FromKilogramsPerCubicMeter(1);
            Assert.IsTrue(v.Equals(Density.FromKilogramsPerCubicMeter(1)));
            Assert.IsFalse(v.Equals(Density.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Density kilogrampercubicmeter = Density.FromKilogramsPerCubicMeter(1);
            Assert.IsFalse(kilogrampercubicmeter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Density kilogrampercubicmeter = Density.FromKilogramsPerCubicMeter(1);
            Assert.IsFalse(kilogrampercubicmeter.Equals(null));
        }
    }
}
