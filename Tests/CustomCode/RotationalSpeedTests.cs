namespace UnitsNet.Tests.net35.UnitClassTests
{
    public class RotationalSpeedTests : RotationalSpeedTestsBase
    {
        public override double RevolutionsPerMinuteInOneRevolutionPerSecond
        {
            get { return 1.0*60; }
        }

        public override double RevolutionsPerSecondInOneRevolutionPerSecond
        {
            get { return 1; }
        }
    }
}
