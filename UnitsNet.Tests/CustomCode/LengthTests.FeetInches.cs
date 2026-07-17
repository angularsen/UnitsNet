// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Globalization;
using UnitsNet.Tests.Helpers;

namespace UnitsNet.Tests
{
    public class FeetInchesTests
    {
        private static readonly CultureInfo EnglishUs = new("en-US", useUserOverride: false);
        private static readonly CultureInfo GermanSwitzerland = new("de-CH", useUserOverride: false);
        private const double FeetInOneMeter = 3.28084;
        private const double InchesInOneMeter = 39.37007874;
        private const double FeetTolerance = 1e-5;
        private const double InchesTolerance = 1e-5;

        [Fact]
        public void FeetInchesFrom()
        {
            Length meter = Length.FromFeetInches(2, 3);
            double expectedMeters = 2 / FeetInOneMeter + 3 / InchesInOneMeter;
            AssertEx.EqualTolerance(expectedMeters, meter.Meters, FeetTolerance);
        }

        [Fact]
        public void FeetInchesRoundTrip()
        {
            Length meter = Length.FromFeetInches(2, 3);
            FeetInches feetInches = meter.FeetInches;
            AssertEx.EqualTolerance(2, feetInches.Feet, FeetTolerance);
            AssertEx.EqualTolerance(3, feetInches.Inches, InchesTolerance);
        }

        public static IEnumerable<object[]> ValidData => new List<object[]>
        {
            new object[]{"1'", 1, EnglishUs},                    // Feet only
            new object[]{"1′", 1, EnglishUs},                    // Feet only
            new object[]{"1,000′", 1000, EnglishUs},             // Feet only, with seperator
            new object[]{"1e3'", 1000, EnglishUs},               // Feet only, exponential notation
            new object[]{"1\"", 0.08333333, EnglishUs},          // Inches only
            new object[]{"1″", 0.08333333, EnglishUs},           // Inches only
            new object[]{"0' 1\"", 0.08333333, EnglishUs},       // Inches only
            new object[]{"0' 1″", 0.08333333, EnglishUs},        // Inches only
            new object[]{"0′ 1\"", 0.08333333, EnglishUs},       // Inches only
            new object[]{"0′ 1″", 0.08333333, EnglishUs},        // Inches only
            new object[]{"1' 1\"", 1.08333333, EnglishUs},       // Normal form
            new object[]{"1′ 1″", 1.08333333, EnglishUs},        // Normal form
            new object[]{" 1′ 1″ ", 1.08333333, EnglishUs},      // Normal form, requires trimming
            new object[]{"1'1\"", 1.08333333, EnglishUs},        // Without space
            new object[]{"1′1″", 1.08333333, EnglishUs},         // Without space
            new object[]{"1 ft 1 in", 1.08333333, EnglishUs},
            new object[]{"1ft 1in", 1.08333333, EnglishUs},
            new object[]{"-1'", -1, EnglishUs},                  // Feet only
            new object[]{"-1′", -1, EnglishUs},                  // Feet only
            new object[]{"-1,000′", -1000, EnglishUs},           // Feet only, with seperator
            new object[]{"-1e3'", -1000, EnglishUs},             // Feet only, exponential notation
            new object[]{"-1\"", -0.08333333, EnglishUs},        // Inches only
            new object[]{"-1″", -0.08333333, EnglishUs},         // Inches only
            new object[]{"-0' 1\"", -0.08333333, EnglishUs},     // Inches only
            new object[]{"-0' 1″", -0.08333333, EnglishUs},      // Inches only
            new object[]{"-0′ 1\"", -0.08333333, EnglishUs},     // Inches only
            new object[]{"-0′ 1″", -0.08333333, EnglishUs},      // Inches only
            new object[]{"-1' 1\"", -1.08333333, EnglishUs},     // Normal form
            new object[]{"-1′ 1″", -1.08333333, EnglishUs},      // Normal form
            new object[]{" -1′ 1″ ", -1.08333333, EnglishUs},    // Normal form, requires trimming
            new object[]{"-1'1\"", -1.08333333, EnglishUs},      // Without space
            new object[]{"-1′1″", -1.08333333, EnglishUs},       // Without space
            new object[]{"-1 ft 1 in", -1.08333333, EnglishUs},
            new object[]{"-1ft 1in", -1.08333333, EnglishUs},
            new object[]{"1’000′", 1000, GermanSwitzerland},             // Feet only, with seperator
            new object[]{"1’000′ 6\"", 1000.5, GermanSwitzerland},       // Normal form, using separators for culture
        };

        [Theory]
        [MemberData(nameof(ValidData))]
        public void TryParseFeetInches(string str, double expectedFeet, CultureInfo formatProvider)
        {
            Assert.True(Length.TryParseFeetInches(str, out Length result, formatProvider));
            AssertEx.EqualTolerance(expectedFeet, result.Feet, 1e-5);
        }

