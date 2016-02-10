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
    /// Test of Speed.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class SpeedTestsBase
    {
        protected abstract double CentimetersPerSecondInOneMeterPerSecond { get; }
        protected abstract double DecimetersPerSecondInOneMeterPerSecond { get; }
        protected abstract double FeetPerSecondInOneMeterPerSecond { get; }
        protected abstract double KilometersPerHourInOneMeterPerSecond { get; }
        protected abstract double KilometersPerSecondInOneMeterPerSecond { get; }
        protected abstract double KnotsInOneMeterPerSecond { get; }
        protected abstract double MetersPerHourInOneMeterPerSecond { get; }
        protected abstract double MetersPerSecondInOneMeterPerSecond { get; }
        protected abstract double MicrometersPerSecondInOneMeterPerSecond { get; }
        protected abstract double MilesPerHourInOneMeterPerSecond { get; }
        protected abstract double MillimetersPerSecondInOneMeterPerSecond { get; }
        protected abstract double NanometersPerSecondInOneMeterPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentimetersPerSecondTolerance { get { return 1e-5; } }
        protected virtual double DecimetersPerSecondTolerance { get { return 1e-5; } }
        protected virtual double FeetPerSecondTolerance { get { return 1e-5; } }
        protected virtual double KilometersPerHourTolerance { get { return 1e-5; } }
        protected virtual double KilometersPerSecondTolerance { get { return 1e-5; } }
        protected virtual double KnotsTolerance { get { return 1e-5; } }
        protected virtual double MetersPerHourTolerance { get { return 1e-5; } }
        protected virtual double MetersPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MicrometersPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MilesPerHourTolerance { get { return 1e-5; } }
        protected virtual double MillimetersPerSecondTolerance { get { return 1e-5; } }
        protected virtual double NanometersPerSecondTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void MeterPerSecondToSpeedUnits()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(CentimetersPerSecondInOneMeterPerSecond, meterpersecond.CentimetersPerSecond, CentimetersPerSecondTolerance);
            Assert.AreEqual(DecimetersPerSecondInOneMeterPerSecond, meterpersecond.DecimetersPerSecond, DecimetersPerSecondTolerance);
            Assert.AreEqual(FeetPerSecondInOneMeterPerSecond, meterpersecond.FeetPerSecond, FeetPerSecondTolerance);
            Assert.AreEqual(KilometersPerHourInOneMeterPerSecond, meterpersecond.KilometersPerHour, KilometersPerHourTolerance);
            Assert.AreEqual(KilometersPerSecondInOneMeterPerSecond, meterpersecond.KilometersPerSecond, KilometersPerSecondTolerance);
            Assert.AreEqual(KnotsInOneMeterPerSecond, meterpersecond.Knots, KnotsTolerance);
            Assert.AreEqual(MetersPerHourInOneMeterPerSecond, meterpersecond.MetersPerHour, MetersPerHourTolerance);
            Assert.AreEqual(MetersPerSecondInOneMeterPerSecond, meterpersecond.MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(MicrometersPerSecondInOneMeterPerSecond, meterpersecond.MicrometersPerSecond, MicrometersPerSecondTolerance);
            Assert.AreEqual(MilesPerHourInOneMeterPerSecond, meterpersecond.MilesPerHour, MilesPerHourTolerance);
            Assert.AreEqual(MillimetersPerSecondInOneMeterPerSecond, meterpersecond.MillimetersPerSecond, MillimetersPerSecondTolerance);
            Assert.AreEqual(NanometersPerSecondInOneMeterPerSecond, meterpersecond.NanometersPerSecond, NanometersPerSecondTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.CentimeterPerSecond).CentimetersPerSecond, CentimetersPerSecondTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.DecimeterPerSecond).DecimetersPerSecond, DecimetersPerSecondTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.FootPerSecond).FeetPerSecond, FeetPerSecondTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.KilometerPerHour).KilometersPerHour, KilometersPerHourTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.KilometerPerSecond).KilometersPerSecond, KilometersPerSecondTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.Knot).Knots, KnotsTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.MeterPerHour).MetersPerHour, MetersPerHourTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.MeterPerSecond).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.MicrometerPerSecond).MicrometersPerSecond, MicrometersPerSecondTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.MilePerHour).MilesPerHour, MilesPerHourTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.MillimeterPerSecond).MillimetersPerSecond, MillimetersPerSecondTolerance);
            Assert.AreEqual(1, Speed.From(1, SpeedUnit.NanometerPerSecond).NanometersPerSecond, NanometersPerSecondTolerance);
        }

        [Test]
        public void As()
        {
            var meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(CentimetersPerSecondInOneMeterPerSecond, meterpersecond.As(SpeedUnit.CentimeterPerSecond), CentimetersPerSecondTolerance);
            Assert.AreEqual(DecimetersPerSecondInOneMeterPerSecond, meterpersecond.As(SpeedUnit.DecimeterPerSecond), DecimetersPerSecondTolerance);
            Assert.AreEqual(FeetPerSecondInOneMeterPerSecond, meterpersecond.As(SpeedUnit.FootPerSecond), FeetPerSecondTolerance);
            Assert.AreEqual(KilometersPerHourInOneMeterPerSecond, meterpersecond.As(SpeedUnit.KilometerPerHour), KilometersPerHourTolerance);
            Assert.AreEqual(KilometersPerSecondInOneMeterPerSecond, meterpersecond.As(SpeedUnit.KilometerPerSecond), KilometersPerSecondTolerance);
            Assert.AreEqual(KnotsInOneMeterPerSecond, meterpersecond.As(SpeedUnit.Knot), KnotsTolerance);
            Assert.AreEqual(MetersPerHourInOneMeterPerSecond, meterpersecond.As(SpeedUnit.MeterPerHour), MetersPerHourTolerance);
            Assert.AreEqual(MetersPerSecondInOneMeterPerSecond, meterpersecond.As(SpeedUnit.MeterPerSecond), MetersPerSecondTolerance);
            Assert.AreEqual(MicrometersPerSecondInOneMeterPerSecond, meterpersecond.As(SpeedUnit.MicrometerPerSecond), MicrometersPerSecondTolerance);
            Assert.AreEqual(MilesPerHourInOneMeterPerSecond, meterpersecond.As(SpeedUnit.MilePerHour), MilesPerHourTolerance);
            Assert.AreEqual(MillimetersPerSecondInOneMeterPerSecond, meterpersecond.As(SpeedUnit.MillimeterPerSecond), MillimetersPerSecondTolerance);
            Assert.AreEqual(NanometersPerSecondInOneMeterPerSecond, meterpersecond.As(SpeedUnit.NanometerPerSecond), NanometersPerSecondTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(1, Speed.FromCentimetersPerSecond(meterpersecond.CentimetersPerSecond).MetersPerSecond, CentimetersPerSecondTolerance);
            Assert.AreEqual(1, Speed.FromDecimetersPerSecond(meterpersecond.DecimetersPerSecond).MetersPerSecond, DecimetersPerSecondTolerance);
            Assert.AreEqual(1, Speed.FromFeetPerSecond(meterpersecond.FeetPerSecond).MetersPerSecond, FeetPerSecondTolerance);
            Assert.AreEqual(1, Speed.FromKilometersPerHour(meterpersecond.KilometersPerHour).MetersPerSecond, KilometersPerHourTolerance);
            Assert.AreEqual(1, Speed.FromKilometersPerSecond(meterpersecond.KilometersPerSecond).MetersPerSecond, KilometersPerSecondTolerance);
            Assert.AreEqual(1, Speed.FromKnots(meterpersecond.Knots).MetersPerSecond, KnotsTolerance);
            Assert.AreEqual(1, Speed.FromMetersPerHour(meterpersecond.MetersPerHour).MetersPerSecond, MetersPerHourTolerance);
            Assert.AreEqual(1, Speed.FromMetersPerSecond(meterpersecond.MetersPerSecond).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(1, Speed.FromMicrometersPerSecond(meterpersecond.MicrometersPerSecond).MetersPerSecond, MicrometersPerSecondTolerance);
            Assert.AreEqual(1, Speed.FromMilesPerHour(meterpersecond.MilesPerHour).MetersPerSecond, MilesPerHourTolerance);
            Assert.AreEqual(1, Speed.FromMillimetersPerSecond(meterpersecond.MillimetersPerSecond).MetersPerSecond, MillimetersPerSecondTolerance);
            Assert.AreEqual(1, Speed.FromNanometersPerSecond(meterpersecond.NanometersPerSecond).MetersPerSecond, NanometersPerSecondTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Speed v = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(-1, -v.MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(2, (Speed.FromMetersPerSecond(3)-v).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(2, (v + v).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(10, (v*10).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(10, (10*v).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(2, (Speed.FromMetersPerSecond(10)/5).MetersPerSecond, MetersPerSecondTolerance);
            Assert.AreEqual(2, Speed.FromMetersPerSecond(10)/Speed.FromMetersPerSecond(5), MetersPerSecondTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Speed oneMeterPerSecond = Speed.FromMetersPerSecond(1);
            Speed twoMetersPerSecond = Speed.FromMetersPerSecond(2);

            Assert.True(oneMeterPerSecond < twoMetersPerSecond);
            Assert.True(oneMeterPerSecond <= twoMetersPerSecond);
            Assert.True(twoMetersPerSecond > oneMeterPerSecond);
            Assert.True(twoMetersPerSecond >= oneMeterPerSecond);

            Assert.False(oneMeterPerSecond > twoMetersPerSecond);
            Assert.False(oneMeterPerSecond >= twoMetersPerSecond);
            Assert.False(twoMetersPerSecond < oneMeterPerSecond);
            Assert.False(twoMetersPerSecond <= oneMeterPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.AreEqual(0, meterpersecond.CompareTo(meterpersecond));
            Assert.Greater(meterpersecond.CompareTo(Speed.Zero), 0);
            Assert.Less(Speed.Zero.CompareTo(meterpersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meterpersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meterpersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Speed a = Speed.FromMetersPerSecond(1);
            Speed b = Speed.FromMetersPerSecond(2);

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
            Speed v = Speed.FromMetersPerSecond(1);
            Assert.IsTrue(v.Equals(Speed.FromMetersPerSecond(1)));
            Assert.IsFalse(v.Equals(Speed.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.IsFalse(meterpersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            Assert.IsFalse(meterpersecond.Equals(null));
        }

		[Test]
        public void ToStringReturnsCorrectNumberAndUnitWithDefaultUnit()
        {
            Speed.ToStringDefaultUnit = SpeedUnit.MeterPerSecond;
            Speed meterpersecond = Speed.FromMetersPerSecond(1);
            string meterpersecondString = meterpersecond.ToString();
            Assert.AreEqual("1 " + UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.MeterPerSecond), meterpersecondString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithCentimeterPerSecondAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.CentimeterPerSecond;
            Speed value = Speed.From(1, SpeedUnit.CentimeterPerSecond);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.CentimeterPerSecond);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithDecimeterPerSecondAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.DecimeterPerSecond;
            Speed value = Speed.From(1, SpeedUnit.DecimeterPerSecond);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.DecimeterPerSecond);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithFootPerSecondAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.FootPerSecond;
            Speed value = Speed.From(1, SpeedUnit.FootPerSecond);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.FootPerSecond);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithKilometerPerHourAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.KilometerPerHour;
            Speed value = Speed.From(1, SpeedUnit.KilometerPerHour);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.KilometerPerHour);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithKilometerPerSecondAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.KilometerPerSecond;
            Speed value = Speed.From(1, SpeedUnit.KilometerPerSecond);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.KilometerPerSecond);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithKnotAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.Knot;
            Speed value = Speed.From(1, SpeedUnit.Knot);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.Knot);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithMeterPerHourAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.MeterPerHour;
            Speed value = Speed.From(1, SpeedUnit.MeterPerHour);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.MeterPerHour);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithMeterPerSecondAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.MeterPerSecond;
            Speed value = Speed.From(1, SpeedUnit.MeterPerSecond);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.MeterPerSecond);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithMicrometerPerSecondAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.MicrometerPerSecond;
            Speed value = Speed.From(1, SpeedUnit.MicrometerPerSecond);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.MicrometerPerSecond);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithMilePerHourAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.MilePerHour;
            Speed value = Speed.From(1, SpeedUnit.MilePerHour);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.MilePerHour);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithMillimeterPerSecondAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.MillimeterPerSecond;
            Speed value = Speed.From(1, SpeedUnit.MillimeterPerSecond);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.MillimeterPerSecond);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithNanometerPerSecondAsDefualtUnit()
        {
            SpeedUnit oldUnit = Speed.ToStringDefaultUnit;
            Speed.ToStringDefaultUnit = SpeedUnit.NanometerPerSecond;
            Speed value = Speed.From(1, SpeedUnit.NanometerPerSecond);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(SpeedUnit.NanometerPerSecond);
            Speed.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

    }
}
