﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated (once) by \generate-code.bat, but will not be
//     regenerated when it already exists. The purpose of creating this file is to make
//     it easier to remember to implement all the unit conversion test cases.
//
//     Whenever a new unit is added to this unit class and \generate-code.bat is run,
//     the base test class will get a new abstract property and cause a compile error
//     in this derived class, reminding the developer to implement the test case
//     for the new unit.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\UnitClasses\MyQuantity.extra.cs files to add code to generated unit classes.
//     Add UnitDefinitions\MyQuantity.json and run GeneratUnits.bat to generate new units or unit classes.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.


using Xunit;
using System;

namespace UnitsNet.Tests.CustomCode
{
    public class MolarityTests : MolarityTestsBase
    {
        #region Unit Conversion Coefficients
        protected override double CentimolesPerLiterInOneMolesPerCubicMeter => 1e-1;
        protected override double DecimolesPerLiterInOneMolesPerCubicMeter => 1e-2;
        protected override double MolesPerLiterInOneMolesPerCubicMeter => 1e-3;
        protected override double MillimolesPerLiterInOneMolesPerCubicMeter => 1;
        protected override double MolesPerCubicMeterInOneMolesPerCubicMeter => 1;
        protected override double MicromolesPerLiterInOneMolesPerCubicMeter => 1e3;
        protected override double NanomolesPerLiterInOneMolesPerCubicMeter => 1e6;
        protected override double PicomolesPerLiterInOneMolesPerCubicMeter => 1e9;
        #endregion

        private const double MolarMassHClInGramsPerMole = 36.46;
        
        private const double MolarMassOfEthanolInGramsPerMole = 46.06844;
        private const double DensityOfEthanolInKgPerCubicMeter = 789;

        [Fact]
        public void ExpectMassConcentrationConvertedToMolarityCorrectly()
        {
            var massConcentration = MassConcentration.FromKilogramsPerCubicMeter(60.02); // used to be Density
            var molarMass = MolarMass.FromGramsPerMole(58.443); // used to be Mass

            Molarity molarity = massConcentration / molarMass;
            AssertEx.EqualTolerance(1026.98355, molarity.MolesPerCubicMeter, MolesPerCubicMeterTolerance);
        }

        [Fact]
        public void ExpectMolarityConvertedToMassConcentrationCorrectly()
        {
            var molarity = Molarity.FromMolesPerLiter(1.02698355);
            var molarMass = MolarMass.FromGramsPerMole(58.443);

            MassConcentration concentration = molarity.ToMassConcentration(molarMass);  // molarity * molarMass
            AssertEx.EqualTolerance(60.02, concentration.KilogramsPerCubicMeter, MolesPerCubicMeterTolerance);
        }

        [Fact]
        public void HClSolutionMolarityIsEqualToExpected()
        {
            const double MassOfSubstanceInGrams = 5;
            const double VolumeOfSolutionInLiters = 1.2;
            const double ExpectedMolarityMolesPerLiter = 0.1142805; // molarity = 5 / (1.2 * 36.46) = 0.114 mol/l = 0.114 M
            // same test is performed in AmountOfSubstanceTests
            var molarMass = MolarMass.FromGramsPerMole(MolarMassHClInGramsPerMole);
            var substanceMass = Mass.FromGrams(MassOfSubstanceInGrams);
            var volumeSolution = Volume.FromLiters(VolumeOfSolutionInLiters);
            AmountOfSubstance amountOfSubstance = substanceMass / molarMass;

            Molarity molarity = amountOfSubstance / volumeSolution;
            AssertEx.EqualTolerance(ExpectedMolarityMolesPerLiter, molarity.MolesPerLiter, MolesPerLiterTolerance);
        }

        [Fact]
        public void HClSolutionConcentrationIsEqualToExpected()
        {
            const double ExpectedMolarityMolesPerLiter = 0.1142805; // molarity = 5 / (1.2 * 36.46) = 0.114 mol/l = 0.114 M
            const double ExpectedConcentrationInKgPerCubicMeter = 4.16667;
            var molarMass = MolarMass.FromGramsPerMole(MolarMassHClInGramsPerMole);
            var molarity = Molarity.FromMolesPerLiter(ExpectedMolarityMolesPerLiter);

            MassConcentration concentration = molarity * molarMass;
            AssertEx.EqualTolerance(ExpectedConcentrationInKgPerCubicMeter, concentration.KilogramsPerCubicMeter, MolesPerLiterTolerance);
        }

        [Fact]
        public void TenPercentHClSolutionMolarityIsEqualToExpected()
        {
            const double ExpectedMolarityMolesPerLiter = 0.1142805; // molarity = 5 / (1.2 * 36.46) = 0.114 mol/l = 0.114 M
            var originalMolarity = Molarity.FromMolesPerLiter(ExpectedMolarityMolesPerLiter);

            Molarity tenPercentMolarity = originalMolarity * VolumeConcentration.FromPercent(10);
            AssertEx.EqualTolerance(ExpectedMolarityMolesPerLiter / 10, tenPercentMolarity.MolesPerLiter, MolesPerLiterTolerance);
        }

        [Fact]
        public void MolarityFromVolumeConcentrationEthanol()
        {
            const double VolumeConcentration_0_5M_Ethanol = 29.19419518377693;
            var density = Density.FromKilogramsPerCubicMeter(DensityOfEthanolInKgPerCubicMeter);
            var molarMass = MolarMass.FromGramsPerMole(MolarMassOfEthanolInGramsPerMole);
            var volumeConcentration = VolumeConcentration.FromMillilitersPerLiter(VolumeConcentration_0_5M_Ethanol);

            Molarity molarity = volumeConcentration.ToMolarity(density, molarMass); // volumeConcentration * density / molarMass
            AssertEx.EqualTolerance(0.5, molarity.MolesPerLiter, MolesPerCubicMeterTolerance);
        }

        [Fact]
        public void OneMolarFromStringParsedCorrectly()
        {
            Assert.Equal(Molarity.Parse("1M"), Molarity.Parse("1 mol/L"));
        }

        [Fact(Skip = "Awaiting fix for https://github.com/angularsen/UnitsNet/issues/344")]
        public void OneMilliMolarFromStringParsedCorrectly()
        {
            var one_mM = Molarity.Parse("1000 mM");
            Assert.Equal(1, one_mM.MolesPerLiter);
        }

    }

}
