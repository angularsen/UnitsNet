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
//     Add Extensions\MyQuantityExtensions.cs to decorate quantities with new behavior.
//     Add UnitDefinitions\MyQuantity.json and run GeneratUnits.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

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
    /// Test of MolarMass.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MolarMassTestsBase
    {
        protected abstract double CentigramsPerMoleInOneKilogramPerMole { get; }
        protected abstract double DecagramsPerMoleInOneKilogramPerMole { get; }
        protected abstract double DecigramsPerMoleInOneKilogramPerMole { get; }
        protected abstract double GramsPerMoleInOneKilogramPerMole { get; }
        protected abstract double HectogramsPerMoleInOneKilogramPerMole { get; }
        protected abstract double KilogramsPerMoleInOneKilogramPerMole { get; }
        protected abstract double KilopoundsPerMoleInOneKilogramPerMole { get; }
        protected abstract double MegapoundsPerMoleInOneKilogramPerMole { get; }
        protected abstract double MicrogramsPerMoleInOneKilogramPerMole { get; }
        protected abstract double MilligramsPerMoleInOneKilogramPerMole { get; }
        protected abstract double NanogramsPerMoleInOneKilogramPerMole { get; }
        protected abstract double PoundsPerMoleInOneKilogramPerMole { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentigramsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double DecagramsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double DecigramsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double GramsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double HectogramsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double KilogramsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double KilopoundsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double MegapoundsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double MicrogramsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double MilligramsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double NanogramsPerMoleTolerance { get { return 1e-5; } }
        protected virtual double PoundsPerMoleTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void KilogramPerMoleToMolarMassUnits()
        {
            MolarMass kilogrampermole = MolarMass.FromKilogramsPerMole(1);
            AssertEx.EqualTolerance(CentigramsPerMoleInOneKilogramPerMole, kilogrampermole.CentigramsPerMole, CentigramsPerMoleTolerance);
            AssertEx.EqualTolerance(DecagramsPerMoleInOneKilogramPerMole, kilogrampermole.DecagramsPerMole, DecagramsPerMoleTolerance);
            AssertEx.EqualTolerance(DecigramsPerMoleInOneKilogramPerMole, kilogrampermole.DecigramsPerMole, DecigramsPerMoleTolerance);
            AssertEx.EqualTolerance(GramsPerMoleInOneKilogramPerMole, kilogrampermole.GramsPerMole, GramsPerMoleTolerance);
            AssertEx.EqualTolerance(HectogramsPerMoleInOneKilogramPerMole, kilogrampermole.HectogramsPerMole, HectogramsPerMoleTolerance);
            AssertEx.EqualTolerance(KilogramsPerMoleInOneKilogramPerMole, kilogrampermole.KilogramsPerMole, KilogramsPerMoleTolerance);
            AssertEx.EqualTolerance(KilopoundsPerMoleInOneKilogramPerMole, kilogrampermole.KilopoundsPerMole, KilopoundsPerMoleTolerance);
            AssertEx.EqualTolerance(MegapoundsPerMoleInOneKilogramPerMole, kilogrampermole.MegapoundsPerMole, MegapoundsPerMoleTolerance);
            AssertEx.EqualTolerance(MicrogramsPerMoleInOneKilogramPerMole, kilogrampermole.MicrogramsPerMole, MicrogramsPerMoleTolerance);
            AssertEx.EqualTolerance(MilligramsPerMoleInOneKilogramPerMole, kilogrampermole.MilligramsPerMole, MilligramsPerMoleTolerance);
            AssertEx.EqualTolerance(NanogramsPerMoleInOneKilogramPerMole, kilogrampermole.NanogramsPerMole, NanogramsPerMoleTolerance);
            AssertEx.EqualTolerance(PoundsPerMoleInOneKilogramPerMole, kilogrampermole.PoundsPerMole, PoundsPerMoleTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.CentigramPerMole).CentigramsPerMole, CentigramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.DecagramPerMole).DecagramsPerMole, DecagramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.DecigramPerMole).DecigramsPerMole, DecigramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.GramPerMole).GramsPerMole, GramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.HectogramPerMole).HectogramsPerMole, HectogramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.KilogramPerMole).KilogramsPerMole, KilogramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.KilopoundPerMole).KilopoundsPerMole, KilopoundsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.MegapoundPerMole).MegapoundsPerMole, MegapoundsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.MicrogramPerMole).MicrogramsPerMole, MicrogramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.MilligramPerMole).MilligramsPerMole, MilligramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.NanogramPerMole).NanogramsPerMole, NanogramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.From(1, MolarMassUnit.PoundPerMole).PoundsPerMole, PoundsPerMoleTolerance);
        }

        [Fact]
        public void As()
        {
            var kilogrampermole = MolarMass.FromKilogramsPerMole(1);
            AssertEx.EqualTolerance(CentigramsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.CentigramPerMole), CentigramsPerMoleTolerance);
            AssertEx.EqualTolerance(DecagramsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.DecagramPerMole), DecagramsPerMoleTolerance);
            AssertEx.EqualTolerance(DecigramsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.DecigramPerMole), DecigramsPerMoleTolerance);
            AssertEx.EqualTolerance(GramsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.GramPerMole), GramsPerMoleTolerance);
            AssertEx.EqualTolerance(HectogramsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.HectogramPerMole), HectogramsPerMoleTolerance);
            AssertEx.EqualTolerance(KilogramsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.KilogramPerMole), KilogramsPerMoleTolerance);
            AssertEx.EqualTolerance(KilopoundsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.KilopoundPerMole), KilopoundsPerMoleTolerance);
            AssertEx.EqualTolerance(MegapoundsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.MegapoundPerMole), MegapoundsPerMoleTolerance);
            AssertEx.EqualTolerance(MicrogramsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.MicrogramPerMole), MicrogramsPerMoleTolerance);
            AssertEx.EqualTolerance(MilligramsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.MilligramPerMole), MilligramsPerMoleTolerance);
            AssertEx.EqualTolerance(NanogramsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.NanogramPerMole), NanogramsPerMoleTolerance);
            AssertEx.EqualTolerance(PoundsPerMoleInOneKilogramPerMole, kilogrampermole.As(MolarMassUnit.PoundPerMole), PoundsPerMoleTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var kilogrampermole = MolarMass.FromKilogramsPerMole(1);

            var centigrampermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.CentigramPerMole);
            AssertEx.EqualTolerance(CentigramsPerMoleInOneKilogramPerMole, (double)centigrampermoleQuantity.Value, CentigramsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.CentigramPerMole, centigrampermoleQuantity.Unit);

            var decagrampermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.DecagramPerMole);
            AssertEx.EqualTolerance(DecagramsPerMoleInOneKilogramPerMole, (double)decagrampermoleQuantity.Value, DecagramsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.DecagramPerMole, decagrampermoleQuantity.Unit);

            var decigrampermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.DecigramPerMole);
            AssertEx.EqualTolerance(DecigramsPerMoleInOneKilogramPerMole, (double)decigrampermoleQuantity.Value, DecigramsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.DecigramPerMole, decigrampermoleQuantity.Unit);

            var grampermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.GramPerMole);
            AssertEx.EqualTolerance(GramsPerMoleInOneKilogramPerMole, (double)grampermoleQuantity.Value, GramsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.GramPerMole, grampermoleQuantity.Unit);

            var hectogrampermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.HectogramPerMole);
            AssertEx.EqualTolerance(HectogramsPerMoleInOneKilogramPerMole, (double)hectogrampermoleQuantity.Value, HectogramsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.HectogramPerMole, hectogrampermoleQuantity.Unit);

            var kilogrampermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.KilogramPerMole);
            AssertEx.EqualTolerance(KilogramsPerMoleInOneKilogramPerMole, (double)kilogrampermoleQuantity.Value, KilogramsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.KilogramPerMole, kilogrampermoleQuantity.Unit);

            var kilopoundpermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.KilopoundPerMole);
            AssertEx.EqualTolerance(KilopoundsPerMoleInOneKilogramPerMole, (double)kilopoundpermoleQuantity.Value, KilopoundsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.KilopoundPerMole, kilopoundpermoleQuantity.Unit);

            var megapoundpermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.MegapoundPerMole);
            AssertEx.EqualTolerance(MegapoundsPerMoleInOneKilogramPerMole, (double)megapoundpermoleQuantity.Value, MegapoundsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.MegapoundPerMole, megapoundpermoleQuantity.Unit);

            var microgrampermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.MicrogramPerMole);
            AssertEx.EqualTolerance(MicrogramsPerMoleInOneKilogramPerMole, (double)microgrampermoleQuantity.Value, MicrogramsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.MicrogramPerMole, microgrampermoleQuantity.Unit);

            var milligrampermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.MilligramPerMole);
            AssertEx.EqualTolerance(MilligramsPerMoleInOneKilogramPerMole, (double)milligrampermoleQuantity.Value, MilligramsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.MilligramPerMole, milligrampermoleQuantity.Unit);

            var nanogrampermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.NanogramPerMole);
            AssertEx.EqualTolerance(NanogramsPerMoleInOneKilogramPerMole, (double)nanogrampermoleQuantity.Value, NanogramsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.NanogramPerMole, nanogrampermoleQuantity.Unit);

            var poundpermoleQuantity = kilogrampermole.ToUnit(MolarMassUnit.PoundPerMole);
            AssertEx.EqualTolerance(PoundsPerMoleInOneKilogramPerMole, (double)poundpermoleQuantity.Value, PoundsPerMoleTolerance);
            Assert.Equal(MolarMassUnit.PoundPerMole, poundpermoleQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            MolarMass kilogrampermole = MolarMass.FromKilogramsPerMole(1);
            AssertEx.EqualTolerance(1, MolarMass.FromCentigramsPerMole(kilogrampermole.CentigramsPerMole).KilogramsPerMole, CentigramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromDecagramsPerMole(kilogrampermole.DecagramsPerMole).KilogramsPerMole, DecagramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromDecigramsPerMole(kilogrampermole.DecigramsPerMole).KilogramsPerMole, DecigramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromGramsPerMole(kilogrampermole.GramsPerMole).KilogramsPerMole, GramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromHectogramsPerMole(kilogrampermole.HectogramsPerMole).KilogramsPerMole, HectogramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromKilogramsPerMole(kilogrampermole.KilogramsPerMole).KilogramsPerMole, KilogramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromKilopoundsPerMole(kilogrampermole.KilopoundsPerMole).KilogramsPerMole, KilopoundsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromMegapoundsPerMole(kilogrampermole.MegapoundsPerMole).KilogramsPerMole, MegapoundsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromMicrogramsPerMole(kilogrampermole.MicrogramsPerMole).KilogramsPerMole, MicrogramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromMilligramsPerMole(kilogrampermole.MilligramsPerMole).KilogramsPerMole, MilligramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromNanogramsPerMole(kilogrampermole.NanogramsPerMole).KilogramsPerMole, NanogramsPerMoleTolerance);
            AssertEx.EqualTolerance(1, MolarMass.FromPoundsPerMole(kilogrampermole.PoundsPerMole).KilogramsPerMole, PoundsPerMoleTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            MolarMass v = MolarMass.FromKilogramsPerMole(1);
            AssertEx.EqualTolerance(-1, -v.KilogramsPerMole, KilogramsPerMoleTolerance);
            AssertEx.EqualTolerance(2, (MolarMass.FromKilogramsPerMole(3)-v).KilogramsPerMole, KilogramsPerMoleTolerance);
            AssertEx.EqualTolerance(2, (v + v).KilogramsPerMole, KilogramsPerMoleTolerance);
            AssertEx.EqualTolerance(10, (v*10).KilogramsPerMole, KilogramsPerMoleTolerance);
            AssertEx.EqualTolerance(10, (10*v).KilogramsPerMole, KilogramsPerMoleTolerance);
            AssertEx.EqualTolerance(2, (MolarMass.FromKilogramsPerMole(10)/5).KilogramsPerMole, KilogramsPerMoleTolerance);
            AssertEx.EqualTolerance(2, MolarMass.FromKilogramsPerMole(10)/MolarMass.FromKilogramsPerMole(5), KilogramsPerMoleTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            MolarMass oneKilogramPerMole = MolarMass.FromKilogramsPerMole(1);
            MolarMass twoKilogramsPerMole = MolarMass.FromKilogramsPerMole(2);

            Assert.True(oneKilogramPerMole < twoKilogramsPerMole);
            Assert.True(oneKilogramPerMole <= twoKilogramsPerMole);
            Assert.True(twoKilogramsPerMole > oneKilogramPerMole);
            Assert.True(twoKilogramsPerMole >= oneKilogramPerMole);

            Assert.False(oneKilogramPerMole > twoKilogramsPerMole);
            Assert.False(oneKilogramPerMole >= twoKilogramsPerMole);
            Assert.False(twoKilogramsPerMole < oneKilogramPerMole);
            Assert.False(twoKilogramsPerMole <= oneKilogramPerMole);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            MolarMass kilogrampermole = MolarMass.FromKilogramsPerMole(1);
            Assert.Equal(0, kilogrampermole.CompareTo(kilogrampermole));
            Assert.True(kilogrampermole.CompareTo(MolarMass.Zero) > 0);
            Assert.True(MolarMass.Zero.CompareTo(kilogrampermole) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            MolarMass kilogrampermole = MolarMass.FromKilogramsPerMole(1);
            Assert.Throws<ArgumentException>(() => kilogrampermole.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            MolarMass kilogrampermole = MolarMass.FromKilogramsPerMole(1);
            Assert.Throws<ArgumentNullException>(() => kilogrampermole.CompareTo(null));
        }


        [Fact]
        public void EqualityOperators()
        {
            MolarMass a = MolarMass.FromKilogramsPerMole(1);
            MolarMass b = MolarMass.FromKilogramsPerMole(2);

// ReSharper disable EqualExpressionComparison
            Assert.True(a == a);
            Assert.True(a != b);

            Assert.False(a == b);
            Assert.False(a != a);
// ReSharper restore EqualExpressionComparison
        }

        [Fact]
        public void EqualsIsImplemented()
        {
            MolarMass v = MolarMass.FromKilogramsPerMole(1);
            Assert.True(v.Equals(MolarMass.FromKilogramsPerMole(1), MolarMass.FromKilogramsPerMole(KilogramsPerMoleTolerance)));
            Assert.False(v.Equals(MolarMass.Zero, MolarMass.FromKilogramsPerMole(KilogramsPerMoleTolerance)));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            MolarMass kilogrampermole = MolarMass.FromKilogramsPerMole(1);
            Assert.False(kilogrampermole.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            MolarMass kilogrampermole = MolarMass.FromKilogramsPerMole(1);
            Assert.False(kilogrampermole.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(MolarMassUnit.Undefined, MolarMass.Units);
        }

    }
}
