// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct LinearDensity
    {

        /// <summary>Get <see cref="Density"/> from <see cref="LinearDensity"/> times <see cref="Area"/>.</summary>
        public static Density operator /(LinearDensity linearDensity, Area area)
        {
            return Density.FromKilogramsPerCubicMeter(linearDensity.KilogramsPerMeter / area.SquareMeters);
        }

        /// <summary>Get <see cref="Area"/> from <see cref="LinearDensity"/> times <see cref="Density"/>.</summary>
        public static Area operator /(LinearDensity linearDensity, Density density)
        {
            return Area.FromSquareMeters(linearDensity.KilogramsPerMeter / density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="Mass"/> from <see cref="LinearDensity"/> times <see cref="Length"/>.</summary>
        public static Mass operator *(LinearDensity linearDensity, Length length)
        {
            return Mass.FromKilograms(linearDensity.KilogramsPerMeter * length.Meters);
        }
    }
}
