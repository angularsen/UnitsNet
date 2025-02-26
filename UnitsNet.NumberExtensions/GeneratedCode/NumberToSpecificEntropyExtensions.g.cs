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

namespace UnitsNet.NumberExtensions.NumberToSpecificEntropy
{
    /// <summary>
    /// A number to SpecificEntropy Extensions
    /// </summary>
    public static class NumberToSpecificEntropyExtensions
    {
        /// <inheritdoc cref="SpecificEntropy.FromBtusPerPoundFahrenheit(double)" />
        public static SpecificEntropy BtusPerPoundFahrenheit<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => SpecificEntropy.FromBtusPerPoundFahrenheit(double.CreateChecked(value));
#else
            => SpecificEntropy.FromBtusPerPoundFahrenheit(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="SpecificEntropy.FromCaloriesPerGramKelvin(double)" />
        public static SpecificEntropy CaloriesPerGramKelvin<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => SpecificEntropy.FromCaloriesPerGramKelvin(double.CreateChecked(value));
#else
            => SpecificEntropy.FromCaloriesPerGramKelvin(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="SpecificEntropy.FromJoulesPerKilogramDegreeCelsius(double)" />
        public static SpecificEntropy JoulesPerKilogramDegreeCelsius<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => SpecificEntropy.FromJoulesPerKilogramDegreeCelsius(double.CreateChecked(value));
#else
            => SpecificEntropy.FromJoulesPerKilogramDegreeCelsius(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="SpecificEntropy.FromJoulesPerKilogramKelvin(double)" />
        public static SpecificEntropy JoulesPerKilogramKelvin<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => SpecificEntropy.FromJoulesPerKilogramKelvin(double.CreateChecked(value));
#else
            => SpecificEntropy.FromJoulesPerKilogramKelvin(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="SpecificEntropy.FromKilocaloriesPerGramKelvin(double)" />
        public static SpecificEntropy KilocaloriesPerGramKelvin<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => SpecificEntropy.FromKilocaloriesPerGramKelvin(double.CreateChecked(value));
#else
            => SpecificEntropy.FromKilocaloriesPerGramKelvin(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="SpecificEntropy.FromKilojoulesPerKilogramDegreeCelsius(double)" />
        public static SpecificEntropy KilojoulesPerKilogramDegreeCelsius<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => SpecificEntropy.FromKilojoulesPerKilogramDegreeCelsius(double.CreateChecked(value));
#else
            => SpecificEntropy.FromKilojoulesPerKilogramDegreeCelsius(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="SpecificEntropy.FromKilojoulesPerKilogramKelvin(double)" />
        public static SpecificEntropy KilojoulesPerKilogramKelvin<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => SpecificEntropy.FromKilojoulesPerKilogramKelvin(double.CreateChecked(value));
#else
            => SpecificEntropy.FromKilojoulesPerKilogramKelvin(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="SpecificEntropy.FromMegajoulesPerKilogramDegreeCelsius(double)" />
        public static SpecificEntropy MegajoulesPerKilogramDegreeCelsius<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => SpecificEntropy.FromMegajoulesPerKilogramDegreeCelsius(double.CreateChecked(value));
#else
            => SpecificEntropy.FromMegajoulesPerKilogramDegreeCelsius(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="SpecificEntropy.FromMegajoulesPerKilogramKelvin(double)" />
        public static SpecificEntropy MegajoulesPerKilogramKelvin<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => SpecificEntropy.FromMegajoulesPerKilogramKelvin(double.CreateChecked(value));
#else
            => SpecificEntropy.FromMegajoulesPerKilogramKelvin(Convert.ToDouble(value));
#endif

    }
}
