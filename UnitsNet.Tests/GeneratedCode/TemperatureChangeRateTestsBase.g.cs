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
    /// Test of TemperatureChangeRate.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class TemperatureChangeRateTestsBase
    {
        protected abstract double CentidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond { get; }
        protected abstract double DecadegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond { get; }
        protected abstract double DecidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond { get; }
        protected abstract double DegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond { get; }
        protected abstract double HectodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond { get; }
        protected abstract double KilodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond { get; }
        protected abstract double MicrodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond { get; }
        protected abstract double MillidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond { get; }
        protected abstract double NanodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentidegreesCelsiusPerSecondTolerance { get { return 1e-5; } }
        protected virtual double DecadegreesCelsiusPerSecondTolerance { get { return 1e-5; } }
        protected virtual double DecidegreesCelsiusPerSecondTolerance { get { return 1e-5; } }
        protected virtual double DegreesCelsiusPerSecondTolerance { get { return 1e-5; } }
        protected virtual double HectodegreesCelsiusPerSecondTolerance { get { return 1e-5; } }
        protected virtual double KilodegreesCelsiusPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MicrodegreesCelsiusPerSecondTolerance { get { return 1e-5; } }
        protected virtual double MillidegreesCelsiusPerSecondTolerance { get { return 1e-5; } }
        protected virtual double NanodegreesCelsiusPerSecondTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void DegreeCelsiusPerSecondToTemperatureChangeRateUnits()
        {
            TemperatureChangeRate degreecelsiuspersecond = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
            Assert.AreEqual(CentidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.CentidegreesCelsiusPerSecond, CentidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(DecadegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.DecadegreesCelsiusPerSecond, DecadegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(DecidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.DecidegreesCelsiusPerSecond, DecidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(DegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.DegreesCelsiusPerSecond, DegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(HectodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.HectodegreesCelsiusPerSecond, HectodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(KilodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.KilodegreesCelsiusPerSecond, KilodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(MicrodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.MicrodegreesCelsiusPerSecond, MicrodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(MillidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.MillidegreesCelsiusPerSecond, MillidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(NanodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.NanodegreesCelsiusPerSecond, NanodegreesCelsiusPerSecondTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, TemperatureChangeRate.From(1, TemperatureChangeRateUnit.CentidegreeCelsiusPerSecond).CentidegreesCelsiusPerSecond, CentidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.From(1, TemperatureChangeRateUnit.DecadegreeCelsiusPerSecond).DecadegreesCelsiusPerSecond, DecadegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.From(1, TemperatureChangeRateUnit.DecidegreeCelsiusPerSecond).DecidegreesCelsiusPerSecond, DecidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.From(1, TemperatureChangeRateUnit.DegreeCelsiusPerSecond).DegreesCelsiusPerSecond, DegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.From(1, TemperatureChangeRateUnit.HectodegreeCelsiusPerSecond).HectodegreesCelsiusPerSecond, HectodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.From(1, TemperatureChangeRateUnit.KilodegreeCelsiusPerSecond).KilodegreesCelsiusPerSecond, KilodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.From(1, TemperatureChangeRateUnit.MicrodegreeCelsiusPerSecond).MicrodegreesCelsiusPerSecond, MicrodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.From(1, TemperatureChangeRateUnit.MillidegreeCelsiusPerSecond).MillidegreesCelsiusPerSecond, MillidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.From(1, TemperatureChangeRateUnit.NanodegreeCelsiusPerSecond).NanodegreesCelsiusPerSecond, NanodegreesCelsiusPerSecondTolerance);
        }

        [Test]
        public void As()
        {
            var degreecelsiuspersecond = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
            Assert.AreEqual(CentidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.As(TemperatureChangeRateUnit.CentidegreeCelsiusPerSecond), CentidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(DecadegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.As(TemperatureChangeRateUnit.DecadegreeCelsiusPerSecond), DecadegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(DecidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.As(TemperatureChangeRateUnit.DecidegreeCelsiusPerSecond), DecidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(DegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.As(TemperatureChangeRateUnit.DegreeCelsiusPerSecond), DegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(HectodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.As(TemperatureChangeRateUnit.HectodegreeCelsiusPerSecond), HectodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(KilodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.As(TemperatureChangeRateUnit.KilodegreeCelsiusPerSecond), KilodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(MicrodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.As(TemperatureChangeRateUnit.MicrodegreeCelsiusPerSecond), MicrodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(MillidegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.As(TemperatureChangeRateUnit.MillidegreeCelsiusPerSecond), MillidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(NanodegreesCelsiusPerSecondInOneDegreeCelsiusPerSecond, degreecelsiuspersecond.As(TemperatureChangeRateUnit.NanodegreeCelsiusPerSecond), NanodegreesCelsiusPerSecondTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            TemperatureChangeRate degreecelsiuspersecond = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
            Assert.AreEqual(1, TemperatureChangeRate.FromCentidegreesCelsiusPerSecond(degreecelsiuspersecond.CentidegreesCelsiusPerSecond).DegreesCelsiusPerSecond, CentidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.FromDecadegreesCelsiusPerSecond(degreecelsiuspersecond.DecadegreesCelsiusPerSecond).DegreesCelsiusPerSecond, DecadegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.FromDecidegreesCelsiusPerSecond(degreecelsiuspersecond.DecidegreesCelsiusPerSecond).DegreesCelsiusPerSecond, DecidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.FromDegreesCelsiusPerSecond(degreecelsiuspersecond.DegreesCelsiusPerSecond).DegreesCelsiusPerSecond, DegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.FromHectodegreesCelsiusPerSecond(degreecelsiuspersecond.HectodegreesCelsiusPerSecond).DegreesCelsiusPerSecond, HectodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.FromKilodegreesCelsiusPerSecond(degreecelsiuspersecond.KilodegreesCelsiusPerSecond).DegreesCelsiusPerSecond, KilodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.FromMicrodegreesCelsiusPerSecond(degreecelsiuspersecond.MicrodegreesCelsiusPerSecond).DegreesCelsiusPerSecond, MicrodegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.FromMillidegreesCelsiusPerSecond(degreecelsiuspersecond.MillidegreesCelsiusPerSecond).DegreesCelsiusPerSecond, MillidegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(1, TemperatureChangeRate.FromNanodegreesCelsiusPerSecond(degreecelsiuspersecond.NanodegreesCelsiusPerSecond).DegreesCelsiusPerSecond, NanodegreesCelsiusPerSecondTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            TemperatureChangeRate v = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
            Assert.AreEqual(-1, -v.DegreesCelsiusPerSecond, DegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(2, (TemperatureChangeRate.FromDegreesCelsiusPerSecond(3)-v).DegreesCelsiusPerSecond, DegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(2, (v + v).DegreesCelsiusPerSecond, DegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(10, (v*10).DegreesCelsiusPerSecond, DegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(10, (10*v).DegreesCelsiusPerSecond, DegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(2, (TemperatureChangeRate.FromDegreesCelsiusPerSecond(10)/5).DegreesCelsiusPerSecond, DegreesCelsiusPerSecondTolerance);
            Assert.AreEqual(2, TemperatureChangeRate.FromDegreesCelsiusPerSecond(10)/TemperatureChangeRate.FromDegreesCelsiusPerSecond(5), DegreesCelsiusPerSecondTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            TemperatureChangeRate oneDegreeCelsiusPerSecond = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
            TemperatureChangeRate twoDegreesCelsiusPerSecond = TemperatureChangeRate.FromDegreesCelsiusPerSecond(2);

            Assert.True(oneDegreeCelsiusPerSecond < twoDegreesCelsiusPerSecond);
            Assert.True(oneDegreeCelsiusPerSecond <= twoDegreesCelsiusPerSecond);
            Assert.True(twoDegreesCelsiusPerSecond > oneDegreeCelsiusPerSecond);
            Assert.True(twoDegreesCelsiusPerSecond >= oneDegreeCelsiusPerSecond);

            Assert.False(oneDegreeCelsiusPerSecond > twoDegreesCelsiusPerSecond);
            Assert.False(oneDegreeCelsiusPerSecond >= twoDegreesCelsiusPerSecond);
            Assert.False(twoDegreesCelsiusPerSecond < oneDegreeCelsiusPerSecond);
            Assert.False(twoDegreesCelsiusPerSecond <= oneDegreeCelsiusPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            TemperatureChangeRate degreecelsiuspersecond = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
            Assert.AreEqual(0, degreecelsiuspersecond.CompareTo(degreecelsiuspersecond));
            Assert.Greater(degreecelsiuspersecond.CompareTo(TemperatureChangeRate.Zero), 0);
            Assert.Less(TemperatureChangeRate.Zero.CompareTo(degreecelsiuspersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            TemperatureChangeRate degreecelsiuspersecond = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            degreecelsiuspersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            TemperatureChangeRate degreecelsiuspersecond = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            degreecelsiuspersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            TemperatureChangeRate a = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
            TemperatureChangeRate b = TemperatureChangeRate.FromDegreesCelsiusPerSecond(2);

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
            TemperatureChangeRate v = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
            Assert.IsTrue(v.Equals(TemperatureChangeRate.FromDegreesCelsiusPerSecond(1)));
            Assert.IsFalse(v.Equals(TemperatureChangeRate.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            TemperatureChangeRate degreecelsiuspersecond = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
            Assert.IsFalse(degreecelsiuspersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            TemperatureChangeRate degreecelsiuspersecond = TemperatureChangeRate.FromDegreesCelsiusPerSecond(1);
            Assert.IsFalse(degreecelsiuspersecond.Equals(null));
        }
    }
}
