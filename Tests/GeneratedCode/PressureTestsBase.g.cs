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
    /// Test of Pressure.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class PressureTestsBase
    {
        protected abstract double AtmospheresInOnePascal { get; }
        protected abstract double BarsInOnePascal { get; }
        protected abstract double KilogramsForcePerSquareCentimeterInOnePascal { get; }
        protected abstract double KilopascalsInOnePascal { get; }
        protected abstract double MegapascalsInOnePascal { get; }
        protected abstract double NewtonsPerSquareCentimeterInOnePascal { get; }
        protected abstract double NewtonsPerSquareMeterInOnePascal { get; }
        protected abstract double NewtonsPerSquareMillimeterInOnePascal { get; }
        protected abstract double PascalsInOnePascal { get; }
        protected abstract double PsiInOnePascal { get; }
        protected abstract double TechnicalAtmospheresInOnePascal { get; }
        protected abstract double TorrsInOnePascal { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double AtmospheresTolerance { get { return 1E-5; } }
        protected virtual double BarsTolerance { get { return 1E-5; } }
        protected virtual double KilogramsForcePerSquareCentimeterTolerance { get { return 1E-5; } }
        protected virtual double KilopascalsTolerance { get { return 1E-5; } }
        protected virtual double MegapascalsTolerance { get { return 1E-5; } }
        protected virtual double NewtonsPerSquareCentimeterTolerance { get { return 1E-5; } }
        protected virtual double NewtonsPerSquareMeterTolerance { get { return 1E-5; } }
        protected virtual double NewtonsPerSquareMillimeterTolerance { get { return 1E-5; } }
        protected virtual double PascalsTolerance { get { return 1E-5; } }
        protected virtual double PsiTolerance { get { return 1E-5; } }
        protected virtual double TechnicalAtmospheresTolerance { get { return 1E-5; } }
        protected virtual double TorrsTolerance { get { return 1E-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void PascalToPressureUnits()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.AreEqual(AtmospheresInOnePascal, pascal.Atmospheres, AtmospheresTolerance);
            Assert.AreEqual(BarsInOnePascal, pascal.Bars, BarsTolerance);
            Assert.AreEqual(KilogramsForcePerSquareCentimeterInOnePascal, pascal.KilogramsForcePerSquareCentimeter, KilogramsForcePerSquareCentimeterTolerance);
            Assert.AreEqual(KilopascalsInOnePascal, pascal.Kilopascals, KilopascalsTolerance);
            Assert.AreEqual(MegapascalsInOnePascal, pascal.Megapascals, MegapascalsTolerance);
            Assert.AreEqual(NewtonsPerSquareCentimeterInOnePascal, pascal.NewtonsPerSquareCentimeter, NewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(NewtonsPerSquareMeterInOnePascal, pascal.NewtonsPerSquareMeter, NewtonsPerSquareMeterTolerance);
            Assert.AreEqual(NewtonsPerSquareMillimeterInOnePascal, pascal.NewtonsPerSquareMillimeter, NewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(PascalsInOnePascal, pascal.Pascals, PascalsTolerance);
            Assert.AreEqual(PsiInOnePascal, pascal.Psi, PsiTolerance);
            Assert.AreEqual(TechnicalAtmospheresInOnePascal, pascal.TechnicalAtmospheres, TechnicalAtmospheresTolerance);
            Assert.AreEqual(TorrsInOnePascal, pascal.Torrs, TorrsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Atmosphere).Atmospheres, AtmospheresTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Bar).Bars, BarsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.KilogramForcePerSquareCentimeter).KilogramsForcePerSquareCentimeter, KilogramsForcePerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Kilopascal).Kilopascals, KilopascalsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Megapascal).Megapascals, MegapascalsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.NewtonPerSquareCentimeter).NewtonsPerSquareCentimeter, NewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.NewtonPerSquareMeter).NewtonsPerSquareMeter, NewtonsPerSquareMeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.NewtonPerSquareMillimeter).NewtonsPerSquareMillimeter, NewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Pascal).Pascals, PascalsTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Psi).Psi, PsiTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.TechnicalAtmosphere).TechnicalAtmospheres, TechnicalAtmospheresTolerance);
            Assert.AreEqual(1, Pressure.From(1, PressureUnit.Torr).Torrs, TorrsTolerance);
        }

        [Test]
        public void As()
        {
            var pascal = Pressure.FromPascals(1);
            Assert.AreEqual(AtmospheresInOnePascal, pascal.As(PressureUnit.Atmosphere), AtmospheresTolerance);
            Assert.AreEqual(BarsInOnePascal, pascal.As(PressureUnit.Bar), BarsTolerance);
            Assert.AreEqual(KilogramsForcePerSquareCentimeterInOnePascal, pascal.As(PressureUnit.KilogramForcePerSquareCentimeter), KilogramsForcePerSquareCentimeterTolerance);
            Assert.AreEqual(KilopascalsInOnePascal, pascal.As(PressureUnit.Kilopascal), KilopascalsTolerance);
            Assert.AreEqual(MegapascalsInOnePascal, pascal.As(PressureUnit.Megapascal), MegapascalsTolerance);
            Assert.AreEqual(NewtonsPerSquareCentimeterInOnePascal, pascal.As(PressureUnit.NewtonPerSquareCentimeter), NewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(NewtonsPerSquareMeterInOnePascal, pascal.As(PressureUnit.NewtonPerSquareMeter), NewtonsPerSquareMeterTolerance);
            Assert.AreEqual(NewtonsPerSquareMillimeterInOnePascal, pascal.As(PressureUnit.NewtonPerSquareMillimeter), NewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(PascalsInOnePascal, pascal.As(PressureUnit.Pascal), PascalsTolerance);
            Assert.AreEqual(PsiInOnePascal, pascal.As(PressureUnit.Psi), PsiTolerance);
            Assert.AreEqual(TechnicalAtmospheresInOnePascal, pascal.As(PressureUnit.TechnicalAtmosphere), TechnicalAtmospheresTolerance);
            Assert.AreEqual(TorrsInOnePascal, pascal.As(PressureUnit.Torr), TorrsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Pressure pascal = Pressure.FromPascals(1);
            Assert.AreEqual(1, Pressure.FromAtmospheres(pascal.Atmospheres).Pascals, AtmospheresTolerance);
            Assert.AreEqual(1, Pressure.FromBars(pascal.Bars).Pascals, BarsTolerance);
            Assert.AreEqual(1, Pressure.FromKilogramsForcePerSquareCentimeter(pascal.KilogramsForcePerSquareCentimeter).Pascals, KilogramsForcePerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.FromKilopascals(pascal.Kilopascals).Pascals, KilopascalsTolerance);
            Assert.AreEqual(1, Pressure.FromMegapascals(pascal.Megapascals).Pascals, MegapascalsTolerance);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareCentimeter(pascal.NewtonsPerSquareCentimeter).Pascals, NewtonsPerSquareCentimeterTolerance);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareMeter(pascal.NewtonsPerSquareMeter).Pascals, NewtonsPerSquareMeterTolerance);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareMillimeter(pascal.NewtonsPerSquareMillimeter).Pascals, NewtonsPerSquareMillimeterTolerance);
            Assert.AreEqual(1, Pressure.FromPascals(pascal.Pascals).Pascals, PascalsTolerance);
            Assert.AreEqual(1, Pressure.FromPsi(pascal.Psi).Pascals, PsiTolerance);
            Assert.AreEqual(1, Pressure.FromTechnicalAtmospheres(pascal.TechnicalAtmospheres).Pascals, TechnicalAtmospheresTolerance);
            Assert.AreEqual(1, Pressure.FromTorrs(pascal.Torrs).Pascals, TorrsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Pressure v = Pressure.FromPascals(1);
            Assert.AreEqual(-1, -v.Pascals, TorrsTolerance);
            Assert.AreEqual(2, (Pressure.FromPascals(3)-v).Pascals, TorrsTolerance);
            Assert.AreEqual(2, (v + v).Pascals, TorrsTolerance);
            Assert.AreEqual(10, (v*10).Pascals, TorrsTolerance);
            Assert.AreEqual(10, (10*v).Pascals, TorrsTolerance);
            Assert.AreEqual(2, (Pressure.FromPascals(10)/5).Pascals, TorrsTolerance);
            Assert.AreEqual(2, Pressure.FromPascals(10)/Pressure.FromPascals(5), TorrsTolerance);
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
