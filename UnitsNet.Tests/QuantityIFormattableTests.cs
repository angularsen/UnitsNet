using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityIFormattableTests
    {
        private static Length length = Length.FromFeet(3.0);

        [Fact]
        public void GFormatStringEqualsToString()
        {
            Assert.Equal(length.ToString("G"), length.ToString());
        }

        [Fact]
        public void EmptyOrNullFormatStringEqualsGFormat()
        {
            Assert.Equal(length.ToString("G"), length.ToString(string.Empty));
            Assert.Equal(length.ToString("G"), length.ToString((string)null));
            Assert.Equal(length.ToString("G"), length.ToString(" "));
        }

        [Fact]
        public void AFormatGetsAbbreviations()
        {
            Assert.Equal(UnitAbbreviationsCache.Default.GetDefaultAbbreviation(length.Unit), length.ToString("A"));
            Assert.Equal(UnitAbbreviationsCache.Default.GetDefaultAbbreviation(length.Unit), length.ToString("A0"));

            Assert.Equal(UnitAbbreviationsCache.Default.GetUnitAbbreviations(length.Unit)[1], length.ToString("A1"));
            Assert.Equal(UnitAbbreviationsCache.Default.GetUnitAbbreviations(length.Unit)[2], length.ToString("A2"));
        }

        [Fact]
        public void VFormatEqualsValueToString()
        {
            Assert.Equal(length.Value.ToString(), length.ToString("V"));
        }

        [Fact]
        public void QFormatEqualsQuantityName()
        {
            Assert.Equal(Length.Info.Name, length.ToString("Q"));
        }

        [Fact]
        public void SFormatEqualsSignificantDigits()
        {
            Assert.Equal(length.ToString(null, 1), length.ToString("S"));
            Assert.Equal(length.ToString(null, 1), length.ToString("S1"));
            Assert.Equal(length.ToString(null, 2), length.ToString("S2"));
            Assert.Equal(length.ToString(null, 3), length.ToString("S3"));
            Assert.Equal(length.ToString(null, 4), length.ToString("S4"));
            Assert.Equal(length.ToString(null, 5), length.ToString("S5"));
        }

        [Fact]
        public void FormatStringsAreCaseInsensitive()
        {
            Assert.Equal(length.ToString("g"), length.ToString("G"));
            Assert.Equal(length.ToString("a"), length.ToString("A"));
            Assert.Equal(length.ToString("v"), length.ToString("V"));
            Assert.Equal(length.ToString("q"), length.ToString("Q"));
            Assert.Equal(length.ToString("s"), length.ToString("S"));
        }

        [Fact]
        public void UnsupportedFormatStringThrowsException()
        {
            Assert.Throws<FormatException>(() => length.ToString("Z"));
        }
    }
}
