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

namespace UnitsNet.NumberExtensions.NumberToElectricConductance
{
    /// <summary>
    /// A number to ElectricConductance Extensions
    /// </summary>
    public static class NumberToElectricConductanceExtensions
    {
        /// <inheritdoc cref="ElectricConductance.FromGigamhos(double)" />
        public static ElectricConductance Gigamhos<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromGigamhos(double.CreateChecked(value));
#else
            => ElectricConductance.FromGigamhos(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromGigasiemens(double)" />
        public static ElectricConductance Gigasiemens<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromGigasiemens(double.CreateChecked(value));
#else
            => ElectricConductance.FromGigasiemens(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromKilomhos(double)" />
        public static ElectricConductance Kilomhos<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromKilomhos(double.CreateChecked(value));
#else
            => ElectricConductance.FromKilomhos(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromKilosiemens(double)" />
        public static ElectricConductance Kilosiemens<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromKilosiemens(double.CreateChecked(value));
#else
            => ElectricConductance.FromKilosiemens(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromMegamhos(double)" />
        public static ElectricConductance Megamhos<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromMegamhos(double.CreateChecked(value));
#else
            => ElectricConductance.FromMegamhos(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromMegasiemens(double)" />
        public static ElectricConductance Megasiemens<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromMegasiemens(double.CreateChecked(value));
#else
            => ElectricConductance.FromMegasiemens(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromMhos(double)" />
        public static ElectricConductance Mhos<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromMhos(double.CreateChecked(value));
#else
            => ElectricConductance.FromMhos(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromMicromhos(double)" />
        public static ElectricConductance Micromhos<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromMicromhos(double.CreateChecked(value));
#else
            => ElectricConductance.FromMicromhos(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromMicrosiemens(double)" />
        public static ElectricConductance Microsiemens<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromMicrosiemens(double.CreateChecked(value));
#else
            => ElectricConductance.FromMicrosiemens(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromMillimhos(double)" />
        public static ElectricConductance Millimhos<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromMillimhos(double.CreateChecked(value));
#else
            => ElectricConductance.FromMillimhos(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromMillisiemens(double)" />
        public static ElectricConductance Millisiemens<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromMillisiemens(double.CreateChecked(value));
#else
            => ElectricConductance.FromMillisiemens(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromNanomhos(double)" />
        public static ElectricConductance Nanomhos<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromNanomhos(double.CreateChecked(value));
#else
            => ElectricConductance.FromNanomhos(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromNanosiemens(double)" />
        public static ElectricConductance Nanosiemens<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromNanosiemens(double.CreateChecked(value));
#else
            => ElectricConductance.FromNanosiemens(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromSiemens(double)" />
        public static ElectricConductance Siemens<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromSiemens(double.CreateChecked(value));
#else
            => ElectricConductance.FromSiemens(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromTeramhos(double)" />
        public static ElectricConductance Teramhos<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromTeramhos(double.CreateChecked(value));
#else
            => ElectricConductance.FromTeramhos(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricConductance.FromTerasiemens(double)" />
        public static ElectricConductance Terasiemens<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricConductance.FromTerasiemens(double.CreateChecked(value));
#else
            => ElectricConductance.FromTerasiemens(Convert.ToDouble(value));
#endif

    }
}
