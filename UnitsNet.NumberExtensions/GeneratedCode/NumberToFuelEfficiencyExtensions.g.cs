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

namespace UnitsNet.NumberExtensions.NumberToFuelEfficiency
{
    /// <summary>
    /// A number to FuelEfficiency Extensions
    /// </summary>
    public static class NumberToFuelEfficiencyExtensions
    {
        /// <inheritdoc cref="FuelEfficiency{T}.FromKilometersPerLiters(T)" />
        public static FuelEfficiency<double> KilometersPerLiters<T>(this T value) =>
            FuelEfficiency<double>.FromKilometersPerLiters(Convert.ToDouble(value));

        /// <inheritdoc cref="FuelEfficiency{T}.FromLitersPer100Kilometers(T)" />
        public static FuelEfficiency<double> LitersPer100Kilometers<T>(this T value) =>
            FuelEfficiency<double>.FromLitersPer100Kilometers(Convert.ToDouble(value));

        /// <inheritdoc cref="FuelEfficiency{T}.FromMilesPerUkGallon(T)" />
        public static FuelEfficiency<double> MilesPerUkGallon<T>(this T value) =>
            FuelEfficiency<double>.FromMilesPerUkGallon(Convert.ToDouble(value));

        /// <inheritdoc cref="FuelEfficiency{T}.FromMilesPerUsGallon(T)" />
        public static FuelEfficiency<double> MilesPerUsGallon<T>(this T value) =>
            FuelEfficiency<double>.FromMilesPerUsGallon(Convert.ToDouble(value));

    }
}
