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
    /// Test of Luminosity.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class LuminosityTestsBase : QuantityTestsBase
    {
        protected abstract double DecawattsInOneWatt { get; }
        protected abstract double DeciwattsInOneWatt { get; }
        protected abstract double FemtowattsInOneWatt { get; }
        protected abstract double GigawattsInOneWatt { get; }
        protected abstract double KilowattsInOneWatt { get; }
        protected abstract double MegawattsInOneWatt { get; }
        protected abstract double MicrowattsInOneWatt { get; }
        protected abstract double MilliwattsInOneWatt { get; }
        protected abstract double NanowattsInOneWatt { get; }
        protected abstract double PetawattsInOneWatt { get; }
        protected abstract double PicowattsInOneWatt { get; }
        protected abstract double SolarLuminositiesInOneWatt { get; }
        protected abstract double TerawattsInOneWatt { get; }
        protected abstract double WattsInOneWatt { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DecawattsTolerance { get { return 1e-5; } }
        protected virtual double DeciwattsTolerance { get { return 1e-5; } }
        protected virtual double FemtowattsTolerance { get { return 1e-5; } }
        protected virtual double GigawattsTolerance { get { return 1e-5; } }
        protected virtual double KilowattsTolerance { get { return 1e-5; } }
        protected virtual double MegawattsTolerance { get { return 1e-5; } }
        protected virtual double MicrowattsTolerance { get { return 1e-5; } }
        protected virtual double MilliwattsTolerance { get { return 1e-5; } }
        protected virtual double NanowattsTolerance { get { return 1e-5; } }
        protected virtual double PetawattsTolerance { get { return 1e-5; } }
        protected virtual double PicowattsTolerance { get { return 1e-5; } }
        protected virtual double SolarLuminositiesTolerance { get { return 1e-5; } }
        protected virtual double TerawattsTolerance { get { return 1e-5; } }
        protected virtual double WattsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        protected (double UnitsInBaseUnit, double Tolerence) GetConversionFactor(LuminosityUnit unit)
        {
            return unit switch
            {
                LuminosityUnit.Decawatt => (DecawattsInOneWatt, DecawattsTolerance),
                LuminosityUnit.Deciwatt => (DeciwattsInOneWatt, DeciwattsTolerance),
                LuminosityUnit.Femtowatt => (FemtowattsInOneWatt, FemtowattsTolerance),
                LuminosityUnit.Gigawatt => (GigawattsInOneWatt, GigawattsTolerance),
                LuminosityUnit.Kilowatt => (KilowattsInOneWatt, KilowattsTolerance),
                LuminosityUnit.Megawatt => (MegawattsInOneWatt, MegawattsTolerance),
                LuminosityUnit.Microwatt => (MicrowattsInOneWatt, MicrowattsTolerance),
                LuminosityUnit.Milliwatt => (MilliwattsInOneWatt, MilliwattsTolerance),
                LuminosityUnit.Nanowatt => (NanowattsInOneWatt, NanowattsTolerance),
                LuminosityUnit.Petawatt => (PetawattsInOneWatt, PetawattsTolerance),
                LuminosityUnit.Picowatt => (PicowattsInOneWatt, PicowattsTolerance),
                LuminosityUnit.SolarLuminosity => (SolarLuminositiesInOneWatt, SolarLuminositiesTolerance),
                LuminosityUnit.Terawatt => (TerawattsInOneWatt, TerawattsTolerance),
                LuminosityUnit.Watt => (WattsInOneWatt, WattsTolerance),
                _ => throw new NotSupportedException()
            };
        }

        public static IEnumerable<object[]> UnitTypes = new List<object[]>
        {
            new object[] { LuminosityUnit.Decawatt },
            new object[] { LuminosityUnit.Deciwatt },
            new object[] { LuminosityUnit.Femtowatt },
            new object[] { LuminosityUnit.Gigawatt },
            new object[] { LuminosityUnit.Kilowatt },
            new object[] { LuminosityUnit.Megawatt },
            new object[] { LuminosityUnit.Microwatt },
            new object[] { LuminosityUnit.Milliwatt },
            new object[] { LuminosityUnit.Nanowatt },
            new object[] { LuminosityUnit.Petawatt },
            new object[] { LuminosityUnit.Picowatt },
            new object[] { LuminosityUnit.SolarLuminosity },
            new object[] { LuminosityUnit.Terawatt },
            new object[] { LuminosityUnit.Watt },
        };

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Luminosity((double)0.0, LuminosityUnit.Undefined));
        }

        [Fact]
        public void DefaultCtor_ReturnsQuantityWithZeroValueAndBaseUnit()
        {
            var quantity = new Luminosity();
            Assert.Equal(0, quantity.Value);
            Assert.Equal(LuminosityUnit.Watt, quantity.Unit);
        }


        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Luminosity(double.PositiveInfinity, LuminosityUnit.Watt));
            Assert.Throws<ArgumentException>(() => new Luminosity(double.NegativeInfinity, LuminosityUnit.Watt));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Luminosity(double.NaN, LuminosityUnit.Watt));
        }

        [Fact]
        public void Ctor_NullAsUnitSystem_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Luminosity(value: 1, unitSystem: null));
        }

        [Fact]
        public void Ctor_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            Func<object> TestCode = () => new Luminosity(value: 1, unitSystem: UnitSystem.SI);
            if (SupportsSIUnitSystem)
            {
                var quantity = (Luminosity) TestCode();
                Assert.Equal(1, quantity.Value);
            }
            else
            {
                Assert.Throws<ArgumentException>(TestCode);
            }
        }

        [Fact]
        public void Luminosity_QuantityInfo_ReturnsQuantityInfoDescribingQuantity()
        {
            var quantity = new Luminosity(1, LuminosityUnit.Watt);

            QuantityInfo<LuminosityUnit> quantityInfo = quantity.QuantityInfo;

            Assert.Equal(Luminosity.Zero, quantityInfo.Zero);
            Assert.Equal("Luminosity", quantityInfo.Name);
            Assert.Equal(QuantityType.Luminosity, quantityInfo.QuantityType);

            var units = EnumUtils.GetEnumValues<LuminosityUnit>().Except(new[] {LuminosityUnit.Undefined}).ToArray();
            var unitNames = units.Select(x => x.ToString());

            // Obsolete members
            Assert.Equal(units, quantityInfo.Units);
            Assert.Equal(unitNames, quantityInfo.UnitNames);
        }

        [Fact]
        public void WattToLuminosityUnits()
        {
            Luminosity watt = Luminosity.FromWatts(1);
            AssertEx.EqualTolerance(DecawattsInOneWatt, watt.Decawatts, DecawattsTolerance);
            AssertEx.EqualTolerance(DeciwattsInOneWatt, watt.Deciwatts, DeciwattsTolerance);
            AssertEx.EqualTolerance(FemtowattsInOneWatt, watt.Femtowatts, FemtowattsTolerance);
            AssertEx.EqualTolerance(GigawattsInOneWatt, watt.Gigawatts, GigawattsTolerance);
            AssertEx.EqualTolerance(KilowattsInOneWatt, watt.Kilowatts, KilowattsTolerance);
            AssertEx.EqualTolerance(MegawattsInOneWatt, watt.Megawatts, MegawattsTolerance);
            AssertEx.EqualTolerance(MicrowattsInOneWatt, watt.Microwatts, MicrowattsTolerance);
            AssertEx.EqualTolerance(MilliwattsInOneWatt, watt.Milliwatts, MilliwattsTolerance);
            AssertEx.EqualTolerance(NanowattsInOneWatt, watt.Nanowatts, NanowattsTolerance);
            AssertEx.EqualTolerance(PetawattsInOneWatt, watt.Petawatts, PetawattsTolerance);
            AssertEx.EqualTolerance(PicowattsInOneWatt, watt.Picowatts, PicowattsTolerance);
            AssertEx.EqualTolerance(SolarLuminositiesInOneWatt, watt.SolarLuminosities, SolarLuminositiesTolerance);
            AssertEx.EqualTolerance(TerawattsInOneWatt, watt.Terawatts, TerawattsTolerance);
            AssertEx.EqualTolerance(WattsInOneWatt, watt.Watts, WattsTolerance);
        }

        [Fact]
        public void From_ValueAndUnit_ReturnsQuantityWithSameValueAndUnit()
        {
            var quantity00 = Luminosity.From(1, LuminosityUnit.Decawatt);
            AssertEx.EqualTolerance(1, quantity00.Decawatts, DecawattsTolerance);
            Assert.Equal(LuminosityUnit.Decawatt, quantity00.Unit);

            var quantity01 = Luminosity.From(1, LuminosityUnit.Deciwatt);
            AssertEx.EqualTolerance(1, quantity01.Deciwatts, DeciwattsTolerance);
            Assert.Equal(LuminosityUnit.Deciwatt, quantity01.Unit);

            var quantity02 = Luminosity.From(1, LuminosityUnit.Femtowatt);
            AssertEx.EqualTolerance(1, quantity02.Femtowatts, FemtowattsTolerance);
            Assert.Equal(LuminosityUnit.Femtowatt, quantity02.Unit);

            var quantity03 = Luminosity.From(1, LuminosityUnit.Gigawatt);
            AssertEx.EqualTolerance(1, quantity03.Gigawatts, GigawattsTolerance);
            Assert.Equal(LuminosityUnit.Gigawatt, quantity03.Unit);

            var quantity04 = Luminosity.From(1, LuminosityUnit.Kilowatt);
            AssertEx.EqualTolerance(1, quantity04.Kilowatts, KilowattsTolerance);
            Assert.Equal(LuminosityUnit.Kilowatt, quantity04.Unit);

            var quantity05 = Luminosity.From(1, LuminosityUnit.Megawatt);
            AssertEx.EqualTolerance(1, quantity05.Megawatts, MegawattsTolerance);
            Assert.Equal(LuminosityUnit.Megawatt, quantity05.Unit);

            var quantity06 = Luminosity.From(1, LuminosityUnit.Microwatt);
            AssertEx.EqualTolerance(1, quantity06.Microwatts, MicrowattsTolerance);
            Assert.Equal(LuminosityUnit.Microwatt, quantity06.Unit);

            var quantity07 = Luminosity.From(1, LuminosityUnit.Milliwatt);
            AssertEx.EqualTolerance(1, quantity07.Milliwatts, MilliwattsTolerance);
            Assert.Equal(LuminosityUnit.Milliwatt, quantity07.Unit);

            var quantity08 = Luminosity.From(1, LuminosityUnit.Nanowatt);
            AssertEx.EqualTolerance(1, quantity08.Nanowatts, NanowattsTolerance);
            Assert.Equal(LuminosityUnit.Nanowatt, quantity08.Unit);

            var quantity09 = Luminosity.From(1, LuminosityUnit.Petawatt);
            AssertEx.EqualTolerance(1, quantity09.Petawatts, PetawattsTolerance);
            Assert.Equal(LuminosityUnit.Petawatt, quantity09.Unit);

            var quantity10 = Luminosity.From(1, LuminosityUnit.Picowatt);
            AssertEx.EqualTolerance(1, quantity10.Picowatts, PicowattsTolerance);
            Assert.Equal(LuminosityUnit.Picowatt, quantity10.Unit);

            var quantity11 = Luminosity.From(1, LuminosityUnit.SolarLuminosity);
            AssertEx.EqualTolerance(1, quantity11.SolarLuminosities, SolarLuminositiesTolerance);
            Assert.Equal(LuminosityUnit.SolarLuminosity, quantity11.Unit);

            var quantity12 = Luminosity.From(1, LuminosityUnit.Terawatt);
            AssertEx.EqualTolerance(1, quantity12.Terawatts, TerawattsTolerance);
            Assert.Equal(LuminosityUnit.Terawatt, quantity12.Unit);

            var quantity13 = Luminosity.From(1, LuminosityUnit.Watt);
            AssertEx.EqualTolerance(1, quantity13.Watts, WattsTolerance);
            Assert.Equal(LuminosityUnit.Watt, quantity13.Unit);

        }

        [Fact]
        public void FromWatts_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Luminosity.FromWatts(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => Luminosity.FromWatts(double.NegativeInfinity));
        }

        [Fact]
        public void FromWatts_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Luminosity.FromWatts(double.NaN));
        }

        [Fact]
        public void As()
        {
            var watt = Luminosity.FromWatts(1);
            AssertEx.EqualTolerance(DecawattsInOneWatt, watt.As(LuminosityUnit.Decawatt), DecawattsTolerance);
            AssertEx.EqualTolerance(DeciwattsInOneWatt, watt.As(LuminosityUnit.Deciwatt), DeciwattsTolerance);
            AssertEx.EqualTolerance(FemtowattsInOneWatt, watt.As(LuminosityUnit.Femtowatt), FemtowattsTolerance);
            AssertEx.EqualTolerance(GigawattsInOneWatt, watt.As(LuminosityUnit.Gigawatt), GigawattsTolerance);
            AssertEx.EqualTolerance(KilowattsInOneWatt, watt.As(LuminosityUnit.Kilowatt), KilowattsTolerance);
            AssertEx.EqualTolerance(MegawattsInOneWatt, watt.As(LuminosityUnit.Megawatt), MegawattsTolerance);
            AssertEx.EqualTolerance(MicrowattsInOneWatt, watt.As(LuminosityUnit.Microwatt), MicrowattsTolerance);
            AssertEx.EqualTolerance(MilliwattsInOneWatt, watt.As(LuminosityUnit.Milliwatt), MilliwattsTolerance);
            AssertEx.EqualTolerance(NanowattsInOneWatt, watt.As(LuminosityUnit.Nanowatt), NanowattsTolerance);
            AssertEx.EqualTolerance(PetawattsInOneWatt, watt.As(LuminosityUnit.Petawatt), PetawattsTolerance);
            AssertEx.EqualTolerance(PicowattsInOneWatt, watt.As(LuminosityUnit.Picowatt), PicowattsTolerance);
            AssertEx.EqualTolerance(SolarLuminositiesInOneWatt, watt.As(LuminosityUnit.SolarLuminosity), SolarLuminositiesTolerance);
            AssertEx.EqualTolerance(TerawattsInOneWatt, watt.As(LuminosityUnit.Terawatt), TerawattsTolerance);
            AssertEx.EqualTolerance(WattsInOneWatt, watt.As(LuminosityUnit.Watt), WattsTolerance);
        }

        [Fact]
        public void As_SIUnitSystem_ThrowsArgumentExceptionIfNotSupported()
        {
            var quantity = new Luminosity(value: 1, unit: Luminosity.BaseUnit);
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
        public void ToUnit(LuminosityUnit unit)
        {
            var inBaseUnits = Luminosity.From(1.0, Luminosity.BaseUnit);
            var converted = inBaseUnits.ToUnit(unit);

            var conversionFactor = GetConversionFactor(unit);
            AssertEx.EqualTolerance(conversionFactor.UnitsInBaseUnit, (double)converted.Value, conversionFactor.Tolerence);
            Assert.Equal(unit, converted.Unit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_WithSameUnits_AreEqual(LuminosityUnit unit)
        {
            var quantity = Luminosity.From(3.0, unit);
            var toUnitWithSameUnit = quantity.ToUnit(unit);
            Assert.Equal(quantity, toUnitWithSameUnit);
        }

        [Theory]
        [MemberData(nameof(UnitTypes))]
        public void ToUnit_FromNonBaseUnit_ReturnsQuantityWithGivenUnit(LuminosityUnit unit)
        {
            // See if there is a unit available that is not the base unit.
            var fromUnit = Luminosity.Units.FirstOrDefault(u => u != Luminosity.BaseUnit && u != LuminosityUnit.Undefined);

            // If there is only one unit for the quantity, we must use the base unit.
            if(fromUnit == LuminosityUnit.Undefined)
                fromUnit = Luminosity.BaseUnit;

            var quantity = Luminosity.From(3.0, fromUnit);
            var converted = quantity.ToUnit(unit);
            Assert.Equal(converted.Unit, unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Luminosity watt = Luminosity.FromWatts(1);
            AssertEx.EqualTolerance(1, Luminosity.FromDecawatts(watt.Decawatts).Watts, DecawattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromDeciwatts(watt.Deciwatts).Watts, DeciwattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromFemtowatts(watt.Femtowatts).Watts, FemtowattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromGigawatts(watt.Gigawatts).Watts, GigawattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromKilowatts(watt.Kilowatts).Watts, KilowattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromMegawatts(watt.Megawatts).Watts, MegawattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromMicrowatts(watt.Microwatts).Watts, MicrowattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromMilliwatts(watt.Milliwatts).Watts, MilliwattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromNanowatts(watt.Nanowatts).Watts, NanowattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromPetawatts(watt.Petawatts).Watts, PetawattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromPicowatts(watt.Picowatts).Watts, PicowattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromSolarLuminosities(watt.SolarLuminosities).Watts, SolarLuminositiesTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromTerawatts(watt.Terawatts).Watts, TerawattsTolerance);
            AssertEx.EqualTolerance(1, Luminosity.FromWatts(watt.Watts).Watts, WattsTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Luminosity v = Luminosity.FromWatts(1);
            AssertEx.EqualTolerance(-1, -v.Watts, WattsTolerance);
            AssertEx.EqualTolerance(2, (Luminosity.FromWatts(3)-v).Watts, WattsTolerance);
            AssertEx.EqualTolerance(2, (v + v).Watts, WattsTolerance);
            AssertEx.EqualTolerance(10, (v*10).Watts, WattsTolerance);
            AssertEx.EqualTolerance(10, (10*v).Watts, WattsTolerance);
            AssertEx.EqualTolerance(2, (Luminosity.FromWatts(10)/5).Watts, WattsTolerance);
            AssertEx.EqualTolerance(2, Luminosity.FromWatts(10)/Luminosity.FromWatts(5), WattsTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            Luminosity oneWatt = Luminosity.FromWatts(1);
            Luminosity twoWatts = Luminosity.FromWatts(2);

            Assert.True(oneWatt < twoWatts);
            Assert.True(oneWatt <= twoWatts);
            Assert.True(twoWatts > oneWatt);
            Assert.True(twoWatts >= oneWatt);

            Assert.False(oneWatt > twoWatts);
            Assert.False(oneWatt >= twoWatts);
            Assert.False(twoWatts < oneWatt);
            Assert.False(twoWatts <= oneWatt);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Luminosity watt = Luminosity.FromWatts(1);
            Assert.Equal(0, watt.CompareTo(watt));
            Assert.True(watt.CompareTo(Luminosity.Zero) > 0);
            Assert.True(Luminosity.Zero.CompareTo(watt) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Luminosity watt = Luminosity.FromWatts(1);
            Assert.Throws<ArgumentException>(() => watt.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Luminosity watt = Luminosity.FromWatts(1);
            Assert.Throws<ArgumentNullException>(() => watt.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = Luminosity.FromWatts(1);
            var b = Luminosity.FromWatts(2);

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
            var a = Luminosity.FromWatts(1);
            var b = Luminosity.FromWatts(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
        }

        [Fact]
        public void Equals_QuantityAsObject_IsImplemented()
        {
            object a = Luminosity.FromWatts(1);
            object b = Luminosity.FromWatts(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals((object)null));
        }

        [Fact]
        public void Equals_RelativeTolerance_IsImplemented()
        {
            var v = Luminosity.FromWatts(1);
            Assert.True(v.Equals(Luminosity.FromWatts(1), WattsTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Luminosity.Zero, WattsTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void Equals_NegativeRelativeTolerance_ThrowsArgumentOutOfRangeException()
        {
            var v = Luminosity.FromWatts(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => v.Equals(Luminosity.FromWatts(1), -1, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Luminosity watt = Luminosity.FromWatts(1);
            Assert.False(watt.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Luminosity watt = Luminosity.FromWatts(1);
            Assert.False(watt.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(LuminosityUnit.Undefined, Luminosity.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(LuminosityUnit)).Cast<LuminosityUnit>();
            foreach(var unit in units)
            {
                if(unit == LuminosityUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(Luminosity.BaseDimensions is null);
        }

        [Fact]
        public void ToString_ReturnsValueAndUnitAbbreviationInCurrentCulture()
        {
            var prevCulture = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            try {
                Assert.Equal("1 daW", new Luminosity(1, LuminosityUnit.Decawatt).ToString());
                Assert.Equal("1 dW", new Luminosity(1, LuminosityUnit.Deciwatt).ToString());
                Assert.Equal("1 fW", new Luminosity(1, LuminosityUnit.Femtowatt).ToString());
                Assert.Equal("1 GW", new Luminosity(1, LuminosityUnit.Gigawatt).ToString());
                Assert.Equal("1 kW", new Luminosity(1, LuminosityUnit.Kilowatt).ToString());
                Assert.Equal("1 MW", new Luminosity(1, LuminosityUnit.Megawatt).ToString());
                Assert.Equal("1 µW", new Luminosity(1, LuminosityUnit.Microwatt).ToString());
                Assert.Equal("1 mW", new Luminosity(1, LuminosityUnit.Milliwatt).ToString());
                Assert.Equal("1 nW", new Luminosity(1, LuminosityUnit.Nanowatt).ToString());
                Assert.Equal("1 PW", new Luminosity(1, LuminosityUnit.Petawatt).ToString());
                Assert.Equal("1 pW", new Luminosity(1, LuminosityUnit.Picowatt).ToString());
                Assert.Equal("1 L⊙", new Luminosity(1, LuminosityUnit.SolarLuminosity).ToString());
                Assert.Equal("1 TW", new Luminosity(1, LuminosityUnit.Terawatt).ToString());
                Assert.Equal("1 W", new Luminosity(1, LuminosityUnit.Watt).ToString());
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

            Assert.Equal("1 daW", new Luminosity(1, LuminosityUnit.Decawatt).ToString(swedishCulture));
            Assert.Equal("1 dW", new Luminosity(1, LuminosityUnit.Deciwatt).ToString(swedishCulture));
            Assert.Equal("1 fW", new Luminosity(1, LuminosityUnit.Femtowatt).ToString(swedishCulture));
            Assert.Equal("1 GW", new Luminosity(1, LuminosityUnit.Gigawatt).ToString(swedishCulture));
            Assert.Equal("1 kW", new Luminosity(1, LuminosityUnit.Kilowatt).ToString(swedishCulture));
            Assert.Equal("1 MW", new Luminosity(1, LuminosityUnit.Megawatt).ToString(swedishCulture));
            Assert.Equal("1 µW", new Luminosity(1, LuminosityUnit.Microwatt).ToString(swedishCulture));
            Assert.Equal("1 mW", new Luminosity(1, LuminosityUnit.Milliwatt).ToString(swedishCulture));
            Assert.Equal("1 nW", new Luminosity(1, LuminosityUnit.Nanowatt).ToString(swedishCulture));
            Assert.Equal("1 PW", new Luminosity(1, LuminosityUnit.Petawatt).ToString(swedishCulture));
            Assert.Equal("1 pW", new Luminosity(1, LuminosityUnit.Picowatt).ToString(swedishCulture));
            Assert.Equal("1 L⊙", new Luminosity(1, LuminosityUnit.SolarLuminosity).ToString(swedishCulture));
            Assert.Equal("1 TW", new Luminosity(1, LuminosityUnit.Terawatt).ToString(swedishCulture));
            Assert.Equal("1 W", new Luminosity(1, LuminosityUnit.Watt).ToString(swedishCulture));
        }

        [Fact]
        public void ToString_SFormat_FormatsNumberWithGivenDigitsAfterRadixForCurrentCulture()
        {
            var oldCulture = CultureInfo.CurrentUICulture;
            try
            {
                CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
                Assert.Equal("0.1 W", new Luminosity(0.123456, LuminosityUnit.Watt).ToString("s1"));
                Assert.Equal("0.12 W", new Luminosity(0.123456, LuminosityUnit.Watt).ToString("s2"));
                Assert.Equal("0.123 W", new Luminosity(0.123456, LuminosityUnit.Watt).ToString("s3"));
                Assert.Equal("0.1235 W", new Luminosity(0.123456, LuminosityUnit.Watt).ToString("s4"));
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
            Assert.Equal("0.1 W", new Luminosity(0.123456, LuminosityUnit.Watt).ToString("s1", culture));
            Assert.Equal("0.12 W", new Luminosity(0.123456, LuminosityUnit.Watt).ToString("s2", culture));
            Assert.Equal("0.123 W", new Luminosity(0.123456, LuminosityUnit.Watt).ToString("s3", culture));
            Assert.Equal("0.1235 W", new Luminosity(0.123456, LuminosityUnit.Watt).ToString("s4", culture));
        }


        [Fact]
        public void ToString_NullFormat_ThrowsArgumentNullException()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, null, null));
        }

        [Fact]
        public void ToString_NullArgs_ThrowsArgumentNullException()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Throws<ArgumentNullException>(() => quantity.ToString(null, "g", null));
        }

        [Fact]
        public void ToString_NullProvider_EqualsCurrentUICulture()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal(quantity.ToString(CultureInfo.CurrentUICulture, "g"), quantity.ToString(null, "g"));
        }


        [Fact]
        public void Convert_ToBool_ThrowsInvalidCastException()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToBoolean(quantity));
        }

        [Fact]
        public void Convert_ToByte_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
           Assert.Equal((byte)quantity.Value, Convert.ToByte(quantity));
        }

        [Fact]
        public void Convert_ToChar_ThrowsInvalidCastException()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToChar(quantity));
        }

        [Fact]
        public void Convert_ToDateTime_ThrowsInvalidCastException()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ToDateTime(quantity));
        }

        [Fact]
        public void Convert_ToDecimal_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal((decimal)quantity.Value, Convert.ToDecimal(quantity));
        }

        [Fact]
        public void Convert_ToDouble_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal((double)quantity.Value, Convert.ToDouble(quantity));
        }

        [Fact]
        public void Convert_ToInt16_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal((short)quantity.Value, Convert.ToInt16(quantity));
        }

        [Fact]
        public void Convert_ToInt32_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal((int)quantity.Value, Convert.ToInt32(quantity));
        }

        [Fact]
        public void Convert_ToInt64_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal((long)quantity.Value, Convert.ToInt64(quantity));
        }

        [Fact]
        public void Convert_ToSByte_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal((sbyte)quantity.Value, Convert.ToSByte(quantity));
        }

        [Fact]
        public void Convert_ToSingle_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal((float)quantity.Value, Convert.ToSingle(quantity));
        }

        [Fact]
        public void Convert_ToString_EqualsToString()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal(quantity.ToString(), Convert.ToString(quantity));
        }

        [Fact]
        public void Convert_ToUInt16_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal((ushort)quantity.Value, Convert.ToUInt16(quantity));
        }

        [Fact]
        public void Convert_ToUInt32_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal((uint)quantity.Value, Convert.ToUInt32(quantity));
        }

        [Fact]
        public void Convert_ToUInt64_EqualsValueAsSameType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal((ulong)quantity.Value, Convert.ToUInt64(quantity));
        }

        [Fact]
        public void Convert_ChangeType_SelfType_EqualsSelf()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal(quantity, Convert.ChangeType(quantity, typeof(Luminosity)));
        }

        [Fact]
        public void Convert_ChangeType_UnitType_EqualsUnit()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal(quantity.Unit, Convert.ChangeType(quantity, typeof(LuminosityUnit)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityType_EqualsQuantityType()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal(QuantityType.Luminosity, Convert.ChangeType(quantity, typeof(QuantityType)));
        }

        [Fact]
        public void Convert_ChangeType_QuantityInfo_EqualsQuantityInfo()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal(Luminosity.Info, Convert.ChangeType(quantity, typeof(QuantityInfo)));
        }

        [Fact]
        public void Convert_ChangeType_BaseDimensions_EqualsBaseDimensions()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal(Luminosity.BaseDimensions, Convert.ChangeType(quantity, typeof(BaseDimensions)));
        }

        [Fact]
        public void Convert_ChangeType_InvalidType_ThrowsInvalidCastException()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Throws<InvalidCastException>(() => Convert.ChangeType(quantity, typeof(QuantityFormatter)));
        }

        [Fact]
        public void GetHashCode_Equals()
        {
            var quantity = Luminosity.FromWatts(1.0);
            Assert.Equal(new {Luminosity.Info.Name, quantity.Value, quantity.Unit}.GetHashCode(), quantity.GetHashCode());
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-1.0)]
        public void NegationOperator_ReturnsQuantity_WithNegatedValue(double value)
        {
            var quantity = Luminosity.FromWatts(value);
            Assert.Equal(Luminosity.FromWatts(-value), -quantity);
        }
    }
}
