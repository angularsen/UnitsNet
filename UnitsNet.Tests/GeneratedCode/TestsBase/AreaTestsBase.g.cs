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
    /// Test of Area.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class AreaTestsBase : QuantityTestsBase
    {
        protected abstract double AcresInOneSquareMeter { get; }
        protected abstract double HectaresInOneSquareMeter { get; }
        protected abstract double SquareCentimetersInOneSquareMeter { get; }
        protected abstract double SquareDecimetersInOneSquareMeter { get; }
        protected abstract double SquareFeetInOneSquareMeter { get; }
        protected abstract double SquareInchesInOneSquareMeter { get; }
        protected abstract double SquareKilometersInOneSquareMeter { get; }
        protected abstract double SquareMetersInOneSquareMeter { get; }
        protected abstract double SquareMicrometersInOneSquareMeter { get; }
        protected abstract double SquareMilesInOneSquareMeter { get; }
        protected abstract double SquareMillimetersInOneSquareMeter { get; }
        protected abstract double SquareNauticalMilesInOneSquareMeter { get; }
        protected abstract double SquareYardsInOneSquareMeter { get; }
        protected abstract double UsSurveySquareFeetInOneSquareMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double AcresTolerance { get { return 1e-5; } }
        protected virtual double HectaresTolerance { get { return 1e-5; } }
        protected virtual double SquareCentimetersTolerance { get { return 1e-5; } }
        protected virtual double SquareDecimetersTolerance { get { return 1e-5; } }
        protected virtual double SquareFeetTolerance { get { return 1e-5; } }
        protected virtual double SquareInchesTolerance { get { return 1e-5; } }
        protected virtual double SquareKilometersTolerance { get { return 1e-5; } }
        protected virtual double SquareMetersTolerance { get { return 1e-5; } }
        protected virtual double SquareMicrometersTolerance { get { return 1e-5; } }
        protected virtual double SquareMilesTolerance { get { return 1e-5; } }
        protected virtual double SquareMillimetersTolerance { get { return 1e-5; } }
        protected virtual double SquareNauticalMilesTolerance { get { return 1e-5; } }
        protected virtual double SquareYardsTolerance { get { return 1e-5; } }
        protected virtual double UsSurveySquareFeetTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(AreaUnit unit)
        {
            return unit switch
            {
                AreaUnit.Acre => (AcresInOneSquareMeter, AcresTolerance),
                AreaUnit.Hectare => (HectaresInOneSquareMeter, HectaresTolerance),
                AreaUnit.SquareCentimeter => (SquareCentimetersInOneSquareMeter, SquareCentimetersTolerance),
                AreaUnit.SquareDecimeter => (SquareDecimetersInOneSquareMeter, SquareDecimetersTolerance),
                AreaUnit.SquareFoot => (SquareFeetInOneSquareMeter, SquareFeetTolerance),
                AreaUnit.SquareInch => (SquareInchesInOneSquareMeter, SquareInchesTolerance),
                AreaUnit.SquareKilometer => (SquareKilometersInOneSquareMeter, SquareKilometersTolerance),
                AreaUnit.SquareMeter => (SquareMetersInOneSquareMeter, SquareMetersTolerance),
                AreaUnit.SquareMicrometer => (SquareMicrometersInOneSquareMeter, SquareMicrometersTolerance),
                AreaUnit.SquareMile => (SquareMilesInOneSquareMeter, SquareMilesTolerance),
                AreaUnit.SquareMillimeter => (SquareMillimetersInOneSquareMeter, SquareMillimetersTolerance),
                AreaUnit.SquareNauticalMile => (SquareNauticalMilesInOneSquareMeter, SquareNauticalMilesTolerance),
                AreaUnit.SquareYard => (SquareYardsInOneSquareMeter, SquareYardsTolerance),
                AreaUnit.UsSurveySquareFoot => (UsSurveySquareFeetInOneSquareMeter, UsSurveySquareFeetTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { AreaUnit.Acre },
            new object[] { AreaUnit.Hectare },
            new object[] { AreaUnit.SquareCentimeter },
            new object[] { AreaUnit.SquareDecimeter },
            new object[] { AreaUnit.SquareFoot },
            new object[] { AreaUnit.SquareInch },
            new object[] { AreaUnit.SquareKilometer },
            new object[] { AreaUnit.SquareMeter },
            new object[] { AreaUnit.SquareMicrometer },
            new object[] { AreaUnit.SquareMile },
            new object[] { AreaUnit.SquareMillimeter },
            new object[] { AreaUnit.SquareNauticalMile },
            new object[] { AreaUnit.SquareYard },
            new object[] { AreaUnit.UsSurveySquareFoot },
        };

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Area((double)0.0, AreaUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new Area();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(AreaUnit.SquareMeter, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Area(double.PositiveInfinity, AreaUnit.SquareMeter));
            Assert.Throws<ArgumentException>(() => new Area(double.NegativeInfinity, AreaUnit.SquareMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Area(double.NaN, AreaUnit.SquareMeter));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Area(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new Area(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (Area) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void Area_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new Area(1, AreaUnit.SquareMeter);

            QuantityInfo<AreaUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(Area.Zero, quantityInfo.Zero);
            Assert.Equal("Area", quantityInfo.Name);
            Assert.Equal(QuantityType.Area, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<AreaUnit>().Except(new[] {AreaUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
        }

        [Fact]
        public void SquareMeterToAreaUnits()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            AssertEx.EqualTolerance(AcresInOneSquareMeter, squaremeter.Acres, AcresTolerance);
            AssertEx.EqualTolerance(HectaresInOneSquareMeter, squaremeter.Hectares, HectaresTolerance);
            AssertEx.EqualTolerance(SquareCentimetersInOneSquareMeter, squaremeter.SquareCentimeters, SquareCentimetersTolerance);
            AssertEx.EqualTolerance(SquareDecimetersInOneSquareMeter, squaremeter.SquareDecimeters, SquareDecimetersTolerance);
            AssertEx.EqualTolerance(SquareFeetInOneSquareMeter, squaremeter.SquareFeet, SquareFeetTolerance);
            AssertEx.EqualTolerance(SquareInchesInOneSquareMeter, squaremeter.SquareInches, SquareInchesTolerance);
            AssertEx.EqualTolerance(SquareKilometersInOneSquareMeter, squaremeter.SquareKilometers, SquareKilometersTolerance);
            AssertEx.EqualTolerance(SquareMetersInOneSquareMeter, squaremeter.SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(SquareMicrometersInOneSquareMeter, squaremeter.SquareMicrometers, SquareMicrometersTolerance);
            AssertEx.EqualTolerance(SquareMilesInOneSquareMeter, squaremeter.SquareMiles, SquareMilesTolerance);
            AssertEx.EqualTolerance(SquareMillimetersInOneSquareMeter, squaremeter.SquareMillimeters, SquareMillimetersTolerance);
            AssertEx.EqualTolerance(SquareNauticalMilesInOneSquareMeter, squaremeter.SquareNauticalMiles, SquareNauticalMilesTolerance);
            AssertEx.EqualTolerance(SquareYardsInOneSquareMeter, squaremeter.SquareYards, SquareYardsTolerance);
            AssertEx.EqualTolerance(UsSurveySquareFeetInOneSquareMeter, squaremeter.UsSurveySquareFeet, UsSurveySquareFeetTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = Area.From(1, AreaUnit.Acre);
            AssertEx.EqualTolerance(1, quantity00.Acres, AcresTolerance);
            Assert.Equal(AreaUnit.Acre, quantity00.Unit);

            var quantity01 = Area.From(1, AreaUnit.Hectare);
            AssertEx.EqualTolerance(1, quantity01.Hectares, HectaresTolerance);
            Assert.Equal(AreaUnit.Hectare, quantity01.Unit);

            var quantity02 = Area.From(1, AreaUnit.SquareCentimeter);
            AssertEx.EqualTolerance(1, quantity02.SquareCentimeters, SquareCentimetersTolerance);
            Assert.Equal(AreaUnit.SquareCentimeter, quantity02.Unit);

            var quantity03 = Area.From(1, AreaUnit.SquareDecimeter);
            AssertEx.EqualTolerance(1, quantity03.SquareDecimeters, SquareDecimetersTolerance);
            Assert.Equal(AreaUnit.SquareDecimeter, quantity03.Unit);

            var quantity04 = Area.From(1, AreaUnit.SquareFoot);
            AssertEx.EqualTolerance(1, quantity04.SquareFeet, SquareFeetTolerance);
            Assert.Equal(AreaUnit.SquareFoot, quantity04.Unit);

            var quantity05 = Area.From(1, AreaUnit.SquareInch);
            AssertEx.EqualTolerance(1, quantity05.SquareInches, SquareInchesTolerance);
            Assert.Equal(AreaUnit.SquareInch, quantity05.Unit);

            var quantity06 = Area.From(1, AreaUnit.SquareKilometer);
            AssertEx.EqualTolerance(1, quantity06.SquareKilometers, SquareKilometersTolerance);
            Assert.Equal(AreaUnit.SquareKilometer, quantity06.Unit);

            var quantity07 = Area.From(1, AreaUnit.SquareMeter);
            AssertEx.EqualTolerance(1, quantity07.SquareMeters, SquareMetersTolerance);
            Assert.Equal(AreaUnit.SquareMeter, quantity07.Unit);

            var quantity08 = Area.From(1, AreaUnit.SquareMicrometer);
            AssertEx.EqualTolerance(1, quantity08.SquareMicrometers, SquareMicrometersTolerance);
            Assert.Equal(AreaUnit.SquareMicrometer, quantity08.Unit);

            var quantity09 = Area.From(1, AreaUnit.SquareMile);
            AssertEx.EqualTolerance(1, quantity09.SquareMiles, SquareMilesTolerance);
            Assert.Equal(AreaUnit.SquareMile, quantity09.Unit);

            var quantity10 = Area.From(1, AreaUnit.SquareMillimeter);
            AssertEx.EqualTolerance(1, quantity10.SquareMillimeters, SquareMillimetersTolerance);
            Assert.Equal(AreaUnit.SquareMillimeter, quantity10.Unit);

            var quantity11 = Area.From(1, AreaUnit.SquareNauticalMile);
            AssertEx.EqualTolerance(1, quantity11.SquareNauticalMiles, SquareNauticalMilesTolerance);
            Assert.Equal(AreaUnit.SquareNauticalMile, quantity11.Unit);

            var quantity12 = Area.From(1, AreaUnit.SquareYard);
            AssertEx.EqualTolerance(1, quantity12.SquareYards, SquareYardsTolerance);
            Assert.Equal(AreaUnit.SquareYard, quantity12.Unit);

            var quantity13 = Area.From(1, AreaUnit.UsSurveySquareFoot);
            AssertEx.EqualTolerance(1, quantity13.UsSurveySquareFeet, UsSurveySquareFeetTolerance);
            Assert.Equal(AreaUnit.UsSurveySquareFoot, quantity13.Unit);

        }

        [Fact]
        public void FromSquareMeters_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Area.FromSquareMeters(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => Area.FromSquareMeters(double.NegativeInfinity));
        }

        [Fact]
        public void FromSquareMeters_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Area.FromSquareMeters(double.NaN));
        }

        [Fact]
        public void As()
        {
            var squaremeter = Area.FromSquareMeters(1);
            AssertEx.EqualTolerance(AcresInOneSquareMeter, squaremeter.As(AreaUnit.Acre), AcresTolerance);
            AssertEx.EqualTolerance(HectaresInOneSquareMeter, squaremeter.As(AreaUnit.Hectare), HectaresTolerance);
            AssertEx.EqualTolerance(SquareCentimetersInOneSquareMeter, squaremeter.As(AreaUnit.SquareCentimeter), SquareCentimetersTolerance);
            AssertEx.EqualTolerance(SquareDecimetersInOneSquareMeter, squaremeter.As(AreaUnit.SquareDecimeter), SquareDecimetersTolerance);
            AssertEx.EqualTolerance(SquareFeetInOneSquareMeter, squaremeter.As(AreaUnit.SquareFoot), SquareFeetTolerance);
            AssertEx.EqualTolerance(SquareInchesInOneSquareMeter, squaremeter.As(AreaUnit.SquareInch), SquareInchesTolerance);
            AssertEx.EqualTolerance(SquareKilometersInOneSquareMeter, squaremeter.As(AreaUnit.SquareKilometer), SquareKilometersTolerance);
            AssertEx.EqualTolerance(SquareMetersInOneSquareMeter, squaremeter.As(AreaUnit.SquareMeter), SquareMetersTolerance);
            AssertEx.EqualTolerance(SquareMicrometersInOneSquareMeter, squaremeter.As(AreaUnit.SquareMicrometer), SquareMicrometersTolerance);
            AssertEx.EqualTolerance(SquareMilesInOneSquareMeter, squaremeter.As(AreaUnit.SquareMile), SquareMilesTolerance);
            AssertEx.EqualTolerance(SquareMillimetersInOneSquareMeter, squaremeter.As(AreaUnit.SquareMillimeter), SquareMillimetersTolerance);
            AssertEx.EqualTolerance(SquareNauticalMilesInOneSquareMeter, squaremeter.As(AreaUnit.SquareNauticalMile), SquareNauticalMilesTolerance);
            AssertEx.EqualTolerance(SquareYardsInOneSquareMeter, squaremeter.As(AreaUnit.SquareYard), SquareYardsTolerance);
            AssertEx.EqualTolerance(UsSurveySquareFeetInOneSquareMeter, squaremeter.As(AreaUnit.UsSurveySquareFoot), UsSurveySquareFeetTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new Area(value: 1, unit: Area.BaseUnit);
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

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit(AreaUnit unit)
        {
            var inBaseUnits = Area.From(1.0, Area.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, (double)converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(AreaUnit unit)
        {
            var quantity = Area.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(AreaUnit unit)
        {
            // See if there is a unit available that is not the base unit.
            var fromUnit = Area.Units.FirstOrDefault(u => u != Area.BaseUnit && u != AreaUnit.Undefined);

            // If there is only one unit for the quantity, we must use the base unit.
            if(fromUnit == AreaUnit.Undefined)
                fromUnit = Area.BaseUnit;

            var quantity = Area.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            AssertEx.EqualTolerance(1, Area.FromAcres(squaremeter.Acres).SquareMeters, AcresTolerance);
            AssertEx.EqualTolerance(1, Area.FromHectares(squaremeter.Hectares).SquareMeters, HectaresTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareCentimeters(squaremeter.SquareCentimeters).SquareMeters, SquareCentimetersTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareDecimeters(squaremeter.SquareDecimeters).SquareMeters, SquareDecimetersTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareFeet(squaremeter.SquareFeet).SquareMeters, SquareFeetTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareInches(squaremeter.SquareInches).SquareMeters, SquareInchesTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareKilometers(squaremeter.SquareKilometers).SquareMeters, SquareKilometersTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareMeters(squaremeter.SquareMeters).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareMicrometers(squaremeter.SquareMicrometers).SquareMeters, SquareMicrometersTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareMiles(squaremeter.SquareMiles).SquareMeters, SquareMilesTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareMillimeters(squaremeter.SquareMillimeters).SquareMeters, SquareMillimetersTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareNauticalMiles(squaremeter.SquareNauticalMiles).SquareMeters, SquareNauticalMilesTolerance);
            AssertEx.EqualTolerance(1, Area.FromSquareYards(squaremeter.SquareYards).SquareMeters, SquareYardsTolerance);
            AssertEx.EqualTolerance(1, Area.FromUsSurveySquareFeet(squaremeter.UsSurveySquareFeet).SquareMeters, UsSurveySquareFeetTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Area v = Area.FromSquareMeters(1);
            AssertEx.EqualTolerance(-1, -v.SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(2, (Area.FromSquareMeters(3)-v).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(2, (v + v).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(10, (v*10).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(10, (10*v).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(2, (Area.FromSquareMeters(10)/5).SquareMeters, SquareMetersTolerance);
            AssertEx.EqualTolerance(2, Area.FromSquareMeters(10)/Area.FromSquareMeters(5), SquareMetersTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            Area oneSquareMeter = Area.FromSquareMeters(1);
            Area twoSquareMeters = Area.FromSquareMeters(2);

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
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.Equal(0, squaremeter.CompareTo(squaremeter));
            Assert.True(squaremeter.CompareTo(Area.Zero) > 0);
            Assert.True(Area.Zero.CompareTo(squaremeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.Throws<ArgumentException>(() => squaremeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.Throws<ArgumentNullException>(() => squaremeter.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = Area.FromSquareMeters(1);
            var b = Area.FromSquareMeters(2);

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
            var a = Area.FromSquareMeters(1);
            var b = Area.FromSquareMeters(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = Area.FromSquareMeters(1);
            object b = Area.FromSquareMeters(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = Area.FromSquareMeters(1);
            Assert.True(v.Equals(Area.FromSquareMeters(1), SquareMetersTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Area.Zero, SquareMetersTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = Area.FromSquareMeters(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(Area.FromSquareMeters(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.False(squaremeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.False(squaremeter.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(AreaUnit.Undefined, Area.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(AreaUnit)).Cast<AreaUnit>();
            foreach(var unit in units)
            {
                if(unit == AreaUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(Area.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 ac", new Area(1, AreaUnit.Acre).ToString());
                Assert.Equal("1 ha", new Area(1, AreaUnit.Hectare).ToString());
                Assert.Equal("1 cm²", new Area(1, AreaUnit.SquareCentimeter).ToString());
                Assert.Equal("1 dm²", new Area(1, AreaUnit.SquareDecimeter).ToString());
                Assert.Equal("1 ft²", new Area(1, AreaUnit.SquareFoot).ToString());
                Assert.Equal("1 in²", new Area(1, AreaUnit.SquareInch).ToString());
                Assert.Equal("1 km²", new Area(1, AreaUnit.SquareKilometer).ToString());
                Assert.Equal("1 m²", new Area(1, AreaUnit.SquareMeter).ToString());
                Assert.Equal("1 µm²", new Area(1, AreaUnit.SquareMicrometer).ToString());
                Assert.Equal("1 mi²", new Area(1, AreaUnit.SquareMile).ToString());
                Assert.Equal("1 mm²", new Area(1, AreaUnit.SquareMillimeter).ToString());
                Assert.Equal("1 nmi²", new Area(1, AreaUnit.SquareNauticalMile).ToString());
                Assert.Equal("1 yd²", new Area(1, AreaUnit.SquareYard).ToString());
                Assert.Equal("1 ft² (US)", new Area(1, AreaUnit.UsSurveySquareFoot).ToString());
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

            Assert.Equal("1 ac", new Area(1, AreaUnit.Acre).ToString(swedishCulture));
            Assert.Equal("1 ha", new Area(1, AreaUnit.Hectare).ToString(swedishCulture));
            Assert.Equal("1 cm²", new Area(1, AreaUnit.SquareCentimeter).ToString(swedishCulture));
            Assert.Equal("1 dm²", new Area(1, AreaUnit.SquareDecimeter).ToString(swedishCulture));
            Assert.Equal("1 ft²", new Area(1, AreaUnit.SquareFoot).ToString(swedishCulture));
            Assert.Equal("1 in²", new Area(1, AreaUnit.SquareInch).ToString(swedishCulture));
            Assert.Equal("1 km²", new Area(1, AreaUnit.SquareKilometer).ToString(swedishCulture));
            Assert.Equal("1 m²", new Area(1, AreaUnit.SquareMeter).ToString(swedishCulture));
            Assert.Equal("1 µm²", new Area(1, AreaUnit.SquareMicrometer).ToString(swedishCulture));
            Assert.Equal("1 mi²", new Area(1, AreaUnit.SquareMile).ToString(swedishCulture));
            Assert.Equal("1 mm²", new Area(1, AreaUnit.SquareMillimeter).ToString(swedishCulture));
            Assert.Equal("1 nmi²", new Area(1, AreaUnit.SquareNauticalMile).ToString(swedishCulture));
            Assert.Equal("1 yd²", new Area(1, AreaUnit.SquareYard).ToString(swedishCulture));
            Assert.Equal("1 ft² (US)", new Area(1, AreaUnit.UsSurveySquareFoot).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 m²", new Area(0.123456, AreaUnit.SquareMeter).ToString("s1"));
                Assert.Equal("0.12 m²", new Area(0.123456, AreaUnit.SquareMeter).ToString("s2"));
                Assert.Equal("0.123 m²", new Area(0.123456, AreaUnit.SquareMeter).ToString("s3"));
                Assert.Equal("0.1235 m²", new Area(0.123456, AreaUnit.SquareMeter).ToString("s4"));
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
            Assert.Equal("0.1 m²", new Area(0.123456, AreaUnit.SquareMeter).ToString("s1", culture));
            Assert.Equal("0.12 m²", new Area(0.123456, AreaUnit.SquareMeter).ToString("s2", culture));
            Assert.Equal("0.123 m²", new Area(0.123456, AreaUnit.SquareMeter).ToString("s3", culture));
            Assert.Equal("0.1235 m²", new Area(0.123456, AreaUnit.SquareMeter).ToString("s4", culture));
        }


        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }


        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(Area)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(AreaUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal(QuantityType.Area, Convert.ChangeType(quantity, typeof(QuantityType)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal(Area.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal(Area.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = Area.FromSquareMeters(1.0);
            Assert.Equal(new {Area.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = Area.FromSquareMeters(value);
            Assert.Equal(Area.FromSquareMeters(-value), -quantity);
        }
    }
}
