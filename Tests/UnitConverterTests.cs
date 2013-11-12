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
        public void DegreesToAngleUnits()
        {
            Assert.AreEqual(90, UnitConverter.Convert(90, Unit.Degree, Unit.Degree), Delta);
            Assert.AreEqual(Math.PI / 2, UnitConverter.Convert(90, Unit.Degree, Unit.Radian), Delta);
            Assert.AreEqual(100, UnitConverter.Convert(90, Unit.Degree, Unit.Gradian), Delta);
        }

        [Test]
        public void NewtonToForceUnits()
        { 
            Assert.AreEqual(1E-3, UnitConverter.Convert(1, Unit.Newton, Unit.Kilonewton), Delta);
            Assert.AreEqual(1, UnitConverter.Convert(1, Unit.Newton, Unit.Newton), Delta);
            Assert.AreEqual(1E5, UnitConverter.Convert(1, Unit.Newton, Unit.Dyn), Delta);
            Assert.AreEqual(0.10197, UnitConverter.Convert(1, Unit.Newton, Unit.KilogramForce), Delta);
            Assert.AreEqual(0.10197, UnitConverter.Convert(1, Unit.Newton, Unit.KiloPond), Delta);
            Assert.AreEqual(0.22481, UnitConverter.Convert(1, Unit.Newton, Unit.PoundForce), Delta);
            Assert.AreEqual(7.23301, UnitConverter.Convert(1, Unit.Newton, Unit.Poundal), Delta);
        }

        [Test]
        public void PascalToPressureUnits()
        { 
            // Source: http://en.wikipedia.org/wiki/Pressure
            Assert.AreEqual(9.8692*1E-6, UnitConverter.Convert(1, Unit.Pascal, Unit.Atmosphere), Delta);
            Assert.AreEqual(1E-5, UnitConverter.Convert(1, Unit.Pascal, Unit.Bar), Delta);
            Assert.AreEqual(1E-3, UnitConverter.Convert(1, Unit.Pascal, Unit.KiloPascal), Delta);
            Assert.AreEqual(1E-4, UnitConverter.Convert(1, Unit.Pascal, Unit.NewtonPerSquareCentimeter), Delta);
            Assert.AreEqual(1E-6, UnitConverter.Convert(1, Unit.Pascal, Unit.NewtonPerSquareMillimeter), Delta);
            Assert.AreEqual(1, UnitConverter.Convert(1, Unit.Pascal, Unit.NewtonPerSquareMeter), Delta);
            Assert.AreEqual(1, UnitConverter.Convert(1, Unit.Pascal, Unit.Pascal), Delta);
            Assert.AreEqual(1.450377*1E-4, UnitConverter.Convert(1, Unit.Pascal, Unit.Psi), Delta);
            Assert.AreEqual(1.0197*1E-5, UnitConverter.Convert(1, Unit.Pascal, Unit.TechnicalAtmosphere), Delta);
            Assert.AreEqual(7.5006*1E-3, UnitConverter.Convert(1, Unit.Pascal, Unit.Torr), Delta);
			Assert.AreEqual(1E-6, UnitConverter.Convert(1, Unit.Pascal, Unit.MegaPascal), Delta);
	        Assert.AreEqual(1/98066.5, UnitConverter.Convert(1, Unit.Pascal, Unit.KilogramForcePerSquareCentimeter), Delta);
        }

		[Test]
		public void CubicMeterPerSecondToFlowUnits()
		{
			Assert.AreEqual(1, UnitConverter.Convert(1, Unit.CubicMeterPerSecond, Unit.CubicMeterPerSecond), Delta);
			Assert.AreEqual(1/3600.0, UnitConverter.Convert(1, Unit.CubicMeterPerSecond, Unit.CubicMeterPerHour), Delta);
		}

        [Test]
        public void ThrowsOnIncompatibleUnits()
        {
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.Meter, Unit.Second));
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.SquareMeter, Unit.Second));
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.CubicMeter, Unit.Second));
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.Newton, Unit.Second));
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.Pascal, Unit.Second));
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.Kilogram, Unit.Second));
            Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.Degree, Unit.Second));
			Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.CubicMeterPerSecond, Unit.Second));
			Assert.Throws<Exception>(() => UnitConverter.Convert(1, Unit.RevolutionsPerSecond, Unit.Second));
        }

        [Test]
        public void TryConvertReturnsFalseOnIncompatibleUnits()
        {
            double newValue;

            // Assert from-unit cases. One for each class of unit.
            Assert.False(UnitConverter.TryConvert(1, Unit.Meter, Unit.Second, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.SquareMeter, Unit.Second, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.CubicMeter, Unit.Second, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Newton, Unit.Second, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Pascal, Unit.Second, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Kilogram, Unit.Second, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Degree, Unit.Second, out newValue));
			Assert.False(UnitConverter.TryConvert(1, Unit.CubicMeterPerSecond, Unit.Second, out newValue));
			Assert.False(UnitConverter.TryConvert(1, Unit.RevolutionsPerSecond, Unit.Second, out newValue));

            // Assert to-unit cases. One for each class of unit.
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.Meter, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.SquareMeter, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.CubicMeter, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.Newton, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.Pascal, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.Kilogram, out newValue));
            Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.Degree, out newValue));
			Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.CubicMeterPerSecond, out newValue));
			Assert.False(UnitConverter.TryConvert(1, Unit.Second, Unit.RevolutionsPerSecond, out newValue));
        }

        [Test]
        public void TryConvertReturnsTrueOnCompatibleUnits()
        {
            double newValue;

            // Assert from-unit cases. One for each class of unit.
            Assert.True(UnitConverter.TryConvert(1, Unit.Meter, Unit.Centimeter, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.SquareMeter, Unit.SquareCentimeter, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.CubicMeter, Unit.Liter, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.Newton, Unit.KilogramForce, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.Pascal, Unit.KiloPascal, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.Kilogram, Unit.Gram, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.Degree, Unit.Radian, out newValue));
			Assert.True(UnitConverter.TryConvert(1, Unit.CubicMeterPerSecond, Unit.CubicMeterPerHour, out newValue));
			Assert.True(UnitConverter.TryConvert(1, Unit.RevolutionsPerSecond, Unit.RevolutionsPerMinute, out newValue));

            // Assert to-unit cases. One for each class of unit.
            Assert.True(UnitConverter.TryConvert(1, Unit.Centimeter, Unit.Meter, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.SquareCentimeter, Unit.SquareMeter, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.Liter, Unit.CubicMeter, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.KilogramForce, Unit.Newton, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.KiloPascal, Unit.Pascal, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.Gram, Unit.Kilogram, out newValue));
            Assert.True(UnitConverter.TryConvert(1, Unit.CubicMeterPerHour, Unit.CubicMeterPerSecond, out newValue));
			Assert.True(UnitConverter.TryConvert(1, Unit.RevolutionsPerMinute, Unit.RevolutionsPerSecond, out newValue));
        }
    }
}
