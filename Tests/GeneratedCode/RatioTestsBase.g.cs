// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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
    public abstract partial class RatioTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        public abstract double DecimalFractionsInOneDecimalFraction { get; }
        public abstract double PartsPerBillionsInOneDecimalFraction { get; }
        public abstract double PartsPerMillionsInOneDecimalFraction { get; }
        public abstract double PartsPerThousandsInOneDecimalFraction { get; }
        public abstract double PartsPerTrillionsInOneDecimalFraction { get; }
        public abstract double PercentsInOneDecimalFraction { get; }

        [Test]
        public void DecimalFractionToRatioUnits()
        {
            Ratio decimalfraction = Ratio.FromDecimalFractions(1);
            Assert.AreEqual(DecimalFractionsInOneDecimalFraction, decimalfraction.DecimalFractions, Delta);
            Assert.AreEqual(PartsPerBillionsInOneDecimalFraction, decimalfraction.PartsPerBillions, Delta);
            Assert.AreEqual(PartsPerMillionsInOneDecimalFraction, decimalfraction.PartsPerMillions, Delta);
            Assert.AreEqual(PartsPerThousandsInOneDecimalFraction, decimalfraction.PartsPerThousands, Delta);
            Assert.AreEqual(PartsPerTrillionsInOneDecimalFraction, decimalfraction.PartsPerTrillions, Delta);
            Assert.AreEqual(PercentsInOneDecimalFraction, decimalfraction.Percents, Delta);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.DecimalFraction).DecimalFractions, Delta);
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.PartsPerBillion).PartsPerBillions, Delta);
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.PartsPerMillion).PartsPerMillions, Delta);
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.PartsPerThousand).PartsPerThousands, Delta);
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.PartsPerTrillion).PartsPerTrillions, Delta);
            Assert.AreEqual(1, Ratio.From(1, RatioUnit.Percent).Percents, Delta);
        }


        [Test]
        public void As()
        {
            var decimalfraction = Ratio.FromDecimalFractions(1);
            Assert.AreEqual(DecimalFractionsInOneDecimalFraction, decimalfraction.As(RatioUnit.DecimalFraction), Delta);
            Assert.AreEqual(PartsPerBillionsInOneDecimalFraction, decimalfraction.As(RatioUnit.PartsPerBillion), Delta);
            Assert.AreEqual(PartsPerMillionsInOneDecimalFraction, decimalfraction.As(RatioUnit.PartsPerMillion), Delta);
            Assert.AreEqual(PartsPerThousandsInOneDecimalFraction, decimalfraction.As(RatioUnit.PartsPerThousand), Delta);
            Assert.AreEqual(PartsPerTrillionsInOneDecimalFraction, decimalfraction.As(RatioUnit.PartsPerTrillion), Delta);
            Assert.AreEqual(PercentsInOneDecimalFraction, decimalfraction.As(RatioUnit.Percent), Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Ratio decimalfraction = Ratio.FromDecimalFractions(1); 
            Assert.AreEqual(1, Ratio.FromDecimalFractions(decimalfraction.DecimalFractions).DecimalFractions, Delta);
            Assert.AreEqual(1, Ratio.FromPartsPerBillions(decimalfraction.PartsPerBillions).DecimalFractions, Delta);
            Assert.AreEqual(1, Ratio.FromPartsPerMillions(decimalfraction.PartsPerMillions).DecimalFractions, Delta);
            Assert.AreEqual(1, Ratio.FromPartsPerThousands(decimalfraction.PartsPerThousands).DecimalFractions, Delta);
            Assert.AreEqual(1, Ratio.FromPartsPerTrillions(decimalfraction.PartsPerTrillions).DecimalFractions, Delta);
            Assert.AreEqual(1, Ratio.FromPercents(decimalfraction.Percents).DecimalFractions, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Ratio v = Ratio.FromDecimalFractions(1);
            Assert.AreEqual(-1, -v.DecimalFractions, Delta);
            Assert.AreEqual(2, (Ratio.FromDecimalFractions(3)-v).DecimalFractions, Delta);
            Assert.AreEqual(2, (v + v).DecimalFractions, Delta);
            Assert.AreEqual(10, (v*10).DecimalFractions, Delta);
            Assert.AreEqual(10, (10*v).DecimalFractions, Delta);
            Assert.AreEqual(2, (Ratio.FromDecimalFractions(10)/5).DecimalFractions, Delta);
            Assert.AreEqual(2, Ratio.FromDecimalFractions(10)/Ratio.FromDecimalFractions(5), Delta);
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
