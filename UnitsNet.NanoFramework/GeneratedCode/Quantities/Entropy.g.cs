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
    ///     Entropy is an important concept in the branch of science known as thermodynamics. The idea of "irreversibility" is central to the understanding of entropy.  It is often said that entropy is an expression of the disorder, or randomness of a system, or of our lack of information about it. Entropy is an extensive property. It has the dimension of energy divided by temperature, which has a unit of joules per kelvin (J/K) in the International System of Units
    /// </summary>
    public struct  Entropy
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly EntropyUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public EntropyUnit Unit => _unit;
        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public Entropy(double value, EntropyUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static EntropyUnit BaseUnit { get; } = EntropyUnit.JoulePerKelvin;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static Entropy MaxValue { get; } = new Entropy(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static Entropy MinValue { get; } = new Entropy(double.MinValue, BaseUnit);
        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static Entropy Zero { get; } = new Entropy(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Get Entropy in CaloriesPerKelvin.
        /// </summary>
        public double CaloriesPerKelvin => As(EntropyUnit.CaloriePerKelvin);

        /// <summary>
        ///     Get Entropy in JoulesPerDegreeCelsius.
        /// </summary>
        public double JoulesPerDegreeCelsius => As(EntropyUnit.JoulePerDegreeCelsius);

        /// <summary>
        ///     Get Entropy in JoulesPerKelvin.
        /// </summary>
        public double JoulesPerKelvin => As(EntropyUnit.JoulePerKelvin);

        /// <summary>
        ///     Get Entropy in KilocaloriesPerKelvin.
        /// </summary>
        public double KilocaloriesPerKelvin => As(EntropyUnit.KilocaloriePerKelvin);

        /// <summary>
        ///     Get Entropy in KilojoulesPerDegreeCelsius.
        /// </summary>
        public double KilojoulesPerDegreeCelsius => As(EntropyUnit.KilojoulePerDegreeCelsius);

        /// <summary>
        ///     Get Entropy in KilojoulesPerKelvin.
        /// </summary>
        public double KilojoulesPerKelvin => As(EntropyUnit.KilojoulePerKelvin);

        /// <summary>
        ///     Get Entropy in MegajoulesPerKelvin.
        /// </summary>
        public double MegajoulesPerKelvin => As(EntropyUnit.MegajoulePerKelvin);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Get Entropy from CaloriesPerKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Entropy FromCaloriesPerKelvin(double caloriesperkelvin) => new Entropy(caloriesperkelvin, EntropyUnit.CaloriePerKelvin);

        /// <summary>
        ///     Get Entropy from JoulesPerDegreeCelsius.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Entropy FromJoulesPerDegreeCelsius(double joulesperdegreecelsius) => new Entropy(joulesperdegreecelsius, EntropyUnit.JoulePerDegreeCelsius);

        /// <summary>
        ///     Get Entropy from JoulesPerKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Entropy FromJoulesPerKelvin(double joulesperkelvin) => new Entropy(joulesperkelvin, EntropyUnit.JoulePerKelvin);

        /// <summary>
        ///     Get Entropy from KilocaloriesPerKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Entropy FromKilocaloriesPerKelvin(double kilocaloriesperkelvin) => new Entropy(kilocaloriesperkelvin, EntropyUnit.KilocaloriePerKelvin);

        /// <summary>
        ///     Get Entropy from KilojoulesPerDegreeCelsius.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Entropy FromKilojoulesPerDegreeCelsius(double kilojoulesperdegreecelsius) => new Entropy(kilojoulesperdegreecelsius, EntropyUnit.KilojoulePerDegreeCelsius);

        /// <summary>
        ///     Get Entropy from KilojoulesPerKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Entropy FromKilojoulesPerKelvin(double kilojoulesperkelvin) => new Entropy(kilojoulesperkelvin, EntropyUnit.KilojoulePerKelvin);

        /// <summary>
        ///     Get Entropy from MegajoulesPerKelvin.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Entropy FromMegajoulesPerKelvin(double megajoulesperkelvin) => new Entropy(megajoulesperkelvin, EntropyUnit.MegajoulePerKelvin);


        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="EntropyUnit" /> to <see cref="Entropy" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Entropy unit value.</returns>
        public static Entropy From(double value, EntropyUnit fromUnit)
        {
            return new Entropy(value, fromUnit);
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(EntropyUnit unit) => GetValueAs(unit);        

        /// <summary>
        ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Duration with the specified unit.</returns>
        public Entropy ToUnit(EntropyUnit unit)
        {
                
            var convertedValue = GetValueAs(unit);
            return new Entropy(convertedValue, unit);
        }


        /// <summary>
        ///     Converts the current value + unit to the base unit.
        ///     This is typically the first step in converting from one unit to another.
        /// </summary>
        /// <returns>The value in the base unit representation.</returns>
        private double GetValueInBaseUnit()
        {
            switch(Unit)
            {
                case EntropyUnit.CaloriePerKelvin: return _value*4.184;
                case EntropyUnit.JoulePerDegreeCelsius: return _value;
                case EntropyUnit.JoulePerKelvin: return _value;
                case EntropyUnit.KilocaloriePerKelvin: return (_value*4.184) * 1e3d;
                case EntropyUnit.KilojoulePerDegreeCelsius: return (_value) * 1e3d;
                case EntropyUnit.KilojoulePerKelvin: return (_value) * 1e3d;
                case EntropyUnit.MegajoulePerKelvin: return (_value) * 1e6d;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to base units.");
            }
        }

        private double GetValueAs(EntropyUnit unit)
        {
            if(Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            switch(unit)
            {
                case EntropyUnit.CaloriePerKelvin: return baseUnitValue/4.184;
                case EntropyUnit.JoulePerDegreeCelsius: return baseUnitValue;
                case EntropyUnit.JoulePerKelvin: return baseUnitValue;
                case EntropyUnit.KilocaloriePerKelvin: return (baseUnitValue/4.184) / 1e3d;
                case EntropyUnit.KilojoulePerDegreeCelsius: return (baseUnitValue) / 1e3d;
                case EntropyUnit.KilojoulePerKelvin: return (baseUnitValue) / 1e3d;
                case EntropyUnit.MegajoulePerKelvin: return (baseUnitValue) / 1e6d;
                default:
                    throw new NotImplementedException($"Can not convert {Unit} to {unit}.");
            }
        }

        #endregion

    }
}

