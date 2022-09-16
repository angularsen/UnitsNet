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
using OasysUnitsNet.Units;

namespace OasysUnitsNet
{
    /// <inheritdoc />
    /// <summary>
    ///     In photometry, luminous intensity is a measure of the wavelength-weighted power emitted by a light source in a particular direction per unit solid angle, based on the luminosity function, a standardized model of the sensitivity of the human eye.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Luminous_intensity
    /// </remarks>
    public struct  LuminousIntensity
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly LuminousIntensityUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public LuminousIntensityUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public LuminousIntensity(double value, LuminousIntensityUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static LuminousIntensityUnit BaseUnit { get; } = LuminousIntensityUnit.Candela;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static LuminousIntensity MaxValue { get; } = new LuminousIntensity(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static LuminousIntensity MinValue { get; } = new LuminousIntensity(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static LuminousIntensity Zero { get; } = new LuminousIntensity(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LuminousIntensityUnit.Candela"/>
        /// </summary>
        public double Candela => As(LuminousIntensityUnit.Candela);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="LuminousIntensity"/> from <see cref="LuminousIntensityUnit.Candela"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LuminousIntensity FromCandela(double candela) => new LuminousIntensity(candela, LuminousIntensityUnit.Candela);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="LuminousIntensityUnit" /> to <see cref="LuminousIntensity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>LuminousIntensity unit value.</returns>
        public static LuminousIntensity From(double value, LuminousIntensityUnit fromUnit)
        {
            return new LuminousIntensity(value, fromUnit);
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(LuminousIntensityUnit unit) => GetValueAs(unit);

        /// <summary>
        ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Duration with the specified unit.</returns>
        public LuminousIntensity ToUnit(LuminousIntensityUnit unit)
        {
            var convertedValue = GetValueAs(unit);
            return new LuminousIntensity(convertedValue, unit);
        }

        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private double GetValueInBaseUnit()
        {
            return Unit switch
            {
                LuminousIntensityUnit.Candela => _value,
                _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
            };
        }

        private double GetValueAs(LuminousIntensityUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            return unit switch
            {
                LuminousIntensityUnit.Candela => baseUnitValue,
                _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
            };
        }

        #endregion
    }
}

