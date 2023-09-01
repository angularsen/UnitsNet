// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics.CodeAnalysis;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    // ReSharper disable once InconsistentNaming
    public partial class IQuantityTests
    {
        [Fact]
        public void As_GivenWrongUnitType_ThrowsArgumentException()
        {
            IQuantity length = Length.FromMeters(1.2345);
            Assert.Throws<ArgumentException>(() => length.As(MassUnit.Kilogram));
        }

        [Fact]
        [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
        public void As_GivenNullUnitSystem_ThrowsArgumentNullException()
        {
            IQuantity imperialLengthQuantity = new Length(2.0, LengthUnit.Inch);
            Assert.Throws<ArgumentNullException>(() => imperialLengthQuantity.As((UnitSystem)null!));
        }

        [Fact]
        public void As_GivenSIUnitSystem_ReturnsSIValue()
        {
            IQuantity inches = new Length(2.0, LengthUnit.Inch);
            Assert.Equal(0.0508, inches.As(UnitSystem.SI));
        }

        [Fact]
        public void ToUnit_GivenWrongUnitType_ThrowsArgumentException()
        {
            IQuantity length = Length.FromMeters(1.2345);
            Assert.Throws<ArgumentException>(() => length.ToUnit(MassUnit.Kilogram));
        }

        [Fact]
        public void ToUnit_GivenNullUnitSystem_ThrowsArgumentNullException()
        {
            IQuantity imperialLengthQuantity = new Length(2.0, LengthUnit.Inch);
            Assert.Throws<ArgumentNullException>(() => imperialLengthQuantity.ToUnit((UnitSystem)null!));
        }

        [Fact]
        public void ToUnit_GivenSIUnitSystem_ReturnsSIQuantity()
        {
            IQuantity inches = new Length(2.0, LengthUnit.Inch);

            IQuantity inSI = inches.ToUnit(UnitSystem.SI);

            Assert.Equal(0.0508, inSI.Value);
            Assert.Equal(LengthUnit.Meter, inSI.Unit);
        }


        [Fact]
        public void IQuantityTUnitDouble_Value_ReturnsDouble()
        {
            IQuantity<TemperatureUnit, double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.Value);
        }

        [Fact]
        public void IQuantityTUnitDouble_AsEnum_ReturnsDouble()
        {
            IQuantity<TemperatureUnit, double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.As(TemperatureUnit.Kelvin));
        }

        [Fact]
        public void IQuantityTUnitDouble_AsUnitSystem_ReturnsDouble()
        {
            IQuantity<TemperatureUnit, double> doubleQuantity = Temperature.FromDegreesCelsius(1234.5);
            Assert.IsType<double>(doubleQuantity.As(UnitSystem.SI));
        }

        [Fact]
        public void IQuantityTUnitDecimal_Value_ReturnsDecimal()
        {
            IQuantity<InformationUnit, decimal> decimalQuantity = Information.FromKilobytes(1234.5);
            Assert.IsType<decimal>(decimalQuantity.Value);
        }

        [Fact]
        public void IQuantityTUnitDecimal_AsEnum_ReturnsDecimal()
        {
            IQuantity<InformationUnit, decimal> decimalQuantity = Information.FromKilobytes(1234.5);
            Assert.IsType<decimal>(decimalQuantity.As(InformationUnit.Byte));
        }

        [Fact]
        public void IQuantityTUnitDecimal_AsUnitSystem_ReturnsDecimal()
        {
            IQuantity<PowerUnit, decimal> decimalQuantity = Power.FromMegawatts(1234.5);
            Assert.IsType<decimal>(decimalQuantity.As(UnitSystem.SI));
        }
    }
}
