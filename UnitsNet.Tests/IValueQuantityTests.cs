// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class IValueQuantityTests
    {
        [Fact]
        public void IValueQuantityDouble_Value_ReturnsDouble()
        {
            IValueQuantity<double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.Value);
        }

        [Fact]
        public void IValueQuantityDouble_AsEnum_ReturnsDouble()
        {
            IValueQuantity<double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.As(TemperatureUnit.Kelvin));
        }

        [Fact]
        public void IValueQuantityDouble_AsUnitSystem_ReturnsDouble()
        {
            IValueQuantity<double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.As(UnitSystem.SI));
        }

        [Fact]
        public void IValueQuantityDoubleTemperature_Value_ReturnsDouble()
        {
            IValueQuantity<TemperatureUnit, double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.Value);
        }

        [Fact]
        public void IValueQuantityTDoubleTemperature_AsEnum_ReturnsDouble()
        {
            IValueQuantity<double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.As(TemperatureUnit.Kelvin));
        }

        [Fact]
        public void IValueQuantityTDoubleTemperature_AsUnitSystem_ReturnsDouble()
        {
            IValueQuantity<double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.As(UnitSystem.SI));
        }
    }
}
