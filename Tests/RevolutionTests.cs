using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class RevolutionTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void CubicMeterPerSecondToRevolutionUnits()
        {
            Revolution rps = Revolution.FromRevolutionsPerSecond(1);

            Assert.AreEqual(60.0, rps.RevolutionsPerMinute, Delta);
            Assert.AreEqual(1, rps.RevolutionsPerSecond);
        }

        [Test]
        public void RevolutionUnitsRoundTrip()
        {
            Revolution rps = Revolution.FromRevolutionsPerSecond(1);

            Assert.AreEqual(1, Revolution.FromRevolutionsPerSecond(rps.RevolutionsPerSecond).RevolutionsPerSecond, Delta);
            Assert.AreEqual(1, Revolution.FromRevolutionsPerMinute(rps.RevolutionsPerMinute).RevolutionsPerSecond, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Revolution rps = Revolution.FromRevolutionsPerSecond(1);
            Assert.AreEqual(-1, -rps.RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, (Revolution.FromRevolutionsPerSecond(3) - rps).RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, (rps + rps).RevolutionsPerSecond, Delta);
            Assert.AreEqual(10, (rps * 10).RevolutionsPerSecond, Delta);
            Assert.AreEqual(10, (10 * rps).RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, (Revolution.FromRevolutionsPerSecond(10) / 5).RevolutionsPerSecond, Delta);
            Assert.AreEqual(2, Revolution.FromRevolutionsPerSecond(10) / Revolution.FromRevolutionsPerSecond(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Revolution oneRps = Revolution.FromRevolutionsPerSecond(1);
            Revolution twoRps = Revolution.FromRevolutionsPerSecond(2);

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
            Revolution rps = Revolution.FromRevolutionsPerSecond(1);
            Assert.AreEqual(0, rps.CompareTo(rps));
            Assert.Greater(rps.CompareTo(Revolution.Zero), 0);
            Assert.Less(Revolution.Zero.CompareTo(rps), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Revolution rps = Revolution.FromRevolutionsPerSecond(1);
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            rps.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        {
            Revolution rps = Revolution.FromRevolutionsPerSecond(1);
            // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            rps.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Revolution a = Revolution.FromRevolutionsPerSecond(1);
            Revolution b = Revolution.FromRevolutionsPerSecond(2);

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
            Revolution rps = Revolution.FromRevolutionsPerSecond(1);
            Assert.IsTrue(rps.Equals(Revolution.FromRevolutionsPerSecond(1)));
            Assert.IsFalse(rps.Equals(Revolution.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Revolution rps = Revolution.FromRevolutionsPerSecond(1);
            Assert.IsFalse(rps.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Revolution rps = Revolution.FromRevolutionsPerSecond(1);
            Assert.IsFalse(rps.Equals(null));
        }
    }
}
