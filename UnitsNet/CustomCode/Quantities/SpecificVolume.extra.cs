// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct SpecificVolume
    {
        /// <summary>Get <see cref="Density"/> from <see cref="double"/> divided by <see cref="SpecificVolume"/>.</summary>
        public static Density operator /(double constant, SpecificVolume volume)
        {
            return Density.FromKilogramsPerCubicMeter(constant / volume.CubicMetersPerKilogram);
        }

        /// <summary>Get <see cref="Volume"/> from <see cref="SpecificVolume"/> times <see cref="Mass"/>.</summary>
        public static Volume operator *(SpecificVolume volume, Mass mass)
        {
            return Volume.FromCubicMeters(volume.CubicMetersPerKilogram * mass.Kilograms);
        }
    }
}
