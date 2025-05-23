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

namespace UnitsNet.NumberExtensions.NumberToElectricReactiveEnergy
{
    /// <summary>
    /// A number to ElectricReactiveEnergy Extensions
    /// </summary>
    public static class NumberToElectricReactiveEnergyExtensions
    {
        /// <inheritdoc cref="ElectricReactiveEnergy.FromKilovoltampereReactiveHours(double)" />
        public static ElectricReactiveEnergy KilovoltampereReactiveHours<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricReactiveEnergy.FromKilovoltampereReactiveHours(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricReactiveEnergy.FromKilovoltampereReactiveHours(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricReactiveEnergy.FromMegavoltampereReactiveHours(double)" />
        public static ElectricReactiveEnergy MegavoltampereReactiveHours<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricReactiveEnergy.FromMegavoltampereReactiveHours(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricReactiveEnergy.FromMegavoltampereReactiveHours(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricReactiveEnergy.FromVoltampereReactiveHours(double)" />
        public static ElectricReactiveEnergy VoltampereReactiveHours<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricReactiveEnergy.FromVoltampereReactiveHours(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricReactiveEnergy.FromVoltampereReactiveHours(value.ToDouble(null));
#endif

    }
}
