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
    /// Test of Volume.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class VolumeTestsBase
    {
        protected abstract double AuTablespoonsInOneCubicMeter { get; }
        protected abstract double CentilitersInOneCubicMeter { get; }
        protected abstract double CubicCentimetersInOneCubicMeter { get; }
        protected abstract double CubicDecimetersInOneCubicMeter { get; }
        protected abstract double CubicFeetInOneCubicMeter { get; }
        protected abstract double CubicInchesInOneCubicMeter { get; }
        protected abstract double CubicKilometersInOneCubicMeter { get; }
        protected abstract double CubicMetersInOneCubicMeter { get; }
        protected abstract double CubicMicrometersInOneCubicMeter { get; }
        protected abstract double CubicMilesInOneCubicMeter { get; }
        protected abstract double CubicMillimetersInOneCubicMeter { get; }
        protected abstract double CubicYardsInOneCubicMeter { get; }
        protected abstract double DecilitersInOneCubicMeter { get; }
        protected abstract double HectolitersInOneCubicMeter { get; }
        protected abstract double ImperialGallonsInOneCubicMeter { get; }
        protected abstract double ImperialOuncesInOneCubicMeter { get; }
        protected abstract double LitersInOneCubicMeter { get; }
        protected abstract double MetricCupsInOneCubicMeter { get; }
        protected abstract double MetricTeaspoonsInOneCubicMeter { get; }
        protected abstract double MicrolitersInOneCubicMeter { get; }
        protected abstract double MillilitersInOneCubicMeter { get; }
        protected abstract double TablespoonsInOneCubicMeter { get; }
        protected abstract double TeaspoonsInOneCubicMeter { get; }
        protected abstract double UkTablespoonsInOneCubicMeter { get; }
        protected abstract double UsCustomaryCupsInOneCubicMeter { get; }
        protected abstract double UsGallonsInOneCubicMeter { get; }
        protected abstract double UsLegalCupsInOneCubicMeter { get; }
        protected abstract double UsOuncesInOneCubicMeter { get; }
        protected abstract double UsTablespoonsInOneCubicMeter { get; }
        protected abstract double UsTeaspoonsInOneCubicMeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double AuTablespoonsTolerance { get { return 1e-5; } }
        protected virtual double CentilitersTolerance { get { return 1e-5; } }
        protected virtual double CubicCentimetersTolerance { get { return 1e-5; } }
        protected virtual double CubicDecimetersTolerance { get { return 1e-5; } }
        protected virtual double CubicFeetTolerance { get { return 1e-5; } }
        protected virtual double CubicInchesTolerance { get { return 1e-5; } }
        protected virtual double CubicKilometersTolerance { get { return 1e-5; } }
        protected virtual double CubicMetersTolerance { get { return 1e-5; } }
        protected virtual double CubicMicrometersTolerance { get { return 1e-5; } }
        protected virtual double CubicMilesTolerance { get { return 1e-5; } }
        protected virtual double CubicMillimetersTolerance { get { return 1e-5; } }
        protected virtual double CubicYardsTolerance { get { return 1e-5; } }
        protected virtual double DecilitersTolerance { get { return 1e-5; } }
        protected virtual double HectolitersTolerance { get { return 1e-5; } }
        protected virtual double ImperialGallonsTolerance { get { return 1e-5; } }
        protected virtual double ImperialOuncesTolerance { get { return 1e-5; } }
        protected virtual double LitersTolerance { get { return 1e-5; } }
        protected virtual double MetricCupsTolerance { get { return 1e-5; } }
        protected virtual double MetricTeaspoonsTolerance { get { return 1e-5; } }
        protected virtual double MicrolitersTolerance { get { return 1e-5; } }
        protected virtual double MillilitersTolerance { get { return 1e-5; } }
        protected virtual double TablespoonsTolerance { get { return 1e-5; } }
        protected virtual double TeaspoonsTolerance { get { return 1e-5; } }
        protected virtual double UkTablespoonsTolerance { get { return 1e-5; } }
        protected virtual double UsCustomaryCupsTolerance { get { return 1e-5; } }
        protected virtual double UsGallonsTolerance { get { return 1e-5; } }
        protected virtual double UsLegalCupsTolerance { get { return 1e-5; } }
        protected virtual double UsOuncesTolerance { get { return 1e-5; } }
        protected virtual double UsTablespoonsTolerance { get { return 1e-5; } }
        protected virtual double UsTeaspoonsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void CubicMeterToVolumeUnits()
        {
            Volume cubicmeter = Volume.FromCubicMeters(1);
            Assert.AreEqual(AuTablespoonsInOneCubicMeter, cubicmeter.AuTablespoons, AuTablespoonsTolerance);
            Assert.AreEqual(CentilitersInOneCubicMeter, cubicmeter.Centiliters, CentilitersTolerance);
            Assert.AreEqual(CubicCentimetersInOneCubicMeter, cubicmeter.CubicCentimeters, CubicCentimetersTolerance);
            Assert.AreEqual(CubicDecimetersInOneCubicMeter, cubicmeter.CubicDecimeters, CubicDecimetersTolerance);
            Assert.AreEqual(CubicFeetInOneCubicMeter, cubicmeter.CubicFeet, CubicFeetTolerance);
            Assert.AreEqual(CubicInchesInOneCubicMeter, cubicmeter.CubicInches, CubicInchesTolerance);
            Assert.AreEqual(CubicKilometersInOneCubicMeter, cubicmeter.CubicKilometers, CubicKilometersTolerance);
            Assert.AreEqual(CubicMetersInOneCubicMeter, cubicmeter.CubicMeters, CubicMetersTolerance);
            Assert.AreEqual(CubicMicrometersInOneCubicMeter, cubicmeter.CubicMicrometers, CubicMicrometersTolerance);
            Assert.AreEqual(CubicMilesInOneCubicMeter, cubicmeter.CubicMiles, CubicMilesTolerance);
            Assert.AreEqual(CubicMillimetersInOneCubicMeter, cubicmeter.CubicMillimeters, CubicMillimetersTolerance);
            Assert.AreEqual(CubicYardsInOneCubicMeter, cubicmeter.CubicYards, CubicYardsTolerance);
            Assert.AreEqual(DecilitersInOneCubicMeter, cubicmeter.Deciliters, DecilitersTolerance);
            Assert.AreEqual(HectolitersInOneCubicMeter, cubicmeter.Hectoliters, HectolitersTolerance);
            Assert.AreEqual(ImperialGallonsInOneCubicMeter, cubicmeter.ImperialGallons, ImperialGallonsTolerance);
            Assert.AreEqual(ImperialOuncesInOneCubicMeter, cubicmeter.ImperialOunces, ImperialOuncesTolerance);
            Assert.AreEqual(LitersInOneCubicMeter, cubicmeter.Liters, LitersTolerance);
            Assert.AreEqual(MetricCupsInOneCubicMeter, cubicmeter.MetricCups, MetricCupsTolerance);
            Assert.AreEqual(MetricTeaspoonsInOneCubicMeter, cubicmeter.MetricTeaspoons, MetricTeaspoonsTolerance);
            Assert.AreEqual(MicrolitersInOneCubicMeter, cubicmeter.Microliters, MicrolitersTolerance);
            Assert.AreEqual(MillilitersInOneCubicMeter, cubicmeter.Milliliters, MillilitersTolerance);
            Assert.AreEqual(TablespoonsInOneCubicMeter, cubicmeter.Tablespoons, TablespoonsTolerance);
            Assert.AreEqual(TeaspoonsInOneCubicMeter, cubicmeter.Teaspoons, TeaspoonsTolerance);
            Assert.AreEqual(UkTablespoonsInOneCubicMeter, cubicmeter.UkTablespoons, UkTablespoonsTolerance);
            Assert.AreEqual(UsCustomaryCupsInOneCubicMeter, cubicmeter.UsCustomaryCups, UsCustomaryCupsTolerance);
            Assert.AreEqual(UsGallonsInOneCubicMeter, cubicmeter.UsGallons, UsGallonsTolerance);
            Assert.AreEqual(UsLegalCupsInOneCubicMeter, cubicmeter.UsLegalCups, UsLegalCupsTolerance);
            Assert.AreEqual(UsOuncesInOneCubicMeter, cubicmeter.UsOunces, UsOuncesTolerance);
            Assert.AreEqual(UsTablespoonsInOneCubicMeter, cubicmeter.UsTablespoons, UsTablespoonsTolerance);
            Assert.AreEqual(UsTeaspoonsInOneCubicMeter, cubicmeter.UsTeaspoons, UsTeaspoonsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.AuTablespoon).AuTablespoons, AuTablespoonsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.Centiliter).Centiliters, CentilitersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.CubicCentimeter).CubicCentimeters, CubicCentimetersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.CubicDecimeter).CubicDecimeters, CubicDecimetersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.CubicFoot).CubicFeet, CubicFeetTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.CubicInch).CubicInches, CubicInchesTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.CubicKilometer).CubicKilometers, CubicKilometersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.CubicMeter).CubicMeters, CubicMetersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.CubicMicrometer).CubicMicrometers, CubicMicrometersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.CubicMile).CubicMiles, CubicMilesTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.CubicMillimeter).CubicMillimeters, CubicMillimetersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.CubicYard).CubicYards, CubicYardsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.Deciliter).Deciliters, DecilitersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.Hectoliter).Hectoliters, HectolitersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.ImperialGallon).ImperialGallons, ImperialGallonsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.ImperialOunce).ImperialOunces, ImperialOuncesTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.Liter).Liters, LitersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.MetricCup).MetricCups, MetricCupsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.MetricTeaspoon).MetricTeaspoons, MetricTeaspoonsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.Microliter).Microliters, MicrolitersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.Milliliter).Milliliters, MillilitersTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.Tablespoon).Tablespoons, TablespoonsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.Teaspoon).Teaspoons, TeaspoonsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.UkTablespoon).UkTablespoons, UkTablespoonsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.UsCustomaryCup).UsCustomaryCups, UsCustomaryCupsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.UsGallon).UsGallons, UsGallonsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.UsLegalCup).UsLegalCups, UsLegalCupsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.UsOunce).UsOunces, UsOuncesTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.UsTablespoon).UsTablespoons, UsTablespoonsTolerance);
            Assert.AreEqual(1, Volume.From(1, VolumeUnit.UsTeaspoon).UsTeaspoons, UsTeaspoonsTolerance);
        }

        [Test]
        public void As()
        {
            var cubicmeter = Volume.FromCubicMeters(1);
            Assert.AreEqual(AuTablespoonsInOneCubicMeter, cubicmeter.As(VolumeUnit.AuTablespoon), AuTablespoonsTolerance);
            Assert.AreEqual(CentilitersInOneCubicMeter, cubicmeter.As(VolumeUnit.Centiliter), CentilitersTolerance);
            Assert.AreEqual(CubicCentimetersInOneCubicMeter, cubicmeter.As(VolumeUnit.CubicCentimeter), CubicCentimetersTolerance);
            Assert.AreEqual(CubicDecimetersInOneCubicMeter, cubicmeter.As(VolumeUnit.CubicDecimeter), CubicDecimetersTolerance);
            Assert.AreEqual(CubicFeetInOneCubicMeter, cubicmeter.As(VolumeUnit.CubicFoot), CubicFeetTolerance);
            Assert.AreEqual(CubicInchesInOneCubicMeter, cubicmeter.As(VolumeUnit.CubicInch), CubicInchesTolerance);
            Assert.AreEqual(CubicKilometersInOneCubicMeter, cubicmeter.As(VolumeUnit.CubicKilometer), CubicKilometersTolerance);
            Assert.AreEqual(CubicMetersInOneCubicMeter, cubicmeter.As(VolumeUnit.CubicMeter), CubicMetersTolerance);
            Assert.AreEqual(CubicMicrometersInOneCubicMeter, cubicmeter.As(VolumeUnit.CubicMicrometer), CubicMicrometersTolerance);
            Assert.AreEqual(CubicMilesInOneCubicMeter, cubicmeter.As(VolumeUnit.CubicMile), CubicMilesTolerance);
            Assert.AreEqual(CubicMillimetersInOneCubicMeter, cubicmeter.As(VolumeUnit.CubicMillimeter), CubicMillimetersTolerance);
            Assert.AreEqual(CubicYardsInOneCubicMeter, cubicmeter.As(VolumeUnit.CubicYard), CubicYardsTolerance);
            Assert.AreEqual(DecilitersInOneCubicMeter, cubicmeter.As(VolumeUnit.Deciliter), DecilitersTolerance);
            Assert.AreEqual(HectolitersInOneCubicMeter, cubicmeter.As(VolumeUnit.Hectoliter), HectolitersTolerance);
            Assert.AreEqual(ImperialGallonsInOneCubicMeter, cubicmeter.As(VolumeUnit.ImperialGallon), ImperialGallonsTolerance);
            Assert.AreEqual(ImperialOuncesInOneCubicMeter, cubicmeter.As(VolumeUnit.ImperialOunce), ImperialOuncesTolerance);
            Assert.AreEqual(LitersInOneCubicMeter, cubicmeter.As(VolumeUnit.Liter), LitersTolerance);
            Assert.AreEqual(MetricCupsInOneCubicMeter, cubicmeter.As(VolumeUnit.MetricCup), MetricCupsTolerance);
            Assert.AreEqual(MetricTeaspoonsInOneCubicMeter, cubicmeter.As(VolumeUnit.MetricTeaspoon), MetricTeaspoonsTolerance);
            Assert.AreEqual(MicrolitersInOneCubicMeter, cubicmeter.As(VolumeUnit.Microliter), MicrolitersTolerance);
            Assert.AreEqual(MillilitersInOneCubicMeter, cubicmeter.As(VolumeUnit.Milliliter), MillilitersTolerance);
            Assert.AreEqual(TablespoonsInOneCubicMeter, cubicmeter.As(VolumeUnit.Tablespoon), TablespoonsTolerance);
            Assert.AreEqual(TeaspoonsInOneCubicMeter, cubicmeter.As(VolumeUnit.Teaspoon), TeaspoonsTolerance);
            Assert.AreEqual(UkTablespoonsInOneCubicMeter, cubicmeter.As(VolumeUnit.UkTablespoon), UkTablespoonsTolerance);
            Assert.AreEqual(UsCustomaryCupsInOneCubicMeter, cubicmeter.As(VolumeUnit.UsCustomaryCup), UsCustomaryCupsTolerance);
            Assert.AreEqual(UsGallonsInOneCubicMeter, cubicmeter.As(VolumeUnit.UsGallon), UsGallonsTolerance);
            Assert.AreEqual(UsLegalCupsInOneCubicMeter, cubicmeter.As(VolumeUnit.UsLegalCup), UsLegalCupsTolerance);
            Assert.AreEqual(UsOuncesInOneCubicMeter, cubicmeter.As(VolumeUnit.UsOunce), UsOuncesTolerance);
            Assert.AreEqual(UsTablespoonsInOneCubicMeter, cubicmeter.As(VolumeUnit.UsTablespoon), UsTablespoonsTolerance);
            Assert.AreEqual(UsTeaspoonsInOneCubicMeter, cubicmeter.As(VolumeUnit.UsTeaspoon), UsTeaspoonsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Volume cubicmeter = Volume.FromCubicMeters(1);
            Assert.AreEqual(1, Volume.FromAuTablespoons(cubicmeter.AuTablespoons).CubicMeters, AuTablespoonsTolerance);
            Assert.AreEqual(1, Volume.FromCentiliters(cubicmeter.Centiliters).CubicMeters, CentilitersTolerance);
            Assert.AreEqual(1, Volume.FromCubicCentimeters(cubicmeter.CubicCentimeters).CubicMeters, CubicCentimetersTolerance);
            Assert.AreEqual(1, Volume.FromCubicDecimeters(cubicmeter.CubicDecimeters).CubicMeters, CubicDecimetersTolerance);
            Assert.AreEqual(1, Volume.FromCubicFeet(cubicmeter.CubicFeet).CubicMeters, CubicFeetTolerance);
            Assert.AreEqual(1, Volume.FromCubicInches(cubicmeter.CubicInches).CubicMeters, CubicInchesTolerance);
            Assert.AreEqual(1, Volume.FromCubicKilometers(cubicmeter.CubicKilometers).CubicMeters, CubicKilometersTolerance);
            Assert.AreEqual(1, Volume.FromCubicMeters(cubicmeter.CubicMeters).CubicMeters, CubicMetersTolerance);
            Assert.AreEqual(1, Volume.FromCubicMicrometers(cubicmeter.CubicMicrometers).CubicMeters, CubicMicrometersTolerance);
            Assert.AreEqual(1, Volume.FromCubicMiles(cubicmeter.CubicMiles).CubicMeters, CubicMilesTolerance);
            Assert.AreEqual(1, Volume.FromCubicMillimeters(cubicmeter.CubicMillimeters).CubicMeters, CubicMillimetersTolerance);
            Assert.AreEqual(1, Volume.FromCubicYards(cubicmeter.CubicYards).CubicMeters, CubicYardsTolerance);
            Assert.AreEqual(1, Volume.FromDeciliters(cubicmeter.Deciliters).CubicMeters, DecilitersTolerance);
            Assert.AreEqual(1, Volume.FromHectoliters(cubicmeter.Hectoliters).CubicMeters, HectolitersTolerance);
            Assert.AreEqual(1, Volume.FromImperialGallons(cubicmeter.ImperialGallons).CubicMeters, ImperialGallonsTolerance);
            Assert.AreEqual(1, Volume.FromImperialOunces(cubicmeter.ImperialOunces).CubicMeters, ImperialOuncesTolerance);
            Assert.AreEqual(1, Volume.FromLiters(cubicmeter.Liters).CubicMeters, LitersTolerance);
            Assert.AreEqual(1, Volume.FromMetricCups(cubicmeter.MetricCups).CubicMeters, MetricCupsTolerance);
            Assert.AreEqual(1, Volume.FromMetricTeaspoons(cubicmeter.MetricTeaspoons).CubicMeters, MetricTeaspoonsTolerance);
            Assert.AreEqual(1, Volume.FromMicroliters(cubicmeter.Microliters).CubicMeters, MicrolitersTolerance);
            Assert.AreEqual(1, Volume.FromMilliliters(cubicmeter.Milliliters).CubicMeters, MillilitersTolerance);
            Assert.AreEqual(1, Volume.FromTablespoons(cubicmeter.Tablespoons).CubicMeters, TablespoonsTolerance);
            Assert.AreEqual(1, Volume.FromTeaspoons(cubicmeter.Teaspoons).CubicMeters, TeaspoonsTolerance);
            Assert.AreEqual(1, Volume.FromUkTablespoons(cubicmeter.UkTablespoons).CubicMeters, UkTablespoonsTolerance);
            Assert.AreEqual(1, Volume.FromUsCustomaryCups(cubicmeter.UsCustomaryCups).CubicMeters, UsCustomaryCupsTolerance);
            Assert.AreEqual(1, Volume.FromUsGallons(cubicmeter.UsGallons).CubicMeters, UsGallonsTolerance);
            Assert.AreEqual(1, Volume.FromUsLegalCups(cubicmeter.UsLegalCups).CubicMeters, UsLegalCupsTolerance);
            Assert.AreEqual(1, Volume.FromUsOunces(cubicmeter.UsOunces).CubicMeters, UsOuncesTolerance);
            Assert.AreEqual(1, Volume.FromUsTablespoons(cubicmeter.UsTablespoons).CubicMeters, UsTablespoonsTolerance);
            Assert.AreEqual(1, Volume.FromUsTeaspoons(cubicmeter.UsTeaspoons).CubicMeters, UsTeaspoonsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Volume v = Volume.FromCubicMeters(1);
            Assert.AreEqual(-1, -v.CubicMeters, CubicMetersTolerance);
            Assert.AreEqual(2, (Volume.FromCubicMeters(3)-v).CubicMeters, CubicMetersTolerance);
            Assert.AreEqual(2, (v + v).CubicMeters, CubicMetersTolerance);
            Assert.AreEqual(10, (v*10).CubicMeters, CubicMetersTolerance);
            Assert.AreEqual(10, (10*v).CubicMeters, CubicMetersTolerance);
            Assert.AreEqual(2, (Volume.FromCubicMeters(10)/5).CubicMeters, CubicMetersTolerance);
            Assert.AreEqual(2, Volume.FromCubicMeters(10)/Volume.FromCubicMeters(5), CubicMetersTolerance);
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
