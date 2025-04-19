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
    /// Test of LuminousIntensity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class LuminousIntensityTestsBase : QuantityTestsBase
    {
        protected abstract double CandelaInOneCandela { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CandelaTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(LuminousIntensityUnit unit)
        {
            return unit switch
            {
                LuminousIntensityUnit.Candela => (CandelaInOneCandela, CandelaTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { LuminousIntensityUnit.Candela },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new LuminousIntensity();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(LuminousIntensityUnit.Candela, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => new LuminousIntensity(double.PositiveInfinity, LuminousIntensityUnit.Candela));
            var exception2 = Record.Exception(() => new LuminousIntensity(double.NegativeInfinity, LuminousIntensityUnit.Candela));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => new LuminousIntensity(double.NaN, LuminousIntensityUnit.Candela));

            Assert.Null(exception);
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new LuminousIntensity(value: 1, unitSystem: null));
        }

        [Fact]
        public virtual void Ctor_SIUnitSystem_ReturnsQuantityWithSIUnits()
        {
            var quantity = new LuminousIntensity(value: 1, unitSystem: UnitSystem.SI);
            Assert.Equal(1, quantity.Value);
            Assert.True(quantity.QuantityInfo.UnitInfos.First(x => x.Value == quantity.Unit).BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public void Ctor_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => new LuminousIntensity(value: 1, unitSystem: unsupportedUnitSystem));
        }

        [Fact]
        public void LuminousIntensity_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new LuminousIntensity(1, LuminousIntensityUnit.Candela);

            QuantityInfo<LuminousIntensityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(LuminousIntensity.Zero, quantityInfo.Zero);
            Assert.Equal("LuminousIntensity", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<LuminousIntensityUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void CandelaToLuminousIntensityUnits()
        {
            LuminousIntensity candela = LuminousIntensity.FromCandela(1);
            AssertEx.EqualTolerance(CandelaInOneCandela, candela.Candela, CandelaTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = LuminousIntensity.From(1, LuminousIntensityUnit.Candela);
            AssertEx.EqualTolerance(1, quantity00.Candela, CandelaTolerance);
            Assert.Equal(LuminousIntensityUnit.Candela, quantity00.Unit);

        }

        [Fact]
        public void FromCandela_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => LuminousIntensity.FromCandela(double.PositiveInfinity));
            var exception2 = Record.Exception(() => LuminousIntensity.FromCandela(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void FromCandela_WithNanValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => LuminousIntensity.FromCandela(double.NaN));

            Assert.Null(exception);
        }

        [Fact]
        public void As()
        {
            var candela = LuminousIntensity.FromCandela(1);
            AssertEx.EqualTolerance(CandelaInOneCandela, candela.As(LuminousIntensityUnit.Candela), CandelaTolerance);
        }

        [Fact]
        public virtual void BaseUnit_HasSIBase()
        {
            var baseUnitInfo = LuminousIntensity.Info.BaseUnitInfo;
            Assert.True(baseUnitInfo.BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public virtual void As_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new LuminousIntensity(value: 1, unit: LuminousIntensity.BaseUnit);
            var expectedValue = quantity.As(LuminousIntensity.Info.GetDefaultUnit(UnitSystem.SI));

            var convertedValue = quantity.As(UnitSystem.SI);

            Assert.Equal(expectedValue, convertedValue);
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {
            var quantity = new LuminousIntensity(value: 1, unit: LuminousIntensity.BaseUnit);
            UnitSystem nullUnitSystem = null!;
            Assert.Throws<ArgumentNullException>(() => quantity.As(nullUnitSystem));
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new LuminousIntensity(value: 1, unit: LuminousIntensity.BaseUnit);
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => quantity.As(unsupportedUnitSystem));
        }

        [Fact]
        public virtual void ToUnit_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new LuminousIntensity(value: 1, unit: LuminousIntensity.BaseUnit);
            var expectedUnit = LuminousIntensity.Info.GetDefaultUnit(UnitSystem.SI);
            var expectedValue = quantity.As(expectedUnit);

            Assert.Multiple(() =>
            {
                LuminousIntensity quantityToConvert = quantity;

                LuminousIntensity convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

                Assert.Equal(expectedUnit, convertedQuantity.Unit);
                Assert.Equal(expectedValue, convertedQuantity.Value);
            }, () =>
            {
                IQuantity<LuminousIntensityUnit> quantityToConvert = quantity;

                IQuantity<LuminousIntensityUnit> convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

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
                var quantity = new LuminousIntensity(value: 1, unit: LuminousIntensity.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity<LuminousIntensityUnit> quantity = new LuminousIntensity(value: 1, unit: LuminousIntensity.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity quantity = new LuminousIntensity(value: 1, unit: LuminousIntensity.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            });
        }

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Multiple(() =>
            {
                var quantity = new LuminousIntensity(value: 1, unit: LuminousIntensity.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity<LuminousIntensityUnit> quantity = new LuminousIntensity(value: 1, unit: LuminousIntensity.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity quantity = new LuminousIntensity(value: 1, unit: LuminousIntensity.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            });
        }

        [Fact]
        public void Parse()
        {
            try
            {
                var parsed = LuminousIntensity.Parse("1 cd", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Candela, CandelaTolerance);
                Assert.Equal(LuminousIntensityUnit.Candela, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(LuminousIntensity.TryParse("1 cd", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Candela, CandelaTolerance);
                Assert.Equal(LuminousIntensityUnit.Candela, parsed.Unit);
            }

        }

        [Theory]
        [InlineData("cd", LuminousIntensityUnit.Candela)]
        public void ParseUnit_WithUsEnglishCurrentCulture(string abbreviation, LuminousIntensityUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            LuminousIntensityUnit parsedUnit = LuminousIntensity.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("cd", LuminousIntensityUnit.Candela)]
        public void ParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, LuminousIntensityUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            LuminousIntensityUnit parsedUnit = LuminousIntensity.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "cd", LuminousIntensityUnit.Candela)]
        public void ParseUnit_WithCurrentCulture(string culture, string abbreviation, LuminousIntensityUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            LuminousIntensityUnit parsedUnit = LuminousIntensity.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "cd", LuminousIntensityUnit.Candela)]
        public void ParseUnit_WithCulture(string culture, string abbreviation, LuminousIntensityUnit expectedUnit)
        {
            LuminousIntensityUnit parsedUnit = LuminousIntensity.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("cd", LuminousIntensityUnit.Candela)]
        public void TryParseUnit_WithUsEnglishCurrentCulture(string abbreviation, LuminousIntensityUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            Assert.True(LuminousIntensity.TryParseUnit(abbreviation, out LuminousIntensityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("cd", LuminousIntensityUnit.Candela)]
        public void TryParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, LuminousIntensityUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            Assert.True(LuminousIntensity.TryParseUnit(abbreviation, out LuminousIntensityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "cd", LuminousIntensityUnit.Candela)]
        public void TryParseUnit_WithCurrentCulture(string culture, string abbreviation, LuminousIntensityUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            Assert.True(LuminousIntensity.TryParseUnit(abbreviation, out LuminousIntensityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "cd", LuminousIntensityUnit.Candela)]
        public void TryParseUnit_WithCulture(string culture, string abbreviation, LuminousIntensityUnit expectedUnit)
        {
            Assert.True(LuminousIntensity.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out LuminousIntensityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(LuminousIntensityUnit unit)
        {
            var inBaseUnits = LuminousIntensity.From(1.0, LuminousIntensity.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(LuminousIntensityUnit unit)
        {
            var quantity = LuminousIntensity.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(LuminousIntensityUnit unit)
        {
            Assert.All(LuminousIntensity.Units.Where(u => u != LuminousIntensity.BaseUnit), fromUnit =>
            {
                var quantity = LuminousIntensity.From(3.0, fromUnit);
                var converted = quantity.ToUnit(unit);
                Assert.Equal(converted.Unit, unit);
            });
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(LuminousIntensityUnit unit)
        {
            var quantity = default(LuminousIntensity);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromIQuantity_ReturnsTheExpectedIQuantity(LuminousIntensityUnit unit)
        {
            var quantity = LuminousIntensity.From(3, LuminousIntensity.BaseUnit);
            LuminousIntensity expectedQuantity = quantity.ToUnit(unit);
            Assert.Multiple(() =>
            {
                IQuantity<LuminousIntensityUnit> quantityToConvert = quantity;
                IQuantity<LuminousIntensityUnit> convertedQuantity = quantityToConvert.ToUnit(unit);
                Assert.Equal(unit, convertedQuantity.Unit);
            }, () =>
            {
                IQuantity quantityToConvert = quantity;
                IQuantity convertedQuantity = quantityToConvert.ToUnit(unit);
                Assert.Equal(unit, convertedQuantity.Unit);
            });
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            LuminousIntensity candela = LuminousIntensity.FromCandela(1);
            AssertEx.EqualTolerance(1, LuminousIntensity.FromCandela(candela.Candela).Candela, CandelaTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            LuminousIntensity v = LuminousIntensity.FromCandela(1);
            AssertEx.EqualTolerance(-1, -v.Candela, CandelaTolerance);
            AssertEx.EqualTolerance(2, (LuminousIntensity.FromCandela(3)-v).Candela, CandelaTolerance);
            AssertEx.EqualTolerance(2, (v + v).Candela, CandelaTolerance);
            AssertEx.EqualTolerance(10, (v*10).Candela, CandelaTolerance);
            AssertEx.EqualTolerance(10, (10*v).Candela, CandelaTolerance);
            AssertEx.EqualTolerance(2, (LuminousIntensity.FromCandela(10)/5).Candela, CandelaTolerance);
            AssertEx.EqualTolerance(2, LuminousIntensity.FromCandela(10)/LuminousIntensity.FromCandela(5), CandelaTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            LuminousIntensity oneCandela = LuminousIntensity.FromCandela(1);
            LuminousIntensity twoCandela = LuminousIntensity.FromCandela(2);

            Assert.True(oneCandela < twoCandela);
            Assert.True(oneCandela <= twoCandela);
            Assert.True(twoCandela > oneCandela);
            Assert.True(twoCandela >= oneCandela);

            Assert.False(oneCandela > twoCandela);
            Assert.False(oneCandela >= twoCandela);
            Assert.False(twoCandela < oneCandela);
            Assert.False(twoCandela <= oneCandela);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            LuminousIntensity candela = LuminousIntensity.FromCandela(1);
            Assert.Equal(0, candela.CompareTo(candela));
            Assert.True(candela.CompareTo(LuminousIntensity.Zero) > 0);
            Assert.True(LuminousIntensity.Zero.CompareTo(candela) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            LuminousIntensity candela = LuminousIntensity.FromCandela(1);
            Assert.Throws<ArgumentException>(() => candela.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            LuminousIntensity candela = LuminousIntensity.FromCandela(1);
            Assert.Throws<ArgumentNullException>(() => candela.CompareTo(null));
        }

        [Theory]
        [InlineData(1, LuminousIntensityUnit.Candela, 1, LuminousIntensityUnit.Candela, true)]  // Same value and unit.
        [InlineData(1, LuminousIntensityUnit.Candela, 2, LuminousIntensityUnit.Candela, false)] // Different value.
        [InlineData(2, LuminousIntensityUnit.Candela, 1, LuminousIntensityUnit.Candela, false)] // Different value and unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, LuminousIntensityUnit unitA, double valueB, LuminousIntensityUnit unitB, bool expectEqual)
        {
            var a = new LuminousIntensity(valueA, unitA);
            var b = new LuminousIntensity(valueB, unitB);

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
            var a = LuminousIntensity.Zero;

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
            var v = LuminousIntensity.FromCandela(1);
            Assert.True(v.Equals(LuminousIntensity.FromCandela(1), CandelaTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(LuminousIntensity.Zero, CandelaTolerance, ComparisonType.Relative));
            Assert.True(LuminousIntensity.FromCandela(100).Equals(LuminousIntensity.FromCandela(120), 0.3, ComparisonType.Relative));
            Assert.False(LuminousIntensity.FromCandela(100).Equals(LuminousIntensity.FromCandela(120), 0.1, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = LuminousIntensity.FromCandela(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(LuminousIntensity.FromCandela(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            LuminousIntensity candela = LuminousIntensity.FromCandela(1);
            Assert.False(candela.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            LuminousIntensity candela = LuminousIntensity.FromCandela(1);
            Assert.False(candela.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(LuminousIntensityUnit)).Cast<LuminousIntensityUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(LuminousIntensity.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            using var _ = new CultureScope("en-US");
            Assert.Equal("1 cd", new LuminousIntensity(1, LuminousIntensityUnit.Candela).ToString());
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 cd", new LuminousIntensity(1, LuminousIntensityUnit.Candela).ToString(null, swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var _ = new CultureScope(CultureInfo.InvariantCulture);
            Assert.Equal("0.1 cd", new LuminousIntensity(0.123456, LuminousIntensityUnit.Candela).ToString("s1"));
            Assert.Equal("0.12 cd", new LuminousIntensity(0.123456, LuminousIntensityUnit.Candela).ToString("s2"));
            Assert.Equal("0.123 cd", new LuminousIntensity(0.123456, LuminousIntensityUnit.Candela).ToString("s3"));
            Assert.Equal("0.1235 cd", new LuminousIntensity(0.123456, LuminousIntensityUnit.Candela).ToString("s4"));
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 cd", new LuminousIntensity(0.123456, LuminousIntensityUnit.Candela).ToString("s1", culture));
            Assert.Equal("0.12 cd", new LuminousIntensity(0.123456, LuminousIntensityUnit.Candela).ToString("s2", culture));
            Assert.Equal("0.123 cd", new LuminousIntensity(0.123456, LuminousIntensityUnit.Candela).ToString("s3", culture));
            Assert.Equal("0.1235 cd", new LuminousIntensity(0.123456, LuminousIntensityUnit.Candela).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = LuminousIntensity.FromCandela(1.0);
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
            var quantity = LuminousIntensity.FromCandela(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = LuminousIntensity.FromCandela(1.0);
            Assert.Equal(new {LuminousIntensity.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = LuminousIntensity.FromCandela(value);
            Assert.Equal(LuminousIntensity.FromCandela(-value), -quantity);
        }
    }
}
