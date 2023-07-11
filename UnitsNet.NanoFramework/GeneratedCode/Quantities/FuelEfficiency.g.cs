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
    ///     Fuel efficiency is a form of thermal efficiency, meaning the ratio from effort to result of a process that converts chemical potential energy contained in a carrier (fuel) into kinetic energy or work. Fuel economy is stated as "fuel consumption" in liters per 100 kilometers (L/100 km). In countries using non-metric system, fuel economy is expressed in miles per gallon (mpg) (imperial galon or US galon).
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Fuel_efficiency
    /// </remarks>
    public struct  FuelEfficiency
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly FuelEfficiencyUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public FuelEfficiencyUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public FuelEfficiency(double value, FuelEfficiencyUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static FuelEfficiencyUnit BaseUnit { get; } = FuelEfficiencyUnit.LiterPer100Kilometers;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static FuelEfficiency MaxValue { get; } = new FuelEfficiency(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static FuelEfficiency MinValue { get; } = new FuelEfficiency(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static FuelEfficiency Zero { get; } = new FuelEfficiency(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="FuelEfficiencyUnit.KilometerPerLiter"/>
        /// </summary>
        public double KilometersPerLiters => As(FuelEfficiencyUnit.KilometerPerLiter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="FuelEfficiencyUnit.LiterPer100Kilometers"/>
        /// </summary>
        public double LitersPer100Kilometers => As(FuelEfficiencyUnit.LiterPer100Kilometers);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="FuelEfficiencyUnit.MilePerUkGallon"/>
        /// </summary>
        public double MilesPerUkGallon => As(FuelEfficiencyUnit.MilePerUkGallon);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="FuelEfficiencyUnit.MilePerUsGallon"/>
        /// </summary>
        public double MilesPerUsGallon => As(FuelEfficiencyUnit.MilePerUsGallon);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="FuelEfficiency"/> from <see cref="FuelEfficiencyUnit.KilometerPerLiter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static FuelEfficiency FromKilometersPerLiters(double kilometersperliters) => new FuelEfficiency(kilometersperliters, FuelEfficiencyUnit.KilometerPerLiter);

        /// <summary>
        ///     Creates a <see cref="FuelEfficiency"/> from <see cref="FuelEfficiencyUnit.LiterPer100Kilometers"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static FuelEfficiency FromLitersPer100Kilometers(double litersper100kilometers) => new FuelEfficiency(litersper100kilometers, FuelEfficiencyUnit.LiterPer100Kilometers);

        /// <summary>
        ///     Creates a <see cref="FuelEfficiency"/> from <see cref="FuelEfficiencyUnit.MilePerUkGallon"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static FuelEfficiency FromMilesPerUkGallon(double milesperukgallon) => new FuelEfficiency(milesperukgallon, FuelEfficiencyUnit.MilePerUkGallon);

        /// <summary>
        ///     Creates a <see cref="FuelEfficiency"/> from <see cref="FuelEfficiencyUnit.MilePerUsGallon"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static FuelEfficiency FromMilesPerUsGallon(double milesperusgallon) => new FuelEfficiency(milesperusgallon, FuelEfficiencyUnit.MilePerUsGallon);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="FuelEfficiencyUnit" /> to <see cref="FuelEfficiency" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>FuelEfficiency unit value.</returns>
        public static FuelEfficiency From(double value, FuelEfficiencyUnit fromUnit)
        {
            return new FuelEfficiency(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(FuelEfficiencyUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A Duration with the specified unit.</returns>
                public FuelEfficiency ToUnit(FuelEfficiencyUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new FuelEfficiency(convertedValue, unit);
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
                        FuelEfficiencyUnit.KilometerPerLiter => 100 / _value,
                        FuelEfficiencyUnit.LiterPer100Kilometers => _value,
                        FuelEfficiencyUnit.MilePerUkGallon => (100 * 4.54609188) / (1.609344 * _value),
                        FuelEfficiencyUnit.MilePerUsGallon => (100 * 3.785411784) / (1.609344 * _value),
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(FuelEfficiencyUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        FuelEfficiencyUnit.KilometerPerLiter => 100 / baseUnitValue,
                        FuelEfficiencyUnit.LiterPer100Kilometers => baseUnitValue,
                        FuelEfficiencyUnit.MilePerUkGallon => (100 * 4.54609188) / (1.609344 * baseUnitValue),
                        FuelEfficiencyUnit.MilePerUsGallon => (100 * 3.785411784) / (1.609344 * baseUnitValue),
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

