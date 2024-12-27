//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run generate-code.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using UnitsNet.Tests.Helpers;
using UnitsNet.Tests.TestsBase;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of ElectricField.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricFieldTestsBase : QuantityTestsBase
    {
        protected abstract double VoltsPerMeterInOneVoltPerMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double VoltsPerMeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(ElectricFieldUnit unit)
        {
            return unit switch
            {
                ElectricFieldUnit.VoltPerMeter => (VoltsPerMeterInOneVoltPerMeter, VoltsPerMeterTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { ElectricFieldUnit.VoltPerMeter },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ElectricField();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ElectricFieldUnit.VoltPerMeter, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => new ElectricField(double.PositiveInfinity, ElectricFieldUnit.VoltPerMeter));
            var exception2 = Record.Exception(() => new ElectricField(double.NegativeInfinity, ElectricFieldUnit.VoltPerMeter));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => new ElectricField(double.NaN, ElectricFieldUnit.VoltPerMeter));

            Assert.Null(exception);
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ElectricField(value: 1, unitSystem: null));
        }

        [Fact]
        public virtual void Ctor_SIUnitSystem_ReturnsQuantityWithSIUnits()
        {
            var quantity = new ElectricField(value: 1, unitSystem: UnitSystem.SI);
            Assert.Equal(1, quantity.Value);
            Assert.True(quantity.QuantityInfo.UnitInfos.First(x => x.Value == quantity.Unit).BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public void Ctor_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            // simulating a combination of units that won't match anything
            var unsupportedUnitSystem = new UnitSystem(new BaseUnits(
                (LengthUnit)(-1), (MassUnit)(-1), (DurationUnit)(-1), (ElectricCurrentUnit)(-1), (TemperatureUnit)(-1), (AmountOfSubstanceUnit)(-1), (LuminousIntensityUnit)(-1)));
            Assert.Throws<ArgumentException>(() => new ElectricField(value: 1, unitSystem: unsupportedUnitSystem));
        }

        [Fact]
        public void ElectricField_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ElectricField(1, ElectricFieldUnit.VoltPerMeter);

            QuantityInfo<ElectricFieldUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ElectricField.Zero, quantityInfo.Zero);
            Assert.Equal("ElectricField", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<ElectricFieldUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void VoltPerMeterToElectricFieldUnits()
        {
            ElectricField voltpermeter = ElectricField.FromVoltsPerMeter(1);
            AssertEx.EqualTolerance(VoltsPerMeterInOneVoltPerMeter, voltpermeter.VoltsPerMeter, VoltsPerMeterTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ElectricField.From(1, ElectricFieldUnit.VoltPerMeter);
            AssertEx.EqualTolerance(1, quantity00.VoltsPerMeter, VoltsPerMeterTolerance);
            Assert.Equal(ElectricFieldUnit.VoltPerMeter, quantity00.Unit);

        }

        [Fact]
        public void FromVoltsPerMeter_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => ElectricField.FromVoltsPerMeter(double.PositiveInfinity));
            var exception2 = Record.Exception(() => ElectricField.FromVoltsPerMeter(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void FromVoltsPerMeter_WithNanValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => ElectricField.FromVoltsPerMeter(double.NaN));

            Assert.Null(exception);
        }

        [Fact]
        public void As()
        {
            var voltpermeter = ElectricField.FromVoltsPerMeter(1);
            AssertEx.EqualTolerance(VoltsPerMeterInOneVoltPerMeter, voltpermeter.As(ElectricFieldUnit.VoltPerMeter), VoltsPerMeterTolerance);
        }

        [Fact]
        public virtual void BaseUnit_HasSIBase()
        {
            var baseUnitInfo = ElectricField.Info.BaseUnitInfo;
            Assert.True(baseUnitInfo.BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public virtual void As_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new ElectricField(value: 1, unit: ElectricField.BaseUnit);
            var expectedValue = quantity.As(ElectricField.Info.GetDefaultUnit(UnitSystem.SI));

            var convertedValue = quantity.As(UnitSystem.SI);

            Assert.Equal(expectedValue, convertedValue);
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {
            var quantity = new ElectricField(value: 1, unit: ElectricField.BaseUnit);
            UnitSystem nullUnitSystem = null!;
            Assert.Throws<ArgumentNullException>(() => quantity.As(nullUnitSystem));
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new ElectricField(value: 1, unit: ElectricField.BaseUnit);
            // simulating a combination of units that won't match anything
            var unsupportedUnitSystem = new UnitSystem(new BaseUnits(
                (LengthUnit)(-1), (MassUnit)(-1), (DurationUnit)(-1), (ElectricCurrentUnit)(-1), (TemperatureUnit)(-1), (AmountOfSubstanceUnit)(-1), (LuminousIntensityUnit)(-1)));
            Assert.Throws<ArgumentException>(() => quantity.As(unsupportedUnitSystem));
        }

        [Fact]
        public virtual void ToUnit_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new ElectricField(value: 1, unit: ElectricField.BaseUnit);
            var expectedUnit = ElectricField.Info.GetDefaultUnit(UnitSystem.SI);
            var expectedValue = quantity.As(expectedUnit);

            Assert.Multiple(() =>
            {
                ElectricField quantityToConvert = quantity;

                ElectricField convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

                Assert.Equal(expectedUnit, convertedQuantity.Unit);
                Assert.Equal(expectedValue, convertedQuantity.Value);
            }, () =>
            {
                IQuantity<ElectricFieldUnit> quantityToConvert = quantity;

                IQuantity<ElectricFieldUnit> convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

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
                var quantity = new ElectricField(value: 1, unit: ElectricField.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity<ElectricFieldUnit> quantity = new ElectricField(value: 1, unit: ElectricField.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity quantity = new ElectricField(value: 1, unit: ElectricField.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            });
        }

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            // simulating a combination of units that won't match anything
            var unsupportedUnitSystem = new UnitSystem(new BaseUnits(
                (LengthUnit)(-1), (MassUnit)(-1), (DurationUnit)(-1), (ElectricCurrentUnit)(-1), (TemperatureUnit)(-1), (AmountOfSubstanceUnit)(-1), (LuminousIntensityUnit)(-1)));
            Assert.Multiple(() =>
            {
                var quantity = new ElectricField(value: 1, unit: ElectricField.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity<ElectricFieldUnit> quantity = new ElectricField(value: 1, unit: ElectricField.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity quantity = new ElectricField(value: 1, unit: ElectricField.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            });
        }

        [Fact]
        public void Parse()
        {
            try
            {
                var parsed = ElectricField.Parse("1 V/m", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.VoltsPerMeter, VoltsPerMeterTolerance);
                Assert.Equal(ElectricFieldUnit.VoltPerMeter, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(ElectricField.TryParse("1 V/m", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.VoltsPerMeter, VoltsPerMeterTolerance);
                Assert.Equal(ElectricFieldUnit.VoltPerMeter, parsed.Unit);
            }

        }

        [Theory]
        [InlineData("V/m", ElectricFieldUnit.VoltPerMeter)]
        public void ParseUnit_WithUsEnglishCurrentCulture(string abbreviation, ElectricFieldUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            ElectricFieldUnit parsedUnit = ElectricField.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("V/m", ElectricFieldUnit.VoltPerMeter)]
        public void ParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, ElectricFieldUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            ElectricFieldUnit parsedUnit = ElectricField.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "V/m", ElectricFieldUnit.VoltPerMeter)]
        public void ParseUnit_WithCurrentCulture(string culture, string abbreviation, ElectricFieldUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            ElectricFieldUnit parsedUnit = ElectricField.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "V/m", ElectricFieldUnit.VoltPerMeter)]
        public void ParseUnit_WithCulture(string culture, string abbreviation, ElectricFieldUnit expectedUnit)
        {
            ElectricFieldUnit parsedUnit = ElectricField.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("V/m", ElectricFieldUnit.VoltPerMeter)]
        public void TryParseUnit_WithUsEnglishCurrentCulture(string abbreviation, ElectricFieldUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            Assert.True(ElectricField.TryParseUnit(abbreviation, out ElectricFieldUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("V/m", ElectricFieldUnit.VoltPerMeter)]
        public void TryParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, ElectricFieldUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            Assert.True(ElectricField.TryParseUnit(abbreviation, out ElectricFieldUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "V/m", ElectricFieldUnit.VoltPerMeter)]
        public void TryParseUnit_WithCurrentCulture(string culture, string abbreviation, ElectricFieldUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            Assert.True(ElectricField.TryParseUnit(abbreviation, out ElectricFieldUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "V/m", ElectricFieldUnit.VoltPerMeter)]
        public void TryParseUnit_WithCulture(string culture, string abbreviation, ElectricFieldUnit expectedUnit)
        {
            Assert.True(ElectricField.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out ElectricFieldUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(ElectricFieldUnit unit)
        {
            var inBaseUnits = ElectricField.From(1.0, ElectricField.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(ElectricFieldUnit unit)
        {
            var quantity = ElectricField.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory(Skip = "Multiple units required")]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(ElectricFieldUnit unit)
        {
            // See if there is a unit available that is not the base unit, fallback to base unit if it has only a single unit.
            var fromUnit = ElectricField.Units.First(u => u != ElectricField.BaseUnit);

            var quantity = ElectricField.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(ElectricFieldUnit unit)
        {
            var quantity = default(ElectricField);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ElectricField voltpermeter = ElectricField.FromVoltsPerMeter(1);
            AssertEx.EqualTolerance(1, ElectricField.FromVoltsPerMeter(voltpermeter.VoltsPerMeter).VoltsPerMeter, VoltsPerMeterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ElectricField v = ElectricField.FromVoltsPerMeter(1);
            AssertEx.EqualTolerance(-1, -v.VoltsPerMeter, VoltsPerMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricField.FromVoltsPerMeter(3)-v).VoltsPerMeter, VoltsPerMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).VoltsPerMeter, VoltsPerMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).VoltsPerMeter, VoltsPerMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).VoltsPerMeter, VoltsPerMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricField.FromVoltsPerMeter(10)/5).VoltsPerMeter, VoltsPerMeterTolerance);
            AssertEx.EqualTolerance(2, ElectricField.FromVoltsPerMeter(10)/ElectricField.FromVoltsPerMeter(5), VoltsPerMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ElectricField oneVoltPerMeter = ElectricField.FromVoltsPerMeter(1);
            ElectricField twoVoltsPerMeter = ElectricField.FromVoltsPerMeter(2);

            Assert.True(oneVoltPerMeter < twoVoltsPerMeter);
            Assert.True(oneVoltPerMeter <= twoVoltsPerMeter);
            Assert.True(twoVoltsPerMeter > oneVoltPerMeter);
            Assert.True(twoVoltsPerMeter >= oneVoltPerMeter);

            Assert.False(oneVoltPerMeter > twoVoltsPerMeter);
            Assert.False(oneVoltPerMeter >= twoVoltsPerMeter);
            Assert.False(twoVoltsPerMeter < oneVoltPerMeter);
            Assert.False(twoVoltsPerMeter <= oneVoltPerMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ElectricField voltpermeter = ElectricField.FromVoltsPerMeter(1);
            Assert.Equal(0, voltpermeter.CompareTo(voltpermeter));
            Assert.True(voltpermeter.CompareTo(ElectricField.Zero) > 0);
            Assert.True(ElectricField.Zero.CompareTo(voltpermeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricField voltpermeter = ElectricField.FromVoltsPerMeter(1);
            Assert.Throws<ArgumentException>(() => voltpermeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ElectricField voltpermeter = ElectricField.FromVoltsPerMeter(1);
            Assert.Throws<ArgumentNullException>(() => voltpermeter.CompareTo(null));
        }

        [Theory]
        [InlineData(1, ElectricFieldUnit.VoltPerMeter, 1, ElectricFieldUnit.VoltPerMeter, true)]  // Same value and unit.
        [InlineData(1, ElectricFieldUnit.VoltPerMeter, 2, ElectricFieldUnit.VoltPerMeter, false)] // Different value.
        [InlineData(2, ElectricFieldUnit.VoltPerMeter, 1, ElectricFieldUnit.VoltPerMeter, false)] // Different value and unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, ElectricFieldUnit unitA, double valueB, ElectricFieldUnit unitB, bool expectEqual)
        {
            var a = new ElectricField(valueA, unitA);
            var b = new ElectricField(valueB, unitB);

            // Operator overloads.
            Assert.Equal(expectEqual, a == b);
            Assert.Equal(expectEqual, b == a);
            Assert.Equal(!expectEqual, a != b);
            Assert.Equal(!expectEqual, b != a);

            // IEquatable<T>
            Assert.Equal(expectEqual, a.Equals(b));
            Assert.Equal(expectEqual, b.Equals(a));

            // IEquatable
            Assert.Equal(expectEqual, a.Equals((object)b));
            Assert.Equal(expectEqual, b.Equals((object)a));
        }

        [Fact]
        public void Equals_Null_ReturnsFalse()
        {
            var a = ElectricField.Zero;

            Assert.False(a.Equals((object)null));

            // "The result of the expression is always 'false'..."
            #pragma warning disable CS8073
            Assert.False(a == null);
            Assert.False(null == a);
            Assert.True(a != null);
            Assert.True(null != a);
            #pragma warning restore CS8073
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = ElectricField.FromVoltsPerMeter(1);
            Assert.True(v.Equals(ElectricField.FromVoltsPerMeter(1), VoltsPerMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ElectricField.Zero, VoltsPerMeterTolerance, ComparisonType.Relative));
            Assert.True(ElectricField.FromVoltsPerMeter(100).Equals(ElectricField.FromVoltsPerMeter(120), 0.3, ComparisonType.Relative));
            Assert.False(ElectricField.FromVoltsPerMeter(100).Equals(ElectricField.FromVoltsPerMeter(120), 0.1, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = ElectricField.FromVoltsPerMeter(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(ElectricField.FromVoltsPerMeter(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricField voltpermeter = ElectricField.FromVoltsPerMeter(1);
            Assert.False(voltpermeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricField voltpermeter = ElectricField.FromVoltsPerMeter(1);
            Assert.False(voltpermeter.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ElectricFieldUnit)).Cast<ElectricFieldUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ElectricField.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 V/m", new ElectricField(1, ElectricFieldUnit.VoltPerMeter).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = prevCulture;
            }
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 V/m", new ElectricField(1, ElectricFieldUnit.VoltPerMeter).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 V/m", new ElectricField(0.123456, ElectricFieldUnit.VoltPerMeter).ToString("s1"));
                Assert.Equal("0.12 V/m", new ElectricField(0.123456, ElectricFieldUnit.VoltPerMeter).ToString("s2"));
                Assert.Equal("0.123 V/m", new ElectricField(0.123456, ElectricFieldUnit.VoltPerMeter).ToString("s3"));
                Assert.Equal("0.1235 V/m", new ElectricField(0.123456, ElectricFieldUnit.VoltPerMeter).ToString("s4"));
            }
            finally
            {
                CultureInfo.CurrentCulture = oldCulture;
            }
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 V/m", new ElectricField(0.123456, ElectricFieldUnit.VoltPerMeter).ToString("s1", culture));
            Assert.Equal("0.12 V/m", new ElectricField(0.123456, ElectricFieldUnit.VoltPerMeter).ToString("s2", culture));
            Assert.Equal("0.123 V/m", new ElectricField(0.123456, ElectricFieldUnit.VoltPerMeter).ToString("s3", culture));
            Assert.Equal("0.1235 V/m", new ElectricField(0.123456, ElectricFieldUnit.VoltPerMeter).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            CultureInfo formatProvider = cultureName == null
                ? null
                : CultureInfo.GetCultureInfo(cultureName);

            Assert.Equal(quantity.ToString("G", formatProvider), quantity.ToString(null, formatProvider));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("g")]
        public void ToString_NullProvider_EqualsCurrentCulture(string format)
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(ElectricField)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(ElectricFieldUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal(ElectricField.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal(ElectricField.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = ElectricField.FromVoltsPerMeter(1.0);
            Assert.Equal(new {ElectricField.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = ElectricField.FromVoltsPerMeter(value);
            Assert.Equal(ElectricField.FromVoltsPerMeter(-value), -quantity);
        }
    }
}
