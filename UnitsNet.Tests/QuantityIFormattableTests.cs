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
        public void VFormatEqualsValueToString()
        {
            Assert.Equal(length.Value.ToString(), length.ToString("v"));
        }

        [Fact]
        public void QFormatEqualsQuantityName()
        {
            Assert.Equal(Length.Info.Name, length.ToString("q"));
        }

        [Fact]
        public void SFormatEqualsSignificantDigits()
        {
            Assert.Equal(length.ToString(null, 1), length.ToString("s"));
            Assert.Equal(length.ToString(null, 1), length.ToString("s1"));
            Assert.Equal(length.ToString(null, 2), length.ToString("s2"));
            Assert.Equal(length.ToString(null, 3), length.ToString("s3"));
            Assert.Equal(length.ToString(null, 4), length.ToString("s4"));
            Assert.Equal(length.ToString(null, 5), length.ToString("s5"));
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
