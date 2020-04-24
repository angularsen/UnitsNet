// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;
using System;
using System.Globalization;

namespace UnitsNet.Tests.CustomCode
{
    public class DurationTests : DurationTestsBase
    {
        protected override double DaysInOneSecond => 1.15741e-5;

        protected override double HoursInOneSecond => 0.0002777784;

        protected override double MicrosecondsInOneSecond => 1e+6;

        protected override double MillisecondsInOneSecond => 1000;

        protected override double MinutesInOneSecond => 0.0166667;

        protected override double Months30InOneSecond => 3.858024691358024e-7;

        protected override double NanosecondsInOneSecond => 1e+9;

        protected override double SecondsInOneSecond => 1;

        protected override double WeeksInOneSecond => 1.653439153439153e-6;

        protected override double Years365InOneSecond => 3.170979198376458e-8;

        [Fact]
        public static void ToTimeSpanShouldThrowExceptionOnValuesLargerThanTimeSpanMax()
        {
            Duration duration = Duration.FromSeconds(TimeSpan.MaxValue.TotalSeconds + 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => duration.ToTimeSpan());
        }

        [Fact]
        public static void ToTimeSpanShouldThrowExceptionOnValuesSmallerThanTimeSpanMin()
        {
            Duration duration = Duration.FromSeconds(TimeSpan.MinValue.TotalSeconds - 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => duration.ToTimeSpan());
        }

        [Fact]
        public static void ToTimeSpanShouldNotThrowExceptionOnValuesSlightlyLargerThanTimeSpanMin()
        {
            Duration duration = Duration.FromSeconds(TimeSpan.MinValue.TotalSeconds + 1);
            TimeSpan timeSpan = duration.ToTimeSpan();
            AssertEx.EqualTolerance(duration.Seconds, timeSpan.TotalSeconds, 1e-3);
        }

        [Fact]
        public static void ToTimeSpanShouldNotThrowExceptionOnValuesSlightlySmallerThanTimeSpanMax()
        {
            Duration duration = Duration.FromSeconds(TimeSpan.MaxValue.TotalSeconds - 1);
            TimeSpan timeSpan = duration.ToTimeSpan();
            AssertEx.EqualTolerance(duration.Seconds, timeSpan.TotalSeconds, 1e-3);
        }

        [Fact]
        public static void ExplicitCastToTimeSpanShouldReturnSameValue()
        {
            Duration duration = Duration.FromSeconds(60);
            TimeSpan timeSpan = (TimeSpan)duration;
            AssertEx.EqualTolerance(duration.Seconds, timeSpan.TotalSeconds, 1e-10);
        }

        [Fact]
        public static void ExplicitCastToDurationShouldReturnSameValue()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(60);
            Duration duration = (Duration)timeSpan;
            AssertEx.EqualTolerance(timeSpan.TotalSeconds, duration.Seconds, 1e-10);
        }

        [Fact]
        public static void DateTimePlusDurationReturnsDateTime()
        {
            DateTime dateTime = new DateTime(2016, 1, 1);
            Duration oneDay = Duration.FromDays(1);
            DateTime result = dateTime + oneDay;
            DateTime expected = new DateTime(2016, 1, 2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void DateTimeMinusDurationReturnsDateTime()
        {
            DateTime dateTime = new DateTime(2016, 1, 2);
            Duration oneDay = Duration.FromDays(1);
            DateTime result = dateTime - oneDay;
            DateTime expected = new DateTime(2016, 1, 1);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void TimeSpanLessThanDurationShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(10);
            Duration duration = Duration.FromHours(11);
            Assert.True(timeSpan < duration, "timeSpan should be less than duration");
        }

        [Fact]
        public static void TimeSpanGreaterThanDurationShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(12);
            Duration duration = Duration.FromHours(11);
            Assert.True(timeSpan > duration, "timeSpan should be greater than duration");
        }

        [Fact]
        public static void DurationLessThanTimeSpanShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            Duration duration = Duration.FromHours(10);
            Assert.True(duration < timeSpan, "duration should be less than timeSpan");
        }

        [Fact]
        public static void DurationGreaterThanTimeSpanShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            Duration duration = Duration.FromHours(12);
            Assert.True(duration > timeSpan, "duration should be greater than timeSpan");
        }

        [Fact]
        public static void TimeSpanLessOrEqualThanDurationShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(10);
            Duration duration = Duration.FromHours(11);
            Assert.True(timeSpan <= duration, "timeSpan should be less than duration");
        }

        [Fact]
        public static void TimeSpanGreaterThanOrEqualDurationShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(12);
            Duration duration = Duration.FromHours(11);
            Assert.True(timeSpan >= duration, "timeSpan should be greater than duration");
        }

        [Fact]
        public static void DurationLessThanOrEqualTimeSpanShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            Duration duration = Duration.FromHours(10);
            Assert.True(duration <= timeSpan, "duration should be less than timeSpan");
        }

        [Fact]
        public static void DurationGreaterThanOrEqualTimeSpanShouldReturnCorrectly()
        {
            TimeSpan timeSpan = TimeSpan.FromHours(11);
            Duration duration = Duration.FromHours(12);
            Assert.True(duration >= timeSpan, "duration should be greater than timeSpan");
        }

        [Fact]
        public void DurationTimesVolumeFlowEqualsVolume()
        {
            Volume volume = Duration.FromSeconds(20) * VolumeFlow.FromCubicMetersPerSecond(2);
            Assert.Equal(Volume.FromCubicMeters(40), volume);
        }

        [Theory]
        [InlineData("1s", 1)]
        [InlineData("2 seconds", 2)]
        [InlineData("1 ms", 1e-3)]
        [InlineData("1000 msec", 1)]
        [InlineData("1 с", 1, "ru-RU")]
        [InlineData("1 сек", 1, "ru-RU")]
        [InlineData("1000 мс", 1, "ru-RU")]
        [InlineData("1000 мсек", 1, "ru-RU")]
        public void DurationFromStringUsingMultipleAbbreviationsParsedCorrectly(string textValue, double expectedSeconds, string culture = null)
        {
            var cultureInfo = culture == null ? null : new CultureInfo(culture);

            AssertEx.EqualTolerance(expectedSeconds, Duration.Parse(textValue, cultureInfo).Seconds, SecondsTolerance);
        }
    }
}
