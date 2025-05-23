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

namespace UnitsNet.NumberExtensions.NumberToMassMomentOfInertia
{
    /// <summary>
    /// A number to MassMomentOfInertia Extensions
    /// </summary>
    public static class NumberToMassMomentOfInertiaExtensions
    {
        /// <inheritdoc cref="MassMomentOfInertia.FromGramSquareCentimeters(double)" />
        public static MassMomentOfInertia GramSquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromGramSquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromGramSquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromGramSquareDecimeters(double)" />
        public static MassMomentOfInertia GramSquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromGramSquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromGramSquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromGramSquareMeters(double)" />
        public static MassMomentOfInertia GramSquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromGramSquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromGramSquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromGramSquareMillimeters(double)" />
        public static MassMomentOfInertia GramSquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromGramSquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromGramSquareMillimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromKilogramSquareCentimeters(double)" />
        public static MassMomentOfInertia KilogramSquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromKilogramSquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromKilogramSquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromKilogramSquareDecimeters(double)" />
        public static MassMomentOfInertia KilogramSquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromKilogramSquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromKilogramSquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromKilogramSquareMeters(double)" />
        public static MassMomentOfInertia KilogramSquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromKilogramSquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromKilogramSquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromKilogramSquareMillimeters(double)" />
        public static MassMomentOfInertia KilogramSquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromKilogramSquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromKilogramSquareMillimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromKilotonneSquareCentimeters(double)" />
        public static MassMomentOfInertia KilotonneSquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromKilotonneSquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromKilotonneSquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromKilotonneSquareDecimeters(double)" />
        public static MassMomentOfInertia KilotonneSquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromKilotonneSquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromKilotonneSquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromKilotonneSquareMeters(double)" />
        public static MassMomentOfInertia KilotonneSquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromKilotonneSquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromKilotonneSquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromKilotonneSquareMillimeters(double)" />
        public static MassMomentOfInertia KilotonneSquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromKilotonneSquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromKilotonneSquareMillimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromMegatonneSquareCentimeters(double)" />
        public static MassMomentOfInertia MegatonneSquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromMegatonneSquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromMegatonneSquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromMegatonneSquareDecimeters(double)" />
        public static MassMomentOfInertia MegatonneSquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromMegatonneSquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromMegatonneSquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromMegatonneSquareMeters(double)" />
        public static MassMomentOfInertia MegatonneSquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromMegatonneSquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromMegatonneSquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromMegatonneSquareMillimeters(double)" />
        public static MassMomentOfInertia MegatonneSquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromMegatonneSquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromMegatonneSquareMillimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromMilligramSquareCentimeters(double)" />
        public static MassMomentOfInertia MilligramSquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromMilligramSquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromMilligramSquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromMilligramSquareDecimeters(double)" />
        public static MassMomentOfInertia MilligramSquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromMilligramSquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromMilligramSquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromMilligramSquareMeters(double)" />
        public static MassMomentOfInertia MilligramSquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromMilligramSquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromMilligramSquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromMilligramSquareMillimeters(double)" />
        public static MassMomentOfInertia MilligramSquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromMilligramSquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromMilligramSquareMillimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromPoundSquareFeet(double)" />
        public static MassMomentOfInertia PoundSquareFeet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromPoundSquareFeet(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromPoundSquareFeet(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromPoundSquareInches(double)" />
        public static MassMomentOfInertia PoundSquareInches<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromPoundSquareInches(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromPoundSquareInches(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromSlugSquareFeet(double)" />
        public static MassMomentOfInertia SlugSquareFeet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromSlugSquareFeet(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromSlugSquareFeet(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromSlugSquareInches(double)" />
        public static MassMomentOfInertia SlugSquareInches<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromSlugSquareInches(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromSlugSquareInches(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromTonneSquareCentimeters(double)" />
        public static MassMomentOfInertia TonneSquareCentimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromTonneSquareCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromTonneSquareCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromTonneSquareDecimeters(double)" />
        public static MassMomentOfInertia TonneSquareDecimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromTonneSquareDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromTonneSquareDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromTonneSquareMeters(double)" />
        public static MassMomentOfInertia TonneSquareMeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromTonneSquareMeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromTonneSquareMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="MassMomentOfInertia.FromTonneSquareMillimeters(double)" />
        public static MassMomentOfInertia TonneSquareMillimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => MassMomentOfInertia.FromTonneSquareMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => MassMomentOfInertia.FromTonneSquareMillimeters(value.ToDouble(null));
#endif

    }
}
