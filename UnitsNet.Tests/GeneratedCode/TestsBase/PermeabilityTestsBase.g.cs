﻿//------------------------------------------------------------------------------
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
    /// Test of Permeability.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class PermeabilityTestsBase : QuantityTestsBase
    {
        protected abstract double HenriesPerMeterInOneHenryPerMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double HenriesPerMeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Permeability<double>((double)0.0, PermeabilityUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new Permeability();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(PermeabilityUnit.HenryPerMeter, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Permeability<double>(double.PositiveInfinity, PermeabilityUnit.HenryPerMeter));
            Assert.Throws<ArgumentException>(() => new Permeability<double>(double.NegativeInfinity, PermeabilityUnit.HenryPerMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Permeability<double>(double.NaN, PermeabilityUnit.HenryPerMeter));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Permeability(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new Permeability(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (Permeability) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void Permeability_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new Permeability(1, PermeabilityUnit.HenryPerMeter);

            QuantityInfo<PermeabilityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(Permeability.Zero, quantityInfo.Zero);
            Assert.Equal("Permeability", quantityInfo.Name);
            Assert.Equal(QuantityType.Permeability, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<PermeabilityUnit>().Except(new[] {PermeabilityUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
        }

        [Fact]
        public void HenryPerMeterToPermeabilityUnits()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            AssertEx.EqualTolerance(HenriesPerMeterInOneHenryPerMeter, henrypermeter.HenriesPerMeter, HenriesPerMeterTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = Permeability<double>.From(1, PermeabilityUnit.HenryPerMeter);
            AssertEx.EqualTolerance(1, quantity00.HenriesPerMeter, HenriesPerMeterTolerance);
            Assert.Equal(PermeabilityUnit.HenryPerMeter, quantity00.Unit);

        }

        [Fact]
        public void FromHenriesPerMeter_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Permeability<double>.FromHenriesPerMeter(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => Permeability<double>.FromHenriesPerMeter(double.NegativeInfinity));
        }

        [Fact]
        public void FromHenriesPerMeter_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Permeability<double>.FromHenriesPerMeter(double.NaN));
        }

        [Fact]
        public void As()
        {
            var henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            AssertEx.EqualTolerance(HenriesPerMeterInOneHenryPerMeter, henrypermeter.As(PermeabilityUnit.HenryPerMeter), HenriesPerMeterTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new Permeability(value: 1, unit: Permeability.BaseUnit);
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
            var henrypermeter = Permeability<double>.FromHenriesPerMeter(1);

            var henrypermeterQuantity = henrypermeter.ToUnit(PermeabilityUnit.HenryPerMeter);
            AssertEx.EqualTolerance(HenriesPerMeterInOneHenryPerMeter, (double)henrypermeterQuantity.Value, HenriesPerMeterTolerance);
            Assert.Equal(PermeabilityUnit.HenryPerMeter, henrypermeterQuantity.Unit);
        }

        [Fact]
        public void ToBaseUnit_ReturnsQuantityWithBaseUnit()
        {
            var quantityInBaseUnit = Permeability.FromHenriesPerMeter(1).ToBaseUnit();
            Assert.Equal(Permeability.BaseUnit, quantityInBaseUnit.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            AssertEx.EqualTolerance(1, Permeability<double>.FromHenriesPerMeter(henrypermeter.HenriesPerMeter).HenriesPerMeter, HenriesPerMeterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Permeability<double> v = Permeability<double>.FromHenriesPerMeter(1);
            AssertEx.EqualTolerance(-1, -v.HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(2, (Permeability<double>.FromHenriesPerMeter(3)-v).HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(2, (Permeability<double>.FromHenriesPerMeter(10)/5).HenriesPerMeter, HenriesPerMeterTolerance);
            AssertEx.EqualTolerance(2, Permeability<double>.FromHenriesPerMeter(10)/Permeability<double>.FromHenriesPerMeter(5), HenriesPerMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            Permeability<double> oneHenryPerMeter = Permeability<double>.FromHenriesPerMeter(1);
            Permeability<double> twoHenriesPerMeter = Permeability<double>.FromHenriesPerMeter(2);

            Assert.True(oneHenryPerMeter < twoHenriesPerMeter);
            Assert.True(oneHenryPerMeter <= twoHenriesPerMeter);
            Assert.True(twoHenriesPerMeter > oneHenryPerMeter);
            Assert.True(twoHenriesPerMeter >= oneHenryPerMeter);

            Assert.False(oneHenryPerMeter > twoHenriesPerMeter);
            Assert.False(oneHenryPerMeter >= twoHenriesPerMeter);
            Assert.False(twoHenriesPerMeter < oneHenryPerMeter);
            Assert.False(twoHenriesPerMeter <= oneHenryPerMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            Assert.Equal(0, henrypermeter.CompareTo(henrypermeter));
            Assert.True(henrypermeter.CompareTo(Permeability<double>.Zero) > 0);
            Assert.True(Permeability<double>.Zero.CompareTo(henrypermeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            Assert.Throws<ArgumentException>(() => henrypermeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            Assert.Throws<ArgumentNullException>(() => henrypermeter.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = Permeability<double>.FromHenriesPerMeter(1);
            var b = Permeability<double>.FromHenriesPerMeter(2);

 // ReSharper disable EqualExpressionComparison

            Assert.True(a == a);
            Assert.False(a != a);

            Assert.True(a != b);
            Assert.False(a == b);

            Assert.False(a == null);
            Assert.False(null == a);

// ReSharper restore EqualExpressionComparison
        }

        [Fact]
        public void Equals_SameType_IsImplemented()
        {
            var a = Permeability<double>.FromHenriesPerMeter(1);
            var b = Permeability<double>.FromHenriesPerMeter(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = Permeability.FromHenriesPerMeter(1);
            object b = Permeability.FromHenriesPerMeter(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = Permeability<double>.FromHenriesPerMeter(1);
            Assert.True(v.Equals(Permeability<double>.FromHenriesPerMeter(1), HenriesPerMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Permeability<double>.Zero, HenriesPerMeterTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = Permeability.FromHenriesPerMeter(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(Permeability.FromHenriesPerMeter(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            Assert.False(henrypermeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Permeability<double> henrypermeter = Permeability<double>.FromHenriesPerMeter(1);
            Assert.False(henrypermeter.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(PermeabilityUnit.Undefined, Permeability<double>.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(PermeabilityUnit)).Cast<PermeabilityUnit>();
            foreach(var unit in units)
            {
                if(unit == PermeabilityUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(Permeability<double>.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 H/m", new Permeability(1, PermeabilityUnit.HenryPerMeter).ToString());
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

            Assert.Equal("1 H/m", new Permeability(1, PermeabilityUnit.HenryPerMeter).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 H/m", new Permeability(0.123456, PermeabilityUnit.HenryPerMeter).ToString("s1"));
                Assert.Equal("0.12 H/m", new Permeability(0.123456, PermeabilityUnit.HenryPerMeter).ToString("s2"));
                Assert.Equal("0.123 H/m", new Permeability(0.123456, PermeabilityUnit.HenryPerMeter).ToString("s3"));
                Assert.Equal("0.1235 H/m", new Permeability(0.123456, PermeabilityUnit.HenryPerMeter).ToString("s4"));
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
            Assert.Equal("0.1 H/m", new Permeability(0.123456, PermeabilityUnit.HenryPerMeter).ToString("s1", culture));
            Assert.Equal("0.12 H/m", new Permeability(0.123456, PermeabilityUnit.HenryPerMeter).ToString("s2", culture));
            Assert.Equal("0.123 H/m", new Permeability(0.123456, PermeabilityUnit.HenryPerMeter).ToString("s3", culture));
            Assert.Equal("0.1235 H/m", new Permeability(0.123456, PermeabilityUnit.HenryPerMeter).ToString("s4", culture));
        }


        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }


        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(Permeability)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(PermeabilityUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal(QuantityType.Permeability, Convert.ChangeType(quantity, typeof(QuantityType)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal(Permeability.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal(Permeability.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = Permeability.FromHenriesPerMeter(1.0);
            Assert.Equal(new {Permeability.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = Permeability.FromHenriesPerMeter(value);
            Assert.Equal(Permeability.FromHenriesPerMeter(-value), -quantity);
        }
    }
}
