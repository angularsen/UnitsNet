// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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
    public abstract partial class TemperatureTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        public abstract double DegreesCelsiusInOneKelvin { get; }
        public abstract double DegreesDelisleInOneKelvin { get; }
        public abstract double DegreesFahrenheitInOneKelvin { get; }
        public abstract double DegreesNewtonInOneKelvin { get; }
        public abstract double DegreesRankineInOneKelvin { get; }
        public abstract double DegreesReaumurInOneKelvin { get; }
        public abstract double DegreesRoemerInOneKelvin { get; }
        public abstract double KelvinsInOneKelvin { get; }

        [Test]
        public void KelvinToTemperatureUnits()
        {
            Temperature kelvin = Temperature.FromKelvins(1);
            Assert.AreEqual(DegreesCelsiusInOneKelvin, kelvin.DegreesCelsius, Delta);
            Assert.AreEqual(DegreesDelisleInOneKelvin, kelvin.DegreesDelisle, Delta);
            Assert.AreEqual(DegreesFahrenheitInOneKelvin, kelvin.DegreesFahrenheit, Delta);
            Assert.AreEqual(DegreesNewtonInOneKelvin, kelvin.DegreesNewton, Delta);
            Assert.AreEqual(DegreesRankineInOneKelvin, kelvin.DegreesRankine, Delta);
            Assert.AreEqual(DegreesReaumurInOneKelvin, kelvin.DegreesReaumur, Delta);
            Assert.AreEqual(DegreesRoemerInOneKelvin, kelvin.DegreesRoemer, Delta);
            Assert.AreEqual(KelvinsInOneKelvin, kelvin.Kelvins, Delta);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeCelsius).DegreesCelsius, Delta);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeDelisle).DegreesDelisle, Delta);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeFahrenheit).DegreesFahrenheit, Delta);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeNewton).DegreesNewton, Delta);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeRankine).DegreesRankine, Delta);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeReaumur).DegreesReaumur, Delta);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.DegreeRoemer).DegreesRoemer, Delta);
            Assert.AreEqual(1, Temperature.From(1, TemperatureUnit.Kelvin).Kelvins, Delta);
        }


        [Test]
        public void As()
        {
            var kelvin = Temperature.FromKelvins(1);
            Assert.AreEqual(DegreesCelsiusInOneKelvin, kelvin.As(TemperatureUnit.DegreeCelsius), Delta);
            Assert.AreEqual(DegreesDelisleInOneKelvin, kelvin.As(TemperatureUnit.DegreeDelisle), Delta);
            Assert.AreEqual(DegreesFahrenheitInOneKelvin, kelvin.As(TemperatureUnit.DegreeFahrenheit), Delta);
            Assert.AreEqual(DegreesNewtonInOneKelvin, kelvin.As(TemperatureUnit.DegreeNewton), Delta);
            Assert.AreEqual(DegreesRankineInOneKelvin, kelvin.As(TemperatureUnit.DegreeRankine), Delta);
            Assert.AreEqual(DegreesReaumurInOneKelvin, kelvin.As(TemperatureUnit.DegreeReaumur), Delta);
            Assert.AreEqual(DegreesRoemerInOneKelvin, kelvin.As(TemperatureUnit.DegreeRoemer), Delta);
            Assert.AreEqual(KelvinsInOneKelvin, kelvin.As(TemperatureUnit.Kelvin), Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Temperature kelvin = Temperature.FromKelvins(1); 
            Assert.AreEqual(1, Temperature.FromDegreesCelsius(kelvin.DegreesCelsius).Kelvins, Delta);
            Assert.AreEqual(1, Temperature.FromDegreesDelisle(kelvin.DegreesDelisle).Kelvins, Delta);
            Assert.AreEqual(1, Temperature.FromDegreesFahrenheit(kelvin.DegreesFahrenheit).Kelvins, Delta);
            Assert.AreEqual(1, Temperature.FromDegreesNewton(kelvin.DegreesNewton).Kelvins, Delta);
            Assert.AreEqual(1, Temperature.FromDegreesRankine(kelvin.DegreesRankine).Kelvins, Delta);
            Assert.AreEqual(1, Temperature.FromDegreesReaumur(kelvin.DegreesReaumur).Kelvins, Delta);
            Assert.AreEqual(1, Temperature.FromDegreesRoemer(kelvin.DegreesRoemer).Kelvins, Delta);
            Assert.AreEqual(1, Temperature.FromKelvins(kelvin.Kelvins).Kelvins, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Temperature v = Temperature.FromKelvins(1);
            Assert.AreEqual(-1, -v.Kelvins, Delta);
            Assert.AreEqual(2, (Temperature.FromKelvins(3)-v).Kelvins, Delta);
            Assert.AreEqual(2, (v + v).Kelvins, Delta);
            Assert.AreEqual(10, (v*10).Kelvins, Delta);
            Assert.AreEqual(10, (10*v).Kelvins, Delta);
            Assert.AreEqual(2, (Temperature.FromKelvins(10)/5).Kelvins, Delta);
            Assert.AreEqual(2, Temperature.FromKelvins(10)/Temperature.FromKelvins(5), Delta);
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
