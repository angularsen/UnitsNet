// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct MassConcentration
    {
        /// <summary>
        ///     Get <see cref="Molarity" /> from this <see cref="MassConcentration" /> using the known component <see cref="MolarMass" />.
        /// </summary>
        /// <param name="molecularWeight"></param>
        public Molarity ToMolarity(MolarMass molecularWeight)
        {
            return this / molecularWeight;
        }

        /// <summary>
        ///  Get <see cref="VolumeConcentration" /> from this <see cref="MassConcentration" /> using the known component <see cref="Density" />.
        /// </summary>
        /// <param name="componentDensity"></param>
        /// <returns></returns>
        public VolumeConcentration ToVolumeConcentration(Density componentDensity)
        {
            return this / componentDensity;
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="MassConcentration" /> from <see cref="Molarity" />.
        /// </summary>
        public static MassConcentration FromMolarity(Molarity molarity, MolarMass mass)
        {
            return molarity * mass;
        }

        /// <summary>
        ///     Get <see cref="MassConcentration" /> from <see cref="VolumeConcentration" /> and component <see cref="Density" />.
        /// </summary>
        public static MassConcentration FromVolumeConcentration(VolumeConcentration volumeConcentration, Density componentDensity)
        {
            return volumeConcentration * componentDensity;
        }

        #endregion
    }
}
