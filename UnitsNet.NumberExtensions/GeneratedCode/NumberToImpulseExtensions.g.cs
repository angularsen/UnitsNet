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

namespace UnitsNet.NumberExtensions.NumberToImpulse
{
    /// <summary>
    /// A number to Impulse Extensions
    /// </summary>
    public static class NumberToImpulseExtensions
    {
        /// <inheritdoc cref="Impulse.FromCentinewtonSeconds(double)" />
        public static Impulse CentinewtonSeconds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromCentinewtonSeconds(double.CreateChecked(value));
#else
            => Impulse.FromCentinewtonSeconds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromDecanewtonSeconds(double)" />
        public static Impulse DecanewtonSeconds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromDecanewtonSeconds(double.CreateChecked(value));
#else
            => Impulse.FromDecanewtonSeconds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromDecinewtonSeconds(double)" />
        public static Impulse DecinewtonSeconds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromDecinewtonSeconds(double.CreateChecked(value));
#else
            => Impulse.FromDecinewtonSeconds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromKilogramMetersPerSecond(double)" />
        public static Impulse KilogramMetersPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromKilogramMetersPerSecond(double.CreateChecked(value));
#else
            => Impulse.FromKilogramMetersPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromKilonewtonSeconds(double)" />
        public static Impulse KilonewtonSeconds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromKilonewtonSeconds(double.CreateChecked(value));
#else
            => Impulse.FromKilonewtonSeconds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromMeganewtonSeconds(double)" />
        public static Impulse MeganewtonSeconds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromMeganewtonSeconds(double.CreateChecked(value));
#else
            => Impulse.FromMeganewtonSeconds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromMicronewtonSeconds(double)" />
        public static Impulse MicronewtonSeconds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromMicronewtonSeconds(double.CreateChecked(value));
#else
            => Impulse.FromMicronewtonSeconds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromMillinewtonSeconds(double)" />
        public static Impulse MillinewtonSeconds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromMillinewtonSeconds(double.CreateChecked(value));
#else
            => Impulse.FromMillinewtonSeconds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromNanonewtonSeconds(double)" />
        public static Impulse NanonewtonSeconds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromNanonewtonSeconds(double.CreateChecked(value));
#else
            => Impulse.FromNanonewtonSeconds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromNewtonSeconds(double)" />
        public static Impulse NewtonSeconds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromNewtonSeconds(double.CreateChecked(value));
#else
            => Impulse.FromNewtonSeconds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromPoundFeetPerSecond(double)" />
        public static Impulse PoundFeetPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromPoundFeetPerSecond(double.CreateChecked(value));
#else
            => Impulse.FromPoundFeetPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromPoundForceSeconds(double)" />
        public static Impulse PoundForceSeconds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromPoundForceSeconds(double.CreateChecked(value));
#else
            => Impulse.FromPoundForceSeconds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Impulse.FromSlugFeetPerSecond(double)" />
        public static Impulse SlugFeetPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Impulse.FromSlugFeetPerSecond(double.CreateChecked(value));
#else
            => Impulse.FromSlugFeetPerSecond(Convert.ToDouble(value));
#endif

    }
}
