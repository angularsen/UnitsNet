// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class IQuantityTests
    {
        [Fact]
        public void As_GivenWrongUnitType_ThrowsArgumentException()
        {
            IQuantity quantity = Length.FromMeters(1.2345);
            Assert.Throws<ArgumentException>(() => quantity.As(MassUnit.Kilogram));
        }

        [Fact]
        public void ToUnit_GivenWrongUnitType_ThrowsArgumentException()
        {
            IQuantity quantity = Length.FromMeters(1.2345);
            Assert.Throws<ArgumentException>(() => quantity.ToUnit(MassUnit.Kilogram));
        }
    }
}
