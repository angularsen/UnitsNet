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

// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

// ReSharper disable once CheckNamespace
namespace UnitsNet.Tests
{
    /// <summary>
    /// Test of Duration.
    /// </summary>
    [TestFixture]
    public abstract partial class DurationTestsBase
    {
        protected virtual double Delta { get { return 1E-5; } }

        public abstract double DaysInOneSecond { get; }
        public abstract double HoursInOneSecond { get; }
        public abstract double MicrosecondsInOneSecond { get; }
        public abstract double MillisecondsInOneSecond { get; }
        public abstract double MinutesInOneSecond { get; }
        public abstract double Month30DayssInOneSecond { get; }
        public abstract double NanosecondsInOneSecond { get; }
        public abstract double SecondsInOneSecond { get; }
        public abstract double WeeksInOneSecond { get; }
        public abstract double Year365DayssInOneSecond { get; }

        [Test]
        public void SecondToDurationUnits()
        {
            Duration second = Duration.FromSeconds(1);
            Assert.AreEqual(DaysInOneSecond, second.Days, Delta);
            Assert.AreEqual(HoursInOneSecond, second.Hours, Delta);
            Assert.AreEqual(MicrosecondsInOneSecond, second.Microseconds, Delta);
            Assert.AreEqual(MillisecondsInOneSecond, second.Milliseconds, Delta);
            Assert.AreEqual(MinutesInOneSecond, second.Minutes, Delta);
            Assert.AreEqual(Month30DayssInOneSecond, second.Month30Dayss, Delta);
            Assert.AreEqual(NanosecondsInOneSecond, second.Nanoseconds, Delta);
            Assert.AreEqual(SecondsInOneSecond, second.Seconds, Delta);
            Assert.AreEqual(WeeksInOneSecond, second.Weeks, Delta);
            Assert.AreEqual(Year365DayssInOneSecond, second.Year365Dayss, Delta);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Duration second = Duration.FromSeconds(1); 
            Assert.AreEqual(1, Duration.FromDays(second.Days).Seconds, Delta);
            Assert.AreEqual(1, Duration.FromHours(second.Hours).Seconds, Delta);
            Assert.AreEqual(1, Duration.FromMicroseconds(second.Microseconds).Seconds, Delta);
            Assert.AreEqual(1, Duration.FromMilliseconds(second.Milliseconds).Seconds, Delta);
            Assert.AreEqual(1, Duration.FromMinutes(second.Minutes).Seconds, Delta);
            Assert.AreEqual(1, Duration.FromMonth30Dayss(second.Month30Dayss).Seconds, Delta);
            Assert.AreEqual(1, Duration.FromNanoseconds(second.Nanoseconds).Seconds, Delta);
            Assert.AreEqual(1, Duration.FromSeconds(second.Seconds).Seconds, Delta);
            Assert.AreEqual(1, Duration.FromWeeks(second.Weeks).Seconds, Delta);
            Assert.AreEqual(1, Duration.FromYear365Dayss(second.Year365Dayss).Seconds, Delta);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Duration v = Duration.FromSeconds(1);
            Assert.AreEqual(-1, -v.Seconds, Delta);
            Assert.AreEqual(2, (Duration.FromSeconds(3)-v).Seconds, Delta);
            Assert.AreEqual(2, (v + v).Seconds, Delta);
            Assert.AreEqual(10, (v*10).Seconds, Delta);
            Assert.AreEqual(10, (10*v).Seconds, Delta);
            Assert.AreEqual(2, (Duration.FromSeconds(10)/5).Seconds, Delta);
            Assert.AreEqual(2, Duration.FromSeconds(10)/Duration.FromSeconds(5), Delta);
        }

        [Test]
        public void ComparisonOperators()
        {
            Duration oneSecond = Duration.FromSeconds(1);
            Duration twoSeconds = Duration.FromSeconds(2);

            Assert.True(oneSecond < twoSeconds);
            Assert.True(oneSecond <= twoSeconds);
            Assert.True(twoSeconds > oneSecond);
            Assert.True(twoSeconds >= oneSecond);

            Assert.False(oneSecond > twoSeconds);
            Assert.False(oneSecond >= twoSeconds);
            Assert.False(twoSeconds < oneSecond);
            Assert.False(twoSeconds <= oneSecond);
        }

        [Test]
        public void CompareToIsImplemented()
        {
            Duration second = Duration.FromSeconds(1);
            Assert.AreEqual(0, second.CompareTo(second));
            Assert.Greater(second.CompareTo(Duration.Zero), 0);
            Assert.Less(Duration.Zero.CompareTo(second), 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void CompareToThrowsOnTypeMismatch()
        {
            Duration second = Duration.FromSeconds(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            second.CompareTo(new object());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CompareToThrowsOnNull()
        { 
            Duration second = Duration.FromSeconds(1);
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
            second.CompareTo(null);
        }


        [Test]
        public void EqualityOperators()
        {
            Duration a = Duration.FromSeconds(1);
            Duration b = Duration.FromSeconds(2);

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
            Duration v = Duration.FromSeconds(1);
            Assert.IsTrue(v.Equals(Duration.FromSeconds(1)));
            Assert.IsFalse(v.Equals(Duration.Zero));
        }

        [Test]
        public void EqualsReturnsFalseOnTypeMismatch()
        {
            Duration second = Duration.FromSeconds(1);
            Assert.IsFalse(second.Equals(new object()));
        }

        [Test]
        public void EqualsReturnsFalseOnNull()
        {
            Duration second = Duration.FromSeconds(1);
            Assert.IsFalse(second.Equals(null));
        }
    }
}
