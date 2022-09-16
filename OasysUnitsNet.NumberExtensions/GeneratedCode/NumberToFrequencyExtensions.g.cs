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

using System;

#nullable enable

namespace OasysUnitsNet.NumberExtensions.NumberToFrequency
{
    /// <summary>
    /// A number to Frequency Extensions
    /// </summary>
    public static class NumberToFrequencyExtensions
    {
        /// <inheritdoc cref="Frequency.FromBeatsPerMinute(OasysUnitsNet.QuantityValue)" />
        public static Frequency BeatsPerMinute<T>(this T value) =>
            Frequency.FromBeatsPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="Frequency.FromBUnits(OasysUnitsNet.QuantityValue)" />
        public static Frequency BUnits<T>(this T value) =>
            Frequency.FromBUnits(Convert.ToDouble(value));

        /// <inheritdoc cref="Frequency.FromCyclesPerHour(OasysUnitsNet.QuantityValue)" />
        public static Frequency CyclesPerHour<T>(this T value) =>
            Frequency.FromCyclesPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="Frequency.FromCyclesPerMinute(OasysUnitsNet.QuantityValue)" />
        public static Frequency CyclesPerMinute<T>(this T value) =>
            Frequency.FromCyclesPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="Frequency.FromGigahertz(OasysUnitsNet.QuantityValue)" />
        public static Frequency Gigahertz<T>(this T value) =>
            Frequency.FromGigahertz(Convert.ToDouble(value));

        /// <inheritdoc cref="Frequency.FromHertz(OasysUnitsNet.QuantityValue)" />
        public static Frequency Hertz<T>(this T value) =>
            Frequency.FromHertz(Convert.ToDouble(value));

        /// <inheritdoc cref="Frequency.FromKilohertz(OasysUnitsNet.QuantityValue)" />
        public static Frequency Kilohertz<T>(this T value) =>
            Frequency.FromKilohertz(Convert.ToDouble(value));

        /// <inheritdoc cref="Frequency.FromMegahertz(OasysUnitsNet.QuantityValue)" />
        public static Frequency Megahertz<T>(this T value) =>
            Frequency.FromMegahertz(Convert.ToDouble(value));

        /// <inheritdoc cref="Frequency.FromPerSecond(OasysUnitsNet.QuantityValue)" />
        public static Frequency PerSecond<T>(this T value) =>
            Frequency.FromPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Frequency.FromRadiansPerSecond(OasysUnitsNet.QuantityValue)" />
        public static Frequency RadiansPerSecond<T>(this T value) =>
            Frequency.FromRadiansPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Frequency.FromTerahertz(OasysUnitsNet.QuantityValue)" />
        public static Frequency Terahertz<T>(this T value) =>
            Frequency.FromTerahertz(Convert.ToDouble(value));

    }
}
