// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet.Tests;

// ReSharper disable once InconsistentNaming
public partial class IQuantityTests
{
    [Fact]
    public void As_GivenWrongUnitType_ThrowsUnitNotFoundException()
    {
        Assert.All(Quantity.Infos.Select(x => x.Zero), quantity => { Assert.Throws<UnitNotFoundException>(() => quantity.As(ComparisonType.Absolute)); });
    }

    [Fact]
    public void ToUnit_GivenWrongUnitType_ThrowsUnitNotFoundException()
    {
        Assert.All(Quantity.Infos.Select(x => x.Zero),
            quantity => { Assert.Throws<UnitNotFoundException>(() => quantity.ToUnit(ComparisonType.Absolute)); });
    }

    [Fact]
    public void As_InterfaceReferences_ReturnConvertedValue()
    {
        var mass = Mass.FromKilograms(1);
        IQuantity quantity = mass;
        IQuantity<MassUnit> typedQuantity = mass;

        Assert.Equal(1000, quantity.As(MassUnit.Gram));
        Assert.Equal(1000, typedQuantity.As(MassUnit.Gram));
    }

    [Fact]
    public void ToUnit_IQuantityFromNonBaseUnit_ReturnsConvertedQuantity()
    {
        IQuantity quantity = Length.FromKilometers(1);

        IQuantity convertedQuantity = quantity.ToUnit(LengthUnit.Centimeter);

        Assert.Equal(100_000, convertedQuantity.Value);
        Assert.Equal(LengthUnit.Centimeter, convertedQuantity.Unit);
    }

    [Fact]
    public void ToUnit_GenericConstraintWithCustomConverter_UsesProvidedConverter()
    {
        var converter = new UnitConverter();
        converter.SetConversionFunction<Length>(
            LengthUnit.Meter,
            LengthUnit.Centimeter,
            _ => Length.FromCentimeters(123));

        Length convertedQuantity = ConvertToUnit(Length.FromMeters(1), LengthUnit.Centimeter, converter);

        Assert.Equal(123, convertedQuantity.Value);
        Assert.Equal(LengthUnit.Centimeter, convertedQuantity.Unit);

        static TQuantity ConvertToUnit<TQuantity, TUnit>(TQuantity quantity, TUnit unit, UnitConverter unitConverter)
            where TQuantity : IQuantity<TQuantity, TUnit>
            where TUnit : struct, Enum
        {
            return quantity.ToUnit(unit, unitConverter);
        }
    }

    [Fact]
    public virtual void ToUnit_UnitSystem_SI_ReturnsQuantityInSIUnits()
    {
        var quantity = new Mass(1, Mass.BaseUnit);
        MassUnit expectedUnit = Mass.Info.GetDefaultUnit(UnitSystem.SI);
        var expectedValue = quantity.As(expectedUnit);

        Assert.Multiple(() =>
        {
            IQuantity<MassUnit> quantityToConvert = quantity;

            IQuantity<MassUnit> convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

            Assert.Equal(expectedUnit, convertedQuantity.Unit);
            Assert.Equal(expectedValue, convertedQuantity.Value);
        }, () =>
        {
            IQuantity quantityToConvert = quantity;

            IQuantity convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

            Assert.Equal(expectedUnit, convertedQuantity.Unit);
            Assert.Equal(expectedValue, convertedQuantity.Value);
        });
    }

    [Fact]
    public void ToUnit_UnitSystem_ThrowsArgumentNullExceptionIfNull()
    {
        UnitSystem nullUnitSystem = null!;
        Assert.Multiple(() =>
        {
            IQuantity<MassUnit> quantity = new Mass(1, Mass.BaseUnit);
            Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
        }, () =>
        {
            IQuantity quantity = new Mass(1, Mass.BaseUnit);
            Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
        });
    }

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
        Assert.All(Quantity.Infos.Select(x => x.Zero), quantity =>
        {
            Assert.Equal(quantity.Unit, quantity.GetUnitInfo().Value);
        });
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

    [Fact]
    public void ToUnit_SelfTypedGenericConstraint_ReturnsConcreteQuantity()
    {
        var length = Length.FromKilometers(1.5);

        Length converted = ConvertToUnit<Length, LengthUnit>(length, LengthUnit.Meter);

        Assert.Equal(1500, converted.Value);
        Assert.Equal(LengthUnit.Meter, converted.Unit);

        static TQuantity ConvertToUnit<TQuantity, TUnit>(TQuantity quantity, TUnit unit)
            where TQuantity : IQuantity<TQuantity, TUnit>
            where TUnit : struct, Enum
        {
            return quantity.ToUnit(unit);
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
