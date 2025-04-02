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

namespace UnitsNet.NumberExtensions.NumberToElectricPotentialChangeRate
{
    /// <summary>
    /// A number to ElectricPotentialChangeRate Extensions
    /// </summary>
    public static class NumberToElectricPotentialChangeRateExtensions
    {
        /// <inheritdoc cref="ElectricPotentialChangeRate.FromKilovoltsPerHour(double)" />
        public static ElectricPotentialChangeRate KilovoltsPerHour<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromKilovoltsPerHour(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromKilovoltsPerHour(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromKilovoltsPerMicrosecond(double)" />
        public static ElectricPotentialChangeRate KilovoltsPerMicrosecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromKilovoltsPerMicrosecond(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromKilovoltsPerMicrosecond(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromKilovoltsPerMinute(double)" />
        public static ElectricPotentialChangeRate KilovoltsPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromKilovoltsPerMinute(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromKilovoltsPerMinute(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromKilovoltsPerSecond(double)" />
        public static ElectricPotentialChangeRate KilovoltsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromKilovoltsPerSecond(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromKilovoltsPerSecond(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMegavoltsPerHour(double)" />
        public static ElectricPotentialChangeRate MegavoltsPerHour<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMegavoltsPerHour(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMegavoltsPerHour(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMegavoltsPerMicrosecond(double)" />
        public static ElectricPotentialChangeRate MegavoltsPerMicrosecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMegavoltsPerMicrosecond(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMegavoltsPerMicrosecond(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMegavoltsPerMinute(double)" />
        public static ElectricPotentialChangeRate MegavoltsPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMegavoltsPerMinute(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMegavoltsPerMinute(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMegavoltsPerSecond(double)" />
        public static ElectricPotentialChangeRate MegavoltsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMegavoltsPerSecond(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMegavoltsPerSecond(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMicrovoltsPerHour(double)" />
        public static ElectricPotentialChangeRate MicrovoltsPerHour<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMicrovoltsPerHour(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMicrovoltsPerHour(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMicrovoltsPerMicrosecond(double)" />
        public static ElectricPotentialChangeRate MicrovoltsPerMicrosecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMicrovoltsPerMicrosecond(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMicrovoltsPerMicrosecond(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMicrovoltsPerMinute(double)" />
        public static ElectricPotentialChangeRate MicrovoltsPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMicrovoltsPerMinute(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMicrovoltsPerMinute(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMicrovoltsPerSecond(double)" />
        public static ElectricPotentialChangeRate MicrovoltsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMicrovoltsPerSecond(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMicrovoltsPerSecond(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMillivoltsPerHour(double)" />
        public static ElectricPotentialChangeRate MillivoltsPerHour<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMillivoltsPerHour(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMillivoltsPerHour(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMillivoltsPerMicrosecond(double)" />
        public static ElectricPotentialChangeRate MillivoltsPerMicrosecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMillivoltsPerMicrosecond(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMillivoltsPerMicrosecond(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMillivoltsPerMinute(double)" />
        public static ElectricPotentialChangeRate MillivoltsPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMillivoltsPerMinute(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMillivoltsPerMinute(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromMillivoltsPerSecond(double)" />
        public static ElectricPotentialChangeRate MillivoltsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromMillivoltsPerSecond(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromMillivoltsPerSecond(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromVoltsPerHour(double)" />
        public static ElectricPotentialChangeRate VoltsPerHour<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromVoltsPerHour(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromVoltsPerHour(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromVoltsPerMicrosecond(double)" />
        public static ElectricPotentialChangeRate VoltsPerMicrosecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromVoltsPerMicrosecond(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromVoltsPerMicrosecond(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromVoltsPerMinute(double)" />
        public static ElectricPotentialChangeRate VoltsPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromVoltsPerMinute(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromVoltsPerMinute(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricPotentialChangeRate.FromVoltsPerSecond(double)" />
        public static ElectricPotentialChangeRate VoltsPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricPotentialChangeRate.FromVoltsPerSecond(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricPotentialChangeRate.FromVoltsPerSecond(value.ToDouble(null));
#endif

    }
}
