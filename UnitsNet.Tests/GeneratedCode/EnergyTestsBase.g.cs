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
    /// Test of Energy.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class EnergyTestsBase
    {
        protected abstract double BritishThermalUnitsInOneJoule { get; }
        protected abstract double CaloriesInOneJoule { get; }
        protected abstract double ElectronVoltsInOneJoule { get; }
        protected abstract double ErgsInOneJoule { get; }
        protected abstract double FootPoundsInOneJoule { get; }
        protected abstract double GigawattHoursInOneJoule { get; }
        protected abstract double JoulesInOneJoule { get; }
        protected abstract double KilocaloriesInOneJoule { get; }
        protected abstract double KilojoulesInOneJoule { get; }
        protected abstract double KilowattHoursInOneJoule { get; }
        protected abstract double MegajoulesInOneJoule { get; }
        protected abstract double MegawattHoursInOneJoule { get; }
        protected abstract double WattHoursInOneJoule { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double BritishThermalUnitsTolerance { get { return 1e-5; } }
        protected virtual double CaloriesTolerance { get { return 1e-5; } }
        protected virtual double ElectronVoltsTolerance { get { return 1e-5; } }
        protected virtual double ErgsTolerance { get { return 1e-5; } }
        protected virtual double FootPoundsTolerance { get { return 1e-5; } }
        protected virtual double GigawattHoursTolerance { get { return 1e-5; } }
        protected virtual double JoulesTolerance { get { return 1e-5; } }
        protected virtual double KilocaloriesTolerance { get { return 1e-5; } }
        protected virtual double KilojoulesTolerance { get { return 1e-5; } }
        protected virtual double KilowattHoursTolerance { get { return 1e-5; } }
        protected virtual double MegajoulesTolerance { get { return 1e-5; } }
        protected virtual double MegawattHoursTolerance { get { return 1e-5; } }
        protected virtual double WattHoursTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void JouleToEnergyUnits()
        {
            Energy joule = Energy.FromJoules(1);
            Assert.AreEqual(BritishThermalUnitsInOneJoule, joule.BritishThermalUnits, BritishThermalUnitsTolerance);
            Assert.AreEqual(CaloriesInOneJoule, joule.Calories, CaloriesTolerance);
            Assert.AreEqual(ElectronVoltsInOneJoule, joule.ElectronVolts, ElectronVoltsTolerance);
            Assert.AreEqual(ErgsInOneJoule, joule.Ergs, ErgsTolerance);
            Assert.AreEqual(FootPoundsInOneJoule, joule.FootPounds, FootPoundsTolerance);
            Assert.AreEqual(GigawattHoursInOneJoule, joule.GigawattHours, GigawattHoursTolerance);
            Assert.AreEqual(JoulesInOneJoule, joule.Joules, JoulesTolerance);
            Assert.AreEqual(KilocaloriesInOneJoule, joule.Kilocalories, KilocaloriesTolerance);
            Assert.AreEqual(KilojoulesInOneJoule, joule.Kilojoules, KilojoulesTolerance);
            Assert.AreEqual(KilowattHoursInOneJoule, joule.KilowattHours, KilowattHoursTolerance);
            Assert.AreEqual(MegajoulesInOneJoule, joule.Megajoules, MegajoulesTolerance);
            Assert.AreEqual(MegawattHoursInOneJoule, joule.MegawattHours, MegawattHoursTolerance);
            Assert.AreEqual(WattHoursInOneJoule, joule.WattHours, WattHoursTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.BritishThermalUnit).BritishThermalUnits, BritishThermalUnitsTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.Calorie).Calories, CaloriesTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.ElectronVolt).ElectronVolts, ElectronVoltsTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.Erg).Ergs, ErgsTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.FootPound).FootPounds, FootPoundsTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.GigawattHour).GigawattHours, GigawattHoursTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.Joule).Joules, JoulesTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.Kilocalorie).Kilocalories, KilocaloriesTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.Kilojoule).Kilojoules, KilojoulesTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.KilowattHour).KilowattHours, KilowattHoursTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.Megajoule).Megajoules, MegajoulesTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.MegawattHour).MegawattHours, MegawattHoursTolerance);
            Assert.AreEqual(1, Energy.From(1, EnergyUnit.WattHour).WattHours, WattHoursTolerance);
        }

        [Test]
        public void As()
        {
            var joule = Energy.FromJoules(1);
            Assert.AreEqual(BritishThermalUnitsInOneJoule, joule.As(EnergyUnit.BritishThermalUnit), BritishThermalUnitsTolerance);
            Assert.AreEqual(CaloriesInOneJoule, joule.As(EnergyUnit.Calorie), CaloriesTolerance);
            Assert.AreEqual(ElectronVoltsInOneJoule, joule.As(EnergyUnit.ElectronVolt), ElectronVoltsTolerance);
            Assert.AreEqual(ErgsInOneJoule, joule.As(EnergyUnit.Erg), ErgsTolerance);
            Assert.AreEqual(FootPoundsInOneJoule, joule.As(EnergyUnit.FootPound), FootPoundsTolerance);
            Assert.AreEqual(GigawattHoursInOneJoule, joule.As(EnergyUnit.GigawattHour), GigawattHoursTolerance);
            Assert.AreEqual(JoulesInOneJoule, joule.As(EnergyUnit.Joule), JoulesTolerance);
            Assert.AreEqual(KilocaloriesInOneJoule, joule.As(EnergyUnit.Kilocalorie), KilocaloriesTolerance);
            Assert.AreEqual(KilojoulesInOneJoule, joule.As(EnergyUnit.Kilojoule), KilojoulesTolerance);
            Assert.AreEqual(KilowattHoursInOneJoule, joule.As(EnergyUnit.KilowattHour), KilowattHoursTolerance);
            Assert.AreEqual(MegajoulesInOneJoule, joule.As(EnergyUnit.Megajoule), MegajoulesTolerance);
            Assert.AreEqual(MegawattHoursInOneJoule, joule.As(EnergyUnit.MegawattHour), MegawattHoursTolerance);
            Assert.AreEqual(WattHoursInOneJoule, joule.As(EnergyUnit.WattHour), WattHoursTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Energy joule = Energy.FromJoules(1);
            Assert.AreEqual(1, Energy.FromBritishThermalUnits(joule.BritishThermalUnits).Joules, BritishThermalUnitsTolerance);
            Assert.AreEqual(1, Energy.FromCalories(joule.Calories).Joules, CaloriesTolerance);
            Assert.AreEqual(1, Energy.FromElectronVolts(joule.ElectronVolts).Joules, ElectronVoltsTolerance);
            Assert.AreEqual(1, Energy.FromErgs(joule.Ergs).Joules, ErgsTolerance);
            Assert.AreEqual(1, Energy.FromFootPounds(joule.FootPounds).Joules, FootPoundsTolerance);
            Assert.AreEqual(1, Energy.FromGigawattHours(joule.GigawattHours).Joules, GigawattHoursTolerance);
            Assert.AreEqual(1, Energy.FromJoules(joule.Joules).Joules, JoulesTolerance);
            Assert.AreEqual(1, Energy.FromKilocalories(joule.Kilocalories).Joules, KilocaloriesTolerance);
            Assert.AreEqual(1, Energy.FromKilojoules(joule.Kilojoules).Joules, KilojoulesTolerance);
            Assert.AreEqual(1, Energy.FromKilowattHours(joule.KilowattHours).Joules, KilowattHoursTolerance);
            Assert.AreEqual(1, Energy.FromMegajoules(joule.Megajoules).Joules, MegajoulesTolerance);
            Assert.AreEqual(1, Energy.FromMegawattHours(joule.MegawattHours).Joules, MegawattHoursTolerance);
            Assert.AreEqual(1, Energy.FromWattHours(joule.WattHours).Joules, WattHoursTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Energy v = Energy.FromJoules(1);
            Assert.AreEqual(-1, -v.Joules, JoulesTolerance);
            Assert.AreEqual(2, (Energy.FromJoules(3)-v).Joules, JoulesTolerance);
            Assert.AreEqual(2, (v + v).Joules, JoulesTolerance);
            Assert.AreEqual(10, (v*10).Joules, JoulesTolerance);
            Assert.AreEqual(10, (10*v).Joules, JoulesTolerance);
            Assert.AreEqual(2, (Energy.FromJoules(10)/5).Joules, JoulesTolerance);
            Assert.AreEqual(2, Energy.FromJoules(10)/Energy.FromJoules(5), JoulesTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Energy oneJoule = Energy.FromJoules(1);
            Energy twoJoules = Energy.FromJoules(2);

            Assert.True(oneJoule < twoJoules);
            Assert.True(oneJoule <= twoJoules);
            Assert.True(twoJoules > oneJoule);
            Assert.True(twoJoules >= oneJoule);

            Assert.False(oneJoule > twoJoules);
            Assert.False(oneJoule >= twoJoules);
            Assert.False(twoJoules < oneJoule);
            Assert.False(twoJoules <= oneJoule);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Energy joule = Energy.FromJoules(1);
            Assert.AreEqual(0, joule.CompareTo(joule));
            Assert.Greater(joule.CompareTo(Energy.Zero), 0);
            Assert.Less(Energy.Zero.CompareTo(joule), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Energy joule = Energy.FromJoules(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            joule.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Energy joule = Energy.FromJoules(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            joule.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Energy a = Energy.FromJoules(1);
            Energy b = Energy.FromJoules(2);

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
            Energy v = Energy.FromJoules(1);
            Assert.IsTrue(v.Equals(Energy.FromJoules(1)));
            Assert.IsFalse(v.Equals(Energy.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Energy joule = Energy.FromJoules(1);
            Assert.IsFalse(joule.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Energy joule = Energy.FromJoules(1);
            Assert.IsFalse(joule.Equals(null));
        }
    }
}
