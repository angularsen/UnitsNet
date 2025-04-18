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
using UnitsNet.InternalHelpers;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of MolarEntropy.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MolarEntropyTestsBase : QuantityTestsBase
    {
        protected abstract double JoulesPerMoleKelvinInOneJoulePerMoleKelvin { get; }
        protected abstract double KilojoulesPerMoleKelvinInOneJoulePerMoleKelvin { get; }
        protected abstract double MegajoulesPerMoleKelvinInOneJoulePerMoleKelvin { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double JoulesPerMoleKelvinTolerance { get { return 1e-5; } }
        protected virtual double KilojoulesPerMoleKelvinTolerance { get { return 1e-5; } }
        protected virtual double MegajoulesPerMoleKelvinTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(MolarEntropyUnit unit)
        {
            return unit switch
            {
                MolarEntropyUnit.JoulePerMoleKelvin => (JoulesPerMoleKelvinInOneJoulePerMoleKelvin, JoulesPerMoleKelvinTolerance),
                MolarEntropyUnit.KilojoulePerMoleKelvin => (KilojoulesPerMoleKelvinInOneJoulePerMoleKelvin, KilojoulesPerMoleKelvinTolerance),
                MolarEntropyUnit.MegajoulePerMoleKelvin => (MegajoulesPerMoleKelvinInOneJoulePerMoleKelvin, MegajoulesPerMoleKelvinTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { MolarEntropyUnit.JoulePerMoleKelvin },
            new object[] { MolarEntropyUnit.KilojoulePerMoleKelvin },
            new object[] { MolarEntropyUnit.MegajoulePerMoleKelvin },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new MolarEntropy();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(MolarEntropyUnit.JoulePerMoleKelvin, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => new MolarEntropy(double.PositiveInfinity, MolarEntropyUnit.JoulePerMoleKelvin));
            var exception2 = Record.Exception(() => new MolarEntropy(double.NegativeInfinity, MolarEntropyUnit.JoulePerMoleKelvin));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => new MolarEntropy(double.NaN, MolarEntropyUnit.JoulePerMoleKelvin));

            Assert.Null(exception);
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new MolarEntropy(value: 1, unitSystem: null));
        }

        [Fact]
        public virtual void Ctor_SIUnitSystem_ReturnsQuantityWithSIUnits()
        {
            var quantity = new MolarEntropy(value: 1, unitSystem: UnitSystem.SI);
            Assert.Equal(1, quantity.Value);
            Assert.True(quantity.QuantityInfo.UnitInfos.First(x => x.Value == quantity.Unit).BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public void Ctor_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => new MolarEntropy(value: 1, unitSystem: unsupportedUnitSystem));
        }

        [Fact]
        public void MolarEntropy_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new MolarEntropy(1, MolarEntropyUnit.JoulePerMoleKelvin);

            QuantityInfo<MolarEntropyUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(MolarEntropy.Zero, quantityInfo.Zero);
            Assert.Equal("MolarEntropy", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<MolarEntropyUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void JoulePerMoleKelvinToMolarEntropyUnits()
        {
            MolarEntropy joulepermolekelvin = MolarEntropy.FromJoulesPerMoleKelvin(1);
            AssertEx.EqualTolerance(JoulesPerMoleKelvinInOneJoulePerMoleKelvin, joulepermolekelvin.JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(KilojoulesPerMoleKelvinInOneJoulePerMoleKelvin, joulepermolekelvin.KilojoulesPerMoleKelvin, KilojoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(MegajoulesPerMoleKelvinInOneJoulePerMoleKelvin, joulepermolekelvin.MegajoulesPerMoleKelvin, MegajoulesPerMoleKelvinTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = MolarEntropy.From(1, MolarEntropyUnit.JoulePerMoleKelvin);
            AssertEx.EqualTolerance(1, quantity00.JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
            Assert.Equal(MolarEntropyUnit.JoulePerMoleKelvin, quantity00.Unit);

            var quantity01 = MolarEntropy.From(1, MolarEntropyUnit.KilojoulePerMoleKelvin);
            AssertEx.EqualTolerance(1, quantity01.KilojoulesPerMoleKelvin, KilojoulesPerMoleKelvinTolerance);
            Assert.Equal(MolarEntropyUnit.KilojoulePerMoleKelvin, quantity01.Unit);

            var quantity02 = MolarEntropy.From(1, MolarEntropyUnit.MegajoulePerMoleKelvin);
            AssertEx.EqualTolerance(1, quantity02.MegajoulesPerMoleKelvin, MegajoulesPerMoleKelvinTolerance);
            Assert.Equal(MolarEntropyUnit.MegajoulePerMoleKelvin, quantity02.Unit);

        }

        [Fact]
        public void FromJoulesPerMoleKelvin_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => MolarEntropy.FromJoulesPerMoleKelvin(double.PositiveInfinity));
            var exception2 = Record.Exception(() => MolarEntropy.FromJoulesPerMoleKelvin(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void FromJoulesPerMoleKelvin_WithNanValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => MolarEntropy.FromJoulesPerMoleKelvin(double.NaN));

            Assert.Null(exception);
        }

        [Fact]
        public void As()
        {
            var joulepermolekelvin = MolarEntropy.FromJoulesPerMoleKelvin(1);
            AssertEx.EqualTolerance(JoulesPerMoleKelvinInOneJoulePerMoleKelvin, joulepermolekelvin.As(MolarEntropyUnit.JoulePerMoleKelvin), JoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(KilojoulesPerMoleKelvinInOneJoulePerMoleKelvin, joulepermolekelvin.As(MolarEntropyUnit.KilojoulePerMoleKelvin), KilojoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(MegajoulesPerMoleKelvinInOneJoulePerMoleKelvin, joulepermolekelvin.As(MolarEntropyUnit.MegajoulePerMoleKelvin), MegajoulesPerMoleKelvinTolerance);
        }

        [Fact]
        public virtual void BaseUnit_HasSIBase()
        {
            var baseUnitInfo = MolarEntropy.Info.BaseUnitInfo;
            Assert.True(baseUnitInfo.BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public virtual void As_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new MolarEntropy(value: 1, unit: MolarEntropy.BaseUnit);
            var expectedValue = quantity.As(MolarEntropy.Info.GetDefaultUnit(UnitSystem.SI));

            var convertedValue = quantity.As(UnitSystem.SI);

            Assert.Equal(expectedValue, convertedValue);
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {
            var quantity = new MolarEntropy(value: 1, unit: MolarEntropy.BaseUnit);
            UnitSystem nullUnitSystem = null!;
            Assert.Throws<ArgumentNullException>(() => quantity.As(nullUnitSystem));
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new MolarEntropy(value: 1, unit: MolarEntropy.BaseUnit);
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => quantity.As(unsupportedUnitSystem));
        }

        [Fact]
        public virtual void ToUnit_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new MolarEntropy(value: 1, unit: MolarEntropy.BaseUnit);
            var expectedUnit = MolarEntropy.Info.GetDefaultUnit(UnitSystem.SI);
            var expectedValue = quantity.As(expectedUnit);

            Assert.Multiple(() =>
            {
                MolarEntropy quantityToConvert = quantity;

                MolarEntropy convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

                Assert.Equal(expectedUnit, convertedQuantity.Unit);
                Assert.Equal(expectedValue, convertedQuantity.Value);
            }, () =>
            {
                IQuantity<MolarEntropyUnit> quantityToConvert = quantity;

                IQuantity<MolarEntropyUnit> convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

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
                var quantity = new MolarEntropy(value: 1, unit: MolarEntropy.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity<MolarEntropyUnit> quantity = new MolarEntropy(value: 1, unit: MolarEntropy.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity quantity = new MolarEntropy(value: 1, unit: MolarEntropy.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            });
        }

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Multiple(() =>
            {
                var quantity = new MolarEntropy(value: 1, unit: MolarEntropy.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity<MolarEntropyUnit> quantity = new MolarEntropy(value: 1, unit: MolarEntropy.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity quantity = new MolarEntropy(value: 1, unit: MolarEntropy.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            });
        }

        [Fact]
        public void Parse()
        {
            try
            {
                var parsed = MolarEntropy.Parse("1 J/(mol·K)", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
                Assert.Equal(MolarEntropyUnit.JoulePerMoleKelvin, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = MolarEntropy.Parse("1 kJ/(mol·K)", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.KilojoulesPerMoleKelvin, KilojoulesPerMoleKelvinTolerance);
                Assert.Equal(MolarEntropyUnit.KilojoulePerMoleKelvin, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = MolarEntropy.Parse("1 MJ/(mol·K)", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.MegajoulesPerMoleKelvin, MegajoulesPerMoleKelvinTolerance);
                Assert.Equal(MolarEntropyUnit.MegajoulePerMoleKelvin, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(MolarEntropy.TryParse("1 J/(mol·K)", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
                Assert.Equal(MolarEntropyUnit.JoulePerMoleKelvin, parsed.Unit);
            }

            {
                Assert.True(MolarEntropy.TryParse("1 kJ/(mol·K)", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.KilojoulesPerMoleKelvin, KilojoulesPerMoleKelvinTolerance);
                Assert.Equal(MolarEntropyUnit.KilojoulePerMoleKelvin, parsed.Unit);
            }

            {
                Assert.True(MolarEntropy.TryParse("1 MJ/(mol·K)", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.MegajoulesPerMoleKelvin, MegajoulesPerMoleKelvinTolerance);
                Assert.Equal(MolarEntropyUnit.MegajoulePerMoleKelvin, parsed.Unit);
            }

        }

        [Theory]
        [InlineData("J/(mol·K)", MolarEntropyUnit.JoulePerMoleKelvin)]
        [InlineData("kJ/(mol·K)", MolarEntropyUnit.KilojoulePerMoleKelvin)]
        [InlineData("MJ/(mol·K)", MolarEntropyUnit.MegajoulePerMoleKelvin)]
        public void ParseUnit_WithUsEnglishCurrentCulture(string abbreviation, MolarEntropyUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            MolarEntropyUnit parsedUnit = MolarEntropy.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("J/(mol·K)", MolarEntropyUnit.JoulePerMoleKelvin)]
        [InlineData("kJ/(mol·K)", MolarEntropyUnit.KilojoulePerMoleKelvin)]
        [InlineData("MJ/(mol·K)", MolarEntropyUnit.MegajoulePerMoleKelvin)]
        public void ParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, MolarEntropyUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            MolarEntropyUnit parsedUnit = MolarEntropy.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "J/(mol·K)", MolarEntropyUnit.JoulePerMoleKelvin)]
        [InlineData("en-US", "kJ/(mol·K)", MolarEntropyUnit.KilojoulePerMoleKelvin)]
        [InlineData("en-US", "MJ/(mol·K)", MolarEntropyUnit.MegajoulePerMoleKelvin)]
        public void ParseUnit_WithCurrentCulture(string culture, string abbreviation, MolarEntropyUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            MolarEntropyUnit parsedUnit = MolarEntropy.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "J/(mol·K)", MolarEntropyUnit.JoulePerMoleKelvin)]
        [InlineData("en-US", "kJ/(mol·K)", MolarEntropyUnit.KilojoulePerMoleKelvin)]
        [InlineData("en-US", "MJ/(mol·K)", MolarEntropyUnit.MegajoulePerMoleKelvin)]
        public void ParseUnit_WithCulture(string culture, string abbreviation, MolarEntropyUnit expectedUnit)
        {
            MolarEntropyUnit parsedUnit = MolarEntropy.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("J/(mol·K)", MolarEntropyUnit.JoulePerMoleKelvin)]
        [InlineData("kJ/(mol·K)", MolarEntropyUnit.KilojoulePerMoleKelvin)]
        [InlineData("MJ/(mol·K)", MolarEntropyUnit.MegajoulePerMoleKelvin)]
        public void TryParseUnit_WithUsEnglishCurrentCulture(string abbreviation, MolarEntropyUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            Assert.True(MolarEntropy.TryParseUnit(abbreviation, out MolarEntropyUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("J/(mol·K)", MolarEntropyUnit.JoulePerMoleKelvin)]
        [InlineData("kJ/(mol·K)", MolarEntropyUnit.KilojoulePerMoleKelvin)]
        [InlineData("MJ/(mol·K)", MolarEntropyUnit.MegajoulePerMoleKelvin)]
        public void TryParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, MolarEntropyUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            Assert.True(MolarEntropy.TryParseUnit(abbreviation, out MolarEntropyUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "J/(mol·K)", MolarEntropyUnit.JoulePerMoleKelvin)]
        [InlineData("en-US", "kJ/(mol·K)", MolarEntropyUnit.KilojoulePerMoleKelvin)]
        [InlineData("en-US", "MJ/(mol·K)", MolarEntropyUnit.MegajoulePerMoleKelvin)]
        public void TryParseUnit_WithCurrentCulture(string culture, string abbreviation, MolarEntropyUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            Assert.True(MolarEntropy.TryParseUnit(abbreviation, out MolarEntropyUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "J/(mol·K)", MolarEntropyUnit.JoulePerMoleKelvin)]
        [InlineData("en-US", "kJ/(mol·K)", MolarEntropyUnit.KilojoulePerMoleKelvin)]
        [InlineData("en-US", "MJ/(mol·K)", MolarEntropyUnit.MegajoulePerMoleKelvin)]
        public void TryParseUnit_WithCulture(string culture, string abbreviation, MolarEntropyUnit expectedUnit)
        {
            Assert.True(MolarEntropy.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out MolarEntropyUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(MolarEntropyUnit unit)
        {
            var inBaseUnits = MolarEntropy.From(1.0, MolarEntropy.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(MolarEntropyUnit unit)
        {
            var quantity = MolarEntropy.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(MolarEntropyUnit unit)
        {
            Assert.All(MolarEntropy.Units.Where(u => u != MolarEntropy.BaseUnit), fromUnit =>
            {
                var quantity = MolarEntropy.From(3.0, fromUnit);
                var converted = quantity.ToUnit(unit);
                Assert.Equal(converted.Unit, unit);
            });
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(MolarEntropyUnit unit)
        {
            var quantity = default(MolarEntropy);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromIQuantity_ReturnsTheExpectedIQuantity(MolarEntropyUnit unit)
        {
            var quantity = MolarEntropy.From(3, MolarEntropy.BaseUnit);
            MolarEntropy expectedQuantity = quantity.ToUnit(unit);
            Assert.Multiple(() =>
            {
                IQuantity<MolarEntropyUnit> quantityToConvert = quantity;
                IQuantity<MolarEntropyUnit> convertedQuantity = quantityToConvert.ToUnit(unit);
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
            MolarEntropy joulepermolekelvin = MolarEntropy.FromJoulesPerMoleKelvin(1);
            AssertEx.EqualTolerance(1, MolarEntropy.FromJoulesPerMoleKelvin(joulepermolekelvin.JoulesPerMoleKelvin).JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(1, MolarEntropy.FromKilojoulesPerMoleKelvin(joulepermolekelvin.KilojoulesPerMoleKelvin).JoulesPerMoleKelvin, KilojoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(1, MolarEntropy.FromMegajoulesPerMoleKelvin(joulepermolekelvin.MegajoulesPerMoleKelvin).JoulesPerMoleKelvin, MegajoulesPerMoleKelvinTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            MolarEntropy v = MolarEntropy.FromJoulesPerMoleKelvin(1);
            AssertEx.EqualTolerance(-1, -v.JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(2, (MolarEntropy.FromJoulesPerMoleKelvin(3)-v).JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(2, (v + v).JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(10, (v*10).JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(10, (10*v).JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(2, (MolarEntropy.FromJoulesPerMoleKelvin(10)/5).JoulesPerMoleKelvin, JoulesPerMoleKelvinTolerance);
            AssertEx.EqualTolerance(2, MolarEntropy.FromJoulesPerMoleKelvin(10)/MolarEntropy.FromJoulesPerMoleKelvin(5), JoulesPerMoleKelvinTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            MolarEntropy oneJoulePerMoleKelvin = MolarEntropy.FromJoulesPerMoleKelvin(1);
            MolarEntropy twoJoulesPerMoleKelvin = MolarEntropy.FromJoulesPerMoleKelvin(2);

            Assert.True(oneJoulePerMoleKelvin < twoJoulesPerMoleKelvin);
            Assert.True(oneJoulePerMoleKelvin <= twoJoulesPerMoleKelvin);
            Assert.True(twoJoulesPerMoleKelvin > oneJoulePerMoleKelvin);
            Assert.True(twoJoulesPerMoleKelvin >= oneJoulePerMoleKelvin);

            Assert.False(oneJoulePerMoleKelvin > twoJoulesPerMoleKelvin);
            Assert.False(oneJoulePerMoleKelvin >= twoJoulesPerMoleKelvin);
            Assert.False(twoJoulesPerMoleKelvin < oneJoulePerMoleKelvin);
            Assert.False(twoJoulesPerMoleKelvin <= oneJoulePerMoleKelvin);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            MolarEntropy joulepermolekelvin = MolarEntropy.FromJoulesPerMoleKelvin(1);
            Assert.Equal(0, joulepermolekelvin.CompareTo(joulepermolekelvin));
            Assert.True(joulepermolekelvin.CompareTo(MolarEntropy.Zero) > 0);
            Assert.True(MolarEntropy.Zero.CompareTo(joulepermolekelvin) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            MolarEntropy joulepermolekelvin = MolarEntropy.FromJoulesPerMoleKelvin(1);
            Assert.Throws<ArgumentException>(() => joulepermolekelvin.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            MolarEntropy joulepermolekelvin = MolarEntropy.FromJoulesPerMoleKelvin(1);
            Assert.Throws<ArgumentNullException>(() => joulepermolekelvin.CompareTo(null));
        }

        [Theory]
        [InlineData(1, MolarEntropyUnit.JoulePerMoleKelvin, 1, MolarEntropyUnit.JoulePerMoleKelvin, true)]  // Same value and unit.
        [InlineData(1, MolarEntropyUnit.JoulePerMoleKelvin, 2, MolarEntropyUnit.JoulePerMoleKelvin, false)] // Different value.
        [InlineData(2, MolarEntropyUnit.JoulePerMoleKelvin, 1, MolarEntropyUnit.KilojoulePerMoleKelvin, false)] // Different value and unit.
        [InlineData(1, MolarEntropyUnit.JoulePerMoleKelvin, 1, MolarEntropyUnit.KilojoulePerMoleKelvin, false)] // Different unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, MolarEntropyUnit unitA, double valueB, MolarEntropyUnit unitB, bool expectEqual)
        {
            var a = new MolarEntropy(valueA, unitA);
            var b = new MolarEntropy(valueB, unitB);

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
            var a = MolarEntropy.Zero;

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
            var v = MolarEntropy.FromJoulesPerMoleKelvin(1);
            Assert.True(v.Equals(MolarEntropy.FromJoulesPerMoleKelvin(1), JoulesPerMoleKelvinTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(MolarEntropy.Zero, JoulesPerMoleKelvinTolerance, ComparisonType.Relative));
            Assert.True(MolarEntropy.FromJoulesPerMoleKelvin(100).Equals(MolarEntropy.FromJoulesPerMoleKelvin(120), 0.3, ComparisonType.Relative));
            Assert.False(MolarEntropy.FromJoulesPerMoleKelvin(100).Equals(MolarEntropy.FromJoulesPerMoleKelvin(120), 0.1, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = MolarEntropy.FromJoulesPerMoleKelvin(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(MolarEntropy.FromJoulesPerMoleKelvin(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            MolarEntropy joulepermolekelvin = MolarEntropy.FromJoulesPerMoleKelvin(1);
            Assert.False(joulepermolekelvin.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            MolarEntropy joulepermolekelvin = MolarEntropy.FromJoulesPerMoleKelvin(1);
            Assert.False(joulepermolekelvin.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = EnumHelpers.GetValues<MolarEntropyUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(MolarEntropy.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            using var _ = new CultureScope("en-US");
            Assert.Equal("1 J/(mol·K)", new MolarEntropy(1, MolarEntropyUnit.JoulePerMoleKelvin).ToString());
            Assert.Equal("1 kJ/(mol·K)", new MolarEntropy(1, MolarEntropyUnit.KilojoulePerMoleKelvin).ToString());
            Assert.Equal("1 MJ/(mol·K)", new MolarEntropy(1, MolarEntropyUnit.MegajoulePerMoleKelvin).ToString());
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 J/(mol·K)", new MolarEntropy(1, MolarEntropyUnit.JoulePerMoleKelvin).ToString(swedishCulture));
            Assert.Equal("1 kJ/(mol·K)", new MolarEntropy(1, MolarEntropyUnit.KilojoulePerMoleKelvin).ToString(swedishCulture));
            Assert.Equal("1 MJ/(mol·K)", new MolarEntropy(1, MolarEntropyUnit.MegajoulePerMoleKelvin).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var _ = new CultureScope(CultureInfo.InvariantCulture);
            Assert.Equal("0.1 J/(mol·K)", new MolarEntropy(0.123456, MolarEntropyUnit.JoulePerMoleKelvin).ToString("s1"));
            Assert.Equal("0.12 J/(mol·K)", new MolarEntropy(0.123456, MolarEntropyUnit.JoulePerMoleKelvin).ToString("s2"));
            Assert.Equal("0.123 J/(mol·K)", new MolarEntropy(0.123456, MolarEntropyUnit.JoulePerMoleKelvin).ToString("s3"));
            Assert.Equal("0.1235 J/(mol·K)", new MolarEntropy(0.123456, MolarEntropyUnit.JoulePerMoleKelvin).ToString("s4"));
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 J/(mol·K)", new MolarEntropy(0.123456, MolarEntropyUnit.JoulePerMoleKelvin).ToString("s1", culture));
            Assert.Equal("0.12 J/(mol·K)", new MolarEntropy(0.123456, MolarEntropyUnit.JoulePerMoleKelvin).ToString("s2", culture));
            Assert.Equal("0.123 J/(mol·K)", new MolarEntropy(0.123456, MolarEntropyUnit.JoulePerMoleKelvin).ToString("s3", culture));
            Assert.Equal("0.1235 J/(mol·K)", new MolarEntropy(0.123456, MolarEntropyUnit.JoulePerMoleKelvin).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
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
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(MolarEntropy)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(MolarEntropyUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal(MolarEntropy.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal(MolarEntropy.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void Convert_GetTypeCode_Returns_Object()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal(TypeCode.Object, Convert.GetTypeCode(quantity));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(1.0);
            Assert.Equal(new {MolarEntropy.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = MolarEntropy.FromJoulesPerMoleKelvin(value);
            Assert.Equal(MolarEntropy.FromJoulesPerMoleKelvin(-value), -quantity);
        }
    }
}
