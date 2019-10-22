// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Volume<T>
    {
        /// <summary>Get <see cref="Area{T}"/> from <see cref="Volume{T}"/> divided by <see cref="Length{T}"/>.</summary>
        public static Area<T> operator /(Volume<T> volume, Length<T> length )
        {
            return Area<T>.FromSquareMeters(volume.CubicMeters / length.Meters);
        }

        /// <summary>Get <see cref="Length{T}"/> from <see cref="Volume{T}"/> divided by <see cref="Area{T}"/>.</summary>
        public static Length<T> operator /(Volume<T> volume, Area<T> area )
        {
            return Length<T>.FromMeters(volume.CubicMeters / area.SquareMeters);
        }

        /// <summary>Get <see cref="VolumeFlow{T}"/> from <see cref="Volume{T}"/> divided by <see cref="Duration{T}"/>.</summary>
        public static VolumeFlow<T> operator /(Volume<T> volume, Duration<T> duration )
        {
            return VolumeFlow<T>.FromCubicMetersPerSecond(volume.CubicMeters / duration.Seconds);
        }

        /// <summary>Get <see cref="VolumeFlow{T}"/> from <see cref="Volume{T}"/> divided by <see cref="TimeSpan"/>.</summary>
        public static VolumeFlow<T> operator /(Volume<T> volume, TimeSpan timeSpan)
        {
            return VolumeFlow<T>.FromCubicMetersPerSecond(volume.CubicMeters / timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="TimeSpan"/> from <see cref="Volume{T}"/> divided by <see cref="VolumeFlow{T}"/>.</summary>
        public static TimeSpan operator /(Volume<T> volume, VolumeFlow<T> volumeFlow )
        {
            return TimeSpan.FromSeconds(volume.CubicMeters / volumeFlow.CubicMetersPerSecond);
        }
    }
}
