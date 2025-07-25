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
    /// Test of MolarEnergy.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MolarEnergyTestsBase : QuantityTestsBase
    {
        protected abstract double JoulesPerMoleInOneJoulePerMole { get; }
        protected abstract double KilojoulesPerMoleInOneJoulePerMole { get; }
        protected abstract double MegajoulesPerMoleInOneJoulePerMole { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double JoulesPerMoleTolerance { get { return 1e-5; } }
        protected virtual double KilojoulesPerMoleTolerance { get { return 1e-5; } }
        protected virtual double MegajoulesPerMoleTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(MolarEnergyUnit unit)
        {
            return unit switch
            {
                MolarEnergyUnit.JoulePerMole => (JoulesPerMoleInOneJoulePerMole, JoulesPerMoleTolerance),
                MolarEnergyUnit.KilojoulePerMole => (KilojoulesPerMoleInOneJoulePerMole, KilojoulesPerMoleTolerance),
                MolarEnergyUnit.MegajoulePerMole => (MegajoulesPerMoleInOneJoulePerMole, MegajoulesPerMoleTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { MolarEnergyUnit.JoulePerMole },
            new object[] { MolarEnergyUnit.KilojoulePerMole },
            new object[] { MolarEnergyUnit.MegajoulePerMole },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new MolarEnergy();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(MolarEnergyUnit.JoulePerMole, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => new MolarEnergy(double.PositiveInfinity, MolarEnergyUnit.JoulePerMole));
            var exception2 = Record.Exception(() => new MolarEnergy(double.NegativeInfinity, MolarEnergyUnit.JoulePerMole));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => new MolarEnergy(double.NaN, MolarEnergyUnit.JoulePerMole));

            Assert.Null(exception);
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new MolarEnergy(value: 1, unitSystem: null));
        }

        [Fact]
        public virtual void Ctor_SIUnitSystem_ReturnsQuantityWithSIUnits()
        {
            var quantity = new MolarEnergy(value: 1, unitSystem: UnitSystem.SI);
            Assert.Equal(1, quantity.Value);
            Assert.True(quantity.QuantityInfo.UnitInfos.First(x => x.Value == quantity.Unit).BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public void Ctor_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => new MolarEnergy(value: 1, unitSystem: unsupportedUnitSystem));
        }

        [Fact]
        public void MolarEnergy_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new MolarEnergy(1, MolarEnergyUnit.JoulePerMole);

            QuantityInfo<MolarEnergyUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(MolarEnergy.Zero, quantityInfo.Zero);
            Assert.Equal("MolarEnergy", quantityInfo.Name);

            var units = Enum.GetValues<MolarEnergyUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void JoulePerMoleToMolarEnergyUnits()
        {
            MolarEnergy joulepermole = MolarEnergy.FromJoulesPerMole(1);
            AssertEx.EqualTolerance(JoulesPerMoleInOneJoulePerMole, joulepermole.JoulesPerMole, JoulesPerMoleTolerance);
            AssertEx.EqualTolerance(KilojoulesPerMoleInOneJoulePerMole, joulepermole.KilojoulesPerMole, KilojoulesPerMoleTolerance);
            AssertEx.EqualTolerance(MegajoulesPerMoleInOneJoulePerMole, joulepermole.MegajoulesPerMole, MegajoulesPerMoleTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = MolarEnergy.From(1, MolarEnergyUnit.JoulePerMole);
            AssertEx.EqualTolerance(1, quantity00.JoulesPerMole, JoulesPerMoleTolerance);
            Assert.Equal(MolarEnergyUnit.JoulePerMole, quantity00.Unit);

            var quantity01 = MolarEnergy.From(1, MolarEnergyUnit.KilojoulePerMole);
            AssertEx.EqualTolerance(1, quantity01.KilojoulesPerMole, KilojoulesPerMoleTolerance);
            Assert.Equal(MolarEnergyUnit.KilojoulePerMole, quantity01.Unit);

            var quantity02 = MolarEnergy.From(1, MolarEnergyUnit.MegajoulePerMole);
            AssertEx.EqualTolerance(1, quantity02.MegajoulesPerMole, MegajoulesPerMoleTolerance);
            Assert.Equal(MolarEnergyUnit.MegajoulePerMole, quantity02.Unit);

        }

        [Fact]
        public void FromJoulesPerMole_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => MolarEnergy.FromJoulesPerMole(double.PositiveInfinity));
            var exception2 = Record.Exception(() => MolarEnergy.FromJoulesPerMole(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void FromJoulesPerMole_WithNanValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => MolarEnergy.FromJoulesPerMole(double.NaN));

            Assert.Null(exception);
        }

        [Fact]
        public void As()
        {
            var joulepermole = MolarEnergy.FromJoulesPerMole(1);
            AssertEx.EqualTolerance(JoulesPerMoleInOneJoulePerMole, joulepermole.As(MolarEnergyUnit.JoulePerMole), JoulesPerMoleTolerance);
            AssertEx.EqualTolerance(KilojoulesPerMoleInOneJoulePerMole, joulepermole.As(MolarEnergyUnit.KilojoulePerMole), KilojoulesPerMoleTolerance);
            AssertEx.EqualTolerance(MegajoulesPerMoleInOneJoulePerMole, joulepermole.As(MolarEnergyUnit.MegajoulePerMole), MegajoulesPerMoleTolerance);
        }

        [Fact]
        public virtual void BaseUnit_HasSIBase()
        {
            var baseUnitInfo = MolarEnergy.Info.BaseUnitInfo;
            Assert.True(baseUnitInfo.BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public virtual void As_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new MolarEnergy(value: 1, unit: MolarEnergy.BaseUnit);
            var expectedValue = quantity.As(MolarEnergy.Info.GetDefaultUnit(UnitSystem.SI));

            var convertedValue = quantity.As(UnitSystem.SI);

            Assert.Equal(expectedValue, convertedValue);
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {
            var quantity = new MolarEnergy(value: 1, unit: MolarEnergy.BaseUnit);
            UnitSystem nullUnitSystem = null!;
            Assert.Throws<ArgumentNullException>(() => quantity.As(nullUnitSystem));
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new MolarEnergy(value: 1, unit: MolarEnergy.BaseUnit);
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => quantity.As(unsupportedUnitSystem));
        }

        [Fact]
        public virtual void ToUnit_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new MolarEnergy(value: 1, unit: MolarEnergy.BaseUnit);
            var expectedUnit = MolarEnergy.Info.GetDefaultUnit(UnitSystem.SI);
            var expectedValue = quantity.As(expectedUnit);

            Assert.Multiple(() =>
            {
                MolarEnergy quantityToConvert = quantity;

                MolarEnergy convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

                Assert.Equal(expectedUnit, convertedQuantity.Unit);
                Assert.Equal(expectedValue, convertedQuantity.Value);
            }, () =>
            {
                IQuantity<MolarEnergyUnit> quantityToConvert = quantity;

                IQuantity<MolarEnergyUnit> convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

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
                var quantity = new MolarEnergy(value: 1, unit: MolarEnergy.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity<MolarEnergyUnit> quantity = new MolarEnergy(value: 1, unit: MolarEnergy.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity quantity = new MolarEnergy(value: 1, unit: MolarEnergy.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            });
        }

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Multiple(() =>
            {
                var quantity = new MolarEnergy(value: 1, unit: MolarEnergy.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity<MolarEnergyUnit> quantity = new MolarEnergy(value: 1, unit: MolarEnergy.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity quantity = new MolarEnergy(value: 1, unit: MolarEnergy.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            });
        }

        [Fact]
        public void Parse()
        {
            try
            {
                var parsed = MolarEnergy.Parse("1 J/mol", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.JoulesPerMole, JoulesPerMoleTolerance);
                Assert.Equal(MolarEnergyUnit.JoulePerMole, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = MolarEnergy.Parse("1 kJ/mol", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.KilojoulesPerMole, KilojoulesPerMoleTolerance);
                Assert.Equal(MolarEnergyUnit.KilojoulePerMole, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = MolarEnergy.Parse("1 MJ/mol", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.MegajoulesPerMole, MegajoulesPerMoleTolerance);
                Assert.Equal(MolarEnergyUnit.MegajoulePerMole, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(MolarEnergy.TryParse("1 J/mol", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.JoulesPerMole, JoulesPerMoleTolerance);
                Assert.Equal(MolarEnergyUnit.JoulePerMole, parsed.Unit);
            }

            {
                Assert.True(MolarEnergy.TryParse("1 kJ/mol", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.KilojoulesPerMole, KilojoulesPerMoleTolerance);
                Assert.Equal(MolarEnergyUnit.KilojoulePerMole, parsed.Unit);
            }

            {
                Assert.True(MolarEnergy.TryParse("1 MJ/mol", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.MegajoulesPerMole, MegajoulesPerMoleTolerance);
                Assert.Equal(MolarEnergyUnit.MegajoulePerMole, parsed.Unit);
            }

        }

        [Theory]
        [InlineData("J/mol", MolarEnergyUnit.JoulePerMole)]
        [InlineData("kJ/mol", MolarEnergyUnit.KilojoulePerMole)]
        [InlineData("MJ/mol", MolarEnergyUnit.MegajoulePerMole)]
        public void ParseUnit_WithUsEnglishCurrentCulture(string abbreviation, MolarEnergyUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            MolarEnergyUnit parsedUnit = MolarEnergy.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("J/mol", MolarEnergyUnit.JoulePerMole)]
        [InlineData("kJ/mol", MolarEnergyUnit.KilojoulePerMole)]
        [InlineData("MJ/mol", MolarEnergyUnit.MegajoulePerMole)]
        public void ParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, MolarEnergyUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            MolarEnergyUnit parsedUnit = MolarEnergy.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "J/mol", MolarEnergyUnit.JoulePerMole)]
        [InlineData("en-US", "kJ/mol", MolarEnergyUnit.KilojoulePerMole)]
        [InlineData("en-US", "MJ/mol", MolarEnergyUnit.MegajoulePerMole)]
        public void ParseUnit_WithCurrentCulture(string culture, string abbreviation, MolarEnergyUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            MolarEnergyUnit parsedUnit = MolarEnergy.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "J/mol", MolarEnergyUnit.JoulePerMole)]
        [InlineData("en-US", "kJ/mol", MolarEnergyUnit.KilojoulePerMole)]
        [InlineData("en-US", "MJ/mol", MolarEnergyUnit.MegajoulePerMole)]
        public void ParseUnit_WithCulture(string culture, string abbreviation, MolarEnergyUnit expectedUnit)
        {
            MolarEnergyUnit parsedUnit = MolarEnergy.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("J/mol", MolarEnergyUnit.JoulePerMole)]
        [InlineData("kJ/mol", MolarEnergyUnit.KilojoulePerMole)]
        [InlineData("MJ/mol", MolarEnergyUnit.MegajoulePerMole)]
        public void TryParseUnit_WithUsEnglishCurrentCulture(string abbreviation, MolarEnergyUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            Assert.True(MolarEnergy.TryParseUnit(abbreviation, out MolarEnergyUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("J/mol", MolarEnergyUnit.JoulePerMole)]
        [InlineData("kJ/mol", MolarEnergyUnit.KilojoulePerMole)]
        [InlineData("MJ/mol", MolarEnergyUnit.MegajoulePerMole)]
        public void TryParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, MolarEnergyUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            Assert.True(MolarEnergy.TryParseUnit(abbreviation, out MolarEnergyUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "J/mol", MolarEnergyUnit.JoulePerMole)]
        [InlineData("en-US", "kJ/mol", MolarEnergyUnit.KilojoulePerMole)]
        [InlineData("en-US", "MJ/mol", MolarEnergyUnit.MegajoulePerMole)]
        public void TryParseUnit_WithCurrentCulture(string culture, string abbreviation, MolarEnergyUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            Assert.True(MolarEnergy.TryParseUnit(abbreviation, out MolarEnergyUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "J/mol", MolarEnergyUnit.JoulePerMole)]
        [InlineData("en-US", "kJ/mol", MolarEnergyUnit.KilojoulePerMole)]
        [InlineData("en-US", "MJ/mol", MolarEnergyUnit.MegajoulePerMole)]
        public void TryParseUnit_WithCulture(string culture, string abbreviation, MolarEnergyUnit expectedUnit)
        {
            Assert.True(MolarEnergy.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out MolarEnergyUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(MolarEnergyUnit unit)
        {
            var inBaseUnits = MolarEnergy.From(1.0, MolarEnergy.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(MolarEnergyUnit unit)
        {
            var quantity = MolarEnergy.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(MolarEnergyUnit unit)
        {
            Assert.All(MolarEnergy.Units.Where(u => u != MolarEnergy.BaseUnit), fromUnit =>
            {
                var quantity = MolarEnergy.From(3.0, fromUnit);
                var converted = quantity.ToUnit(unit);
                Assert.Equal(converted.Unit, unit);
            });
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(MolarEnergyUnit unit)
        {
            var quantity = default(MolarEnergy);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromIQuantity_ReturnsTheExpectedIQuantity(MolarEnergyUnit unit)
        {
            var quantity = MolarEnergy.From(3, MolarEnergy.BaseUnit);
            MolarEnergy expectedQuantity = quantity.ToUnit(unit);
            Assert.Multiple(() =>
            {
                IQuantity<MolarEnergyUnit> quantityToConvert = quantity;
                IQuantity<MolarEnergyUnit> convertedQuantity = quantityToConvert.ToUnit(unit);
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
            MolarEnergy joulepermole = MolarEnergy.FromJoulesPerMole(1);
            AssertEx.EqualTolerance(1, MolarEnergy.FromJoulesPerMole(joulepermole.JoulesPerMole).JoulesPerMole, JoulesPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarEnergy.FromKilojoulesPerMole(joulepermole.KilojoulesPerMole).JoulesPerMole, KilojoulesPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarEnergy.FromMegajoulesPerMole(joulepermole.MegajoulesPerMole).JoulesPerMole, MegajoulesPerMoleTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            MolarEnergy v = MolarEnergy.FromJoulesPerMole(1);
            AssertEx.EqualTolerance(-1, -v.JoulesPerMole, JoulesPerMoleTolerance);
            AssertEx.EqualTolerance(2, (MolarEnergy.FromJoulesPerMole(3)-v).JoulesPerMole, JoulesPerMoleTolerance);
            AssertEx.EqualTolerance(2, (v + v).JoulesPerMole, JoulesPerMoleTolerance);
            AssertEx.EqualTolerance(10, (v*10).JoulesPerMole, JoulesPerMoleTolerance);
            AssertEx.EqualTolerance(10, (10*v).JoulesPerMole, JoulesPerMoleTolerance);
            AssertEx.EqualTolerance(2, (MolarEnergy.FromJoulesPerMole(10)/5).JoulesPerMole, JoulesPerMoleTolerance);
            AssertEx.EqualTolerance(2, MolarEnergy.FromJoulesPerMole(10)/MolarEnergy.FromJoulesPerMole(5), JoulesPerMoleTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            MolarEnergy oneJoulePerMole = MolarEnergy.FromJoulesPerMole(1);
            MolarEnergy twoJoulesPerMole = MolarEnergy.FromJoulesPerMole(2);

            Assert.True(oneJoulePerMole < twoJoulesPerMole);
            Assert.True(oneJoulePerMole <= twoJoulesPerMole);
            Assert.True(twoJoulesPerMole > oneJoulePerMole);
            Assert.True(twoJoulesPerMole >= oneJoulePerMole);

            Assert.False(oneJoulePerMole > twoJoulesPerMole);
            Assert.False(oneJoulePerMole >= twoJoulesPerMole);
            Assert.False(twoJoulesPerMole < oneJoulePerMole);
            Assert.False(twoJoulesPerMole <= oneJoulePerMole);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            MolarEnergy joulepermole = MolarEnergy.FromJoulesPerMole(1);
            Assert.Equal(0, joulepermole.CompareTo(joulepermole));
            Assert.True(joulepermole.CompareTo(MolarEnergy.Zero) > 0);
            Assert.True(MolarEnergy.Zero.CompareTo(joulepermole) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            MolarEnergy joulepermole = MolarEnergy.FromJoulesPerMole(1);
            Assert.Throws<ArgumentException>(() => joulepermole.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            MolarEnergy joulepermole = MolarEnergy.FromJoulesPerMole(1);
            Assert.Throws<ArgumentNullException>(() => joulepermole.CompareTo(null));
        }

        [Theory]
        [InlineData(1, MolarEnergyUnit.JoulePerMole, 1, MolarEnergyUnit.JoulePerMole, true)]  // Same value and unit.
        [InlineData(1, MolarEnergyUnit.JoulePerMole, 2, MolarEnergyUnit.JoulePerMole, false)] // Different value.
        [InlineData(2, MolarEnergyUnit.JoulePerMole, 1, MolarEnergyUnit.KilojoulePerMole, false)] // Different value and unit.
        [InlineData(1, MolarEnergyUnit.JoulePerMole, 1, MolarEnergyUnit.KilojoulePerMole, false)] // Different unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, MolarEnergyUnit unitA, double valueB, MolarEnergyUnit unitB, bool expectEqual)
        {
            var a = new MolarEnergy(valueA, unitA);
            var b = new MolarEnergy(valueB, unitB);

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
            var a = MolarEnergy.Zero;

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
            var v = MolarEnergy.FromJoulesPerMole(1);
            Assert.True(v.Equals(MolarEnergy.FromJoulesPerMole(1), JoulesPerMoleTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(MolarEnergy.Zero, JoulesPerMoleTolerance, ComparisonType.Relative));
            Assert.True(MolarEnergy.FromJoulesPerMole(100).Equals(MolarEnergy.FromJoulesPerMole(120), 0.3, ComparisonType.Relative));
            Assert.False(MolarEnergy.FromJoulesPerMole(100).Equals(MolarEnergy.FromJoulesPerMole(120), 0.1, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = MolarEnergy.FromJoulesPerMole(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(MolarEnergy.FromJoulesPerMole(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            MolarEnergy joulepermole = MolarEnergy.FromJoulesPerMole(1);
            Assert.False(joulepermole.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            MolarEnergy joulepermole = MolarEnergy.FromJoulesPerMole(1);
            Assert.False(joulepermole.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues<MolarEnergyUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(MolarEnergy.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            using var _ = new CultureScope("en-US");
            Assert.Equal("1 J/mol", new MolarEnergy(1, MolarEnergyUnit.JoulePerMole).ToString());
            Assert.Equal("1 kJ/mol", new MolarEnergy(1, MolarEnergyUnit.KilojoulePerMole).ToString());
            Assert.Equal("1 MJ/mol", new MolarEnergy(1, MolarEnergyUnit.MegajoulePerMole).ToString());
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 J/mol", new MolarEnergy(1, MolarEnergyUnit.JoulePerMole).ToString(swedishCulture));
            Assert.Equal("1 kJ/mol", new MolarEnergy(1, MolarEnergyUnit.KilojoulePerMole).ToString(swedishCulture));
            Assert.Equal("1 MJ/mol", new MolarEnergy(1, MolarEnergyUnit.MegajoulePerMole).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var _ = new CultureScope(CultureInfo.InvariantCulture);
            Assert.Equal("0.1 J/mol", new MolarEnergy(0.123456, MolarEnergyUnit.JoulePerMole).ToString("s1"));
            Assert.Equal("0.12 J/mol", new MolarEnergy(0.123456, MolarEnergyUnit.JoulePerMole).ToString("s2"));
            Assert.Equal("0.123 J/mol", new MolarEnergy(0.123456, MolarEnergyUnit.JoulePerMole).ToString("s3"));
            Assert.Equal("0.1235 J/mol", new MolarEnergy(0.123456, MolarEnergyUnit.JoulePerMole).ToString("s4"));
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 J/mol", new MolarEnergy(0.123456, MolarEnergyUnit.JoulePerMole).ToString("s1", culture));
            Assert.Equal("0.12 J/mol", new MolarEnergy(0.123456, MolarEnergyUnit.JoulePerMole).ToString("s2", culture));
            Assert.Equal("0.123 J/mol", new MolarEnergy(0.123456, MolarEnergyUnit.JoulePerMole).ToString("s3", culture));
            Assert.Equal("0.1235 J/mol", new MolarEnergy(0.123456, MolarEnergyUnit.JoulePerMole).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = MolarEnergy.FromJoulesPerMole(1.0);
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
            var quantity = MolarEnergy.FromJoulesPerMole(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = MolarEnergy.FromJoulesPerMole(1.0);
            Assert.Equal(new {MolarEnergy.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = MolarEnergy.FromJoulesPerMole(value);
            Assert.Equal(MolarEnergy.FromJoulesPerMole(-value), -quantity);
        }
    }
}
