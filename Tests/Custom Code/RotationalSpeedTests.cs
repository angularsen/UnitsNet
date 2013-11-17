// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35.UnitClassTests
{
    [TestFixture]
    public class RotationalSpeedTests : RotationalSpeedTestsBase
    {
        public override double RevolutionsPerMinuteInOneRevolutionPerSecond
        {
            get { return 1.0/60; }
        }

        public override double RevolutionsPerSecondInOneRevolutionPerSecond
        {
            get { return 1; }
        }
    }
}
