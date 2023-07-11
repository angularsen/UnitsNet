// Licensed under MIT No Attribution, see LICENSE file at the root.
// Copyright 2013 Andreas Gullberg Larsen (andreas.larsen84@gmail.com). Maintained at https://github.com/angularsen/UnitsNet.

using System;

namespace UnitsNet
{
    public partial struct ElectricCurrentGradient
    {
        /// <summary>Get <see cref="ElectricCurrent"/> from <see cref="ElectricCurrentGradient"/> times <see cref="Duration"/>.</summary>
        public static ElectricCurrent operator *(ElectricCurrentGradient currentGradient, Duration duration)
        {
            return ElectricCurrent.FromAmperes(currentGradient.AmperesPerSecond * duration.Seconds);
        }

        /// <summary>Get <see cref="ElectricCurrent"/> from <see cref="ElectricCurrentGradient"/> times <see cref="TimeSpan"/>.</summary>
        public static ElectricCurrent operator *(ElectricCurrentGradient currentGradient, TimeSpan timeSpan)
        {
            return ElectricCurrent.FromAmperes(currentGradient.AmperesPerSecond * timeSpan.TotalSeconds);
        }
    }
}
