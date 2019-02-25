// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct VolumeFlow
    {
        public static Volume operator *(VolumeFlow volumeFlow, TimeSpan timeSpan)
        {
            return Volume.FromCubicMeters(volumeFlow.CubicMetersPerSecond * timeSpan.TotalSeconds);
        }

        public static Volume operator *(VolumeFlow volumeFlow, Duration duration)
        {
            return Volume.FromCubicMeters(volumeFlow.CubicMetersPerSecond * duration.Seconds);
        }

        public static Speed operator /(VolumeFlow volumeFlow, Area area)
        {
            return Speed.FromMetersPerSecond(volumeFlow.CubicMetersPerSecond / area.SquareMeters);
        }

        public static Area operator /(VolumeFlow volumeFlow, Speed speed)
        {
            return Area.FromSquareMeters(volumeFlow.CubicMetersPerSecond / speed.MetersPerSecond);
        }

        public static MassFlow operator *(VolumeFlow volumeFlow, Density density)
        {
            return MassFlow.FromKilogramsPerSecond(volumeFlow.CubicMetersPerSecond * density.KilogramsPerCubicMeter);
        }

        public static MassFlow operator *(Density density, VolumeFlow volumeFlow)
        {
            return MassFlow.FromKilogramsPerSecond(volumeFlow.CubicMetersPerSecond * density.KilogramsPerCubicMeter);
        }
    }
}
