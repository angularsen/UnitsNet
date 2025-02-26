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

namespace UnitsNet.NumberExtensions.NumberToForceChangeRate
{
    /// <summary>
    /// A number to ForceChangeRate Extensions
    /// </summary>
    public static class NumberToForceChangeRateExtensions
    {
        /// <inheritdoc cref="ForceChangeRate.FromCentinewtonsPerSecond(double)" />
        public static ForceChangeRate CentinewtonsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromCentinewtonsPerSecond(double.CreateChecked(value));
#else
            => ForceChangeRate.FromCentinewtonsPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromDecanewtonsPerMinute(double)" />
        public static ForceChangeRate DecanewtonsPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromDecanewtonsPerMinute(double.CreateChecked(value));
#else
            => ForceChangeRate.FromDecanewtonsPerMinute(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromDecanewtonsPerSecond(double)" />
        public static ForceChangeRate DecanewtonsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromDecanewtonsPerSecond(double.CreateChecked(value));
#else
            => ForceChangeRate.FromDecanewtonsPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromDecinewtonsPerSecond(double)" />
        public static ForceChangeRate DecinewtonsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromDecinewtonsPerSecond(double.CreateChecked(value));
#else
            => ForceChangeRate.FromDecinewtonsPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromKilonewtonsPerMinute(double)" />
        public static ForceChangeRate KilonewtonsPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromKilonewtonsPerMinute(double.CreateChecked(value));
#else
            => ForceChangeRate.FromKilonewtonsPerMinute(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromKilonewtonsPerSecond(double)" />
        public static ForceChangeRate KilonewtonsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromKilonewtonsPerSecond(double.CreateChecked(value));
#else
            => ForceChangeRate.FromKilonewtonsPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromKilopoundsForcePerMinute(double)" />
        public static ForceChangeRate KilopoundsForcePerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromKilopoundsForcePerMinute(double.CreateChecked(value));
#else
            => ForceChangeRate.FromKilopoundsForcePerMinute(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromKilopoundsForcePerSecond(double)" />
        public static ForceChangeRate KilopoundsForcePerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromKilopoundsForcePerSecond(double.CreateChecked(value));
#else
            => ForceChangeRate.FromKilopoundsForcePerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromMicronewtonsPerSecond(double)" />
        public static ForceChangeRate MicronewtonsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromMicronewtonsPerSecond(double.CreateChecked(value));
#else
            => ForceChangeRate.FromMicronewtonsPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromMillinewtonsPerSecond(double)" />
        public static ForceChangeRate MillinewtonsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromMillinewtonsPerSecond(double.CreateChecked(value));
#else
            => ForceChangeRate.FromMillinewtonsPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromNanonewtonsPerSecond(double)" />
        public static ForceChangeRate NanonewtonsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromNanonewtonsPerSecond(double.CreateChecked(value));
#else
            => ForceChangeRate.FromNanonewtonsPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromNewtonsPerMinute(double)" />
        public static ForceChangeRate NewtonsPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromNewtonsPerMinute(double.CreateChecked(value));
#else
            => ForceChangeRate.FromNewtonsPerMinute(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromNewtonsPerSecond(double)" />
        public static ForceChangeRate NewtonsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromNewtonsPerSecond(double.CreateChecked(value));
#else
            => ForceChangeRate.FromNewtonsPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromPoundsForcePerMinute(double)" />
        public static ForceChangeRate PoundsForcePerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromPoundsForcePerMinute(double.CreateChecked(value));
#else
            => ForceChangeRate.FromPoundsForcePerMinute(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForceChangeRate.FromPoundsForcePerSecond(double)" />
        public static ForceChangeRate PoundsForcePerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForceChangeRate.FromPoundsForcePerSecond(double.CreateChecked(value));
#else
            => ForceChangeRate.FromPoundsForcePerSecond(Convert.ToDouble(value));
#endif

    }
}
