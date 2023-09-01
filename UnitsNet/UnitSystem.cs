// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     A unit system defined by a combination of base units.
    ///     This is typically used to define the "working units" for consistently creating and presenting quantities in the selected base units,
    ///     such as <see cref="SI"/> to use SI base units such as meters, kilograms and seconds.
    /// </summary>
    public sealed class UnitSystem : IEquatable<UnitSystem>
    {
        /// <summary>
        /// Creates an instance of a unit system with the specified base units.
        /// </summary>
        /// <param name="baseUnits">The base units for the unit system.</param>
        public UnitSystem(BaseUnits baseUnits)
        {
            if (baseUnits is null) throw new ArgumentNullException(nameof(baseUnits));
            if (!baseUnits.IsFullyDefined) throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));

            BaseUnits = baseUnits;
        }

        /// <inheritdoc />
        public override bool Equals(object? other)
        {
            return other is UnitSystem otherUnitSystem && Equals(otherUnitSystem);
        }

        /// <inheritdoc />
        public bool Equals(UnitSystem? other)
        {
            return other is not null && BaseUnits.Equals(other.BaseUnits);
        }

        /// <summary>
        /// Checks if this instance is equal to another.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>True if equal, otherwise false.</returns>
        /// <seealso cref="Equals(UnitSystem)"/>
        public static bool operator ==(UnitSystem? left, UnitSystem? right)
        {
            return left?.Equals(right) ?? right is null;
        }

        /// <summary>
        /// Checks if this instance is equal to another.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>True if equal, otherwise false.</returns>
        /// <seealso cref="Equals(UnitSystem)"/>
        public static bool operator !=(UnitSystem? left, UnitSystem? right)
        {
            return !(left == right);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return new {BaseUnits}.GetHashCode();
        }

        /// <summary>
        ///     The base units of this unit system.
        /// </summary>
        public BaseUnits BaseUnits{ get; }

        private static readonly BaseUnits SIBaseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
            ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

        /// <summary>
        /// Gets the SI unit system.
        /// </summary>
        public static UnitSystem SI { get; } = new UnitSystem(SIBaseUnits);
    }
}
