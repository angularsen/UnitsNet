// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct RotationalSpeed
    {
        /// <summary>Get <see cref="Angle"/> from <see cref="RotationalSpeed"/> times <see cref="TimeSpan"/>.</summary>
        public static Angle operator *(RotationalSpeed rotationalSpeed, TimeSpan timeSpan)
        {
            return Angle.FromRadians(rotationalSpeed.RadiansPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Angle"/> from <see cref="TimeSpan"/> times <see cref="RotationalSpeed"/>.</summary>
        public static Angle operator *(TimeSpan timeSpan, RotationalSpeed rotationalSpeed)
        {
            return Angle.FromRadians(rotationalSpeed.RadiansPerSecond * timeSpan.TotalSeconds);
        }

        /// <summary>Get <see cref="Angle"/> from <see cref="RotationalSpeed"/> times <see cref="Duration"/>.</summary>
        public static Angle operator *(RotationalSpeed rotationalSpeed, Duration duration)
        {
            return Angle.FromRadians(rotationalSpeed.RadiansPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="Angle"/> from <see cref="Duration"/> times <see cref="RotationalSpeed"/>.</summary>
        public static Angle operator *(Duration duration, RotationalSpeed rotationalSpeed)
        {
            return Angle.FromRadians(rotationalSpeed.RadiansPerSecond * duration.Seconds);
        }
    }
}
