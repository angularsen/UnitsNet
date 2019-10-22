using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct MassFraction<T>
    {
        /// <summary>
        /// Get the <see cref="Mass{T}"/> of the component by multiplying the <see cref="Mass{T}"/> of the mixture and this <see cref="MassFraction{T}"/>.
        /// </summary>
        /// <param name="totalMass">The total mass of the mixture</param>
        /// <returns>The actual mass of the component involved in this mixture</returns>
        public Mass<T> GetComponentMass(Mass<T> totalMass )
        {
            return totalMass * this;
        }

        /// <summary>
        /// Get the total <see cref="Mass{T}"/> of the mixture by dividing the <see cref="Mass{T}"/> of the component by this <see cref="MassFraction{T}"/>
        /// </summary>
        /// <param name="componentMass">The actual mass of the component involved in this mixture</param>
        /// <returns>The total mass of the mixture</returns>
        public Mass<T> GetTotalMass(Mass<T> componentMass )
        {
            return componentMass / this;
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="MassFraction{T}" /> from a component <see cref="Mass{T}" /> and total mixture <see cref="Mass{T}" /> .
        /// </summary>
        public static MassFraction<T> FromMasses(Mass<T> componentMass, Mass<T> mixtureMass )
        {
            return new MassFraction<T>( componentMass / mixtureMass, MassFractionUnit.DecimalFraction);
        }

        #endregion

        /// <summary>Get <see cref="Mass{T}"/> from <see cref="Mass{T}"/> multiplied by a <see cref="MassFraction{T}"/>.</summary>
        public static Mass<T> operator *(MassFraction<T> massFraction, Mass<T> mass )
        {
            return Mass<T>.FromKilograms(massFraction.DecimalFractions * mass.Kilograms);
        }

        /// <summary>Get <see cref="Mass{T}"/> from <see cref="Mass{T}"/> multiplied by a <see cref="MassFraction{T}"/>.</summary>
        public static Mass<T> operator *(Mass<T> mass, MassFraction<T> massFraction )
        {
            return Mass<T>.FromKilograms(massFraction.DecimalFractions * mass.Kilograms);
        }
        /// <summary>Get the total <see cref="Mass{T}"/> by dividing the component  <see cref="Mass{T}"/> by a <see cref="MassFraction{T}"/>.</summary>
        public static Mass<T> operator /(Mass<T> mass, MassFraction<T> massFraction )
        {
            return Mass<T>.FromKilograms(mass.Kilograms / massFraction.DecimalFractions);
        }

    }
}
