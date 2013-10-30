using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class ForceTests
    {
        private const double Delta = 1E-5;

        [Test]
        public void NewtonToForceUnits()
        { 
            Force newton = Force.FromNewtons(1);
            Assert.AreEqual(1E-3, newton.Kilonewtons);
            Assert.AreEqual(1, newton.Newtons);
            Assert.AreEqual(1E5, newton.Dyne);
            Assert.AreEqual(0.10197, newton.KilogramForce, Delta);
            Assert.AreEqual(0.10197, newton.KiloPonds, Delta);
            Assert.AreEqual(0.22481, newton.PoundForce, Delta);
            Assert.AreEqual(7.2330, newton.Poundal, Delta);
        }

        [Test]
        public void ForceUnitsRoundTrip()
        {
            Force newton = Force.FromNewtons(1);
            Assert.AreEqual(1, Force.FromNewtons(newton.Newtons).Newtons, Delta);
            Assert.AreEqual(1, Force.FromKilonewtons(newton.Kilonewtons).Newtons, Delta);
            Assert.AreEqual(1, Force.FromKilogramForce(newton.KilogramForce).Newtons, Delta);
            Assert.AreEqual(1, Force.FromDyne(newton.Dyne).Newtons, Delta);
            Assert.AreEqual(1, Force.FromKiloPonds(newton.KiloPonds).Newtons, Delta);
            Assert.AreEqual(1, Force.FromPoundForce(newton.PoundForce).Newtons, Delta);
            Assert.AreEqual(1, Force.FromPoundal(newton.Poundal).Newtons, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Force newton = Force.FromNewtons(1);
            Assert.AreEqual(-1, -newton.Newtons, Delta);
            Assert.AreEqual(1, (Force.FromNewtons(2) - newton).Newtons, Delta);
            Assert.AreEqual(2, (newton + newton).Newtons, Delta);
            Assert.AreEqual(1, (Force.FromNewtons(2) - newton).Newtons, Delta);
            Assert.AreEqual(10, (newton*10).Newtons, Delta);
            Assert.AreEqual(10, (10*newton).Newtons, Delta);
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
            Force newton = Force.FromNewtons(1);
            Assert.IsTrue(newton.Equals(Force.FromNewtons(1)));
            Assert.IsFalse(newton.Equals(Force.Zero));
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