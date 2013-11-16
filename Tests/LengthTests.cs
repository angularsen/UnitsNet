// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?

#pragma warning disable 1718

using NUnit.Framework;
using System;

namespace UnitsNet.Tests.net35
{
    [TestFixture]
    public class LengthTests : LengthTestsBase
    {
        protected override double Delta
        {
            get { return 1E-5; }
        }

        protected override double CentimetersInOneMeter
        {
            get { return 100; }
        }

        protected override double DecimetersInOneMeter
        {
            get { return 10; }
        }

        protected override double FeetInOneMeter
        {
            get { return 3.28084; }
        }

        protected override double InchesInOneMeter
        {
                get { return 39.37007874; }
        }

        protected override double KilometersInOneMeter
        {
            get { return 1E-3; }
        }

        protected override double MetersInOneMeter
        {
            get { return 1; }
        }

        protected override double MicroinchesInOneMeter
        {
            get { return 39370078.74015748; }
        }

        protected override double MicrometersInOneMeter
        {
            get { return 1E6; }
        }

        protected override double MilsInOneMeter
        {
            get { return 39370.07874015; }
        }

        protected override double MilesInOneMeter
        {
            get { return 0.000621371; }
        }

        protected override double MillimetersInOneMeter
        {
            get { return 1E3; }
        }

        protected override double NanometersInOneMeter
        {
            get { return 1E9; }
        }

        protected override double YardsInOneMeter
        {
            get { return 1.09361; }
        }
    }
}