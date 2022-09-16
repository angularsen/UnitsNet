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

namespace OasysUnitsNet.NumberExtensions.NumberToRotationalSpeed
{
    /// <summary>
    /// A number to RotationalSpeed Extensions
    /// </summary>
    public static class NumberToRotationalSpeedExtensions
    {
        /// <inheritdoc cref="RotationalSpeed.FromCentiradiansPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed CentiradiansPerSecond<T>(this T value) =>
            RotationalSpeed.FromCentiradiansPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromDeciradiansPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed DeciradiansPerSecond<T>(this T value) =>
            RotationalSpeed.FromDeciradiansPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromDegreesPerMinute(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed DegreesPerMinute<T>(this T value) =>
            RotationalSpeed.FromDegreesPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromDegreesPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed DegreesPerSecond<T>(this T value) =>
            RotationalSpeed.FromDegreesPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromMicrodegreesPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed MicrodegreesPerSecond<T>(this T value) =>
            RotationalSpeed.FromMicrodegreesPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromMicroradiansPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed MicroradiansPerSecond<T>(this T value) =>
            RotationalSpeed.FromMicroradiansPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromMillidegreesPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed MillidegreesPerSecond<T>(this T value) =>
            RotationalSpeed.FromMillidegreesPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromMilliradiansPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed MilliradiansPerSecond<T>(this T value) =>
            RotationalSpeed.FromMilliradiansPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromNanodegreesPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed NanodegreesPerSecond<T>(this T value) =>
            RotationalSpeed.FromNanodegreesPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromNanoradiansPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed NanoradiansPerSecond<T>(this T value) =>
            RotationalSpeed.FromNanoradiansPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromRadiansPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed RadiansPerSecond<T>(this T value) =>
            RotationalSpeed.FromRadiansPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromRevolutionsPerMinute(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed RevolutionsPerMinute<T>(this T value) =>
            RotationalSpeed.FromRevolutionsPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="RotationalSpeed.FromRevolutionsPerSecond(OasysUnitsNet.QuantityValue)" />
        public static RotationalSpeed RevolutionsPerSecond<T>(this T value) =>
            RotationalSpeed.FromRevolutionsPerSecond(Convert.ToDouble(value));

    }
}
