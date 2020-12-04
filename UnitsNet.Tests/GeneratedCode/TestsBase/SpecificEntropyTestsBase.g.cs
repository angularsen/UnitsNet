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
    /// Test of SpecificEntropy.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class SpecificEntropyTestsBase : QuantityTestsBase
    {
        protected abstract double BtusPerPoundFahrenheitInOneJoulePerKilogramKelvin { get; }
        protected abstract double CaloriesPerGramKelvinInOneJoulePerKilogramKelvin { get; }
        protected abstract double JoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin { get; }
        protected abstract double JoulesPerKilogramKelvinInOneJoulePerKilogramKelvin { get; }
        protected abstract double KilocaloriesPerGramKelvinInOneJoulePerKilogramKelvin { get; }
        protected abstract double KilojoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin { get; }
        protected abstract double KilojoulesPerKilogramKelvinInOneJoulePerKilogramKelvin { get; }
        protected abstract double MegajoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin { get; }
        protected abstract double MegajoulesPerKilogramKelvinInOneJoulePerKilogramKelvin { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double BtusPerPoundFahrenheitTolerance { get { return 1e-5; } }
        protected virtual double CaloriesPerGramKelvinTolerance { get { return 1e-5; } }
        protected virtual double JoulesPerKilogramDegreeCelsiusTolerance { get { return 1e-5; } }
        protected virtual double JoulesPerKilogramKelvinTolerance { get { return 1e-5; } }
        protected virtual double KilocaloriesPerGramKelvinTolerance { get { return 1e-5; } }
        protected virtual double KilojoulesPerKilogramDegreeCelsiusTolerance { get { return 1e-5; } }
        protected virtual double KilojoulesPerKilogramKelvinTolerance { get { return 1e-5; } }
        protected virtual double MegajoulesPerKilogramDegreeCelsiusTolerance { get { return 1e-5; } }
        protected virtual double MegajoulesPerKilogramKelvinTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new SpecificEntropy((double)0.0, SpecificEntropyUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new SpecificEntropy();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(SpecificEntropyUnit.JoulePerKilogramKelvin, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new SpecificEntropy(double.PositiveInfinity, SpecificEntropyUnit.JoulePerKilogramKelvin));
            Assert.Throws<ArgumentException>(() => new SpecificEntropy(double.NegativeInfinity, SpecificEntropyUnit.JoulePerKilogramKelvin));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new SpecificEntropy(double.NaN, SpecificEntropyUnit.JoulePerKilogramKelvin));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SpecificEntropy(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new SpecificEntropy(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (SpecificEntropy) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void SpecificEntropy_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new SpecificEntropy(1, SpecificEntropyUnit.JoulePerKilogramKelvin);

            QuantityInfo<SpecificEntropyUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(SpecificEntropy.Zero, quantityInfo.Zero);
            Assert.Equal("SpecificEntropy", quantityInfo.Name);

            var units = EnumUtils.GetEnumValues<SpecificEntropyUnit>().Except(new[] {SpecificEntropyUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
#pragma warning disable 618
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
#pragma warning restore 618
        }

        [Fact]
        public void JoulePerKilogramKelvinToSpecificEntropyUnits()
        {
            SpecificEntropy jouleperkilogramkelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            AssertEx.EqualTolerance(BtusPerPoundFahrenheitInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.BtusPerPoundFahrenheit, BtusPerPoundFahrenheitTolerance);
            AssertEx.EqualTolerance(CaloriesPerGramKelvinInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.CaloriesPerGramKelvin, CaloriesPerGramKelvinTolerance);
            AssertEx.EqualTolerance(JoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.JoulesPerKilogramDegreeCelsius, JoulesPerKilogramDegreeCelsiusTolerance);
            AssertEx.EqualTolerance(JoulesPerKilogramKelvinInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.JoulesPerKilogramKelvin, JoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(KilocaloriesPerGramKelvinInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.KilocaloriesPerGramKelvin, KilocaloriesPerGramKelvinTolerance);
            AssertEx.EqualTolerance(KilojoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.KilojoulesPerKilogramDegreeCelsius, KilojoulesPerKilogramDegreeCelsiusTolerance);
            AssertEx.EqualTolerance(KilojoulesPerKilogramKelvinInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.KilojoulesPerKilogramKelvin, KilojoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(MegajoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.MegajoulesPerKilogramDegreeCelsius, MegajoulesPerKilogramDegreeCelsiusTolerance);
            AssertEx.EqualTolerance(MegajoulesPerKilogramKelvinInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.MegajoulesPerKilogramKelvin, MegajoulesPerKilogramKelvinTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = SpecificEntropy.From(1, SpecificEntropyUnit.BtuPerPoundFahrenheit);
            AssertEx.EqualTolerance(1, quantity00.BtusPerPoundFahrenheit, BtusPerPoundFahrenheitTolerance);
            Assert.Equal(SpecificEntropyUnit.BtuPerPoundFahrenheit, quantity00.Unit);

            var quantity01 = SpecificEntropy.From(1, SpecificEntropyUnit.CaloriePerGramKelvin);
            AssertEx.EqualTolerance(1, quantity01.CaloriesPerGramKelvin, CaloriesPerGramKelvinTolerance);
            Assert.Equal(SpecificEntropyUnit.CaloriePerGramKelvin, quantity01.Unit);

            var quantity02 = SpecificEntropy.From(1, SpecificEntropyUnit.JoulePerKilogramDegreeCelsius);
            AssertEx.EqualTolerance(1, quantity02.JoulesPerKilogramDegreeCelsius, JoulesPerKilogramDegreeCelsiusTolerance);
            Assert.Equal(SpecificEntropyUnit.JoulePerKilogramDegreeCelsius, quantity02.Unit);

            var quantity03 = SpecificEntropy.From(1, SpecificEntropyUnit.JoulePerKilogramKelvin);
            AssertEx.EqualTolerance(1, quantity03.JoulesPerKilogramKelvin, JoulesPerKilogramKelvinTolerance);
            Assert.Equal(SpecificEntropyUnit.JoulePerKilogramKelvin, quantity03.Unit);

            var quantity04 = SpecificEntropy.From(1, SpecificEntropyUnit.KilocaloriePerGramKelvin);
            AssertEx.EqualTolerance(1, quantity04.KilocaloriesPerGramKelvin, KilocaloriesPerGramKelvinTolerance);
            Assert.Equal(SpecificEntropyUnit.KilocaloriePerGramKelvin, quantity04.Unit);

            var quantity05 = SpecificEntropy.From(1, SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius);
            AssertEx.EqualTolerance(1, quantity05.KilojoulesPerKilogramDegreeCelsius, KilojoulesPerKilogramDegreeCelsiusTolerance);
            Assert.Equal(SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius, quantity05.Unit);

            var quantity06 = SpecificEntropy.From(1, SpecificEntropyUnit.KilojoulePerKilogramKelvin);
            AssertEx.EqualTolerance(1, quantity06.KilojoulesPerKilogramKelvin, KilojoulesPerKilogramKelvinTolerance);
            Assert.Equal(SpecificEntropyUnit.KilojoulePerKilogramKelvin, quantity06.Unit);

            var quantity07 = SpecificEntropy.From(1, SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius);
            AssertEx.EqualTolerance(1, quantity07.MegajoulesPerKilogramDegreeCelsius, MegajoulesPerKilogramDegreeCelsiusTolerance);
            Assert.Equal(SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius, quantity07.Unit);

            var quantity08 = SpecificEntropy.From(1, SpecificEntropyUnit.MegajoulePerKilogramKelvin);
            AssertEx.EqualTolerance(1, quantity08.MegajoulesPerKilogramKelvin, MegajoulesPerKilogramKelvinTolerance);
            Assert.Equal(SpecificEntropyUnit.MegajoulePerKilogramKelvin, quantity08.Unit);

        }

        [Fact]
        public void FromJoulesPerKilogramKelvin_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => SpecificEntropy.FromJoulesPerKilogramKelvin(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => SpecificEntropy.FromJoulesPerKilogramKelvin(double.NegativeInfinity));
        }

        [Fact]
        public void FromJoulesPerKilogramKelvin_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => SpecificEntropy.FromJoulesPerKilogramKelvin(double.NaN));
        }

        [Fact]
        public void As()
        {
            var jouleperkilogramkelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            AssertEx.EqualTolerance(BtusPerPoundFahrenheitInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.As(SpecificEntropyUnit.BtuPerPoundFahrenheit), BtusPerPoundFahrenheitTolerance);
            AssertEx.EqualTolerance(CaloriesPerGramKelvinInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.As(SpecificEntropyUnit.CaloriePerGramKelvin), CaloriesPerGramKelvinTolerance);
            AssertEx.EqualTolerance(JoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.As(SpecificEntropyUnit.JoulePerKilogramDegreeCelsius), JoulesPerKilogramDegreeCelsiusTolerance);
            AssertEx.EqualTolerance(JoulesPerKilogramKelvinInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.As(SpecificEntropyUnit.JoulePerKilogramKelvin), JoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(KilocaloriesPerGramKelvinInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.As(SpecificEntropyUnit.KilocaloriePerGramKelvin), KilocaloriesPerGramKelvinTolerance);
            AssertEx.EqualTolerance(KilojoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.As(SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius), KilojoulesPerKilogramDegreeCelsiusTolerance);
            AssertEx.EqualTolerance(KilojoulesPerKilogramKelvinInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.As(SpecificEntropyUnit.KilojoulePerKilogramKelvin), KilojoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(MegajoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.As(SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius), MegajoulesPerKilogramDegreeCelsiusTolerance);
            AssertEx.EqualTolerance(MegajoulesPerKilogramKelvinInOneJoulePerKilogramKelvin, jouleperkilogramkelvin.As(SpecificEntropyUnit.MegajoulePerKilogramKelvin), MegajoulesPerKilogramKelvinTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new SpecificEntropy(value: 1, unit: SpecificEntropy.BaseUnit);
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
            var jouleperkilogramkelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(1);

            var btuperpoundfahrenheitQuantity = jouleperkilogramkelvin.ToUnit(SpecificEntropyUnit.BtuPerPoundFahrenheit);
            AssertEx.EqualTolerance(BtusPerPoundFahrenheitInOneJoulePerKilogramKelvin, (double)btuperpoundfahrenheitQuantity.Value, BtusPerPoundFahrenheitTolerance);
            Assert.Equal(SpecificEntropyUnit.BtuPerPoundFahrenheit, btuperpoundfahrenheitQuantity.Unit);

            var caloriepergramkelvinQuantity = jouleperkilogramkelvin.ToUnit(SpecificEntropyUnit.CaloriePerGramKelvin);
            AssertEx.EqualTolerance(CaloriesPerGramKelvinInOneJoulePerKilogramKelvin, (double)caloriepergramkelvinQuantity.Value, CaloriesPerGramKelvinTolerance);
            Assert.Equal(SpecificEntropyUnit.CaloriePerGramKelvin, caloriepergramkelvinQuantity.Unit);

            var jouleperkilogramdegreecelsiusQuantity = jouleperkilogramkelvin.ToUnit(SpecificEntropyUnit.JoulePerKilogramDegreeCelsius);
            AssertEx.EqualTolerance(JoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin, (double)jouleperkilogramdegreecelsiusQuantity.Value, JoulesPerKilogramDegreeCelsiusTolerance);
            Assert.Equal(SpecificEntropyUnit.JoulePerKilogramDegreeCelsius, jouleperkilogramdegreecelsiusQuantity.Unit);

            var jouleperkilogramkelvinQuantity = jouleperkilogramkelvin.ToUnit(SpecificEntropyUnit.JoulePerKilogramKelvin);
            AssertEx.EqualTolerance(JoulesPerKilogramKelvinInOneJoulePerKilogramKelvin, (double)jouleperkilogramkelvinQuantity.Value, JoulesPerKilogramKelvinTolerance);
            Assert.Equal(SpecificEntropyUnit.JoulePerKilogramKelvin, jouleperkilogramkelvinQuantity.Unit);

            var kilocaloriepergramkelvinQuantity = jouleperkilogramkelvin.ToUnit(SpecificEntropyUnit.KilocaloriePerGramKelvin);
            AssertEx.EqualTolerance(KilocaloriesPerGramKelvinInOneJoulePerKilogramKelvin, (double)kilocaloriepergramkelvinQuantity.Value, KilocaloriesPerGramKelvinTolerance);
            Assert.Equal(SpecificEntropyUnit.KilocaloriePerGramKelvin, kilocaloriepergramkelvinQuantity.Unit);

            var kilojouleperkilogramdegreecelsiusQuantity = jouleperkilogramkelvin.ToUnit(SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius);
            AssertEx.EqualTolerance(KilojoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin, (double)kilojouleperkilogramdegreecelsiusQuantity.Value, KilojoulesPerKilogramDegreeCelsiusTolerance);
            Assert.Equal(SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius, kilojouleperkilogramdegreecelsiusQuantity.Unit);

            var kilojouleperkilogramkelvinQuantity = jouleperkilogramkelvin.ToUnit(SpecificEntropyUnit.KilojoulePerKilogramKelvin);
            AssertEx.EqualTolerance(KilojoulesPerKilogramKelvinInOneJoulePerKilogramKelvin, (double)kilojouleperkilogramkelvinQuantity.Value, KilojoulesPerKilogramKelvinTolerance);
            Assert.Equal(SpecificEntropyUnit.KilojoulePerKilogramKelvin, kilojouleperkilogramkelvinQuantity.Unit);

            var megajouleperkilogramdegreecelsiusQuantity = jouleperkilogramkelvin.ToUnit(SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius);
            AssertEx.EqualTolerance(MegajoulesPerKilogramDegreeCelsiusInOneJoulePerKilogramKelvin, (double)megajouleperkilogramdegreecelsiusQuantity.Value, MegajoulesPerKilogramDegreeCelsiusTolerance);
            Assert.Equal(SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius, megajouleperkilogramdegreecelsiusQuantity.Unit);

            var megajouleperkilogramkelvinQuantity = jouleperkilogramkelvin.ToUnit(SpecificEntropyUnit.MegajoulePerKilogramKelvin);
            AssertEx.EqualTolerance(MegajoulesPerKilogramKelvinInOneJoulePerKilogramKelvin, (double)megajouleperkilogramkelvinQuantity.Value, MegajoulesPerKilogramKelvinTolerance);
            Assert.Equal(SpecificEntropyUnit.MegajoulePerKilogramKelvin, megajouleperkilogramkelvinQuantity.Unit);
        }

        [Fact]
        public void ToBaseUnit_ReturnsQuantityWithBaseUnit()
        {
            var quantityInBaseUnit = SpecificEntropy.FromJoulesPerKilogramKelvin(1).ToBaseUnit();
            Assert.Equal(SpecificEntropy.BaseUnit, quantityInBaseUnit.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            SpecificEntropy jouleperkilogramkelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            AssertEx.EqualTolerance(1, SpecificEntropy.FromBtusPerPoundFahrenheit(jouleperkilogramkelvin.BtusPerPoundFahrenheit).JoulesPerKilogramKelvin, BtusPerPoundFahrenheitTolerance);
            AssertEx.EqualTolerance(1, SpecificEntropy.FromCaloriesPerGramKelvin(jouleperkilogramkelvin.CaloriesPerGramKelvin).JoulesPerKilogramKelvin, CaloriesPerGramKelvinTolerance);
            AssertEx.EqualTolerance(1, SpecificEntropy.FromJoulesPerKilogramDegreeCelsius(jouleperkilogramkelvin.JoulesPerKilogramDegreeCelsius).JoulesPerKilogramKelvin, JoulesPerKilogramDegreeCelsiusTolerance);
            AssertEx.EqualTolerance(1, SpecificEntropy.FromJoulesPerKilogramKelvin(jouleperkilogramkelvin.JoulesPerKilogramKelvin).JoulesPerKilogramKelvin, JoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(1, SpecificEntropy.FromKilocaloriesPerGramKelvin(jouleperkilogramkelvin.KilocaloriesPerGramKelvin).JoulesPerKilogramKelvin, KilocaloriesPerGramKelvinTolerance);
            AssertEx.EqualTolerance(1, SpecificEntropy.FromKilojoulesPerKilogramDegreeCelsius(jouleperkilogramkelvin.KilojoulesPerKilogramDegreeCelsius).JoulesPerKilogramKelvin, KilojoulesPerKilogramDegreeCelsiusTolerance);
            AssertEx.EqualTolerance(1, SpecificEntropy.FromKilojoulesPerKilogramKelvin(jouleperkilogramkelvin.KilojoulesPerKilogramKelvin).JoulesPerKilogramKelvin, KilojoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(1, SpecificEntropy.FromMegajoulesPerKilogramDegreeCelsius(jouleperkilogramkelvin.MegajoulesPerKilogramDegreeCelsius).JoulesPerKilogramKelvin, MegajoulesPerKilogramDegreeCelsiusTolerance);
            AssertEx.EqualTolerance(1, SpecificEntropy.FromMegajoulesPerKilogramKelvin(jouleperkilogramkelvin.MegajoulesPerKilogramKelvin).JoulesPerKilogramKelvin, MegajoulesPerKilogramKelvinTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            SpecificEntropy v = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            AssertEx.EqualTolerance(-1, -v.JoulesPerKilogramKelvin, JoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(2, (SpecificEntropy.FromJoulesPerKilogramKelvin(3)-v).JoulesPerKilogramKelvin, JoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(2, (v + v).JoulesPerKilogramKelvin, JoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(10, (v*10).JoulesPerKilogramKelvin, JoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(10, (10*v).JoulesPerKilogramKelvin, JoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(2, (SpecificEntropy.FromJoulesPerKilogramKelvin(10)/5).JoulesPerKilogramKelvin, JoulesPerKilogramKelvinTolerance);
            AssertEx.EqualTolerance(2, SpecificEntropy.FromJoulesPerKilogramKelvin(10)/SpecificEntropy.FromJoulesPerKilogramKelvin(5), JoulesPerKilogramKelvinTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            SpecificEntropy oneJoulePerKilogramKelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            SpecificEntropy twoJoulesPerKilogramKelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(2);

            Assert.True(oneJoulePerKilogramKelvin < twoJoulesPerKilogramKelvin);
            Assert.True(oneJoulePerKilogramKelvin <= twoJoulesPerKilogramKelvin);
            Assert.True(twoJoulesPerKilogramKelvin > oneJoulePerKilogramKelvin);
            Assert.True(twoJoulesPerKilogramKelvin >= oneJoulePerKilogramKelvin);

            Assert.False(oneJoulePerKilogramKelvin > twoJoulesPerKilogramKelvin);
            Assert.False(oneJoulePerKilogramKelvin >= twoJoulesPerKilogramKelvin);
            Assert.False(twoJoulesPerKilogramKelvin < oneJoulePerKilogramKelvin);
            Assert.False(twoJoulesPerKilogramKelvin <= oneJoulePerKilogramKelvin);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            SpecificEntropy jouleperkilogramkelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            Assert.Equal(0, jouleperkilogramkelvin.CompareTo(jouleperkilogramkelvin));
            Assert.True(jouleperkilogramkelvin.CompareTo(SpecificEntropy.Zero) > 0);
            Assert.True(SpecificEntropy.Zero.CompareTo(jouleperkilogramkelvin) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            SpecificEntropy jouleperkilogramkelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            Assert.Throws<ArgumentException>(() => jouleperkilogramkelvin.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            SpecificEntropy jouleperkilogramkelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            Assert.Throws<ArgumentNullException>(() => jouleperkilogramkelvin.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            var b = SpecificEntropy.FromJoulesPerKilogramKelvin(2);

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
            var a = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            var b = SpecificEntropy.FromJoulesPerKilogramKelvin(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            object b = SpecificEntropy.FromJoulesPerKilogramKelvin(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            Assert.True(v.Equals(SpecificEntropy.FromJoulesPerKilogramKelvin(1), JoulesPerKilogramKelvinTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(SpecificEntropy.Zero, JoulesPerKilogramKelvinTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(SpecificEntropy.FromJoulesPerKilogramKelvin(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            SpecificEntropy jouleperkilogramkelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            Assert.False(jouleperkilogramkelvin.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            SpecificEntropy jouleperkilogramkelvin = SpecificEntropy.FromJoulesPerKilogramKelvin(1);
            Assert.False(jouleperkilogramkelvin.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(SpecificEntropyUnit.Undefined, SpecificEntropy.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(SpecificEntropyUnit)).Cast<SpecificEntropyUnit>();
            foreach(var unit in units)
            {
                if(unit == SpecificEntropyUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(SpecificEntropy.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 BTU/lb·°F", new SpecificEntropy(1, SpecificEntropyUnit.BtuPerPoundFahrenheit).ToString());
                Assert.Equal("1 cal/g.K", new SpecificEntropy(1, SpecificEntropyUnit.CaloriePerGramKelvin).ToString());
                Assert.Equal("1 J/kg.C", new SpecificEntropy(1, SpecificEntropyUnit.JoulePerKilogramDegreeCelsius).ToString());
                Assert.Equal("1 J/kg.K", new SpecificEntropy(1, SpecificEntropyUnit.JoulePerKilogramKelvin).ToString());
                Assert.Equal("1 kcal/g.K", new SpecificEntropy(1, SpecificEntropyUnit.KilocaloriePerGramKelvin).ToString());
                Assert.Equal("1 kJ/kg.C", new SpecificEntropy(1, SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius).ToString());
                Assert.Equal("1 kJ/kg.K", new SpecificEntropy(1, SpecificEntropyUnit.KilojoulePerKilogramKelvin).ToString());
                Assert.Equal("1 MJ/kg.C", new SpecificEntropy(1, SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius).ToString());
                Assert.Equal("1 MJ/kg.K", new SpecificEntropy(1, SpecificEntropyUnit.MegajoulePerKilogramKelvin).ToString());
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

            Assert.Equal("1 BTU/lb·°F", new SpecificEntropy(1, SpecificEntropyUnit.BtuPerPoundFahrenheit).ToString(swedishCulture));
            Assert.Equal("1 cal/g.K", new SpecificEntropy(1, SpecificEntropyUnit.CaloriePerGramKelvin).ToString(swedishCulture));
            Assert.Equal("1 J/kg.C", new SpecificEntropy(1, SpecificEntropyUnit.JoulePerKilogramDegreeCelsius).ToString(swedishCulture));
            Assert.Equal("1 J/kg.K", new SpecificEntropy(1, SpecificEntropyUnit.JoulePerKilogramKelvin).ToString(swedishCulture));
            Assert.Equal("1 kcal/g.K", new SpecificEntropy(1, SpecificEntropyUnit.KilocaloriePerGramKelvin).ToString(swedishCulture));
            Assert.Equal("1 kJ/kg.C", new SpecificEntropy(1, SpecificEntropyUnit.KilojoulePerKilogramDegreeCelsius).ToString(swedishCulture));
            Assert.Equal("1 kJ/kg.K", new SpecificEntropy(1, SpecificEntropyUnit.KilojoulePerKilogramKelvin).ToString(swedishCulture));
            Assert.Equal("1 MJ/kg.C", new SpecificEntropy(1, SpecificEntropyUnit.MegajoulePerKilogramDegreeCelsius).ToString(swedishCulture));
            Assert.Equal("1 MJ/kg.K", new SpecificEntropy(1, SpecificEntropyUnit.MegajoulePerKilogramKelvin).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 J/kg.K", new SpecificEntropy(0.123456, SpecificEntropyUnit.JoulePerKilogramKelvin).ToString("s1"));
                Assert.Equal("0.12 J/kg.K", new SpecificEntropy(0.123456, SpecificEntropyUnit.JoulePerKilogramKelvin).ToString("s2"));
                Assert.Equal("0.123 J/kg.K", new SpecificEntropy(0.123456, SpecificEntropyUnit.JoulePerKilogramKelvin).ToString("s3"));
                Assert.Equal("0.1235 J/kg.K", new SpecificEntropy(0.123456, SpecificEntropyUnit.JoulePerKilogramKelvin).ToString("s4"));
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
            Assert.Equal("0.1 J/kg.K", new SpecificEntropy(0.123456, SpecificEntropyUnit.JoulePerKilogramKelvin).ToString("s1", culture));
            Assert.Equal("0.12 J/kg.K", new SpecificEntropy(0.123456, SpecificEntropyUnit.JoulePerKilogramKelvin).ToString("s2", culture));
            Assert.Equal("0.123 J/kg.K", new SpecificEntropy(0.123456, SpecificEntropyUnit.JoulePerKilogramKelvin).ToString("s3", culture));
            Assert.Equal("0.1235 J/kg.K", new SpecificEntropy(0.123456, SpecificEntropyUnit.JoulePerKilogramKelvin).ToString("s4", culture));
        }

        #pragma warning disable 612, 618

        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }

        #pragma warning restore 612, 618

        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(SpecificEntropy)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(SpecificEntropyUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal(SpecificEntropy.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal(SpecificEntropy.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(1.0);
            Assert.Equal(new {SpecificEntropy.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = SpecificEntropy.FromJoulesPerKilogramKelvin(value);
            Assert.Equal(SpecificEntropy.FromJoulesPerKilogramKelvin(-value), -quantity);
        }
    }
}
