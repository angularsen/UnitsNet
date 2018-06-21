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
            if(comparisonType == ComparisonType.Relative)
            {
                bool areEqual = UnitsNet.Comparison.EqualsRelative(expected, actual, tolerance);

                double difference = Math.Abs(expected - actual);
                double percentDifference = (difference / actual) * 100.0d;

                Assert.True( areEqual, $"Values are not equal within relative tolerance: {tolerance * 100.0d}%\nExpected: {expected}\nActual: {actual}\nDiff: {percentDifference}%" );
            }
            else if( comparisonType == ComparisonType.Absolute )
            {
                bool areEqual = UnitsNet.Comparison.EqualsAbsolute(expected, actual, tolerance);
                Assert.True( areEqual, $"Values are not equal within absolute tolerance: {tolerance}\nExpected: {expected}\nActual: {actual}\nDiff: {actual - expected:e}" );
            }
        }
    }
}
