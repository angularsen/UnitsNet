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

namespace UnitsNet.NumberExtensions.NumberToElectricResistivity
{
    /// <summary>
    /// A number to ElectricResistivity Extensions
    /// </summary>
    public static class NumberToElectricResistivityExtensions
    {
        /// <inheritdoc cref="ElectricResistivity.FromKiloohmsCentimeter(double)" />
        public static ElectricResistivity KiloohmsCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromKiloohmsCentimeter(double.CreateChecked(value));
#else
            => ElectricResistivity.FromKiloohmsCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromKiloohmMeters(double)" />
        public static ElectricResistivity KiloohmMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromKiloohmMeters(double.CreateChecked(value));
#else
            => ElectricResistivity.FromKiloohmMeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromMegaohmsCentimeter(double)" />
        public static ElectricResistivity MegaohmsCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromMegaohmsCentimeter(double.CreateChecked(value));
#else
            => ElectricResistivity.FromMegaohmsCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromMegaohmMeters(double)" />
        public static ElectricResistivity MegaohmMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromMegaohmMeters(double.CreateChecked(value));
#else
            => ElectricResistivity.FromMegaohmMeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromMicroohmsCentimeter(double)" />
        public static ElectricResistivity MicroohmsCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromMicroohmsCentimeter(double.CreateChecked(value));
#else
            => ElectricResistivity.FromMicroohmsCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromMicroohmMeters(double)" />
        public static ElectricResistivity MicroohmMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromMicroohmMeters(double.CreateChecked(value));
#else
            => ElectricResistivity.FromMicroohmMeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromMilliohmsCentimeter(double)" />
        public static ElectricResistivity MilliohmsCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromMilliohmsCentimeter(double.CreateChecked(value));
#else
            => ElectricResistivity.FromMilliohmsCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromMilliohmMeters(double)" />
        public static ElectricResistivity MilliohmMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromMilliohmMeters(double.CreateChecked(value));
#else
            => ElectricResistivity.FromMilliohmMeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromNanoohmsCentimeter(double)" />
        public static ElectricResistivity NanoohmsCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromNanoohmsCentimeter(double.CreateChecked(value));
#else
            => ElectricResistivity.FromNanoohmsCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromNanoohmMeters(double)" />
        public static ElectricResistivity NanoohmMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromNanoohmMeters(double.CreateChecked(value));
#else
            => ElectricResistivity.FromNanoohmMeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromOhmsCentimeter(double)" />
        public static ElectricResistivity OhmsCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromOhmsCentimeter(double.CreateChecked(value));
#else
            => ElectricResistivity.FromOhmsCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromOhmMeters(double)" />
        public static ElectricResistivity OhmMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromOhmMeters(double.CreateChecked(value));
#else
            => ElectricResistivity.FromOhmMeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromPicoohmsCentimeter(double)" />
        public static ElectricResistivity PicoohmsCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromPicoohmsCentimeter(double.CreateChecked(value));
#else
            => ElectricResistivity.FromPicoohmsCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="ElectricResistivity.FromPicoohmMeters(double)" />
        public static ElectricResistivity PicoohmMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => ElectricResistivity.FromPicoohmMeters(double.CreateChecked(value));
#else
            => ElectricResistivity.FromPicoohmMeters(Convert.ToDouble(value));
#endif

    }
}
