// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
// ReSharper disable once InconsistentNaming
    public class Length2dTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void MetersToDistanceUnits()
        {
            Length2d meter = Length2d.FromMeters(1,1);

            AssertAreEqual(new Vector2(1), meter.Meters, Delta);
            AssertAreEqual(new Vector2(1E2), meter.Centimeters, Delta);
            AssertAreEqual(new Vector2(1E3), meter.Millimeters, Delta);
            AssertAreEqual(new Vector2(1E-3), meter.Kilometers, Delta);
            AssertAreEqual(new Vector2(1), meter.Meters, Delta);
            AssertAreEqual(new Vector2(1E1), meter.Decimeters, Delta);
            AssertAreEqual(new Vector2(1E2), meter.Centimeters, Delta);
            AssertAreEqual(new Vector2(1E3), meter.Millimeters, Delta);
            AssertAreEqual(new Vector2(1E6), meter.Micrometers, Delta); 
            AssertAreEqual(new Vector2(1E9), meter.Nanometers, Delta);

            Assert.AreEqual(0.000621371, meter.Miles.X, Delta);
            Assert.AreEqual(0.000621371, meter.Miles.Y, Delta);
            Assert.AreEqual(1.09361, meter.Yards.X, Delta);
            Assert.AreEqual(1.09361, meter.Yards.Y, Delta);
            Assert.AreEqual(3.28084, meter.Feet.X, Delta);
            Assert.AreEqual(3.28084, meter.Feet.Y, Delta);
            Assert.AreEqual(39.37007874, meter.Inches.X, Delta);
            Assert.AreEqual(39.37007874, meter.Inches.Y, Delta);
        }

        private void AssertAreEqual(Vector2 expected, Vector2 actual, double delta)
        { 
            Assert.AreEqual(expected.X, actual.X, Delta);
            Assert.AreEqual(expected.Y, actual.Y, Delta);
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
        }

        [Test]
        public void VectorLength()
        {
            var v = new Length2d(3, 4);
            Assert.AreEqual(5, v.Length.Meters);
        }


        [Test]
        public void ArithmeticOperators()
        {
            Length2d v = Length2d.FromMeters(1, 2);
            Assert.AreEqual(-1, -v.Meters.X, Delta);
            Assert.AreEqual(-2, -v.Meters.Y, Delta);
            Assert.AreEqual(2, (Length2d.FromMeters(3, 3)-v).Meters.X, Delta);
            Assert.AreEqual(1, (Length2d.FromMeters(3, 3)-v).Meters.Y, Delta);
            Assert.AreEqual(2, (v + v).Meters.X, Delta);
            Assert.AreEqual(4, (v + v).Meters.Y, Delta);
            Assert.AreEqual(10, (v*10).Meters.X, Delta);
            Assert.AreEqual(20, (v*10).Meters.Y, Delta);
            Assert.AreEqual(10, (10*v).Meters.X, Delta);
            Assert.AreEqual(20, (10*v).Meters.Y, Delta);
            Assert.AreEqual(2, (Length2d.FromMeters(2, 2)*v).Meters.X, Delta);
            Assert.AreEqual(4, (Length2d.FromMeters(2, 2)*v).Meters.Y, Delta);
            Assert.AreEqual(2, (Length2d.FromMeters(10, 20)/5).Meters.X, Delta);
            Assert.AreEqual(4, (Length2d.FromMeters(10, 20)/5).Meters.Y, Delta);
            Assert.AreEqual(2, (Length2d.FromMeters(10, 20)/Length2d.FromMeters(5, 5)).X, Delta);
            Assert.AreEqual(4, (Length2d.FromMeters(10, 20)/Length2d.FromMeters(5, 5)).Y, Delta);
        }

        [Test]
        public void EqualityOperators()
        {
            Length2d a = Length2d.FromMeters(1, 2);
            Length2d b = Length2d.FromMeters(2, 1);

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
            Length2d v = Length2d.FromMeters(1, 2);
            Assert.IsTrue(v.Equals(Length2d.FromMeters(1, 2)));
            Assert.IsFalse(v.Equals(Length2d.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Length2d newton = Length2d.FromMeters(1, 2);
            Assert.IsFalse(newton.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Length2d newton = Length2d.FromMeters(1, 2);
            Assert.IsFalse(newton.Equals(null));
        }
    }
}