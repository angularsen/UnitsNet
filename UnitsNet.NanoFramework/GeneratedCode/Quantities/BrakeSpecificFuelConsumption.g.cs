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
    ///     Brake specific fuel consumption (BSFC) is a measure of the fuel efficiency of any prime mover that burns fuel and produces rotational, or shaft, power. It is typically used for comparing the efficiency of internal combustion engines with a shaft output.
    /// </summary>
    public struct  BrakeSpecificFuelConsumption
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly BrakeSpecificFuelConsumptionUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public BrakeSpecificFuelConsumptionUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public BrakeSpecificFuelConsumption(double value, BrakeSpecificFuelConsumptionUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of BrakeSpecificFuelConsumption, which is Second. All conversions go via this value.
        /// </summary>
        public static BrakeSpecificFuelConsumptionUnit BaseUnit { get; } = BrakeSpecificFuelConsumptionUnit.KilogramPerJoule;

        /// <summary>
        /// Represents the largest possible value of BrakeSpecificFuelConsumption.
        /// </summary>
        public static BrakeSpecificFuelConsumption MaxValue { get; } = new BrakeSpecificFuelConsumption(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of BrakeSpecificFuelConsumption.
        /// </summary>
        public static BrakeSpecificFuelConsumption MinValue { get; } = new BrakeSpecificFuelConsumption(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static BrakeSpecificFuelConsumption Zero { get; } = new BrakeSpecificFuelConsumption(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour"/>
        /// </summary>
        public double GramsPerKiloWattHour => As(BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="BrakeSpecificFuelConsumptionUnit.KilogramPerJoule"/>
        /// </summary>
        public double KilogramsPerJoule => As(BrakeSpecificFuelConsumptionUnit.KilogramPerJoule);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour"/>
        /// </summary>
        public double PoundsPerMechanicalHorsepowerHour => As(BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="BrakeSpecificFuelConsumption"/> from <see cref="BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static BrakeSpecificFuelConsumption FromGramsPerKiloWattHour(double gramsperkilowatthour) => new BrakeSpecificFuelConsumption(gramsperkilowatthour, BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour);

        /// <summary>
        ///     Creates a <see cref="BrakeSpecificFuelConsumption"/> from <see cref="BrakeSpecificFuelConsumptionUnit.KilogramPerJoule"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static BrakeSpecificFuelConsumption FromKilogramsPerJoule(double kilogramsperjoule) => new BrakeSpecificFuelConsumption(kilogramsperjoule, BrakeSpecificFuelConsumptionUnit.KilogramPerJoule);

        /// <summary>
        ///     Creates a <see cref="BrakeSpecificFuelConsumption"/> from <see cref="BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static BrakeSpecificFuelConsumption FromPoundsPerMechanicalHorsepowerHour(double poundspermechanicalhorsepowerhour) => new BrakeSpecificFuelConsumption(poundspermechanicalhorsepowerhour, BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="BrakeSpecificFuelConsumptionUnit" /> to <see cref="BrakeSpecificFuelConsumption" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>BrakeSpecificFuelConsumption unit value.</returns>
        public static BrakeSpecificFuelConsumption From(double value, BrakeSpecificFuelConsumptionUnit fromUnit)
        {
            return new BrakeSpecificFuelConsumption(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(BrakeSpecificFuelConsumptionUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this BrakeSpecificFuelConsumption to another BrakeSpecificFuelConsumption with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A BrakeSpecificFuelConsumption with the specified unit.</returns>
                public BrakeSpecificFuelConsumption ToUnit(BrakeSpecificFuelConsumptionUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new BrakeSpecificFuelConsumption(convertedValue, unit);
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
                        BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour => _value / 3.6e9,
                        BrakeSpecificFuelConsumptionUnit.KilogramPerJoule => _value,
                        BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour => _value * 1.689659410672e-7,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(BrakeSpecificFuelConsumptionUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        BrakeSpecificFuelConsumptionUnit.GramPerKiloWattHour => baseUnitValue * 3.6e9,
                        BrakeSpecificFuelConsumptionUnit.KilogramPerJoule => baseUnitValue,
                        BrakeSpecificFuelConsumptionUnit.PoundPerMechanicalHorsepowerHour => baseUnitValue / 1.689659410672e-7,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

