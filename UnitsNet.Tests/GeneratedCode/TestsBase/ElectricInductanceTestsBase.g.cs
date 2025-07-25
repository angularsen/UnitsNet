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
    /// Test of ElectricInductance.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricInductanceTestsBase : QuantityTestsBase
    {
        protected abstract double HenriesInOneHenry { get; }
        protected abstract double MicrohenriesInOneHenry { get; }
        protected abstract double MillihenriesInOneHenry { get; }
        protected abstract double NanohenriesInOneHenry { get; }
        protected abstract double PicohenriesInOneHenry { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double HenriesTolerance { get { return 1e-5; } }
        protected virtual double MicrohenriesTolerance { get { return 1e-5; } }
        protected virtual double MillihenriesTolerance { get { return 1e-5; } }
        protected virtual double NanohenriesTolerance { get { return 1e-5; } }
        protected virtual double PicohenriesTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(ElectricInductanceUnit unit)
        {
            return unit switch
            {
                ElectricInductanceUnit.Henry => (HenriesInOneHenry, HenriesTolerance),
                ElectricInductanceUnit.Microhenry => (MicrohenriesInOneHenry, MicrohenriesTolerance),
                ElectricInductanceUnit.Millihenry => (MillihenriesInOneHenry, MillihenriesTolerance),
                ElectricInductanceUnit.Nanohenry => (NanohenriesInOneHenry, NanohenriesTolerance),
                ElectricInductanceUnit.Picohenry => (PicohenriesInOneHenry, PicohenriesTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { ElectricInductanceUnit.Henry },
            new object[] { ElectricInductanceUnit.Microhenry },
            new object[] { ElectricInductanceUnit.Millihenry },
            new object[] { ElectricInductanceUnit.Nanohenry },
            new object[] { ElectricInductanceUnit.Picohenry },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ElectricInductance();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ElectricInductanceUnit.Henry, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => new ElectricInductance(double.PositiveInfinity, ElectricInductanceUnit.Henry));
            var exception2 = Record.Exception(() => new ElectricInductance(double.NegativeInfinity, ElectricInductanceUnit.Henry));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => new ElectricInductance(double.NaN, ElectricInductanceUnit.Henry));

            Assert.Null(exception);
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ElectricInductance(value: 1, unitSystem: null));
        }

        [Fact]
        public virtual void Ctor_SIUnitSystem_ReturnsQuantityWithSIUnits()
        {
            var quantity = new ElectricInductance(value: 1, unitSystem: UnitSystem.SI);
            Assert.Equal(1, quantity.Value);
            Assert.True(quantity.QuantityInfo.UnitInfos.First(x => x.Value == quantity.Unit).BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public void Ctor_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => new ElectricInductance(value: 1, unitSystem: unsupportedUnitSystem));
        }

        [Fact]
        public void ElectricInductance_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ElectricInductance(1, ElectricInductanceUnit.Henry);

            QuantityInfo<ElectricInductanceUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ElectricInductance.Zero, quantityInfo.Zero);
            Assert.Equal("ElectricInductance", quantityInfo.Name);

            var units = Enum.GetValues<ElectricInductanceUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void HenryToElectricInductanceUnits()
        {
            ElectricInductance henry = ElectricInductance.FromHenries(1);
            AssertEx.EqualTolerance(HenriesInOneHenry, henry.Henries, HenriesTolerance);
            AssertEx.EqualTolerance(MicrohenriesInOneHenry, henry.Microhenries, MicrohenriesTolerance);
            AssertEx.EqualTolerance(MillihenriesInOneHenry, henry.Millihenries, MillihenriesTolerance);
            AssertEx.EqualTolerance(NanohenriesInOneHenry, henry.Nanohenries, NanohenriesTolerance);
            AssertEx.EqualTolerance(PicohenriesInOneHenry, henry.Picohenries, PicohenriesTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ElectricInductance.From(1, ElectricInductanceUnit.Henry);
            AssertEx.EqualTolerance(1, quantity00.Henries, HenriesTolerance);
            Assert.Equal(ElectricInductanceUnit.Henry, quantity00.Unit);

            var quantity01 = ElectricInductance.From(1, ElectricInductanceUnit.Microhenry);
            AssertEx.EqualTolerance(1, quantity01.Microhenries, MicrohenriesTolerance);
            Assert.Equal(ElectricInductanceUnit.Microhenry, quantity01.Unit);

            var quantity02 = ElectricInductance.From(1, ElectricInductanceUnit.Millihenry);
            AssertEx.EqualTolerance(1, quantity02.Millihenries, MillihenriesTolerance);
            Assert.Equal(ElectricInductanceUnit.Millihenry, quantity02.Unit);

            var quantity03 = ElectricInductance.From(1, ElectricInductanceUnit.Nanohenry);
            AssertEx.EqualTolerance(1, quantity03.Nanohenries, NanohenriesTolerance);
            Assert.Equal(ElectricInductanceUnit.Nanohenry, quantity03.Unit);

            var quantity04 = ElectricInductance.From(1, ElectricInductanceUnit.Picohenry);
            AssertEx.EqualTolerance(1, quantity04.Picohenries, PicohenriesTolerance);
            Assert.Equal(ElectricInductanceUnit.Picohenry, quantity04.Unit);

        }

        [Fact]
        public void FromHenries_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => ElectricInductance.FromHenries(double.PositiveInfinity));
            var exception2 = Record.Exception(() => ElectricInductance.FromHenries(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void FromHenries_WithNanValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => ElectricInductance.FromHenries(double.NaN));

            Assert.Null(exception);
        }

        [Fact]
        public void As()
        {
            var henry = ElectricInductance.FromHenries(1);
            AssertEx.EqualTolerance(HenriesInOneHenry, henry.As(ElectricInductanceUnit.Henry), HenriesTolerance);
            AssertEx.EqualTolerance(MicrohenriesInOneHenry, henry.As(ElectricInductanceUnit.Microhenry), MicrohenriesTolerance);
            AssertEx.EqualTolerance(MillihenriesInOneHenry, henry.As(ElectricInductanceUnit.Millihenry), MillihenriesTolerance);
            AssertEx.EqualTolerance(NanohenriesInOneHenry, henry.As(ElectricInductanceUnit.Nanohenry), NanohenriesTolerance);
            AssertEx.EqualTolerance(PicohenriesInOneHenry, henry.As(ElectricInductanceUnit.Picohenry), PicohenriesTolerance);
        }

        [Fact]
        public virtual void BaseUnit_HasSIBase()
        {
            var baseUnitInfo = ElectricInductance.Info.BaseUnitInfo;
            Assert.True(baseUnitInfo.BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public virtual void As_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new ElectricInductance(value: 1, unit: ElectricInductance.BaseUnit);
            var expectedValue = quantity.As(ElectricInductance.Info.GetDefaultUnit(UnitSystem.SI));

            var convertedValue = quantity.As(UnitSystem.SI);

            Assert.Equal(expectedValue, convertedValue);
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {
            var quantity = new ElectricInductance(value: 1, unit: ElectricInductance.BaseUnit);
            UnitSystem nullUnitSystem = null!;
            Assert.Throws<ArgumentNullException>(() => quantity.As(nullUnitSystem));
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new ElectricInductance(value: 1, unit: ElectricInductance.BaseUnit);
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => quantity.As(unsupportedUnitSystem));
        }

        [Fact]
        public virtual void ToUnit_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new ElectricInductance(value: 1, unit: ElectricInductance.BaseUnit);
            var expectedUnit = ElectricInductance.Info.GetDefaultUnit(UnitSystem.SI);
            var expectedValue = quantity.As(expectedUnit);

            Assert.Multiple(() =>
            {
                ElectricInductance quantityToConvert = quantity;

                ElectricInductance convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

                Assert.Equal(expectedUnit, convertedQuantity.Unit);
                Assert.Equal(expectedValue, convertedQuantity.Value);
            }, () =>
            {
                IQuantity<ElectricInductanceUnit> quantityToConvert = quantity;

                IQuantity<ElectricInductanceUnit> convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

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
                var quantity = new ElectricInductance(value: 1, unit: ElectricInductance.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity<ElectricInductanceUnit> quantity = new ElectricInductance(value: 1, unit: ElectricInductance.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity quantity = new ElectricInductance(value: 1, unit: ElectricInductance.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            });
        }

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Multiple(() =>
            {
                var quantity = new ElectricInductance(value: 1, unit: ElectricInductance.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity<ElectricInductanceUnit> quantity = new ElectricInductance(value: 1, unit: ElectricInductance.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity quantity = new ElectricInductance(value: 1, unit: ElectricInductance.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            });
        }

        [Fact]
        public void Parse()
        {
            try
            {
                var parsed = ElectricInductance.Parse("1 H", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Henries, HenriesTolerance);
                Assert.Equal(ElectricInductanceUnit.Henry, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ElectricInductance.Parse("1 µH", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Microhenries, MicrohenriesTolerance);
                Assert.Equal(ElectricInductanceUnit.Microhenry, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ElectricInductance.Parse("1 mH", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Millihenries, MillihenriesTolerance);
                Assert.Equal(ElectricInductanceUnit.Millihenry, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ElectricInductance.Parse("1 nH", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Nanohenries, NanohenriesTolerance);
                Assert.Equal(ElectricInductanceUnit.Nanohenry, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ElectricInductance.Parse("1 pH", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Picohenries, PicohenriesTolerance);
                Assert.Equal(ElectricInductanceUnit.Picohenry, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(ElectricInductance.TryParse("1 H", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Henries, HenriesTolerance);
                Assert.Equal(ElectricInductanceUnit.Henry, parsed.Unit);
            }

            {
                Assert.True(ElectricInductance.TryParse("1 µH", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Microhenries, MicrohenriesTolerance);
                Assert.Equal(ElectricInductanceUnit.Microhenry, parsed.Unit);
            }

            {
                Assert.True(ElectricInductance.TryParse("1 mH", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Millihenries, MillihenriesTolerance);
                Assert.Equal(ElectricInductanceUnit.Millihenry, parsed.Unit);
            }

            {
                Assert.True(ElectricInductance.TryParse("1 nH", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Nanohenries, NanohenriesTolerance);
                Assert.Equal(ElectricInductanceUnit.Nanohenry, parsed.Unit);
            }

            {
                Assert.True(ElectricInductance.TryParse("1 pH", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Picohenries, PicohenriesTolerance);
                Assert.Equal(ElectricInductanceUnit.Picohenry, parsed.Unit);
            }

        }

        [Theory]
        [InlineData("H", ElectricInductanceUnit.Henry)]
        [InlineData("µH", ElectricInductanceUnit.Microhenry)]
        [InlineData("mH", ElectricInductanceUnit.Millihenry)]
        [InlineData("nH", ElectricInductanceUnit.Nanohenry)]
        [InlineData("pH", ElectricInductanceUnit.Picohenry)]
        public void ParseUnit_WithUsEnglishCurrentCulture(string abbreviation, ElectricInductanceUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            ElectricInductanceUnit parsedUnit = ElectricInductance.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("H", ElectricInductanceUnit.Henry)]
        [InlineData("µH", ElectricInductanceUnit.Microhenry)]
        [InlineData("mH", ElectricInductanceUnit.Millihenry)]
        [InlineData("nH", ElectricInductanceUnit.Nanohenry)]
        [InlineData("pH", ElectricInductanceUnit.Picohenry)]
        public void ParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, ElectricInductanceUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            ElectricInductanceUnit parsedUnit = ElectricInductance.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "H", ElectricInductanceUnit.Henry)]
        [InlineData("en-US", "µH", ElectricInductanceUnit.Microhenry)]
        [InlineData("en-US", "mH", ElectricInductanceUnit.Millihenry)]
        [InlineData("en-US", "nH", ElectricInductanceUnit.Nanohenry)]
        [InlineData("en-US", "pH", ElectricInductanceUnit.Picohenry)]
        public void ParseUnit_WithCurrentCulture(string culture, string abbreviation, ElectricInductanceUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            ElectricInductanceUnit parsedUnit = ElectricInductance.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "H", ElectricInductanceUnit.Henry)]
        [InlineData("en-US", "µH", ElectricInductanceUnit.Microhenry)]
        [InlineData("en-US", "mH", ElectricInductanceUnit.Millihenry)]
        [InlineData("en-US", "nH", ElectricInductanceUnit.Nanohenry)]
        [InlineData("en-US", "pH", ElectricInductanceUnit.Picohenry)]
        public void ParseUnit_WithCulture(string culture, string abbreviation, ElectricInductanceUnit expectedUnit)
        {
            ElectricInductanceUnit parsedUnit = ElectricInductance.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("H", ElectricInductanceUnit.Henry)]
        [InlineData("µH", ElectricInductanceUnit.Microhenry)]
        [InlineData("mH", ElectricInductanceUnit.Millihenry)]
        [InlineData("nH", ElectricInductanceUnit.Nanohenry)]
        [InlineData("pH", ElectricInductanceUnit.Picohenry)]
        public void TryParseUnit_WithUsEnglishCurrentCulture(string abbreviation, ElectricInductanceUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            Assert.True(ElectricInductance.TryParseUnit(abbreviation, out ElectricInductanceUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("H", ElectricInductanceUnit.Henry)]
        [InlineData("µH", ElectricInductanceUnit.Microhenry)]
        [InlineData("mH", ElectricInductanceUnit.Millihenry)]
        [InlineData("nH", ElectricInductanceUnit.Nanohenry)]
        [InlineData("pH", ElectricInductanceUnit.Picohenry)]
        public void TryParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, ElectricInductanceUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            Assert.True(ElectricInductance.TryParseUnit(abbreviation, out ElectricInductanceUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "H", ElectricInductanceUnit.Henry)]
        [InlineData("en-US", "µH", ElectricInductanceUnit.Microhenry)]
        [InlineData("en-US", "mH", ElectricInductanceUnit.Millihenry)]
        [InlineData("en-US", "nH", ElectricInductanceUnit.Nanohenry)]
        [InlineData("en-US", "pH", ElectricInductanceUnit.Picohenry)]
        public void TryParseUnit_WithCurrentCulture(string culture, string abbreviation, ElectricInductanceUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            Assert.True(ElectricInductance.TryParseUnit(abbreviation, out ElectricInductanceUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "H", ElectricInductanceUnit.Henry)]
        [InlineData("en-US", "µH", ElectricInductanceUnit.Microhenry)]
        [InlineData("en-US", "mH", ElectricInductanceUnit.Millihenry)]
        [InlineData("en-US", "nH", ElectricInductanceUnit.Nanohenry)]
        [InlineData("en-US", "pH", ElectricInductanceUnit.Picohenry)]
        public void TryParseUnit_WithCulture(string culture, string abbreviation, ElectricInductanceUnit expectedUnit)
        {
            Assert.True(ElectricInductance.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out ElectricInductanceUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(ElectricInductanceUnit unit)
        {
            var inBaseUnits = ElectricInductance.From(1.0, ElectricInductance.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(ElectricInductanceUnit unit)
        {
            var quantity = ElectricInductance.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(ElectricInductanceUnit unit)
        {
            Assert.All(ElectricInductance.Units.Where(u => u != ElectricInductance.BaseUnit), fromUnit =>
            {
                var quantity = ElectricInductance.From(3.0, fromUnit);
                var converted = quantity.ToUnit(unit);
                Assert.Equal(converted.Unit, unit);
            });
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(ElectricInductanceUnit unit)
        {
            var quantity = default(ElectricInductance);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromIQuantity_ReturnsTheExpectedIQuantity(ElectricInductanceUnit unit)
        {
            var quantity = ElectricInductance.From(3, ElectricInductance.BaseUnit);
            ElectricInductance expectedQuantity = quantity.ToUnit(unit);
            Assert.Multiple(() =>
            {
                IQuantity<ElectricInductanceUnit> quantityToConvert = quantity;
                IQuantity<ElectricInductanceUnit> convertedQuantity = quantityToConvert.ToUnit(unit);
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
            ElectricInductance henry = ElectricInductance.FromHenries(1);
            AssertEx.EqualTolerance(1, ElectricInductance.FromHenries(henry.Henries).Henries, HenriesTolerance);
            AssertEx.EqualTolerance(1, ElectricInductance.FromMicrohenries(henry.Microhenries).Henries, MicrohenriesTolerance);
            AssertEx.EqualTolerance(1, ElectricInductance.FromMillihenries(henry.Millihenries).Henries, MillihenriesTolerance);
            AssertEx.EqualTolerance(1, ElectricInductance.FromNanohenries(henry.Nanohenries).Henries, NanohenriesTolerance);
            AssertEx.EqualTolerance(1, ElectricInductance.FromPicohenries(henry.Picohenries).Henries, PicohenriesTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ElectricInductance v = ElectricInductance.FromHenries(1);
            AssertEx.EqualTolerance(-1, -v.Henries, HenriesTolerance);
            AssertEx.EqualTolerance(2, (ElectricInductance.FromHenries(3)-v).Henries, HenriesTolerance);
            AssertEx.EqualTolerance(2, (v + v).Henries, HenriesTolerance);
            AssertEx.EqualTolerance(10, (v*10).Henries, HenriesTolerance);
            AssertEx.EqualTolerance(10, (10*v).Henries, HenriesTolerance);
            AssertEx.EqualTolerance(2, (ElectricInductance.FromHenries(10)/5).Henries, HenriesTolerance);
            AssertEx.EqualTolerance(2, ElectricInductance.FromHenries(10)/ElectricInductance.FromHenries(5), HenriesTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ElectricInductance oneHenry = ElectricInductance.FromHenries(1);
            ElectricInductance twoHenries = ElectricInductance.FromHenries(2);

            Assert.True(oneHenry < twoHenries);
            Assert.True(oneHenry <= twoHenries);
            Assert.True(twoHenries > oneHenry);
            Assert.True(twoHenries >= oneHenry);

            Assert.False(oneHenry > twoHenries);
            Assert.False(oneHenry >= twoHenries);
            Assert.False(twoHenries < oneHenry);
            Assert.False(twoHenries <= oneHenry);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ElectricInductance henry = ElectricInductance.FromHenries(1);
            Assert.Equal(0, henry.CompareTo(henry));
            Assert.True(henry.CompareTo(ElectricInductance.Zero) > 0);
            Assert.True(ElectricInductance.Zero.CompareTo(henry) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricInductance henry = ElectricInductance.FromHenries(1);
            Assert.Throws<ArgumentException>(() => henry.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ElectricInductance henry = ElectricInductance.FromHenries(1);
            Assert.Throws<ArgumentNullException>(() => henry.CompareTo(null));
        }

        [Theory]
        [InlineData(1, ElectricInductanceUnit.Henry, 1, ElectricInductanceUnit.Henry, true)]  // Same value and unit.
        [InlineData(1, ElectricInductanceUnit.Henry, 2, ElectricInductanceUnit.Henry, false)] // Different value.
        [InlineData(2, ElectricInductanceUnit.Henry, 1, ElectricInductanceUnit.Microhenry, false)] // Different value and unit.
        [InlineData(1, ElectricInductanceUnit.Henry, 1, ElectricInductanceUnit.Microhenry, false)] // Different unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, ElectricInductanceUnit unitA, double valueB, ElectricInductanceUnit unitB, bool expectEqual)
        {
            var a = new ElectricInductance(valueA, unitA);
            var b = new ElectricInductance(valueB, unitB);

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
            var a = ElectricInductance.Zero;

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
            var v = ElectricInductance.FromHenries(1);
            Assert.True(v.Equals(ElectricInductance.FromHenries(1), HenriesTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ElectricInductance.Zero, HenriesTolerance, ComparisonType.Relative));
            Assert.True(ElectricInductance.FromHenries(100).Equals(ElectricInductance.FromHenries(120), 0.3, ComparisonType.Relative));
            Assert.False(ElectricInductance.FromHenries(100).Equals(ElectricInductance.FromHenries(120), 0.1, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = ElectricInductance.FromHenries(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(ElectricInductance.FromHenries(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricInductance henry = ElectricInductance.FromHenries(1);
            Assert.False(henry.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricInductance henry = ElectricInductance.FromHenries(1);
            Assert.False(henry.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues<ElectricInductanceUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ElectricInductance.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            using var _ = new CultureScope("en-US");
            Assert.Equal("1 H", new ElectricInductance(1, ElectricInductanceUnit.Henry).ToString());
            Assert.Equal("1 µH", new ElectricInductance(1, ElectricInductanceUnit.Microhenry).ToString());
            Assert.Equal("1 mH", new ElectricInductance(1, ElectricInductanceUnit.Millihenry).ToString());
            Assert.Equal("1 nH", new ElectricInductance(1, ElectricInductanceUnit.Nanohenry).ToString());
            Assert.Equal("1 pH", new ElectricInductance(1, ElectricInductanceUnit.Picohenry).ToString());
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 H", new ElectricInductance(1, ElectricInductanceUnit.Henry).ToString(swedishCulture));
            Assert.Equal("1 µH", new ElectricInductance(1, ElectricInductanceUnit.Microhenry).ToString(swedishCulture));
            Assert.Equal("1 mH", new ElectricInductance(1, ElectricInductanceUnit.Millihenry).ToString(swedishCulture));
            Assert.Equal("1 nH", new ElectricInductance(1, ElectricInductanceUnit.Nanohenry).ToString(swedishCulture));
            Assert.Equal("1 pH", new ElectricInductance(1, ElectricInductanceUnit.Picohenry).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var _ = new CultureScope(CultureInfo.InvariantCulture);
            Assert.Equal("0.1 H", new ElectricInductance(0.123456, ElectricInductanceUnit.Henry).ToString("s1"));
            Assert.Equal("0.12 H", new ElectricInductance(0.123456, ElectricInductanceUnit.Henry).ToString("s2"));
            Assert.Equal("0.123 H", new ElectricInductance(0.123456, ElectricInductanceUnit.Henry).ToString("s3"));
            Assert.Equal("0.1235 H", new ElectricInductance(0.123456, ElectricInductanceUnit.Henry).ToString("s4"));
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 H", new ElectricInductance(0.123456, ElectricInductanceUnit.Henry).ToString("s1", culture));
            Assert.Equal("0.12 H", new ElectricInductance(0.123456, ElectricInductanceUnit.Henry).ToString("s2", culture));
            Assert.Equal("0.123 H", new ElectricInductance(0.123456, ElectricInductanceUnit.Henry).ToString("s3", culture));
            Assert.Equal("0.1235 H", new ElectricInductance(0.123456, ElectricInductanceUnit.Henry).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = ElectricInductance.FromHenries(1.0);
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
            var quantity = ElectricInductance.FromHenries(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = ElectricInductance.FromHenries(1.0);
            Assert.Equal(new {ElectricInductance.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = ElectricInductance.FromHenries(value);
            Assert.Equal(ElectricInductance.FromHenries(-value), -quantity);
        }
    }
}
