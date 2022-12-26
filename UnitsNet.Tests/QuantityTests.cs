// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public partial class QuantityTests
    {
        [Fact]
        public void GetHashCodeForDifferentQuantitiesWithSameValuesAreNotEqual()
        {
            var length = new Length(1.0, (LengthUnit)2);
            var area = new Area(1.0, (AreaUnit)2);

            Assert.NotEqual(length.GetHashCode(), area.GetHashCode());
        }
    }
}
