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
using Xunit;
using UnitsNet.Units;

namespace UnitsNet.Tests.CustomCode
{
    /// <remarks>
    ///     These test methods would ideally be generated for each unit class,
    ///     but that was not trivial to do. At the time of writing this,
    ///     all unit classes are generated using the same scripts, so it is
    ///     reasonable to assume that testing one unit class would cover
    ///     all of them. Obviously, that can change in the future.
    /// </remarks>
    public class ParseTests
    {
        [Theory]
        [InlineData("1km", 1000)]
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
        [InlineData(null, "System.ArgumentNullException")] // Can't parse null.
        [InlineData("1", "System.ArgumentException")] // No unit abbreviation.
        [InlineData("km", "UnitsNet.UnitsNetException")] // No value, wrong measurement type.
        [InlineData("1 kg", "UnitsNet.UnitsNetException")] // Wrong measurement type.
        [InlineData("1ft monkey 1in", "UnitsNet.UnitsNetException")] // Invalid separator between two valid measurements.
        [InlineData("1ft 1invalid", "UnitsNet.UnitsNetException")] // Valid 
        public void ParseLength_InvalidString_USEnglish_ThrowsException(string s, string expected)
        {
            CultureInfo usEnglish = new CultureInfo("en-US");
            string actual = AssertExceptionAndGetFullTypeName(() => Length.Parse(s, usEnglish));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1 ft 1 in", 13)]
        [InlineData("1ft 1in", 13)]
        [InlineData("1' 1\"", 13)]
        [InlineData("1'1\"", 13)]
        [InlineData("1ft1in", 13)]
        [InlineData("1ft and 1in", 13)]
        public void ParseLength_FeetInchesString_USEnglish(string s, double expected)
        {
            CultureInfo usEnglish = new CultureInfo("en-US");
            double actual = Length.Parse(s, usEnglish).Inches;
            Assert.Equal(expected, actual);
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
            numberFormat.NumberDecimalSeparator = ".";

            double actual = Length.Parse(s, numberFormat).Meters;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("500.005.050,001 m", "UnitsNet.UnitsNetException")]
        // quantity doesn't match number format
        public void ParseWithCultureUsingSpaceAsThousandSeparators_ThrowsExceptionOnInvalidString(string s, string expected)
        {
            var numberFormat = (NumberFormatInfo) CultureInfo.InvariantCulture.NumberFormat.Clone();
            numberFormat.NumberGroupSeparator = " ";
            numberFormat.NumberDecimalSeparator = ".";

            string actual = AssertExceptionAndGetFullTypeName(() => Length.Parse(s, numberFormat));
            Assert.Equal(expected, actual);
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
            numberFormat.NumberDecimalSeparator = ",";

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
        [InlineData("500 005 m", "UnitsNet.UnitsNetException")] // Quantity doesn't match number format.
        public void ParseWithCultureUsingDotAsThousandSeparators_ThrowsExceptionOnInvalidString(string s, string expected)
        {
            var numberFormat = (NumberFormatInfo) CultureInfo.InvariantCulture.NumberFormat.Clone();
            numberFormat.NumberGroupSeparator = ".";
            numberFormat.NumberDecimalSeparator = ",";

            string actual = AssertExceptionAndGetFullTypeName(() => Length.Parse(s, numberFormat));
            Assert.Equal(expected, actual);
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
        [InlineData("kg", "UnitsNet.UnitNotFoundException")]
        [InlineData(null, "System.ArgumentNullException")]
        public void ParseLengthUnitUsEnglish_ThrowsExceptionOnInvalidString(string s, string expected)
        {
            CultureInfo usEnglish = new CultureInfo("en-US");
            string actual = AssertExceptionAndGetFullTypeName(() => Length.ParseUnit(s, usEnglish));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1 m", true)]
        [InlineData("1 m 50 cm", true)]
        [InlineData("2 kg", false)]
        [InlineData(null, false)]
        [InlineData("foo", false)]
        public void TryParseLengthUnitUsEnglish(string s, bool expected)
        {
            CultureInfo usEnglish = new CultureInfo("en-US");
            bool actual = Length.TryParse(s, usEnglish, out Length _);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("!")]
        [InlineData("@")]
        [InlineData("#")]
        [InlineData("$")]
        [InlineData("%")]
        [InlineData("^")]
        [InlineData("&")]
        [InlineData("*")]
        [InlineData("-")]
        [InlineData("_")]
        [InlineData("?")]
        [InlineData("123")]
        [InlineData(" ")]
        public void TryParseLengthUnitAbbreviationSpecialCharacters(string s)
        {
            string abbrev = $"m{s}s";

            UnitSystem unitSystem = UnitSystem.GetCached();
            unitSystem.MapUnitToAbbreviation(LengthUnit.Meter, abbrev);

            // Act
            bool ok = unitSystem.TryParse(abbrev, out LengthUnit result);

            // Assert
            Assert.True(ok, "TryParse " + abbrev);
            Assert.Equal(LengthUnit.Meter, result);
        }

        [Theory]
        [InlineData("!")]
        [InlineData("@")]
        [InlineData("#")]
        [InlineData("$")]
        [InlineData("%")]
        [InlineData("^")]
        [InlineData("&")]
        [InlineData("*")]
        [InlineData("-")]
        [InlineData("_")]
        [InlineData("?")]
        [InlineData("123")]
        [InlineData(" ")]
        public void TryParseLengthSpecialCharacters(string s)
        {
            string abbrev = $"m{s}s";

            UnitSystem unitSystem = UnitSystem.GetCached();
            unitSystem.MapUnitToAbbreviation(LengthUnit.Meter, abbrev);

            // Act
            bool ok = Length.TryParse($"10 {abbrev}", out Length result);

            // Assert
            Assert.True(ok, $"TryParse \"10 {abbrev}\"");
            Assert.Equal(10, result.Meters);
        }

        private static string AssertExceptionAndGetFullTypeName(Action code)
        {
            var exception = Assert.ThrowsAny<Exception>(code);
            return exception.GetType().FullName;
        }

    }
}