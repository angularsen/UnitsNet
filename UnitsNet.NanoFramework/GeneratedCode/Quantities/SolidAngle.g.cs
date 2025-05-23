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
    ///     In geometry, a solid angle is the two-dimensional angle in three-dimensional space that an object subtends at a point.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Solid_angle
    /// </remarks>
    public struct  SolidAngle
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly SolidAngleUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public SolidAngleUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        public SolidAngle(double value, SolidAngleUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of SolidAngle, which is Second. All conversions go via this value.
        /// </summary>
        public static SolidAngleUnit BaseUnit { get; } = SolidAngleUnit.Steradian;

        /// <summary>
        /// Represents the largest possible value of SolidAngle.
        /// </summary>
        public static SolidAngle MaxValue { get; } = new SolidAngle(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of SolidAngle.
        /// </summary>
        public static SolidAngle MinValue { get; } = new SolidAngle(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static SolidAngle Zero { get; } = new SolidAngle(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SolidAngleUnit.Steradian"/>
        /// </summary>
        public double Steradians => As(SolidAngleUnit.Steradian);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="SolidAngle"/> from <see cref="SolidAngleUnit.Steradian"/>.
        /// </summary>
        public static SolidAngle FromSteradians(double steradians) => new SolidAngle(steradians, SolidAngleUnit.Steradian);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SolidAngleUnit" /> to <see cref="SolidAngle" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>SolidAngle unit value.</returns>
        public static SolidAngle From(double value, SolidAngleUnit fromUnit)
        {
            return new SolidAngle(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(SolidAngleUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this SolidAngle to another SolidAngle with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A SolidAngle with the specified unit.</returns>
                public SolidAngle ToUnit(SolidAngleUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new SolidAngle(convertedValue, unit);
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
                        SolidAngleUnit.Steradian => _value,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(SolidAngleUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        SolidAngleUnit.Steradian => baseUnitValue,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

