// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using NUnit.Framework;

namespace UnitsNet.Tests.net35.UnitClassTests
{
    [TestFixture]
    public class ForceTests : ForceTestsBase
    {
        protected override double DyneInOneNewton
        {
            get { return 1E5; }
        }

        protected override double KilogramsForceInOneNewton
        {
            get { return 1/Constants.Gravity; }
        }

        protected override double KilonewtonsInOneNewton
        {
            get { return 1E-3; }
        }

        protected override double KiloPondsInOneNewton
        {
            get { return 1/Constants.Gravity; }
        }

        protected override double NewtonsInOneNewton
        {
            get { return 1; }
        }

        protected override double PoundalsInOneNewton
        {
            get { return 7.23301; }
        }

        protected override double PoundForcesInOneNewton
        {
            get { return 0.22481; }
        }
    }
}