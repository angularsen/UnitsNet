// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class VolumeTests : VolumeTestsBase
    {
        protected override double CentilitersInOneCubicMeter
        {
            get { return 1E5; }
        }

        protected override double CubicCentimetersInOneCubicMeter
        {
            get { return 1E6; }
        }

        protected override double CubicDecimetersInOneCubicMeter
        {
            get { return 1E3; }
        }

        protected override double CubicFeetInOneCubicMeter
        {
            get { return 35.31472; }
        }

        protected override double CubicInchesInOneCubicMeter
        {
            get { return 61023.98242; }
        }

        protected override double CubicKilometersInOneCubicMeter
        {
            get { return 1E-9; }
        }

        protected override double CubicMetersInOneCubicMeter
        {
            get { return 1; }
        }

        protected override double CubicMilesInOneCubicMeter
        {
            get { return 3.86102*1E-7; }
        }

        protected override double CubicMillimetersInOneCubicMeter
        {
            get { return 1E9; }
        }

        protected override double CubicYardsInOneCubicMeter
        {
            get { return 1.30795062; }
        }

        protected override double DecilitersInOneCubicMeter
        {
            get { return 1E4; }
        }

        protected override double HectolitersInOneCubicMeter
        {
            get { return 1E1; }
        }

        protected override double ImperialGallonsInOneCubicMeter
        {
            get { return 219.96924; }
        }

        protected override double ImperialOuncesInOneCubicMeter
        {
            get { return 35195.07972; }
        }

        protected override double LitersInOneCubicMeter
        {
            get { return 1E3; }
        }

        protected override double MillilitersInOneCubicMeter
        {
            get { return 1E6; }
        }

        protected override double UsGallonsInOneCubicMeter
        {
            get { return 264.17217; }
        }

        protected override double UsOuncesInOneCubicMeter
        {
            get { return 33814.02270; }
        }
    }
}