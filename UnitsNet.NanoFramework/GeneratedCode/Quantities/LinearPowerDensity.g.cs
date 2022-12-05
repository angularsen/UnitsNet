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
    ///     The Linear Power Density of a substance is its power per unit length.  The term linear density is most often used when describing the characteristics of one-dimensional objects, although linear density can also be used to describe the density of a three-dimensional quantity along one particular dimension.
    /// </summary>
    /// <remarks>
    ///     http://en.wikipedia.org/wiki/Linear_density
    /// </remarks>
    public struct  LinearPowerDensity
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly LinearPowerDensityUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public LinearPowerDensityUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public LinearPowerDensity(double value, LinearPowerDensityUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static LinearPowerDensityUnit BaseUnit { get; } = LinearPowerDensityUnit.WattPerMeter;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static LinearPowerDensity MaxValue { get; } = new LinearPowerDensity(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static LinearPowerDensity MinValue { get; } = new LinearPowerDensity(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static LinearPowerDensity Zero { get; } = new LinearPowerDensity(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.GigawattPerCentimeter"/>
        /// </summary>
        public double GigawattsPerCentimeter => As(LinearPowerDensityUnit.GigawattPerCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.GigawattPerFoot"/>
        /// </summary>
        public double GigawattsPerFoot => As(LinearPowerDensityUnit.GigawattPerFoot);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.GigawattPerInch"/>
        /// </summary>
        public double GigawattsPerInch => As(LinearPowerDensityUnit.GigawattPerInch);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.GigawattPerMeter"/>
        /// </summary>
        public double GigawattsPerMeter => As(LinearPowerDensityUnit.GigawattPerMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.GigawattPerMillimeter"/>
        /// </summary>
        public double GigawattsPerMillimeter => As(LinearPowerDensityUnit.GigawattPerMillimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.KilowattPerCentimeter"/>
        /// </summary>
        public double KilowattsPerCentimeter => As(LinearPowerDensityUnit.KilowattPerCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.KilowattPerFoot"/>
        /// </summary>
        public double KilowattsPerFoot => As(LinearPowerDensityUnit.KilowattPerFoot);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.KilowattPerInch"/>
        /// </summary>
        public double KilowattsPerInch => As(LinearPowerDensityUnit.KilowattPerInch);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.KilowattPerMeter"/>
        /// </summary>
        public double KilowattsPerMeter => As(LinearPowerDensityUnit.KilowattPerMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.KilowattPerMillimeter"/>
        /// </summary>
        public double KilowattsPerMillimeter => As(LinearPowerDensityUnit.KilowattPerMillimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.MegawattPerCentimeter"/>
        /// </summary>
        public double MegawattsPerCentimeter => As(LinearPowerDensityUnit.MegawattPerCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.MegawattPerFoot"/>
        /// </summary>
        public double MegawattsPerFoot => As(LinearPowerDensityUnit.MegawattPerFoot);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.MegawattPerInch"/>
        /// </summary>
        public double MegawattsPerInch => As(LinearPowerDensityUnit.MegawattPerInch);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.MegawattPerMeter"/>
        /// </summary>
        public double MegawattsPerMeter => As(LinearPowerDensityUnit.MegawattPerMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.MegawattPerMillimeter"/>
        /// </summary>
        public double MegawattsPerMillimeter => As(LinearPowerDensityUnit.MegawattPerMillimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.MilliwattPerCentimeter"/>
        /// </summary>
        public double MilliwattsPerCentimeter => As(LinearPowerDensityUnit.MilliwattPerCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.MilliwattPerFoot"/>
        /// </summary>
        public double MilliwattsPerFoot => As(LinearPowerDensityUnit.MilliwattPerFoot);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.MilliwattPerInch"/>
        /// </summary>
        public double MilliwattsPerInch => As(LinearPowerDensityUnit.MilliwattPerInch);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.MilliwattPerMeter"/>
        /// </summary>
        public double MilliwattsPerMeter => As(LinearPowerDensityUnit.MilliwattPerMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.MilliwattPerMillimeter"/>
        /// </summary>
        public double MilliwattsPerMillimeter => As(LinearPowerDensityUnit.MilliwattPerMillimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.WattPerCentimeter"/>
        /// </summary>
        public double WattsPerCentimeter => As(LinearPowerDensityUnit.WattPerCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.WattPerFoot"/>
        /// </summary>
        public double WattsPerFoot => As(LinearPowerDensityUnit.WattPerFoot);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.WattPerInch"/>
        /// </summary>
        public double WattsPerInch => As(LinearPowerDensityUnit.WattPerInch);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.WattPerMeter"/>
        /// </summary>
        public double WattsPerMeter => As(LinearPowerDensityUnit.WattPerMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="LinearPowerDensityUnit.WattPerMillimeter"/>
        /// </summary>
        public double WattsPerMillimeter => As(LinearPowerDensityUnit.WattPerMillimeter);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.GigawattPerCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromGigawattsPerCentimeter(double gigawattspercentimeter) => new LinearPowerDensity(gigawattspercentimeter, LinearPowerDensityUnit.GigawattPerCentimeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.GigawattPerFoot"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromGigawattsPerFoot(double gigawattsperfoot) => new LinearPowerDensity(gigawattsperfoot, LinearPowerDensityUnit.GigawattPerFoot);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.GigawattPerInch"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromGigawattsPerInch(double gigawattsperinch) => new LinearPowerDensity(gigawattsperinch, LinearPowerDensityUnit.GigawattPerInch);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.GigawattPerMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromGigawattsPerMeter(double gigawattspermeter) => new LinearPowerDensity(gigawattspermeter, LinearPowerDensityUnit.GigawattPerMeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.GigawattPerMillimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromGigawattsPerMillimeter(double gigawattspermillimeter) => new LinearPowerDensity(gigawattspermillimeter, LinearPowerDensityUnit.GigawattPerMillimeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.KilowattPerCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromKilowattsPerCentimeter(double kilowattspercentimeter) => new LinearPowerDensity(kilowattspercentimeter, LinearPowerDensityUnit.KilowattPerCentimeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.KilowattPerFoot"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromKilowattsPerFoot(double kilowattsperfoot) => new LinearPowerDensity(kilowattsperfoot, LinearPowerDensityUnit.KilowattPerFoot);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.KilowattPerInch"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromKilowattsPerInch(double kilowattsperinch) => new LinearPowerDensity(kilowattsperinch, LinearPowerDensityUnit.KilowattPerInch);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.KilowattPerMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromKilowattsPerMeter(double kilowattspermeter) => new LinearPowerDensity(kilowattspermeter, LinearPowerDensityUnit.KilowattPerMeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.KilowattPerMillimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromKilowattsPerMillimeter(double kilowattspermillimeter) => new LinearPowerDensity(kilowattspermillimeter, LinearPowerDensityUnit.KilowattPerMillimeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.MegawattPerCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromMegawattsPerCentimeter(double megawattspercentimeter) => new LinearPowerDensity(megawattspercentimeter, LinearPowerDensityUnit.MegawattPerCentimeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.MegawattPerFoot"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromMegawattsPerFoot(double megawattsperfoot) => new LinearPowerDensity(megawattsperfoot, LinearPowerDensityUnit.MegawattPerFoot);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.MegawattPerInch"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromMegawattsPerInch(double megawattsperinch) => new LinearPowerDensity(megawattsperinch, LinearPowerDensityUnit.MegawattPerInch);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.MegawattPerMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromMegawattsPerMeter(double megawattspermeter) => new LinearPowerDensity(megawattspermeter, LinearPowerDensityUnit.MegawattPerMeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.MegawattPerMillimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromMegawattsPerMillimeter(double megawattspermillimeter) => new LinearPowerDensity(megawattspermillimeter, LinearPowerDensityUnit.MegawattPerMillimeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.MilliwattPerCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromMilliwattsPerCentimeter(double milliwattspercentimeter) => new LinearPowerDensity(milliwattspercentimeter, LinearPowerDensityUnit.MilliwattPerCentimeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.MilliwattPerFoot"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromMilliwattsPerFoot(double milliwattsperfoot) => new LinearPowerDensity(milliwattsperfoot, LinearPowerDensityUnit.MilliwattPerFoot);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.MilliwattPerInch"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromMilliwattsPerInch(double milliwattsperinch) => new LinearPowerDensity(milliwattsperinch, LinearPowerDensityUnit.MilliwattPerInch);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.MilliwattPerMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromMilliwattsPerMeter(double milliwattspermeter) => new LinearPowerDensity(milliwattspermeter, LinearPowerDensityUnit.MilliwattPerMeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.MilliwattPerMillimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromMilliwattsPerMillimeter(double milliwattspermillimeter) => new LinearPowerDensity(milliwattspermillimeter, LinearPowerDensityUnit.MilliwattPerMillimeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.WattPerCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromWattsPerCentimeter(double wattspercentimeter) => new LinearPowerDensity(wattspercentimeter, LinearPowerDensityUnit.WattPerCentimeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.WattPerFoot"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromWattsPerFoot(double wattsperfoot) => new LinearPowerDensity(wattsperfoot, LinearPowerDensityUnit.WattPerFoot);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.WattPerInch"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromWattsPerInch(double wattsperinch) => new LinearPowerDensity(wattsperinch, LinearPowerDensityUnit.WattPerInch);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.WattPerMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromWattsPerMeter(double wattspermeter) => new LinearPowerDensity(wattspermeter, LinearPowerDensityUnit.WattPerMeter);

        /// <summary>
        ///     Creates a <see cref="LinearPowerDensity"/> from <see cref="LinearPowerDensityUnit.WattPerMillimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static LinearPowerDensity FromWattsPerMillimeter(double wattspermillimeter) => new LinearPowerDensity(wattspermillimeter, LinearPowerDensityUnit.WattPerMillimeter);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="LinearPowerDensityUnit" /> to <see cref="LinearPowerDensity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>LinearPowerDensity unit value.</returns>
        public static LinearPowerDensity From(double value, LinearPowerDensityUnit fromUnit)
        {
            return new LinearPowerDensity(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(LinearPowerDensityUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A Duration with the specified unit.</returns>
                public LinearPowerDensity ToUnit(LinearPowerDensityUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new LinearPowerDensity(convertedValue, unit);
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
                        LinearPowerDensityUnit.GigawattPerCentimeter => (_value * 1e2) * 1e9d,
                        LinearPowerDensityUnit.GigawattPerFoot => (_value * 3.280839895) * 1e9d,
                        LinearPowerDensityUnit.GigawattPerInch => (_value * 39.37007874) * 1e9d,
                        LinearPowerDensityUnit.GigawattPerMeter => (_value) * 1e9d,
                        LinearPowerDensityUnit.GigawattPerMillimeter => (_value * 1e3) * 1e9d,
                        LinearPowerDensityUnit.KilowattPerCentimeter => (_value * 1e2) * 1e3d,
                        LinearPowerDensityUnit.KilowattPerFoot => (_value * 3.280839895) * 1e3d,
                        LinearPowerDensityUnit.KilowattPerInch => (_value * 39.37007874) * 1e3d,
                        LinearPowerDensityUnit.KilowattPerMeter => (_value) * 1e3d,
                        LinearPowerDensityUnit.KilowattPerMillimeter => (_value * 1e3) * 1e3d,
                        LinearPowerDensityUnit.MegawattPerCentimeter => (_value * 1e2) * 1e6d,
                        LinearPowerDensityUnit.MegawattPerFoot => (_value * 3.280839895) * 1e6d,
                        LinearPowerDensityUnit.MegawattPerInch => (_value * 39.37007874) * 1e6d,
                        LinearPowerDensityUnit.MegawattPerMeter => (_value) * 1e6d,
                        LinearPowerDensityUnit.MegawattPerMillimeter => (_value * 1e3) * 1e6d,
                        LinearPowerDensityUnit.MilliwattPerCentimeter => (_value * 1e2) * 1e-3d,
                        LinearPowerDensityUnit.MilliwattPerFoot => (_value * 3.280839895) * 1e-3d,
                        LinearPowerDensityUnit.MilliwattPerInch => (_value * 39.37007874) * 1e-3d,
                        LinearPowerDensityUnit.MilliwattPerMeter => (_value) * 1e-3d,
                        LinearPowerDensityUnit.MilliwattPerMillimeter => (_value * 1e3) * 1e-3d,
                        LinearPowerDensityUnit.WattPerCentimeter => _value * 1e2,
                        LinearPowerDensityUnit.WattPerFoot => _value * 3.280839895,
                        LinearPowerDensityUnit.WattPerInch => _value * 39.37007874,
                        LinearPowerDensityUnit.WattPerMeter => _value,
                        LinearPowerDensityUnit.WattPerMillimeter => _value * 1e3,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(LinearPowerDensityUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        LinearPowerDensityUnit.GigawattPerCentimeter => (baseUnitValue / 1e2) / 1e9d,
                        LinearPowerDensityUnit.GigawattPerFoot => (baseUnitValue / 3.280839895) / 1e9d,
                        LinearPowerDensityUnit.GigawattPerInch => (baseUnitValue / 39.37007874) / 1e9d,
                        LinearPowerDensityUnit.GigawattPerMeter => (baseUnitValue) / 1e9d,
                        LinearPowerDensityUnit.GigawattPerMillimeter => (baseUnitValue / 1e3) / 1e9d,
                        LinearPowerDensityUnit.KilowattPerCentimeter => (baseUnitValue / 1e2) / 1e3d,
                        LinearPowerDensityUnit.KilowattPerFoot => (baseUnitValue / 3.280839895) / 1e3d,
                        LinearPowerDensityUnit.KilowattPerInch => (baseUnitValue / 39.37007874) / 1e3d,
                        LinearPowerDensityUnit.KilowattPerMeter => (baseUnitValue) / 1e3d,
                        LinearPowerDensityUnit.KilowattPerMillimeter => (baseUnitValue / 1e3) / 1e3d,
                        LinearPowerDensityUnit.MegawattPerCentimeter => (baseUnitValue / 1e2) / 1e6d,
                        LinearPowerDensityUnit.MegawattPerFoot => (baseUnitValue / 3.280839895) / 1e6d,
                        LinearPowerDensityUnit.MegawattPerInch => (baseUnitValue / 39.37007874) / 1e6d,
                        LinearPowerDensityUnit.MegawattPerMeter => (baseUnitValue) / 1e6d,
                        LinearPowerDensityUnit.MegawattPerMillimeter => (baseUnitValue / 1e3) / 1e6d,
                        LinearPowerDensityUnit.MilliwattPerCentimeter => (baseUnitValue / 1e2) / 1e-3d,
                        LinearPowerDensityUnit.MilliwattPerFoot => (baseUnitValue / 3.280839895) / 1e-3d,
                        LinearPowerDensityUnit.MilliwattPerInch => (baseUnitValue / 39.37007874) / 1e-3d,
                        LinearPowerDensityUnit.MilliwattPerMeter => (baseUnitValue) / 1e-3d,
                        LinearPowerDensityUnit.MilliwattPerMillimeter => (baseUnitValue / 1e3) / 1e-3d,
                        LinearPowerDensityUnit.WattPerCentimeter => baseUnitValue / 1e2,
                        LinearPowerDensityUnit.WattPerFoot => baseUnitValue / 3.280839895,
                        LinearPowerDensityUnit.WattPerInch => baseUnitValue / 39.37007874,
                        LinearPowerDensityUnit.WattPerMeter => baseUnitValue,
                        LinearPowerDensityUnit.WattPerMillimeter => baseUnitValue / 1e3,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

