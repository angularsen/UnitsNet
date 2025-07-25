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
    /// Test of ThermalResistance.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ThermalResistanceTestsBase : QuantityTestsBase
    {
        protected abstract double DegreesCelsiusPerWattInOneKelvinPerWatt { get; }
        protected abstract double KelvinsPerWattInOneKelvinPerWatt { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DegreesCelsiusPerWattTolerance { get { return 1e-5; } }
        protected virtual double KelvinsPerWattTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(ThermalResistanceUnit unit)
        {
            return unit switch
            {
                ThermalResistanceUnit.DegreeCelsiusPerWatt => (DegreesCelsiusPerWattInOneKelvinPerWatt, DegreesCelsiusPerWattTolerance),
                ThermalResistanceUnit.KelvinPerWatt => (KelvinsPerWattInOneKelvinPerWatt, KelvinsPerWattTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { ThermalResistanceUnit.DegreeCelsiusPerWatt },
            new object[] { ThermalResistanceUnit.KelvinPerWatt },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ThermalResistance();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ThermalResistanceUnit.KelvinPerWatt, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => new ThermalResistance(double.PositiveInfinity, ThermalResistanceUnit.KelvinPerWatt));
            var exception2 = Record.Exception(() => new ThermalResistance(double.NegativeInfinity, ThermalResistanceUnit.KelvinPerWatt));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => new ThermalResistance(double.NaN, ThermalResistanceUnit.KelvinPerWatt));

            Assert.Null(exception);
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ThermalResistance(value: 1, unitSystem: null));
        }

        [Fact]
        public virtual void Ctor_SIUnitSystem_ReturnsQuantityWithSIUnits()
        {
            var quantity = new ThermalResistance(value: 1, unitSystem: UnitSystem.SI);
            Assert.Equal(1, quantity.Value);
            Assert.True(quantity.QuantityInfo.UnitInfos.First(x => x.Value == quantity.Unit).BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public void Ctor_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => new ThermalResistance(value: 1, unitSystem: unsupportedUnitSystem));
        }

        [Fact]
        public void ThermalResistance_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ThermalResistance(1, ThermalResistanceUnit.KelvinPerWatt);

            QuantityInfo<ThermalResistanceUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ThermalResistance.Zero, quantityInfo.Zero);
            Assert.Equal("ThermalResistance", quantityInfo.Name);

            var units = Enum.GetValues<ThermalResistanceUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void KelvinPerWattToThermalResistanceUnits()
        {
            ThermalResistance kelvinperwatt = ThermalResistance.FromKelvinsPerWatt(1);
            AssertEx.EqualTolerance(DegreesCelsiusPerWattInOneKelvinPerWatt, kelvinperwatt.DegreesCelsiusPerWatt, DegreesCelsiusPerWattTolerance);
            AssertEx.EqualTolerance(KelvinsPerWattInOneKelvinPerWatt, kelvinperwatt.KelvinsPerWatt, KelvinsPerWattTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ThermalResistance.From(1, ThermalResistanceUnit.DegreeCelsiusPerWatt);
            AssertEx.EqualTolerance(1, quantity00.DegreesCelsiusPerWatt, DegreesCelsiusPerWattTolerance);
            Assert.Equal(ThermalResistanceUnit.DegreeCelsiusPerWatt, quantity00.Unit);

            var quantity01 = ThermalResistance.From(1, ThermalResistanceUnit.KelvinPerWatt);
            AssertEx.EqualTolerance(1, quantity01.KelvinsPerWatt, KelvinsPerWattTolerance);
            Assert.Equal(ThermalResistanceUnit.KelvinPerWatt, quantity01.Unit);

        }

        [Fact]
        public void FromKelvinsPerWatt_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => ThermalResistance.FromKelvinsPerWatt(double.PositiveInfinity));
            var exception2 = Record.Exception(() => ThermalResistance.FromKelvinsPerWatt(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void FromKelvinsPerWatt_WithNanValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => ThermalResistance.FromKelvinsPerWatt(double.NaN));

            Assert.Null(exception);
        }

        [Fact]
        public void As()
        {
            var kelvinperwatt = ThermalResistance.FromKelvinsPerWatt(1);
            AssertEx.EqualTolerance(DegreesCelsiusPerWattInOneKelvinPerWatt, kelvinperwatt.As(ThermalResistanceUnit.DegreeCelsiusPerWatt), DegreesCelsiusPerWattTolerance);
            AssertEx.EqualTolerance(KelvinsPerWattInOneKelvinPerWatt, kelvinperwatt.As(ThermalResistanceUnit.KelvinPerWatt), KelvinsPerWattTolerance);
        }

        [Fact]
        public virtual void BaseUnit_HasSIBase()
        {
            var baseUnitInfo = ThermalResistance.Info.BaseUnitInfo;
            Assert.True(baseUnitInfo.BaseUnits.IsSubsetOf(UnitSystem.SI.BaseUnits));
        }

        [Fact]
        public virtual void As_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new ThermalResistance(value: 1, unit: ThermalResistance.BaseUnit);
            var expectedValue = quantity.As(ThermalResistance.Info.GetDefaultUnit(UnitSystem.SI));

            var convertedValue = quantity.As(UnitSystem.SI);

            Assert.Equal(expectedValue, convertedValue);
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentNullExceptionIfNull()
        {
            var quantity = new ThermalResistance(value: 1, unit: ThermalResistance.BaseUnit);
            UnitSystem nullUnitSystem = null!;
            Assert.Throws<ArgumentNullException>(() => quantity.As(nullUnitSystem));
        }

        [Fact]
        public void As_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new ThermalResistance(value: 1, unit: ThermalResistance.BaseUnit);
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Throws<ArgumentException>(() => quantity.As(unsupportedUnitSystem));
        }

        [Fact]
        public virtual void ToUnit_UnitSystem_SI_ReturnsQuantityInSIUnits()
        {
            var quantity = new ThermalResistance(value: 1, unit: ThermalResistance.BaseUnit);
            var expectedUnit = ThermalResistance.Info.GetDefaultUnit(UnitSystem.SI);
            var expectedValue = quantity.As(expectedUnit);

            Assert.Multiple(() =>
            {
                ThermalResistance quantityToConvert = quantity;

                ThermalResistance convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

                Assert.Equal(expectedUnit, convertedQuantity.Unit);
                Assert.Equal(expectedValue, convertedQuantity.Value);
            }, () =>
            {
                IQuantity<ThermalResistanceUnit> quantityToConvert = quantity;

                IQuantity<ThermalResistanceUnit> convertedQuantity = quantityToConvert.ToUnit(UnitSystem.SI);

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
                var quantity = new ThermalResistance(value: 1, unit: ThermalResistance.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity<ThermalResistanceUnit> quantity = new ThermalResistance(value: 1, unit: ThermalResistance.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            }, () =>
            {
                IQuantity quantity = new ThermalResistance(value: 1, unit: ThermalResistance.BaseUnit);
                Assert.Throws<ArgumentNullException>(() => quantity.ToUnit(nullUnitSystem));
            });
        }

        [Fact]
        public void ToUnit_UnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var unsupportedUnitSystem = new UnitSystem(UnsupportedBaseUnits);
            Assert.Multiple(() =>
            {
                var quantity = new ThermalResistance(value: 1, unit: ThermalResistance.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity<ThermalResistanceUnit> quantity = new ThermalResistance(value: 1, unit: ThermalResistance.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            }, () =>
            {
                IQuantity quantity = new ThermalResistance(value: 1, unit: ThermalResistance.BaseUnit);
                Assert.Throws<ArgumentException>(() => quantity.ToUnit(unsupportedUnitSystem));
            });
        }

        [Fact]
        public void Parse()
        {
            try
            {
                var parsed = ThermalResistance.Parse("1 °C/W", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.DegreesCelsiusPerWatt, DegreesCelsiusPerWattTolerance);
                Assert.Equal(ThermalResistanceUnit.DegreeCelsiusPerWatt, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ThermalResistance.Parse("1 K/W", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.KelvinsPerWatt, KelvinsPerWattTolerance);
                Assert.Equal(ThermalResistanceUnit.KelvinPerWatt, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(ThermalResistance.TryParse("1 °C/W", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.DegreesCelsiusPerWatt, DegreesCelsiusPerWattTolerance);
                Assert.Equal(ThermalResistanceUnit.DegreeCelsiusPerWatt, parsed.Unit);
            }

            {
                Assert.True(ThermalResistance.TryParse("1 K/W", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.KelvinsPerWatt, KelvinsPerWattTolerance);
                Assert.Equal(ThermalResistanceUnit.KelvinPerWatt, parsed.Unit);
            }

        }

        [Theory]
        [InlineData("°C/W", ThermalResistanceUnit.DegreeCelsiusPerWatt)]
        [InlineData("K/W", ThermalResistanceUnit.KelvinPerWatt)]
        public void ParseUnit_WithUsEnglishCurrentCulture(string abbreviation, ThermalResistanceUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            ThermalResistanceUnit parsedUnit = ThermalResistance.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("°C/W", ThermalResistanceUnit.DegreeCelsiusPerWatt)]
        [InlineData("K/W", ThermalResistanceUnit.KelvinPerWatt)]
        public void ParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, ThermalResistanceUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            ThermalResistanceUnit parsedUnit = ThermalResistance.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "°C/W", ThermalResistanceUnit.DegreeCelsiusPerWatt)]
        [InlineData("en-US", "K/W", ThermalResistanceUnit.KelvinPerWatt)]
        public void ParseUnit_WithCurrentCulture(string culture, string abbreviation, ThermalResistanceUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            ThermalResistanceUnit parsedUnit = ThermalResistance.ParseUnit(abbreviation);
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "°C/W", ThermalResistanceUnit.DegreeCelsiusPerWatt)]
        [InlineData("en-US", "K/W", ThermalResistanceUnit.KelvinPerWatt)]
        public void ParseUnit_WithCulture(string culture, string abbreviation, ThermalResistanceUnit expectedUnit)
        {
            ThermalResistanceUnit parsedUnit = ThermalResistance.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("°C/W", ThermalResistanceUnit.DegreeCelsiusPerWatt)]
        [InlineData("K/W", ThermalResistanceUnit.KelvinPerWatt)]
        public void TryParseUnit_WithUsEnglishCurrentCulture(string abbreviation, ThermalResistanceUnit expectedUnit)
        {
            // Fallback culture "en-US" is always localized
            using var _ = new CultureScope("en-US");
            Assert.True(ThermalResistance.TryParseUnit(abbreviation, out ThermalResistanceUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("°C/W", ThermalResistanceUnit.DegreeCelsiusPerWatt)]
        [InlineData("K/W", ThermalResistanceUnit.KelvinPerWatt)]
        public void TryParseUnit_WithUnsupportedCurrentCulture_FallsBackToUsEnglish(string abbreviation, ThermalResistanceUnit expectedUnit)
        {
            // Currently, no abbreviations are localized for Icelandic, so it should fall back to "en-US" when parsing.
            using var _ = new CultureScope("is-IS");
            Assert.True(ThermalResistance.TryParseUnit(abbreviation, out ThermalResistanceUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "°C/W", ThermalResistanceUnit.DegreeCelsiusPerWatt)]
        [InlineData("en-US", "K/W", ThermalResistanceUnit.KelvinPerWatt)]
        public void TryParseUnit_WithCurrentCulture(string culture, string abbreviation, ThermalResistanceUnit expectedUnit)
        {
            using var _ = new CultureScope(culture);
            Assert.True(ThermalResistance.TryParseUnit(abbreviation, out ThermalResistanceUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "°C/W", ThermalResistanceUnit.DegreeCelsiusPerWatt)]
        [InlineData("en-US", "K/W", ThermalResistanceUnit.KelvinPerWatt)]
        public void TryParseUnit_WithCulture(string culture, string abbreviation, ThermalResistanceUnit expectedUnit)
        {
            Assert.True(ThermalResistance.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out ThermalResistanceUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(ThermalResistanceUnit unit)
        {
            var inBaseUnits = ThermalResistance.From(1.0, ThermalResistance.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(ThermalResistanceUnit unit)
        {
            var quantity = ThermalResistance.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(ThermalResistanceUnit unit)
        {
            Assert.All(ThermalResistance.Units.Where(u => u != ThermalResistance.BaseUnit), fromUnit =>
            {
                var quantity = ThermalResistance.From(3.0, fromUnit);
                var converted = quantity.ToUnit(unit);
                Assert.Equal(converted.Unit, unit);
            });
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(ThermalResistanceUnit unit)
        {
            var quantity = default(ThermalResistance);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromIQuantity_ReturnsTheExpectedIQuantity(ThermalResistanceUnit unit)
        {
            var quantity = ThermalResistance.From(3, ThermalResistance.BaseUnit);
            ThermalResistance expectedQuantity = quantity.ToUnit(unit);
            Assert.Multiple(() =>
            {
                IQuantity<ThermalResistanceUnit> quantityToConvert = quantity;
                IQuantity<ThermalResistanceUnit> convertedQuantity = quantityToConvert.ToUnit(unit);
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
            ThermalResistance kelvinperwatt = ThermalResistance.FromKelvinsPerWatt(1);
            AssertEx.EqualTolerance(1, ThermalResistance.FromDegreesCelsiusPerWatt(kelvinperwatt.DegreesCelsiusPerWatt).KelvinsPerWatt, DegreesCelsiusPerWattTolerance);
            AssertEx.EqualTolerance(1, ThermalResistance.FromKelvinsPerWatt(kelvinperwatt.KelvinsPerWatt).KelvinsPerWatt, KelvinsPerWattTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ThermalResistance v = ThermalResistance.FromKelvinsPerWatt(1);
            AssertEx.EqualTolerance(-1, -v.KelvinsPerWatt, KelvinsPerWattTolerance);
            AssertEx.EqualTolerance(2, (ThermalResistance.FromKelvinsPerWatt(3)-v).KelvinsPerWatt, KelvinsPerWattTolerance);
            AssertEx.EqualTolerance(2, (v + v).KelvinsPerWatt, KelvinsPerWattTolerance);
            AssertEx.EqualTolerance(10, (v*10).KelvinsPerWatt, KelvinsPerWattTolerance);
            AssertEx.EqualTolerance(10, (10*v).KelvinsPerWatt, KelvinsPerWattTolerance);
            AssertEx.EqualTolerance(2, (ThermalResistance.FromKelvinsPerWatt(10)/5).KelvinsPerWatt, KelvinsPerWattTolerance);
            AssertEx.EqualTolerance(2, ThermalResistance.FromKelvinsPerWatt(10)/ThermalResistance.FromKelvinsPerWatt(5), KelvinsPerWattTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ThermalResistance oneKelvinPerWatt = ThermalResistance.FromKelvinsPerWatt(1);
            ThermalResistance twoKelvinsPerWatt = ThermalResistance.FromKelvinsPerWatt(2);

            Assert.True(oneKelvinPerWatt < twoKelvinsPerWatt);
            Assert.True(oneKelvinPerWatt <= twoKelvinsPerWatt);
            Assert.True(twoKelvinsPerWatt > oneKelvinPerWatt);
            Assert.True(twoKelvinsPerWatt >= oneKelvinPerWatt);

            Assert.False(oneKelvinPerWatt > twoKelvinsPerWatt);
            Assert.False(oneKelvinPerWatt >= twoKelvinsPerWatt);
            Assert.False(twoKelvinsPerWatt < oneKelvinPerWatt);
            Assert.False(twoKelvinsPerWatt <= oneKelvinPerWatt);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ThermalResistance kelvinperwatt = ThermalResistance.FromKelvinsPerWatt(1);
            Assert.Equal(0, kelvinperwatt.CompareTo(kelvinperwatt));
            Assert.True(kelvinperwatt.CompareTo(ThermalResistance.Zero) > 0);
            Assert.True(ThermalResistance.Zero.CompareTo(kelvinperwatt) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ThermalResistance kelvinperwatt = ThermalResistance.FromKelvinsPerWatt(1);
            Assert.Throws<ArgumentException>(() => kelvinperwatt.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ThermalResistance kelvinperwatt = ThermalResistance.FromKelvinsPerWatt(1);
            Assert.Throws<ArgumentNullException>(() => kelvinperwatt.CompareTo(null));
        }

        [Theory]
        [InlineData(1, ThermalResistanceUnit.KelvinPerWatt, 1, ThermalResistanceUnit.KelvinPerWatt, true)]  // Same value and unit.
        [InlineData(1, ThermalResistanceUnit.KelvinPerWatt, 2, ThermalResistanceUnit.KelvinPerWatt, false)] // Different value.
        [InlineData(2, ThermalResistanceUnit.KelvinPerWatt, 1, ThermalResistanceUnit.DegreeCelsiusPerWatt, false)] // Different value and unit.
        [InlineData(1, ThermalResistanceUnit.KelvinPerWatt, 1, ThermalResistanceUnit.DegreeCelsiusPerWatt, false)] // Different unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, ThermalResistanceUnit unitA, double valueB, ThermalResistanceUnit unitB, bool expectEqual)
        {
            var a = new ThermalResistance(valueA, unitA);
            var b = new ThermalResistance(valueB, unitB);

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
            var a = ThermalResistance.Zero;

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
            var v = ThermalResistance.FromKelvinsPerWatt(1);
            Assert.True(v.Equals(ThermalResistance.FromKelvinsPerWatt(1), KelvinsPerWattTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ThermalResistance.Zero, KelvinsPerWattTolerance, ComparisonType.Relative));
            Assert.True(ThermalResistance.FromKelvinsPerWatt(100).Equals(ThermalResistance.FromKelvinsPerWatt(120), 0.3, ComparisonType.Relative));
            Assert.False(ThermalResistance.FromKelvinsPerWatt(100).Equals(ThermalResistance.FromKelvinsPerWatt(120), 0.1, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = ThermalResistance.FromKelvinsPerWatt(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(ThermalResistance.FromKelvinsPerWatt(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ThermalResistance kelvinperwatt = ThermalResistance.FromKelvinsPerWatt(1);
            Assert.False(kelvinperwatt.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ThermalResistance kelvinperwatt = ThermalResistance.FromKelvinsPerWatt(1);
            Assert.False(kelvinperwatt.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues<ThermalResistanceUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ThermalResistance.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            using var _ = new CultureScope("en-US");
            Assert.Equal("1 °C/W", new ThermalResistance(1, ThermalResistanceUnit.DegreeCelsiusPerWatt).ToString());
            Assert.Equal("1 K/W", new ThermalResistance(1, ThermalResistanceUnit.KelvinPerWatt).ToString());
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 °C/W", new ThermalResistance(1, ThermalResistanceUnit.DegreeCelsiusPerWatt).ToString(swedishCulture));
            Assert.Equal("1 K/W", new ThermalResistance(1, ThermalResistanceUnit.KelvinPerWatt).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var _ = new CultureScope(CultureInfo.InvariantCulture);
            Assert.Equal("0.1 K/W", new ThermalResistance(0.123456, ThermalResistanceUnit.KelvinPerWatt).ToString("s1"));
            Assert.Equal("0.12 K/W", new ThermalResistance(0.123456, ThermalResistanceUnit.KelvinPerWatt).ToString("s2"));
            Assert.Equal("0.123 K/W", new ThermalResistance(0.123456, ThermalResistanceUnit.KelvinPerWatt).ToString("s3"));
            Assert.Equal("0.1235 K/W", new ThermalResistance(0.123456, ThermalResistanceUnit.KelvinPerWatt).ToString("s4"));
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 K/W", new ThermalResistance(0.123456, ThermalResistanceUnit.KelvinPerWatt).ToString("s1", culture));
            Assert.Equal("0.12 K/W", new ThermalResistance(0.123456, ThermalResistanceUnit.KelvinPerWatt).ToString("s2", culture));
            Assert.Equal("0.123 K/W", new ThermalResistance(0.123456, ThermalResistanceUnit.KelvinPerWatt).ToString("s3", culture));
            Assert.Equal("0.1235 K/W", new ThermalResistance(0.123456, ThermalResistanceUnit.KelvinPerWatt).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = ThermalResistance.FromKelvinsPerWatt(1.0);
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
            var quantity = ThermalResistance.FromKelvinsPerWatt(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = ThermalResistance.FromKelvinsPerWatt(1.0);
            Assert.Equal(new {ThermalResistance.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = ThermalResistance.FromKelvinsPerWatt(value);
            Assert.Equal(ThermalResistance.FromKelvinsPerWatt(-value), -quantity);
        }
    }
}
