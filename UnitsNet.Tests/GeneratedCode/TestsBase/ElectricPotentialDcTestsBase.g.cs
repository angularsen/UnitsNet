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
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of ElectricPotentialDc.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricPotentialDcTestsBase
    {
        protected abstract double KilovoltsDcInOneVoltDc { get; }
        protected abstract double MegavoltsDcInOneVoltDc { get; }
        protected abstract double MicrovoltsDcInOneVoltDc { get; }
        protected abstract double MillivoltsDcInOneVoltDc { get; }
        protected abstract double VoltsDcInOneVoltDc { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KilovoltsDcTolerance { get { return 1e-5; } }
        protected virtual double MegavoltsDcTolerance { get { return 1e-5; } }
        protected virtual double MicrovoltsDcTolerance { get { return 1e-5; } }
        protected virtual double MillivoltsDcTolerance { get { return 1e-5; } }
        protected virtual double VoltsDcTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricPotentialDc((double)0.0, ElectricPotentialDcUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ElectricPotentialDc();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ElectricPotentialDcUnit.VoltDc, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricPotentialDc(double.PositiveInfinity, ElectricPotentialDcUnit.VoltDc));
            Assert.Throws<ArgumentException>(() => new ElectricPotentialDc(double.NegativeInfinity, ElectricPotentialDcUnit.VoltDc));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricPotentialDc(double.NaN, ElectricPotentialDcUnit.VoltDc));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ElectricPotentialDc(value: 1.0, unitSystem: null));
        }

        [Fact]
        public void ElectricPotentialDc_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ElectricPotentialDc(1, ElectricPotentialDcUnit.VoltDc);

            QuantityInfo<ElectricPotentialDcUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ElectricPotentialDc.Zero, quantityInfo.Zero);
            Assert.Equal("ElectricPotentialDc", quantityInfo.Name);
            Assert.Equal(QuantityType.ElectricPotentialDc, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<ElectricPotentialDcUnit>().Except(new[] {ElectricPotentialDcUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
#pragma warning disable 618
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
#pragma warning restore 618
        }

        [Fact]
        public void VoltDcToElectricPotentialDcUnits()
        {
            ElectricPotentialDc voltdc = ElectricPotentialDc.FromVoltsDc(1);
            AssertEx.EqualTolerance(KilovoltsDcInOneVoltDc, voltdc.KilovoltsDc, KilovoltsDcTolerance);
            AssertEx.EqualTolerance(MegavoltsDcInOneVoltDc, voltdc.MegavoltsDc, MegavoltsDcTolerance);
            AssertEx.EqualTolerance(MicrovoltsDcInOneVoltDc, voltdc.MicrovoltsDc, MicrovoltsDcTolerance);
            AssertEx.EqualTolerance(MillivoltsDcInOneVoltDc, voltdc.MillivoltsDc, MillivoltsDcTolerance);
            AssertEx.EqualTolerance(VoltsDcInOneVoltDc, voltdc.VoltsDc, VoltsDcTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ElectricPotentialDc.From(1, ElectricPotentialDcUnit.KilovoltDc);
            AssertEx.EqualTolerance(1, quantity00.KilovoltsDc, KilovoltsDcTolerance);
            Assert.Equal(ElectricPotentialDcUnit.KilovoltDc, quantity00.Unit);

            var quantity01 = ElectricPotentialDc.From(1, ElectricPotentialDcUnit.MegavoltDc);
            AssertEx.EqualTolerance(1, quantity01.MegavoltsDc, MegavoltsDcTolerance);
            Assert.Equal(ElectricPotentialDcUnit.MegavoltDc, quantity01.Unit);

            var quantity02 = ElectricPotentialDc.From(1, ElectricPotentialDcUnit.MicrovoltDc);
            AssertEx.EqualTolerance(1, quantity02.MicrovoltsDc, MicrovoltsDcTolerance);
            Assert.Equal(ElectricPotentialDcUnit.MicrovoltDc, quantity02.Unit);

            var quantity03 = ElectricPotentialDc.From(1, ElectricPotentialDcUnit.MillivoltDc);
            AssertEx.EqualTolerance(1, quantity03.MillivoltsDc, MillivoltsDcTolerance);
            Assert.Equal(ElectricPotentialDcUnit.MillivoltDc, quantity03.Unit);

            var quantity04 = ElectricPotentialDc.From(1, ElectricPotentialDcUnit.VoltDc);
            AssertEx.EqualTolerance(1, quantity04.VoltsDc, VoltsDcTolerance);
            Assert.Equal(ElectricPotentialDcUnit.VoltDc, quantity04.Unit);

        }

        [Fact]
        public void FromVoltsDc_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricPotentialDc.FromVoltsDc(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => ElectricPotentialDc.FromVoltsDc(double.NegativeInfinity));
        }

        [Fact]
        public void FromVoltsDc_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricPotentialDc.FromVoltsDc(double.NaN));
        }

        [Fact]
        public void As()
        {
            var voltdc = ElectricPotentialDc.FromVoltsDc(1);
            AssertEx.EqualTolerance(KilovoltsDcInOneVoltDc, voltdc.As(ElectricPotentialDcUnit.KilovoltDc), KilovoltsDcTolerance);
            AssertEx.EqualTolerance(MegavoltsDcInOneVoltDc, voltdc.As(ElectricPotentialDcUnit.MegavoltDc), MegavoltsDcTolerance);
            AssertEx.EqualTolerance(MicrovoltsDcInOneVoltDc, voltdc.As(ElectricPotentialDcUnit.MicrovoltDc), MicrovoltsDcTolerance);
            AssertEx.EqualTolerance(MillivoltsDcInOneVoltDc, voltdc.As(ElectricPotentialDcUnit.MillivoltDc), MillivoltsDcTolerance);
            AssertEx.EqualTolerance(VoltsDcInOneVoltDc, voltdc.As(ElectricPotentialDcUnit.VoltDc), VoltsDcTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var voltdc = ElectricPotentialDc.FromVoltsDc(1);

            var kilovoltdcQuantity = voltdc.ToUnit(ElectricPotentialDcUnit.KilovoltDc);
            AssertEx.EqualTolerance(KilovoltsDcInOneVoltDc, (double)kilovoltdcQuantity.Value, KilovoltsDcTolerance);
            Assert.Equal(ElectricPotentialDcUnit.KilovoltDc, kilovoltdcQuantity.Unit);

            var megavoltdcQuantity = voltdc.ToUnit(ElectricPotentialDcUnit.MegavoltDc);
            AssertEx.EqualTolerance(MegavoltsDcInOneVoltDc, (double)megavoltdcQuantity.Value, MegavoltsDcTolerance);
            Assert.Equal(ElectricPotentialDcUnit.MegavoltDc, megavoltdcQuantity.Unit);

            var microvoltdcQuantity = voltdc.ToUnit(ElectricPotentialDcUnit.MicrovoltDc);
            AssertEx.EqualTolerance(MicrovoltsDcInOneVoltDc, (double)microvoltdcQuantity.Value, MicrovoltsDcTolerance);
            Assert.Equal(ElectricPotentialDcUnit.MicrovoltDc, microvoltdcQuantity.Unit);

            var millivoltdcQuantity = voltdc.ToUnit(ElectricPotentialDcUnit.MillivoltDc);
            AssertEx.EqualTolerance(MillivoltsDcInOneVoltDc, (double)millivoltdcQuantity.Value, MillivoltsDcTolerance);
            Assert.Equal(ElectricPotentialDcUnit.MillivoltDc, millivoltdcQuantity.Unit);

            var voltdcQuantity = voltdc.ToUnit(ElectricPotentialDcUnit.VoltDc);
            AssertEx.EqualTolerance(VoltsDcInOneVoltDc, (double)voltdcQuantity.Value, VoltsDcTolerance);
            Assert.Equal(ElectricPotentialDcUnit.VoltDc, voltdcQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ElectricPotentialDc voltdc = ElectricPotentialDc.FromVoltsDc(1);
            AssertEx.EqualTolerance(1, ElectricPotentialDc.FromKilovoltsDc(voltdc.KilovoltsDc).VoltsDc, KilovoltsDcTolerance);
            AssertEx.EqualTolerance(1, ElectricPotentialDc.FromMegavoltsDc(voltdc.MegavoltsDc).VoltsDc, MegavoltsDcTolerance);
            AssertEx.EqualTolerance(1, ElectricPotentialDc.FromMicrovoltsDc(voltdc.MicrovoltsDc).VoltsDc, MicrovoltsDcTolerance);
            AssertEx.EqualTolerance(1, ElectricPotentialDc.FromMillivoltsDc(voltdc.MillivoltsDc).VoltsDc, MillivoltsDcTolerance);
            AssertEx.EqualTolerance(1, ElectricPotentialDc.FromVoltsDc(voltdc.VoltsDc).VoltsDc, VoltsDcTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ElectricPotentialDc v = ElectricPotentialDc.FromVoltsDc(1);
            AssertEx.EqualTolerance(-1, -v.VoltsDc, VoltsDcTolerance);
            AssertEx.EqualTolerance(2, (ElectricPotentialDc.FromVoltsDc(3)-v).VoltsDc, VoltsDcTolerance);
            AssertEx.EqualTolerance(2, (v + v).VoltsDc, VoltsDcTolerance);
            AssertEx.EqualTolerance(10, (v*10).VoltsDc, VoltsDcTolerance);
            AssertEx.EqualTolerance(10, (10*v).VoltsDc, VoltsDcTolerance);
            AssertEx.EqualTolerance(2, (ElectricPotentialDc.FromVoltsDc(10)/5).VoltsDc, VoltsDcTolerance);
            AssertEx.EqualTolerance(2, ElectricPotentialDc.FromVoltsDc(10)/ElectricPotentialDc.FromVoltsDc(5), VoltsDcTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ElectricPotentialDc oneVoltDc = ElectricPotentialDc.FromVoltsDc(1);
            ElectricPotentialDc twoVoltsDc = ElectricPotentialDc.FromVoltsDc(2);

            Assert.True(oneVoltDc < twoVoltsDc);
            Assert.True(oneVoltDc <= twoVoltsDc);
            Assert.True(twoVoltsDc > oneVoltDc);
            Assert.True(twoVoltsDc >= oneVoltDc);

            Assert.False(oneVoltDc > twoVoltsDc);
            Assert.False(oneVoltDc >= twoVoltsDc);
            Assert.False(twoVoltsDc < oneVoltDc);
            Assert.False(twoVoltsDc <= oneVoltDc);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ElectricPotentialDc voltdc = ElectricPotentialDc.FromVoltsDc(1);
            Assert.Equal(0, voltdc.CompareTo(voltdc));
            Assert.True(voltdc.CompareTo(ElectricPotentialDc.Zero) > 0);
            Assert.True(ElectricPotentialDc.Zero.CompareTo(voltdc) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricPotentialDc voltdc = ElectricPotentialDc.FromVoltsDc(1);
            Assert.Throws<ArgumentException>(() => voltdc.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ElectricPotentialDc voltdc = ElectricPotentialDc.FromVoltsDc(1);
            Assert.Throws<ArgumentNullException>(() => voltdc.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = ElectricPotentialDc.FromVoltsDc(1);
            var b = ElectricPotentialDc.FromVoltsDc(2);

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
        public void EqualsIsImplemented()
        {
            var a = ElectricPotentialDc.FromVoltsDc(1);
            var b = ElectricPotentialDc.FromVoltsDc(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {
            var v = ElectricPotentialDc.FromVoltsDc(1);
            Assert.True(v.Equals(ElectricPotentialDc.FromVoltsDc(1), VoltsDcTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ElectricPotentialDc.Zero, VoltsDcTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricPotentialDc voltdc = ElectricPotentialDc.FromVoltsDc(1);
            Assert.False(voltdc.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricPotentialDc voltdc = ElectricPotentialDc.FromVoltsDc(1);
            Assert.False(voltdc.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(ElectricPotentialDcUnit.Undefined, ElectricPotentialDc.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ElectricPotentialDcUnit)).Cast<ElectricPotentialDcUnit>();
            foreach(var unit in units)
            {
                if(unit == ElectricPotentialDcUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ElectricPotentialDc.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 kVdc", new ElectricPotentialDc(1, ElectricPotentialDcUnit.KilovoltDc).ToString());
                Assert.Equal("1 MVdc", new ElectricPotentialDc(1, ElectricPotentialDcUnit.MegavoltDc).ToString());
                Assert.Equal("1 µVdc", new ElectricPotentialDc(1, ElectricPotentialDcUnit.MicrovoltDc).ToString());
                Assert.Equal("1 mVdc", new ElectricPotentialDc(1, ElectricPotentialDcUnit.MillivoltDc).ToString());
                Assert.Equal("1 Vdc", new ElectricPotentialDc(1, ElectricPotentialDcUnit.VoltDc).ToString());
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

            Assert.Equal("1 kVdc", new ElectricPotentialDc(1, ElectricPotentialDcUnit.KilovoltDc).ToString(swedishCulture));
            Assert.Equal("1 MVdc", new ElectricPotentialDc(1, ElectricPotentialDcUnit.MegavoltDc).ToString(swedishCulture));
            Assert.Equal("1 µVdc", new ElectricPotentialDc(1, ElectricPotentialDcUnit.MicrovoltDc).ToString(swedishCulture));
            Assert.Equal("1 mVdc", new ElectricPotentialDc(1, ElectricPotentialDcUnit.MillivoltDc).ToString(swedishCulture));
            Assert.Equal("1 Vdc", new ElectricPotentialDc(1, ElectricPotentialDcUnit.VoltDc).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 Vdc", new ElectricPotentialDc(0.123456, ElectricPotentialDcUnit.VoltDc).ToString("s1"));
                Assert.Equal("0.12 Vdc", new ElectricPotentialDc(0.123456, ElectricPotentialDcUnit.VoltDc).ToString("s2"));
                Assert.Equal("0.123 Vdc", new ElectricPotentialDc(0.123456, ElectricPotentialDcUnit.VoltDc).ToString("s3"));
                Assert.Equal("0.1235 Vdc", new ElectricPotentialDc(0.123456, ElectricPotentialDcUnit.VoltDc).ToString("s4"));
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
            Assert.Equal("0.1 Vdc", new ElectricPotentialDc(0.123456, ElectricPotentialDcUnit.VoltDc).ToString("s1", culture));
            Assert.Equal("0.12 Vdc", new ElectricPotentialDc(0.123456, ElectricPotentialDcUnit.VoltDc).ToString("s2", culture));
            Assert.Equal("0.123 Vdc", new ElectricPotentialDc(0.123456, ElectricPotentialDcUnit.VoltDc).ToString("s3", culture));
            Assert.Equal("0.1235 Vdc", new ElectricPotentialDc(0.123456, ElectricPotentialDcUnit.VoltDc).ToString("s4", culture));
        }

        #pragma warning disable 612, 618

        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }

        #pragma warning restore 612, 618

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricPotentialDc.FromVoltsDc(1.0);
           Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }
    }
}
