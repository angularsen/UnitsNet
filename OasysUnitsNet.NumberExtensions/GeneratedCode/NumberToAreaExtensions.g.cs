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

#nullable enable

namespace OasysUnitsNet.NumberExtensions.NumberToArea
{
    /// <summary>
    /// A number to Area Extensions
    /// </summary>
    public static class NumberToAreaExtensions
    {
        /// <inheritdoc cref="Area.FromAcres(OasysUnitsNet.QuantityValue)" />
        public static Area Acres<T>(this T value) =>
            Area.FromAcres(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromHectares(OasysUnitsNet.QuantityValue)" />
        public static Area Hectares<T>(this T value) =>
            Area.FromHectares(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareCentimeters(OasysUnitsNet.QuantityValue)" />
        public static Area SquareCentimeters<T>(this T value) =>
            Area.FromSquareCentimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareDecimeters(OasysUnitsNet.QuantityValue)" />
        public static Area SquareDecimeters<T>(this T value) =>
            Area.FromSquareDecimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareFeet(OasysUnitsNet.QuantityValue)" />
        public static Area SquareFeet<T>(this T value) =>
            Area.FromSquareFeet(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareInches(OasysUnitsNet.QuantityValue)" />
        public static Area SquareInches<T>(this T value) =>
            Area.FromSquareInches(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareKilometers(OasysUnitsNet.QuantityValue)" />
        public static Area SquareKilometers<T>(this T value) =>
            Area.FromSquareKilometers(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareMeters(OasysUnitsNet.QuantityValue)" />
        public static Area SquareMeters<T>(this T value) =>
            Area.FromSquareMeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareMicrometers(OasysUnitsNet.QuantityValue)" />
        public static Area SquareMicrometers<T>(this T value) =>
            Area.FromSquareMicrometers(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareMiles(OasysUnitsNet.QuantityValue)" />
        public static Area SquareMiles<T>(this T value) =>
            Area.FromSquareMiles(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareMillimeters(OasysUnitsNet.QuantityValue)" />
        public static Area SquareMillimeters<T>(this T value) =>
            Area.FromSquareMillimeters(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareNauticalMiles(OasysUnitsNet.QuantityValue)" />
        public static Area SquareNauticalMiles<T>(this T value) =>
            Area.FromSquareNauticalMiles(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromSquareYards(OasysUnitsNet.QuantityValue)" />
        public static Area SquareYards<T>(this T value) =>
            Area.FromSquareYards(Convert.ToDouble(value));

        /// <inheritdoc cref="Area.FromUsSurveySquareFeet(OasysUnitsNet.QuantityValue)" />
        public static Area UsSurveySquareFeet<T>(this T value) =>
            Area.FromUsSurveySquareFeet(Convert.ToDouble(value));

    }
}
