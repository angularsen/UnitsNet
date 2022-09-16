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

namespace OasysUnitsNet.NumberExtensions.NumberToVolumePerLength
{
    /// <summary>
    /// A number to VolumePerLength Extensions
    /// </summary>
    public static class NumberToVolumePerLengthExtensions
    {
        /// <inheritdoc cref="VolumePerLength.FromCubicMetersPerMeter(OasysUnitsNet.QuantityValue)" />
        public static VolumePerLength CubicMetersPerMeter<T>(this T value) =>
            VolumePerLength.FromCubicMetersPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromCubicYardsPerFoot(OasysUnitsNet.QuantityValue)" />
        public static VolumePerLength CubicYardsPerFoot<T>(this T value) =>
            VolumePerLength.FromCubicYardsPerFoot(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromCubicYardsPerUsSurveyFoot(OasysUnitsNet.QuantityValue)" />
        public static VolumePerLength CubicYardsPerUsSurveyFoot<T>(this T value) =>
            VolumePerLength.FromCubicYardsPerUsSurveyFoot(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromLitersPerKilometer(OasysUnitsNet.QuantityValue)" />
        public static VolumePerLength LitersPerKilometer<T>(this T value) =>
            VolumePerLength.FromLitersPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromLitersPerMeter(OasysUnitsNet.QuantityValue)" />
        public static VolumePerLength LitersPerMeter<T>(this T value) =>
            VolumePerLength.FromLitersPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromLitersPerMillimeter(OasysUnitsNet.QuantityValue)" />
        public static VolumePerLength LitersPerMillimeter<T>(this T value) =>
            VolumePerLength.FromLitersPerMillimeter(Convert.ToDouble(value));

        /// <inheritdoc cref="VolumePerLength.FromOilBarrelsPerFoot(OasysUnitsNet.QuantityValue)" />
        public static VolumePerLength OilBarrelsPerFoot<T>(this T value) =>
            VolumePerLength.FromOilBarrelsPerFoot(Convert.ToDouble(value));

    }
}
