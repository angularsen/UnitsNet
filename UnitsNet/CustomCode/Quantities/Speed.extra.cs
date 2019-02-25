// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Speed
    {
        public static Acceleration operator /(Speed speed, TimeSpan timeSpan)
        {
            return Acceleration.FromMetersPerSecondSquared(speed.MetersPerSecond / timeSpan.TotalSeconds);
        }

        public static Length operator *(Speed speed, TimeSpan timeSpan)
        {
            return Length.FromMeters(speed.MetersPerSecond * timeSpan.TotalSeconds);
        }

        public static Length operator *(TimeSpan timeSpan, Speed speed)
        {
            return Length.FromMeters(speed.MetersPerSecond * timeSpan.TotalSeconds);
        }

        public static Acceleration operator /(Speed speed, Duration duration)
        {
            return Acceleration.FromMetersPerSecondSquared(speed.MetersPerSecond / duration.Seconds);
        }

        public static Length operator *(Speed speed, Duration duration)
        {
            return Length.FromMeters(speed.MetersPerSecond * duration.Seconds);
        }

        public static Length operator *(Duration duration, Speed speed)
        {
            return Length.FromMeters(speed.MetersPerSecond * duration.Seconds);
        }

        public static KinematicViscosity operator *(Speed speed, Length length)
        {
            return KinematicViscosity.FromSquareMetersPerSecond(length.Meters * speed.MetersPerSecond);
        }

        public static SpecificEnergy operator *(Speed left, Speed right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.MetersPerSecond * right.MetersPerSecond);
        }

        public static MassFlux operator *(Speed speed, Density density)
        {
            return MassFlux.FromKilogramsPerSecondPerSquareMeter(speed.MetersPerSecond * density.KilogramsPerCubicMeter);
        }

        public static VolumeFlow operator *(Speed speed, Area area)
        {
            return VolumeFlow.FromCubicMetersPerSecond(speed.MetersPerSecond * area.SquareMeters);
        }
    }
}
