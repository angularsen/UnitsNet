using System;

namespace UnitsNet.Tests.net35.CustomCode
{
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