// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class FlowTests : FlowTestsBase
    {
        protected override double CubicMetersPerHourInOneCubicMeterPerSecond
        {
            get { return 1/3600.0; }
        }

        protected override double CubicMetersPerSecondInOneCubicMeterPerSecond
        {
            get { return 1; }
        }
    }
}
