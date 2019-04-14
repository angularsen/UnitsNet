// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;
using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Density
    {
        /// <summary>
        ///     Gets <see cref="Molarity" /> from this <see cref="Density" />.
        /// </summary>
        /// <param name="molecularWeight"></param>
        /// <seealso cref="MassConcentration.ToMolarity(MolarMass)"/>
        [Obsolete("This method is deprecated in favor of MassConcentration.ToMolarity(MolarMass).")]
        public Molarity ToMolarity(Mass molecularWeight)
        {
            return Molarity.FromMolesPerCubicMeter(KilogramsPerCubicMeter / molecularWeight.Kilograms);
        }

        #region Static Methods

        /// <summary>
        ///     Get <see cref="Density" /> from <see cref="Molarity" />.
        /// </summary>
        /// <seealso cref="MassConcentration.FromMolarity(Molarity, MolarMass)"/>
        [Obsolete("This method is deprecated in favor of MassConcentration.FromMolarity(Molarity, MolarMass).")]
        public static Density FromMolarity(Molarity molarity, Mass molecularWeight)
        {
            return new Density(molarity.MolesPerCubicMeter * molecularWeight.Kilograms, DensityUnit.KilogramPerCubicMeter);
        }

        #endregion

        /// <summary>Get <see cref="Mass"/> from <see cref="Density"/> times <see cref="Volume"/>.</summary>
        public static Mass operator *(Density density, Volume volume)
        {
            return Mass.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        /// <summary>Get <see cref="Mass"/> from <see cref="Volume"/> times <see cref="Density"/>.</summary>
        public static Mass operator *(Volume volume, Density density)
        {
            return Mass.FromKilograms(density.KilogramsPerCubicMeter * volume.CubicMeters);
        }

        /// <summary>Get <see cref="DynamicViscosity"/> from <see cref="Density"/> times <see cref="KinematicViscosity"/>.</summary>
        public static DynamicViscosity operator *(Density density, KinematicViscosity kinematicViscosity)
        {
            return DynamicViscosity.FromNewtonSecondsPerMeterSquared(kinematicViscosity.SquareMetersPerSecond * density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="MassFlux"/> <see cref="Density"/> times <see cref="Speed"/>.</summary>
        public static MassFlux operator *(Density density, Speed speed)
        {
            return MassFlux.FromKilogramsPerSecondPerSquareMeter(density.KilogramsPerCubicMeter * speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="SpecificWeight"/> from <see cref="Density"/> times <see cref="Acceleration"/>.</summary>
        public static SpecificWeight operator *(Density density, Acceleration acceleration)
        {
            return new SpecificWeight(density.KilogramsPerCubicMeter * acceleration.MetersPerSecondSquared, SpecificWeightUnit.NewtonPerCubicMeter);
        }

        /// <summary>Get <see cref="Molarity"/> from <see cref="Density"/> divided by <see cref="Mass"/>.</summary>
        /// <seealso cref="MassConcentration.op_Division(MassConcentration, MolarMass)"/>
        [Obsolete("This operator is deprecated in favor of MassConcentration.op_Division(MassConcentration, MolarMass).")]
        public static Molarity operator /(Density density, Mass molecularWeight)
        {
            return new Molarity(density.KilogramsPerCubicMeter / molecularWeight.Kilograms, MolarityUnit.MolesPerCubicMeter);
        }
    }
}
