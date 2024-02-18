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
    ///     In thermodynamics, the specific volume of a substance is the ratio of the substance's volume to its mass. It is the reciprocal of density and an intrinsic property of matter as well.
    /// </summary>
    public struct  SpecificVolume
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly SpecificVolumeUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public SpecificVolumeUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public SpecificVolume(double value, SpecificVolumeUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of SpecificVolume, which is Second. All conversions go via this value.
        /// </summary>
        public static SpecificVolumeUnit BaseUnit { get; } = SpecificVolumeUnit.CubicMeterPerKilogram;

        /// <summary>
        /// Represents the largest possible value of SpecificVolume.
        /// </summary>
        public static SpecificVolume MaxValue { get; } = new SpecificVolume(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of SpecificVolume.
        /// </summary>
        public static SpecificVolume MinValue { get; } = new SpecificVolume(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static SpecificVolume Zero { get; } = new SpecificVolume(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpecificVolumeUnit.CubicFootPerPound"/>
        /// </summary>
        public double CubicFeetPerPound => As(SpecificVolumeUnit.CubicFootPerPound);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpecificVolumeUnit.CubicMeterPerKilogram"/>
        /// </summary>
        public double CubicMetersPerKilogram => As(SpecificVolumeUnit.CubicMeterPerKilogram);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpecificVolumeUnit.MillicubicMeterPerKilogram"/>
        /// </summary>
        public double MillicubicMetersPerKilogram => As(SpecificVolumeUnit.MillicubicMeterPerKilogram);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="SpecificVolume"/> from <see cref="SpecificVolumeUnit.CubicFootPerPound"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static SpecificVolume FromCubicFeetPerPound(double cubicfeetperpound) => new SpecificVolume(cubicfeetperpound, SpecificVolumeUnit.CubicFootPerPound);

        /// <summary>
        ///     Creates a <see cref="SpecificVolume"/> from <see cref="SpecificVolumeUnit.CubicMeterPerKilogram"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static SpecificVolume FromCubicMetersPerKilogram(double cubicmetersperkilogram) => new SpecificVolume(cubicmetersperkilogram, SpecificVolumeUnit.CubicMeterPerKilogram);

        /// <summary>
        ///     Creates a <see cref="SpecificVolume"/> from <see cref="SpecificVolumeUnit.MillicubicMeterPerKilogram"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static SpecificVolume FromMillicubicMetersPerKilogram(double millicubicmetersperkilogram) => new SpecificVolume(millicubicmetersperkilogram, SpecificVolumeUnit.MillicubicMeterPerKilogram);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpecificVolumeUnit" /> to <see cref="SpecificVolume" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>SpecificVolume unit value.</returns>
        public static SpecificVolume From(double value, SpecificVolumeUnit fromUnit)
        {
            return new SpecificVolume(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(SpecificVolumeUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this SpecificVolume to another SpecificVolume with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A SpecificVolume with the specified unit.</returns>
                public SpecificVolume ToUnit(SpecificVolumeUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new SpecificVolume(convertedValue, unit);
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
                        SpecificVolumeUnit.CubicFootPerPound => _value / 16.01846353,
                        SpecificVolumeUnit.CubicMeterPerKilogram => _value,
                        SpecificVolumeUnit.MillicubicMeterPerKilogram => (_value) * 1e-3d,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(SpecificVolumeUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        SpecificVolumeUnit.CubicFootPerPound => baseUnitValue * 16.01846353,
                        SpecificVolumeUnit.CubicMeterPerKilogram => baseUnitValue,
                        SpecificVolumeUnit.MillicubicMeterPerKilogram => (baseUnitValue) / 1e-3d,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

