using System;
using System.Numerics;
using Xunit;

namespace UnitsNet.Tests
{
    /// <summary>
    ///     Additional assert methods to XUnit's <see cref="Xunit.Assert" />.
    /// </summary>
    public static class AssertEx
    {
        public static void EqualTolerance(QuantityValue expected, QuantityValue actual, QuantityValue tolerance, ComparisonType comparisonType = ComparisonType.Relative)
        {
            if (comparisonType == ComparisonType.Relative)
            {
                var areEqual = Comparison.EqualsRelative(expected, actual, tolerance);
                if (areEqual)
                {
                    return;
                }
                
                var difference = QuantityValue.Abs(expected - actual);
                QuantityValue relativeDifference = difference / expected;
                // Assert.True(areEqual, $"Values are not equal within relative tolerance: {tolerance:P4}\nExpected: {expected}\nActual: {actual}\nDiff: {relativeDifference:P4}");
                
                int percentDecimals;
                if (tolerance >= QuantityValue.One)
                {
                    percentDecimals = 0;
                }
                else
                {
                    (BigInteger _, BigInteger denominator) = tolerance;
                    percentDecimals = Math.Max(0, denominator.ToString().Length - 3);
                }
                
                var toleranceFormat = "P" + percentDecimals;
                var differenceFormat = "P" + (percentDecimals + 1);
                var userMessage = $"Values are not equal within relative tolerance: {tolerance.ToString(toleranceFormat)}\nExpected: {expected}\nActual: {actual}\nDiff: {relativeDifference.ToString(differenceFormat)}";
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
