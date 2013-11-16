// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/InitialForce/SIUnits
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

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Force.
    /// </summary>
    public abstract partial class ForceTestsBase
    {
        protected abstract double Delta { get; }

        protected abstract double DyneInOneNewton { get; }
        protected abstract double KilogramsForceInOneNewton { get; }
        protected abstract double KilonewtonsInOneNewton { get; }
        protected abstract double KiloPondsInOneNewton { get; }
        protected abstract double NewtonsInOneNewton { get; }
        protected abstract double PoundalsInOneNewton { get; }
        protected abstract double PoundForcesInOneNewton { get; }

        [Test]
        public void NewtonToForceUnits()
        {
            Force newton = Force.FromNewtons(1);
            Assert.AreEqual(DyneInOneNewton, newton.Dyne, Delta);
            Assert.AreEqual(KilogramsForceInOneNewton, newton.KilogramsForce, Delta);
            Assert.AreEqual(KilonewtonsInOneNewton, newton.Kilonewtons, Delta);
            Assert.AreEqual(KiloPondsInOneNewton, newton.KiloPonds, Delta);
            Assert.AreEqual(NewtonsInOneNewton, newton.Newtons, Delta);
            Assert.AreEqual(PoundalsInOneNewton, newton.Poundals, Delta);
            Assert.AreEqual(PoundForcesInOneNewton, newton.PoundForces, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Force newton = Force.FromNewtons(1); 
            Assert.AreEqual(1, Force.FromDyne(newton.Dyne).Newtons, Delta);
            Assert.AreEqual(1, Force.FromKilogramsForce(newton.KilogramsForce).Newtons, Delta);
            Assert.AreEqual(1, Force.FromKilonewtons(newton.Kilonewtons).Newtons, Delta);
            Assert.AreEqual(1, Force.FromKiloPonds(newton.KiloPonds).Newtons, Delta);
            Assert.AreEqual(1, Force.FromNewtons(newton.Newtons).Newtons, Delta);
            Assert.AreEqual(1, Force.FromPoundals(newton.Poundals).Newtons, Delta);
            Assert.AreEqual(1, Force.FromPoundForces(newton.PoundForces).Newtons, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Force v = Force.FromNewtons(1);
            Assert.AreEqual(-1, -v.Newtons, Delta);
            Assert.AreEqual(2, (Force.FromNewtons(3)-v).Newtons, Delta);
            Assert.AreEqual(2, (v + v).Newtons, Delta);
            Assert.AreEqual(10, (v*10).Newtons, Delta);
            Assert.AreEqual(10, (10*v).Newtons, Delta);
            Assert.AreEqual(2, (Force.FromNewtons(10)/5).Newtons, Delta);
            Assert.AreEqual(2, Force.FromNewtons(10)/Force.FromNewtons(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Force oneNewton = Force.FromNewtons(1);
            Force twoNewtons = Force.FromNewtons(2);

            Assert.True(oneNewton < twoNewtons);
            Assert.True(oneNewton <= twoNewtons);
            Assert.True(twoNewtons > oneNewton);
            Assert.True(twoNewtons >= oneNewton);

            Assert.False(oneNewton > twoNewtons);
            Assert.False(oneNewton >= twoNewtons);
            Assert.False(twoNewtons < oneNewton);
            Assert.False(twoNewtons <= oneNewton);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Force newton = Force.FromNewtons(1);
            Assert.AreEqual(0, newton.CompareTo(newton));
            Assert.Greater(newton.CompareTo(Force.Zero), 0);
            Assert.Less(Force.Zero.CompareTo(newton), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Force newton = Force.FromNewtons(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newton.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Force newton = Force.FromNewtons(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            newton.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Force a = Force.FromNewtons(1);
            Force b = Force.FromNewtons(2);

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
            Force v = Force.FromNewtons(1);
            Assert.IsTrue(v.Equals(Force.FromNewtons(1)));
            Assert.IsFalse(v.Equals(Force.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Force newton = Force.FromNewtons(1);
            Assert.IsFalse(newton.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Force newton = Force.FromNewtons(1);
            Assert.IsFalse(newton.Equals(null));
        }
    }
}
