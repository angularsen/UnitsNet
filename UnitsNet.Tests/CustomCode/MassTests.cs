// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;
using Xunit;

namespace UnitsNet.Tests.CustomCode
{
    public class MassTests : MassTestsBase
    {
        protected override double CentigramsInOneKilogram => 1E5;

        protected override double DecagramsInOneKilogram => 1E2;

        protected override double DecigramsInOneKilogram => 1E4;

        protected override double GrainsInOneKilogram => 15432.358352941431d;

        protected override double GramsInOneKilogram => 1E3;

        protected override double HectogramsInOneKilogram => 10;

        protected override double KilogramsInOneKilogram => 1;

        protected override double KilopoundsInOneKilogram => 2.2046226218487757e-3;

        protected override double KilotonnesInOneKilogram => 1E-6;

        protected override double LongTonsInOneKilogram => 9.842065276110606e-4;

        protected override double MegapoundsInOneKilogram => 2.2046226218487757e-6;

        protected override double MegatonnesInOneKilogram => 1E-9;

        protected override double MicrogramsInOneKilogram => 1E9;

        protected override double MilligramsInOneKilogram => 1E6;

        protected override double NanogramsInOneKilogram => 1E12;

        protected override double NanogramsTolerance => 1E-3;

        protected override double OuncesInOneKilogram => 35.2739619;

        protected override double PoundsInOneKilogram => 2.2046226218487757d;

        protected override double ShortTonsInOneKilogram => 1.102311310924388e-3;

        protected override double SlugsInOneKilogram => 6.852176556196105e-2;

        protected override double StoneInOneKilogram => 0.1574731728702698;

        protected override double TonnesInOneKilogram => 1E-3;

        protected override double LongHundredweightInOneKilogram => 0.01968413055222121;

        protected override double ShortHundredweightInOneKilogram => 0.022046226218487758;

        protected override double EarthMassesInOneKilogram => 1.6744248350691500000000000E-25;

        protected override double SolarMassesInOneKilogram => 5.0264643347223100000000000E-31;

        //protected override double SolarMassesTolerance => 0.1;

        [Fact]
        public void AccelerationTimesMassEqualsForce()
        {
            Force force = Acceleration.FromMetersPerSecondSquared(3)*Mass.FromKilograms(18);
            Assert.Equal(force, Force.FromNewtons(54));
        }

        [Fact]
        public void MassDividedByDurationEqualsMassFlow()
        {
            MassFlow massFlow = Mass.FromKilograms(18.0)/Duration.FromSeconds(6);
            Assert.Equal(massFlow, MassFlow.FromKilogramsPerSecond(3.0));
        }

        [Fact]
        public void MassDividedByTimeSpanEqualsMassFlow()
        {
            MassFlow massFlow = Mass.FromKilograms(18.0)/TimeSpan.FromSeconds(6);
            Assert.Equal(massFlow, MassFlow.FromKilogramsPerSecond(3.0));
        }

        [Fact]
        public void MassDividedByVolumeEqualsDensity()
        {
            Density density = Mass.FromKilograms(18)/Volume.FromCubicMeters(3);
            Assert.Equal(density, Density.FromKilogramsPerCubicMeter(6));
        }

        [Fact]
        public void MassTimesAccelerationEqualsForce()
        {
            Force force = Mass.FromKilograms(18)*Acceleration.FromMetersPerSecondSquared(3);
            Assert.Equal(force, Force.FromNewtons(54));
        }

        [Fact]
        public void NegativeMassToStonePoundsReturnsCorrectValues()
        {
            var negativeMass = Mass.FromPounds(-1.0);
            var stonePounds = negativeMass.StonePounds;

            Assert.Equal(0, stonePounds.Stone);
            Assert.Equal(-1.0, stonePounds.Pounds);

            negativeMass = Mass.FromPounds(-25.0);
            stonePounds = negativeMass.StonePounds;

            Assert.Equal(-1.0, stonePounds.Stone);
            Assert.Equal(-11.0, stonePounds.Pounds);
        }

        [Theory]
        [InlineData(10, MassUnit.Gram,
                    KnownQuantities.MolarMassOfOxygen, MolarMassUnit.GramPerMole,
                    0.625023438378939, AmountOfSubstanceUnit.Mole)]     // 10 grams Of Oxygen contain 0.625023438378939 Moles
        public void AmountOfSubstanceFromMassAndMolarMass(
            double massValue, MassUnit massUnit,
            double molarMassValue, MolarMassUnit molarMassUnit,
            double expectedAmountOfSubstanceValue, AmountOfSubstanceUnit expectedAmountOfSubstanceUnit, double tolerence = 1e-5)
        {
            var mass = new Mass(massValue, massUnit);
            var molarMass = new MolarMass(molarMassValue, molarMassUnit);

            AmountOfSubstance amountOfSubstance = mass / molarMass;

            AssertEx.EqualTolerance(expectedAmountOfSubstanceValue, amountOfSubstance.As(expectedAmountOfSubstanceUnit), tolerence);
        }
    }
}
