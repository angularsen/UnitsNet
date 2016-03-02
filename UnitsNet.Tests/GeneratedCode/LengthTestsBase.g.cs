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
    /// Test of Length.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class LengthTestsBase
    {
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
        protected abstract double NauticalMilesInOneMeter { get; }
        protected abstract double YardsInOneMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentimetersTolerance { get { return 1e-5; } }
        protected virtual double DecimetersTolerance { get { return 1e-5; } }
        protected virtual double FeetTolerance { get { return 1e-5; } }
        protected virtual double InchesTolerance { get { return 1e-5; } }
        protected virtual double KilometersTolerance { get { return 1e-5; } }
        protected virtual double MetersTolerance { get { return 1e-5; } }
        protected virtual double MicroinchesTolerance { get { return 1e-5; } }
        protected virtual double MicrometersTolerance { get { return 1e-5; } }
        protected virtual double MilsTolerance { get { return 1e-5; } }
        protected virtual double MilesTolerance { get { return 1e-5; } }
        protected virtual double MillimetersTolerance { get { return 1e-5; } }
        protected virtual double NanometersTolerance { get { return 1e-5; } }
        protected virtual double NauticalMilesTolerance { get { return 1e-5; } }
        protected virtual double YardsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void MeterToLengthUnits()
        {
            Length meter = Length.FromMeters(1);
            Assert.AreEqual(CentimetersInOneMeter, meter.Centimeters, CentimetersTolerance);
            Assert.AreEqual(DecimetersInOneMeter, meter.Decimeters, DecimetersTolerance);
            Assert.AreEqual(FeetInOneMeter, meter.Feet, FeetTolerance);
            Assert.AreEqual(InchesInOneMeter, meter.Inches, InchesTolerance);
            Assert.AreEqual(KilometersInOneMeter, meter.Kilometers, KilometersTolerance);
            Assert.AreEqual(MetersInOneMeter, meter.Meters, MetersTolerance);
            Assert.AreEqual(MicroinchesInOneMeter, meter.Microinches, MicroinchesTolerance);
            Assert.AreEqual(MicrometersInOneMeter, meter.Micrometers, MicrometersTolerance);
            Assert.AreEqual(MilsInOneMeter, meter.Mils, MilsTolerance);
            Assert.AreEqual(MilesInOneMeter, meter.Miles, MilesTolerance);
            Assert.AreEqual(MillimetersInOneMeter, meter.Millimeters, MillimetersTolerance);
            Assert.AreEqual(NanometersInOneMeter, meter.Nanometers, NanometersTolerance);
            Assert.AreEqual(NauticalMilesInOneMeter, meter.NauticalMiles, NauticalMilesTolerance);
            Assert.AreEqual(YardsInOneMeter, meter.Yards, YardsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Length.From(1, LengthUnit.Centimeter).Centimeters, CentimetersTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Decimeter).Decimeters, DecimetersTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Foot).Feet, FeetTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Inch).Inches, InchesTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Kilometer).Kilometers, KilometersTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Meter).Meters, MetersTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Microinch).Microinches, MicroinchesTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Micrometer).Micrometers, MicrometersTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Mil).Mils, MilsTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Mile).Miles, MilesTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Millimeter).Millimeters, MillimetersTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Nanometer).Nanometers, NanometersTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.NauticalMile).NauticalMiles, NauticalMilesTolerance);
            Assert.AreEqual(1, Length.From(1, LengthUnit.Yard).Yards, YardsTolerance);
        }

        [Test]
        public void As()
        {
            var meter = Length.FromMeters(1);
            Assert.AreEqual(CentimetersInOneMeter, meter.As(LengthUnit.Centimeter), CentimetersTolerance);
            Assert.AreEqual(DecimetersInOneMeter, meter.As(LengthUnit.Decimeter), DecimetersTolerance);
            Assert.AreEqual(FeetInOneMeter, meter.As(LengthUnit.Foot), FeetTolerance);
            Assert.AreEqual(InchesInOneMeter, meter.As(LengthUnit.Inch), InchesTolerance);
            Assert.AreEqual(KilometersInOneMeter, meter.As(LengthUnit.Kilometer), KilometersTolerance);
            Assert.AreEqual(MetersInOneMeter, meter.As(LengthUnit.Meter), MetersTolerance);
            Assert.AreEqual(MicroinchesInOneMeter, meter.As(LengthUnit.Microinch), MicroinchesTolerance);
            Assert.AreEqual(MicrometersInOneMeter, meter.As(LengthUnit.Micrometer), MicrometersTolerance);
            Assert.AreEqual(MilsInOneMeter, meter.As(LengthUnit.Mil), MilsTolerance);
            Assert.AreEqual(MilesInOneMeter, meter.As(LengthUnit.Mile), MilesTolerance);
            Assert.AreEqual(MillimetersInOneMeter, meter.As(LengthUnit.Millimeter), MillimetersTolerance);
            Assert.AreEqual(NanometersInOneMeter, meter.As(LengthUnit.Nanometer), NanometersTolerance);
            Assert.AreEqual(NauticalMilesInOneMeter, meter.As(LengthUnit.NauticalMile), NauticalMilesTolerance);
            Assert.AreEqual(YardsInOneMeter, meter.As(LengthUnit.Yard), YardsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Length meter = Length.FromMeters(1);
            Assert.AreEqual(1, Length.FromCentimeters(meter.Centimeters).Meters, CentimetersTolerance);
            Assert.AreEqual(1, Length.FromDecimeters(meter.Decimeters).Meters, DecimetersTolerance);
            Assert.AreEqual(1, Length.FromFeet(meter.Feet).Meters, FeetTolerance);
            Assert.AreEqual(1, Length.FromInches(meter.Inches).Meters, InchesTolerance);
            Assert.AreEqual(1, Length.FromKilometers(meter.Kilometers).Meters, KilometersTolerance);
            Assert.AreEqual(1, Length.FromMeters(meter.Meters).Meters, MetersTolerance);
            Assert.AreEqual(1, Length.FromMicroinches(meter.Microinches).Meters, MicroinchesTolerance);
            Assert.AreEqual(1, Length.FromMicrometers(meter.Micrometers).Meters, MicrometersTolerance);
            Assert.AreEqual(1, Length.FromMils(meter.Mils).Meters, MilsTolerance);
            Assert.AreEqual(1, Length.FromMiles(meter.Miles).Meters, MilesTolerance);
            Assert.AreEqual(1, Length.FromMillimeters(meter.Millimeters).Meters, MillimetersTolerance);
            Assert.AreEqual(1, Length.FromNanometers(meter.Nanometers).Meters, NanometersTolerance);
            Assert.AreEqual(1, Length.FromNauticalMiles(meter.NauticalMiles).Meters, NauticalMilesTolerance);
            Assert.AreEqual(1, Length.FromYards(meter.Yards).Meters, YardsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Length v = Length.FromMeters(1);
            Assert.AreEqual(-1, -v.Meters, MetersTolerance);
            Assert.AreEqual(2, (Length.FromMeters(3)-v).Meters, MetersTolerance);
            Assert.AreEqual(2, (v + v).Meters, MetersTolerance);
            Assert.AreEqual(10, (v*10).Meters, MetersTolerance);
            Assert.AreEqual(10, (10*v).Meters, MetersTolerance);
            Assert.AreEqual(2, (Length.FromMeters(10)/5).Meters, MetersTolerance);
            Assert.AreEqual(2, Length.FromMeters(10)/Length.FromMeters(5), MetersTolerance);
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
