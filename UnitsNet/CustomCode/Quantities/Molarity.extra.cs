using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Molarity
    {
        /// <summary>
        ///     Construct from <see cref="Density"/> divided by <see cref="Mass"/>.
        /// </summary>
        /// <seealso cref="Density.op_Division(UnitsNet.Density,UnitsNet.Mass)"/>
        [Obsolete("This constructor will be removed in favor of operator overload Density.op_Division(UnitsNet.Density,UnitsNet.Mass).")]
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
        [Obsolete("Use Density / Mass operator overload instead.")]
        public static Molarity FromDensity(Density density, Mass molecularWeight)
        {
            return density / molecularWeight;
        }

        #endregion
    }
}
