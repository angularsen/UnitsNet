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
                if (areEqual)
                {
                    return;
                }

                var difference = Math.Abs(expected - actual);
                double relativeDifference = expected != 0 ? difference / Math.Abs(expected) : difference;

                var userMessage = $"Values are not equal within relative tolerance: {tolerance:P4}\nExpected: {expected}\nActual: {actual}\nDiff: {relativeDifference:P4}";
                Assert.True(areEqual, userMessage);
            }
            else if (comparisonType == ComparisonType.Absolute)
            {
                var areEqual = Comparison.EqualsAbsolute(expected, actual, tolerance);
                if (areEqual)
                {
                    return;
                }

                Assert.True(areEqual, $"Values are not equal within absolute tolerance: {tolerance}\nExpected: {expected}\nActual: {actual}\nDiff: {actual - expected:e}" );
            }
        }
    }
}
