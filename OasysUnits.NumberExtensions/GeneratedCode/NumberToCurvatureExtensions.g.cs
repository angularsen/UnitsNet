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

namespace OasysUnits.NumberExtensions.NumberToCurvature
{
    /// <summary>
    /// A number to Curvature Extensions
    /// </summary>
    public static class NumberToCurvatureExtensions
    {
        /// <inheritdoc cref="Curvature.FromPerCentimeters(OasysUnits.QuantityValue)" />
        public static Curvature PerCentimeters<T>(this T value) =>
            Curvature.FromPerCentimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Curvature.FromPerFeet(OasysUnits.QuantityValue)" />
        public static Curvature PerFeet<T>(this T value) =>
            Curvature.FromPerFeet(Convert.ToDouble(value));

        /// <inheritdoc cref="Curvature.FromPerInches(OasysUnits.QuantityValue)" />
        public static Curvature PerInches<T>(this T value) =>
            Curvature.FromPerInches(Convert.ToDouble(value));

        /// <inheritdoc cref="Curvature.FromPerMeters(OasysUnits.QuantityValue)" />
        public static Curvature PerMeters<T>(this T value) =>
            Curvature.FromPerMeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Curvature.FromPerMillimeters(OasysUnits.QuantityValue)" />
        public static Curvature PerMillimeters<T>(this T value) =>
            Curvature.FromPerMillimeters(Convert.ToDouble(value));

    }
}
