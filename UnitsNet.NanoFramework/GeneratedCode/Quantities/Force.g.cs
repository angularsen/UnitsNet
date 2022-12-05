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
    ///     In physics, a force is any influence that causes an object to undergo a certain change, either concerning its movement, direction, or geometrical construction. In other words, a force can cause an object with mass to change its velocity (which includes to begin moving from a state of rest), i.e., to accelerate, or a flexible object to deform, or both. Force can also be described by intuitive concepts such as a push or a pull. A force has both magnitude and direction, making it a vector quantity. It is measured in the SI unit of newtons and represented by the symbol F.
    /// </summary>
    public struct  Force
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly ForceUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public ForceUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public Force(double value, ForceUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static ForceUnit BaseUnit { get; } = ForceUnit.Newton;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static Force MaxValue { get; } = new Force(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static Force MinValue { get; } = new Force(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static Force Zero { get; } = new Force(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.Decanewton"/>
        /// </summary>
        public double Decanewtons => As(ForceUnit.Decanewton);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.Dyn"/>
        /// </summary>
        public double Dyne => As(ForceUnit.Dyn);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.KilogramForce"/>
        /// </summary>
        public double KilogramsForce => As(ForceUnit.KilogramForce);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.Kilonewton"/>
        /// </summary>
        public double Kilonewtons => As(ForceUnit.Kilonewton);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.KiloPond"/>
        /// </summary>
        public double KiloPonds => As(ForceUnit.KiloPond);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.KilopoundForce"/>
        /// </summary>
        public double KilopoundsForce => As(ForceUnit.KilopoundForce);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.Meganewton"/>
        /// </summary>
        public double Meganewtons => As(ForceUnit.Meganewton);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.Micronewton"/>
        /// </summary>
        public double Micronewtons => As(ForceUnit.Micronewton);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.Millinewton"/>
        /// </summary>
        public double Millinewtons => As(ForceUnit.Millinewton);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.Newton"/>
        /// </summary>
        public double Newtons => As(ForceUnit.Newton);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.OunceForce"/>
        /// </summary>
        public double OunceForce => As(ForceUnit.OunceForce);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.Poundal"/>
        /// </summary>
        public double Poundals => As(ForceUnit.Poundal);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.PoundForce"/>
        /// </summary>
        public double PoundsForce => As(ForceUnit.PoundForce);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.ShortTonForce"/>
        /// </summary>
        public double ShortTonsForce => As(ForceUnit.ShortTonForce);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ForceUnit.TonneForce"/>
        /// </summary>
        public double TonnesForce => As(ForceUnit.TonneForce);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.Decanewton"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromDecanewtons(double decanewtons) => new Force(decanewtons, ForceUnit.Decanewton);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.Dyn"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromDyne(double dyne) => new Force(dyne, ForceUnit.Dyn);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.KilogramForce"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromKilogramsForce(double kilogramsforce) => new Force(kilogramsforce, ForceUnit.KilogramForce);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.Kilonewton"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromKilonewtons(double kilonewtons) => new Force(kilonewtons, ForceUnit.Kilonewton);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.KiloPond"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromKiloPonds(double kiloponds) => new Force(kiloponds, ForceUnit.KiloPond);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.KilopoundForce"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromKilopoundsForce(double kilopoundsforce) => new Force(kilopoundsforce, ForceUnit.KilopoundForce);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.Meganewton"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromMeganewtons(double meganewtons) => new Force(meganewtons, ForceUnit.Meganewton);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.Micronewton"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromMicronewtons(double micronewtons) => new Force(micronewtons, ForceUnit.Micronewton);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.Millinewton"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromMillinewtons(double millinewtons) => new Force(millinewtons, ForceUnit.Millinewton);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.Newton"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromNewtons(double newtons) => new Force(newtons, ForceUnit.Newton);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.OunceForce"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromOunceForce(double ounceforce) => new Force(ounceforce, ForceUnit.OunceForce);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.Poundal"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromPoundals(double poundals) => new Force(poundals, ForceUnit.Poundal);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.PoundForce"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromPoundsForce(double poundsforce) => new Force(poundsforce, ForceUnit.PoundForce);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.ShortTonForce"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromShortTonsForce(double shorttonsforce) => new Force(shorttonsforce, ForceUnit.ShortTonForce);

        /// <summary>
        ///     Creates a <see cref="Force"/> from <see cref="ForceUnit.TonneForce"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static Force FromTonnesForce(double tonnesforce) => new Force(tonnesforce, ForceUnit.TonneForce);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ForceUnit" /> to <see cref="Force" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>Force unit value.</returns>
        public static Force From(double value, ForceUnit fromUnit)
        {
            return new Force(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(ForceUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A Duration with the specified unit.</returns>
                public Force ToUnit(ForceUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new Force(convertedValue, unit);
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
                        ForceUnit.Decanewton => (_value) * 1e1d,
                        ForceUnit.Dyn => _value / 1e5,
                        ForceUnit.KilogramForce => _value * 9.80665002864,
                        ForceUnit.Kilonewton => (_value) * 1e3d,
                        ForceUnit.KiloPond => _value * 9.80665002864,
                        ForceUnit.KilopoundForce => (_value * 4.4482216152605095551842641431421) * 1e3d,
                        ForceUnit.Meganewton => (_value) * 1e6d,
                        ForceUnit.Micronewton => (_value) * 1e-6d,
                        ForceUnit.Millinewton => (_value) * 1e-3d,
                        ForceUnit.Newton => _value,
                        ForceUnit.OunceForce => _value * 2.780138509537812e-1,
                        ForceUnit.Poundal => _value * 0.13825502798973041652092282466083,
                        ForceUnit.PoundForce => _value * 4.4482216152605095551842641431421,
                        ForceUnit.ShortTonForce => _value * 8.896443230521e3,
                        ForceUnit.TonneForce => _value * 9.80665002864e3,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(ForceUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        ForceUnit.Decanewton => (baseUnitValue) / 1e1d,
                        ForceUnit.Dyn => baseUnitValue * 1e5,
                        ForceUnit.KilogramForce => baseUnitValue / 9.80665002864,
                        ForceUnit.Kilonewton => (baseUnitValue) / 1e3d,
                        ForceUnit.KiloPond => baseUnitValue / 9.80665002864,
                        ForceUnit.KilopoundForce => (baseUnitValue / 4.4482216152605095551842641431421) / 1e3d,
                        ForceUnit.Meganewton => (baseUnitValue) / 1e6d,
                        ForceUnit.Micronewton => (baseUnitValue) / 1e-6d,
                        ForceUnit.Millinewton => (baseUnitValue) / 1e-3d,
                        ForceUnit.Newton => baseUnitValue,
                        ForceUnit.OunceForce => baseUnitValue / 2.780138509537812e-1,
                        ForceUnit.Poundal => baseUnitValue / 0.13825502798973041652092282466083,
                        ForceUnit.PoundForce => baseUnitValue / 4.4482216152605095551842641431421,
                        ForceUnit.ShortTonForce => baseUnitValue / 8.896443230521e3,
                        ForceUnit.TonneForce => baseUnitValue / 9.80665002864e3,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

