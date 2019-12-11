// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class LongOverloadTests
    {
        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromLongReturnsCorrectValue()
        {
            Acceleration acceleration = Acceleration.FromMetersPerSecondSquared(1L);
            Assert.Equal(1.0, acceleration.MetersPerSecondSquared);
        }

        [Fact]
        public static void CreatingQuantityWithLongBackingFieldFromLongReturnsCorrectValue()
        {
            Power power = Power.FromWatts(1L);
            Assert.Equal(1.0, power.Watts);
        }
    }
}
