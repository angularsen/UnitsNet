using Xunit;

namespace UnitsNet.Tests
{
    /// <summary>
    ///     Additional assert methods to XUnit's <see cref="Xunit.Assert" />.
    /// </summary>
    public static class AssertEx
    {
        public static void EqualTolerance(double expected, double actual, double tolerance)
        {
            Assert.True(actual >= expected - tolerance && actual <= expected + tolerance, "Within tolerance: " + tolerance);
        }
    }
}