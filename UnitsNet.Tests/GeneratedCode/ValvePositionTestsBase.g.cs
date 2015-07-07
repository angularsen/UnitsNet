// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
    /// Test of ValvePosition.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ValvePositionTestsBase
    {
        protected abstract double ClosePercentagesInOneOpenPercentage { get; }
        protected abstract double DegreesInOneOpenPercentage { get; }
        protected abstract double OpenPercentagesInOneOpenPercentage { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double ClosePercentagesTolerance { get { return 1e-5; } }
        protected virtual double DegreesTolerance { get { return 1e-5; } }
        protected virtual double OpenPercentagesTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void OpenPercentageToValvePositionUnits()
        {
            ValvePosition openpercentage = ValvePosition.FromOpenPercentages(1);
            Assert.AreEqual(ClosePercentagesInOneOpenPercentage, openpercentage.ClosePercentages, ClosePercentagesTolerance);
            Assert.AreEqual(DegreesInOneOpenPercentage, openpercentage.Degrees, DegreesTolerance);
            Assert.AreEqual(OpenPercentagesInOneOpenPercentage, openpercentage.OpenPercentages, OpenPercentagesTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, ValvePosition.From(1, ValvePositionUnit.ClosePercentage).ClosePercentages, ClosePercentagesTolerance);
            Assert.AreEqual(1, ValvePosition.From(1, ValvePositionUnit.Degree).Degrees, DegreesTolerance);
            Assert.AreEqual(1, ValvePosition.From(1, ValvePositionUnit.OpenPercentage).OpenPercentages, OpenPercentagesTolerance);
        }

        [Test]
        public void As()
        {
            var openpercentage = ValvePosition.FromOpenPercentages(1);
            Assert.AreEqual(ClosePercentagesInOneOpenPercentage, openpercentage.As(ValvePositionUnit.ClosePercentage), ClosePercentagesTolerance);
            Assert.AreEqual(DegreesInOneOpenPercentage, openpercentage.As(ValvePositionUnit.Degree), DegreesTolerance);
            Assert.AreEqual(OpenPercentagesInOneOpenPercentage, openpercentage.As(ValvePositionUnit.OpenPercentage), OpenPercentagesTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            ValvePosition openpercentage = ValvePosition.FromOpenPercentages(1);
            Assert.AreEqual(1, ValvePosition.FromClosePercentages(openpercentage.ClosePercentages).OpenPercentages, ClosePercentagesTolerance);
            Assert.AreEqual(1, ValvePosition.FromDegrees(openpercentage.Degrees).OpenPercentages, DegreesTolerance);
            Assert.AreEqual(1, ValvePosition.FromOpenPercentages(openpercentage.OpenPercentages).OpenPercentages, OpenPercentagesTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            ValvePosition v = ValvePosition.FromOpenPercentages(1);
            Assert.AreEqual(-1, -v.OpenPercentages, OpenPercentagesTolerance);
            Assert.AreEqual(2, (ValvePosition.FromOpenPercentages(3)-v).OpenPercentages, OpenPercentagesTolerance);
            Assert.AreEqual(2, (v + v).OpenPercentages, OpenPercentagesTolerance);
            Assert.AreEqual(10, (v*10).OpenPercentages, OpenPercentagesTolerance);
            Assert.AreEqual(10, (10*v).OpenPercentages, OpenPercentagesTolerance);
            Assert.AreEqual(2, (ValvePosition.FromOpenPercentages(10)/5).OpenPercentages, OpenPercentagesTolerance);
            Assert.AreEqual(2, ValvePosition.FromOpenPercentages(10)/ValvePosition.FromOpenPercentages(5), OpenPercentagesTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            ValvePosition oneOpenPercentage = ValvePosition.FromOpenPercentages(1);
            ValvePosition twoOpenPercentages = ValvePosition.FromOpenPercentages(2);

            Assert.True(oneOpenPercentage < twoOpenPercentages);
            Assert.True(oneOpenPercentage <= twoOpenPercentages);
            Assert.True(twoOpenPercentages > oneOpenPercentage);
            Assert.True(twoOpenPercentages >= oneOpenPercentage);

            Assert.False(oneOpenPercentage > twoOpenPercentages);
            Assert.False(oneOpenPercentage >= twoOpenPercentages);
            Assert.False(twoOpenPercentages < oneOpenPercentage);
            Assert.False(twoOpenPercentages <= oneOpenPercentage);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            ValvePosition openpercentage = ValvePosition.FromOpenPercentages(1);
            Assert.AreEqual(0, openpercentage.CompareTo(openpercentage));
            Assert.Greater(openpercentage.CompareTo(ValvePosition.Zero), 0);
            Assert.Less(ValvePosition.Zero.CompareTo(openpercentage), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            ValvePosition openpercentage = ValvePosition.FromOpenPercentages(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            openpercentage.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            ValvePosition openpercentage = ValvePosition.FromOpenPercentages(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            openpercentage.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            ValvePosition a = ValvePosition.FromOpenPercentages(1);
            ValvePosition b = ValvePosition.FromOpenPercentages(2);

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
            ValvePosition v = ValvePosition.FromOpenPercentages(1);
            Assert.IsTrue(v.Equals(ValvePosition.FromOpenPercentages(1)));
            Assert.IsFalse(v.Equals(ValvePosition.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ValvePosition openpercentage = ValvePosition.FromOpenPercentages(1);
            Assert.IsFalse(openpercentage.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            ValvePosition openpercentage = ValvePosition.FromOpenPercentages(1);
            Assert.IsFalse(openpercentage.Equals(null));
        }
    }
}
