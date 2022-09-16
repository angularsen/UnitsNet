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
using OasysUnitsNet.Tests.TestsBase;
using OasysUnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace OasysUnitsNet.Tests
{
    /// <summary>
    /// Test of AmplitudeRatio.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class AmplitudeRatioTestsBase : QuantityTestsBase
    {
        protected abstract double DecibelMicrovoltsInOneDecibelVolt { get; }
        protected abstract double DecibelMillivoltsInOneDecibelVolt { get; }
        protected abstract double DecibelsUnloadedInOneDecibelVolt { get; }
        protected abstract double DecibelVoltsInOneDecibelVolt { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DecibelMicrovoltsTolerance { get { return 1e-5; } }
        protected virtual double DecibelMillivoltsTolerance { get { return 1e-5; } }
        protected virtual double DecibelsUnloadedTolerance { get { return 1e-5; } }
        protected virtual double DecibelVoltsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(AmplitudeRatioUnit unit)
        {
            return unit switch
            {
                AmplitudeRatioUnit.DecibelMicrovolt => (DecibelMicrovoltsInOneDecibelVolt, DecibelMicrovoltsTolerance),
                AmplitudeRatioUnit.DecibelMillivolt => (DecibelMillivoltsInOneDecibelVolt, DecibelMillivoltsTolerance),
                AmplitudeRatioUnit.DecibelUnloaded => (DecibelsUnloadedInOneDecibelVolt, DecibelsUnloadedTolerance),
                AmplitudeRatioUnit.DecibelVolt => (DecibelVoltsInOneDecibelVolt, DecibelVoltsTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { AmplitudeRatioUnit.DecibelMicrovolt },
            new object[] { AmplitudeRatioUnit.DecibelMillivolt },
            new object[] { AmplitudeRatioUnit.DecibelUnloaded },
            new object[] { AmplitudeRatioUnit.DecibelVolt },
        };

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new AmplitudeRatio((double)0.0, AmplitudeRatioUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new AmplitudeRatio();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(AmplitudeRatioUnit.DecibelVolt, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new AmplitudeRatio(double.PositiveInfinity, AmplitudeRatioUnit.DecibelVolt));
            Assert.Throws<ArgumentException>(() => new AmplitudeRatio(double.NegativeInfinity, AmplitudeRatioUnit.DecibelVolt));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new AmplitudeRatio(double.NaN, AmplitudeRatioUnit.DecibelVolt));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AmplitudeRatio(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new AmplitudeRatio(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (AmplitudeRatio) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void AmplitudeRatio_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new AmplitudeRatio(1, AmplitudeRatioUnit.DecibelVolt);

            QuantityInfo<AmplitudeRatioUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(AmplitudeRatio.Zero, quantityInfo.Zero);
            Assert.Equal("AmplitudeRatio", quantityInfo.Name);
            Assert.Equal(QuantityType.AmplitudeRatio, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<AmplitudeRatioUnit>().Except(new[] {AmplitudeRatioUnit.Undefined}).OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
        }

        [Fact]
        public void DecibelVoltToAmplitudeRatioUnits()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            AssertEx.EqualTolerance(DecibelMicrovoltsInOneDecibelVolt, decibelvolt.DecibelMicrovolts, DecibelMicrovoltsTolerance);
            AssertEx.EqualTolerance(DecibelMillivoltsInOneDecibelVolt, decibelvolt.DecibelMillivolts, DecibelMillivoltsTolerance);
            AssertEx.EqualTolerance(DecibelsUnloadedInOneDecibelVolt, decibelvolt.DecibelsUnloaded, DecibelsUnloadedTolerance);
            AssertEx.EqualTolerance(DecibelVoltsInOneDecibelVolt, decibelvolt.DecibelVolts, DecibelVoltsTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = AmplitudeRatio.From(1, AmplitudeRatioUnit.DecibelMicrovolt);
            AssertEx.EqualTolerance(1, quantity00.DecibelMicrovolts, DecibelMicrovoltsTolerance);
            Assert.Equal(AmplitudeRatioUnit.DecibelMicrovolt, quantity00.Unit);

            var quantity01 = AmplitudeRatio.From(1, AmplitudeRatioUnit.DecibelMillivolt);
            AssertEx.EqualTolerance(1, quantity01.DecibelMillivolts, DecibelMillivoltsTolerance);
            Assert.Equal(AmplitudeRatioUnit.DecibelMillivolt, quantity01.Unit);

            var quantity02 = AmplitudeRatio.From(1, AmplitudeRatioUnit.DecibelUnloaded);
            AssertEx.EqualTolerance(1, quantity02.DecibelsUnloaded, DecibelsUnloadedTolerance);
            Assert.Equal(AmplitudeRatioUnit.DecibelUnloaded, quantity02.Unit);

            var quantity03 = AmplitudeRatio.From(1, AmplitudeRatioUnit.DecibelVolt);
            AssertEx.EqualTolerance(1, quantity03.DecibelVolts, DecibelVoltsTolerance);
            Assert.Equal(AmplitudeRatioUnit.DecibelVolt, quantity03.Unit);

        }

        [Fact]
        public void FromDecibelVolts_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => AmplitudeRatio.FromDecibelVolts(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => AmplitudeRatio.FromDecibelVolts(double.NegativeInfinity));
        }

        [Fact]
        public void FromDecibelVolts_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => AmplitudeRatio.FromDecibelVolts(double.NaN));
        }

        [Fact]
        public void As()
        {
            var decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            AssertEx.EqualTolerance(DecibelMicrovoltsInOneDecibelVolt, decibelvolt.As(AmplitudeRatioUnit.DecibelMicrovolt), DecibelMicrovoltsTolerance);
            AssertEx.EqualTolerance(DecibelMillivoltsInOneDecibelVolt, decibelvolt.As(AmplitudeRatioUnit.DecibelMillivolt), DecibelMillivoltsTolerance);
            AssertEx.EqualTolerance(DecibelsUnloadedInOneDecibelVolt, decibelvolt.As(AmplitudeRatioUnit.DecibelUnloaded), DecibelsUnloadedTolerance);
            AssertEx.EqualTolerance(DecibelVoltsInOneDecibelVolt, decibelvolt.As(AmplitudeRatioUnit.DecibelVolt), DecibelVoltsTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new AmplitudeRatio(value: 1, unit: AmplitudeRatio.BaseUnit);
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
                var parsed = AmplitudeRatio.Parse("1 dBµV", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.DecibelMicrovolts, DecibelMicrovoltsTolerance);
                Assert.Equal(AmplitudeRatioUnit.DecibelMicrovolt, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = AmplitudeRatio.Parse("1 dBmV", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.DecibelMillivolts, DecibelMillivoltsTolerance);
                Assert.Equal(AmplitudeRatioUnit.DecibelMillivolt, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = AmplitudeRatio.Parse("1 dBu", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.DecibelsUnloaded, DecibelsUnloadedTolerance);
                Assert.Equal(AmplitudeRatioUnit.DecibelUnloaded, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = AmplitudeRatio.Parse("1 dBV", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.DecibelVolts, DecibelVoltsTolerance);
                Assert.Equal(AmplitudeRatioUnit.DecibelVolt, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(AmplitudeRatio.TryParse("1 dBµV", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.DecibelMicrovolts, DecibelMicrovoltsTolerance);
                Assert.Equal(AmplitudeRatioUnit.DecibelMicrovolt, parsed.Unit);
            }

            {
                Assert.True(AmplitudeRatio.TryParse("1 dBmV", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.DecibelMillivolts, DecibelMillivoltsTolerance);
                Assert.Equal(AmplitudeRatioUnit.DecibelMillivolt, parsed.Unit);
            }

            {
                Assert.True(AmplitudeRatio.TryParse("1 dBu", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.DecibelsUnloaded, DecibelsUnloadedTolerance);
                Assert.Equal(AmplitudeRatioUnit.DecibelUnloaded, parsed.Unit);
            }

            {
                Assert.True(AmplitudeRatio.TryParse("1 dBV", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.DecibelVolts, DecibelVoltsTolerance);
                Assert.Equal(AmplitudeRatioUnit.DecibelVolt, parsed.Unit);
            }

        }

        [Fact]
        public void ParseUnit()
        {
            try
            {
                var parsedUnit = AmplitudeRatio.ParseUnit("dBµV", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(AmplitudeRatioUnit.DecibelMicrovolt, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = AmplitudeRatio.ParseUnit("dBmV", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(AmplitudeRatioUnit.DecibelMillivolt, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = AmplitudeRatio.ParseUnit("dBu", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(AmplitudeRatioUnit.DecibelUnloaded, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = AmplitudeRatio.ParseUnit("dBV", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(AmplitudeRatioUnit.DecibelVolt, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParseUnit()
        {
            {
                Assert.True(AmplitudeRatio.TryParseUnit("dBµV", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(AmplitudeRatioUnit.DecibelMicrovolt, parsedUnit);
            }

            {
                Assert.True(AmplitudeRatio.TryParseUnit("dBmV", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(AmplitudeRatioUnit.DecibelMillivolt, parsedUnit);
            }

            {
                Assert.True(AmplitudeRatio.TryParseUnit("dBu", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(AmplitudeRatioUnit.DecibelUnloaded, parsedUnit);
            }

            {
                Assert.True(AmplitudeRatio.TryParseUnit("dBV", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(AmplitudeRatioUnit.DecibelVolt, parsedUnit);
            }

        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(AmplitudeRatioUnit unit)
        {
            var inBaseUnits = AmplitudeRatio.From(1.0, AmplitudeRatio.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, (double)converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(AmplitudeRatioUnit unit)
        {
            var quantity = AmplitudeRatio.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(AmplitudeRatioUnit unit)
        {
            // See if there is a unit available that is not the base unit.
            var fromUnit = AmplitudeRatio.Units.FirstOrDefault(u => u != AmplitudeRatio.BaseUnit && u != AmplitudeRatioUnit.Undefined);

            // If there is only one unit for the quantity, we must use the base unit.
            if (fromUnit == AmplitudeRatioUnit.Undefined)
                fromUnit = AmplitudeRatio.BaseUnit;

            var quantity = AmplitudeRatio.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(AmplitudeRatioUnit unit)
        {
            var quantity = default(AmplitudeRatio);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            AssertEx.EqualTolerance(1, AmplitudeRatio.FromDecibelMicrovolts(decibelvolt.DecibelMicrovolts).DecibelVolts, DecibelMicrovoltsTolerance);
            AssertEx.EqualTolerance(1, AmplitudeRatio.FromDecibelMillivolts(decibelvolt.DecibelMillivolts).DecibelVolts, DecibelMillivoltsTolerance);
            AssertEx.EqualTolerance(1, AmplitudeRatio.FromDecibelsUnloaded(decibelvolt.DecibelsUnloaded).DecibelVolts, DecibelsUnloadedTolerance);
            AssertEx.EqualTolerance(1, AmplitudeRatio.FromDecibelVolts(decibelvolt.DecibelVolts).DecibelVolts, DecibelVoltsTolerance);
        }

        [Fact]
        public void LogarithmicArithmeticOperators()
        {
            AmplitudeRatio v = AmplitudeRatio.FromDecibelVolts(40);
            AssertEx.EqualTolerance(-40, -v.DecibelVolts, DecibelVoltsTolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            AssertEx.EqualTolerance(50, (v*10).DecibelVolts, DecibelVoltsTolerance);
            AssertEx.EqualTolerance(50, (10*v).DecibelVolts, DecibelVoltsTolerance);
            AssertEx.EqualTolerance(35, (v/5).DecibelVolts, DecibelVoltsTolerance);
            AssertEx.EqualTolerance(35, v/AmplitudeRatio.FromDecibelVolts(5), DecibelVoltsTolerance);
        }

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();

        [Fact]
        public void ComparisonOperators()
        {
            AmplitudeRatio oneDecibelVolt = AmplitudeRatio.FromDecibelVolts(1);
            AmplitudeRatio twoDecibelVolts = AmplitudeRatio.FromDecibelVolts(2);

            Assert.True(oneDecibelVolt < twoDecibelVolts);
            Assert.True(oneDecibelVolt <= twoDecibelVolts);
            Assert.True(twoDecibelVolts > oneDecibelVolt);
            Assert.True(twoDecibelVolts >= oneDecibelVolt);

            Assert.False(oneDecibelVolt > twoDecibelVolts);
            Assert.False(oneDecibelVolt >= twoDecibelVolts);
            Assert.False(twoDecibelVolts < oneDecibelVolt);
            Assert.False(twoDecibelVolts <= oneDecibelVolt);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.Equal(0, decibelvolt.CompareTo(decibelvolt));
            Assert.True(decibelvolt.CompareTo(AmplitudeRatio.Zero) > 0);
            Assert.True(AmplitudeRatio.Zero.CompareTo(decibelvolt) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.Throws<ArgumentException>(() => decibelvolt.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.Throws<ArgumentNullException>(() => decibelvolt.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = AmplitudeRatio.FromDecibelVolts(1);
            var b = AmplitudeRatio.FromDecibelVolts(2);

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
            var a = AmplitudeRatio.FromDecibelVolts(1);
            var b = AmplitudeRatio.FromDecibelVolts(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = AmplitudeRatio.FromDecibelVolts(1);
            object b = AmplitudeRatio.FromDecibelVolts(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = AmplitudeRatio.FromDecibelVolts(1);
            Assert.True(v.Equals(AmplitudeRatio.FromDecibelVolts(1), DecibelVoltsTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(AmplitudeRatio.Zero, DecibelVoltsTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = AmplitudeRatio.FromDecibelVolts(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(AmplitudeRatio.FromDecibelVolts(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.False(decibelvolt.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.False(decibelvolt.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(AmplitudeRatioUnit.Undefined, AmplitudeRatio.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(AmplitudeRatioUnit)).Cast<AmplitudeRatioUnit>();
            foreach(var unit in units)
            {
                if (unit == AmplitudeRatioUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(AmplitudeRatio.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 dBµV", new AmplitudeRatio(1, AmplitudeRatioUnit.DecibelMicrovolt).ToString());
                Assert.Equal("1 dBmV", new AmplitudeRatio(1, AmplitudeRatioUnit.DecibelMillivolt).ToString());
                Assert.Equal("1 dBu", new AmplitudeRatio(1, AmplitudeRatioUnit.DecibelUnloaded).ToString());
                Assert.Equal("1 dBV", new AmplitudeRatio(1, AmplitudeRatioUnit.DecibelVolt).ToString());
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

            Assert.Equal("1 dBµV", new AmplitudeRatio(1, AmplitudeRatioUnit.DecibelMicrovolt).ToString(swedishCulture));
            Assert.Equal("1 dBmV", new AmplitudeRatio(1, AmplitudeRatioUnit.DecibelMillivolt).ToString(swedishCulture));
            Assert.Equal("1 dBu", new AmplitudeRatio(1, AmplitudeRatioUnit.DecibelUnloaded).ToString(swedishCulture));
            Assert.Equal("1 dBV", new AmplitudeRatio(1, AmplitudeRatioUnit.DecibelVolt).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 dBV", new AmplitudeRatio(0.123456, AmplitudeRatioUnit.DecibelVolt).ToString("s1"));
                Assert.Equal("0.12 dBV", new AmplitudeRatio(0.123456, AmplitudeRatioUnit.DecibelVolt).ToString("s2"));
                Assert.Equal("0.123 dBV", new AmplitudeRatio(0.123456, AmplitudeRatioUnit.DecibelVolt).ToString("s3"));
                Assert.Equal("0.1235 dBV", new AmplitudeRatio(0.123456, AmplitudeRatioUnit.DecibelVolt).ToString("s4"));
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
            Assert.Equal("0.1 dBV", new AmplitudeRatio(0.123456, AmplitudeRatioUnit.DecibelVolt).ToString("s1", culture));
            Assert.Equal("0.12 dBV", new AmplitudeRatio(0.123456, AmplitudeRatioUnit.DecibelVolt).ToString("s2", culture));
            Assert.Equal("0.123 dBV", new AmplitudeRatio(0.123456, AmplitudeRatioUnit.DecibelVolt).ToString("s3", culture));
            Assert.Equal("0.1235 dBV", new AmplitudeRatio(0.123456, AmplitudeRatioUnit.DecibelVolt).ToString("s4", culture));
        }


        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }


        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(AmplitudeRatio)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(AmplitudeRatioUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal(QuantityType.AmplitudeRatio, Convert.ChangeType(quantity, typeof(QuantityType)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal(AmplitudeRatio.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal(AmplitudeRatio.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(1.0);
            Assert.Equal(new {AmplitudeRatio.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = AmplitudeRatio.FromDecibelVolts(value);
            Assert.Equal(AmplitudeRatio.FromDecibelVolts(-value), -quantity);
        }
    }
}
