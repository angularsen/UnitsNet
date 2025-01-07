// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using Xunit;

namespace UnitsNet.Tests
{
    // ReSharper disable once InconsistentNaming
    public partial class IQuantityTests
    {
        [Fact]
        public void As_GivenWrongUnitType_ThrowsArgumentException()
        {
            Assert.All(Quantity.Infos.Select(x => x.Zero), quantity =>
            {
                Assert.Throws<ArgumentException>(() => quantity.As(ComparisonType.Absolute));
            });
        }

        [Fact]
        public void ToUnit_GivenWrongUnitType_ThrowsArgumentException()
        {
            Assert.All(Quantity.Infos.Select(x => x.Zero), quantity =>
            {
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(ComparisonType.Absolute));
            });
        }
    }
}
