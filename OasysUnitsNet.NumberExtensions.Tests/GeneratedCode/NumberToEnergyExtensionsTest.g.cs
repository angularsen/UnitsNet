//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by \generate-code.bat.
//
//     Changes to this file will be lost when the code is regenerated.
//     The build server regenerates the code before each build and a pre-build
//     step will regenerate the code on each local build.
//
//     See https://github.com/angularsen/UnitsNet/wiki/Adding-a-New-Unit for how to add or edit units.
//
//     Add CustomCode\Quantities\MyQuantity.extra.cs files to add code to generated quantities.
//     Add UnitDefinitions\MyQuantity.json and run generate-code.bat to generate new units or quantities.
//
// </auto-generated>
//------------------------------------------------------------------------------

// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using OasysUnitsNet.NumberExtensions.NumberToEnergy;
using Xunit;

namespace OasysUnitsNet.Tests
{
    public class NumberToEnergyExtensionsTests
    {
        [Fact]
        public void NumberToBritishThermalUnitsTest() =>
            Assert.Equal(Energy.FromBritishThermalUnits(2), 2.BritishThermalUnits());

        [Fact]
        public void NumberToCaloriesTest() =>
            Assert.Equal(Energy.FromCalories(2), 2.Calories());

        [Fact]
        public void NumberToDecathermsEcTest() =>
            Assert.Equal(Energy.FromDecathermsEc(2), 2.DecathermsEc());

        [Fact]
        public void NumberToDecathermsImperialTest() =>
            Assert.Equal(Energy.FromDecathermsImperial(2), 2.DecathermsImperial());

        [Fact]
        public void NumberToDecathermsUsTest() =>
            Assert.Equal(Energy.FromDecathermsUs(2), 2.DecathermsUs());

        [Fact]
        public void NumberToElectronVoltsTest() =>
            Assert.Equal(Energy.FromElectronVolts(2), 2.ElectronVolts());

        [Fact]
        public void NumberToErgsTest() =>
            Assert.Equal(Energy.FromErgs(2), 2.Ergs());

        [Fact]
        public void NumberToFootPoundsTest() =>
            Assert.Equal(Energy.FromFootPounds(2), 2.FootPounds());

        [Fact]
        public void NumberToGigabritishThermalUnitsTest() =>
            Assert.Equal(Energy.FromGigabritishThermalUnits(2), 2.GigabritishThermalUnits());

        [Fact]
        public void NumberToGigaelectronVoltsTest() =>
            Assert.Equal(Energy.FromGigaelectronVolts(2), 2.GigaelectronVolts());

        [Fact]
        public void NumberToGigajoulesTest() =>
            Assert.Equal(Energy.FromGigajoules(2), 2.Gigajoules());

        [Fact]
        public void NumberToGigawattDaysTest() =>
            Assert.Equal(Energy.FromGigawattDays(2), 2.GigawattDays());

        [Fact]
        public void NumberToGigawattHoursTest() =>
            Assert.Equal(Energy.FromGigawattHours(2), 2.GigawattHours());

        [Fact]
        public void NumberToHorsepowerHoursTest() =>
            Assert.Equal(Energy.FromHorsepowerHours(2), 2.HorsepowerHours());

        [Fact]
        public void NumberToJoulesTest() =>
            Assert.Equal(Energy.FromJoules(2), 2.Joules());

        [Fact]
        public void NumberToKilobritishThermalUnitsTest() =>
            Assert.Equal(Energy.FromKilobritishThermalUnits(2), 2.KilobritishThermalUnits());

        [Fact]
        public void NumberToKilocaloriesTest() =>
            Assert.Equal(Energy.FromKilocalories(2), 2.Kilocalories());

        [Fact]
        public void NumberToKiloelectronVoltsTest() =>
            Assert.Equal(Energy.FromKiloelectronVolts(2), 2.KiloelectronVolts());

        [Fact]
        public void NumberToKilojoulesTest() =>
            Assert.Equal(Energy.FromKilojoules(2), 2.Kilojoules());

        [Fact]
        public void NumberToKilowattDaysTest() =>
            Assert.Equal(Energy.FromKilowattDays(2), 2.KilowattDays());

        [Fact]
        public void NumberToKilowattHoursTest() =>
            Assert.Equal(Energy.FromKilowattHours(2), 2.KilowattHours());

        [Fact]
        public void NumberToMegabritishThermalUnitsTest() =>
            Assert.Equal(Energy.FromMegabritishThermalUnits(2), 2.MegabritishThermalUnits());

        [Fact]
        public void NumberToMegacaloriesTest() =>
            Assert.Equal(Energy.FromMegacalories(2), 2.Megacalories());

        [Fact]
        public void NumberToMegaelectronVoltsTest() =>
            Assert.Equal(Energy.FromMegaelectronVolts(2), 2.MegaelectronVolts());

        [Fact]
        public void NumberToMegajoulesTest() =>
            Assert.Equal(Energy.FromMegajoules(2), 2.Megajoules());

        [Fact]
        public void NumberToMegawattDaysTest() =>
            Assert.Equal(Energy.FromMegawattDays(2), 2.MegawattDays());

        [Fact]
        public void NumberToMegawattHoursTest() =>
            Assert.Equal(Energy.FromMegawattHours(2), 2.MegawattHours());

        [Fact]
        public void NumberToMillijoulesTest() =>
            Assert.Equal(Energy.FromMillijoules(2), 2.Millijoules());

        [Fact]
        public void NumberToTeraelectronVoltsTest() =>
            Assert.Equal(Energy.FromTeraelectronVolts(2), 2.TeraelectronVolts());

        [Fact]
        public void NumberToTerawattDaysTest() =>
            Assert.Equal(Energy.FromTerawattDays(2), 2.TerawattDays());

        [Fact]
        public void NumberToTerawattHoursTest() =>
            Assert.Equal(Energy.FromTerawattHours(2), 2.TerawattHours());

        [Fact]
        public void NumberToThermsEcTest() =>
            Assert.Equal(Energy.FromThermsEc(2), 2.ThermsEc());

        [Fact]
        public void NumberToThermsImperialTest() =>
            Assert.Equal(Energy.FromThermsImperial(2), 2.ThermsImperial());

        [Fact]
        public void NumberToThermsUsTest() =>
            Assert.Equal(Energy.FromThermsUs(2), 2.ThermsUs());

        [Fact]
        public void NumberToWattDaysTest() =>
            Assert.Equal(Energy.FromWattDays(2), 2.WattDays());

        [Fact]
        public void NumberToWattHoursTest() =>
            Assert.Equal(Energy.FromWattHours(2), 2.WattHours());

    }
}
