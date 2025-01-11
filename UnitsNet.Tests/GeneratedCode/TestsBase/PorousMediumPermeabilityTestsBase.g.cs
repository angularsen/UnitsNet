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
using UnitsNet.Tests.Helpers;
using UnitsNet.Tests.TestsBase;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of PorousMediumPermeability.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class PorousMediumPermeabilityTestsBase : QuantityTestsBase
    {
        protected abstract double DarcysInOneSquareMeter { get; }
        protected abstract double MicrodarcysInOneSquareMeter { get; }
        protected abstract double MillidarcysInOneSquareMeter { get; }
        protected abstract double SquareCentimetersInOneSquareMeter { get; }
        protected abstract double SquareMetersInOneSquareMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DarcysTolerance { get { return 1e-5; } }
        protected virtual double MicrodarcysTolerance { get { return 1e-5; } }
        protected virtual double MillidarcysTolerance { get { return 1e-5; } }
        protected virtual double SquareCentimetersTolerance { get { return 1e-5; } }
        protected virtual double SquareMetersTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(PorousMediumPermeabilityUnit unit)
        {
            return unit switch
            {
                PorousMediumPermeabilityUnit.Darcy => (DarcysInOneSquareMeter, DarcysTolerance),
                PorousMediumPermeabilityUnit.Microdarcy => (MicrodarcysInOneSquareMeter, MicrodarcysTolerance),
                PorousMediumPermeabilityUnit.Millidarcy => (MillidarcysInOneSquareMeter, MillidarcysTolerance),
                PorousMediumPermeabilityUnit.SquareCentimeter => (SquareCentimetersInOneSquareMeter, SquareCentimetersTolerance),
                PorousMediumPermeabilityUnit.SquareMeter => (SquareMetersInOneSquareMeter, SquareMetersTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { PorousMediumPermeabilityUnit.Darcy },
            new object[] { PorousMediumPermeabilityUnit.Microdarcy },
            new object[] { PorousMediumPermeabilityUnit.Millidarcy },
            new object[] { PorousMediumPermeabilityUnit.SquareCentimeter },
            new object[] { PorousMediumPermeabilityUnit.SquareMeter },
        };

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new PorousMediumPermeability();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(PorousMediumPermeabilityUnit.SquareMeter, quantity.Unit);
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PorousMediumPermeability(double.PositiveInfinity, PorousMediumPermeabilityUnit.SquareMeter));
            Assert.Throws<ArgumentException>(() => new PorousMediumPermeability(double.NegativeInfinity, PorousMediumPermeabilityUnit.SquareMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PorousMediumPermeability(double.NaN, PorousMediumPermeabilityUnit.SquareMeter));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new PorousMediumPermeability(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new PorousMediumPermeability(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (PorousMediumPermeability) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void PorousMediumPermeability_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.SquareMeter);

            QuantityInfo<PorousMediumPermeabilityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(PorousMediumPermeability.Zero, quantityInfo.Zero);
            Assert.Equal("PorousMediumPermeability", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<PorousMediumPermeabilityUnit>().OrderBy(x => x.ToString()).ToArray();
            var unitNames = units.Select(x => x.ToString());
        }

        [Fact]
        public void SquareMeterToPorousMediumPermeabilityUnits()
        {
            PorousMediumPermeability squaremeter = PorousMediumPermeability.FromSquareMeters(1);
            AssertEx.EqualTolerance(DarcysInOneSquareMeter, squaremeter.Darcys, DarcysTolerance);
            AssertEx.EqualTolerance(MicrodarcysInOneSquareMeter, squaremeter.Microdarcys, MicrodarcysTolerance);
            AssertEx.EqualTolerance(MillidarcysInOneSquareMeter, squaremeter.Millidarcys, MillidarcysTolerance);
            AssertEx.EqualTolerance(SquareCentimetersInOneSquareMeter, squaremeter.SquareCentimeters, SquareCentimetersTolerance);
            AssertEx.EqualTolerance(SquareMetersInOneSquareMeter, squaremeter.SquareMeters, SquareMetersTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = PorousMediumPermeability.From(1, PorousMediumPermeabilityUnit.Darcy);
            AssertEx.EqualTolerance(1, quantity00.Darcys, DarcysTolerance);
            Assert.Equal(PorousMediumPermeabilityUnit.Darcy, quantity00.Unit);

            var quantity01 = PorousMediumPermeability.From(1, PorousMediumPermeabilityUnit.Microdarcy);
            AssertEx.EqualTolerance(1, quantity01.Microdarcys, MicrodarcysTolerance);
            Assert.Equal(PorousMediumPermeabilityUnit.Microdarcy, quantity01.Unit);

            var quantity02 = PorousMediumPermeability.From(1, PorousMediumPermeabilityUnit.Millidarcy);
            AssertEx.EqualTolerance(1, quantity02.Millidarcys, MillidarcysTolerance);
            Assert.Equal(PorousMediumPermeabilityUnit.Millidarcy, quantity02.Unit);

            var quantity03 = PorousMediumPermeability.From(1, PorousMediumPermeabilityUnit.SquareCentimeter);
            AssertEx.EqualTolerance(1, quantity03.SquareCentimeters, SquareCentimetersTolerance);
            Assert.Equal(PorousMediumPermeabilityUnit.SquareCentimeter, quantity03.Unit);

            var quantity04 = PorousMediumPermeability.From(1, PorousMediumPermeabilityUnit.SquareMeter);
            AssertEx.EqualTolerance(1, quantity04.SquareMeters, SquareMetersTolerance);
            Assert.Equal(PorousMediumPermeabilityUnit.SquareMeter, quantity04.Unit);

        }

        [Fact]
        public void FromSquareMeters_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => PorousMediumPermeability.FromSquareMeters(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => PorousMediumPermeability.FromSquareMeters(double.NegativeInfinity));
        }

        [Fact]
        public void FromSquareMeters_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => PorousMediumPermeability.FromSquareMeters(double.NaN));
        }

        [Fact]
        public void As()
        {
            var squaremeter = PorousMediumPermeability.FromSquareMeters(1);
            AssertEx.EqualTolerance(DarcysInOneSquareMeter, squaremeter.As(PorousMediumPermeabilityUnit.Darcy), DarcysTolerance);
            AssertEx.EqualTolerance(MicrodarcysInOneSquareMeter, squaremeter.As(PorousMediumPermeabilityUnit.Microdarcy), MicrodarcysTolerance);
            AssertEx.EqualTolerance(MillidarcysInOneSquareMeter, squaremeter.As(PorousMediumPermeabilityUnit.Millidarcy), MillidarcysTolerance);
            AssertEx.EqualTolerance(SquareCentimetersInOneSquareMeter, squaremeter.As(PorousMediumPermeabilityUnit.SquareCentimeter), SquareCentimetersTolerance);
            AssertEx.EqualTolerance(SquareMetersInOneSquareMeter, squaremeter.As(PorousMediumPermeabilityUnit.SquareMeter), SquareMetersTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new PorousMediumPermeability(value: 1, unit: PorousMediumPermeability.BaseUnit);
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
                var parsed = PorousMediumPermeability.Parse("1 D", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Darcys, DarcysTolerance);
                Assert.Equal(PorousMediumPermeabilityUnit.Darcy, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = PorousMediumPermeability.Parse("1 µD", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Microdarcys, MicrodarcysTolerance);
                Assert.Equal(PorousMediumPermeabilityUnit.Microdarcy, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = PorousMediumPermeability.Parse("1 mD", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.Millidarcys, MillidarcysTolerance);
                Assert.Equal(PorousMediumPermeabilityUnit.Millidarcy, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = PorousMediumPermeability.Parse("1 cm²", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.SquareCentimeters, SquareCentimetersTolerance);
                Assert.Equal(PorousMediumPermeabilityUnit.SquareCentimeter, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsed = PorousMediumPermeability.Parse("1 m²", CultureInfo.GetCultureInfo("en-US"));
                AssertEx.EqualTolerance(1, parsed.SquareMeters, SquareMetersTolerance);
                Assert.Equal(PorousMediumPermeabilityUnit.SquareMeter, parsed.Unit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParse()
        {
            {
                Assert.True(PorousMediumPermeability.TryParse("1 D", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Darcys, DarcysTolerance);
                Assert.Equal(PorousMediumPermeabilityUnit.Darcy, parsed.Unit);
            }

            {
                Assert.True(PorousMediumPermeability.TryParse("1 µD", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Microdarcys, MicrodarcysTolerance);
                Assert.Equal(PorousMediumPermeabilityUnit.Microdarcy, parsed.Unit);
            }

            {
                Assert.True(PorousMediumPermeability.TryParse("1 mD", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.Millidarcys, MillidarcysTolerance);
                Assert.Equal(PorousMediumPermeabilityUnit.Millidarcy, parsed.Unit);
            }

            {
                Assert.True(PorousMediumPermeability.TryParse("1 cm²", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.SquareCentimeters, SquareCentimetersTolerance);
                Assert.Equal(PorousMediumPermeabilityUnit.SquareCentimeter, parsed.Unit);
            }

            {
                Assert.True(PorousMediumPermeability.TryParse("1 m²", CultureInfo.GetCultureInfo("en-US"), out var parsed));
                AssertEx.EqualTolerance(1, parsed.SquareMeters, SquareMetersTolerance);
                Assert.Equal(PorousMediumPermeabilityUnit.SquareMeter, parsed.Unit);
            }

        }

        [Fact]
        public void ParseUnit()
        {
            try
            {
                var parsedUnit = PorousMediumPermeability.ParseUnit("D", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(PorousMediumPermeabilityUnit.Darcy, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = PorousMediumPermeability.ParseUnit("µD", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(PorousMediumPermeabilityUnit.Microdarcy, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = PorousMediumPermeability.ParseUnit("mD", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(PorousMediumPermeabilityUnit.Millidarcy, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = PorousMediumPermeability.ParseUnit("cm²", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(PorousMediumPermeabilityUnit.SquareCentimeter, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

            try
            {
                var parsedUnit = PorousMediumPermeability.ParseUnit("m²", CultureInfo.GetCultureInfo("en-US"));
                Assert.Equal(PorousMediumPermeabilityUnit.SquareMeter, parsedUnit);
            } catch (AmbiguousUnitParseException) { /* Some units have the same abbreviations */ }

        }

        [Fact]
        public void TryParseUnit()
        {
            {
                Assert.True(PorousMediumPermeability.TryParseUnit("D", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(PorousMediumPermeabilityUnit.Darcy, parsedUnit);
            }

            {
                Assert.True(PorousMediumPermeability.TryParseUnit("µD", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(PorousMediumPermeabilityUnit.Microdarcy, parsedUnit);
            }

            {
                Assert.True(PorousMediumPermeability.TryParseUnit("mD", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(PorousMediumPermeabilityUnit.Millidarcy, parsedUnit);
            }

            {
                Assert.True(PorousMediumPermeability.TryParseUnit("cm²", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(PorousMediumPermeabilityUnit.SquareCentimeter, parsedUnit);
            }

            {
                Assert.True(PorousMediumPermeability.TryParseUnit("m²", CultureInfo.GetCultureInfo("en-US"), out var parsedUnit));
                Assert.Equal(PorousMediumPermeabilityUnit.SquareMeter, parsedUnit);
            }

        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(PorousMediumPermeabilityUnit unit)
        {
            var inBaseUnits = PorousMediumPermeability.From(1.0, PorousMediumPermeability.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(PorousMediumPermeabilityUnit unit)
        {
            var quantity = PorousMediumPermeability.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(PorousMediumPermeabilityUnit unit)
        {
            // See if there is a unit available that is not the base unit, fallback to base unit if it has only a single unit.
            var fromUnit = PorousMediumPermeability.Units.First(u => u != PorousMediumPermeability.BaseUnit);

            var quantity = PorousMediumPermeability.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public virtual void ToUnit_FromDefaultQuantity_ReturnsQuantityWithGivenUnit(PorousMediumPermeabilityUnit unit)
        {
            var quantity = default(PorousMediumPermeability);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            PorousMediumPermeability squaremeter = PorousMediumPermeability.FromSquareMeters(1);
            AssertEx.EqualTolerance(1, PorousMediumPermeability.FromDarcys(squaremeter.Darcys).SquareMeters, DarcysTolerance);
            AssertEx.EqualTolerance(1, PorousMediumPermeability.FromMicrodarcys(squaremeter.Microdarcys).SquareMeters, MicrodarcysTolerance);
            AssertEx.EqualTolerance(1, PorousMediumPermeability.FromMillidarcys(squaremeter.Millidarcys).SquareMeters, MillidarcysTolerance);
            AssertEx.EqualTolerance(1, PorousMediumPermeability.FromSquareCentimeters(squaremeter.SquareCentimeters).SquareMeters, SquareCentimetersTolerance);
            AssertEx.EqualTolerance(1, PorousMediumPermeability.FromSquareMeters(squaremeter.SquareMeters).SquareMeters, SquareMetersTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            PorousMediumPermeability v = PorousMediumPermeability.FromSquareMeters(1);
            AssertEx.EqualTolerance(-1, -v.SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(2, (PorousMediumPermeability.FromSquareMeters(3)-v).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(2, (v + v).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(10, (v*10).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(10, (10*v).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(2, (PorousMediumPermeability.FromSquareMeters(10)/5).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(2, PorousMediumPermeability.FromSquareMeters(10)/PorousMediumPermeability.FromSquareMeters(5), SquareMetersTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            PorousMediumPermeability oneSquareMeter = PorousMediumPermeability.FromSquareMeters(1);
            PorousMediumPermeability twoSquareMeters = PorousMediumPermeability.FromSquareMeters(2);

            Assert.True(oneSquareMeter < twoSquareMeters);
            Assert.True(oneSquareMeter <= twoSquareMeters);
            Assert.True(twoSquareMeters > oneSquareMeter);
            Assert.True(twoSquareMeters >= oneSquareMeter);

            Assert.False(oneSquareMeter > twoSquareMeters);
            Assert.False(oneSquareMeter >= twoSquareMeters);
            Assert.False(twoSquareMeters < oneSquareMeter);
            Assert.False(twoSquareMeters <= oneSquareMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            PorousMediumPermeability squaremeter = PorousMediumPermeability.FromSquareMeters(1);
            Assert.Equal(0, squaremeter.CompareTo(squaremeter));
            Assert.True(squaremeter.CompareTo(PorousMediumPermeability.Zero) > 0);
            Assert.True(PorousMediumPermeability.Zero.CompareTo(squaremeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            PorousMediumPermeability squaremeter = PorousMediumPermeability.FromSquareMeters(1);
            Assert.Throws<ArgumentException>(() => squaremeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            PorousMediumPermeability squaremeter = PorousMediumPermeability.FromSquareMeters(1);
            Assert.Throws<ArgumentNullException>(() => squaremeter.CompareTo(null));
        }

        [Theory]
        [InlineData(1, PorousMediumPermeabilityUnit.SquareMeter, 1, PorousMediumPermeabilityUnit.SquareMeter, true)]  // Same value and unit.
        [InlineData(1, PorousMediumPermeabilityUnit.SquareMeter, 2, PorousMediumPermeabilityUnit.SquareMeter, false)] // Different value.
        [InlineData(2, PorousMediumPermeabilityUnit.SquareMeter, 1, PorousMediumPermeabilityUnit.Darcy, false)] // Different value and unit.
        [InlineData(1, PorousMediumPermeabilityUnit.SquareMeter, 1, PorousMediumPermeabilityUnit.Darcy, false)] // Different unit.
        public void Equals_ReturnsTrue_IfValueAndUnitAreEqual(double valueA, PorousMediumPermeabilityUnit unitA, double valueB, PorousMediumPermeabilityUnit unitB, bool expectEqual)
        {
            var a = new PorousMediumPermeability(valueA, unitA);
            var b = new PorousMediumPermeability(valueB, unitB);

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
            var a = PorousMediumPermeability.Zero;

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
            var v = PorousMediumPermeability.FromSquareMeters(1);
            Assert.True(v.Equals(PorousMediumPermeability.FromSquareMeters(1), SquareMetersTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(PorousMediumPermeability.Zero, SquareMetersTolerance, ComparisonType.Relative));
            Assert.True(PorousMediumPermeability.FromSquareMeters(100).Equals(PorousMediumPermeability.FromSquareMeters(120), (double)0.3m, ComparisonType.Relative));
            Assert.False(PorousMediumPermeability.FromSquareMeters(100).Equals(PorousMediumPermeability.FromSquareMeters(120), (double)0.1m, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = PorousMediumPermeability.FromSquareMeters(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(PorousMediumPermeability.FromSquareMeters(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            PorousMediumPermeability squaremeter = PorousMediumPermeability.FromSquareMeters(1);
            Assert.False(squaremeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            PorousMediumPermeability squaremeter = PorousMediumPermeability.FromSquareMeters(1);
            Assert.False(squaremeter.Equals(null));
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(PorousMediumPermeabilityUnit)).Cast<PorousMediumPermeabilityUnit>();
            foreach (var unit in units)
            {
                var defaultAbbreviation = UnitsNetSetup.Default.UnitAbbreviations.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(PorousMediumPermeability.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            using var _ = new CultureScope("en-US");
            Assert.Equal("1 D", new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.Darcy).ToString());
            Assert.Equal("1 µD", new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.Microdarcy).ToString());
            Assert.Equal("1 mD", new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.Millidarcy).ToString());
            Assert.Equal("1 cm²", new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.SquareCentimeter).ToString());
            Assert.Equal("1 m²", new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.SquareMeter).ToString());
        }

        [Fact]
        public void ToString_WithSwedishCulture_ReturnsUnitAbbreviationForEnglishCultureSinceThereAreNoMappings()
        {
            // Chose this culture, because we don't currently have any abbreviations mapped for that culture and we expect the en-US to be used as fallback.
            var swedishCulture = CultureInfo.GetCultureInfo("sv-SE");

            Assert.Equal("1 D", new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.Darcy).ToString(swedishCulture));
            Assert.Equal("1 µD", new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.Microdarcy).ToString(swedishCulture));
            Assert.Equal("1 mD", new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.Millidarcy).ToString(swedishCulture));
            Assert.Equal("1 cm²", new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.SquareCentimeter).ToString(swedishCulture));
            Assert.Equal("1 m²", new PorousMediumPermeability(1, PorousMediumPermeabilityUnit.SquareMeter).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var _ = new CultureScope(CultureInfo.InvariantCulture);
            Assert.Equal("0.1 m²", new PorousMediumPermeability(0.123456, PorousMediumPermeabilityUnit.SquareMeter).ToString("s1"));
            Assert.Equal("0.12 m²", new PorousMediumPermeability(0.123456, PorousMediumPermeabilityUnit.SquareMeter).ToString("s2"));
            Assert.Equal("0.123 m²", new PorousMediumPermeability(0.123456, PorousMediumPermeabilityUnit.SquareMeter).ToString("s3"));
            Assert.Equal("0.1235 m²", new PorousMediumPermeability(0.123456, PorousMediumPermeabilityUnit.SquareMeter).ToString("s4"));
        }

        [Fact]
        public void ToString_SFormatAndCulture_FormatsNumberWithGivenDigitsAfterRadixForGivenCulture()
        {
            var culture = CultureInfo.InvariantCulture;
            Assert.Equal("0.1 m²", new PorousMediumPermeability(0.123456, PorousMediumPermeabilityUnit.SquareMeter).ToString("s1", culture));
            Assert.Equal("0.12 m²", new PorousMediumPermeability(0.123456, PorousMediumPermeabilityUnit.SquareMeter).ToString("s2", culture));
            Assert.Equal("0.123 m²", new PorousMediumPermeability(0.123456, PorousMediumPermeabilityUnit.SquareMeter).ToString("s3", culture));
            Assert.Equal("0.1235 m²", new PorousMediumPermeability(0.123456, PorousMediumPermeabilityUnit.SquareMeter).ToString("s4", culture));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("en-US")]
        public void ToString_NullFormat_DefaultsToGeneralFormat(string cultureName)
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
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
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal(quantity.ToString(format, CultureInfo.CurrentCulture), quantity.ToString(format, null));
        }

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(PorousMediumPermeability)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(PorousMediumPermeabilityUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal(PorousMediumPermeability.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal(PorousMediumPermeability.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(1.0);
            Assert.Equal(new {PorousMediumPermeability.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = PorousMediumPermeability.FromSquareMeters(value);
            Assert.Equal(PorousMediumPermeability.FromSquareMeters(-value), -quantity);
        }
    }
}
