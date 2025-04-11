// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using System.Globalization;
using Xunit;

namespace UnitsNet.Tests
{
    public class QuantityIFormattableTests
    {
        private static readonly Length MyLength = Length.FromFeet(1.2345678);

        [Fact]
        public void GFormatStringEqualsToString()
        {
            Assert.Equal(MyLength.ToString("G"), MyLength.ToString());
        }

        [Fact]
        public void EmptyOrNullFormatStringEqualsGFormat()
        {
            Assert.Equal(MyLength.ToString("G"), MyLength.ToString(string.Empty));
            Assert.Equal(MyLength.ToString("G"), MyLength.ToString(format: null));
        }

        [Fact]
        public void AFormatGetsAbbreviations()
        {
            UnitAbbreviationsCache cache = UnitsNetSetup.Default.UnitAbbreviations;
            Assert.Equal(cache.GetDefaultAbbreviation(MyLength.Unit, CultureInfo.InvariantCulture), MyLength.ToString("a", CultureInfo.InvariantCulture));
            Assert.Equal(cache.GetDefaultAbbreviation(MyLength.Unit, CultureInfo.InvariantCulture), MyLength.ToString("a0", CultureInfo.InvariantCulture));

            Assert.Equal(cache.GetUnitAbbreviations(MyLength.Unit, CultureInfo.InvariantCulture)[1], MyLength.ToString("a1", CultureInfo.InvariantCulture));
            Assert.Equal(cache.GetUnitAbbreviations(MyLength.Unit, CultureInfo.InvariantCulture)[2], MyLength.ToString("a2", CultureInfo.InvariantCulture));
        }

        [Fact]
        public void AFormatWithInvalidIndexThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => MyLength.ToString("a100"));
        }

        [Fact]
        public void UnsupportedFormatStringThrowsException()
        {
            Assert.Throws<FormatException>(() => MyLength.ToString("z"));
        }
    }
}
