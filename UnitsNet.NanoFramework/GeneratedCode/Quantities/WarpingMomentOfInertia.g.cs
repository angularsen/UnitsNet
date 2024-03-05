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
    ///     A geometric property of an area that is used to determine the warping stress.
    /// </summary>
    public struct  WarpingMomentOfInertia
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly WarpingMomentOfInertiaUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public WarpingMomentOfInertiaUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        public WarpingMomentOfInertia(double value, WarpingMomentOfInertiaUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of WarpingMomentOfInertia, which is Second. All conversions go via this value.
        /// </summary>
        public static WarpingMomentOfInertiaUnit BaseUnit { get; } = WarpingMomentOfInertiaUnit.MeterToTheSixth;

        /// <summary>
        /// Represents the largest possible value of WarpingMomentOfInertia.
        /// </summary>
        public static WarpingMomentOfInertia MaxValue { get; } = new WarpingMomentOfInertia(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of WarpingMomentOfInertia.
        /// </summary>
        public static WarpingMomentOfInertia MinValue { get; } = new WarpingMomentOfInertia(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static WarpingMomentOfInertia Zero { get; } = new WarpingMomentOfInertia(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="WarpingMomentOfInertiaUnit.CentimeterToTheSixth"/>
        /// </summary>
        public double CentimetersToTheSixth => As(WarpingMomentOfInertiaUnit.CentimeterToTheSixth);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="WarpingMomentOfInertiaUnit.DecimeterToTheSixth"/>
        /// </summary>
        public double DecimetersToTheSixth => As(WarpingMomentOfInertiaUnit.DecimeterToTheSixth);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="WarpingMomentOfInertiaUnit.FootToTheSixth"/>
        /// </summary>
        public double FeetToTheSixth => As(WarpingMomentOfInertiaUnit.FootToTheSixth);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="WarpingMomentOfInertiaUnit.InchToTheSixth"/>
        /// </summary>
        public double InchesToTheSixth => As(WarpingMomentOfInertiaUnit.InchToTheSixth);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="WarpingMomentOfInertiaUnit.MeterToTheSixth"/>
        /// </summary>
        public double MetersToTheSixth => As(WarpingMomentOfInertiaUnit.MeterToTheSixth);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="WarpingMomentOfInertiaUnit.MillimeterToTheSixth"/>
        /// </summary>
        public double MillimetersToTheSixth => As(WarpingMomentOfInertiaUnit.MillimeterToTheSixth);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="WarpingMomentOfInertia"/> from <see cref="WarpingMomentOfInertiaUnit.CentimeterToTheSixth"/>.
        /// </summary>
        public static WarpingMomentOfInertia FromCentimetersToTheSixth(double centimeterstothesixth) => new WarpingMomentOfInertia(centimeterstothesixth, WarpingMomentOfInertiaUnit.CentimeterToTheSixth);

        /// <summary>
        ///     Creates a <see cref="WarpingMomentOfInertia"/> from <see cref="WarpingMomentOfInertiaUnit.DecimeterToTheSixth"/>.
        /// </summary>
        public static WarpingMomentOfInertia FromDecimetersToTheSixth(double decimeterstothesixth) => new WarpingMomentOfInertia(decimeterstothesixth, WarpingMomentOfInertiaUnit.DecimeterToTheSixth);

        /// <summary>
        ///     Creates a <see cref="WarpingMomentOfInertia"/> from <see cref="WarpingMomentOfInertiaUnit.FootToTheSixth"/>.
        /// </summary>
        public static WarpingMomentOfInertia FromFeetToTheSixth(double feettothesixth) => new WarpingMomentOfInertia(feettothesixth, WarpingMomentOfInertiaUnit.FootToTheSixth);

        /// <summary>
        ///     Creates a <see cref="WarpingMomentOfInertia"/> from <see cref="WarpingMomentOfInertiaUnit.InchToTheSixth"/>.
        /// </summary>
        public static WarpingMomentOfInertia FromInchesToTheSixth(double inchestothesixth) => new WarpingMomentOfInertia(inchestothesixth, WarpingMomentOfInertiaUnit.InchToTheSixth);

        /// <summary>
        ///     Creates a <see cref="WarpingMomentOfInertia"/> from <see cref="WarpingMomentOfInertiaUnit.MeterToTheSixth"/>.
        /// </summary>
        public static WarpingMomentOfInertia FromMetersToTheSixth(double meterstothesixth) => new WarpingMomentOfInertia(meterstothesixth, WarpingMomentOfInertiaUnit.MeterToTheSixth);

        /// <summary>
        ///     Creates a <see cref="WarpingMomentOfInertia"/> from <see cref="WarpingMomentOfInertiaUnit.MillimeterToTheSixth"/>.
        /// </summary>
        public static WarpingMomentOfInertia FromMillimetersToTheSixth(double millimeterstothesixth) => new WarpingMomentOfInertia(millimeterstothesixth, WarpingMomentOfInertiaUnit.MillimeterToTheSixth);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="WarpingMomentOfInertiaUnit" /> to <see cref="WarpingMomentOfInertia" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>WarpingMomentOfInertia unit value.</returns>
        public static WarpingMomentOfInertia From(double value, WarpingMomentOfInertiaUnit fromUnit)
        {
            return new WarpingMomentOfInertia(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(WarpingMomentOfInertiaUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this WarpingMomentOfInertia to another WarpingMomentOfInertia with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A WarpingMomentOfInertia with the specified unit.</returns>
                public WarpingMomentOfInertia ToUnit(WarpingMomentOfInertiaUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new WarpingMomentOfInertia(convertedValue, unit);
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
                        WarpingMomentOfInertiaUnit.CentimeterToTheSixth => _value / 1e12,
                        WarpingMomentOfInertiaUnit.DecimeterToTheSixth => _value / 1e6,
                        WarpingMomentOfInertiaUnit.FootToTheSixth => _value * 0.000801843800914862014464,
                        WarpingMomentOfInertiaUnit.InchToTheSixth => _value * Math.Pow(2.54e-2, 6),
                        WarpingMomentOfInertiaUnit.MeterToTheSixth => _value,
                        WarpingMomentOfInertiaUnit.MillimeterToTheSixth => _value / 1e18,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(WarpingMomentOfInertiaUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        WarpingMomentOfInertiaUnit.CentimeterToTheSixth => baseUnitValue * 1e12,
                        WarpingMomentOfInertiaUnit.DecimeterToTheSixth => baseUnitValue * 1e6,
                        WarpingMomentOfInertiaUnit.FootToTheSixth => baseUnitValue / 0.000801843800914862014464,
                        WarpingMomentOfInertiaUnit.InchToTheSixth => baseUnitValue / Math.Pow(2.54e-2, 6),
                        WarpingMomentOfInertiaUnit.MeterToTheSixth => baseUnitValue,
                        WarpingMomentOfInertiaUnit.MillimeterToTheSixth => baseUnitValue * 1e18,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

