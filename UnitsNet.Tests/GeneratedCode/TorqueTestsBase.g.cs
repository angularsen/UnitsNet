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
    /// Test of Torque.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class TorqueTestsBase
    {
        protected abstract double KilogramForceCentimetersInOneNewtonMeter { get; }
        protected abstract double KilogramForceMetersInOneNewtonMeter { get; }
        protected abstract double KilogramForceMillimetersInOneNewtonMeter { get; }
        protected abstract double KilonewtonCentimetersInOneNewtonMeter { get; }
        protected abstract double KilonewtonMetersInOneNewtonMeter { get; }
        protected abstract double KilonewtonMillimetersInOneNewtonMeter { get; }
        protected abstract double KilopoundForceFeetInOneNewtonMeter { get; }
        protected abstract double KilopoundForceInchesInOneNewtonMeter { get; }
        protected abstract double NewtonCentimetersInOneNewtonMeter { get; }
        protected abstract double NewtonMetersInOneNewtonMeter { get; }
        protected abstract double NewtonMillimetersInOneNewtonMeter { get; }
        protected abstract double PoundForceFeetInOneNewtonMeter { get; }
        protected abstract double PoundForceInchesInOneNewtonMeter { get; }
        protected abstract double TonneForceCentimetersInOneNewtonMeter { get; }
        protected abstract double TonneForceMetersInOneNewtonMeter { get; }
        protected abstract double TonneForceMillimetersInOneNewtonMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KilogramForceCentimetersTolerance { get { return 1e-5; } }
        protected virtual double KilogramForceMetersTolerance { get { return 1e-5; } }
        protected virtual double KilogramForceMillimetersTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonCentimetersTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonMetersTolerance { get { return 1e-5; } }
        protected virtual double KilonewtonMillimetersTolerance { get { return 1e-5; } }
        protected virtual double KilopoundForceFeetTolerance { get { return 1e-5; } }
        protected virtual double KilopoundForceInchesTolerance { get { return 1e-5; } }
        protected virtual double NewtonCentimetersTolerance { get { return 1e-5; } }
        protected virtual double NewtonMetersTolerance { get { return 1e-5; } }
        protected virtual double NewtonMillimetersTolerance { get { return 1e-5; } }
        protected virtual double PoundForceFeetTolerance { get { return 1e-5; } }
        protected virtual double PoundForceInchesTolerance { get { return 1e-5; } }
        protected virtual double TonneForceCentimetersTolerance { get { return 1e-5; } }
        protected virtual double TonneForceMetersTolerance { get { return 1e-5; } }
        protected virtual double TonneForceMillimetersTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void NewtonMeterToTorqueUnits()
        {
            Torque newtonmeter = Torque.FromNewtonMeters(1);
            Assert.AreEqual(KilogramForceCentimetersInOneNewtonMeter, newtonmeter.KilogramForceCentimeters, KilogramForceCentimetersTolerance);
            Assert.AreEqual(KilogramForceMetersInOneNewtonMeter, newtonmeter.KilogramForceMeters, KilogramForceMetersTolerance);
            Assert.AreEqual(KilogramForceMillimetersInOneNewtonMeter, newtonmeter.KilogramForceMillimeters, KilogramForceMillimetersTolerance);
            Assert.AreEqual(KilonewtonCentimetersInOneNewtonMeter, newtonmeter.KilonewtonCentimeters, KilonewtonCentimetersTolerance);
            Assert.AreEqual(KilonewtonMetersInOneNewtonMeter, newtonmeter.KilonewtonMeters, KilonewtonMetersTolerance);
            Assert.AreEqual(KilonewtonMillimetersInOneNewtonMeter, newtonmeter.KilonewtonMillimeters, KilonewtonMillimetersTolerance);
            Assert.AreEqual(KilopoundForceFeetInOneNewtonMeter, newtonmeter.KilopoundForceFeet, KilopoundForceFeetTolerance);
            Assert.AreEqual(KilopoundForceInchesInOneNewtonMeter, newtonmeter.KilopoundForceInches, KilopoundForceInchesTolerance);
            Assert.AreEqual(NewtonCentimetersInOneNewtonMeter, newtonmeter.NewtonCentimeters, NewtonCentimetersTolerance);
            Assert.AreEqual(NewtonMetersInOneNewtonMeter, newtonmeter.NewtonMeters, NewtonMetersTolerance);
            Assert.AreEqual(NewtonMillimetersInOneNewtonMeter, newtonmeter.NewtonMillimeters, NewtonMillimetersTolerance);
            Assert.AreEqual(PoundForceFeetInOneNewtonMeter, newtonmeter.PoundForceFeet, PoundForceFeetTolerance);
            Assert.AreEqual(PoundForceInchesInOneNewtonMeter, newtonmeter.PoundForceInches, PoundForceInchesTolerance);
            Assert.AreEqual(TonneForceCentimetersInOneNewtonMeter, newtonmeter.TonneForceCentimeters, TonneForceCentimetersTolerance);
            Assert.AreEqual(TonneForceMetersInOneNewtonMeter, newtonmeter.TonneForceMeters, TonneForceMetersTolerance);
            Assert.AreEqual(TonneForceMillimetersInOneNewtonMeter, newtonmeter.TonneForceMillimeters, TonneForceMillimetersTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.KilogramForceCentimeter).KilogramForceCentimeters, KilogramForceCentimetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.KilogramForceMeter).KilogramForceMeters, KilogramForceMetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.KilogramForceMillimeter).KilogramForceMillimeters, KilogramForceMillimetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.KilonewtonCentimeter).KilonewtonCentimeters, KilonewtonCentimetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.KilonewtonMeter).KilonewtonMeters, KilonewtonMetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.KilonewtonMillimeter).KilonewtonMillimeters, KilonewtonMillimetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.KilopoundForceFoot).KilopoundForceFeet, KilopoundForceFeetTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.KilopoundForceInch).KilopoundForceInches, KilopoundForceInchesTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.NewtonCentimeter).NewtonCentimeters, NewtonCentimetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.NewtonMeter).NewtonMeters, NewtonMetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.NewtonMillimeter).NewtonMillimeters, NewtonMillimetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.PoundForceFoot).PoundForceFeet, PoundForceFeetTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.PoundForceInch).PoundForceInches, PoundForceInchesTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.TonneForceCentimeter).TonneForceCentimeters, TonneForceCentimetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.TonneForceMeter).TonneForceMeters, TonneForceMetersTolerance);
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.TonneForceMillimeter).TonneForceMillimeters, TonneForceMillimetersTolerance);
        }

        [Test]
        public void As()
        {
            var newtonmeter = Torque.FromNewtonMeters(1);
            Assert.AreEqual(KilogramForceCentimetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.KilogramForceCentimeter), KilogramForceCentimetersTolerance);
            Assert.AreEqual(KilogramForceMetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.KilogramForceMeter), KilogramForceMetersTolerance);
            Assert.AreEqual(KilogramForceMillimetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.KilogramForceMillimeter), KilogramForceMillimetersTolerance);
            Assert.AreEqual(KilonewtonCentimetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.KilonewtonCentimeter), KilonewtonCentimetersTolerance);
            Assert.AreEqual(KilonewtonMetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.KilonewtonMeter), KilonewtonMetersTolerance);
            Assert.AreEqual(KilonewtonMillimetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.KilonewtonMillimeter), KilonewtonMillimetersTolerance);
            Assert.AreEqual(KilopoundForceFeetInOneNewtonMeter, newtonmeter.As(TorqueUnit.KilopoundForceFoot), KilopoundForceFeetTolerance);
            Assert.AreEqual(KilopoundForceInchesInOneNewtonMeter, newtonmeter.As(TorqueUnit.KilopoundForceInch), KilopoundForceInchesTolerance);
            Assert.AreEqual(NewtonCentimetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.NewtonCentimeter), NewtonCentimetersTolerance);
            Assert.AreEqual(NewtonMetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.NewtonMeter), NewtonMetersTolerance);
            Assert.AreEqual(NewtonMillimetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.NewtonMillimeter), NewtonMillimetersTolerance);
            Assert.AreEqual(PoundForceFeetInOneNewtonMeter, newtonmeter.As(TorqueUnit.PoundForceFoot), PoundForceFeetTolerance);
            Assert.AreEqual(PoundForceInchesInOneNewtonMeter, newtonmeter.As(TorqueUnit.PoundForceInch), PoundForceInchesTolerance);
            Assert.AreEqual(TonneForceCentimetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.TonneForceCentimeter), TonneForceCentimetersTolerance);
            Assert.AreEqual(TonneForceMetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.TonneForceMeter), TonneForceMetersTolerance);
            Assert.AreEqual(TonneForceMillimetersInOneNewtonMeter, newtonmeter.As(TorqueUnit.TonneForceMillimeter), TonneForceMillimetersTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Torque newtonmeter = Torque.FromNewtonMeters(1);
            Assert.AreEqual(1, Torque.FromKilogramForceCentimeters(newtonmeter.KilogramForceCentimeters).NewtonMeters, KilogramForceCentimetersTolerance);
            Assert.AreEqual(1, Torque.FromKilogramForceMeters(newtonmeter.KilogramForceMeters).NewtonMeters, KilogramForceMetersTolerance);
            Assert.AreEqual(1, Torque.FromKilogramForceMillimeters(newtonmeter.KilogramForceMillimeters).NewtonMeters, KilogramForceMillimetersTolerance);
            Assert.AreEqual(1, Torque.FromKilonewtonCentimeters(newtonmeter.KilonewtonCentimeters).NewtonMeters, KilonewtonCentimetersTolerance);
            Assert.AreEqual(1, Torque.FromKilonewtonMeters(newtonmeter.KilonewtonMeters).NewtonMeters, KilonewtonMetersTolerance);
            Assert.AreEqual(1, Torque.FromKilonewtonMillimeters(newtonmeter.KilonewtonMillimeters).NewtonMeters, KilonewtonMillimetersTolerance);
            Assert.AreEqual(1, Torque.FromKilopoundForceFeet(newtonmeter.KilopoundForceFeet).NewtonMeters, KilopoundForceFeetTolerance);
            Assert.AreEqual(1, Torque.FromKilopoundForceInches(newtonmeter.KilopoundForceInches).NewtonMeters, KilopoundForceInchesTolerance);
            Assert.AreEqual(1, Torque.FromNewtonCentimeters(newtonmeter.NewtonCentimeters).NewtonMeters, NewtonCentimetersTolerance);
            Assert.AreEqual(1, Torque.FromNewtonMeters(newtonmeter.NewtonMeters).NewtonMeters, NewtonMetersTolerance);
            Assert.AreEqual(1, Torque.FromNewtonMillimeters(newtonmeter.NewtonMillimeters).NewtonMeters, NewtonMillimetersTolerance);
            Assert.AreEqual(1, Torque.FromPoundForceFeet(newtonmeter.PoundForceFeet).NewtonMeters, PoundForceFeetTolerance);
            Assert.AreEqual(1, Torque.FromPoundForceInches(newtonmeter.PoundForceInches).NewtonMeters, PoundForceInchesTolerance);
            Assert.AreEqual(1, Torque.FromTonneForceCentimeters(newtonmeter.TonneForceCentimeters).NewtonMeters, TonneForceCentimetersTolerance);
            Assert.AreEqual(1, Torque.FromTonneForceMeters(newtonmeter.TonneForceMeters).NewtonMeters, TonneForceMetersTolerance);
            Assert.AreEqual(1, Torque.FromTonneForceMillimeters(newtonmeter.TonneForceMillimeters).NewtonMeters, TonneForceMillimetersTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Torque v = Torque.FromNewtonMeters(1);
            Assert.AreEqual(-1, -v.NewtonMeters, NewtonMetersTolerance);
            Assert.AreEqual(2, (Torque.FromNewtonMeters(3)-v).NewtonMeters, NewtonMetersTolerance);
            Assert.AreEqual(2, (v + v).NewtonMeters, NewtonMetersTolerance);
            Assert.AreEqual(10, (v*10).NewtonMeters, NewtonMetersTolerance);
            Assert.AreEqual(10, (10*v).NewtonMeters, NewtonMetersTolerance);
            Assert.AreEqual(2, (Torque.FromNewtonMeters(10)/5).NewtonMeters, NewtonMetersTolerance);
            Assert.AreEqual(2, Torque.FromNewtonMeters(10)/Torque.FromNewtonMeters(5), NewtonMetersTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Torque oneNewtonMeter = Torque.FromNewtonMeters(1);
            Torque twoNewtonMeters = Torque.FromNewtonMeters(2);

            Assert.True(oneNewtonMeter < twoNewtonMeters);
            Assert.True(oneNewtonMeter <= twoNewtonMeters);
            Assert.True(twoNewtonMeters > oneNewtonMeter);
            Assert.True(twoNewtonMeters >= oneNewtonMeter);

            Assert.False(oneNewtonMeter > twoNewtonMeters);
            Assert.False(oneNewtonMeter >= twoNewtonMeters);
            Assert.False(twoNewtonMeters < oneNewtonMeter);
            Assert.False(twoNewtonMeters <= oneNewtonMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Torque newtonmeter = Torque.FromNewtonMeters(1);
            Assert.AreEqual(0, newtonmeter.CompareTo(newtonmeter));
            Assert.Greater(newtonmeter.CompareTo(Torque.Zero), 0);
            Assert.Less(Torque.Zero.CompareTo(newtonmeter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Torque newtonmeter = Torque.FromNewtonMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newtonmeter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Torque newtonmeter = Torque.FromNewtonMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newtonmeter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Torque a = Torque.FromNewtonMeters(1);
            Torque b = Torque.FromNewtonMeters(2);

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
            Torque v = Torque.FromNewtonMeters(1);
            Assert.IsTrue(v.Equals(Torque.FromNewtonMeters(1)));
            Assert.IsFalse(v.Equals(Torque.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Torque newtonmeter = Torque.FromNewtonMeters(1);
            Assert.IsFalse(newtonmeter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Torque newtonmeter = Torque.FromNewtonMeters(1);
            Assert.IsFalse(newtonmeter.Equals(null));
        }
    }
}
