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

            Assert.AreEqual(1E-9, oneKg.Megatonnes);
            Assert.AreEqual(1E-6, oneKg.Kilotonnes);
            Assert.AreEqual(1E-3, oneKg.Tonnes);
            Assert.AreEqual(1, oneKg.Kilograms);
            Assert.AreEqual(1E1, oneKg.Hectograms);
            Assert.AreEqual(1E2, oneKg.Decigrams);
            Assert.AreEqual(1E3, oneKg.Grams);
            Assert.AreEqual(1E5, oneKg.Centigrams);
            Assert.AreEqual(1E6, oneKg.Milligrams);
        }

        [Test]
        public void MassUnitsRoundTrip()
        {
            SiMass oneKg = SiMass.FromKilograms(1);
            Assert.AreEqual(1, SiMass.FromMegatonnes(oneKg.Megatonnes).Kilograms);
            Assert.AreEqual(1, SiMass.FromKilotonnes(oneKg.Kilotonnes).Kilograms);
            Assert.AreEqual(1, SiMass.FromTonnes(oneKg.Tonnes).Kilograms);
            Assert.AreEqual(1, SiMass.FromKilograms(oneKg.Kilograms).Kilograms);
            Assert.AreEqual(1, SiMass.FromHectograms(oneKg.Hectograms).Kilograms);
            Assert.AreEqual(1, SiMass.FromDecigrams(oneKg.Decigrams).Kilograms);
            Assert.AreEqual(1, SiMass.FromGrams(oneKg.Grams).Kilograms); 
            Assert.AreEqual(1, SiMass.FromCentigrams(oneKg.Centigrams).Kilograms); 
            Assert.AreEqual(1, SiMass.FromMilligrams(oneKg.Milligrams).Kilograms); 
        }
    }
}