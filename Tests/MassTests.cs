using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class MassTests
    { 
        [Test]
        public void KilogramToMassUnits()
        { 
            Mass oneKg = Mass.FromKilograms(1);

            Assert.AreEqual(1E-9, oneKg.Megatonnes);
            Assert.AreEqual(1E-6, oneKg.Kilotonnes);
            Assert.AreEqual(1E-3, oneKg.Tonnes);
            Assert.AreEqual(1, oneKg.Kilograms);
            Assert.AreEqual(1E1, oneKg.Hectograms);
            Assert.AreEqual(1E2, oneKg.Decagrams);
            Assert.AreEqual(1E3, oneKg.Grams);
            Assert.AreEqual(1E4, oneKg.Decigrams);
            Assert.AreEqual(1E5, oneKg.Centigrams);
            Assert.AreEqual(1E6, oneKg.Milligrams);
        }

        [Test]
        public void MassUnitsRoundTrip()
        {
            Mass oneKg = Mass.FromKilograms(1);
            Assert.AreEqual(1, Mass.FromMegatonnes(oneKg.Megatonnes).Kilograms);
            Assert.AreEqual(1, Mass.FromKilotonnes(oneKg.Kilotonnes).Kilograms);
            Assert.AreEqual(1, Mass.FromTonnes(oneKg.Tonnes).Kilograms);
            Assert.AreEqual(1, Mass.FromKilograms(oneKg.Kilograms).Kilograms);
            Assert.AreEqual(1, Mass.FromHectograms(oneKg.Hectograms).Kilograms);
            Assert.AreEqual(1, Mass.FromDecagrams(oneKg.Decagrams).Kilograms);
            Assert.AreEqual(1, Mass.FromGrams(oneKg.Grams).Kilograms); 
            Assert.AreEqual(1, Mass.FromDecigrams(oneKg.Decigrams).Kilograms); 
            Assert.AreEqual(1, Mass.FromCentigrams(oneKg.Centigrams).Kilograms); 
            Assert.AreEqual(1, Mass.FromMilligrams(oneKg.Milligrams).Kilograms); 
        }
    }
}