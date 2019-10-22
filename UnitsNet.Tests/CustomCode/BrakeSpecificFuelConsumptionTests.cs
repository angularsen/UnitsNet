// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.


using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class BrakeSpecificFuelConsumptionTests : BrakeSpecificFuelConsumptionTestsBase
    {
        protected override double GramsPerKiloWattHourInOneKilogramPerJoule => 3600000000;

        protected override double KilogramsPerJouleInOneKilogramPerJoule => 1.0;

        protected override double PoundsPerMechanicalHorsepowerHourInOneKilogramPerJoule => 5918352.5016;

        [Fact]
        public void PowerTimesBrakeSpecificFuelConsumptionEqualsMassFlow()
        {
            var massFlow = BrakeSpecificFuelConsumption<double>.FromGramsPerKiloWattHour(180.0) * Power<double>.FromKilowatts(20.0 / 24.0 * 1e6 / 180.0);
            AssertEx.EqualTolerance(20.0, massFlow.TonnesPerDay, 1e-11);
        }

        [Fact]
        public void DoubleDividedByBrakeSpecificFuelConsumptionEqualsSpecificEnergy()
        {
            var specificEnergy = 2.0 / BrakeSpecificFuelConsumption<double>.FromKilogramsPerJoule(4.0);
            Assert.Equal(SpecificEnergy<double>.FromJoulesPerKilogram(0.5), specificEnergy);
        }

        [Fact]
        public void BrakeSpecificFuelConsumptionTimesSpecificEnergyEqualsEnergy()
        {
            double value = BrakeSpecificFuelConsumption<double>.FromKilogramsPerJoule(20.0) * SpecificEnergy<double>.FromJoulesPerKilogram(10.0);
            Assert.Equal(200.0, value);
        }
    }
}
