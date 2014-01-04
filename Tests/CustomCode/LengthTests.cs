namespace UnitsNet.Tests.net35.UnitClassTests
{
    public class LengthTests : LengthTestsBase
    {
        public override double CentimetersInOneMeter
        {
            get { return 100; }
        }

        public override double DecimetersInOneMeter
        {
            get { return 10; }
        }

        public override double FeetInOneMeter
        {
            get { return 3.28084; }
        }

        public override double InchesInOneMeter
        {
                get { return 39.37007874; }
        }

        public override double KilometersInOneMeter
        {
            get { return 1E-3; }
        }

        public override double MetersInOneMeter
        {
            get { return 1; }
        }

        public override double MicroinchesInOneMeter
        {
            get { return 39370078.74015748; }
        }

        public override double MicrometersInOneMeter
        {
            get { return 1E6; }
        }

        public override double MilsInOneMeter
        {
            get { return 39370.07874015; }
        }

        public override double MilesInOneMeter
        {
            get { return 0.000621371; }
        }

        public override double MillimetersInOneMeter
        {
            get { return 1E3; }
        }

        public override double NanometersInOneMeter
        {
            get { return 1E9; }
        }

        public override double YardsInOneMeter
        {
            get { return 1.09361; }
        }
    }
}