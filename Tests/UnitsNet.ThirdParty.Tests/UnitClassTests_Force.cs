using System.Globalization;
using System.Threading;
using NUnit.Framework;
using UnitsNet.Units;

namespace UnitsNet.ThirdParty.Tests
{
    // I don't know where to put these tests. They were intended to test UnitSystem via unit classes, 
    // but I won't bother testing all the unit classes since they are generated from the same template.
    [TestFixture]
    public class UnitClassTests_Force
    {
        private readonly CultureInfo _russian = CultureInfo.GetCultureInfo("ru-RU");
        private readonly CultureInfo _usEnglish = CultureInfo.GetCultureInfo("en-US");
        private readonly Force _newton = new Force(1);
        private readonly Force _kgf = Force.FromKilogramsForce(1);

        [Test]
        public void ToStringUsesCurrentUICulture()
        {
            Thread.CurrentThread.CurrentUICulture = _russian;
            Assert.AreEqual("1 Н", _newton.ToString());

            Thread.CurrentThread.CurrentUICulture = _usEnglish;
            Assert.AreEqual("1 N", _newton.ToString());
        }

        [Test]
        public void ToStringUsesSpecifiedUnit()
        {
            Assert.AreEqual("1 N", _newton.ToString(ForceUnit.Newton));
            Assert.AreEqual("1 kgf", _kgf.ToString(ForceUnit.KilogramForce));
        }

        [Test]
        public void ToStringWithUnitUsesSpecifiedCulture()
        {
            Thread.CurrentThread.CurrentUICulture = _usEnglish;
            Assert.AreEqual("1 kgf", _kgf.ToString(ForceUnit.KilogramForce));

            Thread.CurrentThread.CurrentUICulture = _russian;
            Assert.AreEqual("1 кгс", _kgf.ToString(ForceUnit.KilogramForce));
        }

        [Test]
        public void ToStringUsesSpecifiedCulture()
        {
            Assert.AreEqual("1 kgf", _kgf.ToString(ForceUnit.KilogramForce, _usEnglish));
            Assert.AreEqual("1 кгс", _kgf.ToString(ForceUnit.KilogramForce, _russian));
        }

        [Test]
        public void ToStringUsesSpecifiedFormat()
        {
            // Test both string format pattern and number formatting.
            // Russian uses comma as decimal separator, US English uses dot.
            Assert.AreEqual("kgf 1.00", _kgf.ToString(ForceUnit.KilogramForce, _usEnglish, "{1} {0:0.00}"));
            Assert.AreEqual("1,00 кгс", _kgf.ToString(ForceUnit.KilogramForce, _russian, "{0:0.00} {1}"));
        }

        [Test]
        public void ToStringUsesSpecifiedArgs()
        {
            Assert.AreEqual("kgf 1.00 extra",
                _kgf.ToString(ForceUnit.KilogramForce, _usEnglish, "{1} {0:0.00} {2}", "extra"));
        }

        [Test]
        public void GetAbbreviationUsesSpecifiedUnit()
        {
            Assert.AreEqual("N", Force.GetAbbreviation(ForceUnit.Newton, _usEnglish));
            Assert.AreEqual("kgf", Force.GetAbbreviation(ForceUnit.KilogramForce, _usEnglish));
        }

        [Test]
        public void GetAbbreviationUsesSpecifiedCulture()
        {
            Assert.AreEqual("kgf", Force.GetAbbreviation(ForceUnit.KilogramForce, _usEnglish));
            Assert.AreEqual("кгс", Force.GetAbbreviation(ForceUnit.KilogramForce, _russian));
        }
    }
}