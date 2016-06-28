// Copyright(c) 2007 Andreas Gullberg Larsen
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

using NUnit.Framework;
using System;

namespace UnitsNet.Tests.CustomCode
{
    public class DurationTests : DurationTestsBase
    {
        protected override double DaysInOneSecond => 1.15741e-5;

        protected override double HoursInOneSecond => 0.0002777784;

        protected override double MicrosecondsInOneSecond => 1e+6;

        protected override double MillisecondsInOneSecond => 1000;

        protected override double MinutesInOneSecond => 0.0166667;

        protected override double MonthsInOneSecond => 3.8027e-7;

        protected override double NanosecondsInOneSecond => 1e+9;

        protected override double SecondsInOneSecond => 1;

        protected override double WeeksInOneSecond => 1.6534e-6;

        protected override double YearsInOneSecond => 3.1689e-8;

        [Test]
        public static void ToTimeSpanShouldThrowExceptionOnValuesLargerThanTimeSpanMax()
        {
            Duration duration = Duration.FromSeconds(TimeSpan.MaxValue.TotalSeconds + 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => duration.ToTimeSpan());
        }

        [Test]
        public static void ToTimeSpanShouldThrowExceptionOnValuesSmallerThanTimeSpanMin()
        {
            Duration duration = Duration.FromSeconds(TimeSpan.MinValue.TotalSeconds - 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => duration.ToTimeSpan());
        }

        [Test]
        public static void ToTimeSpanShouldNotThrowExceptionOnValuesSlightlyLargerThanTimeSpanMin()
        {
            Duration duration = Duration.FromSeconds(TimeSpan.MinValue.TotalSeconds + 1);
            TimeSpan timeSpan = duration.ToTimeSpan();
            Assert.AreEqual(duration.Seconds, timeSpan.TotalSeconds, 1e-3);
        }

        [Test]
        public static void ToTimeSpanShouldNotThrowExceptionOnValuesSlightlySmallerThanTimeSpanMax()
        {
            Duration duration = Duration.FromSeconds(TimeSpan.MaxValue.TotalSeconds - 1);
            TimeSpan timeSpan = duration.ToTimeSpan();
            Assert.AreEqual(duration.Seconds, timeSpan.TotalSeconds, 1e-3);
        }

        [Test]
        public static void ExplicitCastToTimeSpanShouldReturnSameValue()
        {
            Duration duration = Duration.FromSeconds(60);
            TimeSpan timeSpan = (TimeSpan)duration;
            Assert.AreEqual(duration.Seconds, timeSpan.TotalSeconds, 1e-10);
        }

        [Test]
        public static void ExplicitCastToDurationShouldReturnSameValue()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(60);
            Duration duration = (Duration)timeSpan;
            Assert.AreEqual(timeSpan.TotalSeconds, duration.Seconds, 1e-10);
        }

        [Test]
        public static void DateTimePlusDurationReturnsDateTime()
        {
            DateTime dateTime = new DateTime(2016, 1, 1);
            Duration oneDay = Duration.FromDays(1);
            DateTime result = dateTime + oneDay;
            DateTime expected = new DateTime(2016, 1, 2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public static void DateTimeMinusDurationReturnsDateTime()
        {
            DateTime dateTime = new DateTime(2016, 1, 2);
            Duration oneDay = Duration.FromDays(1);
            DateTime result = dateTime - oneDay;
            DateTime expected = new DateTime(2016, 1, 1);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public static void TimeSpanLessThanDurationShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(10);
            Duration duration = Duration.FromHours(11);
            Assert.IsTrue(timeSpan < duration, "timeSpan should be less than duration");
        }

        [Test]
        public static void TimeSpanGreaterThanDurationShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(12);
            Duration duration = Duration.FromHours(11);
            Assert.IsTrue(timeSpan > duration, "timeSpan should be greater than duration");
        }

        [Test]
        public static void DurationLessThanTimeSpanShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            Duration duration = Duration.FromHours(10);
            Assert.IsTrue(duration < timeSpan, "duration should be less than timeSpan");
        }

        [Test]
        public static void DurationGreaterThanTimeSpanShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            Duration duration = Duration.FromHours(12);
            Assert.IsTrue(duration > timeSpan, "duration should be greater than timeSpan");
        }

        [Test]
        public static void TimeSpanLessOrEqualThanDurationShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(10);
            Duration duration = Duration.FromHours(11);
            Assert.IsTrue(timeSpan <= duration, "timeSpan should be less than duration");
        }

        [Test]
        public static void TimeSpanGreaterThanOrEqualDurationShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(12);
            Duration duration = Duration.FromHours(11);
            Assert.IsTrue(timeSpan >= duration, "timeSpan should be greater than duration");
        }

        [Test]
        public static void DurationLessThanOrEqualTimeSpanShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            Duration duration = Duration.FromHours(10);
            Assert.IsTrue(duration <= timeSpan, "duration should be less than timeSpan");
        }

        [Test]
        public static void DurationGreaterThanOrEqualTimeSpanShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            Duration duration = Duration.FromHours(12);
            Assert.IsTrue(duration >= timeSpan, "duration should be greater than timeSpan");
        }

        [Test]
        public static void DurationEqualToTimeSpanShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            Duration duration = Duration.FromHours(11);
            Assert.IsTrue(duration == timeSpan, "duration should be equal to timeSpan");
        }

        [Test]
        public static void TimeSpanEqualToDurationShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            Duration duration = Duration.FromHours(11);
            Assert.IsTrue(timeSpan == duration, "timeSpan should be equal to duration");
        }

        [Test]
        public static void DurationNotEqualToTimeSpanShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(12);
            Duration duration = Duration.FromHours(11);
            Assert.IsTrue(duration != timeSpan, "duration should not be equal to timeSpan");
        }

        [Test]
        public static void TimeSpanNotEqualToDurationShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(12);
            Duration duration = Duration.FromHours(11);
            Assert.IsTrue(timeSpan != duration, "timeSpan should not be equal to duration");
        }
    }
}