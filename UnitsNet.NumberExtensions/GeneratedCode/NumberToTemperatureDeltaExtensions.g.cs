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

namespace UnitsNet.NumberExtensions.NumberToTemperatureDelta
{
    /// <summary>
    /// A number to TemperatureDelta Extensions
    /// </summary>
    public static class NumberToTemperatureDeltaExtensions
    {
        /// <inheritdoc cref="TemperatureDelta.FromDegreesCelsius(double)" />
        public static TemperatureDelta DegreesCelsius<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => TemperatureDelta.FromDegreesCelsius(double.CreateChecked(value));
#else
            => TemperatureDelta.FromDegreesCelsius(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="TemperatureDelta.FromDegreesDelisle(double)" />
        public static TemperatureDelta DegreesDelisle<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => TemperatureDelta.FromDegreesDelisle(double.CreateChecked(value));
#else
            => TemperatureDelta.FromDegreesDelisle(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="TemperatureDelta.FromDegreesFahrenheit(double)" />
        public static TemperatureDelta DegreesFahrenheit<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => TemperatureDelta.FromDegreesFahrenheit(double.CreateChecked(value));
#else
            => TemperatureDelta.FromDegreesFahrenheit(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="TemperatureDelta.FromDegreesNewton(double)" />
        public static TemperatureDelta DegreesNewton<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => TemperatureDelta.FromDegreesNewton(double.CreateChecked(value));
#else
            => TemperatureDelta.FromDegreesNewton(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="TemperatureDelta.FromDegreesRankine(double)" />
        public static TemperatureDelta DegreesRankine<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => TemperatureDelta.FromDegreesRankine(double.CreateChecked(value));
#else
            => TemperatureDelta.FromDegreesRankine(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="TemperatureDelta.FromDegreesReaumur(double)" />
        public static TemperatureDelta DegreesReaumur<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => TemperatureDelta.FromDegreesReaumur(double.CreateChecked(value));
#else
            => TemperatureDelta.FromDegreesReaumur(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="TemperatureDelta.FromDegreesRoemer(double)" />
        public static TemperatureDelta DegreesRoemer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => TemperatureDelta.FromDegreesRoemer(double.CreateChecked(value));
#else
            => TemperatureDelta.FromDegreesRoemer(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="TemperatureDelta.FromKelvins(double)" />
        public static TemperatureDelta Kelvins<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => TemperatureDelta.FromKelvins(double.CreateChecked(value));
#else
            => TemperatureDelta.FromKelvins(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="TemperatureDelta.FromMillidegreesCelsius(double)" />
        public static TemperatureDelta MillidegreesCelsius<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => TemperatureDelta.FromMillidegreesCelsius(double.CreateChecked(value));
#else
            => TemperatureDelta.FromMillidegreesCelsius(Convert.ToDouble(value));
#endif

    }
}
