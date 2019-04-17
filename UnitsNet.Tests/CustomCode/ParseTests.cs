// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

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

        [Theory]
        [InlineData("1 ng", "en-US", 1, MassUnit.Nanogram)]
        [InlineData("1 нг", "ru-RU", 1, MassUnit.Nanogram)]
        [InlineData("1 g", "en-US", 1, MassUnit.Gram)]
        [InlineData("1 г", "ru-RU", 1, MassUnit.Gram)]
        [InlineData("1 kg", "en-US", 1, MassUnit.Kilogram)]
        [InlineData("1 кг", "ru-RU", 1, MassUnit.Kilogram)]
        public void ParseMassWithPrefixUnits_GivenCulture_ReturnsQuantityWithSameUnitAndValue(string str, string cultureName, double expectedValue, Enum expectedUnit)
        {
            var actual = Mass.Parse(str, new CultureInfo(cultureName));

            Assert.Equal(expectedUnit, actual.Unit);
            Assert.Equal(expectedValue, actual.Value);
        }

        [Theory]
        [InlineData("1 nm", "en-US", 1, LengthUnit.Nanometer)]
        [InlineData("1 нм", "ru-RU", 1, LengthUnit.Nanometer)]
        [InlineData("1 m", "en-US", 1, LengthUnit.Meter)]
        [InlineData("1 м", "ru-RU", 1, LengthUnit.Meter)]
        [InlineData("1 km", "en-US", 1, LengthUnit.Kilometer)]
        [InlineData("1 км", "ru-RU", 1, LengthUnit.Kilometer)]
        public void ParseLengthWithPrefixUnits_GivenCulture_ReturnsQuantityWithSameUnitAndValue(string str, string cultureName, double expectedValue, Enum expectedUnit)
        {
            var actual = Length.Parse(str, new CultureInfo(cultureName));

            Assert.Equal(expectedUnit, actual.Unit);
            Assert.Equal(expectedValue, actual.Value);
        }

        [Theory]
        [InlineData("1 µN", "en-US", 1, ForceUnit.Micronewton)]
        [InlineData("1 мкН", "ru-RU", 1, ForceUnit.Micronewton)]
        [InlineData("1 N", "en-US", 1, ForceUnit.Newton)]
        [InlineData("1 Н", "ru-RU", 1, ForceUnit.Newton)]
        [InlineData("1 kN", "en-US", 1, ForceUnit.Kilonewton)]
        [InlineData("1 кН", "ru-RU", 1, ForceUnit.Kilonewton)]
        public void ParseForceWithPrefixUnits_GivenCulture_ReturnsQuantityWithSameUnitAndValue(string str, string cultureName, double expectedValue, Enum expectedUnit)
        {
            var actual = Force.Parse(str, new CultureInfo(cultureName));

            Assert.Equal(expectedUnit, actual.Unit);
            Assert.Equal(expectedValue, actual.Value);
        }

        [Theory]
        [InlineData("1 b", "en-US", 1, InformationUnit.Bit)]
        [InlineData("1 b", "ru-RU", 1, InformationUnit.Bit)]
        [InlineData("1 B", "en-US", 1, InformationUnit.Byte)]
        [InlineData("1 B", "ru-RU", 1, InformationUnit.Byte)]
        [InlineData("1 Mb", "en-US", 1, InformationUnit.Megabit)]
        [InlineData("1 Mb", "ru-RU", 1, InformationUnit.Megabit)]
        [InlineData("1 Mib", "en-US", 1, InformationUnit.Mebibit)]
        [InlineData("1 Mib", "ru-RU", 1, InformationUnit.Mebibit)]
        [InlineData("1 MB", "en-US", 1, InformationUnit.Megabyte)]
        [InlineData("1 MB", "ru-RU", 1, InformationUnit.Megabyte)]
        [InlineData("1 MiB", "en-US", 1, InformationUnit.Mebibyte)]
        [InlineData("1 MiB", "ru-RU", 1, InformationUnit.Mebibyte)]
        public void ParseInformationWithPrefixUnits_GivenCulture_ReturnsQuantityWithSameUnitAndValue(string str, string cultureName, decimal expectedValue, Enum expectedUnit)
        {
            var actual = Information.Parse(str, new CultureInfo(cultureName));

            Assert.Equal(expectedUnit, actual.Unit);
            Assert.Equal(expectedValue, actual.Value);
        }
    }
}
