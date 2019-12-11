// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct KinematicViscosity
    {
        /// <summary>Get <see cref="Speed"/> from <see cref="KinematicViscosity"/> divided by <see cref="Length"/>.</summary>
        public static Speed operator /(KinematicViscosity kinematicViscosity, Length length)
        {
            return Speed.FromMetersPerSecond(kinematicViscosity.SquareMetersPerSecond / length.Meters);
        }

        /// <summary>Get <see cref="Area"/> from <see cref="KinematicViscosity"/> times <see cref="TimeSpan"/>.</summary>
        public static Area operator *(KinematicViscosity kinematicViscosity, TimeSpan timeSpan)
        {
            return Area.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Area"/> from <see cref="TimeSpan"/> times <see cref="KinematicViscosity"/>.</summary>
        public static Area operator *(TimeSpan timeSpan, KinematicViscosity kinematicViscosity)
        {
            return Area.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Area"/> from <see cref="KinematicViscosity"/> times <see cref="Duration"/>.</summary>
        public static Area operator *(KinematicViscosity kinematicViscosity, Duration duration)
        {
            return Area.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Area"/> from <see cref="Duration"/> times <see cref="KinematicViscosity"/>.</summary>
        public static Area operator *(Duration duration, KinematicViscosity kinematicViscosity)
        {
            return Area.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="DynamicViscosity"/> from <see cref="KinematicViscosity"/> times <see cref="Density"/>.</summary>
        public static DynamicViscosity operator *(KinematicViscosity kinematicViscosity, Density density)
        {
            return DynamicViscosity.FromNewtonSecondsPerMeterSquared(kinematicViscosity.SquareMetersPerSecond * density.KilogramsPerCubicMeter);
        }
    }
}
