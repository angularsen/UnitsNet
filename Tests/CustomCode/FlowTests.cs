namespace UnitsNet.Tests.net35.CustomCode
{
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
