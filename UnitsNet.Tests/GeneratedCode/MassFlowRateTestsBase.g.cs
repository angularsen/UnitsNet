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
    /// Test of MassFlowRate.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class MassFlowRateTestsBase
    {
        protected abstract double KillogramsPerSecondInOneKillogramPerSecond { get; }
        protected abstract double NewtonsPerSecondInOneKillogramPerSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double KillogramsPerSecondTolerance { get { return 1e-5; } }
        protected virtual double NewtonsPerSecondTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void KillogramPerSecondToMassFlowRateUnits()
        {
            MassFlowRate killogrampersecond = MassFlowRate.FromKillogramsPerSecond(1);
            Assert.AreEqual(KillogramsPerSecondInOneKillogramPerSecond, killogrampersecond.KillogramsPerSecond, KillogramsPerSecondTolerance);
            Assert.AreEqual(NewtonsPerSecondInOneKillogramPerSecond, killogrampersecond.NewtonsPerSecond, NewtonsPerSecondTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, MassFlowRate.From(1, MassFlowRateUnit.KillogramPerSecond).KillogramsPerSecond, KillogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlowRate.From(1, MassFlowRateUnit.NewtonPerSecond).NewtonsPerSecond, NewtonsPerSecondTolerance);
        }

        [Test]
        public void As()
        {
            var killogrampersecond = MassFlowRate.FromKillogramsPerSecond(1);
            Assert.AreEqual(KillogramsPerSecondInOneKillogramPerSecond, killogrampersecond.As(MassFlowRateUnit.KillogramPerSecond), KillogramsPerSecondTolerance);
            Assert.AreEqual(NewtonsPerSecondInOneKillogramPerSecond, killogrampersecond.As(MassFlowRateUnit.NewtonPerSecond), NewtonsPerSecondTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            MassFlowRate killogrampersecond = MassFlowRate.FromKillogramsPerSecond(1);
            Assert.AreEqual(1, MassFlowRate.FromKillogramsPerSecond(killogrampersecond.KillogramsPerSecond).KillogramsPerSecond, KillogramsPerSecondTolerance);
            Assert.AreEqual(1, MassFlowRate.FromNewtonsPerSecond(killogrampersecond.NewtonsPerSecond).KillogramsPerSecond, NewtonsPerSecondTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            MassFlowRate v = MassFlowRate.FromKillogramsPerSecond(1);
            Assert.AreEqual(-1, -v.KillogramsPerSecond, KillogramsPerSecondTolerance);
            Assert.AreEqual(2, (MassFlowRate.FromKillogramsPerSecond(3)-v).KillogramsPerSecond, KillogramsPerSecondTolerance);
            Assert.AreEqual(2, (v + v).KillogramsPerSecond, KillogramsPerSecondTolerance);
            Assert.AreEqual(10, (v*10).KillogramsPerSecond, KillogramsPerSecondTolerance);
            Assert.AreEqual(10, (10*v).KillogramsPerSecond, KillogramsPerSecondTolerance);
            Assert.AreEqual(2, (MassFlowRate.FromKillogramsPerSecond(10)/5).KillogramsPerSecond, KillogramsPerSecondTolerance);
            Assert.AreEqual(2, MassFlowRate.FromKillogramsPerSecond(10)/MassFlowRate.FromKillogramsPerSecond(5), KillogramsPerSecondTolerance);
        }

        [Test]
        public void ComparisonOperators()
        {
            MassFlowRate oneKillogramPerSecond = MassFlowRate.FromKillogramsPerSecond(1);
            MassFlowRate twoKillogramsPerSecond = MassFlowRate.FromKillogramsPerSecond(2);

            Assert.True(oneKillogramPerSecond < twoKillogramsPerSecond);
            Assert.True(oneKillogramPerSecond <= twoKillogramsPerSecond);
            Assert.True(twoKillogramsPerSecond > oneKillogramPerSecond);
            Assert.True(twoKillogramsPerSecond >= oneKillogramPerSecond);

            Assert.False(oneKillogramPerSecond > twoKillogramsPerSecond);
            Assert.False(oneKillogramPerSecond >= twoKillogramsPerSecond);
            Assert.False(twoKillogramsPerSecond < oneKillogramPerSecond);
            Assert.False(twoKillogramsPerSecond <= oneKillogramPerSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            MassFlowRate killogrampersecond = MassFlowRate.FromKillogramsPerSecond(1);
            Assert.AreEqual(0, killogrampersecond.CompareTo(killogrampersecond));
            Assert.Greater(killogrampersecond.CompareTo(MassFlowRate.Zero), 0);
            Assert.Less(MassFlowRate.Zero.CompareTo(killogrampersecond), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            MassFlowRate killogrampersecond = MassFlowRate.FromKillogramsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            killogrampersecond.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            MassFlowRate killogrampersecond = MassFlowRate.FromKillogramsPerSecond(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            killogrampersecond.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            MassFlowRate a = MassFlowRate.FromKillogramsPerSecond(1);
            MassFlowRate b = MassFlowRate.FromKillogramsPerSecond(2);

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
            MassFlowRate v = MassFlowRate.FromKillogramsPerSecond(1);
            Assert.IsTrue(v.Equals(MassFlowRate.FromKillogramsPerSecond(1)));
            Assert.IsFalse(v.Equals(MassFlowRate.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            MassFlowRate killogrampersecond = MassFlowRate.FromKillogramsPerSecond(1);
            Assert.IsFalse(killogrampersecond.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            MassFlowRate killogrampersecond = MassFlowRate.FromKillogramsPerSecond(1);
            Assert.IsFalse(killogrampersecond.Equals(null));
        }
    }
}