        public static IEnumerable<object[]> InvalidData => new List<object[]>
        {
            new object[]{"a", EnglishUs},        // Missing or invalid apostrophe or double prime chars
            new object[]{"1", EnglishUs},
            new object[]{"1`", EnglishUs},
            new object[]{"1^", EnglishUs},
            new object[]{"1' 1'", EnglishUs},    // Feet apostrophe twice
            new object[]{"1′ 1′", EnglishUs},
            new object[]{"1' 1", EnglishUs},     // No inches double prime
            new object[]{"1′ 1", EnglishUs},
            new object[]{"1′ 1`", EnglishUs},    // Invalid inches double prime
            new object[]{"1' 1`", EnglishUs},
            new object[]{"1'1'", EnglishUs},     // Same without space
            new object[]{"1′1′", EnglishUs},
            new object[]{"1'1", EnglishUs},
            new object[]{"1′1", EnglishUs},
            new object[]{"1′1`", EnglishUs},
            new object[]{"1'1`", EnglishUs}
        };

        [Theory]
        [MemberData(nameof(InvalidData))]
        public void TryParseFeetInches_GivenInvalidString_ReturnsFalseAndZeroOut(string str, CultureInfo formatProvider)
        {
            Assert.False(Length.TryParseFeetInches(str, out Length result, formatProvider));
            Assert.Equal(Length.Zero, result);
        }

        [Theory]
        [InlineData(-11.9999, 0, -11.9999)]
        [InlineData(-23.98, -1, -11.98)]
        [InlineData(-13, -1, -1)]
        [InlineData(-38.563, -3, -2.563)]

        public static void NegativeFeetInchesIsAsExpected(double inch, double expectedFeet, double expectedInches)
        {
            var length = Length.FromInches(inch);

            Assert.Equal(expectedFeet, length.FeetInches.Feet, tolerance: 0.000000000001d);
            Assert.Equal(expectedInches, length.FeetInches.Inches, tolerance: 0.000000000001d);

        }

        [Theory]
        [InlineData(1, -11, 0, 1)]
        [InlineData(-2, 2, -1, -10)]
        [InlineData(-1, 32, 1, 8)]

        public static void MixedPositiveNegativeFeetInchesIsAsExpected(double feet, double inch, double expectedFeet, double expectedInches)
        {
            var length = Length.FromFeetInches(feet, inch);

            Assert.Equal(expectedFeet, length.FeetInches.Feet);
            Assert.Equal(expectedInches, length.FeetInches.Inches);

        }

        [Theory]
        [InlineData(11.9999, 16, "1' - 0\"")]
        [InlineData(-11.9999, 16, "-1' - 0\"")]
        [InlineData(23.98, 32, "1' - 11 31/32\"")]
        [InlineData(-23.98, 32, "-1' - 11 31/32\"")]
        [InlineData(13, 32, "1' - 1\"")]
        [InlineData(-13, 32, "-1' - 1\"")]
        [InlineData(38.563, 32, "3' - 2 9/16\"")]
        [InlineData(-38.563, 32, "-3' - 2 9/16\"")]

        public static void NegativeToArchitecturalString_ReturnsFormatted(double inch, int fractionDenominator, string expected)
        {
            var length = Length.FromInches(inch);

            Assert.Equal(expected, length.FeetInches.ToArchitecturalString(fractionDenominator));
        }

        [Theory]
        [InlineData(11.9999, "1 ft 0 in")]
        [InlineData(-11.9999, "-1 ft 0 in")]
        [InlineData(23.98, "2 ft 0 in")]
        [InlineData(-23.98, "-2 ft 0 in")]
        [InlineData(13, "1 ft 1 in")]
        [InlineData(-13, "-1 ft 1 in")]
        [InlineData(38.563, "3 ft 3 in")]
        [InlineData(-38.563, "-3 ft 3 in")]
        [InlineData(50.2, "4 ft 2 in")]
        [InlineData(-50.2, "-4 ft 2 in")]
        [InlineData(-50.2, "-4 фут 2 дюйм", "ru-RU")]//ensure we are using alternate units
        [InlineData(-50.2, "\u22124 ft 2 in", "nb-NO")]// nb-NO does not have alternate abbreviations defined in length.json but does use a different negative symbol
        public static void FeetInches_ToStringFormatsCorrectly(double inch, string expected, string? cultureString = null)
        {
            var length = Length.FromInches(inch);
            CultureInfo culture;
            if (cultureString == null)
            {
                culture = CultureInfo.InvariantCulture;
            }
            else
            {
                culture = new CultureInfo(cultureString, useUserOverride: false);
            }
            Assert.Equal(expected, length.FeetInches.ToString(culture));
        }

        [Theory]
        [InlineData(47.9988, "4 ft 0 in")]
        [InlineData(-47.9988, "-4 ft 0 in")]
        public static void FeetInches_ToString_RoundsTwelveInchesIntoNextFoot(double inch, string expected)
        {
            using var _ = new CultureScope(CultureInfo.InvariantCulture);

            var length = Length.FromInches(inch);

            Assert.Equal(expected, length.FeetInches.ToString());
        }
    }
}
