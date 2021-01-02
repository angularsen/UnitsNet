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

namespace UnitsNet.NumberExtensions.NumberToEntropy
{
    /// <summary>
    /// A number to Entropy Extensions
    /// </summary>
    public static class NumberToEntropyExtensions
    {
        /// <inheritdoc cref="Entropy{T}.FromCaloriesPerKelvin(T)" />
        public static Entropy<double> CaloriesPerKelvin<T>(this T value) =>
            Entropy<double>.FromCaloriesPerKelvin(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy{T}.FromJoulesPerDegreeCelsius(T)" />
        public static Entropy<double> JoulesPerDegreeCelsius<T>(this T value) =>
            Entropy<double>.FromJoulesPerDegreeCelsius(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy{T}.FromJoulesPerKelvin(T)" />
        public static Entropy<double> JoulesPerKelvin<T>(this T value) =>
            Entropy<double>.FromJoulesPerKelvin(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy{T}.FromKilocaloriesPerKelvin(T)" />
        public static Entropy<double> KilocaloriesPerKelvin<T>(this T value) =>
            Entropy<double>.FromKilocaloriesPerKelvin(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy{T}.FromKilojoulesPerDegreeCelsius(T)" />
        public static Entropy<double> KilojoulesPerDegreeCelsius<T>(this T value) =>
            Entropy<double>.FromKilojoulesPerDegreeCelsius(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy{T}.FromKilojoulesPerKelvin(T)" />
        public static Entropy<double> KilojoulesPerKelvin<T>(this T value) =>
            Entropy<double>.FromKilojoulesPerKelvin(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy{T}.FromMegajoulesPerKelvin(T)" />
        public static Entropy<double> MegajoulesPerKelvin<T>(this T value) =>
            Entropy<double>.FromMegajoulesPerKelvin(Convert.ToDouble(value));

    }
}
