using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class LengthTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void MetersToDistanceUnits()
        {
            Length meter = Length.FromMeters(1);

            Assert.AreEqual(1E-3, meter.Kilometers);
            Assert.AreEqual(1, meter.Meters);
            Assert.AreEqual(1E1, meter.Decimeters);
            Assert.AreEqual(1E2, meter.Centimeters);
            Assert.AreEqual(1E3, meter.Millimeters);
            Assert.AreEqual(1E6, meter.Micrometers);
            Assert.AreEqual(1E9, meter.Nanometers);

            Assert.AreEqual(0.000621371, meter.Miles, Delta);
            Assert.AreEqual(1.09361, meter.Yards, Delta);
            Assert.AreEqual(3.28084, meter.Feet, Delta);
            Assert.AreEqual(39.3701, meter.Inches, Delta);
            Assert.AreEqual(39370078.74015748, meter.Microinch, Delta);
            Assert.AreEqual(39370.07874015, meter.Mil, Delta);
        }

        [Test]
        public void DistanceUnitsRoundTrip()
        {
            Length meter = Length.FromMeters(1);

            Assert.AreEqual(1, Length.FromKilometers(meter.Kilometers).Meters, Delta);
            Assert.AreEqual(1, Length.FromMeters(meter.Meters).Meters, Delta);
            Assert.AreEqual(1, Length.FromDecimeters(meter.Decimeters).Meters, Delta);
            Assert.AreEqual(1, Length.FromCentimeters(meter.Centimeters).Meters, Delta);
            Assert.AreEqual(1, Length.FromMillimeters(meter.Millimeters).Meters, Delta);
            Assert.AreEqual(1, Length.FromMicrometers(meter.Micrometers).Meters, Delta);
            Assert.AreEqual(1, Length.FromNanometers(meter.Nanometers).Meters, Delta);

            Assert.AreEqual(1, Length.FromMiles(meter.Miles).Meters, Delta);
            Assert.AreEqual(1, Length.FromYards(meter.Yards).Meters, Delta);
            Assert.AreEqual(1, Length.FromFeet(meter.Feet).Meters, Delta);
            Assert.AreEqual(1, Length.FromInches(meter.Inches).Meters, Delta);
            Assert.AreEqual(1, Length.FromMicroinches(meter.Microinch).Meters, Delta);
            Assert.AreEqual(1, Length.FromMils(meter.Mil).Meters, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Length v = Length.FromMeters(1);
            Assert.AreEqual(-1, -v.Meters, Delta);
            Assert.AreEqual(2, (Length.FromMeters(3)-v).Meters, Delta);
            Assert.AreEqual(2, (v + v).Meters, Delta);
            Assert.AreEqual(10, (v*10).Meters, Delta);
            Assert.AreEqual(10, (10*v).Meters, Delta);
            Assert.AreEqual(2, (Length.FromMeters(10)/5).Meters, Delta);
            Assert.AreEqual(2, Length.FromMeters(10)/Length.FromMeters(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Length oneMeter = Length.FromMeters(1);
            Length twoMeters = Length.FromMeters(2);

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
            Length meter = Length.FromMeters(1);
            Assert.AreEqual(0, meter.CompareTo(meter));
            Assert.Greater(meter.CompareTo(Length.Zero), 0);
            Assert.Less(Length.Zero.CompareTo(meter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Length meter = Length.FromMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Length meter = Length.FromMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Length a = Length.FromMeters(1);
            Length b = Length.FromMeters(2);

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
            Length v = Length.FromMeters(1);
            Assert.IsTrue(v.Equals(Length.FromMeters(1)));
            Assert.IsFalse(v.Equals(Length.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Length meter = Length.FromMeters(1);
            Assert.IsFalse(meter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Length meter = Length.FromMeters(1);
            Assert.IsFalse(meter.Equals(null));
        }
    }
}