// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Volume
    {
        public static Area operator /(Volume volume, Length length)
        {
            return Area.FromSquareMeters(volume.CubicMeters / length.Meters);
        }

        public static Length operator /(Volume volume, Area area)
        {
            return Length.FromMeters(volume.CubicMeters / area.SquareMeters);
        }

        public static VolumeFlow operator /(Volume volume, Duration duration)
        {
            return VolumeFlow.FromCubicMetersPerSecond(volume.CubicMeters / duration.Seconds);
        }

        public static VolumeFlow operator /(Volume volume, TimeSpan timeSpan)
        {
            return VolumeFlow.FromCubicMetersPerSecond(volume.CubicMeters / timeSpan.TotalSeconds);
        }

        public static TimeSpan operator /(Volume volume, VolumeFlow volumeFlow)
        {
            return TimeSpan.FromSeconds(volume.CubicMeters / volumeFlow.CubicMetersPerSecond);
        }
    }
}
