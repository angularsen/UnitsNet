// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class BaseUnitsTests
    {
        private static BaseUnits siBaseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

        private static BaseUnits siBaseUnitsCopy = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

        private static BaseUnits nonSiBaseUnits = new BaseUnits(LengthUnit.Foot, MassUnit.Pound, DurationUnit.Second,
            ElectricCurrentUnit.Ampere, TemperatureUnit.DegreeFahrenheit, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

        [Fact]
        public void ConstructorSetsUnitsProperly()
        {
            var baseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

            Assert.Equal(LengthUnit.Meter, baseUnits.Length);
            Assert.Equal(MassUnit.Kilogram, baseUnits.Mass);
            Assert.Equal(DurationUnit.Second, baseUnits.Time);
            Assert.Equal(ElectricCurrentUnit.Ampere, baseUnits.Current);
            Assert.Equal(TemperatureUnit.Kelvin, baseUnits.Temperature);
            Assert.Equal(AmountOfSubstanceUnit.Mole, baseUnits.Amount);
            Assert.Equal(LuminousIntensityUnit.Candela, baseUnits.LuminousIntensity);
        }

        [Fact]
        public void EqualsObjectIsImplementedCorrectly()
        {
            Assert.True(siBaseUnits.Equals((object)siBaseUnitsCopy));
            Assert.False(siBaseUnits.Equals((object)nonSiBaseUnits));

            Assert.False(siBaseUnits.Equals("Some object."));
            Assert.False(siBaseUnits.Equals((IFormatProvider)null));
        }

        [Fact]
        public void EqualsBaseUnitsIsImplementedCorrectly()
        {
            Assert.True(siBaseUnits.Equals(siBaseUnitsCopy));
            Assert.True(siBaseUnitsCopy.Equals(siBaseUnits));

            Assert.False(siBaseUnits.Equals(nonSiBaseUnits));
            Assert.False(nonSiBaseUnits.Equals(siBaseUnits));

            Assert.False(siBaseUnits.Equals(null));
        }

        [Fact]
        public void EqualityOperatorIsImplementedCorrectly()
        {
            Assert.True(siBaseUnits == siBaseUnitsCopy);
            Assert.True(siBaseUnitsCopy == siBaseUnits);

            Assert.False(siBaseUnits == nonSiBaseUnits);
            Assert.False(nonSiBaseUnits == siBaseUnits);

            Assert.False(siBaseUnits == null);
            Assert.False(null == siBaseUnits);

            BaseUnits nullBaseUnits1 = null;
            BaseUnits nullBaseUnits2 = null;

            Assert.True(nullBaseUnits1 == nullBaseUnits2);
        }

        [Fact]
        public void InequalityOperatorIsImplementedCorrectly()
        {
            Assert.False(siBaseUnits != siBaseUnitsCopy);
            Assert.False(siBaseUnitsCopy != siBaseUnits);

            Assert.True(siBaseUnits != nonSiBaseUnits);
            Assert.True(nonSiBaseUnits != siBaseUnits);

            Assert.True(siBaseUnits != null);
            Assert.True(null != siBaseUnits);

            BaseUnits nullBaseUnits1 = null;
            BaseUnits nullBaseUnits2 = null;

            Assert.False(nullBaseUnits1 != nullBaseUnits2);
        }

        [Fact]
        public void UndefinedHasAllBaseUnitsAsUndefined()
        {
            Assert.Equal(LengthUnit.Undefined, BaseUnits.Undefined.Length);
            Assert.Equal(MassUnit.Undefined, BaseUnits.Undefined.Mass);
            Assert.Equal(DurationUnit.Undefined, BaseUnits.Undefined.Time);
            Assert.Equal(ElectricCurrentUnit.Undefined, BaseUnits.Undefined.Current);
            Assert.Equal(TemperatureUnit.Undefined, BaseUnits.Undefined.Temperature);
            Assert.Equal(AmountOfSubstanceUnit.Undefined, BaseUnits.Undefined.Amount);
            Assert.Equal(LuminousIntensityUnit.Undefined, BaseUnits.Undefined.LuminousIntensity);
        }

        [Fact]
        public void UndefinedIsSubsetOfUndefined()
        {
            Assert.True(BaseUnits.Undefined.IsSubsetOf(BaseUnits.Undefined));
        }

        [Fact]
        public void IsSubsetOfReturnsFalseWithNull()
        {
            Assert.False(siBaseUnits.IsSubsetOf(null));
        }

        [Fact]
        public void ExistsInWorksCorrectly()
        {
            Assert.False(BaseUnits.Undefined.IsSubsetOf(siBaseUnits));
            Assert.False(siBaseUnits.IsSubsetOf(BaseUnits.Undefined));

            var meterBaseUnits = new BaseUnits(LengthUnit.Meter);
            Assert.True(meterBaseUnits.IsSubsetOf(siBaseUnits));

            // Not all units in siBaseUnits will exist in meterBaseUnits
            Assert.False(siBaseUnits.IsSubsetOf(meterBaseUnits));
        }

        [Fact]
        public void ToStringGivesExpectedResult()
        {
            var siBaseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

            Assert.Equal("[Length]: m, [Mass]: kg, [Time]: s, [Current]: A, [Temperature]: K, [Amount]: mol, [LuminousIntensity]: cd", siBaseUnits.ToString());
        }

        [Fact]
        public void IsFullyDefined_TrueIfAllBaseUnitDefined()
        {
            Assert.True(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole,
                LuminousIntensityUnit.Candela).IsFullyDefined);
        }
    
        [Fact]
        public void IsFullyDefined_FalseIfAnyBaseUnitIsUndefined()
        {
            Assert.False(new BaseUnits(mass: MassUnit.Kilogram, time: DurationUnit.Second,
                current: ElectricCurrentUnit.Ampere, temperature: TemperatureUnit.Kelvin, amount: AmountOfSubstanceUnit.Mole,
                luminousIntensity: LuminousIntensityUnit.Candela).IsFullyDefined);

            Assert.False(new BaseUnits(length: LengthUnit.Meter, time: DurationUnit.Second,
                current: ElectricCurrentUnit.Ampere, temperature: TemperatureUnit.Kelvin, amount: AmountOfSubstanceUnit.Mole,
                luminousIntensity: LuminousIntensityUnit.Candela).IsFullyDefined);

            Assert.False(new BaseUnits(length: LengthUnit.Meter, mass: MassUnit.Kilogram,
                current: ElectricCurrentUnit.Ampere, temperature: TemperatureUnit.Kelvin, amount: AmountOfSubstanceUnit.Mole,
                luminousIntensity: LuminousIntensityUnit.Candela).IsFullyDefined);

            Assert.False(new BaseUnits(length: LengthUnit.Meter, mass: MassUnit.Kilogram, time: DurationUnit.Second,
                temperature: TemperatureUnit.Kelvin, amount: AmountOfSubstanceUnit.Mole,
                luminousIntensity: LuminousIntensityUnit.Candela).IsFullyDefined);

            Assert.False(new BaseUnits(length: LengthUnit.Meter, mass: MassUnit.Kilogram, time: DurationUnit.Second,
                current: ElectricCurrentUnit.Ampere, amount: AmountOfSubstanceUnit.Mole,
                luminousIntensity: LuminousIntensityUnit.Candela).IsFullyDefined);

            Assert.False(new BaseUnits(length: LengthUnit.Meter, mass: MassUnit.Kilogram, time: DurationUnit.Second,
                current: ElectricCurrentUnit.Ampere, temperature: TemperatureUnit.Kelvin,
                luminousIntensity: LuminousIntensityUnit.Candela).IsFullyDefined);

            Assert.False(new BaseUnits(length: LengthUnit.Meter, mass: MassUnit.Kilogram, time: DurationUnit.Second,
                current: ElectricCurrentUnit.Ampere, temperature: TemperatureUnit.Kelvin, amount: AmountOfSubstanceUnit.Mole
                ).IsFullyDefined);
        }
    }
}
