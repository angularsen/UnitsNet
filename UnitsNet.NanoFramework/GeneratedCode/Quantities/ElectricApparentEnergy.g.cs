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
    ///     A unit for expressing the integral of apparent power over time, equal to the product of 1 volt-ampere and 1 hour, or to 3600 joules.
    /// </summary>
    public struct  ElectricApparentEnergy
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly ElectricApparentEnergyUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public ElectricApparentEnergyUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public ElectricApparentEnergy(double value, ElectricApparentEnergyUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of ElectricApparentEnergy, which is Second. All conversions go via this value.
        /// </summary>
        public static ElectricApparentEnergyUnit BaseUnit { get; } = ElectricApparentEnergyUnit.VoltampereHour;

        /// <summary>
        /// Represents the largest possible value of ElectricApparentEnergy.
        /// </summary>
        public static ElectricApparentEnergy MaxValue { get; } = new ElectricApparentEnergy(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of ElectricApparentEnergy.
        /// </summary>
        public static ElectricApparentEnergy MinValue { get; } = new ElectricApparentEnergy(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static ElectricApparentEnergy Zero { get; } = new ElectricApparentEnergy(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricApparentEnergyUnit.KilovoltampereHour"/>
        /// </summary>
        public double KilovoltampereHours => As(ElectricApparentEnergyUnit.KilovoltampereHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricApparentEnergyUnit.MegavoltampereHour"/>
        /// </summary>
        public double MegavoltampereHours => As(ElectricApparentEnergyUnit.MegavoltampereHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricApparentEnergyUnit.VoltampereHour"/>
        /// </summary>
        public double VoltampereHours => As(ElectricApparentEnergyUnit.VoltampereHour);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="ElectricApparentEnergy"/> from <see cref="ElectricApparentEnergyUnit.KilovoltampereHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricApparentEnergy FromKilovoltampereHours(double kilovoltamperehours) => new ElectricApparentEnergy(kilovoltamperehours, ElectricApparentEnergyUnit.KilovoltampereHour);

        /// <summary>
        ///     Creates a <see cref="ElectricApparentEnergy"/> from <see cref="ElectricApparentEnergyUnit.MegavoltampereHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricApparentEnergy FromMegavoltampereHours(double megavoltamperehours) => new ElectricApparentEnergy(megavoltamperehours, ElectricApparentEnergyUnit.MegavoltampereHour);

        /// <summary>
        ///     Creates a <see cref="ElectricApparentEnergy"/> from <see cref="ElectricApparentEnergyUnit.VoltampereHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricApparentEnergy FromVoltampereHours(double voltamperehours) => new ElectricApparentEnergy(voltamperehours, ElectricApparentEnergyUnit.VoltampereHour);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricApparentEnergyUnit" /> to <see cref="ElectricApparentEnergy" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricApparentEnergy unit value.</returns>
        public static ElectricApparentEnergy From(double value, ElectricApparentEnergyUnit fromUnit)
        {
            return new ElectricApparentEnergy(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(ElectricApparentEnergyUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this ElectricApparentEnergy to another ElectricApparentEnergy with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A ElectricApparentEnergy with the specified unit.</returns>
                public ElectricApparentEnergy ToUnit(ElectricApparentEnergyUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new ElectricApparentEnergy(convertedValue, unit);
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
                        ElectricApparentEnergyUnit.KilovoltampereHour => (_value) * 1e3d,
                        ElectricApparentEnergyUnit.MegavoltampereHour => (_value) * 1e6d,
                        ElectricApparentEnergyUnit.VoltampereHour => _value,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(ElectricApparentEnergyUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        ElectricApparentEnergyUnit.KilovoltampereHour => (baseUnitValue) / 1e3d,
                        ElectricApparentEnergyUnit.MegavoltampereHour => (baseUnitValue) / 1e6d,
                        ElectricApparentEnergyUnit.VoltampereHour => baseUnitValue,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

