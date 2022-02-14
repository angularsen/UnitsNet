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
    ///     https://en.wikipedia.org/wiki/Stiffness#Rotational_stiffness
    /// </summary>
    public struct  RotationalStiffness
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly RotationalStiffnessUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public RotationalStiffnessUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public RotationalStiffness(double value, RotationalStiffnessUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static RotationalStiffnessUnit BaseUnit { get; } = RotationalStiffnessUnit.NewtonMeterPerRadian;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static RotationalStiffness MaxValue { get; } = new RotationalStiffness(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static RotationalStiffness MinValue { get; } = new RotationalStiffness(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static RotationalStiffness Zero { get; } = new RotationalStiffness(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.CentinewtonMeterPerDegree"/>
        /// </summary>
        public double CentinewtonMetersPerDegree => As(RotationalStiffnessUnit.CentinewtonMeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.CentinewtonMillimeterPerDegree"/>
        /// </summary>
        public double CentinewtonMillimetersPerDegree => As(RotationalStiffnessUnit.CentinewtonMillimeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.CentinewtonMillimeterPerRadian"/>
        /// </summary>
        public double CentinewtonMillimetersPerRadian => As(RotationalStiffnessUnit.CentinewtonMillimeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.DecanewtonMeterPerDegree"/>
        /// </summary>
        public double DecanewtonMetersPerDegree => As(RotationalStiffnessUnit.DecanewtonMeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.DecanewtonMillimeterPerDegree"/>
        /// </summary>
        public double DecanewtonMillimetersPerDegree => As(RotationalStiffnessUnit.DecanewtonMillimeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.DecanewtonMillimeterPerRadian"/>
        /// </summary>
        public double DecanewtonMillimetersPerRadian => As(RotationalStiffnessUnit.DecanewtonMillimeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.DecinewtonMeterPerDegree"/>
        /// </summary>
        public double DecinewtonMetersPerDegree => As(RotationalStiffnessUnit.DecinewtonMeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.DecinewtonMillimeterPerDegree"/>
        /// </summary>
        public double DecinewtonMillimetersPerDegree => As(RotationalStiffnessUnit.DecinewtonMillimeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.DecinewtonMillimeterPerRadian"/>
        /// </summary>
        public double DecinewtonMillimetersPerRadian => As(RotationalStiffnessUnit.DecinewtonMillimeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.KilonewtonMeterPerDegree"/>
        /// </summary>
        public double KilonewtonMetersPerDegree => As(RotationalStiffnessUnit.KilonewtonMeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.KilonewtonMeterPerRadian"/>
        /// </summary>
        public double KilonewtonMetersPerRadian => As(RotationalStiffnessUnit.KilonewtonMeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.KilonewtonMillimeterPerDegree"/>
        /// </summary>
        public double KilonewtonMillimetersPerDegree => As(RotationalStiffnessUnit.KilonewtonMillimeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.KilonewtonMillimeterPerRadian"/>
        /// </summary>
        public double KilonewtonMillimetersPerRadian => As(RotationalStiffnessUnit.KilonewtonMillimeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.KilopoundForceFootPerDegrees"/>
        /// </summary>
        public double KilopoundForceFeetPerDegrees => As(RotationalStiffnessUnit.KilopoundForceFootPerDegrees);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.MeganewtonMeterPerDegree"/>
        /// </summary>
        public double MeganewtonMetersPerDegree => As(RotationalStiffnessUnit.MeganewtonMeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.MeganewtonMeterPerRadian"/>
        /// </summary>
        public double MeganewtonMetersPerRadian => As(RotationalStiffnessUnit.MeganewtonMeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.MeganewtonMillimeterPerDegree"/>
        /// </summary>
        public double MeganewtonMillimetersPerDegree => As(RotationalStiffnessUnit.MeganewtonMillimeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.MeganewtonMillimeterPerRadian"/>
        /// </summary>
        public double MeganewtonMillimetersPerRadian => As(RotationalStiffnessUnit.MeganewtonMillimeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.MicronewtonMeterPerDegree"/>
        /// </summary>
        public double MicronewtonMetersPerDegree => As(RotationalStiffnessUnit.MicronewtonMeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.MicronewtonMillimeterPerDegree"/>
        /// </summary>
        public double MicronewtonMillimetersPerDegree => As(RotationalStiffnessUnit.MicronewtonMillimeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.MicronewtonMillimeterPerRadian"/>
        /// </summary>
        public double MicronewtonMillimetersPerRadian => As(RotationalStiffnessUnit.MicronewtonMillimeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.MillinewtonMeterPerDegree"/>
        /// </summary>
        public double MillinewtonMetersPerDegree => As(RotationalStiffnessUnit.MillinewtonMeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.MillinewtonMillimeterPerDegree"/>
        /// </summary>
        public double MillinewtonMillimetersPerDegree => As(RotationalStiffnessUnit.MillinewtonMillimeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.MillinewtonMillimeterPerRadian"/>
        /// </summary>
        public double MillinewtonMillimetersPerRadian => As(RotationalStiffnessUnit.MillinewtonMillimeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.NanonewtonMeterPerDegree"/>
        /// </summary>
        public double NanonewtonMetersPerDegree => As(RotationalStiffnessUnit.NanonewtonMeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.NanonewtonMillimeterPerDegree"/>
        /// </summary>
        public double NanonewtonMillimetersPerDegree => As(RotationalStiffnessUnit.NanonewtonMillimeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.NanonewtonMillimeterPerRadian"/>
        /// </summary>
        public double NanonewtonMillimetersPerRadian => As(RotationalStiffnessUnit.NanonewtonMillimeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.NewtonMeterPerDegree"/>
        /// </summary>
        public double NewtonMetersPerDegree => As(RotationalStiffnessUnit.NewtonMeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.NewtonMeterPerRadian"/>
        /// </summary>
        public double NewtonMetersPerRadian => As(RotationalStiffnessUnit.NewtonMeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.NewtonMillimeterPerDegree"/>
        /// </summary>
        public double NewtonMillimetersPerDegree => As(RotationalStiffnessUnit.NewtonMillimeterPerDegree);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.NewtonMillimeterPerRadian"/>
        /// </summary>
        public double NewtonMillimetersPerRadian => As(RotationalStiffnessUnit.NewtonMillimeterPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.PoundForceFeetPerRadian"/>
        /// </summary>
        public double PoundForceFeetPerRadian => As(RotationalStiffnessUnit.PoundForceFeetPerRadian);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalStiffnessUnit.PoundForceFootPerDegrees"/>
        /// </summary>
        public double PoundForceFeetPerDegrees => As(RotationalStiffnessUnit.PoundForceFootPerDegrees);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.CentinewtonMeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromCentinewtonMetersPerDegree(double centinewtonmetersperdegree) => new RotationalStiffness(centinewtonmetersperdegree, RotationalStiffnessUnit.CentinewtonMeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.CentinewtonMillimeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromCentinewtonMillimetersPerDegree(double centinewtonmillimetersperdegree) => new RotationalStiffness(centinewtonmillimetersperdegree, RotationalStiffnessUnit.CentinewtonMillimeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.CentinewtonMillimeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromCentinewtonMillimetersPerRadian(double centinewtonmillimetersperradian) => new RotationalStiffness(centinewtonmillimetersperradian, RotationalStiffnessUnit.CentinewtonMillimeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.DecanewtonMeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromDecanewtonMetersPerDegree(double decanewtonmetersperdegree) => new RotationalStiffness(decanewtonmetersperdegree, RotationalStiffnessUnit.DecanewtonMeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.DecanewtonMillimeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromDecanewtonMillimetersPerDegree(double decanewtonmillimetersperdegree) => new RotationalStiffness(decanewtonmillimetersperdegree, RotationalStiffnessUnit.DecanewtonMillimeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.DecanewtonMillimeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromDecanewtonMillimetersPerRadian(double decanewtonmillimetersperradian) => new RotationalStiffness(decanewtonmillimetersperradian, RotationalStiffnessUnit.DecanewtonMillimeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.DecinewtonMeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromDecinewtonMetersPerDegree(double decinewtonmetersperdegree) => new RotationalStiffness(decinewtonmetersperdegree, RotationalStiffnessUnit.DecinewtonMeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.DecinewtonMillimeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromDecinewtonMillimetersPerDegree(double decinewtonmillimetersperdegree) => new RotationalStiffness(decinewtonmillimetersperdegree, RotationalStiffnessUnit.DecinewtonMillimeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.DecinewtonMillimeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromDecinewtonMillimetersPerRadian(double decinewtonmillimetersperradian) => new RotationalStiffness(decinewtonmillimetersperradian, RotationalStiffnessUnit.DecinewtonMillimeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.KilonewtonMeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromKilonewtonMetersPerDegree(double kilonewtonmetersperdegree) => new RotationalStiffness(kilonewtonmetersperdegree, RotationalStiffnessUnit.KilonewtonMeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.KilonewtonMeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromKilonewtonMetersPerRadian(double kilonewtonmetersperradian) => new RotationalStiffness(kilonewtonmetersperradian, RotationalStiffnessUnit.KilonewtonMeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.KilonewtonMillimeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromKilonewtonMillimetersPerDegree(double kilonewtonmillimetersperdegree) => new RotationalStiffness(kilonewtonmillimetersperdegree, RotationalStiffnessUnit.KilonewtonMillimeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.KilonewtonMillimeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromKilonewtonMillimetersPerRadian(double kilonewtonmillimetersperradian) => new RotationalStiffness(kilonewtonmillimetersperradian, RotationalStiffnessUnit.KilonewtonMillimeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.KilopoundForceFootPerDegrees"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromKilopoundForceFeetPerDegrees(double kilopoundforcefeetperdegrees) => new RotationalStiffness(kilopoundforcefeetperdegrees, RotationalStiffnessUnit.KilopoundForceFootPerDegrees);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.MeganewtonMeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromMeganewtonMetersPerDegree(double meganewtonmetersperdegree) => new RotationalStiffness(meganewtonmetersperdegree, RotationalStiffnessUnit.MeganewtonMeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.MeganewtonMeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromMeganewtonMetersPerRadian(double meganewtonmetersperradian) => new RotationalStiffness(meganewtonmetersperradian, RotationalStiffnessUnit.MeganewtonMeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.MeganewtonMillimeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromMeganewtonMillimetersPerDegree(double meganewtonmillimetersperdegree) => new RotationalStiffness(meganewtonmillimetersperdegree, RotationalStiffnessUnit.MeganewtonMillimeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.MeganewtonMillimeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromMeganewtonMillimetersPerRadian(double meganewtonmillimetersperradian) => new RotationalStiffness(meganewtonmillimetersperradian, RotationalStiffnessUnit.MeganewtonMillimeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.MicronewtonMeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromMicronewtonMetersPerDegree(double micronewtonmetersperdegree) => new RotationalStiffness(micronewtonmetersperdegree, RotationalStiffnessUnit.MicronewtonMeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.MicronewtonMillimeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromMicronewtonMillimetersPerDegree(double micronewtonmillimetersperdegree) => new RotationalStiffness(micronewtonmillimetersperdegree, RotationalStiffnessUnit.MicronewtonMillimeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.MicronewtonMillimeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromMicronewtonMillimetersPerRadian(double micronewtonmillimetersperradian) => new RotationalStiffness(micronewtonmillimetersperradian, RotationalStiffnessUnit.MicronewtonMillimeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.MillinewtonMeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromMillinewtonMetersPerDegree(double millinewtonmetersperdegree) => new RotationalStiffness(millinewtonmetersperdegree, RotationalStiffnessUnit.MillinewtonMeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.MillinewtonMillimeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromMillinewtonMillimetersPerDegree(double millinewtonmillimetersperdegree) => new RotationalStiffness(millinewtonmillimetersperdegree, RotationalStiffnessUnit.MillinewtonMillimeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.MillinewtonMillimeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromMillinewtonMillimetersPerRadian(double millinewtonmillimetersperradian) => new RotationalStiffness(millinewtonmillimetersperradian, RotationalStiffnessUnit.MillinewtonMillimeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.NanonewtonMeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromNanonewtonMetersPerDegree(double nanonewtonmetersperdegree) => new RotationalStiffness(nanonewtonmetersperdegree, RotationalStiffnessUnit.NanonewtonMeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.NanonewtonMillimeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromNanonewtonMillimetersPerDegree(double nanonewtonmillimetersperdegree) => new RotationalStiffness(nanonewtonmillimetersperdegree, RotationalStiffnessUnit.NanonewtonMillimeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.NanonewtonMillimeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromNanonewtonMillimetersPerRadian(double nanonewtonmillimetersperradian) => new RotationalStiffness(nanonewtonmillimetersperradian, RotationalStiffnessUnit.NanonewtonMillimeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.NewtonMeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromNewtonMetersPerDegree(double newtonmetersperdegree) => new RotationalStiffness(newtonmetersperdegree, RotationalStiffnessUnit.NewtonMeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.NewtonMeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromNewtonMetersPerRadian(double newtonmetersperradian) => new RotationalStiffness(newtonmetersperradian, RotationalStiffnessUnit.NewtonMeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.NewtonMillimeterPerDegree"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromNewtonMillimetersPerDegree(double newtonmillimetersperdegree) => new RotationalStiffness(newtonmillimetersperdegree, RotationalStiffnessUnit.NewtonMillimeterPerDegree);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.NewtonMillimeterPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromNewtonMillimetersPerRadian(double newtonmillimetersperradian) => new RotationalStiffness(newtonmillimetersperradian, RotationalStiffnessUnit.NewtonMillimeterPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.PoundForceFeetPerRadian"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromPoundForceFeetPerRadian(double poundforcefeetperradian) => new RotationalStiffness(poundforcefeetperradian, RotationalStiffnessUnit.PoundForceFeetPerRadian);

        /// <summary>
        ///     Creates a <see cref="RotationalStiffness"/> from <see cref="RotationalStiffnessUnit.PoundForceFootPerDegrees"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static RotationalStiffness FromPoundForceFeetPerDegrees(double poundforcefeetperdegrees) => new RotationalStiffness(poundforcefeetperdegrees, RotationalStiffnessUnit.PoundForceFootPerDegrees);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RotationalStiffnessUnit" /> to <see cref="RotationalStiffness" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>RotationalStiffness unit value.</returns>
        public static RotationalStiffness From(double value, RotationalStiffnessUnit fromUnit)
        {
            return new RotationalStiffness(value, fromUnit);
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(RotationalStiffnessUnit unit) => GetValueAs(unit);

        /// <summary>
        ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Duration with the specified unit.</returns>
        public RotationalStiffness ToUnit(RotationalStiffnessUnit unit)
        {
            var convertedValue = GetValueAs(unit);
            return new RotationalStiffness(convertedValue, unit);
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
                RotationalStiffnessUnit.CentinewtonMeterPerDegree => (_value * (180 / 3.1415926535897931)) * 1e-2d,
                RotationalStiffnessUnit.CentinewtonMillimeterPerDegree => (_value * 180 / 3.1415926535897931 * 0.001) * 1e-2d,
                RotationalStiffnessUnit.CentinewtonMillimeterPerRadian => (_value * 0.001) * 1e-2d,
                RotationalStiffnessUnit.DecanewtonMeterPerDegree => (_value * (180 / 3.1415926535897931)) * 1e1d,
                RotationalStiffnessUnit.DecanewtonMillimeterPerDegree => (_value * 180 / 3.1415926535897931 * 0.001) * 1e1d,
                RotationalStiffnessUnit.DecanewtonMillimeterPerRadian => (_value * 0.001) * 1e1d,
                RotationalStiffnessUnit.DecinewtonMeterPerDegree => (_value * (180 / 3.1415926535897931)) * 1e-1d,
                RotationalStiffnessUnit.DecinewtonMillimeterPerDegree => (_value * 180 / 3.1415926535897931 * 0.001) * 1e-1d,
                RotationalStiffnessUnit.DecinewtonMillimeterPerRadian => (_value * 0.001) * 1e-1d,
                RotationalStiffnessUnit.KilonewtonMeterPerDegree => (_value * (180 / 3.1415926535897931)) * 1e3d,
                RotationalStiffnessUnit.KilonewtonMeterPerRadian => (_value) * 1e3d,
                RotationalStiffnessUnit.KilonewtonMillimeterPerDegree => (_value * 180 / 3.1415926535897931 * 0.001) * 1e3d,
                RotationalStiffnessUnit.KilonewtonMillimeterPerRadian => (_value * 0.001) * 1e3d,
                RotationalStiffnessUnit.KilopoundForceFootPerDegrees => _value * 77682.6,
                RotationalStiffnessUnit.MeganewtonMeterPerDegree => (_value * (180 / 3.1415926535897931)) * 1e6d,
                RotationalStiffnessUnit.MeganewtonMeterPerRadian => (_value) * 1e6d,
                RotationalStiffnessUnit.MeganewtonMillimeterPerDegree => (_value * 180 / 3.1415926535897931 * 0.001) * 1e6d,
                RotationalStiffnessUnit.MeganewtonMillimeterPerRadian => (_value * 0.001) * 1e6d,
                RotationalStiffnessUnit.MicronewtonMeterPerDegree => (_value * (180 / 3.1415926535897931)) * 1e-6d,
                RotationalStiffnessUnit.MicronewtonMillimeterPerDegree => (_value * 180 / 3.1415926535897931 * 0.001) * 1e-6d,
                RotationalStiffnessUnit.MicronewtonMillimeterPerRadian => (_value * 0.001) * 1e-6d,
                RotationalStiffnessUnit.MillinewtonMeterPerDegree => (_value * (180 / 3.1415926535897931)) * 1e-3d,
                RotationalStiffnessUnit.MillinewtonMillimeterPerDegree => (_value * 180 / 3.1415926535897931 * 0.001) * 1e-3d,
                RotationalStiffnessUnit.MillinewtonMillimeterPerRadian => (_value * 0.001) * 1e-3d,
                RotationalStiffnessUnit.NanonewtonMeterPerDegree => (_value * (180 / 3.1415926535897931)) * 1e-9d,
                RotationalStiffnessUnit.NanonewtonMillimeterPerDegree => (_value * 180 / 3.1415926535897931 * 0.001) * 1e-9d,
                RotationalStiffnessUnit.NanonewtonMillimeterPerRadian => (_value * 0.001) * 1e-9d,
                RotationalStiffnessUnit.NewtonMeterPerDegree => _value * (180 / 3.1415926535897931),
                RotationalStiffnessUnit.NewtonMeterPerRadian => _value,
                RotationalStiffnessUnit.NewtonMillimeterPerDegree => _value * 180 / 3.1415926535897931 * 0.001,
                RotationalStiffnessUnit.NewtonMillimeterPerRadian => _value * 0.001,
                RotationalStiffnessUnit.PoundForceFeetPerRadian => _value * 1.3558179483314,
                RotationalStiffnessUnit.PoundForceFootPerDegrees => _value * 77.6826,
                _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
            };
        }

        private double GetValueAs(RotationalStiffnessUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            return unit switch
            {
                RotationalStiffnessUnit.CentinewtonMeterPerDegree => (baseUnitValue / (180 / 3.1415926535897931)) / 1e-2d,
                RotationalStiffnessUnit.CentinewtonMillimeterPerDegree => (baseUnitValue / 180 * 3.1415926535897931 * 1000) / 1e-2d,
                RotationalStiffnessUnit.CentinewtonMillimeterPerRadian => (baseUnitValue * 1000) / 1e-2d,
                RotationalStiffnessUnit.DecanewtonMeterPerDegree => (baseUnitValue / (180 / 3.1415926535897931)) / 1e1d,
                RotationalStiffnessUnit.DecanewtonMillimeterPerDegree => (baseUnitValue / 180 * 3.1415926535897931 * 1000) / 1e1d,
                RotationalStiffnessUnit.DecanewtonMillimeterPerRadian => (baseUnitValue * 1000) / 1e1d,
                RotationalStiffnessUnit.DecinewtonMeterPerDegree => (baseUnitValue / (180 / 3.1415926535897931)) / 1e-1d,
                RotationalStiffnessUnit.DecinewtonMillimeterPerDegree => (baseUnitValue / 180 * 3.1415926535897931 * 1000) / 1e-1d,
                RotationalStiffnessUnit.DecinewtonMillimeterPerRadian => (baseUnitValue * 1000) / 1e-1d,
                RotationalStiffnessUnit.KilonewtonMeterPerDegree => (baseUnitValue / (180 / 3.1415926535897931)) / 1e3d,
                RotationalStiffnessUnit.KilonewtonMeterPerRadian => (baseUnitValue) / 1e3d,
                RotationalStiffnessUnit.KilonewtonMillimeterPerDegree => (baseUnitValue / 180 * 3.1415926535897931 * 1000) / 1e3d,
                RotationalStiffnessUnit.KilonewtonMillimeterPerRadian => (baseUnitValue * 1000) / 1e3d,
                RotationalStiffnessUnit.KilopoundForceFootPerDegrees => baseUnitValue / 77682.6,
                RotationalStiffnessUnit.MeganewtonMeterPerDegree => (baseUnitValue / (180 / 3.1415926535897931)) / 1e6d,
                RotationalStiffnessUnit.MeganewtonMeterPerRadian => (baseUnitValue) / 1e6d,
                RotationalStiffnessUnit.MeganewtonMillimeterPerDegree => (baseUnitValue / 180 * 3.1415926535897931 * 1000) / 1e6d,
                RotationalStiffnessUnit.MeganewtonMillimeterPerRadian => (baseUnitValue * 1000) / 1e6d,
                RotationalStiffnessUnit.MicronewtonMeterPerDegree => (baseUnitValue / (180 / 3.1415926535897931)) / 1e-6d,
                RotationalStiffnessUnit.MicronewtonMillimeterPerDegree => (baseUnitValue / 180 * 3.1415926535897931 * 1000) / 1e-6d,
                RotationalStiffnessUnit.MicronewtonMillimeterPerRadian => (baseUnitValue * 1000) / 1e-6d,
                RotationalStiffnessUnit.MillinewtonMeterPerDegree => (baseUnitValue / (180 / 3.1415926535897931)) / 1e-3d,
                RotationalStiffnessUnit.MillinewtonMillimeterPerDegree => (baseUnitValue / 180 * 3.1415926535897931 * 1000) / 1e-3d,
                RotationalStiffnessUnit.MillinewtonMillimeterPerRadian => (baseUnitValue * 1000) / 1e-3d,
                RotationalStiffnessUnit.NanonewtonMeterPerDegree => (baseUnitValue / (180 / 3.1415926535897931)) / 1e-9d,
                RotationalStiffnessUnit.NanonewtonMillimeterPerDegree => (baseUnitValue / 180 * 3.1415926535897931 * 1000) / 1e-9d,
                RotationalStiffnessUnit.NanonewtonMillimeterPerRadian => (baseUnitValue * 1000) / 1e-9d,
                RotationalStiffnessUnit.NewtonMeterPerDegree => baseUnitValue / (180 / 3.1415926535897931),
                RotationalStiffnessUnit.NewtonMeterPerRadian => baseUnitValue,
                RotationalStiffnessUnit.NewtonMillimeterPerDegree => baseUnitValue / 180 * 3.1415926535897931 * 1000,
                RotationalStiffnessUnit.NewtonMillimeterPerRadian => baseUnitValue * 1000,
                RotationalStiffnessUnit.PoundForceFeetPerRadian => baseUnitValue / 1.3558179483314,
                RotationalStiffnessUnit.PoundForceFootPerDegrees => baseUnitValue / 77.6826,
                _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
            };
        }

        #endregion
    }
}

