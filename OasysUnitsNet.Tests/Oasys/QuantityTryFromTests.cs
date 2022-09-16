using System.Globalization;
using OasysUnitsNet.Units;
using Xunit;

namespace OasysUnitsNet.Tests.Oasys
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
