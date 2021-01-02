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
    /// Test of MagneticField.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MagneticFieldTestsBase : QuantityTestsBase
    {
        protected abstract double GaussesInOneTesla { get; }
        protected abstract double MicroteslasInOneTesla { get; }
        protected abstract double MilliteslasInOneTesla { get; }
        protected abstract double NanoteslasInOneTesla { get; }
        protected abstract double TeslasInOneTesla { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double GaussesTolerance { get { return 1e-5; } }
        protected virtual double MicroteslasTolerance { get { return 1e-5; } }
        protected virtual double MilliteslasTolerance { get { return 1e-5; } }
        protected virtual double NanoteslasTolerance { get { return 1e-5; } }
        protected virtual double TeslasTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new MagneticField<double>((double)0.0, MagneticFieldUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new MagneticField();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(MagneticFieldUnit.Tesla, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new MagneticField<double>(double.PositiveInfinity, MagneticFieldUnit.Tesla));
            Assert.Throws<ArgumentException>(() => new MagneticField<double>(double.NegativeInfinity, MagneticFieldUnit.Tesla));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new MagneticField<double>(double.NaN, MagneticFieldUnit.Tesla));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new MagneticField(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new MagneticField(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (MagneticField) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void MagneticField_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new MagneticField(1, MagneticFieldUnit.Tesla);

            QuantityInfo<MagneticFieldUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(MagneticField.Zero, quantityInfo.Zero);
            Assert.Equal("MagneticField", quantityInfo.Name);
            Assert.Equal(QuantityType.MagneticField, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<MagneticFieldUnit>().Except(new[] {MagneticFieldUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
        }

        [Fact]
        public void TeslaToMagneticFieldUnits()
        {
            MagneticField<double> tesla = MagneticField<double>.FromTeslas(1);
            AssertEx.EqualTolerance(GaussesInOneTesla, tesla.Gausses, GaussesTolerance);
            AssertEx.EqualTolerance(MicroteslasInOneTesla, tesla.Microteslas, MicroteslasTolerance);
            AssertEx.EqualTolerance(MilliteslasInOneTesla, tesla.Milliteslas, MilliteslasTolerance);
            AssertEx.EqualTolerance(NanoteslasInOneTesla, tesla.Nanoteslas, NanoteslasTolerance);
            AssertEx.EqualTolerance(TeslasInOneTesla, tesla.Teslas, TeslasTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = MagneticField<double>.From(1, MagneticFieldUnit.Gauss);
            AssertEx.EqualTolerance(1, quantity00.Gausses, GaussesTolerance);
            Assert.Equal(MagneticFieldUnit.Gauss, quantity00.Unit);

            var quantity01 = MagneticField<double>.From(1, MagneticFieldUnit.Microtesla);
            AssertEx.EqualTolerance(1, quantity01.Microteslas, MicroteslasTolerance);
            Assert.Equal(MagneticFieldUnit.Microtesla, quantity01.Unit);

            var quantity02 = MagneticField<double>.From(1, MagneticFieldUnit.Millitesla);
            AssertEx.EqualTolerance(1, quantity02.Milliteslas, MilliteslasTolerance);
            Assert.Equal(MagneticFieldUnit.Millitesla, quantity02.Unit);

            var quantity03 = MagneticField<double>.From(1, MagneticFieldUnit.Nanotesla);
            AssertEx.EqualTolerance(1, quantity03.Nanoteslas, NanoteslasTolerance);
            Assert.Equal(MagneticFieldUnit.Nanotesla, quantity03.Unit);

            var quantity04 = MagneticField<double>.From(1, MagneticFieldUnit.Tesla);
            AssertEx.EqualTolerance(1, quantity04.Teslas, TeslasTolerance);
            Assert.Equal(MagneticFieldUnit.Tesla, quantity04.Unit);

        }

        [Fact]
        public void FromTeslas_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => MagneticField<double>.FromTeslas(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => MagneticField<double>.FromTeslas(double.NegativeInfinity));
        }

        [Fact]
        public void FromTeslas_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => MagneticField<double>.FromTeslas(double.NaN));
        }

        [Fact]
        public void As()
        {
            var tesla = MagneticField<double>.FromTeslas(1);
            AssertEx.EqualTolerance(GaussesInOneTesla, tesla.As(MagneticFieldUnit.Gauss), GaussesTolerance);
            AssertEx.EqualTolerance(MicroteslasInOneTesla, tesla.As(MagneticFieldUnit.Microtesla), MicroteslasTolerance);
            AssertEx.EqualTolerance(MilliteslasInOneTesla, tesla.As(MagneticFieldUnit.Millitesla), MilliteslasTolerance);
            AssertEx.EqualTolerance(NanoteslasInOneTesla, tesla.As(MagneticFieldUnit.Nanotesla), NanoteslasTolerance);
            AssertEx.EqualTolerance(TeslasInOneTesla, tesla.As(MagneticFieldUnit.Tesla), TeslasTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new MagneticField(value: 1, unit: MagneticField.BaseUnit);
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
            var tesla = MagneticField<double>.FromTeslas(1);

            var gaussQuantity = tesla.ToUnit(MagneticFieldUnit.Gauss);
            AssertEx.EqualTolerance(GaussesInOneTesla, (double)gaussQuantity.Value, GaussesTolerance);
            Assert.Equal(MagneticFieldUnit.Gauss, gaussQuantity.Unit);

            var microteslaQuantity = tesla.ToUnit(MagneticFieldUnit.Microtesla);
            AssertEx.EqualTolerance(MicroteslasInOneTesla, (double)microteslaQuantity.Value, MicroteslasTolerance);
            Assert.Equal(MagneticFieldUnit.Microtesla, microteslaQuantity.Unit);

            var milliteslaQuantity = tesla.ToUnit(MagneticFieldUnit.Millitesla);
            AssertEx.EqualTolerance(MilliteslasInOneTesla, (double)milliteslaQuantity.Value, MilliteslasTolerance);
            Assert.Equal(MagneticFieldUnit.Millitesla, milliteslaQuantity.Unit);

            var nanoteslaQuantity = tesla.ToUnit(MagneticFieldUnit.Nanotesla);
            AssertEx.EqualTolerance(NanoteslasInOneTesla, (double)nanoteslaQuantity.Value, NanoteslasTolerance);
            Assert.Equal(MagneticFieldUnit.Nanotesla, nanoteslaQuantity.Unit);

            var teslaQuantity = tesla.ToUnit(MagneticFieldUnit.Tesla);
            AssertEx.EqualTolerance(TeslasInOneTesla, (double)teslaQuantity.Value, TeslasTolerance);
            Assert.Equal(MagneticFieldUnit.Tesla, teslaQuantity.Unit);
        }

        [Fact]
        public void ToBaseUnit_ReturnsQuantityWithBaseUnit()
        {
            var quantityInBaseUnit = MagneticField.FromTeslas(1).ToBaseUnit();
            Assert.Equal(MagneticField.BaseUnit, quantityInBaseUnit.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            MagneticField<double> tesla = MagneticField<double>.FromTeslas(1);
            AssertEx.EqualTolerance(1, MagneticField<double>.FromGausses(tesla.Gausses).Teslas, GaussesTolerance);
            AssertEx.EqualTolerance(1, MagneticField<double>.FromMicroteslas(tesla.Microteslas).Teslas, MicroteslasTolerance);
            AssertEx.EqualTolerance(1, MagneticField<double>.FromMilliteslas(tesla.Milliteslas).Teslas, MilliteslasTolerance);
            AssertEx.EqualTolerance(1, MagneticField<double>.FromNanoteslas(tesla.Nanoteslas).Teslas, NanoteslasTolerance);
            AssertEx.EqualTolerance(1, MagneticField<double>.FromTeslas(tesla.Teslas).Teslas, TeslasTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            MagneticField<double> v = MagneticField<double>.FromTeslas(1);
            AssertEx.EqualTolerance(-1, -v.Teslas, TeslasTolerance);
            AssertEx.EqualTolerance(2, (MagneticField<double>.FromTeslas(3)-v).Teslas, TeslasTolerance);
            AssertEx.EqualTolerance(2, (v + v).Teslas, TeslasTolerance);
            AssertEx.EqualTolerance(10, (v*10).Teslas, TeslasTolerance);
            AssertEx.EqualTolerance(10, (10*v).Teslas, TeslasTolerance);
            AssertEx.EqualTolerance(2, (MagneticField<double>.FromTeslas(10)/5).Teslas, TeslasTolerance);
            AssertEx.EqualTolerance(2, MagneticField<double>.FromTeslas(10)/MagneticField<double>.FromTeslas(5), TeslasTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            MagneticField<double> oneTesla = MagneticField<double>.FromTeslas(1);
            MagneticField<double> twoTeslas = MagneticField<double>.FromTeslas(2);

            Assert.True(oneTesla < twoTeslas);
            Assert.True(oneTesla <= twoTeslas);
            Assert.True(twoTeslas > oneTesla);
            Assert.True(twoTeslas >= oneTesla);

            Assert.False(oneTesla > twoTeslas);
            Assert.False(oneTesla >= twoTeslas);
            Assert.False(twoTeslas < oneTesla);
            Assert.False(twoTeslas <= oneTesla);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            MagneticField<double> tesla = MagneticField<double>.FromTeslas(1);
            Assert.Equal(0, tesla.CompareTo(tesla));
            Assert.True(tesla.CompareTo(MagneticField<double>.Zero) > 0);
            Assert.True(MagneticField<double>.Zero.CompareTo(tesla) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            MagneticField<double> tesla = MagneticField<double>.FromTeslas(1);
            Assert.Throws<ArgumentException>(() => tesla.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            MagneticField<double> tesla = MagneticField<double>.FromTeslas(1);
            Assert.Throws<ArgumentNullException>(() => tesla.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = MagneticField<double>.FromTeslas(1);
            var b = MagneticField<double>.FromTeslas(2);

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
            var a = MagneticField<double>.FromTeslas(1);
            var b = MagneticField<double>.FromTeslas(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = MagneticField.FromTeslas(1);
            object b = MagneticField.FromTeslas(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = MagneticField<double>.FromTeslas(1);
            Assert.True(v.Equals(MagneticField<double>.FromTeslas(1), TeslasTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(MagneticField<double>.Zero, TeslasTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = MagneticField.FromTeslas(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(MagneticField.FromTeslas(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            MagneticField<double> tesla = MagneticField<double>.FromTeslas(1);
            Assert.False(tesla.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            MagneticField<double> tesla = MagneticField<double>.FromTeslas(1);
            Assert.False(tesla.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(MagneticFieldUnit.Undefined, MagneticField<double>.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(MagneticFieldUnit)).Cast<MagneticFieldUnit>();
            foreach(var unit in units)
            {
                if(unit == MagneticFieldUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(MagneticField<double>.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 G", new MagneticField(1, MagneticFieldUnit.Gauss).ToString());
                Assert.Equal("1 µT", new MagneticField(1, MagneticFieldUnit.Microtesla).ToString());
                Assert.Equal("1 mT", new MagneticField(1, MagneticFieldUnit.Millitesla).ToString());
                Assert.Equal("1 nT", new MagneticField(1, MagneticFieldUnit.Nanotesla).ToString());
                Assert.Equal("1 T", new MagneticField(1, MagneticFieldUnit.Tesla).ToString());
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

            Assert.Equal("1 G", new MagneticField(1, MagneticFieldUnit.Gauss).ToString(swedishCulture));
            Assert.Equal("1 µT", new MagneticField(1, MagneticFieldUnit.Microtesla).ToString(swedishCulture));
            Assert.Equal("1 mT", new MagneticField(1, MagneticFieldUnit.Millitesla).ToString(swedishCulture));
            Assert.Equal("1 nT", new MagneticField(1, MagneticFieldUnit.Nanotesla).ToString(swedishCulture));
            Assert.Equal("1 T", new MagneticField(1, MagneticFieldUnit.Tesla).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 T", new MagneticField(0.123456, MagneticFieldUnit.Tesla).ToString("s1"));
                Assert.Equal("0.12 T", new MagneticField(0.123456, MagneticFieldUnit.Tesla).ToString("s2"));
                Assert.Equal("0.123 T", new MagneticField(0.123456, MagneticFieldUnit.Tesla).ToString("s3"));
                Assert.Equal("0.1235 T", new MagneticField(0.123456, MagneticFieldUnit.Tesla).ToString("s4"));
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
            Assert.Equal("0.1 T", new MagneticField(0.123456, MagneticFieldUnit.Tesla).ToString("s1", culture));
            Assert.Equal("0.12 T", new MagneticField(0.123456, MagneticFieldUnit.Tesla).ToString("s2", culture));
            Assert.Equal("0.123 T", new MagneticField(0.123456, MagneticFieldUnit.Tesla).ToString("s3", culture));
            Assert.Equal("0.1235 T", new MagneticField(0.123456, MagneticFieldUnit.Tesla).ToString("s4", culture));
        }


        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }


        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(MagneticField)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(MagneticFieldUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal(QuantityType.MagneticField, Convert.ChangeType(quantity, typeof(QuantityType)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal(MagneticField.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal(MagneticField.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = MagneticField.FromTeslas(1.0);
            Assert.Equal(new {MagneticField.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = MagneticField.FromTeslas(value);
            Assert.Equal(MagneticField.FromTeslas(-value), -quantity);
        }
    }
}
