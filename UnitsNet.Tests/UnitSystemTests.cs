// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Linq;
using UnitsNet.UnitSystems;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class UnitSystemTests
    {
        [Fact]
        [Obsolete("The constructor relies on the presence of BaseUnits property for Units- which is likely to be removed", false)]
        public void ConstructorImplementedProperly()
        {
            var baseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

            var unitSystem = new BaseUnitSystem(baseUnits);

            Assert.Equal(unitSystem.BaseUnits, baseUnits);
        }

        [Fact]
        [Obsolete("The constructor relies on the presence of BaseUnits property for Units- which is likely to be removed", false)]
        public void ConstructorThrowsArgumentNullExceptionForNullBaseUnits()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitSystem(null!));
        }

        [Theory]
        [InlineData(LengthUnit.Undefined, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Undefined, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Undefined, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Undefined, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Undefined, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Undefined, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Undefined)]
        [Obsolete("The constructor relies on the presence of BaseUnits property for Units- which is likely to be removed", false)]
        public void ConstructorThrowsArgumentExceptionWithUndefinedUnits(LengthUnit length, MassUnit mass, DurationUnit time, ElectricCurrentUnit current,
            TemperatureUnit temperature, AmountOfSubstanceUnit amount, LuminousIntensityUnit luminousIntensity)
        {
            var baseUnits = new BaseUnits(length, mass, time, current, temperature, amount, luminousIntensity);

            Assert.Throws<ArgumentException>(() => new UnitSystem(baseUnits));
            Assert.Throws<ArgumentException>(() => new BaseUnitSystem(baseUnits));
        }

        [Fact]
        [Obsolete("The constructor relies on the presence of BaseUnits property for Units- which is likely to be removed", false)]
        public void EqualsUnitSystem_ConstructedFromDefaultSIUnits_ReturnsTrue()
        {
            var derivedSystem = new UnitSystem(UnitSystem.SI.BaseUnits);

            Assert.Equal(UnitSystem.SI, derivedSystem);
        }

        [Fact]
        public void EqualsBaseUnitSystem_ConstructedFromDefaultSIUnits_ReturnsTrue()
        {
            var derivedSystem = new BaseUnitSystem(SI.GetDefaultSystemUnits());

            Assert.Equal(UnitSystem.SI.BaseUnits, derivedSystem.BaseUnits);
            Assert.Equal(UnitSystem.SI, derivedSystem);
        }

        [Fact]
        public void EqualsUnitSystem_DerivedUsingSameDefaultUnit_ReturnsTrue()
        {
            var derivedSystem = UnitSystem.SI.WithDefaultUnit(QuantityType.Length, UnitSystem.SI.GetDefaultUnitInfo(QuantityType.Length));

            Assert.Equal(UnitSystem.SI.BaseUnits, derivedSystem.BaseUnits);
            Assert.Equal(UnitSystem.SI, derivedSystem);
        }

        [Fact]
        [Obsolete("The constructor relies on the presence of BaseUnits property for Units- which is likely to be removed", false)]
        public void EqualsObjectIsImplementedCorrectly()
        {
            var unitSystem1 = new BaseUnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem2 = new BaseUnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem3 = new BaseUnitSystem(new BaseUnits(LengthUnit.Foot, MassUnit.Pound, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.DegreeFahrenheit, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            Assert.True(unitSystem1.Equals((object)unitSystem2));
            Assert.False(unitSystem1.Equals((object)unitSystem3));

            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.False(unitSystem1.Equals("Some object."));
            Assert.False(unitSystem1.Equals((IFormatProvider)null));
        }

        [Fact]
        [Obsolete("The constructor relies on the presence of BaseUnits property for Units- which is likely to be removed", false)]
        public void EqualsUnitSystemIsImplementedCorrectly()
        {
            var unitSystem1 = new BaseUnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem2 = new BaseUnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem3 = new BaseUnitSystem(new BaseUnits(LengthUnit.Foot, MassUnit.Pound, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.DegreeFahrenheit, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            Assert.True(unitSystem1.Equals(unitSystem2));
            Assert.True(unitSystem2.Equals(unitSystem1));

            Assert.False(unitSystem1.Equals(unitSystem3));
            Assert.False(unitSystem3.Equals(unitSystem1));

            Assert.False(unitSystem1.Equals(null));
        }

        [Fact]
        [Obsolete("The constructor relies on the presence of BaseUnits property for Units- which is likely to be removed", false)]
        public void EqualityOperatorIsImplementedCorrectly()
        {
            var unitSystem1 = new BaseUnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem2 = new BaseUnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem3 = new BaseUnitSystem(new BaseUnits(LengthUnit.Foot, MassUnit.Pound, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.DegreeFahrenheit, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            Assert.True(unitSystem1 == unitSystem2);
            Assert.True(unitSystem2 == unitSystem1);

            Assert.False(unitSystem1 == unitSystem3);
            Assert.False(unitSystem3 == unitSystem1);

            Assert.False(unitSystem1 == null);
            Assert.False(null == unitSystem1);

            UnitSystem nullUnitSystem1 = null;
            UnitSystem nullUnitSystem2 = null;

            Assert.True(nullUnitSystem1 == nullUnitSystem2);
        }

        [Fact]
        [Obsolete("The constructor relies on the presence of BaseUnits property for Units- which is likely to be removed", false)]
        public void InequalityOperatorIsImplementedCorrectly()
        {
            var unitSystem1 = new BaseUnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem2 = new BaseUnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem3 = new BaseUnitSystem(new BaseUnits(LengthUnit.Foot, MassUnit.Pound, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.DegreeFahrenheit, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            Assert.False(unitSystem1 != unitSystem2);
            Assert.False(unitSystem2 != unitSystem1);

            Assert.True(unitSystem1 != unitSystem3);
            Assert.True(unitSystem3 != unitSystem1);

            Assert.True(unitSystem1 != null);
            Assert.True(null != unitSystem1);

            BaseUnitSystem nullUnitSystem1 = null;
            BaseUnitSystem nullUnitSystem2 = null;

            Assert.False(nullUnitSystem1 != nullUnitSystem2);
        }

        [Fact]
        public void SIUnitSystemHasCorrectBaseUnits()
        {
            Assert.Equal(LengthUnit.Meter, UnitSystem.SI.BaseUnits.Length);
            Assert.Equal(MassUnit.Kilogram, UnitSystem.SI.BaseUnits.Mass);
            Assert.Equal(DurationUnit.Second, UnitSystem.SI.BaseUnits.Time);
            Assert.Equal(ElectricCurrentUnit.Ampere, UnitSystem.SI.BaseUnits.Current);
            Assert.Equal(TemperatureUnit.Kelvin, UnitSystem.SI.BaseUnits.Temperature);
            Assert.Equal(AmountOfSubstanceUnit.Mole, UnitSystem.SI.BaseUnits.Amount);
            Assert.Equal(LuminousIntensityUnit.Candela, UnitSystem.SI.BaseUnits.LuminousIntensity);
        }

        [Fact]
        public void GetDefaultUnitInfo_GivenUndefinedQuantity_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => UnitSystem.SI.GetDefaultUnitInfo(QuantityType.Undefined));
        }

        [Fact]
        public void GetDefaultUnitInfo_FromBaseUnitSystem_ReturnsBaseUnitSystem()
        {
            var anyUnitInfo = Length.Info.UnitInfos.First();
            BaseUnitSystem unitSystem = UnitSystem.SI;

            // default overload: same as SI.WithDefaultUnit(..)
            var derivedSystem = unitSystem.WithDefaultUnit(QuantityType.Length, anyUnitInfo); 
            
            Assert.IsType<BaseUnitSystem>(derivedSystem);
        }
        
        [Fact]
        public void GetDefaultUnitInfo_FromUnitSystem_ReturnsUnitSystem()
        {
            UnitSystem unitSystem = UnitSystem.SI;

            var derivedSystem = unitSystem.WithDefaultUnit(QuantityType.Length, null); // base type no longer defined
            
            Assert.IsType<UnitSystem>(derivedSystem);
        }
        
        [Theory]
        [InlineData(QuantityType.Length)]
        [InlineData(QuantityType.Mass)]
        [InlineData(QuantityType.Duration)]
        [InlineData(QuantityType.ElectricCurrent)]
        [InlineData(QuantityType.Temperature)]
        [InlineData(QuantityType.AmountOfSubstance)]
        [InlineData(QuantityType.LuminousIntensity)]
        public void WithDefaultUnit_GivenBaseUnitsAssociationsNotFullyDefined_ThrowsArgumentException(QuantityType baseType)
        {
            BaseUnitSystem unitSystem = UnitSystem.SI;

            // exception thrown from the BaseUnitSystem constructor
            Assert.Throws<ArgumentException>(() => unitSystem.WithDefaultUnit(baseType, null));
        }
        
        [Theory]
        [InlineData(QuantityType.Length)]
        [InlineData(QuantityType.Mass)]
        [InlineData(QuantityType.Duration)]
        [InlineData(QuantityType.ElectricCurrent)]
        [InlineData(QuantityType.Temperature)]
        [InlineData(QuantityType.AmountOfSubstance)]
        [InlineData(QuantityType.LuminousIntensity)]
        public void GetDefaultUnitInfo_GivenUndefinedQuantityType_ReturnsNull(QuantityType baseType)
        {
            UnitSystem unitSystem = UnitSystem.SI;

            // since Length, Mass etc are part of the BaseUnits definition, we need to derive from UnitSystem (instead of BaseUnitSystem)
            var unitSystemWithNoDefaultUnit = unitSystem.WithDefaultUnit(baseType, null); // force the dissociation
            
            Assert.IsType<UnitSystem>(unitSystemWithNoDefaultUnit);
            Assert.Null(unitSystemWithNoDefaultUnit.GetDefaultUnitInfo(baseType));
        }

        [Fact]
        public void WithDefaultUnit_GivenNullForDerivedUnits_ReturnsUnitSystemWithOldDerivedUnits()
        {
            var myDefaultLengthUnit = Length.Info.UnitInfos.First(x => x.Value == LengthUnit.Millimeter);

            var derivedSystem = UnitSystem.SI.WithDefaultUnit(QuantityType.Length, myDefaultLengthUnit); 

            Assert.Equal(LengthUnit.Millimeter, derivedSystem.GetDefaultUnitInfo(QuantityType.Length)?.Value);
            Assert.Equal(UnitSystem.SI.GetCommonUnitsInfo(QuantityType.Length), derivedSystem.GetCommonUnitsInfo(QuantityType.Length));
        }

        [Fact]
        public void WithDefaultUnit_GivenUndefinedQuantityType_ThrowsArgumentException()
        {
            var anyUnitInfo = Length.Info.UnitInfos.First();

            Assert.Throws<ArgumentException>(() => UnitSystem.SI.WithDefaultUnit(QuantityType.Undefined, anyUnitInfo));
        }

        [Fact]
        public void WithDefaultUnit_GivenIncompatibleUnitAndQuantityType_ThrowsArgumentException()
        {
            var nonMassUnit = Length.Info.UnitInfos.First();

            Assert.Throws<ArgumentException>(() => UnitSystem.SI.WithDefaultUnit(QuantityType.Mass, nonMassUnit));
        }

    }
}
