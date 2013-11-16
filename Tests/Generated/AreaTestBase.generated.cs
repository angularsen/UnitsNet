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

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Area.
    /// </summary>
    public abstract partial class AreaTestsBase
    {
        protected abstract double Delta { get; }

        protected abstract double OneSquareMeterInSquareCentimeters { get; }
        protected abstract double OneSquareMeterInSquareDecimeters { get; }
        protected abstract double OneSquareMeterInSquareFeet { get; }
        protected abstract double OneSquareMeterInSquareInches { get; }
        protected abstract double OneSquareMeterInSquareKilometers { get; }
        protected abstract double OneSquareMeterInSquareMeters { get; }
        protected abstract double OneSquareMeterInSquareMiles { get; }
        protected abstract double OneSquareMeterInSquareMillimeters { get; }
        protected abstract double OneSquareMeterInSquareYards { get; }

        [Test]
        public void SquareMeterToAreaUnits()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.AreEqual(OneSquareMeterInSquareCentimeters, squaremeter.SquareCentimeters, Delta);
            Assert.AreEqual(OneSquareMeterInSquareDecimeters, squaremeter.SquareDecimeters, Delta);
            Assert.AreEqual(OneSquareMeterInSquareFeet, squaremeter.SquareFeet, Delta);
            Assert.AreEqual(OneSquareMeterInSquareInches, squaremeter.SquareInches, Delta);
            Assert.AreEqual(OneSquareMeterInSquareKilometers, squaremeter.SquareKilometers, Delta);
            Assert.AreEqual(OneSquareMeterInSquareMeters, squaremeter.SquareMeters, Delta);
            Assert.AreEqual(OneSquareMeterInSquareMiles, squaremeter.SquareMiles, Delta);
            Assert.AreEqual(OneSquareMeterInSquareMillimeters, squaremeter.SquareMillimeters, Delta);
            Assert.AreEqual(OneSquareMeterInSquareYards, squaremeter.SquareYards, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Area squaremeter = Area.FromSquareMeters(1); 
            Assert.AreEqual(1, Area.FromSquareCentimeters(squaremeter.SquareCentimeters).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareDecimeters(squaremeter.SquareDecimeters).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareFeet(squaremeter.SquareFeet).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareInches(squaremeter.SquareInches).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareKilometers(squaremeter.SquareKilometers).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareMeters(squaremeter.SquareMeters).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareMiles(squaremeter.SquareMiles).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareMillimeters(squaremeter.SquareMillimeters).SquareMeters, Delta);
            Assert.AreEqual(1, Area.FromSquareYards(squaremeter.SquareYards).SquareMeters, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Area v = Area.FromSquareMeters(1);
            Assert.AreEqual(-1, -v.SquareMeters, Delta);
            Assert.AreEqual(2, (Area.FromSquareMeters(3)-v).SquareMeters, Delta);
            Assert.AreEqual(2, (v + v).SquareMeters, Delta);
            Assert.AreEqual(10, (v*10).SquareMeters, Delta);
            Assert.AreEqual(10, (10*v).SquareMeters, Delta);
            Assert.AreEqual(2, (Area.FromSquareMeters(10)/5).SquareMeters, Delta);
            Assert.AreEqual(2, Area.FromSquareMeters(10)/Area.FromSquareMeters(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Area oneSquareMeter = Area.FromSquareMeters(1);
            Area twoSquareMeters = Area.FromSquareMeters(2);

            Assert.True(oneSquareMeter < twoSquareMeters);
            Assert.True(oneSquareMeter <= twoSquareMeters);
            Assert.True(twoSquareMeters > oneSquareMeter);
            Assert.True(twoSquareMeters >= oneSquareMeter);

            Assert.False(oneSquareMeter > twoSquareMeters);
            Assert.False(oneSquareMeter >= twoSquareMeters);
            Assert.False(twoSquareMeters < oneSquareMeter);
            Assert.False(twoSquareMeters <= oneSquareMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.AreEqual(0, squaremeter.CompareTo(squaremeter));
            Assert.Greater(squaremeter.CompareTo(Area.Zero), 0);
            Assert.Less(Area.Zero.CompareTo(squaremeter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Area squaremeter = Area.FromSquareMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            squaremeter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Area squaremeter = Area.FromSquareMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            squaremeter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Area a = Area.FromSquareMeters(1);
            Area b = Area.FromSquareMeters(2);

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
            Area v = Area.FromSquareMeters(1);
            Assert.IsTrue(v.Equals(Area.FromSquareMeters(1)));
            Assert.IsFalse(v.Equals(Area.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.IsFalse(squaremeter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Area squaremeter = Area.FromSquareMeters(1);
            Assert.IsFalse(squaremeter.Equals(null));
        }
    }
}
