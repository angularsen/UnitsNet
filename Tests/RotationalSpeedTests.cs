using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
	public class RotationalSpeedTests
    {
        private const double Delta = 1E-5;

        [Test]
		public void CubicMeterPerSecondToRotationalSpeedUnits()
        {
            RotationalSpeed rps = RotationalSpeed.FromRevolutionsPerSecond(1);

            Assert.AreEqual(60.0, rps.RevolutionsPerMinute, Delta);
            Assert.AreEqual(1, rps.RevolutionsPerSecond);
        }

        [Test]
		public void RotationalSpeedUnitsRoundTrip()
        {
            RotationalSpeed rps = RotationalSpeed.FromRevolutionsPerSecond(1);

            Assert.AreEqual(1, RotationalSpeed.FromRevolutionsPerSecond(rps.RevolutionsPerSecond).RevolutionsPerSecond, Delta);
            Assert.AreEqual(1, RotationalSpeed.FromRevolutionsPerMinute(rps.RevolutionsPerMinute).RevolutionsPerSecond, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            RotationalSpeed rps = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.AreEqual(-1, -rps.RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, (RotationalSpeed.FromRevolutionsPerSecond(3) - rps).RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, (rps + rps).RevolutionsPerSecond, Delta);
            Assert.AreEqual(10, (rps * 10).RevolutionsPerSecond, Delta);
            Assert.AreEqual(10, (10 * rps).RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, (RotationalSpeed.FromRevolutionsPerSecond(10) / 5).RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, RotationalSpeed.FromRevolutionsPerSecond(10) / RotationalSpeed.FromRevolutionsPerSecond(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            RotationalSpeed oneRps = RotationalSpeed.FromRevolutionsPerSecond(1);
            RotationalSpeed twoRps = RotationalSpeed.FromRevolutionsPerSecond(2);

            Assert.True(oneRps < twoRps);
            Assert.True(oneRps <= twoRps);
            Assert.True(twoRps > oneRps);
            Assert.True(twoRps >= oneRps);

            Assert.False(oneRps > twoRps);
            Assert.False(oneRps >= twoRps);
            Assert.False(twoRps < oneRps);
            Assert.False(twoRps <= oneRps);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            RotationalSpeed rps = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.AreEqual(0, rps.CompareTo(rps));
            Assert.Greater(rps.CompareTo(RotationalSpeed.Zero), 0);
            Assert.Less(RotationalSpeed.Zero.CompareTo(rps), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            RotationalSpeed rps = RotationalSpeed.FromRevolutionsPerSecond(1);
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            rps.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            RotationalSpeed rps = RotationalSpeed.FromRevolutionsPerSecond(1);
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            rps.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            RotationalSpeed a = RotationalSpeed.FromRevolutionsPerSecond(1);
            RotationalSpeed b = RotationalSpeed.FromRevolutionsPerSecond(2);

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
            RotationalSpeed rps = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.IsTrue(rps.Equals(RotationalSpeed.FromRevolutionsPerSecond(1)));
            Assert.IsFalse(rps.Equals(RotationalSpeed.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            RotationalSpeed rps = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.IsFalse(rps.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            RotationalSpeed rps = RotationalSpeed.FromRevolutionsPerSecond(1);
            Assert.IsFalse(rps.Equals(null));
        }
    }
}
