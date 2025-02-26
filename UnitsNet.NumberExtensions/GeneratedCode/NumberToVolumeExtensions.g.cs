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

namespace UnitsNet.NumberExtensions.NumberToVolume
{
    /// <summary>
    /// A number to Volume Extensions
    /// </summary>
    public static class NumberToVolumeExtensions
    {
        /// <inheritdoc cref="Volume.FromAcreFeet(double)" />
        public static Volume AcreFeet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromAcreFeet(double.CreateChecked(value));
#else
            => Volume.FromAcreFeet(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromAuTablespoons(double)" />
        public static Volume AuTablespoons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromAuTablespoons(double.CreateChecked(value));
#else
            => Volume.FromAuTablespoons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromBoardFeet(double)" />
        public static Volume BoardFeet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromBoardFeet(double.CreateChecked(value));
#else
            => Volume.FromBoardFeet(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCentiliters(double)" />
        public static Volume Centiliters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCentiliters(double.CreateChecked(value));
#else
            => Volume.FromCentiliters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicCentimeters(double)" />
        public static Volume CubicCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicCentimeters(double.CreateChecked(value));
#else
            => Volume.FromCubicCentimeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicDecimeters(double)" />
        public static Volume CubicDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicDecimeters(double.CreateChecked(value));
#else
            => Volume.FromCubicDecimeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicFeet(double)" />
        public static Volume CubicFeet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicFeet(double.CreateChecked(value));
#else
            => Volume.FromCubicFeet(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicHectometers(double)" />
        public static Volume CubicHectometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicHectometers(double.CreateChecked(value));
#else
            => Volume.FromCubicHectometers(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicInches(double)" />
        public static Volume CubicInches<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicInches(double.CreateChecked(value));
#else
            => Volume.FromCubicInches(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicKilometers(double)" />
        public static Volume CubicKilometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicKilometers(double.CreateChecked(value));
#else
            => Volume.FromCubicKilometers(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicMeters(double)" />
        public static Volume CubicMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicMeters(double.CreateChecked(value));
#else
            => Volume.FromCubicMeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicMicrometers(double)" />
        public static Volume CubicMicrometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicMicrometers(double.CreateChecked(value));
#else
            => Volume.FromCubicMicrometers(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicMiles(double)" />
        public static Volume CubicMiles<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicMiles(double.CreateChecked(value));
#else
            => Volume.FromCubicMiles(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicMillimeters(double)" />
        public static Volume CubicMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicMillimeters(double.CreateChecked(value));
#else
            => Volume.FromCubicMillimeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromCubicYards(double)" />
        public static Volume CubicYards<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromCubicYards(double.CreateChecked(value));
#else
            => Volume.FromCubicYards(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromDecaliters(double)" />
        public static Volume Decaliters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromDecaliters(double.CreateChecked(value));
#else
            => Volume.FromDecaliters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromDecausGallons(double)" />
        public static Volume DecausGallons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromDecausGallons(double.CreateChecked(value));
#else
            => Volume.FromDecausGallons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromDeciliters(double)" />
        public static Volume Deciliters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromDeciliters(double.CreateChecked(value));
#else
            => Volume.FromDeciliters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromDeciusGallons(double)" />
        public static Volume DeciusGallons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromDeciusGallons(double.CreateChecked(value));
#else
            => Volume.FromDeciusGallons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromHectocubicFeet(double)" />
        public static Volume HectocubicFeet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromHectocubicFeet(double.CreateChecked(value));
#else
            => Volume.FromHectocubicFeet(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromHectocubicMeters(double)" />
        public static Volume HectocubicMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromHectocubicMeters(double.CreateChecked(value));
#else
            => Volume.FromHectocubicMeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromHectoliters(double)" />
        public static Volume Hectoliters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromHectoliters(double.CreateChecked(value));
#else
            => Volume.FromHectoliters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromHectousGallons(double)" />
        public static Volume HectousGallons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromHectousGallons(double.CreateChecked(value));
#else
            => Volume.FromHectousGallons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromImperialBeerBarrels(double)" />
        public static Volume ImperialBeerBarrels<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromImperialBeerBarrels(double.CreateChecked(value));
#else
            => Volume.FromImperialBeerBarrels(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromImperialGallons(double)" />
        public static Volume ImperialGallons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromImperialGallons(double.CreateChecked(value));
#else
            => Volume.FromImperialGallons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromImperialOunces(double)" />
        public static Volume ImperialOunces<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromImperialOunces(double.CreateChecked(value));
#else
            => Volume.FromImperialOunces(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromImperialPints(double)" />
        public static Volume ImperialPints<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromImperialPints(double.CreateChecked(value));
#else
            => Volume.FromImperialPints(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromImperialQuarts(double)" />
        public static Volume ImperialQuarts<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromImperialQuarts(double.CreateChecked(value));
#else
            => Volume.FromImperialQuarts(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromKilocubicFeet(double)" />
        public static Volume KilocubicFeet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromKilocubicFeet(double.CreateChecked(value));
#else
            => Volume.FromKilocubicFeet(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromKilocubicMeters(double)" />
        public static Volume KilocubicMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromKilocubicMeters(double.CreateChecked(value));
#else
            => Volume.FromKilocubicMeters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromKiloimperialGallons(double)" />
        public static Volume KiloimperialGallons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromKiloimperialGallons(double.CreateChecked(value));
#else
            => Volume.FromKiloimperialGallons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromKiloliters(double)" />
        public static Volume Kiloliters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromKiloliters(double.CreateChecked(value));
#else
            => Volume.FromKiloliters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromKilousGallons(double)" />
        public static Volume KilousGallons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromKilousGallons(double.CreateChecked(value));
#else
            => Volume.FromKilousGallons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromLiters(double)" />
        public static Volume Liters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromLiters(double.CreateChecked(value));
#else
            => Volume.FromLiters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromMegacubicFeet(double)" />
        public static Volume MegacubicFeet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromMegacubicFeet(double.CreateChecked(value));
#else
            => Volume.FromMegacubicFeet(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromMegaimperialGallons(double)" />
        public static Volume MegaimperialGallons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromMegaimperialGallons(double.CreateChecked(value));
#else
            => Volume.FromMegaimperialGallons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromMegaliters(double)" />
        public static Volume Megaliters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromMegaliters(double.CreateChecked(value));
#else
            => Volume.FromMegaliters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromMegausGallons(double)" />
        public static Volume MegausGallons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromMegausGallons(double.CreateChecked(value));
#else
            => Volume.FromMegausGallons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromMetricCups(double)" />
        public static Volume MetricCups<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromMetricCups(double.CreateChecked(value));
#else
            => Volume.FromMetricCups(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromMetricTeaspoons(double)" />
        public static Volume MetricTeaspoons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromMetricTeaspoons(double.CreateChecked(value));
#else
            => Volume.FromMetricTeaspoons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromMicroliters(double)" />
        public static Volume Microliters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromMicroliters(double.CreateChecked(value));
#else
            => Volume.FromMicroliters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromMilliliters(double)" />
        public static Volume Milliliters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromMilliliters(double.CreateChecked(value));
#else
            => Volume.FromMilliliters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromNanoliters(double)" />
        public static Volume Nanoliters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromNanoliters(double.CreateChecked(value));
#else
            => Volume.FromNanoliters(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromOilBarrels(double)" />
        public static Volume OilBarrels<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromOilBarrels(double.CreateChecked(value));
#else
            => Volume.FromOilBarrels(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromUkTablespoons(double)" />
        public static Volume UkTablespoons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromUkTablespoons(double.CreateChecked(value));
#else
            => Volume.FromUkTablespoons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromUsBeerBarrels(double)" />
        public static Volume UsBeerBarrels<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromUsBeerBarrels(double.CreateChecked(value));
#else
            => Volume.FromUsBeerBarrels(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromUsCustomaryCups(double)" />
        public static Volume UsCustomaryCups<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromUsCustomaryCups(double.CreateChecked(value));
#else
            => Volume.FromUsCustomaryCups(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromUsGallons(double)" />
        public static Volume UsGallons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromUsGallons(double.CreateChecked(value));
#else
            => Volume.FromUsGallons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromUsLegalCups(double)" />
        public static Volume UsLegalCups<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromUsLegalCups(double.CreateChecked(value));
#else
            => Volume.FromUsLegalCups(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromUsOunces(double)" />
        public static Volume UsOunces<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromUsOunces(double.CreateChecked(value));
#else
            => Volume.FromUsOunces(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromUsPints(double)" />
        public static Volume UsPints<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromUsPints(double.CreateChecked(value));
#else
            => Volume.FromUsPints(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromUsQuarts(double)" />
        public static Volume UsQuarts<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromUsQuarts(double.CreateChecked(value));
#else
            => Volume.FromUsQuarts(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromUsTablespoons(double)" />
        public static Volume UsTablespoons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromUsTablespoons(double.CreateChecked(value));
#else
            => Volume.FromUsTablespoons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Volume.FromUsTeaspoons(double)" />
        public static Volume UsTeaspoons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Volume.FromUsTeaspoons(double.CreateChecked(value));
#else
            => Volume.FromUsTeaspoons(Convert.ToDouble(value));
#endif

    }
}
