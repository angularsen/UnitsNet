// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct VolumeFlow<T>
    {
        /// <summary>Get <see cref="Volume{T}"/> from <see cref="VolumeFlow{T}"/> times <see cref="TimeSpan"/>.</summary>
        public static Volume<T> operator *(VolumeFlow<T> volumeFlow, TimeSpan timeSpan)
        {
            return Volume<T>.FromCubicMeters(volumeFlow.CubicMetersPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Volume{T}"/> from <see cref="VolumeFlow{T}"/> times <see cref="Duration{T}"/>.</summary>
        public static Volume<T> operator *(VolumeFlow<T> volumeFlow, Duration<T> duration )
        {
            return Volume<T>.FromCubicMeters(volumeFlow.CubicMetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Speed{T}"/> from <see cref="VolumeFlow{T}"/> divided by <see cref="Area{T}"/>.</summary>
        public static Speed<T> operator /(VolumeFlow<T> volumeFlow, Area<T> area )
        {
            return Speed<T>.FromMetersPerSecond(volumeFlow.CubicMetersPerSecond / area.SquareMeters);
        }

        /// <summary>Get <see cref="Area{T}"/> from <see cref="VolumeFlow{T}"/> divided by <see cref="Speed{T}"/>.</summary>
        public static Area<T> operator /(VolumeFlow<T> volumeFlow, Speed<T> speed )
        {
            return Area<T>.FromSquareMeters(volumeFlow.CubicMetersPerSecond / speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="MassFlow{T}"/> from <see cref="VolumeFlow{T}"/> times <see cref="Density{T}"/>.</summary>
        public static MassFlow<T> operator *(VolumeFlow<T> volumeFlow, Density<T> density )
        {
            return MassFlow<T>.FromKilogramsPerSecond(volumeFlow.CubicMetersPerSecond * density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="MassFlow{T}"/> from <see cref="Density{T}"/> times <see cref="VolumeFlow{T}"/>.</summary>
        public static MassFlow<T> operator *(Density<T> density, VolumeFlow<T> volumeFlow )
        {
            return MassFlow<T>.FromKilogramsPerSecond(volumeFlow.CubicMetersPerSecond * density.KilogramsPerCubicMeter);
        }
    }
}
