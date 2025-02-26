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

namespace UnitsNet.NumberExtensions.NumberToFrequency
{
    /// <summary>
    /// A number to Frequency Extensions
    /// </summary>
    public static class NumberToFrequencyExtensions
    {
        /// <inheritdoc cref="Frequency.FromBeatsPerMinute(double)" />
        public static Frequency BeatsPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromBeatsPerMinute(double.CreateChecked(value));
#else
            => Frequency.FromBeatsPerMinute(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromBUnits(double)" />
        public static Frequency BUnits<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromBUnits(double.CreateChecked(value));
#else
            => Frequency.FromBUnits(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromCyclesPerHour(double)" />
        public static Frequency CyclesPerHour<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromCyclesPerHour(double.CreateChecked(value));
#else
            => Frequency.FromCyclesPerHour(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromCyclesPerMinute(double)" />
        public static Frequency CyclesPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromCyclesPerMinute(double.CreateChecked(value));
#else
            => Frequency.FromCyclesPerMinute(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromGigahertz(double)" />
        public static Frequency Gigahertz<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromGigahertz(double.CreateChecked(value));
#else
            => Frequency.FromGigahertz(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromHertz(double)" />
        public static Frequency Hertz<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromHertz(double.CreateChecked(value));
#else
            => Frequency.FromHertz(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromKilohertz(double)" />
        public static Frequency Kilohertz<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromKilohertz(double.CreateChecked(value));
#else
            => Frequency.FromKilohertz(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromMegahertz(double)" />
        public static Frequency Megahertz<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromMegahertz(double.CreateChecked(value));
#else
            => Frequency.FromMegahertz(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromMicrohertz(double)" />
        public static Frequency Microhertz<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromMicrohertz(double.CreateChecked(value));
#else
            => Frequency.FromMicrohertz(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromMillihertz(double)" />
        public static Frequency Millihertz<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromMillihertz(double.CreateChecked(value));
#else
            => Frequency.FromMillihertz(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromPerSecond(double)" />
        public static Frequency PerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromPerSecond(double.CreateChecked(value));
#else
            => Frequency.FromPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromRadiansPerSecond(double)" />
        public static Frequency RadiansPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromRadiansPerSecond(double.CreateChecked(value));
#else
            => Frequency.FromRadiansPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Frequency.FromTerahertz(double)" />
        public static Frequency Terahertz<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Frequency.FromTerahertz(double.CreateChecked(value));
#else
            => Frequency.FromTerahertz(Convert.ToDouble(value));
#endif

    }
}
