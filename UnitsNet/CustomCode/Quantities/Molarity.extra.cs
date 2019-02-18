using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Molarity
    {
        public Molarity(Density density, Mass molecularWeight)
            : this()
        {
            _value = density.KilogramsPerCubicMeter / molecularWeight.Kilograms;
            _unit = MolarityUnit.MolesPerCubicMeter;
        }

        /// <summary>
        ///     Get a <see cref="Density"/> from this <see cref="Molarity"/>.
        /// </summary>
        /// <param name="molecularWeight"></param>
        public Density ToDensity(Mass molecularWeight)
        {
            return Density.FromKilogramsPerCubicMeter(MolesPerCubicMeter * molecularWeight.Kilograms);
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="Molarity"/> from <see cref="Density"/>.
        /// </summary>
        /// <param name="density"></param>
        /// <param name="molecularWeight"></param>
        public static Molarity FromDensity(Density density, Mass molecularWeight)
        {
            return new Molarity(density, molecularWeight);
        }

        #endregion
    }
}
