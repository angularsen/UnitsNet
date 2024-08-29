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

namespace UnitsNet.NumberExtensions.NumberToEnergyEfficiency
{
    /// <summary>
    /// A number to EnergyEfficiency Extensions
    /// </summary>
    public static class NumberToEnergyEfficiencyExtensions
    {
        /// <inheritdoc cref="EnergyEfficiency.FromFemtowattHoursPerKilometer(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency FemtowattHoursPerKilometer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromFemtowattHoursPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromFemtowattHoursPerMeter(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency FemtowattHoursPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromFemtowattHoursPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromGigawattHoursPerKilometer(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency GigawattHoursPerKilometer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromGigawattHoursPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromGigawattHoursPerMeter(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency GigawattHoursPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromGigawattHoursPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromKilowattHoursPerKilometer(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency KilowattHoursPerKilometer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromKilowattHoursPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromKilowattHoursPerMeter(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency KilowattHoursPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromKilowattHoursPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromMegawattHoursPerKilometer(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency MegawattHoursPerKilometer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromMegawattHoursPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromMegawattHoursPerMeter(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency MegawattHoursPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromMegawattHoursPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromMicrowattHoursPerKilometer(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency MicrowattHoursPerKilometer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromMicrowattHoursPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromMicrowattHoursPerMeter(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency MicrowattHoursPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromMicrowattHoursPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromMilliwattHoursPerKilometer(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency MilliwattHoursPerKilometer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromMilliwattHoursPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromMilliwattHoursPerMeter(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency MilliwattHoursPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromMilliwattHoursPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromNanowattHoursPerKilometer(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency NanowattHoursPerKilometer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromNanowattHoursPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromNanowattHoursPerMeter(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency NanowattHoursPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromNanowattHoursPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromPicowattHoursPerKilometer(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency PicowattHoursPerKilometer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromPicowattHoursPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromPicowattHoursPerMeter(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency PicowattHoursPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromPicowattHoursPerMeter(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromWattHoursPerKilometer(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency WattHoursPerKilometer<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromWattHoursPerKilometer(Convert.ToDouble(value));

        /// <inheritdoc cref="EnergyEfficiency.FromWattHoursPerMeter(UnitsNet.QuantityValue)" />
        public static EnergyEfficiency WattHoursPerMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
#endif
            => EnergyEfficiency.FromWattHoursPerMeter(Convert.ToDouble(value));

    }
}
