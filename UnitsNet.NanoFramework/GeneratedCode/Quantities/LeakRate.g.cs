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
    ///     A leakage rate of QL = 1 Pa-m³/s is given when the pressure in a closed, evacuated container with a volume of 1 m³ rises by 1 Pa per second or when the pressure in the container drops by 1 Pa in the event of overpressure.
    /// </summary>
    public struct  LeakRate
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly LeakRateUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public LeakRateUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public LeakRate(double value, LeakRateUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static LeakRateUnit BaseUnit { get; } = LeakRateUnit.PascalCubicMeterPerSecond;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static LeakRate MaxValue { get; } = new LeakRate(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static LeakRate MinValue { get; } = new LeakRate(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static LeakRate Zero { get; } = new LeakRate(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LeakRateUnit.MillibarLiterPerSecond"/>
        /// </summary>
        public double MillibarLitersPerSecond => As(LeakRateUnit.MillibarLiterPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LeakRateUnit.PascalCubicMeterPerSecond"/>
        /// </summary>
        public double PascalCubicMetersPerSecond => As(LeakRateUnit.PascalCubicMeterPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LeakRateUnit.TorrLiterPerSecond"/>
        /// </summary>
        public double TorrLitersPerSecond => As(LeakRateUnit.TorrLiterPerSecond);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="LeakRate"/> from <see cref="LeakRateUnit.MillibarLiterPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LeakRate FromMillibarLitersPerSecond(double millibarliterspersecond) => new LeakRate(millibarliterspersecond, LeakRateUnit.MillibarLiterPerSecond);

        /// <summary>
        ///     Creates a <see cref="LeakRate"/> from <see cref="LeakRateUnit.PascalCubicMeterPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LeakRate FromPascalCubicMetersPerSecond(double pascalcubicmeterspersecond) => new LeakRate(pascalcubicmeterspersecond, LeakRateUnit.PascalCubicMeterPerSecond);

        /// <summary>
        ///     Creates a <see cref="LeakRate"/> from <see cref="LeakRateUnit.TorrLiterPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LeakRate FromTorrLitersPerSecond(double torrliterspersecond) => new LeakRate(torrliterspersecond, LeakRateUnit.TorrLiterPerSecond);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="LeakRateUnit" /> to <see cref="LeakRate" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>LeakRate unit value.</returns>
        public static LeakRate From(double value, LeakRateUnit fromUnit)
        {
            return new LeakRate(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(LeakRateUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A Duration with the specified unit.</returns>
                public LeakRate ToUnit(LeakRateUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new LeakRate(convertedValue, unit);
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
                        LeakRateUnit.MillibarLiterPerSecond => _value / 10,
                        LeakRateUnit.PascalCubicMeterPerSecond => _value,
                        LeakRateUnit.TorrLiterPerSecond => _value / 7.5,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(LeakRateUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        LeakRateUnit.MillibarLiterPerSecond => baseUnitValue * 10,
                        LeakRateUnit.PascalCubicMeterPerSecond => baseUnitValue,
                        LeakRateUnit.TorrLiterPerSecond => baseUnitValue * 7.5,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

