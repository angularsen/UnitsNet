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
    /// Test of RelativeHumidity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class RelativeHumidityTestsBase : QuantityTestsBase
    {
        protected abstract double PercentInOnePercent { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double PercentTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(RelativeHumidityUnit unit)
        {
            return unit switch
            {
                RelativeHumidityUnit.Percent => (PercentInOnePercent, PercentTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { RelativeHumidityUnit.Percent },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new RelativeHumidity();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(RelativeHumidityUnit.Percent, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => new RelativeHumidity(double.PositiveInfinity, RelativeHumidityUnit.Percent));
            var exception2 = Record.Exception(() => new RelativeHumidity(double.NegativeInfinity, RelativeHumidityUnit.Percent));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => new RelativeHumidity(double.NaN, RelativeHumidityUnit.Percent));

            Assert.Null(exception);
        }

        [Fact]
        public void RelativeHumidity_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new RelativeHumidity(1, RelativeHumidityUnit.Percent);

            QuantityInfo<RelativeHumidityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(RelativeHumidity.Zero, quantityInfo.Zero);
            Assert.Equal("RelativeHumidity", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<RelativeHumidityUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void PercentToRelativeHumidityUnits()
        {
            RelativeHumidity percent = RelativeHumidity.FromPercent(1);
            AssertEx.EqualTolerance(PercentInOnePercent, percent.Percent, PercentTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = RelativeHumidity.From(1, RelativeHumidityUnit.Percent);
            AssertEx.EqualTolerance(1, quantity00.Percent, PercentTolerance);
            Assert.Equal(RelativeHumidityUnit.Percent, quantity00.Unit);

        }

        [Fact]
        public void FromPercent_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => RelativeHumidity.FromPercent(double.PositiveInfinity));
            var exception2 = Record.Exception(() => RelativeHumidity.FromPercent(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void FromPercent_WithNanValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => RelativeHumidity.FromPercent(double.NaN));

            Assert.Null(exception);
        }

        [Fact]
        public void As()
        {
            var percent = RelativeHumidity.FromPercent(1);
            AssertEx.EqualTolerance(PercentInOnePercent, percent.As(RelativeHumidityUnit.Percent), PercentTolerance);
        }

        [Fact]
        public void As_UnitSystem_ReturnsValueInDimensionlessUnit()
        {
            var quantity = new RelativeHumidity(value: 1, unit: RelativeHumidityUnit.Percent);

            var convertedValue = quantity.As(UnitSystem.SI);
            
            Assert.Equal(quantity.Value, convertedValue);
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {
            var quantity = new RelativeHumidity(value: 1, unit: RelativeHumidity.BaseUnit);
            UnitSystem nullUnitSystem = null!;
            Assert.Throws<ArgumentNullException>(() => quantity.As(nullUnitSystem));
        }

        [Fact]
        public void ToUnitSystem_ReturnsValueInDimensionlessUnit()
        {
            Assert.Multiple(() =>
            {
                var quantity = new RelativeHumidity(value: 1, unit: RelativeHumidityUnit.Percent);

                RelativeHumidity convertedQuantity = quantity.ToUnit(UnitSystem.SI);

                Assert.Equal(RelativeHumidityUnit.Percent, convertedQuantity.Unit);
                Assert.Equal(quantity.Value, convertedQuantity.Value);
            }, () =>
            {
                IQuantity<RelativeHumidityUnit> quantity = new RelativeHumidity(value: 1, unit: RelativeHumidityUnit.Percent);

                IQuantity<RelativeHumidityUnit> convertedQuantity = quantity.ToUnit(UnitSystem.SI);

                Assert.Equal(RelativeHumidityUnit.Percent, convertedQuantity.Unit);
                Assert.Equal(quantity.Value, convertedQuantity.Value);
            }, () =>
            {
                IQuantity quantity = new RelativeHumidity(value: 1, unit: RelativeHumidityUnit.Percent);

                IQuantity convertedQuantity = quantity.ToUnit(UnitSystem.SI);

                Assert.Equal(RelativeHumidityUnit.Percent, convertedQuantity.Unit);
                Assert.Equal(quantity.Value, convertedQuantity.Value);
            });
        }

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {
            UnitSystem nullUnitSystem = null!;
            Assert.Multiple(() => 
            {
                var quantity = new RelativeHumidity(value: 1, unit: RelativeHumidity.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity<RelativeHumidityUnit> quantity = new RelativeHumidity(value: 1, unit: RelativeHumidity.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity quantity = new RelativeHumidity(value: 1, unit: RelativeHumidity.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            });
        }

        [Fact]
        public void Parse()
        {
            try
            {
                var parsed = RelativeHumidity.Parse("1 %RH", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Percent, PercentTolerance);
                Assert.Equal(RelativeHumidityUnit.Percent, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(RelativeHumidity.TryParse("1 %RH", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Percent, PercentTolerance);
                Assert.Equal(RelativeHumidityUnit.Percent, parsed.Unit);
            }

        }

        [Theory]
        [InlineData("%RH", RelativeHumidityUnit.Percent)]
        public void ParseUnit_WithUsEnglishCurrentCulture(string abbreviation, RelativeHumidityUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            RelativeHumidityUnit parsedUnit = RelativeHumidity.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("%RH", RelativeHumidityUnit.Percent)]
        public void ParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, RelativeHumidityUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            RelativeHumidityUnit parsedUnit = RelativeHumidity.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "%RH", RelativeHumidityUnit.Percent)]
        public void ParseUnit_WithCurrentCulture(string culture, string abbreviation, RelativeHumidityUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            RelativeHumidityUnit parsedUnit = RelativeHumidity.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "%RH", RelativeHumidityUnit.Percent)]
        public void ParseUnit_WithCulture(string culture, string abbreviation, RelativeHumidityUnit expectedUnit)
        {
            RelativeHumidityUnit parsedUnit = RelativeHumidity.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("%RH", RelativeHumidityUnit.Percent)]
        public void TryParseUnit_WithUsEnglishCurrentCulture(string abbreviation, RelativeHumidityUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            Assert.True(RelativeHumidity.TryParseUnit(abbreviation, out RelativeHumidityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("%RH", RelativeHumidityUnit.Percent)]
        public void TryParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, RelativeHumidityUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            Assert.True(RelativeHumidity.TryParseUnit(abbreviation, out RelativeHumidityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "%RH", RelativeHumidityUnit.Percent)]
        public void TryParseUnit_WithCurrentCulture(string culture, string abbreviation, RelativeHumidityUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            Assert.True(RelativeHumidity.TryParseUnit(abbreviation, out RelativeHumidityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "%RH", RelativeHumidityUnit.Percent)]
        public void TryParseUnit_WithCulture(string culture, string abbreviation, RelativeHumidityUnit expectedUnit)
        {
            Assert.True(RelativeHumidity.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out RelativeHumidityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(RelativeHumidityUnit unit)
        {
            var inBaseUnits = RelativeHumidity.From(1.0, RelativeHumidity.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(RelativeHumidityUnit unit)
        {
            var quantity = RelativeHumidity.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory(Skip = "Multiple units required")]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(RelativeHumidityUnit unit)
        {
            // See if there is a unit available that is not the base unit, fallback to base unit if it has only a single unit.
            var fromUnit = RelativeHumidity.Units.First(u => u != RelativeHumidity.BaseUnit);

            var quantity = RelativeHumidity.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(RelativeHumidityUnit unit)
        {
            var quantity = default(RelativeHumidity);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            RelativeHumidity percent = RelativeHumidity.FromPercent(1);
            AssertEx.EqualTolerance(1, RelativeHumidity.FromPercent(percent.Percent).Percent, PercentTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            RelativeHumidity v = RelativeHumidity.FromPercent(1);
            AssertEx.EqualTolerance(-1, -v.Percent, PercentTolerance);
            AssertEx.EqualTolerance(2, (RelativeHumidity.FromPercent(3)-v).Percent, PercentTolerance);
            AssertEx.EqualTolerance(2, (v + v).Percent, PercentTolerance);
            AssertEx.EqualTolerance(10, (v*10).Percent, PercentTolerance);
            AssertEx.EqualTolerance(10, (10*v).Percent, PercentTolerance);
            AssertEx.EqualTolerance(2, (RelativeHumidity.FromPercent(10)/5).Percent, PercentTolerance);
            AssertEx.EqualTolerance(2, RelativeHumidity.FromPercent(10)/RelativeHumidity.FromPercent(5), PercentTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            RelativeHumidity onePercent = RelativeHumidity.FromPercent(1);
            RelativeHumidity twoPercent = RelativeHumidity.FromPercent(2);

            Assert.True(onePercent < twoPercent);
            Assert.True(onePercent <= twoPercent);
            Assert.True(twoPercent > onePercent);
            Assert.True(twoPercent >= onePercent);

            Assert.False(onePercent > twoPercent);
            Assert.False(onePercent >= twoPercent);
            Assert.False(twoPercent < onePercent);
            Assert.False(twoPercent <= onePercent);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            RelativeHumidity percent = RelativeHumidity.FromPercent(1);
            Assert.Equal(0, percent.CompareTo(percent));
            Assert.True(percent.CompareTo(RelativeHumidity.Zero) > 0);
            Assert.True(RelativeHumidity.Zero.CompareTo(percent) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            RelativeHumidity percent = RelativeHumidity.FromPercent(1);
            Assert.Throws<ArgumentException>(() => percent.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            RelativeHumidity percent = RelativeHumidity.FromPercent(1);
            Assert.Throws<ArgumentNullException>(() => percent.CompareTo(null));
        }

        [Theory]
        [InlineData(1, RelativeHumidityUnit.Percent, 1, RelativeHumidityUnit.Percent, true)]  // Same value and unit.
        [InlineData(1, RelativeHumidityUnit.Percent, 2, RelativeHumidityUnit.Percent, false)] // Different value.
        [InlineData(2, RelativeHumidityUnit.Percent, 1, RelativeHumidityUnit.Percent, false)] // Different value and unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, RelativeHumidityUnit unitA, double valueB, RelativeHumidityUnit unitB, bool expectEqual)
        {
            var a = new RelativeHumidity(valueA, unitA);
            var b = new RelativeHumidity(valueB, unitB);

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
            var a = RelativeHumidity.Zero;

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
            var v = RelativeHumidity.FromPercent(1);
            Assert.True(v.Equals(RelativeHumidity.FromPercent(1), PercentTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(RelativeHumidity.Zero, PercentTolerance, ComparisonType.Relative));
            Assert.True(RelativeHumidity.FromPercent(100).Equals(RelativeHumidity.FromPercent(120), 0.3, ComparisonType.Relative));
            Assert.False(RelativeHumidity.FromPercent(100).Equals(RelativeHumidity.FromPercent(120), 0.1, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = RelativeHumidity.FromPercent(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(RelativeHumidity.FromPercent(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            RelativeHumidity percent = RelativeHumidity.FromPercent(1);
            Assert.False(percent.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            RelativeHumidity percent = RelativeHumidity.FromPercent(1);
            Assert.False(percent.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(RelativeHumidityUnit)).Cast<RelativeHumidityUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(RelativeHumidity.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 %RH", new RelativeHumidity(1, RelativeHumidityUnit.Percent).ToString());
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

            Assert.Equal("1 %RH", new RelativeHumidity(1, RelativeHumidityUnit.Percent).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 %RH", new RelativeHumidity(0.123456, RelativeHumidityUnit.Percent).ToString("s1"));
                Assert.Equal("0.12 %RH", new RelativeHumidity(0.123456, RelativeHumidityUnit.Percent).ToString("s2"));
                Assert.Equal("0.123 %RH", new RelativeHumidity(0.123456, RelativeHumidityUnit.Percent).ToString("s3"));
                Assert.Equal("0.1235 %RH", new RelativeHumidity(0.123456, RelativeHumidityUnit.Percent).ToString("s4"));
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
            Assert.Equal("0.1 %RH", new RelativeHumidity(0.123456, RelativeHumidityUnit.Percent).ToString("s1", culture));
            Assert.Equal("0.12 %RH", new RelativeHumidity(0.123456, RelativeHumidityUnit.Percent).ToString("s2", culture));
            Assert.Equal("0.123 %RH", new RelativeHumidity(0.123456, RelativeHumidityUnit.Percent).ToString("s3", culture));
            Assert.Equal("0.1235 %RH", new RelativeHumidity(0.123456, RelativeHumidityUnit.Percent).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
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
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(RelativeHumidity)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(RelativeHumidityUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal(RelativeHumidity.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal(RelativeHumidity.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = RelativeHumidity.FromPercent(1.0);
            Assert.Equal(new {RelativeHumidity.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = RelativeHumidity.FromPercent(value);
            Assert.Equal(RelativeHumidity.FromPercent(-value), -quantity);
        }
    }
}
