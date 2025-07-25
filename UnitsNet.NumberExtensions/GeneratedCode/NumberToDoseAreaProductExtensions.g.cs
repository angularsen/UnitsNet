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

namespace UnitsNet.NumberExtensions.NumberToDoseAreaProduct
{
    /// <summary>
    /// A number to DoseAreaProduct Extensions
    /// </summary>
    public static class NumberToDoseAreaProductExtensions
    {
        /// <inheritdoc cref="DoseAreaProduct.FromCentigraySquareCentimeters(double)" />
        public static DoseAreaProduct CentigraySquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromCentigraySquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromCentigraySquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromCentigraySquareDecimeters(double)" />
        public static DoseAreaProduct CentigraySquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromCentigraySquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromCentigraySquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromCentigraySquareMeters(double)" />
        public static DoseAreaProduct CentigraySquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromCentigraySquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromCentigraySquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromCentigraySquareMicrometers(double)" />
        public static DoseAreaProduct CentigraySquareMicrometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromCentigraySquareMicrometers(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromCentigraySquareMicrometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromCentigraySquareMillimeters(double)" />
        public static DoseAreaProduct CentigraySquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromCentigraySquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromCentigraySquareMillimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromDecigraySquareCentimeters(double)" />
        public static DoseAreaProduct DecigraySquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromDecigraySquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromDecigraySquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromDecigraySquareDecimeters(double)" />
        public static DoseAreaProduct DecigraySquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromDecigraySquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromDecigraySquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromDecigraySquareMeters(double)" />
        public static DoseAreaProduct DecigraySquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromDecigraySquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromDecigraySquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromDecigraySquareMicrometers(double)" />
        public static DoseAreaProduct DecigraySquareMicrometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromDecigraySquareMicrometers(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromDecigraySquareMicrometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromDecigraySquareMillimeters(double)" />
        public static DoseAreaProduct DecigraySquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromDecigraySquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromDecigraySquareMillimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromGraySquareCentimeters(double)" />
        public static DoseAreaProduct GraySquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromGraySquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromGraySquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromGraySquareDecimeters(double)" />
        public static DoseAreaProduct GraySquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromGraySquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromGraySquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromGraySquareMeters(double)" />
        public static DoseAreaProduct GraySquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromGraySquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromGraySquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromGraySquareMicrometers(double)" />
        public static DoseAreaProduct GraySquareMicrometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromGraySquareMicrometers(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromGraySquareMicrometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromGraySquareMillimeters(double)" />
        public static DoseAreaProduct GraySquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromGraySquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromGraySquareMillimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromMicrograySquareCentimeters(double)" />
        public static DoseAreaProduct MicrograySquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromMicrograySquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromMicrograySquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromMicrograySquareDecimeters(double)" />
        public static DoseAreaProduct MicrograySquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromMicrograySquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromMicrograySquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromMicrograySquareMeters(double)" />
        public static DoseAreaProduct MicrograySquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromMicrograySquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromMicrograySquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromMicrograySquareMicrometers(double)" />
        public static DoseAreaProduct MicrograySquareMicrometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromMicrograySquareMicrometers(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromMicrograySquareMicrometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromMicrograySquareMillimeters(double)" />
        public static DoseAreaProduct MicrograySquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromMicrograySquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromMicrograySquareMillimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromMilligraySquareCentimeters(double)" />
        public static DoseAreaProduct MilligraySquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromMilligraySquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromMilligraySquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromMilligraySquareDecimeters(double)" />
        public static DoseAreaProduct MilligraySquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromMilligraySquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromMilligraySquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromMilligraySquareMeters(double)" />
        public static DoseAreaProduct MilligraySquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromMilligraySquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromMilligraySquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromMilligraySquareMicrometers(double)" />
        public static DoseAreaProduct MilligraySquareMicrometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromMilligraySquareMicrometers(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromMilligraySquareMicrometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="DoseAreaProduct.FromMilligraySquareMillimeters(double)" />
        public static DoseAreaProduct MilligraySquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => DoseAreaProduct.FromMilligraySquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => DoseAreaProduct.FromMilligraySquareMillimeters(value.ToDouble(null));
#endif

    }
}
