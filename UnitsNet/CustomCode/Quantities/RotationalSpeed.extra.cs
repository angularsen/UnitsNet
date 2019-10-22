// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct RotationalSpeed<T>
    {
        /// <summary>Get <see cref="Angle{T}"/> from <see cref="RotationalSpeed{T}"/> times <see cref="TimeSpan"/>.</summary>
        public static Angle<T> operator *(RotationalSpeed<T> rotationalSpeed, TimeSpan timeSpan )
        {
            return Angle<T>.FromRadians(rotationalSpeed.RadiansPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Angle{T}"/> from <see cref="TimeSpan"/> times <see cref="RotationalSpeed{T}"/>.</summary>
        public static Angle<T> operator *(TimeSpan timeSpan, RotationalSpeed<T> rotationalSpeed )
        {
            return Angle<T>.FromRadians(rotationalSpeed.RadiansPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Angle{T}"/> from <see cref="RotationalSpeed{T}"/> times <see cref="Duration{T}"/>.</summary>
        public static Angle<T> operator *(RotationalSpeed<T> rotationalSpeed, Duration<T> duration )
        {
            return Angle<T>.FromRadians(rotationalSpeed.RadiansPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Angle{T}"/> from <see cref="Duration{T}"/> times <see cref="RotationalSpeed{T}"/>.</summary>
        public static Angle<T> operator *(Duration<T> duration, RotationalSpeed<T> rotationalSpeed )
        {
            return Angle<T>.FromRadians(rotationalSpeed.RadiansPerSecond * duration.Seconds);
        }
    }
}
