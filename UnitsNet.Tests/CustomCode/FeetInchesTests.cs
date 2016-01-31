using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    [TestFixture]
    public class FeetInchesTests
    {
        private const double FeetInOneMeter = 3.28084;
        private const double InchesInOneMeter = 39.37007874;
        private const double FeetTolerance = 1e-5;
        private const double InchesTolerance = 1e-5;

        [Test]
        public void FeetInchesFrom()
        {
            Length meter = Length.FromFeetInches(2, 3);
            double expectedMeters = 2/FeetInOneMeter + 3/InchesInOneMeter;
            Assert.AreEqual(expectedMeters, meter.Meters, FeetTolerance);
        }

        [Test]
        public void FeetInchesRoundTrip()
        {
            Length meter = Length.FromFeetInches(2, 3);
            FeetInches feetInches = meter.FeetInches;
            Assert.AreEqual(2, feetInches.Feet, FeetTolerance);
            Assert.AreEqual(3, feetInches.Inches, InchesTolerance);
        }
    }
}