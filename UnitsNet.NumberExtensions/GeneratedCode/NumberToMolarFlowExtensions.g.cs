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

namespace UnitsNet.NumberExtensions.NumberToMolarFlow
{
    /// <summary>
    /// A number to MolarFlow Extensions
    /// </summary>
    public static class NumberToMolarFlowExtensions
    {
        /// <inheritdoc cref="MolarFlow.FromKilomolesPerHour(UnitsNet.QuantityValue)" />
        public static MolarFlow KilomolesPerHour<T>(this T value) =>
            MolarFlow.FromKilomolesPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="MolarFlow.FromKilomolesPerMinute(UnitsNet.QuantityValue)" />
        public static MolarFlow KilomolesPerMinute<T>(this T value) =>
            MolarFlow.FromKilomolesPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="MolarFlow.FromKilomolesPerSecond(UnitsNet.QuantityValue)" />
        public static MolarFlow KilomolesPerSecond<T>(this T value) =>
            MolarFlow.FromKilomolesPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MolarFlow.FromMolesPerHour(UnitsNet.QuantityValue)" />
        public static MolarFlow MolesPerHour<T>(this T value) =>
            MolarFlow.FromMolesPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="MolarFlow.FromMolesPerMinute(UnitsNet.QuantityValue)" />
        public static MolarFlow MolesPerMinute<T>(this T value) =>
            MolarFlow.FromMolesPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="MolarFlow.FromMolesPerSecond(UnitsNet.QuantityValue)" />
        public static MolarFlow MolesPerSecond<T>(this T value) =>
            MolarFlow.FromMolesPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="MolarFlow.FromPoundMolesPerHour(UnitsNet.QuantityValue)" />
        public static MolarFlow PoundMolesPerHour<T>(this T value) =>
            MolarFlow.FromPoundMolesPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="MolarFlow.FromPoundMolesPerMinute(UnitsNet.QuantityValue)" />
        public static MolarFlow PoundMolesPerMinute<T>(this T value) =>
            MolarFlow.FromPoundMolesPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="MolarFlow.FromPoundMolesPerSecond(UnitsNet.QuantityValue)" />
        public static MolarFlow PoundMolesPerSecond<T>(this T value) =>
            MolarFlow.FromPoundMolesPerSecond(Convert.ToDouble(value));

    }
}
