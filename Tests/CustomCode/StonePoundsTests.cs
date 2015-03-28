using NUnit.Framework;

namespace UnitsNet.Tests.CustomCode
{
    [TestFixture]
    public class StonePoundsTests : MassTests
    {
        [Test]
        public void StonePoundsRoundTrip()
        {
            Mass m = Mass.FromStonePounds(3, 7);
            Mass.StonePoundsCombo stonePounds = m.StonePounds;
            Assert.AreEqual(3, stonePounds.Stone, StoneTolerance);
            Assert.AreEqual(7, stonePounds.Pounds, PoundsTolerance);
        }

        [Test]
        public void StonePoundsFrom()
        {
            Mass m = Mass.FromStonePounds(3, 7);
            double expectedKg = (3 / StoneInOneKilogram) + (7 / PoundsInOneKilogram);
            Assert.AreEqual(expectedKg, m.Kilograms, StoneTolerance);
        }
    }
}
