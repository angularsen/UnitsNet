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
//     Add CustomCode\UnitClasses\MyUnit.extra.cs files to add code to generated unit classes.
//     Add Extensions\MyUnitExtensions.cs to decorate unit classes with new behavior.
//     Add UnitDefinitions\MyUnit.json and run GeneratUnits.bat to generate new units or unit classes.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Copyright (c) 2007 Andreas Gullberg Larsen (angularsen@gmail.com).
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
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of MassFlow.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MassFlowTestsBase
    {
        protected abstract double CentigramsPerSecondInOneGramPerSecond { get; }
        protected abstract double DecagramsPerSecondInOneGramPerSecond { get; }
        protected abstract double DecigramsPerSecondInOneGramPerSecond { get; }
        protected abstract double GramsPerSecondInOneGramPerSecond { get; }
        protected abstract double HectogramsPerSecondInOneGramPerSecond { get; }
        protected abstract double KilogramsPerHourInOneGramPerSecond { get; }
        protected abstract double KilogramsPerSecondInOneGramPerSecond { get; }
        protected abstract double MicrogramsPerSecondInOneGramPerSecond { get; }
        protected abstract double MilligramsPerSecondInOneGramPerSecond { get; }
        protected abstract double NanogramsPerSecondInOneGramPerSecond { get; }
        protected abstract double PoundsPerHourInOneGramPerSecond { get; }
        protected abstract double TonnesPerDayInOneGramPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentigramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double DecagramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double DecigramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double GramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double HectogramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double KilogramsPerHourTolerance { get { return 1e-5; } }
        protected virtual double KilogramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MicrogramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MilligramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double NanogramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double PoundsPerHourTolerance { get { return 1e-5; } }
        protected virtual double TonnesPerDayTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void GramPerSecondToMassFlowUnits()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            AssertEx.EqualTolerance(CentigramsPerSecondInOneGramPerSecond, grampersecond.CentigramsPerSecond, CentigramsPerSecondTolerance);
            AssertEx.EqualTolerance(DecagramsPerSecondInOneGramPerSecond, grampersecond.DecagramsPerSecond, DecagramsPerSecondTolerance);
            AssertEx.EqualTolerance(DecigramsPerSecondInOneGramPerSecond, grampersecond.DecigramsPerSecond, DecigramsPerSecondTolerance);
            AssertEx.EqualTolerance(GramsPerSecondInOneGramPerSecond, grampersecond.GramsPerSecond, GramsPerSecondTolerance);
            AssertEx.EqualTolerance(HectogramsPerSecondInOneGramPerSecond, grampersecond.HectogramsPerSecond, HectogramsPerSecondTolerance);
            AssertEx.EqualTolerance(KilogramsPerHourInOneGramPerSecond, grampersecond.KilogramsPerHour, KilogramsPerHourTolerance);
            AssertEx.EqualTolerance(KilogramsPerSecondInOneGramPerSecond, grampersecond.KilogramsPerSecond, KilogramsPerSecondTolerance);
            AssertEx.EqualTolerance(MicrogramsPerSecondInOneGramPerSecond, grampersecond.MicrogramsPerSecond, MicrogramsPerSecondTolerance);
            AssertEx.EqualTolerance(MilligramsPerSecondInOneGramPerSecond, grampersecond.MilligramsPerSecond, MilligramsPerSecondTolerance);
            AssertEx.EqualTolerance(NanogramsPerSecondInOneGramPerSecond, grampersecond.NanogramsPerSecond, NanogramsPerSecondTolerance);
            AssertEx.EqualTolerance(PoundsPerHourInOneGramPerSecond, grampersecond.PoundsPerHour, PoundsPerHourTolerance);
            AssertEx.EqualTolerance(TonnesPerDayInOneGramPerSecond, grampersecond.TonnesPerDay, TonnesPerDayTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.CentigramPerSecond).CentigramsPerSecond, CentigramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.DecagramPerSecond).DecagramsPerSecond, DecagramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.DecigramPerSecond).DecigramsPerSecond, DecigramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.GramPerSecond).GramsPerSecond, GramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.HectogramPerSecond).HectogramsPerSecond, HectogramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.KilogramPerHour).KilogramsPerHour, KilogramsPerHourTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.KilogramPerSecond).KilogramsPerSecond, KilogramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.MicrogramPerSecond).MicrogramsPerSecond, MicrogramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.MilligramPerSecond).MilligramsPerSecond, MilligramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.NanogramPerSecond).NanogramsPerSecond, NanogramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.PoundPerHour).PoundsPerHour, PoundsPerHourTolerance);
            AssertEx.EqualTolerance(1, MassFlow.From(1, MassFlowUnit.TonnePerDay).TonnesPerDay, TonnesPerDayTolerance);
        }

        [Fact]
        public void As()
        {
            var grampersecond = MassFlow.FromGramsPerSecond(1);
            AssertEx.EqualTolerance(CentigramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.CentigramPerSecond), CentigramsPerSecondTolerance);
            AssertEx.EqualTolerance(DecagramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.DecagramPerSecond), DecagramsPerSecondTolerance);
            AssertEx.EqualTolerance(DecigramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.DecigramPerSecond), DecigramsPerSecondTolerance);
            AssertEx.EqualTolerance(GramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.GramPerSecond), GramsPerSecondTolerance);
            AssertEx.EqualTolerance(HectogramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.HectogramPerSecond), HectogramsPerSecondTolerance);
            AssertEx.EqualTolerance(KilogramsPerHourInOneGramPerSecond, grampersecond.As(MassFlowUnit.KilogramPerHour), KilogramsPerHourTolerance);
            AssertEx.EqualTolerance(KilogramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.KilogramPerSecond), KilogramsPerSecondTolerance);
            AssertEx.EqualTolerance(MicrogramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.MicrogramPerSecond), MicrogramsPerSecondTolerance);
            AssertEx.EqualTolerance(MilligramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.MilligramPerSecond), MilligramsPerSecondTolerance);
            AssertEx.EqualTolerance(NanogramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.NanogramPerSecond), NanogramsPerSecondTolerance);
            AssertEx.EqualTolerance(PoundsPerHourInOneGramPerSecond, grampersecond.As(MassFlowUnit.PoundPerHour), PoundsPerHourTolerance);
            AssertEx.EqualTolerance(TonnesPerDayInOneGramPerSecond, grampersecond.As(MassFlowUnit.TonnePerDay), TonnesPerDayTolerance);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            AssertEx.EqualTolerance(1, MassFlow.FromCentigramsPerSecond(grampersecond.CentigramsPerSecond).GramsPerSecond, CentigramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromDecagramsPerSecond(grampersecond.DecagramsPerSecond).GramsPerSecond, DecagramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromDecigramsPerSecond(grampersecond.DecigramsPerSecond).GramsPerSecond, DecigramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromGramsPerSecond(grampersecond.GramsPerSecond).GramsPerSecond, GramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromHectogramsPerSecond(grampersecond.HectogramsPerSecond).GramsPerSecond, HectogramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromKilogramsPerHour(grampersecond.KilogramsPerHour).GramsPerSecond, KilogramsPerHourTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromKilogramsPerSecond(grampersecond.KilogramsPerSecond).GramsPerSecond, KilogramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromMicrogramsPerSecond(grampersecond.MicrogramsPerSecond).GramsPerSecond, MicrogramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromMilligramsPerSecond(grampersecond.MilligramsPerSecond).GramsPerSecond, MilligramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromNanogramsPerSecond(grampersecond.NanogramsPerSecond).GramsPerSecond, NanogramsPerSecondTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromPoundsPerHour(grampersecond.PoundsPerHour).GramsPerSecond, PoundsPerHourTolerance);
            AssertEx.EqualTolerance(1, MassFlow.FromTonnesPerDay(grampersecond.TonnesPerDay).GramsPerSecond, TonnesPerDayTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            MassFlow v = MassFlow.FromGramsPerSecond(1);
            AssertEx.EqualTolerance(-1, -v.GramsPerSecond, GramsPerSecondTolerance);
            AssertEx.EqualTolerance(2, (MassFlow.FromGramsPerSecond(3)-v).GramsPerSecond, GramsPerSecondTolerance);
            AssertEx.EqualTolerance(2, (v + v).GramsPerSecond, GramsPerSecondTolerance);
            AssertEx.EqualTolerance(10, (v*10).GramsPerSecond, GramsPerSecondTolerance);
            AssertEx.EqualTolerance(10, (10*v).GramsPerSecond, GramsPerSecondTolerance);
            AssertEx.EqualTolerance(2, (MassFlow.FromGramsPerSecond(10)/5).GramsPerSecond, GramsPerSecondTolerance);
            AssertEx.EqualTolerance(2, MassFlow.FromGramsPerSecond(10)/MassFlow.FromGramsPerSecond(5), GramsPerSecondTolerance);
        }

        [Fact]
        public void ComparisonOperators()
        {
            MassFlow oneGramPerSecond = MassFlow.FromGramsPerSecond(1);
            MassFlow twoGramsPerSecond = MassFlow.FromGramsPerSecond(2);

            Assert.True(oneGramPerSecond < twoGramsPerSecond);
            Assert.True(oneGramPerSecond <= twoGramsPerSecond);
            Assert.True(twoGramsPerSecond > oneGramPerSecond);
            Assert.True(twoGramsPerSecond >= oneGramPerSecond);

            Assert.False(oneGramPerSecond > twoGramsPerSecond);
            Assert.False(oneGramPerSecond >= twoGramsPerSecond);
            Assert.False(twoGramsPerSecond < oneGramPerSecond);
            Assert.False(twoGramsPerSecond <= oneGramPerSecond);
        }

        [Fact]
        public void CompareToIsImplemented()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.Equal(0, grampersecond.CompareTo(grampersecond));
            Assert.True(grampersecond.CompareTo(MassFlow.Zero) > 0);
            Assert.True(MassFlow.Zero.CompareTo(grampersecond) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.Throws<ArgumentException>(() => grampersecond.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.Throws<ArgumentNullException>(() => grampersecond.CompareTo(null));
        }


        [Fact]
        public void EqualityOperators()
        {
            MassFlow a = MassFlow.FromGramsPerSecond(1);
            MassFlow b = MassFlow.FromGramsPerSecond(2);

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
            MassFlow v = MassFlow.FromGramsPerSecond(1);
            Assert.True(v.Equals(MassFlow.FromGramsPerSecond(1)));
            Assert.False(v.Equals(MassFlow.Zero));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.False(grampersecond.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.False(grampersecond.Equals(null));
        }
    }
}
