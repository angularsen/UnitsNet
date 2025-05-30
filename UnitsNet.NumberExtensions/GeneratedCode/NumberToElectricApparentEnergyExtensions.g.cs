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

namespace UnitsNet.NumberExtensions.NumberToElectricApparentEnergy
{
    /// <summary>
    /// A number to ElectricApparentEnergy Extensions
    /// </summary>
    public static class NumberToElectricApparentEnergyExtensions
    {
        /// <inheritdoc cref="ElectricApparentEnergy.FromKilovoltampereHours(double)" />
        public static ElectricApparentEnergy KilovoltampereHours<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricApparentEnergy.FromKilovoltampereHours(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricApparentEnergy.FromKilovoltampereHours(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricApparentEnergy.FromMegavoltampereHours(double)" />
        public static ElectricApparentEnergy MegavoltampereHours<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricApparentEnergy.FromMegavoltampereHours(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricApparentEnergy.FromMegavoltampereHours(value.ToDouble(null));
#endif

        /// <inheritdoc cref="ElectricApparentEnergy.FromVoltampereHours(double)" />
        public static ElectricApparentEnergy VoltampereHours<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricApparentEnergy.FromVoltampereHours(double.CreateChecked(value));
#else
            , IConvertible
            => ElectricApparentEnergy.FromVoltampereHours(value.ToDouble(null));
#endif

    }
}
