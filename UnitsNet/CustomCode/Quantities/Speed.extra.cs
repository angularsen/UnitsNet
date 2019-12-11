// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Speed
    {
        /// <summary>Get <see cref="Acceleration"/> from <see cref="Speed"/> divided by <see cref="TimeSpan"/>.</summary>
        public static Acceleration operator /(Speed speed, TimeSpan timeSpan)
        {
            return Acceleration.FromMetersPerSecondSquared(speed.MetersPerSecond / timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="Speed"/> times <see cref="TimeSpan"/>.</summary>
        public static Length operator *(Speed speed, TimeSpan timeSpan)
        {
            return Length.FromMeters(speed.MetersPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="TimeSpan"/> times <see cref="Speed"/>.</summary>
        public static Length operator *(TimeSpan timeSpan, Speed speed)
        {
            return Length.FromMeters(speed.MetersPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Acceleration"/> from <see cref="Speed"/> divided by <see cref="Duration"/>.</summary>
        public static Acceleration operator /(Speed speed, Duration duration)
        {
            return Acceleration.FromMetersPerSecondSquared(speed.MetersPerSecond / duration.Seconds);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="Speed"/> times <see cref="Duration"/>.</summary>
        public static Length operator *(Speed speed, Duration duration)
        {
            return Length.FromMeters(speed.MetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Length"/> from <see cref="Duration"/> times <see cref="Speed"/>.</summary>
        public static Length operator *(Duration duration, Speed speed)
        {
            return Length.FromMeters(speed.MetersPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="KinematicViscosity"/> from <see cref="Speed"/> times <see cref="Length"/>.</summary>
        public static KinematicViscosity operator *(Speed speed, Length length)
        {
            return KinematicViscosity.FromSquareMetersPerSecond(length.Meters * speed.MetersPerSecond);
        }

        /// <summary>Get <see cref="SpecificEnergy"/> from <see cref="Speed"/> times <see cref="Speed"/>.</summary>
        public static SpecificEnergy operator *(Speed left, Speed right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.MetersPerSecond * right.MetersPerSecond);
        }

        /// <summary>Get <see cref="MassFlux"/> from <see cref="Speed"/> times <see cref="Density"/>.</summary>
        public static MassFlux operator *(Speed speed, Density density)
        {
            return MassFlux.FromKilogramsPerSecondPerSquareMeter(speed.MetersPerSecond * density.KilogramsPerCubicMeter);
        }

        /// <summary>Get <see cref="VolumeFlow"/> from <see cref="Speed"/> times <see cref="Area"/>.</summary>
        public static VolumeFlow operator *(Speed speed, Area area)
        {
            return VolumeFlow.FromCubicMetersPerSecond(speed.MetersPerSecond * area.SquareMeters);
        }
    }
}
