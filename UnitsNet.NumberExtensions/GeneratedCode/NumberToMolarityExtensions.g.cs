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

#if NET7_0_OR_GREATER
using System.Numerics;
#endif

#nullable enable

namespace UnitsNet.NumberExtensions.NumberToMolarity
{
    /// <summary>
    /// A number to Molarity Extensions
    /// </summary>
    public static class NumberToMolarityExtensions
    {
        /// <inheritdoc cref="Molarity.FromCentimolesPerLiter(double)" />
        public static Molarity CentimolesPerLiter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromCentimolesPerLiter(double.CreateChecked(value));
#else
            => Molarity.FromCentimolesPerLiter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Molarity.FromDecimolesPerLiter(double)" />
        public static Molarity DecimolesPerLiter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromDecimolesPerLiter(double.CreateChecked(value));
#else
            => Molarity.FromDecimolesPerLiter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Molarity.FromFemtomolesPerLiter(double)" />
        public static Molarity FemtomolesPerLiter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromFemtomolesPerLiter(double.CreateChecked(value));
#else
            => Molarity.FromFemtomolesPerLiter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Molarity.FromKilomolesPerCubicMeter(double)" />
        public static Molarity KilomolesPerCubicMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromKilomolesPerCubicMeter(double.CreateChecked(value));
#else
            => Molarity.FromKilomolesPerCubicMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Molarity.FromMicromolesPerLiter(double)" />
        public static Molarity MicromolesPerLiter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromMicromolesPerLiter(double.CreateChecked(value));
#else
            => Molarity.FromMicromolesPerLiter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Molarity.FromMillimolesPerLiter(double)" />
        public static Molarity MillimolesPerLiter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromMillimolesPerLiter(double.CreateChecked(value));
#else
            => Molarity.FromMillimolesPerLiter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Molarity.FromMolesPerCubicMeter(double)" />
        public static Molarity MolesPerCubicMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromMolesPerCubicMeter(double.CreateChecked(value));
#else
            => Molarity.FromMolesPerCubicMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Molarity.FromMolesPerLiter(double)" />
        public static Molarity MolesPerLiter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromMolesPerLiter(double.CreateChecked(value));
#else
            => Molarity.FromMolesPerLiter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Molarity.FromNanomolesPerLiter(double)" />
        public static Molarity NanomolesPerLiter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromNanomolesPerLiter(double.CreateChecked(value));
#else
            => Molarity.FromNanomolesPerLiter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Molarity.FromPicomolesPerLiter(double)" />
        public static Molarity PicomolesPerLiter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromPicomolesPerLiter(double.CreateChecked(value));
#else
            => Molarity.FromPicomolesPerLiter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Molarity.FromPoundMolesPerCubicFoot(double)" />
        public static Molarity PoundMolesPerCubicFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Molarity.FromPoundMolesPerCubicFoot(double.CreateChecked(value));
#else
            => Molarity.FromPoundMolesPerCubicFoot(Convert.ToDouble(value));
#endif

    }
}
