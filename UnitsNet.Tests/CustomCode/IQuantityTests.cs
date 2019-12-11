// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public partial class IQuantityTests
    {
        [Fact]
        public void As_GivenWrongUnitType_ThrowsArgumentException()
        {
            IQuantity length = Length.FromMeters(1.2345);
            Assert.Throws<ArgumentException>(() => length.As(MassUnit.Kilogram));
        }

        [Fact]
        public void As_GivenNullUnitSystem_ThrowsArgumentNullException()
        {
            IQuantity imperialLengthQuantity = new Length(2.0, LengthUnit.Inch);
            Assert.Throws<ArgumentNullException>(() => imperialLengthQuantity.As((UnitSystem)null));
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
            Assert.Throws<ArgumentNullException>(() => imperialLengthQuantity.ToUnit((UnitSystem)null));
        }

        [Fact]
        public void ToUnit_GivenSIUnitSystem_ReturnsSIQuantity()
        {
            IQuantity inches = new Length(2.0, LengthUnit.Inch);

            IQuantity inSI = inches.ToUnit(UnitSystem.SI);

            Assert.Equal(0.0508, inSI.Value);
            Assert.Equal(LengthUnit.Meter, inSI.Unit);
        }
    }
}
