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
    /// Test of TemperatureGradient.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class TemperatureGradientTestsBase : QuantityTestsBase
    {
        protected abstract double DegreesCelciusPerKilometerInOneKelvinPerMeter { get; }
        protected abstract double DegreesCelciusPerMeterInOneKelvinPerMeter { get; }
        protected abstract double DegreesFahrenheitPerFootInOneKelvinPerMeter { get; }
        protected abstract double KelvinsPerMeterInOneKelvinPerMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DegreesCelciusPerKilometerTolerance { get { return 1e-5; } }
        protected virtual double DegreesCelciusPerMeterTolerance { get { return 1e-5; } }
        protected virtual double DegreesFahrenheitPerFootTolerance { get { return 1e-5; } }
        protected virtual double KelvinsPerMeterTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(TemperatureGradientUnit unit)
        {
            return unit switch
            {
                TemperatureGradientUnit.DegreeCelsiusPerKilometer => (DegreesCelciusPerKilometerInOneKelvinPerMeter, DegreesCelciusPerKilometerTolerance),
                TemperatureGradientUnit.DegreeCelsiusPerMeter => (DegreesCelciusPerMeterInOneKelvinPerMeter, DegreesCelciusPerMeterTolerance),
                TemperatureGradientUnit.DegreeFahrenheitPerFoot => (DegreesFahrenheitPerFootInOneKelvinPerMeter, DegreesFahrenheitPerFootTolerance),
                TemperatureGradientUnit.KelvinPerMeter => (KelvinsPerMeterInOneKelvinPerMeter, KelvinsPerMeterTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { TemperatureGradientUnit.DegreeCelsiusPerKilometer },
            new object[] { TemperatureGradientUnit.DegreeCelsiusPerMeter },
            new object[] { TemperatureGradientUnit.DegreeFahrenheitPerFoot },
            new object[] { TemperatureGradientUnit.KelvinPerMeter },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new TemperatureGradient();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(TemperatureGradientUnit.KelvinPerMeter, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new TemperatureGradient(double.PositiveInfinity, TemperatureGradientUnit.KelvinPerMeter));
            Assert.Throws<ArgumentException>(() => new TemperatureGradient(double.NegativeInfinity, TemperatureGradientUnit.KelvinPerMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new TemperatureGradient(double.NaN, TemperatureGradientUnit.KelvinPerMeter));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new TemperatureGradient(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new TemperatureGradient(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (TemperatureGradient) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void TemperatureGradient_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new TemperatureGradient(1, TemperatureGradientUnit.KelvinPerMeter);

            QuantityInfo<TemperatureGradientUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(TemperatureGradient.Zero, quantityInfo.Zero);
            Assert.Equal("TemperatureGradient", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<TemperatureGradientUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void KelvinPerMeterToTemperatureGradientUnits()
        {
            TemperatureGradient kelvinpermeter = TemperatureGradient.FromKelvinsPerMeter(1);
            AssertEx.EqualTolerance(DegreesCelciusPerKilometerInOneKelvinPerMeter, kelvinpermeter.DegreesCelciusPerKilometer, DegreesCelciusPerKilometerTolerance);
            AssertEx.EqualTolerance(DegreesCelciusPerMeterInOneKelvinPerMeter, kelvinpermeter.DegreesCelciusPerMeter, DegreesCelciusPerMeterTolerance);
            AssertEx.EqualTolerance(DegreesFahrenheitPerFootInOneKelvinPerMeter, kelvinpermeter.DegreesFahrenheitPerFoot, DegreesFahrenheitPerFootTolerance);
            AssertEx.EqualTolerance(KelvinsPerMeterInOneKelvinPerMeter, kelvinpermeter.KelvinsPerMeter, KelvinsPerMeterTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = TemperatureGradient.From(1, TemperatureGradientUnit.DegreeCelsiusPerKilometer);
            AssertEx.EqualTolerance(1, quantity00.DegreesCelciusPerKilometer, DegreesCelciusPerKilometerTolerance);
            Assert.Equal(TemperatureGradientUnit.DegreeCelsiusPerKilometer, quantity00.Unit);

            var quantity01 = TemperatureGradient.From(1, TemperatureGradientUnit.DegreeCelsiusPerMeter);
            AssertEx.EqualTolerance(1, quantity01.DegreesCelciusPerMeter, DegreesCelciusPerMeterTolerance);
            Assert.Equal(TemperatureGradientUnit.DegreeCelsiusPerMeter, quantity01.Unit);

            var quantity02 = TemperatureGradient.From(1, TemperatureGradientUnit.DegreeFahrenheitPerFoot);
            AssertEx.EqualTolerance(1, quantity02.DegreesFahrenheitPerFoot, DegreesFahrenheitPerFootTolerance);
            Assert.Equal(TemperatureGradientUnit.DegreeFahrenheitPerFoot, quantity02.Unit);

            var quantity03 = TemperatureGradient.From(1, TemperatureGradientUnit.KelvinPerMeter);
            AssertEx.EqualTolerance(1, quantity03.KelvinsPerMeter, KelvinsPerMeterTolerance);
            Assert.Equal(TemperatureGradientUnit.KelvinPerMeter, quantity03.Unit);

        }

        [Fact]
        public void FromKelvinsPerMeter_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => TemperatureGradient.FromKelvinsPerMeter(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => TemperatureGradient.FromKelvinsPerMeter(double.NegativeInfinity));
        }

        [Fact]
        public void FromKelvinsPerMeter_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => TemperatureGradient.FromKelvinsPerMeter(double.NaN));
        }

        [Fact]
        public void As()
        {
            var kelvinpermeter = TemperatureGradient.FromKelvinsPerMeter(1);
            AssertEx.EqualTolerance(DegreesCelciusPerKilometerInOneKelvinPerMeter, kelvinpermeter.As(TemperatureGradientUnit.DegreeCelsiusPerKilometer), DegreesCelciusPerKilometerTolerance);
            AssertEx.EqualTolerance(DegreesCelciusPerMeterInOneKelvinPerMeter, kelvinpermeter.As(TemperatureGradientUnit.DegreeCelsiusPerMeter), DegreesCelciusPerMeterTolerance);
            AssertEx.EqualTolerance(DegreesFahrenheitPerFootInOneKelvinPerMeter, kelvinpermeter.As(TemperatureGradientUnit.DegreeFahrenheitPerFoot), DegreesFahrenheitPerFootTolerance);
            AssertEx.EqualTolerance(KelvinsPerMeterInOneKelvinPerMeter, kelvinpermeter.As(TemperatureGradientUnit.KelvinPerMeter), KelvinsPerMeterTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new TemperatureGradient(value: 1, unit: TemperatureGradient.BaseUnit);
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
                var parsed = TemperatureGradient.Parse("1 ∆°C/km", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.DegreesCelciusPerKilometer, DegreesCelciusPerKilometerTolerance);
                Assert.Equal(TemperatureGradientUnit.DegreeCelsiusPerKilometer, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = TemperatureGradient.Parse("1 ∆°C/m", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.DegreesCelciusPerMeter, DegreesCelciusPerMeterTolerance);
                Assert.Equal(TemperatureGradientUnit.DegreeCelsiusPerMeter, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = TemperatureGradient.Parse("1 ∆°F/ft", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.DegreesFahrenheitPerFoot, DegreesFahrenheitPerFootTolerance);
                Assert.Equal(TemperatureGradientUnit.DegreeFahrenheitPerFoot, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = TemperatureGradient.Parse("1 ∆°K/m", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.KelvinsPerMeter, KelvinsPerMeterTolerance);
                Assert.Equal(TemperatureGradientUnit.KelvinPerMeter, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(TemperatureGradient.TryParse("1 ∆°C/km", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.DegreesCelciusPerKilometer, DegreesCelciusPerKilometerTolerance);
                Assert.Equal(TemperatureGradientUnit.DegreeCelsiusPerKilometer, parsed.Unit);
            }

            {
                Assert.True(TemperatureGradient.TryParse("1 ∆°C/m", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.DegreesCelciusPerMeter, DegreesCelciusPerMeterTolerance);
                Assert.Equal(TemperatureGradientUnit.DegreeCelsiusPerMeter, parsed.Unit);
            }

            {
                Assert.True(TemperatureGradient.TryParse("1 ∆°F/ft", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.DegreesFahrenheitPerFoot, DegreesFahrenheitPerFootTolerance);
                Assert.Equal(TemperatureGradientUnit.DegreeFahrenheitPerFoot, parsed.Unit);
            }

            {
                Assert.True(TemperatureGradient.TryParse("1 ∆°K/m", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.KelvinsPerMeter, KelvinsPerMeterTolerance);
                Assert.Equal(TemperatureGradientUnit.KelvinPerMeter, parsed.Unit);
            }

        }

        [Fact]
        public void ParseUnit()
        {
            try
            {
                var parsedUnit = TemperatureGradient.ParseUnit("∆°C/km", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(TemperatureGradientUnit.DegreeCelsiusPerKilometer, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = TemperatureGradient.ParseUnit("∆°C/m", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(TemperatureGradientUnit.DegreeCelsiusPerMeter, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = TemperatureGradient.ParseUnit("∆°F/ft", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(TemperatureGradientUnit.DegreeFahrenheitPerFoot, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = TemperatureGradient.ParseUnit("∆°K/m", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(TemperatureGradientUnit.KelvinPerMeter, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParseUnit()
        {
            {
                Assert.True(TemperatureGradient.TryParseUnit("∆°C/km", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(TemperatureGradientUnit.DegreeCelsiusPerKilometer, parsedUnit);
            }

            {
                Assert.True(TemperatureGradient.TryParseUnit("∆°C/m", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(TemperatureGradientUnit.DegreeCelsiusPerMeter, parsedUnit);
            }

            {
                Assert.True(TemperatureGradient.TryParseUnit("∆°F/ft", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(TemperatureGradientUnit.DegreeFahrenheitPerFoot, parsedUnit);
            }

            {
                Assert.True(TemperatureGradient.TryParseUnit("∆°K/m", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(TemperatureGradientUnit.KelvinPerMeter, parsedUnit);
            }

        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(TemperatureGradientUnit unit)
        {
            var inBaseUnits = TemperatureGradient.From(1.0, TemperatureGradient.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(TemperatureGradientUnit unit)
        {
            var quantity = TemperatureGradient.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(TemperatureGradientUnit unit)
        {
            // See if there is a unit available that is not the base unit, fallback to base unit if it has only a single unit.
            var fromUnit = TemperatureGradient.Units.First(u => u != TemperatureGradient.BaseUnit);

            var quantity = TemperatureGradient.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(TemperatureGradientUnit unit)
        {
            var quantity = default(TemperatureGradient);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            TemperatureGradient kelvinpermeter = TemperatureGradient.FromKelvinsPerMeter(1);
            AssertEx.EqualTolerance(1, TemperatureGradient.FromDegreesCelciusPerKilometer(kelvinpermeter.DegreesCelciusPerKilometer).KelvinsPerMeter, DegreesCelciusPerKilometerTolerance);
            AssertEx.EqualTolerance(1, TemperatureGradient.FromDegreesCelciusPerMeter(kelvinpermeter.DegreesCelciusPerMeter).KelvinsPerMeter, DegreesCelciusPerMeterTolerance);
            AssertEx.EqualTolerance(1, TemperatureGradient.FromDegreesFahrenheitPerFoot(kelvinpermeter.DegreesFahrenheitPerFoot).KelvinsPerMeter, DegreesFahrenheitPerFootTolerance);
            AssertEx.EqualTolerance(1, TemperatureGradient.FromKelvinsPerMeter(kelvinpermeter.KelvinsPerMeter).KelvinsPerMeter, KelvinsPerMeterTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            TemperatureGradient v = TemperatureGradient.FromKelvinsPerMeter(1);
            AssertEx.EqualTolerance(-1, -v.KelvinsPerMeter, KelvinsPerMeterTolerance);
            AssertEx.EqualTolerance(2, (TemperatureGradient.FromKelvinsPerMeter(3)-v).KelvinsPerMeter, KelvinsPerMeterTolerance);
            AssertEx.EqualTolerance(2, (v + v).KelvinsPerMeter, KelvinsPerMeterTolerance);
            AssertEx.EqualTolerance(10, (v*10).KelvinsPerMeter, KelvinsPerMeterTolerance);
            AssertEx.EqualTolerance(10, (10*v).KelvinsPerMeter, KelvinsPerMeterTolerance);
            AssertEx.EqualTolerance(2, (TemperatureGradient.FromKelvinsPerMeter(10)/5).KelvinsPerMeter, KelvinsPerMeterTolerance);
            AssertEx.EqualTolerance(2, TemperatureGradient.FromKelvinsPerMeter(10)/TemperatureGradient.FromKelvinsPerMeter(5), KelvinsPerMeterTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            TemperatureGradient oneKelvinPerMeter = TemperatureGradient.FromKelvinsPerMeter(1);
            TemperatureGradient twoKelvinsPerMeter = TemperatureGradient.FromKelvinsPerMeter(2);

            Assert.True(oneKelvinPerMeter < twoKelvinsPerMeter);
            Assert.True(oneKelvinPerMeter <= twoKelvinsPerMeter);
            Assert.True(twoKelvinsPerMeter > oneKelvinPerMeter);
            Assert.True(twoKelvinsPerMeter >= oneKelvinPerMeter);

            Assert.False(oneKelvinPerMeter > twoKelvinsPerMeter);
            Assert.False(oneKelvinPerMeter >= twoKelvinsPerMeter);
            Assert.False(twoKelvinsPerMeter < oneKelvinPerMeter);
            Assert.False(twoKelvinsPerMeter <= oneKelvinPerMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            TemperatureGradient kelvinpermeter = TemperatureGradient.FromKelvinsPerMeter(1);
            Assert.Equal(0, kelvinpermeter.CompareTo(kelvinpermeter));
            Assert.True(kelvinpermeter.CompareTo(TemperatureGradient.Zero) > 0);
            Assert.True(TemperatureGradient.Zero.CompareTo(kelvinpermeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            TemperatureGradient kelvinpermeter = TemperatureGradient.FromKelvinsPerMeter(1);
            Assert.Throws<ArgumentException>(() => kelvinpermeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            TemperatureGradient kelvinpermeter = TemperatureGradient.FromKelvinsPerMeter(1);
            Assert.Throws<ArgumentNullException>(() => kelvinpermeter.CompareTo(null));
        }

        [Theory]
        [InlineData(1, TemperatureGradientUnit.KelvinPerMeter, 1, TemperatureGradientUnit.KelvinPerMeter, true)]  // Same value and unit.
        [InlineData(1, TemperatureGradientUnit.KelvinPerMeter, 2, TemperatureGradientUnit.KelvinPerMeter, false)] // Different value.
        [InlineData(2, TemperatureGradientUnit.KelvinPerMeter, 1, TemperatureGradientUnit.DegreeCelsiusPerKilometer, false)] // Different value and unit.
        [InlineData(1, TemperatureGradientUnit.KelvinPerMeter, 1, TemperatureGradientUnit.DegreeCelsiusPerKilometer, false)] // Different unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, TemperatureGradientUnit unitA, double valueB, TemperatureGradientUnit unitB, bool expectEqual)
        {
            var a = new TemperatureGradient(valueA, unitA);
            var b = new TemperatureGradient(valueB, unitB);

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
            var a = TemperatureGradient.Zero;

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
            var v = TemperatureGradient.FromKelvinsPerMeter(1);
            Assert.True(v.Equals(TemperatureGradient.FromKelvinsPerMeter(1), KelvinsPerMeterTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(TemperatureGradient.Zero, KelvinsPerMeterTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = TemperatureGradient.FromKelvinsPerMeter(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(TemperatureGradient.FromKelvinsPerMeter(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            TemperatureGradient kelvinpermeter = TemperatureGradient.FromKelvinsPerMeter(1);
            Assert.False(kelvinpermeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            TemperatureGradient kelvinpermeter = TemperatureGradient.FromKelvinsPerMeter(1);
            Assert.False(kelvinpermeter.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(TemperatureGradientUnit)).Cast<TemperatureGradientUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(TemperatureGradient.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 ∆°C/km", new TemperatureGradient(1, TemperatureGradientUnit.DegreeCelsiusPerKilometer).ToString());
                Assert.Equal("1 ∆°C/m", new TemperatureGradient(1, TemperatureGradientUnit.DegreeCelsiusPerMeter).ToString());
                Assert.Equal("1 ∆°F/ft", new TemperatureGradient(1, TemperatureGradientUnit.DegreeFahrenheitPerFoot).ToString());
                Assert.Equal("1 ∆°K/m", new TemperatureGradient(1, TemperatureGradientUnit.KelvinPerMeter).ToString());
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

            Assert.Equal("1 ∆°C/km", new TemperatureGradient(1, TemperatureGradientUnit.DegreeCelsiusPerKilometer).ToString(swedishCulture));
            Assert.Equal("1 ∆°C/m", new TemperatureGradient(1, TemperatureGradientUnit.DegreeCelsiusPerMeter).ToString(swedishCulture));
            Assert.Equal("1 ∆°F/ft", new TemperatureGradient(1, TemperatureGradientUnit.DegreeFahrenheitPerFoot).ToString(swedishCulture));
            Assert.Equal("1 ∆°K/m", new TemperatureGradient(1, TemperatureGradientUnit.KelvinPerMeter).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentCulture;
            try
            {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 ∆°K/m", new TemperatureGradient(0.123456, TemperatureGradientUnit.KelvinPerMeter).ToString("s1"));
                Assert.Equal("0.12 ∆°K/m", new TemperatureGradient(0.123456, TemperatureGradientUnit.KelvinPerMeter).ToString("s2"));
                Assert.Equal("0.123 ∆°K/m", new TemperatureGradient(0.123456, TemperatureGradientUnit.KelvinPerMeter).ToString("s3"));
                Assert.Equal("0.1235 ∆°K/m", new TemperatureGradient(0.123456, TemperatureGradientUnit.KelvinPerMeter).ToString("s4"));
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
            Assert.Equal("0.1 ∆°K/m", new TemperatureGradient(0.123456, TemperatureGradientUnit.KelvinPerMeter).ToString("s1", culture));
            Assert.Equal("0.12 ∆°K/m", new TemperatureGradient(0.123456, TemperatureGradientUnit.KelvinPerMeter).ToString("s2", culture));
            Assert.Equal("0.123 ∆°K/m", new TemperatureGradient(0.123456, TemperatureGradientUnit.KelvinPerMeter).ToString("s3", culture));
            Assert.Equal("0.1235 ∆°K/m", new TemperatureGradient(0.123456, TemperatureGradientUnit.KelvinPerMeter).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
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
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(TemperatureGradient)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(TemperatureGradientUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal(TemperatureGradient.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal(TemperatureGradient.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(1.0);
            Assert.Equal(new {TemperatureGradient.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = TemperatureGradient.FromKelvinsPerMeter(value);
            Assert.Equal(TemperatureGradient.FromKelvinsPerMeter(-value), -quantity);
        }
    }
}
