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
			Revolution cms = Revolution.FromRevolutionsPerSecond(1);

			Assert.AreEqual(60.0, cms.RevolutionsPerMinute, Delta);
			Assert.AreEqual(1, cms.RevolutionsPerSecond);
		}

		[Test]
		public void RevolutionUnitsRoundTrip()
		{
			Revolution cms = Revolution.FromRevolutionsPerSecond(1);

			Assert.AreEqual(1, Revolution.FromRevolutionsPerSecond(cms.RevolutionsPerSecond).RevolutionsPerSecond, Delta);
			Assert.AreEqual(1, Revolution.FromRevolutionsPerMinute(cms.RevolutionsPerMinute).RevolutionsPerSecond, Delta);
		}

		[Test]
		public void ArithmeticOperators()
		{
			Revolution v = Revolution.FromRevolutionsPerSecond(1);
			Assert.AreEqual(-1, -v.RevolutionsPerSecond, Delta);
			Assert.AreEqual(2, (Revolution.FromRevolutionsPerSecond(3) - v).RevolutionsPerSecond, Delta);
			Assert.AreEqual(2, (v + v).RevolutionsPerSecond, Delta);
			Assert.AreEqual(10, (v * 10).RevolutionsPerSecond, Delta);
			Assert.AreEqual(10, (10 * v).RevolutionsPerSecond, Delta);
			Assert.AreEqual(2, (Revolution.FromRevolutionsPerSecond(10) / 5).RevolutionsPerSecond, Delta);
			Assert.AreEqual(2, Revolution.FromRevolutionsPerSecond(10) / Revolution.FromRevolutionsPerSecond(5), Delta);
		}

		[Test]
		public void ComparisonOperators()
		{
			Revolution oneMeter = Revolution.FromRevolutionsPerSecond(1);
			Revolution twoMeters = Revolution.FromRevolutionsPerSecond(2);

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
			Revolution meter = Revolution.FromRevolutionsPerSecond(1);
			Assert.AreEqual(0, meter.CompareTo(meter));
			Assert.Greater(meter.CompareTo(Revolution.Zero), 0);
			Assert.Less(Revolution.Zero.CompareTo(meter), 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void CompareToThrowsOnTypeMismatch()
		{
			Revolution meter = Revolution.FromRevolutionsPerSecond(1);
			// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
			meter.CompareTo(new object());
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CompareToThrowsOnNull()
		{
			Revolution meter = Revolution.FromRevolutionsPerSecond(1);
			// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
			meter.CompareTo(null);
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
			Revolution v = Revolution.FromRevolutionsPerSecond(1);
			Assert.IsTrue(v.Equals(Revolution.FromRevolutionsPerSecond(1)));
			Assert.IsFalse(v.Equals(Revolution.Zero));
		}

		[Test]
		public void EqualsReturnsFalseOnTypeMismatch()
		{
			Revolution meter = Revolution.FromRevolutionsPerSecond(1);
			Assert.IsFalse(meter.Equals(new object()));
		}

		[Test]
		public void EqualsReturnsFalseOnNull()
		{
			Revolution meter = Revolution.FromRevolutionsPerSecond(1);
			Assert.IsFalse(meter.Equals(null));
		}
	}
}
