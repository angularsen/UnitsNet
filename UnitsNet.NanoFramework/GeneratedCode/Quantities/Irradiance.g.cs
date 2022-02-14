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
    ///     Irradiance is the intensity of ultraviolet (UV) or visible light incident on a surface.
    /// </summary>
    public struct  Irradiance
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly IrradianceUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public IrradianceUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public Irradiance(double value, IrradianceUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static IrradianceUnit BaseUnit { get; } = IrradianceUnit.WattPerSquareMeter;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static Irradiance MaxValue { get; } = new Irradiance(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static Irradiance MinValue { get; } = new Irradiance(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static Irradiance Zero { get; } = new Irradiance(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.KilowattPerSquareCentimeter"/>
        /// </summary>
        public double KilowattsPerSquareCentimeter => As(IrradianceUnit.KilowattPerSquareCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.KilowattPerSquareMeter"/>
        /// </summary>
        public double KilowattsPerSquareMeter => As(IrradianceUnit.KilowattPerSquareMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.MegawattPerSquareCentimeter"/>
        /// </summary>
        public double MegawattsPerSquareCentimeter => As(IrradianceUnit.MegawattPerSquareCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.MegawattPerSquareMeter"/>
        /// </summary>
        public double MegawattsPerSquareMeter => As(IrradianceUnit.MegawattPerSquareMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.MicrowattPerSquareCentimeter"/>
        /// </summary>
        public double MicrowattsPerSquareCentimeter => As(IrradianceUnit.MicrowattPerSquareCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.MicrowattPerSquareMeter"/>
        /// </summary>
        public double MicrowattsPerSquareMeter => As(IrradianceUnit.MicrowattPerSquareMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.MilliwattPerSquareCentimeter"/>
        /// </summary>
        public double MilliwattsPerSquareCentimeter => As(IrradianceUnit.MilliwattPerSquareCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.MilliwattPerSquareMeter"/>
        /// </summary>
        public double MilliwattsPerSquareMeter => As(IrradianceUnit.MilliwattPerSquareMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.NanowattPerSquareCentimeter"/>
        /// </summary>
        public double NanowattsPerSquareCentimeter => As(IrradianceUnit.NanowattPerSquareCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.NanowattPerSquareMeter"/>
        /// </summary>
        public double NanowattsPerSquareMeter => As(IrradianceUnit.NanowattPerSquareMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.PicowattPerSquareCentimeter"/>
        /// </summary>
        public double PicowattsPerSquareCentimeter => As(IrradianceUnit.PicowattPerSquareCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.PicowattPerSquareMeter"/>
        /// </summary>
        public double PicowattsPerSquareMeter => As(IrradianceUnit.PicowattPerSquareMeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.WattPerSquareCentimeter"/>
        /// </summary>
        public double WattsPerSquareCentimeter => As(IrradianceUnit.WattPerSquareCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="IrradianceUnit.WattPerSquareMeter"/>
        /// </summary>
        public double WattsPerSquareMeter => As(IrradianceUnit.WattPerSquareMeter);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.KilowattPerSquareCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromKilowattsPerSquareCentimeter(double kilowattspersquarecentimeter) => new Irradiance(kilowattspersquarecentimeter, IrradianceUnit.KilowattPerSquareCentimeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.KilowattPerSquareMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromKilowattsPerSquareMeter(double kilowattspersquaremeter) => new Irradiance(kilowattspersquaremeter, IrradianceUnit.KilowattPerSquareMeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.MegawattPerSquareCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromMegawattsPerSquareCentimeter(double megawattspersquarecentimeter) => new Irradiance(megawattspersquarecentimeter, IrradianceUnit.MegawattPerSquareCentimeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.MegawattPerSquareMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromMegawattsPerSquareMeter(double megawattspersquaremeter) => new Irradiance(megawattspersquaremeter, IrradianceUnit.MegawattPerSquareMeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.MicrowattPerSquareCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromMicrowattsPerSquareCentimeter(double microwattspersquarecentimeter) => new Irradiance(microwattspersquarecentimeter, IrradianceUnit.MicrowattPerSquareCentimeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.MicrowattPerSquareMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromMicrowattsPerSquareMeter(double microwattspersquaremeter) => new Irradiance(microwattspersquaremeter, IrradianceUnit.MicrowattPerSquareMeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.MilliwattPerSquareCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromMilliwattsPerSquareCentimeter(double milliwattspersquarecentimeter) => new Irradiance(milliwattspersquarecentimeter, IrradianceUnit.MilliwattPerSquareCentimeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.MilliwattPerSquareMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromMilliwattsPerSquareMeter(double milliwattspersquaremeter) => new Irradiance(milliwattspersquaremeter, IrradianceUnit.MilliwattPerSquareMeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.NanowattPerSquareCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromNanowattsPerSquareCentimeter(double nanowattspersquarecentimeter) => new Irradiance(nanowattspersquarecentimeter, IrradianceUnit.NanowattPerSquareCentimeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.NanowattPerSquareMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromNanowattsPerSquareMeter(double nanowattspersquaremeter) => new Irradiance(nanowattspersquaremeter, IrradianceUnit.NanowattPerSquareMeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.PicowattPerSquareCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromPicowattsPerSquareCentimeter(double picowattspersquarecentimeter) => new Irradiance(picowattspersquarecentimeter, IrradianceUnit.PicowattPerSquareCentimeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.PicowattPerSquareMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromPicowattsPerSquareMeter(double picowattspersquaremeter) => new Irradiance(picowattspersquaremeter, IrradianceUnit.PicowattPerSquareMeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.WattPerSquareCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromWattsPerSquareCentimeter(double wattspersquarecentimeter) => new Irradiance(wattspersquarecentimeter, IrradianceUnit.WattPerSquareCentimeter);

        /// <summary>
        ///     Creates a <see cref="Irradiance"/> from <see cref="IrradianceUnit.WattPerSquareMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Irradiance FromWattsPerSquareMeter(double wattspersquaremeter) => new Irradiance(wattspersquaremeter, IrradianceUnit.WattPerSquareMeter);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="IrradianceUnit" /> to <see cref="Irradiance" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Irradiance unit value.</returns>
        public static Irradiance From(double value, IrradianceUnit fromUnit)
        {
            return new Irradiance(value, fromUnit);
        }

        #endregion

        #region Conversion Methods

        /// <summary>
        ///     Convert to the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>Value converted to the specified unit.</returns>
        public double As(IrradianceUnit unit) => GetValueAs(unit);

        /// <summary>
        ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
        /// </summary>
        /// <returns>A Duration with the specified unit.</returns>
        public Irradiance ToUnit(IrradianceUnit unit)
        {
            var convertedValue = GetValueAs(unit);
            return new Irradiance(convertedValue, unit);
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
                IrradianceUnit.KilowattPerSquareCentimeter => (_value * 10000) * 1e3d,
                IrradianceUnit.KilowattPerSquareMeter => (_value) * 1e3d,
                IrradianceUnit.MegawattPerSquareCentimeter => (_value * 10000) * 1e6d,
                IrradianceUnit.MegawattPerSquareMeter => (_value) * 1e6d,
                IrradianceUnit.MicrowattPerSquareCentimeter => (_value * 10000) * 1e-6d,
                IrradianceUnit.MicrowattPerSquareMeter => (_value) * 1e-6d,
                IrradianceUnit.MilliwattPerSquareCentimeter => (_value * 10000) * 1e-3d,
                IrradianceUnit.MilliwattPerSquareMeter => (_value) * 1e-3d,
                IrradianceUnit.NanowattPerSquareCentimeter => (_value * 10000) * 1e-9d,
                IrradianceUnit.NanowattPerSquareMeter => (_value) * 1e-9d,
                IrradianceUnit.PicowattPerSquareCentimeter => (_value * 10000) * 1e-12d,
                IrradianceUnit.PicowattPerSquareMeter => (_value) * 1e-12d,
                IrradianceUnit.WattPerSquareCentimeter => _value * 10000,
                IrradianceUnit.WattPerSquareMeter => _value,
                _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
            };
        }

        private double GetValueAs(IrradianceUnit unit)
        {
            if (Unit == unit)
                return _value;

            var baseUnitValue = GetValueInBaseUnit();

            return unit switch
            {
                IrradianceUnit.KilowattPerSquareCentimeter => (baseUnitValue * 0.0001) / 1e3d,
                IrradianceUnit.KilowattPerSquareMeter => (baseUnitValue) / 1e3d,
                IrradianceUnit.MegawattPerSquareCentimeter => (baseUnitValue * 0.0001) / 1e6d,
                IrradianceUnit.MegawattPerSquareMeter => (baseUnitValue) / 1e6d,
                IrradianceUnit.MicrowattPerSquareCentimeter => (baseUnitValue * 0.0001) / 1e-6d,
                IrradianceUnit.MicrowattPerSquareMeter => (baseUnitValue) / 1e-6d,
                IrradianceUnit.MilliwattPerSquareCentimeter => (baseUnitValue * 0.0001) / 1e-3d,
                IrradianceUnit.MilliwattPerSquareMeter => (baseUnitValue) / 1e-3d,
                IrradianceUnit.NanowattPerSquareCentimeter => (baseUnitValue * 0.0001) / 1e-9d,
                IrradianceUnit.NanowattPerSquareMeter => (baseUnitValue) / 1e-9d,
                IrradianceUnit.PicowattPerSquareCentimeter => (baseUnitValue * 0.0001) / 1e-12d,
                IrradianceUnit.PicowattPerSquareMeter => (baseUnitValue) / 1e-12d,
                IrradianceUnit.WattPerSquareCentimeter => baseUnitValue * 0.0001,
                IrradianceUnit.WattPerSquareMeter => baseUnitValue,
                _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
            };
        }

        #endregion
    }
}

