// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/UnitsNet
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
    /// Test of Torque.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class TorqueTestsBase
    {
        protected abstract double NewtonmetersInOneNewtonmeter { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double NewtonmetersTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void NewtonmeterToTorqueUnits()
        {
            Torque newtonmeter = Torque.FromNewtonmeters(1);
            Assert.AreEqual(NewtonmetersInOneNewtonmeter, newtonmeter.Newtonmeters, NewtonmetersTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Torque.From(1, TorqueUnit.Newtonmeter).Newtonmeters, NewtonmetersTolerance);
        }

        [Test]
        public void As()
        {
            var newtonmeter = Torque.FromNewtonmeters(1);
            Assert.AreEqual(NewtonmetersInOneNewtonmeter, newtonmeter.As(TorqueUnit.Newtonmeter), NewtonmetersTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Torque newtonmeter = Torque.FromNewtonmeters(1);
            Assert.AreEqual(1, Torque.FromNewtonmeters(newtonmeter.Newtonmeters).Newtonmeters, NewtonmetersTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Torque v = Torque.FromNewtonmeters(1);
            Assert.AreEqual(-1, -v.Newtonmeters, NewtonmetersTolerance);
            Assert.AreEqual(2, (Torque.FromNewtonmeters(3)-v).Newtonmeters, NewtonmetersTolerance);
            Assert.AreEqual(2, (v + v).Newtonmeters, NewtonmetersTolerance);
            Assert.AreEqual(10, (v*10).Newtonmeters, NewtonmetersTolerance);
            Assert.AreEqual(10, (10*v).Newtonmeters, NewtonmetersTolerance);
            Assert.AreEqual(2, (Torque.FromNewtonmeters(10)/5).Newtonmeters, NewtonmetersTolerance);
            Assert.AreEqual(2, Torque.FromNewtonmeters(10)/Torque.FromNewtonmeters(5), NewtonmetersTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            Torque oneNewtonmeter = Torque.FromNewtonmeters(1);
            Torque twoNewtonmeters = Torque.FromNewtonmeters(2);

            Assert.True(oneNewtonmeter < twoNewtonmeters);
            Assert.True(oneNewtonmeter <= twoNewtonmeters);
            Assert.True(twoNewtonmeters > oneNewtonmeter);
            Assert.True(twoNewtonmeters >= oneNewtonmeter);

            Assert.False(oneNewtonmeter > twoNewtonmeters);
            Assert.False(oneNewtonmeter >= twoNewtonmeters);
            Assert.False(twoNewtonmeters < oneNewtonmeter);
            Assert.False(twoNewtonmeters <= oneNewtonmeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Torque newtonmeter = Torque.FromNewtonmeters(1);
            Assert.AreEqual(0, newtonmeter.CompareTo(newtonmeter));
            Assert.Greater(newtonmeter.CompareTo(Torque.Zero), 0);
            Assert.Less(Torque.Zero.CompareTo(newtonmeter), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Torque newtonmeter = Torque.FromNewtonmeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newtonmeter.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Torque newtonmeter = Torque.FromNewtonmeters(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newtonmeter.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Torque a = Torque.FromNewtonmeters(1);
            Torque b = Torque.FromNewtonmeters(2);

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
            Torque v = Torque.FromNewtonmeters(1);
            Assert.IsTrue(v.Equals(Torque.FromNewtonmeters(1)));
            Assert.IsFalse(v.Equals(Torque.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Torque newtonmeter = Torque.FromNewtonmeters(1);
            Assert.IsFalse(newtonmeter.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Torque newtonmeter = Torque.FromNewtonmeters(1);
            Assert.IsFalse(newtonmeter.Equals(null));
        }
    }
}
