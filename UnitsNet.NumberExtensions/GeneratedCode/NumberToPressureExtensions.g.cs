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

namespace UnitsNet.NumberExtensions.NumberToPressure
{
    /// <summary>
    /// A number to Pressure Extensions
    /// </summary>
    public static class NumberToPressureExtensions
    {
        /// <inheritdoc cref="Pressure.FromAtmospheres(double)" />
        public static Pressure Atmospheres<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromAtmospheres(double.CreateChecked(value));
#else
            => Pressure.FromAtmospheres(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromBars(double)" />
        public static Pressure Bars<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromBars(double.CreateChecked(value));
#else
            => Pressure.FromBars(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromCentibars(double)" />
        public static Pressure Centibars<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromCentibars(double.CreateChecked(value));
#else
            => Pressure.FromCentibars(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromCentimetersOfWaterColumn(double)" />
        public static Pressure CentimetersOfWaterColumn<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromCentimetersOfWaterColumn(double.CreateChecked(value));
#else
            => Pressure.FromCentimetersOfWaterColumn(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromDecapascals(double)" />
        public static Pressure Decapascals<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromDecapascals(double.CreateChecked(value));
#else
            => Pressure.FromDecapascals(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromDecibars(double)" />
        public static Pressure Decibars<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromDecibars(double.CreateChecked(value));
#else
            => Pressure.FromDecibars(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromDynesPerSquareCentimeter(double)" />
        public static Pressure DynesPerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromDynesPerSquareCentimeter(double.CreateChecked(value));
#else
            => Pressure.FromDynesPerSquareCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromFeetOfElevation(double)" />
        public static Pressure FeetOfElevation<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromFeetOfElevation(double.CreateChecked(value));
#else
            => Pressure.FromFeetOfElevation(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromFeetOfHead(double)" />
        public static Pressure FeetOfHead<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromFeetOfHead(double.CreateChecked(value));
#else
            => Pressure.FromFeetOfHead(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromGigapascals(double)" />
        public static Pressure Gigapascals<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromGigapascals(double.CreateChecked(value));
#else
            => Pressure.FromGigapascals(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromHectopascals(double)" />
        public static Pressure Hectopascals<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromHectopascals(double.CreateChecked(value));
#else
            => Pressure.FromHectopascals(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromInchesOfMercury(double)" />
        public static Pressure InchesOfMercury<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromInchesOfMercury(double.CreateChecked(value));
#else
            => Pressure.FromInchesOfMercury(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromInchesOfWaterColumn(double)" />
        public static Pressure InchesOfWaterColumn<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromInchesOfWaterColumn(double.CreateChecked(value));
#else
            => Pressure.FromInchesOfWaterColumn(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilobars(double)" />
        public static Pressure Kilobars<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilobars(double.CreateChecked(value));
#else
            => Pressure.FromKilobars(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilogramsForcePerSquareCentimeter(double)" />
        public static Pressure KilogramsForcePerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilogramsForcePerSquareCentimeter(double.CreateChecked(value));
#else
            => Pressure.FromKilogramsForcePerSquareCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilogramsForcePerSquareMeter(double)" />
        public static Pressure KilogramsForcePerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilogramsForcePerSquareMeter(double.CreateChecked(value));
#else
            => Pressure.FromKilogramsForcePerSquareMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilogramsForcePerSquareMillimeter(double)" />
        public static Pressure KilogramsForcePerSquareMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilogramsForcePerSquareMillimeter(double.CreateChecked(value));
#else
            => Pressure.FromKilogramsForcePerSquareMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilonewtonsPerSquareCentimeter(double)" />
        public static Pressure KilonewtonsPerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilonewtonsPerSquareCentimeter(double.CreateChecked(value));
#else
            => Pressure.FromKilonewtonsPerSquareCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilonewtonsPerSquareMeter(double)" />
        public static Pressure KilonewtonsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilonewtonsPerSquareMeter(double.CreateChecked(value));
#else
            => Pressure.FromKilonewtonsPerSquareMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilonewtonsPerSquareMillimeter(double)" />
        public static Pressure KilonewtonsPerSquareMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilonewtonsPerSquareMillimeter(double.CreateChecked(value));
#else
            => Pressure.FromKilonewtonsPerSquareMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilopascals(double)" />
        public static Pressure Kilopascals<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilopascals(double.CreateChecked(value));
#else
            => Pressure.FromKilopascals(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilopoundsForcePerSquareFoot(double)" />
        public static Pressure KilopoundsForcePerSquareFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilopoundsForcePerSquareFoot(double.CreateChecked(value));
#else
            => Pressure.FromKilopoundsForcePerSquareFoot(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilopoundsForcePerSquareInch(double)" />
        public static Pressure KilopoundsForcePerSquareInch<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilopoundsForcePerSquareInch(double.CreateChecked(value));
#else
            => Pressure.FromKilopoundsForcePerSquareInch(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromKilopoundsForcePerSquareMil(double)" />
        public static Pressure KilopoundsForcePerSquareMil<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromKilopoundsForcePerSquareMil(double.CreateChecked(value));
#else
            => Pressure.FromKilopoundsForcePerSquareMil(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMegabars(double)" />
        public static Pressure Megabars<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMegabars(double.CreateChecked(value));
#else
            => Pressure.FromMegabars(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMeganewtonsPerSquareMeter(double)" />
        public static Pressure MeganewtonsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMeganewtonsPerSquareMeter(double.CreateChecked(value));
#else
            => Pressure.FromMeganewtonsPerSquareMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMegapascals(double)" />
        public static Pressure Megapascals<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMegapascals(double.CreateChecked(value));
#else
            => Pressure.FromMegapascals(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMetersOfElevation(double)" />
        public static Pressure MetersOfElevation<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMetersOfElevation(double.CreateChecked(value));
#else
            => Pressure.FromMetersOfElevation(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMetersOfHead(double)" />
        public static Pressure MetersOfHead<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMetersOfHead(double.CreateChecked(value));
#else
            => Pressure.FromMetersOfHead(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMetersOfWaterColumn(double)" />
        public static Pressure MetersOfWaterColumn<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMetersOfWaterColumn(double.CreateChecked(value));
#else
            => Pressure.FromMetersOfWaterColumn(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMicrobars(double)" />
        public static Pressure Microbars<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMicrobars(double.CreateChecked(value));
#else
            => Pressure.FromMicrobars(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMicropascals(double)" />
        public static Pressure Micropascals<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMicropascals(double.CreateChecked(value));
#else
            => Pressure.FromMicropascals(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMillibars(double)" />
        public static Pressure Millibars<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMillibars(double.CreateChecked(value));
#else
            => Pressure.FromMillibars(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMillimetersOfMercury(double)" />
        public static Pressure MillimetersOfMercury<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMillimetersOfMercury(double.CreateChecked(value));
#else
            => Pressure.FromMillimetersOfMercury(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMillimetersOfWaterColumn(double)" />
        public static Pressure MillimetersOfWaterColumn<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMillimetersOfWaterColumn(double.CreateChecked(value));
#else
            => Pressure.FromMillimetersOfWaterColumn(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromMillipascals(double)" />
        public static Pressure Millipascals<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromMillipascals(double.CreateChecked(value));
#else
            => Pressure.FromMillipascals(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromNewtonsPerSquareCentimeter(double)" />
        public static Pressure NewtonsPerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromNewtonsPerSquareCentimeter(double.CreateChecked(value));
#else
            => Pressure.FromNewtonsPerSquareCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromNewtonsPerSquareMeter(double)" />
        public static Pressure NewtonsPerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromNewtonsPerSquareMeter(double.CreateChecked(value));
#else
            => Pressure.FromNewtonsPerSquareMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromNewtonsPerSquareMillimeter(double)" />
        public static Pressure NewtonsPerSquareMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromNewtonsPerSquareMillimeter(double.CreateChecked(value));
#else
            => Pressure.FromNewtonsPerSquareMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromPascals(double)" />
        public static Pressure Pascals<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromPascals(double.CreateChecked(value));
#else
            => Pressure.FromPascals(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromPoundsForcePerSquareFoot(double)" />
        public static Pressure PoundsForcePerSquareFoot<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromPoundsForcePerSquareFoot(double.CreateChecked(value));
#else
            => Pressure.FromPoundsForcePerSquareFoot(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromPoundsForcePerSquareInch(double)" />
        public static Pressure PoundsForcePerSquareInch<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromPoundsForcePerSquareInch(double.CreateChecked(value));
#else
            => Pressure.FromPoundsForcePerSquareInch(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromPoundsForcePerSquareMil(double)" />
        public static Pressure PoundsForcePerSquareMil<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromPoundsForcePerSquareMil(double.CreateChecked(value));
#else
            => Pressure.FromPoundsForcePerSquareMil(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromPoundsPerInchSecondSquared(double)" />
        public static Pressure PoundsPerInchSecondSquared<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromPoundsPerInchSecondSquared(double.CreateChecked(value));
#else
            => Pressure.FromPoundsPerInchSecondSquared(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromTechnicalAtmospheres(double)" />
        public static Pressure TechnicalAtmospheres<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromTechnicalAtmospheres(double.CreateChecked(value));
#else
            => Pressure.FromTechnicalAtmospheres(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromTonnesForcePerSquareCentimeter(double)" />
        public static Pressure TonnesForcePerSquareCentimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromTonnesForcePerSquareCentimeter(double.CreateChecked(value));
#else
            => Pressure.FromTonnesForcePerSquareCentimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromTonnesForcePerSquareMeter(double)" />
        public static Pressure TonnesForcePerSquareMeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromTonnesForcePerSquareMeter(double.CreateChecked(value));
#else
            => Pressure.FromTonnesForcePerSquareMeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromTonnesForcePerSquareMillimeter(double)" />
        public static Pressure TonnesForcePerSquareMillimeter<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromTonnesForcePerSquareMillimeter(double.CreateChecked(value));
#else
            => Pressure.FromTonnesForcePerSquareMillimeter(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Pressure.FromTorrs(double)" />
        public static Pressure Torrs<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Pressure.FromTorrs(double.CreateChecked(value));
#else
            => Pressure.FromTorrs(Convert.ToDouble(value));
#endif

    }
}
