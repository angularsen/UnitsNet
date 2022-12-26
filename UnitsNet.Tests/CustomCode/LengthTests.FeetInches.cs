// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace UnitsNet.Tests
{
    public class FeetInchesTests
    {
        private const double FeetInOneMeter = 3.28084;
        private const double InchesInOneMeter = 39.37007874;
        private const double FeetTolerance = 1e-5;
        private const double InchesTolerance = 1e-5;

        [Fact]
        public void FeetInchesFrom()
        {
            Length meter = Length.FromFeetInches(2, 3);
            double expectedMeters = 2/FeetInOneMeter + 3/InchesInOneMeter;
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
            new object[]{"1'", 1, new CultureInfo("en-US", false)},                    // Feet only
            new object[]{"1′", 1, new CultureInfo("en-US", false)},                    // Feet only
            new object[]{"1,000′", 1000, new CultureInfo("en-US", false)},             // Feet only, with seperator
            new object[]{"1e3'", 1000, new CultureInfo("en-US", false)},               // Feet only, exponential notation
            new object[]{"1\"", 0.08333333, new CultureInfo("en-US", false)},          // Inches only
            new object[]{"1″", 0.08333333, new CultureInfo("en-US", false)},           // Inches only
            new object[]{"0' 1\"", 0.08333333, new CultureInfo("en-US", false)},       // Inches only
            new object[]{"0' 1″", 0.08333333, new CultureInfo("en-US", false)},        // Inches only
            new object[]{"0′ 1\"", 0.08333333, new CultureInfo("en-US", false)},       // Inches only
            new object[]{"0′ 1″", 0.08333333, new CultureInfo("en-US", false)},        // Inches only
            new object[]{"1' 1\"", 1.08333333, new CultureInfo("en-US", false)},       // Normal form
            new object[]{"1′ 1″", 1.08333333, new CultureInfo("en-US", false)},        // Normal form
            new object[]{" 1′ 1″ ", 1.08333333, new CultureInfo("en-US", false)},      // Normal form, requires trimming
            new object[]{"1'1\"", 1.08333333, new CultureInfo("en-US", false)},        // Without space
            new object[]{"1′1″", 1.08333333, new CultureInfo("en-US", false)},         // Without space
            new object[]{"1 ft 1 in", 1.08333333, new CultureInfo("en-US", false)},
            new object[]{"1ft 1in", 1.08333333, new CultureInfo("en-US", false)},
            new object[]{"-1'", -1, new CultureInfo("en-US", false)},                  // Feet only
            new object[]{"-1′", -1, new CultureInfo("en-US", false)},                  // Feet only
            new object[]{"-1,000′", -1000, new CultureInfo("en-US", false)},           // Feet only, with seperator
            new object[]{"-1e3'", -1000, new CultureInfo("en-US", false)},             // Feet only, exponential notation
            new object[]{"-1\"", -0.08333333, new CultureInfo("en-US", false)},        // Inches only
            new object[]{"-1″", -0.08333333, new CultureInfo("en-US", false)},         // Inches only
            new object[]{"-0' 1\"", -0.08333333, new CultureInfo("en-US", false)},     // Inches only
            new object[]{"-0' 1″", -0.08333333, new CultureInfo("en-US", false)},      // Inches only
            new object[]{"-0′ 1\"", -0.08333333, new CultureInfo("en-US", false)},     // Inches only
            new object[]{"-0′ 1″", -0.08333333, new CultureInfo("en-US", false)},      // Inches only
            new object[]{"-1' 1\"", -1.08333333, new CultureInfo("en-US", false)},     // Normal form
            new object[]{"-1′ 1″", -1.08333333, new CultureInfo("en-US", false)},      // Normal form
            new object[]{" -1′ 1″ ", -1.08333333, new CultureInfo("en-US", false)},    // Normal form, requires trimming
            new object[]{"-1'1\"", -1.08333333, new CultureInfo("en-US", false)},      // Without space
            new object[]{"-1′1″", -1.08333333, new CultureInfo("en-US", false)},       // Without space
            new object[]{"-1 ft 1 in", -1.08333333, new CultureInfo("en-US", false)},
            new object[]{"-1ft 1in", -1.08333333, new CultureInfo("en-US", false)},
            new object[]{"1’000′", 1000, new CultureInfo("de-CH", false)},             // Feet only, with seperator
            new object[]{"1’000′ 6\"", 1000.5, new CultureInfo("de-CH", false)},       // Normal form, using separators for culture
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
            new object[]{"a", new CultureInfo("en-US", false)},        // Missing or invalid apostrophe or double prime chars
            new object[]{"1", new CultureInfo("en-US", false)},
            new object[]{"1`", new CultureInfo("en-US", false)},
            new object[]{"1^", new CultureInfo("en-US", false)},
            new object[]{"1' 1'", new CultureInfo("en-US", false)},    // Feet apostrophe twice
            new object[]{"1′ 1′", new CultureInfo("en-US", false)},
            new object[]{"1' 1", new CultureInfo("en-US", false)},     // No inches double prime
            new object[]{"1′ 1", new CultureInfo("en-US", false)},
            new object[]{"1′ 1`", new CultureInfo("en-US", false)},    // Invalid inches double prime
            new object[]{"1' 1`", new CultureInfo("en-US", false)},
            new object[]{"1'1'", new CultureInfo("en-US", false)},     // Same without space
            new object[]{"1′1′", new CultureInfo("en-US", false)},
            new object[]{"1'1", new CultureInfo("en-US", false)},
            new object[]{"1′1", new CultureInfo("en-US", false)},
            new object[]{"1′1`", new CultureInfo("en-US", false)},
            new object[]{"1'1`", new CultureInfo("en-US", false)}
        };

        [Theory]
        [MemberData(nameof(InvalidData))]
        public void TryParseFeetInches_GivenInvalidString_ReturnsFalseAndZeroOut(string str, CultureInfo formatProvider)
        {
            Assert.False(Length.TryParseFeetInches(str, out Length result, formatProvider));
            Assert.Equal(Length.Zero, result);
        }
    }
}
