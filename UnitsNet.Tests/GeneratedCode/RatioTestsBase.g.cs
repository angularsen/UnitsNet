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
    /// Test of Ratio.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class RatioTestsBase
    {
        protected abstract double DecimalFractionsInOneDecimalFraction { get; }
        protected abstract double PartsPerBillionInOneDecimalFraction { get; }
        protected abstract double PartsPerMillionInOneDecimalFraction { get; }
        protected abstract double PartsPerThousandInOneDecimalFraction { get; }
        protected abstract double PartsPerTrillionInOneDecimalFraction { get; }
        protected abstract double PercentInOneDecimalFraction { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DecimalFractionsTolerance { get { return 1e-5; } }
        protected virtual double PartsPerBillionTolerance { get { return 1e-5; } }
        protected virtual double PartsPerMillionTolerance { get { return 1e-5; } }
        protected virtual double PartsPerThousandTolerance { get { return 1e-5; } }
        protected virtual double PartsPerTrillionTolerance { get { return 1e-5; } }
        protected virtual double PercentTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void DecimalFractionToRatioUnits()
        {
            Ratio decimalfraction = Ratio.FromDecimalFractions(1);
            Assert.AreEqual(DecimalFractionsInOneDecimalFraction, decimalfraction.DecimalFractions, DecimalFractionsTolerance);
            Assert.AreEqual(PartsPerBillionInOneDecimalFraction, decimalfraction.PartsPerBillion, PartsPerBillionTolerance);
            Assert.AreEqual(PartsPerMillionInOneDecimalFraction, decimalfraction.PartsPerMillion, PartsPerMillionTolerance);
            Assert.AreEqual(PartsPerThousandInOneDecimalFraction, decimalfraction.PartsPerThousand, PartsPerThousandTolerance);
            Assert.AreEqual(PartsPerTrillionInOneDecimalFraction, decimalfraction.PartsPerTrillion, PartsPerTrillionTolerance);
            Assert.AreEqual(PercentInOneDecimalFraction, decimalfraction.Percent, PercentTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.DecimalFraction).DecimalFractions, DecimalFractionsTolerance);
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.PartPerBillion).PartsPerBillion, PartsPerBillionTolerance);
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.PartPerMillion).PartsPerMillion, PartsPerMillionTolerance);
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.PartPerThousand).PartsPerThousand, PartsPerThousandTolerance);
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.PartPerTrillion).PartsPerTrillion, PartsPerTrillionTolerance);
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.Percent).Percent, PercentTolerance);
        }

        [Test]
        public void As()
        {
            var decimalfraction = Ratio.FromDecimalFractions(1);
            Assert.AreEqual(DecimalFractionsInOneDecimalFraction, decimalfraction.As(RatioUnit.DecimalFraction), DecimalFractionsTolerance);
            Assert.AreEqual(PartsPerBillionInOneDecimalFraction, decimalfraction.As(RatioUnit.PartPerBillion), PartsPerBillionTolerance);
            Assert.AreEqual(PartsPerMillionInOneDecimalFraction, decimalfraction.As(RatioUnit.PartPerMillion), PartsPerMillionTolerance);
            Assert.AreEqual(PartsPerThousandInOneDecimalFraction, decimalfraction.As(RatioUnit.PartPerThousand), PartsPerThousandTolerance);
            Assert.AreEqual(PartsPerTrillionInOneDecimalFraction, decimalfraction.As(RatioUnit.PartPerTrillion), PartsPerTrillionTolerance);
            Assert.AreEqual(PercentInOneDecimalFraction, decimalfraction.As(RatioUnit.Percent), PercentTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Ratio decimalfraction = Ratio.FromDecimalFractions(1);
            Assert.AreEqual(1, Ratio.FromDecimalFractions(decimalfraction.DecimalFractions).DecimalFractions, DecimalFractionsTolerance);
            Assert.AreEqual(1, Ratio.FromPartsPerBillion(decimalfraction.PartsPerBillion).DecimalFractions, PartsPerBillionTolerance);
            Assert.AreEqual(1, Ratio.FromPartsPerMillion(decimalfraction.PartsPerMillion).DecimalFractions, PartsPerMillionTolerance);
            Assert.AreEqual(1, Ratio.FromPartsPerThousand(decimalfraction.PartsPerThousand).DecimalFractions, PartsPerThousandTolerance);
            Assert.AreEqual(1, Ratio.FromPartsPerTrillion(decimalfraction.PartsPerTrillion).DecimalFractions, PartsPerTrillionTolerance);
            Assert.AreEqual(1, Ratio.FromPercent(decimalfraction.Percent).DecimalFractions, PercentTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Ratio v = Ratio.FromDecimalFractions(1);
            Assert.AreEqual(-1, -v.DecimalFractions, DecimalFractionsTolerance);
            Assert.AreEqual(2, (Ratio.FromDecimalFractions(3)-v).DecimalFractions, DecimalFractionsTolerance);
            Assert.AreEqual(2, (v + v).DecimalFractions, DecimalFractionsTolerance);
            Assert.AreEqual(10, (v*10).DecimalFractions, DecimalFractionsTolerance);
            Assert.AreEqual(10, (10*v).DecimalFractions, DecimalFractionsTolerance);
            Assert.AreEqual(2, (Ratio.FromDecimalFractions(10)/5).DecimalFractions, DecimalFractionsTolerance);
            Assert.AreEqual(2, Ratio.FromDecimalFractions(10)/Ratio.FromDecimalFractions(5), DecimalFractionsTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Ratio oneDecimalFraction = Ratio.FromDecimalFractions(1);
            Ratio twoDecimalFractions = Ratio.FromDecimalFractions(2);

            Assert.True(oneDecimalFraction < twoDecimalFractions);
            Assert.True(oneDecimalFraction <= twoDecimalFractions);
            Assert.True(twoDecimalFractions > oneDecimalFraction);
            Assert.True(twoDecimalFractions >= oneDecimalFraction);

            Assert.False(oneDecimalFraction > twoDecimalFractions);
            Assert.False(oneDecimalFraction >= twoDecimalFractions);
            Assert.False(twoDecimalFractions < oneDecimalFraction);
            Assert.False(twoDecimalFractions <= oneDecimalFraction);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Ratio decimalfraction = Ratio.FromDecimalFractions(1);
            Assert.AreEqual(0, decimalfraction.CompareTo(decimalfraction));
            Assert.Greater(decimalfraction.CompareTo(Ratio.Zero), 0);
            Assert.Less(Ratio.Zero.CompareTo(decimalfraction), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Ratio decimalfraction = Ratio.FromDecimalFractions(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            decimalfraction.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Ratio decimalfraction = Ratio.FromDecimalFractions(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            decimalfraction.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Ratio a = Ratio.FromDecimalFractions(1);
            Ratio b = Ratio.FromDecimalFractions(2);

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
            Ratio v = Ratio.FromDecimalFractions(1);
            Assert.IsTrue(v.Equals(Ratio.FromDecimalFractions(1)));
            Assert.IsFalse(v.Equals(Ratio.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Ratio decimalfraction = Ratio.FromDecimalFractions(1);
            Assert.IsFalse(decimalfraction.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Ratio decimalfraction = Ratio.FromDecimalFractions(1);
            Assert.IsFalse(decimalfraction.Equals(null));
        }
    }
}
