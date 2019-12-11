// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityIFormattableTests
    {
        private static Length length = Length.FromFeet(1.2345678);

        [Fact]
        public void GFormatStringEqualsToString()
        {
            Assert.Equal(length.ToString("g"), length.ToString());
        }

        [Fact]
        public void EmptyOrNullFormatStringEqualsGFormat()
        {
            Assert.Equal(length.ToString("g"), length.ToString(string.Empty));
            Assert.Equal(length.ToString("g"), length.ToString((string)null));
        }

        [Fact]
        public void AFormatGetsAbbreviations()
        {
            Assert.Equal(UnitAbbreviationsCache.Default.GetDefaultAbbreviation(length.Unit), length.ToString("a"));
            Assert.Equal(UnitAbbreviationsCache.Default.GetDefaultAbbreviation(length.Unit), length.ToString("a0"));

            Assert.Equal(UnitAbbreviationsCache.Default.GetUnitAbbreviations(length.Unit)[1], length.ToString("a1"));
            Assert.Equal(UnitAbbreviationsCache.Default.GetUnitAbbreviations(length.Unit)[2], length.ToString("a2"));
        }

        [Fact]
        public void AFormatWithInvalidIndexThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => length.ToString("a100"));
        }

        [Fact]
        public void VFormatEqualsValueToString()
        {
            Assert.Equal(length.Value.ToString(CultureInfo.CurrentUICulture), length.ToString("v"));
        }

        [Fact]
        public void QFormatEqualsQuantityName()
        {
            Assert.Equal(Length.Info.Name, length.ToString("q"));
        }

        [Theory]
        [InlineData("s", "1 ft")]
        [InlineData("s1", "1.2 ft")]
        [InlineData("s2", "1.23 ft")]
        [InlineData("s3", "1.235 ft")]
        [InlineData("s4", "1.2346 ft")]
        [InlineData("s5", "1.23457 ft")]
        [InlineData("s6", "1.234568 ft")]
        public void SFormatEqualsSignificantDigits(string sFormatString, string expected)
        {
            Assert.Equal(expected, length.ToString(sFormatString, NumberFormatInfo.InvariantInfo));
        }

        [Fact]
        public void UFormatEqualsUnitToString()
        {
            Assert.Equal(length.Unit.ToString(), length.ToString("u"));
        }

        [Fact]
        public void UnsupportedFormatStringThrowsException()
        {
            Assert.Throws<FormatException>(() => length.ToString("z"));
        }
    }
}
