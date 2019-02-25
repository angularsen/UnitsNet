// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct KinematicViscosity
    {
        public static Speed operator /(KinematicViscosity kinematicViscosity, Length length)
        {
            return Speed.FromMetersPerSecond(kinematicViscosity.SquareMetersPerSecond / length.Meters);
        }

        public static Area operator *(KinematicViscosity kinematicViscosity, TimeSpan timeSpan)
        {
            return Area.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * timeSpan.TotalSeconds);
        }

        public static Area operator *(TimeSpan timeSpan, KinematicViscosity kinematicViscosity)
        {
            return Area.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * timeSpan.TotalSeconds);
        }

        public static Area operator *(KinematicViscosity kinematicViscosity, Duration duration)
        {
            return Area.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * duration.Seconds);
        }

        public static Area operator *(Duration duration, KinematicViscosity kinematicViscosity)
        {
            return Area.FromSquareMeters(kinematicViscosity.SquareMetersPerSecond * duration.Seconds);
        }

        public static DynamicViscosity operator *(KinematicViscosity kinematicViscosity, Density density)
        {
            return DynamicViscosity.FromNewtonSecondsPerMeterSquared(kinematicViscosity.SquareMetersPerSecond * density.KilogramsPerCubicMeter);
        }
    }
}
