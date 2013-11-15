// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class FlowTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void CubicMetersPerSecondToFlowUnits()
        {
            Flow cms = Flow.FromCubicMetersPerSecond(1);

            Assert.AreEqual(1/3600.0, cms.CubicMetersPerHour, Delta);
            Assert.AreEqual(1, cms.CubicMetersPerSecond);
        }

        [Test]
        public void FlowUnitsRoundTrip()
        {
            Flow cms = Flow.FromCubicMetersPerSecond(1);

            Assert.AreEqual(1, Flow.FromCubicMetersPerSecond(cms.CubicMetersPerSecond).CubicMetersPerSecond, Delta);
            Assert.AreEqual(1, Flow.FromCubicMetersPerHour(cms.CubicMetersPerHour).CubicMetersPerSecond, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Flow v = Flow.FromCubicMetersPerSecond(1);
            Assert.AreEqual(-1, -v.CubicMetersPerSecond, Delta);
            Assert.AreEqual(2, (Flow.FromCubicMetersPerSecond(3) - v).CubicMetersPerSecond, Delta);
            Assert.AreEqual(2, (v + v).CubicMetersPerSecond, Delta);
            Assert.AreEqual(10, (v * 10).CubicMetersPerSecond, Delta);
            Assert.AreEqual(10, (10 * v).CubicMetersPerSecond, Delta);
            Assert.AreEqual(2, (Flow.FromCubicMetersPerSecond(10) / 5).CubicMetersPerSecond, Delta);
            Assert.AreEqual(2, Flow.FromCubicMetersPerSecond(10) / Flow.FromCubicMetersPerSecond(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Flow oneMeter = Flow.FromCubicMetersPerSecond(1);
            Flow twoMeters = Flow.FromCubicMetersPerSecond(2);

            Assert.True(oneMeter < twoMeters);
            Assert.True(oneMeter <= twoMeters);
            Assert.True(twoMeters > oneMeter);
            Assert.True(twoMeters >= oneMeter);

            Assert.False(oneMeter > twoMeters);
            Assert.False(oneMeter >= twoMeters);
            Assert.False(twoMeters < oneMeter);
            Assert.False(twoMeters <= oneMeter);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Flow oneCmps = Flow.FromCubicMetersPerSecond(1);
            Assert.AreEqual(0, oneCmps.CompareTo(oneCmps));
            Assert.Greater(oneCmps.CompareTo(Flow.Zero), 0);
            Assert.Less(Flow.Zero.CompareTo(oneCmps), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Flow oneCmps = Flow.FromCubicMetersPerSecond(1);
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            oneCmps.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Flow oneCmps = Flow.FromCubicMetersPerSecond(1);
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            oneCmps.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Flow a = Flow.FromCubicMetersPerSecond(1);
            Flow b = Flow.FromCubicMetersPerSecond(2);

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
            Flow v = Flow.FromCubicMetersPerSecond(1);
            Assert.IsTrue(v.Equals(Flow.FromCubicMetersPerSecond(1)));
            Assert.IsFalse(v.Equals(Flow.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Flow oneCmps = Flow.FromCubicMetersPerSecond(1);
            Assert.IsFalse(oneCmps.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Flow oneCmps = Flow.FromCubicMetersPerSecond(1);
            Assert.IsFalse(oneCmps.Equals(null));
        }
    }
}
