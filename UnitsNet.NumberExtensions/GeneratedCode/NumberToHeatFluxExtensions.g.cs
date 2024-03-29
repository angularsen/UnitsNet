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

namespace UnitsNet.NumberExtensions.NumberToHeatFlux
{
    /// <summary>
    /// A number to HeatFlux Extensions
    /// </summary>
    public static class NumberToHeatFluxExtensions
    {
        /// <inheritdoc cref="HeatFlux.FromBtusPerHourSquareFoot(UnitsNet.QuantityValue)" />
        public static HeatFlux BtusPerHourSquareFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromBtusPerHourSquareFoot(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromBtusPerMinuteSquareFoot(UnitsNet.QuantityValue)" />
        public static HeatFlux BtusPerMinuteSquareFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromBtusPerMinuteSquareFoot(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromBtusPerSecondSquareFoot(UnitsNet.QuantityValue)" />
        public static HeatFlux BtusPerSecondSquareFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromBtusPerSecondSquareFoot(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromBtusPerSecondSquareInch(UnitsNet.QuantityValue)" />
        public static HeatFlux BtusPerSecondSquareInch<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromBtusPerSecondSquareInch(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromCaloriesPerSecondSquareCentimeter(UnitsNet.QuantityValue)" />
        public static HeatFlux CaloriesPerSecondSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromCaloriesPerSecondSquareCentimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromCentiwattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static HeatFlux CentiwattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromCentiwattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromDeciwattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static HeatFlux DeciwattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromDeciwattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromKilocaloriesPerHourSquareMeter(UnitsNet.QuantityValue)" />
        public static HeatFlux KilocaloriesPerHourSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromKilocaloriesPerHourSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromKilocaloriesPerSecondSquareCentimeter(UnitsNet.QuantityValue)" />
        public static HeatFlux KilocaloriesPerSecondSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromKilocaloriesPerSecondSquareCentimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromKilowattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static HeatFlux KilowattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromKilowattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromMicrowattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static HeatFlux MicrowattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromMicrowattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromMilliwattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static HeatFlux MilliwattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromMilliwattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromNanowattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static HeatFlux NanowattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromNanowattsPerSquareMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromPoundsForcePerFootSecond(UnitsNet.QuantityValue)" />
        public static HeatFlux PoundsForcePerFootSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromPoundsForcePerFootSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromPoundsPerSecondCubed(UnitsNet.QuantityValue)" />
        public static HeatFlux PoundsPerSecondCubed<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromPoundsPerSecondCubed(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromWattsPerSquareFoot(UnitsNet.QuantityValue)" />
        public static HeatFlux WattsPerSquareFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromWattsPerSquareFoot(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromWattsPerSquareInch(UnitsNet.QuantityValue)" />
        public static HeatFlux WattsPerSquareInch<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromWattsPerSquareInch(Convert.ToDouble(value));

        /// <inheritdoc cref="HeatFlux.FromWattsPerSquareMeter(UnitsNet.QuantityValue)" />
        public static HeatFlux WattsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => HeatFlux.FromWattsPerSquareMeter(Convert.ToDouble(value));

    }
}
