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
    ///     Rotational speed (sometimes called speed of revolution) is the number of complete rotations, revolutions, cycles, or turns per time unit. Rotational speed is a cyclic frequency, measured in radians per second or in hertz in the SI System by scientists, or in revolutions per minute (rpm or min-1) or revolutions per second in everyday life. The symbol for rotational speed is ω (the Greek lowercase letter "omega").
    /// </summary>
    public struct  RotationalSpeed
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly RotationalSpeedUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public RotationalSpeedUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        public RotationalSpeed(double value, RotationalSpeedUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of RotationalSpeed, which is Second. All conversions go via this value.
        /// </summary>
        public static RotationalSpeedUnit BaseUnit { get; } = RotationalSpeedUnit.RadianPerSecond;

        /// <summary>
        /// Represents the largest possible value of RotationalSpeed.
        /// </summary>
        public static RotationalSpeed MaxValue { get; } = new RotationalSpeed(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of RotationalSpeed.
        /// </summary>
        public static RotationalSpeed MinValue { get; } = new RotationalSpeed(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static RotationalSpeed Zero { get; } = new RotationalSpeed(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.CentiradianPerSecond"/>
        /// </summary>
        public double CentiradiansPerSecond => As(RotationalSpeedUnit.CentiradianPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.DeciradianPerSecond"/>
        /// </summary>
        public double DeciradiansPerSecond => As(RotationalSpeedUnit.DeciradianPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.DegreePerMinute"/>
        /// </summary>
        public double DegreesPerMinute => As(RotationalSpeedUnit.DegreePerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.DegreePerSecond"/>
        /// </summary>
        public double DegreesPerSecond => As(RotationalSpeedUnit.DegreePerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.MicrodegreePerSecond"/>
        /// </summary>
        public double MicrodegreesPerSecond => As(RotationalSpeedUnit.MicrodegreePerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.MicroradianPerSecond"/>
        /// </summary>
        public double MicroradiansPerSecond => As(RotationalSpeedUnit.MicroradianPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.MillidegreePerSecond"/>
        /// </summary>
        public double MillidegreesPerSecond => As(RotationalSpeedUnit.MillidegreePerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.MilliradianPerSecond"/>
        /// </summary>
        public double MilliradiansPerSecond => As(RotationalSpeedUnit.MilliradianPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.NanodegreePerSecond"/>
        /// </summary>
        public double NanodegreesPerSecond => As(RotationalSpeedUnit.NanodegreePerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.NanoradianPerSecond"/>
        /// </summary>
        public double NanoradiansPerSecond => As(RotationalSpeedUnit.NanoradianPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.RadianPerSecond"/>
        /// </summary>
        public double RadiansPerSecond => As(RotationalSpeedUnit.RadianPerSecond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.RevolutionPerMinute"/>
        /// </summary>
        public double RevolutionsPerMinute => As(RotationalSpeedUnit.RevolutionPerMinute);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="RotationalSpeedUnit.RevolutionPerSecond"/>
        /// </summary>
        public double RevolutionsPerSecond => As(RotationalSpeedUnit.RevolutionPerSecond);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.CentiradianPerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromCentiradiansPerSecond(double centiradianspersecond) => new RotationalSpeed(centiradianspersecond, RotationalSpeedUnit.CentiradianPerSecond);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.DeciradianPerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromDeciradiansPerSecond(double deciradianspersecond) => new RotationalSpeed(deciradianspersecond, RotationalSpeedUnit.DeciradianPerSecond);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.DegreePerMinute"/>.
        /// </summary>
        public static RotationalSpeed FromDegreesPerMinute(double degreesperminute) => new RotationalSpeed(degreesperminute, RotationalSpeedUnit.DegreePerMinute);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.DegreePerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromDegreesPerSecond(double degreespersecond) => new RotationalSpeed(degreespersecond, RotationalSpeedUnit.DegreePerSecond);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.MicrodegreePerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromMicrodegreesPerSecond(double microdegreespersecond) => new RotationalSpeed(microdegreespersecond, RotationalSpeedUnit.MicrodegreePerSecond);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.MicroradianPerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromMicroradiansPerSecond(double microradianspersecond) => new RotationalSpeed(microradianspersecond, RotationalSpeedUnit.MicroradianPerSecond);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.MillidegreePerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromMillidegreesPerSecond(double millidegreespersecond) => new RotationalSpeed(millidegreespersecond, RotationalSpeedUnit.MillidegreePerSecond);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.MilliradianPerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromMilliradiansPerSecond(double milliradianspersecond) => new RotationalSpeed(milliradianspersecond, RotationalSpeedUnit.MilliradianPerSecond);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.NanodegreePerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromNanodegreesPerSecond(double nanodegreespersecond) => new RotationalSpeed(nanodegreespersecond, RotationalSpeedUnit.NanodegreePerSecond);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.NanoradianPerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromNanoradiansPerSecond(double nanoradianspersecond) => new RotationalSpeed(nanoradianspersecond, RotationalSpeedUnit.NanoradianPerSecond);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.RadianPerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromRadiansPerSecond(double radianspersecond) => new RotationalSpeed(radianspersecond, RotationalSpeedUnit.RadianPerSecond);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.RevolutionPerMinute"/>.
        /// </summary>
        public static RotationalSpeed FromRevolutionsPerMinute(double revolutionsperminute) => new RotationalSpeed(revolutionsperminute, RotationalSpeedUnit.RevolutionPerMinute);

        /// <summary>
        ///     Creates a <see cref="RotationalSpeed"/> from <see cref="RotationalSpeedUnit.RevolutionPerSecond"/>.
        /// </summary>
        public static RotationalSpeed FromRevolutionsPerSecond(double revolutionspersecond) => new RotationalSpeed(revolutionspersecond, RotationalSpeedUnit.RevolutionPerSecond);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="RotationalSpeedUnit" /> to <see cref="RotationalSpeed" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>RotationalSpeed unit value.</returns>
        public static RotationalSpeed From(double value, RotationalSpeedUnit fromUnit)
        {
            return new RotationalSpeed(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(RotationalSpeedUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this RotationalSpeed to another RotationalSpeed with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A RotationalSpeed with the specified unit.</returns>
                public RotationalSpeed ToUnit(RotationalSpeedUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new RotationalSpeed(convertedValue, unit);
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
                        RotationalSpeedUnit.CentiradianPerSecond => (_value) * 1e-2d,
                        RotationalSpeedUnit.DeciradianPerSecond => (_value) * 1e-1d,
                        RotationalSpeedUnit.DegreePerMinute => (3.1415926535897931 / (180 * 60)) * _value,
                        RotationalSpeedUnit.DegreePerSecond => (3.1415926535897931 / 180) * _value,
                        RotationalSpeedUnit.MicrodegreePerSecond => ((3.1415926535897931 / 180) * _value) * 1e-6d,
                        RotationalSpeedUnit.MicroradianPerSecond => (_value) * 1e-6d,
                        RotationalSpeedUnit.MillidegreePerSecond => ((3.1415926535897931 / 180) * _value) * 1e-3d,
                        RotationalSpeedUnit.MilliradianPerSecond => (_value) * 1e-3d,
                        RotationalSpeedUnit.NanodegreePerSecond => ((3.1415926535897931 / 180) * _value) * 1e-9d,
                        RotationalSpeedUnit.NanoradianPerSecond => (_value) * 1e-9d,
                        RotationalSpeedUnit.RadianPerSecond => _value,
                        RotationalSpeedUnit.RevolutionPerMinute => (_value * 2 * 3.1415926535897931) / 60,
                        RotationalSpeedUnit.RevolutionPerSecond => _value * 2 * 3.1415926535897931,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(RotationalSpeedUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        RotationalSpeedUnit.CentiradianPerSecond => (baseUnitValue) / 1e-2d,
                        RotationalSpeedUnit.DeciradianPerSecond => (baseUnitValue) / 1e-1d,
                        RotationalSpeedUnit.DegreePerMinute => (180 * 60 / 3.1415926535897931) * baseUnitValue,
                        RotationalSpeedUnit.DegreePerSecond => (180 / 3.1415926535897931) * baseUnitValue,
                        RotationalSpeedUnit.MicrodegreePerSecond => ((180 / 3.1415926535897931) * baseUnitValue) / 1e-6d,
                        RotationalSpeedUnit.MicroradianPerSecond => (baseUnitValue) / 1e-6d,
                        RotationalSpeedUnit.MillidegreePerSecond => ((180 / 3.1415926535897931) * baseUnitValue) / 1e-3d,
                        RotationalSpeedUnit.MilliradianPerSecond => (baseUnitValue) / 1e-3d,
                        RotationalSpeedUnit.NanodegreePerSecond => ((180 / 3.1415926535897931) * baseUnitValue) / 1e-9d,
                        RotationalSpeedUnit.NanoradianPerSecond => (baseUnitValue) / 1e-9d,
                        RotationalSpeedUnit.RadianPerSecond => baseUnitValue,
                        RotationalSpeedUnit.RevolutionPerMinute => (baseUnitValue / (2 * 3.1415926535897931)) * 60,
                        RotationalSpeedUnit.RevolutionPerSecond => baseUnitValue / (2 * 3.1415926535897931),
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

