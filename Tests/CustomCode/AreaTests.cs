namespace UnitsNet.Tests.net35.UnitClassTests
{
    public class AreaTests : AreaTestsBase
    {
        public override double SquareCentimetersInOneSquareMeter
        {
            get { return 1E4; }
        }

        public override double SquareDecimetersInOneSquareMeter
        {
            get { return 1E2; }
        }

        public override double SquareFeetInOneSquareMeter
        {
            get { return 10.76391; }
        }

        public override double SquareInchesInOneSquareMeter
        {
            get { return 1550.003100; }
        }

        public override double SquareKilometersInOneSquareMeter
        {
            get { return 1E-6; }
        }

        public override double SquareMetersInOneSquareMeter
        {
            get { return 1; }
        }

        public override double SquareMilesInOneSquareMeter
        {
            get { return 3.86102*1E-7; }
        }

        public override double SquareMillimetersInOneSquareMeter
        {
            get { return 1E6; }
        }

        public override double SquareYardsInOneSquareMeter
        {
            get { return 1.19599; }
        }
    }
}