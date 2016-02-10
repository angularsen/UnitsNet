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
    /// Test of Angle.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class AngleTestsBase
    {
        protected abstract double ArcminutesInOneDegree { get; }
        protected abstract double ArcsecondsInOneDegree { get; }
        protected abstract double CentiradiansInOneDegree { get; }
        protected abstract double DeciradiansInOneDegree { get; }
        protected abstract double DegreesInOneDegree { get; }
        protected abstract double GradiansInOneDegree { get; }
        protected abstract double MicroradiansInOneDegree { get; }
        protected abstract double MilliradiansInOneDegree { get; }
        protected abstract double NanoradiansInOneDegree { get; }
        protected abstract double RadiansInOneDegree { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double ArcminutesTolerance { get { return 1e-5; } }
        protected virtual double ArcsecondsTolerance { get { return 1e-5; } }
        protected virtual double CentiradiansTolerance { get { return 1e-5; } }
        protected virtual double DeciradiansTolerance { get { return 1e-5; } }
        protected virtual double DegreesTolerance { get { return 1e-5; } }
        protected virtual double GradiansTolerance { get { return 1e-5; } }
        protected virtual double MicroradiansTolerance { get { return 1e-5; } }
        protected virtual double MilliradiansTolerance { get { return 1e-5; } }
        protected virtual double NanoradiansTolerance { get { return 1e-5; } }
        protected virtual double RadiansTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void DegreeToAngleUnits()
        {
            Angle degree = Angle.FromDegrees(1);
            Assert.AreEqual(ArcminutesInOneDegree, degree.Arcminutes, ArcminutesTolerance);
            Assert.AreEqual(ArcsecondsInOneDegree, degree.Arcseconds, ArcsecondsTolerance);
            Assert.AreEqual(CentiradiansInOneDegree, degree.Centiradians, CentiradiansTolerance);
            Assert.AreEqual(DeciradiansInOneDegree, degree.Deciradians, DeciradiansTolerance);
            Assert.AreEqual(DegreesInOneDegree, degree.Degrees, DegreesTolerance);
            Assert.AreEqual(GradiansInOneDegree, degree.Gradians, GradiansTolerance);
            Assert.AreEqual(MicroradiansInOneDegree, degree.Microradians, MicroradiansTolerance);
            Assert.AreEqual(MilliradiansInOneDegree, degree.Milliradians, MilliradiansTolerance);
            Assert.AreEqual(NanoradiansInOneDegree, degree.Nanoradians, NanoradiansTolerance);
            Assert.AreEqual(RadiansInOneDegree, degree.Radians, RadiansTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Arcminute).Arcminutes, ArcminutesTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Arcsecond).Arcseconds, ArcsecondsTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Centiradian).Centiradians, CentiradiansTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Deciradian).Deciradians, DeciradiansTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Degree).Degrees, DegreesTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Gradian).Gradians, GradiansTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Microradian).Microradians, MicroradiansTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Milliradian).Milliradians, MilliradiansTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Nanoradian).Nanoradians, NanoradiansTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Radian).Radians, RadiansTolerance);
        }

        [Test]
        public void As()
        {
            var degree = Angle.FromDegrees(1);
            Assert.AreEqual(ArcminutesInOneDegree, degree.As(AngleUnit.Arcminute), ArcminutesTolerance);
            Assert.AreEqual(ArcsecondsInOneDegree, degree.As(AngleUnit.Arcsecond), ArcsecondsTolerance);
            Assert.AreEqual(CentiradiansInOneDegree, degree.As(AngleUnit.Centiradian), CentiradiansTolerance);
            Assert.AreEqual(DeciradiansInOneDegree, degree.As(AngleUnit.Deciradian), DeciradiansTolerance);
            Assert.AreEqual(DegreesInOneDegree, degree.As(AngleUnit.Degree), DegreesTolerance);
            Assert.AreEqual(GradiansInOneDegree, degree.As(AngleUnit.Gradian), GradiansTolerance);
            Assert.AreEqual(MicroradiansInOneDegree, degree.As(AngleUnit.Microradian), MicroradiansTolerance);
            Assert.AreEqual(MilliradiansInOneDegree, degree.As(AngleUnit.Milliradian), MilliradiansTolerance);
            Assert.AreEqual(NanoradiansInOneDegree, degree.As(AngleUnit.Nanoradian), NanoradiansTolerance);
            Assert.AreEqual(RadiansInOneDegree, degree.As(AngleUnit.Radian), RadiansTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Angle degree = Angle.FromDegrees(1);
            Assert.AreEqual(1, Angle.FromArcminutes(degree.Arcminutes).Degrees, ArcminutesTolerance);
            Assert.AreEqual(1, Angle.FromArcseconds(degree.Arcseconds).Degrees, ArcsecondsTolerance);
            Assert.AreEqual(1, Angle.FromCentiradians(degree.Centiradians).Degrees, CentiradiansTolerance);
            Assert.AreEqual(1, Angle.FromDeciradians(degree.Deciradians).Degrees, DeciradiansTolerance);
            Assert.AreEqual(1, Angle.FromDegrees(degree.Degrees).Degrees, DegreesTolerance);
            Assert.AreEqual(1, Angle.FromGradians(degree.Gradians).Degrees, GradiansTolerance);
            Assert.AreEqual(1, Angle.FromMicroradians(degree.Microradians).Degrees, MicroradiansTolerance);
            Assert.AreEqual(1, Angle.FromMilliradians(degree.Milliradians).Degrees, MilliradiansTolerance);
            Assert.AreEqual(1, Angle.FromNanoradians(degree.Nanoradians).Degrees, NanoradiansTolerance);
            Assert.AreEqual(1, Angle.FromRadians(degree.Radians).Degrees, RadiansTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Angle v = Angle.FromDegrees(1);
            Assert.AreEqual(-1, -v.Degrees, DegreesTolerance);
            Assert.AreEqual(2, (Angle.FromDegrees(3)-v).Degrees, DegreesTolerance);
            Assert.AreEqual(2, (v + v).Degrees, DegreesTolerance);
            Assert.AreEqual(10, (v*10).Degrees, DegreesTolerance);
            Assert.AreEqual(10, (10*v).Degrees, DegreesTolerance);
            Assert.AreEqual(2, (Angle.FromDegrees(10)/5).Degrees, DegreesTolerance);
            Assert.AreEqual(2, Angle.FromDegrees(10)/Angle.FromDegrees(5), DegreesTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Angle oneDegree = Angle.FromDegrees(1);
            Angle twoDegrees = Angle.FromDegrees(2);

            Assert.True(oneDegree < twoDegrees);
            Assert.True(oneDegree <= twoDegrees);
            Assert.True(twoDegrees > oneDegree);
            Assert.True(twoDegrees >= oneDegree);

            Assert.False(oneDegree > twoDegrees);
            Assert.False(oneDegree >= twoDegrees);
            Assert.False(twoDegrees < oneDegree);
            Assert.False(twoDegrees <= oneDegree);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Angle degree = Angle.FromDegrees(1);
            Assert.AreEqual(0, degree.CompareTo(degree));
            Assert.Greater(degree.CompareTo(Angle.Zero), 0);
            Assert.Less(Angle.Zero.CompareTo(degree), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Angle degree = Angle.FromDegrees(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            degree.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Angle degree = Angle.FromDegrees(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            degree.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Angle a = Angle.FromDegrees(1);
            Angle b = Angle.FromDegrees(2);

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
            Angle v = Angle.FromDegrees(1);
            Assert.IsTrue(v.Equals(Angle.FromDegrees(1)));
            Assert.IsFalse(v.Equals(Angle.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Angle degree = Angle.FromDegrees(1);
            Assert.IsFalse(degree.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Angle degree = Angle.FromDegrees(1);
            Assert.IsFalse(degree.Equals(null));
        }

		[Test]
        public void ToStringReturnsCorrectNumberAndUnitWithDefaultUnit()
        {
            Angle.ToStringDefaultUnit = AngleUnit.Degree;
            Angle degree = Angle.FromDegrees(1);
            string degreeString = degree.ToString();
            Assert.AreEqual("1 " + UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Degree), degreeString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithArcminuteAsDefualtUnit()
        {
            AngleUnit oldUnit = Angle.ToStringDefaultUnit;
            Angle.ToStringDefaultUnit = AngleUnit.Arcminute;
            Angle value = Angle.From(1, AngleUnit.Arcminute);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Arcminute);
            Angle.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithArcsecondAsDefualtUnit()
        {
            AngleUnit oldUnit = Angle.ToStringDefaultUnit;
            Angle.ToStringDefaultUnit = AngleUnit.Arcsecond;
            Angle value = Angle.From(1, AngleUnit.Arcsecond);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Arcsecond);
            Angle.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithCentiradianAsDefualtUnit()
        {
            AngleUnit oldUnit = Angle.ToStringDefaultUnit;
            Angle.ToStringDefaultUnit = AngleUnit.Centiradian;
            Angle value = Angle.From(1, AngleUnit.Centiradian);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Centiradian);
            Angle.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithDeciradianAsDefualtUnit()
        {
            AngleUnit oldUnit = Angle.ToStringDefaultUnit;
            Angle.ToStringDefaultUnit = AngleUnit.Deciradian;
            Angle value = Angle.From(1, AngleUnit.Deciradian);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Deciradian);
            Angle.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithDegreeAsDefualtUnit()
        {
            AngleUnit oldUnit = Angle.ToStringDefaultUnit;
            Angle.ToStringDefaultUnit = AngleUnit.Degree;
            Angle value = Angle.From(1, AngleUnit.Degree);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Degree);
            Angle.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithGradianAsDefualtUnit()
        {
            AngleUnit oldUnit = Angle.ToStringDefaultUnit;
            Angle.ToStringDefaultUnit = AngleUnit.Gradian;
            Angle value = Angle.From(1, AngleUnit.Gradian);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Gradian);
            Angle.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithMicroradianAsDefualtUnit()
        {
            AngleUnit oldUnit = Angle.ToStringDefaultUnit;
            Angle.ToStringDefaultUnit = AngleUnit.Microradian;
            Angle value = Angle.From(1, AngleUnit.Microradian);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Microradian);
            Angle.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithMilliradianAsDefualtUnit()
        {
            AngleUnit oldUnit = Angle.ToStringDefaultUnit;
            Angle.ToStringDefaultUnit = AngleUnit.Milliradian;
            Angle value = Angle.From(1, AngleUnit.Milliradian);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Milliradian);
            Angle.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithNanoradianAsDefualtUnit()
        {
            AngleUnit oldUnit = Angle.ToStringDefaultUnit;
            Angle.ToStringDefaultUnit = AngleUnit.Nanoradian;
            Angle value = Angle.From(1, AngleUnit.Nanoradian);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Nanoradian);
            Angle.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

        [Test]
        public void ToStringReturnsCorrectNumberAndUnitWithRadianAsDefualtUnit()
        {
            AngleUnit oldUnit = Angle.ToStringDefaultUnit;
            Angle.ToStringDefaultUnit = AngleUnit.Radian;
            Angle value = Angle.From(1, AngleUnit.Radian);
            string valueString = value.ToString();
            string unitString = UnitSystem.GetCached(null).GetDefaultAbbreviation(AngleUnit.Radian);
            Angle.ToStringDefaultUnit = oldUnit;
            Assert.AreEqual("1 " + unitString, valueString);
        }

    }
}
