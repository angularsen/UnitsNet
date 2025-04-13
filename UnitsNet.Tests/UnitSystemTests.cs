﻿// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class UnitSystemTests
    {
        [Fact]
        public void ConstructorImplementedProperly()
        {
            var baseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

            var unitSystem = new UnitSystem(baseUnits);

            Assert.Equal(unitSystem.BaseUnits, baseUnits);
        }

        [Fact]
        public void ConstructorThrowsArgumentNullExceptionForNullBaseUnits()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitSystem(null!));
        }

        [Theory]
        [InlineData(null, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, null, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Kilogram, null, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second, null, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Ampere, null, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, null, LuminousIntensityUnit.Candela)]
        [InlineData(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, null)]
        public void ConstructorSupportPartialDimensions(LengthUnit? length, MassUnit? mass, DurationUnit? time, ElectricCurrentUnit? current,
            TemperatureUnit? temperature, AmountOfSubstanceUnit? amount, LuminousIntensityUnit? luminousIntensity)
        {
            var baseUnits = new BaseUnits(length, mass, time, current, temperature, amount, luminousIntensity);
            var unitSystem = new UnitSystem(baseUnits);

            Assert.Equal(unitSystem.BaseUnits, baseUnits);
        }

        [Fact]
        public void ConstructorThrowsArgumentExceptionWithUndefinedUnits()
        {
            Assert.Throws<ArgumentException>(() => new UnitSystem(BaseUnits.Undefined));
        }

        [Fact]
        public void EqualsObjectIsImplementedCorrectly()
        {
            var unitSystem1 = new UnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem2 = new UnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem3 = new UnitSystem(new BaseUnits(LengthUnit.Foot, MassUnit.Pound, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.DegreeFahrenheit, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            Assert.True(unitSystem1.Equals((object)unitSystem2));
            Assert.False(unitSystem1.Equals((object)unitSystem3));

            // ReSharper disable once SuspiciousTypeConversion.Global
            Assert.False(unitSystem1.Equals("Some object."));
            Assert.False(unitSystem1.Equals((IFormatProvider?)null));
        }

        [Fact]
        public void EqualsUnitSystemIsImplementedCorrectly()
        {
            var unitSystem1 = new UnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem2 = new UnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem3 = new UnitSystem(new BaseUnits(LengthUnit.Foot, MassUnit.Pound, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.DegreeFahrenheit, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            Assert.True(unitSystem1.Equals(unitSystem2));
            Assert.True(unitSystem2.Equals(unitSystem1));

            Assert.False(unitSystem1.Equals(unitSystem3));
            Assert.False(unitSystem3.Equals(unitSystem1));

            Assert.False(unitSystem1.Equals(null));
        }

        [Fact]
        public void EqualityOperatorIsImplementedCorrectly()
        {
            var unitSystem1 = new UnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem2 = new UnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem3 = new UnitSystem(new BaseUnits(LengthUnit.Foot, MassUnit.Pound, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.DegreeFahrenheit, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            Assert.True(unitSystem1 == unitSystem2);
            Assert.True(unitSystem2 == unitSystem1);

            Assert.False(unitSystem1 == unitSystem3);
            Assert.False(unitSystem3 == unitSystem1);

            Assert.False(unitSystem1 == null);
            Assert.False(null == unitSystem1);

            UnitSystem? nullUnitSystem1 = null;
            UnitSystem? nullUnitSystem2 = null;

            Assert.True(nullUnitSystem1 == nullUnitSystem2);
        }

        [Fact]
        public void InequalityOperatorIsImplementedCorrectly()
        {
            var unitSystem1 = new UnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem2 = new UnitSystem(new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            var unitSystem3 = new UnitSystem(new BaseUnits(LengthUnit.Foot, MassUnit.Pound, DurationUnit.Second,
                ElectricCurrentUnit.Ampere, TemperatureUnit.DegreeFahrenheit, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela));

            Assert.False(unitSystem1 != unitSystem2);
            Assert.False(unitSystem2 != unitSystem1);

            Assert.True(unitSystem1 != unitSystem3);
            Assert.True(unitSystem3 != unitSystem1);

            Assert.True(unitSystem1 != null);
            Assert.True(null != unitSystem1);

            UnitSystem? nullUnitSystem1 = null;
            UnitSystem? nullUnitSystem2 = null;

            Assert.False(nullUnitSystem1 != nullUnitSystem2);
        }

        [Fact]
        public void GetHashCodeIsImplementedCorrectly()
        {
            var baseUnits1 = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin,
                AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);
            var baseUnits2 = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second, ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin,
                AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

            var unitSystem1 = new UnitSystem(baseUnits1);
            var unitSystem2 = new UnitSystem(baseUnits2);

            Assert.Equal(unitSystem1.GetHashCode(), unitSystem2.GetHashCode());
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
    }
}
