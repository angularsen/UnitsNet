using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class UnitConversionTests
    {
        [Test]
        public void KilogramEqualsKilogramForce()
        {
            var mass = SiMass.FromKilograms(10);
            var force = SiForce.FromKilograms(mass.Kilograms);
            Assert.AreEqual(mass.Kilograms, force.KilogramForce);
        }

        [Test]
        public void ConvertingFromKilogram()
        {
            var mass = SiMass.FromKilograms(1);
            Assert.AreEqual(1, mass.Kilograms);
            Assert.AreEqual(10, mass.Hectograms);
            Assert.AreEqual(100, mass.Decigrams);
            Assert.AreEqual(1000, mass.Grams); 
        }

        [Test]
        public void ConvertingToKilogram()
        {
            SiMass oneKg = SiMass.FromKilograms(1);
            Assert.AreEqual(1, SiMass.FromHectograms(oneKg.Hectograms).Kilograms);
            Assert.AreEqual(1, SiMass.FromDecigrams(oneKg.Decigrams).Kilograms);
            Assert.AreEqual(1, SiMass.FromGrams(oneKg.Grams).Kilograms); 
        }
    }
}
