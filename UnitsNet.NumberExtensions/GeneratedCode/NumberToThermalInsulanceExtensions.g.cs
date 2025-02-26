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

namespace UnitsNet.NumberExtensions.NumberToThermalInsulance
{
    /// <summary>
    /// A number to ThermalInsulance Extensions
    /// </summary>
    public static class NumberToThermalInsulanceExtensions
    {
        /// <inheritdoc cref="ThermalInsulance.FromHourSquareFeetDegreesFahrenheitPerBtu(double)" />
        public static ThermalInsulance HourSquareFeetDegreesFahrenheitPerBtu<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ThermalInsulance.FromHourSquareFeetDegreesFahrenheitPerBtu(double.CreateChecked(value));
#else
            => ThermalInsulance.FromHourSquareFeetDegreesFahrenheitPerBtu(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ThermalInsulance.FromSquareCentimeterHourDegreesCelsiusPerKilocalorie(double)" />
        public static ThermalInsulance SquareCentimeterHourDegreesCelsiusPerKilocalorie<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ThermalInsulance.FromSquareCentimeterHourDegreesCelsiusPerKilocalorie(double.CreateChecked(value));
#else
            => ThermalInsulance.FromSquareCentimeterHourDegreesCelsiusPerKilocalorie(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ThermalInsulance.FromSquareCentimeterKelvinsPerWatt(double)" />
        public static ThermalInsulance SquareCentimeterKelvinsPerWatt<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ThermalInsulance.FromSquareCentimeterKelvinsPerWatt(double.CreateChecked(value));
#else
            => ThermalInsulance.FromSquareCentimeterKelvinsPerWatt(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ThermalInsulance.FromSquareMeterDegreesCelsiusPerWatt(double)" />
        public static ThermalInsulance SquareMeterDegreesCelsiusPerWatt<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ThermalInsulance.FromSquareMeterDegreesCelsiusPerWatt(double.CreateChecked(value));
#else
            => ThermalInsulance.FromSquareMeterDegreesCelsiusPerWatt(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ThermalInsulance.FromSquareMeterKelvinsPerKilowatt(double)" />
        public static ThermalInsulance SquareMeterKelvinsPerKilowatt<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ThermalInsulance.FromSquareMeterKelvinsPerKilowatt(double.CreateChecked(value));
#else
            => ThermalInsulance.FromSquareMeterKelvinsPerKilowatt(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ThermalInsulance.FromSquareMeterKelvinsPerWatt(double)" />
        public static ThermalInsulance SquareMeterKelvinsPerWatt<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ThermalInsulance.FromSquareMeterKelvinsPerWatt(double.CreateChecked(value));
#else
            => ThermalInsulance.FromSquareMeterKelvinsPerWatt(Convert.ToDouble(value));
#endif

    }
}
