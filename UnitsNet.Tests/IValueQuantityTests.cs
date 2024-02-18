// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    // ReSharper disable once InconsistentNaming
    public class IValueQuantityTests
    {
        [Fact]
        public void IValueQuantityTDouble_Value_ReturnsDouble()
        {
            IValueQuantity<double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.Value);
        }

        [Fact]
        public void IValueQuantityTDouble_AsEnum_ReturnsDouble()
        {
            IValueQuantity<double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.As(TemperatureUnit.Kelvin));
        }

        [Fact]
        public void IValueQuantityTDouble_AsUnitSystem_ReturnsDouble()
        {
            IValueQuantity<double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.As(UnitSystem.SI));
        }

        [Fact]
        public void IValueQuantityTDecimal_Value_ReturnsDecimal()
        {
            IValueQuantity<decimal> decimalQuantity = Information.FromKilobytes(1234.5);
            Assert.IsType<decimal>(decimalQuantity.Value);
        }

        [Fact]
        public void IValueQuantityTDecimal_AsEnum_ReturnsDecimal()
        {
            IValueQuantity<decimal> decimalQuantity = Information.FromKilobytes(1234.5);
            Assert.IsType<decimal>(decimalQuantity.As(InformationUnit.Byte));
        }

        [Fact]
        public void IValueQuantityTDecimal_AsUnitSystem_ReturnsDecimal()
        {
            IValueQuantity<decimal> decimalQuantity = Power.FromMegawatts(1234.5);
            Assert.IsType<decimal>(decimalQuantity.As(UnitSystem.SI));
        }

        [Fact]
        public void IValueQuantityTDouble_ToUnitEnum_ReturnsIValueQuantityTDouble()
        {
            IValueQuantity<double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsAssignableFrom<IValueQuantity<double>>(doubleQuantity.ToUnit(TemperatureUnit.Kelvin));
        }

        [Fact]
        public void IValueQuantityTDouble_ToUnitUnitSystem_ReturnsIValueQuantityTDouble()
        {
            IValueQuantity<double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsAssignableFrom<IValueQuantity<double>>(doubleQuantity.ToUnit(UnitSystem.SI));
        }

        [Fact]
        public void IValueQuantityTDecimal_ToUnitEnum_ReturnsIValueQuantityTDecimal()
        {
            IValueQuantity<decimal> decimalQuantity = Information.FromKilobytes(1234.5);
            Assert.IsAssignableFrom<IValueQuantity<decimal>>(decimalQuantity.ToUnit(InformationUnit.Bit));
        }

        [Fact]
        public void IValueQuantityTDecimal_ToUnitUnitSystem_ReturnsIValueQuantityTDecimal()
        {
            IValueQuantity<decimal> decimalQuantity = Power.FromWatts(1234.5);
            Assert.IsAssignableFrom<IValueQuantity<decimal>>(decimalQuantity.ToUnit(UnitSystem.SI));
        }
    }
}
