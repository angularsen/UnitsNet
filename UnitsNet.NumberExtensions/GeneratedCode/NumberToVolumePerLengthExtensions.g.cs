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

namespace UnitsNet.NumberExtensions.NumberToVolumePerLength
{
    /// <summary>
    /// A number to VolumePerLength Extensions
    /// </summary>
    public static class NumberToVolumePerLengthExtensions
    {
        /// <inheritdoc cref="VolumePerLength.FromCubicMetersPerMeter(double)" />
        public static VolumePerLength CubicMetersPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => VolumePerLength.FromCubicMetersPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromCubicYardsPerFoot(double)" />
        public static VolumePerLength CubicYardsPerFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => VolumePerLength.FromCubicYardsPerFoot(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromCubicYardsPerUsSurveyFoot(double)" />
        public static VolumePerLength CubicYardsPerUsSurveyFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => VolumePerLength.FromCubicYardsPerUsSurveyFoot(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromImperialGallonsPerMile(double)" />
        public static VolumePerLength ImperialGallonsPerMile<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => VolumePerLength.FromImperialGallonsPerMile(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromLitersPerKilometer(double)" />
        public static VolumePerLength LitersPerKilometer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => VolumePerLength.FromLitersPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromLitersPerMeter(double)" />
        public static VolumePerLength LitersPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => VolumePerLength.FromLitersPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromLitersPerMillimeter(double)" />
        public static VolumePerLength LitersPerMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => VolumePerLength.FromLitersPerMillimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromOilBarrelsPerFoot(double)" />
        public static VolumePerLength OilBarrelsPerFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => VolumePerLength.FromOilBarrelsPerFoot(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromUsGallonsPerMile(double)" />
        public static VolumePerLength UsGallonsPerMile<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => VolumePerLength.FromUsGallonsPerMile(Convert.ToDouble(value));

    }
}
