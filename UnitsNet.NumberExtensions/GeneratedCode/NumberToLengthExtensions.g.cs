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

namespace UnitsNet.NumberExtensions.NumberToLength
{
    /// <summary>
    /// A number to Length Extensions
    /// </summary>
    public static class NumberToLengthExtensions
    {
        /// <inheritdoc cref="Length.FromAngstroms(double)" />
        public static Length Angstroms<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromAngstroms(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromAngstroms(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromAstronomicalUnits(double)" />
        public static Length AstronomicalUnits<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromAstronomicalUnits(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromAstronomicalUnits(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromCentimeters(double)" />
        public static Length Centimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromCentimeters(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromCentimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromChains(double)" />
        public static Length Chains<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromChains(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromChains(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromDataMiles(double)" />
        public static Length DataMiles<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromDataMiles(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromDataMiles(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromDecameters(double)" />
        public static Length Decameters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromDecameters(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromDecameters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromDecimeters(double)" />
        public static Length Decimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromDecimeters(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromDecimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromDtpPicas(double)" />
        public static Length DtpPicas<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromDtpPicas(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromDtpPicas(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromDtpPoints(double)" />
        public static Length DtpPoints<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromDtpPoints(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromDtpPoints(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromFathoms(double)" />
        public static Length Fathoms<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromFathoms(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromFathoms(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromFemtometers(double)" />
        public static Length Femtometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromFemtometers(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromFemtometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromFeet(double)" />
        public static Length Feet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromFeet(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromFeet(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromGigameters(double)" />
        public static Length Gigameters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromGigameters(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromGigameters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromHands(double)" />
        public static Length Hands<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromHands(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromHands(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromHectometers(double)" />
        public static Length Hectometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromHectometers(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromHectometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromInches(double)" />
        public static Length Inches<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromInches(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromInches(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromKilofeet(double)" />
        public static Length Kilofeet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromKilofeet(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromKilofeet(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromKilolightYears(double)" />
        public static Length KilolightYears<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromKilolightYears(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromKilolightYears(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromKilometers(double)" />
        public static Length Kilometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromKilometers(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromKilometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromKiloparsecs(double)" />
        public static Length Kiloparsecs<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromKiloparsecs(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromKiloparsecs(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromKiloyards(double)" />
        public static Length Kiloyards<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromKiloyards(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromKiloyards(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromLightYears(double)" />
        public static Length LightYears<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromLightYears(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromLightYears(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromMegalightYears(double)" />
        public static Length MegalightYears<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromMegalightYears(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromMegalightYears(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromMegameters(double)" />
        public static Length Megameters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromMegameters(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromMegameters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromMegaparsecs(double)" />
        public static Length Megaparsecs<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromMegaparsecs(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromMegaparsecs(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromMeters(double)" />
        public static Length Meters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromMeters(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromMeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromMicroinches(double)" />
        public static Length Microinches<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromMicroinches(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromMicroinches(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromMicrometers(double)" />
        public static Length Micrometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromMicrometers(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromMicrometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromMils(double)" />
        public static Length Mils<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromMils(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromMils(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromMiles(double)" />
        public static Length Miles<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromMiles(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromMiles(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromMillimeters(double)" />
        public static Length Millimeters<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromMillimeters(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromMillimeters(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromNanometers(double)" />
        public static Length Nanometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromNanometers(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromNanometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromNauticalMiles(double)" />
        public static Length NauticalMiles<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromNauticalMiles(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromNauticalMiles(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromParsecs(double)" />
        public static Length Parsecs<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromParsecs(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromParsecs(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromPicometers(double)" />
        public static Length Picometers<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromPicometers(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromPicometers(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromPrinterPicas(double)" />
        public static Length PrinterPicas<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromPrinterPicas(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromPrinterPicas(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromPrinterPoints(double)" />
        public static Length PrinterPoints<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromPrinterPoints(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromPrinterPoints(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromShackles(double)" />
        public static Length Shackles<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromShackles(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromShackles(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromSolarRadiuses(double)" />
        public static Length SolarRadiuses<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromSolarRadiuses(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromSolarRadiuses(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromTwips(double)" />
        public static Length Twips<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromTwips(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromTwips(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromUsSurveyFeet(double)" />
        public static Length UsSurveyFeet<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromUsSurveyFeet(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromUsSurveyFeet(value.ToDouble(null));
#endif

        /// <inheritdoc cref="Length.FromYards(double)" />
        public static Length Yards<T>(this T value)
            where T : notnull
#if NET7_0_OR_GREATER
            , INumber<T>
            => Length.FromYards(double.CreateChecked(value));
#else
            , IConvertible
            => Length.FromYards(value.ToDouble(null));
#endif

    }
}
