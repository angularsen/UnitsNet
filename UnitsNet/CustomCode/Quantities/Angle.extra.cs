// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Angle<T>
    {
        /// <summary>Get <see cref="RotationalSpeed{T}"/> from <see cref="Angle{T}"/> delta over time delta.</summary>
        public static RotationalSpeed<T> operator /(Angle<T> angle, TimeSpan timeSpan )
        {
            return RotationalSpeed<T>.FromRadiansPerSecond(angle.Radians / timeSpan.TotalSeconds);
        }

        /// <inheritdoc cref="op_Division(UnitsNet.Angle{T}, System.TimeSpan)" />
        public static RotationalSpeed<T> operator /(Angle<T> angle, Duration<T> duration )
        {
            return RotationalSpeed<T>.FromRadiansPerSecond(angle.Radians / duration.Seconds);
        }
    }
}
