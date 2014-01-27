// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35.UnitClassTests
{
    [TestFixture]
    public class MassTests : MassTestsBase
    {
        public override double CentigramsInOneKilogram
        {
            get { return 1E5; }
        }

        public override double DecagramsInOneKilogram
        {
            get { return 1E2; }
        }

        public override double DecigramsInOneKilogram
        {
            get { return 1E4; }
        }

        public override double GramsInOneKilogram
        {
            get { return 1E3; }
        }

        public override double HectogramsInOneKilogram
        {
            get { return 10; }
        }

        public override double KilogramsInOneKilogram
        {
            get { return 1; }
        }

        public override double KilotonnesInOneKilogram
        {
            get { return 1E-6; }
        }

        public override double LongTonsInOneKilogram
        {
            get { return 0.000984207; }
        }

        public override double MegatonnesInOneKilogram
        {
            get { return 1E-6; }
        }

        public override double MicrogramsInOneKilogram
        {
            get { return 1E9; }
        }

        public override double MilligramsInOneKilogram
        {
            get { return 1E6; }
        }

        public override double NanogramsInOneKilogram
        {
            get { return 1E12; }
        }

        public override double PoundsInOneKilogram
        {
            get { return 2.2046226218487757d; }
        }

        public override double ShortTonsInOneKilogram
        {
            get { return 0.00110231; }
        }

        public override double TonnesInOneKilogram
        {
            get { return 1E-3; }
        }
    }
}