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
    /// Test of Length.
    /// </summary>
    public abstract partial class LengthTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        protected abstract double CentimetersInOneMeter { get; }
        protected abstract double DecimetersInOneMeter { get; }
        protected abstract double FeetInOneMeter { get; }
        protected abstract double InchesInOneMeter { get; }
        protected abstract double KilometersInOneMeter { get; }
        protected abstract double MetersInOneMeter { get; }
        protected abstract double MicroinchesInOneMeter { get; }
        protected abstract double MicrometersInOneMeter { get; }
        protected abstract double MilsInOneMeter { get; }
        protected abstract double MilesInOneMeter { get; }
        protected abstract double MillimetersInOneMeter { get; }
        protected abstract double NanometersInOneMeter { get; }
        protected abstract double YardsInOneMeter { get; }

        [Test]
        public void MeterToLengthUnits()
        {
            Length meter = Length.FromMeters(1);
            Assert.AreEqual(CentimetersInOneMeter, meter.Centimeters, Delta);
            Assert.AreEqual(DecimetersInOneMeter, meter.Decimeters, Delta);
            Assert.AreEqual(FeetInOneMeter, meter.Feet, Delta);
            Assert.AreEqual(InchesInOneMeter, meter.Inches, Delta);
            Assert.AreEqual(KilometersInOneMeter, meter.Kilometers, Delta);
            Assert.AreEqual(MetersInOneMeter, meter.Meters, Delta);
            Assert.AreEqual(MicroinchesInOneMeter, meter.Microinches, Delta);
            Assert.AreEqual(MicrometersInOneMeter, meter.Micrometers, Delta);
            Assert.AreEqual(MilsInOneMeter, meter.Mils, Delta);
            Assert.AreEqual(MilesInOneMeter, meter.Miles, Delta);
            Assert.AreEqual(MillimetersInOneMeter, meter.Millimeters, Delta);
            Assert.AreEqual(NanometersInOneMeter, meter.Nanometers, Delta);
            Assert.AreEqual(YardsInOneMeter, meter.Yards, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Length meter = Length.FromMeters(1); 
            Assert.AreEqual(1, Length.FromCentimeters(meter.Centimeters).Meters, Delta);
            Assert.AreEqual(1, Length.FromDecimeters(meter.Decimeters).Meters, Delta);
            Assert.AreEqual(1, Length.FromFeet(meter.Feet).Meters, Delta);
            Assert.AreEqual(1, Length.FromInches(meter.Inches).Meters, Delta);
            Assert.AreEqual(1, Length.FromKilometers(meter.Kilometers).Meters, Delta);
            Assert.AreEqual(1, Length.FromMeters(meter.Meters).Meters, Delta);
            Assert.AreEqual(1, Length.FromMicroinches(meter.Microinches).Meters, Delta);
            Assert.AreEqual(1, Length.FromMicrometers(meter.Micrometers).Meters, Delta);
            Assert.AreEqual(1, Length.FromMils(meter.Mils).Meters, Delta);
            Assert.AreEqual(1, Length.FromMiles(meter.Miles).Meters, Delta);
            Assert.AreEqual(1, Length.FromMillimeters(meter.Millimeters).Meters, Delta);
            Assert.AreEqual(1, Length.FromNanometers(meter.Nanometers).Meters, Delta);
            Assert.AreEqual(1, Length.FromYards(meter.Yards).Meters, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Length v = Length.FromMeters(1);
            Assert.AreEqual(-1, -v.Meters, Delta);
            Assert.AreEqual(2, (Length.FromMeters(3)-v).Meters, Delta);
            Assert.AreEqual(2, (v + v).Meters, Delta);
            Assert.AreEqual(10, (v*10).Meters, Delta);
            Assert.AreEqual(10, (10*v).Meters, Delta);
            Assert.AreEqual(2, (Length.FromMeters(10)/5).Meters, Delta);
            Assert.AreEqual(2, Length.FromMeters(10)/Length.FromMeters(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Length oneMeter = Length.FromMeters(1);
            Length twoMeters = Length.FromMeters(2);

            Assert.True(oneMeter < twoMeters);
            Assert.True(oneMeter <= twoMeters);
            Assert.True(twoMeters > oneMeter);
            Assert.True(twoMeters >= oneMeter);

            Assert.False(oneMeter > twoMeters);
            Assert.False(oneMeter >= twoMeters);
            Assert.False(twoMeters < oneMeter);
            Assert.False(twoMeters <= oneMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Length meter = Length.FromMeters(1);
            Assert.AreEqual(0, meter.CompareTo(meter));
            Assert.Greater(meter.CompareTo(Length.Zero), 0);
            Assert.Less(Length.Zero.CompareTo(meter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Length meter = Length.FromMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Length meter = Length.FromMeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Length a = Length.FromMeters(1);
            Length b = Length.FromMeters(2);

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
            Length v = Length.FromMeters(1);
            Assert.IsTrue(v.Equals(Length.FromMeters(1)));
            Assert.IsFalse(v.Equals(Length.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Length meter = Length.FromMeters(1);
            Assert.IsFalse(meter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Length meter = Length.FromMeters(1);
            Assert.IsFalse(meter.Equals(null));
        }
    }
}
