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
using OasysUnitsNet.Units;

namespace OasysUnitsNet
{
    /// <inheritdoc />
    /// <summary>
    ///     In computing and telecommunications, a unit of information is the capacity of some standard data storage system or communication channel, used to measure the capacities of other systems and channels. In information theory, units of information are also used to measure the information contents or entropy of random variables.
    /// </summary>
    public struct  Information
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly InformationUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public InformationUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public Information(double value, InformationUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static InformationUnit BaseUnit { get; } = InformationUnit.Bit;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static Information MaxValue { get; } = new Information(79228162514264337593543950335d, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static Information MinValue { get; } = new Information(-79228162514264337593543950335d, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static Information Zero { get; } = new Information(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Bit"/>
        /// </summary>
        public double Bits => As(InformationUnit.Bit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Byte"/>
        /// </summary>
        public double Bytes => As(InformationUnit.Byte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Exabit"/>
        /// </summary>
        public double Exabits => As(InformationUnit.Exabit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Exabyte"/>
        /// </summary>
        public double Exabytes => As(InformationUnit.Exabyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Exbibit"/>
        /// </summary>
        public double Exbibits => As(InformationUnit.Exbibit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Exbibyte"/>
        /// </summary>
        public double Exbibytes => As(InformationUnit.Exbibyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Gibibit"/>
        /// </summary>
        public double Gibibits => As(InformationUnit.Gibibit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Gibibyte"/>
        /// </summary>
        public double Gibibytes => As(InformationUnit.Gibibyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Gigabit"/>
        /// </summary>
        public double Gigabits => As(InformationUnit.Gigabit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Gigabyte"/>
        /// </summary>
        public double Gigabytes => As(InformationUnit.Gigabyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Kibibit"/>
        /// </summary>
        public double Kibibits => As(InformationUnit.Kibibit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Kibibyte"/>
        /// </summary>
        public double Kibibytes => As(InformationUnit.Kibibyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Kilobit"/>
        /// </summary>
        public double Kilobits => As(InformationUnit.Kilobit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Kilobyte"/>
        /// </summary>
        public double Kilobytes => As(InformationUnit.Kilobyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Mebibit"/>
        /// </summary>
        public double Mebibits => As(InformationUnit.Mebibit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Mebibyte"/>
        /// </summary>
        public double Mebibytes => As(InformationUnit.Mebibyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Megabit"/>
        /// </summary>
        public double Megabits => As(InformationUnit.Megabit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Megabyte"/>
        /// </summary>
        public double Megabytes => As(InformationUnit.Megabyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Pebibit"/>
        /// </summary>
        public double Pebibits => As(InformationUnit.Pebibit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Pebibyte"/>
        /// </summary>
        public double Pebibytes => As(InformationUnit.Pebibyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Petabit"/>
        /// </summary>
        public double Petabits => As(InformationUnit.Petabit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Petabyte"/>
        /// </summary>
        public double Petabytes => As(InformationUnit.Petabyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Tebibit"/>
        /// </summary>
        public double Tebibits => As(InformationUnit.Tebibit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Tebibyte"/>
        /// </summary>
        public double Tebibytes => As(InformationUnit.Tebibyte);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Terabit"/>
        /// </summary>
        public double Terabits => As(InformationUnit.Terabit);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="InformationUnit.Terabyte"/>
        /// </summary>
        public double Terabytes => As(InformationUnit.Terabyte);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Bit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromBits(double bits) => new Information(bits, InformationUnit.Bit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Byte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromBytes(double bytes) => new Information(bytes, InformationUnit.Byte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Exabit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromExabits(double exabits) => new Information(exabits, InformationUnit.Exabit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Exabyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromExabytes(double exabytes) => new Information(exabytes, InformationUnit.Exabyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Exbibit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromExbibits(double exbibits) => new Information(exbibits, InformationUnit.Exbibit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Exbibyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromExbibytes(double exbibytes) => new Information(exbibytes, InformationUnit.Exbibyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Gibibit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromGibibits(double gibibits) => new Information(gibibits, InformationUnit.Gibibit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Gibibyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromGibibytes(double gibibytes) => new Information(gibibytes, InformationUnit.Gibibyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Gigabit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromGigabits(double gigabits) => new Information(gigabits, InformationUnit.Gigabit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Gigabyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromGigabytes(double gigabytes) => new Information(gigabytes, InformationUnit.Gigabyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Kibibit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromKibibits(double kibibits) => new Information(kibibits, InformationUnit.Kibibit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Kibibyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromKibibytes(double kibibytes) => new Information(kibibytes, InformationUnit.Kibibyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Kilobit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromKilobits(double kilobits) => new Information(kilobits, InformationUnit.Kilobit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Kilobyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromKilobytes(double kilobytes) => new Information(kilobytes, InformationUnit.Kilobyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Mebibit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromMebibits(double mebibits) => new Information(mebibits, InformationUnit.Mebibit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Mebibyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromMebibytes(double mebibytes) => new Information(mebibytes, InformationUnit.Mebibyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Megabit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromMegabits(double megabits) => new Information(megabits, InformationUnit.Megabit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Megabyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromMegabytes(double megabytes) => new Information(megabytes, InformationUnit.Megabyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Pebibit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromPebibits(double pebibits) => new Information(pebibits, InformationUnit.Pebibit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Pebibyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromPebibytes(double pebibytes) => new Information(pebibytes, InformationUnit.Pebibyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Petabit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromPetabits(double petabits) => new Information(petabits, InformationUnit.Petabit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Petabyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromPetabytes(double petabytes) => new Information(petabytes, InformationUnit.Petabyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Tebibit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromTebibits(double tebibits) => new Information(tebibits, InformationUnit.Tebibit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Tebibyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromTebibytes(double tebibytes) => new Information(tebibytes, InformationUnit.Tebibyte);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Terabit"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromTerabits(double terabits) => new Information(terabits, InformationUnit.Terabit);

        /// <summary>
        ///     Creates a <see cref="Information"/> from <see cref="InformationUnit.Terabyte"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Information FromTerabytes(double terabytes) => new Information(terabytes, InformationUnit.Terabyte);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="InformationUnit" /> to <see cref="Information" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Information unit value.</returns>
        public static Information From(double value, InformationUnit fromUnit)
        {
            return new Information(value, fromUnit);
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(InformationUnit unit) => GetValueAs(unit);

        /// <summary>
        ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Duration with the specified unit.</returns>
        public Information ToUnit(InformationUnit unit)
        {
            var convertedValue = GetValueAs(unit);
            return new Information(convertedValue, unit);
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
                InformationUnit.Bit => _value,
                InformationUnit.Byte => _value * 8d,
                InformationUnit.Exabit => (_value) * 1e18d,
                InformationUnit.Exabyte => (_value * 8d) * 1e18d,
                InformationUnit.Exbibit => (_value) * (1024d * 1024 * 1024 * 1024 * 1024 * 1024),
                InformationUnit.Exbibyte => (_value * 8d) * (1024d * 1024 * 1024 * 1024 * 1024 * 1024),
                InformationUnit.Gibibit => (_value) * (1024d * 1024 * 1024),
                InformationUnit.Gibibyte => (_value * 8d) * (1024d * 1024 * 1024),
                InformationUnit.Gigabit => (_value) * 1e9d,
                InformationUnit.Gigabyte => (_value * 8d) * 1e9d,
                InformationUnit.Kibibit => (_value) * 1024d,
                InformationUnit.Kibibyte => (_value * 8d) * 1024d,
                InformationUnit.Kilobit => (_value) * 1e3d,
                InformationUnit.Kilobyte => (_value * 8d) * 1e3d,
                InformationUnit.Mebibit => (_value) * (1024d * 1024),
                InformationUnit.Mebibyte => (_value * 8d) * (1024d * 1024),
                InformationUnit.Megabit => (_value) * 1e6d,
                InformationUnit.Megabyte => (_value * 8d) * 1e6d,
                InformationUnit.Pebibit => (_value) * (1024d * 1024 * 1024 * 1024 * 1024),
                InformationUnit.Pebibyte => (_value * 8d) * (1024d * 1024 * 1024 * 1024 * 1024),
                InformationUnit.Petabit => (_value) * 1e15d,
                InformationUnit.Petabyte => (_value * 8d) * 1e15d,
                InformationUnit.Tebibit => (_value) * (1024d * 1024 * 1024 * 1024),
                InformationUnit.Tebibyte => (_value * 8d) * (1024d * 1024 * 1024 * 1024),
                InformationUnit.Terabit => (_value) * 1e12d,
                InformationUnit.Terabyte => (_value * 8d) * 1e12d,
                _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
            };
        }

        private double GetValueAs(InformationUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            return unit switch
            {
                InformationUnit.Bit => baseUnitValue,
                InformationUnit.Byte => baseUnitValue / 8d,
                InformationUnit.Exabit => (baseUnitValue) / 1e18d,
                InformationUnit.Exabyte => (baseUnitValue / 8d) / 1e18d,
                InformationUnit.Exbibit => (baseUnitValue) / (1024d * 1024 * 1024 * 1024 * 1024 * 1024),
                InformationUnit.Exbibyte => (baseUnitValue / 8d) / (1024d * 1024 * 1024 * 1024 * 1024 * 1024),
                InformationUnit.Gibibit => (baseUnitValue) / (1024d * 1024 * 1024),
                InformationUnit.Gibibyte => (baseUnitValue / 8d) / (1024d * 1024 * 1024),
                InformationUnit.Gigabit => (baseUnitValue) / 1e9d,
                InformationUnit.Gigabyte => (baseUnitValue / 8d) / 1e9d,
                InformationUnit.Kibibit => (baseUnitValue) / 1024d,
                InformationUnit.Kibibyte => (baseUnitValue / 8d) / 1024d,
                InformationUnit.Kilobit => (baseUnitValue) / 1e3d,
                InformationUnit.Kilobyte => (baseUnitValue / 8d) / 1e3d,
                InformationUnit.Mebibit => (baseUnitValue) / (1024d * 1024),
                InformationUnit.Mebibyte => (baseUnitValue / 8d) / (1024d * 1024),
                InformationUnit.Megabit => (baseUnitValue) / 1e6d,
                InformationUnit.Megabyte => (baseUnitValue / 8d) / 1e6d,
                InformationUnit.Pebibit => (baseUnitValue) / (1024d * 1024 * 1024 * 1024 * 1024),
                InformationUnit.Pebibyte => (baseUnitValue / 8d) / (1024d * 1024 * 1024 * 1024 * 1024),
                InformationUnit.Petabit => (baseUnitValue) / 1e15d,
                InformationUnit.Petabyte => (baseUnitValue / 8d) / 1e15d,
                InformationUnit.Tebibit => (baseUnitValue) / (1024d * 1024 * 1024 * 1024),
                InformationUnit.Tebibyte => (baseUnitValue / 8d) / (1024d * 1024 * 1024 * 1024),
                InformationUnit.Terabit => (baseUnitValue) / 1e12d,
                InformationUnit.Terabyte => (baseUnitValue / 8d) / 1e12d,
                _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
            };
        }

        #endregion
    }
}

