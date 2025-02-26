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

namespace UnitsNet.NumberExtensions.NumberToMolarFlow
{
    /// <summary>
    /// A number to MolarFlow Extensions
    /// </summary>
    public static class NumberToMolarFlowExtensions
    {
        /// <inheritdoc cref="MolarFlow.FromKilomolesPerHour(double)" />
        public static MolarFlow KilomolesPerHour<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MolarFlow.FromKilomolesPerHour(double.CreateChecked(value));
#else
            => MolarFlow.FromKilomolesPerHour(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="MolarFlow.FromKilomolesPerMinute(double)" />
        public static MolarFlow KilomolesPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MolarFlow.FromKilomolesPerMinute(double.CreateChecked(value));
#else
            => MolarFlow.FromKilomolesPerMinute(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="MolarFlow.FromKilomolesPerSecond(double)" />
        public static MolarFlow KilomolesPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MolarFlow.FromKilomolesPerSecond(double.CreateChecked(value));
#else
            => MolarFlow.FromKilomolesPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="MolarFlow.FromMolesPerHour(double)" />
        public static MolarFlow MolesPerHour<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MolarFlow.FromMolesPerHour(double.CreateChecked(value));
#else
            => MolarFlow.FromMolesPerHour(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="MolarFlow.FromMolesPerMinute(double)" />
        public static MolarFlow MolesPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MolarFlow.FromMolesPerMinute(double.CreateChecked(value));
#else
            => MolarFlow.FromMolesPerMinute(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="MolarFlow.FromMolesPerSecond(double)" />
        public static MolarFlow MolesPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MolarFlow.FromMolesPerSecond(double.CreateChecked(value));
#else
            => MolarFlow.FromMolesPerSecond(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="MolarFlow.FromPoundMolesPerHour(double)" />
        public static MolarFlow PoundMolesPerHour<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MolarFlow.FromPoundMolesPerHour(double.CreateChecked(value));
#else
            => MolarFlow.FromPoundMolesPerHour(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="MolarFlow.FromPoundMolesPerMinute(double)" />
        public static MolarFlow PoundMolesPerMinute<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MolarFlow.FromPoundMolesPerMinute(double.CreateChecked(value));
#else
            => MolarFlow.FromPoundMolesPerMinute(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="MolarFlow.FromPoundMolesPerSecond(double)" />
        public static MolarFlow PoundMolesPerSecond<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MolarFlow.FromPoundMolesPerSecond(double.CreateChecked(value));
#else
            => MolarFlow.FromPoundMolesPerSecond(Convert.ToDouble(value));
#endif

    }
}
