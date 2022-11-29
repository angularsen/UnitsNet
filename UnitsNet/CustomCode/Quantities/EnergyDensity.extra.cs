using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct EnergyDensity
    {
        #region Operators

        /// <summary>
        ///     Returns the <see cref = "Energy" /> from the given <see cref = "EnergyDensity" /> and <see cref = "Volume" />.
        /// </summary>
        public static Energy operator * ( EnergyDensity energyDensity, Volume volume )
        {
            return Energy.FromJoules ( energyDensity.JoulesPerCubicMeter * volume.As ( VolumeUnit.CubicMeter ) );
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Computes the combustion energy of a natural gas heating system.
        ///     <para>
        ///         The energy density of natural gas may vary monthly.
        ///     </para>
        /// </summary>
        /// <param name = "energyDensity">
        ///     The <see cref = "EnergyDensity" /> that specifies the combustion energy of natural gas.
        ///     <para>
        ///         This value is normally shown on the invoice, otherwise it is to be requested from the supplier. For a rough approximation, a value of 10 kWh/m³ for natural gas can be assumed.
        ///     </para>
        /// </param>
        /// <param name = "conversionFactor">
        ///     The <see cref = "double" /> that specifies the ratio of a natural gas volume in the standard condition to the natural gas volume in the operating condition.
        ///     <para>
        ///         This value is normally shown on the invoice, otherwise it is to be requested from the supplier. For a rough approximation, a value of 100% for natural gas can be assumed.
        ///     </para>
        /// </param>
        /// <param name = "volume">
        ///     The <see cref = "Volume" /> that specifies the consumed volume of natural gas determined by meter reading.
        /// </param>
        /// <returns>
        ///     An <see cref = "Energy" /> that specifies the combustion energy of natural gas as consumed by the heating system.
        /// </returns>
        public static Energy CombustionEnergy ( EnergyDensity energyDensity, Volume volume, Ratio conversionFactor )
        {
            return Energy.FromJoules ( (energyDensity * volume).As ( EnergyUnit.Joule ) * conversionFactor.DecimalFractions );
        }

        #endregion
    }
}
