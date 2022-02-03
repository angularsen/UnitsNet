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
    /// Test of ReciprocalLength.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ReciprocalLengthTestsBase : QuantityTestsBase
    {
        protected abstract double InverseCentimetersInOneInverseMeter { get; }
        protected abstract double InverseFeetInOneInverseMeter { get; }
        protected abstract double InverseInchesInOneInverseMeter { get; }
        protected abstract double InverseMetersInOneInverseMeter { get; }
        protected abstract double InverseMicroinchesInOneInverseMeter { get; }
        protected abstract double InverseMilsInOneInverseMeter { get; }
        protected abstract double InverseMilesInOneInverseMeter { get; }
        protected abstract double InverseMillimetersInOneInverseMeter { get; }
        protected abstract double InverseUsSurveyFeetInOneInverseMeter { get; }
        protected abstract double InverseYardsInOneInverseMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double InverseCentimetersTolerance { get { return 1e-5; } }
        protected virtual double InverseFeetTolerance { get { return 1e-5; } }
        protected virtual double InverseInchesTolerance { get { return 1e-5; } }
        protected virtual double InverseMetersTolerance { get { return 1e-5; } }
        protected virtual double InverseMicroinchesTolerance { get { return 1e-5; } }
        protected virtual double InverseMilsTolerance { get { return 1e-5; } }
        protected virtual double InverseMilesTolerance { get { return 1e-5; } }
        protected virtual double InverseMillimetersTolerance { get { return 1e-5; } }
        protected virtual double InverseUsSurveyFeetTolerance { get { return 1e-5; } }
        protected virtual double InverseYardsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { ReciprocalLengthUnit.InverseCentimeter },
            new object[] { ReciprocalLengthUnit.InverseFoot },
            new object[] { ReciprocalLengthUnit.InverseInch },
            new object[] { ReciprocalLengthUnit.InverseMeter },
            new object[] { ReciprocalLengthUnit.InverseMicroinch },
            new object[] { ReciprocalLengthUnit.InverseMil },
            new object[] { ReciprocalLengthUnit.InverseMile },
            new object[] { ReciprocalLengthUnit.InverseMillimeter },
            new object[] { ReciprocalLengthUnit.InverseUsSurveyFoot },
            new object[] { ReciprocalLengthUnit.InverseYard },
        };

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ReciprocalLength((double)0.0, ReciprocalLengthUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new ReciprocalLength();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(ReciprocalLengthUnit.InverseMeter, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ReciprocalLength(double.PositiveInfinity, ReciprocalLengthUnit.InverseMeter));
            Assert.Throws<ArgumentException>(() => new ReciprocalLength(double.NegativeInfinity, ReciprocalLengthUnit.InverseMeter));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ReciprocalLength(double.NaN, ReciprocalLengthUnit.InverseMeter));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ReciprocalLength(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new ReciprocalLength(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (ReciprocalLength) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void ReciprocalLength_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new ReciprocalLength(1, ReciprocalLengthUnit.InverseMeter);

            QuantityInfo<ReciprocalLengthUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(ReciprocalLength.Zero, quantityInfo.Zero);
            Assert.Equal("ReciprocalLength", quantityInfo.Name);
            Assert.Equal(QuantityType.ReciprocalLength, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<ReciprocalLengthUnit>().Except(new[] {ReciprocalLengthUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
        }

        [Fact]
        public void InverseMeterToReciprocalLengthUnits()
        {
            ReciprocalLength inversemeter = ReciprocalLength.FromInverseMeters(1);
            AssertEx.EqualTolerance(InverseCentimetersInOneInverseMeter, inversemeter.InverseCentimeters, InverseCentimetersTolerance);
            AssertEx.EqualTolerance(InverseFeetInOneInverseMeter, inversemeter.InverseFeet, InverseFeetTolerance);
            AssertEx.EqualTolerance(InverseInchesInOneInverseMeter, inversemeter.InverseInches, InverseInchesTolerance);
            AssertEx.EqualTolerance(InverseMetersInOneInverseMeter, inversemeter.InverseMeters, InverseMetersTolerance);
            AssertEx.EqualTolerance(InverseMicroinchesInOneInverseMeter, inversemeter.InverseMicroinches, InverseMicroinchesTolerance);
            AssertEx.EqualTolerance(InverseMilsInOneInverseMeter, inversemeter.InverseMils, InverseMilsTolerance);
            AssertEx.EqualTolerance(InverseMilesInOneInverseMeter, inversemeter.InverseMiles, InverseMilesTolerance);
            AssertEx.EqualTolerance(InverseMillimetersInOneInverseMeter, inversemeter.InverseMillimeters, InverseMillimetersTolerance);
            AssertEx.EqualTolerance(InverseUsSurveyFeetInOneInverseMeter, inversemeter.InverseUsSurveyFeet, InverseUsSurveyFeetTolerance);
            AssertEx.EqualTolerance(InverseYardsInOneInverseMeter, inversemeter.InverseYards, InverseYardsTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = ReciprocalLength.From(1, ReciprocalLengthUnit.InverseCentimeter);
            AssertEx.EqualTolerance(1, quantity00.InverseCentimeters, InverseCentimetersTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseCentimeter, quantity00.Unit);

            var quantity01 = ReciprocalLength.From(1, ReciprocalLengthUnit.InverseFoot);
            AssertEx.EqualTolerance(1, quantity01.InverseFeet, InverseFeetTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseFoot, quantity01.Unit);

            var quantity02 = ReciprocalLength.From(1, ReciprocalLengthUnit.InverseInch);
            AssertEx.EqualTolerance(1, quantity02.InverseInches, InverseInchesTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseInch, quantity02.Unit);

            var quantity03 = ReciprocalLength.From(1, ReciprocalLengthUnit.InverseMeter);
            AssertEx.EqualTolerance(1, quantity03.InverseMeters, InverseMetersTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseMeter, quantity03.Unit);

            var quantity04 = ReciprocalLength.From(1, ReciprocalLengthUnit.InverseMicroinch);
            AssertEx.EqualTolerance(1, quantity04.InverseMicroinches, InverseMicroinchesTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseMicroinch, quantity04.Unit);

            var quantity05 = ReciprocalLength.From(1, ReciprocalLengthUnit.InverseMil);
            AssertEx.EqualTolerance(1, quantity05.InverseMils, InverseMilsTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseMil, quantity05.Unit);

            var quantity06 = ReciprocalLength.From(1, ReciprocalLengthUnit.InverseMile);
            AssertEx.EqualTolerance(1, quantity06.InverseMiles, InverseMilesTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseMile, quantity06.Unit);

            var quantity07 = ReciprocalLength.From(1, ReciprocalLengthUnit.InverseMillimeter);
            AssertEx.EqualTolerance(1, quantity07.InverseMillimeters, InverseMillimetersTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseMillimeter, quantity07.Unit);

            var quantity08 = ReciprocalLength.From(1, ReciprocalLengthUnit.InverseUsSurveyFoot);
            AssertEx.EqualTolerance(1, quantity08.InverseUsSurveyFeet, InverseUsSurveyFeetTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseUsSurveyFoot, quantity08.Unit);

            var quantity09 = ReciprocalLength.From(1, ReciprocalLengthUnit.InverseYard);
            AssertEx.EqualTolerance(1, quantity09.InverseYards, InverseYardsTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseYard, quantity09.Unit);

        }

        [Fact]
        public void FromInverseMeters_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ReciprocalLength.FromInverseMeters(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => ReciprocalLength.FromInverseMeters(double.NegativeInfinity));
        }

        [Fact]
        public void FromInverseMeters_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ReciprocalLength.FromInverseMeters(double.NaN));
        }

        [Fact]
        public void As()
        {
            var inversemeter = ReciprocalLength.FromInverseMeters(1);
            AssertEx.EqualTolerance(InverseCentimetersInOneInverseMeter, inversemeter.As(ReciprocalLengthUnit.InverseCentimeter), InverseCentimetersTolerance);
            AssertEx.EqualTolerance(InverseFeetInOneInverseMeter, inversemeter.As(ReciprocalLengthUnit.InverseFoot), InverseFeetTolerance);
            AssertEx.EqualTolerance(InverseInchesInOneInverseMeter, inversemeter.As(ReciprocalLengthUnit.InverseInch), InverseInchesTolerance);
            AssertEx.EqualTolerance(InverseMetersInOneInverseMeter, inversemeter.As(ReciprocalLengthUnit.InverseMeter), InverseMetersTolerance);
            AssertEx.EqualTolerance(InverseMicroinchesInOneInverseMeter, inversemeter.As(ReciprocalLengthUnit.InverseMicroinch), InverseMicroinchesTolerance);
            AssertEx.EqualTolerance(InverseMilsInOneInverseMeter, inversemeter.As(ReciprocalLengthUnit.InverseMil), InverseMilsTolerance);
            AssertEx.EqualTolerance(InverseMilesInOneInverseMeter, inversemeter.As(ReciprocalLengthUnit.InverseMile), InverseMilesTolerance);
            AssertEx.EqualTolerance(InverseMillimetersInOneInverseMeter, inversemeter.As(ReciprocalLengthUnit.InverseMillimeter), InverseMillimetersTolerance);
            AssertEx.EqualTolerance(InverseUsSurveyFeetInOneInverseMeter, inversemeter.As(ReciprocalLengthUnit.InverseUsSurveyFoot), InverseUsSurveyFeetTolerance);
            AssertEx.EqualTolerance(InverseYardsInOneInverseMeter, inversemeter.As(ReciprocalLengthUnit.InverseYard), InverseYardsTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new ReciprocalLength(value: 1, unit: ReciprocalLength.BaseUnit);
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
            var inversemeter = ReciprocalLength.FromInverseMeters(1);

            var inversecentimeterQuantity = inversemeter.ToUnit(ReciprocalLengthUnit.InverseCentimeter);
            AssertEx.EqualTolerance(InverseCentimetersInOneInverseMeter, (double)inversecentimeterQuantity.Value, InverseCentimetersTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseCentimeter, inversecentimeterQuantity.Unit);

            var inversefootQuantity = inversemeter.ToUnit(ReciprocalLengthUnit.InverseFoot);
            AssertEx.EqualTolerance(InverseFeetInOneInverseMeter, (double)inversefootQuantity.Value, InverseFeetTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseFoot, inversefootQuantity.Unit);

            var inverseinchQuantity = inversemeter.ToUnit(ReciprocalLengthUnit.InverseInch);
            AssertEx.EqualTolerance(InverseInchesInOneInverseMeter, (double)inverseinchQuantity.Value, InverseInchesTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseInch, inverseinchQuantity.Unit);

            var inversemeterQuantity = inversemeter.ToUnit(ReciprocalLengthUnit.InverseMeter);
            AssertEx.EqualTolerance(InverseMetersInOneInverseMeter, (double)inversemeterQuantity.Value, InverseMetersTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseMeter, inversemeterQuantity.Unit);

            var inversemicroinchQuantity = inversemeter.ToUnit(ReciprocalLengthUnit.InverseMicroinch);
            AssertEx.EqualTolerance(InverseMicroinchesInOneInverseMeter, (double)inversemicroinchQuantity.Value, InverseMicroinchesTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseMicroinch, inversemicroinchQuantity.Unit);

            var inversemilQuantity = inversemeter.ToUnit(ReciprocalLengthUnit.InverseMil);
            AssertEx.EqualTolerance(InverseMilsInOneInverseMeter, (double)inversemilQuantity.Value, InverseMilsTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseMil, inversemilQuantity.Unit);

            var inversemileQuantity = inversemeter.ToUnit(ReciprocalLengthUnit.InverseMile);
            AssertEx.EqualTolerance(InverseMilesInOneInverseMeter, (double)inversemileQuantity.Value, InverseMilesTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseMile, inversemileQuantity.Unit);

            var inversemillimeterQuantity = inversemeter.ToUnit(ReciprocalLengthUnit.InverseMillimeter);
            AssertEx.EqualTolerance(InverseMillimetersInOneInverseMeter, (double)inversemillimeterQuantity.Value, InverseMillimetersTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseMillimeter, inversemillimeterQuantity.Unit);

            var inverseussurveyfootQuantity = inversemeter.ToUnit(ReciprocalLengthUnit.InverseUsSurveyFoot);
            AssertEx.EqualTolerance(InverseUsSurveyFeetInOneInverseMeter, (double)inverseussurveyfootQuantity.Value, InverseUsSurveyFeetTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseUsSurveyFoot, inverseussurveyfootQuantity.Unit);

            var inverseyardQuantity = inversemeter.ToUnit(ReciprocalLengthUnit.InverseYard);
            AssertEx.EqualTolerance(InverseYardsInOneInverseMeter, (double)inverseyardQuantity.Value, InverseYardsTolerance);
            Assert.Equal(ReciprocalLengthUnit.InverseYard, inverseyardQuantity.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(ReciprocalLengthUnit unit)
        {
            var quantity = ReciprocalLength.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_NoException(ReciprocalLengthUnit unit)
        {
            var quantity = ReciprocalLength.From(3.0, ReciprocalLength.Units.First(unit => unit != ReciprocalLength.BaseUnit));
            var converted = quantity.ToUnit(unit);
            // TODO: Meaningful check possible?
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            ReciprocalLength inversemeter = ReciprocalLength.FromInverseMeters(1);
            AssertEx.EqualTolerance(1, ReciprocalLength.FromInverseCentimeters(inversemeter.InverseCentimeters).InverseMeters, InverseCentimetersTolerance);
            AssertEx.EqualTolerance(1, ReciprocalLength.FromInverseFeet(inversemeter.InverseFeet).InverseMeters, InverseFeetTolerance);
            AssertEx.EqualTolerance(1, ReciprocalLength.FromInverseInches(inversemeter.InverseInches).InverseMeters, InverseInchesTolerance);
            AssertEx.EqualTolerance(1, ReciprocalLength.FromInverseMeters(inversemeter.InverseMeters).InverseMeters, InverseMetersTolerance);
            AssertEx.EqualTolerance(1, ReciprocalLength.FromInverseMicroinches(inversemeter.InverseMicroinches).InverseMeters, InverseMicroinchesTolerance);
            AssertEx.EqualTolerance(1, ReciprocalLength.FromInverseMils(inversemeter.InverseMils).InverseMeters, InverseMilsTolerance);
            AssertEx.EqualTolerance(1, ReciprocalLength.FromInverseMiles(inversemeter.InverseMiles).InverseMeters, InverseMilesTolerance);
            AssertEx.EqualTolerance(1, ReciprocalLength.FromInverseMillimeters(inversemeter.InverseMillimeters).InverseMeters, InverseMillimetersTolerance);
            AssertEx.EqualTolerance(1, ReciprocalLength.FromInverseUsSurveyFeet(inversemeter.InverseUsSurveyFeet).InverseMeters, InverseUsSurveyFeetTolerance);
            AssertEx.EqualTolerance(1, ReciprocalLength.FromInverseYards(inversemeter.InverseYards).InverseMeters, InverseYardsTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            ReciprocalLength v = ReciprocalLength.FromInverseMeters(1);
            AssertEx.EqualTolerance(-1, -v.InverseMeters, InverseMetersTolerance);
            AssertEx.EqualTolerance(2, (ReciprocalLength.FromInverseMeters(3)-v).InverseMeters, InverseMetersTolerance);
            AssertEx.EqualTolerance(2, (v + v).InverseMeters, InverseMetersTolerance);
            AssertEx.EqualTolerance(10, (v*10).InverseMeters, InverseMetersTolerance);
            AssertEx.EqualTolerance(10, (10*v).InverseMeters, InverseMetersTolerance);
            AssertEx.EqualTolerance(2, (ReciprocalLength.FromInverseMeters(10)/5).InverseMeters, InverseMetersTolerance);
            AssertEx.EqualTolerance(2, ReciprocalLength.FromInverseMeters(10)/ReciprocalLength.FromInverseMeters(5), InverseMetersTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            ReciprocalLength oneInverseMeter = ReciprocalLength.FromInverseMeters(1);
            ReciprocalLength twoInverseMeters = ReciprocalLength.FromInverseMeters(2);

            Assert.True(oneInverseMeter < twoInverseMeters);
            Assert.True(oneInverseMeter <= twoInverseMeters);
            Assert.True(twoInverseMeters > oneInverseMeter);
            Assert.True(twoInverseMeters >= oneInverseMeter);

            Assert.False(oneInverseMeter > twoInverseMeters);
            Assert.False(oneInverseMeter >= twoInverseMeters);
            Assert.False(twoInverseMeters < oneInverseMeter);
            Assert.False(twoInverseMeters <= oneInverseMeter);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            ReciprocalLength inversemeter = ReciprocalLength.FromInverseMeters(1);
            Assert.Equal(0, inversemeter.CompareTo(inversemeter));
            Assert.True(inversemeter.CompareTo(ReciprocalLength.Zero) > 0);
            Assert.True(ReciprocalLength.Zero.CompareTo(inversemeter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            ReciprocalLength inversemeter = ReciprocalLength.FromInverseMeters(1);
            Assert.Throws<ArgumentException>(() => inversemeter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            ReciprocalLength inversemeter = ReciprocalLength.FromInverseMeters(1);
            Assert.Throws<ArgumentNullException>(() => inversemeter.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = ReciprocalLength.FromInverseMeters(1);
            var b = ReciprocalLength.FromInverseMeters(2);

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
            var a = ReciprocalLength.FromInverseMeters(1);
            var b = ReciprocalLength.FromInverseMeters(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = ReciprocalLength.FromInverseMeters(1);
            object b = ReciprocalLength.FromInverseMeters(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = ReciprocalLength.FromInverseMeters(1);
            Assert.True(v.Equals(ReciprocalLength.FromInverseMeters(1), InverseMetersTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(ReciprocalLength.Zero, InverseMetersTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = ReciprocalLength.FromInverseMeters(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(ReciprocalLength.FromInverseMeters(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ReciprocalLength inversemeter = ReciprocalLength.FromInverseMeters(1);
            Assert.False(inversemeter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            ReciprocalLength inversemeter = ReciprocalLength.FromInverseMeters(1);
            Assert.False(inversemeter.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(ReciprocalLengthUnit.Undefined, ReciprocalLength.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(ReciprocalLengthUnit)).Cast<ReciprocalLengthUnit>();
            foreach(var unit in units)
            {
                if(unit == ReciprocalLengthUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(ReciprocalLength.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 cm⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseCentimeter).ToString());
                Assert.Equal("1 ft⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseFoot).ToString());
                Assert.Equal("1 in⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseInch).ToString());
                Assert.Equal("1 m⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseMeter).ToString());
                Assert.Equal("1 µin⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseMicroinch).ToString());
                Assert.Equal("1 mil⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseMil).ToString());
                Assert.Equal("1 mi⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseMile).ToString());
                Assert.Equal("1 mm⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseMillimeter).ToString());
                Assert.Equal("1 ftUS⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseUsSurveyFoot).ToString());
                Assert.Equal("1 yd⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseYard).ToString());
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

            Assert.Equal("1 cm⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseCentimeter).ToString(swedishCulture));
            Assert.Equal("1 ft⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseFoot).ToString(swedishCulture));
            Assert.Equal("1 in⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseInch).ToString(swedishCulture));
            Assert.Equal("1 m⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseMeter).ToString(swedishCulture));
            Assert.Equal("1 µin⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseMicroinch).ToString(swedishCulture));
            Assert.Equal("1 mil⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseMil).ToString(swedishCulture));
            Assert.Equal("1 mi⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseMile).ToString(swedishCulture));
            Assert.Equal("1 mm⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseMillimeter).ToString(swedishCulture));
            Assert.Equal("1 ftUS⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseUsSurveyFoot).ToString(swedishCulture));
            Assert.Equal("1 yd⁻¹", new ReciprocalLength(1, ReciprocalLengthUnit.InverseYard).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 m⁻¹", new ReciprocalLength(0.123456, ReciprocalLengthUnit.InverseMeter).ToString("s1"));
                Assert.Equal("0.12 m⁻¹", new ReciprocalLength(0.123456, ReciprocalLengthUnit.InverseMeter).ToString("s2"));
                Assert.Equal("0.123 m⁻¹", new ReciprocalLength(0.123456, ReciprocalLengthUnit.InverseMeter).ToString("s3"));
                Assert.Equal("0.1235 m⁻¹", new ReciprocalLength(0.123456, ReciprocalLengthUnit.InverseMeter).ToString("s4"));
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
            Assert.Equal("0.1 m⁻¹", new ReciprocalLength(0.123456, ReciprocalLengthUnit.InverseMeter).ToString("s1", culture));
            Assert.Equal("0.12 m⁻¹", new ReciprocalLength(0.123456, ReciprocalLengthUnit.InverseMeter).ToString("s2", culture));
            Assert.Equal("0.123 m⁻¹", new ReciprocalLength(0.123456, ReciprocalLengthUnit.InverseMeter).ToString("s3", culture));
            Assert.Equal("0.1235 m⁻¹", new ReciprocalLength(0.123456, ReciprocalLengthUnit.InverseMeter).ToString("s4", culture));
        }


        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }


        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(ReciprocalLength)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(ReciprocalLengthUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal(QuantityType.ReciprocalLength, Convert.ChangeType(quantity, typeof(QuantityType)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal(ReciprocalLength.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal(ReciprocalLength.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = ReciprocalLength.FromInverseMeters(1.0);
            Assert.Equal(new {ReciprocalLength.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = ReciprocalLength.FromInverseMeters(value);
            Assert.Equal(ReciprocalLength.FromInverseMeters(-value), -quantity);
        }
    }
}
