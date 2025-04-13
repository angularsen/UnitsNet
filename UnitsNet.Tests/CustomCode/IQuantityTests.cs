// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using UnitsNet.Units;
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
                Assert.Throws<UnitNotFoundException>(() => quantity.As(ComparisonType.Absolute));
            });
        }

        // [Fact]
        // public void As_GivenNullUnitSystem_ThrowsArgumentNullException()
        // {
        //     Assert.All(Quantity.Infos.Select(x => x.Zero), quantity =>
        //     {
        //         Assert.Throws<ArgumentNullException>(() => quantity.As((UnitSystem)null!));
        //     });
        // }

        // [Fact]
        // public void As_GivenSIUnitSystem_ReturnsSIValue()
        // {
        //     IQuantity inches = new Length(2.0, LengthUnit.Inch);
        //     Assert.Equal(0.0508, inches.As(UnitSystem.SI));
        // }

        [Fact]
        public void ToUnit_GivenWrongUnitType_ThrowsArgumentException()
        {
            Assert.All(Quantity.Infos.Select(x => x.Zero), quantity =>
            {
                Assert.Throws<UnitNotFoundException>(() => quantity.ToUnit(ComparisonType.Absolute));
            });
        }

        // [Fact]
        // public void ToUnit_GivenNullUnitSystem_ThrowsArgumentNullException()
        // {
        //     Assert.All(Quantity.Infos.Select(x => x.Zero), quantity =>
        //     {
        //         Assert.Throws<ArgumentNullException>(() => quantity.ToUnit((UnitSystem)null!));
        //     });
        // }
        //
        // [Fact]
        // public void ToUnit_GivenSIUnitSystem_ReturnsSIQuantity()
        // {
        //     IQuantity inches = new Length(2.0, LengthUnit.Inch);
        //
        //     IQuantity inSI = inches.ToUnit(UnitSystem.SI);
        //
        //     Assert.Equal(0.0508, inSI.Value);
        //     Assert.Equal(LengthUnit.Meter, inSI.Unit);
        // }
        
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
