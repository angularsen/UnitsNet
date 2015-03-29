using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    [TestFixture]
    public class StonePoundsTests
    {
        private const double StoneInOneKilogram = 0.1574731728702698;
        private const double PoundsInOneKilogram = 2.2046226218487757d;
        private const double StoneTolerance = 1e-5;
        private const double PoundsTolerance = 1e-5;

        [Test]
        public void StonePoundsRoundTrip()
        {
            Mass m = Mass.FromStonePounds(2, 3);
            StonePounds stonePounds = m.StonePounds;
            Assert.AreEqual(2, stonePounds.Stone, StoneTolerance);
            Assert.AreEqual(3, stonePounds.Pounds, PoundsTolerance);
        }

        [Test]
        public void StonePoundsFrom()
        {
            Mass m = Mass.FromStonePounds(2, 3);
            double expectedKg = (2 / StoneInOneKilogram) + (3 / PoundsInOneKilogram);
            Assert.AreEqual(expectedKg, m.Kilograms, StoneTolerance);
        }
    }
}
