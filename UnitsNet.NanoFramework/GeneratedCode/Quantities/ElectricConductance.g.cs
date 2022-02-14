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
    ///     The electrical conductance of an electrical conductor is a measure of the easeness to pass an electric current through that conductor.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Electrical_resistance_and_conductance
    /// </remarks>
    public struct  ElectricConductance
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly ElectricConductanceUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public ElectricConductanceUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public ElectricConductance(double value, ElectricConductanceUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static ElectricConductanceUnit BaseUnit { get; } = ElectricConductanceUnit.Siemens;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static ElectricConductance MaxValue { get; } = new ElectricConductance(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static ElectricConductance MinValue { get; } = new ElectricConductance(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static ElectricConductance Zero { get; } = new ElectricConductance(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricConductanceUnit.Microsiemens"/>
        /// </summary>
        public double Microsiemens => As(ElectricConductanceUnit.Microsiemens);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricConductanceUnit.Millisiemens"/>
        /// </summary>
        public double Millisiemens => As(ElectricConductanceUnit.Millisiemens);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricConductanceUnit.Siemens"/>
        /// </summary>
        public double Siemens => As(ElectricConductanceUnit.Siemens);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="ElectricConductance"/> from <see cref="ElectricConductanceUnit.Microsiemens"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricConductance FromMicrosiemens(double microsiemens) => new ElectricConductance(microsiemens, ElectricConductanceUnit.Microsiemens);

        /// <summary>
        ///     Creates a <see cref="ElectricConductance"/> from <see cref="ElectricConductanceUnit.Millisiemens"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricConductance FromMillisiemens(double millisiemens) => new ElectricConductance(millisiemens, ElectricConductanceUnit.Millisiemens);

        /// <summary>
        ///     Creates a <see cref="ElectricConductance"/> from <see cref="ElectricConductanceUnit.Siemens"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricConductance FromSiemens(double siemens) => new ElectricConductance(siemens, ElectricConductanceUnit.Siemens);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricConductanceUnit" /> to <see cref="ElectricConductance" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricConductance unit value.</returns>
        public static ElectricConductance From(double value, ElectricConductanceUnit fromUnit)
        {
            return new ElectricConductance(value, fromUnit);
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(ElectricConductanceUnit unit) => GetValueAs(unit);

        /// <summary>
        ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Duration with the specified unit.</returns>
        public ElectricConductance ToUnit(ElectricConductanceUnit unit)
        {
            var convertedValue = GetValueAs(unit);
            return new ElectricConductance(convertedValue, unit);
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
                ElectricConductanceUnit.Microsiemens => (_value) * 1e-6d,
                ElectricConductanceUnit.Millisiemens => (_value) * 1e-3d,
                ElectricConductanceUnit.Siemens => _value,
                _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
            };
        }

        private double GetValueAs(ElectricConductanceUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            return unit switch
            {
                ElectricConductanceUnit.Microsiemens => (baseUnitValue) / 1e-6d,
                ElectricConductanceUnit.Millisiemens => (baseUnitValue) / 1e-3d,
                ElectricConductanceUnit.Siemens => baseUnitValue,
                _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
            };
        }

        #endregion
    }
}

