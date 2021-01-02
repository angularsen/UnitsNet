﻿//------------------------------------------------------------------------------
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

namespace UnitsNet.NumberExtensions.NumberToElectricCurrentGradient
{
    /// <summary>
    /// A number to ElectricCurrentGradient Extensions
    /// </summary>
    public static class NumberToElectricCurrentGradientExtensions
    {
        /// <inheritdoc cref="ElectricCurrentGradient{T}.FromAmperesPerMicrosecond(T)" />
        public static ElectricCurrentGradient<double> AmperesPerMicrosecond<T>(this T value) =>
            ElectricCurrentGradient<double>.FromAmperesPerMicrosecond(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricCurrentGradient{T}.FromAmperesPerMillisecond(T)" />
        public static ElectricCurrentGradient<double> AmperesPerMillisecond<T>(this T value) =>
            ElectricCurrentGradient<double>.FromAmperesPerMillisecond(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricCurrentGradient{T}.FromAmperesPerNanosecond(T)" />
        public static ElectricCurrentGradient<double> AmperesPerNanosecond<T>(this T value) =>
            ElectricCurrentGradient<double>.FromAmperesPerNanosecond(Convert.ToDouble(value));

        /// <inheritdoc cref="ElectricCurrentGradient{T}.FromAmperesPerSecond(T)" />
        public static ElectricCurrentGradient<double> AmperesPerSecond<T>(this T value) =>
            ElectricCurrentGradient<double>.FromAmperesPerSecond(Convert.ToDouble(value));

    }
}
