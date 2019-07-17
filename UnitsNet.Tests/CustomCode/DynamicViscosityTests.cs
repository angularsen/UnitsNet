// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.


using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class DynamicViscosityTests : DynamicViscosityTestsBase
    {
        protected override double CentipoiseInOneNewtonSecondPerMeterSquared => 1e3;
        protected override double MicropascalSecondsInOneNewtonSecondPerMeterSquared => 1e6;
        protected override double MillipascalSecondsInOneNewtonSecondPerMeterSquared => 1e3;
        protected override double NewtonSecondsPerMeterSquaredInOneNewtonSecondPerMeterSquared => 1;
        protected override double PascalSecondsInOneNewtonSecondPerMeterSquared => 1;
        protected override double PoiseInOneNewtonSecondPerMeterSquared => 10;
        protected override double ReynsInOneNewtonSecondPerMeterSquared => 1.4503773773020922e-4;
        protected override double PoundsForceSecondPerSquareInchInOneNewtonSecondPerMeterSquared => 1.4503773773020922e-4;
        protected override double PoundsForceSecondPerSquareFootInOneNewtonSecondPerMeterSquared => 2.0885434233150127e-2;

        [Fact]
        public static void DynamicViscosityDividedByDensityEqualsKinematicViscosity()
        {
            KinematicViscosity kinematicViscosity = DynamicViscosity.FromNewtonSecondsPerMeterSquared(10) / Density.FromKilogramsPerCubicMeter(2);
            Assert.Equal(kinematicViscosity, KinematicViscosity.FromSquareMetersPerSecond(5));
        }
    }
}
