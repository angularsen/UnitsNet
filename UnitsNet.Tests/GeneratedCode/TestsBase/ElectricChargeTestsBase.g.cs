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
    /// Test of ElectricCharge.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricChargeTestsBase : QuantityTestsBase
    {
        protected abstract double AmpereHoursInOneCoulomb { get; }
        protected abstract double CoulombsInOneCoulomb { get; }
        protected abstract double KiloampereHoursInOneCoulomb { get; }
        protected abstract double MegaampereHoursInOneCoulomb { get; }
        protected abstract double MilliampereHoursInOneCoulomb { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double AmpereHoursTolerance { get { return 1e-5; } }
        protected virtual double CoulombsTolerance { get { return 1e-5; } }
        protected virtual double KiloampereHoursTolerance { get { return 1e-5; } }
        protected virtual double MegaampereHoursTolerance { get { return 1e-5; } }
        protected virtual double MilliampereHoursTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricCharge<double>((double)0.0, ElectricChargeUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ElectricCharge();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ElectricChargeUnit.Coulomb, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricCharge<double>(double.PositiveInfinity, ElectricChargeUnit.Coulomb));
            Assert.Throws<ArgumentException>(() => new ElectricCharge<double>(double.NegativeInfinity, ElectricChargeUnit.Coulomb));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricCharge<double>(double.NaN, ElectricChargeUnit.Coulomb));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ElectricCharge(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new ElectricCharge(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (ElectricCharge) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void ElectricCharge_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ElectricCharge(1, ElectricChargeUnit.Coulomb);

            QuantityInfo<ElectricChargeUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ElectricCharge.Zero, quantityInfo.Zero);
            Assert.Equal("ElectricCharge", quantityInfo.Name);
            Assert.Equal(QuantityType.ElectricCharge, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<ElectricChargeUnit>().Except(new[] {ElectricChargeUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
        }

        [Fact]
        public void CoulombToElectricChargeUnits()
        {
            ElectricCharge<double> coulomb = ElectricCharge<double>.FromCoulombs(1);
            AssertEx.EqualTolerance(AmpereHoursInOneCoulomb, coulomb.AmpereHours, AmpereHoursTolerance);
            AssertEx.EqualTolerance(CoulombsInOneCoulomb, coulomb.Coulombs, CoulombsTolerance);
            AssertEx.EqualTolerance(KiloampereHoursInOneCoulomb, coulomb.KiloampereHours, KiloampereHoursTolerance);
            AssertEx.EqualTolerance(MegaampereHoursInOneCoulomb, coulomb.MegaampereHours, MegaampereHoursTolerance);
            AssertEx.EqualTolerance(MilliampereHoursInOneCoulomb, coulomb.MilliampereHours, MilliampereHoursTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ElectricCharge<double>.From(1, ElectricChargeUnit.AmpereHour);
            AssertEx.EqualTolerance(1, quantity00.AmpereHours, AmpereHoursTolerance);
            Assert.Equal(ElectricChargeUnit.AmpereHour, quantity00.Unit);

            var quantity01 = ElectricCharge<double>.From(1, ElectricChargeUnit.Coulomb);
            AssertEx.EqualTolerance(1, quantity01.Coulombs, CoulombsTolerance);
            Assert.Equal(ElectricChargeUnit.Coulomb, quantity01.Unit);

            var quantity02 = ElectricCharge<double>.From(1, ElectricChargeUnit.KiloampereHour);
            AssertEx.EqualTolerance(1, quantity02.KiloampereHours, KiloampereHoursTolerance);
            Assert.Equal(ElectricChargeUnit.KiloampereHour, quantity02.Unit);

            var quantity03 = ElectricCharge<double>.From(1, ElectricChargeUnit.MegaampereHour);
            AssertEx.EqualTolerance(1, quantity03.MegaampereHours, MegaampereHoursTolerance);
            Assert.Equal(ElectricChargeUnit.MegaampereHour, quantity03.Unit);

            var quantity04 = ElectricCharge<double>.From(1, ElectricChargeUnit.MilliampereHour);
            AssertEx.EqualTolerance(1, quantity04.MilliampereHours, MilliampereHoursTolerance);
            Assert.Equal(ElectricChargeUnit.MilliampereHour, quantity04.Unit);

        }

        [Fact]
        public void FromCoulombs_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricCharge<double>.FromCoulombs(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => ElectricCharge<double>.FromCoulombs(double.NegativeInfinity));
        }

        [Fact]
        public void FromCoulombs_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricCharge<double>.FromCoulombs(double.NaN));
        }

        [Fact]
        public void As()
        {
            var coulomb = ElectricCharge<double>.FromCoulombs(1);
            AssertEx.EqualTolerance(AmpereHoursInOneCoulomb, coulomb.As(ElectricChargeUnit.AmpereHour), AmpereHoursTolerance);
            AssertEx.EqualTolerance(CoulombsInOneCoulomb, coulomb.As(ElectricChargeUnit.Coulomb), CoulombsTolerance);
            AssertEx.EqualTolerance(KiloampereHoursInOneCoulomb, coulomb.As(ElectricChargeUnit.KiloampereHour), KiloampereHoursTolerance);
            AssertEx.EqualTolerance(MegaampereHoursInOneCoulomb, coulomb.As(ElectricChargeUnit.MegaampereHour), MegaampereHoursTolerance);
            AssertEx.EqualTolerance(MilliampereHoursInOneCoulomb, coulomb.As(ElectricChargeUnit.MilliampereHour), MilliampereHoursTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new ElectricCharge(value: 1, unit: ElectricCharge.BaseUnit);
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
            var coulomb = ElectricCharge<double>.FromCoulombs(1);

            var amperehourQuantity = coulomb.ToUnit(ElectricChargeUnit.AmpereHour);
            AssertEx.EqualTolerance(AmpereHoursInOneCoulomb, (double)amperehourQuantity.Value, AmpereHoursTolerance);
            Assert.Equal(ElectricChargeUnit.AmpereHour, amperehourQuantity.Unit);

            var coulombQuantity = coulomb.ToUnit(ElectricChargeUnit.Coulomb);
            AssertEx.EqualTolerance(CoulombsInOneCoulomb, (double)coulombQuantity.Value, CoulombsTolerance);
            Assert.Equal(ElectricChargeUnit.Coulomb, coulombQuantity.Unit);

            var kiloamperehourQuantity = coulomb.ToUnit(ElectricChargeUnit.KiloampereHour);
            AssertEx.EqualTolerance(KiloampereHoursInOneCoulomb, (double)kiloamperehourQuantity.Value, KiloampereHoursTolerance);
            Assert.Equal(ElectricChargeUnit.KiloampereHour, kiloamperehourQuantity.Unit);

            var megaamperehourQuantity = coulomb.ToUnit(ElectricChargeUnit.MegaampereHour);
            AssertEx.EqualTolerance(MegaampereHoursInOneCoulomb, (double)megaamperehourQuantity.Value, MegaampereHoursTolerance);
            Assert.Equal(ElectricChargeUnit.MegaampereHour, megaamperehourQuantity.Unit);

            var milliamperehourQuantity = coulomb.ToUnit(ElectricChargeUnit.MilliampereHour);
            AssertEx.EqualTolerance(MilliampereHoursInOneCoulomb, (double)milliamperehourQuantity.Value, MilliampereHoursTolerance);
            Assert.Equal(ElectricChargeUnit.MilliampereHour, milliamperehourQuantity.Unit);
        }

        [Fact]
        public void ToBaseUnit_ReturnsQuantityWithBaseUnit()
        {
            var quantityInBaseUnit = ElectricCharge.FromCoulombs(1).ToBaseUnit();
            Assert.Equal(ElectricCharge.BaseUnit, quantityInBaseUnit.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ElectricCharge<double> coulomb = ElectricCharge<double>.FromCoulombs(1);
            AssertEx.EqualTolerance(1, ElectricCharge<double>.FromAmpereHours(coulomb.AmpereHours).Coulombs, AmpereHoursTolerance);
            AssertEx.EqualTolerance(1, ElectricCharge<double>.FromCoulombs(coulomb.Coulombs).Coulombs, CoulombsTolerance);
            AssertEx.EqualTolerance(1, ElectricCharge<double>.FromKiloampereHours(coulomb.KiloampereHours).Coulombs, KiloampereHoursTolerance);
            AssertEx.EqualTolerance(1, ElectricCharge<double>.FromMegaampereHours(coulomb.MegaampereHours).Coulombs, MegaampereHoursTolerance);
            AssertEx.EqualTolerance(1, ElectricCharge<double>.FromMilliampereHours(coulomb.MilliampereHours).Coulombs, MilliampereHoursTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ElectricCharge<double> v = ElectricCharge<double>.FromCoulombs(1);
            AssertEx.EqualTolerance(-1, -v.Coulombs, CoulombsTolerance);
            AssertEx.EqualTolerance(2, (ElectricCharge<double>.FromCoulombs(3)-v).Coulombs, CoulombsTolerance);
            AssertEx.EqualTolerance(2, (v + v).Coulombs, CoulombsTolerance);
            AssertEx.EqualTolerance(10, (v*10).Coulombs, CoulombsTolerance);
            AssertEx.EqualTolerance(10, (10*v).Coulombs, CoulombsTolerance);
            AssertEx.EqualTolerance(2, (ElectricCharge<double>.FromCoulombs(10)/5).Coulombs, CoulombsTolerance);
            AssertEx.EqualTolerance(2, ElectricCharge<double>.FromCoulombs(10)/ElectricCharge<double>.FromCoulombs(5), CoulombsTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ElectricCharge<double> oneCoulomb = ElectricCharge<double>.FromCoulombs(1);
            ElectricCharge<double> twoCoulombs = ElectricCharge<double>.FromCoulombs(2);

            Assert.True(oneCoulomb < twoCoulombs);
            Assert.True(oneCoulomb <= twoCoulombs);
            Assert.True(twoCoulombs > oneCoulomb);
            Assert.True(twoCoulombs >= oneCoulomb);

            Assert.False(oneCoulomb > twoCoulombs);
            Assert.False(oneCoulomb >= twoCoulombs);
            Assert.False(twoCoulombs < oneCoulomb);
            Assert.False(twoCoulombs <= oneCoulomb);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ElectricCharge<double> coulomb = ElectricCharge<double>.FromCoulombs(1);
            Assert.Equal(0, coulomb.CompareTo(coulomb));
            Assert.True(coulomb.CompareTo(ElectricCharge<double>.Zero) > 0);
            Assert.True(ElectricCharge<double>.Zero.CompareTo(coulomb) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricCharge<double> coulomb = ElectricCharge<double>.FromCoulombs(1);
            Assert.Throws<ArgumentException>(() => coulomb.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ElectricCharge<double> coulomb = ElectricCharge<double>.FromCoulombs(1);
            Assert.Throws<ArgumentNullException>(() => coulomb.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = ElectricCharge<double>.FromCoulombs(1);
            var b = ElectricCharge<double>.FromCoulombs(2);

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
            var a = ElectricCharge<double>.FromCoulombs(1);
            var b = ElectricCharge<double>.FromCoulombs(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = ElectricCharge.FromCoulombs(1);
            object b = ElectricCharge.FromCoulombs(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = ElectricCharge<double>.FromCoulombs(1);
            Assert.True(v.Equals(ElectricCharge<double>.FromCoulombs(1), CoulombsTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ElectricCharge<double>.Zero, CoulombsTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = ElectricCharge.FromCoulombs(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(ElectricCharge.FromCoulombs(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricCharge<double> coulomb = ElectricCharge<double>.FromCoulombs(1);
            Assert.False(coulomb.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricCharge<double> coulomb = ElectricCharge<double>.FromCoulombs(1);
            Assert.False(coulomb.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(ElectricChargeUnit.Undefined, ElectricCharge<double>.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ElectricChargeUnit)).Cast<ElectricChargeUnit>();
            foreach(var unit in units)
            {
                if(unit == ElectricChargeUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ElectricCharge<double>.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 A-h", new ElectricCharge(1, ElectricChargeUnit.AmpereHour).ToString());
                Assert.Equal("1 C", new ElectricCharge(1, ElectricChargeUnit.Coulomb).ToString());
                Assert.Equal("1 kA-h", new ElectricCharge(1, ElectricChargeUnit.KiloampereHour).ToString());
                Assert.Equal("1 MA-h", new ElectricCharge(1, ElectricChargeUnit.MegaampereHour).ToString());
                Assert.Equal("1 mA-h", new ElectricCharge(1, ElectricChargeUnit.MilliampereHour).ToString());
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

            Assert.Equal("1 A-h", new ElectricCharge(1, ElectricChargeUnit.AmpereHour).ToString(swedishCulture));
            Assert.Equal("1 C", new ElectricCharge(1, ElectricChargeUnit.Coulomb).ToString(swedishCulture));
            Assert.Equal("1 kA-h", new ElectricCharge(1, ElectricChargeUnit.KiloampereHour).ToString(swedishCulture));
            Assert.Equal("1 MA-h", new ElectricCharge(1, ElectricChargeUnit.MegaampereHour).ToString(swedishCulture));
            Assert.Equal("1 mA-h", new ElectricCharge(1, ElectricChargeUnit.MilliampereHour).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 C", new ElectricCharge(0.123456, ElectricChargeUnit.Coulomb).ToString("s1"));
                Assert.Equal("0.12 C", new ElectricCharge(0.123456, ElectricChargeUnit.Coulomb).ToString("s2"));
                Assert.Equal("0.123 C", new ElectricCharge(0.123456, ElectricChargeUnit.Coulomb).ToString("s3"));
                Assert.Equal("0.1235 C", new ElectricCharge(0.123456, ElectricChargeUnit.Coulomb).ToString("s4"));
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
            Assert.Equal("0.1 C", new ElectricCharge(0.123456, ElectricChargeUnit.Coulomb).ToString("s1", culture));
            Assert.Equal("0.12 C", new ElectricCharge(0.123456, ElectricChargeUnit.Coulomb).ToString("s2", culture));
            Assert.Equal("0.123 C", new ElectricCharge(0.123456, ElectricChargeUnit.Coulomb).ToString("s3", culture));
            Assert.Equal("0.1235 C", new ElectricCharge(0.123456, ElectricChargeUnit.Coulomb).ToString("s4", culture));
        }


        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }


        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(ElectricCharge)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(ElectricChargeUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal(QuantityType.ElectricCharge, Convert.ChangeType(quantity, typeof(QuantityType)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal(ElectricCharge.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal(ElectricCharge.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = ElectricCharge.FromCoulombs(1.0);
            Assert.Equal(new {ElectricCharge.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = ElectricCharge.FromCoulombs(value);
            Assert.Equal(ElectricCharge.FromCoulombs(-value), -quantity);
        }
    }
}
