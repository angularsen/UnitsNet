using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class Distance2dTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void MetersToDistanceUnits()
        {
            SiDistance2d meter = SiDistance2d.FromMeters(1,1);

            Assert.AreEqual(new Vector2(1), meter.Meters);
            Assert.AreEqual(new Vector2(1E2), meter.Centimeters);
            Assert.AreEqual(new Vector2(1E3), meter.Millimeters);
            Assert.AreEqual(new Vector2(1E-3), meter.Kilometers);
            Assert.AreEqual(new Vector2(1), meter.Meters);
            Assert.AreEqual(new Vector2(1E1), meter.Decimeters);
            Assert.AreEqual(new Vector2(1E2), meter.Centimeters);
            Assert.AreEqual(new Vector2(1E3), meter.Millimeters);
            Assert.AreEqual(new Vector2(1E6), meter.Micrometers);
            Assert.AreEqual(new Vector2(1E9), meter.Nanometers);

            Assert.AreEqual(0.000621371, meter.Miles.X, Delta);
            Assert.AreEqual(0.000621371, meter.Miles.Y, Delta);
            Assert.AreEqual(1.09361, meter.Yards.X, Delta);
            Assert.AreEqual(1.09361, meter.Yards.Y, Delta);
            Assert.AreEqual(3.28084, meter.Feet.X, Delta);
            Assert.AreEqual(3.28084, meter.Feet.Y, Delta);
            Assert.AreEqual(39.3701, meter.Inches.X, Delta);
            Assert.AreEqual(39.3701, meter.Inches.Y, Delta);
        }

        [Test]
        public void DistanceUnitsRoundTrip()
        {
            SiDistance meter = SiDistance.FromMeters(1);

            Assert.AreEqual(1, SiDistance.FromKilometers(meter.Kilometers).Meters, Delta);
            Assert.AreEqual(1, SiDistance.FromMeters(meter.Meters).Meters, Delta);
            Assert.AreEqual(1, SiDistance.FromDecimeters(meter.Decimeters).Meters, Delta);
            Assert.AreEqual(1, SiDistance.FromCentimeters(meter.Centimeters).Meters, Delta);
            Assert.AreEqual(1, SiDistance.FromMillimeters(meter.Millimeters).Meters, Delta);
            Assert.AreEqual(1, SiDistance.FromMicrometers(meter.Micrometers).Meters, Delta);
            Assert.AreEqual(1, SiDistance.FromNanometers(meter.Nanometers).Meters, Delta);
        }
        [Test]
        public void VectorLength()
        {
            var v = new SiDistance2d(3, 4);
            Assert.AreEqual(5, v.Distance.Meters);
        }
    }
}