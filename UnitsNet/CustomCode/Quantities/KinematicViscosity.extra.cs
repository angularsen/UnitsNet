// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct KinematicViscosity<T>
    {
        /// <summary>Get <see cref="Speed{T}"/> from <see cref="KinematicViscosity{T}"/> divided by <see cref="Length{T}"/>.</summary>
        public static Speed<T> operator /(KinematicViscosity<T> kinematicViscosity, Length<T> length )
        {
            return Speed<T>.FromMetersPerSecond(kinematicViscosity.SquareMetersPerSecond / length.Meters);
        }

        /// <summary>Get <see cref="Area{T}"/> from <see cref="KinematicViscosity{T}"/> times <see cref="TimeSpan"/>.</summary>
        public static Area<T> operator *(KinematicViscosity<T> kinematicViscosity, TimeSpan timeSpan)
        {
            return Area<T>.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Area{T}"/> from <see cref="TimeSpan"/> times <see cref="KinematicViscosity{T}"/>.</summary>
        public static Area<T> operator *(TimeSpan timeSpan, KinematicViscosity<T> kinematicViscosity )
        {
            return Area<T>.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Area{T}"/> from <see cref="KinematicViscosity{T}"/> times <see cref="Duration{T}"/>.</summary>
        public static Area<T> operator *(KinematicViscosity<T> kinematicViscosity, Duration<T> duration )
        {
            return Area<T>.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Area{T}"/> from <see cref="Duration{T}"/> times <see cref="KinematicViscosity{T}"/>.</summary>
        public static Area<T> operator *(Duration<T> duration, KinematicViscosity<T> kinematicViscosity )
        {
            return Area<T>.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="DynamicViscosity{T}"/> from <see cref="KinematicViscosity{T}"/> times <see cref="Density{T}"/>.</summary>
        public static DynamicViscosity<T> operator *(KinematicViscosity<T> kinematicViscosity, Density<T> density )
        {
            return DynamicViscosity<T>.FromNewtonSecondsPerMeterSquared(kinematicViscosity.SquareMetersPerSecond * density.KilogramsPerCubicMeter);
        }
    }
}
