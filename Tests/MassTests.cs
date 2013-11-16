// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class MassTests : MassTestsBase
    {
        protected override double CentigramsInOneKilogram
        {
            get { return 1E5; }
        }

        protected override double DecagramsInOneKilogram
        {
            get { return 1E2; }
        }

        protected override double DecigramsInOneKilogram
        {
            get { return 1E4; }
        }

        protected override double GramsInOneKilogram
        {
            get { return 1E3; }
        }

        protected override double HectogramsInOneKilogram
        {
            get { return 10; }
        }

        protected override double KilogramsInOneKilogram
        {
            get { return 1; }
        }

        protected override double KilotonnesInOneKilogram
        {
            get { return 1E-6; }
        }

        protected override double LongTonsInOneKilogram
        {
            get { return 0.000984207; }
        }

        protected override double MegatonnesInOneKilogram
        {
            get { return 1E-6; }
        }

        protected override double MilligramsInOneKilogram
        {
            get { return 1E6; }
        }

        protected override double ShortTonsInOneKilogram
        {
            get { return 0.00110231; }
        }

        protected override double TonnesInOneKilogram
        {
            get { return 1E-3; }
        }
    }
}