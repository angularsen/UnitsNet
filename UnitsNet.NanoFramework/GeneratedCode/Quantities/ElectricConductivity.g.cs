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
    ///     Electrical conductivity or specific conductance is the reciprocal of electrical resistivity, and measures a material's ability to conduct an electric current.
    /// </summary>
    /// <remarks>
    ///     https://en.wikipedia.org/wiki/Electrical_resistivity_and_conductivity
    /// </remarks>
    public struct  ElectricConductivity
    {
        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        private readonly double _value;

        /// <summary>
        ///     The unit this quantity was constructed with.
        /// </summary>
        private readonly ElectricConductivityUnit _unit;

        /// <summary>
        ///     The numeric value this quantity was constructed with.
        /// </summary>
        public double Value => _value;

        /// <inheritdoc />
        public ElectricConductivityUnit Unit => _unit;

        /// <summary>
        ///     Creates the quantity with the given numeric value and unit.
        /// </summary>
        /// <param name="value">The numeric value to construct this quantity with.</param>
        /// <param name="unit">The unit representation to construct this quantity with.</param>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public ElectricConductivity(double value, ElectricConductivityUnit unit)
        {
            _value = value;
            _unit = unit;
        }

        /// <summary>
        ///     The base unit of Duration, which is Second. All conversions go via this value.
        /// </summary>
        public static ElectricConductivityUnit BaseUnit { get; } = ElectricConductivityUnit.SiemensPerMeter;

        /// <summary>
        /// Represents the largest possible value of Duration
        /// </summary>
        public static ElectricConductivity MaxValue { get; } = new ElectricConductivity(double.MaxValue, BaseUnit);

        /// <summary>
        /// Represents the smallest possible value of Duration
        /// </summary>
        public static ElectricConductivity MinValue { get; } = new ElectricConductivity(double.MinValue, BaseUnit);

        /// <summary>
        ///     Gets an instance of this quantity with a value of 0 in the base unit Second.
        /// </summary>
        public static ElectricConductivity Zero { get; } = new ElectricConductivity(0, BaseUnit);
        #region Conversion Properties

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricConductivityUnit.MicrosiemensPerCentimeter"/>
        /// </summary>
        public double MicrosiemensPerCentimeter => As(ElectricConductivityUnit.MicrosiemensPerCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricConductivityUnit.MillisiemensPerCentimeter"/>
        /// </summary>
        public double MillisiemensPerCentimeter => As(ElectricConductivityUnit.MillisiemensPerCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricConductivityUnit.SiemensPerCentimeter"/>
        /// </summary>
        public double SiemensPerCentimeter => As(ElectricConductivityUnit.SiemensPerCentimeter);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricConductivityUnit.SiemensPerFoot"/>
        /// </summary>
        public double SiemensPerFoot => As(ElectricConductivityUnit.SiemensPerFoot);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricConductivityUnit.SiemensPerInch"/>
        /// </summary>
        public double SiemensPerInch => As(ElectricConductivityUnit.SiemensPerInch);

        /// <summary>
        ///     Gets a <see cref="double"/> value of this quantity converted into <see cref="ElectricConductivityUnit.SiemensPerMeter"/>
        /// </summary>
        public double SiemensPerMeter => As(ElectricConductivityUnit.SiemensPerMeter);

        #endregion

        #region Static Factory Methods

        /// <summary>
        ///     Creates a <see cref="ElectricConductivity"/> from <see cref="ElectricConductivityUnit.MicrosiemensPerCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricConductivity FromMicrosiemensPerCentimeter(double microsiemenspercentimeter) => new ElectricConductivity(microsiemenspercentimeter, ElectricConductivityUnit.MicrosiemensPerCentimeter);

        /// <summary>
        ///     Creates a <see cref="ElectricConductivity"/> from <see cref="ElectricConductivityUnit.MillisiemensPerCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricConductivity FromMillisiemensPerCentimeter(double millisiemenspercentimeter) => new ElectricConductivity(millisiemenspercentimeter, ElectricConductivityUnit.MillisiemensPerCentimeter);

        /// <summary>
        ///     Creates a <see cref="ElectricConductivity"/> from <see cref="ElectricConductivityUnit.SiemensPerCentimeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricConductivity FromSiemensPerCentimeter(double siemenspercentimeter) => new ElectricConductivity(siemenspercentimeter, ElectricConductivityUnit.SiemensPerCentimeter);

        /// <summary>
        ///     Creates a <see cref="ElectricConductivity"/> from <see cref="ElectricConductivityUnit.SiemensPerFoot"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricConductivity FromSiemensPerFoot(double siemensperfoot) => new ElectricConductivity(siemensperfoot, ElectricConductivityUnit.SiemensPerFoot);

        /// <summary>
        ///     Creates a <see cref="ElectricConductivity"/> from <see cref="ElectricConductivityUnit.SiemensPerInch"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricConductivity FromSiemensPerInch(double siemensperinch) => new ElectricConductivity(siemensperinch, ElectricConductivityUnit.SiemensPerInch);

        /// <summary>
        ///     Creates a <see cref="ElectricConductivity"/> from <see cref="ElectricConductivityUnit.SiemensPerMeter"/>.
        /// </summary>
        /// <exception cref="ArgumentException">If value is NaN or Infinity.</exception>
        public static ElectricConductivity FromSiemensPerMeter(double siemenspermeter) => new ElectricConductivity(siemenspermeter, ElectricConductivityUnit.SiemensPerMeter);

        /// <summary>
        ///     Dynamically convert from value and unit enum <see cref="ElectricConductivityUnit" /> to <see cref="ElectricConductivity" />.
        /// </summary>
        /// <param name="value">Value to convert from.</param>
        /// <param name="fromUnit">Unit to convert from.</param>
        /// <returns>ElectricConductivity unit value.</returns>
        public static ElectricConductivity From(double value, ElectricConductivityUnit fromUnit)
        {
            return new ElectricConductivity(value, fromUnit);
        }

        #endregion

                #region Conversion Methods

                /// <summary>
                ///     Convert to the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>Value converted to the specified unit.</returns>
                public double As(ElectricConductivityUnit unit) => GetValueAs(unit);

                /// <summary>
                ///     Converts this Duration to another Duration with the unit representation <paramref name="unit" />.
                /// </summary>
                /// <returns>A Duration with the specified unit.</returns>
                public ElectricConductivity ToUnit(ElectricConductivityUnit unit)
                {
                    var convertedValue = GetValueAs(unit);
                    return new ElectricConductivity(convertedValue, unit);
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
                        ElectricConductivityUnit.MicrosiemensPerCentimeter => (_value * 1e2) * 1e-6d,
                        ElectricConductivityUnit.MillisiemensPerCentimeter => (_value * 1e2) * 1e-3d,
                        ElectricConductivityUnit.SiemensPerCentimeter => _value * 1e2,
                        ElectricConductivityUnit.SiemensPerFoot => _value * 3.2808398950131234,
                        ElectricConductivityUnit.SiemensPerInch => _value * 3.937007874015748e1,
                        ElectricConductivityUnit.SiemensPerMeter => _value,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to base units.")
                    };
                    }

                private double GetValueAs(ElectricConductivityUnit unit)
                {
                    if (Unit == unit)
                        return _value;

                    var baseUnitValue = GetValueInBaseUnit();

                    return unit switch
                    {
                        ElectricConductivityUnit.MicrosiemensPerCentimeter => (baseUnitValue / 1e2) / 1e-6d,
                        ElectricConductivityUnit.MillisiemensPerCentimeter => (baseUnitValue / 1e2) / 1e-3d,
                        ElectricConductivityUnit.SiemensPerCentimeter => baseUnitValue / 1e2,
                        ElectricConductivityUnit.SiemensPerFoot => baseUnitValue / 3.2808398950131234,
                        ElectricConductivityUnit.SiemensPerInch => baseUnitValue / 3.937007874015748e1,
                        ElectricConductivityUnit.SiemensPerMeter => baseUnitValue,
                        _ => throw new NotImplementedException($"Can not convert {Unit} to {unit}.")
                    };
                    }

                #endregion
    }
}

