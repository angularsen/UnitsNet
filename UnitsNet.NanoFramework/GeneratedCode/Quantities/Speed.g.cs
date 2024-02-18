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
    ///     In everyday use and in kinematics, the speed of an object is the magnitude of its velocity (the rate of change of its position); it is thus a scalar quantity.[1] The average speed of an object in an interval of time is the distance travelled by the object divided by the duration of the interval;[2] the instantaneous speed is the limit of the average speed as the duration of the time interval approaches zero.
    /// </summary>
    public struct  Speed
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly SpeedUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public SpeedUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public Speed(double value, SpeedUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static SpeedUnit BaseUnit { get; } = SpeedUnit.MeterPerSecond;

        /// <summary>
        /// Represents the largest possible value of Speed.
        /// </summary>
        public static Speed MaxValue { get; } = new Speed(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Speed.
        /// </summary>
        public static Speed MinValue { get; } = new Speed(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static Speed Zero { get; } = new Speed(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.CentimeterPerHour"/>
        /// </summary>
        public double CentimetersPerHour => As(SpeedUnit.CentimeterPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.CentimeterPerMinute"/>
        /// </summary>
        public double CentimetersPerMinute => As(SpeedUnit.CentimeterPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.CentimeterPerSecond"/>
        /// </summary>
        public double CentimetersPerSecond => As(SpeedUnit.CentimeterPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.DecimeterPerMinute"/>
        /// </summary>
        public double DecimetersPerMinute => As(SpeedUnit.DecimeterPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.DecimeterPerSecond"/>
        /// </summary>
        public double DecimetersPerSecond => As(SpeedUnit.DecimeterPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.FootPerHour"/>
        /// </summary>
        public double FeetPerHour => As(SpeedUnit.FootPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.FootPerMinute"/>
        /// </summary>
        public double FeetPerMinute => As(SpeedUnit.FootPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.FootPerSecond"/>
        /// </summary>
        public double FeetPerSecond => As(SpeedUnit.FootPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.InchPerHour"/>
        /// </summary>
        public double InchesPerHour => As(SpeedUnit.InchPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.InchPerMinute"/>
        /// </summary>
        public double InchesPerMinute => As(SpeedUnit.InchPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.InchPerSecond"/>
        /// </summary>
        public double InchesPerSecond => As(SpeedUnit.InchPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.KilometerPerHour"/>
        /// </summary>
        public double KilometersPerHour => As(SpeedUnit.KilometerPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.KilometerPerMinute"/>
        /// </summary>
        public double KilometersPerMinute => As(SpeedUnit.KilometerPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.KilometerPerSecond"/>
        /// </summary>
        public double KilometersPerSecond => As(SpeedUnit.KilometerPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.Knot"/>
        /// </summary>
        public double Knots => As(SpeedUnit.Knot);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.Mach"/>
        /// </summary>
        public double Mach => As(SpeedUnit.Mach);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.MeterPerHour"/>
        /// </summary>
        public double MetersPerHour => As(SpeedUnit.MeterPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.MeterPerMinute"/>
        /// </summary>
        public double MetersPerMinute => As(SpeedUnit.MeterPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.MeterPerSecond"/>
        /// </summary>
        public double MetersPerSecond => As(SpeedUnit.MeterPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.MicrometerPerMinute"/>
        /// </summary>
        public double MicrometersPerMinute => As(SpeedUnit.MicrometerPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.MicrometerPerSecond"/>
        /// </summary>
        public double MicrometersPerSecond => As(SpeedUnit.MicrometerPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.MilePerHour"/>
        /// </summary>
        public double MilesPerHour => As(SpeedUnit.MilePerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.MillimeterPerHour"/>
        /// </summary>
        public double MillimetersPerHour => As(SpeedUnit.MillimeterPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.MillimeterPerMinute"/>
        /// </summary>
        public double MillimetersPerMinute => As(SpeedUnit.MillimeterPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.MillimeterPerSecond"/>
        /// </summary>
        public double MillimetersPerSecond => As(SpeedUnit.MillimeterPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.NanometerPerMinute"/>
        /// </summary>
        public double NanometersPerMinute => As(SpeedUnit.NanometerPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.NanometerPerSecond"/>
        /// </summary>
        public double NanometersPerSecond => As(SpeedUnit.NanometerPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.UsSurveyFootPerHour"/>
        /// </summary>
        public double UsSurveyFeetPerHour => As(SpeedUnit.UsSurveyFootPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.UsSurveyFootPerMinute"/>
        /// </summary>
        public double UsSurveyFeetPerMinute => As(SpeedUnit.UsSurveyFootPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.UsSurveyFootPerSecond"/>
        /// </summary>
        public double UsSurveyFeetPerSecond => As(SpeedUnit.UsSurveyFootPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.YardPerHour"/>
        /// </summary>
        public double YardsPerHour => As(SpeedUnit.YardPerHour);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.YardPerMinute"/>
        /// </summary>
        public double YardsPerMinute => As(SpeedUnit.YardPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="SpeedUnit.YardPerSecond"/>
        /// </summary>
        public double YardsPerSecond => As(SpeedUnit.YardPerSecond);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.CentimeterPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromCentimetersPerHour(double centimetersperhour) => new Speed(centimetersperhour, SpeedUnit.CentimeterPerHour);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.CentimeterPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromCentimetersPerMinute(double centimetersperminute) => new Speed(centimetersperminute, SpeedUnit.CentimeterPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.CentimeterPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromCentimetersPerSecond(double centimeterspersecond) => new Speed(centimeterspersecond, SpeedUnit.CentimeterPerSecond);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.DecimeterPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromDecimetersPerMinute(double decimetersperminute) => new Speed(decimetersperminute, SpeedUnit.DecimeterPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.DecimeterPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromDecimetersPerSecond(double decimeterspersecond) => new Speed(decimeterspersecond, SpeedUnit.DecimeterPerSecond);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.FootPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromFeetPerHour(double feetperhour) => new Speed(feetperhour, SpeedUnit.FootPerHour);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.FootPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromFeetPerMinute(double feetperminute) => new Speed(feetperminute, SpeedUnit.FootPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.FootPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromFeetPerSecond(double feetpersecond) => new Speed(feetpersecond, SpeedUnit.FootPerSecond);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.InchPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromInchesPerHour(double inchesperhour) => new Speed(inchesperhour, SpeedUnit.InchPerHour);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.InchPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromInchesPerMinute(double inchesperminute) => new Speed(inchesperminute, SpeedUnit.InchPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.InchPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromInchesPerSecond(double inchespersecond) => new Speed(inchespersecond, SpeedUnit.InchPerSecond);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.KilometerPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromKilometersPerHour(double kilometersperhour) => new Speed(kilometersperhour, SpeedUnit.KilometerPerHour);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.KilometerPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromKilometersPerMinute(double kilometersperminute) => new Speed(kilometersperminute, SpeedUnit.KilometerPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.KilometerPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromKilometersPerSecond(double kilometerspersecond) => new Speed(kilometerspersecond, SpeedUnit.KilometerPerSecond);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.Knot"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromKnots(double knots) => new Speed(knots, SpeedUnit.Knot);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.Mach"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromMach(double mach) => new Speed(mach, SpeedUnit.Mach);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.MeterPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromMetersPerHour(double metersperhour) => new Speed(metersperhour, SpeedUnit.MeterPerHour);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.MeterPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromMetersPerMinute(double metersperminute) => new Speed(metersperminute, SpeedUnit.MeterPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.MeterPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromMetersPerSecond(double meterspersecond) => new Speed(meterspersecond, SpeedUnit.MeterPerSecond);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.MicrometerPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromMicrometersPerMinute(double micrometersperminute) => new Speed(micrometersperminute, SpeedUnit.MicrometerPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.MicrometerPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromMicrometersPerSecond(double micrometerspersecond) => new Speed(micrometerspersecond, SpeedUnit.MicrometerPerSecond);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.MilePerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromMilesPerHour(double milesperhour) => new Speed(milesperhour, SpeedUnit.MilePerHour);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.MillimeterPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromMillimetersPerHour(double millimetersperhour) => new Speed(millimetersperhour, SpeedUnit.MillimeterPerHour);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.MillimeterPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromMillimetersPerMinute(double millimetersperminute) => new Speed(millimetersperminute, SpeedUnit.MillimeterPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.MillimeterPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromMillimetersPerSecond(double millimeterspersecond) => new Speed(millimeterspersecond, SpeedUnit.MillimeterPerSecond);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.NanometerPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromNanometersPerMinute(double nanometersperminute) => new Speed(nanometersperminute, SpeedUnit.NanometerPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.NanometerPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromNanometersPerSecond(double nanometerspersecond) => new Speed(nanometerspersecond, SpeedUnit.NanometerPerSecond);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.UsSurveyFootPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromUsSurveyFeetPerHour(double ussurveyfeetperhour) => new Speed(ussurveyfeetperhour, SpeedUnit.UsSurveyFootPerHour);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.UsSurveyFootPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromUsSurveyFeetPerMinute(double ussurveyfeetperminute) => new Speed(ussurveyfeetperminute, SpeedUnit.UsSurveyFootPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.UsSurveyFootPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromUsSurveyFeetPerSecond(double ussurveyfeetpersecond) => new Speed(ussurveyfeetpersecond, SpeedUnit.UsSurveyFootPerSecond);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.YardPerHour"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromYardsPerHour(double yardsperhour) => new Speed(yardsperhour, SpeedUnit.YardPerHour);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.YardPerMinute"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromYardsPerMinute(double yardsperminute) => new Speed(yardsperminute, SpeedUnit.YardPerMinute);

        /// <summary>
        ///     Creates a <see cref="Speed"/> from <see cref="SpeedUnit.YardPerSecond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Speed FromYardsPerSecond(double yardspersecond) => new Speed(yardspersecond, SpeedUnit.YardPerSecond);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="SpeedUnit" /> to <see cref="Speed" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Speed unit value.</returns>
        public static Speed From(double value, SpeedUnit fromUnit)
        {
            return new Speed(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(SpeedUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A Duration with the specified unit.</returns>
                public Speed ToUnit(SpeedUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new Speed(convertedValue, unit);
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
                        SpeedUnit.CentimeterPerHour => (_value / 3600) * 1e-2d,
                        SpeedUnit.CentimeterPerMinute => (_value / 60) * 1e-2d,
                        SpeedUnit.CentimeterPerSecond => (_value) * 1e-2d,
                        SpeedUnit.DecimeterPerMinute => (_value / 60) * 1e-1d,
                        SpeedUnit.DecimeterPerSecond => (_value) * 1e-1d,
                        SpeedUnit.FootPerHour => _value * 0.3048 / 3600,
                        SpeedUnit.FootPerMinute => _value * 0.3048 / 60,
                        SpeedUnit.FootPerSecond => _value * 0.3048,
                        SpeedUnit.InchPerHour => (_value / 3600) * 2.54e-2,
                        SpeedUnit.InchPerMinute => (_value / 60) * 2.54e-2,
                        SpeedUnit.InchPerSecond => _value * 2.54e-2,
                        SpeedUnit.KilometerPerHour => (_value / 3600) * 1e3d,
                        SpeedUnit.KilometerPerMinute => (_value / 60) * 1e3d,
                        SpeedUnit.KilometerPerSecond => (_value) * 1e3d,
                        SpeedUnit.Knot => _value * (1852.0 / 3600.0),
                        SpeedUnit.Mach => _value * 340.29,
                        SpeedUnit.MeterPerHour => _value / 3600,
                        SpeedUnit.MeterPerMinute => _value / 60,
                        SpeedUnit.MeterPerSecond => _value,
                        SpeedUnit.MicrometerPerMinute => (_value / 60) * 1e-6d,
                        SpeedUnit.MicrometerPerSecond => (_value) * 1e-6d,
                        SpeedUnit.MilePerHour => _value * 0.44704,
                        SpeedUnit.MillimeterPerHour => (_value / 3600) * 1e-3d,
                        SpeedUnit.MillimeterPerMinute => (_value / 60) * 1e-3d,
                        SpeedUnit.MillimeterPerSecond => (_value) * 1e-3d,
                        SpeedUnit.NanometerPerMinute => (_value / 60) * 1e-9d,
                        SpeedUnit.NanometerPerSecond => (_value) * 1e-9d,
                        SpeedUnit.UsSurveyFootPerHour => (_value * 1200 / 3937) / 3600,
                        SpeedUnit.UsSurveyFootPerMinute => (_value * 1200 / 3937) / 60,
                        SpeedUnit.UsSurveyFootPerSecond => _value * 1200 / 3937,
                        SpeedUnit.YardPerHour => _value * 0.9144 / 3600,
                        SpeedUnit.YardPerMinute => _value * 0.9144 / 60,
                        SpeedUnit.YardPerSecond => _value * 0.9144,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(SpeedUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        SpeedUnit.CentimeterPerHour => (baseUnitValue * 3600) / 1e-2d,
                        SpeedUnit.CentimeterPerMinute => (baseUnitValue * 60) / 1e-2d,
                        SpeedUnit.CentimeterPerSecond => (baseUnitValue) / 1e-2d,
                        SpeedUnit.DecimeterPerMinute => (baseUnitValue * 60) / 1e-1d,
                        SpeedUnit.DecimeterPerSecond => (baseUnitValue) / 1e-1d,
                        SpeedUnit.FootPerHour => baseUnitValue / 0.3048 * 3600,
                        SpeedUnit.FootPerMinute => baseUnitValue / 0.3048 * 60,
                        SpeedUnit.FootPerSecond => baseUnitValue / 0.3048,
                        SpeedUnit.InchPerHour => (baseUnitValue / 2.54e-2) * 3600,
                        SpeedUnit.InchPerMinute => (baseUnitValue / 2.54e-2) * 60,
                        SpeedUnit.InchPerSecond => baseUnitValue / 2.54e-2,
                        SpeedUnit.KilometerPerHour => (baseUnitValue * 3600) / 1e3d,
                        SpeedUnit.KilometerPerMinute => (baseUnitValue * 60) / 1e3d,
                        SpeedUnit.KilometerPerSecond => (baseUnitValue) / 1e3d,
                        SpeedUnit.Knot => baseUnitValue / (1852.0 / 3600.0),
                        SpeedUnit.Mach => baseUnitValue / 340.29,
                        SpeedUnit.MeterPerHour => baseUnitValue * 3600,
                        SpeedUnit.MeterPerMinute => baseUnitValue * 60,
                        SpeedUnit.MeterPerSecond => baseUnitValue,
                        SpeedUnit.MicrometerPerMinute => (baseUnitValue * 60) / 1e-6d,
                        SpeedUnit.MicrometerPerSecond => (baseUnitValue) / 1e-6d,
                        SpeedUnit.MilePerHour => baseUnitValue / 0.44704,
                        SpeedUnit.MillimeterPerHour => (baseUnitValue * 3600) / 1e-3d,
                        SpeedUnit.MillimeterPerMinute => (baseUnitValue * 60) / 1e-3d,
                        SpeedUnit.MillimeterPerSecond => (baseUnitValue) / 1e-3d,
                        SpeedUnit.NanometerPerMinute => (baseUnitValue * 60) / 1e-9d,
                        SpeedUnit.NanometerPerSecond => (baseUnitValue) / 1e-9d,
                        SpeedUnit.UsSurveyFootPerHour => (baseUnitValue * 3937 / 1200) * 3600,
                        SpeedUnit.UsSurveyFootPerMinute => (baseUnitValue * 3937 / 1200) * 60,
                        SpeedUnit.UsSurveyFootPerSecond => baseUnitValue * 3937 / 1200,
                        SpeedUnit.YardPerHour => baseUnitValue / 0.9144 * 3600,
                        SpeedUnit.YardPerMinute => baseUnitValue / 0.9144 * 60,
                        SpeedUnit.YardPerSecond => baseUnitValue / 0.9144,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

