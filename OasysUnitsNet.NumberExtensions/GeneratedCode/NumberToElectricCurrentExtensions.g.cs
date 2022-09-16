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

namespace OasysUnitsNet.NumberExtensions.NumberToElectricCurrent
{
    /// <summary>
    /// A number to ElectricCurrent Extensions
    /// </summary>
    public static class NumberToElectricCurrentExtensions
    {
        /// <inheritdoc cref="ElectricCurrent.FromAmperes(OasysUnitsNet.QuantityValue)" />
        public static ElectricCurrent Amperes<T>(this T value) =>
            ElectricCurrent.FromAmperes(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricCurrent.FromCentiamperes(OasysUnitsNet.QuantityValue)" />
        public static ElectricCurrent Centiamperes<T>(this T value) =>
            ElectricCurrent.FromCentiamperes(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricCurrent.FromKiloamperes(OasysUnitsNet.QuantityValue)" />
        public static ElectricCurrent Kiloamperes<T>(this T value) =>
            ElectricCurrent.FromKiloamperes(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricCurrent.FromMegaamperes(OasysUnitsNet.QuantityValue)" />
        public static ElectricCurrent Megaamperes<T>(this T value) =>
            ElectricCurrent.FromMegaamperes(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricCurrent.FromMicroamperes(OasysUnitsNet.QuantityValue)" />
        public static ElectricCurrent Microamperes<T>(this T value) =>
            ElectricCurrent.FromMicroamperes(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricCurrent.FromMilliamperes(OasysUnitsNet.QuantityValue)" />
        public static ElectricCurrent Milliamperes<T>(this T value) =>
            ElectricCurrent.FromMilliamperes(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricCurrent.FromNanoamperes(OasysUnitsNet.QuantityValue)" />
        public static ElectricCurrent Nanoamperes<T>(this T value) =>
            ElectricCurrent.FromNanoamperes(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricCurrent.FromPicoamperes(OasysUnitsNet.QuantityValue)" />
        public static ElectricCurrent Picoamperes<T>(this T value) =>
            ElectricCurrent.FromPicoamperes(Convert.ToDouble(value));

    }
}
