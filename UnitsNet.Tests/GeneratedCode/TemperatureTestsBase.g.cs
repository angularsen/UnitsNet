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
    /// Test of Temperature.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class TemperatureTestsBase
    {
        protected abstract double DegreesCelsiusInOneKelvin { get; }
        protected abstract double DegreesDelisleInOneKelvin { get; }
        protected abstract double DegreesFahrenheitInOneKelvin { get; }
        protected abstract double DegreesNewtonInOneKelvin { get; }
        protected abstract double DegreesRankineInOneKelvin { get; }
        protected abstract double DegreesReaumurInOneKelvin { get; }
        protected abstract double DegreesRoemerInOneKelvin { get; }
        protected abstract double KelvinsInOneKelvin { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DegreesCelsiusTolerance { get { return 1e-5; } }
        protected virtual double DegreesDelisleTolerance { get { return 1e-5; } }
        protected virtual double DegreesFahrenheitTolerance { get { return 1e-5; } }
        protected virtual double DegreesNewtonTolerance { get { return 1e-5; } }
        protected virtual double DegreesRankineTolerance { get { return 1e-5; } }
        protected virtual double DegreesReaumurTolerance { get { return 1e-5; } }
        protected virtual double DegreesRoemerTolerance { get { return 1e-5; } }
        protected virtual double KelvinsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void KelvinToTemperatureUnits()
        {
            Temperature kelvin = Temperature.FromKelvins(1);
            Assert.AreEqual(DegreesCelsiusInOneKelvin, kelvin.DegreesCelsius, DegreesCelsiusTolerance);
            Assert.AreEqual(DegreesDelisleInOneKelvin, kelvin.DegreesDelisle, DegreesDelisleTolerance);
            Assert.AreEqual(DegreesFahrenheitInOneKelvin, kelvin.DegreesFahrenheit, DegreesFahrenheitTolerance);
            Assert.AreEqual(DegreesNewtonInOneKelvin, kelvin.DegreesNewton, DegreesNewtonTolerance);
            Assert.AreEqual(DegreesRankineInOneKelvin, kelvin.DegreesRankine, DegreesRankineTolerance);
            Assert.AreEqual(DegreesReaumurInOneKelvin, kelvin.DegreesReaumur, DegreesReaumurTolerance);
            Assert.AreEqual(DegreesRoemerInOneKelvin, kelvin.DegreesRoemer, DegreesRoemerTolerance);
            Assert.AreEqual(KelvinsInOneKelvin, kelvin.Kelvins, KelvinsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeCelsius).DegreesCelsius, DegreesCelsiusTolerance);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeDelisle).DegreesDelisle, DegreesDelisleTolerance);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeFahrenheit).DegreesFahrenheit, DegreesFahrenheitTolerance);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeNewton).DegreesNewton, DegreesNewtonTolerance);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeRankine).DegreesRankine, DegreesRankineTolerance);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeReaumur).DegreesReaumur, DegreesReaumurTolerance);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeRoemer).DegreesRoemer, DegreesRoemerTolerance);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.Kelvin).Kelvins, KelvinsTolerance);
        }

        [Test]
        public void As()
        {
            var kelvin = Temperature.FromKelvins(1);
            Assert.AreEqual(DegreesCelsiusInOneKelvin, kelvin.As(TemperatureUnit.DegreeCelsius), DegreesCelsiusTolerance);
            Assert.AreEqual(DegreesDelisleInOneKelvin, kelvin.As(TemperatureUnit.DegreeDelisle), DegreesDelisleTolerance);
            Assert.AreEqual(DegreesFahrenheitInOneKelvin, kelvin.As(TemperatureUnit.DegreeFahrenheit), DegreesFahrenheitTolerance);
            Assert.AreEqual(DegreesNewtonInOneKelvin, kelvin.As(TemperatureUnit.DegreeNewton), DegreesNewtonTolerance);
            Assert.AreEqual(DegreesRankineInOneKelvin, kelvin.As(TemperatureUnit.DegreeRankine), DegreesRankineTolerance);
            Assert.AreEqual(DegreesReaumurInOneKelvin, kelvin.As(TemperatureUnit.DegreeReaumur), DegreesReaumurTolerance);
            Assert.AreEqual(DegreesRoemerInOneKelvin, kelvin.As(TemperatureUnit.DegreeRoemer), DegreesRoemerTolerance);
            Assert.AreEqual(KelvinsInOneKelvin, kelvin.As(TemperatureUnit.Kelvin), KelvinsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Temperature kelvin = Temperature.FromKelvins(1);
            Assert.AreEqual(1, Temperature.FromDegreesCelsius(kelvin.DegreesCelsius).Kelvins, DegreesCelsiusTolerance);
            Assert.AreEqual(1, Temperature.FromDegreesDelisle(kelvin.DegreesDelisle).Kelvins, DegreesDelisleTolerance);
            Assert.AreEqual(1, Temperature.FromDegreesFahrenheit(kelvin.DegreesFahrenheit).Kelvins, DegreesFahrenheitTolerance);
            Assert.AreEqual(1, Temperature.FromDegreesNewton(kelvin.DegreesNewton).Kelvins, DegreesNewtonTolerance);
            Assert.AreEqual(1, Temperature.FromDegreesRankine(kelvin.DegreesRankine).Kelvins, DegreesRankineTolerance);
            Assert.AreEqual(1, Temperature.FromDegreesReaumur(kelvin.DegreesReaumur).Kelvins, DegreesReaumurTolerance);
            Assert.AreEqual(1, Temperature.FromDegreesRoemer(kelvin.DegreesRoemer).Kelvins, DegreesRoemerTolerance);
            Assert.AreEqual(1, Temperature.FromKelvins(kelvin.Kelvins).Kelvins, KelvinsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Temperature v = Temperature.FromKelvins(1);
            Assert.AreEqual(-1, -v.Kelvins, KelvinsTolerance);
            Assert.AreEqual(2, (Temperature.FromKelvins(3)-v).Kelvins, KelvinsTolerance);
            Assert.AreEqual(2, (v + v).Kelvins, KelvinsTolerance);
            Assert.AreEqual(10, (v*10).Kelvins, KelvinsTolerance);
            Assert.AreEqual(10, (10*v).Kelvins, KelvinsTolerance);
            Assert.AreEqual(2, (Temperature.FromKelvins(10)/5).Kelvins, KelvinsTolerance);
            Assert.AreEqual(2, Temperature.FromKelvins(10)/Temperature.FromKelvins(5), KelvinsTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Temperature oneKelvin = Temperature.FromKelvins(1);
            Temperature twoKelvins = Temperature.FromKelvins(2);

            Assert.True(oneKelvin < twoKelvins);
            Assert.True(oneKelvin <= twoKelvins);
            Assert.True(twoKelvins > oneKelvin);
            Assert.True(twoKelvins >= oneKelvin);

            Assert.False(oneKelvin > twoKelvins);
            Assert.False(oneKelvin >= twoKelvins);
            Assert.False(twoKelvins < oneKelvin);
            Assert.False(twoKelvins <= oneKelvin);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Temperature kelvin = Temperature.FromKelvins(1);
            Assert.AreEqual(0, kelvin.CompareTo(kelvin));
            Assert.Greater(kelvin.CompareTo(Temperature.Zero), 0);
            Assert.Less(Temperature.Zero.CompareTo(kelvin), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Temperature kelvin = Temperature.FromKelvins(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kelvin.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Temperature kelvin = Temperature.FromKelvins(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kelvin.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Temperature a = Temperature.FromKelvins(1);
            Temperature b = Temperature.FromKelvins(2);

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
            Temperature v = Temperature.FromKelvins(1);
            Assert.IsTrue(v.Equals(Temperature.FromKelvins(1)));
            Assert.IsFalse(v.Equals(Temperature.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Temperature kelvin = Temperature.FromKelvins(1);
            Assert.IsFalse(kelvin.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Temperature kelvin = Temperature.FromKelvins(1);
            Assert.IsFalse(kelvin.Equals(null));
        }
    }
}
