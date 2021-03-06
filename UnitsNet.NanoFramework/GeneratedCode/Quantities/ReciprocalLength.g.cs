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
using UnitsNet.Units;

namespace UnitsNet
{
    /// <inheritdoc />
    /// <summary>
    ///     Reciprocal (Inverse) Length is used in various fields of science and mathematics. It is defined as the inverse value of a length unit.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Reciprocal_length
    /// </remarks>
    public struct  ReciprocalLength
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly ReciprocalLengthUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public ReciprocalLengthUnit Unit => _unit;
        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public ReciprocalLength(double value, ReciprocalLengthUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static ReciprocalLengthUnit BaseUnit { get; } = ReciprocalLengthUnit.InverseMeter;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static ReciprocalLength MaxValue { get; } = new ReciprocalLength(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static ReciprocalLength MinValue { get; } = new ReciprocalLength(double.MinValue, BaseUnit);
        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static ReciprocalLength Zero { get; } = new ReciprocalLength(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Get ReciprocalLength in InverseCentimeters.
        /// </summary>
        public double InverseCentimeters => As(ReciprocalLengthUnit.InverseCentimeter);

        /// <summary>
        ///     Get ReciprocalLength in InverseFeet.
        /// </summary>
        public double InverseFeet => As(ReciprocalLengthUnit.InverseFoot);

        /// <summary>
        ///     Get ReciprocalLength in InverseInches.
        /// </summary>
        public double InverseInches => As(ReciprocalLengthUnit.InverseInch);

        /// <summary>
        ///     Get ReciprocalLength in InverseMeters.
        /// </summary>
        public double InverseMeters => As(ReciprocalLengthUnit.InverseMeter);

        /// <summary>
        ///     Get ReciprocalLength in InverseMicroinches.
        /// </summary>
        public double InverseMicroinches => As(ReciprocalLengthUnit.InverseMicroinch);

        /// <summary>
        ///     Get ReciprocalLength in InverseMils.
        /// </summary>
        public double InverseMils => As(ReciprocalLengthUnit.InverseMil);

        /// <summary>
        ///     Get ReciprocalLength in InverseMiles.
        /// </summary>
        public double InverseMiles => As(ReciprocalLengthUnit.InverseMile);

        /// <summary>
        ///     Get ReciprocalLength in InverseMillimeters.
        /// </summary>
        public double InverseMillimeters => As(ReciprocalLengthUnit.InverseMillimeter);

        /// <summary>
        ///     Get ReciprocalLength in InverseUsSurveyFeet.
        /// </summary>
        public double InverseUsSurveyFeet => As(ReciprocalLengthUnit.InverseUsSurveyFoot);

        /// <summary>
        ///     Get ReciprocalLength in InverseYards.
        /// </summary>
        public double InverseYards => As(ReciprocalLengthUnit.InverseYard);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Get ReciprocalLength from InverseCentimeters.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReciprocalLength FromInverseCentimeters(double inversecentimeters) => new ReciprocalLength(inversecentimeters, ReciprocalLengthUnit.InverseCentimeter);

        /// <summary>
        ///     Get ReciprocalLength from InverseFeet.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReciprocalLength FromInverseFeet(double inversefeet) => new ReciprocalLength(inversefeet, ReciprocalLengthUnit.InverseFoot);

        /// <summary>
        ///     Get ReciprocalLength from InverseInches.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReciprocalLength FromInverseInches(double inverseinches) => new ReciprocalLength(inverseinches, ReciprocalLengthUnit.InverseInch);

        /// <summary>
        ///     Get ReciprocalLength from InverseMeters.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReciprocalLength FromInverseMeters(double inversemeters) => new ReciprocalLength(inversemeters, ReciprocalLengthUnit.InverseMeter);

        /// <summary>
        ///     Get ReciprocalLength from InverseMicroinches.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReciprocalLength FromInverseMicroinches(double inversemicroinches) => new ReciprocalLength(inversemicroinches, ReciprocalLengthUnit.InverseMicroinch);

        /// <summary>
        ///     Get ReciprocalLength from InverseMils.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReciprocalLength FromInverseMils(double inversemils) => new ReciprocalLength(inversemils, ReciprocalLengthUnit.InverseMil);

        /// <summary>
        ///     Get ReciprocalLength from InverseMiles.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReciprocalLength FromInverseMiles(double inversemiles) => new ReciprocalLength(inversemiles, ReciprocalLengthUnit.InverseMile);

        /// <summary>
        ///     Get ReciprocalLength from InverseMillimeters.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReciprocalLength FromInverseMillimeters(double inversemillimeters) => new ReciprocalLength(inversemillimeters, ReciprocalLengthUnit.InverseMillimeter);

        /// <summary>
        ///     Get ReciprocalLength from InverseUsSurveyFeet.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReciprocalLength FromInverseUsSurveyFeet(double inverseussurveyfeet) => new ReciprocalLength(inverseussurveyfeet, ReciprocalLengthUnit.InverseUsSurveyFoot);

        /// <summary>
        ///     Get ReciprocalLength from InverseYards.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ReciprocalLength FromInverseYards(double inverseyards) => new ReciprocalLength(inverseyards, ReciprocalLengthUnit.InverseYard);


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ReciprocalLengthUnit" /> to <see cref="ReciprocalLength" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ReciprocalLength unit value.</returns>
        public static ReciprocalLength From(double value, ReciprocalLengthUnit fromUnit)
        {
            return new ReciprocalLength(value, fromUnit);
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(ReciprocalLengthUnit unit) => GetValueAs(unit);        

        /// <summary>
        ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Duration with the specified unit.</returns>
        public ReciprocalLength ToUnit(ReciprocalLengthUnit unit)
        {
                
            var convertedValue = GetValueAs(unit);
            return new ReciprocalLength(convertedValue, unit);
        }


        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private double GetValueInBaseUnit()
        {
            switch(Unit)
            {
                case ReciprocalLengthUnit.InverseCentimeter: return _value*1e2;
                case ReciprocalLengthUnit.InverseFoot: return _value/0.3048;
                case ReciprocalLengthUnit.InverseInch: return _value/2.54e-2;
                case ReciprocalLengthUnit.InverseMeter: return _value;
                case ReciprocalLengthUnit.InverseMicroinch: return _value/2.54e-8;
                case ReciprocalLengthUnit.InverseMil: return _value/2.54e-5;
                case ReciprocalLengthUnit.InverseMile: return _value/1609.34;
                case ReciprocalLengthUnit.InverseMillimeter: return _value*1e3;
                case ReciprocalLengthUnit.InverseUsSurveyFoot: return _value*3937/1200;
                case ReciprocalLengthUnit.InverseYard: return _value/0.9144;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double GetValueAs(ReciprocalLengthUnit unit)
        {
            if(Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            switch(unit)
            {
                case ReciprocalLengthUnit.InverseCentimeter: return baseUnitValue/1e2;
                case ReciprocalLengthUnit.InverseFoot: return baseUnitValue*0.3048;
                case ReciprocalLengthUnit.InverseInch: return baseUnitValue*2.54e-2;
                case ReciprocalLengthUnit.InverseMeter: return baseUnitValue;
                case ReciprocalLengthUnit.InverseMicroinch: return baseUnitValue*2.54e-8;
                case ReciprocalLengthUnit.InverseMil: return baseUnitValue*2.54e-5;
                case ReciprocalLengthUnit.InverseMile: return baseUnitValue*1609.34;
                case ReciprocalLengthUnit.InverseMillimeter: return baseUnitValue/1e3;
                case ReciprocalLengthUnit.InverseUsSurveyFoot: return baseUnitValue*1200/3937;
                case ReciprocalLengthUnit.InverseYard: return baseUnitValue*0.9144;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }

        #endregion

    }
}

