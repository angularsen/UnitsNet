﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run GeneratUnits.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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
using System.Linq;
using UnitsNet.Units;
using Xunit;

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Length.
    /// </summary>
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class LengthTestsBase
    {
        protected abstract double CentimetersInOneMeter { get; }
        protected abstract double DecimetersInOneMeter { get; }
        protected abstract double DtpPicasInOneMeter { get; }
        protected abstract double DtpPointsInOneMeter { get; }
        protected abstract double FathomsInOneMeter { get; }
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
        protected abstract double PrinterPicasInOneMeter { get; }
        protected abstract double PrinterPointsInOneMeter { get; }
        protected abstract double ShacklesInOneMeter { get; }
        protected abstract double TwipsInOneMeter { get; }
        protected abstract double UsSurveyFeetInOneMeter { get; }
        protected abstract double YardsInOneMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentimetersTolerance { get { return 1e-5; } }
        protected virtual double DecimetersTolerance { get { return 1e-5; } }
        protected virtual double DtpPicasTolerance { get { return 1e-5; } }
        protected virtual double DtpPointsTolerance { get { return 1e-5; } }
        protected virtual double FathomsTolerance { get { return 1e-5; } }
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
        protected virtual double PrinterPicasTolerance { get { return 1e-5; } }
        protected virtual double PrinterPointsTolerance { get { return 1e-5; } }
        protected virtual double ShacklesTolerance { get { return 1e-5; } }
        protected virtual double TwipsTolerance { get { return 1e-5; } }
        protected virtual double UsSurveyFeetTolerance { get { return 1e-5; } }
        protected virtual double YardsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Fact]
        public void ConstructorWithUndefinedUnitThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Length((double)0.0, LengthUnit.Undefined));
        }

        [Fact]
        public void MeterToLengthUnits()
        {
            Length meter = Length.FromMeters(1);
            AssertEx.EqualTolerance(CentimetersInOneMeter, meter.Centimeters, CentimetersTolerance);
            AssertEx.EqualTolerance(DecimetersInOneMeter, meter.Decimeters, DecimetersTolerance);
            AssertEx.EqualTolerance(DtpPicasInOneMeter, meter.DtpPicas, DtpPicasTolerance);
            AssertEx.EqualTolerance(DtpPointsInOneMeter, meter.DtpPoints, DtpPointsTolerance);
            AssertEx.EqualTolerance(FathomsInOneMeter, meter.Fathoms, FathomsTolerance);
            AssertEx.EqualTolerance(FeetInOneMeter, meter.Feet, FeetTolerance);
            AssertEx.EqualTolerance(InchesInOneMeter, meter.Inches, InchesTolerance);
            AssertEx.EqualTolerance(KilometersInOneMeter, meter.Kilometers, KilometersTolerance);
            AssertEx.EqualTolerance(MetersInOneMeter, meter.Meters, MetersTolerance);
            AssertEx.EqualTolerance(MicroinchesInOneMeter, meter.Microinches, MicroinchesTolerance);
            AssertEx.EqualTolerance(MicrometersInOneMeter, meter.Micrometers, MicrometersTolerance);
            AssertEx.EqualTolerance(MilsInOneMeter, meter.Mils, MilsTolerance);
            AssertEx.EqualTolerance(MilesInOneMeter, meter.Miles, MilesTolerance);
            AssertEx.EqualTolerance(MillimetersInOneMeter, meter.Millimeters, MillimetersTolerance);
            AssertEx.EqualTolerance(NanometersInOneMeter, meter.Nanometers, NanometersTolerance);
            AssertEx.EqualTolerance(NauticalMilesInOneMeter, meter.NauticalMiles, NauticalMilesTolerance);
            AssertEx.EqualTolerance(PrinterPicasInOneMeter, meter.PrinterPicas, PrinterPicasTolerance);
            AssertEx.EqualTolerance(PrinterPointsInOneMeter, meter.PrinterPoints, PrinterPointsTolerance);
            AssertEx.EqualTolerance(ShacklesInOneMeter, meter.Shackles, ShacklesTolerance);
            AssertEx.EqualTolerance(TwipsInOneMeter, meter.Twips, TwipsTolerance);
            AssertEx.EqualTolerance(UsSurveyFeetInOneMeter, meter.UsSurveyFeet, UsSurveyFeetTolerance);
            AssertEx.EqualTolerance(YardsInOneMeter, meter.Yards, YardsTolerance);
        }

        [Fact]
        public void FromValueAndUnit()
        {
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Centimeter).Centimeters, CentimetersTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Decimeter).Decimeters, DecimetersTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.DtpPica).DtpPicas, DtpPicasTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.DtpPoint).DtpPoints, DtpPointsTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Fathom).Fathoms, FathomsTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Foot).Feet, FeetTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Inch).Inches, InchesTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Kilometer).Kilometers, KilometersTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Meter).Meters, MetersTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Microinch).Microinches, MicroinchesTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Micrometer).Micrometers, MicrometersTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Mil).Mils, MilsTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Mile).Miles, MilesTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Millimeter).Millimeters, MillimetersTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Nanometer).Nanometers, NanometersTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.NauticalMile).NauticalMiles, NauticalMilesTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.PrinterPica).PrinterPicas, PrinterPicasTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.PrinterPoint).PrinterPoints, PrinterPointsTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Shackle).Shackles, ShacklesTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Twip).Twips, TwipsTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.UsSurveyFoot).UsSurveyFeet, UsSurveyFeetTolerance);
            AssertEx.EqualTolerance(1, Length.From(1, LengthUnit.Yard).Yards, YardsTolerance);
        }

        [Fact]
        public void As()
        {
            var meter = Length.FromMeters(1);
            AssertEx.EqualTolerance(CentimetersInOneMeter, meter.As(LengthUnit.Centimeter), CentimetersTolerance);
            AssertEx.EqualTolerance(DecimetersInOneMeter, meter.As(LengthUnit.Decimeter), DecimetersTolerance);
            AssertEx.EqualTolerance(DtpPicasInOneMeter, meter.As(LengthUnit.DtpPica), DtpPicasTolerance);
            AssertEx.EqualTolerance(DtpPointsInOneMeter, meter.As(LengthUnit.DtpPoint), DtpPointsTolerance);
            AssertEx.EqualTolerance(FathomsInOneMeter, meter.As(LengthUnit.Fathom), FathomsTolerance);
            AssertEx.EqualTolerance(FeetInOneMeter, meter.As(LengthUnit.Foot), FeetTolerance);
            AssertEx.EqualTolerance(InchesInOneMeter, meter.As(LengthUnit.Inch), InchesTolerance);
            AssertEx.EqualTolerance(KilometersInOneMeter, meter.As(LengthUnit.Kilometer), KilometersTolerance);
            AssertEx.EqualTolerance(MetersInOneMeter, meter.As(LengthUnit.Meter), MetersTolerance);
            AssertEx.EqualTolerance(MicroinchesInOneMeter, meter.As(LengthUnit.Microinch), MicroinchesTolerance);
            AssertEx.EqualTolerance(MicrometersInOneMeter, meter.As(LengthUnit.Micrometer), MicrometersTolerance);
            AssertEx.EqualTolerance(MilsInOneMeter, meter.As(LengthUnit.Mil), MilsTolerance);
            AssertEx.EqualTolerance(MilesInOneMeter, meter.As(LengthUnit.Mile), MilesTolerance);
            AssertEx.EqualTolerance(MillimetersInOneMeter, meter.As(LengthUnit.Millimeter), MillimetersTolerance);
            AssertEx.EqualTolerance(NanometersInOneMeter, meter.As(LengthUnit.Nanometer), NanometersTolerance);
            AssertEx.EqualTolerance(NauticalMilesInOneMeter, meter.As(LengthUnit.NauticalMile), NauticalMilesTolerance);
            AssertEx.EqualTolerance(PrinterPicasInOneMeter, meter.As(LengthUnit.PrinterPica), PrinterPicasTolerance);
            AssertEx.EqualTolerance(PrinterPointsInOneMeter, meter.As(LengthUnit.PrinterPoint), PrinterPointsTolerance);
            AssertEx.EqualTolerance(ShacklesInOneMeter, meter.As(LengthUnit.Shackle), ShacklesTolerance);
            AssertEx.EqualTolerance(TwipsInOneMeter, meter.As(LengthUnit.Twip), TwipsTolerance);
            AssertEx.EqualTolerance(UsSurveyFeetInOneMeter, meter.As(LengthUnit.UsSurveyFoot), UsSurveyFeetTolerance);
            AssertEx.EqualTolerance(YardsInOneMeter, meter.As(LengthUnit.Yard), YardsTolerance);
        }

        [Fact]
        public void ToUnit()
        {
            var meter = Length.FromMeters(1);

            var centimeterQuantity = meter.ToUnit(LengthUnit.Centimeter);
            AssertEx.EqualTolerance(CentimetersInOneMeter, (double)centimeterQuantity.Value, CentimetersTolerance);
            Assert.Equal(LengthUnit.Centimeter, centimeterQuantity.Unit);

            var decimeterQuantity = meter.ToUnit(LengthUnit.Decimeter);
            AssertEx.EqualTolerance(DecimetersInOneMeter, (double)decimeterQuantity.Value, DecimetersTolerance);
            Assert.Equal(LengthUnit.Decimeter, decimeterQuantity.Unit);

            var dtppicaQuantity = meter.ToUnit(LengthUnit.DtpPica);
            AssertEx.EqualTolerance(DtpPicasInOneMeter, (double)dtppicaQuantity.Value, DtpPicasTolerance);
            Assert.Equal(LengthUnit.DtpPica, dtppicaQuantity.Unit);

            var dtppointQuantity = meter.ToUnit(LengthUnit.DtpPoint);
            AssertEx.EqualTolerance(DtpPointsInOneMeter, (double)dtppointQuantity.Value, DtpPointsTolerance);
            Assert.Equal(LengthUnit.DtpPoint, dtppointQuantity.Unit);

            var fathomQuantity = meter.ToUnit(LengthUnit.Fathom);
            AssertEx.EqualTolerance(FathomsInOneMeter, (double)fathomQuantity.Value, FathomsTolerance);
            Assert.Equal(LengthUnit.Fathom, fathomQuantity.Unit);

            var footQuantity = meter.ToUnit(LengthUnit.Foot);
            AssertEx.EqualTolerance(FeetInOneMeter, (double)footQuantity.Value, FeetTolerance);
            Assert.Equal(LengthUnit.Foot, footQuantity.Unit);

            var inchQuantity = meter.ToUnit(LengthUnit.Inch);
            AssertEx.EqualTolerance(InchesInOneMeter, (double)inchQuantity.Value, InchesTolerance);
            Assert.Equal(LengthUnit.Inch, inchQuantity.Unit);

            var kilometerQuantity = meter.ToUnit(LengthUnit.Kilometer);
            AssertEx.EqualTolerance(KilometersInOneMeter, (double)kilometerQuantity.Value, KilometersTolerance);
            Assert.Equal(LengthUnit.Kilometer, kilometerQuantity.Unit);

            var meterQuantity = meter.ToUnit(LengthUnit.Meter);
            AssertEx.EqualTolerance(MetersInOneMeter, (double)meterQuantity.Value, MetersTolerance);
            Assert.Equal(LengthUnit.Meter, meterQuantity.Unit);

            var microinchQuantity = meter.ToUnit(LengthUnit.Microinch);
            AssertEx.EqualTolerance(MicroinchesInOneMeter, (double)microinchQuantity.Value, MicroinchesTolerance);
            Assert.Equal(LengthUnit.Microinch, microinchQuantity.Unit);

            var micrometerQuantity = meter.ToUnit(LengthUnit.Micrometer);
            AssertEx.EqualTolerance(MicrometersInOneMeter, (double)micrometerQuantity.Value, MicrometersTolerance);
            Assert.Equal(LengthUnit.Micrometer, micrometerQuantity.Unit);

            var milQuantity = meter.ToUnit(LengthUnit.Mil);
            AssertEx.EqualTolerance(MilsInOneMeter, (double)milQuantity.Value, MilsTolerance);
            Assert.Equal(LengthUnit.Mil, milQuantity.Unit);

            var mileQuantity = meter.ToUnit(LengthUnit.Mile);
            AssertEx.EqualTolerance(MilesInOneMeter, (double)mileQuantity.Value, MilesTolerance);
            Assert.Equal(LengthUnit.Mile, mileQuantity.Unit);

            var millimeterQuantity = meter.ToUnit(LengthUnit.Millimeter);
            AssertEx.EqualTolerance(MillimetersInOneMeter, (double)millimeterQuantity.Value, MillimetersTolerance);
            Assert.Equal(LengthUnit.Millimeter, millimeterQuantity.Unit);

            var nanometerQuantity = meter.ToUnit(LengthUnit.Nanometer);
            AssertEx.EqualTolerance(NanometersInOneMeter, (double)nanometerQuantity.Value, NanometersTolerance);
            Assert.Equal(LengthUnit.Nanometer, nanometerQuantity.Unit);

            var nauticalmileQuantity = meter.ToUnit(LengthUnit.NauticalMile);
            AssertEx.EqualTolerance(NauticalMilesInOneMeter, (double)nauticalmileQuantity.Value, NauticalMilesTolerance);
            Assert.Equal(LengthUnit.NauticalMile, nauticalmileQuantity.Unit);

            var printerpicaQuantity = meter.ToUnit(LengthUnit.PrinterPica);
            AssertEx.EqualTolerance(PrinterPicasInOneMeter, (double)printerpicaQuantity.Value, PrinterPicasTolerance);
            Assert.Equal(LengthUnit.PrinterPica, printerpicaQuantity.Unit);

            var printerpointQuantity = meter.ToUnit(LengthUnit.PrinterPoint);
            AssertEx.EqualTolerance(PrinterPointsInOneMeter, (double)printerpointQuantity.Value, PrinterPointsTolerance);
            Assert.Equal(LengthUnit.PrinterPoint, printerpointQuantity.Unit);

            var shackleQuantity = meter.ToUnit(LengthUnit.Shackle);
            AssertEx.EqualTolerance(ShacklesInOneMeter, (double)shackleQuantity.Value, ShacklesTolerance);
            Assert.Equal(LengthUnit.Shackle, shackleQuantity.Unit);

            var twipQuantity = meter.ToUnit(LengthUnit.Twip);
            AssertEx.EqualTolerance(TwipsInOneMeter, (double)twipQuantity.Value, TwipsTolerance);
            Assert.Equal(LengthUnit.Twip, twipQuantity.Unit);

            var ussurveyfootQuantity = meter.ToUnit(LengthUnit.UsSurveyFoot);
            AssertEx.EqualTolerance(UsSurveyFeetInOneMeter, (double)ussurveyfootQuantity.Value, UsSurveyFeetTolerance);
            Assert.Equal(LengthUnit.UsSurveyFoot, ussurveyfootQuantity.Unit);

            var yardQuantity = meter.ToUnit(LengthUnit.Yard);
            AssertEx.EqualTolerance(YardsInOneMeter, (double)yardQuantity.Value, YardsTolerance);
            Assert.Equal(LengthUnit.Yard, yardQuantity.Unit);
        }

        [Fact]
        public void ConversionRoundTrip()
        {
            Length meter = Length.FromMeters(1);
            AssertEx.EqualTolerance(1, Length.FromCentimeters(meter.Centimeters).Meters, CentimetersTolerance);
            AssertEx.EqualTolerance(1, Length.FromDecimeters(meter.Decimeters).Meters, DecimetersTolerance);
            AssertEx.EqualTolerance(1, Length.FromDtpPicas(meter.DtpPicas).Meters, DtpPicasTolerance);
            AssertEx.EqualTolerance(1, Length.FromDtpPoints(meter.DtpPoints).Meters, DtpPointsTolerance);
            AssertEx.EqualTolerance(1, Length.FromFathoms(meter.Fathoms).Meters, FathomsTolerance);
            AssertEx.EqualTolerance(1, Length.FromFeet(meter.Feet).Meters, FeetTolerance);
            AssertEx.EqualTolerance(1, Length.FromInches(meter.Inches).Meters, InchesTolerance);
            AssertEx.EqualTolerance(1, Length.FromKilometers(meter.Kilometers).Meters, KilometersTolerance);
            AssertEx.EqualTolerance(1, Length.FromMeters(meter.Meters).Meters, MetersTolerance);
            AssertEx.EqualTolerance(1, Length.FromMicroinches(meter.Microinches).Meters, MicroinchesTolerance);
            AssertEx.EqualTolerance(1, Length.FromMicrometers(meter.Micrometers).Meters, MicrometersTolerance);
            AssertEx.EqualTolerance(1, Length.FromMils(meter.Mils).Meters, MilsTolerance);
            AssertEx.EqualTolerance(1, Length.FromMiles(meter.Miles).Meters, MilesTolerance);
            AssertEx.EqualTolerance(1, Length.FromMillimeters(meter.Millimeters).Meters, MillimetersTolerance);
            AssertEx.EqualTolerance(1, Length.FromNanometers(meter.Nanometers).Meters, NanometersTolerance);
            AssertEx.EqualTolerance(1, Length.FromNauticalMiles(meter.NauticalMiles).Meters, NauticalMilesTolerance);
            AssertEx.EqualTolerance(1, Length.FromPrinterPicas(meter.PrinterPicas).Meters, PrinterPicasTolerance);
            AssertEx.EqualTolerance(1, Length.FromPrinterPoints(meter.PrinterPoints).Meters, PrinterPointsTolerance);
            AssertEx.EqualTolerance(1, Length.FromShackles(meter.Shackles).Meters, ShacklesTolerance);
            AssertEx.EqualTolerance(1, Length.FromTwips(meter.Twips).Meters, TwipsTolerance);
            AssertEx.EqualTolerance(1, Length.FromUsSurveyFeet(meter.UsSurveyFeet).Meters, UsSurveyFeetTolerance);
            AssertEx.EqualTolerance(1, Length.FromYards(meter.Yards).Meters, YardsTolerance);
        }

        [Fact]
        public void ArithmeticOperators()
        {
            Length v = Length.FromMeters(1);
            AssertEx.EqualTolerance(-1, -v.Meters, MetersTolerance);
            AssertEx.EqualTolerance(2, (Length.FromMeters(3)-v).Meters, MetersTolerance);
            AssertEx.EqualTolerance(2, (v + v).Meters, MetersTolerance);
            AssertEx.EqualTolerance(10, (v*10).Meters, MetersTolerance);
            AssertEx.EqualTolerance(10, (10*v).Meters, MetersTolerance);
            AssertEx.EqualTolerance(2, (Length.FromMeters(10)/5).Meters, MetersTolerance);
            AssertEx.EqualTolerance(2, Length.FromMeters(10)/Length.FromMeters(5), MetersTolerance);
        }

        [Fact]
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

        [Fact]
        public void CompareToIsImplemented()
        {
            Length meter = Length.FromMeters(1);
            Assert.Equal(0, meter.CompareTo(meter));
            Assert.True(meter.CompareTo(Length.Zero) > 0);
            Assert.True(Length.Zero.CompareTo(meter) < 0);
        }

        [Fact]
        public void CompareToThrowsOnTypeMismatch()
        {
            Length meter = Length.FromMeters(1);
            Assert.Throws<ArgumentException>(() => meter.CompareTo(new object()));
        }

        [Fact]
        public void CompareToThrowsOnNull()
        {
            Length meter = Length.FromMeters(1);
            Assert.Throws<ArgumentNullException>(() => meter.CompareTo(null));
        }

        [Fact]
        public void EqualsIsImplemented()
        {
            Length v = Length.FromMeters(1);
            Assert.True(v.Equals(Length.FromMeters(1), MetersTolerance, ComparisonType.Relative));
            Assert.False(v.Equals(Length.Zero, MetersTolerance, ComparisonType.Relative));
        }

        [Fact]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Length meter = Length.FromMeters(1);
            Assert.False(meter.Equals(new object()));
        }

        [Fact]
        public void EqualsReturnsFalseOnNull()
        {
            Length meter = Length.FromMeters(1);
            Assert.False(meter.Equals(null));
        }

        [Fact]
        public void UnitsDoesNotContainUndefined()
        {
            Assert.DoesNotContain(LengthUnit.Undefined, Length.Units);
        }
    }
}
