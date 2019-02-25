// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class TorqueTests : TorqueTestsBase
    {
        protected override double KilogramForceCentimetersInOneNewtonMeter => 10.1971621;

        protected override double KilogramForceMetersInOneNewtonMeter => 0.101971621;

        protected override double KilogramForceMillimetersInOneNewtonMeter => 101.971621;

        protected override double MeganewtonCentimetersInOneNewtonMeter => 1E-4;

        protected override double KilonewtonCentimetersInOneNewtonMeter => 0.1;

        protected override double MeganewtonMetersInOneNewtonMeter => 1E-6;

        protected override double KilonewtonMetersInOneNewtonMeter => 0.001;

        protected override double MeganewtonMillimetersInOneNewtonMeter => 1E-3;

        protected override double KilonewtonMillimetersInOneNewtonMeter => 1;

        protected override double MegapoundForceFeetInOneNewtonMeter => 7.375621492772654e-7;

        protected override double KilopoundForceFeetInOneNewtonMeter => 7.375621492772654e-4;

        protected override double MegapoundForceInchesInOneNewtonMeter => 8.850745791327184e-6;

        protected override double KilopoundForceInchesInOneNewtonMeter => 8.850745791327184e-3;

        protected override double NewtonCentimetersInOneNewtonMeter => 100;

        protected override double NewtonMetersInOneNewtonMeter => 1;

        protected override double NewtonMillimetersInOneNewtonMeter => 1000;

        protected override double PoundForceFeetInOneNewtonMeter => 0.737562149277;

        protected override double PoundForceInchesInOneNewtonMeter => 8.85074579;

        protected override double TonneForceCentimetersInOneNewtonMeter => 1.01972e-2;

        protected override double TonneForceMetersInOneNewtonMeter => 1.01972e-4;

        protected override double TonneForceMillimetersInOneNewtonMeter => 1.01972e-1;

        [Fact]
        public void TorqueDividedByForceEqualsLength()
        {
            Length length = Torque.FromNewtonMeters(4)/Force.FromNewtons(2);
            Assert.Equal(length, Length.FromMeters(2));
        }

        [Fact]
        public void TorqueDividedByLengthEqualsForce()
        {
            Force force = Torque.FromNewtonMeters(4)/Length.FromMeters(2);
            Assert.Equal(force, Force.FromNewtons(2));
        }
    }
}
