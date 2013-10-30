using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class UnitConverterTests
    {
        private const double Delta = 1E-5;

        // TODO Test Force, Length2d, Mass, Pressure units.

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
        public void CubicMeterToVolumeUnits()
        {
            Assert.AreEqual(1E-9, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicKilometer), Delta);
            Assert.AreEqual(1E0, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicMeter), Delta);
            Assert.AreEqual(1E3, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicDecimeter), Delta);
            Assert.AreEqual(1E6, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicCentimeter), Delta);
            Assert.AreEqual(1E9, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicMillimeter), Delta);

            Assert.AreEqual(1E1, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Hectoliter), Delta);
            Assert.AreEqual(1E3, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Liter), Delta);
            Assert.AreEqual(1E4, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Deciliter), Delta);
            Assert.AreEqual(1E5, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Centiliter), Delta);
            Assert.AreEqual(1E6, UnitConverter.Convert(1, Unit.CubicMeter, Unit.Milliliter), Delta);
 
            Assert.AreEqual(3.86102*1E-7, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicMile), Delta);
            Assert.AreEqual(1.30795062, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicYard), Delta);
            Assert.AreEqual(35.31472, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicFoot), Delta);
            Assert.AreEqual(61023.98242, UnitConverter.Convert(1, Unit.CubicMeter, Unit.CubicInch), Delta);

            Assert.AreEqual(264.17217, UnitConverter.Convert(1, Unit.CubicMeter, Unit.UsGallon), Delta);
            Assert.AreEqual(33814.02270, UnitConverter.Convert(1, Unit.CubicMeter, Unit.UsOunce), Delta);
            Assert.AreEqual(219.96924, UnitConverter.Convert(1, Unit.CubicMeter, Unit.ImperialGallon), Delta);
            Assert.AreEqual(35195.07972, UnitConverter.Convert(1, Unit.CubicMeter, Unit.ImperialOunce), Delta);
        }

        [Test]
        public void SquareMeterToAreaUnits()
        {
            Assert.AreEqual(1E-6, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareKilometer), Delta);
            Assert.AreEqual(1E0, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareMeter), Delta);
            Assert.AreEqual(1E2, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareDecimeter), Delta);
            Assert.AreEqual(1E4, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareCentimeter), Delta);
            Assert.AreEqual(1E6, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareMillimeter), Delta);

            Assert.AreEqual(3.86102*1E-7, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareMile), Delta);
            Assert.AreEqual(1.19599, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareYard), Delta);
            Assert.AreEqual(10.76391, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareFoot), Delta);
            Assert.AreEqual(1550.003100, UnitConverter.Convert(1, Unit.SquareMeter, Unit.SquareInch), Delta);
        }

        [Test]
        public void ThrowsOnIncompatibleUnits()
        {
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.Meter, Unit.Second));
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.Pascal, Unit.Second));
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.Kilogram, Unit.Second));
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.CubicMeter, Unit.Second));
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.Degree, Unit.Second));
        }

        [Test]
        public void TryConvertReturnsFalseOnIncompatibleUnits()
        {
            double newValue;

            // Assert from-unit cases. One for each class of unit.
            Assert.False(UnitConverter.TryConvert(1, Unit.Meter, Unit.Second, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Pascal, Unit.Second, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Kilogram, Unit.Second, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.CubicMeter, Unit.Second, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Degree, Unit.Second, out newValue));

            // Assert to-unit cases. One for each class of unit.
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.Meter, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.Pascal, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.Kilogram, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.Degree, out newValue));
        }
    }
}
