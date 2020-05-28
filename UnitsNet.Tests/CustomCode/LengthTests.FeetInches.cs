// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace UnitsNet.Tests.CustomCode
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
            new object[]{"1'", 1, new CultureInfo("en-US")},                    // Feet only
            new object[]{"1′", 1, new CultureInfo("en-US")},                    // Feet only
            new object[]{"1\"", 0.08333333, new CultureInfo("en-US")},          // Inches only
            new object[]{"1″", 0.08333333, new CultureInfo("en-US")},           // Inches only
            new object[]{"0' 1\"", 0.08333333, new CultureInfo("en-US")},       // Inches only
            new object[]{"0' 1″", 0.08333333, new CultureInfo("en-US")},        // Inches only
            new object[]{"0′ 1\"", 0.08333333, new CultureInfo("en-US")},       // Inches only
            new object[]{"0′ 1″", 0.08333333, new CultureInfo("en-US")},        // Inches only
            new object[]{"1' 1\"", 1.08333333, new CultureInfo("en-US")},       // Normal form
            new object[]{"1′ 1″", 1.08333333, new CultureInfo("en-US")},        // Normal form
            new object[]{" 1′ 1″ ", 1.08333333, new CultureInfo("en-US")},      // Normal form, requires trimming
            new object[]{"1'1\"", 1.08333333, new CultureInfo("en-US")},        // Without space
            new object[]{"1′1″", 1.08333333, new CultureInfo("en-US")},         // Without space
            new object[]{"1 ft 1 in", 1.08333333, new CultureInfo("en-US")},
            new object[]{"1ft 1in", 1.08333333, new CultureInfo("en-US")},
            new object[]{"-1'", -1, new CultureInfo("en-US")},                  // Feet only
            new object[]{"-1′", -1, new CultureInfo("en-US")},                  // Feet only
            new object[]{"-1\"", -0.08333333, new CultureInfo("en-US")},        // Inches only
            new object[]{"-1″", -0.08333333, new CultureInfo("en-US")},         // Inches only
            new object[]{"-0' 1\"", -0.08333333, new CultureInfo("en-US")},     // Inches only
            new object[]{"-0' 1″", -0.08333333, new CultureInfo("en-US")},      // Inches only
            new object[]{"-0′ 1\"", -0.08333333, new CultureInfo("en-US")},     // Inches only
            new object[]{"-0′ 1″", -0.08333333, new CultureInfo("en-US")},      // Inches only
            new object[]{"-1' 1\"", -1.08333333, new CultureInfo("en-US")},     // Normal form
            new object[]{"-1′ 1″", -1.08333333, new CultureInfo("en-US")},      // Normal form
            new object[]{" -1′ 1″ ", -1.08333333, new CultureInfo("en-US")},    // Normal form, requires trimming
            new object[]{"-1'1\"", -1.08333333, new CultureInfo("en-US")},      // Without space
            new object[]{"-1′1″", -1.08333333, new CultureInfo("en-US")},       // Without space
            new object[]{"-1 ft 1 in", -1.08333333, new CultureInfo("en-US")},
            new object[]{"-1ft 1in", -1.08333333, new CultureInfo("en-US")},
            // Same as above, but with de-CH culture (uses ' as separator)
            new object[]{"1'", 1, new CultureInfo("de-CH")},                    // Feet only
            new object[]{"1′", 1, new CultureInfo("de-CH")},                    // Feet only
            new object[]{"1\"", 0.08333333, new CultureInfo("de-CH")},          // Inches only
            new object[]{"1″", 0.08333333, new CultureInfo("de-CH")},           // Inches only
            new object[]{"0' 1\"", 0.08333333, new CultureInfo("de-CH")},       // Inches only
            new object[]{"0' 1″", 0.08333333, new CultureInfo("de-CH")},        // Inches only
            new object[]{"0′ 1\"", 0.08333333, new CultureInfo("de-CH")},       // Inches only
            new object[]{"0′ 1″", 0.08333333, new CultureInfo("de-CH")},        // Inches only
            new object[]{"1' 1\"", 1.08333333, new CultureInfo("de-CH")},       // Normal form
            new object[]{"1′ 1″", 1.08333333, new CultureInfo("de-CH")},        // Normal form
            new object[]{" 1′ 1″ ", 1.08333333, new CultureInfo("de-CH")},      // Normal form, requires trimming
            new object[]{"1'1\"", 1.08333333, new CultureInfo("de-CH")},        // Without space
            new object[]{"1′1″", 1.08333333, new CultureInfo("de-CH")},         // Without space
            new object[]{"1 ft 1 in", 1.08333333, new CultureInfo("de-CH")},
            new object[]{"1ft 1in", 1.08333333, new CultureInfo("de-CH")},
            new object[]{"-1'", -1, new CultureInfo("de-CH")},                  // Feet only
            new object[]{"-1′", -1, new CultureInfo("de-CH")},                  // Feet only
            new object[]{"-1\"", -0.08333333, new CultureInfo("de-CH")},        // Inches only
            new object[]{"-1″", -0.08333333, new CultureInfo("de-CH")},         // Inches only
            new object[]{"-0' 1\"", -0.08333333, new CultureInfo("de-CH")},     // Inches only
            new object[]{"-0' 1″", -0.08333333, new CultureInfo("de-CH")},      // Inches only
            new object[]{"-0′ 1\"", -0.08333333, new CultureInfo("de-CH")},     // Inches only
            new object[]{"-0′ 1″", -0.08333333, new CultureInfo("de-CH")},      // Inches only
            new object[]{"-1' 1\"", -1.08333333, new CultureInfo("de-CH")},     // Normal form
            new object[]{"-1′ 1″", -1.08333333, new CultureInfo("de-CH")},      // Normal form
            new object[]{" -1′ 1″ ", -1.08333333, new CultureInfo("de-CH")},    // Normal form, requires trimming
            new object[]{"-1'1\"", -1.08333333, new CultureInfo("de-CH")},      // Without space
            new object[]{"-1′1″", -1.08333333, new CultureInfo("de-CH")},       // Without space
            new object[]{"-1 ft 1 in", -1.08333333, new CultureInfo("de-CH")},
            new object[]{"-1ft 1in", -1.08333333, new CultureInfo("de-CH")},
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
            new object[]{"a", new CultureInfo("en-US")},        // Missing or invalid apostrophe or double prime chars
            new object[]{"1", new CultureInfo("en-US")},
            new object[]{"1`", new CultureInfo("en-US")},
            new object[]{"1^", new CultureInfo("en-US")},
            new object[]{"1' 1'", new CultureInfo("en-US")},    // Feet apostrophe twice
            new object[]{"1′ 1′", new CultureInfo("en-US")},
            new object[]{"1' 1", new CultureInfo("en-US")},     // No inches double prime
            new object[]{"1′ 1", new CultureInfo("en-US")},
            new object[]{"1′ 1`", new CultureInfo("en-US")},    // Invalid inches double prime
            new object[]{"1' 1`", new CultureInfo("en-US")},
            new object[]{"1'1'", new CultureInfo("en-US")},     // Same without space
            new object[]{"1′1′", new CultureInfo("en-US")},
            new object[]{"1'1", new CultureInfo("en-US")},
            new object[]{"1′1", new CultureInfo("en-US")},
            new object[]{"1′1`", new CultureInfo("en-US")},
            new object[]{"1'1`", new CultureInfo("en-US")},
            // Same as above, but with de-CH culture (uses ' as separator)
            new object[]{"a", new CultureInfo("de-CH")},        // Missing or invalid apostrophe or double prime chars
            new object[]{"1", new CultureInfo("de-CH")},
            new object[]{"1`", new CultureInfo("de-CH")},
            new object[]{"1^", new CultureInfo("de-CH")},
            new object[]{"1' 1'", new CultureInfo("de-CH")},    // Feet apostrophe twice
            new object[]{"1′ 1′", new CultureInfo("de-CH")},
            new object[]{"1' 1", new CultureInfo("de-CH")},     // No inches double prime
            new object[]{"1′ 1", new CultureInfo("de-CH")},
            new object[]{"1′ 1`", new CultureInfo("de-CH")},    // Invalid inches double prime
            new object[]{"1' 1`", new CultureInfo("de-CH")},
            new object[]{"1'1'", new CultureInfo("de-CH")},     // Same without space
            new object[]{"1′1′", new CultureInfo("de-CH")},
            new object[]{"1'1", new CultureInfo("de-CH")},
            new object[]{"1′1", new CultureInfo("de-CH")},
            new object[]{"1′1`", new CultureInfo("de-CH")},
            new object[]{"1'1`", new CultureInfo("de-CH")},
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
