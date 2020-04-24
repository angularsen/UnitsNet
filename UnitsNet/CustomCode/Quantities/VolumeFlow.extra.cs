// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct VolumeFlow
    {
        /// <summary>Get <see cref="Volume"/> from <see cref="VolumeFlow"/> times <see cref="TimeSpan"/>.</summary>
        public static Volume operator *(VolumeFlow volumeFlow, TimeSpan timeSpan)
        {
            return Volume.FromCubicMeters(volumeFlow.CubicMetersPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Volume"/> from <see cref="VolumeFlow"/> times <see cref="Duration"/>.</summary>
        public static Volume operator *(VolumeFlow volumeFlow, Duration duration)
        {
            return Volume.FromCubicMeters(volumeFlow.CubicMetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Speed"/> from <see cref="VolumeFlow"/> divided by <see cref="Area"/>.</summary>
        public static Speed operator /(VolumeFlow volumeFlow, Area area)
        {
            return Speed.FromMetersPerSecond(volumeFlow.CubicMetersPerSecond / area.SquareMeters);
        }

        /// <summary>Get <see cref="Area"/> from <see cref="VolumeFlow"/> divided by <see cref="Speed"/>.</summary>
        public static Area operator /(VolumeFlow volumeFlow, Speed speed)
        {
            return Area.FromSquareMeters(volumeFlow.CubicMetersPerSecond / speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="MassFlow"/> from <see cref="VolumeFlow"/> times <see cref="Density"/>.</summary>
        public static MassFlow operator *(VolumeFlow volumeFlow, Density density)
        {
            return MassFlow.FromKilogramsPerSecond(volumeFlow.CubicMetersPerSecond * density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="MassFlow"/> from <see cref="Density"/> times <see cref="VolumeFlow"/>.</summary>
        public static MassFlow operator *(Density density, VolumeFlow volumeFlow)
        {
            return MassFlow.FromKilogramsPerSecond(volumeFlow.CubicMetersPerSecond * density.KilogramsPerCubicMeter);
        }
    }
}
