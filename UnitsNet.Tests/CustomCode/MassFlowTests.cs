// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class MassFlowTests : MassFlowTestsBase
    {
        /// <inheritdoc />
        protected override double GramsPerSecondInOneGramPerSecond => 1;

        protected override double DecagramsPerSecondInOneGramPerSecond => 1E-1;

        protected override double HectogramsPerSecondInOneGramPerSecond => 1E-2;

        protected override double KilogramsPerHourInOneGramPerSecond => 3.6;

        protected override double TonnesPerHourInOneGramPerSecond => 3.6E-3;

        protected override double KilogramsPerSecondInOneGramPerSecond => 1E-3;

        protected override double MegapoundsPerHourInOneGramPerSecond => 7.93664e-6;

        protected override double DecigramsPerSecondInOneGramPerSecond => 1E1;

        protected override double CentigramsPerSecondInOneGramPerSecond => 1E2;

        protected override double MilligramsPerSecondInOneGramPerSecond => 1E3;

        protected override double MicrogramsPerSecondInOneGramPerSecond => 1E6;

        protected override double NanogramsPerSecondInOneGramPerSecond => 1E9;

        protected override double ShortTonsPerHourInOneGramPerSecond => 3.96832e-3;

        protected override double TonnesPerDayInOneGramPerSecond => 60.0 * 60 * 24 / 1E6;

        protected override double PoundsPerHourInOneGramPerSecond => 7.93664;

        protected override double PoundsPerMinuteInOneGramPerSecond => 0.132277;

        protected override double PoundsPerSecondInOneGramPerSecond => 2.2046226218487758e-3;

        protected override double MegapoundsPerMinuteInOneGramPerSecond => 0.132277e-6;

        protected override double MegapoundsPerSecondInOneGramPerSecond => 2.2046226218487758e-9;

        protected override double KilogramsPerMinuteInOneGramPerSecond => 0.06;

        protected override double CentigramsPerDayInOneGramPerSecond => 8.64e+6;

        protected override double DecagramsPerDayInOneGramPerSecond => 8.64e3;

        protected override double DecigramsPerDayInOneGramPerSecond => 8.64e5;

        protected override double GramsPerDayInOneGramPerSecond => 8.64e4;

        protected override double HectogramsPerDayInOneGramPerSecond => 8.64e2;

        protected override double KilogramsPerDayInOneGramPerSecond => 8.64e1;

        protected override double MegagramsPerDayInOneGramPerSecond => 8.64e-2;

        protected override double MegapoundsPerDayInOneGramPerSecond => 1.90479395e-4;

        protected override double MicrogramsPerDayInOneGramPerSecond => 8.64e+10;

        protected override double MilligramsPerDayInOneGramPerSecond => 8.64e+7;

        protected override double NanogramsPerDayInOneGramPerSecond => 8.64e+13;

        protected override double PoundsPerDayInOneGramPerSecond => 1.9047936e2;

        protected override double GramsPerHourInOneGramPerSecond => 3600;


        [Fact]
        public void DurationTimesMassFlowEqualsMass()
        {
            Mass mass = Duration.FromSeconds(4.0) * MassFlow.FromKilogramsPerSecond(20.0);
            Assert.Equal(mass, Mass.FromKilograms(80.0));
        }

        [Fact]
        public void MassFlowTimesDurationEqualsMass()
        {
            Mass mass = MassFlow.FromKilogramsPerSecond(20.0) * Duration.FromSeconds(4.0);
            Assert.Equal(mass, Mass.FromKilograms(80.0));
        }

        [Fact]
        public void MassFlowTimesTimeSpanEqualsMass()
        {
            Mass mass = MassFlow.FromKilogramsPerSecond(20.0) * TimeSpan.FromSeconds(4.0);
            Assert.Equal(mass, Mass.FromKilograms(80.0));
        }

        [Fact]
        public void TimeSpanTimesMassFlowEqualsMass()
        {
            Mass mass = TimeSpan.FromSeconds(4.0) * MassFlow.FromKilogramsPerSecond(20.0);
            Assert.Equal(mass, Mass.FromKilograms(80.0));
        }

        [Fact]
        public void MassFlowDividedByBrakeSpecificFuelConsumptionEqualsPower()
        {
            Power power = MassFlow.FromTonnesPerDay(20) / BrakeSpecificFuelConsumption.FromGramsPerKiloWattHour(180.0);
            Assert.Equal(20.0 / 24.0 * 1e6 / 180.0, power.Kilowatts);
        }

        [Fact]
        public void MassFlowDividedByPowerEqualsBrakeSpecificFuelConsumption()
        {
            BrakeSpecificFuelConsumption bsfc = MassFlow.FromTonnesPerDay(20) / Power.FromKilowatts(20.0 / 24.0 * 1e6 / 180.0);
            AssertEx.EqualTolerance(180.0, bsfc.GramsPerKiloWattHour, 1e-11);
        }

        [Fact]
        public void MassFlowTimesSpecificEnergyEqualsPower()
        {
            Power power = MassFlow.FromKilogramsPerSecond(20.0) * SpecificEnergy.FromJoulesPerKilogram(10.0);
            Assert.Equal(200, power.Watts);
        }

        [Fact]
        public void MassFlowDividedByAreaEqualsMassFlux()
        {
            MassFlux massFlux = MassFlow.FromKilogramsPerSecond(20) / Area.FromSquareMeters(2);
            Assert.Equal(10, massFlux.KilogramsPerSecondPerSquareMeter);
        }

        [Fact]
        public void MassFlowDividedByMassFluxEqualsArea()
        {
            Area area = MassFlow.FromKilogramsPerSecond(20) / MassFlux.FromKilogramsPerSecondPerSquareMeter(2);
            Assert.Equal(10, area.SquareMeters);
        }

        [Fact]
        public void MassFlowDividedByVolumeFlowEqualsDensity()
        {
            Density density = MassFlow.FromKilogramsPerSecond(12) / VolumeFlow.FromCubicMetersPerSecond(3);
            Assert.Equal(4, density.KilogramsPerCubicMeter);
        }

        [Fact]
        public void MassFlowDividedByDensityEqualsVolumeFlow()
        {
            VolumeFlow volumeFlow = MassFlow.FromKilogramsPerSecond(20) / Density.FromKilogramsPerCubicMeter(4);
            Assert.Equal(5, volumeFlow.CubicMetersPerSecond);
        }
    }
}
