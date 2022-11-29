// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct TemperatureChangeRate
    {
        /// <summary>Get <see cref="TemperatureDelta"/> from <see cref="Duration"/> times <see cref="TemperatureChangeRate"/>.</summary>
        public static TemperatureDelta operator *(Duration left, TemperatureChangeRate right) => right * left;

        /// <summary>Get <see cref="TemperatureDelta"/> from <see cref="TemperatureChangeRate"/> times <see cref="Duration"/>.</summary>
        public static TemperatureDelta operator *(TemperatureChangeRate left, Duration right)
        {
            return TemperatureDelta.FromDegreesCelsius(left.DegreesCelsiusPerSecond * right.Seconds);
        }


        /// <summary>Get <see cref="TemperatureDelta"/> from <see cref="TimeSpan"/> times <see cref="TemperatureChangeRate"/>.</summary>
        public static TemperatureDelta operator *(TimeSpan left, TemperatureChangeRate right) => right * left;

        /// <summary>Get <see cref="TemperatureDelta"/> from <see cref="TemperatureChangeRate"/> times <see cref="TimeSpan"/>.</summary>
        public static TemperatureDelta operator *(TemperatureChangeRate left, TimeSpan right)
        {
            return TemperatureDelta.FromDegreesCelsius(left.DegreesCelsiusPerSecond * right.TotalSeconds);
        }
    }
}
