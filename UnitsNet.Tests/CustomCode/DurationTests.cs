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
            var duration = Duration<double>.FromSeconds(TimeSpan.MaxValue.TotalSeconds + 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => duration.ToTimeSpan());
        }

        [Fact]
        public static void ToTimeSpanShouldThrowExceptionOnValuesSmallerThanTimeSpanMin()
        {
            var duration = Duration<double>.FromSeconds(TimeSpan.MinValue.TotalSeconds - 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => duration.ToTimeSpan());
        }

        [Fact]
        public static void ToTimeSpanShouldNotThrowExceptionOnValuesSlightlyLargerThanTimeSpanMin()
        {
            var duration = Duration<double>.FromSeconds(TimeSpan.MinValue.TotalSeconds + 1);
            var timeSpan = duration.ToTimeSpan();
            AssertEx.EqualTolerance(duration.Seconds, timeSpan.TotalSeconds, 1e-3);
        }

        [Fact]
        public static void ToTimeSpanShouldNotThrowExceptionOnValuesSlightlySmallerThanTimeSpanMax()
        {
            var duration = Duration<double>.FromSeconds(TimeSpan.MaxValue.TotalSeconds - 1);
            var timeSpan = duration.ToTimeSpan();
            AssertEx.EqualTolerance(duration.Seconds, timeSpan.TotalSeconds, 1e-3);
        }

        [Fact]
        public static void ExplicitCastToTimeSpanShouldReturnSameValue()
        {
            var duration = Duration<double>.FromSeconds(60);
            var timeSpan = (TimeSpan)duration;
            AssertEx.EqualTolerance(duration.Seconds, timeSpan.TotalSeconds, 1e-10);
        }

        [Fact]
        public static void ExplicitCastToDurationShouldReturnSameValue()
        {
            var timeSpan = TimeSpan.FromSeconds(60);
            var duration = (Duration<double>)timeSpan;
            AssertEx.EqualTolerance(timeSpan.TotalSeconds, duration.Seconds, 1e-10);
        }

        [Fact]
        public static void DateTimePlusDurationReturnsDateTime()
        {
            var dateTime = new DateTime(2016, 1, 1);
            var oneDay = Duration<double>.FromDays(1);
            var result = dateTime + oneDay;
            var expected = new DateTime(2016, 1, 2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void DateTimeMinusDurationReturnsDateTime()
        {
            var dateTime = new DateTime(2016, 1, 2);
            var oneDay = Duration<double>.FromDays(1);
            var result = dateTime - oneDay;
            var expected = new DateTime(2016, 1, 1);
            Assert.Equal(expected, result);
        }

        [Fact]
        public static void TimeSpanLessThanDurationShouldReturnCorrectly()
        {
            var timeSpan = TimeSpan.FromHours(10);
            var duration = Duration<double>.FromHours(11);
            Assert.True(timeSpan < duration, "timeSpan should be less than duration");
        }

        [Fact]
        public static void TimeSpanGreaterThanDurationShouldReturnCorrectly()
        {
            var timeSpan = TimeSpan.FromHours(12);
            var duration = Duration<double>.FromHours(11);
            Assert.True(timeSpan > duration, "timeSpan should be greater than duration");
        }

        [Fact]
        public static void DurationLessThanTimeSpanShouldReturnCorrectly()
        {
            var timeSpan = TimeSpan.FromHours(11);
            var duration = Duration<double>.FromHours(10);
            Assert.True(duration < timeSpan, "duration should be less than timeSpan");
        }

        [Fact]
        public static void DurationGreaterThanTimeSpanShouldReturnCorrectly()
        {
            var timeSpan = TimeSpan.FromHours(11);
            var duration = Duration<double>.FromHours(12);
            Assert.True(duration > timeSpan, "duration should be greater than timeSpan");
        }

        [Fact]
        public static void TimeSpanLessOrEqualThanDurationShouldReturnCorrectly()
        {
            var timeSpan = TimeSpan.FromHours(10);
            var duration = Duration<double>.FromHours(11);
            Assert.True(timeSpan <= duration, "timeSpan should be less than duration");
        }

        [Fact]
        public static void TimeSpanGreaterThanOrEqualDurationShouldReturnCorrectly()
        {
            var timeSpan = TimeSpan.FromHours(12);
            var duration = Duration<double>.FromHours(11);
            Assert.True(timeSpan >= duration, "timeSpan should be greater than duration");
        }

        [Fact]
        public static void DurationLessThanOrEqualTimeSpanShouldReturnCorrectly()
        {
            var timeSpan = TimeSpan.FromHours(11);
            var duration = Duration<double>.FromHours(10);
            Assert.True(duration <= timeSpan, "duration should be less than timeSpan");
        }

        [Fact]
        public static void DurationGreaterThanOrEqualTimeSpanShouldReturnCorrectly()
        {
            var timeSpan = TimeSpan.FromHours(11);
            var duration = Duration<double>.FromHours(12);
            Assert.True(duration >= timeSpan, "duration should be greater than timeSpan");
        }

        [Fact]
        public void DurationTimesVolumeFlowEqualsVolume()
        {
            var volume = Duration<double>.FromSeconds(20) * VolumeFlow<double>.FromCubicMetersPerSecond(2);
            Assert.Equal(Volume<double>.FromCubicMeters(40), volume);
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

            AssertEx.EqualTolerance(expectedSeconds, Duration<double>.Parse(textValue, cultureInfo).Seconds, SecondsTolerance);
        }
    }
}
