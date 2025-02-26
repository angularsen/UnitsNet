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

namespace UnitsNet.NumberExtensions.NumberToForcePerLength
{
    /// <summary>
    /// A number to ForcePerLength Extensions
    /// </summary>
    public static class NumberToForcePerLengthExtensions
    {
        /// <inheritdoc cref="ForcePerLength.FromCentinewtonsPerCentimeter(double)" />
        public static ForcePerLength CentinewtonsPerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromCentinewtonsPerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromCentinewtonsPerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromCentinewtonsPerMeter(double)" />
        public static ForcePerLength CentinewtonsPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromCentinewtonsPerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromCentinewtonsPerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromCentinewtonsPerMillimeter(double)" />
        public static ForcePerLength CentinewtonsPerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromCentinewtonsPerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromCentinewtonsPerMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromDecanewtonsPerCentimeter(double)" />
        public static ForcePerLength DecanewtonsPerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromDecanewtonsPerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromDecanewtonsPerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromDecanewtonsPerMeter(double)" />
        public static ForcePerLength DecanewtonsPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromDecanewtonsPerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromDecanewtonsPerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromDecanewtonsPerMillimeter(double)" />
        public static ForcePerLength DecanewtonsPerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromDecanewtonsPerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromDecanewtonsPerMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromDecinewtonsPerCentimeter(double)" />
        public static ForcePerLength DecinewtonsPerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromDecinewtonsPerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromDecinewtonsPerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromDecinewtonsPerMeter(double)" />
        public static ForcePerLength DecinewtonsPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromDecinewtonsPerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromDecinewtonsPerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromDecinewtonsPerMillimeter(double)" />
        public static ForcePerLength DecinewtonsPerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromDecinewtonsPerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromDecinewtonsPerMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromKilogramsForcePerCentimeter(double)" />
        public static ForcePerLength KilogramsForcePerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromKilogramsForcePerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromKilogramsForcePerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromKilogramsForcePerMeter(double)" />
        public static ForcePerLength KilogramsForcePerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromKilogramsForcePerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromKilogramsForcePerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromKilogramsForcePerMillimeter(double)" />
        public static ForcePerLength KilogramsForcePerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromKilogramsForcePerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromKilogramsForcePerMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromKilonewtonsPerCentimeter(double)" />
        public static ForcePerLength KilonewtonsPerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromKilonewtonsPerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromKilonewtonsPerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromKilonewtonsPerMeter(double)" />
        public static ForcePerLength KilonewtonsPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromKilonewtonsPerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromKilonewtonsPerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromKilonewtonsPerMillimeter(double)" />
        public static ForcePerLength KilonewtonsPerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromKilonewtonsPerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromKilonewtonsPerMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromKilopoundsForcePerFoot(double)" />
        public static ForcePerLength KilopoundsForcePerFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromKilopoundsForcePerFoot(double.CreateChecked(value));
#else
            => ForcePerLength.FromKilopoundsForcePerFoot(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromKilopoundsForcePerInch(double)" />
        public static ForcePerLength KilopoundsForcePerInch<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromKilopoundsForcePerInch(double.CreateChecked(value));
#else
            => ForcePerLength.FromKilopoundsForcePerInch(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromMeganewtonsPerCentimeter(double)" />
        public static ForcePerLength MeganewtonsPerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromMeganewtonsPerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromMeganewtonsPerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromMeganewtonsPerMeter(double)" />
        public static ForcePerLength MeganewtonsPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromMeganewtonsPerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromMeganewtonsPerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromMeganewtonsPerMillimeter(double)" />
        public static ForcePerLength MeganewtonsPerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromMeganewtonsPerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromMeganewtonsPerMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromMicronewtonsPerCentimeter(double)" />
        public static ForcePerLength MicronewtonsPerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromMicronewtonsPerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromMicronewtonsPerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromMicronewtonsPerMeter(double)" />
        public static ForcePerLength MicronewtonsPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromMicronewtonsPerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromMicronewtonsPerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromMicronewtonsPerMillimeter(double)" />
        public static ForcePerLength MicronewtonsPerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromMicronewtonsPerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromMicronewtonsPerMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromMillinewtonsPerCentimeter(double)" />
        public static ForcePerLength MillinewtonsPerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromMillinewtonsPerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromMillinewtonsPerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromMillinewtonsPerMeter(double)" />
        public static ForcePerLength MillinewtonsPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromMillinewtonsPerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromMillinewtonsPerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromMillinewtonsPerMillimeter(double)" />
        public static ForcePerLength MillinewtonsPerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromMillinewtonsPerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromMillinewtonsPerMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromNanonewtonsPerCentimeter(double)" />
        public static ForcePerLength NanonewtonsPerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromNanonewtonsPerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromNanonewtonsPerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromNanonewtonsPerMeter(double)" />
        public static ForcePerLength NanonewtonsPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromNanonewtonsPerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromNanonewtonsPerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromNanonewtonsPerMillimeter(double)" />
        public static ForcePerLength NanonewtonsPerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromNanonewtonsPerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromNanonewtonsPerMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromNewtonsPerCentimeter(double)" />
        public static ForcePerLength NewtonsPerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromNewtonsPerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromNewtonsPerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromNewtonsPerMeter(double)" />
        public static ForcePerLength NewtonsPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromNewtonsPerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromNewtonsPerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromNewtonsPerMillimeter(double)" />
        public static ForcePerLength NewtonsPerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromNewtonsPerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromNewtonsPerMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromPoundsForcePerFoot(double)" />
        public static ForcePerLength PoundsForcePerFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromPoundsForcePerFoot(double.CreateChecked(value));
#else
            => ForcePerLength.FromPoundsForcePerFoot(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromPoundsForcePerInch(double)" />
        public static ForcePerLength PoundsForcePerInch<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromPoundsForcePerInch(double.CreateChecked(value));
#else
            => ForcePerLength.FromPoundsForcePerInch(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromPoundsForcePerYard(double)" />
        public static ForcePerLength PoundsForcePerYard<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromPoundsForcePerYard(double.CreateChecked(value));
#else
            => ForcePerLength.FromPoundsForcePerYard(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromTonnesForcePerCentimeter(double)" />
        public static ForcePerLength TonnesForcePerCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromTonnesForcePerCentimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromTonnesForcePerCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromTonnesForcePerMeter(double)" />
        public static ForcePerLength TonnesForcePerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromTonnesForcePerMeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromTonnesForcePerMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ForcePerLength.FromTonnesForcePerMillimeter(double)" />
        public static ForcePerLength TonnesForcePerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ForcePerLength.FromTonnesForcePerMillimeter(double.CreateChecked(value));
#else
            => ForcePerLength.FromTonnesForcePerMillimeter(Convert.ToDouble(value));
#endif

    }
}
