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
    /// Test of SpecificEnergy.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class SpecificEnergyTestsBase
    {
        protected abstract double JoulesPerKiloGramInOneJoulePerKiloGram { get; }
        protected abstract double KiloCaloriesPerGramInOneJoulePerKiloGram { get; }
        protected abstract double KilojoulesPerKiloGramInOneJoulePerKiloGram { get; }
        protected abstract double KilowattHoursPerKiloGramInOneJoulePerKiloGram { get; }
        protected abstract double MegajoulesPerKiloGramInOneJoulePerKiloGram { get; }
        protected abstract double MegawattHoursPerKiloGramInOneJoulePerKiloGram { get; }
        protected abstract double WattHoursPerKiloGramInOneJoulePerKiloGram { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double JoulesPerKiloGramTolerance { get { return 1e-5; } }
        protected virtual double KiloCaloriesPerGramTolerance { get { return 1e-5; } }
        protected virtual double KilojoulesPerKiloGramTolerance { get { return 1e-5; } }
        protected virtual double KilowattHoursPerKiloGramTolerance { get { return 1e-5; } }
        protected virtual double MegajoulesPerKiloGramTolerance { get { return 1e-5; } }
        protected virtual double MegawattHoursPerKiloGramTolerance { get { return 1e-5; } }
        protected virtual double WattHoursPerKiloGramTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void JoulePerKiloGramToSpecificEnergyUnits()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKiloGram(1);
            Assert.AreEqual(JoulesPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.JoulesPerKiloGram, JoulesPerKiloGramTolerance);
            Assert.AreEqual(KiloCaloriesPerGramInOneJoulePerKiloGram, jouleperkilogram.KiloCaloriesPerGram, KiloCaloriesPerGramTolerance);
            Assert.AreEqual(KilojoulesPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.KilojoulesPerKiloGram, KilojoulesPerKiloGramTolerance);
            Assert.AreEqual(KilowattHoursPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.KilowattHoursPerKiloGram, KilowattHoursPerKiloGramTolerance);
            Assert.AreEqual(MegajoulesPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.MegajoulesPerKiloGram, MegajoulesPerKiloGramTolerance);
            Assert.AreEqual(MegawattHoursPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.MegawattHoursPerKiloGram, MegawattHoursPerKiloGramTolerance);
            Assert.AreEqual(WattHoursPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.WattHoursPerKiloGram, WattHoursPerKiloGramTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.JoulePerKiloGram).JoulesPerKiloGram, JoulesPerKiloGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.KiloCaloriePerGram).KiloCaloriesPerGram, KiloCaloriesPerGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.KilojoulePerKiloGram).KilojoulesPerKiloGram, KilojoulesPerKiloGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.KilowattHourPerKiloGram).KilowattHoursPerKiloGram, KilowattHoursPerKiloGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.MegajoulePerKiloGram).MegajoulesPerKiloGram, MegajoulesPerKiloGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.MegawattHourPerKiloGram).MegawattHoursPerKiloGram, MegawattHoursPerKiloGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.From(1, SpecificEnergyUnit.WattHourPerKiloGram).WattHoursPerKiloGram, WattHoursPerKiloGramTolerance);
        }

        [Test]
        public void As()
        {
            var jouleperkilogram = SpecificEnergy.FromJoulesPerKiloGram(1);
            Assert.AreEqual(JoulesPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.As(SpecificEnergyUnit.JoulePerKiloGram), JoulesPerKiloGramTolerance);
            Assert.AreEqual(KiloCaloriesPerGramInOneJoulePerKiloGram, jouleperkilogram.As(SpecificEnergyUnit.KiloCaloriePerGram), KiloCaloriesPerGramTolerance);
            Assert.AreEqual(KilojoulesPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.As(SpecificEnergyUnit.KilojoulePerKiloGram), KilojoulesPerKiloGramTolerance);
            Assert.AreEqual(KilowattHoursPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.As(SpecificEnergyUnit.KilowattHourPerKiloGram), KilowattHoursPerKiloGramTolerance);
            Assert.AreEqual(MegajoulesPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.As(SpecificEnergyUnit.MegajoulePerKiloGram), MegajoulesPerKiloGramTolerance);
            Assert.AreEqual(MegawattHoursPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.As(SpecificEnergyUnit.MegawattHourPerKiloGram), MegawattHoursPerKiloGramTolerance);
            Assert.AreEqual(WattHoursPerKiloGramInOneJoulePerKiloGram, jouleperkilogram.As(SpecificEnergyUnit.WattHourPerKiloGram), WattHoursPerKiloGramTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKiloGram(1);
            Assert.AreEqual(1, SpecificEnergy.FromJoulesPerKiloGram(jouleperkilogram.JoulesPerKiloGram).JoulesPerKiloGram, JoulesPerKiloGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromKiloCaloriesPerGram(jouleperkilogram.KiloCaloriesPerGram).JoulesPerKiloGram, KiloCaloriesPerGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromKilojoulesPerKiloGram(jouleperkilogram.KilojoulesPerKiloGram).JoulesPerKiloGram, KilojoulesPerKiloGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromKilowattHoursPerKiloGram(jouleperkilogram.KilowattHoursPerKiloGram).JoulesPerKiloGram, KilowattHoursPerKiloGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromMegajoulesPerKiloGram(jouleperkilogram.MegajoulesPerKiloGram).JoulesPerKiloGram, MegajoulesPerKiloGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromMegawattHoursPerKiloGram(jouleperkilogram.MegawattHoursPerKiloGram).JoulesPerKiloGram, MegawattHoursPerKiloGramTolerance);
            Assert.AreEqual(1, SpecificEnergy.FromWattHoursPerKiloGram(jouleperkilogram.WattHoursPerKiloGram).JoulesPerKiloGram, WattHoursPerKiloGramTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            SpecificEnergy v = SpecificEnergy.FromJoulesPerKiloGram(1);
            Assert.AreEqual(-1, -v.JoulesPerKiloGram, JoulesPerKiloGramTolerance);
            Assert.AreEqual(2, (SpecificEnergy.FromJoulesPerKiloGram(3)-v).JoulesPerKiloGram, JoulesPerKiloGramTolerance);
            Assert.AreEqual(2, (v + v).JoulesPerKiloGram, JoulesPerKiloGramTolerance);
            Assert.AreEqual(10, (v*10).JoulesPerKiloGram, JoulesPerKiloGramTolerance);
            Assert.AreEqual(10, (10*v).JoulesPerKiloGram, JoulesPerKiloGramTolerance);
            Assert.AreEqual(2, (SpecificEnergy.FromJoulesPerKiloGram(10)/5).JoulesPerKiloGram, JoulesPerKiloGramTolerance);
            Assert.AreEqual(2, SpecificEnergy.FromJoulesPerKiloGram(10)/SpecificEnergy.FromJoulesPerKiloGram(5), JoulesPerKiloGramTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            SpecificEnergy oneJoulePerKiloGram = SpecificEnergy.FromJoulesPerKiloGram(1);
            SpecificEnergy twoJoulesPerKiloGram = SpecificEnergy.FromJoulesPerKiloGram(2);

            Assert.True(oneJoulePerKiloGram < twoJoulesPerKiloGram);
            Assert.True(oneJoulePerKiloGram <= twoJoulesPerKiloGram);
            Assert.True(twoJoulesPerKiloGram > oneJoulePerKiloGram);
            Assert.True(twoJoulesPerKiloGram >= oneJoulePerKiloGram);

            Assert.False(oneJoulePerKiloGram > twoJoulesPerKiloGram);
            Assert.False(oneJoulePerKiloGram >= twoJoulesPerKiloGram);
            Assert.False(twoJoulesPerKiloGram < oneJoulePerKiloGram);
            Assert.False(twoJoulesPerKiloGram <= oneJoulePerKiloGram);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKiloGram(1);
            Assert.AreEqual(0, jouleperkilogram.CompareTo(jouleperkilogram));
            Assert.Greater(jouleperkilogram.CompareTo(SpecificEnergy.Zero), 0);
            Assert.Less(SpecificEnergy.Zero.CompareTo(jouleperkilogram), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKiloGram(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            jouleperkilogram.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKiloGram(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            jouleperkilogram.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            SpecificEnergy a = SpecificEnergy.FromJoulesPerKiloGram(1);
            SpecificEnergy b = SpecificEnergy.FromJoulesPerKiloGram(2);

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
            SpecificEnergy v = SpecificEnergy.FromJoulesPerKiloGram(1);
            Assert.IsTrue(v.Equals(SpecificEnergy.FromJoulesPerKiloGram(1)));
            Assert.IsFalse(v.Equals(SpecificEnergy.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKiloGram(1);
            Assert.IsFalse(jouleperkilogram.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            SpecificEnergy jouleperkilogram = SpecificEnergy.FromJoulesPerKiloGram(1);
            Assert.IsFalse(jouleperkilogram.Equals(null));
        }
    }
}
