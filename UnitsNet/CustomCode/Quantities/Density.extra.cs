// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Density
    {
        /// <summary>
        ///     Gets <see cref="Molarity" /> from this <see cref="Density" />.
        /// </summary>
        /// <param name="molecularWeight"></param>
        public Molarity ToMolarity(Mass molecularWeight)
        {
            return Molarity.FromMolesPerCubicMeter(KilogramsPerCubicMeter / molecularWeight.Kilograms);
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="Density" /> from <see cref="Molarity" />.
        /// </summary>
        /// <param name="molarity"></param>
        /// <param name="molecularWeight"></param>
        public static Density FromMolarity(Molarity molarity, Mass molecularWeight)
        {
            return new Density(molarity.MolesPerCubicMeter * molecularWeight.Kilograms, DensityUnit.KilogramPerCubicMeter);
        }

        #endregion

        public static Mass operator *(Density density, Volume volume)
        {
            return Mass.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        public static Mass operator *(Volume volume, Density density)
        {
            return Mass.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        public static DynamicViscosity operator *(Density density, KinematicViscosity kinematicViscosity)
        {
            return DynamicViscosity.FromNewtonSecondsPerMeterSquared(kinematicViscosity.SquareMetersPerSecond * density.KilogramsPerCubicMeter);
        }

        public static MassFlux operator *(Density density, Speed speed)
        {
            return MassFlux.FromKilogramsPerSecondPerSquareMeter(density.KilogramsPerCubicMeter * speed.MetersPerSecond);
        }

        public static SpecificWeight operator *(Density density, Acceleration acceleration)
        {
            return new SpecificWeight(density.KilogramsPerCubicMeter * acceleration.MetersPerSecondSquared, SpecificWeightUnit.NewtonPerCubicMeter);
        }
    }
}
