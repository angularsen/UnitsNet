using Xunit;

namespace UnitsNet.Tests
{
    /// <summary>
    ///     Tests that cover generated code in quantity structs, such as <see cref="Length" /> and <see cref="Mass" />.
    ///     The idea is to move tests that cover uniformly generated code here, because repeating the exact same test N times
    ///     over don't make it safer.
    /// </summary>
    public class GeneratedQuantityCodeTests
    {
        /// <summary>
        ///     Types with <see cref="double" /> as internal representation. This is the majority of units, such as
        ///     <see cref="Length" />.
        /// </summary>
        public class QuantitiesWithDouble
        {
            [Fact]
            public void LengthEquals_GivenMaxError_ReturnsTrueIfWithinError()
            {
                var smallError = 1e-5;

                Assert.True(Length.FromMeters(1).Equals(Length.FromMeters(1), 0, ComparisonType.Relative), "Integer values have zero difference.");
                Assert.True(Length.FromMeters(1).Equals(Length.FromMeters(1), smallError, ComparisonType.Relative), "Using a max difference value should not change that fact.");

                Assert.False(Length.FromMeters(1 + 0.39).Equals(Length.FromMeters(1.39), 0, ComparisonType.Relative),
                    "Example of floating precision arithmetic that produces slightly different results.");
                Assert.True(Length.FromMeters(1 + 0.39).Equals(Length.FromMeters(1.39), smallError, ComparisonType.Relative), "But the difference is very small");
            }
        }
    }
}
