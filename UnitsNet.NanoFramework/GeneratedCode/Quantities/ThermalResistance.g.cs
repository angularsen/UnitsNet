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
    ///     Heat Transfer Coefficient or Thermal conductivity - indicates a materials ability to conduct heat.
    /// </summary>
    public struct  ThermalResistance
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly ThermalResistanceUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public ThermalResistanceUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public ThermalResistance(double value, ThermalResistanceUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static ThermalResistanceUnit BaseUnit { get; } = ThermalResistanceUnit.SquareMeterKelvinPerKilowatt;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static ThermalResistance MaxValue { get; } = new ThermalResistance(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static ThermalResistance MinValue { get; } = new ThermalResistance(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static ThermalResistance Zero { get; } = new ThermalResistance(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ThermalResistanceUnit.HourSquareFeetDegreeFahrenheitPerBtu"/>
        /// </summary>
        public double HourSquareFeetDegreesFahrenheitPerBtu => As(ThermalResistanceUnit.HourSquareFeetDegreeFahrenheitPerBtu);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ThermalResistanceUnit.SquareCentimeterHourDegreeCelsiusPerKilocalorie"/>
        /// </summary>
        public double SquareCentimeterHourDegreesCelsiusPerKilocalorie => As(ThermalResistanceUnit.SquareCentimeterHourDegreeCelsiusPerKilocalorie);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ThermalResistanceUnit.SquareCentimeterKelvinPerWatt"/>
        /// </summary>
        public double SquareCentimeterKelvinsPerWatt => As(ThermalResistanceUnit.SquareCentimeterKelvinPerWatt);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ThermalResistanceUnit.SquareMeterDegreeCelsiusPerWatt"/>
        /// </summary>
        public double SquareMeterDegreesCelsiusPerWatt => As(ThermalResistanceUnit.SquareMeterDegreeCelsiusPerWatt);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ThermalResistanceUnit.SquareMeterKelvinPerKilowatt"/>
        /// </summary>
        public double SquareMeterKelvinsPerKilowatt => As(ThermalResistanceUnit.SquareMeterKelvinPerKilowatt);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ThermalResistanceUnit.SquareMeterKelvinPerWatt"/>
        /// </summary>
        public double SquareMeterKelvinsPerWatt => As(ThermalResistanceUnit.SquareMeterKelvinPerWatt);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="ThermalResistance"/> from <see cref="ThermalResistanceUnit.HourSquareFeetDegreeFahrenheitPerBtu"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ThermalResistance FromHourSquareFeetDegreesFahrenheitPerBtu(double hoursquarefeetdegreesfahrenheitperbtu) => new ThermalResistance(hoursquarefeetdegreesfahrenheitperbtu, ThermalResistanceUnit.HourSquareFeetDegreeFahrenheitPerBtu);

        /// <summary>
        ///     Creates a <see cref="ThermalResistance"/> from <see cref="ThermalResistanceUnit.SquareCentimeterHourDegreeCelsiusPerKilocalorie"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ThermalResistance FromSquareCentimeterHourDegreesCelsiusPerKilocalorie(double squarecentimeterhourdegreescelsiusperkilocalorie) => new ThermalResistance(squarecentimeterhourdegreescelsiusperkilocalorie, ThermalResistanceUnit.SquareCentimeterHourDegreeCelsiusPerKilocalorie);

        /// <summary>
        ///     Creates a <see cref="ThermalResistance"/> from <see cref="ThermalResistanceUnit.SquareCentimeterKelvinPerWatt"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ThermalResistance FromSquareCentimeterKelvinsPerWatt(double squarecentimeterkelvinsperwatt) => new ThermalResistance(squarecentimeterkelvinsperwatt, ThermalResistanceUnit.SquareCentimeterKelvinPerWatt);

        /// <summary>
        ///     Creates a <see cref="ThermalResistance"/> from <see cref="ThermalResistanceUnit.SquareMeterDegreeCelsiusPerWatt"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ThermalResistance FromSquareMeterDegreesCelsiusPerWatt(double squaremeterdegreescelsiusperwatt) => new ThermalResistance(squaremeterdegreescelsiusperwatt, ThermalResistanceUnit.SquareMeterDegreeCelsiusPerWatt);

        /// <summary>
        ///     Creates a <see cref="ThermalResistance"/> from <see cref="ThermalResistanceUnit.SquareMeterKelvinPerKilowatt"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ThermalResistance FromSquareMeterKelvinsPerKilowatt(double squaremeterkelvinsperkilowatt) => new ThermalResistance(squaremeterkelvinsperkilowatt, ThermalResistanceUnit.SquareMeterKelvinPerKilowatt);

        /// <summary>
        ///     Creates a <see cref="ThermalResistance"/> from <see cref="ThermalResistanceUnit.SquareMeterKelvinPerWatt"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ThermalResistance FromSquareMeterKelvinsPerWatt(double squaremeterkelvinsperwatt) => new ThermalResistance(squaremeterkelvinsperwatt, ThermalResistanceUnit.SquareMeterKelvinPerWatt);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ThermalResistanceUnit" /> to <see cref="ThermalResistance" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ThermalResistance unit value.</returns>
        public static ThermalResistance From(double value, ThermalResistanceUnit fromUnit)
        {
            return new ThermalResistance(value, fromUnit);
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(ThermalResistanceUnit unit) => GetValueAs(unit);

        /// <summary>
        ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Duration with the specified unit.</returns>
        public ThermalResistance ToUnit(ThermalResistanceUnit unit)
        {
            var convertedValue = GetValueAs(unit);
            return new ThermalResistance(convertedValue, unit);
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
                ThermalResistanceUnit.HourSquareFeetDegreeFahrenheitPerBtu => _value * 176.1121482159839,
                ThermalResistanceUnit.SquareCentimeterHourDegreeCelsiusPerKilocalorie => _value * 0.0859779507590433,
                ThermalResistanceUnit.SquareCentimeterKelvinPerWatt => _value * 0.0999964777570357,
                ThermalResistanceUnit.SquareMeterDegreeCelsiusPerWatt => _value * 1000.088056074108,
                ThermalResistanceUnit.SquareMeterKelvinPerKilowatt => _value,
                ThermalResistanceUnit.SquareMeterKelvinPerWatt => _value * 1000,
                _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
            };
        }

        private double GetValueAs(ThermalResistanceUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            return unit switch
            {
                ThermalResistanceUnit.HourSquareFeetDegreeFahrenheitPerBtu => baseUnitValue / 176.1121482159839,
                ThermalResistanceUnit.SquareCentimeterHourDegreeCelsiusPerKilocalorie => baseUnitValue / 0.0859779507590433,
                ThermalResistanceUnit.SquareCentimeterKelvinPerWatt => baseUnitValue / 0.0999964777570357,
                ThermalResistanceUnit.SquareMeterDegreeCelsiusPerWatt => baseUnitValue / 1000.088056074108,
                ThermalResistanceUnit.SquareMeterKelvinPerKilowatt => baseUnitValue,
                ThermalResistanceUnit.SquareMeterKelvinPerWatt => baseUnitValue / 1000,
                _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
            };
        }

        #endregion
    }
}

