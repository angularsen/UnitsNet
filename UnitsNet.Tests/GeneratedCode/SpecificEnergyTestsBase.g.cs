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
    /// Test of SpecificEnergy.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class SpecificEnergyTestsBase
    {
        protected abstract double CaloriesPerGramInOneJoulePerKilogram { get; }
        protected abstract double JoulesPerKilogramInOneJoulePerKilogram { get; }
        protected abstract double KilocaloriesPerGramInOneJoulePerKilogram { get; }
        protected abstract double KilojoulesPerKilogramInOneJoulePerKilogram { get; }
        protected abstract double KilowattHoursPerKilogramInOneJoulePerKilogram { get; }
        protected abstract double MegajoulesPerKilogramInOneJoulePerKilogram { get; }
        protected abstract double MegawattHoursPerKilogramInOneJoulePerKilogram { get; }
        protected abstract double WattHoursPerKilogramInOneJoulePerKilogram { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CaloriesPerGramTolerance { get { return 1e-5; } }
        protected virtual double JoulesPerKilogramTolerance { get { return 1e-5; } }
        protected virtual double KilocaloriesPerGramTolerance { get { return 1e-5; } }
        protected virtual double KilojoulesPerKilogramTolerance { get { return 1e-5; } }
        protected virtual double KilowattHoursPerKilogramTolerance { get { return 1e-5; } }
        protected virtual double MegajoulesPerKilogramTolerance { get { return 1e-5; } }
        protected virtual double MegawattHoursPerKilogramTolerance { get { return 1e-5; } }
        protected virtual double WattHoursPerKilogramTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void JoulePerKilogramToSpecificEnergyUnits()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKilogram(1);
            Assert.AreEqual(CaloriesPerGramInOneJoulePerKilogram, jouleperkilogram.CaloriesPerGram, CaloriesPerGramTolerance);
            Assert.AreEqual(JoulesPerKilogramInOneJoulePerKilogram, jouleperkilogram.JoulesPerKilogram, JoulesPerKilogramTolerance);
            Assert.AreEqual(KilocaloriesPerGramInOneJoulePerKilogram, jouleperkilogram.KilocaloriesPerGram, KilocaloriesPerGramTolerance);
            Assert.AreEqual(KilojoulesPerKilogramInOneJoulePerKilogram, jouleperkilogram.KilojoulesPerKilogram, KilojoulesPerKilogramTolerance);
            Assert.AreEqual(KilowattHoursPerKilogramInOneJoulePerKilogram, jouleperkilogram.KilowattHoursPerKilogram, KilowattHoursPerKilogramTolerance);
            Assert.AreEqual(MegajoulesPerKilogramInOneJoulePerKilogram, jouleperkilogram.MegajoulesPerKilogram, MegajoulesPerKilogramTolerance);
            Assert.AreEqual(MegawattHoursPerKilogramInOneJoulePerKilogram, jouleperkilogram.MegawattHoursPerKilogram, MegawattHoursPerKilogramTolerance);
            Assert.AreEqual(WattHoursPerKilogramInOneJoulePerKilogram, jouleperkilogram.WattHoursPerKilogram, WattHoursPerKilogramTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.CaloriePerGram).CaloriesPerGram, CaloriesPerGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.JoulePerKilogram).JoulesPerKilogram, JoulesPerKilogramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.KilocaloriePerGram).KilocaloriesPerGram, KilocaloriesPerGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.KilojoulePerKilogram).KilojoulesPerKilogram, KilojoulesPerKilogramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.KilowattHourPerKilogram).KilowattHoursPerKilogram, KilowattHoursPerKilogramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.MegajoulePerKilogram).MegajoulesPerKilogram, MegajoulesPerKilogramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.MegawattHourPerKilogram).MegawattHoursPerKilogram, MegawattHoursPerKilogramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.WattHourPerKilogram).WattHoursPerKilogram, WattHoursPerKilogramTolerance);
        }

        [Test]
        public void As()
        {
            var jouleperkilogram = SpecificEnergy.FromJoulesPerKilogram(1);
            Assert.AreEqual(CaloriesPerGramInOneJoulePerKilogram, jouleperkilogram.As(SpecificEnergyUnit.CaloriePerGram), CaloriesPerGramTolerance);
            Assert.AreEqual(JoulesPerKilogramInOneJoulePerKilogram, jouleperkilogram.As(SpecificEnergyUnit.JoulePerKilogram), JoulesPerKilogramTolerance);
            Assert.AreEqual(KilocaloriesPerGramInOneJoulePerKilogram, jouleperkilogram.As(SpecificEnergyUnit.KilocaloriePerGram), KilocaloriesPerGramTolerance);
            Assert.AreEqual(KilojoulesPerKilogramInOneJoulePerKilogram, jouleperkilogram.As(SpecificEnergyUnit.KilojoulePerKilogram), KilojoulesPerKilogramTolerance);
            Assert.AreEqual(KilowattHoursPerKilogramInOneJoulePerKilogram, jouleperkilogram.As(SpecificEnergyUnit.KilowattHourPerKilogram), KilowattHoursPerKilogramTolerance);
            Assert.AreEqual(MegajoulesPerKilogramInOneJoulePerKilogram, jouleperkilogram.As(SpecificEnergyUnit.MegajoulePerKilogram), MegajoulesPerKilogramTolerance);
            Assert.AreEqual(MegawattHoursPerKilogramInOneJoulePerKilogram, jouleperkilogram.As(SpecificEnergyUnit.MegawattHourPerKilogram), MegawattHoursPerKilogramTolerance);
            Assert.AreEqual(WattHoursPerKilogramInOneJoulePerKilogram, jouleperkilogram.As(SpecificEnergyUnit.WattHourPerKilogram), WattHoursPerKilogramTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKilogram(1);
            Assert.AreEqual(1, SpecificEnergy.FromCaloriesPerGram(jouleperkilogram.CaloriesPerGram).JoulesPerKilogram, CaloriesPerGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromJoulesPerKilogram(jouleperkilogram.JoulesPerKilogram).JoulesPerKilogram, JoulesPerKilogramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromKilocaloriesPerGram(jouleperkilogram.KilocaloriesPerGram).JoulesPerKilogram, KilocaloriesPerGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromKilojoulesPerKilogram(jouleperkilogram.KilojoulesPerKilogram).JoulesPerKilogram, KilojoulesPerKilogramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromKilowattHoursPerKilogram(jouleperkilogram.KilowattHoursPerKilogram).JoulesPerKilogram, KilowattHoursPerKilogramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromMegajoulesPerKilogram(jouleperkilogram.MegajoulesPerKilogram).JoulesPerKilogram, MegajoulesPerKilogramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromMegawattHoursPerKilogram(jouleperkilogram.MegawattHoursPerKilogram).JoulesPerKilogram, MegawattHoursPerKilogramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromWattHoursPerKilogram(jouleperkilogram.WattHoursPerKilogram).JoulesPerKilogram, WattHoursPerKilogramTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            SpecificEnergy v = SpecificEnergy.FromJoulesPerKilogram(1);
            Assert.AreEqual(-1, -v.JoulesPerKilogram, JoulesPerKilogramTolerance);
            Assert.AreEqual(2, (SpecificEnergy.FromJoulesPerKilogram(3)-v).JoulesPerKilogram, JoulesPerKilogramTolerance);
            Assert.AreEqual(2, (v + v).JoulesPerKilogram, JoulesPerKilogramTolerance);
            Assert.AreEqual(10, (v*10).JoulesPerKilogram, JoulesPerKilogramTolerance);
            Assert.AreEqual(10, (10*v).JoulesPerKilogram, JoulesPerKilogramTolerance);
            Assert.AreEqual(2, (SpecificEnergy.FromJoulesPerKilogram(10)/5).JoulesPerKilogram, JoulesPerKilogramTolerance);
            Assert.AreEqual(2, SpecificEnergy.FromJoulesPerKilogram(10)/SpecificEnergy.FromJoulesPerKilogram(5), JoulesPerKilogramTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            SpecificEnergy oneJoulePerKilogram = SpecificEnergy.FromJoulesPerKilogram(1);
            SpecificEnergy twoJoulesPerKilogram = SpecificEnergy.FromJoulesPerKilogram(2);

            Assert.True(oneJoulePerKilogram < twoJoulesPerKilogram);
            Assert.True(oneJoulePerKilogram <= twoJoulesPerKilogram);
            Assert.True(twoJoulesPerKilogram > oneJoulePerKilogram);
            Assert.True(twoJoulesPerKilogram >= oneJoulePerKilogram);

            Assert.False(oneJoulePerKilogram > twoJoulesPerKilogram);
            Assert.False(oneJoulePerKilogram >= twoJoulesPerKilogram);
            Assert.False(twoJoulesPerKilogram < oneJoulePerKilogram);
            Assert.False(twoJoulesPerKilogram <= oneJoulePerKilogram);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKilogram(1);
            Assert.AreEqual(0, jouleperkilogram.CompareTo(jouleperkilogram));
            Assert.Greater(jouleperkilogram.CompareTo(SpecificEnergy.Zero), 0);
            Assert.Less(SpecificEnergy.Zero.CompareTo(jouleperkilogram), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKilogram(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            jouleperkilogram.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKilogram(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            jouleperkilogram.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            SpecificEnergy a = SpecificEnergy.FromJoulesPerKilogram(1);
            SpecificEnergy b = SpecificEnergy.FromJoulesPerKilogram(2);

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
            SpecificEnergy v = SpecificEnergy.FromJoulesPerKilogram(1);
            Assert.IsTrue(v.Equals(SpecificEnergy.FromJoulesPerKilogram(1)));
            Assert.IsFalse(v.Equals(SpecificEnergy.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKilogram(1);
            Assert.IsFalse(jouleperkilogram.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKilogram(1);
            Assert.IsFalse(jouleperkilogram.Equals(null));
        }
    }
}
