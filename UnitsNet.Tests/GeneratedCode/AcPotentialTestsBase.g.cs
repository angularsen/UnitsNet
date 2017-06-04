// Copyright © 2007 Andreas Gullberg Larsen (anjdreas@gmail.com).
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
    /// Test of AcPotential.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class AcPotentialTestsBase
    {
        protected abstract double VoltsPeakInOneVoltPeak { get; }
        protected abstract double VoltsPeakToPeakInOneVoltPeak { get; }
        protected abstract double VoltsRMSInOneVoltPeak { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double VoltsPeakTolerance { get { return 1e-5; } }
        protected virtual double VoltsPeakToPeakTolerance { get { return 1e-5; } }
        protected virtual double VoltsRMSTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void VoltPeakToAcPotentialUnits()
        {
            AcPotential voltpeak = AcPotential.FromVoltsPeak(1);
            Assert.AreEqual(VoltsPeakInOneVoltPeak, voltpeak.VoltsPeak, VoltsPeakTolerance);
            Assert.AreEqual(VoltsPeakToPeakInOneVoltPeak, voltpeak.VoltsPeakToPeak, VoltsPeakToPeakTolerance);
            Assert.AreEqual(VoltsRMSInOneVoltPeak, voltpeak.VoltsRMS, VoltsRMSTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, AcPotential.From(1, AcPotentialUnit.VoltPeak).VoltsPeak, VoltsPeakTolerance);
            Assert.AreEqual(1, AcPotential.From(1, AcPotentialUnit.VoltPeakToPeak).VoltsPeakToPeak, VoltsPeakToPeakTolerance);
            Assert.AreEqual(1, AcPotential.From(1, AcPotentialUnit.VoltRMS).VoltsRMS, VoltsRMSTolerance);
        }

        [Test]
        public void As()
        {
            var voltpeak = AcPotential.FromVoltsPeak(1);
            Assert.AreEqual(VoltsPeakInOneVoltPeak, voltpeak.As(AcPotentialUnit.VoltPeak), VoltsPeakTolerance);
            Assert.AreEqual(VoltsPeakToPeakInOneVoltPeak, voltpeak.As(AcPotentialUnit.VoltPeakToPeak), VoltsPeakToPeakTolerance);
            Assert.AreEqual(VoltsRMSInOneVoltPeak, voltpeak.As(AcPotentialUnit.VoltRMS), VoltsRMSTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            AcPotential voltpeak = AcPotential.FromVoltsPeak(1);
            Assert.AreEqual(1, AcPotential.FromVoltsPeak(voltpeak.VoltsPeak).VoltsPeak, VoltsPeakTolerance);
            Assert.AreEqual(1, AcPotential.FromVoltsPeakToPeak(voltpeak.VoltsPeakToPeak).VoltsPeak, VoltsPeakToPeakTolerance);
            Assert.AreEqual(1, AcPotential.FromVoltsRMS(voltpeak.VoltsRMS).VoltsPeak, VoltsRMSTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            AcPotential v = AcPotential.FromVoltsPeak(1);
            Assert.AreEqual(-1, -v.VoltsPeak, VoltsPeakTolerance);
            Assert.AreEqual(2, (AcPotential.FromVoltsPeak(3)-v).VoltsPeak, VoltsPeakTolerance);
            Assert.AreEqual(2, (v + v).VoltsPeak, VoltsPeakTolerance);
            Assert.AreEqual(10, (v*10).VoltsPeak, VoltsPeakTolerance);
            Assert.AreEqual(10, (10*v).VoltsPeak, VoltsPeakTolerance);
            Assert.AreEqual(2, (AcPotential.FromVoltsPeak(10)/5).VoltsPeak, VoltsPeakTolerance);
            Assert.AreEqual(2, AcPotential.FromVoltsPeak(10)/AcPotential.FromVoltsPeak(5), VoltsPeakTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            AcPotential oneVoltPeak = AcPotential.FromVoltsPeak(1);
            AcPotential twoVoltsPeak = AcPotential.FromVoltsPeak(2);

            Assert.True(oneVoltPeak < twoVoltsPeak);
            Assert.True(oneVoltPeak <= twoVoltsPeak);
            Assert.True(twoVoltsPeak > oneVoltPeak);
            Assert.True(twoVoltsPeak >= oneVoltPeak);

            Assert.False(oneVoltPeak > twoVoltsPeak);
            Assert.False(oneVoltPeak >= twoVoltsPeak);
            Assert.False(twoVoltsPeak < oneVoltPeak);
            Assert.False(twoVoltsPeak <= oneVoltPeak);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            AcPotential voltpeak = AcPotential.FromVoltsPeak(1);
            Assert.AreEqual(0, voltpeak.CompareTo(voltpeak));
            Assert.Greater(voltpeak.CompareTo(AcPotential.Zero), 0);
            Assert.Less(AcPotential.Zero.CompareTo(voltpeak), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            AcPotential voltpeak = AcPotential.FromVoltsPeak(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            voltpeak.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            AcPotential voltpeak = AcPotential.FromVoltsPeak(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            voltpeak.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            AcPotential a = AcPotential.FromVoltsPeak(1);
            AcPotential b = AcPotential.FromVoltsPeak(2);

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
            AcPotential v = AcPotential.FromVoltsPeak(1);
            Assert.IsTrue(v.Equals(AcPotential.FromVoltsPeak(1)));
            Assert.IsFalse(v.Equals(AcPotential.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            AcPotential voltpeak = AcPotential.FromVoltsPeak(1);
            Assert.IsFalse(voltpeak.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            AcPotential voltpeak = AcPotential.FromVoltsPeak(1);
            Assert.IsFalse(voltpeak.Equals(null));
        }
    }
}
