using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class UnitConverterTests
    {
        private const double Delta = 1E-5;

        // TODO Test Force, Length2d, Mass, Pressure and Volume units.

        [Test]
        public void MeterToLengthUnits()
        {
            Assert.AreEqual(1E-3, UnitConverter.Convert(1, Unit.Meter, Unit.Kilometer));
            Assert.AreEqual(1, UnitConverter.Convert(1, Unit.Meter, Unit.Meter));
            Assert.AreEqual(1E1, UnitConverter.Convert(1, Unit.Meter, Unit.Decimeter));
            Assert.AreEqual(1E2, UnitConverter.Convert(1, Unit.Meter, Unit.Centimeter));
            Assert.AreEqual(1E3, UnitConverter.Convert(1, Unit.Meter, Unit.Millimeter));
            Assert.AreEqual(1E6, UnitConverter.Convert(1, Unit.Meter, Unit.Micrometer));
            Assert.AreEqual(1E9, UnitConverter.Convert(1, Unit.Meter, Unit.Nanometer));

            Assert.AreEqual(0.000621371, UnitConverter.Convert(1, Unit.Meter, Unit.Mile), Delta);
            Assert.AreEqual(1.09361, UnitConverter.Convert(1, Unit.Meter, Unit.Yard), Delta);
            Assert.AreEqual(3.28084, UnitConverter.Convert(1, Unit.Meter, Unit.Foot), Delta);
            Assert.AreEqual(39.3701, UnitConverter.Convert(1, Unit.Meter, Unit.Inch), Delta);
        }

        [Test]
        public void ThrowsOnIncompatibleUnits()
        {
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.Meter, Unit.Second));
        }

        [Test]
        public void TryConvertReturnsFalseOnIncompatibleUnits()
        {
            double newValue;
            Assert.False(UnitConverter.TryConvert(1, Unit.Meter, Unit.Second, out newValue));
        }
    }
}
