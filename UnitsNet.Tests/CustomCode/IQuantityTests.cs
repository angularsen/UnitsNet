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
            Assert.All(Quantity.Infos.Select(x => x.Zero), quantity => { Assert.Throws<UnitNotFoundException>(() => quantity.As(ComparisonType.Absolute)); });
        }

        [Fact]
        public void ToUnit_GivenWrongUnitType_ThrowsArgumentException()
        {
            Assert.All(Quantity.Infos.Select(x => x.Zero),
                quantity => { Assert.Throws<UnitNotFoundException>(() => quantity.ToUnit(ComparisonType.Absolute)); });
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

        private static void AssertThat_IAffineQuantity_AdditiveIdentity_ReturnsTheZeroOffset<TQuantity, TOffset>()
            where TQuantity : IAffineQuantity<TQuantity, TOffset>
            where TOffset : IAdditiveIdentity<TOffset, TOffset>
        {
            Assert.Equal(TOffset.AdditiveIdentity, TQuantity.AdditiveIdentity);
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

#endif

        [Fact]
        public void GetUnitInfo_ReturnsUnitInfoForQuantityUnit()
        {
            var length = new Length(3.0, LengthUnit.Centimeter);
            IQuantity quantity = length;

            UnitInfo unitInfo = quantity.GetUnitInfo();

            Assert.Equal(nameof(LengthUnit.Centimeter), unitInfo.Name);
            Assert.Equal(quantity.UnitKey, unitInfo.UnitKey);
        }

        [Fact]
        public void GetUnitInfo_Zero_ReturnsBaseUnitInfo()
        {
            IQuantity quantity = Length.Info.Zero;

            UnitInfo unitInfo = quantity.GetUnitInfo();

            Assert.Equal(Length.Info.BaseUnitInfo.UnitKey, unitInfo.UnitKey);
        }

        [Fact]
        public void GetUnitInfo_ConcreteQuantity_ReturnsFullyTypedUnitInfo()
        {
            var quantity = new Length(3.0, LengthUnit.Centimeter);

            // Overload resolution picks GetUnitInfo<TQuantity, TUnit> for the concrete struct receiver,
            // returning the most specific UnitInfo<Length, LengthUnit>.
            UnitInfo<Length, LengthUnit> unitInfo = quantity.GetUnitInfo();

            Assert.Equal(LengthUnit.Centimeter, unitInfo.Value);
            Assert.Equal(nameof(LengthUnit.Centimeter), unitInfo.Name);
        }

        [Fact]
        public void GetUnitInfo_TypedQuantityReference_FallsBackToNonGeneric()
        {
            IQuantity<LengthUnit> quantity = new Length(3.0, LengthUnit.Centimeter);

            // The IQuantity<TUnit> reference does not satisfy the IQuantity<TSelf, TUnit> constraint
            // (TSelf would be IQuantity<MassUnit>), so resolution falls back to GetUnitInfo(IQuantity).
            UnitInfo unitInfo = quantity.GetUnitInfo();

            Assert.Equal(LengthUnit.Centimeter, ((UnitInfo<LengthUnit>)unitInfo).Value);
            Assert.Equal(nameof(LengthUnit.Centimeter), unitInfo.Name);
        }

        [Fact]
        public void GetUnitInfo_MatchesUnit()
        {
            Assert.All(Quantity.Infos.Select(x => x.Zero), quantity => { Assert.Equal(quantity.Unit, quantity.GetUnitInfo().Value); });
        }

        [Fact]
        public void GetQuantityInfo_NonGeneric_ReturnsRegisteredQuantityInfo()
        {
            IQuantity quantity = new Mass(1.0, MassUnit.Kilogram);

            QuantityInfo info = quantity.GetQuantityInfo();

            Assert.Same(Mass.Info, info);
        }

        [Fact]
        public void GetQuantityInfo_Typed_ReturnsRegisteredQuantityInfo()
        {
            IQuantity<MassUnit> quantity = new Mass(1.0, MassUnit.Kilogram);

            QuantityInfo<MassUnit> info = quantity.GetQuantityInfo();

            Assert.Same(Mass.Info, info);
        }

#if NET
        [Fact]
        public void StaticAbstract_Info_ReturnsSameAsTypedInfo()
        {
            // Calls IQuantity<TSelf, TUnitType>.Info via the static abstract member.
            QuantityInfo<Mass, MassUnit> typedInfo = Mass.Info;
            QuantityInfo<Mass, MassUnit> viaStaticAbstract = StaticAbstractAccess<Mass, MassUnit>();

            Assert.Same(typedInfo, viaStaticAbstract);

            static QuantityInfo<TSelf, TUnit> StaticAbstractAccess<TSelf, TUnit>()
                where TSelf : IQuantity<TSelf, TUnit>
                where TUnit : struct, Enum
            {
                return TSelf.Info;
            }
        }

        [Fact]
        public void StaticAbstract_Info_NonGeneric_ReturnsSameAsTypedInfo()
        {
            // Calls IQuantityOfType<TQuantity>.Info via the static abstract member.
            QuantityInfo info = StaticAbstractAccess<Mass>();

            Assert.Same((QuantityInfo)Mass.Info, info);

            static QuantityInfo StaticAbstractAccess<TQuantity>()
                where TQuantity : IQuantityOfType<TQuantity>
            {
                return TQuantity.Info;
            }
        }
#endif

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(new BaseUnits(
                (LengthUnit)(-1),
                (MassUnit)(-1),
                (DurationUnit)(-1),
                (ElectricCurrentUnit)(-1),
                (TemperatureUnit)(-1),
                (AmountOfSubstanceUnit)(-1),
                (LuminousIntensityUnit)(-1)));

            Assert.Multiple(() =>
            {
                IQuantity<MassUnit> quantity = new Mass(1, Mass.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity quantity = new Mass(1, Mass.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            });
        }
    }
}
