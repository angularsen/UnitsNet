// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Numerics;

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
                Assert.Throws<UnitNotFoundException>(() => quantity.As(ComparisonType.Absolute));
            });
        }

        [Fact]
        public void ToUnit_GivenWrongUnitType_ThrowsArgumentException()
        {
            Assert.All(Quantity.Infos.Select(x => x.Zero), quantity =>
            {
                Assert.Throws<UnitNotFoundException>(() => quantity.ToUnit(ComparisonType.Absolute));
            });
        }
        
        #if NET
        
        [Fact]
        public void ILinearQuantity_AdditiveIdentity_ReturnsZero()
        {
            AssertThat_ILinearQuantity_AdditiveIdentity_ReturnsZero<Mass>();
        }

        private static void AssertThat_ILinearQuantity_AdditiveIdentity_ReturnsZero<TQuantity>()
            where TQuantity : ILinearQuantity<TQuantity>
        {
            Assert.Equal(TQuantity.Zero, TQuantity.AdditiveIdentity);
        }
        
        [Fact]
        public void ILogarithmicQuantity_MultiplicativeIdentity_ReturnsZero()
        {
            AssertThat_ILogarithmicQuantity_MultiplicativeIdentity_ReturnsZero<PowerRatio>();
        }

        private static void AssertThat_ILogarithmicQuantity_MultiplicativeIdentity_ReturnsZero<TQuantity>()
            where TQuantity : ILogarithmicQuantity<TQuantity>
        {
            Assert.Equal(TQuantity.Zero, TQuantity.MultiplicativeIdentity);
        }
        
        [Fact]
        public void IAffineQuantity_AdditiveIdentity_ReturnsTheZeroOffset()
        {
            AssertThat_ILinearQuantity_AdditiveIdentity_ReturnsZero<TemperatureDelta>();
            AssertThat_IAffineQuantity_AdditiveIdentity_ReturnsTheZeroOffset<Temperature, TemperatureDelta>();
        }

        private static void AssertThat_IAffineQuantity_AdditiveIdentity_ReturnsTheZeroOffset<TQuantity, TOffset>()
            where TQuantity : IAffineQuantity<TQuantity, TOffset>
            where TOffset : IAdditiveIdentity<TOffset, TOffset>
        {
            Assert.Equal(TOffset.AdditiveIdentity, TQuantity.AdditiveIdentity);
        }

        #endif
    }
}
