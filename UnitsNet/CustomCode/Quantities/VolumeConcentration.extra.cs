using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct VolumeConcentration<T>
    {
        /// <summary>
        /// Get <see cref="MassConcentration{T}" /> from this <see cref="VolumeConcentration{T}" /> and component <see cref="Density{T}" /> .
        /// </summary>
        /// <param name="componentDensity"></param>
        /// <returns></returns>
        public MassConcentration<T> ToMassConcentration(Density<T> componentDensity )
        {
            return this * componentDensity;
        }

        /// <summary>
        /// Get <see cref="Molarity{T}" /> from this <see cref="VolumeConcentration{T}" /> and component <see cref="Density{T}"/> and <see cref="MolarMass{T}"/> .
        /// </summary>
        /// <param name="componentDensity"></param>
        /// <param name="compontMolarMass"></param>
        /// <returns></returns>
        public Molarity<T> ToMolarity(Density<T> componentDensity, MolarMass<T> compontMolarMass )
        {
            return this * componentDensity / compontMolarMass;
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="VolumeConcentration{T}" /> from a component <see cref="Volume{T}" /> and total mixture <see cref="Volume{T}" /> .
        /// </summary>
        public static VolumeConcentration<T> FromVolumes(Volume<T> componentVolume, Volume<T> mixtureMass )
        {
            return new VolumeConcentration<T>( componentVolume / mixtureMass, VolumeConcentrationUnit.DecimalFraction);
        }

        /// <summary>
        ///     Get a <see cref="VolumeConcentration{T}"/> from <see cref="Molarity{T}" /> and a component <see cref="Density{T}" /> and <see cref="MolarMass{T}" />.
        /// </summary>
        /// <param name="molarity"></param>
        /// <param name="componentDensity"></param>
        /// <param name="componentMolarMass"></param>
        public static VolumeConcentration<T> FromMolarity(Molarity<T> molarity, Density<T> componentDensity, MolarMass<T> componentMolarMass )
        {
            return molarity * componentMolarMass / componentDensity;
        }


        #endregion

        #region Operators

        /// <summary>Get <see cref="MassConcentration{T}" /> from <see cref="VolumeConcentration{T}" /> times the component <see cref="Density{T}" />.</summary>
        public static MassConcentration<T> operator *(VolumeConcentration<T> volumeConcentration, Density<T> componentDensity )
        {
            return MassConcentration<T>.FromKilogramsPerCubicMeter(volumeConcentration.DecimalFractions * componentDensity.KilogramsPerCubicMeter);
        }
        
        /// <summary>Get <see cref="MassConcentration{T}" /> from <see cref="VolumeConcentration{T}" /> times the component <see cref="Density{T}" />.</summary>
        public static MassConcentration<T> operator *(Density<T> componentDensity, VolumeConcentration<T> volumeConcentration )
        {
            return MassConcentration<T>.FromKilogramsPerCubicMeter(volumeConcentration.DecimalFractions * componentDensity.KilogramsPerCubicMeter);
        }
        
        #endregion

    }
}
