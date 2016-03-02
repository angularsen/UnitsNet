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
    /// Test of AmplitudeRatio.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class AmplitudeRatioTestsBase
    {
        protected abstract double DecibelMicrovoltsInOneDecibelVolt { get; }
        protected abstract double DecibelMillivoltsInOneDecibelVolt { get; }
        protected abstract double DecibelVoltsInOneDecibelVolt { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DecibelMicrovoltsTolerance { get { return 1e-5; } }
        protected virtual double DecibelMillivoltsTolerance { get { return 1e-5; } }
        protected virtual double DecibelVoltsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void DecibelVoltToAmplitudeRatioUnits()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.AreEqual(DecibelMicrovoltsInOneDecibelVolt, decibelvolt.DecibelMicrovolts, DecibelMicrovoltsTolerance);
            Assert.AreEqual(DecibelMillivoltsInOneDecibelVolt, decibelvolt.DecibelMillivolts, DecibelMillivoltsTolerance);
            Assert.AreEqual(DecibelVoltsInOneDecibelVolt, decibelvolt.DecibelVolts, DecibelVoltsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, AmplitudeRatio.From(1, AmplitudeRatioUnit.DecibelMicrovolt).DecibelMicrovolts, DecibelMicrovoltsTolerance);
            Assert.AreEqual(1, AmplitudeRatio.From(1, AmplitudeRatioUnit.DecibelMillivolt).DecibelMillivolts, DecibelMillivoltsTolerance);
            Assert.AreEqual(1, AmplitudeRatio.From(1, AmplitudeRatioUnit.DecibelVolt).DecibelVolts, DecibelVoltsTolerance);
        }

        [Test]
        public void As()
        {
            var decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.AreEqual(DecibelMicrovoltsInOneDecibelVolt, decibelvolt.As(AmplitudeRatioUnit.DecibelMicrovolt), DecibelMicrovoltsTolerance);
            Assert.AreEqual(DecibelMillivoltsInOneDecibelVolt, decibelvolt.As(AmplitudeRatioUnit.DecibelMillivolt), DecibelMillivoltsTolerance);
            Assert.AreEqual(DecibelVoltsInOneDecibelVolt, decibelvolt.As(AmplitudeRatioUnit.DecibelVolt), DecibelVoltsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.AreEqual(1, AmplitudeRatio.FromDecibelMicrovolts(decibelvolt.DecibelMicrovolts).DecibelVolts, DecibelMicrovoltsTolerance);
            Assert.AreEqual(1, AmplitudeRatio.FromDecibelMillivolts(decibelvolt.DecibelMillivolts).DecibelVolts, DecibelMillivoltsTolerance);
            Assert.AreEqual(1, AmplitudeRatio.FromDecibelVolts(decibelvolt.DecibelVolts).DecibelVolts, DecibelVoltsTolerance);
        }

        [Test]
        public void LogarithmicArithmeticOperators()
        {
            AmplitudeRatio v = AmplitudeRatio.FromDecibelVolts(40);
            Assert.AreEqual(-40, -v.DecibelVolts, DecibelVoltsTolerance);
            AssertLogarithmicAddition();
            AssertLogarithmicSubtraction();
            Assert.AreEqual(50, (v*10).DecibelVolts, DecibelVoltsTolerance);
            Assert.AreEqual(50, (10*v).DecibelVolts, DecibelVoltsTolerance);
            Assert.AreEqual(35, (v/5).DecibelVolts, DecibelVoltsTolerance);
            Assert.AreEqual(35, v/AmplitudeRatio.FromDecibelVolts(5), DecibelVoltsTolerance);
        }

        protected abstract void AssertLogarithmicAddition();

        protected abstract void AssertLogarithmicSubtraction();

        [Test]
        public void ComparisonOperators()
        {
            AmplitudeRatio oneDecibelVolt = AmplitudeRatio.FromDecibelVolts(1);
            AmplitudeRatio twoDecibelVolts = AmplitudeRatio.FromDecibelVolts(2);

            Assert.True(oneDecibelVolt < twoDecibelVolts);
            Assert.True(oneDecibelVolt <= twoDecibelVolts);
            Assert.True(twoDecibelVolts > oneDecibelVolt);
            Assert.True(twoDecibelVolts >= oneDecibelVolt);

            Assert.False(oneDecibelVolt > twoDecibelVolts);
            Assert.False(oneDecibelVolt >= twoDecibelVolts);
            Assert.False(twoDecibelVolts < oneDecibelVolt);
            Assert.False(twoDecibelVolts <= oneDecibelVolt);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.AreEqual(0, decibelvolt.CompareTo(decibelvolt));
            Assert.Greater(decibelvolt.CompareTo(AmplitudeRatio.Zero), 0);
            Assert.Less(AmplitudeRatio.Zero.CompareTo(decibelvolt), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            decibelvolt.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            decibelvolt.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            AmplitudeRatio a = AmplitudeRatio.FromDecibelVolts(1);
            AmplitudeRatio b = AmplitudeRatio.FromDecibelVolts(2);

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
            AmplitudeRatio v = AmplitudeRatio.FromDecibelVolts(1);
            Assert.IsTrue(v.Equals(AmplitudeRatio.FromDecibelVolts(1)));
            Assert.IsFalse(v.Equals(AmplitudeRatio.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.IsFalse(decibelvolt.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            AmplitudeRatio decibelvolt = AmplitudeRatio.FromDecibelVolts(1);
            Assert.IsFalse(decibelvolt.Equals(null));
        }
    }
}
