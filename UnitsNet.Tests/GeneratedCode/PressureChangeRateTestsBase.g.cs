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
    /// Test of PressureChangeRate.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class PressureChangeRateTestsBase
    {
        protected abstract double AtmospheresPerSecondInOnePascalPerSecond { get; }
        protected abstract double KilopascalsPerSecondInOnePascalPerSecond { get; }
        protected abstract double MegapascalsPerSecondInOnePascalPerSecond { get; }
        protected abstract double PascalsPerSecondInOnePascalPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double AtmospheresPerSecondTolerance { get { return 1e-5; } }
        protected virtual double KilopascalsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MegapascalsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double PascalsPerSecondTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void PascalPerSecondToPressureChangeRateUnits()
        {
            PressureChangeRate pascalpersecond = PressureChangeRate.FromPascalsPerSecond(1);
            Assert.AreEqual(AtmospheresPerSecondInOnePascalPerSecond, pascalpersecond.AtmospheresPerSecond, AtmospheresPerSecondTolerance);
            Assert.AreEqual(KilopascalsPerSecondInOnePascalPerSecond, pascalpersecond.KilopascalsPerSecond, KilopascalsPerSecondTolerance);
            Assert.AreEqual(MegapascalsPerSecondInOnePascalPerSecond, pascalpersecond.MegapascalsPerSecond, MegapascalsPerSecondTolerance);
            Assert.AreEqual(PascalsPerSecondInOnePascalPerSecond, pascalpersecond.PascalsPerSecond, PascalsPerSecondTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, PressureChangeRate.From(1, PressureChangeRateUnit.AtmospherePerSecond).AtmospheresPerSecond, AtmospheresPerSecondTolerance);
            Assert.AreEqual(1, PressureChangeRate.From(1, PressureChangeRateUnit.KilopascalPerSecond).KilopascalsPerSecond, KilopascalsPerSecondTolerance);
            Assert.AreEqual(1, PressureChangeRate.From(1, PressureChangeRateUnit.MegapascalPerSecond).MegapascalsPerSecond, MegapascalsPerSecondTolerance);
            Assert.AreEqual(1, PressureChangeRate.From(1, PressureChangeRateUnit.PascalPerSecond).PascalsPerSecond, PascalsPerSecondTolerance);
        }

        [Test]
        public void As()
        {
            var pascalpersecond = PressureChangeRate.FromPascalsPerSecond(1);
            Assert.AreEqual(AtmospheresPerSecondInOnePascalPerSecond, pascalpersecond.As(PressureChangeRateUnit.AtmospherePerSecond), AtmospheresPerSecondTolerance);
            Assert.AreEqual(KilopascalsPerSecondInOnePascalPerSecond, pascalpersecond.As(PressureChangeRateUnit.KilopascalPerSecond), KilopascalsPerSecondTolerance);
            Assert.AreEqual(MegapascalsPerSecondInOnePascalPerSecond, pascalpersecond.As(PressureChangeRateUnit.MegapascalPerSecond), MegapascalsPerSecondTolerance);
            Assert.AreEqual(PascalsPerSecondInOnePascalPerSecond, pascalpersecond.As(PressureChangeRateUnit.PascalPerSecond), PascalsPerSecondTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            PressureChangeRate pascalpersecond = PressureChangeRate.FromPascalsPerSecond(1);
            Assert.AreEqual(1, PressureChangeRate.FromAtmospheresPerSecond(pascalpersecond.AtmospheresPerSecond).PascalsPerSecond, AtmospheresPerSecondTolerance);
            Assert.AreEqual(1, PressureChangeRate.FromKilopascalsPerSecond(pascalpersecond.KilopascalsPerSecond).PascalsPerSecond, KilopascalsPerSecondTolerance);
            Assert.AreEqual(1, PressureChangeRate.FromMegapascalsPerSecond(pascalpersecond.MegapascalsPerSecond).PascalsPerSecond, MegapascalsPerSecondTolerance);
            Assert.AreEqual(1, PressureChangeRate.FromPascalsPerSecond(pascalpersecond.PascalsPerSecond).PascalsPerSecond, PascalsPerSecondTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            PressureChangeRate v = PressureChangeRate.FromPascalsPerSecond(1);
            Assert.AreEqual(-1, -v.PascalsPerSecond, PascalsPerSecondTolerance);
            Assert.AreEqual(2, (PressureChangeRate.FromPascalsPerSecond(3)-v).PascalsPerSecond, PascalsPerSecondTolerance);
            Assert.AreEqual(2, (v + v).PascalsPerSecond, PascalsPerSecondTolerance);
            Assert.AreEqual(10, (v*10).PascalsPerSecond, PascalsPerSecondTolerance);
            Assert.AreEqual(10, (10*v).PascalsPerSecond, PascalsPerSecondTolerance);
            Assert.AreEqual(2, (PressureChangeRate.FromPascalsPerSecond(10)/5).PascalsPerSecond, PascalsPerSecondTolerance);
            Assert.AreEqual(2, PressureChangeRate.FromPascalsPerSecond(10)/PressureChangeRate.FromPascalsPerSecond(5), PascalsPerSecondTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            PressureChangeRate onePascalPerSecond = PressureChangeRate.FromPascalsPerSecond(1);
            PressureChangeRate twoPascalsPerSecond = PressureChangeRate.FromPascalsPerSecond(2);

            Assert.True(onePascalPerSecond < twoPascalsPerSecond);
            Assert.True(onePascalPerSecond <= twoPascalsPerSecond);
            Assert.True(twoPascalsPerSecond > onePascalPerSecond);
            Assert.True(twoPascalsPerSecond >= onePascalPerSecond);

            Assert.False(onePascalPerSecond > twoPascalsPerSecond);
            Assert.False(onePascalPerSecond >= twoPascalsPerSecond);
            Assert.False(twoPascalsPerSecond < onePascalPerSecond);
            Assert.False(twoPascalsPerSecond <= onePascalPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            PressureChangeRate pascalpersecond = PressureChangeRate.FromPascalsPerSecond(1);
            Assert.AreEqual(0, pascalpersecond.CompareTo(pascalpersecond));
            Assert.Greater(pascalpersecond.CompareTo(PressureChangeRate.Zero), 0);
            Assert.Less(PressureChangeRate.Zero.CompareTo(pascalpersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            PressureChangeRate pascalpersecond = PressureChangeRate.FromPascalsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            pascalpersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            PressureChangeRate pascalpersecond = PressureChangeRate.FromPascalsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            pascalpersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            PressureChangeRate a = PressureChangeRate.FromPascalsPerSecond(1);
            PressureChangeRate b = PressureChangeRate.FromPascalsPerSecond(2);

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
            PressureChangeRate v = PressureChangeRate.FromPascalsPerSecond(1);
            Assert.IsTrue(v.Equals(PressureChangeRate.FromPascalsPerSecond(1)));
            Assert.IsFalse(v.Equals(PressureChangeRate.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            PressureChangeRate pascalpersecond = PressureChangeRate.FromPascalsPerSecond(1);
            Assert.IsFalse(pascalpersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            PressureChangeRate pascalpersecond = PressureChangeRate.FromPascalsPerSecond(1);
            Assert.IsFalse(pascalpersecond.Equals(null));
        }
    }
}
