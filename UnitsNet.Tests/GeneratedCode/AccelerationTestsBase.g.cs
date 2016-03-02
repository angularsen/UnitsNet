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
    /// Test of Acceleration.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class AccelerationTestsBase
    {
        protected abstract double CentimeterPerSecondSquaredInOneMeterPerSecondSquared { get; }
        protected abstract double DecimeterPerSecondSquaredInOneMeterPerSecondSquared { get; }
        protected abstract double KilometerPerSecondSquaredInOneMeterPerSecondSquared { get; }
        protected abstract double MeterPerSecondSquaredInOneMeterPerSecondSquared { get; }
        protected abstract double MicrometerPerSecondSquaredInOneMeterPerSecondSquared { get; }
        protected abstract double MillimeterPerSecondSquaredInOneMeterPerSecondSquared { get; }
        protected abstract double NanometerPerSecondSquaredInOneMeterPerSecondSquared { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double CentimeterPerSecondSquaredTolerance { get { return 1e-5; } }
        protected virtual double DecimeterPerSecondSquaredTolerance { get { return 1e-5; } }
        protected virtual double KilometerPerSecondSquaredTolerance { get { return 1e-5; } }
        protected virtual double MeterPerSecondSquaredTolerance { get { return 1e-5; } }
        protected virtual double MicrometerPerSecondSquaredTolerance { get { return 1e-5; } }
        protected virtual double MillimeterPerSecondSquaredTolerance { get { return 1e-5; } }
        protected virtual double NanometerPerSecondSquaredTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void MeterPerSecondSquaredToAccelerationUnits()
        {
            Acceleration meterpersecondsquared = Acceleration.FromMeterPerSecondSquared(1);
            Assert.AreEqual(CentimeterPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.CentimeterPerSecondSquared, CentimeterPerSecondSquaredTolerance);
            Assert.AreEqual(DecimeterPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.DecimeterPerSecondSquared, DecimeterPerSecondSquaredTolerance);
            Assert.AreEqual(KilometerPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.KilometerPerSecondSquared, KilometerPerSecondSquaredTolerance);
            Assert.AreEqual(MeterPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.MeterPerSecondSquared, MeterPerSecondSquaredTolerance);
            Assert.AreEqual(MicrometerPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.MicrometerPerSecondSquared, MicrometerPerSecondSquaredTolerance);
            Assert.AreEqual(MillimeterPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.MillimeterPerSecondSquared, MillimeterPerSecondSquaredTolerance);
            Assert.AreEqual(NanometerPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.NanometerPerSecondSquared, NanometerPerSecondSquaredTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Acceleration.From(1, AccelerationUnit.CentimeterPerSecondSquared).CentimeterPerSecondSquared, CentimeterPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.From(1, AccelerationUnit.DecimeterPerSecondSquared).DecimeterPerSecondSquared, DecimeterPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.From(1, AccelerationUnit.KilometerPerSecondSquared).KilometerPerSecondSquared, KilometerPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.From(1, AccelerationUnit.MeterPerSecondSquared).MeterPerSecondSquared, MeterPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.From(1, AccelerationUnit.MicrometerPerSecondSquared).MicrometerPerSecondSquared, MicrometerPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.From(1, AccelerationUnit.MillimeterPerSecondSquared).MillimeterPerSecondSquared, MillimeterPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.From(1, AccelerationUnit.NanometerPerSecondSquared).NanometerPerSecondSquared, NanometerPerSecondSquaredTolerance);
        }

        [Test]
        public void As()
        {
            var meterpersecondsquared = Acceleration.FromMeterPerSecondSquared(1);
            Assert.AreEqual(CentimeterPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.As(AccelerationUnit.CentimeterPerSecondSquared), CentimeterPerSecondSquaredTolerance);
            Assert.AreEqual(DecimeterPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.As(AccelerationUnit.DecimeterPerSecondSquared), DecimeterPerSecondSquaredTolerance);
            Assert.AreEqual(KilometerPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.As(AccelerationUnit.KilometerPerSecondSquared), KilometerPerSecondSquaredTolerance);
            Assert.AreEqual(MeterPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.As(AccelerationUnit.MeterPerSecondSquared), MeterPerSecondSquaredTolerance);
            Assert.AreEqual(MicrometerPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.As(AccelerationUnit.MicrometerPerSecondSquared), MicrometerPerSecondSquaredTolerance);
            Assert.AreEqual(MillimeterPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.As(AccelerationUnit.MillimeterPerSecondSquared), MillimeterPerSecondSquaredTolerance);
            Assert.AreEqual(NanometerPerSecondSquaredInOneMeterPerSecondSquared, meterpersecondsquared.As(AccelerationUnit.NanometerPerSecondSquared), NanometerPerSecondSquaredTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Acceleration meterpersecondsquared = Acceleration.FromMeterPerSecondSquared(1);
            Assert.AreEqual(1, Acceleration.FromCentimeterPerSecondSquared(meterpersecondsquared.CentimeterPerSecondSquared).MeterPerSecondSquared, CentimeterPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.FromDecimeterPerSecondSquared(meterpersecondsquared.DecimeterPerSecondSquared).MeterPerSecondSquared, DecimeterPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.FromKilometerPerSecondSquared(meterpersecondsquared.KilometerPerSecondSquared).MeterPerSecondSquared, KilometerPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.FromMeterPerSecondSquared(meterpersecondsquared.MeterPerSecondSquared).MeterPerSecondSquared, MeterPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.FromMicrometerPerSecondSquared(meterpersecondsquared.MicrometerPerSecondSquared).MeterPerSecondSquared, MicrometerPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.FromMillimeterPerSecondSquared(meterpersecondsquared.MillimeterPerSecondSquared).MeterPerSecondSquared, MillimeterPerSecondSquaredTolerance);
            Assert.AreEqual(1, Acceleration.FromNanometerPerSecondSquared(meterpersecondsquared.NanometerPerSecondSquared).MeterPerSecondSquared, NanometerPerSecondSquaredTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Acceleration v = Acceleration.FromMeterPerSecondSquared(1);
            Assert.AreEqual(-1, -v.MeterPerSecondSquared, MeterPerSecondSquaredTolerance);
            Assert.AreEqual(2, (Acceleration.FromMeterPerSecondSquared(3)-v).MeterPerSecondSquared, MeterPerSecondSquaredTolerance);
            Assert.AreEqual(2, (v + v).MeterPerSecondSquared, MeterPerSecondSquaredTolerance);
            Assert.AreEqual(10, (v*10).MeterPerSecondSquared, MeterPerSecondSquaredTolerance);
            Assert.AreEqual(10, (10*v).MeterPerSecondSquared, MeterPerSecondSquaredTolerance);
            Assert.AreEqual(2, (Acceleration.FromMeterPerSecondSquared(10)/5).MeterPerSecondSquared, MeterPerSecondSquaredTolerance);
            Assert.AreEqual(2, Acceleration.FromMeterPerSecondSquared(10)/Acceleration.FromMeterPerSecondSquared(5), MeterPerSecondSquaredTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Acceleration oneMeterPerSecondSquared = Acceleration.FromMeterPerSecondSquared(1);
            Acceleration twoMeterPerSecondSquared = Acceleration.FromMeterPerSecondSquared(2);

            Assert.True(oneMeterPerSecondSquared < twoMeterPerSecondSquared);
            Assert.True(oneMeterPerSecondSquared <= twoMeterPerSecondSquared);
            Assert.True(twoMeterPerSecondSquared > oneMeterPerSecondSquared);
            Assert.True(twoMeterPerSecondSquared >= oneMeterPerSecondSquared);

            Assert.False(oneMeterPerSecondSquared > twoMeterPerSecondSquared);
            Assert.False(oneMeterPerSecondSquared >= twoMeterPerSecondSquared);
            Assert.False(twoMeterPerSecondSquared < oneMeterPerSecondSquared);
            Assert.False(twoMeterPerSecondSquared <= oneMeterPerSecondSquared);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Acceleration meterpersecondsquared = Acceleration.FromMeterPerSecondSquared(1);
            Assert.AreEqual(0, meterpersecondsquared.CompareTo(meterpersecondsquared));
            Assert.Greater(meterpersecondsquared.CompareTo(Acceleration.Zero), 0);
            Assert.Less(Acceleration.Zero.CompareTo(meterpersecondsquared), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Acceleration meterpersecondsquared = Acceleration.FromMeterPerSecondSquared(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meterpersecondsquared.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Acceleration meterpersecondsquared = Acceleration.FromMeterPerSecondSquared(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            meterpersecondsquared.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Acceleration a = Acceleration.FromMeterPerSecondSquared(1);
            Acceleration b = Acceleration.FromMeterPerSecondSquared(2);

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
            Acceleration v = Acceleration.FromMeterPerSecondSquared(1);
            Assert.IsTrue(v.Equals(Acceleration.FromMeterPerSecondSquared(1)));
            Assert.IsFalse(v.Equals(Acceleration.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Acceleration meterpersecondsquared = Acceleration.FromMeterPerSecondSquared(1);
            Assert.IsFalse(meterpersecondsquared.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Acceleration meterpersecondsquared = Acceleration.FromMeterPerSecondSquared(1);
            Assert.IsFalse(meterpersecondsquared.Equals(null));
        }
    }
}
