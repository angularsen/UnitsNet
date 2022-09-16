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

namespace OasysUnitsNet.NumberExtensions.NumberToEntropy
{
    /// <summary>
    /// A number to Entropy Extensions
    /// </summary>
    public static class NumberToEntropyExtensions
    {
        /// <inheritdoc cref="Entropy.FromCaloriesPerKelvin(OasysUnitsNet.QuantityValue)" />
        public static Entropy CaloriesPerKelvin<T>(this T value) =>
            Entropy.FromCaloriesPerKelvin(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy.FromJoulesPerDegreeCelsius(OasysUnitsNet.QuantityValue)" />
        public static Entropy JoulesPerDegreeCelsius<T>(this T value) =>
            Entropy.FromJoulesPerDegreeCelsius(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy.FromJoulesPerKelvin(OasysUnitsNet.QuantityValue)" />
        public static Entropy JoulesPerKelvin<T>(this T value) =>
            Entropy.FromJoulesPerKelvin(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy.FromKilocaloriesPerKelvin(OasysUnitsNet.QuantityValue)" />
        public static Entropy KilocaloriesPerKelvin<T>(this T value) =>
            Entropy.FromKilocaloriesPerKelvin(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy.FromKilojoulesPerDegreeCelsius(OasysUnitsNet.QuantityValue)" />
        public static Entropy KilojoulesPerDegreeCelsius<T>(this T value) =>
            Entropy.FromKilojoulesPerDegreeCelsius(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy.FromKilojoulesPerKelvin(OasysUnitsNet.QuantityValue)" />
        public static Entropy KilojoulesPerKelvin<T>(this T value) =>
            Entropy.FromKilojoulesPerKelvin(Convert.ToDouble(value));

        /// <inheritdoc cref="Entropy.FromMegajoulesPerKelvin(OasysUnitsNet.QuantityValue)" />
        public static Entropy MegajoulesPerKelvin<T>(this T value) =>
            Entropy.FromMegajoulesPerKelvin(Convert.ToDouble(value));

    }
}
