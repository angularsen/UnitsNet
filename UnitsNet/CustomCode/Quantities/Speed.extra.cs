// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Speed<T>
    {
        /// <summary>Get <see cref="Acceleration{T}"/> from <see cref="Speed{T}"/> divided by <see cref="TimeSpan"/>.</summary>
        public static Acceleration<T> operator /(Speed<T> speed, TimeSpan timeSpan )
        {
            return Acceleration<T>.FromMetersPerSecondSquared(speed.MetersPerSecond / timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Length{T}"/> from <see cref="Speed{T}"/> times <see cref="TimeSpan"/>.</summary>
        public static Length<T> operator *(Speed<T> speed, TimeSpan timeSpan)
        {
            return Length<T>.FromMeters(speed.MetersPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Length{T}"/> from <see cref="TimeSpan"/> times <see cref="Speed{T}"/>.</summary>
        public static Length<T> operator *(TimeSpan timeSpan, Speed<T> speed )
        {
            return Length<T>.FromMeters(speed.MetersPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Acceleration{T}"/> from <see cref="Speed{T}"/> divided by <see cref="Duration{T}"/>.</summary>
        public static Acceleration<T> operator /(Speed<T> speed, Duration<T> duration )
        {
            return Acceleration<T>.FromMetersPerSecondSquared(speed.MetersPerSecond / duration.Seconds);
        }

        /// <summary>Get <see cref="Length{T}"/> from <see cref="Speed{T}"/> times <see cref="Duration{T}"/>.</summary>
        public static Length<T> operator *(Speed<T> speed, Duration<T> duration )
        {
            return Length<T>.FromMeters(speed.MetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Length{T}"/> from <see cref="Duration{T}"/> times <see cref="Speed{T}"/>.</summary>
        public static Length<T> operator *(Duration<T> duration, Speed<T> speed )
        {
            return Length<T>.FromMeters(speed.MetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="KinematicViscosity{T}"/> from <see cref="Speed{T}"/> times <see cref="Length{T}"/>.</summary>
        public static KinematicViscosity<T> operator *(Speed<T> speed, Length<T> length )
        {
            return KinematicViscosity<T>.FromSquareMetersPerSecond(length.Meters * speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="SpecificEnergy{T}"/> from <see cref="Speed{T}"/> times <see cref="Speed{T}"/>.</summary>
        public static SpecificEnergy<T> operator *(Speed<T> left, Speed<T> right )
        {
            return SpecificEnergy<T>.FromJoulesPerKilogram(left.MetersPerSecond * right.MetersPerSecond);
        }

        /// <summary>Get <see cref="MassFlux{T}"/> from <see cref="Speed{T}"/> times <see cref="Density{T}"/>.</summary>
        public static MassFlux<T> operator *(Speed<T> speed, Density<T> density )
        {
            return MassFlux<T>.FromKilogramsPerSecondPerSquareMeter(speed.MetersPerSecond * density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="VolumeFlow{T}"/> from <see cref="Speed{T}"/> times <see cref="Area{T}"/>.</summary>
        public static VolumeFlow<T> operator *(Speed<T> speed, Area<T> area )
        {
            return VolumeFlow<T>.FromCubicMetersPerSecond(speed.MetersPerSecond * area.SquareMeters);
        }
    }
}
