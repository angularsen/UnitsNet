// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35.UnitClassTests
{
    [TestFixture]
    public class FlowTests : FlowTestsBase
    {
        public override double CubicMetersPerHourInOneCubicMeterPerSecond
        {
            get { return 1*3600.0; }
        }

        public override double CubicMetersPerSecondInOneCubicMeterPerSecond
        {
            get { return 1; }
        }
    }
}
