using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.Oasys
{
    public class QuantityTryFromTests
    {
        [Fact]
        public void MomentUnitTryFromTest()
        {
            double val = 2;
            MomentUnit unit = MomentUnit.KilopoundForceFoot;
            Assert.True(Quantity.TryFrom(val, unit, out IQuantity quantity));
            Assert.Equal(val, quantity.As(unit));
        }
    }
}
