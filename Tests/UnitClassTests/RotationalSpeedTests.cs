// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35.UnitClassTests
{
    [TestFixture]
    public class RotationalSpeedTests : RotationalSpeedTestsBase
    {
        protected override double RevolutionsPerMinuteInOneRevolutionPerSecond
        {
            get { return 1.0/60; }
        }

        protected override double RevolutionsPerSecondInOneRevolutionPerSecond
        {
            get { return 1; }
        }
    }
}
