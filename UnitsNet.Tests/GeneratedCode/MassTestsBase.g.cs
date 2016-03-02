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
    /// Test of Mass.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MassTestsBase
    {
        protected abstract double CentigramsInOneKilogram { get; }
        protected abstract double DecagramsInOneKilogram { get; }
        protected abstract double DecigramsInOneKilogram { get; }
        protected abstract double GramsInOneKilogram { get; }
        protected abstract double HectogramsInOneKilogram { get; }
        protected abstract double KilogramsInOneKilogram { get; }
        protected abstract double KilotonnesInOneKilogram { get; }
        protected abstract double LongTonsInOneKilogram { get; }
        protected abstract double MegatonnesInOneKilogram { get; }
        protected abstract double MicrogramsInOneKilogram { get; }
        protected abstract double MilligramsInOneKilogram { get; }
        protected abstract double NanogramsInOneKilogram { get; }
        protected abstract double OuncesInOneKilogram { get; }
        protected abstract double PoundsInOneKilogram { get; }
        protected abstract double ShortTonsInOneKilogram { get; }
        protected abstract double StoneInOneKilogram { get; }
        protected abstract double TonnesInOneKilogram { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentigramsTolerance { get { return 1e-5; } }
        protected virtual double DecagramsTolerance { get { return 1e-5; } }
        protected virtual double DecigramsTolerance { get { return 1e-5; } }
        protected virtual double GramsTolerance { get { return 1e-5; } }
        protected virtual double HectogramsTolerance { get { return 1e-5; } }
        protected virtual double KilogramsTolerance { get { return 1e-5; } }
        protected virtual double KilotonnesTolerance { get { return 1e-5; } }
        protected virtual double LongTonsTolerance { get { return 1e-5; } }
        protected virtual double MegatonnesTolerance { get { return 1e-5; } }
        protected virtual double MicrogramsTolerance { get { return 1e-5; } }
        protected virtual double MilligramsTolerance { get { return 1e-5; } }
        protected virtual double NanogramsTolerance { get { return 1e-5; } }
        protected virtual double OuncesTolerance { get { return 1e-5; } }
        protected virtual double PoundsTolerance { get { return 1e-5; } }
        protected virtual double ShortTonsTolerance { get { return 1e-5; } }
        protected virtual double StoneTolerance { get { return 1e-5; } }
        protected virtual double TonnesTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void KilogramToMassUnits()
        {
            Mass kilogram = Mass.FromKilograms(1);
            Assert.AreEqual(CentigramsInOneKilogram, kilogram.Centigrams, CentigramsTolerance);
            Assert.AreEqual(DecagramsInOneKilogram, kilogram.Decagrams, DecagramsTolerance);
            Assert.AreEqual(DecigramsInOneKilogram, kilogram.Decigrams, DecigramsTolerance);
            Assert.AreEqual(GramsInOneKilogram, kilogram.Grams, GramsTolerance);
            Assert.AreEqual(HectogramsInOneKilogram, kilogram.Hectograms, HectogramsTolerance);
            Assert.AreEqual(KilogramsInOneKilogram, kilogram.Kilograms, KilogramsTolerance);
            Assert.AreEqual(KilotonnesInOneKilogram, kilogram.Kilotonnes, KilotonnesTolerance);
            Assert.AreEqual(LongTonsInOneKilogram, kilogram.LongTons, LongTonsTolerance);
            Assert.AreEqual(MegatonnesInOneKilogram, kilogram.Megatonnes, MegatonnesTolerance);
            Assert.AreEqual(MicrogramsInOneKilogram, kilogram.Micrograms, MicrogramsTolerance);
            Assert.AreEqual(MilligramsInOneKilogram, kilogram.Milligrams, MilligramsTolerance);
            Assert.AreEqual(NanogramsInOneKilogram, kilogram.Nanograms, NanogramsTolerance);
            Assert.AreEqual(OuncesInOneKilogram, kilogram.Ounces, OuncesTolerance);
            Assert.AreEqual(PoundsInOneKilogram, kilogram.Pounds, PoundsTolerance);
            Assert.AreEqual(ShortTonsInOneKilogram, kilogram.ShortTons, ShortTonsTolerance);
            Assert.AreEqual(StoneInOneKilogram, kilogram.Stone, StoneTolerance);
            Assert.AreEqual(TonnesInOneKilogram, kilogram.Tonnes, TonnesTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Mass.From(1, MassUnit.Centigram).Centigrams, CentigramsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Decagram).Decagrams, DecagramsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Decigram).Decigrams, DecigramsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Gram).Grams, GramsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Hectogram).Hectograms, HectogramsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Kilogram).Kilograms, KilogramsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Kilotonne).Kilotonnes, KilotonnesTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.LongTon).LongTons, LongTonsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Megatonne).Megatonnes, MegatonnesTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Microgram).Micrograms, MicrogramsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Milligram).Milligrams, MilligramsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Nanogram).Nanograms, NanogramsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Ounce).Ounces, OuncesTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Pound).Pounds, PoundsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.ShortTon).ShortTons, ShortTonsTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Stone).Stone, StoneTolerance);
            Assert.AreEqual(1, Mass.From(1, MassUnit.Tonne).Tonnes, TonnesTolerance);
        }

        [Test]
        public void As()
        {
            var kilogram = Mass.FromKilograms(1);
            Assert.AreEqual(CentigramsInOneKilogram, kilogram.As(MassUnit.Centigram), CentigramsTolerance);
            Assert.AreEqual(DecagramsInOneKilogram, kilogram.As(MassUnit.Decagram), DecagramsTolerance);
            Assert.AreEqual(DecigramsInOneKilogram, kilogram.As(MassUnit.Decigram), DecigramsTolerance);
            Assert.AreEqual(GramsInOneKilogram, kilogram.As(MassUnit.Gram), GramsTolerance);
            Assert.AreEqual(HectogramsInOneKilogram, kilogram.As(MassUnit.Hectogram), HectogramsTolerance);
            Assert.AreEqual(KilogramsInOneKilogram, kilogram.As(MassUnit.Kilogram), KilogramsTolerance);
            Assert.AreEqual(KilotonnesInOneKilogram, kilogram.As(MassUnit.Kilotonne), KilotonnesTolerance);
            Assert.AreEqual(LongTonsInOneKilogram, kilogram.As(MassUnit.LongTon), LongTonsTolerance);
            Assert.AreEqual(MegatonnesInOneKilogram, kilogram.As(MassUnit.Megatonne), MegatonnesTolerance);
            Assert.AreEqual(MicrogramsInOneKilogram, kilogram.As(MassUnit.Microgram), MicrogramsTolerance);
            Assert.AreEqual(MilligramsInOneKilogram, kilogram.As(MassUnit.Milligram), MilligramsTolerance);
            Assert.AreEqual(NanogramsInOneKilogram, kilogram.As(MassUnit.Nanogram), NanogramsTolerance);
            Assert.AreEqual(OuncesInOneKilogram, kilogram.As(MassUnit.Ounce), OuncesTolerance);
            Assert.AreEqual(PoundsInOneKilogram, kilogram.As(MassUnit.Pound), PoundsTolerance);
            Assert.AreEqual(ShortTonsInOneKilogram, kilogram.As(MassUnit.ShortTon), ShortTonsTolerance);
            Assert.AreEqual(StoneInOneKilogram, kilogram.As(MassUnit.Stone), StoneTolerance);
            Assert.AreEqual(TonnesInOneKilogram, kilogram.As(MassUnit.Tonne), TonnesTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Mass kilogram = Mass.FromKilograms(1);
            Assert.AreEqual(1, Mass.FromCentigrams(kilogram.Centigrams).Kilograms, CentigramsTolerance);
            Assert.AreEqual(1, Mass.FromDecagrams(kilogram.Decagrams).Kilograms, DecagramsTolerance);
            Assert.AreEqual(1, Mass.FromDecigrams(kilogram.Decigrams).Kilograms, DecigramsTolerance);
            Assert.AreEqual(1, Mass.FromGrams(kilogram.Grams).Kilograms, GramsTolerance);
            Assert.AreEqual(1, Mass.FromHectograms(kilogram.Hectograms).Kilograms, HectogramsTolerance);
            Assert.AreEqual(1, Mass.FromKilograms(kilogram.Kilograms).Kilograms, KilogramsTolerance);
            Assert.AreEqual(1, Mass.FromKilotonnes(kilogram.Kilotonnes).Kilograms, KilotonnesTolerance);
            Assert.AreEqual(1, Mass.FromLongTons(kilogram.LongTons).Kilograms, LongTonsTolerance);
            Assert.AreEqual(1, Mass.FromMegatonnes(kilogram.Megatonnes).Kilograms, MegatonnesTolerance);
            Assert.AreEqual(1, Mass.FromMicrograms(kilogram.Micrograms).Kilograms, MicrogramsTolerance);
            Assert.AreEqual(1, Mass.FromMilligrams(kilogram.Milligrams).Kilograms, MilligramsTolerance);
            Assert.AreEqual(1, Mass.FromNanograms(kilogram.Nanograms).Kilograms, NanogramsTolerance);
            Assert.AreEqual(1, Mass.FromOunces(kilogram.Ounces).Kilograms, OuncesTolerance);
            Assert.AreEqual(1, Mass.FromPounds(kilogram.Pounds).Kilograms, PoundsTolerance);
            Assert.AreEqual(1, Mass.FromShortTons(kilogram.ShortTons).Kilograms, ShortTonsTolerance);
            Assert.AreEqual(1, Mass.FromStone(kilogram.Stone).Kilograms, StoneTolerance);
            Assert.AreEqual(1, Mass.FromTonnes(kilogram.Tonnes).Kilograms, TonnesTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Mass v = Mass.FromKilograms(1);
            Assert.AreEqual(-1, -v.Kilograms, KilogramsTolerance);
            Assert.AreEqual(2, (Mass.FromKilograms(3)-v).Kilograms, KilogramsTolerance);
            Assert.AreEqual(2, (v + v).Kilograms, KilogramsTolerance);
            Assert.AreEqual(10, (v*10).Kilograms, KilogramsTolerance);
            Assert.AreEqual(10, (10*v).Kilograms, KilogramsTolerance);
            Assert.AreEqual(2, (Mass.FromKilograms(10)/5).Kilograms, KilogramsTolerance);
            Assert.AreEqual(2, Mass.FromKilograms(10)/Mass.FromKilograms(5), KilogramsTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Mass oneKilogram = Mass.FromKilograms(1);
            Mass twoKilograms = Mass.FromKilograms(2);

            Assert.True(oneKilogram < twoKilograms);
            Assert.True(oneKilogram <= twoKilograms);
            Assert.True(twoKilograms > oneKilogram);
            Assert.True(twoKilograms >= oneKilogram);

            Assert.False(oneKilogram > twoKilograms);
            Assert.False(oneKilogram >= twoKilograms);
            Assert.False(twoKilograms < oneKilogram);
            Assert.False(twoKilograms <= oneKilogram);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Mass kilogram = Mass.FromKilograms(1);
            Assert.AreEqual(0, kilogram.CompareTo(kilogram));
            Assert.Greater(kilogram.CompareTo(Mass.Zero), 0);
            Assert.Less(Mass.Zero.CompareTo(kilogram), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Mass kilogram = Mass.FromKilograms(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogram.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Mass kilogram = Mass.FromKilograms(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            kilogram.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Mass a = Mass.FromKilograms(1);
            Mass b = Mass.FromKilograms(2);

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
            Mass v = Mass.FromKilograms(1);
            Assert.IsTrue(v.Equals(Mass.FromKilograms(1)));
            Assert.IsFalse(v.Equals(Mass.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Mass kilogram = Mass.FromKilograms(1);
            Assert.IsFalse(kilogram.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Mass kilogram = Mass.FromKilograms(1);
            Assert.IsFalse(kilogram.Equals(null));
        }
    }
}
