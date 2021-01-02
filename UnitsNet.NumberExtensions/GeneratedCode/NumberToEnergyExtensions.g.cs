﻿//------------------------------------------------------------------------------
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

using System;

#nullable enable

namespace UnitsNet.NumberExtensions.NumberToEnergy
{
    /// <summary>
    /// A number to Energy Extensions
    /// </summary>
    public static class NumberToEnergyExtensions
    {
        /// <inheritdoc cref="Energy{T}.FromBritishThermalUnits(T)" />
        public static Energy<double> BritishThermalUnits<T>(this T value) =>
            Energy<double>.FromBritishThermalUnits(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromCalories(T)" />
        public static Energy<double> Calories<T>(this T value) =>
            Energy<double>.FromCalories(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromDecathermsEc(T)" />
        public static Energy<double> DecathermsEc<T>(this T value) =>
            Energy<double>.FromDecathermsEc(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromDecathermsImperial(T)" />
        public static Energy<double> DecathermsImperial<T>(this T value) =>
            Energy<double>.FromDecathermsImperial(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromDecathermsUs(T)" />
        public static Energy<double> DecathermsUs<T>(this T value) =>
            Energy<double>.FromDecathermsUs(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromElectronVolts(T)" />
        public static Energy<double> ElectronVolts<T>(this T value) =>
            Energy<double>.FromElectronVolts(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromErgs(T)" />
        public static Energy<double> Ergs<T>(this T value) =>
            Energy<double>.FromErgs(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromFootPounds(T)" />
        public static Energy<double> FootPounds<T>(this T value) =>
            Energy<double>.FromFootPounds(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromGigabritishThermalUnits(T)" />
        public static Energy<double> GigabritishThermalUnits<T>(this T value) =>
            Energy<double>.FromGigabritishThermalUnits(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromGigaelectronVolts(T)" />
        public static Energy<double> GigaelectronVolts<T>(this T value) =>
            Energy<double>.FromGigaelectronVolts(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromGigajoules(T)" />
        public static Energy<double> Gigajoules<T>(this T value) =>
            Energy<double>.FromGigajoules(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromGigawattDays(T)" />
        public static Energy<double> GigawattDays<T>(this T value) =>
            Energy<double>.FromGigawattDays(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromGigawattHours(T)" />
        public static Energy<double> GigawattHours<T>(this T value) =>
            Energy<double>.FromGigawattHours(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromHorsepowerHours(T)" />
        public static Energy<double> HorsepowerHours<T>(this T value) =>
            Energy<double>.FromHorsepowerHours(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromJoules(T)" />
        public static Energy<double> Joules<T>(this T value) =>
            Energy<double>.FromJoules(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromKilobritishThermalUnits(T)" />
        public static Energy<double> KilobritishThermalUnits<T>(this T value) =>
            Energy<double>.FromKilobritishThermalUnits(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromKilocalories(T)" />
        public static Energy<double> Kilocalories<T>(this T value) =>
            Energy<double>.FromKilocalories(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromKiloelectronVolts(T)" />
        public static Energy<double> KiloelectronVolts<T>(this T value) =>
            Energy<double>.FromKiloelectronVolts(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromKilojoules(T)" />
        public static Energy<double> Kilojoules<T>(this T value) =>
            Energy<double>.FromKilojoules(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromKilowattDays(T)" />
        public static Energy<double> KilowattDays<T>(this T value) =>
            Energy<double>.FromKilowattDays(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromKilowattHours(T)" />
        public static Energy<double> KilowattHours<T>(this T value) =>
            Energy<double>.FromKilowattHours(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromMegabritishThermalUnits(T)" />
        public static Energy<double> MegabritishThermalUnits<T>(this T value) =>
            Energy<double>.FromMegabritishThermalUnits(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromMegacalories(T)" />
        public static Energy<double> Megacalories<T>(this T value) =>
            Energy<double>.FromMegacalories(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromMegaelectronVolts(T)" />
        public static Energy<double> MegaelectronVolts<T>(this T value) =>
            Energy<double>.FromMegaelectronVolts(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromMegajoules(T)" />
        public static Energy<double> Megajoules<T>(this T value) =>
            Energy<double>.FromMegajoules(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromMegawattDays(T)" />
        public static Energy<double> MegawattDays<T>(this T value) =>
            Energy<double>.FromMegawattDays(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromMegawattHours(T)" />
        public static Energy<double> MegawattHours<T>(this T value) =>
            Energy<double>.FromMegawattHours(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromMillijoules(T)" />
        public static Energy<double> Millijoules<T>(this T value) =>
            Energy<double>.FromMillijoules(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromTeraelectronVolts(T)" />
        public static Energy<double> TeraelectronVolts<T>(this T value) =>
            Energy<double>.FromTeraelectronVolts(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromTerawattDays(T)" />
        public static Energy<double> TerawattDays<T>(this T value) =>
            Energy<double>.FromTerawattDays(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromTerawattHours(T)" />
        public static Energy<double> TerawattHours<T>(this T value) =>
            Energy<double>.FromTerawattHours(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromThermsEc(T)" />
        public static Energy<double> ThermsEc<T>(this T value) =>
            Energy<double>.FromThermsEc(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromThermsImperial(T)" />
        public static Energy<double> ThermsImperial<T>(this T value) =>
            Energy<double>.FromThermsImperial(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromThermsUs(T)" />
        public static Energy<double> ThermsUs<T>(this T value) =>
            Energy<double>.FromThermsUs(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromWattDays(T)" />
        public static Energy<double> WattDays<T>(this T value) =>
            Energy<double>.FromWattDays(Convert.ToDouble(value));

        /// <inheritdoc cref="Energy{T}.FromWattHours(T)" />
        public static Energy<double> WattHours<T>(this T value) =>
            Energy<double>.FromWattHours(Convert.ToDouble(value));

    }
}
