using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct VolumeConcentration
    {
        /// <summary>
        /// Get <see cref="MassConcentration" /> from this <see cref="VolumeConcentration" /> and component <see cref="Density" /> .
        /// </summary>
        /// <param name="componentDensity"></param>
        /// <returns></returns>
        public MassConcentration ToMassConcentration(Density componentDensity)
        {
            return this * componentDensity;
        }

        /// <summary>
        /// Get <see cref="Molarity" /> from this <see cref="VolumeConcentration" /> and component <see cref="Density"/> and <see cref="MolarMass"/> .
        /// </summary>
        /// <param name="componentDensity"></param>
        /// <param name="compontMolarMass"></param>
        /// <returns></returns>
        public Molarity ToMolarity(Density componentDensity, MolarMass compontMolarMass)
        {
            return this * componentDensity / compontMolarMass;
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="VolumeConcentration" /> from a component <see cref="Volume" /> and total mixture <see cref="Volume" /> .
        /// </summary>
        public static VolumeConcentration FromVolumes(Volume componentVolume, Volume mixtureMass)
        {
            return new VolumeConcentration(componentVolume / mixtureMass, VolumeConcentrationUnit.DecimalFraction);
        }

        /// <summary>
        ///     Get a <see cref="VolumeConcentration"/> from <see cref="Molarity" /> and a component <see cref="Density" /> and <see cref="MolarMass" />.
        /// </summary>
        /// <param name="molarity"></param>
        /// <param name="componentDensity"></param>
        /// <param name="componentMolarMass"></param>
        public static VolumeConcentration FromMolarity(Molarity molarity, Density componentDensity, MolarMass componentMolarMass)
        {
            return molarity * componentMolarMass / componentDensity;
        }


        #endregion

        #region Operators

        /// <summary>Get <see cref="MassConcentration" /> from <see cref="VolumeConcentration" /> times the component <see cref="Density" />.</summary>
        public static MassConcentration operator *(VolumeConcentration volumeConcentration, Density componentDensity)
        {
            return MassConcentration.FromKilogramsPerCubicMeter(volumeConcentration.DecimalFractions * componentDensity.KilogramsPerCubicMeter);
        }
        
        /// <summary>Get <see cref="MassConcentration" /> from <see cref="VolumeConcentration" /> times the component <see cref="Density" />.</summary>
        public static MassConcentration operator *(Density componentDensity, VolumeConcentration volumeConcentration)
        {
            return MassConcentration.FromKilogramsPerCubicMeter(volumeConcentration.DecimalFractions * componentDensity.KilogramsPerCubicMeter);
        }
        
        #endregion

    }
}
