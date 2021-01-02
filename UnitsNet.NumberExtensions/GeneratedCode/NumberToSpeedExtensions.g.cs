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

namespace UnitsNet.NumberExtensions.NumberToSpeed
{
    /// <summary>
    /// A number to Speed Extensions
    /// </summary>
    public static class NumberToSpeedExtensions
    {
        /// <inheritdoc cref="Speed{T}.FromCentimetersPerHour(T)" />
        public static Speed<double> CentimetersPerHour<T>(this T value) =>
            Speed<double>.FromCentimetersPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromCentimetersPerMinutes(T)" />
        public static Speed<double> CentimetersPerMinutes<T>(this T value) =>
            Speed<double>.FromCentimetersPerMinutes(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromCentimetersPerSecond(T)" />
        public static Speed<double> CentimetersPerSecond<T>(this T value) =>
            Speed<double>.FromCentimetersPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromDecimetersPerMinutes(T)" />
        public static Speed<double> DecimetersPerMinutes<T>(this T value) =>
            Speed<double>.FromDecimetersPerMinutes(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromDecimetersPerSecond(T)" />
        public static Speed<double> DecimetersPerSecond<T>(this T value) =>
            Speed<double>.FromDecimetersPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromFeetPerHour(T)" />
        public static Speed<double> FeetPerHour<T>(this T value) =>
            Speed<double>.FromFeetPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromFeetPerMinute(T)" />
        public static Speed<double> FeetPerMinute<T>(this T value) =>
            Speed<double>.FromFeetPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromFeetPerSecond(T)" />
        public static Speed<double> FeetPerSecond<T>(this T value) =>
            Speed<double>.FromFeetPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromInchesPerHour(T)" />
        public static Speed<double> InchesPerHour<T>(this T value) =>
            Speed<double>.FromInchesPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromInchesPerMinute(T)" />
        public static Speed<double> InchesPerMinute<T>(this T value) =>
            Speed<double>.FromInchesPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromInchesPerSecond(T)" />
        public static Speed<double> InchesPerSecond<T>(this T value) =>
            Speed<double>.FromInchesPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromKilometersPerHour(T)" />
        public static Speed<double> KilometersPerHour<T>(this T value) =>
            Speed<double>.FromKilometersPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromKilometersPerMinutes(T)" />
        public static Speed<double> KilometersPerMinutes<T>(this T value) =>
            Speed<double>.FromKilometersPerMinutes(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromKilometersPerSecond(T)" />
        public static Speed<double> KilometersPerSecond<T>(this T value) =>
            Speed<double>.FromKilometersPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromKnots(T)" />
        public static Speed<double> Knots<T>(this T value) =>
            Speed<double>.FromKnots(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromMetersPerHour(T)" />
        public static Speed<double> MetersPerHour<T>(this T value) =>
            Speed<double>.FromMetersPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromMetersPerMinutes(T)" />
        public static Speed<double> MetersPerMinutes<T>(this T value) =>
            Speed<double>.FromMetersPerMinutes(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromMetersPerSecond(T)" />
        public static Speed<double> MetersPerSecond<T>(this T value) =>
            Speed<double>.FromMetersPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromMicrometersPerMinutes(T)" />
        public static Speed<double> MicrometersPerMinutes<T>(this T value) =>
            Speed<double>.FromMicrometersPerMinutes(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromMicrometersPerSecond(T)" />
        public static Speed<double> MicrometersPerSecond<T>(this T value) =>
            Speed<double>.FromMicrometersPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromMilesPerHour(T)" />
        public static Speed<double> MilesPerHour<T>(this T value) =>
            Speed<double>.FromMilesPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromMillimetersPerHour(T)" />
        public static Speed<double> MillimetersPerHour<T>(this T value) =>
            Speed<double>.FromMillimetersPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromMillimetersPerMinutes(T)" />
        public static Speed<double> MillimetersPerMinutes<T>(this T value) =>
            Speed<double>.FromMillimetersPerMinutes(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromMillimetersPerSecond(T)" />
        public static Speed<double> MillimetersPerSecond<T>(this T value) =>
            Speed<double>.FromMillimetersPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromNanometersPerMinutes(T)" />
        public static Speed<double> NanometersPerMinutes<T>(this T value) =>
            Speed<double>.FromNanometersPerMinutes(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromNanometersPerSecond(T)" />
        public static Speed<double> NanometersPerSecond<T>(this T value) =>
            Speed<double>.FromNanometersPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromUsSurveyFeetPerHour(T)" />
        public static Speed<double> UsSurveyFeetPerHour<T>(this T value) =>
            Speed<double>.FromUsSurveyFeetPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromUsSurveyFeetPerMinute(T)" />
        public static Speed<double> UsSurveyFeetPerMinute<T>(this T value) =>
            Speed<double>.FromUsSurveyFeetPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromUsSurveyFeetPerSecond(T)" />
        public static Speed<double> UsSurveyFeetPerSecond<T>(this T value) =>
            Speed<double>.FromUsSurveyFeetPerSecond(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromYardsPerHour(T)" />
        public static Speed<double> YardsPerHour<T>(this T value) =>
            Speed<double>.FromYardsPerHour(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromYardsPerMinute(T)" />
        public static Speed<double> YardsPerMinute<T>(this T value) =>
            Speed<double>.FromYardsPerMinute(Convert.ToDouble(value));

        /// <inheritdoc cref="Speed{T}.FromYardsPerSecond(T)" />
        public static Speed<double> YardsPerSecond<T>(this T value) =>
            Speed<double>.FromYardsPerSecond(Convert.ToDouble(value));

    }
}
