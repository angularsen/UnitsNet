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
    /// Test of Molality.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MolalityTestsBase : QuantityTestsBase
    {
        protected abstract double MillimolesPerKilogramInOneMolePerKilogram { get; }
        protected abstract double MolesPerGramInOneMolePerKilogram { get; }
        protected abstract double MolesPerKilogramInOneMolePerKilogram { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double MillimolesPerKilogramTolerance { get { return 1e-5; } }
        protected virtual double MolesPerGramTolerance { get { return 1e-5; } }
        protected virtual double MolesPerKilogramTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(MolalityUnit unit)
        {
            return unit switch
            {
                MolalityUnit.MillimolePerKilogram => (MillimolesPerKilogramInOneMolePerKilogram, MillimolesPerKilogramTolerance),
                MolalityUnit.MolePerGram => (MolesPerGramInOneMolePerKilogram, MolesPerGramTolerance),
                MolalityUnit.MolePerKilogram => (MolesPerKilogramInOneMolePerKilogram, MolesPerKilogramTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { MolalityUnit.MillimolePerKilogram },
            new object[] { MolalityUnit.MolePerGram },
            new object[] { MolalityUnit.MolePerKilogram },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new Molality();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(MolalityUnit.MolePerKilogram, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => new Molality(double.PositiveInfinity, MolalityUnit.MolePerKilogram));
            var exception2 = Record.Exception(() => new Molality(double.NegativeInfinity, MolalityUnit.MolePerKilogram));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => new Molality(double.NaN, MolalityUnit.MolePerKilogram));

            Assert.Null(exception);
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Molality(value: 1, unitSystem: null));
        }

        [Fact]
        public virtual void Ctor_SIUnitSystem_ReturnsQuantityWithSIUnits()
        {
            var quantity = new Molality(value: 1, unitSystem: UnitSystem.SI);
            Assert.Equal(1, quantity.Value);
            Assert.True(quantity.QuantityInfo.UnitInfos.First(x => x.Value == quantity.Unit).BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public void Ctor_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => new Molality(value: 1, unitSystem: unsupportedUnitSystem));
        }

        [Fact]
        public void Molality_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new Molality(1, MolalityUnit.MolePerKilogram);

            QuantityInfo<MolalityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(Molality.Zero, quantityInfo.Zero);
            Assert.Equal("Molality", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<MolalityUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void MolePerKilogramToMolalityUnits()
        {
            Molality moleperkilogram = Molality.FromMolesPerKilogram(1);
            AssertEx.EqualTolerance(MillimolesPerKilogramInOneMolePerKilogram, moleperkilogram.MillimolesPerKilogram, MillimolesPerKilogramTolerance);
            AssertEx.EqualTolerance(MolesPerGramInOneMolePerKilogram, moleperkilogram.MolesPerGram, MolesPerGramTolerance);
            AssertEx.EqualTolerance(MolesPerKilogramInOneMolePerKilogram, moleperkilogram.MolesPerKilogram, MolesPerKilogramTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = Molality.From(1, MolalityUnit.MillimolePerKilogram);
            AssertEx.EqualTolerance(1, quantity00.MillimolesPerKilogram, MillimolesPerKilogramTolerance);
            Assert.Equal(MolalityUnit.MillimolePerKilogram, quantity00.Unit);

            var quantity01 = Molality.From(1, MolalityUnit.MolePerGram);
            AssertEx.EqualTolerance(1, quantity01.MolesPerGram, MolesPerGramTolerance);
            Assert.Equal(MolalityUnit.MolePerGram, quantity01.Unit);

            var quantity02 = Molality.From(1, MolalityUnit.MolePerKilogram);
            AssertEx.EqualTolerance(1, quantity02.MolesPerKilogram, MolesPerKilogramTolerance);
            Assert.Equal(MolalityUnit.MolePerKilogram, quantity02.Unit);

        }

        [Fact]
        public void FromMolesPerKilogram_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => Molality.FromMolesPerKilogram(double.PositiveInfinity));
            var exception2 = Record.Exception(() => Molality.FromMolesPerKilogram(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void FromMolesPerKilogram_WithNanValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => Molality.FromMolesPerKilogram(double.NaN));

            Assert.Null(exception);
        }

        [Fact]
        public void As()
        {
            var moleperkilogram = Molality.FromMolesPerKilogram(1);
            AssertEx.EqualTolerance(MillimolesPerKilogramInOneMolePerKilogram, moleperkilogram.As(MolalityUnit.MillimolePerKilogram), MillimolesPerKilogramTolerance);
            AssertEx.EqualTolerance(MolesPerGramInOneMolePerKilogram, moleperkilogram.As(MolalityUnit.MolePerGram), MolesPerGramTolerance);
            AssertEx.EqualTolerance(MolesPerKilogramInOneMolePerKilogram, moleperkilogram.As(MolalityUnit.MolePerKilogram), MolesPerKilogramTolerance);
        }

        [Fact]
        public virtual void BaseUnit_HasSIBase()
        {
            var baseUnitInfo = Molality.Info.BaseUnitInfo;
            Assert.True(baseUnitInfo.BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public virtual void As_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new Molality(value: 1, unit: Molality.BaseUnit);
            var expectedValue = quantity.As(Molality.Info.GetDefaultUnit(UnitSystem.SI));

            var convertedValue = quantity.As(UnitSystem.SI);

            Assert.Equal(expectedValue, convertedValue);
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {
            var quantity = new Molality(value: 1, unit: Molality.BaseUnit);
            UnitSystem nullUnitSystem = null!;
            Assert.Throws<ArgumentNullException>(() => quantity.As(nullUnitSystem));
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new Molality(value: 1, unit: Molality.BaseUnit);
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => quantity.As(unsupportedUnitSystem));
        }

        [Fact]
        public virtual void ToUnit_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new Molality(value: 1, unit: Molality.BaseUnit);
            var expectedUnit = Molality.Info.GetDefaultUnit(UnitSystem.SI);
            var expectedValue = quantity.As(expectedUnit);

            Assert.Multiple(() =>
            {
                Molality quantityToConvert = quantity;

                Molality convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

                Assert.Equal(expectedUnit, convertedQuantity.Unit);
                Assert.Equal(expectedValue, convertedQuantity.Value);
            }, () =>
            {
                IQuantity<MolalityUnit> quantityToConvert = quantity;

                IQuantity<MolalityUnit> convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

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
                var quantity = new Molality(value: 1, unit: Molality.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity<MolalityUnit> quantity = new Molality(value: 1, unit: Molality.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity quantity = new Molality(value: 1, unit: Molality.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            });
        }

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Multiple(() =>
            {
                var quantity = new Molality(value: 1, unit: Molality.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity<MolalityUnit> quantity = new Molality(value: 1, unit: Molality.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity quantity = new Molality(value: 1, unit: Molality.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            });
        }

        [Fact]
        public void Parse()
        {
            try
            {
                var parsed = Molality.Parse("1 mmol/kg", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.MillimolesPerKilogram, MillimolesPerKilogramTolerance);
                Assert.Equal(MolalityUnit.MillimolePerKilogram, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = Molality.Parse("1 mol/g", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.MolesPerGram, MolesPerGramTolerance);
                Assert.Equal(MolalityUnit.MolePerGram, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = Molality.Parse("1 mol/kg", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.MolesPerKilogram, MolesPerKilogramTolerance);
                Assert.Equal(MolalityUnit.MolePerKilogram, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(Molality.TryParse("1 mmol/kg", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.MillimolesPerKilogram, MillimolesPerKilogramTolerance);
                Assert.Equal(MolalityUnit.MillimolePerKilogram, parsed.Unit);
            }

            {
                Assert.True(Molality.TryParse("1 mol/g", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.MolesPerGram, MolesPerGramTolerance);
                Assert.Equal(MolalityUnit.MolePerGram, parsed.Unit);
            }

            {
                Assert.True(Molality.TryParse("1 mol/kg", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.MolesPerKilogram, MolesPerKilogramTolerance);
                Assert.Equal(MolalityUnit.MolePerKilogram, parsed.Unit);
            }

        }

        [Theory]
        [InlineData("mmol/kg", MolalityUnit.MillimolePerKilogram)]
        [InlineData("mol/g", MolalityUnit.MolePerGram)]
        [InlineData("mol/kg", MolalityUnit.MolePerKilogram)]
        public void ParseUnit_WithUsEnglishCurrentCulture(string abbreviation, MolalityUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            MolalityUnit parsedUnit = Molality.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("mmol/kg", MolalityUnit.MillimolePerKilogram)]
        [InlineData("mol/g", MolalityUnit.MolePerGram)]
        [InlineData("mol/kg", MolalityUnit.MolePerKilogram)]
        public void ParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, MolalityUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            MolalityUnit parsedUnit = Molality.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "mmol/kg", MolalityUnit.MillimolePerKilogram)]
        [InlineData("en-US", "mol/g", MolalityUnit.MolePerGram)]
        [InlineData("en-US", "mol/kg", MolalityUnit.MolePerKilogram)]
        public void ParseUnit_WithCurrentCulture(string culture, string abbreviation, MolalityUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            MolalityUnit parsedUnit = Molality.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "mmol/kg", MolalityUnit.MillimolePerKilogram)]
        [InlineData("en-US", "mol/g", MolalityUnit.MolePerGram)]
        [InlineData("en-US", "mol/kg", MolalityUnit.MolePerKilogram)]
        public void ParseUnit_WithCulture(string culture, string abbreviation, MolalityUnit expectedUnit)
        {
            MolalityUnit parsedUnit = Molality.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("mmol/kg", MolalityUnit.MillimolePerKilogram)]
        [InlineData("mol/g", MolalityUnit.MolePerGram)]
        [InlineData("mol/kg", MolalityUnit.MolePerKilogram)]
        public void TryParseUnit_WithUsEnglishCurrentCulture(string abbreviation, MolalityUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            Assert.True(Molality.TryParseUnit(abbreviation, out MolalityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("mmol/kg", MolalityUnit.MillimolePerKilogram)]
        [InlineData("mol/g", MolalityUnit.MolePerGram)]
        [InlineData("mol/kg", MolalityUnit.MolePerKilogram)]
        public void TryParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, MolalityUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            Assert.True(Molality.TryParseUnit(abbreviation, out MolalityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "mmol/kg", MolalityUnit.MillimolePerKilogram)]
        [InlineData("en-US", "mol/g", MolalityUnit.MolePerGram)]
        [InlineData("en-US", "mol/kg", MolalityUnit.MolePerKilogram)]
        public void TryParseUnit_WithCurrentCulture(string culture, string abbreviation, MolalityUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            Assert.True(Molality.TryParseUnit(abbreviation, out MolalityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "mmol/kg", MolalityUnit.MillimolePerKilogram)]
        [InlineData("en-US", "mol/g", MolalityUnit.MolePerGram)]
        [InlineData("en-US", "mol/kg", MolalityUnit.MolePerKilogram)]
        public void TryParseUnit_WithCulture(string culture, string abbreviation, MolalityUnit expectedUnit)
        {
            Assert.True(Molality.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out MolalityUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(MolalityUnit unit)
        {
            var inBaseUnits = Molality.From(1.0, Molality.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(MolalityUnit unit)
        {
            var quantity = Molality.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(MolalityUnit unit)
        {
            Assert.All(Molality.Units.Where(u => u != Molality.BaseUnit), fromUnit =>
            {
                var quantity = Molality.From(3.0, fromUnit);
                var converted = quantity.ToUnit(unit);
                Assert.Equal(converted.Unit, unit);
            });
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(MolalityUnit unit)
        {
            var quantity = default(Molality);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromIQuantity_ReturnsTheExpectedIQuantity(MolalityUnit unit)
        {
            var quantity = Molality.From(3, Molality.BaseUnit);
            Molality expectedQuantity = quantity.ToUnit(unit);
            Assert.Multiple(() =>
            {
                IQuantity<MolalityUnit> quantityToConvert = quantity;
                IQuantity<MolalityUnit> convertedQuantity = quantityToConvert.ToUnit(unit);
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
            Molality moleperkilogram = Molality.FromMolesPerKilogram(1);
            AssertEx.EqualTolerance(1, Molality.FromMillimolesPerKilogram(moleperkilogram.MillimolesPerKilogram).MolesPerKilogram, MillimolesPerKilogramTolerance);
            AssertEx.EqualTolerance(1, Molality.FromMolesPerGram(moleperkilogram.MolesPerGram).MolesPerKilogram, MolesPerGramTolerance);
            AssertEx.EqualTolerance(1, Molality.FromMolesPerKilogram(moleperkilogram.MolesPerKilogram).MolesPerKilogram, MolesPerKilogramTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Molality v = Molality.FromMolesPerKilogram(1);
            AssertEx.EqualTolerance(-1, -v.MolesPerKilogram, MolesPerKilogramTolerance);
            AssertEx.EqualTolerance(2, (Molality.FromMolesPerKilogram(3)-v).MolesPerKilogram, MolesPerKilogramTolerance);
            AssertEx.EqualTolerance(2, (v + v).MolesPerKilogram, MolesPerKilogramTolerance);
            AssertEx.EqualTolerance(10, (v*10).MolesPerKilogram, MolesPerKilogramTolerance);
            AssertEx.EqualTolerance(10, (10*v).MolesPerKilogram, MolesPerKilogramTolerance);
            AssertEx.EqualTolerance(2, (Molality.FromMolesPerKilogram(10)/5).MolesPerKilogram, MolesPerKilogramTolerance);
            AssertEx.EqualTolerance(2, Molality.FromMolesPerKilogram(10)/Molality.FromMolesPerKilogram(5), MolesPerKilogramTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            Molality oneMolePerKilogram = Molality.FromMolesPerKilogram(1);
            Molality twoMolesPerKilogram = Molality.FromMolesPerKilogram(2);

            Assert.True(oneMolePerKilogram < twoMolesPerKilogram);
            Assert.True(oneMolePerKilogram <= twoMolesPerKilogram);
            Assert.True(twoMolesPerKilogram > oneMolePerKilogram);
            Assert.True(twoMolesPerKilogram >= oneMolePerKilogram);

            Assert.False(oneMolePerKilogram > twoMolesPerKilogram);
            Assert.False(oneMolePerKilogram >= twoMolesPerKilogram);
            Assert.False(twoMolesPerKilogram < oneMolePerKilogram);
            Assert.False(twoMolesPerKilogram <= oneMolePerKilogram);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Molality moleperkilogram = Molality.FromMolesPerKilogram(1);
            Assert.Equal(0, moleperkilogram.CompareTo(moleperkilogram));
            Assert.True(moleperkilogram.CompareTo(Molality.Zero) > 0);
            Assert.True(Molality.Zero.CompareTo(moleperkilogram) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Molality moleperkilogram = Molality.FromMolesPerKilogram(1);
            Assert.Throws<ArgumentException>(() => moleperkilogram.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Molality moleperkilogram = Molality.FromMolesPerKilogram(1);
            Assert.Throws<ArgumentNullException>(() => moleperkilogram.CompareTo(null));
        }

        [Theory]
        [InlineData(1, MolalityUnit.MolePerKilogram, 1, MolalityUnit.MolePerKilogram, true)]  // Same value and unit.
        [InlineData(1, MolalityUnit.MolePerKilogram, 2, MolalityUnit.MolePerKilogram, false)] // Different value.
        [InlineData(2, MolalityUnit.MolePerKilogram, 1, MolalityUnit.MillimolePerKilogram, false)] // Different value and unit.
        [InlineData(1, MolalityUnit.MolePerKilogram, 1, MolalityUnit.MillimolePerKilogram, false)] // Different unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, MolalityUnit unitA, double valueB, MolalityUnit unitB, bool expectEqual)
        {
            var a = new Molality(valueA, unitA);
            var b = new Molality(valueB, unitB);

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
            var a = Molality.Zero;

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
            var v = Molality.FromMolesPerKilogram(1);
            Assert.True(v.Equals(Molality.FromMolesPerKilogram(1), MolesPerKilogramTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Molality.Zero, MolesPerKilogramTolerance, ComparisonType.Relative));
            Assert.True(Molality.FromMolesPerKilogram(100).Equals(Molality.FromMolesPerKilogram(120), 0.3, ComparisonType.Relative));
            Assert.False(Molality.FromMolesPerKilogram(100).Equals(Molality.FromMolesPerKilogram(120), 0.1, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = Molality.FromMolesPerKilogram(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(Molality.FromMolesPerKilogram(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Molality moleperkilogram = Molality.FromMolesPerKilogram(1);
            Assert.False(moleperkilogram.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Molality moleperkilogram = Molality.FromMolesPerKilogram(1);
            Assert.False(moleperkilogram.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = EnumHelpers.GetValues<MolalityUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(Molality.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            using var _ = new CultureScope("en-US");
            Assert.Equal("1 mmol/kg", new Molality(1, MolalityUnit.MillimolePerKilogram).ToString());
            Assert.Equal("1 mol/g", new Molality(1, MolalityUnit.MolePerGram).ToString());
            Assert.Equal("1 mol/kg", new Molality(1, MolalityUnit.MolePerKilogram).ToString());
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 mmol/kg", new Molality(1, MolalityUnit.MillimolePerKilogram).ToString(swedishCulture));
            Assert.Equal("1 mol/g", new Molality(1, MolalityUnit.MolePerGram).ToString(swedishCulture));
            Assert.Equal("1 mol/kg", new Molality(1, MolalityUnit.MolePerKilogram).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var _ = new CultureScope(CultureInfo.InvariantCulture);
            Assert.Equal("0.1 mol/kg", new Molality(0.123456, MolalityUnit.MolePerKilogram).ToString("s1"));
            Assert.Equal("0.12 mol/kg", new Molality(0.123456, MolalityUnit.MolePerKilogram).ToString("s2"));
            Assert.Equal("0.123 mol/kg", new Molality(0.123456, MolalityUnit.MolePerKilogram).ToString("s3"));
            Assert.Equal("0.1235 mol/kg", new Molality(0.123456, MolalityUnit.MolePerKilogram).ToString("s4"));
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 mol/kg", new Molality(0.123456, MolalityUnit.MolePerKilogram).ToString("s1", culture));
            Assert.Equal("0.12 mol/kg", new Molality(0.123456, MolalityUnit.MolePerKilogram).ToString("s2", culture));
            Assert.Equal("0.123 mol/kg", new Molality(0.123456, MolalityUnit.MolePerKilogram).ToString("s3", culture));
            Assert.Equal("0.1235 mol/kg", new Molality(0.123456, MolalityUnit.MolePerKilogram).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
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
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(Molality)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(MolalityUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal(Molality.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal(Molality.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void Convert_GetTypeCode_Returns_Object()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal(TypeCode.Object, Convert.GetTypeCode(quantity));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = Molality.FromMolesPerKilogram(1.0);
            Assert.Equal(new {Molality.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = Molality.FromMolesPerKilogram(value);
            Assert.Equal(Molality.FromMolesPerKilogram(-value), -quantity);
        }
    }
}
