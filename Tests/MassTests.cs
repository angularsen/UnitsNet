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

            Assert.AreEqual(1E-9, oneKg.Megatonnes);
            Assert.AreEqual(1E-6, oneKg.Kilotonnes);
            Assert.AreEqual(1E-3, oneKg.Tonnes);
            Assert.AreEqual(1, oneKg.Kilograms);
            Assert.AreEqual(1E1, oneKg.Hectograms);
            Assert.AreEqual(1E2, oneKg.Decagrams);
            Assert.AreEqual(1E3, oneKg.Grams);
            Assert.AreEqual(1E4, oneKg.Decigrams);
            Assert.AreEqual(1E5, oneKg.Centigrams);
            Assert.AreEqual(1E6, oneKg.Milligrams);

            Assert.AreEqual(0.00110231, oneKg.ShortTons, Delta);
            Assert.AreEqual(0.000984207, oneKg.LongTons, Delta);
        }

        [Test]
        public void MassUnitsRoundTrip()
        {
            Mass oneKg = Mass.FromKilograms(1);
            Assert.AreEqual(1, Mass.FromMegatonnes(oneKg.Megatonnes).Kilograms);
            Assert.AreEqual(1, Mass.FromKilotonnes(oneKg.Kilotonnes).Kilograms);
            Assert.AreEqual(1, Mass.FromTonnes(oneKg.Tonnes).Kilograms);
            Assert.AreEqual(1, Mass.FromKilograms(oneKg.Kilograms).Kilograms);
            Assert.AreEqual(1, Mass.FromHectograms(oneKg.Hectograms).Kilograms);
            Assert.AreEqual(1, Mass.FromDecagrams(oneKg.Decagrams).Kilograms);
            Assert.AreEqual(1, Mass.FromGrams(oneKg.Grams).Kilograms); 
            Assert.AreEqual(1, Mass.FromDecigrams(oneKg.Decigrams).Kilograms); 
            Assert.AreEqual(1, Mass.FromCentigrams(oneKg.Centigrams).Kilograms); 
            Assert.AreEqual(1, Mass.FromMilligrams(oneKg.Milligrams).Kilograms);
            
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
            Assert.AreEqual(2, (Mass.FromKilograms(2)*v).Kilograms, Delta);
            Assert.AreEqual(2, (Mass.FromKilograms(10)/5).Kilograms, Delta);
            Assert.AreEqual(2, (Mass.FromKilograms(10)/Mass.FromKilograms(5)).Kilograms, Delta);
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
            meter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Mass meter = Mass.FromKilograms(1);
            meter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Mass a = Mass.FromKilograms(1);
            Mass b = Mass.FromKilograms(2);

            Assert.True(a == a); 
            Assert.True(a != b);

            Assert.False(a == b);
            Assert.False(a != a);
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