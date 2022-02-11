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
    ///     The rate of change of temperature with displacement in a given direction (as with increase of height)
    /// </summary>
    public struct  TemperatureGradient
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly TemperatureGradientUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public TemperatureGradientUnit Unit => _unit;
        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public TemperatureGradient(double value, TemperatureGradientUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static TemperatureGradientUnit BaseUnit { get; } = TemperatureGradientUnit.KelvinPerMeter;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static TemperatureGradient MaxValue { get; } = new TemperatureGradient(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static TemperatureGradient MinValue { get; } = new TemperatureGradient(double.MinValue, BaseUnit);
        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static TemperatureGradient Zero { get; } = new TemperatureGradient(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Get TemperatureGradient in DegreesCelciusPerKilometer.
        /// </summary>
        public double DegreesCelciusPerKilometer => As(TemperatureGradientUnit.DegreeCelsiusPerKilometer);

        /// <summary>
        ///     Get TemperatureGradient in DegreesCelciusPerMeter.
        /// </summary>
        public double DegreesCelciusPerMeter => As(TemperatureGradientUnit.DegreeCelsiusPerMeter);

        /// <summary>
        ///     Get TemperatureGradient in DegreesFahrenheitPerFoot.
        /// </summary>
        public double DegreesFahrenheitPerFoot => As(TemperatureGradientUnit.DegreeFahrenheitPerFoot);

        /// <summary>
        ///     Get TemperatureGradient in KelvinsPerMeter.
        /// </summary>
        public double KelvinsPerMeter => As(TemperatureGradientUnit.KelvinPerMeter);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Get TemperatureGradient from DegreesCelciusPerKilometer.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static TemperatureGradient FromDegreesCelciusPerKilometer(double degreescelciusperkilometer) => new TemperatureGradient(degreescelciusperkilometer, TemperatureGradientUnit.DegreeCelsiusPerKilometer);

        /// <summary>
        ///     Get TemperatureGradient from DegreesCelciusPerMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static TemperatureGradient FromDegreesCelciusPerMeter(double degreescelciuspermeter) => new TemperatureGradient(degreescelciuspermeter, TemperatureGradientUnit.DegreeCelsiusPerMeter);

        /// <summary>
        ///     Get TemperatureGradient from DegreesFahrenheitPerFoot.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static TemperatureGradient FromDegreesFahrenheitPerFoot(double degreesfahrenheitperfoot) => new TemperatureGradient(degreesfahrenheitperfoot, TemperatureGradientUnit.DegreeFahrenheitPerFoot);

        /// <summary>
        ///     Get TemperatureGradient from KelvinsPerMeter.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static TemperatureGradient FromKelvinsPerMeter(double kelvinspermeter) => new TemperatureGradient(kelvinspermeter, TemperatureGradientUnit.KelvinPerMeter);


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="TemperatureGradientUnit" /> to <see cref="TemperatureGradient" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>TemperatureGradient unit value.</returns>
        public static TemperatureGradient From(double value, TemperatureGradientUnit fromUnit)
        {
            return new TemperatureGradient(value, fromUnit);
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(TemperatureGradientUnit unit) => GetValueAs(unit);

        /// <summary>
        ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Duration with the specified unit.</returns>
        public TemperatureGradient ToUnit(TemperatureGradientUnit unit)
        {
            var convertedValue = GetValueAs(unit);
            return new TemperatureGradient(convertedValue, unit);
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
                TemperatureGradientUnit.DegreeCelsiusPerKilometer => _value / 1e3,
                TemperatureGradientUnit.DegreeCelsiusPerMeter => _value,
                TemperatureGradientUnit.DegreeFahrenheitPerFoot => (_value / 0.3048) * 5 / 9,
                TemperatureGradientUnit.KelvinPerMeter => _value,
                _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
            };
        }

        private double GetValueAs(TemperatureGradientUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            return unit switch
            {
                TemperatureGradientUnit.DegreeCelsiusPerKilometer => baseUnitValue * 1e3,
                TemperatureGradientUnit.DegreeCelsiusPerMeter => baseUnitValue,
                TemperatureGradientUnit.DegreeFahrenheitPerFoot => (baseUnitValue * 0.3048) * 9 / 5,
                TemperatureGradientUnit.KelvinPerMeter => baseUnitValue,
                _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
            };
        }

        #endregion

    }
}

