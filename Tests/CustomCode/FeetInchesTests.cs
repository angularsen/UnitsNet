using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    [TestFixture]
    public class FeetInchesTests : LengthTests
    {
        [Test]
        public void FeetInchesRoundTrip()
        {
            Length meter = Length.FromFeetInches(3, 7);
            FeetInches feetInches = meter.FeetInches;
            Assert.AreEqual(3, feetInches.Feet, FeetTolerance);
            Assert.AreEqual(7, feetInches.Inches, InchesTolerance);
        }

        [Test]
        public void FeetInchesFrom()
        {
            Length meter = Length.FromFeetInches(3, 7);
            double expectedMeters = (3 / FeetInOneMeter) + (7 / InchesInOneMeter);
            Assert.AreEqual(expectedMeters, meter.Meters, FeetTolerance);
        }
    }
}
