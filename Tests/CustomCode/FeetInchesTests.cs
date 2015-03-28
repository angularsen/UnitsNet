using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    [TestFixture]
    public class FeetInchesTests : LengthTests
    {
        [Test]
        public void FeeInchesRoundTrip()
        {
            Length meter = Length.FromFeetInches(3, 7);
            Length.FeetInchesCombo feetInches = meter.FeetInches;
            Assert.AreEqual(3, feetInches.Feet, FeetTolerance);
            Assert.AreEqual(7, feetInches.Inches, InchesTolerance);
        }

        [Test]
        public void FeeInchesFrom()
        {
            Length meter = Length.FromFeetInches(3, 7);
            double expectedMeters = (3 / FeetInOneMeter) + (7 / InchesInOneMeter);
            Assert.AreEqual(expectedMeters, meter.Meters, FeetTolerance);
        }
    }
}
