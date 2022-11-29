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
    /// Test of ElectricSurfaceChargeDensity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricSurfaceChargeDensityTestsBase : QuantityTestsBase
    {
        protected abstract double CoulombsPerSquareCentimeterInOneCoulombPerSquareMeter { get; }
        protected abstract double CoulombsPerSquareInchInOneCoulombPerSquareMeter { get; }
        protected abstract double CoulombsPerSquareMeterInOneCoulombPerSquareMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CoulombsPerSquareCentimeterTolerance { get { return 1e-5; } }
        protected virtual double CoulombsPerSquareInchTolerance { get { return 1e-5; } }
        protected virtual double CoulombsPerSquareMeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(ElectricSurfaceChargeDensityUnit unit)
        {
            return unit switch
            {
                ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter => (CoulombsPerSquareCentimeterInOneCoulombPerSquareMeter, CoulombsPerSquareCentimeterTolerance),
                ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch => (CoulombsPerSquareInchInOneCoulombPerSquareMeter, CoulombsPerSquareInchTolerance),
                ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter => (CoulombsPerSquareMeterInOneCoulombPerSquareMeter, CoulombsPerSquareMeterTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter },
            new object[] { ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch },
            new object[] { ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ElectricSurfaceChargeDensity();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricSurfaceChargeDensity(double.PositiveInfinity, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter));
            Assert.Throws<ArgumentException>(() => new ElectricSurfaceChargeDensity(double.NegativeInfinity, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricSurfaceChargeDensity(double.NaN, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ElectricSurfaceChargeDensity(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new ElectricSurfaceChargeDensity(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (ElectricSurfaceChargeDensity) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void ElectricSurfaceChargeDensity_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ElectricSurfaceChargeDensity(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter);

            QuantityInfo<ElectricSurfaceChargeDensityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ElectricSurfaceChargeDensity.Zero, quantityInfo.Zero);
            Assert.Equal("ElectricSurfaceChargeDensity", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<ElectricSurfaceChargeDensityUnit>().ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void CoulombPerSquareMeterToElectricSurfaceChargeDensityUnits()
        {
            ElectricSurfaceChargeDensity coulombpersquaremeter = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            AssertEx.EqualTolerance(CoulombsPerSquareCentimeterInOneCoulombPerSquareMeter, coulombpersquaremeter.CoulombsPerSquareCentimeter, CoulombsPerSquareCentimeterTolerance);
            AssertEx.EqualTolerance(CoulombsPerSquareInchInOneCoulombPerSquareMeter, coulombpersquaremeter.CoulombsPerSquareInch, CoulombsPerSquareInchTolerance);
            AssertEx.EqualTolerance(CoulombsPerSquareMeterInOneCoulombPerSquareMeter, coulombpersquaremeter.CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ElectricSurfaceChargeDensity.From(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter);
            AssertEx.EqualTolerance(1, quantity00.CoulombsPerSquareCentimeter, CoulombsPerSquareCentimeterTolerance);
            Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter, quantity00.Unit);

            var quantity01 = ElectricSurfaceChargeDensity.From(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch);
            AssertEx.EqualTolerance(1, quantity01.CoulombsPerSquareInch, CoulombsPerSquareInchTolerance);
            Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch, quantity01.Unit);

            var quantity02 = ElectricSurfaceChargeDensity.From(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter);
            AssertEx.EqualTolerance(1, quantity02.CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter, quantity02.Unit);

        }

        [Fact]
        public void FromCoulombsPerSquareMeter_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(double.NegativeInfinity));
        }

        [Fact]
        public void FromCoulombsPerSquareMeter_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(double.NaN));
        }

        [Fact]
        public void As()
        {
            var coulombpersquaremeter = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            AssertEx.EqualTolerance(CoulombsPerSquareCentimeterInOneCoulombPerSquareMeter, coulombpersquaremeter.As(ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter), CoulombsPerSquareCentimeterTolerance);
            AssertEx.EqualTolerance(CoulombsPerSquareInchInOneCoulombPerSquareMeter, coulombpersquaremeter.As(ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch), CoulombsPerSquareInchTolerance);
            AssertEx.EqualTolerance(CoulombsPerSquareMeterInOneCoulombPerSquareMeter, coulombpersquaremeter.As(ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter), CoulombsPerSquareMeterTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new ElectricSurfaceChargeDensity(value: 1, unit: ElectricSurfaceChargeDensity.BaseUnit);
            Func<object> AsWithSIUnitSystem = () => quantity.As(UnitSystem.SI);

            if (SupportsSIUnitSystem)
            {
                var value = (double) AsWithSIUnitSystem();
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
                var parsed = ElectricSurfaceChargeDensity.Parse("1 C/cm²", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.CoulombsPerSquareCentimeter, CoulombsPerSquareCentimeterTolerance);
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ElectricSurfaceChargeDensity.Parse("1 C/in²", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.CoulombsPerSquareInch, CoulombsPerSquareInchTolerance);
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ElectricSurfaceChargeDensity.Parse("1 C/m²", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(ElectricSurfaceChargeDensity.TryParse("1 C/cm²", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.CoulombsPerSquareCentimeter, CoulombsPerSquareCentimeterTolerance);
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter, parsed.Unit);
            }

            {
                Assert.True(ElectricSurfaceChargeDensity.TryParse("1 C/in²", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.CoulombsPerSquareInch, CoulombsPerSquareInchTolerance);
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch, parsed.Unit);
            }

            {
                Assert.True(ElectricSurfaceChargeDensity.TryParse("1 C/m²", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter, parsed.Unit);
            }

        }

        [Fact]
        public void ParseUnit()
        {
            try
            {
                var parsedUnit = ElectricSurfaceChargeDensity.ParseUnit("C/cm²", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = ElectricSurfaceChargeDensity.ParseUnit("C/in²", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = ElectricSurfaceChargeDensity.ParseUnit("C/m²", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParseUnit()
        {
            {
                Assert.True(ElectricSurfaceChargeDensity.TryParseUnit("C/cm²", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter, parsedUnit);
            }

            {
                Assert.True(ElectricSurfaceChargeDensity.TryParseUnit("C/in²", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch, parsedUnit);
            }

            {
                Assert.True(ElectricSurfaceChargeDensity.TryParseUnit("C/m²", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter, parsedUnit);
            }

        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(ElectricSurfaceChargeDensityUnit unit)
        {
            var inBaseUnits = ElectricSurfaceChargeDensity.From(1.0, ElectricSurfaceChargeDensity.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(ElectricSurfaceChargeDensityUnit unit)
        {
            var quantity = ElectricSurfaceChargeDensity.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(ElectricSurfaceChargeDensityUnit unit)
        {
            // See if there is a unit available that is not the base unit, fallback to base unit if it has only a single unit.
            var fromUnit = ElectricSurfaceChargeDensity.Units.Where(u => u != ElectricSurfaceChargeDensity.BaseUnit).DefaultIfEmpty(ElectricSurfaceChargeDensity.BaseUnit).FirstOrDefault();

            var quantity = ElectricSurfaceChargeDensity.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ElectricSurfaceChargeDensity coulombpersquaremeter = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            AssertEx.EqualTolerance(1, ElectricSurfaceChargeDensity.FromCoulombsPerSquareCentimeter(coulombpersquaremeter.CoulombsPerSquareCentimeter).CoulombsPerSquareMeter, CoulombsPerSquareCentimeterTolerance);
            AssertEx.EqualTolerance(1, ElectricSurfaceChargeDensity.FromCoulombsPerSquareInch(coulombpersquaremeter.CoulombsPerSquareInch).CoulombsPerSquareMeter, CoulombsPerSquareInchTolerance);
            AssertEx.EqualTolerance(1, ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(coulombpersquaremeter.CoulombsPerSquareMeter).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ElectricSurfaceChargeDensity v = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            AssertEx.EqualTolerance(-1, -v.CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(3)-v).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(10)/5).CoulombsPerSquareMeter, CoulombsPerSquareMeterTolerance);
            AssertEx.EqualTolerance(2, ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(10)/ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(5), CoulombsPerSquareMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ElectricSurfaceChargeDensity oneCoulombPerSquareMeter = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            ElectricSurfaceChargeDensity twoCoulombsPerSquareMeter = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(2);

            Assert.True(oneCoulombPerSquareMeter < twoCoulombsPerSquareMeter);
            Assert.True(oneCoulombPerSquareMeter <= twoCoulombsPerSquareMeter);
            Assert.True(twoCoulombsPerSquareMeter > oneCoulombPerSquareMeter);
            Assert.True(twoCoulombsPerSquareMeter >= oneCoulombPerSquareMeter);

            Assert.False(oneCoulombPerSquareMeter > twoCoulombsPerSquareMeter);
            Assert.False(oneCoulombPerSquareMeter >= twoCoulombsPerSquareMeter);
            Assert.False(twoCoulombsPerSquareMeter < oneCoulombPerSquareMeter);
            Assert.False(twoCoulombsPerSquareMeter <= oneCoulombPerSquareMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ElectricSurfaceChargeDensity coulombpersquaremeter = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            Assert.Equal(0, coulombpersquaremeter.CompareTo(coulombpersquaremeter));
            Assert.True(coulombpersquaremeter.CompareTo(ElectricSurfaceChargeDensity.Zero) > 0);
            Assert.True(ElectricSurfaceChargeDensity.Zero.CompareTo(coulombpersquaremeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricSurfaceChargeDensity coulombpersquaremeter = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            Assert.Throws<ArgumentException>(() => coulombpersquaremeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ElectricSurfaceChargeDensity coulombpersquaremeter = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            Assert.Throws<ArgumentNullException>(() => coulombpersquaremeter.CompareTo(null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            Assert.True(v.Equals(ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1), CoulombsPerSquareMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ElectricSurfaceChargeDensity.Zero, CoulombsPerSquareMeterTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricSurfaceChargeDensity coulombpersquaremeter = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            Assert.False(coulombpersquaremeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricSurfaceChargeDensity coulombpersquaremeter = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1);
            Assert.False(coulombpersquaremeter.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ElectricSurfaceChargeDensityUnit)).Cast<ElectricSurfaceChargeDensityUnit>();
            foreach(var unit in units)
            {
                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ElectricSurfaceChargeDensity.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 C/cm²", new ElectricSurfaceChargeDensity(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter).ToString());
                Assert.Equal("1 C/in²", new ElectricSurfaceChargeDensity(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch).ToString());
                Assert.Equal("1 C/m²", new ElectricSurfaceChargeDensity(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).ToString());
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

            Assert.Equal("1 C/cm²", new ElectricSurfaceChargeDensity(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareCentimeter).ToString(swedishCulture));
            Assert.Equal("1 C/in²", new ElectricSurfaceChargeDensity(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareInch).ToString(swedishCulture));
            Assert.Equal("1 C/m²", new ElectricSurfaceChargeDensity(1, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 C/m²", new ElectricSurfaceChargeDensity(0.123456, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).ToString("s1"));
                Assert.Equal("0.12 C/m²", new ElectricSurfaceChargeDensity(0.123456, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).ToString("s2"));
                Assert.Equal("0.123 C/m²", new ElectricSurfaceChargeDensity(0.123456, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).ToString("s3"));
                Assert.Equal("0.1235 C/m²", new ElectricSurfaceChargeDensity(0.123456, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).ToString("s4"));
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
            Assert.Equal("0.1 C/m²", new ElectricSurfaceChargeDensity(0.123456, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).ToString("s1", culture));
            Assert.Equal("0.12 C/m²", new ElectricSurfaceChargeDensity(0.123456, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).ToString("s2", culture));
            Assert.Equal("0.123 C/m²", new ElectricSurfaceChargeDensity(0.123456, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).ToString("s3", culture));
            Assert.Equal("0.1235 C/m²", new ElectricSurfaceChargeDensity(0.123456, ElectricSurfaceChargeDensityUnit.CoulombPerSquareMeter).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            CultureInfo formatProvider = cultureName == null
                ? null
                : CultureInfo.GetCultureInfo(cultureName);

            Assert.Equal(quantity.ToString("g", formatProvider), quantity.ToString(null, formatProvider));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("g")]
        public void ToString_NullProvider_EqualsCurrentCulture(string format)
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(ElectricSurfaceChargeDensity)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(ElectricSurfaceChargeDensityUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal(ElectricSurfaceChargeDensity.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal(ElectricSurfaceChargeDensity.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(1.0);
            Assert.Equal(new {ElectricSurfaceChargeDensity.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(value);
            Assert.Equal(ElectricSurfaceChargeDensity.FromCoulombsPerSquareMeter(-value), -quantity);
        }
    }
}
