using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class UnitValueTests
    {
        [Test]
        public void TryConvertReturnsFalseOnIncompatibleUnits()
        {
            double newValue;
            Assert.False(new UnitValue(1, Unit.Meter).TryConvert(Unit.Second, out newValue));
            Assert.False(new UnitValue(1, Unit.SquareMeter).TryConvert(Unit.Second, out newValue));
            Assert.False(new UnitValue(1, Unit.CubicMeter).TryConvert(Unit.Second, out newValue));
            Assert.False(new UnitValue(1, Unit.Newton).TryConvert(Unit.Second, out newValue));
            Assert.False(new UnitValue(1, Unit.Pascal).TryConvert(Unit.Second, out newValue));
            Assert.False(new UnitValue(1, Unit.Kilogram).TryConvert(Unit.Second, out newValue));
            Assert.False(new UnitValue(1, Unit.Degree).TryConvert(Unit.Second, out newValue));
			Assert.False(new UnitValue(1, Unit.CubicMeterPerSecond).TryConvert(Unit.Second, out newValue));
			Assert.False(new UnitValue(1, Unit.RevolutionsPerSecond).TryConvert(Unit.Second, out newValue));
        }
    }
}
