using System;
using UnitsNet.Units;

namespace UnitsNet.UnitSystems
{
    /// <summary>
    ///     Represents a unit system derived from the SI base units
    /// </summary>
    public class BaseUnitSystem : UnitSystem, IEquatable<BaseUnitSystem>
    {
        /// <summary>
        ///     Construct using the original behavior of matching the BaseUnits definition for Units
        /// </summary>
        /// <param name="baseUnits">The base units for this unit system</param>
        [Obsolete("This constructor relies on the presence of BaseUnits property for Units- which is likely to be removed")]
        public BaseUnitSystem(BaseUnits baseUnits) : base(baseUnits)
        {
            BaseUnits = baseUnits;
        }

        /// <summary>
        ///     Construct a BaseUnitSystem with default BaseUnits and a set of unit configurations (for each quantity)
        /// </summary>
        /// <param name="systemInfos">The units configuration for this unit system</param>
        public BaseUnitSystem(UnitSystemInfo?[] systemInfos) : base(systemInfos)
        {
            BaseUnits = GetBaseUnits(systemInfos);
            if (!BaseUnits.IsFullyDefined) // TODO should we required that baseUnits are FullyDefined?
            {
                throw new ArgumentException("A unit system must have all base units defined.");
            }
        }

        /// <summary>
        ///     Construct a BaseUnitSystem with default BaseUnits and a lazy-loaded set of unit configurations (for each quantity)
        /// </summary>
        /// <param name="baseUnits">The base units for this unit system</param>
        /// <param name="systemInfos">The units configuration for this unit system (lazy-loaded)</param>
        protected BaseUnitSystem(BaseUnits baseUnits, Lazy<UnitSystemInfo?[]> systemInfos) : base(systemInfos)
        {
            if (!baseUnits.IsFullyDefined) // TODO should we required that baseUnits are FullyDefined?
            {
                throw new ArgumentException("A unit system must have all base units defined.", nameof(baseUnits));
            }

            BaseUnits = baseUnits;
        }

        /// <summary>
        ///     The base units of this unit system.
        /// </summary>
        public BaseUnits BaseUnits { get; }

        /// <summary>
        ///     Returns the BaseUnits corresponding to the provided unit-system associations
        /// </summary>
        /// <param name="systemInfos"></param>
        /// <returns></returns>
        protected static BaseUnits GetBaseUnits(UnitSystemInfo?[] systemInfos)
        {
            var lengthUnit = (LengthUnit) (GetSystemInfo(systemInfos, QuantityType.Length)?.BaseUnit?.Value ?? LengthUnit.Undefined);
            var massUnit = (MassUnit) (GetSystemInfo(systemInfos, QuantityType.Mass)?.BaseUnit.Value ?? MassUnit.Undefined);
            var durationUnit = (DurationUnit) (GetSystemInfo(systemInfos, QuantityType.Duration)?.BaseUnit.Value ?? DurationUnit.Undefined);
            var electricCurrentUnit =
                (ElectricCurrentUnit) (GetSystemInfo(systemInfos, QuantityType.ElectricCurrent)?.BaseUnit.Value ?? ElectricCurrentUnit.Undefined);
            var temperatureUnit = (TemperatureUnit) (GetSystemInfo(systemInfos, QuantityType.Temperature)?.BaseUnit.Value ?? TemperatureUnit.Undefined);
            var amountOfSubstanceUnit =
                (AmountOfSubstanceUnit) (GetSystemInfo(systemInfos, QuantityType.AmountOfSubstance)?.BaseUnit.Value ?? AmountOfSubstanceUnit.Undefined);
            var luminousIntensityUnit =
                (LuminousIntensityUnit) (GetSystemInfo(systemInfos, QuantityType.LuminousIntensity)?.BaseUnit.Value ?? LuminousIntensityUnit.Undefined);
            return new BaseUnits(lengthUnit, massUnit, durationUnit, electricCurrentUnit, temperatureUnit, amountOfSubstanceUnit, luminousIntensityUnit);
        }


        /// <summary>
        ///     Create a derived unit system by specifying a default unit for a given quantity type.
        ///     It is possible to configure multiple associations by chaining calls to this method:
        ///     SI.WithDefaultUnit(..).WithDefaultUnit(..)...
        /// </summary>
        /// <param name="quantityType">The quantity type of interest.</param>
        /// <param name="defaultUnitInfo">The default UnitInfo to associate with the given quantity type.</param>
        /// <param name="derivedUnitInfos">Optionally provide a new definition for the derived units of the new unit system.</param>
        /// <returns>
        ///     A new UnitSystem that defines <paramref name="defaultUnitInfo" /> as the default unit for
        ///     <paramref name="quantityType" />
        /// </returns>
        /// <exception cref="ArgumentException">
        ///     Quantity type can not be undefined and must be compatible with the new default unit (e.g. cannot associate MassUnit
        ///     with 'Meter')
        /// </exception>
        public new BaseUnitSystem WithDefaultUnit(QuantityType quantityType, UnitInfo? defaultUnitInfo, UnitInfo[]? derivedUnitInfos = null)
        {
            return new BaseUnitSystem(GetDerivedUnitAssociations(quantityType, defaultUnitInfo, derivedUnitInfos));
        }

        #region IEquatable<BaseUnitSystem> interface implementation

        /// <inheritdoc />
        public bool Equals(BaseUnitSystem? other)
        {
            return other is { } && BaseUnits.Equals(other.BaseUnits);
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            return Equals(obj as BaseUnitSystem);
        }
        
        /// <summary>
        ///     Checks if this instance is equal to another.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>True if equal, otherwise false.</returns>
        /// <seealso cref="Equals(BaseUnitSystem)" />
        public static bool operator ==(BaseUnitSystem? left, BaseUnitSystem? right)
        {
            return Equals(left, right);
        }
        
        /// <summary>
        ///     Checks if this instance is equal to another.
        /// </summary>
        /// <param name="left">The left instance.</param>
        /// <param name="right">The right instance.</param>
        /// <returns>True if equal, otherwise false.</returns>
        /// <seealso cref="Equals(BaseUnitSystem)" />
        public static bool operator !=(BaseUnitSystem? left, BaseUnitSystem? right)
        {
            return !Equals(left, right);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return new {BaseUnits}.GetHashCode();
        }

        #endregion
    }
}
