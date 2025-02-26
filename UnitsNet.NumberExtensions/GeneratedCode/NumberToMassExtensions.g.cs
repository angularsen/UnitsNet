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

namespace UnitsNet.NumberExtensions.NumberToMass
{
    /// <summary>
    /// A number to Mass Extensions
    /// </summary>
    public static class NumberToMassExtensions
    {
        /// <inheritdoc cref="Mass.FromCentigrams(double)" />
        public static Mass Centigrams<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromCentigrams(double.CreateChecked(value));
#else
            => Mass.FromCentigrams(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromDecagrams(double)" />
        public static Mass Decagrams<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromDecagrams(double.CreateChecked(value));
#else
            => Mass.FromDecagrams(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromDecigrams(double)" />
        public static Mass Decigrams<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromDecigrams(double.CreateChecked(value));
#else
            => Mass.FromDecigrams(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromEarthMasses(double)" />
        public static Mass EarthMasses<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromEarthMasses(double.CreateChecked(value));
#else
            => Mass.FromEarthMasses(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromFemtograms(double)" />
        public static Mass Femtograms<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromFemtograms(double.CreateChecked(value));
#else
            => Mass.FromFemtograms(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromGrains(double)" />
        public static Mass Grains<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromGrains(double.CreateChecked(value));
#else
            => Mass.FromGrains(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromGrams(double)" />
        public static Mass Grams<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromGrams(double.CreateChecked(value));
#else
            => Mass.FromGrams(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromHectograms(double)" />
        public static Mass Hectograms<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromHectograms(double.CreateChecked(value));
#else
            => Mass.FromHectograms(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromKilograms(double)" />
        public static Mass Kilograms<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromKilograms(double.CreateChecked(value));
#else
            => Mass.FromKilograms(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromKilopounds(double)" />
        public static Mass Kilopounds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromKilopounds(double.CreateChecked(value));
#else
            => Mass.FromKilopounds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromKilotonnes(double)" />
        public static Mass Kilotonnes<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromKilotonnes(double.CreateChecked(value));
#else
            => Mass.FromKilotonnes(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromLongHundredweight(double)" />
        public static Mass LongHundredweight<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromLongHundredweight(double.CreateChecked(value));
#else
            => Mass.FromLongHundredweight(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromLongTons(double)" />
        public static Mass LongTons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromLongTons(double.CreateChecked(value));
#else
            => Mass.FromLongTons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromMegapounds(double)" />
        public static Mass Megapounds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromMegapounds(double.CreateChecked(value));
#else
            => Mass.FromMegapounds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromMegatonnes(double)" />
        public static Mass Megatonnes<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromMegatonnes(double.CreateChecked(value));
#else
            => Mass.FromMegatonnes(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromMicrograms(double)" />
        public static Mass Micrograms<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromMicrograms(double.CreateChecked(value));
#else
            => Mass.FromMicrograms(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromMilligrams(double)" />
        public static Mass Milligrams<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromMilligrams(double.CreateChecked(value));
#else
            => Mass.FromMilligrams(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromNanograms(double)" />
        public static Mass Nanograms<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromNanograms(double.CreateChecked(value));
#else
            => Mass.FromNanograms(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromOunces(double)" />
        public static Mass Ounces<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromOunces(double.CreateChecked(value));
#else
            => Mass.FromOunces(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromPicograms(double)" />
        public static Mass Picograms<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromPicograms(double.CreateChecked(value));
#else
            => Mass.FromPicograms(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromPounds(double)" />
        public static Mass Pounds<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromPounds(double.CreateChecked(value));
#else
            => Mass.FromPounds(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromShortHundredweight(double)" />
        public static Mass ShortHundredweight<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromShortHundredweight(double.CreateChecked(value));
#else
            => Mass.FromShortHundredweight(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromShortTons(double)" />
        public static Mass ShortTons<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromShortTons(double.CreateChecked(value));
#else
            => Mass.FromShortTons(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromSlugs(double)" />
        public static Mass Slugs<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromSlugs(double.CreateChecked(value));
#else
            => Mass.FromSlugs(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromSolarMasses(double)" />
        public static Mass SolarMasses<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromSolarMasses(double.CreateChecked(value));
#else
            => Mass.FromSolarMasses(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromStone(double)" />
        public static Mass Stone<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromStone(double.CreateChecked(value));
#else
            => Mass.FromStone(Convert.ToDouble(value));
#endif

        /// <inheritdoc cref="Mass.FromTonnes(double)" />
        public static Mass Tonnes<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Mass.FromTonnes(double.CreateChecked(value));
#else
            => Mass.FromTonnes(Convert.ToDouble(value));
#endif

    }
}
