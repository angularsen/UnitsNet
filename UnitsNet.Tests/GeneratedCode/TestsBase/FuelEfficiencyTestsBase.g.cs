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
using UnitsNet.Tests.TestsBase;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of FuelEfficiency.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class FuelEfficiencyTestsBase : QuantityTestsBase
    {
        protected abstract double KilometersPerLiterInOneLiterPer100Kilometers { get; }
        protected abstract double LitersPer100KilometersInOneLiterPer100Kilometers { get; }
        protected abstract double MilesPerUkGallonInOneLiterPer100Kilometers { get; }
        protected abstract double MilesPerUsGallonInOneLiterPer100Kilometers { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KilometersPerLiterTolerance { get { return 1e-5; } }
        protected virtual double LitersPer100KilometersTolerance { get { return 1e-5; } }
        protected virtual double MilesPerUkGallonTolerance { get { return 1e-5; } }
        protected virtual double MilesPerUsGallonTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(FuelEfficiencyUnit unit)
        {
            return unit switch
            {
                FuelEfficiencyUnit.KilometerPerLiter => (KilometersPerLiterInOneLiterPer100Kilometers, KilometersPerLiterTolerance),
                FuelEfficiencyUnit.LiterPer100Kilometers => (LitersPer100KilometersInOneLiterPer100Kilometers, LitersPer100KilometersTolerance),
                FuelEfficiencyUnit.MilePerUkGallon => (MilesPerUkGallonInOneLiterPer100Kilometers, MilesPerUkGallonTolerance),
                FuelEfficiencyUnit.MilePerUsGallon => (MilesPerUsGallonInOneLiterPer100Kilometers, MilesPerUsGallonTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { FuelEfficiencyUnit.KilometerPerLiter },
            new object[] { FuelEfficiencyUnit.LiterPer100Kilometers },
            new object[] { FuelEfficiencyUnit.MilePerUkGallon },
            new object[] { FuelEfficiencyUnit.MilePerUsGallon },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new FuelEfficiency();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(FuelEfficiencyUnit.LiterPer100Kilometers, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => new FuelEfficiency(double.PositiveInfinity, FuelEfficiencyUnit.LiterPer100Kilometers));
            var exception2 = Record.Exception(() => new FuelEfficiency(double.NegativeInfinity, FuelEfficiencyUnit.LiterPer100Kilometers));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void Ctor_WithNaNValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => new FuelEfficiency(double.NaN, FuelEfficiencyUnit.LiterPer100Kilometers));

            Assert.Null(exception);
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new FuelEfficiency(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new FuelEfficiency(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (FuelEfficiency) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void FuelEfficiency_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new FuelEfficiency(1, FuelEfficiencyUnit.LiterPer100Kilometers);

            QuantityInfo<FuelEfficiencyUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(FuelEfficiency.Zero, quantityInfo.Zero);
            Assert.Equal("FuelEfficiency", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<FuelEfficiencyUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void LiterPer100KilometersToFuelEfficiencyUnits()
        {
            FuelEfficiency literper100kilometers = FuelEfficiency.FromLitersPer100Kilometers(1);
            AssertEx.EqualTolerance(KilometersPerLiterInOneLiterPer100Kilometers, literper100kilometers.KilometersPerLiter, KilometersPerLiterTolerance);
            AssertEx.EqualTolerance(LitersPer100KilometersInOneLiterPer100Kilometers, literper100kilometers.LitersPer100Kilometers, LitersPer100KilometersTolerance);
            AssertEx.EqualTolerance(MilesPerUkGallonInOneLiterPer100Kilometers, literper100kilometers.MilesPerUkGallon, MilesPerUkGallonTolerance);
            AssertEx.EqualTolerance(MilesPerUsGallonInOneLiterPer100Kilometers, literper100kilometers.MilesPerUsGallon, MilesPerUsGallonTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = FuelEfficiency.From(1, FuelEfficiencyUnit.KilometerPerLiter);
            AssertEx.EqualTolerance(1, quantity00.KilometersPerLiter, KilometersPerLiterTolerance);
            Assert.Equal(FuelEfficiencyUnit.KilometerPerLiter, quantity00.Unit);

            var quantity01 = FuelEfficiency.From(1, FuelEfficiencyUnit.LiterPer100Kilometers);
            AssertEx.EqualTolerance(1, quantity01.LitersPer100Kilometers, LitersPer100KilometersTolerance);
            Assert.Equal(FuelEfficiencyUnit.LiterPer100Kilometers, quantity01.Unit);

            var quantity02 = FuelEfficiency.From(1, FuelEfficiencyUnit.MilePerUkGallon);
            AssertEx.EqualTolerance(1, quantity02.MilesPerUkGallon, MilesPerUkGallonTolerance);
            Assert.Equal(FuelEfficiencyUnit.MilePerUkGallon, quantity02.Unit);

            var quantity03 = FuelEfficiency.From(1, FuelEfficiencyUnit.MilePerUsGallon);
            AssertEx.EqualTolerance(1, quantity03.MilesPerUsGallon, MilesPerUsGallonTolerance);
            Assert.Equal(FuelEfficiencyUnit.MilePerUsGallon, quantity03.Unit);

        }

        [Fact]
        public void FromLitersPer100Kilometers_WithInfinityValue_DoNotThrowsArgumentException()
        {
            var exception1 = Record.Exception(() => FuelEfficiency.FromLitersPer100Kilometers(double.PositiveInfinity));
            var exception2 = Record.Exception(() => FuelEfficiency.FromLitersPer100Kilometers(double.NegativeInfinity));

            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void FromLitersPer100Kilometers_WithNanValue_DoNotThrowsArgumentException()
        {
            var exception = Record.Exception(() => FuelEfficiency.FromLitersPer100Kilometers(double.NaN));

            Assert.Null(exception);
        }

        [Fact]
        public void As()
        {
            var literper100kilometers = FuelEfficiency.FromLitersPer100Kilometers(1);
            AssertEx.EqualTolerance(KilometersPerLiterInOneLiterPer100Kilometers, literper100kilometers.As(FuelEfficiencyUnit.KilometerPerLiter), KilometersPerLiterTolerance);
            AssertEx.EqualTolerance(LitersPer100KilometersInOneLiterPer100Kilometers, literper100kilometers.As(FuelEfficiencyUnit.LiterPer100Kilometers), LitersPer100KilometersTolerance);
            AssertEx.EqualTolerance(MilesPerUkGallonInOneLiterPer100Kilometers, literper100kilometers.As(FuelEfficiencyUnit.MilePerUkGallon), MilesPerUkGallonTolerance);
            AssertEx.EqualTolerance(MilesPerUsGallonInOneLiterPer100Kilometers, literper100kilometers.As(FuelEfficiencyUnit.MilePerUsGallon), MilesPerUsGallonTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new FuelEfficiency(value: 1, unit: FuelEfficiency.BaseUnit);
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
                var parsed = FuelEfficiency.Parse("1 km/l", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.KilometersPerLiter, KilometersPerLiterTolerance);
                Assert.Equal(FuelEfficiencyUnit.KilometerPerLiter, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = FuelEfficiency.Parse("1 l/100km", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.LitersPer100Kilometers, LitersPer100KilometersTolerance);
                Assert.Equal(FuelEfficiencyUnit.LiterPer100Kilometers, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = FuelEfficiency.Parse("1 mpg (imp.)", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.MilesPerUkGallon, MilesPerUkGallonTolerance);
                Assert.Equal(FuelEfficiencyUnit.MilePerUkGallon, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = FuelEfficiency.Parse("1 mpg (U.S.)", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.MilesPerUsGallon, MilesPerUsGallonTolerance);
                Assert.Equal(FuelEfficiencyUnit.MilePerUsGallon, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(FuelEfficiency.TryParse("1 km/l", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.KilometersPerLiter, KilometersPerLiterTolerance);
                Assert.Equal(FuelEfficiencyUnit.KilometerPerLiter, parsed.Unit);
            }

            {
                Assert.True(FuelEfficiency.TryParse("1 l/100km", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.LitersPer100Kilometers, LitersPer100KilometersTolerance);
                Assert.Equal(FuelEfficiencyUnit.LiterPer100Kilometers, parsed.Unit);
            }

            {
                Assert.True(FuelEfficiency.TryParse("1 mpg (imp.)", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.MilesPerUkGallon, MilesPerUkGallonTolerance);
                Assert.Equal(FuelEfficiencyUnit.MilePerUkGallon, parsed.Unit);
            }

            {
                Assert.True(FuelEfficiency.TryParse("1 mpg (U.S.)", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.MilesPerUsGallon, MilesPerUsGallonTolerance);
                Assert.Equal(FuelEfficiencyUnit.MilePerUsGallon, parsed.Unit);
            }

        }

        [Theory]
        [InlineData("km/l", FuelEfficiencyUnit.KilometerPerLiter)]
        [InlineData("l/100km", FuelEfficiencyUnit.LiterPer100Kilometers)]
        [InlineData("mpg (imp.)", FuelEfficiencyUnit.MilePerUkGallon)]
        [InlineData("mpg (U.S.)", FuelEfficiencyUnit.MilePerUsGallon)]
        public void ParseUnit(string abbreviation, FuelEfficiencyUnit expectedUnit)
        {
            // regardless of the CurrentCulture is, this should always work with the FallbackCulture ("en-US")
            FuelEfficiencyUnit parsedUnit = FuelEfficiency.ParseUnit(abbreviation); 
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "km/l", FuelEfficiencyUnit.KilometerPerLiter)]
        [InlineData("en-US", "l/100km", FuelEfficiencyUnit.LiterPer100Kilometers)]
        [InlineData("en-US", "mpg (imp.)", FuelEfficiencyUnit.MilePerUkGallon)]
        [InlineData("en-US", "mpg (U.S.)", FuelEfficiencyUnit.MilePerUsGallon)]
        public void ParseUnitWithCulture(string culture, string abbreviation, FuelEfficiencyUnit expectedUnit)
        {
            FuelEfficiencyUnit parsedUnit = FuelEfficiency.ParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("km/l", FuelEfficiencyUnit.KilometerPerLiter)]
        [InlineData("l/100km", FuelEfficiencyUnit.LiterPer100Kilometers)]
        [InlineData("mpg (imp.)", FuelEfficiencyUnit.MilePerUkGallon)]
        [InlineData("mpg (U.S.)", FuelEfficiencyUnit.MilePerUsGallon)]
        public void TryParseUnit(string abbreviation, FuelEfficiencyUnit expectedUnit)
        {
            // regardless of the CurrentCulture is, this should always work with the FallbackCulture ("en-US")
            Assert.True(FuelEfficiency.TryParseUnit(abbreviation, out FuelEfficiencyUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [InlineData("en-US", "km/l", FuelEfficiencyUnit.KilometerPerLiter)]
        [InlineData("en-US", "l/100km", FuelEfficiencyUnit.LiterPer100Kilometers)]
        [InlineData("en-US", "mpg (imp.)", FuelEfficiencyUnit.MilePerUkGallon)]
        [InlineData("en-US", "mpg (U.S.)", FuelEfficiencyUnit.MilePerUsGallon)]
        public void TryParseUnitWithCulture(string culture, string abbreviation, FuelEfficiencyUnit expectedUnit)
        {
            Assert.True(FuelEfficiency.TryParseUnit(abbreviation, CultureInfo.GetCultureInfo(culture), out FuelEfficiencyUnit parsedUnit));
            Assert.Equal(expectedUnit, parsedUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(FuelEfficiencyUnit unit)
        {
            var inBaseUnits = FuelEfficiency.From(1.0, FuelEfficiency.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(FuelEfficiencyUnit unit)
        {
            var quantity = FuelEfficiency.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(FuelEfficiencyUnit unit)
        {
            // See if there is a unit available that is not the base unit, fallback to base unit if it has only a single unit.
            var fromUnit = FuelEfficiency.Units.First(u => u != FuelEfficiency.BaseUnit);

            var quantity = FuelEfficiency.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(FuelEfficiencyUnit unit)
        {
            var quantity = default(FuelEfficiency);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            FuelEfficiency literper100kilometers = FuelEfficiency.FromLitersPer100Kilometers(1);
            AssertEx.EqualTolerance(1, FuelEfficiency.FromKilometersPerLiter(literper100kilometers.KilometersPerLiter).LitersPer100Kilometers, KilometersPerLiterTolerance);
            AssertEx.EqualTolerance(1, FuelEfficiency.FromLitersPer100Kilometers(literper100kilometers.LitersPer100Kilometers).LitersPer100Kilometers, LitersPer100KilometersTolerance);
            AssertEx.EqualTolerance(1, FuelEfficiency.FromMilesPerUkGallon(literper100kilometers.MilesPerUkGallon).LitersPer100Kilometers, MilesPerUkGallonTolerance);
            AssertEx.EqualTolerance(1, FuelEfficiency.FromMilesPerUsGallon(literper100kilometers.MilesPerUsGallon).LitersPer100Kilometers, MilesPerUsGallonTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            FuelEfficiency v = FuelEfficiency.FromLitersPer100Kilometers(1);
            AssertEx.EqualTolerance(-1, -v.LitersPer100Kilometers, LitersPer100KilometersTolerance);
            AssertEx.EqualTolerance(2, (FuelEfficiency.FromLitersPer100Kilometers(3)-v).LitersPer100Kilometers, LitersPer100KilometersTolerance);
            AssertEx.EqualTolerance(2, (v + v).LitersPer100Kilometers, LitersPer100KilometersTolerance);
            AssertEx.EqualTolerance(10, (v*10).LitersPer100Kilometers, LitersPer100KilometersTolerance);
            AssertEx.EqualTolerance(10, (10*v).LitersPer100Kilometers, LitersPer100KilometersTolerance);
            AssertEx.EqualTolerance(2, (FuelEfficiency.FromLitersPer100Kilometers(10)/5).LitersPer100Kilometers, LitersPer100KilometersTolerance);
            AssertEx.EqualTolerance(2, FuelEfficiency.FromLitersPer100Kilometers(10)/FuelEfficiency.FromLitersPer100Kilometers(5), LitersPer100KilometersTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            FuelEfficiency oneLiterPer100Kilometers = FuelEfficiency.FromLitersPer100Kilometers(1);
            FuelEfficiency twoLitersPer100Kilometers = FuelEfficiency.FromLitersPer100Kilometers(2);

            Assert.True(oneLiterPer100Kilometers < twoLitersPer100Kilometers);
            Assert.True(oneLiterPer100Kilometers <= twoLitersPer100Kilometers);
            Assert.True(twoLitersPer100Kilometers > oneLiterPer100Kilometers);
            Assert.True(twoLitersPer100Kilometers >= oneLiterPer100Kilometers);

            Assert.False(oneLiterPer100Kilometers > twoLitersPer100Kilometers);
            Assert.False(oneLiterPer100Kilometers >= twoLitersPer100Kilometers);
            Assert.False(twoLitersPer100Kilometers < oneLiterPer100Kilometers);
            Assert.False(twoLitersPer100Kilometers <= oneLiterPer100Kilometers);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            FuelEfficiency literper100kilometers = FuelEfficiency.FromLitersPer100Kilometers(1);
            Assert.Equal(0, literper100kilometers.CompareTo(literper100kilometers));
            Assert.True(literper100kilometers.CompareTo(FuelEfficiency.Zero) > 0);
            Assert.True(FuelEfficiency.Zero.CompareTo(literper100kilometers) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            FuelEfficiency literper100kilometers = FuelEfficiency.FromLitersPer100Kilometers(1);
            Assert.Throws<ArgumentException>(() => literper100kilometers.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            FuelEfficiency literper100kilometers = FuelEfficiency.FromLitersPer100Kilometers(1);
            Assert.Throws<ArgumentNullException>(() => literper100kilometers.CompareTo(null));
        }

        [Theory]
        [InlineData(1, FuelEfficiencyUnit.LiterPer100Kilometers, 1, FuelEfficiencyUnit.LiterPer100Kilometers, true)]  // Same value and unit.
        [InlineData(1, FuelEfficiencyUnit.LiterPer100Kilometers, 2, FuelEfficiencyUnit.LiterPer100Kilometers, false)] // Different value.
        [InlineData(2, FuelEfficiencyUnit.LiterPer100Kilometers, 1, FuelEfficiencyUnit.KilometerPerLiter, false)] // Different value and unit.
        [InlineData(1, FuelEfficiencyUnit.LiterPer100Kilometers, 1, FuelEfficiencyUnit.KilometerPerLiter, false)] // Different unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, FuelEfficiencyUnit unitA, double valueB, FuelEfficiencyUnit unitB, bool expectEqual)
        {
            var a = new FuelEfficiency(valueA, unitA);
            var b = new FuelEfficiency(valueB, unitB);

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
            var a = FuelEfficiency.Zero;

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
            var v = FuelEfficiency.FromLitersPer100Kilometers(1);
            Assert.True(v.Equals(FuelEfficiency.FromLitersPer100Kilometers(1), LitersPer100KilometersTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(FuelEfficiency.Zero, LitersPer100KilometersTolerance, ComparisonType.Relative));
            Assert.True(FuelEfficiency.FromLitersPer100Kilometers(100).Equals(FuelEfficiency.FromLitersPer100Kilometers(120), 0.3, ComparisonType.Relative));
            Assert.False(FuelEfficiency.FromLitersPer100Kilometers(100).Equals(FuelEfficiency.FromLitersPer100Kilometers(120), 0.1, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = FuelEfficiency.FromLitersPer100Kilometers(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(FuelEfficiency.FromLitersPer100Kilometers(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            FuelEfficiency literper100kilometers = FuelEfficiency.FromLitersPer100Kilometers(1);
            Assert.False(literper100kilometers.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            FuelEfficiency literper100kilometers = FuelEfficiency.FromLitersPer100Kilometers(1);
            Assert.False(literper100kilometers.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(FuelEfficiencyUnit)).Cast<FuelEfficiencyUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(FuelEfficiency.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 km/l", new FuelEfficiency(1, FuelEfficiencyUnit.KilometerPerLiter).ToString());
                Assert.Equal("1 l/100km", new FuelEfficiency(1, FuelEfficiencyUnit.LiterPer100Kilometers).ToString());
                Assert.Equal("1 mpg (imp.)", new FuelEfficiency(1, FuelEfficiencyUnit.MilePerUkGallon).ToString());
                Assert.Equal("1 mpg (U.S.)", new FuelEfficiency(1, FuelEfficiencyUnit.MilePerUsGallon).ToString());
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

            Assert.Equal("1 km/l", new FuelEfficiency(1, FuelEfficiencyUnit.KilometerPerLiter).ToString(swedishCulture));
            Assert.Equal("1 l/100km", new FuelEfficiency(1, FuelEfficiencyUnit.LiterPer100Kilometers).ToString(swedishCulture));
            Assert.Equal("1 mpg (imp.)", new FuelEfficiency(1, FuelEfficiencyUnit.MilePerUkGallon).ToString(swedishCulture));
            Assert.Equal("1 mpg (U.S.)", new FuelEfficiency(1, FuelEfficiencyUnit.MilePerUsGallon).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 l/100km", new FuelEfficiency(0.123456, FuelEfficiencyUnit.LiterPer100Kilometers).ToString("s1"));
                Assert.Equal("0.12 l/100km", new FuelEfficiency(0.123456, FuelEfficiencyUnit.LiterPer100Kilometers).ToString("s2"));
                Assert.Equal("0.123 l/100km", new FuelEfficiency(0.123456, FuelEfficiencyUnit.LiterPer100Kilometers).ToString("s3"));
                Assert.Equal("0.1235 l/100km", new FuelEfficiency(0.123456, FuelEfficiencyUnit.LiterPer100Kilometers).ToString("s4"));
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
            Assert.Equal("0.1 l/100km", new FuelEfficiency(0.123456, FuelEfficiencyUnit.LiterPer100Kilometers).ToString("s1", culture));
            Assert.Equal("0.12 l/100km", new FuelEfficiency(0.123456, FuelEfficiencyUnit.LiterPer100Kilometers).ToString("s2", culture));
            Assert.Equal("0.123 l/100km", new FuelEfficiency(0.123456, FuelEfficiencyUnit.LiterPer100Kilometers).ToString("s3", culture));
            Assert.Equal("0.1235 l/100km", new FuelEfficiency(0.123456, FuelEfficiencyUnit.LiterPer100Kilometers).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
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
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(FuelEfficiency)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(FuelEfficiencyUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal(FuelEfficiency.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal(FuelEfficiency.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(1.0);
            Assert.Equal(new {FuelEfficiency.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = FuelEfficiency.FromLitersPer100Kilometers(value);
            Assert.Equal(FuelEfficiency.FromLitersPer100Kilometers(-value), -quantity);
        }
    }
}
