// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class AreaTests : AreaTestsBase
    {
        protected override double SquareCentimetersInOneSquareMeter
        {
            get { return 1E4; }
        }

        protected override double SquareDecimetersInOneSquareMeter
        {
            get { return 1E2; }
        }

        protected override double SquareFeetInOneSquareMeter
        {
            get { return 10.76391; }
        }

        protected override double SquareInchesInOneSquareMeter
        {
            get { return 1550.003100; }
        }

        protected override double SquareKilometersInOneSquareMeter
        {
            get { return 1E-6; }
        }

        protected override double SquareMetersInOneSquareMeter
        {
            get { return 1; }
        }

        protected override double SquareMilesInOneSquareMeter
        {
            get { return 3.86102*1E-7; }
        }

        protected override double SquareMillimetersInOneSquareMeter
        {
            get { return 1E6; }
        }

        protected override double SquareYardsInOneSquareMeter
        {
            get { return 1.19599; }
        }
    }
}