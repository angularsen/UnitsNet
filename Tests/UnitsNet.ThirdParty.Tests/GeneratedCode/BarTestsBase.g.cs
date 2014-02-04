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
using UnitsNet.ThirdParty.Units;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.ThirdParty.Tests
{
    /// <summary>
    /// Test of Bar.
    /// </summary>
    [TestFixture]
    public abstract partial class BarTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        public abstract double BarsInOneBar { get; }
        public abstract double BarPlusOnesInOneBar { get; }
        public abstract double BarsTripledInOneBar { get; }
        public abstract double TwiceThanBarsInOneBar { get; }

        [Test]
        public void BarToBarUnits()
        {
            Bar bar = Bar.FromBars(1);
            Assert.AreEqual(BarsInOneBar, bar.Bars, Delta);
            Assert.AreEqual(BarPlusOnesInOneBar, bar.BarPlusOnes, Delta);
            Assert.AreEqual(BarsTripledInOneBar, bar.BarsTripled, Delta);
            Assert.AreEqual(TwiceThanBarsInOneBar, bar.TwiceThanBars, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Bar bar = Bar.FromBars(1); 
            Assert.AreEqual(1, Bar.FromBars(bar.Bars).Bars, Delta);
            Assert.AreEqual(1, Bar.FromBarPlusOnes(bar.BarPlusOnes).Bars, Delta);
            Assert.AreEqual(1, Bar.FromBarsTripled(bar.BarsTripled).Bars, Delta);
            Assert.AreEqual(1, Bar.FromTwiceThanBars(bar.TwiceThanBars).Bars, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Bar v = Bar.FromBars(1);
            Assert.AreEqual(-1, -v.Bars, Delta);
            Assert.AreEqual(2, (Bar.FromBars(3)-v).Bars, Delta);
            Assert.AreEqual(2, (v + v).Bars, Delta);
            Assert.AreEqual(10, (v*10).Bars, Delta);
            Assert.AreEqual(10, (10*v).Bars, Delta);
            Assert.AreEqual(2, (Bar.FromBars(10)/5).Bars, Delta);
            Assert.AreEqual(2, Bar.FromBars(10)/Bar.FromBars(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Bar oneBar = Bar.FromBars(1);
            Bar twoBars = Bar.FromBars(2);

            Assert.True(oneBar < twoBars);
            Assert.True(oneBar <= twoBars);
            Assert.True(twoBars > oneBar);
            Assert.True(twoBars >= oneBar);

            Assert.False(oneBar > twoBars);
            Assert.False(oneBar >= twoBars);
            Assert.False(twoBars < oneBar);
            Assert.False(twoBars <= oneBar);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Bar bar = Bar.FromBars(1);
            Assert.AreEqual(0, bar.CompareTo(bar));
            Assert.Greater(bar.CompareTo(Bar.Zero), 0);
            Assert.Less(Bar.Zero.CompareTo(bar), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Bar bar = Bar.FromBars(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            bar.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Bar bar = Bar.FromBars(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            bar.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Bar a = Bar.FromBars(1);
            Bar b = Bar.FromBars(2);

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
            Bar v = Bar.FromBars(1);
            Assert.IsTrue(v.Equals(Bar.FromBars(1)));
            Assert.IsFalse(v.Equals(Bar.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Bar bar = Bar.FromBars(1);
            Assert.IsFalse(bar.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Bar bar = Bar.FromBars(1);
            Assert.IsFalse(bar.Equals(null));
        }

        [Test]
        public void BarUnitHasAnEnumerationNamedUndefinedEqualToZero()
        {
            Assert.AreEqual("Undefined", Enum.ToObject(typeof (BarUnit), 0).ToString(), "Enumeration 'BarUnit.Undefined = 0' not found.");
        }

        [Test]
        public void From_DynamicConversion()
        {
            Assert.AreEqual(Bar.FromBars(1), Bar.From(1, BarUnit.Bar));
            Assert.AreEqual(Bar.FromBarPlusOnes(1), Bar.From(1, BarUnit.BarPlus1));
            Assert.AreEqual(Bar.FromBarsTripled(1), Bar.From(1, BarUnit.BarTripled));
            Assert.AreEqual(Bar.FromTwiceThanBars(1), Bar.From(1, BarUnit.TwiceThanBar));
        }
        
        [Test]
        public void Convert_Conversion()
        {
            var from = Bar.FromBars(1);
            Assert.AreEqual(from.Bars, from.Convert(BarUnit.Bar));
            Assert.AreEqual(from.BarPlusOnes, from.Convert(BarUnit.BarPlus1));
            Assert.AreEqual(from.BarsTripled, from.Convert(BarUnit.BarTripled));
            Assert.AreEqual(from.TwiceThanBars, from.Convert(BarUnit.TwiceThanBar));
        }

        [Test]
        public void Convert_ThrowsOnInvalidUnit()
        {
            var from = Bar.FromBars(1);
            Assert.Throws<NotImplementedException>(() => from.Convert(0));
        }

        [Test]
        public void TryConvert_Conversion()
        {
            var from = Bar.FromBars(1);
            double val;

            Assert.True(from.TryConvert(BarUnit.Bar, out val));
            Assert.AreEqual(from.Bars, val);

            Assert.True(from.TryConvert(BarUnit.BarPlus1, out val));
            Assert.AreEqual(from.BarPlusOnes, val);

            Assert.True(from.TryConvert(BarUnit.BarTripled, out val));
            Assert.AreEqual(from.BarsTripled, val);

            Assert.True(from.TryConvert(BarUnit.TwiceThanBar, out val));
            Assert.AreEqual(from.TwiceThanBars, val);
        }

        [Test]
        public void TryConvert_ReturnsFalseOnInvalidUnit()
        {
            var from = Bar.FromBars(1);
            double val;
            Assert.False(from.TryConvert(0, out val));
        }
    }
}
