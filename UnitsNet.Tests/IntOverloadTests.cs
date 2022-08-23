// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests
{
    public class IntOverloadTests
    {
        [Fact]
        public static void CreatingQuantityWithDoubleBackingFieldFromIntReturnsCorrectValue()
        {
            Acceleration acceleration = Acceleration.FromMetersPerSecondSquared(1);
            Assert.Equal(1.0, acceleration.MetersPerSecondSquared);
        }

        [Fact]
        public static void CreatingQuantityWithIntBackingFieldFromIntReturnsCorrectValue()
        {
            Power power = Power.FromWatts(1);
            Assert.Equal(1.0, power.Watts);
        }
    }
}
