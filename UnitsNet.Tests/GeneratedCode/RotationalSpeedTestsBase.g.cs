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
    /// Test of RotationalSpeed.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class RotationalSpeedTestsBase
    {
        protected abstract double CentiradiansPerSecondInOneRadianPerSecond { get; }
        protected abstract double DeciradiansPerSecondInOneRadianPerSecond { get; }
        protected abstract double DegreesPerMinuteInOneRadianPerSecond { get; }
        protected abstract double DegreesPerSecondInOneRadianPerSecond { get; }
        protected abstract double MicrodegreesPerSecondInOneRadianPerSecond { get; }
        protected abstract double MicroradiansPerSecondInOneRadianPerSecond { get; }
        protected abstract double MillidegreesPerSecondInOneRadianPerSecond { get; }
        protected abstract double MilliradiansPerSecondInOneRadianPerSecond { get; }
        protected abstract double NanodegreesPerSecondInOneRadianPerSecond { get; }
        protected abstract double NanoradiansPerSecondInOneRadianPerSecond { get; }
        protected abstract double RadiansPerSecondInOneRadianPerSecond { get; }
        protected abstract double RevolutionsPerMinuteInOneRadianPerSecond { get; }
        protected abstract double RevolutionsPerSecondInOneRadianPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentiradiansPerSecondTolerance { get { return 1e-5; } }
        protected virtual double DeciradiansPerSecondTolerance { get { return 1e-5; } }
        protected virtual double DegreesPerMinuteTolerance { get { return 1e-5; } }
        protected virtual double DegreesPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MicrodegreesPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MicroradiansPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MillidegreesPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MilliradiansPerSecondTolerance { get { return 1e-5; } }
        protected virtual double NanodegreesPerSecondTolerance { get { return 1e-5; } }
        protected virtual double NanoradiansPerSecondTolerance { get { return 1e-5; } }
        protected virtual double RadiansPerSecondTolerance { get { return 1e-5; } }
        protected virtual double RevolutionsPerMinuteTolerance { get { return 1e-5; } }
        protected virtual double RevolutionsPerSecondTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void RadianPerSecondToRotationalSpeedUnits()
        {
            RotationalSpeed radianpersecond = RotationalSpeed.FromRadiansPerSecond(1);
            Assert.AreEqual(CentiradiansPerSecondInOneRadianPerSecond, radianpersecond.CentiradiansPerSecond, CentiradiansPerSecondTolerance);
            Assert.AreEqual(DeciradiansPerSecondInOneRadianPerSecond, radianpersecond.DeciradiansPerSecond, DeciradiansPerSecondTolerance);
            Assert.AreEqual(DegreesPerMinuteInOneRadianPerSecond, radianpersecond.DegreesPerMinute, DegreesPerMinuteTolerance);
            Assert.AreEqual(DegreesPerSecondInOneRadianPerSecond, radianpersecond.DegreesPerSecond, DegreesPerSecondTolerance);
            Assert.AreEqual(MicrodegreesPerSecondInOneRadianPerSecond, radianpersecond.MicrodegreesPerSecond, MicrodegreesPerSecondTolerance);
            Assert.AreEqual(MicroradiansPerSecondInOneRadianPerSecond, radianpersecond.MicroradiansPerSecond, MicroradiansPerSecondTolerance);
            Assert.AreEqual(MillidegreesPerSecondInOneRadianPerSecond, radianpersecond.MillidegreesPerSecond, MillidegreesPerSecondTolerance);
            Assert.AreEqual(MilliradiansPerSecondInOneRadianPerSecond, radianpersecond.MilliradiansPerSecond, MilliradiansPerSecondTolerance);
            Assert.AreEqual(NanodegreesPerSecondInOneRadianPerSecond, radianpersecond.NanodegreesPerSecond, NanodegreesPerSecondTolerance);
            Assert.AreEqual(NanoradiansPerSecondInOneRadianPerSecond, radianpersecond.NanoradiansPerSecond, NanoradiansPerSecondTolerance);
            Assert.AreEqual(RadiansPerSecondInOneRadianPerSecond, radianpersecond.RadiansPerSecond, RadiansPerSecondTolerance);
            Assert.AreEqual(RevolutionsPerMinuteInOneRadianPerSecond, radianpersecond.RevolutionsPerMinute, RevolutionsPerMinuteTolerance);
            Assert.AreEqual(RevolutionsPerSecondInOneRadianPerSecond, radianpersecond.RevolutionsPerSecond, RevolutionsPerSecondTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.CentiradianPerSecond).CentiradiansPerSecond, CentiradiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.DeciradianPerSecond).DeciradiansPerSecond, DeciradiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.DegreePerMinute).DegreesPerMinute, DegreesPerMinuteTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.DegreePerSecond).DegreesPerSecond, DegreesPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.MicrodegreePerSecond).MicrodegreesPerSecond, MicrodegreesPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.MicroradianPerSecond).MicroradiansPerSecond, MicroradiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.MillidegreePerSecond).MillidegreesPerSecond, MillidegreesPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.MilliradianPerSecond).MilliradiansPerSecond, MilliradiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.NanodegreePerSecond).NanodegreesPerSecond, NanodegreesPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.NanoradianPerSecond).NanoradiansPerSecond, NanoradiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.RadianPerSecond).RadiansPerSecond, RadiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.RevolutionPerMinute).RevolutionsPerMinute, RevolutionsPerMinuteTolerance);
            Assert.AreEqual(1, RotationalSpeed.From(1, RotationalSpeedUnit.RevolutionPerSecond).RevolutionsPerSecond, RevolutionsPerSecondTolerance);
        }

        [Test]
        public void As()
        {
            var radianpersecond = RotationalSpeed.FromRadiansPerSecond(1);
            Assert.AreEqual(CentiradiansPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.CentiradianPerSecond), CentiradiansPerSecondTolerance);
            Assert.AreEqual(DeciradiansPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.DeciradianPerSecond), DeciradiansPerSecondTolerance);
            Assert.AreEqual(DegreesPerMinuteInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.DegreePerMinute), DegreesPerMinuteTolerance);
            Assert.AreEqual(DegreesPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.DegreePerSecond), DegreesPerSecondTolerance);
            Assert.AreEqual(MicrodegreesPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.MicrodegreePerSecond), MicrodegreesPerSecondTolerance);
            Assert.AreEqual(MicroradiansPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.MicroradianPerSecond), MicroradiansPerSecondTolerance);
            Assert.AreEqual(MillidegreesPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.MillidegreePerSecond), MillidegreesPerSecondTolerance);
            Assert.AreEqual(MilliradiansPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.MilliradianPerSecond), MilliradiansPerSecondTolerance);
            Assert.AreEqual(NanodegreesPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.NanodegreePerSecond), NanodegreesPerSecondTolerance);
            Assert.AreEqual(NanoradiansPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.NanoradianPerSecond), NanoradiansPerSecondTolerance);
            Assert.AreEqual(RadiansPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.RadianPerSecond), RadiansPerSecondTolerance);
            Assert.AreEqual(RevolutionsPerMinuteInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.RevolutionPerMinute), RevolutionsPerMinuteTolerance);
            Assert.AreEqual(RevolutionsPerSecondInOneRadianPerSecond, radianpersecond.As(RotationalSpeedUnit.RevolutionPerSecond), RevolutionsPerSecondTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            RotationalSpeed radianpersecond = RotationalSpeed.FromRadiansPerSecond(1);
            Assert.AreEqual(1, RotationalSpeed.FromCentiradiansPerSecond(radianpersecond.CentiradiansPerSecond).RadiansPerSecond, CentiradiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromDeciradiansPerSecond(radianpersecond.DeciradiansPerSecond).RadiansPerSecond, DeciradiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromDegreesPerMinute(radianpersecond.DegreesPerMinute).RadiansPerSecond, DegreesPerMinuteTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromDegreesPerSecond(radianpersecond.DegreesPerSecond).RadiansPerSecond, DegreesPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromMicrodegreesPerSecond(radianpersecond.MicrodegreesPerSecond).RadiansPerSecond, MicrodegreesPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromMicroradiansPerSecond(radianpersecond.MicroradiansPerSecond).RadiansPerSecond, MicroradiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromMillidegreesPerSecond(radianpersecond.MillidegreesPerSecond).RadiansPerSecond, MillidegreesPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromMilliradiansPerSecond(radianpersecond.MilliradiansPerSecond).RadiansPerSecond, MilliradiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromNanodegreesPerSecond(radianpersecond.NanodegreesPerSecond).RadiansPerSecond, NanodegreesPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromNanoradiansPerSecond(radianpersecond.NanoradiansPerSecond).RadiansPerSecond, NanoradiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromRadiansPerSecond(radianpersecond.RadiansPerSecond).RadiansPerSecond, RadiansPerSecondTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromRevolutionsPerMinute(radianpersecond.RevolutionsPerMinute).RadiansPerSecond, RevolutionsPerMinuteTolerance);
            Assert.AreEqual(1, RotationalSpeed.FromRevolutionsPerSecond(radianpersecond.RevolutionsPerSecond).RadiansPerSecond, RevolutionsPerSecondTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            RotationalSpeed v = RotationalSpeed.FromRadiansPerSecond(1);
            Assert.AreEqual(-1, -v.RadiansPerSecond, RadiansPerSecondTolerance);
            Assert.AreEqual(2, (RotationalSpeed.FromRadiansPerSecond(3)-v).RadiansPerSecond, RadiansPerSecondTolerance);
            Assert.AreEqual(2, (v + v).RadiansPerSecond, RadiansPerSecondTolerance);
            Assert.AreEqual(10, (v*10).RadiansPerSecond, RadiansPerSecondTolerance);
            Assert.AreEqual(10, (10*v).RadiansPerSecond, RadiansPerSecondTolerance);
            Assert.AreEqual(2, (RotationalSpeed.FromRadiansPerSecond(10)/5).RadiansPerSecond, RadiansPerSecondTolerance);
            Assert.AreEqual(2, RotationalSpeed.FromRadiansPerSecond(10)/RotationalSpeed.FromRadiansPerSecond(5), RadiansPerSecondTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            RotationalSpeed oneRadianPerSecond = RotationalSpeed.FromRadiansPerSecond(1);
            RotationalSpeed twoRadiansPerSecond = RotationalSpeed.FromRadiansPerSecond(2);

            Assert.True(oneRadianPerSecond < twoRadiansPerSecond);
            Assert.True(oneRadianPerSecond <= twoRadiansPerSecond);
            Assert.True(twoRadiansPerSecond > oneRadianPerSecond);
            Assert.True(twoRadiansPerSecond >= oneRadianPerSecond);

            Assert.False(oneRadianPerSecond > twoRadiansPerSecond);
            Assert.False(oneRadianPerSecond >= twoRadiansPerSecond);
            Assert.False(twoRadiansPerSecond < oneRadianPerSecond);
            Assert.False(twoRadiansPerSecond <= oneRadianPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            RotationalSpeed radianpersecond = RotationalSpeed.FromRadiansPerSecond(1);
            Assert.AreEqual(0, radianpersecond.CompareTo(radianpersecond));
            Assert.Greater(radianpersecond.CompareTo(RotationalSpeed.Zero), 0);
            Assert.Less(RotationalSpeed.Zero.CompareTo(radianpersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            RotationalSpeed radianpersecond = RotationalSpeed.FromRadiansPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            radianpersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            RotationalSpeed radianpersecond = RotationalSpeed.FromRadiansPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            radianpersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            RotationalSpeed a = RotationalSpeed.FromRadiansPerSecond(1);
            RotationalSpeed b = RotationalSpeed.FromRadiansPerSecond(2);

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
            RotationalSpeed v = RotationalSpeed.FromRadiansPerSecond(1);
            Assert.IsTrue(v.Equals(RotationalSpeed.FromRadiansPerSecond(1)));
            Assert.IsFalse(v.Equals(RotationalSpeed.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            RotationalSpeed radianpersecond = RotationalSpeed.FromRadiansPerSecond(1);
            Assert.IsFalse(radianpersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            RotationalSpeed radianpersecond = RotationalSpeed.FromRadiansPerSecond(1);
            Assert.IsFalse(radianpersecond.Equals(null));
        }
    }
}
