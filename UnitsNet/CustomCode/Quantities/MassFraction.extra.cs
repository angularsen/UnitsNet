using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct MassFraction
    {
        /// <summary>
        /// Get the <see cref="Mass"/> of the component by multiplying the <see cref="Mass"/> of the mixture and this <see cref="MassFraction"/>.
        /// </summary>
        /// <param name="totalMass">The total mass of the mixture</param>
        /// <returns>The actual mass of the component involved in this mixture</returns>
        public Mass GetComponentMass(Mass totalMass)
        {
            return totalMass * this;
        }

        /// <summary>
        /// Get the total <see cref="Mass"/> of the mixture by dividing the <see cref="Mass"/> of the component by this <see cref="MassFraction"/>
        /// </summary>
        /// <param name="componentMass">The actual mass of the component involved in this mixture</param>
        /// <returns>The total mass of the mixture</returns>
        public Mass GetTotalMass(Mass componentMass)
        {
            return componentMass / this;
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="MassFraction" /> from a component <see cref="Mass" /> and total mixture <see cref="Mass" /> .
        /// </summary>
        public static MassFraction FromMasses(Mass componentMass, Mass mixtureMass)
        {
            return new MassFraction(componentMass / mixtureMass, MassFractionUnit.DecimalFraction);
        }

        #endregion

        /// <summary>Get <see cref="Mass"/> from <see cref="Mass"/> multiplied by a <see cref="MassFraction"/>.</summary>
        public static Mass operator *(MassFraction massFraction, Mass mass)
        {
            return Mass.FromKilograms(massFraction.DecimalFractions * mass.Kilograms);
        }

        /// <summary>Get <see cref="Mass"/> from <see cref="Mass"/> multiplied by a <see cref="MassFraction"/>.</summary>
        public static Mass operator *(Mass mass, MassFraction massFraction)
        {
            return Mass.FromKilograms(massFraction.DecimalFractions * mass.Kilograms);
        }
        /// <summary>Get the total <see cref="Mass"/> by dividing the component  <see cref="Mass"/> by a <see cref="MassFraction"/>.</summary>
        public static Mass operator /(Mass mass, MassFraction massFraction)
        {
            return Mass.FromKilograms(mass.Kilograms / massFraction.DecimalFractions);
        }

    }
}
