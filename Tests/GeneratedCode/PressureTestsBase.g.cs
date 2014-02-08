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
    /// Test of Pressure.
    /// </summary>
    [TestFixture]
    public abstract partial class PressureTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        public abstract double AtmospheresInOnePascal { get; }
        public abstract double BarsInOnePascal { get; }
        public abstract double KilogramForcePerSquareCentimeterInOnePascal { get; }
        public abstract double KilopascalsInOnePascal { get; }
        public abstract double MegapascalsInOnePascal { get; }
        public abstract double NewtonsPerSquareCentimeterInOnePascal { get; }
        public abstract double NewtonsPerSquareMeterInOnePascal { get; }
        public abstract double NewtonsPerSquareMillimeterInOnePascal { get; }
        public abstract double PascalsInOnePascal { get; }
        public abstract double PsiInOnePascal { get; }
        public abstract double TechnicalAtmospheresInOnePascal { get; }
        public abstract double TorrsInOnePascal { get; }

        [Test]
        public void PascalToPressureUnits()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.AreEqual(AtmospheresInOnePascal, pascal.Atmospheres, Delta);
            Assert.AreEqual(BarsInOnePascal, pascal.Bars, Delta);
            Assert.AreEqual(KilogramForcePerSquareCentimeterInOnePascal, pascal.KilogramForcePerSquareCentimeter, Delta);
            Assert.AreEqual(KilopascalsInOnePascal, pascal.Kilopascals, Delta);
            Assert.AreEqual(MegapascalsInOnePascal, pascal.Megapascals, Delta);
            Assert.AreEqual(NewtonsPerSquareCentimeterInOnePascal, pascal.NewtonsPerSquareCentimeter, Delta);
            Assert.AreEqual(NewtonsPerSquareMeterInOnePascal, pascal.NewtonsPerSquareMeter, Delta);
            Assert.AreEqual(NewtonsPerSquareMillimeterInOnePascal, pascal.NewtonsPerSquareMillimeter, Delta);
            Assert.AreEqual(PascalsInOnePascal, pascal.Pascals, Delta);
            Assert.AreEqual(PsiInOnePascal, pascal.Psi, Delta);
            Assert.AreEqual(TechnicalAtmospheresInOnePascal, pascal.TechnicalAtmospheres, Delta);
            Assert.AreEqual(TorrsInOnePascal, pascal.Torrs, Delta);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Atmosphere).Atmospheres, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Bar).Bars, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.KilogramForcePerSquareCentimeter).KilogramForcePerSquareCentimeter, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Kilopascal).Kilopascals, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Megapascal).Megapascals, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.NewtonPerSquareCentimeter).NewtonsPerSquareCentimeter, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.NewtonPerSquareMeter).NewtonsPerSquareMeter, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.NewtonPerSquareMillimeter).NewtonsPerSquareMillimeter, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Pascal).Pascals, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Psi).Psi, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.TechnicalAtmosphere).TechnicalAtmospheres, Delta);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Torr).Torrs, Delta);
        }


        [Test]
        public void In()
        {
            var pascal = Pressure.FromPascals(1);
            Assert.AreEqual(AtmospheresInOnePascal, pascal.Convert(PressureUnit.Atmosphere), Delta);
            Assert.AreEqual(BarsInOnePascal, pascal.Convert(PressureUnit.Bar), Delta);
            Assert.AreEqual(KilogramForcePerSquareCentimeterInOnePascal, pascal.Convert(PressureUnit.KilogramForcePerSquareCentimeter), Delta);
            Assert.AreEqual(KilopascalsInOnePascal, pascal.Convert(PressureUnit.Kilopascal), Delta);
            Assert.AreEqual(MegapascalsInOnePascal, pascal.Convert(PressureUnit.Megapascal), Delta);
            Assert.AreEqual(NewtonsPerSquareCentimeterInOnePascal, pascal.Convert(PressureUnit.NewtonPerSquareCentimeter), Delta);
            Assert.AreEqual(NewtonsPerSquareMeterInOnePascal, pascal.Convert(PressureUnit.NewtonPerSquareMeter), Delta);
            Assert.AreEqual(NewtonsPerSquareMillimeterInOnePascal, pascal.Convert(PressureUnit.NewtonPerSquareMillimeter), Delta);
            Assert.AreEqual(PascalsInOnePascal, pascal.Convert(PressureUnit.Pascal), Delta);
            Assert.AreEqual(PsiInOnePascal, pascal.Convert(PressureUnit.Psi), Delta);
            Assert.AreEqual(TechnicalAtmospheresInOnePascal, pascal.Convert(PressureUnit.TechnicalAtmosphere), Delta);
            Assert.AreEqual(TorrsInOnePascal, pascal.Convert(PressureUnit.Torr), Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Pressure pascal = Pressure.FromPascals(1); 
            Assert.AreEqual(1, Pressure.FromAtmospheres(pascal.Atmospheres).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromBars(pascal.Bars).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromKilogramForcePerSquareCentimeter(pascal.KilogramForcePerSquareCentimeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromKilopascals(pascal.Kilopascals).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromMegapascals(pascal.Megapascals).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareCentimeter(pascal.NewtonsPerSquareCentimeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareMeter(pascal.NewtonsPerSquareMeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareMillimeter(pascal.NewtonsPerSquareMillimeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromPascals(pascal.Pascals).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromPsi(pascal.Psi).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromTechnicalAtmospheres(pascal.TechnicalAtmospheres).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromTorrs(pascal.Torrs).Pascals, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Pressure v = Pressure.FromPascals(1);
            Assert.AreEqual(-1, -v.Pascals, Delta);
            Assert.AreEqual(2, (Pressure.FromPascals(3)-v).Pascals, Delta);
            Assert.AreEqual(2, (v + v).Pascals, Delta);
            Assert.AreEqual(10, (v*10).Pascals, Delta);
            Assert.AreEqual(10, (10*v).Pascals, Delta);
            Assert.AreEqual(2, (Pressure.FromPascals(10)/5).Pascals, Delta);
            Assert.AreEqual(2, Pressure.FromPascals(10)/Pressure.FromPascals(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Pressure onePascal = Pressure.FromPascals(1);
            Pressure twoPascals = Pressure.FromPascals(2);

            Assert.True(onePascal < twoPascals);
            Assert.True(onePascal <= twoPascals);
            Assert.True(twoPascals > onePascal);
            Assert.True(twoPascals >= onePascal);

            Assert.False(onePascal > twoPascals);
            Assert.False(onePascal >= twoPascals);
            Assert.False(twoPascals < onePascal);
            Assert.False(twoPascals <= onePascal);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.AreEqual(0, pascal.CompareTo(pascal));
            Assert.Greater(pascal.CompareTo(Pressure.Zero), 0);
            Assert.Less(Pressure.Zero.CompareTo(pascal), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Pressure pascal = Pressure.FromPascals(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            pascal.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Pressure pascal = Pressure.FromPascals(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            pascal.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Pressure a = Pressure.FromPascals(1);
            Pressure b = Pressure.FromPascals(2);

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
            Pressure v = Pressure.FromPascals(1);
            Assert.IsTrue(v.Equals(Pressure.FromPascals(1)));
            Assert.IsFalse(v.Equals(Pressure.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.IsFalse(pascal.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.IsFalse(pascal.Equals(null));
        }
    }
}
