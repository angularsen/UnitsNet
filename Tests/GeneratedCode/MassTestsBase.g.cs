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

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Mass.
    /// </summary>
    public abstract partial class MassTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        public abstract double CentigramsInOneKilogram { get; }
        public abstract double DecagramsInOneKilogram { get; }
        public abstract double DecigramsInOneKilogram { get; }
        public abstract double GramsInOneKilogram { get; }
        public abstract double HectogramsInOneKilogram { get; }
        public abstract double KilogramsInOneKilogram { get; }
        public abstract double KilotonnesInOneKilogram { get; }
        public abstract double LongTonsInOneKilogram { get; }
        public abstract double MegatonnesInOneKilogram { get; }
        public abstract double MicrogramsInOneKilogram { get; }
        public abstract double MilligramsInOneKilogram { get; }
        public abstract double NanogramsInOneKilogram { get; }
        public abstract double ShortTonsInOneKilogram { get; }
        public abstract double TonnesInOneKilogram { get; }

        [Test]
        public void KilogramToMassUnits()
        {
            Mass kilogram = Mass.FromKilograms(1);
            Assert.AreEqual(CentigramsInOneKilogram, kilogram.Centigrams, Delta);
            Assert.AreEqual(DecagramsInOneKilogram, kilogram.Decagrams, Delta);
            Assert.AreEqual(DecigramsInOneKilogram, kilogram.Decigrams, Delta);
            Assert.AreEqual(GramsInOneKilogram, kilogram.Grams, Delta);
            Assert.AreEqual(HectogramsInOneKilogram, kilogram.Hectograms, Delta);
            Assert.AreEqual(KilogramsInOneKilogram, kilogram.Kilograms, Delta);
            Assert.AreEqual(KilotonnesInOneKilogram, kilogram.Kilotonnes, Delta);
            Assert.AreEqual(LongTonsInOneKilogram, kilogram.LongTons, Delta);
            Assert.AreEqual(MegatonnesInOneKilogram, kilogram.Megatonnes, Delta);
            Assert.AreEqual(MicrogramsInOneKilogram, kilogram.Micrograms, Delta);
            Assert.AreEqual(MilligramsInOneKilogram, kilogram.Milligrams, Delta);
            Assert.AreEqual(NanogramsInOneKilogram, kilogram.Nanograms, Delta);
            Assert.AreEqual(ShortTonsInOneKilogram, kilogram.ShortTons, Delta);
            Assert.AreEqual(TonnesInOneKilogram, kilogram.Tonnes, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Mass kilogram = Mass.FromKilograms(1); 
            Assert.AreEqual(1, Mass.FromCentigrams(kilogram.Centigrams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromDecagrams(kilogram.Decagrams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromDecigrams(kilogram.Decigrams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromGrams(kilogram.Grams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromHectograms(kilogram.Hectograms).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromKilograms(kilogram.Kilograms).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromKilotonnes(kilogram.Kilotonnes).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromLongTons(kilogram.LongTons).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromMegatonnes(kilogram.Megatonnes).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromMicrograms(kilogram.Micrograms).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromMilligrams(kilogram.Milligrams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromNanograms(kilogram.Nanograms).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromShortTons(kilogram.ShortTons).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromTonnes(kilogram.Tonnes).Kilograms, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Mass v = Mass.FromKilograms(1);
            Assert.AreEqual(-1, -v.Kilograms, Delta);
            Assert.AreEqual(2, (Mass.FromKilograms(3)-v).Kilograms, Delta);
            Assert.AreEqual(2, (v + v).Kilograms, Delta);
            Assert.AreEqual(10, (v*10).Kilograms, Delta);
            Assert.AreEqual(10, (10*v).Kilograms, Delta);
            Assert.AreEqual(2, (Mass.FromKilograms(10)/5).Kilograms, Delta);
            Assert.AreEqual(2, Mass.FromKilograms(10)/Mass.FromKilograms(5), Delta);
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
