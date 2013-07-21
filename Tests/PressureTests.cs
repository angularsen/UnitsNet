using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class PressureTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void PascalToPressureUnits()
        { 
            Pressure pa = Pressure.FromPascals(1);

            // Source: http://en.wikipedia.org/wiki/Pressure
            Assert.AreEqual(9.8692*1E-6, pa.Atmosphere, Delta);
            Assert.AreEqual(1E-5, pa.Bars, Delta);
            Assert.AreEqual(1E-3, pa.KiloPascals);
            Assert.AreEqual(1E-4, pa.NewtonsPerSquareCentimeter, Delta);
            Assert.AreEqual(1, pa.NewtonsPerSquareMeter, Delta);
            Assert.AreEqual(1E-6, pa.NewtonsPerSquareMillimeter, Delta);
            Assert.AreEqual(1, pa.Pascals);
            Assert.AreEqual(1.450377*1E-4, pa.Psi, Delta);
            Assert.AreEqual(1.0197*1E-5, pa.TechnicalAtmosphere, Delta);
            Assert.AreEqual(7.5006*1E-3, pa.Torr, Delta);
        }

        [Test]
        public void PressureUnitsRoundTrip()
        {
            Pressure pa = Pressure.FromPascals(1);

            Assert.AreEqual(1, Pressure.FromAtmosphere(pa.Atmosphere).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromBars(pa.Bars).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromKiloPascals(pa.KiloPascals).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareCentimeter(pa.NewtonsPerSquareCentimeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareMeter(pa.NewtonsPerSquareMeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromNewtonsPerSquareMillimeter(pa.NewtonsPerSquareMillimeter).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromPascals(pa.Pascals).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromPsi(pa.Psi).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromTechnicalAtmosphere(pa.TechnicalAtmosphere).Pascals, Delta);
            Assert.AreEqual(1, Pressure.FromTorr(pa.Torr).Pascals, Delta);
        }
    }
}