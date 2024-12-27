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
    /// Test of ApparentPower.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ApparentPowerTestsBase : QuantityTestsBase
    {
        protected abstract double GigavoltamperesInOneVoltampere { get; }
        protected abstract double KilovoltamperesInOneVoltampere { get; }
        protected abstract double MegavoltamperesInOneVoltampere { get; }
        protected abstract double MicrovoltamperesInOneVoltampere { get; }
        protected abstract double MillivoltamperesInOneVoltampere { get; }
        protected abstract double VoltamperesInOneVoltampere { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double GigavoltamperesTolerance { get { return 1e-5; } }
        protected virtual double KilovoltamperesTolerance { get { return 1e-5; } }
        protected virtual double MegavoltamperesTolerance { get { return 1e-5; } }
        protected virtual double MicrovoltamperesTolerance { get { return 1e-5; } }
        protected virtual double MillivoltamperesTolerance { get { return 1e-5; } }
        protected virtual double VoltamperesTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(ApparentPowerUnit unit)
        {
            return unit switch
            {
                ApparentPowerUnit.Gigavoltampere => (GigavoltamperesInOneVoltampere, GigavoltamperesTolerance),
                ApparentPowerUnit.Kilovoltampere => (KilovoltamperesInOneVoltampere, KilovoltamperesTolerance),
                ApparentPowerUnit.Megavoltampere => (MegavoltamperesInOneVoltampere, MegavoltamperesTolerance),
                ApparentPowerUnit.Microvoltampere => (MicrovoltamperesInOneVoltampere, MicrovoltamperesTolerance),
                ApparentPowerUnit.Millivoltampere => (MillivoltamperesInOneVoltampere, MillivoltamperesTolerance),
                ApparentPowerUnit.Voltampere => (VoltamperesInOneVoltampere, VoltamperesTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { ApparentPowerUnit.Gigavoltampere },
            new object[] { ApparentPowerUnit.Kilovoltampere },
            new object[] { ApparentPowerUnit.Megavoltampere },
            new object[] { ApparentPowerUnit.Microvoltampere },
            new object[] { ApparentPowerUnit.Millivoltampere },
            new object[] { ApparentPowerUnit.Voltampere },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ApparentPower();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ApparentPowerUnit.Voltampere, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => new ApparentPower(double.PositiveInfinity, ApparentPowerUnit.Voltampere));
            var exception2 = Record.Exception(() => new ApparentPower(double.NegativeInfinity, ApparentPowerUnit.Voltampere));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => new ApparentPower(double.NaN, ApparentPowerUnit.Voltampere));

            Assert.Null(exception);
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ApparentPower(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new ApparentPower(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (ApparentPower) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void ApparentPower_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ApparentPower(1, ApparentPowerUnit.Voltampere);

            QuantityInfo<ApparentPowerUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ApparentPower.Zero, quantityInfo.Zero);
            Assert.Equal("ApparentPower", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<ApparentPowerUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void VoltampereToApparentPowerUnits()
        {
            ApparentPower voltampere = ApparentPower.FromVoltamperes(1);
            AssertEx.EqualTolerance(GigavoltamperesInOneVoltampere, voltampere.Gigavoltamperes, GigavoltamperesTolerance);
            AssertEx.EqualTolerance(KilovoltamperesInOneVoltampere, voltampere.Kilovoltamperes, KilovoltamperesTolerance);
            AssertEx.EqualTolerance(MegavoltamperesInOneVoltampere, voltampere.Megavoltamperes, MegavoltamperesTolerance);
            AssertEx.EqualTolerance(MicrovoltamperesInOneVoltampere, voltampere.Microvoltamperes, MicrovoltamperesTolerance);
            AssertEx.EqualTolerance(MillivoltamperesInOneVoltampere, voltampere.Millivoltamperes, MillivoltamperesTolerance);
            AssertEx.EqualTolerance(VoltamperesInOneVoltampere, voltampere.Voltamperes, VoltamperesTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ApparentPower.From(1, ApparentPowerUnit.Gigavoltampere);
            AssertEx.EqualTolerance(1, quantity00.Gigavoltamperes, GigavoltamperesTolerance);
            Assert.Equal(ApparentPowerUnit.Gigavoltampere, quantity00.Unit);

            var quantity01 = ApparentPower.From(1, ApparentPowerUnit.Kilovoltampere);
            AssertEx.EqualTolerance(1, quantity01.Kilovoltamperes, KilovoltamperesTolerance);
            Assert.Equal(ApparentPowerUnit.Kilovoltampere, quantity01.Unit);

            var quantity02 = ApparentPower.From(1, ApparentPowerUnit.Megavoltampere);
            AssertEx.EqualTolerance(1, quantity02.Megavoltamperes, MegavoltamperesTolerance);
            Assert.Equal(ApparentPowerUnit.Megavoltampere, quantity02.Unit);

            var quantity03 = ApparentPower.From(1, ApparentPowerUnit.Microvoltampere);
            AssertEx.EqualTolerance(1, quantity03.Microvoltamperes, MicrovoltamperesTolerance);
            Assert.Equal(ApparentPowerUnit.Microvoltampere, quantity03.Unit);

            var quantity04 = ApparentPower.From(1, ApparentPowerUnit.Millivoltampere);
            AssertEx.EqualTolerance(1, quantity04.Millivoltamperes, MillivoltamperesTolerance);
            Assert.Equal(ApparentPowerUnit.Millivoltampere, quantity04.Unit);

            var quantity05 = ApparentPower.From(1, ApparentPowerUnit.Voltampere);
            AssertEx.EqualTolerance(1, quantity05.Voltamperes, VoltamperesTolerance);
            Assert.Equal(ApparentPowerUnit.Voltampere, quantity05.Unit);

        }

        [Fact]
        public void FromVoltamperes_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => ApparentPower.FromVoltamperes(double.PositiveInfinity));
            var exception2 = Record.Exception(() => ApparentPower.FromVoltamperes(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void FromVoltamperes_WithNanValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => ApparentPower.FromVoltamperes(double.NaN));

            Assert.Null(exception);
        }

        [Fact]
        public void As()
        {
            var voltampere = ApparentPower.FromVoltamperes(1);
            AssertEx.EqualTolerance(GigavoltamperesInOneVoltampere, voltampere.As(ApparentPowerUnit.Gigavoltampere), GigavoltamperesTolerance);
            AssertEx.EqualTolerance(KilovoltamperesInOneVoltampere, voltampere.As(ApparentPowerUnit.Kilovoltampere), KilovoltamperesTolerance);
            AssertEx.EqualTolerance(MegavoltamperesInOneVoltampere, voltampere.As(ApparentPowerUnit.Megavoltampere), MegavoltamperesTolerance);
            AssertEx.EqualTolerance(MicrovoltamperesInOneVoltampere, voltampere.As(ApparentPowerUnit.Microvoltampere), MicrovoltamperesTolerance);
            AssertEx.EqualTolerance(MillivoltamperesInOneVoltampere, voltampere.As(ApparentPowerUnit.Millivoltampere), MillivoltamperesTolerance);
            AssertEx.EqualTolerance(VoltamperesInOneVoltampere, voltampere.As(ApparentPowerUnit.Voltampere), VoltamperesTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new ApparentPower(value: 1, unit: ApparentPower.BaseUnit);
            Func<object> AsWithSIUnitSystem = () => quantity.As(UnitSystem.SI);

            if (SupportsSIUnitSystem)
            {
                var value = Convert.ToDouble(AsWithSIUnitSystem());
                Assert.Equal(1, value);
            }
            else
            {
                Assert.Throws<ArgumentException>(AsWithSIUnitSystem);
            }
        }

        [Fact]
        public void Parse()
        {
            try
            {
                var parsed = ApparentPower.Parse("1 GVA", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Gigavoltamperes, GigavoltamperesTolerance);
                Assert.Equal(ApparentPowerUnit.Gigavoltampere, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ApparentPower.Parse("1 kVA", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Kilovoltamperes, KilovoltamperesTolerance);
                Assert.Equal(ApparentPowerUnit.Kilovoltampere, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ApparentPower.Parse("1 MVA", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Megavoltamperes, MegavoltamperesTolerance);
                Assert.Equal(ApparentPowerUnit.Megavoltampere, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ApparentPower.Parse("1 µVA", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Microvoltamperes, MicrovoltamperesTolerance);
                Assert.Equal(ApparentPowerUnit.Microvoltampere, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ApparentPower.Parse("1 mVA", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Millivoltamperes, MillivoltamperesTolerance);
                Assert.Equal(ApparentPowerUnit.Millivoltampere, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ApparentPower.Parse("1 VA", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Voltamperes, VoltamperesTolerance);
                Assert.Equal(ApparentPowerUnit.Voltampere, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(ApparentPower.TryParse("1 GVA", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Gigavoltamperes, GigavoltamperesTolerance);
                Assert.Equal(ApparentPowerUnit.Gigavoltampere, parsed.Unit);
            }

            {
                Assert.True(ApparentPower.TryParse("1 kVA", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Kilovoltamperes, KilovoltamperesTolerance);
                Assert.Equal(ApparentPowerUnit.Kilovoltampere, parsed.Unit);
            }

            {
                Assert.True(ApparentPower.TryParse("1 µVA", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Microvoltamperes, MicrovoltamperesTolerance);
                Assert.Equal(ApparentPowerUnit.Microvoltampere, parsed.Unit);
            }

            {
                Assert.True(ApparentPower.TryParse("1 VA", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Voltamperes, VoltamperesTolerance);
                Assert.Equal(ApparentPowerUnit.Voltampere, parsed.Unit);
            }

        }

        [Theory]
        [InlineData("GVA", ApparentPowerUnit.Gigavoltampere)]
        [InlineData("kVA", ApparentPowerUnit.Kilovoltampere)]
        [InlineData("MVA", ApparentPowerUnit.Megavoltampere)]
        [InlineData("µVA", ApparentPowerUnit.Microvoltampere)]
        [InlineData("mVA", ApparentPowerUnit.Millivoltampere)]
        [InlineData("VA", ApparentPowerUnit.Voltampere)]
        public void ParseUnit_WithUsEnglishCurrentCulture(string abbreviation, ApparentPowerUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            ApparentPowerUnit parsedUnit = ApparentPower.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("GVA", ApparentPowerUnit.Gigavoltampere)]
        [InlineData("kVA", ApparentPowerUnit.Kilovoltampere)]
        [InlineData("MVA", ApparentPowerUnit.Megavoltampere)]
        [InlineData("µVA", ApparentPowerUnit.Microvoltampere)]
        [InlineData("mVA", ApparentPowerUnit.Millivoltampere)]
        [InlineData("VA", ApparentPowerUnit.Voltampere)]
        public void ParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, ApparentPowerUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            ApparentPowerUnit parsedUnit = ApparentPower.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "GVA", ApparentPowerUnit.Gigavoltampere)]
        [InlineData("en-US", "kVA", ApparentPowerUnit.Kilovoltampere)]
        [InlineData("en-US", "MVA", ApparentPowerUnit.Megavoltampere)]
        [InlineData("en-US", "µVA", ApparentPowerUnit.Microvoltampere)]
        [InlineData("en-US", "mVA", ApparentPowerUnit.Millivoltampere)]
        [InlineData("en-US", "VA", ApparentPowerUnit.Voltampere)]
        public void ParseUnit_WithCurrentCulture(string culture, string abbreviation, ApparentPowerUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            ApparentPowerUnit parsedUnit = ApparentPower.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "GVA", ApparentPowerUnit.Gigavoltampere)]
        [InlineData("en-US", "kVA", ApparentPowerUnit.Kilovoltampere)]
        [InlineData("en-US", "MVA", ApparentPowerUnit.Megavoltampere)]
        [InlineData("en-US", "µVA", ApparentPowerUnit.Microvoltampere)]
        [InlineData("en-US", "mVA", ApparentPowerUnit.Millivoltampere)]
        [InlineData("en-US", "VA", ApparentPowerUnit.Voltampere)]
        public void ParseUnit_WithCulture(string culture, string abbreviation, ApparentPowerUnit expectedUnit)
        {
            ApparentPowerUnit parsedUnit = ApparentPower.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("GVA", ApparentPowerUnit.Gigavoltampere)]
        [InlineData("kVA", ApparentPowerUnit.Kilovoltampere)]
        [InlineData("MVA", ApparentPowerUnit.Megavoltampere)]
        [InlineData("µVA", ApparentPowerUnit.Microvoltampere)]
        [InlineData("mVA", ApparentPowerUnit.Millivoltampere)]
        [InlineData("VA", ApparentPowerUnit.Voltampere)]
        public void TryParseUnit_WithUsEnglishCurrentCulture(string abbreviation, ApparentPowerUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            Assert.True(ApparentPower.TryParseUnit(abbreviation, out ApparentPowerUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("GVA", ApparentPowerUnit.Gigavoltampere)]
        [InlineData("kVA", ApparentPowerUnit.Kilovoltampere)]
        [InlineData("MVA", ApparentPowerUnit.Megavoltampere)]
        [InlineData("µVA", ApparentPowerUnit.Microvoltampere)]
        [InlineData("mVA", ApparentPowerUnit.Millivoltampere)]
        [InlineData("VA", ApparentPowerUnit.Voltampere)]
        public void TryParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, ApparentPowerUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            Assert.True(ApparentPower.TryParseUnit(abbreviation, out ApparentPowerUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "GVA", ApparentPowerUnit.Gigavoltampere)]
        [InlineData("en-US", "kVA", ApparentPowerUnit.Kilovoltampere)]
        [InlineData("en-US", "MVA", ApparentPowerUnit.Megavoltampere)]
        [InlineData("en-US", "µVA", ApparentPowerUnit.Microvoltampere)]
        [InlineData("en-US", "mVA", ApparentPowerUnit.Millivoltampere)]
        [InlineData("en-US", "VA", ApparentPowerUnit.Voltampere)]
        public void TryParseUnit_WithCurrentCulture(string culture, string abbreviation, ApparentPowerUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            Assert.True(ApparentPower.TryParseUnit(abbreviation, out ApparentPowerUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "GVA", ApparentPowerUnit.Gigavoltampere)]
        [InlineData("en-US", "kVA", ApparentPowerUnit.Kilovoltampere)]
        [InlineData("en-US", "MVA", ApparentPowerUnit.Megavoltampere)]
        [InlineData("en-US", "µVA", ApparentPowerUnit.Microvoltampere)]
        [InlineData("en-US", "mVA", ApparentPowerUnit.Millivoltampere)]
        [InlineData("en-US", "VA", ApparentPowerUnit.Voltampere)]
        public void TryParseUnit_WithCulture(string culture, string abbreviation, ApparentPowerUnit expectedUnit)
        {
            Assert.True(ApparentPower.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out ApparentPowerUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(ApparentPowerUnit unit)
        {
            var inBaseUnits = ApparentPower.From(1.0, ApparentPower.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(ApparentPowerUnit unit)
        {
            var quantity = ApparentPower.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(ApparentPowerUnit unit)
        {
            // See if there is a unit available that is not the base unit, fallback to base unit if it has only a single unit.
            var fromUnit = ApparentPower.Units.First(u => u != ApparentPower.BaseUnit);

            var quantity = ApparentPower.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(ApparentPowerUnit unit)
        {
            var quantity = default(ApparentPower);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ApparentPower voltampere = ApparentPower.FromVoltamperes(1);
            AssertEx.EqualTolerance(1, ApparentPower.FromGigavoltamperes(voltampere.Gigavoltamperes).Voltamperes, GigavoltamperesTolerance);
            AssertEx.EqualTolerance(1, ApparentPower.FromKilovoltamperes(voltampere.Kilovoltamperes).Voltamperes, KilovoltamperesTolerance);
            AssertEx.EqualTolerance(1, ApparentPower.FromMegavoltamperes(voltampere.Megavoltamperes).Voltamperes, MegavoltamperesTolerance);
            AssertEx.EqualTolerance(1, ApparentPower.FromMicrovoltamperes(voltampere.Microvoltamperes).Voltamperes, MicrovoltamperesTolerance);
            AssertEx.EqualTolerance(1, ApparentPower.FromMillivoltamperes(voltampere.Millivoltamperes).Voltamperes, MillivoltamperesTolerance);
            AssertEx.EqualTolerance(1, ApparentPower.FromVoltamperes(voltampere.Voltamperes).Voltamperes, VoltamperesTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ApparentPower v = ApparentPower.FromVoltamperes(1);
            AssertEx.EqualTolerance(-1, -v.Voltamperes, VoltamperesTolerance);
            AssertEx.EqualTolerance(2, (ApparentPower.FromVoltamperes(3)-v).Voltamperes, VoltamperesTolerance);
            AssertEx.EqualTolerance(2, (v + v).Voltamperes, VoltamperesTolerance);
            AssertEx.EqualTolerance(10, (v*10).Voltamperes, VoltamperesTolerance);
            AssertEx.EqualTolerance(10, (10*v).Voltamperes, VoltamperesTolerance);
            AssertEx.EqualTolerance(2, (ApparentPower.FromVoltamperes(10)/5).Voltamperes, VoltamperesTolerance);
            AssertEx.EqualTolerance(2, ApparentPower.FromVoltamperes(10)/ApparentPower.FromVoltamperes(5), VoltamperesTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ApparentPower oneVoltampere = ApparentPower.FromVoltamperes(1);
            ApparentPower twoVoltamperes = ApparentPower.FromVoltamperes(2);

            Assert.True(oneVoltampere < twoVoltamperes);
            Assert.True(oneVoltampere <= twoVoltamperes);
            Assert.True(twoVoltamperes > oneVoltampere);
            Assert.True(twoVoltamperes >= oneVoltampere);

            Assert.False(oneVoltampere > twoVoltamperes);
            Assert.False(oneVoltampere >= twoVoltamperes);
            Assert.False(twoVoltamperes < oneVoltampere);
            Assert.False(twoVoltamperes <= oneVoltampere);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ApparentPower voltampere = ApparentPower.FromVoltamperes(1);
            Assert.Equal(0, voltampere.CompareTo(voltampere));
            Assert.True(voltampere.CompareTo(ApparentPower.Zero) > 0);
            Assert.True(ApparentPower.Zero.CompareTo(voltampere) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ApparentPower voltampere = ApparentPower.FromVoltamperes(1);
            Assert.Throws<ArgumentException>(() => voltampere.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ApparentPower voltampere = ApparentPower.FromVoltamperes(1);
            Assert.Throws<ArgumentNullException>(() => voltampere.CompareTo(null));
        }

        [Theory]
        [InlineData(1, ApparentPowerUnit.Voltampere, 1, ApparentPowerUnit.Voltampere, true)]  // Same value and unit.
        [InlineData(1, ApparentPowerUnit.Voltampere, 2, ApparentPowerUnit.Voltampere, false)] // Different value.
        [InlineData(2, ApparentPowerUnit.Voltampere, 1, ApparentPowerUnit.Gigavoltampere, false)] // Different value and unit.
        [InlineData(1, ApparentPowerUnit.Voltampere, 1, ApparentPowerUnit.Gigavoltampere, false)] // Different unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, ApparentPowerUnit unitA, double valueB, ApparentPowerUnit unitB, bool expectEqual)
        {
            var a = new ApparentPower(valueA, unitA);
            var b = new ApparentPower(valueB, unitB);

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
            var a = ApparentPower.Zero;

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
            var v = ApparentPower.FromVoltamperes(1);
            Assert.True(v.Equals(ApparentPower.FromVoltamperes(1), VoltamperesTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ApparentPower.Zero, VoltamperesTolerance, ComparisonType.Relative));
            Assert.True(ApparentPower.FromVoltamperes(100).Equals(ApparentPower.FromVoltamperes(120), 0.3, ComparisonType.Relative));
            Assert.False(ApparentPower.FromVoltamperes(100).Equals(ApparentPower.FromVoltamperes(120), 0.1, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = ApparentPower.FromVoltamperes(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(ApparentPower.FromVoltamperes(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ApparentPower voltampere = ApparentPower.FromVoltamperes(1);
            Assert.False(voltampere.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ApparentPower voltampere = ApparentPower.FromVoltamperes(1);
            Assert.False(voltampere.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ApparentPowerUnit)).Cast<ApparentPowerUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ApparentPower.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            using var _ = new CultureScope("en-US");
            Assert.Equal("1 GVA", new ApparentPower(1, ApparentPowerUnit.Gigavoltampere).ToString());
            Assert.Equal("1 kVA", new ApparentPower(1, ApparentPowerUnit.Kilovoltampere).ToString());
            Assert.Equal("1 MVA", new ApparentPower(1, ApparentPowerUnit.Megavoltampere).ToString());
            Assert.Equal("1 µVA", new ApparentPower(1, ApparentPowerUnit.Microvoltampere).ToString());
            Assert.Equal("1 mVA", new ApparentPower(1, ApparentPowerUnit.Millivoltampere).ToString());
            Assert.Equal("1 VA", new ApparentPower(1, ApparentPowerUnit.Voltampere).ToString());
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 GVA", new ApparentPower(1, ApparentPowerUnit.Gigavoltampere).ToString(swedishCulture));
            Assert.Equal("1 kVA", new ApparentPower(1, ApparentPowerUnit.Kilovoltampere).ToString(swedishCulture));
            Assert.Equal("1 MVA", new ApparentPower(1, ApparentPowerUnit.Megavoltampere).ToString(swedishCulture));
            Assert.Equal("1 µVA", new ApparentPower(1, ApparentPowerUnit.Microvoltampere).ToString(swedishCulture));
            Assert.Equal("1 mVA", new ApparentPower(1, ApparentPowerUnit.Millivoltampere).ToString(swedishCulture));
            Assert.Equal("1 VA", new ApparentPower(1, ApparentPowerUnit.Voltampere).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var _ = new CultureScope(CultureInfo.InvariantCulture);
            Assert.Equal("0.1 VA", new ApparentPower(0.123456, ApparentPowerUnit.Voltampere).ToString("s1"));
            Assert.Equal("0.12 VA", new ApparentPower(0.123456, ApparentPowerUnit.Voltampere).ToString("s2"));
            Assert.Equal("0.123 VA", new ApparentPower(0.123456, ApparentPowerUnit.Voltampere).ToString("s3"));
            Assert.Equal("0.1235 VA", new ApparentPower(0.123456, ApparentPowerUnit.Voltampere).ToString("s4"));
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 VA", new ApparentPower(0.123456, ApparentPowerUnit.Voltampere).ToString("s1", culture));
            Assert.Equal("0.12 VA", new ApparentPower(0.123456, ApparentPowerUnit.Voltampere).ToString("s2", culture));
            Assert.Equal("0.123 VA", new ApparentPower(0.123456, ApparentPowerUnit.Voltampere).ToString("s3", culture));
            Assert.Equal("0.1235 VA", new ApparentPower(0.123456, ApparentPowerUnit.Voltampere).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
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
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(ApparentPower)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(ApparentPowerUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal(ApparentPower.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal(ApparentPower.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = ApparentPower.FromVoltamperes(1.0);
            Assert.Equal(new {ApparentPower.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = ApparentPower.FromVoltamperes(value);
            Assert.Equal(ApparentPower.FromVoltamperes(-value), -quantity);
        }
    }
}
