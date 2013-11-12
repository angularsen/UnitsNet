using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
	[TestFixture]
	public class FlowTests
	{
		private const double Delta = 1E-5;

		[Test]
		public void CubicMeterPerSecondToFlowUnits()
		{
			Flow cms = Flow.FromCubicMeterPerSecond(1);

			Assert.AreEqual(1/3600.0, cms.CubicMeterPerHour, Delta);
			Assert.AreEqual(1, cms.CubicMeterPerSecond);
		}

		[Test]
		public void FlowUnitsRoundTrip()
		{
			Flow cms = Flow.FromCubicMeterPerSecond(1);

			Assert.AreEqual(1, Flow.FromCubicMeterPerSecond(cms.CubicMeterPerSecond).CubicMeterPerSecond, Delta);
			Assert.AreEqual(1, Flow.FromCubicMeterPerHour(cms.CubicMeterPerHour).CubicMeterPerSecond, Delta);
		}

		[Test]
		public void ArithmeticOperators()
		{
			Flow v = Flow.FromCubicMeterPerSecond(1);
			Assert.AreEqual(-1, -v.CubicMeterPerSecond, Delta);
			Assert.AreEqual(2, (Flow.FromCubicMeterPerSecond(3) - v).CubicMeterPerSecond, Delta);
			Assert.AreEqual(2, (v + v).CubicMeterPerSecond, Delta);
			Assert.AreEqual(10, (v * 10).CubicMeterPerSecond, Delta);
			Assert.AreEqual(10, (10 * v).CubicMeterPerSecond, Delta);
			Assert.AreEqual(2, (Flow.FromCubicMeterPerSecond(10) / 5).CubicMeterPerSecond, Delta);
			Assert.AreEqual(2, Flow.FromCubicMeterPerSecond(10) / Flow.FromCubicMeterPerSecond(5), Delta);
		}

		[Test]
		public void ComparisonOperators()
		{
			Flow oneMeter = Flow.FromCubicMeterPerSecond(1);
			Flow twoMeters = Flow.FromCubicMeterPerSecond(2);

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
			Flow meter = Flow.FromCubicMeterPerSecond(1);
			Assert.AreEqual(0, meter.CompareTo(meter));
			Assert.Greater(meter.CompareTo(Flow.Zero), 0);
			Assert.Less(Flow.Zero.CompareTo(meter), 0);
		}

		[Test]
		[ExpectedException(typeof(ArgumentException))]
		public void CompareToThrowsOnTypeMismatch()
		{
			Flow meter = Flow.FromCubicMeterPerSecond(1);
			// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
			meter.CompareTo(new object());
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void CompareToThrowsOnNull()
		{
			Flow meter = Flow.FromCubicMeterPerSecond(1);
			// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
			meter.CompareTo(null);
		}


		[Test]
		public void EqualityOperators()
		{
			Flow a = Flow.FromCubicMeterPerSecond(1);
			Flow b = Flow.FromCubicMeterPerSecond(2);

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
			Flow v = Flow.FromCubicMeterPerSecond(1);
			Assert.IsTrue(v.Equals(Flow.FromCubicMeterPerSecond(1)));
			Assert.IsFalse(v.Equals(Flow.Zero));
		}

		[Test]
		public void EqualsReturnsFalseOnTypeMismatch()
		{
			Flow meter = Flow.FromCubicMeterPerSecond(1);
			Assert.IsFalse(meter.Equals(new object()));
		}

		[Test]
		public void EqualsReturnsFalseOnNull()
		{
			Flow meter = Flow.FromCubicMeterPerSecond(1);
			Assert.IsFalse(meter.Equals(null));
		}
	}
}
