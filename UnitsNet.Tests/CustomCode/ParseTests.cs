// Copyright (c) 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com).
// https://github.com/angularsen/UnitsNet
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
using System.Globalization;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    /// <remarks>
    ///     These test methods would ideally be generated for each unit class,
    ///     but that was not trivial to do. At the time of writing this,
    ///     all unit classes are generated using the same scripts, so it is
    ///     reasonable to assume that testing one unit class would cover
    ///     all of them. Obviously, that can change in the future.
    /// </remarks>
    [Collection(nameof(UnitAbbreviationsCacheFixture))]
    public class ParseTests
    {
        [Theory]
        [InlineData("1km", 1000)]
        [InlineData(" 1km ", 1000)] // Check that it also trims string
        [InlineData("1 km", 1000)]
        [InlineData("1e-3 km", 1)]
        [InlineData("5.5 m", 5.5)]
        [InlineData("500,005 m", 500005)]
        public void ParseLengthToMetersUsEnglish(string s, double expected)
        {
            CultureInfo usEnglish = new CultureInfo("en-US");
            double actual = Length.Parse(s, usEnglish).Meters;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))] // Can't parse null.
        [InlineData("1", typeof(FormatException))] // No unit abbreviation.
        [InlineData("km", typeof(FormatException))] // No value, wrong measurement type.
        [InlineData("1 kg", typeof(FormatException))] // Wrong measurement type.
        [InlineData("1ft monkey 1in", typeof(FormatException))] // Invalid separator between two valid measurements.
        [InlineData("1ft 1invalid", typeof(FormatException))] // Valid
        public void ParseLength_InvalidString_USEnglish_ThrowsException(string s, Type expectedExceptionType)
        {
            var usEnglish = new CultureInfo("en-US");
            Assert.Throws(expectedExceptionType, () => Length.Parse(s, usEnglish));
        }

        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        [Theory]
        [InlineData("5.5 m", 5.5)]
        [InlineData("500 005 m", 500005)]
        // quantity doesn't match number format
        public void ParseWithCultureUsingSpaceAsThousandSeparators(string s, double expected)
        {
            var numberFormat = (NumberFormatInfo) CultureInfo.InvariantCulture.NumberFormat.Clone();
            numberFormat.NumberGroupSeparator = " ";
            numberFormat.CurrencyGroupSeparator = " ";
            numberFormat.NumberDecimalSeparator = ".";
            numberFormat.CurrencyDecimalSeparator = ".";

            double actual = Length.Parse(s, numberFormat).Meters;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("500.005.050,001 m", typeof(FormatException))]
        // quantity doesn't match number format
        public void ParseWithCultureUsingSpaceAsThousandSeparators_ThrowsExceptionOnInvalidString(string s, Type expectedExceptionType)
        {
            var numberFormat = (NumberFormatInfo) CultureInfo.InvariantCulture.NumberFormat.Clone();
            numberFormat.NumberGroupSeparator = " ";
            numberFormat.CurrencyGroupSeparator = " ";
            numberFormat.NumberDecimalSeparator = ".";
            numberFormat.CurrencyDecimalSeparator = ".";

            Assert.Throws(expectedExceptionType, () => Length.Parse(s, numberFormat));
        }

        /// <exception cref="UnitsNetException">Error parsing string.</exception>
        [Theory]
        [InlineData("5,5 m", 5.5)]
        [InlineData("500.005.050,001 m", 500005050.001)]
        [InlineData("5.555 m", 5555)] // Dot is group separator not decimal
        public void ParseWithCultureUsingDotAsThousandSeparators(string s, double expected)
        {
            var numberFormat = (NumberFormatInfo) CultureInfo.InvariantCulture.NumberFormat.Clone();
            numberFormat.NumberGroupSeparator = ".";
            numberFormat.CurrencyGroupSeparator = ".";
            numberFormat.NumberDecimalSeparator = ",";
            numberFormat.CurrencyDecimalSeparator = ",";

            double actual = Length.Parse(s, numberFormat).Meters;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ParseMultiWordAbbreviations()
        {
            Assert.Equal(Mass.FromShortTons(333), Mass.Parse("333 short tn"));
            Assert.Equal(Mass.FromLongTons(333), Mass.Parse("333 long tn"));
        }

        [Theory]
        [InlineData("500 005 m", typeof(FormatException))] // Quantity doesn't match number format.
        public void ParseWithCultureUsingDotAsThousandSeparators_ThrowsExceptionOnInvalidString(string s, Type expectedExceptionType)
        {
            var numberFormat = (NumberFormatInfo) CultureInfo.InvariantCulture.NumberFormat.Clone();
            numberFormat.NumberGroupSeparator = ".";
            numberFormat.CurrencyGroupSeparator = ".";
            numberFormat.NumberDecimalSeparator = ",";
            numberFormat.CurrencyDecimalSeparator = ",";

            Assert.Throws(expectedExceptionType, () => Length.Parse(s, numberFormat));
        }

        [Theory]
        [InlineData("m", LengthUnit.Meter)]
        public void ParseLengthUnitUsEnglish(string s, LengthUnit expected)
        {
            CultureInfo usEnglish = new CultureInfo("en-US");
            LengthUnit actual = Length.ParseUnit(s, usEnglish);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("kg", typeof(UnitNotFoundException))]
        [InlineData(null, typeof(ArgumentNullException))]
        public void ParseLengthUnitUsEnglish_ThrowsExceptionOnInvalidString(string s, Type expectedExceptionType)
        {
            var usEnglish = new CultureInfo("en-US");
            Assert.Throws(expectedExceptionType, () => Length.ParseUnit(s, usEnglish));
        }

        [Theory]
        [InlineData("1 m", true)]
        [InlineData("1 m 50 cm", false)]
        [InlineData("2 kg", false)]
        [InlineData(null, false)]
        [InlineData("foo", false)]
        public void TryParseLengthUnitUsEnglish(string s, bool expected)
        {
            CultureInfo usEnglish = new CultureInfo("en-US");
            bool actual = Length.TryParse(s, usEnglish, out Length _);
            Assert.Equal(expected, actual);
        }
    }
}
