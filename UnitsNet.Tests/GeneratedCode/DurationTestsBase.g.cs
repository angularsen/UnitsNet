// Copyright © 2007 by Initial Force AS.  All rights reserved.
// https://github.com/anjdreas/UnitsNet
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
    /// Test of Duration.
    /// </summary>
    [TestFixture]
// ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class DurationTestsBase
    {
        protected abstract double DaysInOneSecond { get; }
        protected abstract double HoursInOneSecond { get; }
        protected abstract double MicrosecondsInOneSecond { get; }
        protected abstract double MillisecondsInOneSecond { get; }
        protected abstract double MinutesInOneSecond { get; }
        protected abstract double MonthsInOneSecond { get; }
        protected abstract double NanosecondsInOneSecond { get; }
        protected abstract double SecondsInOneSecond { get; }
        protected abstract double WeeksInOneSecond { get; }
        protected abstract double YearsInOneSecond { get; }

// ReSharper disable VirtualMemberNeverOverriden.Global
        protected virtual double DaysTolerance { get { return 1e-5; } }
        protected virtual double HoursTolerance { get { return 1e-5; } }
        protected virtual double MicrosecondsTolerance { get { return 1e-5; } }
        protected virtual double MillisecondsTolerance { get { return 1e-5; } }
        protected virtual double MinutesTolerance { get { return 1e-5; } }
        protected virtual double MonthsTolerance { get { return 1e-5; } }
        protected virtual double NanosecondsTolerance { get { return 1e-5; } }
        protected virtual double SecondsTolerance { get { return 1e-5; } }
        protected virtual double WeeksTolerance { get { return 1e-5; } }
        protected virtual double YearsTolerance { get { return 1e-5; } }
// ReSharper restore VirtualMemberNeverOverriden.Global

        [Test]
        public void SecondToDurationUnits()
        {
            Duration second = Duration.FromSeconds(1);
            Assert.AreEqual(DaysInOneSecond, second.Days, DaysTolerance);
            Assert.AreEqual(HoursInOneSecond, second.Hours, HoursTolerance);
            Assert.AreEqual(MicrosecondsInOneSecond, second.Microseconds, MicrosecondsTolerance);
            Assert.AreEqual(MillisecondsInOneSecond, second.Milliseconds, MillisecondsTolerance);
            Assert.AreEqual(MinutesInOneSecond, second.Minutes, MinutesTolerance);
            Assert.AreEqual(MonthsInOneSecond, second.Months, MonthsTolerance);
            Assert.AreEqual(NanosecondsInOneSecond, second.Nanoseconds, NanosecondsTolerance);
            Assert.AreEqual(SecondsInOneSecond, second.Seconds, SecondsTolerance);
            Assert.AreEqual(WeeksInOneSecond, second.Weeks, WeeksTolerance);
            Assert.AreEqual(YearsInOneSecond, second.Years, YearsTolerance);
        }

        [Test]
        public void FromValueAndUnit()
        {
            Assert.AreEqual(1, Duration.From(1, DurationUnit.Day).Days, DaysTolerance);
            Assert.AreEqual(1, Duration.From(1, DurationUnit.Hour).Hours, HoursTolerance);
            Assert.AreEqual(1, Duration.From(1, DurationUnit.Microsecond).Microseconds, MicrosecondsTolerance);
            Assert.AreEqual(1, Duration.From(1, DurationUnit.Millisecond).Milliseconds, MillisecondsTolerance);
            Assert.AreEqual(1, Duration.From(1, DurationUnit.Minute).Minutes, MinutesTolerance);
            Assert.AreEqual(1, Duration.From(1, DurationUnit.Month).Months, MonthsTolerance);
            Assert.AreEqual(1, Duration.From(1, DurationUnit.Nanosecond).Nanoseconds, NanosecondsTolerance);
            Assert.AreEqual(1, Duration.From(1, DurationUnit.Second).Seconds, SecondsTolerance);
            Assert.AreEqual(1, Duration.From(1, DurationUnit.Week).Weeks, WeeksTolerance);
            Assert.AreEqual(1, Duration.From(1, DurationUnit.Year).Years, YearsTolerance);
        }

        [Test]
        public void As()
        {
            var second = Duration.FromSeconds(1);
            Assert.AreEqual(DaysInOneSecond, second.As(DurationUnit.Day), DaysTolerance);
            Assert.AreEqual(HoursInOneSecond, second.As(DurationUnit.Hour), HoursTolerance);
            Assert.AreEqual(MicrosecondsInOneSecond, second.As(DurationUnit.Microsecond), MicrosecondsTolerance);
            Assert.AreEqual(MillisecondsInOneSecond, second.As(DurationUnit.Millisecond), MillisecondsTolerance);
            Assert.AreEqual(MinutesInOneSecond, second.As(DurationUnit.Minute), MinutesTolerance);
            Assert.AreEqual(MonthsInOneSecond, second.As(DurationUnit.Month), MonthsTolerance);
            Assert.AreEqual(NanosecondsInOneSecond, second.As(DurationUnit.Nanosecond), NanosecondsTolerance);
            Assert.AreEqual(SecondsInOneSecond, second.As(DurationUnit.Second), SecondsTolerance);
            Assert.AreEqual(WeeksInOneSecond, second.As(DurationUnit.Week), WeeksTolerance);
            Assert.AreEqual(YearsInOneSecond, second.As(DurationUnit.Year), YearsTolerance);
        }

        [Test]
        public void ConversionRoundTrip()
        {
            Duration second = Duration.FromSeconds(1);
            Assert.AreEqual(1, Duration.FromDays(second.Days).Seconds, DaysTolerance);
            Assert.AreEqual(1, Duration.FromHours(second.Hours).Seconds, HoursTolerance);
            Assert.AreEqual(1, Duration.FromMicroseconds(second.Microseconds).Seconds, MicrosecondsTolerance);
            Assert.AreEqual(1, Duration.FromMilliseconds(second.Milliseconds).Seconds, MillisecondsTolerance);
            Assert.AreEqual(1, Duration.FromMinutes(second.Minutes).Seconds, MinutesTolerance);
            Assert.AreEqual(1, Duration.FromMonths(second.Months).Seconds, MonthsTolerance);
            Assert.AreEqual(1, Duration.FromNanoseconds(second.Nanoseconds).Seconds, NanosecondsTolerance);
            Assert.AreEqual(1, Duration.FromSeconds(second.Seconds).Seconds, SecondsTolerance);
            Assert.AreEqual(1, Duration.FromWeeks(second.Weeks).Seconds, WeeksTolerance);
            Assert.AreEqual(1, Duration.FromYears(second.Years).Seconds, YearsTolerance);
        }

        [Test]
        public void ArithmeticOperators()
        {
            Duration v = Duration.FromSeconds(1);
            Assert.AreEqual(-1, -v.Seconds, SecondsTolerance);
            Assert.AreEqual(2, (Duration.FromSeconds(3)-v).Seconds, SecondsTolerance);
            Assert.AreEqual(2, (v + v).Seconds, SecondsTolerance);
            Assert.AreEqual(10, (v*10).Seconds, SecondsTolerance);
            Assert.AreEqual(10, (10*v).Seconds, SecondsTolerance);
            Assert.AreEqual(2, (Duration.FromSeconds(10)/5).Seconds, SecondsTolerance);
            Assert.AreEqual(2, Duration.FromSeconds(10)/Duration.FromSeconds(5), SecondsTolerance);
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
