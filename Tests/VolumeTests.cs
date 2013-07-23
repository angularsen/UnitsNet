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
        private Volume otherLiter;

        [SetUp]
        public void Setup()
        {
            cubicMeter = Volume.FromCubicMeters(1);
            liter = Volume.FromLiters(1);
            otherLiter = Volume.FromLiters(1);
        }

        [Test]
        public void CubicMetersToVolumeUnits()
        {
            Assert.AreEqual(1E-9, cubicMeter.CubicKilometers, Delta);
            Assert.AreEqual(1, cubicMeter.CubicMeters, Delta);
            Assert.AreEqual(1E3, cubicMeter.CubicDecimeters, Delta);
            Assert.AreEqual(1E6, cubicMeter.CubicCentimeters, Delta);
            Assert.AreEqual(1E9, cubicMeter.CubicMilimeters, Delta);

            Assert.AreEqual(1E1, cubicMeter.Hectoliters, Delta);
            Assert.AreEqual(1E3, cubicMeter.Liters, Delta);
            Assert.AreEqual(1E4, cubicMeter.Deciliters, Delta);
            Assert.AreEqual(1E5, cubicMeter.Centiliters, Delta);
            Assert.AreEqual(1E6, cubicMeter.Mililiters, Delta);
        }

        [Test]
        public void VolumeUnitsRoundTrip()
        {
            Assert.AreEqual(1, Volume.FromCubicKilometers(cubicMeter.CubicKilometers).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicMeters(cubicMeter.CubicMeters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicDecimeters(cubicMeter.CubicDecimeters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicCentimeters(cubicMeter.CubicCentimeters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicMilimeters(cubicMeter.CubicMilimeters).CubicMeters, Delta);

            Assert.AreEqual(1, Volume.FromHectoliters(cubicMeter.Hectoliters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromLiters(cubicMeter.Liters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromDeciliters(cubicMeter.Deciliters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCentiliters(cubicMeter.Centiliters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromMililiters(cubicMeter.Mililiters).CubicMeters, Delta);
        }

        [Test]
        public void ArithmeticOperatorsRoundtrip()
        {
            Assert.AreEqual(Volume.FromLiters(-1000).CubicMeters, (-cubicMeter).CubicMeters, Delta);
            Assert.AreEqual(Volume.FromLiters(1000 - 1).CubicMeters, (cubicMeter - liter).CubicMeters, Delta);
            Assert.AreEqual(Volume.FromLiters(1000 + 1).CubicMeters, (cubicMeter + liter).CubicMeters, Delta);
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

            Assert.IsTrue(liter == otherLiter);
            Assert.IsFalse(liter == cubicMeter);

            Assert.IsTrue(liter != cubicMeter);
            Assert.IsFalse(liter != otherLiter);
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
            Assert.IsTrue(cubicMeter.Equals(Volume.FromCubicMeters(1)));
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

        [Test]
        public void DynamicConversion()
        {
            Assert.AreEqual(1E-9, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicKilometer), Delta);
            Assert.AreEqual(1E0, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicMeter), Delta);
            Assert.AreEqual(1E3, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicDecimeter), Delta);
            Assert.AreEqual(1E6, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicCentimeter), Delta);
            Assert.AreEqual(1E9, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicMilimeter), Delta);
            Assert.AreEqual(1E1, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Hectoliter), Delta);
            Assert.AreEqual(1E3, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Liter), Delta);
            Assert.AreEqual(1E4, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Deciliter), Delta);
            Assert.AreEqual(1E5, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Centiliter), Delta);
            Assert.AreEqual(1E6, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Milliliter), Delta);
        }
    }
}