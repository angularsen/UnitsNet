// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.


using Xunit;

namespace UnitsNet.Tests
{
    public class BrakeSpecificFuelConsumptionTests : BrakeSpecificFuelConsumptionTestsBase
    {
        protected override double GramsPerKiloWattHourInOneKilogramPerJoule => 3600000000;

        protected override double KilogramsPerJouleInOneKilogramPerJoule => 1.0;

        protected override double PoundsPerMechanicalHorsepowerHourInOneKilogramPerJoule => 5918352.5016;

        [Fact]
        public void PowerTimesBrakeSpecificFuelConsumptionEqualsMassFlow()
        {
            MassFlow massFlow = BrakeSpecificFuelConsumption.FromGramsPerKiloWattHour(180.0) * Power.FromKilowatts(20.0 / 24.0 * 1e6 / 180.0);
            AssertEx.EqualTolerance(20.0, massFlow.TonnesPerDay, 1e-11);
        }

        [Fact]
        public void DoubleDividedByBrakeSpecificFuelConsumptionEqualsSpecificEnergy()
        {
            SpecificEnergy massFlow = 2 / BrakeSpecificFuelConsumption.FromKilogramsPerJoule(4);
            Assert.Equal(SpecificEnergy.FromJoulesPerKilogram(0.5), massFlow);
        }

        [Fact]
        public void BrakeSpecificFuelConsumptionTimesSpecificEnergyEqualsEnergy()
        {
            var value = BrakeSpecificFuelConsumption.FromKilogramsPerJoule(20) * SpecificEnergy.FromJoulesPerKilogram(10);
            Assert.Equal(200, value);
        }
    }
}
