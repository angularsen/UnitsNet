// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

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

        #region Operators
        
        /// <summary>Get <see cref="Mass" /> from <see cref="MassConcentration" /> times <see cref="Volume" />.</summary>
        public static Mass operator *(MassConcentration density, Volume volume)
        {
            return Mass.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        /// <summary>Get <see cref="Mass" /> from <see cref="Volume" /> times <see cref="MassConcentration" />.</summary>
        public static Mass operator *(Volume volume, MassConcentration density)
        {
            return Mass.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }
        
        /// <summary>Get <see cref="Molarity" /> from <see cref="MassConcentration" /> divided by the component's <see cref="MolarMass" />.</summary>
        public static Molarity operator /(MassConcentration massConcentration, MolarMass componentMass)
        {
            return Molarity.FromMolesPerCubicMeter(massConcentration.GramsPerCubicMeter / componentMass.GramsPerMole);
        }

        /// <summary>Get <see cref="VolumeConcentration" /> from <see cref="MassConcentration" /> divided by the component's <see cref="Density" />.</summary>
        public static VolumeConcentration operator /(MassConcentration massConcentration, Density componentDensity)
        {
            return VolumeConcentration.FromDecimalFractions(massConcentration.KilogramsPerCubicMeter / componentDensity.KilogramsPerCubicMeter);
        }

        #endregion

    }
}
