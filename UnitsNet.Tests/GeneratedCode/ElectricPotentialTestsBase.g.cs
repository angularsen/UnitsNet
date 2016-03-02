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
    /// Test of ElectricPotential.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class ElectricPotentialTestsBase
    {
        protected abstract double KilovoltsInOneVolt { get; }
        protected abstract double MegavoltsInOneVolt { get; }
        protected abstract double MicrovoltsInOneVolt { get; }
        protected abstract double MillivoltsInOneVolt { get; }
        protected abstract double VoltsInOneVolt { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KilovoltsTolerance { get { return 1e-5; } }
        protected virtual double MegavoltsTolerance { get { return 1e-5; } }
        protected virtual double MicrovoltsTolerance { get { return 1e-5; } }
        protected virtual double MillivoltsTolerance { get { return 1e-5; } }
        protected virtual double VoltsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void VoltToElectricPotentialUnits()
        {
            ElectricPotential volt = ElectricPotential.FromVolts(1);
            Assert.AreEqual(KilovoltsInOneVolt, volt.Kilovolts, KilovoltsTolerance);
            Assert.AreEqual(MegavoltsInOneVolt, volt.Megavolts, MegavoltsTolerance);
            Assert.AreEqual(MicrovoltsInOneVolt, volt.Microvolts, MicrovoltsTolerance);
            Assert.AreEqual(MillivoltsInOneVolt, volt.Millivolts, MillivoltsTolerance);
            Assert.AreEqual(VoltsInOneVolt, volt.Volts, VoltsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, ElectricPotential.From(1, ElectricPotentialUnit.Kilovolt).Kilovolts, KilovoltsTolerance);
            Assert.AreEqual(1, ElectricPotential.From(1, ElectricPotentialUnit.Megavolt).Megavolts, MegavoltsTolerance);
            Assert.AreEqual(1, ElectricPotential.From(1, ElectricPotentialUnit.Microvolt).Microvolts, MicrovoltsTolerance);
            Assert.AreEqual(1, ElectricPotential.From(1, ElectricPotentialUnit.Millivolt).Millivolts, MillivoltsTolerance);
            Assert.AreEqual(1, ElectricPotential.From(1, ElectricPotentialUnit.Volt).Volts, VoltsTolerance);
        }

        [Test]
        public void As()
        {
            var volt = ElectricPotential.FromVolts(1);
            Assert.AreEqual(KilovoltsInOneVolt, volt.As(ElectricPotentialUnit.Kilovolt), KilovoltsTolerance);
            Assert.AreEqual(MegavoltsInOneVolt, volt.As(ElectricPotentialUnit.Megavolt), MegavoltsTolerance);
            Assert.AreEqual(MicrovoltsInOneVolt, volt.As(ElectricPotentialUnit.Microvolt), MicrovoltsTolerance);
            Assert.AreEqual(MillivoltsInOneVolt, volt.As(ElectricPotentialUnit.Millivolt), MillivoltsTolerance);
            Assert.AreEqual(VoltsInOneVolt, volt.As(ElectricPotentialUnit.Volt), VoltsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            ElectricPotential volt = ElectricPotential.FromVolts(1);
            Assert.AreEqual(1, ElectricPotential.FromKilovolts(volt.Kilovolts).Volts, KilovoltsTolerance);
            Assert.AreEqual(1, ElectricPotential.FromMegavolts(volt.Megavolts).Volts, MegavoltsTolerance);
            Assert.AreEqual(1, ElectricPotential.FromMicrovolts(volt.Microvolts).Volts, MicrovoltsTolerance);
            Assert.AreEqual(1, ElectricPotential.FromMillivolts(volt.Millivolts).Volts, MillivoltsTolerance);
            Assert.AreEqual(1, ElectricPotential.FromVolts(volt.Volts).Volts, VoltsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            ElectricPotential v = ElectricPotential.FromVolts(1);
            Assert.AreEqual(-1, -v.Volts, VoltsTolerance);
            Assert.AreEqual(2, (ElectricPotential.FromVolts(3)-v).Volts, VoltsTolerance);
            Assert.AreEqual(2, (v + v).Volts, VoltsTolerance);
            Assert.AreEqual(10, (v*10).Volts, VoltsTolerance);
            Assert.AreEqual(10, (10*v).Volts, VoltsTolerance);
            Assert.AreEqual(2, (ElectricPotential.FromVolts(10)/5).Volts, VoltsTolerance);
            Assert.AreEqual(2, ElectricPotential.FromVolts(10)/ElectricPotential.FromVolts(5), VoltsTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            ElectricPotential oneVolt = ElectricPotential.FromVolts(1);
            ElectricPotential twoVolts = ElectricPotential.FromVolts(2);

            Assert.True(oneVolt < twoVolts);
            Assert.True(oneVolt <= twoVolts);
            Assert.True(twoVolts > oneVolt);
            Assert.True(twoVolts >= oneVolt);

            Assert.False(oneVolt > twoVolts);
            Assert.False(oneVolt >= twoVolts);
            Assert.False(twoVolts < oneVolt);
            Assert.False(twoVolts <= oneVolt);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            ElectricPotential volt = ElectricPotential.FromVolts(1);
            Assert.AreEqual(0, volt.CompareTo(volt));
            Assert.Greater(volt.CompareTo(ElectricPotential.Zero), 0);
            Assert.Less(ElectricPotential.Zero.CompareTo(volt), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            ElectricPotential volt = ElectricPotential.FromVolts(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            volt.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            ElectricPotential volt = ElectricPotential.FromVolts(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            volt.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            ElectricPotential a = ElectricPotential.FromVolts(1);
            ElectricPotential b = ElectricPotential.FromVolts(2);

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
            ElectricPotential v = ElectricPotential.FromVolts(1);
            Assert.IsTrue(v.Equals(ElectricPotential.FromVolts(1)));
            Assert.IsFalse(v.Equals(ElectricPotential.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            ElectricPotential volt = ElectricPotential.FromVolts(1);
            Assert.IsFalse(volt.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            ElectricPotential volt = ElectricPotential.FromVolts(1);
            Assert.IsFalse(volt.Equals(null));
        }
    }
}
