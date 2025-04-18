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
    ///     Electric impedance is the opposition to alternating current presented by the combined effect of resistance and reactance in a circuit. It is defined as the inverse of admittance. The SI unit of impedance is the ohm (symbol Ω).
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Electrical_impedance
    /// </remarks>
    [Obsolete("Impedance is a complex number, which is not currently supported by UnitsNet. Please use either ElectricResistance or ElectricReactance instead.")]
    public struct  ElectricImpedance
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly ElectricImpedanceUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public ElectricImpedanceUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        public ElectricImpedance(double value, ElectricImpedanceUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of ElectricImpedance, which is Second. All conversions go via this value.
        /// </summary>
        public static ElectricImpedanceUnit BaseUnit { get; } = ElectricImpedanceUnit.Ohm;

        /// <summary>
        /// Represents the largest possible value of ElectricImpedance.
        /// </summary>
        public static ElectricImpedance MaxValue { get; } = new ElectricImpedance(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of ElectricImpedance.
        /// </summary>
        public static ElectricImpedance MinValue { get; } = new ElectricImpedance(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static ElectricImpedance Zero { get; } = new ElectricImpedance(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricImpedanceUnit.Gigaohm"/>
        /// </summary>
        public double Gigaohms => As(ElectricImpedanceUnit.Gigaohm);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricImpedanceUnit.Kiloohm"/>
        /// </summary>
        public double Kiloohms => As(ElectricImpedanceUnit.Kiloohm);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricImpedanceUnit.Megaohm"/>
        /// </summary>
        public double Megaohms => As(ElectricImpedanceUnit.Megaohm);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricImpedanceUnit.Microohm"/>
        /// </summary>
        public double Microohms => As(ElectricImpedanceUnit.Microohm);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricImpedanceUnit.Milliohm"/>
        /// </summary>
        public double Milliohms => As(ElectricImpedanceUnit.Milliohm);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricImpedanceUnit.Nanoohm"/>
        /// </summary>
        public double Nanoohms => As(ElectricImpedanceUnit.Nanoohm);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricImpedanceUnit.Ohm"/>
        /// </summary>
        public double Ohms => As(ElectricImpedanceUnit.Ohm);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricImpedanceUnit.Teraohm"/>
        /// </summary>
        public double Teraohms => As(ElectricImpedanceUnit.Teraohm);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="ElectricImpedance"/> from <see cref="ElectricImpedanceUnit.Gigaohm"/>.
        /// </summary>
        public static ElectricImpedance FromGigaohms(double gigaohms) => new ElectricImpedance(gigaohms, ElectricImpedanceUnit.Gigaohm);

        /// <summary>
        ///     Creates a <see cref="ElectricImpedance"/> from <see cref="ElectricImpedanceUnit.Kiloohm"/>.
        /// </summary>
        public static ElectricImpedance FromKiloohms(double kiloohms) => new ElectricImpedance(kiloohms, ElectricImpedanceUnit.Kiloohm);

        /// <summary>
        ///     Creates a <see cref="ElectricImpedance"/> from <see cref="ElectricImpedanceUnit.Megaohm"/>.
        /// </summary>
        public static ElectricImpedance FromMegaohms(double megaohms) => new ElectricImpedance(megaohms, ElectricImpedanceUnit.Megaohm);

        /// <summary>
        ///     Creates a <see cref="ElectricImpedance"/> from <see cref="ElectricImpedanceUnit.Microohm"/>.
        /// </summary>
        public static ElectricImpedance FromMicroohms(double microohms) => new ElectricImpedance(microohms, ElectricImpedanceUnit.Microohm);

        /// <summary>
        ///     Creates a <see cref="ElectricImpedance"/> from <see cref="ElectricImpedanceUnit.Milliohm"/>.
        /// </summary>
        public static ElectricImpedance FromMilliohms(double milliohms) => new ElectricImpedance(milliohms, ElectricImpedanceUnit.Milliohm);

        /// <summary>
        ///     Creates a <see cref="ElectricImpedance"/> from <see cref="ElectricImpedanceUnit.Nanoohm"/>.
        /// </summary>
        public static ElectricImpedance FromNanoohms(double nanoohms) => new ElectricImpedance(nanoohms, ElectricImpedanceUnit.Nanoohm);

        /// <summary>
        ///     Creates a <see cref="ElectricImpedance"/> from <see cref="ElectricImpedanceUnit.Ohm"/>.
        /// </summary>
        public static ElectricImpedance FromOhms(double ohms) => new ElectricImpedance(ohms, ElectricImpedanceUnit.Ohm);

        /// <summary>
        ///     Creates a <see cref="ElectricImpedance"/> from <see cref="ElectricImpedanceUnit.Teraohm"/>.
        /// </summary>
        public static ElectricImpedance FromTeraohms(double teraohms) => new ElectricImpedance(teraohms, ElectricImpedanceUnit.Teraohm);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricImpedanceUnit" /> to <see cref="ElectricImpedance" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricImpedance unit value.</returns>
        public static ElectricImpedance From(double value, ElectricImpedanceUnit fromUnit)
        {
            return new ElectricImpedance(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(ElectricImpedanceUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this ElectricImpedance to another ElectricImpedance with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A ElectricImpedance with the specified unit.</returns>
                public ElectricImpedance ToUnit(ElectricImpedanceUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new ElectricImpedance(convertedValue, unit);
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
                        ElectricImpedanceUnit.Gigaohm => (_value) * 1e9d,
                        ElectricImpedanceUnit.Kiloohm => (_value) * 1e3d,
                        ElectricImpedanceUnit.Megaohm => (_value) * 1e6d,
                        ElectricImpedanceUnit.Microohm => (_value) * 1e-6d,
                        ElectricImpedanceUnit.Milliohm => (_value) * 1e-3d,
                        ElectricImpedanceUnit.Nanoohm => (_value) * 1e-9d,
                        ElectricImpedanceUnit.Ohm => _value,
                        ElectricImpedanceUnit.Teraohm => (_value) * 1e12d,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(ElectricImpedanceUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        ElectricImpedanceUnit.Gigaohm => (baseUnitValue) / 1e9d,
                        ElectricImpedanceUnit.Kiloohm => (baseUnitValue) / 1e3d,
                        ElectricImpedanceUnit.Megaohm => (baseUnitValue) / 1e6d,
                        ElectricImpedanceUnit.Microohm => (baseUnitValue) / 1e-6d,
                        ElectricImpedanceUnit.Milliohm => (baseUnitValue) / 1e-3d,
                        ElectricImpedanceUnit.Nanoohm => (baseUnitValue) / 1e-9d,
                        ElectricImpedanceUnit.Ohm => baseUnitValue,
                        ElectricImpedanceUnit.Teraohm => (baseUnitValue) / 1e12d,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

