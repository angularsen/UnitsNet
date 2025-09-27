// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace UnitsNet.Tests;

public class FeetInchesTests
{
    private const string EnglishUs = "en-US";
    private const string GermanSwitzerland = "de-CH";
    
    [Fact]
    public void FeetInchesFrom()
    {
        var meter = Length.FromFeetInches(2, 3);
        Assert.Equal(0.6858m, meter.Meters);
    }

    [Fact]
    public void FeetInchesRoundTrip()
    {
        var meter = Length.FromFeetInches(2, 3);
        FeetInches feetInches = meter.FeetInches;
        Assert.Equal(2, feetInches.Feet);
        Assert.Equal(3, feetInches.Inches);
    }

    public static IEnumerable<object[]> ValidData
    {
        get =>
        [
            ["1'", 1, EnglishUs], // Feet only
            ["1′", 1, EnglishUs], // Feet only
            ["1,000′", 1000, EnglishUs], // Feet only, with separator
            ["1e3'", 1000, EnglishUs], // Feet only, exponential notation
            ["1\"", 0.08333333, EnglishUs], // Inches only
            ["1″", 0.08333333, EnglishUs], // Inches only
            ["0' 1\"", 0.08333333, EnglishUs], // Inches only
            ["0' 1″", 0.08333333, EnglishUs], // Inches only
            ["0′ 1\"", 0.08333333, EnglishUs], // Inches only
            ["0′ 1″", 0.08333333, EnglishUs], // Inches only
            ["1' 1\"", 1.08333333, EnglishUs], // Normal form
            ["1′ 1″", 1.08333333, EnglishUs], // Normal form
            [" 1′ 1″ ", 1.08333333, EnglishUs], // Normal form, requires trimming
            ["1'1\"", 1.08333333, EnglishUs], // Without space
            ["1′1″", 1.08333333, EnglishUs], // Without space
            ["1 ft 1 in", 1.08333333, EnglishUs],
            ["1ft 1in", 1.08333333, EnglishUs],
            ["-1'", -1, EnglishUs], // Feet only
            ["-1′", -1, EnglishUs], // Feet only
            ["-1,000′", -1000, EnglishUs], // Feet only, with separator
            ["-1e3'", -1000, EnglishUs], // Feet only, exponential notation
            ["-1\"", -0.08333333, EnglishUs], // Inches only
            ["-1″", -0.08333333, EnglishUs], // Inches only
            ["-0' 1\"", -0.08333333, EnglishUs], // Inches only
            ["-0' 1″", -0.08333333, EnglishUs], // Inches only
            ["-0′ 1\"", -0.08333333, EnglishUs], // Inches only
            ["-0′ 1″", -0.08333333, EnglishUs], // Inches only
            ["-1' 1\"", -1.08333333, EnglishUs], // Normal form
            ["-1′ 1″", -1.08333333, EnglishUs], // Normal form
            [" -1′ 1″ ", -1.08333333, EnglishUs], // Normal form, requires trimming
            ["-1'1\"", -1.08333333, EnglishUs], // Without space
            ["-1′1″", -1.08333333, EnglishUs], // Without space
            ["-1 ft 1 in", -1.08333333, EnglishUs],
            ["-1ft 1in", -1.08333333, EnglishUs],
            ["1’000′", 1000, GermanSwitzerland], // Feet only, with separator
            ["1’000′ 6\"", 1000.5, GermanSwitzerland] // Normal form, using separators for culture
        ];
    }

    [Theory]
    [MemberData(nameof(ValidData))]
    public void TryParseFeetInches(string str, double expectedFeet, string cultureName)
    {
        var formatProvider = new CultureInfo(cultureName, false);
        Assert.True(Length.TryParseFeetInches(str, out Length result, formatProvider));
        AssertEx.EqualTolerance(expectedFeet, result.Feet, 1e-5);
    }

    public static IEnumerable<object[]> InvalidData
    {
        get =>
        [
            ["a", EnglishUs], // Missing or invalid apostrophe or double prime chars
            ["1", EnglishUs],
            ["1`", EnglishUs],
            ["1^", EnglishUs],
            ["1' 1'", EnglishUs], // Feet apostrophe twice
            ["1′ 1′", EnglishUs],
            ["1' 1", EnglishUs], // No inches double prime
            ["1′ 1", EnglishUs],
            ["1′ 1`", EnglishUs], // Invalid inches double prime
            ["1' 1`", EnglishUs],
            ["1'1'", EnglishUs], // Same without space
            ["1′1′", EnglishUs],
            ["1'1", EnglishUs],
            ["1′1", EnglishUs],
            ["1′1`", EnglishUs],
            ["1'1`", EnglishUs]
        ];
    }

    [Theory]
    [MemberData(nameof(InvalidData))]
    public void TryParseFeetInches_GivenInvalidString_ReturnsFalseAndZeroOut(string str, string cultureName)
    {
        var formatProvider = new CultureInfo(cultureName, false);
        Assert.False(Length.TryParseFeetInches(str, out Length result, formatProvider));
        Assert.Equal(Length.Zero, result);
    }
}
