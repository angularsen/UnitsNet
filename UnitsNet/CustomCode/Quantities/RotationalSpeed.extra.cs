// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct RotationalSpeed
    {
        public static Angle operator *(RotationalSpeed rotationalSpeed, TimeSpan timeSpan)
        {
            return Angle.FromRadians(rotationalSpeed.RadiansPerSecond * timeSpan.TotalSeconds);
        }

        public static Angle operator *(TimeSpan timeSpan, RotationalSpeed rotationalSpeed)
        {
            return Angle.FromRadians(rotationalSpeed.RadiansPerSecond * timeSpan.TotalSeconds);
        }

        public static Angle operator *(RotationalSpeed rotationalSpeed, Duration duration)
        {
            return Angle.FromRadians(rotationalSpeed.RadiansPerSecond * duration.Seconds);
        }

        public static Angle operator *(Duration duration, RotationalSpeed rotationalSpeed)
        {
            return Angle.FromRadians(rotationalSpeed.RadiansPerSecond * duration.Seconds);
        }
    }
}
