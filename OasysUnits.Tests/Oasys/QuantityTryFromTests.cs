using OasysUnits.Units;
using Xunit;

namespace OasysUnits.Tests.Oasys
{
    public class QuantityTryFromTests
    {
        [Fact]
        public void MomentUnitTryFromTest()
        {
            double val = 2;
            MomentUnit unit = MomentUnit.KilopoundForceFoot;
            Assert.True(Quantity.TryFrom(val, unit, out IQuantity? quantity));
            Assert.Equal(val, quantity?.As(unit));
        }
    }
}
