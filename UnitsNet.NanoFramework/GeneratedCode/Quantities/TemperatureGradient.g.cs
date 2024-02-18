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
    ///     
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
        ///     The base unit of TemperatureGradient, which is Second. All conversions go via this value.
        /// </summary>
        public static TemperatureGradientUnit BaseUnit { get; } = TemperatureGradientUnit.KelvinPerMeter;

        /// <summary>
        /// Represents the largest possible value of TemperatureGradient.
        /// </summary>
        public static TemperatureGradient MaxValue { get; } = new TemperatureGradient(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of TemperatureGradient.
        /// </summary>
        public static TemperatureGradient MinValue { get; } = new TemperatureGradient(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static TemperatureGradient Zero { get; } = new TemperatureGradient(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="TemperatureGradientUnit.DegreeCelsiusPerKilometer"/>
        /// </summary>
        public double DegreesCelsiusPerKilometer => As(TemperatureGradientUnit.DegreeCelsiusPerKilometer);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="TemperatureGradientUnit.DegreeCelsiusPerMeter"/>
        /// </summary>
        public double DegreesCelsiusPerMeter => As(TemperatureGradientUnit.DegreeCelsiusPerMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="TemperatureGradientUnit.DegreeFahrenheitPerFoot"/>
        /// </summary>
        public double DegreesFahrenheitPerFoot => As(TemperatureGradientUnit.DegreeFahrenheitPerFoot);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="TemperatureGradientUnit.KelvinPerMeter"/>
        /// </summary>
        public double KelvinsPerMeter => As(TemperatureGradientUnit.KelvinPerMeter);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="TemperatureGradient"/> from <see cref="TemperatureGradientUnit.DegreeCelsiusPerKilometer"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static TemperatureGradient FromDegreesCelsiusPerKilometer(double degreescelsiusperkilometer) => new TemperatureGradient(degreescelsiusperkilometer, TemperatureGradientUnit.DegreeCelsiusPerKilometer);

        /// <summary>
        ///     Creates a <see cref="TemperatureGradient"/> from <see cref="TemperatureGradientUnit.DegreeCelsiusPerMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static TemperatureGradient FromDegreesCelsiusPerMeter(double degreescelsiuspermeter) => new TemperatureGradient(degreescelsiuspermeter, TemperatureGradientUnit.DegreeCelsiusPerMeter);

        /// <summary>
        ///     Creates a <see cref="TemperatureGradient"/> from <see cref="TemperatureGradientUnit.DegreeFahrenheitPerFoot"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static TemperatureGradient FromDegreesFahrenheitPerFoot(double degreesfahrenheitperfoot) => new TemperatureGradient(degreesfahrenheitperfoot, TemperatureGradientUnit.DegreeFahrenheitPerFoot);

        /// <summary>
        ///     Creates a <see cref="TemperatureGradient"/> from <see cref="TemperatureGradientUnit.KelvinPerMeter"/>.
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
                ///     Converts this TemperatureGradient to another TemperatureGradient with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A TemperatureGradient with the specified unit.</returns>
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

