namespace UnitsNet.UnitSystems
{
    /// <summary>
    ///     Represents a quantity in a unit system in terms of a {base unit, list of derived units}
    /// </summary>
    public sealed class UnitSystemInfo
    {
        /// <summary>
        ///     Create an instance of the UnitSystemInfo class.
        /// </summary>
        /// <param name="baseUnit">The default unit used for representing the quantity in a unit system (e.g. "cubic meter")</param>
        /// <param name="derivedUnits">
        ///     The list of units that are commonly used with this unit system (e.g. {"cubic meter", "liter"})
        /// </param>
        public UnitSystemInfo(UnitInfo baseUnit, UnitInfo[] derivedUnits)
        {
            BaseUnit = baseUnit;
            DerivedUnits = derivedUnits;
        }

        /// <summary>
        ///     The default unit used for representing a quantity in a unit system
        /// </summary>
        public UnitInfo BaseUnit { get; }

        /// <summary>
        ///     The list of commonly used (derived or named) units in a unit system
        /// </summary>
        public UnitInfo[] DerivedUnits { get; }
    }
}
