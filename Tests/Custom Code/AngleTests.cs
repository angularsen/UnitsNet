// Disable build warning CS1718: Comparison made to same variable; did you mean to compare something else?
#pragma warning disable 1718

using System;
using NUnit.Framework;

namespace UnitsNet.Tests.net35.UnitClassTests
{
    [TestFixture]
    public class AngleTests : AngleTestsBase
    {
        public override double DegreesInOneDegree
        {
            get { return 1; }
        }

        public override double GradiansInOneDegree
        {
            get { return 400/360.0; }
        }

        public override double RadiansInOneDegree
        {
            get { return Math.PI/2/90; }
        }
    }
}