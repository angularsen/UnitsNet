// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class StonePoundsTests
    {
        private const double StoneInOneKilogram = 0.1574731728702698;
        private const double PoundsInOneKilogram = 2.2046226218487757d;
        private const double StoneTolerance = 1e-4;
        private const double PoundsTolerance = 1e-4;

        // These cultures use a thin space in digit grouping
        [Theory]
        [InlineData("nn-NO")]
        [InlineData("fr-FR")]
        public void StonePoundsToString_GivenCultureWithThinSpaceDigitGroup_ReturnsNumberWithThinSpaceDigitGroup(string cultureName)
        {
            var formatProvider = new CultureInfo(cultureName);
            var m = Mass.FromStonePounds(3500, 1);
            var stonePounds = m.StonePounds;

            Assert.Equal("3 500 st 1 lb", stonePounds.ToString(formatProvider));
        }

        [Fact]
        public void StonePoundsFrom()
        {
            var m = Mass.FromStonePounds(2, 3);
            var expectedKg = 2 / StoneInOneKilogram + 3 / PoundsInOneKilogram;
            AssertEx.EqualTolerance(expectedKg, m.Kilograms, StoneTolerance);
        }

        [Fact]
        public void StonePoundsRoundTrip()
        {
            var m = Mass.FromStonePounds(2, 3);
            var stonePounds = m.StonePounds;
            AssertEx.EqualTolerance(2, stonePounds.Stone, StoneTolerance);
            AssertEx.EqualTolerance(3, stonePounds.Pounds, PoundsTolerance);
        }

        [Fact]
        public void StonePoundsToString_FormatsNumberInDefaultCulture()
        {
            var m = Mass.FromStonePounds(3500, 1);
            var stonePounds = m.StonePounds;
            var numberInCurrentCulture = 3500.ToString("n0", CultureInfo.CurrentUICulture); // Varies between machines, can't hard code it

            Assert.Equal($"{numberInCurrentCulture} st 1 lb", stonePounds.ToString());
        }
    }
}
