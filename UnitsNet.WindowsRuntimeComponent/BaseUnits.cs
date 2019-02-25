// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System.Text;
using UnitsNet.Units;

namespace UnitsNet
{
    /// <summary>
    ///     Represents the base units for a quantity. All quantities, both base and derived, can be
    ///     represented by a combination of these seven base units.
    /// </summary>
    public sealed class BaseUnits
    {
        /// <summary>
        /// Creates an instance of if the base units class that represents the base units for a quantity.
        /// All quantities, both base and derived, can be represented by a combination of these seven base units.
        /// </summary>
        /// <param name="length">The length unit (L).</param>
        /// <param name="mass">The mass unit (M).</param>
        /// <param name="time">The time unit (T).</param>
        /// <param name="current">The electric current unit (I).</param>
        /// <param name="temperature">The temperature unit (Θ).</param>
        /// <param name="amount">The amount of substance unit (N).</param>
        /// <param name="luminousIntensity">The luminous intensity unit (J).</param>
        public BaseUnits(LengthUnit length, MassUnit mass, DurationUnit time, ElectricCurrentUnit current,
            TemperatureUnit temperature, AmountOfSubstanceUnit amount, LuminousIntensityUnit luminousIntensity)
        {
            Length = length;
            Mass = mass;
            Time = time;
            Current = current;
            Temperature = temperature;
            Amount = amount;
            LuminousIntensity = luminousIntensity;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if(obj is null || !(obj is BaseUnits))
                return false;

            return Equals((BaseUnits)obj);
        }

        /// <summary>
        /// Checks if all of the base units are equal to another instance's.
        /// </summary>
        /// <param name="other">The other instance to check if equal to.</param>
        /// <returns>True if equal, otherwise false.</returns>
        [Windows.Foundation.Metadata.DefaultOverload]
        public bool Equals(BaseUnits other)
        {
            if(other is null)
                return false;

            return Length == other.Length &&
                Mass == other.Mass &&
                Time == other.Time &&
                Current == other.Current &&
                Temperature == other.Temperature &&
                Amount == other.Amount &&
                LuminousIntensity == other.LuminousIntensity;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return new {Length, Mass, Time, Current, Temperature, Amount, LuminousIntensity}.GetHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("[Length]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Length));
            sb.AppendFormat("[Mass]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Mass));
            sb.AppendFormat("[Time]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Time));
            sb.AppendFormat("[Current]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Current));
            sb.AppendFormat("[Temperature]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Temperature));
            sb.AppendFormat("[Amount]: {0}, ", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(Amount));
            sb.AppendFormat("[LuminousIntensity]: {0}", UnitAbbreviationsCache.Default.GetDefaultAbbreviation(LuminousIntensity));

            return sb.ToString();
        }

        /// <summary>
        /// Gets the length unit (L).
        /// </summary>
        public LengthUnit Length { get; }

        /// <summary>
        /// Gets the mass unit (M).
        /// </summary>
        public MassUnit Mass{ get; }

        /// <summary>
        /// Gets the time unit (T).
        /// </summary>
        public DurationUnit Time{ get; }

        /// <summary>
        /// Gets the electric current unit (I).
        /// </summary>
        public ElectricCurrentUnit Current{ get; }

        /// <summary>
        /// Gets the temperature unit (Θ).
        /// </summary>
        public TemperatureUnit Temperature{ get; }

        /// <summary>
        /// Gets the amount of substance unit (N).
        /// </summary>
        public AmountOfSubstanceUnit Amount{ get; }

        /// <summary>
        /// Gets the luminous intensity unit (J).
        /// </summary>
        public LuminousIntensityUnit LuminousIntensity{ get; }
    }
}
