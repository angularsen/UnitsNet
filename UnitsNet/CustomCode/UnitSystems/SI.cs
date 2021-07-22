using System;
using UnitsNet.Units;

namespace UnitsNet.UnitSystems
{
    /// <summary>
    ///     The International System of Units (SI, abbreviated from the French Système international (d'unités)) is the modern
    ///     form of the metric system and is the most widely used system of measurement. It comprises a coherent system of
    ///     units of measurement built on seven base units, which are the second, metre, kilogram, ampere, kelvin, mole,
    ///     candela, and a set of twenty prefixes to the unit names and unit symbols that may be used when specifying multiples
    ///     and fractions of the units. The system also specifies names for 22 derived units, such as lumen and watt, for other
    ///     common physical quantities.
    /// </summary>
    public partial class SI : BaseUnitSystem
    {
        private static readonly BaseUnits SIBaseUnits = new BaseUnits(LengthUnit.Meter, MassUnit.Kilogram, DurationUnit.Second,
            ElectricCurrentUnit.Ampere, TemperatureUnit.Kelvin, AmountOfSubstanceUnit.Mole, LuminousIntensityUnit.Candela);

        /// <summary>
        ///     Construct a new instance of the SI class with default unit mappings
        /// </summary>
        public SI() : base(SIBaseUnits,  new Lazy<UnitSystemInfo?[]>(GetDefaultSystemUnits))
        {
        }

    }
}
