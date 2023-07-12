// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct PressureChangeRate
    {
        /// <summary>Get <see cref="Pressure"/> from <see cref="PressureChangeRate"/> times <see cref="TimeSpan"/> </summary>
        public static Pressure operator *(PressureChangeRate pressureChangeRate, TimeSpan timeSpan)
        {
            return new Pressure(pressureChangeRate.PascalsPerSecond * timeSpan.TotalSeconds , UnitsNet.Units.PressureUnit.Pascal);
        }

        /// <summary>Get <see cref="Pressure"/> from <see cref="PressureChangeRate"/> times <see cref="Duration"/> </summary>
        public static Pressure operator *(PressureChangeRate pressureChangeRate, Duration duration)
        {
            return new Pressure(pressureChangeRate.PascalsPerSecond * duration.Seconds, UnitsNet.Units.PressureUnit.Pascal);
        }
    }
}
