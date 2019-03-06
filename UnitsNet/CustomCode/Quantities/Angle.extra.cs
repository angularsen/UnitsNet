// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct Angle
    {
        /// <summary>Get <see cref="RotationalSpeed"/> from <see cref="Angle"/> delta over time delta.</summary>
        public static RotationalSpeed operator /(Angle angle, TimeSpan timeSpan)
        {
            return RotationalSpeed.FromRadiansPerSecond(angle.Radians / timeSpan.TotalSeconds);
        }

        /// <inheritdoc cref="op_Division(UnitsNet.Angle,System.TimeSpan)" />
        public static RotationalSpeed operator /(Angle angle, Duration duration)
        {
            return RotationalSpeed.FromRadiansPerSecond(angle.Radians / duration.Seconds);
        }
    }
}
