using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class VolumeTests
    {
        private const double Delta = 1E-5;
        private Volume cubicMeter;
        private Volume liter;

        [SetUp]
        public void Setup()
        {
            cubicMeter = Volume.FromMeters(1);
            liter = Volume.FromLiters(1);
        }

        [Test]
        public void CubicMetersToVolumeUnits()
        {
            Assert.AreEqual(1E-9, cubicMeter.Kilometers);
            Assert.AreEqual(1, cubicMeter.Meters);
            Assert.AreEqual(1E3, cubicMeter.Decimeters);
            Assert.AreEqual(1E6, cubicMeter.Centimeters);
            Assert.AreEqual(1E9, cubicMeter.Milimeters);

            Assert.AreEqual(1E1, cubicMeter.Hectoliters);
            Assert.AreEqual(1E3, cubicMeter.Liters);
            Assert.AreEqual(1E4, cubicMeter.Deciliters);
            Assert.AreEqual(1E5, cubicMeter.Centiliters);
            Assert.AreEqual(1E6, cubicMeter.Mililiters);
        }

        [Test]
        public void VolumeUnitsRoundTrip()
        {
            Assert.AreEqual(1, Volume.FromKilometers(cubicMeter.Kilometers).Meters, Delta);
            Assert.AreEqual(1, Volume.FromMeters(cubicMeter.Meters).Meters, Delta);
            Assert.AreEqual(1, Volume.FromDecimeters(cubicMeter.Decimeters).Meters, Delta);
            Assert.AreEqual(1, Volume.FromCentimeters(cubicMeter.Centimeters).Meters, Delta);
            Assert.AreEqual(1, Volume.FromMilimeters(cubicMeter.Milimeters).Meters, Delta);

            Assert.AreEqual(1, Volume.FromHectoliters(cubicMeter.Hectoliters).Meters, Delta);
            Assert.AreEqual(1, Volume.FromLiters(cubicMeter.Liters).Meters, Delta);
            Assert.AreEqual(1, Volume.FromDeciliters(cubicMeter.Deciliters).Meters, Delta);
            Assert.AreEqual(1, Volume.FromCentiliters(cubicMeter.Centiliters).Meters, Delta);
            Assert.AreEqual(1, Volume.FromMililiters(cubicMeter.Mililiters).Meters, Delta);
        }

        [Test]
        public void ArithmeticOperatorsRoundtrip()
        {
            Assert.AreEqual(Volume.FromLiters(-1000).Meters, (-cubicMeter).Meters, Delta);
            Assert.AreEqual(Volume.FromLiters(1000 - 1).Meters, (cubicMeter - liter).Meters, Delta);
            Assert.AreEqual(Volume.FromLiters(1000 + 1).Meters, (cubicMeter + liter).Meters, Delta);
        }

        [Test]
        public void ComparableOperatorsRoundtrip()
        {
            Assert.IsTrue(liter < cubicMeter);
            Assert.IsFalse(cubicMeter < liter);

            Assert.IsTrue(liter <= cubicMeter);
            Assert.IsFalse(cubicMeter <= liter);
            Assert.IsTrue(liter <= Volume.FromLiters(1));

            Assert.IsTrue(cubicMeter > liter);
            Assert.IsFalse(liter > cubicMeter);

            Assert.IsTrue(cubicMeter >= liter);
            Assert.IsFalse(liter >= cubicMeter);
            Assert.IsTrue(liter >= Volume.FromLiters(1));
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Assert.AreEqual(0, cubicMeter.CompareTo(cubicMeter));
            Assert.IsTrue(cubicMeter.CompareTo(Volume.Zero) > 0);
            Assert.IsTrue(Volume.Zero.CompareTo(cubicMeter) < 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToCanHandleTypeMismatch()
        {
            cubicMeter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToCanHandleNullInstance()
        {
            cubicMeter.CompareTo((object)null);
        }

        [Test]
        public void EqualsIsImplemented()
        {
            Assert.IsTrue(cubicMeter.Equals(Volume.FromMeters(1)));
            Assert.IsTrue(cubicMeter.Equals(cubicMeter));
            Assert.IsFalse(cubicMeter.Equals(liter));
        }

        [Test]
        public void EqualsCanHandleTypeMismatch()
        {
            Assert.IsFalse(cubicMeter.Equals(new object()));
        }

        [Test]
        public void EqualsCanHandleNullInstance()
        {
            Assert.IsFalse(cubicMeter.Equals(null));
        }
    }
}