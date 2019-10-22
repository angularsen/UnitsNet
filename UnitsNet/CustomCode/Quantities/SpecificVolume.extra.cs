// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

namespace UnitsNet
{
    public partial struct SpecificVolume<T>
    {
        /// <summary>Get <see cref="Density{T}"/> from <see cref="double"/> divided by <see cref="SpecificVolume{T}"/>.</summary>
        public static Density<T> operator /(double constant, SpecificVolume<T> volume )
        {
            return Density<T>.FromKilogramsPerCubicMeter(constant / volume.CubicMetersPerKilogram);
        }

        /// <summary>Get <see cref="Volume{T}"/> from <see cref="SpecificVolume{T}"/> times <see cref="Mass{T}"/>.</summary>
        public static Volume<T> operator *(SpecificVolume<T> volume, Mass<T> mass )
        {
            return Volume<T>.FromCubicMeters(volume.CubicMetersPerKilogram * mass.Kilograms);
        }
    }
}
