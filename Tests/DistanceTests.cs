using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class DistanceTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void MetersToDistanceUnits()
        {
            SiDistance meter = SiDistance.FromMeters(1);

            Assert.AreEqual(1E-3, meter.Kilometers);
            Assert.AreEqual(1, meter.Meters);
            Assert.AreEqual(1.09361, meter.Yards, Delta);
            Assert.AreEqual(1E1, meter.Decimeters);
            Assert.AreEqual(1E2, meter.Centimeters);
            Assert.AreEqual(1E3, meter.Millimeters, Delta);
            Assert.AreEqual(1E6, meter.Micrometers, Delta);
            Assert.AreEqual(1E9, meter.Nanometers, Delta);
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
    }
}