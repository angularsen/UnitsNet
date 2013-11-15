// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class AreaTests
    {
        private const double Delta = 1E-5;
        private readonly Area _squareMeter = Area.FromSquareMeters(1);

        [Test]
        public void SquareMetersToAreaUnits()
        {
            Assert.AreEqual(1E-6, _squareMeter.SquareKilometers, Delta);
            Assert.AreEqual(1, _squareMeter.SquareMeters, Delta);
            Assert.AreEqual(1E2, _squareMeter.SquareDecimeters, Delta);
            Assert.AreEqual(1E4, _squareMeter.SquareCentimeters, Delta);
            Assert.AreEqual(1E6, _squareMeter.SquareMillimeters, Delta);

            Assert.AreEqual(3.86102*1E-7, _squareMeter.SquareMiles, Delta);
            Assert.AreEqual(1.19599, _squareMeter.SquareYards, Delta);
            Assert.AreEqual(10.76391, _squareMeter.SquareFeet, Delta);
            Assert.AreEqual(1550.003100, _squareMeter.SquareInches, Delta);
        }

        [Test]
        public void AreaUnitsRoundTrip()
        {
            Assert.AreEqual(1, Area.FromSquareKilometers(_squareMeter.SquareKilometers).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareMeters(_squareMeter.SquareMeters).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareDecimeters(_squareMeter.SquareDecimeters).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareCentimeters(_squareMeter.SquareCentimeters).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareMillimeters(_squareMeter.SquareMillimeters).SquareMeters, Delta);

            Assert.AreEqual(1, Area.FromSquareMiles(_squareMeter.SquareMiles).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareYards(_squareMeter.SquareYards).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareFeet(_squareMeter.SquareFeet).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareInches(_squareMeter.SquareInches).SquareMeters, Delta);
        }

        [Test]
        public void ArithmeticOperatorsRoundtrip()
        {
            Area v = Area.FromSquareCentimeters(1);
            Assert.AreEqual(-1, -v.SquareCentimeters, Delta);
            Assert.AreEqual(2, (Area.FromSquareCentimeters(3)-v).SquareCentimeters, Delta);
            Assert.AreEqual(2, (v + v).SquareCentimeters, Delta);
            Assert.AreEqual(10, (v*10).SquareCentimeters, Delta);
            Assert.AreEqual(10, (10*v).SquareCentimeters, Delta);
            Assert.AreEqual(2, (Area.FromSquareCentimeters(10)/5).SquareCentimeters, Delta);
            Assert.AreEqual(2, Area.FromSquareCentimeters(10)/Area.FromSquareCentimeters(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Area oneSquareMeter = Area.FromSquareMeters(1);
            Area twoSquareMeters = Area.FromSquareMeters(2);

            Assert.True(oneSquareMeter < twoSquareMeters);
            Assert.True(oneSquareMeter <= twoSquareMeters);
            Assert.True(twoSquareMeters > oneSquareMeter);
            Assert.True(twoSquareMeters >= oneSquareMeter);

            Assert.False(oneSquareMeter > twoSquareMeters);
            Assert.False(oneSquareMeter >= twoSquareMeters);
            Assert.False(twoSquareMeters < oneSquareMeter);
            Assert.False(twoSquareMeters <= oneSquareMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Area meter = Area.FromSquareMeters(1);
            Assert.AreEqual(0, meter.CompareTo(meter));
            Assert.Greater(meter.CompareTo(Area.Zero), 0);
            Assert.Less(Area.Zero.CompareTo(meter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Area meter = Area.FromSquareMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Area meter = Area.FromSquareMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Area a = Area.FromSquareMeters(1);
            Area b = Area.FromSquareMeters(2);

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
            Area v = Area.FromSquareMeters(1);
            Assert.IsTrue(v.Equals(Area.FromSquareMeters(1)));
            Assert.IsFalse(v.Equals(Area.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Area meter = Area.FromSquareMeters(1);
            Assert.IsFalse(meter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Area meter = Area.FromSquareMeters(1);
            Assert.IsFalse(meter.Equals(null));
        }
    }
}