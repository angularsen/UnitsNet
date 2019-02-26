// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Volume
    {
        /// <summary>Get <see cref="Area"/> from <see cref="Volume"/> divided by <see cref="Length"/>.</summary>
        public static Area operator /(Volume volume, Length length)
        {
            return Area.FromSquareMeters(volume.CubicMeters / length.Meters);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="Volume"/> divided by <see cref="Area"/>.</summary>
        public static Length operator /(Volume volume, Area area)
        {
            return Length.FromMeters(volume.CubicMeters / area.SquareMeters);
        }

        /// <summary>Get <see cref="VolumeFlow"/> from <see cref="Volume"/> divided by <see cref="Duration"/>.</summary>
        public static VolumeFlow operator /(Volume volume, Duration duration)
        {
            return VolumeFlow.FromCubicMetersPerSecond(volume.CubicMeters / duration.Seconds);
        }

        /// <summary>Get <see cref="VolumeFlow"/> from <see cref="Volume"/> divided by <see cref="TimeSpan"/>.</summary>
        public static VolumeFlow operator /(Volume volume, TimeSpan timeSpan)
        {
            return VolumeFlow.FromCubicMetersPerSecond(volume.CubicMeters / timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="TimeSpan"/> from <see cref="Volume"/> divided by <see cref="VolumeFlow"/>.</summary>
        public static TimeSpan operator /(Volume volume, VolumeFlow volumeFlow)
        {
            return TimeSpan.FromSeconds(volume.CubicMeters / volumeFlow.CubicMetersPerSecond);
        }
    }
}
