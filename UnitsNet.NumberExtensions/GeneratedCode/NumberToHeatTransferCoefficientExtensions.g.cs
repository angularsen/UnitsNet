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

namespace UnitsNet.NumberExtensions.NumberToHeatTransferCoefficient
{
    /// <summary>
    /// A number to HeatTransferCoefficient Extensions
    /// </summary>
    public static class NumberToHeatTransferCoefficientExtensions
    {
        /// <inheritdoc cref="HeatTransferCoefficient.FromBtusPerHourSquareFootDegreeFahrenheit(double)" />
        public static HeatTransferCoefficient BtusPerHourSquareFootDegreeFahrenheit<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => HeatTransferCoefficient.FromBtusPerHourSquareFootDegreeFahrenheit(double.CreateChecked(value));
#else
            => HeatTransferCoefficient.FromBtusPerHourSquareFootDegreeFahrenheit(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="HeatTransferCoefficient.FromCaloriesPerHourSquareMeterDegreeCelsius(double)" />
        public static HeatTransferCoefficient CaloriesPerHourSquareMeterDegreeCelsius<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => HeatTransferCoefficient.FromCaloriesPerHourSquareMeterDegreeCelsius(double.CreateChecked(value));
#else
            => HeatTransferCoefficient.FromCaloriesPerHourSquareMeterDegreeCelsius(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="HeatTransferCoefficient.FromKilocaloriesPerHourSquareMeterDegreeCelsius(double)" />
        public static HeatTransferCoefficient KilocaloriesPerHourSquareMeterDegreeCelsius<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => HeatTransferCoefficient.FromKilocaloriesPerHourSquareMeterDegreeCelsius(double.CreateChecked(value));
#else
            => HeatTransferCoefficient.FromKilocaloriesPerHourSquareMeterDegreeCelsius(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="HeatTransferCoefficient.FromWattsPerSquareMeterCelsius(double)" />
        public static HeatTransferCoefficient WattsPerSquareMeterCelsius<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => HeatTransferCoefficient.FromWattsPerSquareMeterCelsius(double.CreateChecked(value));
#else
            => HeatTransferCoefficient.FromWattsPerSquareMeterCelsius(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="HeatTransferCoefficient.FromWattsPerSquareMeterKelvin(double)" />
        public static HeatTransferCoefficient WattsPerSquareMeterKelvin<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => HeatTransferCoefficient.FromWattsPerSquareMeterKelvin(double.CreateChecked(value));
#else
            => HeatTransferCoefficient.FromWattsPerSquareMeterKelvin(Convert.ToDouble(value));
#endif

    }
}
