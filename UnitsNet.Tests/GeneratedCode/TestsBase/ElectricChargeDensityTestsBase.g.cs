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
    /// Test of ElectricChargeDensity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricChargeDensityTestsBase : QuantityTestsBase
    {
        protected abstract double CoulombsPerCubicMeterInOneCoulombPerCubicMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CoulombsPerCubicMeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { ElectricChargeDensityUnit.CoulombPerCubicMeter },
        };

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricChargeDensity((double)0.0, ElectricChargeDensityUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ElectricChargeDensity();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ElectricChargeDensityUnit.CoulombPerCubicMeter, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricChargeDensity(double.PositiveInfinity, ElectricChargeDensityUnit.CoulombPerCubicMeter));
            Assert.Throws<ArgumentException>(() => new ElectricChargeDensity(double.NegativeInfinity, ElectricChargeDensityUnit.CoulombPerCubicMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricChargeDensity(double.NaN, ElectricChargeDensityUnit.CoulombPerCubicMeter));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ElectricChargeDensity(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new ElectricChargeDensity(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (ElectricChargeDensity) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void ElectricChargeDensity_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ElectricChargeDensity(1, ElectricChargeDensityUnit.CoulombPerCubicMeter);

            QuantityInfo<ElectricChargeDensityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ElectricChargeDensity.Zero, quantityInfo.Zero);
            Assert.Equal("ElectricChargeDensity", quantityInfo.Name);
            Assert.Equal(QuantityType.ElectricChargeDensity, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<ElectricChargeDensityUnit>().Except(new[] {ElectricChargeDensityUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
        }

        [Fact]
        public void CoulombPerCubicMeterToElectricChargeDensityUnits()
        {
            ElectricChargeDensity coulombpercubicmeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            AssertEx.EqualTolerance(CoulombsPerCubicMeterInOneCoulombPerCubicMeter, coulombpercubicmeter.CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ElectricChargeDensity.From(1, ElectricChargeDensityUnit.CoulombPerCubicMeter);
            AssertEx.EqualTolerance(1, quantity00.CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            Assert.Equal(ElectricChargeDensityUnit.CoulombPerCubicMeter, quantity00.Unit);

        }

        [Fact]
        public void FromCoulombsPerCubicMeter_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricChargeDensity.FromCoulombsPerCubicMeter(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => ElectricChargeDensity.FromCoulombsPerCubicMeter(double.NegativeInfinity));
        }

        [Fact]
        public void FromCoulombsPerCubicMeter_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricChargeDensity.FromCoulombsPerCubicMeter(double.NaN));
        }

        [Fact]
        public void As()
        {
            var coulombpercubicmeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            AssertEx.EqualTolerance(CoulombsPerCubicMeterInOneCoulombPerCubicMeter, coulombpercubicmeter.As(ElectricChargeDensityUnit.CoulombPerCubicMeter), CoulombsPerCubicMeterTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new ElectricChargeDensity(value: 1, unit: ElectricChargeDensity.BaseUnit);
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
        public void ToUnit()
        {
            var coulombpercubicmeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);

            var coulombpercubicmeterQuantity = coulombpercubicmeter.ToUnit(ElectricChargeDensityUnit.CoulombPerCubicMeter);
            AssertEx.EqualTolerance(CoulombsPerCubicMeterInOneCoulombPerCubicMeter, (double)coulombpercubicmeterQuantity.Value, CoulombsPerCubicMeterTolerance);
            Assert.Equal(ElectricChargeDensityUnit.CoulombPerCubicMeter, coulombpercubicmeterQuantity.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(ElectricChargeDensityUnit unit)
        {
            var quantity = ElectricChargeDensity.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_NoException(ElectricChargeDensityUnit unit)
        {
            var quantity = ElectricChargeDensity.From(3.0, ElectricChargeDensity.Units.First(unit => unit != ElectricChargeDensity.BaseUnit));
            var converted = quantity.ToUnit(unit);
            // TODO: Meaningful check possible?
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ElectricChargeDensity coulombpercubicmeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            AssertEx.EqualTolerance(1, ElectricChargeDensity.FromCoulombsPerCubicMeter(coulombpercubicmeter.CoulombsPerCubicMeter).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ElectricChargeDensity v = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            AssertEx.EqualTolerance(-1, -v.CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricChargeDensity.FromCoulombsPerCubicMeter(3)-v).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, (ElectricChargeDensity.FromCoulombsPerCubicMeter(10)/5).CoulombsPerCubicMeter, CoulombsPerCubicMeterTolerance);
            AssertEx.EqualTolerance(2, ElectricChargeDensity.FromCoulombsPerCubicMeter(10)/ElectricChargeDensity.FromCoulombsPerCubicMeter(5), CoulombsPerCubicMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ElectricChargeDensity oneCoulombPerCubicMeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            ElectricChargeDensity twoCoulombsPerCubicMeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(2);

            Assert.True(oneCoulombPerCubicMeter < twoCoulombsPerCubicMeter);
            Assert.True(oneCoulombPerCubicMeter <= twoCoulombsPerCubicMeter);
            Assert.True(twoCoulombsPerCubicMeter > oneCoulombPerCubicMeter);
            Assert.True(twoCoulombsPerCubicMeter >= oneCoulombPerCubicMeter);

            Assert.False(oneCoulombPerCubicMeter > twoCoulombsPerCubicMeter);
            Assert.False(oneCoulombPerCubicMeter >= twoCoulombsPerCubicMeter);
            Assert.False(twoCoulombsPerCubicMeter < oneCoulombPerCubicMeter);
            Assert.False(twoCoulombsPerCubicMeter <= oneCoulombPerCubicMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ElectricChargeDensity coulombpercubicmeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            Assert.Equal(0, coulombpercubicmeter.CompareTo(coulombpercubicmeter));
            Assert.True(coulombpercubicmeter.CompareTo(ElectricChargeDensity.Zero) > 0);
            Assert.True(ElectricChargeDensity.Zero.CompareTo(coulombpercubicmeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricChargeDensity coulombpercubicmeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            Assert.Throws<ArgumentException>(() => coulombpercubicmeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ElectricChargeDensity coulombpercubicmeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            Assert.Throws<ArgumentNullException>(() => coulombpercubicmeter.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            var b = ElectricChargeDensity.FromCoulombsPerCubicMeter(2);

#pragma warning disable CS8073
// ReSharper disable EqualExpressionComparison

            Assert.True(a == a);
            Assert.False(a != a);

            Assert.True(a != b);
            Assert.False(a == b);

            Assert.False(a == null);
            Assert.False(null == a);

// ReSharper restore EqualExpressionComparison
#pragma warning restore CS8073
        }

        [Fact]
        public void Equals_SameType_IsImplemented()
        {
            var a = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            var b = ElectricChargeDensity.FromCoulombsPerCubicMeter(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            object b = ElectricChargeDensity.FromCoulombsPerCubicMeter(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            Assert.True(v.Equals(ElectricChargeDensity.FromCoulombsPerCubicMeter(1), CoulombsPerCubicMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ElectricChargeDensity.Zero, CoulombsPerCubicMeterTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(ElectricChargeDensity.FromCoulombsPerCubicMeter(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricChargeDensity coulombpercubicmeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            Assert.False(coulombpercubicmeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricChargeDensity coulombpercubicmeter = ElectricChargeDensity.FromCoulombsPerCubicMeter(1);
            Assert.False(coulombpercubicmeter.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(ElectricChargeDensityUnit.Undefined, ElectricChargeDensity.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ElectricChargeDensityUnit)).Cast<ElectricChargeDensityUnit>();
            foreach(var unit in units)
            {
                if(unit == ElectricChargeDensityUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ElectricChargeDensity.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 C/m³", new ElectricChargeDensity(1, ElectricChargeDensityUnit.CoulombPerCubicMeter).ToString());
            }
            finally
            {
                Thread.CurrentThread.CurrentUICulture = prevCulture;
            }
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 C/m³", new ElectricChargeDensity(1, ElectricChargeDensityUnit.CoulombPerCubicMeter).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 C/m³", new ElectricChargeDensity(0.123456, ElectricChargeDensityUnit.CoulombPerCubicMeter).ToString("s1"));
                Assert.Equal("0.12 C/m³", new ElectricChargeDensity(0.123456, ElectricChargeDensityUnit.CoulombPerCubicMeter).ToString("s2"));
                Assert.Equal("0.123 C/m³", new ElectricChargeDensity(0.123456, ElectricChargeDensityUnit.CoulombPerCubicMeter).ToString("s3"));
                Assert.Equal("0.1235 C/m³", new ElectricChargeDensity(0.123456, ElectricChargeDensityUnit.CoulombPerCubicMeter).ToString("s4"));
            }
            finally
            {
                CultureInfo.CurrentUICulture = oldCulture;
            }
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 C/m³", new ElectricChargeDensity(0.123456, ElectricChargeDensityUnit.CoulombPerCubicMeter).ToString("s1", culture));
            Assert.Equal("0.12 C/m³", new ElectricChargeDensity(0.123456, ElectricChargeDensityUnit.CoulombPerCubicMeter).ToString("s2", culture));
            Assert.Equal("0.123 C/m³", new ElectricChargeDensity(0.123456, ElectricChargeDensityUnit.CoulombPerCubicMeter).ToString("s3", culture));
            Assert.Equal("0.1235 C/m³", new ElectricChargeDensity(0.123456, ElectricChargeDensityUnit.CoulombPerCubicMeter).ToString("s4", culture));
        }


        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }


        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(ElectricChargeDensity)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(ElectricChargeDensityUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal(QuantityType.ElectricChargeDensity, Convert.ChangeType(quantity, typeof(QuantityType)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal(ElectricChargeDensity.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal(ElectricChargeDensity.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(1.0);
            Assert.Equal(new {ElectricChargeDensity.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = ElectricChargeDensity.FromCoulombsPerCubicMeter(value);
            Assert.Equal(ElectricChargeDensity.FromCoulombsPerCubicMeter(-value), -quantity);
        }
    }
}
