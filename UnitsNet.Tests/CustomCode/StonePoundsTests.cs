// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using Xunit;

namespace UnitsNet.Tests
{
    public class StonePoundsTests
    {
        private const double StoneInOneKilogram = 0.1574731728702698;
        private const double PoundsInOneKilogram = 2.2046226218487757d;
        private const double StoneTolerance = 1e-4;
        private const double PoundsTolerance = 1e-4;

        [Fact]
        public void StonePoundsFrom()
        {
            Mass m = Mass.FromStonePounds(2, 3);
            double expectedKg = 2/StoneInOneKilogram + 3/PoundsInOneKilogram;
            AssertEx.EqualTolerance(expectedKg, m.Kilograms, StoneTolerance);
        }

        [Fact]
        public void StonePoundsRoundTrip()
        {
            Mass m = Mass.FromStonePounds(2, 3);
            StonePounds stonePounds = m.StonePounds;
            AssertEx.EqualTolerance(2, stonePounds.Stone, StoneTolerance);
            AssertEx.EqualTolerance(3, stonePounds.Pounds, PoundsTolerance);
        }

        [Fact]
        public void StonePoundsToString_FormatsNumberInCurrentCulture()
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            StonePounds stonePounds = Mass.FromStonePounds(3500, 1).StonePounds;

            Assert.Equal("3,500 st 1 lb", stonePounds.ToString());
        }

        // These cultures use a thin space in digit grouping
        [Theory]
        [InlineData("nn-NO")]
        [InlineData("fr-FR")]
        public void StonePoundsToString_GivenCultureWithThinSpaceDigitGroup_ReturnsNumberWithThinSpaceDigitGroup(string cultureName)
        {
            var formatProvider = CultureInfo.GetCultureInfo(cultureName);
            Mass m = Mass.FromStonePounds(3500, 1);
            StonePounds stonePounds = m.StonePounds;

            string gs = formatProvider.NumberFormat.NumberGroupSeparator;
            Assert.Equal($"3{gs}500 st 1 lb", stonePounds.ToString(formatProvider));
        }
    }
}
