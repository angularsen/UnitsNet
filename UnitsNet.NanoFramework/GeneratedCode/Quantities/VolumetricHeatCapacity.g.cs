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
    ///     The volumetric heat capacity is the amount of energy that must be added, in the form of heat, to one unit of volume of the material in order to cause an increase of one unit in its temperature.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Volumetric_heat_capacity
    /// </remarks>
    public struct  VolumetricHeatCapacity
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly VolumetricHeatCapacityUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public VolumetricHeatCapacityUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public VolumetricHeatCapacity(double value, VolumetricHeatCapacityUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static VolumetricHeatCapacityUnit BaseUnit { get; } = VolumetricHeatCapacityUnit.JoulePerCubicMeterKelvin;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static VolumetricHeatCapacity MaxValue { get; } = new VolumetricHeatCapacity(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static VolumetricHeatCapacity MinValue { get; } = new VolumetricHeatCapacity(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static VolumetricHeatCapacity Zero { get; } = new VolumetricHeatCapacity(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="VolumetricHeatCapacityUnit.BtuPerCubicFootDegreeFahrenheit"/>
        /// </summary>
        public double BtusPerCubicFootDegreeFahrenheit => As(VolumetricHeatCapacityUnit.BtuPerCubicFootDegreeFahrenheit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="VolumetricHeatCapacityUnit.CaloriePerCubicCentimeterDegreeCelsius"/>
        /// </summary>
        public double CaloriesPerCubicCentimeterDegreeCelsius => As(VolumetricHeatCapacityUnit.CaloriePerCubicCentimeterDegreeCelsius);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="VolumetricHeatCapacityUnit.JoulePerCubicMeterDegreeCelsius"/>
        /// </summary>
        public double JoulesPerCubicMeterDegreeCelsius => As(VolumetricHeatCapacityUnit.JoulePerCubicMeterDegreeCelsius);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="VolumetricHeatCapacityUnit.JoulePerCubicMeterKelvin"/>
        /// </summary>
        public double JoulesPerCubicMeterKelvin => As(VolumetricHeatCapacityUnit.JoulePerCubicMeterKelvin);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="VolumetricHeatCapacityUnit.KilocaloriePerCubicCentimeterDegreeCelsius"/>
        /// </summary>
        public double KilocaloriesPerCubicCentimeterDegreeCelsius => As(VolumetricHeatCapacityUnit.KilocaloriePerCubicCentimeterDegreeCelsius);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="VolumetricHeatCapacityUnit.KilojoulePerCubicMeterDegreeCelsius"/>
        /// </summary>
        public double KilojoulesPerCubicMeterDegreeCelsius => As(VolumetricHeatCapacityUnit.KilojoulePerCubicMeterDegreeCelsius);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="VolumetricHeatCapacityUnit.KilojoulePerCubicMeterKelvin"/>
        /// </summary>
        public double KilojoulesPerCubicMeterKelvin => As(VolumetricHeatCapacityUnit.KilojoulePerCubicMeterKelvin);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="VolumetricHeatCapacityUnit.MegajoulePerCubicMeterDegreeCelsius"/>
        /// </summary>
        public double MegajoulesPerCubicMeterDegreeCelsius => As(VolumetricHeatCapacityUnit.MegajoulePerCubicMeterDegreeCelsius);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="VolumetricHeatCapacityUnit.MegajoulePerCubicMeterKelvin"/>
        /// </summary>
        public double MegajoulesPerCubicMeterKelvin => As(VolumetricHeatCapacityUnit.MegajoulePerCubicMeterKelvin);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="VolumetricHeatCapacity"/> from <see cref="VolumetricHeatCapacityUnit.BtuPerCubicFootDegreeFahrenheit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static VolumetricHeatCapacity FromBtusPerCubicFootDegreeFahrenheit(double btuspercubicfootdegreefahrenheit) => new VolumetricHeatCapacity(btuspercubicfootdegreefahrenheit, VolumetricHeatCapacityUnit.BtuPerCubicFootDegreeFahrenheit);

        /// <summary>
        ///     Creates a <see cref="VolumetricHeatCapacity"/> from <see cref="VolumetricHeatCapacityUnit.CaloriePerCubicCentimeterDegreeCelsius"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static VolumetricHeatCapacity FromCaloriesPerCubicCentimeterDegreeCelsius(double caloriespercubiccentimeterdegreecelsius) => new VolumetricHeatCapacity(caloriespercubiccentimeterdegreecelsius, VolumetricHeatCapacityUnit.CaloriePerCubicCentimeterDegreeCelsius);

        /// <summary>
        ///     Creates a <see cref="VolumetricHeatCapacity"/> from <see cref="VolumetricHeatCapacityUnit.JoulePerCubicMeterDegreeCelsius"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static VolumetricHeatCapacity FromJoulesPerCubicMeterDegreeCelsius(double joulespercubicmeterdegreecelsius) => new VolumetricHeatCapacity(joulespercubicmeterdegreecelsius, VolumetricHeatCapacityUnit.JoulePerCubicMeterDegreeCelsius);

        /// <summary>
        ///     Creates a <see cref="VolumetricHeatCapacity"/> from <see cref="VolumetricHeatCapacityUnit.JoulePerCubicMeterKelvin"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static VolumetricHeatCapacity FromJoulesPerCubicMeterKelvin(double joulespercubicmeterkelvin) => new VolumetricHeatCapacity(joulespercubicmeterkelvin, VolumetricHeatCapacityUnit.JoulePerCubicMeterKelvin);

        /// <summary>
        ///     Creates a <see cref="VolumetricHeatCapacity"/> from <see cref="VolumetricHeatCapacityUnit.KilocaloriePerCubicCentimeterDegreeCelsius"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static VolumetricHeatCapacity FromKilocaloriesPerCubicCentimeterDegreeCelsius(double kilocaloriespercubiccentimeterdegreecelsius) => new VolumetricHeatCapacity(kilocaloriespercubiccentimeterdegreecelsius, VolumetricHeatCapacityUnit.KilocaloriePerCubicCentimeterDegreeCelsius);

        /// <summary>
        ///     Creates a <see cref="VolumetricHeatCapacity"/> from <see cref="VolumetricHeatCapacityUnit.KilojoulePerCubicMeterDegreeCelsius"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static VolumetricHeatCapacity FromKilojoulesPerCubicMeterDegreeCelsius(double kilojoulespercubicmeterdegreecelsius) => new VolumetricHeatCapacity(kilojoulespercubicmeterdegreecelsius, VolumetricHeatCapacityUnit.KilojoulePerCubicMeterDegreeCelsius);

        /// <summary>
        ///     Creates a <see cref="VolumetricHeatCapacity"/> from <see cref="VolumetricHeatCapacityUnit.KilojoulePerCubicMeterKelvin"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static VolumetricHeatCapacity FromKilojoulesPerCubicMeterKelvin(double kilojoulespercubicmeterkelvin) => new VolumetricHeatCapacity(kilojoulespercubicmeterkelvin, VolumetricHeatCapacityUnit.KilojoulePerCubicMeterKelvin);

        /// <summary>
        ///     Creates a <see cref="VolumetricHeatCapacity"/> from <see cref="VolumetricHeatCapacityUnit.MegajoulePerCubicMeterDegreeCelsius"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static VolumetricHeatCapacity FromMegajoulesPerCubicMeterDegreeCelsius(double megajoulespercubicmeterdegreecelsius) => new VolumetricHeatCapacity(megajoulespercubicmeterdegreecelsius, VolumetricHeatCapacityUnit.MegajoulePerCubicMeterDegreeCelsius);

        /// <summary>
        ///     Creates a <see cref="VolumetricHeatCapacity"/> from <see cref="VolumetricHeatCapacityUnit.MegajoulePerCubicMeterKelvin"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static VolumetricHeatCapacity FromMegajoulesPerCubicMeterKelvin(double megajoulespercubicmeterkelvin) => new VolumetricHeatCapacity(megajoulespercubicmeterkelvin, VolumetricHeatCapacityUnit.MegajoulePerCubicMeterKelvin);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="VolumetricHeatCapacityUnit" /> to <see cref="VolumetricHeatCapacity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>VolumetricHeatCapacity unit value.</returns>
        public static VolumetricHeatCapacity From(double value, VolumetricHeatCapacityUnit fromUnit)
        {
            return new VolumetricHeatCapacity(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(VolumetricHeatCapacityUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A Duration with the specified unit.</returns>
                public VolumetricHeatCapacity ToUnit(VolumetricHeatCapacityUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new VolumetricHeatCapacity(convertedValue, unit);
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
                        VolumetricHeatCapacityUnit.BtuPerCubicFootDegreeFahrenheit => _value / 1.4910660e-5,
                        VolumetricHeatCapacityUnit.CaloriePerCubicCentimeterDegreeCelsius => _value / 2.388459e-7,
                        VolumetricHeatCapacityUnit.JoulePerCubicMeterDegreeCelsius => _value,
                        VolumetricHeatCapacityUnit.JoulePerCubicMeterKelvin => _value,
                        VolumetricHeatCapacityUnit.KilocaloriePerCubicCentimeterDegreeCelsius => (_value / 2.388459e-7) * 1e3d,
                        VolumetricHeatCapacityUnit.KilojoulePerCubicMeterDegreeCelsius => (_value) * 1e3d,
                        VolumetricHeatCapacityUnit.KilojoulePerCubicMeterKelvin => (_value) * 1e3d,
                        VolumetricHeatCapacityUnit.MegajoulePerCubicMeterDegreeCelsius => (_value) * 1e6d,
                        VolumetricHeatCapacityUnit.MegajoulePerCubicMeterKelvin => (_value) * 1e6d,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(VolumetricHeatCapacityUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        VolumetricHeatCapacityUnit.BtuPerCubicFootDegreeFahrenheit => baseUnitValue * 1.4910660e-5,
                        VolumetricHeatCapacityUnit.CaloriePerCubicCentimeterDegreeCelsius => baseUnitValue * 2.388459e-7,
                        VolumetricHeatCapacityUnit.JoulePerCubicMeterDegreeCelsius => baseUnitValue,
                        VolumetricHeatCapacityUnit.JoulePerCubicMeterKelvin => baseUnitValue,
                        VolumetricHeatCapacityUnit.KilocaloriePerCubicCentimeterDegreeCelsius => (baseUnitValue * 2.388459e-7) / 1e3d,
                        VolumetricHeatCapacityUnit.KilojoulePerCubicMeterDegreeCelsius => (baseUnitValue) / 1e3d,
                        VolumetricHeatCapacityUnit.KilojoulePerCubicMeterKelvin => (baseUnitValue) / 1e3d,
                        VolumetricHeatCapacityUnit.MegajoulePerCubicMeterDegreeCelsius => (baseUnitValue) / 1e6d,
                        VolumetricHeatCapacityUnit.MegajoulePerCubicMeterKelvin => (baseUnitValue) / 1e6d,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

