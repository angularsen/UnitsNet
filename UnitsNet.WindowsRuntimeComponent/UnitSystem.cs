// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public sealed class UnitSystem
    {
        /// <summary>
        /// Creates an instance of a unit system with the specified base units.
        /// </summary>
        /// <param name="baseUnits">The base units for the unit system.</param>
        public UnitSystem(BaseUnits baseUnits)
        {
            if(baseUnits is null)
                throw new ArgumentNullException(nameof(baseUnits));

            if(baseUnits.Length == LengthUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.Mass == MassUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.Time == DurationUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.Current == ElectricCurrentUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.Temperature == TemperatureUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.Amount == AmountOfSubstanceUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            if(baseUnits.LuminousIntensity == LuminousIntensityUnit.Undefined)
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));

            BaseUnits = baseUnits;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is UnitSystem))
                return false;

            return Equals((UnitSystem)obj);
        }

        [Windows.Foundation.Metadata.DefaultOverload]
        public bool Equals(UnitSystem other)
        {
            if(other is null)
                return false;

            return BaseUnits.Equals(other.BaseUnits);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return new {BaseUnits}.GetHashCode();
        }

        public BaseUnits BaseUnits{ get; }

        private static readonly BaseUnits SIBaseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
            ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

        /// <summary>
        /// Gets the SI unit system.
        /// </summary>
        public static UnitSystem SI{ get; } = new UnitSystem(SIBaseUnits);
    }
}
