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

namespace UnitsNet.NumberExtensions.NumberToElectricInductance
{
    /// <summary>
    /// A number to ElectricInductance Extensions
    /// </summary>
    public static class NumberToElectricInductanceExtensions
    {
        /// <inheritdoc cref="ElectricInductance.FromHenries(UnitsNet.QuantityValue)" />
        public static ElectricInductance Henries<T>(this T value) =>
            ElectricInductance.FromHenries(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricInductance.FromMicrohenries(UnitsNet.QuantityValue)" />
        public static ElectricInductance Microhenries<T>(this T value) =>
            ElectricInductance.FromMicrohenries(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricInductance.FromMillihenries(UnitsNet.QuantityValue)" />
        public static ElectricInductance Millihenries<T>(this T value) =>
            ElectricInductance.FromMillihenries(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricInductance.FromNanohenries(UnitsNet.QuantityValue)" />
        public static ElectricInductance Nanohenries<T>(this T value) =>
            ElectricInductance.FromNanohenries(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricInductance.FromPicohenries(UnitsNet.QuantityValue)" />
        public static ElectricInductance Picohenries<T>(this T value) =>
            ElectricInductance.FromPicohenries(Convert.ToDouble(value));

    }
}
