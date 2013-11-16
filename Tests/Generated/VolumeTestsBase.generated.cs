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

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Volume.
    /// </summary>
    public abstract partial class VolumeTestsBase
    {
        protected abstract double Delta { get; }

        protected abstract double CentilitersInOneCubicMeter { get; }
        protected abstract double CubicCentimetersInOneCubicMeter { get; }
        protected abstract double CubicDecimetersInOneCubicMeter { get; }
        protected abstract double CubicFeetInOneCubicMeter { get; }
        protected abstract double CubicInchesInOneCubicMeter { get; }
        protected abstract double CubicKilometersInOneCubicMeter { get; }
        protected abstract double CubicMetersInOneCubicMeter { get; }
        protected abstract double CubicMilesInOneCubicMeter { get; }
        protected abstract double CubicMillimetersInOneCubicMeter { get; }
        protected abstract double CubicYardsInOneCubicMeter { get; }
        protected abstract double DecilitersInOneCubicMeter { get; }
        protected abstract double HectolitersInOneCubicMeter { get; }
        protected abstract double ImperialGallonsInOneCubicMeter { get; }
        protected abstract double ImperialOuncesInOneCubicMeter { get; }
        protected abstract double LitersInOneCubicMeter { get; }
        protected abstract double MillilitersInOneCubicMeter { get; }
        protected abstract double UsGallonsInOneCubicMeter { get; }
        protected abstract double UsOuncesInOneCubicMeter { get; }

        [Test]
        public void CubicMeterToVolumeUnits()
        {
            Volume cubicmeter = Volume.FromCubicMeters(1);
            Assert.AreEqual(CentilitersInOneCubicMeter, cubicmeter.Centiliters, Delta);
            Assert.AreEqual(CubicCentimetersInOneCubicMeter, cubicmeter.CubicCentimeters, Delta);
            Assert.AreEqual(CubicDecimetersInOneCubicMeter, cubicmeter.CubicDecimeters, Delta);
            Assert.AreEqual(CubicFeetInOneCubicMeter, cubicmeter.CubicFeet, Delta);
            Assert.AreEqual(CubicInchesInOneCubicMeter, cubicmeter.CubicInches, Delta);
            Assert.AreEqual(CubicKilometersInOneCubicMeter, cubicmeter.CubicKilometers, Delta);
            Assert.AreEqual(CubicMetersInOneCubicMeter, cubicmeter.CubicMeters, Delta);
            Assert.AreEqual(CubicMilesInOneCubicMeter, cubicmeter.CubicMiles, Delta);
            Assert.AreEqual(CubicMillimetersInOneCubicMeter, cubicmeter.CubicMillimeters, Delta);
            Assert.AreEqual(CubicYardsInOneCubicMeter, cubicmeter.CubicYards, Delta);
            Assert.AreEqual(DecilitersInOneCubicMeter, cubicmeter.Deciliters, Delta);
            Assert.AreEqual(HectolitersInOneCubicMeter, cubicmeter.Hectoliters, Delta);
            Assert.AreEqual(ImperialGallonsInOneCubicMeter, cubicmeter.ImperialGallons, Delta);
            Assert.AreEqual(ImperialOuncesInOneCubicMeter, cubicmeter.ImperialOunces, Delta);
            Assert.AreEqual(LitersInOneCubicMeter, cubicmeter.Liters, Delta);
            Assert.AreEqual(MillilitersInOneCubicMeter, cubicmeter.Milliliters, Delta);
            Assert.AreEqual(UsGallonsInOneCubicMeter, cubicmeter.UsGallons, Delta);
            Assert.AreEqual(UsOuncesInOneCubicMeter, cubicmeter.UsOunces, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Volume cubicmeter = Volume.FromCubicMeters(1); 
            Assert.AreEqual(1, Volume.FromCentiliters(cubicmeter.Centiliters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicCentimeters(cubicmeter.CubicCentimeters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicDecimeters(cubicmeter.CubicDecimeters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicFeet(cubicmeter.CubicFeet).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicInches(cubicmeter.CubicInches).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicKilometers(cubicmeter.CubicKilometers).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicMeters(cubicmeter.CubicMeters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicMiles(cubicmeter.CubicMiles).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicMillimeters(cubicmeter.CubicMillimeters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromCubicYards(cubicmeter.CubicYards).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromDeciliters(cubicmeter.Deciliters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromHectoliters(cubicmeter.Hectoliters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromImperialGallons(cubicmeter.ImperialGallons).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromImperialOunces(cubicmeter.ImperialOunces).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromLiters(cubicmeter.Liters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromMilliliters(cubicmeter.Milliliters).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromUsGallons(cubicmeter.UsGallons).CubicMeters, Delta);
            Assert.AreEqual(1, Volume.FromUsOunces(cubicmeter.UsOunces).CubicMeters, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Volume v = Volume.FromCubicMeters(1);
            Assert.AreEqual(-1, -v.CubicMeters, Delta);
            Assert.AreEqual(2, (Volume.FromCubicMeters(3)-v).CubicMeters, Delta);
            Assert.AreEqual(2, (v + v).CubicMeters, Delta);
            Assert.AreEqual(10, (v*10).CubicMeters, Delta);
            Assert.AreEqual(10, (10*v).CubicMeters, Delta);
            Assert.AreEqual(2, (Volume.FromCubicMeters(10)/5).CubicMeters, Delta);
            Assert.AreEqual(2, Volume.FromCubicMeters(10)/Volume.FromCubicMeters(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Volume oneCubicMeter = Volume.FromCubicMeters(1);
            Volume twoCubicMeters = Volume.FromCubicMeters(2);

            Assert.True(oneCubicMeter < twoCubicMeters);
            Assert.True(oneCubicMeter <= twoCubicMeters);
            Assert.True(twoCubicMeters > oneCubicMeter);
            Assert.True(twoCubicMeters >= oneCubicMeter);

            Assert.False(oneCubicMeter > twoCubicMeters);
            Assert.False(oneCubicMeter >= twoCubicMeters);
            Assert.False(twoCubicMeters < oneCubicMeter);
            Assert.False(twoCubicMeters <= oneCubicMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Volume cubicmeter = Volume.FromCubicMeters(1);
            Assert.AreEqual(0, cubicmeter.CompareTo(cubicmeter));
            Assert.Greater(cubicmeter.CompareTo(Volume.Zero), 0);
            Assert.Less(Volume.Zero.CompareTo(cubicmeter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Volume cubicmeter = Volume.FromCubicMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            cubicmeter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Volume cubicmeter = Volume.FromCubicMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            cubicmeter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Volume a = Volume.FromCubicMeters(1);
            Volume b = Volume.FromCubicMeters(2);

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
            Volume v = Volume.FromCubicMeters(1);
            Assert.IsTrue(v.Equals(Volume.FromCubicMeters(1)));
            Assert.IsFalse(v.Equals(Volume.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Volume cubicmeter = Volume.FromCubicMeters(1);
            Assert.IsFalse(cubicmeter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Volume cubicmeter = Volume.FromCubicMeters(1);
            Assert.IsFalse(cubicmeter.Equals(null));
        }
    }
}
