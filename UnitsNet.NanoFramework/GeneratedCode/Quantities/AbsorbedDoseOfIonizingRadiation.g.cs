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
    ///     Absorbed dose is a dose quantity which is the measure of the energy deposited in matter by ionizing radiation per unit mass.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Absorbed_dose
    /// </remarks>
    public struct  AbsorbedDoseOfIonizingRadiation
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly AbsorbedDoseOfIonizingRadiationUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public AbsorbedDoseOfIonizingRadiationUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public AbsorbedDoseOfIonizingRadiation(double value, AbsorbedDoseOfIonizingRadiationUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of AbsorbedDoseOfIonizingRadiation, which is Second. All conversions go via this value.
        /// </summary>
        public static AbsorbedDoseOfIonizingRadiationUnit BaseUnit { get; } = AbsorbedDoseOfIonizingRadiationUnit.Gray;

        /// <summary>
        /// Represents the largest possible value of AbsorbedDoseOfIonizingRadiation.
        /// </summary>
        public static AbsorbedDoseOfIonizingRadiation MaxValue { get; } = new AbsorbedDoseOfIonizingRadiation(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of AbsorbedDoseOfIonizingRadiation.
        /// </summary>
        public static AbsorbedDoseOfIonizingRadiation MinValue { get; } = new AbsorbedDoseOfIonizingRadiation(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static AbsorbedDoseOfIonizingRadiation Zero { get; } = new AbsorbedDoseOfIonizingRadiation(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Centigray"/>
        /// </summary>
        public double Centigrays => As(AbsorbedDoseOfIonizingRadiationUnit.Centigray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Femtogray"/>
        /// </summary>
        public double Femtograys => As(AbsorbedDoseOfIonizingRadiationUnit.Femtogray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Gigagray"/>
        /// </summary>
        public double Gigagrays => As(AbsorbedDoseOfIonizingRadiationUnit.Gigagray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Gray"/>
        /// </summary>
        public double Grays => As(AbsorbedDoseOfIonizingRadiationUnit.Gray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Kilogray"/>
        /// </summary>
        public double Kilograys => As(AbsorbedDoseOfIonizingRadiationUnit.Kilogray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Kilorad"/>
        /// </summary>
        public double Kilorads => As(AbsorbedDoseOfIonizingRadiationUnit.Kilorad);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Megagray"/>
        /// </summary>
        public double Megagrays => As(AbsorbedDoseOfIonizingRadiationUnit.Megagray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Megarad"/>
        /// </summary>
        public double Megarads => As(AbsorbedDoseOfIonizingRadiationUnit.Megarad);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Microgray"/>
        /// </summary>
        public double Micrograys => As(AbsorbedDoseOfIonizingRadiationUnit.Microgray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Milligray"/>
        /// </summary>
        public double Milligrays => As(AbsorbedDoseOfIonizingRadiationUnit.Milligray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Millirad"/>
        /// </summary>
        public double Millirads => As(AbsorbedDoseOfIonizingRadiationUnit.Millirad);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Nanogray"/>
        /// </summary>
        public double Nanograys => As(AbsorbedDoseOfIonizingRadiationUnit.Nanogray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Petagray"/>
        /// </summary>
        public double Petagrays => As(AbsorbedDoseOfIonizingRadiationUnit.Petagray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Picogray"/>
        /// </summary>
        public double Picograys => As(AbsorbedDoseOfIonizingRadiationUnit.Picogray);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Rad"/>
        /// </summary>
        public double Rads => As(AbsorbedDoseOfIonizingRadiationUnit.Rad);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="AbsorbedDoseOfIonizingRadiationUnit.Teragray"/>
        /// </summary>
        public double Teragrays => As(AbsorbedDoseOfIonizingRadiationUnit.Teragray);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Centigray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromCentigrays(double centigrays) => new AbsorbedDoseOfIonizingRadiation(centigrays, AbsorbedDoseOfIonizingRadiationUnit.Centigray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Femtogray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromFemtograys(double femtograys) => new AbsorbedDoseOfIonizingRadiation(femtograys, AbsorbedDoseOfIonizingRadiationUnit.Femtogray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Gigagray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromGigagrays(double gigagrays) => new AbsorbedDoseOfIonizingRadiation(gigagrays, AbsorbedDoseOfIonizingRadiationUnit.Gigagray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Gray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromGrays(double grays) => new AbsorbedDoseOfIonizingRadiation(grays, AbsorbedDoseOfIonizingRadiationUnit.Gray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Kilogray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromKilograys(double kilograys) => new AbsorbedDoseOfIonizingRadiation(kilograys, AbsorbedDoseOfIonizingRadiationUnit.Kilogray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Kilorad"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromKilorads(double kilorads) => new AbsorbedDoseOfIonizingRadiation(kilorads, AbsorbedDoseOfIonizingRadiationUnit.Kilorad);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Megagray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromMegagrays(double megagrays) => new AbsorbedDoseOfIonizingRadiation(megagrays, AbsorbedDoseOfIonizingRadiationUnit.Megagray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Megarad"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromMegarads(double megarads) => new AbsorbedDoseOfIonizingRadiation(megarads, AbsorbedDoseOfIonizingRadiationUnit.Megarad);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Microgray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromMicrograys(double micrograys) => new AbsorbedDoseOfIonizingRadiation(micrograys, AbsorbedDoseOfIonizingRadiationUnit.Microgray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Milligray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromMilligrays(double milligrays) => new AbsorbedDoseOfIonizingRadiation(milligrays, AbsorbedDoseOfIonizingRadiationUnit.Milligray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Millirad"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromMillirads(double millirads) => new AbsorbedDoseOfIonizingRadiation(millirads, AbsorbedDoseOfIonizingRadiationUnit.Millirad);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Nanogray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromNanograys(double nanograys) => new AbsorbedDoseOfIonizingRadiation(nanograys, AbsorbedDoseOfIonizingRadiationUnit.Nanogray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Petagray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromPetagrays(double petagrays) => new AbsorbedDoseOfIonizingRadiation(petagrays, AbsorbedDoseOfIonizingRadiationUnit.Petagray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Picogray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromPicograys(double picograys) => new AbsorbedDoseOfIonizingRadiation(picograys, AbsorbedDoseOfIonizingRadiationUnit.Picogray);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Rad"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromRads(double rads) => new AbsorbedDoseOfIonizingRadiation(rads, AbsorbedDoseOfIonizingRadiationUnit.Rad);

        /// <summary>
        ///     Creates a <see cref="AbsorbedDoseOfIonizingRadiation"/> from <see cref="AbsorbedDoseOfIonizingRadiationUnit.Teragray"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static AbsorbedDoseOfIonizingRadiation FromTeragrays(double teragrays) => new AbsorbedDoseOfIonizingRadiation(teragrays, AbsorbedDoseOfIonizingRadiationUnit.Teragray);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="AbsorbedDoseOfIonizingRadiationUnit" /> to <see cref="AbsorbedDoseOfIonizingRadiation" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>AbsorbedDoseOfIonizingRadiation unit value.</returns>
        public static AbsorbedDoseOfIonizingRadiation From(double value, AbsorbedDoseOfIonizingRadiationUnit fromUnit)
        {
            return new AbsorbedDoseOfIonizingRadiation(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(AbsorbedDoseOfIonizingRadiationUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this AbsorbedDoseOfIonizingRadiation to another AbsorbedDoseOfIonizingRadiation with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A AbsorbedDoseOfIonizingRadiation with the specified unit.</returns>
                public AbsorbedDoseOfIonizingRadiation ToUnit(AbsorbedDoseOfIonizingRadiationUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new AbsorbedDoseOfIonizingRadiation(convertedValue, unit);
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
                        AbsorbedDoseOfIonizingRadiationUnit.Centigray => (_value) * 1e-2d,
                        AbsorbedDoseOfIonizingRadiationUnit.Femtogray => (_value) * 1e-15d,
                        AbsorbedDoseOfIonizingRadiationUnit.Gigagray => (_value) * 1e9d,
                        AbsorbedDoseOfIonizingRadiationUnit.Gray => _value,
                        AbsorbedDoseOfIonizingRadiationUnit.Kilogray => (_value) * 1e3d,
                        AbsorbedDoseOfIonizingRadiationUnit.Kilorad => (_value / 100) * 1e3d,
                        AbsorbedDoseOfIonizingRadiationUnit.Megagray => (_value) * 1e6d,
                        AbsorbedDoseOfIonizingRadiationUnit.Megarad => (_value / 100) * 1e6d,
                        AbsorbedDoseOfIonizingRadiationUnit.Microgray => (_value) * 1e-6d,
                        AbsorbedDoseOfIonizingRadiationUnit.Milligray => (_value) * 1e-3d,
                        AbsorbedDoseOfIonizingRadiationUnit.Millirad => (_value / 100) * 1e-3d,
                        AbsorbedDoseOfIonizingRadiationUnit.Nanogray => (_value) * 1e-9d,
                        AbsorbedDoseOfIonizingRadiationUnit.Petagray => (_value) * 1e15d,
                        AbsorbedDoseOfIonizingRadiationUnit.Picogray => (_value) * 1e-12d,
                        AbsorbedDoseOfIonizingRadiationUnit.Rad => _value / 100,
                        AbsorbedDoseOfIonizingRadiationUnit.Teragray => (_value) * 1e12d,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(AbsorbedDoseOfIonizingRadiationUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        AbsorbedDoseOfIonizingRadiationUnit.Centigray => (baseUnitValue) / 1e-2d,
                        AbsorbedDoseOfIonizingRadiationUnit.Femtogray => (baseUnitValue) / 1e-15d,
                        AbsorbedDoseOfIonizingRadiationUnit.Gigagray => (baseUnitValue) / 1e9d,
                        AbsorbedDoseOfIonizingRadiationUnit.Gray => baseUnitValue,
                        AbsorbedDoseOfIonizingRadiationUnit.Kilogray => (baseUnitValue) / 1e3d,
                        AbsorbedDoseOfIonizingRadiationUnit.Kilorad => (baseUnitValue * 100) / 1e3d,
                        AbsorbedDoseOfIonizingRadiationUnit.Megagray => (baseUnitValue) / 1e6d,
                        AbsorbedDoseOfIonizingRadiationUnit.Megarad => (baseUnitValue * 100) / 1e6d,
                        AbsorbedDoseOfIonizingRadiationUnit.Microgray => (baseUnitValue) / 1e-6d,
                        AbsorbedDoseOfIonizingRadiationUnit.Milligray => (baseUnitValue) / 1e-3d,
                        AbsorbedDoseOfIonizingRadiationUnit.Millirad => (baseUnitValue * 100) / 1e-3d,
                        AbsorbedDoseOfIonizingRadiationUnit.Nanogray => (baseUnitValue) / 1e-9d,
                        AbsorbedDoseOfIonizingRadiationUnit.Petagray => (baseUnitValue) / 1e15d,
                        AbsorbedDoseOfIonizingRadiationUnit.Picogray => (baseUnitValue) / 1e-12d,
                        AbsorbedDoseOfIonizingRadiationUnit.Rad => baseUnitValue * 100,
                        AbsorbedDoseOfIonizingRadiationUnit.Teragray => (baseUnitValue) / 1e12d,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

