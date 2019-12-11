// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests
{
    /// <summary>
    ///     Additional assert methods to XUnit's <see cref="Xunit.Assert" />.
    /// </summary>
    public static class AssertEx
    {
        public static void EqualTolerance(double expected, double actual, double tolerance, ComparisonType comparisonType = ComparisonType.Relative)
        {
            if (comparisonType == ComparisonType.Relative)
            {
                var areEqual = Comparison.EqualsRelative(expected, actual, tolerance);

                var difference = Math.Abs(expected - actual);
                var relativeDifference = difference / expected;

                Assert.True(areEqual,
                    $"Values are not equal within relative tolerance: {tolerance:P4}\nExpected: {expected}\nActual: {actual}\nDiff: {relativeDifference:P4}");
            }
            else if (comparisonType == ComparisonType.Absolute)
            {
                var areEqual = Comparison.EqualsAbsolute(expected, actual, tolerance);
                Assert.True(areEqual,
                    $"Values are not equal within absolute tolerance: {tolerance}\nExpected: {expected}\nActual: {actual}\nDiff: {actual - expected:e}");
            }
        }
    }
}
