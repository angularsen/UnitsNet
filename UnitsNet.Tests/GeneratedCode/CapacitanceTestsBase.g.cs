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
using System.Linq;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Capacitance.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class CapacitanceTestsBase
    {
        protected abstract double FaradsInOneFarad { get; }
        protected abstract double KilofaradsInOneFarad { get; }
        protected abstract double MegafaradsInOneFarad { get; }
        protected abstract double MicrofaradsInOneFarad { get; }
        protected abstract double MillifaradsInOneFarad { get; }
        protected abstract double NanofaradsInOneFarad { get; }
        protected abstract double PicofaradsInOneFarad { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double FaradsTolerance { get { return 1e-5; } }
        protected virtual double KilofaradsTolerance { get { return 1e-5; } }
        protected virtual double MegafaradsTolerance { get { return 1e-5; } }
        protected virtual double MicrofaradsTolerance { get { return 1e-5; } }
        protected virtual double MillifaradsTolerance { get { return 1e-5; } }
        protected virtual double NanofaradsTolerance { get { return 1e-5; } }
        protected virtual double PicofaradsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void Ctor_WithUndefinedUnit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Capacitance((double)0.0, CapacitanceUnit.Undefined));
        }

        [Fact]
        public void Ctor_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Capacitance(double.PositiveInfinity, CapacitanceUnit.Farad));
            Assert.Throws<ArgumentException>(() => new Capacitance(double.NegativeInfinity, CapacitanceUnit.Farad));
        }

        [Fact]
        public void Ctor_WithNaNValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Capacitance(double.NaN, CapacitanceUnit.Farad));
        }

        [Fact]
        public void FaradToCapacitanceUnits()
        {
            Capacitance farad = Capacitance.FromFarads(1);
            AssertEx.EqualTolerance(FaradsInOneFarad, farad.Farads, FaradsTolerance);
            AssertEx.EqualTolerance(KilofaradsInOneFarad, farad.Kilofarads, KilofaradsTolerance);
            AssertEx.EqualTolerance(MegafaradsInOneFarad, farad.Megafarads, MegafaradsTolerance);
            AssertEx.EqualTolerance(MicrofaradsInOneFarad, farad.Microfarads, MicrofaradsTolerance);
            AssertEx.EqualTolerance(MillifaradsInOneFarad, farad.Millifarads, MillifaradsTolerance);
            AssertEx.EqualTolerance(NanofaradsInOneFarad, farad.Nanofarads, NanofaradsTolerance);
            AssertEx.EqualTolerance(PicofaradsInOneFarad, farad.Picofarads, PicofaradsTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, Capacitance.From(1, CapacitanceUnit.Farad).Farads, FaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.From(1, CapacitanceUnit.Kilofarad).Kilofarads, KilofaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.From(1, CapacitanceUnit.Megafarad).Megafarads, MegafaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.From(1, CapacitanceUnit.Microfarad).Microfarads, MicrofaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.From(1, CapacitanceUnit.Millifarad).Millifarads, MillifaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.From(1, CapacitanceUnit.Nanofarad).Nanofarads, NanofaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.From(1, CapacitanceUnit.Picofarad).Picofarads, PicofaradsTolerance);
        }

        [Fact]
        public void FromFarads_WithInfinityValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Capacitance.FromFarads(double.PositiveInfinity));
            Assert.Throws<ArgumentException>(() => Capacitance.FromFarads(double.NegativeInfinity));
        }

        [Fact]
        public void FromFarads_WithNanValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Capacitance.FromFarads(double.NaN));
        }

        [Fact]
        public void As()
        {
            var farad = Capacitance.FromFarads(1);
            AssertEx.EqualTolerance(FaradsInOneFarad, farad.As(CapacitanceUnit.Farad), FaradsTolerance);
            AssertEx.EqualTolerance(KilofaradsInOneFarad, farad.As(CapacitanceUnit.Kilofarad), KilofaradsTolerance);
            AssertEx.EqualTolerance(MegafaradsInOneFarad, farad.As(CapacitanceUnit.Megafarad), MegafaradsTolerance);
            AssertEx.EqualTolerance(MicrofaradsInOneFarad, farad.As(CapacitanceUnit.Microfarad), MicrofaradsTolerance);
            AssertEx.EqualTolerance(MillifaradsInOneFarad, farad.As(CapacitanceUnit.Millifarad), MillifaradsTolerance);
            AssertEx.EqualTolerance(NanofaradsInOneFarad, farad.As(CapacitanceUnit.Nanofarad), NanofaradsTolerance);
            AssertEx.EqualTolerance(PicofaradsInOneFarad, farad.As(CapacitanceUnit.Picofarad), PicofaradsTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var farad = Capacitance.FromFarads(1);

            var faradQuantity = farad.ToUnit(CapacitanceUnit.Farad);
            AssertEx.EqualTolerance(FaradsInOneFarad, (double)faradQuantity.Value, FaradsTolerance);
            Assert.Equal(CapacitanceUnit.Farad, faradQuantity.Unit);

            var kilofaradQuantity = farad.ToUnit(CapacitanceUnit.Kilofarad);
            AssertEx.EqualTolerance(KilofaradsInOneFarad, (double)kilofaradQuantity.Value, KilofaradsTolerance);
            Assert.Equal(CapacitanceUnit.Kilofarad, kilofaradQuantity.Unit);

            var megafaradQuantity = farad.ToUnit(CapacitanceUnit.Megafarad);
            AssertEx.EqualTolerance(MegafaradsInOneFarad, (double)megafaradQuantity.Value, MegafaradsTolerance);
            Assert.Equal(CapacitanceUnit.Megafarad, megafaradQuantity.Unit);

            var microfaradQuantity = farad.ToUnit(CapacitanceUnit.Microfarad);
            AssertEx.EqualTolerance(MicrofaradsInOneFarad, (double)microfaradQuantity.Value, MicrofaradsTolerance);
            Assert.Equal(CapacitanceUnit.Microfarad, microfaradQuantity.Unit);

            var millifaradQuantity = farad.ToUnit(CapacitanceUnit.Millifarad);
            AssertEx.EqualTolerance(MillifaradsInOneFarad, (double)millifaradQuantity.Value, MillifaradsTolerance);
            Assert.Equal(CapacitanceUnit.Millifarad, millifaradQuantity.Unit);

            var nanofaradQuantity = farad.ToUnit(CapacitanceUnit.Nanofarad);
            AssertEx.EqualTolerance(NanofaradsInOneFarad, (double)nanofaradQuantity.Value, NanofaradsTolerance);
            Assert.Equal(CapacitanceUnit.Nanofarad, nanofaradQuantity.Unit);

            var picofaradQuantity = farad.ToUnit(CapacitanceUnit.Picofarad);
            AssertEx.EqualTolerance(PicofaradsInOneFarad, (double)picofaradQuantity.Value, PicofaradsTolerance);
            Assert.Equal(CapacitanceUnit.Picofarad, picofaradQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Capacitance farad = Capacitance.FromFarads(1);
            AssertEx.EqualTolerance(1, Capacitance.FromFarads(farad.Farads).Farads, FaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.FromKilofarads(farad.Kilofarads).Farads, KilofaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.FromMegafarads(farad.Megafarads).Farads, MegafaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.FromMicrofarads(farad.Microfarads).Farads, MicrofaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.FromMillifarads(farad.Millifarads).Farads, MillifaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.FromNanofarads(farad.Nanofarads).Farads, NanofaradsTolerance);
            AssertEx.EqualTolerance(1, Capacitance.FromPicofarads(farad.Picofarads).Farads, PicofaradsTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Capacitance v = Capacitance.FromFarads(1);
            AssertEx.EqualTolerance(-1, -v.Farads, FaradsTolerance);
            AssertEx.EqualTolerance(2, (Capacitance.FromFarads(3)-v).Farads, FaradsTolerance);
            AssertEx.EqualTolerance(2, (v + v).Farads, FaradsTolerance);
            AssertEx.EqualTolerance(10, (v*10).Farads, FaradsTolerance);
            AssertEx.EqualTolerance(10, (10*v).Farads, FaradsTolerance);
            AssertEx.EqualTolerance(2, (Capacitance.FromFarads(10)/5).Farads, FaradsTolerance);
            AssertEx.EqualTolerance(2, Capacitance.FromFarads(10)/Capacitance.FromFarads(5), FaradsTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            Capacitance oneFarad = Capacitance.FromFarads(1);
            Capacitance twoFarads = Capacitance.FromFarads(2);

            Assert.True(oneFarad < twoFarads);
            Assert.True(oneFarad <= twoFarads);
            Assert.True(twoFarads > oneFarad);
            Assert.True(twoFarads >= oneFarad);

            Assert.False(oneFarad > twoFarads);
            Assert.False(oneFarad >= twoFarads);
            Assert.False(twoFarads < oneFarad);
            Assert.False(twoFarads <= oneFarad);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            Capacitance farad = Capacitance.FromFarads(1);
            Assert.Equal(0, farad.CompareTo(farad));
            Assert.True(farad.CompareTo(Capacitance.Zero) > 0);
            Assert.True(Capacitance.Zero.CompareTo(farad) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Capacitance farad = Capacitance.FromFarads(1);
            Assert.Throws<ArgumentException>(() => farad.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Capacitance farad = Capacitance.FromFarads(1);
            Assert.Throws<ArgumentNullException>(() => farad.CompareTo(null));
        }

        [Fact]
        public void EqualityOperators()
        {
            var a = Capacitance.FromFarads(1);
            var b = Capacitance.FromFarads(2);

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
        public void EqualsIsImplemented()
        {
            var a = Capacitance.FromFarads(1);
            var b = Capacitance.FromFarads(2);

            Assert.True(a.Equals(a));
            Assert.False(a.Equals(b));
            Assert.False(a.Equals(null));
        }

        [Fact]
        public void EqualsRelativeToleranceIsImplemented()
        {
            var v = Capacitance.FromFarads(1);
            Assert.True(v.Equals(Capacitance.FromFarads(1), FaradsTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Capacitance.Zero, FaradsTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Capacitance farad = Capacitance.FromFarads(1);
            Assert.False(farad.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Capacitance farad = Capacitance.FromFarads(1);
            Assert.False(farad.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(CapacitanceUnit.Undefined, Capacitance.Units);
        }

        [Fact]
        public void HasAtLeastOneAbbreviationSpecified()
        {
            var units = Enum.GetValues(typeof(CapacitanceUnit)).Cast<CapacitanceUnit>();
            foreach(var unit in units)
            {
                if(unit == CapacitanceUnit.Undefined)
                    continue;

                var defaultAbbreviation = UnitAbbreviationsCache.Default.GetDefaultAbbreviation(unit);
            }
        }

        [Fact]
        public void BaseDimensionsShouldNeverBeNull()
        {
            Assert.False(Capacitance.BaseDimensions is null);
        }
    }
}
