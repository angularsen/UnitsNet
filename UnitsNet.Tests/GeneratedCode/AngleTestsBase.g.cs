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
        protected abstract double MicrodegreesInOneDegree { get; }
        protected abstract double MicroradiansInOneDegree { get; }
        protected abstract double MillidegreesInOneDegree { get; }
        protected abstract double MilliradiansInOneDegree { get; }
        protected abstract double NanodegreesInOneDegree { get; }
        protected abstract double NanoradiansInOneDegree { get; }
        protected abstract double RadiansInOneDegree { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double ArcminutesTolerance { get { return 1e-5; } }
        protected virtual double ArcsecondsTolerance { get { return 1e-5; } }
        protected virtual double CentiradiansTolerance { get { return 1e-5; } }
        protected virtual double DeciradiansTolerance { get { return 1e-5; } }
        protected virtual double DegreesTolerance { get { return 1e-5; } }
        protected virtual double GradiansTolerance { get { return 1e-5; } }
        protected virtual double MicrodegreesTolerance { get { return 1e-5; } }
        protected virtual double MicroradiansTolerance { get { return 1e-5; } }
        protected virtual double MillidegreesTolerance { get { return 1e-5; } }
        protected virtual double MilliradiansTolerance { get { return 1e-5; } }
        protected virtual double NanodegreesTolerance { get { return 1e-5; } }
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
            Assert.AreEqual(MicrodegreesInOneDegree, degree.Microdegrees, MicrodegreesTolerance);
            Assert.AreEqual(MicroradiansInOneDegree, degree.Microradians, MicroradiansTolerance);
            Assert.AreEqual(MillidegreesInOneDegree, degree.Millidegrees, MillidegreesTolerance);
            Assert.AreEqual(MilliradiansInOneDegree, degree.Milliradians, MilliradiansTolerance);
            Assert.AreEqual(NanodegreesInOneDegree, degree.Nanodegrees, NanodegreesTolerance);
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
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Microdegree).Microdegrees, MicrodegreesTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Microradian).Microradians, MicroradiansTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Millidegree).Millidegrees, MillidegreesTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Milliradian).Milliradians, MilliradiansTolerance);
            Assert.AreEqual(1, Angle.From(1, AngleUnit.Nanodegree).Nanodegrees, NanodegreesTolerance);
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
            Assert.AreEqual(MicrodegreesInOneDegree, degree.As(AngleUnit.Microdegree), MicrodegreesTolerance);
            Assert.AreEqual(MicroradiansInOneDegree, degree.As(AngleUnit.Microradian), MicroradiansTolerance);
            Assert.AreEqual(MillidegreesInOneDegree, degree.As(AngleUnit.Millidegree), MillidegreesTolerance);
            Assert.AreEqual(MilliradiansInOneDegree, degree.As(AngleUnit.Milliradian), MilliradiansTolerance);
            Assert.AreEqual(NanodegreesInOneDegree, degree.As(AngleUnit.Nanodegree), NanodegreesTolerance);
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
            Assert.AreEqual(1, Angle.FromMicrodegrees(degree.Microdegrees).Degrees, MicrodegreesTolerance);
            Assert.AreEqual(1, Angle.FromMicroradians(degree.Microradians).Degrees, MicroradiansTolerance);
            Assert.AreEqual(1, Angle.FromMillidegrees(degree.Millidegrees).Degrees, MillidegreesTolerance);
            Assert.AreEqual(1, Angle.FromMilliradians(degree.Milliradians).Degrees, MilliradiansTolerance);
            Assert.AreEqual(1, Angle.FromNanodegrees(degree.Nanodegrees).Degrees, NanodegreesTolerance);
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
    }
}
