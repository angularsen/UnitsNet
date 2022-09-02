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
    /// Test of ElectricConductivity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricConductivityTestsBase : QuantityTestsBase
    {
        protected abstract double SiemensPerFootInOneSiemensPerMeter { get; }
        protected abstract double SiemensPerInchInOneSiemensPerMeter { get; }
        protected abstract double SiemensPerMeterInOneSiemensPerMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double SiemensPerFootTolerance { get { return 1E-5; } }
        protected virtual double SiemensPerInchTolerance { get { return 1E-5; } }
        protected virtual double SiemensPerMeterTolerance { get { return 1E-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(ElectricConductivityUnit unit)
        {
            return unit switch
            {
                ElectricConductivityUnit.SiemensPerFoot => (SiemensPerFootInOneSiemensPerMeter, SiemensPerFootTolerance),
                ElectricConductivityUnit.SiemensPerInch => (SiemensPerInchInOneSiemensPerMeter, SiemensPerInchTolerance),
                ElectricConductivityUnit.SiemensPerMeter => (SiemensPerMeterInOneSiemensPerMeter, SiemensPerMeterTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { ElectricConductivityUnit.SiemensPerFoot },
            new object[] { ElectricConductivityUnit.SiemensPerInch },
            new object[] { ElectricConductivityUnit.SiemensPerMeter },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ElectricConductivity();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ElectricConductivityUnit.SiemensPerMeter, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricConductivity(double.PositiveInfinity, ElectricConductivityUnit.SiemensPerMeter));
            Assert.Throws<ArgumentException>(() => new ElectricConductivity(double.NegativeInfinity, ElectricConductivityUnit.SiemensPerMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricConductivity(double.NaN, ElectricConductivityUnit.SiemensPerMeter));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ElectricConductivity(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new ElectricConductivity(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (ElectricConductivity) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void ElectricConductivity_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ElectricConductivity(1, ElectricConductivityUnit.SiemensPerMeter);

            QuantityInfo<ElectricConductivityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ElectricConductivity.Zero, quantityInfo.Zero);
            Assert.Equal("ElectricConductivity", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<ElectricConductivityUnit>().ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void SiemensPerMeterToElectricConductivityUnits()
        {
            ElectricConductivity siemenspermeter = ElectricConductivity.FromSiemensPerMeter(1);
            AssertEx.EqualTolerance(SiemensPerFootInOneSiemensPerMeter, siemenspermeter.SiemensPerFoot, SiemensPerFootTolerance);
            AssertEx.EqualTolerance(SiemensPerInchInOneSiemensPerMeter, siemenspermeter.SiemensPerInch, SiemensPerInchTolerance);
            AssertEx.EqualTolerance(SiemensPerMeterInOneSiemensPerMeter, siemenspermeter.SiemensPerMeter, SiemensPerMeterTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ElectricConductivity.From(1, ElectricConductivityUnit.SiemensPerFoot);
            AssertEx.EqualTolerance(1, quantity00.SiemensPerFoot, SiemensPerFootTolerance);
            Assert.Equal(ElectricConductivityUnit.SiemensPerFoot, quantity00.Unit);

            var quantity01 = ElectricConductivity.From(1, ElectricConductivityUnit.SiemensPerInch);
            AssertEx.EqualTolerance(1, quantity01.SiemensPerInch, SiemensPerInchTolerance);
            Assert.Equal(ElectricConductivityUnit.SiemensPerInch, quantity01.Unit);

            var quantity02 = ElectricConductivity.From(1, ElectricConductivityUnit.SiemensPerMeter);
            AssertEx.EqualTolerance(1, quantity02.SiemensPerMeter, SiemensPerMeterTolerance);
            Assert.Equal(ElectricConductivityUnit.SiemensPerMeter, quantity02.Unit);

        }

        [Fact]
        public void FromSiemensPerMeter_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricConductivity.FromSiemensPerMeter(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => ElectricConductivity.FromSiemensPerMeter(double.NegativeInfinity));
        }

        [Fact]
        public void FromSiemensPerMeter_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricConductivity.FromSiemensPerMeter(double.NaN));
        }

        [Fact]
        public void As()
        {
            var siemenspermeter = ElectricConductivity.FromSiemensPerMeter(1);
            AssertEx.EqualTolerance(SiemensPerFootInOneSiemensPerMeter, siemenspermeter.As(ElectricConductivityUnit.SiemensPerFoot), SiemensPerFootTolerance);
            AssertEx.EqualTolerance(SiemensPerInchInOneSiemensPerMeter, siemenspermeter.As(ElectricConductivityUnit.SiemensPerInch), SiemensPerInchTolerance);
            AssertEx.EqualTolerance(SiemensPerMeterInOneSiemensPerMeter, siemenspermeter.As(ElectricConductivityUnit.SiemensPerMeter), SiemensPerMeterTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new ElectricConductivity(value: 1, unit: ElectricConductivity.BaseUnit);
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
                var parsed = ElectricConductivity.Parse("1 S/ft", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.SiemensPerFoot, SiemensPerFootTolerance);
                Assert.Equal(ElectricConductivityUnit.SiemensPerFoot, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ElectricConductivity.Parse("1 S/in", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.SiemensPerInch, SiemensPerInchTolerance);
                Assert.Equal(ElectricConductivityUnit.SiemensPerInch, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = ElectricConductivity.Parse("1 S/m", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.SiemensPerMeter, SiemensPerMeterTolerance);
                Assert.Equal(ElectricConductivityUnit.SiemensPerMeter, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(ElectricConductivity.TryParse("1 S/ft", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.SiemensPerFoot, SiemensPerFootTolerance);
                Assert.Equal(ElectricConductivityUnit.SiemensPerFoot, parsed.Unit);
            }

            {
                Assert.True(ElectricConductivity.TryParse("1 S/in", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.SiemensPerInch, SiemensPerInchTolerance);
                Assert.Equal(ElectricConductivityUnit.SiemensPerInch, parsed.Unit);
            }

            {
                Assert.True(ElectricConductivity.TryParse("1 S/m", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.SiemensPerMeter, SiemensPerMeterTolerance);
                Assert.Equal(ElectricConductivityUnit.SiemensPerMeter, parsed.Unit);
            }

        }

        [Fact]
        public void ParseUnit()
        {
            try
            {
                var parsedUnit = ElectricConductivity.ParseUnit("S/ft", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(ElectricConductivityUnit.SiemensPerFoot, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = ElectricConductivity.ParseUnit("S/in", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(ElectricConductivityUnit.SiemensPerInch, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = ElectricConductivity.ParseUnit("S/m", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(ElectricConductivityUnit.SiemensPerMeter, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParseUnit()
        {
            {
                Assert.True(ElectricConductivity.TryParseUnit("S/ft", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(ElectricConductivityUnit.SiemensPerFoot, parsedUnit);
            }

            {
                Assert.True(ElectricConductivity.TryParseUnit("S/in", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(ElectricConductivityUnit.SiemensPerInch, parsedUnit);
            }

            {
                Assert.True(ElectricConductivity.TryParseUnit("S/m", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(ElectricConductivityUnit.SiemensPerMeter, parsedUnit);
            }

        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(ElectricConductivityUnit unit)
        {
            var inBaseUnits = ElectricConductivity.From(1.0, ElectricConductivity.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(ElectricConductivityUnit unit)
        {
            var quantity = ElectricConductivity.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(ElectricConductivityUnit unit)
        {
            // See if there is a unit available that is not the base unit, fallback to base unit if it has only a single unit.
            var fromUnit = ElectricConductivity.Units.Where(u => u != ElectricConductivity.BaseUnit).DefaultIfEmpty(ElectricConductivity.BaseUnit).FirstOrDefault();

            var quantity = ElectricConductivity.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ElectricConductivity siemenspermeter = ElectricConductivity.FromSiemensPerMeter(1);
            AssertEx.EqualTolerance(1, ElectricConductivity.FromSiemensPerFoot(siemenspermeter.SiemensPerFoot).SiemensPerMeter, SiemensPerFootTolerance);
            AssertEx.EqualTolerance(1, ElectricConductivity.FromSiemensPerInch(siemenspermeter.SiemensPerInch).SiemensPerMeter, SiemensPerInchTolerance);
            AssertEx.EqualTolerance(1, ElectricConductivity.FromSiemensPerMeter(siemenspermeter.SiemensPerMeter).SiemensPerMeter, SiemensPerMeterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ElectricConductivity v = ElectricConductivity.FromSiemensPerMeter(1);
            AssertEx.EqualTolerance(-1, -v.SiemensPerMeter, SiemensPerMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricConductivity.FromSiemensPerMeter(3)-v).SiemensPerMeter, SiemensPerMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).SiemensPerMeter, SiemensPerMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).SiemensPerMeter, SiemensPerMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).SiemensPerMeter, SiemensPerMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricConductivity.FromSiemensPerMeter(10)/5).SiemensPerMeter, SiemensPerMeterTolerance);
            AssertEx.EqualTolerance(2, ElectricConductivity.FromSiemensPerMeter(10)/ElectricConductivity.FromSiemensPerMeter(5), SiemensPerMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ElectricConductivity oneSiemensPerMeter = ElectricConductivity.FromSiemensPerMeter(1);
            ElectricConductivity twoSiemensPerMeter = ElectricConductivity.FromSiemensPerMeter(2);

            Assert.True(oneSiemensPerMeter < twoSiemensPerMeter);
            Assert.True(oneSiemensPerMeter <= twoSiemensPerMeter);
            Assert.True(twoSiemensPerMeter > oneSiemensPerMeter);
            Assert.True(twoSiemensPerMeter >= oneSiemensPerMeter);

            Assert.False(oneSiemensPerMeter > twoSiemensPerMeter);
            Assert.False(oneSiemensPerMeter >= twoSiemensPerMeter);
            Assert.False(twoSiemensPerMeter < oneSiemensPerMeter);
            Assert.False(twoSiemensPerMeter <= oneSiemensPerMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ElectricConductivity siemenspermeter = ElectricConductivity.FromSiemensPerMeter(1);
            Assert.Equal(0, siemenspermeter.CompareTo(siemenspermeter));
            Assert.True(siemenspermeter.CompareTo(ElectricConductivity.Zero) > 0);
            Assert.True(ElectricConductivity.Zero.CompareTo(siemenspermeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricConductivity siemenspermeter = ElectricConductivity.FromSiemensPerMeter(1);
            Assert.Throws<ArgumentException>(() => siemenspermeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ElectricConductivity siemenspermeter = ElectricConductivity.FromSiemensPerMeter(1);
            Assert.Throws<ArgumentNullException>(() => siemenspermeter.CompareTo(null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = ElectricConductivity.FromSiemensPerMeter(1);
            Assert.True(v.Equals(ElectricConductivity.FromSiemensPerMeter(1), SiemensPerMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ElectricConductivity.Zero, SiemensPerMeterTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = ElectricConductivity.FromSiemensPerMeter(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(ElectricConductivity.FromSiemensPerMeter(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricConductivity siemenspermeter = ElectricConductivity.FromSiemensPerMeter(1);
            Assert.False(siemenspermeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricConductivity siemenspermeter = ElectricConductivity.FromSiemensPerMeter(1);
            Assert.False(siemenspermeter.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ElectricConductivityUnit)).Cast<ElectricConductivityUnit>();
            foreach(var unit in units)
            {
                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ElectricConductivity.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 S/ft", new ElectricConductivity(1, ElectricConductivityUnit.SiemensPerFoot).ToString());
                Assert.Equal("1 S/in", new ElectricConductivity(1, ElectricConductivityUnit.SiemensPerInch).ToString());
                Assert.Equal("1 S/m", new ElectricConductivity(1, ElectricConductivityUnit.SiemensPerMeter).ToString());
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

            Assert.Equal("1 S/ft", new ElectricConductivity(1, ElectricConductivityUnit.SiemensPerFoot).ToString(swedishCulture));
            Assert.Equal("1 S/in", new ElectricConductivity(1, ElectricConductivityUnit.SiemensPerInch).ToString(swedishCulture));
            Assert.Equal("1 S/m", new ElectricConductivity(1, ElectricConductivityUnit.SiemensPerMeter).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 S/m", new ElectricConductivity(0.123456, ElectricConductivityUnit.SiemensPerMeter).ToString("s1"));
                Assert.Equal("0.12 S/m", new ElectricConductivity(0.123456, ElectricConductivityUnit.SiemensPerMeter).ToString("s2"));
                Assert.Equal("0.123 S/m", new ElectricConductivity(0.123456, ElectricConductivityUnit.SiemensPerMeter).ToString("s3"));
                Assert.Equal("0.1235 S/m", new ElectricConductivity(0.123456, ElectricConductivityUnit.SiemensPerMeter).ToString("s4"));
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
            Assert.Equal("0.1 S/m", new ElectricConductivity(0.123456, ElectricConductivityUnit.SiemensPerMeter).ToString("s1", culture));
            Assert.Equal("0.12 S/m", new ElectricConductivity(0.123456, ElectricConductivityUnit.SiemensPerMeter).ToString("s2", culture));
            Assert.Equal("0.123 S/m", new ElectricConductivity(0.123456, ElectricConductivityUnit.SiemensPerMeter).ToString("s3", culture));
            Assert.Equal("0.1235 S/m", new ElectricConductivity(0.123456, ElectricConductivityUnit.SiemensPerMeter).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
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
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(ElectricConductivity)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(ElectricConductivityUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal(ElectricConductivity.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal(ElectricConductivity.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(1.0);
            Assert.Equal(new {ElectricConductivity.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = ElectricConductivity.FromSiemensPerMeter(value);
            Assert.Equal(ElectricConductivity.FromSiemensPerMeter(-value), -quantity);
        }
    }
}
