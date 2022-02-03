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
    /// Test of ElectricAdmittance.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricAdmittanceTestsBase : QuantityTestsBase
    {
        protected abstract double MicrosiemensInOneSiemens { get; }
        protected abstract double MillisiemensInOneSiemens { get; }
        protected abstract double NanosiemensInOneSiemens { get; }
        protected abstract double SiemensInOneSiemens { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double MicrosiemensTolerance { get { return 1e-5; } }
        protected virtual double MillisiemensTolerance { get { return 1e-5; } }
        protected virtual double NanosiemensTolerance { get { return 1e-5; } }
        protected virtual double SiemensTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { ElectricAdmittanceUnit.Microsiemens },
            new object[] { ElectricAdmittanceUnit.Millisiemens },
            new object[] { ElectricAdmittanceUnit.Nanosiemens },
            new object[] { ElectricAdmittanceUnit.Siemens },
        };

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricAdmittance((double)0.0, ElectricAdmittanceUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ElectricAdmittance();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ElectricAdmittanceUnit.Siemens, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricAdmittance(double.PositiveInfinity, ElectricAdmittanceUnit.Siemens));
            Assert.Throws<ArgumentException>(() => new ElectricAdmittance(double.NegativeInfinity, ElectricAdmittanceUnit.Siemens));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ElectricAdmittance(double.NaN, ElectricAdmittanceUnit.Siemens));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ElectricAdmittance(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new ElectricAdmittance(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (ElectricAdmittance) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void ElectricAdmittance_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ElectricAdmittance(1, ElectricAdmittanceUnit.Siemens);

            QuantityInfo<ElectricAdmittanceUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ElectricAdmittance.Zero, quantityInfo.Zero);
            Assert.Equal("ElectricAdmittance", quantityInfo.Name);
            Assert.Equal(QuantityType.ElectricAdmittance, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<ElectricAdmittanceUnit>().Except(new[] {ElectricAdmittanceUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
        }

        [Fact]
        public void SiemensToElectricAdmittanceUnits()
        {
            ElectricAdmittance siemens = ElectricAdmittance.FromSiemens(1);
            AssertEx.EqualTolerance(MicrosiemensInOneSiemens, siemens.Microsiemens, MicrosiemensTolerance);
            AssertEx.EqualTolerance(MillisiemensInOneSiemens, siemens.Millisiemens, MillisiemensTolerance);
            AssertEx.EqualTolerance(NanosiemensInOneSiemens, siemens.Nanosiemens, NanosiemensTolerance);
            AssertEx.EqualTolerance(SiemensInOneSiemens, siemens.Siemens, SiemensTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ElectricAdmittance.From(1, ElectricAdmittanceUnit.Microsiemens);
            AssertEx.EqualTolerance(1, quantity00.Microsiemens, MicrosiemensTolerance);
            Assert.Equal(ElectricAdmittanceUnit.Microsiemens, quantity00.Unit);

            var quantity01 = ElectricAdmittance.From(1, ElectricAdmittanceUnit.Millisiemens);
            AssertEx.EqualTolerance(1, quantity01.Millisiemens, MillisiemensTolerance);
            Assert.Equal(ElectricAdmittanceUnit.Millisiemens, quantity01.Unit);

            var quantity02 = ElectricAdmittance.From(1, ElectricAdmittanceUnit.Nanosiemens);
            AssertEx.EqualTolerance(1, quantity02.Nanosiemens, NanosiemensTolerance);
            Assert.Equal(ElectricAdmittanceUnit.Nanosiemens, quantity02.Unit);

            var quantity03 = ElectricAdmittance.From(1, ElectricAdmittanceUnit.Siemens);
            AssertEx.EqualTolerance(1, quantity03.Siemens, SiemensTolerance);
            Assert.Equal(ElectricAdmittanceUnit.Siemens, quantity03.Unit);

        }

        [Fact]
        public void FromSiemens_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricAdmittance.FromSiemens(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => ElectricAdmittance.FromSiemens(double.NegativeInfinity));
        }

        [Fact]
        public void FromSiemens_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ElectricAdmittance.FromSiemens(double.NaN));
        }

        [Fact]
        public void As()
        {
            var siemens = ElectricAdmittance.FromSiemens(1);
            AssertEx.EqualTolerance(MicrosiemensInOneSiemens, siemens.As(ElectricAdmittanceUnit.Microsiemens), MicrosiemensTolerance);
            AssertEx.EqualTolerance(MillisiemensInOneSiemens, siemens.As(ElectricAdmittanceUnit.Millisiemens), MillisiemensTolerance);
            AssertEx.EqualTolerance(NanosiemensInOneSiemens, siemens.As(ElectricAdmittanceUnit.Nanosiemens), NanosiemensTolerance);
            AssertEx.EqualTolerance(SiemensInOneSiemens, siemens.As(ElectricAdmittanceUnit.Siemens), SiemensTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new ElectricAdmittance(value: 1, unit: ElectricAdmittance.BaseUnit);
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
            var siemens = ElectricAdmittance.FromSiemens(1);

            var microsiemensQuantity = siemens.ToUnit(ElectricAdmittanceUnit.Microsiemens);
            AssertEx.EqualTolerance(MicrosiemensInOneSiemens, (double)microsiemensQuantity.Value, MicrosiemensTolerance);
            Assert.Equal(ElectricAdmittanceUnit.Microsiemens, microsiemensQuantity.Unit);

            var millisiemensQuantity = siemens.ToUnit(ElectricAdmittanceUnit.Millisiemens);
            AssertEx.EqualTolerance(MillisiemensInOneSiemens, (double)millisiemensQuantity.Value, MillisiemensTolerance);
            Assert.Equal(ElectricAdmittanceUnit.Millisiemens, millisiemensQuantity.Unit);

            var nanosiemensQuantity = siemens.ToUnit(ElectricAdmittanceUnit.Nanosiemens);
            AssertEx.EqualTolerance(NanosiemensInOneSiemens, (double)nanosiemensQuantity.Value, NanosiemensTolerance);
            Assert.Equal(ElectricAdmittanceUnit.Nanosiemens, nanosiemensQuantity.Unit);

            var siemensQuantity = siemens.ToUnit(ElectricAdmittanceUnit.Siemens);
            AssertEx.EqualTolerance(SiemensInOneSiemens, (double)siemensQuantity.Value, SiemensTolerance);
            Assert.Equal(ElectricAdmittanceUnit.Siemens, siemensQuantity.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(ElectricAdmittanceUnit unit)
        {
            var quantity = ElectricAdmittance.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_NoException(ElectricAdmittanceUnit unit)
        {
            var quantity = ElectricAdmittance.From(3.0, ElectricAdmittance.Units.First(unit => unit != ElectricAdmittance.BaseUnit));
            var converted = quantity.ToUnit(unit);
            // TODO: Meaningful check possible?
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ElectricAdmittance siemens = ElectricAdmittance.FromSiemens(1);
            AssertEx.EqualTolerance(1, ElectricAdmittance.FromMicrosiemens(siemens.Microsiemens).Siemens, MicrosiemensTolerance);
            AssertEx.EqualTolerance(1, ElectricAdmittance.FromMillisiemens(siemens.Millisiemens).Siemens, MillisiemensTolerance);
            AssertEx.EqualTolerance(1, ElectricAdmittance.FromNanosiemens(siemens.Nanosiemens).Siemens, NanosiemensTolerance);
            AssertEx.EqualTolerance(1, ElectricAdmittance.FromSiemens(siemens.Siemens).Siemens, SiemensTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ElectricAdmittance v = ElectricAdmittance.FromSiemens(1);
            AssertEx.EqualTolerance(-1, -v.Siemens, SiemensTolerance);
            AssertEx.EqualTolerance(2, (ElectricAdmittance.FromSiemens(3)-v).Siemens, SiemensTolerance);
            AssertEx.EqualTolerance(2, (v + v).Siemens, SiemensTolerance);
            AssertEx.EqualTolerance(10, (v*10).Siemens, SiemensTolerance);
            AssertEx.EqualTolerance(10, (10*v).Siemens, SiemensTolerance);
            AssertEx.EqualTolerance(2, (ElectricAdmittance.FromSiemens(10)/5).Siemens, SiemensTolerance);
            AssertEx.EqualTolerance(2, ElectricAdmittance.FromSiemens(10)/ElectricAdmittance.FromSiemens(5), SiemensTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ElectricAdmittance oneSiemens = ElectricAdmittance.FromSiemens(1);
            ElectricAdmittance twoSiemens = ElectricAdmittance.FromSiemens(2);

            Assert.True(oneSiemens < twoSiemens);
            Assert.True(oneSiemens <= twoSiemens);
            Assert.True(twoSiemens > oneSiemens);
            Assert.True(twoSiemens >= oneSiemens);

            Assert.False(oneSiemens > twoSiemens);
            Assert.False(oneSiemens >= twoSiemens);
            Assert.False(twoSiemens < oneSiemens);
            Assert.False(twoSiemens <= oneSiemens);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ElectricAdmittance siemens = ElectricAdmittance.FromSiemens(1);
            Assert.Equal(0, siemens.CompareTo(siemens));
            Assert.True(siemens.CompareTo(ElectricAdmittance.Zero) > 0);
            Assert.True(ElectricAdmittance.Zero.CompareTo(siemens) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricAdmittance siemens = ElectricAdmittance.FromSiemens(1);
            Assert.Throws<ArgumentException>(() => siemens.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ElectricAdmittance siemens = ElectricAdmittance.FromSiemens(1);
            Assert.Throws<ArgumentNullException>(() => siemens.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = ElectricAdmittance.FromSiemens(1);
            var b = ElectricAdmittance.FromSiemens(2);

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
            var a = ElectricAdmittance.FromSiemens(1);
            var b = ElectricAdmittance.FromSiemens(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = ElectricAdmittance.FromSiemens(1);
            object b = ElectricAdmittance.FromSiemens(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = ElectricAdmittance.FromSiemens(1);
            Assert.True(v.Equals(ElectricAdmittance.FromSiemens(1), SiemensTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ElectricAdmittance.Zero, SiemensTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = ElectricAdmittance.FromSiemens(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(ElectricAdmittance.FromSiemens(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricAdmittance siemens = ElectricAdmittance.FromSiemens(1);
            Assert.False(siemens.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricAdmittance siemens = ElectricAdmittance.FromSiemens(1);
            Assert.False(siemens.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(ElectricAdmittanceUnit.Undefined, ElectricAdmittance.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ElectricAdmittanceUnit)).Cast<ElectricAdmittanceUnit>();
            foreach(var unit in units)
            {
                if(unit == ElectricAdmittanceUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ElectricAdmittance.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 µS", new ElectricAdmittance(1, ElectricAdmittanceUnit.Microsiemens).ToString());
                Assert.Equal("1 mS", new ElectricAdmittance(1, ElectricAdmittanceUnit.Millisiemens).ToString());
                Assert.Equal("1 nS", new ElectricAdmittance(1, ElectricAdmittanceUnit.Nanosiemens).ToString());
                Assert.Equal("1 S", new ElectricAdmittance(1, ElectricAdmittanceUnit.Siemens).ToString());
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

            Assert.Equal("1 µS", new ElectricAdmittance(1, ElectricAdmittanceUnit.Microsiemens).ToString(swedishCulture));
            Assert.Equal("1 mS", new ElectricAdmittance(1, ElectricAdmittanceUnit.Millisiemens).ToString(swedishCulture));
            Assert.Equal("1 nS", new ElectricAdmittance(1, ElectricAdmittanceUnit.Nanosiemens).ToString(swedishCulture));
            Assert.Equal("1 S", new ElectricAdmittance(1, ElectricAdmittanceUnit.Siemens).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 S", new ElectricAdmittance(0.123456, ElectricAdmittanceUnit.Siemens).ToString("s1"));
                Assert.Equal("0.12 S", new ElectricAdmittance(0.123456, ElectricAdmittanceUnit.Siemens).ToString("s2"));
                Assert.Equal("0.123 S", new ElectricAdmittance(0.123456, ElectricAdmittanceUnit.Siemens).ToString("s3"));
                Assert.Equal("0.1235 S", new ElectricAdmittance(0.123456, ElectricAdmittanceUnit.Siemens).ToString("s4"));
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
            Assert.Equal("0.1 S", new ElectricAdmittance(0.123456, ElectricAdmittanceUnit.Siemens).ToString("s1", culture));
            Assert.Equal("0.12 S", new ElectricAdmittance(0.123456, ElectricAdmittanceUnit.Siemens).ToString("s2", culture));
            Assert.Equal("0.123 S", new ElectricAdmittance(0.123456, ElectricAdmittanceUnit.Siemens).ToString("s3", culture));
            Assert.Equal("0.1235 S", new ElectricAdmittance(0.123456, ElectricAdmittanceUnit.Siemens).ToString("s4", culture));
        }


        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }


        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(ElectricAdmittance)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(ElectricAdmittanceUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal(QuantityType.ElectricAdmittance, Convert.ChangeType(quantity, typeof(QuantityType)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal(ElectricAdmittance.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal(ElectricAdmittance.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = ElectricAdmittance.FromSiemens(1.0);
            Assert.Equal(new {ElectricAdmittance.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = ElectricAdmittance.FromSiemens(value);
            Assert.Equal(ElectricAdmittance.FromSiemens(-value), -quantity);
        }
    }
}
