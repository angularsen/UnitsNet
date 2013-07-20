using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class MassTests
    { 
        [Test]
        public void KilogramToMassUnits()
        { 
            SiMass oneKg = SiMass.FromKilograms(1);

            Assert.AreEqual(1, oneKg.Kilograms);
            Assert.AreEqual(1E1, oneKg.Hectograms);
            Assert.AreEqual(1E2, oneKg.Decigrams);
            Assert.AreEqual(1E3, oneKg.Grams);
        }

        [Test]
        public void MassUnitsRoundTrip()
        {
            SiMass oneKg = SiMass.FromKilograms(1);
            Assert.AreEqual(1, SiMass.FromKilograms(oneKg.Kilograms).Kilograms);
            Assert.AreEqual(1, SiMass.FromHectograms(oneKg.Hectograms).Kilograms);
            Assert.AreEqual(1, SiMass.FromDecigrams(oneKg.Decigrams).Kilograms);
            Assert.AreEqual(1, SiMass.FromGrams(oneKg.Grams).Kilograms); 
        }
    }
}