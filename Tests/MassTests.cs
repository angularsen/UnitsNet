// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class MassTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void KilogramToMassUnits()
        { 
            Mass oneKg = Mass.FromKilograms(1);

            Assert.AreEqual(1E-9, oneKg.Megatonnes, Delta);
            Assert.AreEqual(1E-6, oneKg.Kilotonnes, Delta);
            Assert.AreEqual(1E-3, oneKg.Tonnes, Delta);
            Assert.AreEqual(1, oneKg.Kilograms, Delta);
            Assert.AreEqual(1E1, oneKg.Hectograms, Delta);
            Assert.AreEqual(1E2, oneKg.Decagrams, Delta);
            Assert.AreEqual(1E3, oneKg.Grams, Delta);
            Assert.AreEqual(1E4, oneKg.Decigrams, Delta);
            Assert.AreEqual(1E5, oneKg.Centigrams, Delta);
            Assert.AreEqual(1E6, oneKg.Milligrams, Delta);

            Assert.AreEqual(0.00110231, oneKg.ShortTons, Delta);
            Assert.AreEqual(0.000984207, oneKg.LongTons, Delta);
        }

        [Test]
        public void MassUnitsRoundTrip()
        {
            Mass oneKg = Mass.FromKilograms(1);
            Assert.AreEqual(1, Mass.FromMegatonnes(oneKg.Megatonnes).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromKilotonnes(oneKg.Kilotonnes).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromTonnes(oneKg.Tonnes).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromKilograms(oneKg.Kilograms).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromHectograms(oneKg.Hectograms).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromDecagrams(oneKg.Decagrams).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromGrams(oneKg.Grams).Kilograms, Delta); 
            Assert.AreEqual(1, Mass.FromDecigrams(oneKg.Decigrams).Kilograms, Delta); 
            Assert.AreEqual(1, Mass.FromCentigrams(oneKg.Centigrams).Kilograms, Delta); 
            Assert.AreEqual(1, Mass.FromMilligrams(oneKg.Milligrams).Kilograms, Delta);
            
            Assert.AreEqual(1, Mass.FromShortTons(oneKg.ShortTons).Kilograms, Delta);
            Assert.AreEqual(1, Mass.FromLongTons(oneKg.LongTons).Kilograms, Delta);
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
            Mass oneMeter = Mass.FromKilograms(1);
            Mass twoMeters = Mass.FromKilograms(2);

            Assert.True(oneMeter < twoMeters);
            Assert.True(oneMeter <= twoMeters);
            Assert.True(twoMeters > oneMeter);
            Assert.True(twoMeters >= oneMeter);

            Assert.False(oneMeter > twoMeters);
            Assert.False(oneMeter >= twoMeters);
            Assert.False(twoMeters < oneMeter);
            Assert.False(twoMeters <= oneMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Mass meter = Mass.FromKilograms(1);
            Assert.AreEqual(0, meter.CompareTo(meter));
            Assert.Greater(meter.CompareTo(Mass.Zero), 0);
            Assert.Less(Mass.Zero.CompareTo(meter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Mass meter = Mass.FromKilograms(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Mass meter = Mass.FromKilograms(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(null);
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
            Mass meter = Mass.FromKilograms(1);
            Assert.IsFalse(meter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Mass meter = Mass.FromKilograms(1);
            Assert.IsFalse(meter.Equals(null));
        }
    }
}