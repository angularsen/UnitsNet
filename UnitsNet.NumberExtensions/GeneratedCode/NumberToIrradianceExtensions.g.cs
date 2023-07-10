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

namespace UnitsNet.NumberExtensions.NumberToIrradiance
{
    /// <summary>
    /// A number to Irradiance Extensions
    /// </summary>
    public static class NumberToIrradianceExtensions
    {
        /// <inheritdoc cref="Irradiance.FromKilowattsPerSquareCentimeter(UnitsNet.QuantityValue)" />
        public static Irradiance KilowattsPerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromKilowattsPerSquareCentimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromKilowattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static Irradiance KilowattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromKilowattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromMegawattsPerSquareCentimeter(UnitsNet.QuantityValue)" />
        public static Irradiance MegawattsPerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromMegawattsPerSquareCentimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromMegawattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static Irradiance MegawattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromMegawattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromMicrowattsPerSquareCentimeter(UnitsNet.QuantityValue)" />
        public static Irradiance MicrowattsPerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromMicrowattsPerSquareCentimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromMicrowattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static Irradiance MicrowattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromMicrowattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromMilliwattsPerSquareCentimeter(UnitsNet.QuantityValue)" />
        public static Irradiance MilliwattsPerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromMilliwattsPerSquareCentimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromMilliwattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static Irradiance MilliwattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromMilliwattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromNanowattsPerSquareCentimeter(UnitsNet.QuantityValue)" />
        public static Irradiance NanowattsPerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromNanowattsPerSquareCentimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromNanowattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static Irradiance NanowattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromNanowattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromPicowattsPerSquareCentimeter(UnitsNet.QuantityValue)" />
        public static Irradiance PicowattsPerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromPicowattsPerSquareCentimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromPicowattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static Irradiance PicowattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromPicowattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromWattsPerSquareCentimeter(UnitsNet.QuantityValue)" />
        public static Irradiance WattsPerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromWattsPerSquareCentimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="Irradiance.FromWattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static Irradiance WattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => Irradiance.FromWattsPerSquareMeter(Convert.ToDouble(value));

    }
}
