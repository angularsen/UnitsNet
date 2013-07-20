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
        public void ConvertingBetweenMassUnits()
        {
            var mass = SiMass.FromKilograms(1);
            Assert.AreEqual(1, mass.Kilograms);
            Assert.AreEqual(10, mass.Hectograms);
            Assert.AreEqual(100, mass.Centigrams);
            Assert.AreEqual(1000, mass.Milligrams);

        }
    }
}
