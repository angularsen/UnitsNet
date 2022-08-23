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
                bool areEqual = Comparison.EqualsRelative(expected, actual, tolerance);

                double difference = Math.Abs(expected - actual);
                double relativeDifference = difference / expected;

                Assert.True( areEqual, $"Values are not equal within relative tolerance: {tolerance:P4}\nExpected: {expected}\nActual: {actual}\nDiff: {relativeDifference:P4}" );
            }
            else if (comparisonType == ComparisonType.Absolute)
            {
                bool areEqual = Comparison.EqualsAbsolute(expected, actual, tolerance);
                Assert.True( areEqual, $"Values are not equal within absolute tolerance: {tolerance}\nExpected: {expected}\nActual: {actual}\nDiff: {actual - expected:e}" );
            }
        }

        public static void EqualTolerance(decimal expected, decimal actual, decimal tolerance, ComparisonType comparisonType = ComparisonType.Relative)
        {
            if (comparisonType == ComparisonType.Relative)
            {
                bool areEqual = Comparison.EqualsRelative(expected, actual, tolerance);

                decimal difference = Math.Abs(expected - actual);
                decimal relativeDifference = difference / expected;

                Assert.True(areEqual, $"Values are not equal within relative tolerance: {tolerance:P4}\nExpected: {expected}\nActual: {actual}\nDiff: {relativeDifference:P4}");
            }
            else if (comparisonType == ComparisonType.Absolute)
            {
                bool areEqual = Comparison.EqualsAbsolute(expected, actual, tolerance);
                Assert.True(areEqual, $"Values are not equal within absolute tolerance: {tolerance}\nExpected: {expected}\nActual: {actual}\nDiff: {actual - expected:e}");
            }
        }

        public static void EqualTolerance(QuantityValue expected, QuantityValue actual, double tolerance,
            ComparisonType comparisonType = ComparisonType.Relative)
        {
            EqualTolerance((double)expected, (double)actual, tolerance, comparisonType);
        }

        public static void EqualTolerance(QuantityValue expected, QuantityValue actual, decimal tolerance,
            ComparisonType comparisonType = ComparisonType.Relative)
        {
            EqualTolerance((decimal)expected, (decimal)actual, tolerance, comparisonType);
        }
    }
}
