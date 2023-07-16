// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class BaseUnitsTests
    {
        private static readonly BaseUnits SIBaseUnits = new(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

        private static readonly BaseUnits SIBaseUnitsCopy = new(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

        private static readonly BaseUnits NonSiBaseUnits = new(LengthUnit.Foot, MassUnit.Pound, DurationUnit.Second,
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
            Assert.True(SIBaseUnits.Equals((object)SIBaseUnitsCopy));
            Assert.False(SIBaseUnits.Equals((object)NonSiBaseUnits));

            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.False(SIBaseUnits.Equals("Some object."));
            Assert.False(SIBaseUnits.Equals((IFormatProvider?)null));
        }

        [Fact]
        public void EqualsBaseUnitsIsImplementedCorrectly()
        {
            Assert.True(SIBaseUnits.Equals(SIBaseUnitsCopy));
            Assert.True(SIBaseUnitsCopy.Equals(SIBaseUnits));

            Assert.False(SIBaseUnits.Equals(NonSiBaseUnits));
            Assert.False(NonSiBaseUnits.Equals(SIBaseUnits));

            Assert.False(SIBaseUnits.Equals(null!));
        }

        [Fact]
        public void EqualityOperatorIsImplementedCorrectly()
        {
            Assert.True(SIBaseUnits == SIBaseUnitsCopy);
            Assert.True(SIBaseUnitsCopy == SIBaseUnits);

            Assert.False(SIBaseUnits == NonSiBaseUnits);
            Assert.False(NonSiBaseUnits == SIBaseUnits);

            Assert.False(SIBaseUnits == null);
            Assert.False(null == SIBaseUnits);

            BaseUnits? nullBaseUnits1 = null;
            BaseUnits? nullBaseUnits2 = null;

            Assert.True(nullBaseUnits1 == nullBaseUnits2);
        }

        [Fact]
        public void InequalityOperatorIsImplementedCorrectly()
        {
            Assert.False(SIBaseUnits != SIBaseUnitsCopy);
            Assert.False(SIBaseUnitsCopy != SIBaseUnits);

            Assert.True(SIBaseUnits != NonSiBaseUnits);
            Assert.True(NonSiBaseUnits != SIBaseUnits);

            Assert.True(SIBaseUnits != null!);
            Assert.True(null! != SIBaseUnits!);

            BaseUnits? nullBaseUnits1 = null;
            BaseUnits? nullBaseUnits2 = null;

            Assert.False(nullBaseUnits1 != nullBaseUnits2);
        }

        [Fact]
        public void UndefinedHasAllBaseUnitsAsUndefined()
        {
            Assert.Null(BaseUnits.Undefined.Length);
            Assert.Null(BaseUnits.Undefined.Mass);
            Assert.Null(BaseUnits.Undefined.Time);
            Assert.Null(BaseUnits.Undefined.Current);
            Assert.Null(BaseUnits.Undefined.Temperature);
            Assert.Null(BaseUnits.Undefined.Amount);
            Assert.Null(BaseUnits.Undefined.LuminousIntensity);
        }

        [Fact]
        public void UndefinedIsSubsetOfUndefined()
        {
            Assert.True(BaseUnits.Undefined.IsSubsetOf(BaseUnits.Undefined));
        }

        [Fact]
        public void IsSubsetOfReturnsFalseWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => SIBaseUnits.IsSubsetOf(null!));
        }

        [Fact]
        public void ExistsInWorksCorrectly()
        {
            Assert.False(BaseUnits.Undefined.IsSubsetOf(SIBaseUnits));
            Assert.False(SIBaseUnits.IsSubsetOf(BaseUnits.Undefined));

            var meterBaseUnits = new BaseUnits(LengthUnit.Meter);
            Assert.True(meterBaseUnits.IsSubsetOf(SIBaseUnits));

            // Not all units in siBaseUnits will exist in meterBaseUnits
            Assert.False(SIBaseUnits.IsSubsetOf(meterBaseUnits));
        }

        [Fact]
        public void ToStringGivesExpectedResult()
        {
            var siBaseUnits = new BaseUnits(LengthUnit.Meter,
                MassUnit.Kilogram,
                DurationUnit.Second,
                ElectricCurrentUnit.Ampere,
                TemperatureUnit.Kelvin,
                AmountOfSubstanceUnit.Mole,
                LuminousIntensityUnit.Candela);

            UnitAbbreviationsCache cache = UnitsNetSetup.Default.UnitAbbreviations;
            var m = cache.GetDefaultAbbreviation(LengthUnit.Meter);
            var kg = cache.GetDefaultAbbreviation(MassUnit.Kilogram);
            var s = cache.GetDefaultAbbreviation(DurationUnit.Second);
            var A = cache.GetDefaultAbbreviation(ElectricCurrentUnit.Ampere);
            var K = cache.GetDefaultAbbreviation(TemperatureUnit.Kelvin);
            var mol = cache.GetDefaultAbbreviation(AmountOfSubstanceUnit.Mole);
            var cd = cache.GetDefaultAbbreviation(LuminousIntensityUnit.Candela);

            Assert.Equal($"[Length]: {m}, [Mass]: {kg}, [Time]: {s}, [Current]: {A}, [Temperature]: {K}, [Amount]: {mol}, [LuminousIntensity]: {cd}", siBaseUnits.ToString());
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
