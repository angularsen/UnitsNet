// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35.UnitClassTests
{
    [TestFixture]
    public class ForceTests : ForceTestsBase
    {
        public override double DyneInOneNewton
        {
            get { return 1E5; }
        }

        public override double KilogramsForceInOneNewton
        {
            get { return 1/Constants.Gravity; }
        }

        public override double KilonewtonsInOneNewton
        {
            get { return 1E-3; }
        }

        public override double KiloPondsInOneNewton
        {
            get { return 1/Constants.Gravity; }
        }

        public override double NewtonsInOneNewton
        {
            get { return 1; }
        }

        public override double PoundalsInOneNewton
        {
            get { return 7.23301; }
        }

        public override double PoundForcesInOneNewton
        {
            get { return 0.22481; }
        }
    }
}