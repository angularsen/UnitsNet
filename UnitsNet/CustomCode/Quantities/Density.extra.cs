// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using UnitsNet.Units;

namespace UnitsNet
{
    public partial struct Density
    {
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

        /// <summary>Get <see cref="LinearDensity"/> from <see cref="Density"/> times <see cref="Area"/>.</summary>
        public static LinearDensity operator *(Density density, Area area)
        {
            return LinearDensity.FromKilogramsPerMeter(density.KilogramsPerCubicMeter * area.SquareMeters);
        }
    }
}
