// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/anjdreas/UnitsNet
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
using NUnit.Framework;
using UnitsNet.Units;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of MassFlow.
    /// </summary>
    [TestFixture]
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
        protected virtual double TonnesPerDayTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void GramPerSecondToMassFlowUnits()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.AreEqual(CentigramsPerSecondInOneGramPerSecond, grampersecond.CentigramsPerSecond, CentigramsPerSecondTolerance);
            Assert.AreEqual(DecagramsPerSecondInOneGramPerSecond, grampersecond.DecagramsPerSecond, DecagramsPerSecondTolerance);
            Assert.AreEqual(DecigramsPerSecondInOneGramPerSecond, grampersecond.DecigramsPerSecond, DecigramsPerSecondTolerance);
            Assert.AreEqual(GramsPerSecondInOneGramPerSecond, grampersecond.GramsPerSecond, GramsPerSecondTolerance);
            Assert.AreEqual(HectogramsPerSecondInOneGramPerSecond, grampersecond.HectogramsPerSecond, HectogramsPerSecondTolerance);
            Assert.AreEqual(KilogramsPerHourInOneGramPerSecond, grampersecond.KilogramsPerHour, KilogramsPerHourTolerance);
            Assert.AreEqual(KilogramsPerSecondInOneGramPerSecond, grampersecond.KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(MicrogramsPerSecondInOneGramPerSecond, grampersecond.MicrogramsPerSecond, MicrogramsPerSecondTolerance);
            Assert.AreEqual(MilligramsPerSecondInOneGramPerSecond, grampersecond.MilligramsPerSecond, MilligramsPerSecondTolerance);
            Assert.AreEqual(NanogramsPerSecondInOneGramPerSecond, grampersecond.NanogramsPerSecond, NanogramsPerSecondTolerance);
            Assert.AreEqual(TonnesPerDayInOneGramPerSecond, grampersecond.TonnesPerDay, TonnesPerDayTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.CentigramPerSecond).CentigramsPerSecond, CentigramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.DecagramPerSecond).DecagramsPerSecond, DecagramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.DecigramPerSecond).DecigramsPerSecond, DecigramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.GramPerSecond).GramsPerSecond, GramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.HectogramPerSecond).HectogramsPerSecond, HectogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.KilogramPerHour).KilogramsPerHour, KilogramsPerHourTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.KilogramPerSecond).KilogramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.MicrogramPerSecond).MicrogramsPerSecond, MicrogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.MilligramPerSecond).MilligramsPerSecond, MilligramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.NanogramPerSecond).NanogramsPerSecond, NanogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.From(1, MassFlowUnit.TonnePerDay).TonnesPerDay, TonnesPerDayTolerance);
        }

        [Test]
        public void As()
        {
            var grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.AreEqual(CentigramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.CentigramPerSecond), CentigramsPerSecondTolerance);
            Assert.AreEqual(DecagramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.DecagramPerSecond), DecagramsPerSecondTolerance);
            Assert.AreEqual(DecigramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.DecigramPerSecond), DecigramsPerSecondTolerance);
            Assert.AreEqual(GramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.GramPerSecond), GramsPerSecondTolerance);
            Assert.AreEqual(HectogramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.HectogramPerSecond), HectogramsPerSecondTolerance);
            Assert.AreEqual(KilogramsPerHourInOneGramPerSecond, grampersecond.As(MassFlowUnit.KilogramPerHour), KilogramsPerHourTolerance);
            Assert.AreEqual(KilogramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.KilogramPerSecond), KilogramsPerSecondTolerance);
            Assert.AreEqual(MicrogramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.MicrogramPerSecond), MicrogramsPerSecondTolerance);
            Assert.AreEqual(MilligramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.MilligramPerSecond), MilligramsPerSecondTolerance);
            Assert.AreEqual(NanogramsPerSecondInOneGramPerSecond, grampersecond.As(MassFlowUnit.NanogramPerSecond), NanogramsPerSecondTolerance);
            Assert.AreEqual(TonnesPerDayInOneGramPerSecond, grampersecond.As(MassFlowUnit.TonnePerDay), TonnesPerDayTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.AreEqual(1, MassFlow.FromCentigramsPerSecond(grampersecond.CentigramsPerSecond).GramsPerSecond, CentigramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.FromDecagramsPerSecond(grampersecond.DecagramsPerSecond).GramsPerSecond, DecagramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.FromDecigramsPerSecond(grampersecond.DecigramsPerSecond).GramsPerSecond, DecigramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.FromGramsPerSecond(grampersecond.GramsPerSecond).GramsPerSecond, GramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.FromHectogramsPerSecond(grampersecond.HectogramsPerSecond).GramsPerSecond, HectogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.FromKilogramsPerHour(grampersecond.KilogramsPerHour).GramsPerSecond, KilogramsPerHourTolerance);
            Assert.AreEqual(1, MassFlow.FromKilogramsPerSecond(grampersecond.KilogramsPerSecond).GramsPerSecond, KilogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.FromMicrogramsPerSecond(grampersecond.MicrogramsPerSecond).GramsPerSecond, MicrogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.FromMilligramsPerSecond(grampersecond.MilligramsPerSecond).GramsPerSecond, MilligramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.FromNanogramsPerSecond(grampersecond.NanogramsPerSecond).GramsPerSecond, NanogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlow.FromTonnesPerDay(grampersecond.TonnesPerDay).GramsPerSecond, TonnesPerDayTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            MassFlow v = MassFlow.FromGramsPerSecond(1);
            Assert.AreEqual(-1, -v.GramsPerSecond, GramsPerSecondTolerance);
            Assert.AreEqual(2, (MassFlow.FromGramsPerSecond(3)-v).GramsPerSecond, GramsPerSecondTolerance);
            Assert.AreEqual(2, (v + v).GramsPerSecond, GramsPerSecondTolerance);
            Assert.AreEqual(10, (v*10).GramsPerSecond, GramsPerSecondTolerance);
            Assert.AreEqual(10, (10*v).GramsPerSecond, GramsPerSecondTolerance);
            Assert.AreEqual(2, (MassFlow.FromGramsPerSecond(10)/5).GramsPerSecond, GramsPerSecondTolerance);
            Assert.AreEqual(2, MassFlow.FromGramsPerSecond(10)/MassFlow.FromGramsPerSecond(5), GramsPerSecondTolerance);
        }

        [Test]
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

        [Test]
        public void CompareToIsImplemented()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.AreEqual(0, grampersecond.CompareTo(grampersecond));
            Assert.Greater(grampersecond.CompareTo(MassFlow.Zero), 0);
            Assert.Less(MassFlow.Zero.CompareTo(grampersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            grampersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            grampersecond.CompareTo(null);
        }


        [Test]
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

        [Test]
        public void EqualsIsImplemented()
        {
            MassFlow v = MassFlow.FromGramsPerSecond(1);
            Assert.IsTrue(v.Equals(MassFlow.FromGramsPerSecond(1)));
            Assert.IsFalse(v.Equals(MassFlow.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.IsFalse(grampersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            MassFlow grampersecond = MassFlow.FromGramsPerSecond(1);
            Assert.IsFalse(grampersecond.Equals(null));
        }
    }
}
